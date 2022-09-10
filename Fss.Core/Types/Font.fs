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
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | XxSmall -> "xx-small"
                | XSmall -> "x-small"
                | Small -> "small"
                | Medium -> "medium"
                | Large -> "large"
                | XLarge -> "x-large"
                | XxLarge -> "xx-large"
                | XxxLarge -> "xxx-large"
                | Smaller -> "smaller"
                | Larger -> "larger"

    type Style =
        | Italic
        | Oblique
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Italic -> "italic"
                | Oblique -> "oblique"

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
            member this.StringifyCss() =
                match this with
                | SemiCondensed -> "semi-condensed"
                | Condensed -> "condensed"
                | ExtraCondensed -> "extra-condensed"
                | UltraCondensed -> "ultra-condensed"
                | SemiExpanded -> "semi-expanded"
                | Expanded -> "expanded"
                | ExtraExpanded -> "extra-expanded"
                | UltraExpanded -> "ultra-expanded"

    type Weight =
        | Bold
        | Lighter
        | Bolder
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Bold -> "bold"
                | Lighter -> "lighter"
                | Bolder -> "bolder"

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
            member this.StringifyCss() =
                match this with
                | Liga -> "liga"
                | Dlig -> "dlig"
                | Onum -> "onum"
                | Lnum -> "lnum"
                | Tnum -> "tnum"
                | Zero -> "zero"
                | Frac -> "frac"
                | Sups -> "sups"
                | Subs -> "subs"
                | Smcp -> "smcp"
                | C2sc -> "c2sc"
                | Case -> "case"
                | Hlig -> "hlig"
                | Calt -> "calt"
                | Swsh -> "swsh"
                | Hist -> "hist"
                | Ss -> "ss"
                | Kern -> "kern"
                | Locl -> "locl"
                | Rlig -> "rlig"
                | Medi -> "medi"
                | Init -> "init"
                | Isol -> "isol"
                | Fina -> "fina"
                | Mark -> "mark"
                | Mkmk -> "mkmk"

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
            member this.StringifyCss() =
                match this with
                | Ordinal -> "ordinal"
                | SlashedZero -> "slashed-zero"
                | LiningNums -> "lining-nums"
                | OldstyleNums -> "oldstyle-nums"
                | ProportionalNums -> "proportional-nums"
                | TabularNums -> "tabular-nums"
                | DiagonalFractions -> "diagonal-fractions"
                | StackedFractions -> "stacked-fractions"

    type VariantCaps =
        | SmallCaps
        | AllSmallCaps
        | PetiteCaps
        | AllPetiteCaps
        | Unicase
        | TitlingCaps
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | SmallCaps -> "small-caps"
                | AllSmallCaps -> "all-small-caps"
                | PetiteCaps -> "petite-caps"
                | AllPetiteCaps -> "all-petite-caps"
                | Unicase -> "unicase"
                | TitlingCaps -> "titling-caps"

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
            member this.StringifyCss() =
                match this with
                | Ruby -> "ruby"
                | Jis78 -> "jis78"
                | Jis83 -> "jis83"
                | Jis90 -> "jis90"
                | Jis04 -> "jis04"
                | Simplified -> "simplified"
                | Traditional -> "traditional"
                | FullWidth -> "full-width"
                | ProportionalWidth -> "proportional-width"

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
            member this.StringifyCss() =
                match this with
                | CommonLigatures -> "common-ligatures"
                | NoCommonLigatures -> "no-common-ligatures"
                | DiscretionaryLigatures -> "discretionary-ligatures"
                | NoDiscretionaryLigatures -> "no-discretionary-ligatures"
                | HistoricalLigatures -> "historical-ligatures"
                | NoHistoricalLigatures -> "no-historical-ligatures"
                | Contextual -> "contextual"
                | NoContextual -> "no-contextual"

    type Name = Name of string

    type Family =
        | Serif
        | SansSerif
        | Monospace
        | Cursive
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Serif -> "serif"
                | SansSerif -> "sans-serif"
                | Monospace -> "monospace"
                | Cursive -> "cursive"

    type LineBreak =
        | Loose
        | Strict
        | Anywhere
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Loose -> "loose"
                | Strict -> "strict"
                | Anywhere -> "anywhere"

    type Synthesis =
        | Weight
        | Style
        | SmallCaps
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Weight -> "weight"
                | Style -> "style"
                | SmallCaps -> "small-caps"

    type VariantPosition =
        | Sub
        | Super
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Sub -> "sub"
                | Super -> "super"

