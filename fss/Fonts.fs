namespace Fss

open Units.Size
open Global
open Types
open Fss.Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
module FontFamily =

    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        interface IFontFamily
        interface IGlobal

    let private fontFamilyValue (v: FontFamily): string = duToKebab v

    let value (v: IFontFamily): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FontFamily as f -> fontFamilyValue f
            | _ -> "Unknown font family"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
module FontSize =

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
