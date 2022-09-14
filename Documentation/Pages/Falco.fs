module Page.Falco

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Falco () = Page (Pages.LibraryPage Pages.Falco) []

JsInterop.exportDefault Falco
