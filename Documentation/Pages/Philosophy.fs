module Page.Philosophy

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Philosophy ()  =
    Page Pages.Philosophy []

JsInterop.exportDefault Philosophy