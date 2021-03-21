namespace Fss

[<RequireQualifiedAccess>]
module Types =
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
        interface Types.IFontSize

    type FontStyle =
        | Italic
        | Oblique of Types.Angle
        interface Types.IFontStyle

    type FontStretch =
        | SemiCondensed
        | Condensed
        | ExtraCondensed
        | UltraCondensed
        | SemiExpanded
        | Expanded
        | ExtraExpanded
        | UltraExpanded
        interface Types.IFontStretch

    type FontWeight =
         | Bold
         | Lighter
         | Bolder
         interface Types.IFontWeight

    type FontDisplay =
        | Block
        | Swap
        | Fallback
        | Optional
        interface Types.IFontDisplay

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
        interface Types.IFontFeatureSetting

    type FontVariantNumeric =
        | Ordinal
        | SlashedZero
        | LiningNums
        | OldstyleNums
        | ProportionalNums
        | TabularNums
        | DiagonalFractions
        | StackedFractions
        interface Types.IFontVariantNumeric

    type FontVariantCaps =
        | SmallCaps
        | AllSmallCaps
        | PetiteCaps
        | AllPetiteCaps
        | Unicase
        | TitlingCaps
        interface Types.IFontVariantCaps

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
        interface Types.IFontVariantEastAsian

    type FontVariantLigature =
        | CommonLigatures
        | NoCommonLigatures
        | DiscretionaryLigatures
        | NoDiscretionaryLigatures
        | HistoricalLigatures
        | NoHistoricalLigatures
        | Contextual
        | NoContextual
        interface Types.IFontVariantLigature

    type FontName =
        | FontName of string
        interface Types.IFontFamily

    type FontFamily =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        | Custom of string
        | FontName of FontName
        interface Types.IFontFamily

    type LineBreak =
        | Loose
        | Strict
        | Anywhere
        interface Types.ILineBreak

    type FontSynthesis =
        | Weight
        | Style
        | WeightStyle
        interface Types.IFontSynthesis

    type FontVariantPosition =
        | Sub
        | Super
        interface Types.IFontVariantPosition

    let internal fontStyleToString (style: Types.IFontStyle) =
        let stringifyFontStyle =
            function
                | Italic -> "italic"
                | Oblique a -> sprintf "oblique %s" (Types.angleToString a)

        match style with
            | :? FontStyle as f -> stringifyFontStyle f
            | :? Types.Keywords as g -> Types.keywordsToString g
            | :? Types.Normal -> Types.normal
            | _ -> "Unknown font style"

    let internal fontStretchToString (stretch: Types.IFontStretch) =
        match stretch with
            | :? FontStretch as f -> Fss.Utilities.Helpers.duToKebab f
            | :? Types.Keywords as k -> Types.keywordsToString k
            | :? Types.Normal -> Types.normal
            | :? Types.Percent as p -> Types.percentToString p
            | _ -> "Unknown font stretch"

    let internal fontWeightToString (fontWeight: Types.IFontWeight) =
         match fontWeight with
            | :? FontWeight as f -> Fss.Utilities.Helpers.duToLowercase f
            | :? Types.Int as i -> Types.IntToString i
            | :? Types.Keywords as k -> Types.keywordsToString k
            | :? Types.Normal -> Types.normal
            | _ -> "Unknown font weight"

    let internal fontDisplayToString (display: Types.IFontDisplay) =
        match display with
        | :? FontDisplay as f -> Fss.Utilities.Helpers.duToLowercase f
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown font display value"