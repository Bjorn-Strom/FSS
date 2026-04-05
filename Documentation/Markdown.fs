[<AutoOpen>]
module Markdown

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

module ReactSyntaxHighlighter =
    [<Import("Light","react-syntax-highlighter")>]
    module import =
        let registerLanguage(language: string) (languageObject: obj) = jsNative

    type Props =
        | Children of string
        | Language of string
        | Style of obj
        | ShowLineNumbers of bool

    let Component (props: Props list): ReactElement =
        let props = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-syntax-highlighter" props []

module ReactMarkdown =
    type Props =
        | Children of string
        | Components of obj

    let Component (props: Props list): ReactElement =
        let props = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-markdown" props []

    type Renderer =
        {   className: string
            children: string
            ``inline``: bool
        }

    let private renderer style =
        createObj [ "code" ==> fun (renderer: Renderer) ->
            if isNullOrUndefined renderer.className then
                Html.code renderer.children
            else
                let language = (renderer.className.Split "-")[1]
                ReactSyntaxHighlighter.Component [
                                    ReactSyntaxHighlighter.Language language
                                    ReactSyntaxHighlighter.Children renderer.children
                                    ReactSyntaxHighlighter.ShowLineNumbers true
                                    ReactSyntaxHighlighter.Style style ] ]


    let ReactMarkdown style (markdown: string) =
        Component [
            Children markdown
            Components (renderer style)
        ]


let fsharp:obj = importDefault "react-syntax-highlighter/dist/esm/languages/hljs/fsharp"
let css:obj = importDefault "react-syntax-highlighter/dist/esm/languages/hljs/css"

ReactSyntaxHighlighter.import.registerLanguage "fsharp" fsharp
ReactSyntaxHighlighter.import.registerLanguage "css" css
