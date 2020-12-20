namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module Import =
// @import url('https://fonts.googleapis.com/css?family=Playfair+Display|Roboto');

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@import
    let importValue value = "@import" ==> value |> CSSProperty

    type Import =
        static member Url (url: string) = importValue (sprintf "url(\"%s\")" url)
        static member Custom (import: string) = importValue import