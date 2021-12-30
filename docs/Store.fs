module Store

open Feliz

open Pages

type Documentation = Page * string

type Store = { Documents: Documentation list
               ShowSidebar: bool }

type StoreAction =
    | SetDocumentation of Documentation list
    | AddDocument of Documentation
    | ToggleSidebar

let tryGetDocumentation store (page: Page) =
    List.tryFind (fun (p, _) -> p = page) store.Documents

let StoreReducer state action =
    match action with
    | SetDocumentation documents -> { state with Documents = documents }
    | AddDocument document ->
        let newDocuments = document :: state.Documents

        { state with Documents = newDocuments }
    | ToggleSidebar ->
        { state with ShowSidebar = not state.ShowSidebar }

let initialStore =
    { Documents =
          [ (Unknown, "Unknown")
            (NotFound, "NotFound") ]
      ShowSidebar = false}

let storeContext = React.createContext()

[<ReactComponent>]
let StoreProvider children =
    let state, dispatch = React.useReducer(StoreReducer, initialStore)
    React.contextProvider(storeContext, (state, dispatch), React.fragment [children])

[<Hook>]
let useStore() =
   React.useContext(storeContext)