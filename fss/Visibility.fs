namespace Fss

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
            | :? Visibility as v -> duToString v
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
        
