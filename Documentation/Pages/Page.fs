module Page

open Fss
open Feliz
open Fable.Core.JsInterop

open Store

[<ReactComponent>]
let Page page styles =
    let state, setState =
        React.useState<Documentation option> None

    useFetchStore page setState
    let store, _ = useStore()

    let dark:obj = import "dark" "react-syntax-highlighter/dist/esm/styles/hljs"
    let light:obj = import "docco" "react-syntax-highlighter/dist/esm/styles/hljs"

    let style =
        if store.Theme = Theme.LightTheme then
            light
        else
            dark

    let rec markdownAndExamples (markdown: string) (examples: ReactElement list) : ReactElement =
        let splitMarkdown =
            markdown.Split "<example/>"
            |> Seq.toList
            |> List.map (fun s -> ReactMarkdown.ReactMarkdown style s)

        if List.length splitMarkdown > List.length examples then
            Html.div [ markdownAndExamples markdown (examples @ [ Html.none ]) ]
        else
            Html.div [ prop.children (
                           List.zip splitMarkdown examples
                           |> List.collect (fun (a, b) -> [ a; b ])
                       ) ]

    match state with
    | Some (_, documentation) -> markdownAndExamples documentation styles
    | None -> Spinner()
