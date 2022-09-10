module Page.Installation

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Installation () = Page (Pages.FssPage Pages.Installation) []

JsInterop.exportDefault Installation
