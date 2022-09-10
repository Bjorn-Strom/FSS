module Page.Core

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Core () = Page (Pages.LibraryPage Pages.Core) []

JsInterop.exportDefault Core
