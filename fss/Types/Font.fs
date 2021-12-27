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
        type SynthesisHelper =
            | Synthesis of Synthesis list
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Synthesis s ->
                        List.map Fss.Utilities.Helpers.toKebabCase s
                        |> String.concat " "

        type FontSynthesis(property) =
            inherit CssRuleWithNone(property)
            member this.value(synthesis: Synthesis list) = (property, Synthesis synthesis) |> Rule
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

        type StyleHelper =
            | Oblique of Angle
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Oblique o -> $"oblique {stringifyICssValue o}"

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
        type FontStyle(property) =
            inherit CssRuleWithNormal(property)
            member this.oblique(angle: Angle) = (property, Oblique angle) |> Rule
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
        type FamilyHelper =
            | Fonts of Family list
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Fonts families ->
                        List.map Fss.Utilities.Helpers.toKebabCase families
                        |> String.concat ", "

        type FontFamily(property) =
            inherit CssRule(property)
            member this.value(family: string) = (property, String family) |> Rule
            member this.value(families: Family list) = (property, Fonts families) |> Rule
            member this.serif = (property, Serif) |> Rule
            member this.sansSerif = (property, SansSerif) |> Rule
            member this.monospace = (property, Monospace) |> Rule
            member this.cursive = (property, Cursive) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
        type FeatureSettingHelper =
            | WithSwitch of Stringed * SettingSwitch
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | WithSwitch (value, switch) ->
                        $"{stringifyICssValue value} {switch}"

        type FontFeatureSettings(property) =
            inherit CssRuleWithNormal(property)

            member this.liga switch =
                (property, WithSwitch(Stringed "liga", switch))
                |> Rule

            member this.dlig switch =
                (property, WithSwitch(Stringed "dlig", switch))
                |> Rule

            member this.onum switch =
                (property, WithSwitch(Stringed "onum", switch))
                |> Rule

            member this.lnum switch =
                (property, WithSwitch(Stringed "lnum", switch))
                |> Rule

            member this.tnum switch =
                (property, WithSwitch(Stringed "tnum", switch))
                |> Rule

            member this.zero switch =
                (property, WithSwitch(Stringed "zero", switch))
                |> Rule

            member this.frac switch =
                (property, WithSwitch(Stringed "frac", switch))
                |> Rule

            member this.sups switch =
                (property, WithSwitch(Stringed "sups", switch))
                |> Rule

            member this.subs switch =
                (property, WithSwitch(Stringed "subs", switch))
                |> Rule

            member this.smcp switch =
                (property, WithSwitch(Stringed "smcp", switch))
                |> Rule

            member this.c2sc switch =
                (property, WithSwitch(Stringed "c2sc", switch))
                |> Rule

            member this.case switch =
                (property, WithSwitch(Stringed "case", switch))
                |> Rule

            member this.hlig switch =
                (property, WithSwitch(Stringed "hlig", switch))
                |> Rule

            member this.calt switch =
                (property, WithSwitch(Stringed "calt", switch))
                |> Rule

            member this.swsh switch =
                (property, WithSwitch(Stringed "swsh", switch))
                |> Rule

            member this.hist switch =
                (property, WithSwitch(Stringed "hist", switch))
                |> Rule

            member this.ss(value, switch) =
                let value = sprintf "%02i" value

                (property, WithSwitch(Stringed $"ss{value}", switch))
                |> Rule

            member this.kern switch =
                (property, WithSwitch(Stringed "kern", switch))
                |> Rule

            member this.locl switch =
                (property, WithSwitch(Stringed "locl", switch))
                |> Rule

            member this.rlig switch =
                (property, WithSwitch(Stringed "rlig", switch))
                |> Rule

            member this.medi switch =
                (property, WithSwitch(Stringed "medi", switch))
                |> Rule

            member this.init switch =
                (property, WithSwitch(Stringed "init", switch))
                |> Rule

            member this.isol switch =
                (property, WithSwitch(Stringed "isol", switch))
                |> Rule

            member this.fina switch =
                (property, WithSwitch(Stringed "fina", switch))
                |> Rule

            member this.mark switch =
                (property, WithSwitch(Stringed "mark", switch))
                |> Rule

            member this.mkmk switch =
                (property, WithSwitch(Stringed "mkmk", switch))
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
