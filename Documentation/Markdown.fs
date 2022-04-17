module Markdown
 
open Feliz
open Fable.Core
open Fable.React
open Fable.Core.JsInterop

type MarkdownProps =
    | Children of string
    | Renderers of obj
type Renderer =
    { language: string
      value: string }

let markdown (props: MarkdownProps list): ReactElement =
    let propsObject = keyValueList CaseRules.LowerFirst props
    ofImport "default" "react-markdown" propsObject []

let markdownDefaultRenderer (markdownText: string) =
    markdown [ Children markdownText ]
    
let rec markdownAndExamples (markdown: string) (examples: ReactElement list): ReactElement =
    let splitMarkdown =
        markdown.Split "<example/>"
        |> Seq.toList
        |> List.map markdownDefaultRenderer

    if List.length splitMarkdown > List.length examples then
        Html.div [
            markdownAndExamples markdown (examples @ [ Html.none ])
        ]
    else
        Html.div [
            prop.children
                (List.zip splitMarkdown examples
                |> List.collect (fun (a, b) -> [ a; b ]))
        ]
            
            