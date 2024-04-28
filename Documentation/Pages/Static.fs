module Page.Static

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Static () = Page (Pages.LibraryPage Pages.Static) []

JsInterop.exportDefault Static
