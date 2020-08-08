namespace Fss

open Fable.Core.JsInterop

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
        interface IFontFace

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
        interface IFontFace

    let private fontStretchValue (v: FontStretch): string = duToKebab v

    let value (v: IFontStretch): string =
        match v with
            | :? FontStretch as f -> fontStretchValue f
            | :? Percent as p -> Units.Percent.value p
            | :? Global as g -> Global.value g
            | _ -> "unknown font stretch value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
module FontWeight =
    type FontWeight =
        | Normal
        | Bold
        | Lighter
        | Bolder
        | Number of int
        interface IFontWeight
        interface IFontFace

    let private fontFamilyValue (v: FontWeight): string = 
        match v with
            | Number n -> string n
            | _ -> duToLowercase v

    let value (v: IFontWeight): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FontWeight as f -> fontFamilyValue f
            | _ -> "Unknown font family"

// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
module LineHeight =
    type LineHeight =
        | Normal
        | Value of float
        | Percent of Percent
        | Size of Size
        interface ILineHeight

    let private lineHeightValue (v: LineHeight): string = 
        match v with
            | Value v -> string v
            | _ -> duToLowercase v

    let value (v: ILineHeight): string =
        match v with
            | :? LineHeight as f -> lineHeightValue f
            | :? Percent as p -> Units.Percent.value p
            | :? Size as s -> Units.Size.value s
            | :? Global as g -> Global.value g
            | _ -> "unknown font stretch value"


//    FontFace [Family "Open Sans"; Sources ["url1"; "url2"]; Formats [Woff2; Woff] ]
//    FontFace [Family "Open Sans"; Source "url1"; Format Woff2 ]

// https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
module FontDisplay =
    type FontDisplay =
        | Auto
        | Block
        | Swap
        | Fallback
        | Optional
        interface IFontDisplay
        interface IFontFace

    let private fontDisplayValue (v: FontDisplay): string = duToLowercase v

    let value (v: IFontDisplay): string =
        match v with
            | :? FontDisplay as f -> fontDisplayValue f
            | _ -> "Unknown font display"

// https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
module FontFace =
    open FontDisplay
    open FontStretch
    open FontStyle
    open FontWeight

    type Format =
        | TrueType
        | OpenType
        | EmpbeddedOpentype
        | Woff
        | Woff2
        | Svg

    let private formatValue (v: Format): string = duToKebab v

    type FontFace =
        | Family of string
        | Url of string * Format
        interface IFontFace
        interface IFontFamily

    let private fontFaceValue (v: FontFace): string =
        match v with
            | Family f -> sprintf "font-family: %s" f
            | Url (s, f) -> sprintf "url('%s') format('%s')" s (formatValue f)

    let private value (v: IFontFace): string =
        match v with
        | :? FontDisplay as d -> FontDisplay.value d
        | :? FontStretch as s -> FontStretch.value s
        | :? FontStyle as s -> FontStyle.value s
        | :? FontWeight as w -> FontWeight.value w
        | :? FontFace as f -> fontFaceValue f
        | _ -> "Unknown font face"

    let createFontFaceObject (fontFace: IFontFace list) =
        [
            "fontFamily" ==> "DroidSerif"
            "src" ==> "url('https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf') format('truetype')"
            "fontWeight" ==> "normal"
            "fontStyle" ==> "normal"
        ] |> createObj

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
module FontFamily =
    open FontFace

    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        | Font of string
        | Custom of string
        interface IFontFamily

    let private fontFamilyValue (v: FontFamily): string = 
        match v with
            | Font f -> f
            | Custom c -> c
            | _ -> duToKebab v

    let value (v: IFontFamily) = //: string =
        match v with
            | :? Global as g -> Global.value g
            | :? FontFamily as f -> fontFamilyValue f
            | _ -> "Unknown font family"
