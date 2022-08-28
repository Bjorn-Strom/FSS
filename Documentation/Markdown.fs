[<AutoOpen>]
module Markdown

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

module ReactSyntaxHighlighter =
    [<Import("PrismLight","react-syntax-highlighter")>]
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
        }

    let private renderer =
        createObj [ "code" ==> fun (renderer: Renderer) ->
            let language = (renderer.className.Split "-")[1]
            ReactSyntaxHighlighter.Component [
                                ReactSyntaxHighlighter.Language language
                                ReactSyntaxHighlighter.Children renderer.children
                                ReactSyntaxHighlighter.ShowLineNumbers true ] ]
    //                            Style style ] ]


    let ReactMarkdown (markdown: string) =
        Component [
            Children markdown
            Components renderer
        ]


// Todo:
//let style:obj = import "oneDark" "react-syntax-highlighter/dist/cjs/styles/prism"
let fsharp:obj = importDefault "react-syntax-highlighter/dist/cjs/languages/prism/fsharp"
let css:obj = importDefault "react-syntax-highlighter/dist/cjs/languages/prism/css"

ReactSyntaxHighlighter.import.registerLanguage "fsharp" fsharp
ReactSyntaxHighlighter.import.registerLanguage "css" css
