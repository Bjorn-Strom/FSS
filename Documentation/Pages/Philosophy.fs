module Page.Philosophy

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Philosophy () = Page (Pages.FssPage Pages.Philosophy) []

JsInterop.exportDefault Philosophy
