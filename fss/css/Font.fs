namespace Fss

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: Types.IFontSize) =
        match fontSize with
        | :? Types.FontSize as f -> Utilities.Helpers.duToKebab f
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: Types.IFontFamily) =
        let stringifyFontName (Types.FontName n) = n
        let stringifyFamily fontFamily =
            match fontFamily with
                | Types.Custom c -> sprintf "'%s'" c
                | Types.FontFamily.FontName n -> stringifyFontName n
                | _ -> Utilities.Helpers.duToKebab fontFamily

        match fontFamily with
            | :? Types.FontFamily as f -> stringifyFamily f
            | :? Types.Keywords as k -> Types.keywordsToString k
            | _ -> "Unknown font family"

    let private featureSettingToString (featureSetting: Types.IFontFeatureSetting) =
        let stringifyFeature =
            function
                | Types.Liga switch    -> sprintf "\"liga\" %A" switch
                | Types.Dlig switch    -> sprintf "\"dlig\" %A" switch
                | Types.Onum switch    -> sprintf "\"onum\" %A" switch
                | Types.Lnum switch    -> sprintf "\"lnum\" %A" switch
                | Types.Tnum switch    -> sprintf "\"tnum\" %A" switch
                | Types.Zero switch    -> sprintf "\"zero\" %A" switch
                | Types.Frac switch    -> sprintf "\"frac\" %A" switch
                | Types.Sups switch    -> sprintf "\"sups\" %A" switch
                | Types.Subs switch    -> sprintf "\"subs\" %A" switch
                | Types.Smcp switch    -> sprintf "\"smcp\" %A" switch
                | Types.C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | Types.Case switch    -> sprintf "\"case\" %A" switch
                | Types.Hlig switch    -> sprintf "\"hlig\" %A" switch
                | Types.Calt switch    -> sprintf "\"calt\" %A" switch
                | Types.Swsh switch    -> sprintf "\"swsh\" %A" switch
                | Types.Hist switch    -> sprintf "\"hist\" %A" switch
                | Types.Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | Types.Kern switch    -> sprintf "\"kern\" %A" switch
                | Types.Locl switch    -> sprintf "\"locl\" %A" switch
                | Types.Rlig switch    -> sprintf "\"rlig\" %A" switch
                | Types.Medi switch    -> sprintf "\"medi\" %A" switch
                | Types.Init switch    -> sprintf "\"init\" %A" switch
                | Types.Isol switch    -> sprintf "\"isol\" %A" switch
                | Types.Fina switch    -> sprintf "\"fina\" %A" switch
                | Types.Mark switch    -> sprintf "\"mark\" %A" switch
                | Types.Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? Types.FontFeatureSetting as f -> stringifyFeature f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown font feature setting"

    let private variantNumericToString (variant: Types.IFontVariantNumeric) =
        match variant with
        | :? Types.FontVariantNumeric as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: Types.IFontVariantCaps) =
        match variant with
        | :? Types.FontVariantCaps as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown font variant caps"

    let private variantEastAsianToString (variant: Types.IFontVariantEastAsian) =
        match variant with
        | :? Types.FontVariantEastAsian as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown font variant east asian"

    let private variantLigatureToString (variant: Types.IFontVariantLigature) =
        match variant with
        | :? Types.FontVariantLigature as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | :? Types.None' -> Types.none
        | _ -> "Unknown font variant ligature"

    let private lineHeightToString (lineHeight: Types.ILineHeight) =
        match lineHeight with
        | :? Types.Float as f -> Types.FloatToString f
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown line height"

    let private lineBreakToString (linebreak: Types.ILineBreak) =
        match linebreak with
        | :? Types.LineBreak as l -> Utilities.Helpers.duToLowercase l
        | :? Types.Auto -> Types.auto
        | :? Types.Normal -> Types.normal
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown line break"

    let private letterSpacingToString (letterSpacing: Types.ILetterSpacing) =
        match letterSpacing with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown letter spacing"

    let private fontKerningTostring (fontKerning: Types.IFontKerning) =
        match fontKerning with
        | :? Types.Normal -> Types.normal
        | :? Types.Auto -> Types.auto
        | :? Types.None' -> Types.none
        | _ -> "Unknown font kerning"

    let private fontLanguageOverrideToString (fontLanguageOverride: Types.IFontLanguageOverride) =
        match fontLanguageOverride with
        | :? Types.Normal -> Types.normal
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown font language override"

    let private fontSynthesisToString (synthesis: Types.IFontSynthesis) =
        match synthesis with
        | :? Types.FontSynthesis as f -> Utilities.Helpers.duToSpaced f
        | :? Types.None' -> Types.none
        | _ -> "Unknown font synthesis"

    let private fontVariantPositionToString (variantPosition: Types.IFontVariantPosition) =
        match variantPosition with
        | :? Types.FontVariantPosition as f -> Utilities.Helpers.duToLowercase f
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | _ -> "Unknown font variant position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = Types.cssValue Types.Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: Types.IFontSize) = value |> sizeCssValue'
        static member XxSmall = Types.XxSmall |> sizeCssValue'
        static member XSmall = Types.XSmall |> sizeCssValue'
        static member Small = Types.Small |> sizeCssValue'
        static member Medium = Types.FontSize.Medium |> sizeCssValue'
        static member Large = Types.Large |> sizeCssValue'
        static member XLarge = Types.XLarge |> sizeCssValue'
        static member XxLarge = Types.XxLarge |> sizeCssValue'
        static member XxxLarge = Types.XxxLarge |> sizeCssValue'
        static member Smaller = Types.Smaller |> sizeCssValue'
        static member Larger = Types.Larger |> sizeCssValue'

        static member Inherit = Types.Inherit |> sizeCssValue'
        static member Initial = Types.Initial |> sizeCssValue'
        static member Unset = Types.Unset |> sizeCssValue'

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
    let FontSize' (size: Types.IFontSize) = FontSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue value = Types.cssValue Types.Property.FontStyle value
    let private styleCssValue' value = value |> Types.fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: Types.IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: Types.Angle) = Types.Oblique angle |> styleCssValue'
        static member Italic = Types.Italic |> styleCssValue'

        static member Normal = Types.Normal |> styleCssValue'
        static member Inherit = Types.Inherit |> styleCssValue'
        static member Initial = Types.Initial |> styleCssValue'
        static member Unset = Types.Unset |> styleCssValue'

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
    let FontStyle' (style: Types.IFontStyle) = FontStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue value = Types.cssValue Types.Property.FontStretch value
    let private stretchCssValue' value = value |> Types.fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: Types.IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: Types.Percent) =
            Types.percentToString percent
            |> stretchCssValue
        static member SemiCondensed = Types.SemiCondensed |> stretchCssValue'
        static member Condensed = Types.Condensed |> stretchCssValue'
        static member ExtraCondensed = Types.ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = Types.UltraCondensed |> stretchCssValue'
        static member SemiExpanded = Types.SemiExpanded |> stretchCssValue'
        static member Expanded = Types.Expanded |> stretchCssValue'
        static member ExtraExpanded = Types.ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = Types.UltraExpanded |> stretchCssValue'
        static member Normal = Types.Normal |> stretchCssValue'
        static member Inherit = Types.Inherit |> stretchCssValue'
        static member Initial = Types.Initial |> stretchCssValue'
        static member Unset = Types.Unset |> stretchCssValue'

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
    let FontStretch' (stretch: Types.IFontStretch) = FontStretch.Value(stretch)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue value = Types.cssValue Types.Property.FontWeight value
    let private weightCssValue' value = value |> Types.fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: Types.IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = Types.Bold |> weightCssValue'
        static member Lighter = Types.Lighter |> weightCssValue'
        static member Bolder = Types.Bolder |> weightCssValue'

        static member Normal = Types.Normal |> weightCssValue'
        static member Inherit = Types.Inherit |> weightCssValue'
        static member Initial = Types.Initial |> weightCssValue'
        static member Unset = Types.Unset |> weightCssValue'

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
    let FontWeight' (weight: Types.IFontWeight) = FontWeight.Value(weight)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    let private heightCssValue value = Types.cssValue Types.Property.LineHeight value
    let private heightCssValue' value =
        value
        |> lineHeightToString
        |> heightCssValue
    type LineHeight =
        static member Value (height: Types.ILineHeight) = height |> heightCssValue'

        static member Normal = Types.Normal |> heightCssValue'
        static member Inherit = Types.Inherit |> heightCssValue'
        static member Initial = Types.Initial |>  heightCssValue'
        static member Unset = Types.Unset |>  heightCssValue'

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
    let LineHeight' (height: Types.ILineHeight) = LineHeight.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue value = Types.cssValue Types.Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': Types.ILineBreak) = break' |> breakCssValue'
        static member Loose = Types.Loose |> breakCssValue'
        static member Strict = Types.Strict |> breakCssValue'
        static member Anywhere = Types.LineBreak.Anywhere |> breakCssValue'

        static member Normal = Types.Normal |> breakCssValue'
        static member Auto = Types.Auto |> breakCssValue'
        static member Inherit = Types.Inherit |> breakCssValue'
        static member Initial = Types.Initial |>  breakCssValue'
        static member Unset = Types.Unset |>  breakCssValue'

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
    let LineBreak' (break': Types.ILineBreak) = LineBreak.Value(break')

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    let private spacingCssValue value = Types.cssValue Types.Property.LetterSpacing value
    let private spacingCssValue' value =
        value
        |> letterSpacingToString
        |> spacingCssValue
    type LetterSpacing =
        static member Value (spacing: Types.ILetterSpacing) = spacing |> spacingCssValue'

        static member Normal = Types.Normal |> spacingCssValue'
        static member Inherit = Types.Inherit |> spacingCssValue'
        static member Initial = Types.Initial |>  spacingCssValue'
        static member Unset = Types.Unset |>  spacingCssValue'

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
    let LetterSpacing' (spacing: Types.ILetterSpacing) = LetterSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue value = Types.cssValue Types.Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> Types.fontDisplayToString
        |> Types.cssValue Types.Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: Types.IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = Types.FontDisplay.Block |> displayCssValue'
        static member Swap = Types.Swap |> displayCssValue'
        static member Fallback = Types.Fallback |> displayCssValue'
        static member Optional = Types.Optional |> displayCssValue'

        static member Auto = Types.Auto |> displayCssValue'

    /// <summary>Specifies how a font is loaded and displayed.</summary>
    /// <param name="display">
    ///     can be:
    ///     - <c> FontDisplay </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontDisplay' (display: Types.IFontDisplay) = FontDisplay.Value(display)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    let private familyCssValue value = Types.cssValue Types.Property.FontFamily value
    let private familyCssValue' value = value |> familyToString |> familyCssValue

    type FontFamily =
        static member Value (fontFamily: Types.IFontFamily) = fontFamily |> familyCssValue'
        static member Values (families: Types.IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member Font (font: Types.FontName) = font |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = Types.Serif |> familyCssValue'
        static member SansSerif = Types.SansSerif |> familyCssValue'
        static member Monospace = Types.Monospace |> familyCssValue'
        static member Cursive = Types.Cursive |> familyCssValue'

        static member Inherit = Types.Inherit |> familyCssValue'
        static member Initial = Types.Initial |> familyCssValue'
        static member Unset = Types.Unset |> familyCssValue'

    /// <summary>Specify which font to use on the.</summary>
    /// <param name="fontFamily">
    ///     can be:
    ///     - <c> FontFamily </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFamily' (fontFamily: Types.IFontFamily) = FontFamily.Value(fontFamily)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue value = Types.cssValue Types.Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: Types.IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: Types.SettingSwitch) = Types.Liga switch |> featureSettingCssValue'
        static member Dlig (switch: Types.SettingSwitch) = Types.Dlig switch |> featureSettingCssValue'
        static member Onum (switch: Types.SettingSwitch) = Types.Onum switch |> featureSettingCssValue'
        static member Lnum (switch: Types.SettingSwitch) = Types.Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: Types.SettingSwitch) = Types.Tnum switch |> featureSettingCssValue'
        static member Zero (switch: Types.SettingSwitch) = Types.Zero switch |> featureSettingCssValue'
        static member Frac (switch: Types.SettingSwitch) = Types.Frac switch |> featureSettingCssValue'
        static member Sups (switch: Types.SettingSwitch) = Types.Sups switch |> featureSettingCssValue'
        static member Subs (switch: Types.SettingSwitch) = Types.Subs switch |> featureSettingCssValue'
        static member Smcp (switch: Types.SettingSwitch) = Types.Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: Types.SettingSwitch) = Types.C2sc switch |> featureSettingCssValue'
        static member Case (switch: Types.SettingSwitch) = Types.Case switch |> featureSettingCssValue'
        static member Hlig (switch: Types.SettingSwitch) = Types.Hlig switch |> featureSettingCssValue'
        static member Calt (switch: Types.SettingSwitch) = Types.Calt switch |> featureSettingCssValue'
        static member Swsh (switch: Types.SettingSwitch) = Types.Swsh switch |> featureSettingCssValue'
        static member Hist (switch: Types.SettingSwitch) = Types.Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: Types.SettingSwitch) = Types.Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: Types.SettingSwitch) = Types.Kern switch |> featureSettingCssValue'
        static member Locl (switch: Types.SettingSwitch) = Types.Locl switch |> featureSettingCssValue'
        static member Rlig (switch: Types.SettingSwitch) = Types.Rlig switch |> featureSettingCssValue'
        static member Medi (switch: Types.SettingSwitch) = Types.Medi switch |> featureSettingCssValue'
        static member Init (switch: Types.SettingSwitch) = Types.Init switch |> featureSettingCssValue'
        static member Isol (switch: Types.SettingSwitch) = Types.Isol switch |> featureSettingCssValue'
        static member Fina (switch: Types.SettingSwitch) = Types.Fina switch |> featureSettingCssValue'
        static member Mark (switch: Types.SettingSwitch) = Types.Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: Types.SettingSwitch) = Types.Mkmk switch |> featureSettingCssValue'

        static member Inherit = Types.Inherit |> featureSettingCssValue'
        static member Initial = Types.Initial |> featureSettingCssValue'
        static member Unset = Types.Unset |> featureSettingCssValue'

    /// <summary>Specify more advanced typographic settings.</summary>
    /// <param name="featureSetting">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFeatureSetting' (featureSetting: Types.IFontFeatureSetting) = FontFeatureSetting.Value(featureSetting)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue value = Types.cssValue Types.Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: Types.IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = Types.Ordinal |> variantNumericCssValue'
        static member SlashedZero = Types.SlashedZero |> variantNumericCssValue'
        static member LiningNums = Types.LiningNums |> variantNumericCssValue'
        static member OldstyleNums = Types.OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = Types.ProportionalNums |> variantNumericCssValue'
        static member TabularNums = Types.TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = Types.DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = Types.StackedFractions |> variantNumericCssValue'

        static member Normal = Types.Normal |> variantNumericCssValue'
        static member Inherit = Types.Inherit |> variantNumericCssValue'
        static member Initial = Types.Initial |> variantNumericCssValue'
        static member Unset = Types.Unset |> variantNumericCssValue'

    /// <summary>Specifies numeric glyphs.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantNumeric' (variant: Types.IFontVariantNumeric) = FontVariantNumeric.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue value = Types.cssValue Types.Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: Types.IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = Types.SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = Types.AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = Types.PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = Types.AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = Types.Unicase |> variantCapsCssValue'
        static member TitlingCaps = Types.TitlingCaps |> variantCapsCssValue'

        static member Normal = Types.Normal |> variantCapsCssValue'
        static member Inherit = Types.Inherit |> variantCapsCssValue'
        static member Initial = Types.Initial |> variantCapsCssValue'
        static member Unset = Types.Unset |> variantCapsCssValue'

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
    let FontVariantCaps' (variant: Types.IFontVariantCaps) = FontVariantCaps.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue value = Types.cssValue Types.Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: Types.IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = Types.Ruby |> variantEastAsianCssValue'
        static member Jis78 = Types.Jis78 |> variantEastAsianCssValue'
        static member Jis83 = Types.Jis83 |> variantEastAsianCssValue'
        static member Jis90 = Types.Jis90 |> variantEastAsianCssValue'
        static member Jis04 = Types.Jis04 |> variantEastAsianCssValue'
        static member Simplified = Types.Simplified |> variantEastAsianCssValue'
        static member Traditional = Types.Traditional |> variantEastAsianCssValue'
        static member FullWidth = Types.FontVariantEastAsian.FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = Types.ProportionalWidth |> variantEastAsianCssValue'

        static member Normal = Types.Normal |> variantEastAsianCssValue'
        static member Inherit = Types.Inherit |> variantEastAsianCssValue'
        static member Initial = Types.Initial |> variantEastAsianCssValue'
        static member Unset = Types.Unset |> variantEastAsianCssValue'

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
    let FontVariantEastAsian' (variant: Types.IFontVariantEastAsian) = FontVariantEastAsian.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue value = Types.cssValue Types.Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: Types.IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = Types.CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = Types.NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = Types.DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = Types.NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = Types.HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = Types.NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = Types.Contextual |> variantLigatureCssValue'
        static member NoContextual = Types.NoContextual |> variantLigatureCssValue'

        static member Normal = Types.Normal |> variantLigatureCssValue'
        static member None = Types.None' |> variantLigatureCssValue'
        static member Inherit = Types.Inherit |> variantLigatureCssValue'
        static member Initial = Types.Initial |> variantLigatureCssValue'
        static member Unset = Types.Unset |> variantLigatureCssValue'

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
    let FontVariantLigatures' (ligature: Types.IFontVariantLigature) = FontVariantLigatures.Value(ligature)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
    let private kerningValue value = Types.cssValue Types.Property.FontKerning value
    let private kerningValue' value = value |> fontKerningTostring |> kerningValue

    type FontKerning =
        static member Value (fontKerning: Types.IFontKerning) = fontKerning |> kerningValue'
        static member Auto = Types.Auto |> kerningValue'
        static member Normal = Types.Normal |> kerningValue'
        static member None = Types.None' |> kerningValue'

    /// <summary>Specifies use of font-kerning.</summary>
    /// <param name="fontKerning">
    ///     can be:
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontKerning' (fontKerning: Types.IFontKerning) = FontKerning.Value(fontKerning)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
    let private fontLanguageOverrideValue value = Types.cssValue Types.Property.FontLanguageOverride value
    let private fontLanguageOverrideValue' value = value |> fontLanguageOverrideToString |> fontLanguageOverrideValue

    type FontLanguageOverride =
        static member Value (languageOverride: Types.IFontLanguageOverride) = languageOverride |> fontLanguageOverrideValue'
        static member Value (languageOverride: string) = $"\"{languageOverride}\"" |> fontLanguageOverrideValue
        static member Normal = Types.Normal |> fontLanguageOverrideValue'
        static member Inherit = Types.Inherit |> fontLanguageOverrideValue'
        static member Initial = Types.Initial |> fontLanguageOverrideValue'
        static member Unset = Types.Unset |> fontLanguageOverrideValue'

    /// <summary>Specifies language specific glyphs.</summary>
    /// <param name="languageOverride">
    ///     can be:
    ///     - <c> Normal </c>
    ///     - <c> Initial </c>
    ///     - <c> Inherit </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontLanguageOverride' (languageOverride: Types.IFontLanguageOverride) = FontLanguageOverride.Value(languageOverride)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    let private fontSynthesisValue value = Types.cssValue Types.Property.FontSynthesis value
    let private fontSynthesisValue' value = value |> fontSynthesisToString |> fontSynthesisValue

    type FontSynthesis =
        static member Value (synthesis: Types.IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member Weight = Types.Weight |> fontSynthesisValue'
        static member Style = Types.Style |> fontSynthesisValue'
        static member WeightStyle = Types.WeightStyle |> fontSynthesisValue'
        static member None = Types.None' |> fontSynthesisValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="synthesis">
    ///     can be:
    ///     - <c> FontSynthesis </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSynthesis' (synthesis: Types.IFontSynthesis) = FontSynthesis.Value(synthesis)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    let private fontVariantPositionValue value = Types.cssValue Types.Property.FontVariantPosition value
    let private fontVariantPositionValue' value = value |> fontVariantPositionToString |> fontVariantPositionValue

    type FontVariantPosition =
        static member Value (variantPosition: Types.IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member Sub = Types.FontVariantPosition.Sub |> fontVariantPositionValue'
        static member Super = Types.FontVariantPosition.Super |> fontVariantPositionValue'
        static member Normal = Types.Normal |> fontVariantPositionValue'
        static member Inherit = Types.Inherit |> fontVariantPositionValue'
        static member Initial = Types.Initial |> fontVariantPositionValue'
        static member Unset = Types.Unset |> fontVariantPositionValue'

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
    let FontVariantPosition' (variantPosition: Types.IFontVariantPosition) = FontVariantPosition.Value(variantPosition)












