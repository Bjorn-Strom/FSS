 namespace Documentation


 module Markdown =
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

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