[<RequireQualifiedAccess>]
module FontClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    type FontSynthesis(property) =
        inherit CssRuleWithNone(property)
        member this.value(synthesis: Font.Synthesis list) =
            let synthesis =
                List.map stringifyICssValue synthesis
                |> String.concat " "
            (property, String synthesis) |> Rule
        /// Bold typeface can be synthesized if needed
        member this.weight = (property, Font.Weight) |> Rule
        /// Italic typeface can be synthesized if needed
        member this.style = (property, Font.Style) |> Rule
        /// Small caps typeface can be synthesized if needed
        member this.smallCaps = (property, Font.SmallCaps) |> Rule

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
        member this.xxSmall = (property, Font.XxSmall) |> Rule
        member this.xSmall = (property, Font.XSmall) |> Rule
        member this.small = (property, Font.Small) |> Rule
        member this.medium = (property, Font.Medium) |> Rule
        member this.large = (property, Font.Large) |> Rule
        member this.xLarge = (property, Font.XLarge) |> Rule
        member this.xxLarge = (property, Font.XxLarge) |> Rule
        member this.xxxLarge = (property, Font.XxxLarge) |> Rule
        member this.smaller = (property, Font.Smaller) |> Rule
        member this.larger = (property, Font.Larger) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    type FontStretch(property) =
        inherit CssRuleWithLengthNormal(property)
        member this.semiCondensed = (property, Font.SemiCondensed) |> Rule
        member this.condensed = (property, Font.Condensed) |> Rule
        member this.extraCondensed = (property, Font.ExtraCondensed) |> Rule
        member this.ultraCondensed = (property, Font.UltraCondensed) |> Rule
        member this.semiExpanded = (property, Font.SemiExpanded) |> Rule
        member this.expanded = (property, Font.Expanded) |> Rule
        member this.extraExpanded = (property, Font.ExtraExpanded) |> Rule
        member this.ultraExpanded = (property, Font.UltraExpanded) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    type FontStyle(property) =
        inherit CssRuleWithNormal(property)
        member this.oblique(angle: Angle) =
            let angle = $"oblique {stringifyICssValue angle}"
            (property, String angle) |> Rule
        member this.italic = (property, Font.Italic) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    type FontWeight(property) =
        inherit CssRuleWithNormal(property)
        member this.value(weight: int) = (property, Int weight) |> Rule
        member this.bold = (property, Font.Bold) |> Rule
        member this.lighter = (property, Font.Lighter) |> Rule
        member this.bolder = (property, Font.Bolder) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    type LineHeight(property) =
        inherit CssRuleWithLengthNormal(property)
        member this.value(height: float) = (property, Float height) |> Rule
        member this.bold = (property, Font.Bold) |> Rule
        member this.lighter = (property, Font.Lighter) |> Rule
        member this.bolder = (property, Font.Bolder) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    type LineBreak(property) =
        inherit CssRuleWithAutoNormal(property)
        member this.loose = (property, Font.Loose) |> Rule
        member this.strict = (property, Font.Strict) |> Rule
        member this.anywhere = (property, Font.Anywhere) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    type LetterSpacing(property) =
        inherit CssRuleWithLengthNormal(property)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    type FontFamily(property) =
        inherit CssRule(property)
        member this.value(family: string) = (property, String family) |> Rule
        member this.value(families: Font.Family list) =
            let families =
                List.map stringifyICssValue families
                |> String.concat ","
            (property, String families) |> Rule
        member this.serif = (property, Font.Serif) |> Rule
        member this.sansSerif = (property, Font.SansSerif) |> Rule
        member this.monospace = (property, Font.Monospace) |> Rule
        member this.cursive = (property, Font.Cursive) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    type FontFeatureSettings(property) =
        inherit CssRuleWithNormal(property)
        let settingToString value switch = $"\"{stringifyICssValue value}\" {switch}"
        member this.liga switch = (property, settingToString Font.Liga switch |> String) |> Rule
        member this.dlig switch = (property, settingToString Font.Dlig switch |> String) |> Rule
        member this.onum switch = (property, settingToString Font.Onum switch |> String) |> Rule
        member this.lnum switch = (property, settingToString Font.Lnum switch |> String) |> Rule
        member this.tnum switch = (property, settingToString Font.Tnum switch |> String) |> Rule
        member this.zero switch = (property, settingToString Font.Zero switch |> String) |> Rule
        member this.frac switch = (property, settingToString Font.Frac switch |> String) |> Rule
        member this.sups switch = (property, settingToString Font.Sups switch |> String) |> Rule
        member this.subs switch = (property, settingToString Font.Subs switch |> String) |> Rule
        member this.smcp switch = (property, settingToString Font.Smcp switch |> String) |> Rule
        member this.c2sc switch = (property, settingToString Font.C2sc switch |> String) |> Rule
        member this.case switch = (property, settingToString Font.Case switch |> String) |> Rule
        member this.hlig switch = (property, settingToString Font.Hlig switch |> String) |> Rule
        member this.calt switch = (property, settingToString Font.Calt switch |> String) |> Rule
        member this.swsh switch = (property, settingToString Font.Swsh switch |> String) |> Rule
        member this.hist switch = (property, settingToString Font.Hist switch |> String) |> Rule
        member this.ss(value: int, switch: Font.SettingSwitch) =
            let value = $"\"ss%02i{value}\" %s{switch.ToString()}"
            (property, value |> String)
            |> Rule
        member this.kern switch = (property, settingToString Font.Kern switch |> String) |> Rule
        member this.locl switch = (property, settingToString Font.Locl switch |> String) |> Rule
        member this.rlig switch = (property, settingToString Font.Rlig switch |> String) |> Rule
        member this.medi switch = (property, settingToString Font.Medi switch |> String) |> Rule
        member this.init switch = (property, settingToString Font.Init switch |> String) |> Rule
        member this.isol switch = (property, settingToString Font.Isol switch |> String) |> Rule
        member this.fina switch = (property, settingToString Font.Fina switch |> String) |> Rule
        member this.mark switch = (property, settingToString Font.Mark switch |> String) |> Rule
        member this.mkmk switch = (property, settingToString Font.Mkmk switch |> String) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    type FontVariantNumeric(property) =
        inherit CssRuleWithNormal(property)
        member this.ordinal = (property, Font.Ordinal) |> Rule
        member this.slashedZero = (property, Font.SlashedZero) |> Rule
        member this.liningNums = (property, Font.LiningNums) |> Rule
        member this.oldstyleNums = (property, Font.OldstyleNums) |> Rule
        member this.proportionalNums = (property, Font.ProportionalNums) |> Rule
        member this.tabularNums = (property, Font.TabularNums) |> Rule
        member this.diagonalFractions = (property, Font.DiagonalFractions) |> Rule
        member this.stackedFractions = (property, Font.StackedFractions) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    type FontVariantCaps(property) =
        inherit CssRuleWithNormal(property)
        member this.smallCaps = (property, Font.SmallCaps) |> Rule
        member this.allSmallCaps = (property, Font.AllSmallCaps) |> Rule
        member this.petiteCaps = (property, Font.PetiteCaps) |> Rule
        member this.allPetiteCaps = (property, Font.AllPetiteCaps) |> Rule
        member this.unicase = (property, Font.Unicase) |> Rule
        member this.titlingCaps = (property, Font.TitlingCaps) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    type FontVariantEastAsian(property) =
        inherit CssRuleWithNormal(property)
        member this.ruby = (property, Font.Ruby) |> Rule
        member this.jis78 = (property, Font.Jis78) |> Rule
        member this.jis83 = (property, Font.Jis83) |> Rule
        member this.jis90 = (property, Font.Jis90) |> Rule
        member this.jis04 = (property, Font.Jis04) |> Rule
        member this.simplified = (property, Font.Simplified) |> Rule
        member this.traditional = (property, Font.Traditional) |> Rule
        member this.fullWidth = (property, Font.FullWidth) |> Rule
        member this.proportionalWidth = (property, Font.ProportionalWidth) |> Rule

    type FontVariantLigatures(property) =
        inherit CssRuleWithNormalNone(property)
        member this.commonLigatures = (property, Font.CommonLigatures) |> Rule
        member this.noCommonLigatures = (property, Font.NoCommonLigatures) |> Rule
        member this.discretionaryLigatures = (property, Font.DiscretionaryLigatures) |> Rule
        member this.noDiscretionaryLigatures = (property, Font.NoDiscretionaryLigatures) |> Rule
        member this.historicalLigatures = (property, Font.HistoricalLigatures) |> Rule
        member this.noHistoricalLigatures = (property, Font.NoHistoricalLigatures) |> Rule
        member this.contextual = (property, Font.Contextual) |> Rule
        member this.noContextual = (property, Font.NoContextual) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    type FontVariantPosition(property) =
        inherit CssRule(property)
        member this.sub = (property, Font.Sub) |> Rule
        member this.super = (property, Font.Super) |> Rule
