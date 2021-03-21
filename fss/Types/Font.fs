namespace FssTypes

type FontSize =
    | XxSmall
    | XSmall
    | Small
    | Medium
    | Large
    | XLarge
    | XxLarge
    | XxxLarge
    | Smaller
    | Larger
    interface IFontSize

type FontStyle =
    | Italic
    | Oblique of Units.Angle.Angle
    interface IFontStyle

type FontStretch =
    | SemiCondensed
    | Condensed
    | ExtraCondensed
    | UltraCondensed
    | SemiExpanded
    | Expanded
    | ExtraExpanded
    | UltraExpanded
    interface IFontStretch

type FontWeight =
     | Bold
     | Lighter
     | Bolder
     interface IFontWeight

type FontDisplay =
    | Block
    | Swap
    | Fallback
    | Optional
    interface IFontDisplay

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
    | Ss of int * SettingSwitch
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

type FontVariantNumeric =
    | Ordinal
    | SlashedZero
    | LiningNums
    | OldstyleNums
    | ProportionalNums
    | TabularNums
    | DiagonalFractions
    | StackedFractions
    interface IFontVariantNumeric

type FontVariantCaps =
    | SmallCaps
    | AllSmallCaps
    | PetiteCaps
    | AllPetiteCaps
    | Unicase
    | TitlingCaps
    interface IFontVariantCaps

type FontVariantEastAsian =
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

type FontVariantLigature =
    | CommonLigatures
    | NoCommonLigatures
    | DiscretionaryLigatures
    | NoDiscretionaryLigatures
    | HistoricalLigatures
    | NoHistoricalLigatures
    | Contextual
    | NoContextual
    interface IFontVariantLigature

type FontName = FontName of string

type FontFamily =
    | Serif
    | SansSerif
    | Monospace
    | Cursive
    | Custom of string
    | FontName of FontName
    interface IFontFamily

type LineBreak =
    | Loose
    | Strict
    | Anywhere
    interface ILineBreak

type FontSynthesis =
    | Weight
    | Style
    | WeightStyle
    interface IFontSynthesis

type FontVariantPosition =
    | Sub
    | Super
    interface IFontVariantPosition

module Font =
    let fontStyleToString (style: IFontStyle) =
        let stringifyFontStyle =
            function
                | Italic -> "italic"
                | Oblique a -> sprintf "oblique %s" (Units.Angle.value a)

        match style with
            | :? FontStyle as f -> stringifyFontStyle f
            | :? Global as g -> global' g
            | :? Normal -> normal
            | _ -> "Unknown font style"

    let fontStretchToString (stretch: IFontStretch) =
        match stretch with
            | :? FontStretch as f -> Fss.Utilities.Helpers.duToKebab f
            | :? Global as g -> global' g
            | :? Normal -> normal
            | :? Units.Percent.Percent as p -> Units.Percent.value p
            | _ -> "Unknown font stretch"

    let fontWeightToString (fontWeight: IFontWeight) =
         match fontWeight with
            | :? FontWeight as f -> Fss.Utilities.Helpers.duToLowercase f
            | :? CssInt as i -> int i
            | :? Global as g -> global' g
            | :? Normal -> normal
            | _ -> "Unknown font weight"

    let fontDisplayToString (display: IFontDisplay) =
        match display with
        | :? FontDisplay as f -> Fss.Utilities.Helpers.duToLowercase f
        | :? Auto -> auto
        | _ -> "Unknown font display value"