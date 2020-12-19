namespace Fss

module FontTypes =
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

    let fontStyleToString (style: IFontStyle) =
        let stringifyFontStyle =
            function
                | Italic -> "italic"
                | Oblique a -> sprintf "oblique %s" (Units.Angle.value a)

        match style with
            | :? FontStyle as f -> stringifyFontStyle f
            | :? Global as k -> GlobalValue.global' k
            | :? Normal -> GlobalValue.normal
            | _ -> "Unknown font style"

    let fontStretchToString (stretch: IFontStretch) =
        let stringifyStretch =
            function
                | SemiCondensed -> "semi-condensed"
                | Condensed -> "condensed"
                | ExtraCondensed -> "extra-condensed"
                | UltraCondensed -> "ultra-condensed"
                | SemiExpanded -> "semi-expanded"
                | Expanded -> "expanded"
                | ExtraExpanded -> "extra-expanded"
                | UltraExpanded -> "ultra-expanded"

        match stretch with
            | :? FontStretch as f -> stringifyStretch f
            | :? Global as k -> GlobalValue.global' k
            | :? Normal -> GlobalValue.normal
            | :? Units.Percent.Percent as p -> Units.Percent.value p
            | _ -> "Unknown font stretch"

    let fontWeightToString (fontWeight: IFontWeight) =
         let stringifyWeight =
             function
                 | Bold -> "bold"
                 | Lighter -> "lighter"
                 | Bolder -> "bolder"

         match fontWeight with
            | :? CssInt as i -> GlobalValue.int i
            | :? FontWeight as f -> stringifyWeight f
            | :? Global as k -> GlobalValue.global' k
            | :? Normal -> GlobalValue.normal
            | _ -> "Unknown font weight"

    let fontDisplayToString (display: IFontDisplay) =
        let stringifyDisplay =
            function
                | Block -> "block"
                | Swap -> "swap"
                | Fallback -> "fallback"
                | Optional -> "optional"

        match display with
        | :? FontDisplay as f -> stringifyDisplay f
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown font display value"

