namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Font =
        type Size =
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

        type Style =
            | Italic
            | Oblique of Angle
            interface IFontStyle

        type Stretch =
            | SemiCondensed
            | Condensed
            | ExtraCondensed
            | UltraCondensed
            | SemiExpanded
            | Expanded
            | ExtraExpanded
            | UltraExpanded
            interface IFontStretch

        type Weight =
             | Bold
             | Lighter
             | Bolder
             interface IFontWeight

        type Display =
            | Block
            | Swap
            | Fallback
            | Optional
            interface IFontDisplay

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

        type VariantNumeric =
            | Ordinal
            | SlashedZero
            | LiningNums
            | OldstyleNums
            | ProportionalNums
            | TabularNums
            | DiagonalFractions
            | StackedFractions
            interface IFontVariantNumeric

        type VariantCaps =
            | SmallCaps
            | AllSmallCaps
            | PetiteCaps
            | AllPetiteCaps
            | Unicase
            | TitlingCaps
            interface IFontVariantCaps

        type VariantEastAsian =
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

        type VariantLigature =
            | CommonLigatures
            | NoCommonLigatures
            | DiscretionaryLigatures
            | NoDiscretionaryLigatures
            | HistoricalLigatures
            | NoHistoricalLigatures
            | Contextual
            | NoContextual
            interface IFontVariantLigature

        type Name =
            | Name of string
            interface IFontFamily

        type Family =
            | Serif
            | SansSerif
            | Monospace
            | Cursive
            | Custom of string
            | FontName of Name
            interface IFontFamily

        type LineBreak =
            | Loose
            | Strict
            | Anywhere
            interface ILineBreak

        type Synthesis =
            | Weight
            | Style
            | WeightStyle
            interface IFontSynthesis

        type VariantPosition =
            | Sub
            | Super
            interface IFontVariantPosition

    [<AutoOpen>]
    module fontHelpers =
        let internal fontStyleToString (style: IFontStyle) =
            let stringifyFontStyle =
                function
                    | Font.Italic -> "italic"
                    | Font.Oblique a -> sprintf "oblique %s" (angleToString a)

            match style with
                | :? Font.Style as f -> stringifyFontStyle f
                | :? Keywords as g -> keywordsToString g
                | :? Normal -> normal
                | _ -> "Unknown font style"

        let internal fontStretchToString (stretch: IFontStretch) =
            match stretch with
                | :? Font.Stretch as f -> Fss.Utilities.Helpers.duToKebab f
                | :? Keywords as k -> keywordsToString k
                | :? Normal -> normal
                | :? Percent as p -> percentToString p
                | _ -> "Unknown font stretch"

        let internal fontWeightToString (fontWeight: IFontWeight) =
             match fontWeight with
                | :? Font.Weight as f -> Fss.Utilities.Helpers.duToLowercase f
                | :? CssInt as i -> IntToString i
                | :? Keywords as k -> keywordsToString k
                | :? Normal -> normal
                | _ -> "Unknown font weight"

        let internal fontDisplayToString (display: IFontDisplay) =
            match display with
            | :? Font.Display as f -> Fss.Utilities.Helpers.duToLowercase f
            | :? Auto -> auto
            | _ -> "Unknown font display value"