module Page.Overview

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Overview () = Page (Pages.FssPage Pages.Overview) []

JsInterop.exportDefault Overview
