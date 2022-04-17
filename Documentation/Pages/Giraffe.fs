module Page.Giraffe

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Giraffe ()  =
    Page Pages.Giraffe []

JsInterop.exportDefault Giraffe