module Page.Core

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Core () = Page Pages.Core []

JsInterop.exportDefault Core
