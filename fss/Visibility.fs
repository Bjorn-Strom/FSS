namespace Fss

open Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
module Visibility =
    open Types

    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

module VisibilityValue =
    open Visibility
    open Types
    open Global
    open Utilities.Helpers

    let visibility (v: IVisibility): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Visibility as v -> duToLowercase v
            | _ -> "Unknown margin size"

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
module Opacity =
    type Opacity = Opacity of float


module OpacityValue =
    open Opacity
    open Utilities.Helpers

    let opacity (Opacity v): string =
        v
        |> clamp 0.0 1.0
        |> string

// https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
module Overflow =
    open Types
    type Overflow =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface IOverflow
    
module OverflowValue =
    open Overflow
    open Global
    open Utilities.Helpers
    
    let overflow (v: IOverflow): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? Auto     as a -> GlobalValue.auto a
            | :? Overflow as o -> duToLowercase o
        
