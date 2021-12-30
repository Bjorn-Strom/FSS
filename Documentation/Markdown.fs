 namespace Documentation


 module Markdown =
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    let style:obj = import "xonokai" "react-syntax-highlighter/dist/cjs/styles/prism"

    type HighlightProps =
        | Language of string
        | Children of string
        | ShowLineNumbers of bool
        | Style of obj

    let syntaxHighlighter (props: HighlightProps list): ReactElement =
        let propsObject = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-syntax-highlighter" propsObject []

    type MarkdownProps =
        | Children of string
        | Renderers of obj
    type Renderer =
        { language: string
          value: string }

    let private renderers =
        createObj [ "code" ==> fun (renderer: Renderer) ->
            syntaxHighlighter [ Language renderer.language; HighlightProps.Children renderer.value; ShowLineNumbers true; Style style ] ]

    let markdown (props: MarkdownProps list): ReactElement =
        let propsObject = keyValueList CaseRules.LowerFirst props
        ofImport "default" "react-markdown" propsObject []

    let markdownDefaultRenderer (markdownText: string) =
        markdown [ Renderers renderers; Children markdownText ]