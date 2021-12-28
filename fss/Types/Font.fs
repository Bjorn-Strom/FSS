namespace Fss

namespace Fss.FssTypes

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
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Style =
        | Italic
        | Oblique
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Stretch =
        | SemiCondensed
        | Condensed
        | ExtraCondensed
        | UltraCondensed
        | SemiExpanded
        | Expanded
        | ExtraExpanded
        | UltraExpanded
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Weight =
        | Bold
        | Lighter
        | Bolder
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type SettingSwitch =
        | On
        | Off

    type FeatureSetting =
        | Liga
        | Dlig
        | Onum
        | Lnum
        | Tnum
        | Zero
        | Frac
        | Sups
        | Subs
        | Smcp
        | C2sc
        | Case
        | Hlig
        | Calt
        | Swsh
        | Hist
        | Ss
        | Kern
        | Locl
        | Rlig
        | Medi
        | Init
        | Isol
        | Fina
        | Mark
        | Mkmk
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type VariantNumeric =
        | Ordinal
        | SlashedZero
        | LiningNums
        | OldstyleNums
        | ProportionalNums
        | TabularNums
        | DiagonalFractions
        | StackedFractions
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type VariantCaps =
        | SmallCaps
        | AllSmallCaps
        | PetiteCaps
        | AllPetiteCaps
        | Unicase
        | TitlingCaps
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this


    type VariantLigature =
        | CommonLigatures
        | NoCommonLigatures
        | DiscretionaryLigatures
        | NoDiscretionaryLigatures
        | HistoricalLigatures
        | NoHistoricalLigatures
        | Contextual
        | NoContextual
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Name = Name of string

    type Family =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type LineBreak =
        | Loose
        | Strict
        | Anywhere
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Synthesis =
        | Weight
        | Style
        | SmallCaps
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type VariantPosition =
        | Sub
        | Super
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module FontClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
        type FontSynthesis(property) =
            inherit CssRuleWithNone(property)
            member this.value(synthesis: Synthesis list) =
                let synthesis =
                    List.map Fss.Utilities.Helpers.toKebabCase synthesis
                    |> String.concat " "
                (property, String synthesis) |> Rule
            member this.weight = (property, Weight) |> Rule
            member this.style = (property, Style) |> Rule
            member this.smallCaps = (property, SmallCaps) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
        type FontLanguageOverride(property) =
            inherit CssRuleWithNormal(property)

            member this.value(languageOverride: string) =
                (property, Stringed languageOverride) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
        type FontKerning(property) =
            inherit CssRuleWithAutoNormalNone(property)

        type FontSize(property) =
            inherit CssRuleWithLength(property)
            member this.xxSmall = (property, XxSmall) |> Rule
            member this.xSmall = (property, XSmall) |> Rule
            member this.small = (property, Small) |> Rule
            member this.medium = (property, Medium) |> Rule
            member this.large = (property, Large) |> Rule
            member this.xLarge = (property, XLarge) |> Rule
            member this.xxLarge = (property, XxLarge) |> Rule
            member this.xxxLarge = (property, XxxLarge) |> Rule
            member this.smaller = (property, Smaller) |> Rule
            member this.larger = (property, Larger) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
        type FontStretch(property) =
            inherit CssRuleWithLengthNormal(property)
            member this.semiCondensed = (property, SemiCondensed) |> Rule
            member this.condensed = (property, Condensed) |> Rule
            member this.extraCondensed = (property, ExtraCondensed) |> Rule
            member this.ultraCondensed = (property, UltraCondensed) |> Rule
            member this.semiExpanded = (property, SemiExpanded) |> Rule
            member this.expanded = (property, Expanded) |> Rule
            member this.extraExpanded = (property, ExtraExpanded) |> Rule
            member this.ultraExpanded = (property, UltraExpanded) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
        type FontStyle(property) =
            inherit CssRuleWithNormal(property)
            member this.oblique(angle: Angle) =
                let angle = $"oblique {stringifyICssValue angle}" 
                (property, String angle) |> Rule
            member this.italic = (property, Italic) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
        type FontWeight(property) =
            inherit CssRuleWithNormal(property)
            member this.value(weight: int) = (property, Int weight) |> Rule
            member this.bold = (property, Bold) |> Rule
            member this.lighter = (property, Lighter) |> Rule
            member this.bolder = (property, Bolder) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
        type LineHeight(property) =
            inherit CssRuleWithLengthNormal(property)
            member this.value(height: float) = (property, Float height) |> Rule
            member this.bold = (property, Bold) |> Rule
            member this.lighter = (property, Lighter) |> Rule
            member this.bolder = (property, Bolder) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
        type LineBreak(property) =
            inherit CssRuleWithAutoNormal(property)
            member this.loose = (property, Loose) |> Rule
            member this.strict = (property, Strict) |> Rule
            member this.anywhere = (property, Anywhere) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
        type LetterSpacing(property) =
            inherit CssRuleWithLengthNormal(property)

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
        type FontFamily(property) =
            inherit CssRule(property)
            member this.value(family: string) = (property, String family) |> Rule
            member this.value(families: Family list) =
                let families =
                    List.map Fss.Utilities.Helpers.toKebabCase families
                    |> String.concat ", " 
                (property, String families) |> Rule
            member this.serif = (property, Serif) |> Rule
            member this.sansSerif = (property, SansSerif) |> Rule
            member this.monospace = (property, Monospace) |> Rule
            member this.cursive = (property, Cursive) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
        type FontFeatureSettings(property) =
            inherit CssRuleWithNormal(property)
            
            let settingToString value switch = $"\"{stringifyICssValue value}\" {switch}"
            member this.liga switch =
                (property, settingToString Liga switch |> String)
                |> Rule

            member this.dlig switch =
                (property, settingToString Dlig switch |> String)
                |> Rule

            member this.onum switch =
                (property, settingToString Onum switch |> String)
                |> Rule

            member this.lnum switch =
                (property, settingToString Lnum switch |> String)
                |> Rule

            member this.tnum switch =
                (property, settingToString Tnum switch |> String)
                |> Rule

            member this.zero switch =
                (property, settingToString Zero switch |> String)
                |> Rule

            member this.frac switch =
                (property, settingToString Frac switch |> String)
                |> Rule

            member this.sups switch =
                (property, settingToString Sups switch |> String)
                |> Rule

            member this.subs switch =
                (property, settingToString Subs switch |> String)
                |> Rule

            member this.smcp switch =
                (property, settingToString Smcp switch |> String)
                |> Rule

            member this.c2sc switch =
                (property, settingToString C2sc switch |> String)
                |> Rule

            member this.case switch =
                (property, settingToString Case switch |> String)
                |> Rule

            member this.hlig switch =
                (property, settingToString Hlig switch |> String)
                |> Rule

            member this.calt switch =
                (property, settingToString Calt switch |> String)
                |> Rule

            member this.swsh switch =
                (property, settingToString Swsh switch |> String)
                |> Rule

            member this.hist switch =
                (property, settingToString Hist switch |> String)
                |> Rule

            member this.ss(value: int, switch: SettingSwitch) =
                let value = $"\"ss%02i{value}\" %s{switch.ToString()}"

                (property, value |> String)
                |> Rule

            member this.kern switch =
                (property, settingToString Kern switch |> String)
                |> Rule

            member this.locl switch =
                (property, settingToString Locl switch |> String)
                |> Rule

            member this.rlig switch =
                (property, settingToString Rlig switch |> String)
                |> Rule

            member this.medi switch =
                (property, settingToString Medi switch |> String)
                |> Rule

            member this.init switch =
                (property, settingToString Init switch |> String)
                |> Rule

            member this.isol switch =
                (property, settingToString Isol switch |> String)
                |> Rule

            member this.fina switch =
                (property, settingToString Fina switch |> String)
                |> Rule

            member this.mark switch =
                (property, settingToString Mark switch |> String)
                |> Rule

            member this.mkmk switch =
                (property, settingToString Mkmk switch |> String)
                |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
        type FontVariantNumeric(property) =
            inherit CssRuleWithNormal(property)
            member this.ordinal = (property, Ordinal) |> Rule
            member this.slashedZero = (property, SlashedZero) |> Rule
            member this.liningNums = (property, LiningNums) |> Rule
            member this.oldstyleNums = (property, OldstyleNums) |> Rule
            member this.proportionalNums = (property, ProportionalNums) |> Rule
            member this.tabularNums = (property, TabularNums) |> Rule
            member this.diagonalFractions = (property, DiagonalFractions) |> Rule
            member this.stackedFractions = (property, StackedFractions) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
        type FontVariantCaps(property) =
            inherit CssRuleWithNormal(property)
            member this.smallCaps = (property, SmallCaps) |> Rule
            member this.allSmallCaps = (property, AllSmallCaps) |> Rule
            member this.petiteCaps = (property, PetiteCaps) |> Rule
            member this.allPetiteCaps = (property, AllPetiteCaps) |> Rule
            member this.unicase = (property, Unicase) |> Rule
            member this.titlingCaps = (property, TitlingCaps) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
        type FontVariantEastAsian(property) =
            inherit CssRuleWithNormal(property)
            member this.ruby = (property, Ruby) |> Rule
            member this.jis78 = (property, Jis78) |> Rule
            member this.jis83 = (property, Jis83) |> Rule
            member this.jis90 = (property, Jis90) |> Rule
            member this.jis04 = (property, Jis04) |> Rule
            member this.simplified = (property, Simplified) |> Rule
            member this.traditional = (property, Traditional) |> Rule
            member this.fullWidth = (property, FullWidth) |> Rule
            member this.proportionalWidth = (property, ProportionalWidth) |> Rule

        type FontVariantLigatures(property) =
            inherit CssRuleWithNormalNone(property)
            member this.commonLigatures = (property, CommonLigatures) |> Rule
            member this.noCommonLigatures = (property, NoCommonLigatures) |> Rule

            member this.discretionaryLigatures =
                (property, DiscretionaryLigatures) |> Rule

            member this.noDiscretionaryLigatures =
                (property, NoDiscretionaryLigatures) |> Rule

            member this.historicalLigatures = (property, HistoricalLigatures) |> Rule

            member this.noHistoricalLigatures =
                (property, NoHistoricalLigatures) |> Rule

            member this.contextual = (property, Contextual) |> Rule
            member this.noContextual = (property, NoContextual) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
        type FontVariantPosition(property) =
            inherit CssRule(property)
            member this.sub = (property, Sub) |> Rule
            member this.super = (property, Super) |> Rule
