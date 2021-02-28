 namespace Docs


 module Markdown =
    open Fable.Core.JS
    open Fable.Core.JsInterop
    open Fable.React

    let darcula:obj = importMember "react-syntax-highlighter/dist/styles/prism"
    let fsharp:obj = importMember "react-syntax-highlighter/dist/languages/prism"

    type HighlightProps =
        | Language of string
        | Children of string
        | ShowLineNumbers of bool
        | Style of obj

    let syntaxHighlighter (props: HighlightProps list): ReactElement =
        printfn "SYNTAX HIGHLIGHTER FOO"
        let propsObject = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-syntax-highlighter" propsObject []

    type MarkdownProps =
        | Children of string
        | Renderers of obj

    type Renderer =
        { language: string
          value: string }

    let renderers =
        printfn "RENDERERS FOO"
        createObj [ "code" ==> fun (a: Renderer) ->
            printfn "%A" <| JSON.stringify a
            printfn "CREATING A SYNTAX HIGHLIGGHTER IN A FUNCTION FOO"
            syntaxHighlighter [ Language a.language; HighlightProps.Children a.value; ShowLineNumbers true ] ]

    let reactMarkdown (props: MarkdownProps list): ReactElement =
        printfn "REACT MARKDOWN FOO"
        let propsObject = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-markdown" propsObject []