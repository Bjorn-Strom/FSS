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
            | :? Global as g   -> Global.value g
            | :? Size as s     -> Units.Size.value s
            | :? Percent as p  -> Units.Percent.value p
            | :? FontSize as s -> fontValue s
            | _                -> "Unknown font size"

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
            | _         -> duToLowercase v

    let value (v: IFontStyle): string =
        match v with
            | :? FontStyle as f -> fontStyleValue f
            | :? Global as g    -> Global.value g
            | _                 -> "Unknown font style"

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
            | :? Percent as p     -> Units.Percent.value p
            | :? Global as g      -> Global.value g
            | _                   -> "unknown font stretch value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
module FontWeight =
    type FontWeight =
        | Normal
        | Bold
        | Lighter
        | Bolder
        | Number of int
        interface IFontWeight

    let private fontFamilyValue (v: FontWeight): string = 
        match v with
            | Number n -> string n
            | _        -> duToLowercase v

    let value (v: IFontWeight): string =
        match v with
            | :? Global as g     -> Global.value g
            | :? FontWeight as f -> fontFamilyValue f
            | _                  -> "Unknown font family"

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
            | _       -> duToLowercase v

    let value (v: ILineHeight): string =
        match v with
            | :? LineHeight as f -> lineHeightValue f
            | :? Percent as p    -> Units.Percent.value p
            | :? Size as s       -> Units.Size.value s
            | :? Global as g     -> Global.value g
            | _                  -> "unknown font stretch value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
module FontDisplay =
    type FontDisplay =
        | Auto
        | Block
        | Swap
        | Fallback
        | Optional
        interface IFontDisplay

    let private fontDisplayValue (v: FontDisplay): string = duToLowercase v

    let value (v: IFontDisplay): string =
        match v with
            | :? FontDisplay as f -> fontDisplayValue f
            | _                   -> "Unknown font display"

// https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
module FontFace =
    open FontDisplay
    open FontStretch
    open FontStyle
    open FontWeight
    open Property

    type Format =
        | Truetype
        | Opentype
        | EmpbeddedOpentype
        | Woff
        | Woff2
        | Svg

    let private formatValue (v: Format): string = duToKebab v

    type Source =
        | Url of string * Format
        | Local of string

    let private sourceValue (v: Source): string =
        match v with
            | Url (s, f) -> sprintf "url('%s') format('%s')" s (formatValue f)
            | Local l    -> sprintf "local('%s')" l

    type FontFace =
        | Source of Source
        | Sources of Source list
        | FontStyle of FontStyle
        | FontDisplay of FontDisplay
        | FontStretch of FontStretch
        | FontWeight of FontWeight
        interface IFontFamily

    type FontName = FontName of string

    let fontName (FontName n) = n

    let createFontFaceObject (fontName: string) (attributeList: FontFace list) =
        let innerStyle =
            attributeList |> List.map (
                function
                    | Source      s -> "src"                      ==> sourceValue s
                    | Sources     s -> "src"                      ==> combineComma s sourceValue
                    | FontStyle   f -> Property.value fontStyle   ==> FontStyle.value f
                    | FontDisplay f -> Property.value fontDisplay ==> FontDisplay.value f
                    | FontStretch f -> Property.value fontStretch ==> FontStretch.value f
                    | FontWeight  f -> Property.value fontWeight  ==> FontWeight.value f)

        createObj
            [
                "@font-face" ==> 
                    createObj
                        ([
                            "fontFamily" ==> fontName
                        ] @ innerStyle) 
            ]

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
module FontFamily =
    open FontFace

    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        | Font of FontName
        | Custom of string
        interface IFontFamily

    let private fontFamilyValue (v: FontFamily): string = 
        match v with
            | Font f   -> fontName f
            | Custom c -> c
            | _ -> duToKebab v

    let value (v: IFontFamily) : string =
        match v with
            | :? Global as g     -> Global.value g
            | :? FontFamily as f -> fontFamilyValue f
            | _ -> "Unknown font family"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
