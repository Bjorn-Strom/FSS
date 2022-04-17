module Page

open Fss
open Feliz

open Store

[<ReactComponent>]
let Page page styles  =
    let state, setState = React.useState<Documentation option> None
    useFetchStore page setState
    
    match state with
    | Some (_, documentation) ->
        Markdown.markdownAndExamples documentation styles
    | None -> Html.p "Fetching..."