module Store

open Fetch
open Feliz
open Browser

open Pages
open Theme

type Documentation = Page * string

type Store =
    { Documents: Documentation list
      Theme: Theme
      ShowSidebar: bool
    }

type StoreAction =
    | SetDocumentation of Documentation list
    | AddDocument of Documentation
    | SetTheme of Theme
    | ToggleSidebar

let tryGetDocumentation store (page: Page) =
    List.tryFind (fun (p, _) -> p = page) store.Documents

let StoreReducer state action =
    match action with
    | SetDocumentation documents -> { state with Documents = documents }
    | AddDocument document ->
        let newDocuments = document :: state.Documents
        { state with Documents = newDocuments }
    | SetTheme theme ->
        let themeName =
            if theme = LightTheme then
                "light"
            else
                "dark"
        window.localStorage.setItem("theme", themeName)
        { state with Theme = theme }
    | ToggleSidebar ->
        { state with ShowSidebar = not state.ShowSidebar }

let initialStore =
    { Documents =
           [ (Page.Unknown, "Unknown")
             (NotFound, "NotFound") ]
      Theme = initialTheme
      ShowSidebar = false
    }

let storeContext = React.createContext ()

[<ReactComponent>]
let StoreProvider children =
    let state, dispatch = React.useReducer (StoreReducer, initialStore)
    React.contextProvider (storeContext, (state, dispatch), React.fragment [ children ])

[<Hook>]
let useStore () = React.useContext storeContext

[<Hook>]
let useFetchStore page setState =
    let store, dispatch = useStore ()

    React.useEffect (
        (fun () ->
            match tryGetDocumentation store page with
            | None ->
                promise {
                    let pageUri = pageToString page
                    let! response =
                        fetch
                            $"https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/documentation/{pageUri}.md"
                            []

                    let! text = response.text ()
                    let document = Documentation(page, text)
                    do dispatch <| AddDocument document
                    do setState (Some document)
                }
                |> Promise.start
            | Some documentation -> setState (Some documentation)),
        [| page :> obj
           store :> obj
           dispatch :> obj |]
    )
