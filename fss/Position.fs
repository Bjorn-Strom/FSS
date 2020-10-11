namespace Fss

open Fss.Types

module PlacementValue =
    open Units.Percent
    open Units.Size
    open Global
    
    let placement (v: IPlacement): string =
        match v with
            | :? Percent as p -> Units.Percent.value p
            | :? Size    as s -> Units.Size.value s
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Auto    as a -> GlobalValue.auto a
            | _ -> "Unknown placement"

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
            
// https://developer.mozilla.org/en-US/docs/Web/CSS/float
module Float =
    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface IFloat
        
module FloatValue =
    open Float
    open Global
    open Utilities.Helpers
    
    let float (v: IFloat): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? None   as n -> GlobalValue.none n
            | :? Float  as v -> duToKebab v
            | _ -> "Unknown float value"