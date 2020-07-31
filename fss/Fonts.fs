namespace Fss

open Units.Size
open Global
open Types
open Fss.Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
module Fonts =

    type FontSize =
        // Absolute
        | XxSmall
        | XSmall
        | Small
        | Medium
        | Large
        | XLarge
        | XxLarge
        | XxxLarge
        // Relative
        | Smaller
        | Larger
        interface IFontSize
        interface IGlobal

    let private fontValue (v: FontSize): string = duToKebab v

    let value (v: IFontSize): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Size as s -> Units.Size.value s
            | :? FontSize as s -> fontValue s
            | _ -> "Unknown font size"
