namespace Fss

open FssTypes

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: IFontSize) =
        match fontSize with
        | :? Font.FontSize as f -> Utilities.Helpers.duToKebab f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: IFontFamily) =
        let stringifyFontName (Font.FontName n) = n
        let stringifyFamily fontFamily =
            match fontFamily with
                | Font.Custom c -> sprintf "'%s'" c
                | Font.FontFamily.FontName n -> stringifyFontName n
                | _ -> Utilities.Helpers.duToKebab fontFamily

        match fontFamily with
            | :? Font.FontFamily as f -> stringifyFamily f
            | :? Global as g -> GlobalValue.global' g
            | _ -> "Unknown font family"

    let private featureSettingToString (featureSetting: IFontFeatureSetting) =
        let stringifyFeature =
            function
                | Font.Liga switch    -> sprintf "\"liga\" %A" switch
                | Font.Dlig switch    -> sprintf "\"dlig\" %A" switch
                | Font.Onum switch    -> sprintf "\"onum\" %A" switch
                | Font.Lnum switch    -> sprintf "\"lnum\" %A" switch
                | Font.Tnum switch    -> sprintf "\"tnum\" %A" switch
                | Font.Zero switch    -> sprintf "\"zero\" %A" switch
                | Font.Frac switch    -> sprintf "\"frac\" %A" switch
                | Font.Sups switch    -> sprintf "\"sups\" %A" switch
                | Font.Subs switch    -> sprintf "\"subs\" %A" switch
                | Font.Smcp switch    -> sprintf "\"smcp\" %A" switch
                | Font.C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | Font.Case switch    -> sprintf "\"case\" %A" switch
                | Font.Hlig switch    -> sprintf "\"hlig\" %A" switch
                | Font.Calt switch    -> sprintf "\"calt\" %A" switch
                | Font.Swsh switch    -> sprintf "\"swsh\" %A" switch
                | Font.Hist switch    -> sprintf "\"hist\" %A" switch
                | Font.Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | Font.Kern switch    -> sprintf "\"kern\" %A" switch
                | Font.Locl switch    -> sprintf "\"locl\" %A" switch
                | Font.Rlig switch    -> sprintf "\"rlig\" %A" switch
                | Font.Medi switch    -> sprintf "\"medi\" %A" switch
                | Font.Init switch    -> sprintf "\"init\" %A" switch
                | Font.Isol switch    -> sprintf "\"isol\" %A" switch
                | Font.Fina switch    -> sprintf "\"fina\" %A" switch
                | Font.Mark switch    -> sprintf "\"mark\" %A" switch
                | Font.Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? Font.FontFeatureSetting as f -> stringifyFeature f
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown font feature setting"

    let private variantNumericToString (variant: IFontVariantNumeric) =
        match variant with
        | :? Font.FontVariantNumeric as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: IFontVariantCaps) =
        match variant with
        | :? Font.FontVariantCaps as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant caps"

    let private variantEastAsianToString (variant: IFontVariantEastAsian) =
        match variant with
        | :? Font.FontVariantEastAsian as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant east asian"

    let private variantLigatureToString (variant: IFontVariantLigature) =
        match variant with
        | :? Font.FontVariantLigature as f -> Utilities.Helpers.duToKebab f
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | :? None' -> GlobalValue.none
        | _ -> "Unknown font variant ligature"

    let private lineHeightToString (lineHeight: ILineHeight) =
        match lineHeight with
        | :? CssFloat as f -> GlobalValue.float f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown line height"

    let private lineBreakToString (linebreak: ILineBreak) =
        match linebreak with
        | :? Font.LineBreak as l -> Utilities.Helpers.duToLowercase l
        | :? Auto -> GlobalValue.auto
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown line break"

    let private letterSpacingToString (letterSpacing: ILetterSpacing) =
        match letterSpacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown letter spacing"

    let private fontKerningTostring (fontKerning: IFontKerning) =
        match fontKerning with
        | :? Normal -> GlobalValue.normal
        | :? Auto -> GlobalValue.auto
        | :? None' -> GlobalValue.none
        | _ -> "Unknown font kerning"

    let private fontLanguageOverrideToString (fontLanguageOverride: IFontLanguageOverride) =
        match fontLanguageOverride with
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown font language override"

    let private fontSynthesisToString (synthesis: IFontSynthesis) =
        match synthesis with
        | :? Font.FontSynthesis as f -> Utilities.Helpers.duToSpaced f
        | :? None' -> GlobalValue.none
        | _ -> "Unknown font synthesis"

    let private fontVariantPositionToString (variantPosition: IFontVariantPosition) =
        match variantPosition with
        | :? Font.FontVariantPosition as f -> Utilities.Helpers.duToLowercase f
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | _ -> "Unknown font variant position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = PropertyValue.cssValue Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: IFontSize) = value |> sizeCssValue'
        static member XxSmall = Font.XxSmall |> sizeCssValue'
        static member XSmall = Font.XSmall |> sizeCssValue'
        static member Small = Font.Small |> sizeCssValue'
        static member Medium = Font.Medium |> sizeCssValue'
        static member Large = Font.Large |> sizeCssValue'
        static member XLarge = Font.XLarge |> sizeCssValue'
        static member XxLarge = Font.XxLarge |> sizeCssValue'
        static member XxxLarge = Font.XxxLarge |> sizeCssValue'
        static member Smaller = Font.Smaller |> sizeCssValue'
        static member Larger = Font.Larger |> sizeCssValue'

        static member Inherit = Inherit |> sizeCssValue'
        static member Initial = Initial |> sizeCssValue'
        static member Unset = Unset |> sizeCssValue'

    /// <summary>Sets size of font. </summary>
    /// <param name="size">
    ///     can be:
    ///     - <c> FontSize </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSize' (size: IFontSize) = FontSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue value = PropertyValue.cssValue Property.FontStyle value
    let private styleCssValue' value = value |> Font.fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: Units.Angle.Angle) = Font.Oblique angle |> styleCssValue'
        static member Italic = Font.Italic |> styleCssValue'

        static member Normal = Normal |> styleCssValue'
        static member Inherit = Inherit |> styleCssValue'
        static member Initial = Initial |> styleCssValue'
        static member Unset = Unset |> styleCssValue'

    /// <summary>Specifies which style to use on a font. </summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> FontStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontStyle' (style: IFontStyle) = FontStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue value = PropertyValue.cssValue Property.FontStretch value
    let private stretchCssValue' value = value |> Font.fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: Units.Percent.Percent) =
            Units.Percent.value percent
            |> stretchCssValue
        static member SemiCondensed = Font.SemiCondensed |> stretchCssValue'
        static member Condensed = Font.Condensed |> stretchCssValue'
        static member ExtraCondensed = Font.ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = Font.UltraCondensed |> stretchCssValue'
        static member SemiExpanded = Font.SemiExpanded |> stretchCssValue'
        static member Expanded = Font.Expanded |> stretchCssValue'
        static member ExtraExpanded = Font.ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = Font.UltraExpanded |> stretchCssValue'
        static member Normal = Normal |> stretchCssValue'
        static member Inherit = Inherit |> stretchCssValue'
        static member Initial = Initial |> stretchCssValue'
        static member Unset = Unset |> stretchCssValue'

    /// <summary>Specifies width of text characters to be wider or narrower default width. </summary>
    /// <param name="stretch">
    ///     can be:
    ///     - <c> FontStretch </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontStretch' (stretch: IFontStretch) = FontStretch.Value(stretch)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue value = PropertyValue.cssValue Property.FontWeight value
    let private weightCssValue' value = value |> Font.fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = Font.Bold |> weightCssValue'
        static member Lighter = Font.Lighter |> weightCssValue'
        static member Bolder = Font.Bolder |> weightCssValue'

        static member Normal = Normal |> weightCssValue'
        static member Inherit = Inherit |> weightCssValue'
        static member Initial = Initial |> weightCssValue'
        static member Unset = Unset |> weightCssValue'

    /// <summary>Specifies weight(boldness) of font. </summary>
    /// <param name="weight">
    ///     can be:
    ///     - <c> FontWeight </c>
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies the amount of space above and below inline elements. </summary>
    /// <param name="height">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LineHeight' (height: ILineHeight) = LineHeight.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue value = PropertyValue.cssValue Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': ILineBreak) = break' |> breakCssValue'
        static member Loose = Font.Loose |> breakCssValue'
        static member Strict = Font.Strict |> breakCssValue'
        static member Anywhere = Font.Anywhere |> breakCssValue'

        static member Normal = Normal |> breakCssValue'
        static member Auto = Auto |> breakCssValue'
        static member Inherit = Inherit |> breakCssValue'
        static member Initial = Initial |>  breakCssValue'
        static member Unset = Unset |>  breakCssValue'

    /// <summary>Specifies how some asian languages wrap text on newlines. </summary>
    /// <param name="break'">
    ///     can be:
    ///     - <c> LineBreak </c>
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Sets horizontal spacing between text characters. </summary>
    /// <param name="spacing">
    ///     can be:
    ///     - <c> Size </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LetterSpacing' (spacing: ILetterSpacing) = LetterSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue value = PropertyValue.cssValue Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> Font.fontDisplayToString
        |> PropertyValue.cssValue Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = Font.Block |> displayCssValue'
        static member Swap = Font.Swap |> displayCssValue'
        static member Fallback = Font.Fallback |> displayCssValue'
        static member Optional = Font.Optional |> displayCssValue'

        static member Auto = Auto |> displayCssValue'

    /// <summary>Specifies how a font is loaded and displayed.</summary>
    /// <param name="display">
    ///     can be:
    ///     - <c> FontDisplay </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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
        static member Font (font: Font.FontName) = font |> Font.FontFamily.FontName |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = Font.Serif |> familyCssValue'
        static member SansSerif = Font.SansSerif |> familyCssValue'
        static member Monospace = Font.Monospace |> familyCssValue'
        static member Cursive = Font.Cursive |> familyCssValue'

        static member Inherit = Inherit |> familyCssValue'
        static member Initial = Initial |> familyCssValue'
        static member Unset = Unset |> familyCssValue'

    /// <summary>Specify which font to use on the.</summary>
    /// <param name="fontFamily">
    ///     can be:
    ///     - <c> FontFamily </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFamily' (fontFamily: IFontFamily) = FontFamily.Value(fontFamily)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue value = PropertyValue.cssValue Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: Font.SettingSwitch) = Font.Liga switch |> featureSettingCssValue'
        static member Dlig (switch: Font.SettingSwitch) = Font.Dlig switch |> featureSettingCssValue'
        static member Onum (switch: Font.SettingSwitch) = Font.Onum switch |> featureSettingCssValue'
        static member Lnum (switch: Font.SettingSwitch) = Font.Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: Font.SettingSwitch) = Font.Tnum switch |> featureSettingCssValue'
        static member Zero (switch: Font.SettingSwitch) = Font.Zero switch |> featureSettingCssValue'
        static member Frac (switch: Font.SettingSwitch) = Font.Frac switch |> featureSettingCssValue'
        static member Sups (switch: Font.SettingSwitch) = Font.Sups switch |> featureSettingCssValue'
        static member Subs (switch: Font.SettingSwitch) = Font.Subs switch |> featureSettingCssValue'
        static member Smcp (switch: Font.SettingSwitch) = Font.Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: Font.SettingSwitch) = Font.C2sc switch |> featureSettingCssValue'
        static member Case (switch: Font.SettingSwitch) = Font.Case switch |> featureSettingCssValue'
        static member Hlig (switch: Font.SettingSwitch) = Font.Hlig switch |> featureSettingCssValue'
        static member Calt (switch: Font.SettingSwitch) = Font.Calt switch |> featureSettingCssValue'
        static member Swsh (switch: Font.SettingSwitch) = Font.Swsh switch |> featureSettingCssValue'
        static member Hist (switch: Font.SettingSwitch) = Font.Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: Font.SettingSwitch) = Font.Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: Font.SettingSwitch) = Font.Kern switch |> featureSettingCssValue'
        static member Locl (switch: Font.SettingSwitch) = Font.Locl switch |> featureSettingCssValue'
        static member Rlig (switch: Font.SettingSwitch) = Font.Rlig switch |> featureSettingCssValue'
        static member Medi (switch: Font.SettingSwitch) = Font.Medi switch |> featureSettingCssValue'
        static member Init (switch: Font.SettingSwitch) = Font.Init switch |> featureSettingCssValue'
        static member Isol (switch: Font.SettingSwitch) = Font.Isol switch |> featureSettingCssValue'
        static member Fina (switch: Font.SettingSwitch) = Font.Fina switch |> featureSettingCssValue'
        static member Mark (switch: Font.SettingSwitch) = Font.Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: Font.SettingSwitch) = Font.Mkmk switch |> featureSettingCssValue'

        static member Inherit = Inherit |> featureSettingCssValue'
        static member Initial = Initial |> featureSettingCssValue'
        static member Unset = Unset |> featureSettingCssValue'

    /// <summary>Specify more advanced typographic settings.</summary>
    /// <param name="featureSetting">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFeatureSetting' (featureSetting: IFontFeatureSetting) = FontFeatureSetting.Value(featureSetting)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue value = PropertyValue.cssValue Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = Font.Ordinal |> variantNumericCssValue'
        static member SlashedZero = Font.SlashedZero |> variantNumericCssValue'
        static member LiningNums = Font.LiningNums |> variantNumericCssValue'
        static member OldstyleNums = Font.OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = Font.ProportionalNums |> variantNumericCssValue'
        static member TabularNums = Font.TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = Font.DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = Font.StackedFractions |> variantNumericCssValue'

        static member Normal = Normal |> variantNumericCssValue'
        static member Inherit = Inherit |> variantNumericCssValue'
        static member Initial = Initial |> variantNumericCssValue'
        static member Unset = Unset |> variantNumericCssValue'

    /// <summary>Specifies numeric glyphs.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantNumeric' (variant: IFontVariantNumeric) = FontVariantNumeric.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue value = PropertyValue.cssValue Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = Font.SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = Font.AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = Font.PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = Font.AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = Font.Unicase |> variantCapsCssValue'
        static member TitlingCaps = Font.TitlingCaps |> variantCapsCssValue'

        static member Normal = Normal |> variantCapsCssValue'
        static member Inherit = Inherit |> variantCapsCssValue'
        static member Initial = Initial |> variantCapsCssValue'
        static member Unset = Unset |> variantCapsCssValue'

    /// <summary>Specify alternate glyphs for capital letters.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontVariantCaps </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantCaps' (variant: IFontVariantCaps) = FontVariantCaps.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue value = PropertyValue.cssValue Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = Font.Ruby |> variantEastAsianCssValue'
        static member Jis78 = Font.Jis78 |> variantEastAsianCssValue'
        static member Jis83 = Font.Jis83 |> variantEastAsianCssValue'
        static member Jis90 = Font.Jis90 |> variantEastAsianCssValue'
        static member Jis04 = Font.Jis04 |> variantEastAsianCssValue'
        static member Simplified = Font.Simplified |> variantEastAsianCssValue'
        static member Traditional = Font.Traditional |> variantEastAsianCssValue'
        static member FullWidth = Font.FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = Font.ProportionalWidth |> variantEastAsianCssValue'

        static member Normal = Normal |> variantEastAsianCssValue'
        static member Inherit = Inherit |> variantEastAsianCssValue'
        static member Initial = Initial |> variantEastAsianCssValue'
        static member Unset = Unset |> variantEastAsianCssValue'

    /// <summary>Specifies alternate glyphs for East Asian languages.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontVariantEastAsian </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantEastAsian' (variant: IFontVariantEastAsian) = FontVariantEastAsian.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue value = PropertyValue.cssValue Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = Font.CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = Font.NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = Font.DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = Font.NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = Font.HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = Font.NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = Font.Contextual |> variantLigatureCssValue'
        static member NoContextual = Font.NoContextual |> variantLigatureCssValue'

        static member Normal = Normal |> variantLigatureCssValue'
        static member None = None' |> variantLigatureCssValue'
        static member Inherit = Inherit |> variantLigatureCssValue'
        static member Initial = Initial |> variantLigatureCssValue'
        static member Unset = Unset |> variantLigatureCssValue'

    /// <summary>Specifies which ligatures are used.</summary>
    /// <param name="ligature">
    ///     can be:
    ///     - <c> FontVariantLigature </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantLigatures' (ligature: IFontVariantLigature) = FontVariantLigatures.Value(ligature)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
    let private kerningValue value = PropertyValue.cssValue Property.FontKerning value
    let private kerningValue' value = value |> fontKerningTostring |> kerningValue

    type FontKerning =
        static member Value (fontKerning: IFontKerning) = fontKerning |> kerningValue'
        static member Auto = Auto |> kerningValue'
        static member Normal = Normal |> kerningValue'
        static member None = None' |> kerningValue'

    /// <summary>Specifies use of font-kerning.</summary>
    /// <param name="fontKerning">
    ///     can be:
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontKerning' (fontKerning: IFontKerning) = FontKerning.Value(fontKerning)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
    let private fontLanguageOverrideValue value = PropertyValue.cssValue Property.FontLanguageOverride value
    let private fontLanguageOverrideValue' value = value |> fontLanguageOverrideToString |> fontLanguageOverrideValue

    type FontLanguageOverride =
        static member Value (languageOverride: IFontLanguageOverride) = languageOverride |> fontLanguageOverrideValue'
        static member Value (languageOverride: string) = $"\"{languageOverride}\"" |> fontLanguageOverrideValue
        static member Normal = Normal |> fontLanguageOverrideValue'
        static member Inherit = Inherit |> fontLanguageOverrideValue'
        static member Initial = Initial |> fontLanguageOverrideValue'
        static member Unset = Unset |> fontLanguageOverrideValue'

    /// <summary>Specifies language specific glyphs.</summary>
    /// <param name="languageOverride">
    ///     can be:
    ///     - <c> Normal </c>
    ///     - <c> Initial </c>
    ///     - <c> Inherit </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontLanguageOverride' (languageOverride: IFontLanguageOverride) = FontLanguageOverride.Value(languageOverride)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    let private fontSynthesisValue value = PropertyValue.cssValue Property.FontSynthesis value
    let private fontSynthesisValue' value = value |> fontSynthesisToString |> fontSynthesisValue

    type FontSynthesis =
        static member Value (synthesis: IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member Weight = Font.Weight |> fontSynthesisValue'
        static member Style = Font.Style |> fontSynthesisValue'
        static member WeightStyle = Font.WeightStyle |> fontSynthesisValue'
        static member None = None' |> fontSynthesisValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="synthesis">
    ///     can be:
    ///     - <c> FontSynthesis </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSynthesis' (synthesis: IFontSynthesis) = FontSynthesis.Value(synthesis)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    let private fontVariantPositionValue value = PropertyValue.cssValue Property.FontVariantPosition value
    let private fontVariantPositionValue' value = value |> fontVariantPositionToString |> fontVariantPositionValue

    type FontVariantPosition =
        static member Value (variantPosition: IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member Sub = Font.Sub |> fontVariantPositionValue'
        static member Super = Font.Super |> fontVariantPositionValue'
        static member Normal = Normal |> fontVariantPositionValue'
        static member Inherit = Inherit |> fontVariantPositionValue'
        static member Initial = Initial |> fontVariantPositionValue'
        static member Unset = Unset |> fontVariantPositionValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="variantPosition">
    ///     can be:
    ///     - <c> FontVariantPosition </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantPosition' (variantPosition: IFontVariantPosition) = FontVariantPosition.Value(variantPosition)












