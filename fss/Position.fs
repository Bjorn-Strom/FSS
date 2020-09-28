namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/position
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed

module PositionValue =
    open Position
    open Utilities.Helpers

    let position (v: Position) = duToLowercase v

// https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
module VerticalAlign =
    open Types

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface IVerticalAlign

module VerticalAlignValue =
    open VerticalAlign
    open Global
    open Types
    open Units.Percent
    open Units.Size
    open Utilities.Helpers

    let verticalAlign (v: IVerticalAlign): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? Percent       as p -> Units.Percent.value p
            | :? Size          as s -> Units.Size.value s
            | :? VerticalAlign as v -> duToKebab v
            | _ -> "Unknown margin size"