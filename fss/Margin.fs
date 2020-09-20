namespace Fss

open Units.Size
open Units.Percent
open Types
open Global

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
module Margin =
    type Margin =
        | Margin of Size
        | Auto
        interface IMargin

module MarginValue =
    open Margin

    let private marginValue (v: Margin): string =
        match v with
            | Margin s -> Units.Size.value s
            | Auto -> "auto"

    let value (v: IMargin): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? Margin as m -> marginValue m
            | _ -> "Unknown margin size"