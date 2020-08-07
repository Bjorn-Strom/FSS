namespace Fss

open Units.Size
open Units.Percent
open Global
open Types
open Fss.Utilities.Helpers


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
            | :? Percent as p -> Units.Percent.value p
            | :? FontSize as s -> fontValue s
            | _ -> "Unknown font size"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
module FontStyle =
    open Units.Angle

    type FontStyle =
        | Normal
        | Italic
        | Oblique of Angle
        interface IFontStyle

    let private fontStyleValue (v: FontStyle): string =
        match v with
            | Oblique a -> sprintf "oblique %s" <| Units.Angle.value a
            | _ -> duToLowercase v

    let value (v: IFontStyle): string =
        match v with
            | :? FontStyle as f -> fontStyleValue f
            | :? Global as g -> Global.value g
            | _ -> "Unknown font style"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
module FontStretch =
    type FontStretch =
        | Normal
        | SemiCondensed
        | Condensed
        | ExtraCondensed
        | UltraCondensed
        | SemiExpanded
        | Expanded
        | ExtraExpanded
        | UltraExpanded
        | Pct of Percent
        interface IFontStretch

    let private fontStretchValue (v: FontStretch): string = duToKebab v

    let value (v: IFontStretch): string =
        match v with
            | :? FontStretch as f -> fontStretchValue f
            | :? Percent as p -> Units.Percent.value p
            | :? Global as g -> Global.value g
            | _ -> "unknown font stretch value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
module FontFamily =

    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        | Font of string
        | Custom of string
        interface IFontFamily
        interface IGlobal

    let private fontFamilyValue (v: FontFamily): string = 
        match v with
            | Custom c -> c
            | _ -> duToKebab v

    let value (v: IFontFamily): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FontFamily as f -> fontFamilyValue f
            | _ -> "Unknown font family"
