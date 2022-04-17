module Page.Fable

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Fable () = Page Pages.Fable []

JsInterop.exportDefault Fable
