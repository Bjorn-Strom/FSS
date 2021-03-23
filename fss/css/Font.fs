namespace Fss

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: Types.IFontSize) =
        match fontSize with
        | :? Types.Font.Size as f -> Utilities.Helpers.duToKebab f
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: Types.IFontFamily) =
        let stringifyFontName (Types.Font.Name n) = n
        let stringifyFamily fontFamily =
            match fontFamily with
                | Types.Font.Custom c -> sprintf "'%s'" c
                | Types.Font.Family.Name n -> stringifyFontName n
                | _ -> Utilities.Helpers.duToKebab fontFamily

        match fontFamily with
            | :? Types.Font.Family as f -> stringifyFamily f
            | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
            | _ -> "Unknown font family"

    let private featureSettingToString (featureSetting: Types.IFontFeatureSetting) =
        let stringifyFeature =
            function
                | Types.Font.Liga switch    -> sprintf "\"liga\" %A" switch
                | Types.Font.Dlig switch    -> sprintf "\"dlig\" %A" switch
                | Types.Font.Onum switch    -> sprintf "\"onum\" %A" switch
                | Types.Font.Lnum switch    -> sprintf "\"lnum\" %A" switch
                | Types.Font.Tnum switch    -> sprintf "\"tnum\" %A" switch
                | Types.Font.Zero switch    -> sprintf "\"zero\" %A" switch
                | Types.Font.Frac switch    -> sprintf "\"frac\" %A" switch
                | Types.Font.Sups switch    -> sprintf "\"sups\" %A" switch
                | Types.Font.Subs switch    -> sprintf "\"subs\" %A" switch
                | Types.Font.Smcp switch    -> sprintf "\"smcp\" %A" switch
                | Types.Font.C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | Types.Font.Case switch    -> sprintf "\"case\" %A" switch
                | Types.Font.Hlig switch    -> sprintf "\"hlig\" %A" switch
                | Types.Font.Calt switch    -> sprintf "\"calt\" %A" switch
                | Types.Font.Swsh switch    -> sprintf "\"swsh\" %A" switch
                | Types.Font.Hist switch    -> sprintf "\"hist\" %A" switch
                | Types.Font.Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | Types.Font.Kern switch    -> sprintf "\"kern\" %A" switch
                | Types.Font.Locl switch    -> sprintf "\"locl\" %A" switch
                | Types.Font.Rlig switch    -> sprintf "\"rlig\" %A" switch
                | Types.Font.Medi switch    -> sprintf "\"medi\" %A" switch
                | Types.Font.Init switch    -> sprintf "\"init\" %A" switch
                | Types.Font.Isol switch    -> sprintf "\"isol\" %A" switch
                | Types.Font.Fina switch    -> sprintf "\"fina\" %A" switch
                | Types.Font.Mark switch    -> sprintf "\"mark\" %A" switch
                | Types.Font.Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? Types.Font.FeatureSetting as f -> stringifyFeature f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "unknown font feature setting"

    let private variantNumericToString (variant: Types.IFontVariantNumeric) =
        match variant with
        | :? Types.Font.VariantNumeric as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: Types.IFontVariantCaps) =
        match variant with
        | :? Types.Font.VariantCaps as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown font variant caps"

    let private variantEastAsianToString (variant: Types.IFontVariantEastAsian) =
        match variant with
        | :? Types.Font.VariantEastAsian as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown font variant east asian"

    let private variantLigatureToString (variant: Types.IFontVariantLigature) =
        match variant with
        | :? Types.Font.VariantLigature as f -> Utilities.Helpers.duToKebab f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown font variant ligature"

    let private lineHeightToString (lineHeight: Types.ILineHeight) =
        match lineHeight with
        | :? Types.CssFloat as f -> Types.masterTypeHelpers.FloatToString f
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown line height"

    let private lineBreakToString (linebreak: Types.ILineBreak) =
        match linebreak with
        | :? Types.Font.LineBreak as l -> Utilities.Helpers.duToLowercase l
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown line break"

    let private letterSpacingToString (letterSpacing: Types.ILetterSpacing) =
        match letterSpacing with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown letter spacing"

    let private fontKerningTostring (fontKerning: Types.IFontKerning) =
        match fontKerning with
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown font kerning"

    let private fontLanguageOverrideToString (fontLanguageOverride: Types.IFontLanguageOverride) =
        match fontLanguageOverride with
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown font language override"

    let private fontSynthesisToString (synthesis: Types.IFontSynthesis) =
        match synthesis with
        | :? Types.Font.Synthesis as f -> Utilities.Helpers.duToSpaced f
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown font synthesis"

    let private fontVariantPositionToString (variantPosition: Types.IFontVariantPosition) =
        match variantPosition with
        | :? Types.Font.VariantPosition as f -> Utilities.Helpers.duToLowercase f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "Unknown font variant position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = Types.propertyHelpers.cssValue Types.Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: Types.IFontSize) = value |> sizeCssValue'
        static member XxSmall = Types.Font.XxSmall |> sizeCssValue'
        static member XSmall = Types.Font.XSmall |> sizeCssValue'
        static member Small = Types.Font.Small |> sizeCssValue'
        static member Medium = Types.Font.Size.Medium |> sizeCssValue'
        static member Large = Types.Font.Large |> sizeCssValue'
        static member XLarge = Types.Font.XLarge |> sizeCssValue'
        static member XxLarge = Types.Font.XxLarge |> sizeCssValue'
        static member XxxLarge = Types.Font.XxxLarge |> sizeCssValue'
        static member Smaller = Types.Font.Smaller |> sizeCssValue'
        static member Larger = Types.Font.Larger |> sizeCssValue'

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
    let private styleCssValue value = Types.propertyHelpers.cssValue Types.Property.FontStyle value
    let private styleCssValue' value = value |> Types.fontHelpers.fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: Types.IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: Types.Angle) = Types.Font.Oblique angle |> styleCssValue'
        static member Italic = Types.Font.Italic |> styleCssValue'

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
    let private stretchCssValue value = Types.propertyHelpers.cssValue Types.Property.FontStretch value
    let private stretchCssValue' value = value |> Types.fontHelpers.fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: Types.IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: Types.Percent) =
            Types.unitHelpers.percentToString percent
            |> stretchCssValue
        static member SemiCondensed = Types.Font.SemiCondensed |> stretchCssValue'
        static member Condensed = Types.Font.Condensed |> stretchCssValue'
        static member ExtraCondensed = Types.Font.ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = Types.Font.UltraCondensed |> stretchCssValue'
        static member SemiExpanded = Types.Font.SemiExpanded |> stretchCssValue'
        static member Expanded = Types.Font.Expanded |> stretchCssValue'
        static member ExtraExpanded = Types.Font.ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = Types.Font.UltraExpanded |> stretchCssValue'
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
    let private weightCssValue value = Types.propertyHelpers.cssValue Types.Property.FontWeight value
    let private weightCssValue' value = value |> Types.fontHelpers.fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: Types.IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = Types.Font.Bold |> weightCssValue'
        static member Lighter = Types.Font.Lighter |> weightCssValue'
        static member Bolder = Types.Font.Bolder |> weightCssValue'

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
    let private heightCssValue value = Types.propertyHelpers.cssValue Types.Property.LineHeight value
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
    let private breakCssValue value = Types.propertyHelpers.cssValue Types.Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': Types.ILineBreak) = break' |> breakCssValue'
        static member Loose = Types.Font.Loose |> breakCssValue'
        static member Strict = Types.Font.Strict |> breakCssValue'
        static member Anywhere = Types.Font.LineBreak.Anywhere |> breakCssValue'

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
    let private spacingCssValue value = Types.propertyHelpers.cssValue Types.Property.LetterSpacing value
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
    let private displayCssValue value = Types.propertyHelpers.cssValue Types.Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> Types.fontHelpers.fontDisplayToString
        |> Types.propertyHelpers.cssValue Types.Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: Types.IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = Types.Font.Display.Block |> displayCssValue'
        static member Swap = Types.Font.Swap |> displayCssValue'
        static member Fallback = Types.Font.Fallback |> displayCssValue'
        static member Optional = Types.Font.Optional |> displayCssValue'

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
    let private familyCssValue value = Types.propertyHelpers.cssValue Types.Property.FontFamily value
    let private familyCssValue' value = value |> familyToString |> familyCssValue

    type FontFamily =
        static member Value (fontFamily: Types.IFontFamily) = fontFamily |> familyCssValue'
        static member Values (families: Types.IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member Font (font: Types.Font.Family) = font |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = Types.Font.Serif |> familyCssValue'
        static member SansSerif = Types.Font.SansSerif |> familyCssValue'
        static member Monospace = Types.Font.Monospace |> familyCssValue'
        static member Cursive = Types.Font.Cursive |> familyCssValue'

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
    let private featureSettingCssValue value = Types.propertyHelpers.cssValue Types.Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: Types.IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: Types.Font.SettingSwitch) = Types.Font.Liga switch |> featureSettingCssValue'
        static member Dlig (switch: Types.Font.SettingSwitch) = Types.Font.Dlig switch |> featureSettingCssValue'
        static member Onum (switch: Types.Font.SettingSwitch) = Types.Font.Onum switch |> featureSettingCssValue'
        static member Lnum (switch: Types.Font.SettingSwitch) = Types.Font.Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: Types.Font.SettingSwitch) = Types.Font.Tnum switch |> featureSettingCssValue'
        static member Zero (switch: Types.Font.SettingSwitch) = Types.Font.Zero switch |> featureSettingCssValue'
        static member Frac (switch: Types.Font.SettingSwitch) = Types.Font.Frac switch |> featureSettingCssValue'
        static member Sups (switch: Types.Font.SettingSwitch) = Types.Font.Sups switch |> featureSettingCssValue'
        static member Subs (switch: Types.Font.SettingSwitch) = Types.Font.Subs switch |> featureSettingCssValue'
        static member Smcp (switch: Types.Font.SettingSwitch) = Types.Font.Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: Types.Font.SettingSwitch) = Types.Font.C2sc switch |> featureSettingCssValue'
        static member Case (switch: Types.Font.SettingSwitch) = Types.Font.Case switch |> featureSettingCssValue'
        static member Hlig (switch: Types.Font.SettingSwitch) = Types.Font.Hlig switch |> featureSettingCssValue'
        static member Calt (switch: Types.Font.SettingSwitch) = Types.Font.Calt switch |> featureSettingCssValue'
        static member Swsh (switch: Types.Font.SettingSwitch) = Types.Font.Swsh switch |> featureSettingCssValue'
        static member Hist (switch: Types.Font.SettingSwitch) = Types.Font.Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: Types.Font.SettingSwitch) = Types.Font.Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: Types.Font.SettingSwitch) = Types.Font.Kern switch |> featureSettingCssValue'
        static member Locl (switch: Types.Font.SettingSwitch) = Types.Font.Locl switch |> featureSettingCssValue'
        static member Rlig (switch: Types.Font.SettingSwitch) = Types.Font.Rlig switch |> featureSettingCssValue'
        static member Medi (switch: Types.Font.SettingSwitch) = Types.Font.Medi switch |> featureSettingCssValue'
        static member Init (switch: Types.Font.SettingSwitch) = Types.Font.Init switch |> featureSettingCssValue'
        static member Isol (switch: Types.Font.SettingSwitch) = Types.Font.Isol switch |> featureSettingCssValue'
        static member Fina (switch: Types.Font.SettingSwitch) = Types.Font.Fina switch |> featureSettingCssValue'
        static member Mark (switch: Types.Font.SettingSwitch) = Types.Font.Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: Types.Font.SettingSwitch) = Types.Font.Mkmk switch |> featureSettingCssValue'

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
    let private variantNumericCssValue value = Types.propertyHelpers.cssValue Types.Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: Types.IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = Types.Font.Ordinal |> variantNumericCssValue'
        static member SlashedZero = Types.Font.SlashedZero |> variantNumericCssValue'
        static member LiningNums = Types.Font.LiningNums |> variantNumericCssValue'
        static member OldstyleNums = Types.Font.OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = Types.Font.ProportionalNums |> variantNumericCssValue'
        static member TabularNums = Types.Font.TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = Types.Font.DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = Types.Font.StackedFractions |> variantNumericCssValue'

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
    let private variantCapsCssValue value = Types.propertyHelpers.cssValue Types.Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: Types.IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = Types.Font.SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = Types.Font.AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = Types.Font.PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = Types.Font.AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = Types.Font.Unicase |> variantCapsCssValue'
        static member TitlingCaps = Types.Font.TitlingCaps |> variantCapsCssValue'

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
    let private variantEastAsianCssValue value = Types.propertyHelpers.cssValue Types.Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: Types.IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = Types.Font.Ruby |> variantEastAsianCssValue'
        static member Jis78 = Types.Font.Jis78 |> variantEastAsianCssValue'
        static member Jis83 = Types.Font.Jis83 |> variantEastAsianCssValue'
        static member Jis90 = Types.Font.Jis90 |> variantEastAsianCssValue'
        static member Jis04 = Types.Font.Jis04 |> variantEastAsianCssValue'
        static member Simplified = Types.Font.Simplified |> variantEastAsianCssValue'
        static member Traditional = Types.Font.Traditional |> variantEastAsianCssValue'
        static member FullWidth = Types.Font.VariantEastAsian.FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = Types.Font.ProportionalWidth |> variantEastAsianCssValue'

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
    let private variantLigatureCssValue value = Types.propertyHelpers.cssValue Types.Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: Types.IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = Types.Font.CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = Types.Font.NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = Types.Font.DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = Types.Font.NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = Types.Font.HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = Types.Font.NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = Types.Font.Contextual |> variantLigatureCssValue'
        static member NoContextual = Types.Font.NoContextual |> variantLigatureCssValue'

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
    let private kerningValue value = Types.propertyHelpers.cssValue Types.Property.FontKerning value
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
    let private fontLanguageOverrideValue value = Types.propertyHelpers.cssValue Types.Property.FontLanguageOverride value
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
    let private fontSynthesisValue value = Types.propertyHelpers.cssValue Types.Property.FontSynthesis value
    let private fontSynthesisValue' value = value |> fontSynthesisToString |> fontSynthesisValue

    type FontSynthesis =
        static member Value (synthesis: Types.IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member Weight = Types.Font.Weight |> fontSynthesisValue'
        static member Style = Types.Font.Style |> fontSynthesisValue'
        static member WeightStyle = Types.Font.WeightStyle |> fontSynthesisValue'
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
    let private fontVariantPositionValue value = Types.propertyHelpers.cssValue Types.Property.FontVariantPosition value
    let private fontVariantPositionValue' value = value |> fontVariantPositionToString |> fontVariantPositionValue

    type FontVariantPosition =
        static member Value (variantPosition: Types.IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member Sub = Types.Font.VariantPosition.Sub |> fontVariantPositionValue'
        static member Super = Types.Font.VariantPosition.Super |> fontVariantPositionValue'
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












