namespace Fss

open Units.Size
open Utilities.Global
open Utilities.Types

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

    let private fontValue (v: FontSize): string =
        match v with
            | XxSmall -> "xx-small"
            | XSmall -> "x-small"
            | Small -> "small"
            | Medium -> "medium"
            | Large -> "large"
            | XLarge -> "x-large"
            | XxLarge -> "xx-large"
            | XxxLarge -> "xxx-large"
            // Relative
            | Smaller -> "smaller"
            | Larger -> "larger"

    let value (v: IFontSize): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? Size as s -> Units.Size.value s
            | :? FontSize as s -> fontValue s
            | _ -> "Unknown font size"