module FontFeatureSetting =
    type SettingSwitch =
        | On
        | Off

    type FontFeatureSetting =
        | Liga of SettingSwitch
        | Dlig of SettingSwitch
        | Onum of SettingSwitch
        | Lnum of SettingSwitch
        | Tnum of SettingSwitch
        | Zero of SettingSwitch
        | Frac of SettingSwitch
        | Sups of SettingSwitch
        | Subs of SettingSwitch
        | Smcp of SettingSwitch
        | C2sc of SettingSwitch
        | Case of SettingSwitch
        | Hlig of SettingSwitch
        | Calt of SettingSwitch
        | Swsh of SettingSwitch
        | Hist of SettingSwitch
        | Ss   of int * SettingSwitch
        | Kern of SettingSwitch
        | Locl of SettingSwitch
        | Rlig of SettingSwitch
        | Medi of SettingSwitch
        | Init of SettingSwitch
        | Isol of SettingSwitch
        | Fina of SettingSwitch
        | Mark of SettingSwitch
        | Mkmk of SettingSwitch
        interface IFontFeatureSetting

    let fontFeatureSettingValue (v: FontFeatureSetting): string =
        let stringify (fontFeature: string) (setting: SettingSwitch) =
            sprintf "\"%s\" %s" fontFeature (duToString setting)

        match v with
        | Liga switch -> stringify "liga" switch
        | Dlig switch -> stringify "dlig" switch
        | Onum switch -> stringify "onum" switch
        | Lnum switch -> stringify "lnum" switch 
        | Tnum switch -> stringify "tnum" switch
        | Zero switch -> stringify "zero" switch 
        | Frac switch -> stringify "frac" switch 
        | Sups switch -> stringify "sups" switch 
        | Subs switch -> stringify "subs" switch 
        | Smcp switch -> stringify "smcp" switch 
        | C2sc switch -> stringify "c2sc" switch 
        | Case switch -> stringify "case" switch
        | Hlig switch -> stringify "hlig" switch 
        | Calt switch -> stringify "calt" switch 
        | Swsh switch -> stringify "swsh" switch 
        | Hist switch -> stringify "hist" switch 
        | Ss   (variant, switch) -> stringify (sprintf "ss%02i" variant) switch
        | Kern switch -> stringify "kern" switch 
        | Locl switch -> stringify "locl" switch 
        | Rlig switch -> stringify "rlig" switch 
        | Medi switch -> stringify "medi" switch 
        | Init switch -> stringify "init" switch 
        | Isol switch -> stringify "isol" switch 
        | Fina switch -> stringify "fina" switch 
        | Mark switch -> stringify "mark" switch 
        | Mkmk switch -> stringify "mkmk" switch 

    let value (v: IFontFeatureSetting): string =
        match v with
            | :? Global as g             -> Global.value g
            | :? FontFeatureSetting as f -> sprintf "%s" (fontFeatureSettingValue f)
            | _ -> "Unknown font feature setting"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
module FontVariantNumeric =
    type FontVariantNumeric =
        | Normal
        | Ordinal
        | SlashedZero
        | LiningNums
        | OldstyleNums
        | ProportionalNums
        | TabularNums
        | DiagonalFractions
        | StackedFractions
        interface IFontVariantNumeric

    let value (v: IFontVariantNumeric): string =
        match v with
        | :? Global as g             -> Global.value g
        | :? FontVariantNumeric as f -> duToKebab f
        | _ -> "Unknown font variant numeric"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
module FontVariantCaps =
    type FontVariantCaps =
        | Normal
        | SmallCaps
        | AllSmallCaps
        | PetiteCaps
        | AllPetiteCaps
        | Unicase
        | TitlingCaps
        interface IFontVariantCaps

    let value (v: IFontVariantCaps): string =
        match v with
        | :? Global          as g -> Global.value g
        | :? FontVariantCaps as f -> duToKebab f
        | _ -> "Unknown font variant caps"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
module FontVariantEastAsian  =
    type FontVariantEastAsian =
        | Normal
        | Ruby
        | Jis78
        | Jis83
        | Jis90
        | Jis04
        | Simplified
        | Traditional
        | FullWidth
        | ProportionalWidth
        interface IFontVariantEastAsian

    let value (v: IFontVariantEastAsian): string =
        match v with
        | :? Global               as g -> Global.value g
        | :? FontVariantEastAsian as f -> duToKebab f
        | _ -> "Unknown font variant east asian"

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
module FontVariantLigatures =
    type FontVariantLigatures = 
        | Normal
        | None
        | CommonLigatures
        | NoCommonLigatures
        | DiscretionaryLigatures
        | NoDiscretionaryLigatures
        | HistoricalLigatures
        | NoHistoricalLigatures
        | Contextual
        | NoContextual
        interface IFontVariantLigatures

    let value (v: IFontVariantLigatures): string =
        match v with
        | :? Global               as g -> Global.value g
        | :? FontVariantLigatures as f -> duToKebab f
        | _ -> "Unknown font variant ligatures"