module Page.Troubleshoot

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Troubleshoot () = Page (Pages.OtherPage Pages.Troubleshoot) []

JsInterop.exportDefault Troubleshoot
