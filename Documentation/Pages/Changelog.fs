module Page.Changelog

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Changelog () = Page (Pages.OtherPage Pages.Changelog) []

JsInterop.exportDefault Changelog
