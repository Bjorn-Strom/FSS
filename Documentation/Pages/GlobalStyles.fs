module Page.GlobalStyles

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let GlobalStyles () = Page (Pages.FssPage Pages.GlobalStyles) []

JsInterop.exportDefault GlobalStyles
