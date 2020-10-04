namespace Fss

open Units.Size
open Units.Percent
open Global
open Types
open Fss.Utilities.Helpers
open Units.Angle

module Font =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    type Size =
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    type Style =
        | Normal
        | Italic
        | Oblique of Angle
        interface IFontStyle

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    type Stretch =
        | Normal
        | SemiCondensed
        | Condensed
        | ExtraCondensed
        | UltraCondensed
        | SemiExpanded
        | Expanded
        | ExtraExpanded
        | UltraExpanded
        interface IFontStretch

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    type Weight =
        | Normal
        | Bold
        | Lighter
        | Bolder
        | Value of int
        interface IFontWeight

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    type LineHeight =
        | Normal
        | Value of float
        | Percent of Percent
        | Size of Size
        interface ILineHeight

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    type Display =
        | Auto
        | Block
        | Swap
        | Fallback
        | Optional
        interface IFontDisplay

    type FontName = FontName of string

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        | Font of FontName
        | Custom of string
        interface IFontFamily

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    type SettingSwitch =
        | On
        | Off

    type FeatureSetting =
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    type VariantNumeric =
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    type VariantCaps =
        | Normal
        | SmallCaps
        | AllSmallCaps
        | PetiteCaps
        | AllPetiteCaps
        | Unicase
        | TitlingCaps
        interface IFontVariantCaps

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    type VariantEastAsian =
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    type VariantLigatures =
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

module FontValues =
    open Font

    let fontSize (v: IFontSize): string =
        match v with
            | :? Global          as g -> GlobalValue.globalValue g
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? Size            as s -> duToKebab s
            | _                       -> "Unknown font size"

    let fontStyle (v: IFontStyle): string =
        let stringifyStyleValue (v: Style): string =
            match v with
                | Oblique a -> sprintf "oblique %s" <| Units.Angle.value a
                | _         -> duToLowercase v

        match v with
            | :? Style  as f -> stringifyStyleValue f
            | :? Global as g -> GlobalValue.globalValue g
            | :? Normal as n -> GlobalValue.normal n
            | _              -> "Unknown font style"

    let fontStretch (v: IFontStretch): string =
        match v with
            | :? Stretch as f -> duToKebab f
            | :? Percent as p -> Units.Percent.value p
            | :? Global  as g -> GlobalValue.globalValue g
            | _               -> "unknown font stretch value"

    let fontWeight (v: IFontWeight): string =
        let stringifyFamilyValue (v: Weight): string =
            match v with
                | Weight.Value n -> string n
                | _              -> duToLowercase v

        match v with
            | :? Global as g     -> GlobalValue.globalValue g
            | :? Normal as n     -> GlobalValue.normal n
            | :? Weight as f     -> stringifyFamilyValue f
            | _                  -> "Unknown font family"

    let lineHeight (v: ILineHeight): string =
        let stringifyLineHeight (v: LineHeight): string =
            match v with
                | Value v -> string v
                | _       -> duToLowercase v

        match v with
            | :? LineHeight      as f -> stringifyLineHeight f
            | :? Percent         as p -> Units.Percent.value p
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Global          as g -> GlobalValue.globalValue g
            | _                       -> "unknown font stretch value"

    let fontDisplay (v: IFontDisplay): string =
        match v with
            | :? Display as f -> duToLowercase f
            | _                   -> "Unknown font display"

    let fontName (FontName n) = n

    let fontFamily (v: IFontFamily) : string =
        let parseFamilyValue (v: FontFamily): string =
            match v with
                | Font   f -> fontName f
                | Custom c -> c
                | _ -> duToKebab v

        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? FontFamily as f -> parseFamilyValue f
            | _ -> "Unknown font family"


    let fontFeatureSetting (v: IFontFeatureSetting): string =
        let parseFontFeatureSetting (v: FeatureSetting): string =
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

        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? FeatureSetting as f -> sprintf "%s" (parseFontFeatureSetting f)
            | _ -> "Unknown font feature setting"

    let fontVariantNumeric (v: IFontVariantNumeric): string =
        match v with
        | :? Global         as g -> GlobalValue.globalValue g
        | :? VariantNumeric as f -> duToKebab f
        | _ -> "Unknown font variant numeric"

    let fontVariantCap (v: IFontVariantCaps): string =
        match v with
        | :? Global      as g -> GlobalValue.globalValue g
        | :? VariantCaps as f -> duToKebab f
        | _ -> "Unknown font variant caps"

    let fontVariantEastAsian (v: IFontVariantEastAsian): string =
        match v with
        | :? Global           as g -> GlobalValue.globalValue g
        | :? VariantEastAsian as f -> duToKebab f
        | _ -> "Unknown font variant east asian"

    let fontVariantLigature (v: IFontVariantLigatures): string =
        match v with
        | :? Global               as g -> GlobalValue.globalValue g
        | :? None                 as n -> GlobalValue.none n
        | :? VariantLigatures     as f -> duToKebab f
        | _ -> "Unknown font variant ligatures"