[<AutoOpen>]
module Font =
    open FontTypes

    let private fontSizeToString (fontSize: IFontSize) =
        let stringifyFontSize =
            function
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

        match fontSize with
        | :? FontSize as f -> stringifyFontSize f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as k -> GlobalValue.global' k
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: IFontFamily) =
        let stringifyFontName (FontName.FontName n) = n
        let stringifyFamily =
            function
                | Serif -> "serif"
                | SansSerif -> "sans-serif"
                | Monospace -> "monospace"
                | Cursive -> "cursive"
                | Custom c -> c
                | FontName n -> stringifyFontName n

        match fontFamily with
            | :? FontFamily as f -> stringifyFamily f
            | :? Global as k -> GlobalValue.global' k
            | _ -> "Unknown font family"

    let private  featureSettingToString (featureSetting: IFontFeatureSetting) =
        let stringifyFeature =
            function
                | Liga switch    -> sprintf "\"liga\" %A" switch
                | Dlig switch    -> sprintf "\"dlig\" %A" switch
                | Onum switch    -> sprintf "\"onum\" %A" switch
                | Lnum switch    -> sprintf "\"lnum\" %A" switch
                | Tnum switch    -> sprintf "\"tnum\" %A" switch
                | Zero switch    -> sprintf "\"zero\" %A" switch
                | Frac switch    -> sprintf "\"frac\" %A" switch
                | Sups switch    -> sprintf "\"sups\" %A" switch
                | Subs switch    -> sprintf "\"subs\" %A" switch
                | Smcp switch    -> sprintf "\"smcp\" %A" switch
                | C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | Case switch    -> sprintf "\"case\" %A" switch
                | Hlig switch    -> sprintf "\"hlig\" %A" switch
                | Calt switch    -> sprintf "\"calt\" %A" switch
                | Swsh switch    -> sprintf "\"swsh\" %A" switch
                | Hist switch    -> sprintf "\"hist\" %A" switch
                | Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | Kern switch    -> sprintf "\"kern\" %A" switch
                | Locl switch    -> sprintf "\"locl\" %A" switch
                | Rlig switch    -> sprintf "\"rlig\" %A" switch
                | Medi switch    -> sprintf "\"medi\" %A" switch
                | Init switch    -> sprintf "\"init\" %A" switch
                | Isol switch    -> sprintf "\"isol\" %A" switch
                | Fina switch    -> sprintf "\"fina\" %A" switch
                | Mark switch    -> sprintf "\"mark\" %A" switch
                | Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? FontFeatureSetting as f -> stringifyFeature f
        | :? Global as k -> GlobalValue.global' k
        | _ -> "unknown font feature setting"

    let private  variantNumericToString (variant: IFontVariantNumeric) =
        let stringifyVariant =
            function
                | Ordinal -> "ordinal"
                | SlashedZero -> "slashed-zero"
                | LiningNums -> "lining-nums"
                | OldstyleNums -> "oldstyle-nums"
                | ProportionalNums -> "proportional-nums"
                | TabularNums -> "tabular-nums"
                | DiagonalFractions -> "diagonal-fractions"
                | StackedFractions -> "stacked-fractions"

        match variant with
        | :? FontVariantNumeric as f -> stringifyVariant f
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: IFontVariantCaps) =
        let stringifyVariant =
            function
                | SmallCaps -> "small-caps"
                | AllSmallCaps -> "all-small-caps"
                | PetiteCaps -> "petite-caps"
                | AllPetiteCaps -> "all-petite-caps"
                | Unicase -> "unicase"
                | TitlingCaps -> "titling-caps"

        match variant with
        | :? FontVariantCaps as f -> stringifyVariant f
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant numeric"

    let private variantEastAsianToString (variant: IFontVariantEastAsian) =
        let stringifyVariant =
            function
            | Ruby -> "ruby"
            | Jis78 -> "jis78"
            | Jis83 -> "jis83"
            | Jis90 -> "jis90"
            | Jis04 -> "jis04"
            | Simplified -> "simplified"
            | Traditional -> "traditional"
            | FullWidth -> "full-width"
            | ProportionalWidth -> "proportional-width"

        match variant with
        | :? FontVariantEastAsian as f -> stringifyVariant f
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant numeric"

    let private  variantLigatureToString (variant: IFontVariantLigature) =
        let stringifyVariant =
            function
            | CommonLigatures -> "common-ligatures"
            | NoCommonLigatures -> "no-common-ligatures"
            | DiscretionaryLigatures -> "discretionary-ligatures"
            | NoDiscretionaryLigatures -> "no-discretionary-ligatures"
            | HistoricalLigatures -> "historical-ligatures"
            | NoHistoricalLigatures -> "no-historical-ligatures"
            | Contextual -> "contextual"
            | NoContextual -> "no-contextual"

        match variant with
        | :? FontVariantLigature as f -> stringifyVariant f
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | :? None -> GlobalValue.none
        | _ -> "Unknown font variant numeric"

    let private lineHeightToString (lineHeight: ILineHeight) =
        match lineHeight with
        | :? CssFloat as f -> GlobalValue.float f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown lineheight"

    let private lineBreakToString (linebreak: ILineBreak) =
        let stringifylineBreak =
            function
                | Loose -> "loose"
                | Strict -> "strict"
                | Anywhere -> "anywhere"

        match linebreak with
        | :? LineBreak as l -> stringifylineBreak l
        | :? Auto -> GlobalValue.auto
        | :? Normal -> GlobalValue.normal
        | :? Global as k -> GlobalValue.global' k
        | _ -> "Unknown line break"


    let private letterSpacingToString (letterSpacing: ILetterSpacing) =
        match letterSpacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as k -> GlobalValue.global' k
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown lineheight"


    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = PropertyValue.cssValue Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: IFontSize) = value |> sizeCssValue'
        static member XxSmall = XxSmall |> sizeCssValue'
        static member XSmall = XSmall |> sizeCssValue'
        static member Small = Small |> sizeCssValue'
        static member Medium = Medium |> sizeCssValue'
        static member Large = Large |> sizeCssValue'
        static member XLarge = XLarge |> sizeCssValue'
        static member XxLarge = XxLarge |> sizeCssValue'
        static member XxxLarge = XxxLarge |> sizeCssValue'
        static member Smaller = Smaller |> sizeCssValue'
        static member Larger = Larger |> sizeCssValue'

        static member Inherit = Inherit |> sizeCssValue'
        static member Initial = Initial |> sizeCssValue'
        static member Unset = Unset |> sizeCssValue'

    let FontSize' (size: IFontSize) = FontSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue value = PropertyValue.cssValue Property.FontStyle value
    let private styleCssValue' value = value |> fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: Units.Angle.Angle) = Oblique angle |> styleCssValue'
        static member Italic = Italic |> styleCssValue'

        static member Normal = Normal |> styleCssValue'
        static member Inherit = Inherit |> styleCssValue'
        static member Initial = Initial |> styleCssValue'
        static member Unset = Unset |> styleCssValue'

    let FontStyle' (style: IFontStyle) = FontStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue value = PropertyValue.cssValue Property.FontStretch value
    let private stretchCssValue' value = value |> fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: Units.Percent.Percent) =
            Units.Percent.value percent
            |> stretchCssValue
        static member SemiCondensed = SemiCondensed |> stretchCssValue'
        static member Condensed = Condensed |> stretchCssValue'
        static member ExtraCondensed = ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = UltraCondensed |> stretchCssValue'
        static member SemiExpanded = SemiExpanded |> stretchCssValue'
        static member Expanded = Expanded |> stretchCssValue'
        static member ExtraExpanded = ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = UltraExpanded |> stretchCssValue'
        static member Normal = Normal |> stretchCssValue'
        static member Inherit = Inherit |> stretchCssValue'
        static member Initial = Initial |> stretchCssValue'
        static member Unset = Unset |> stretchCssValue'

    let FontStretch' (stretch: IFontStretch) = FontStretch.Value(stretch)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue value = PropertyValue.cssValue Property.FontWeight value
    let private weightCssValue' value = value |> fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = Bold |> weightCssValue'
        static member Lighter = Lighter |> weightCssValue'
        static member Bolder = Bolder |> weightCssValue'

        static member Normal = Normal |> weightCssValue'
        static member Inherit = Inherit |> weightCssValue'
        static member Initial = Initial |> weightCssValue'
        static member Unset = Unset |> weightCssValue'

    let FontWeight' (weight: IFontWeight) = FontWeight.Value(weight)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    let private heightCssValue value = PropertyValue.cssValue Property.LineHeight value
    let private heightCssValue' value =
        value
        |> lineHeightToString
        |> heightCssValue
    type LineHeight =
        static member Value (height: ILineHeight) = height |> heightCssValue'

        static member Normal = Normal |> heightCssValue'
        static member Inherit = Inherit |> heightCssValue'
        static member Initial = Initial |>  heightCssValue'
        static member Unset = Unset |>  heightCssValue'

    let LineHeight' (height: ILineHeight) = LineHeight.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue value = PropertyValue.cssValue Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': ILineBreak) = break' |> breakCssValue'
        static member Loose = Loose |> breakCssValue'
        static member Strict = Strict |> breakCssValue'
        static member Anywhere = Anywhere |> breakCssValue'

        static member Normal = Normal |> breakCssValue'
        static member Auto = Auto |> breakCssValue'
        static member Inherit = Inherit |> breakCssValue'
        static member Initial = Initial |>  breakCssValue'
        static member Unset = Unset |>  breakCssValue'

    let LineBreak' (break': ILineBreak) = LineBreak.Value(break')

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    let private spacingCssValue value = PropertyValue.cssValue Property.LetterSpacing value
    let private spacingCssValue' value =
        value
        |> letterSpacingToString
        |> spacingCssValue
    type LetterSpacing =
        static member Value (spacing: ILetterSpacing) = spacing |> spacingCssValue'

        static member Normal = Normal |> spacingCssValue'
        static member Inherit = Inherit |> spacingCssValue'
        static member Initial = Initial |>  spacingCssValue'
        static member Unset = Unset |>  spacingCssValue'

    let LetterSpacing' (height: ILetterSpacing) = LetterSpacing.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue value = PropertyValue.cssValue Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> fontDisplayToString
        |> PropertyValue.cssValue Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = Block |> displayCssValue'
        static member Swap = Swap |> displayCssValue'
        static member Fallback = Fallback |> displayCssValue'
        static member Optional = Optional |> displayCssValue'

        static member Auto = Auto |> displayCssValue'

    let FontDisplay' (display: IFontDisplay) = FontDisplay.Value(display)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    let private familyCssValue value = PropertyValue.cssValue Property.FontFamily value
    let private familyCssValue' value = value |> familyToString |> familyCssValue

    type FontFamily =
        static member Value (fontFamily: IFontFamily) = fontFamily |> familyCssValue'
        static member Values (families: IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member Font (font: FontName) = font |> FontName |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = Serif |> familyCssValue'
        static member SansSerif = SansSerif |> familyCssValue'
        static member Monospace = Monospace |> familyCssValue'
        static member Cursive = Cursive |> familyCssValue'

        static member Inherit = Inherit |> familyCssValue'
        static member Initial = Initial |> familyCssValue'
        static member Unset = Unset |> familyCssValue'

    let FontFamily' (fontFamily: IFontFamily) = FontFamily.Value(fontFamily)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue value = PropertyValue.cssValue Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: SettingSwitch) = Liga switch |> featureSettingCssValue'
        static member Dlig (switch: SettingSwitch) = Dlig switch |> featureSettingCssValue'
        static member Onum (switch: SettingSwitch) = Onum switch |> featureSettingCssValue'
        static member Lnum (switch: SettingSwitch) = Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: SettingSwitch) = Tnum switch |> featureSettingCssValue'
        static member Zero (switch: SettingSwitch) = Zero switch |> featureSettingCssValue'
        static member Frac (switch: SettingSwitch) = Frac switch |> featureSettingCssValue'
        static member Sups (switch: SettingSwitch) = Sups switch |> featureSettingCssValue'
        static member Subs (switch: SettingSwitch) = Subs switch |> featureSettingCssValue'
        static member Smcp (switch: SettingSwitch) = Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: SettingSwitch) = C2sc switch |> featureSettingCssValue'
        static member Case (switch: SettingSwitch) = Case switch |> featureSettingCssValue'
        static member Hlig (switch: SettingSwitch) = Hlig switch |> featureSettingCssValue'
        static member Calt (switch: SettingSwitch) = Calt switch |> featureSettingCssValue'
        static member Swsh (switch: SettingSwitch) = Swsh switch |> featureSettingCssValue'
        static member Hist (switch: SettingSwitch) = Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: SettingSwitch) = Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: SettingSwitch) = Kern switch |> featureSettingCssValue'
        static member Locl (switch: SettingSwitch) = Locl switch |> featureSettingCssValue'
        static member Rlig (switch: SettingSwitch) = Rlig switch |> featureSettingCssValue'
        static member Medi (switch: SettingSwitch) = Medi switch |> featureSettingCssValue'
        static member Init (switch: SettingSwitch) = Init switch |> featureSettingCssValue'
        static member Isol (switch: SettingSwitch) = Isol switch |> featureSettingCssValue'
        static member Fina (switch: SettingSwitch) = Fina switch |> featureSettingCssValue'
        static member Mark (switch: SettingSwitch) = Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: SettingSwitch) = Mkmk switch |> featureSettingCssValue'

        static member Inherit = Inherit |> featureSettingCssValue'
        static member Initial = Initial |> featureSettingCssValue'
        static member Unset = Unset |> featureSettingCssValue'

    let FontFeatureSetting' (featureSetting: IFontFeatureSetting) = FontFeatureSetting.Value(featureSetting)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue value = PropertyValue.cssValue Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = Ordinal |> variantNumericCssValue'
        static member SlashedZero = SlashedZero |> variantNumericCssValue'
        static member LiningNums = LiningNums |> variantNumericCssValue'
        static member OldstyleNums = OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = ProportionalNums |> variantNumericCssValue'
        static member TabularNums = TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = StackedFractions |> variantNumericCssValue'

        static member Normal = Normal |> variantNumericCssValue'
        static member Inherit = Inherit |> variantNumericCssValue'
        static member Initial = Initial |> variantNumericCssValue'
        static member Unset = Unset |> variantNumericCssValue'

    let FontVariantNumeric' (variant: IFontVariantNumeric) = FontVariantNumeric.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue value = PropertyValue.cssValue Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = Unicase |> variantCapsCssValue'
        static member TitlingCaps = TitlingCaps |> variantCapsCssValue'

        static member Normal = Normal |> variantCapsCssValue'
        static member Inherit = Inherit |> variantCapsCssValue'
        static member Initial = Initial |> variantCapsCssValue'
        static member Unset = Unset |> variantCapsCssValue'

    let FontVariantCaps' (variant: IFontVariantCaps) = FontVariantCaps.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue value = PropertyValue.cssValue Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = Ruby |> variantEastAsianCssValue'
        static member Jis78 = Jis78 |> variantEastAsianCssValue'
        static member Jis83 = Jis83 |> variantEastAsianCssValue'
        static member Jis90 = Jis90 |> variantEastAsianCssValue'
        static member Jis04 = Jis04 |> variantEastAsianCssValue'
        static member Simplified = Simplified |> variantEastAsianCssValue'
        static member Traditional = Traditional |> variantEastAsianCssValue'
        static member FullWidth = FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = ProportionalWidth |> variantEastAsianCssValue'

        static member Normal = Normal |> variantEastAsianCssValue'
        static member Inherit = Inherit |> variantEastAsianCssValue'
        static member Initial = Initial |> variantEastAsianCssValue'
        static member Unset = Unset |> variantEastAsianCssValue'

    let FontVariantEastAsian' (variant: IFontVariantEastAsian) = FontVariantEastAsian.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue value = PropertyValue.cssValue Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = Contextual |> variantLigatureCssValue'
        static member NoContextual = NoContextual |> variantLigatureCssValue'

        static member Normal = Normal |> variantLigatureCssValue'
        static member None = None |> variantLigatureCssValue'
        static member Inherit = Inherit |> variantLigatureCssValue'
        static member Initial = Initial |> variantLigatureCssValue'
        static member Unset = Unset |> variantLigatureCssValue'

    let FontVariantLigatures' (ligature: IFontVariantLigature) = FontVariantLigatures.Value(ligature)