namespace Fss

open Units.Size
open Utilities.Types
open Utilities.Global


module Margin =
    type Margin =
        | Margin of Size
        | Auto
        interface IMargin

    let private marginValue (v: Margin): string =
        match v with
            | Margin s -> Units.Size.value s
            | Auto -> "auto"

    let value (v: IMargin): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? Size as s -> Units.Size.value s
            | :? Margin as m -> marginValue m
            | _ -> "Unknown margin size"