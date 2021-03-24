namespace Fss

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: FssTypes.IFontSize) =
        match fontSize with
        | :? FssTypes.Font.Size as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown font size"

    let private familyToString (fontFamily: FssTypes.IFontFamily) =
        let stringifyFontName (FssTypes.Font.Name n) = n
        let stringifyFamily fontFamily =
            match fontFamily with
                | FssTypes.Font.Custom c -> sprintf "'%s'" c
                | FssTypes.Font.Family.Name n -> stringifyFontName n
                | _ -> Utilities.Helpers.duToKebab fontFamily

        match fontFamily with
            | :? FssTypes.Font.Family as f -> stringifyFamily f
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "Unknown font family"

    let private featureSettingToString (featureSetting: FssTypes.IFontFeatureSetting) =
        let stringifyFeature =
            function
                | FssTypes.Font.Liga switch    -> sprintf "\"liga\" %A" switch
                | FssTypes.Font.Dlig switch    -> sprintf "\"dlig\" %A" switch
                | FssTypes.Font.Onum switch    -> sprintf "\"onum\" %A" switch
                | FssTypes.Font.Lnum switch    -> sprintf "\"lnum\" %A" switch
                | FssTypes.Font.Tnum switch    -> sprintf "\"tnum\" %A" switch
                | FssTypes.Font.Zero switch    -> sprintf "\"zero\" %A" switch
                | FssTypes.Font.Frac switch    -> sprintf "\"frac\" %A" switch
                | FssTypes.Font.Sups switch    -> sprintf "\"sups\" %A" switch
                | FssTypes.Font.Subs switch    -> sprintf "\"subs\" %A" switch
                | FssTypes.Font.Smcp switch    -> sprintf "\"smcp\" %A" switch
                | FssTypes.Font.C2sc switch    -> sprintf "\"c2sc\" %A" switch
                | FssTypes.Font.Case switch    -> sprintf "\"case\" %A" switch
                | FssTypes.Font.Hlig switch    -> sprintf "\"hlig\" %A" switch
                | FssTypes.Font.Calt switch    -> sprintf "\"calt\" %A" switch
                | FssTypes.Font.Swsh switch    -> sprintf "\"swsh\" %A" switch
                | FssTypes.Font.Hist switch    -> sprintf "\"hist\" %A" switch
                | FssTypes.Font.Ss (n, switch) -> sprintf "\"ss%2i\" %A" n switch
                | FssTypes.Font.Kern switch    -> sprintf "\"kern\" %A" switch
                | FssTypes.Font.Locl switch    -> sprintf "\"locl\" %A" switch
                | FssTypes.Font.Rlig switch    -> sprintf "\"rlig\" %A" switch
                | FssTypes.Font.Medi switch    -> sprintf "\"medi\" %A" switch
                | FssTypes.Font.Init switch    -> sprintf "\"init\" %A" switch
                | FssTypes.Font.Isol switch    -> sprintf "\"isol\" %A" switch
                | FssTypes.Font.Fina switch    -> sprintf "\"fina\" %A" switch
                | FssTypes.Font.Mark switch    -> sprintf "\"mark\" %A" switch
                | FssTypes.Font.Mkmk switch    -> sprintf "\"mkmk\" %A" switch

        match featureSetting with
        | :? FssTypes.Font.FeatureSetting as f -> stringifyFeature f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown font feature setting"

    let private variantNumericToString (variant: FssTypes.IFontVariantNumeric) =
        match variant with
        | :? FssTypes.Font.VariantNumeric as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown font variant numeric"

    let private fontVariantCapsToString (variant: FssTypes.IFontVariantCaps) =
        match variant with
        | :? FssTypes.Font.VariantCaps as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown font variant caps"

    let private variantEastAsianToString (variant: FssTypes.IFontVariantEastAsian) =
        match variant with
        | :? FssTypes.Font.VariantEastAsian as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown font variant east asian"

    let private variantLigatureToString (variant: FssTypes.IFontVariantLigature) =
        match variant with
        | :? FssTypes.Font.VariantLigature as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown font variant ligature"

    let private lineHeightToString (lineHeight: FssTypes.ILineHeight) =
        match lineHeight with
        | :? FssTypes.CssFloat as f -> FssTypes.masterTypeHelpers.FloatToString f
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown line height"

    let private lineBreakToString (linebreak: FssTypes.ILineBreak) =
        match linebreak with
        | :? FssTypes.Font.LineBreak as l -> Utilities.Helpers.duToLowercase l
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown line break"

    let private letterSpacingToString (letterSpacing: FssTypes.ILetterSpacing) =
        match letterSpacing with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown letter spacing"

    let private fontKerningTostring (fontKerning: FssTypes.IFontKerning) =
        match fontKerning with
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown font kerning"

    let private fontLanguageOverrideToString (fontLanguageOverride: FssTypes.IFontLanguageOverride) =
        match fontLanguageOverride with
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown font language override"

    let private fontSynthesisToString (synthesis: FssTypes.IFontSynthesis) =
        match synthesis with
        | :? FssTypes.Font.Synthesis as f -> Utilities.Helpers.duToSpaced f
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown font synthesis"

    let private fontVariantPositionToString (variantPosition: FssTypes.IFontVariantPosition) =
        match variantPosition with
        | :? FssTypes.Font.VariantPosition as f -> Utilities.Helpers.duToLowercase f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "Unknown font variant position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
    let private sizeCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontSize value
    let private sizeCssValue' value = value |> fontSizeToString |> sizeCssValue
    type FontSize =
        static member Value (value: FssTypes.IFontSize) = value |> sizeCssValue'
        static member XxSmall = FssTypes.Font.XxSmall |> sizeCssValue'
        static member XSmall = FssTypes.Font.XSmall |> sizeCssValue'
        static member Small = FssTypes.Font.Small |> sizeCssValue'
        static member Medium = FssTypes.Font.Size.Medium |> sizeCssValue'
        static member Large = FssTypes.Font.Large |> sizeCssValue'
        static member XLarge = FssTypes.Font.XLarge |> sizeCssValue'
        static member XxLarge = FssTypes.Font.XxLarge |> sizeCssValue'
        static member XxxLarge = FssTypes.Font.XxxLarge |> sizeCssValue'
        static member Smaller = FssTypes.Font.Smaller |> sizeCssValue'
        static member Larger = FssTypes.Font.Larger |> sizeCssValue'

        static member Inherit = FssTypes.Inherit |> sizeCssValue'
        static member Initial = FssTypes.Initial |> sizeCssValue'
        static member Unset = FssTypes.Unset |> sizeCssValue'

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
    let FontSize' (size: FssTypes.IFontSize) = FontSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStyle value
    let private styleCssValue' value = value |> FssTypes.fontHelpers.fontStyleToString |> styleCssValue
    type FontStyle =
        static member Value (fontStyle: FssTypes.IFontStyle) = fontStyle |> styleCssValue'
        static member Oblique (angle: FssTypes.Angle) = FssTypes.Font.Oblique angle |> styleCssValue'
        static member Italic = FssTypes.Font.Italic |> styleCssValue'

        static member Normal = FssTypes.Normal |> styleCssValue'
        static member Inherit = FssTypes.Inherit |> styleCssValue'
        static member Initial = FssTypes.Initial |> styleCssValue'
        static member Unset = FssTypes.Unset |> styleCssValue'

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
    let FontStyle' (style: FssTypes.IFontStyle) = FontStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStretch value
    let private stretchCssValue' value = value |> FssTypes.fontHelpers.fontStretchToString |> stretchCssValue
    type FontStretch =
        static member Value (fontStretch: FssTypes.IFontStretch) = fontStretch |> stretchCssValue'
        static member Value (percent: FssTypes.Percent) =
            FssTypes.unitHelpers.percentToString percent
            |> stretchCssValue
        static member SemiCondensed = FssTypes.Font.SemiCondensed |> stretchCssValue'
        static member Condensed = FssTypes.Font.Condensed |> stretchCssValue'
        static member ExtraCondensed = FssTypes.Font.ExtraCondensed |> stretchCssValue'
        static member UltraCondensed = FssTypes.Font.UltraCondensed |> stretchCssValue'
        static member SemiExpanded = FssTypes.Font.SemiExpanded |> stretchCssValue'
        static member Expanded = FssTypes.Font.Expanded |> stretchCssValue'
        static member ExtraExpanded = FssTypes.Font.ExtraExpanded |> stretchCssValue'
        static member UltraExpanded = FssTypes.Font.UltraExpanded |> stretchCssValue'
        static member Normal = FssTypes.Normal |> stretchCssValue'
        static member Inherit = FssTypes.Inherit |> stretchCssValue'
        static member Initial = FssTypes.Initial |> stretchCssValue'
        static member Unset = FssTypes.Unset |> stretchCssValue'

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
    let FontStretch' (stretch: FssTypes.IFontStretch) = FontStretch.Value(stretch)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontWeight value
    let private weightCssValue' value = value |> FssTypes.fontHelpers.fontWeightToString |> weightCssValue
    type FontWeight =
        static member Value (fontWeight: FssTypes.IFontWeight) = fontWeight |> weightCssValue'
        static member Bold = FssTypes.Font.Bold |> weightCssValue'
        static member Lighter = FssTypes.Font.Lighter |> weightCssValue'
        static member Bolder = FssTypes.Font.Bolder |> weightCssValue'

        static member Normal = FssTypes.Normal |> weightCssValue'
        static member Inherit = FssTypes.Inherit |> weightCssValue'
        static member Initial = FssTypes.Initial |> weightCssValue'
        static member Unset = FssTypes.Unset |> weightCssValue'

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
    let FontWeight' (weight: FssTypes.IFontWeight) = FontWeight.Value(weight)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    let private heightCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.LineHeight value
    let private heightCssValue' value =
        value
        |> lineHeightToString
        |> heightCssValue
    type LineHeight =
        static member Value (height: FssTypes.ILineHeight) = height |> heightCssValue'

        static member Normal = FssTypes.Normal |> heightCssValue'
        static member Inherit = FssTypes.Inherit |> heightCssValue'
        static member Initial = FssTypes.Initial |>  heightCssValue'
        static member Unset = FssTypes.Unset |>  heightCssValue'

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
    let LineHeight' (height: FssTypes.ILineHeight) = LineHeight.Value(height)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.LineBreak value
    let private breakCssValue' value =
        value
        |> lineBreakToString
        |> breakCssValue
    type LineBreak =
        static member Value (break': FssTypes.ILineBreak) = break' |> breakCssValue'
        static member Loose = FssTypes.Font.Loose |> breakCssValue'
        static member Strict = FssTypes.Font.Strict |> breakCssValue'
        static member Anywhere = FssTypes.Font.LineBreak.Anywhere |> breakCssValue'

        static member Normal = FssTypes.Normal |> breakCssValue'
        static member Auto = FssTypes.Auto |> breakCssValue'
        static member Inherit = FssTypes.Inherit |> breakCssValue'
        static member Initial = FssTypes.Initial |>  breakCssValue'
        static member Unset = FssTypes.Unset |>  breakCssValue'

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
    let LineBreak' (break': FssTypes.ILineBreak) = LineBreak.Value(break')

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    let private spacingCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.LetterSpacing value
    let private spacingCssValue' value =
        value
        |> letterSpacingToString
        |> spacingCssValue
    type LetterSpacing =
        static member Value (spacing: FssTypes.ILetterSpacing) = spacing |> spacingCssValue'

        static member Normal = FssTypes.Normal |> spacingCssValue'
        static member Inherit = FssTypes.Inherit |> spacingCssValue'
        static member Initial = FssTypes.Initial |>  spacingCssValue'
        static member Unset = FssTypes.Unset |>  spacingCssValue'

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
    let LetterSpacing' (spacing: FssTypes.ILetterSpacing) = LetterSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay value
    let private displayCssValue' value =
        value
        |> FssTypes.fontHelpers.fontDisplayToString
        |> FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay
    type FontDisplay =
        static member Value (fontDisplay: FssTypes.IFontDisplay) = fontDisplay |> displayCssValue'
        static member Block = FssTypes.Font.Display.Block |> displayCssValue'
        static member Swap = FssTypes.Font.Swap |> displayCssValue'
        static member Fallback = FssTypes.Font.Fallback |> displayCssValue'
        static member Optional = FssTypes.Font.Optional |> displayCssValue'

        static member Auto = FssTypes.Auto |> displayCssValue'

    /// <summary>Specifies how a font is loaded and displayed.</summary>
    /// <param name="display">
    ///     can be:
    ///     - <c> FontDisplay </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontDisplay' (display: FssTypes.IFontDisplay) = FontDisplay.Value(display)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    let private familyCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontFamily value
    let private familyCssValue' value = value |> familyToString |> familyCssValue

    type FontFamily =
        static member Value (fontFamily: FssTypes.IFontFamily) = fontFamily |> familyCssValue'
        static member Values (families: FssTypes.IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member Font (font: FssTypes.Font.Family) = font |> familyCssValue'
        static member Custom (font: string) = familyCssValue font
        static member Serif = FssTypes.Font.Serif |> familyCssValue'
        static member SansSerif = FssTypes.Font.SansSerif |> familyCssValue'
        static member Monospace = FssTypes.Font.Monospace |> familyCssValue'
        static member Cursive = FssTypes.Font.Cursive |> familyCssValue'

        static member Inherit = FssTypes.Inherit |> familyCssValue'
        static member Initial = FssTypes.Initial |> familyCssValue'
        static member Unset = FssTypes.Unset |> familyCssValue'

    /// <summary>Specify which font to use on the.</summary>
    /// <param name="fontFamily">
    ///     can be:
    ///     - <c> FontFamily </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFamily' (fontFamily: FssTypes.IFontFamily) = FontFamily.Value(fontFamily)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontFeatureSettings value
    let private featureSettingCssValue' value = value |> featureSettingToString |> featureSettingCssValue

    type FontFeatureSetting =
        static member Value (featureSetting: FssTypes.IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member Liga (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Liga switch |> featureSettingCssValue'
        static member Dlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Dlig switch |> featureSettingCssValue'
        static member Onum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Onum switch |> featureSettingCssValue'
        static member Lnum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Lnum switch |> featureSettingCssValue'
        static member Tnum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Tnum switch |> featureSettingCssValue'
        static member Zero (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Zero switch |> featureSettingCssValue'
        static member Frac (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Frac switch |> featureSettingCssValue'
        static member Sups (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Sups switch |> featureSettingCssValue'
        static member Subs (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Subs switch |> featureSettingCssValue'
        static member Smcp (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Smcp switch |> featureSettingCssValue'
        static member C2sc (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.C2sc switch |> featureSettingCssValue'
        static member Case (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Case switch |> featureSettingCssValue'
        static member Hlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Hlig switch |> featureSettingCssValue'
        static member Calt (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Calt switch |> featureSettingCssValue'
        static member Swsh (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Swsh switch |> featureSettingCssValue'
        static member Hist (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Hist switch |> featureSettingCssValue'
        static member Ss  (n:int, switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Ss (n, switch) |> featureSettingCssValue'
        static member Kern (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Kern switch |> featureSettingCssValue'
        static member Locl (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Locl switch |> featureSettingCssValue'
        static member Rlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Rlig switch |> featureSettingCssValue'
        static member Medi (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Medi switch |> featureSettingCssValue'
        static member Init (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Init switch |> featureSettingCssValue'
        static member Isol (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Isol switch |> featureSettingCssValue'
        static member Fina (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Fina switch |> featureSettingCssValue'
        static member Mark (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Mark switch |> featureSettingCssValue'
        static member Mkmk (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Mkmk switch |> featureSettingCssValue'

        static member Inherit = FssTypes.Inherit |> featureSettingCssValue'
        static member Initial = FssTypes.Initial |> featureSettingCssValue'
        static member Unset = FssTypes.Unset |> featureSettingCssValue'

    /// <summary>Specify more advanced typographic settings.</summary>
    /// <param name="featureSetting">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontFeatureSetting' (featureSetting: FssTypes.IFontFeatureSetting) = FontFeatureSetting.Value(featureSetting)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantNumeric value
    let private variantNumericCssValue' value = value |> variantNumericToString |> variantNumericCssValue

    type FontVariantNumeric =
        static member Value (variantNumeric: FssTypes.IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member Ordinal = FssTypes.Font.Ordinal |> variantNumericCssValue'
        static member SlashedZero = FssTypes.Font.SlashedZero |> variantNumericCssValue'
        static member LiningNums = FssTypes.Font.LiningNums |> variantNumericCssValue'
        static member OldstyleNums = FssTypes.Font.OldstyleNums |> variantNumericCssValue'
        static member ProportionalNums = FssTypes.Font.ProportionalNums |> variantNumericCssValue'
        static member TabularNums = FssTypes.Font.TabularNums |> variantNumericCssValue'
        static member DiagonalFractions = FssTypes.Font.DiagonalFractions |> variantNumericCssValue'
        static member StackedFractions = FssTypes.Font.StackedFractions |> variantNumericCssValue'

        static member Normal = FssTypes.Normal |> variantNumericCssValue'
        static member Inherit = FssTypes.Inherit |> variantNumericCssValue'
        static member Initial = FssTypes.Initial |> variantNumericCssValue'
        static member Unset = FssTypes.Unset |> variantNumericCssValue'

    /// <summary>Specifies numeric glyphs.</summary>
    /// <param name="variant">
    ///     can be:
    ///     - <c> FontFeatureSetting </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontVariantNumeric' (variant: FssTypes.IFontVariantNumeric) = FontVariantNumeric.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantCaps value
    let private variantCapsCssValue' value = value |> fontVariantCapsToString |> variantCapsCssValue
    type FontVariantCaps =
        static member Value (variantCaps: FssTypes.IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member SmallCaps = FssTypes.Font.SmallCaps |> variantCapsCssValue'
        static member AllSmallCaps = FssTypes.Font.AllSmallCaps |> variantCapsCssValue'
        static member PetiteCaps = FssTypes.Font.PetiteCaps |> variantCapsCssValue'
        static member AllPetiteCaps = FssTypes.Font.AllPetiteCaps |> variantCapsCssValue'
        static member Unicase = FssTypes.Font.Unicase |> variantCapsCssValue'
        static member TitlingCaps = FssTypes.Font.TitlingCaps |> variantCapsCssValue'

        static member Normal = FssTypes.Normal |> variantCapsCssValue'
        static member Inherit = FssTypes.Inherit |> variantCapsCssValue'
        static member Initial = FssTypes.Initial |> variantCapsCssValue'
        static member Unset = FssTypes.Unset |> variantCapsCssValue'

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
    let FontVariantCaps' (variant: FssTypes.IFontVariantCaps) = FontVariantCaps.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantEastAsian value
    let private variantEastAsianCssValue' value = value |> variantEastAsianToString |> variantEastAsianCssValue
    type FontVariantEastAsian =
        static member Value (variant: FssTypes.IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member Ruby = FssTypes.Font.Ruby |> variantEastAsianCssValue'
        static member Jis78 = FssTypes.Font.Jis78 |> variantEastAsianCssValue'
        static member Jis83 = FssTypes.Font.Jis83 |> variantEastAsianCssValue'
        static member Jis90 = FssTypes.Font.Jis90 |> variantEastAsianCssValue'
        static member Jis04 = FssTypes.Font.Jis04 |> variantEastAsianCssValue'
        static member Simplified = FssTypes.Font.Simplified |> variantEastAsianCssValue'
        static member Traditional = FssTypes.Font.Traditional |> variantEastAsianCssValue'
        static member FullWidth = FssTypes.Font.VariantEastAsian.FullWidth |> variantEastAsianCssValue'
        static member ProportionalWidth = FssTypes.Font.ProportionalWidth |> variantEastAsianCssValue'

        static member Normal = FssTypes.Normal |> variantEastAsianCssValue'
        static member Inherit = FssTypes.Inherit |> variantEastAsianCssValue'
        static member Initial = FssTypes.Initial |> variantEastAsianCssValue'
        static member Unset = FssTypes.Unset |> variantEastAsianCssValue'

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
    let FontVariantEastAsian' (variant: FssTypes.IFontVariantEastAsian) = FontVariantEastAsian.Value(variant)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantLigatures value
    let private variantLigatureCssValue' value = value |> variantLigatureToString |> variantLigatureCssValue
    type FontVariantLigatures =
        static member Value (variant: FssTypes.IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member CommonLigatures = FssTypes.Font.CommonLigatures |> variantLigatureCssValue'
        static member NoCommonLigatures = FssTypes.Font.NoCommonLigatures |> variantLigatureCssValue'
        static member DiscretionaryLigatures = FssTypes.Font.DiscretionaryLigatures |> variantLigatureCssValue'
        static member NoDiscretionaryLigatures = FssTypes.Font.NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member HistoricalLigatures = FssTypes.Font.HistoricalLigatures |> variantLigatureCssValue'
        static member NoHistoricalLigatures = FssTypes.Font.NoHistoricalLigatures |> variantLigatureCssValue'
        static member Contextual = FssTypes.Font.Contextual |> variantLigatureCssValue'
        static member NoContextual = FssTypes.Font.NoContextual |> variantLigatureCssValue'

        static member Normal = FssTypes.Normal |> variantLigatureCssValue'
        static member None = FssTypes.None' |> variantLigatureCssValue'
        static member Inherit = FssTypes.Inherit |> variantLigatureCssValue'
        static member Initial = FssTypes.Initial |> variantLigatureCssValue'
        static member Unset = FssTypes.Unset |> variantLigatureCssValue'

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
    let FontVariantLigatures' (ligature: FssTypes.IFontVariantLigature) = FontVariantLigatures.Value(ligature)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
    let private kerningValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontKerning value
    let private kerningValue' value = value |> fontKerningTostring |> kerningValue

    type FontKerning =
        static member Value (fontKerning: FssTypes.IFontKerning) = fontKerning |> kerningValue'
        static member Auto = FssTypes.Auto |> kerningValue'
        static member Normal = FssTypes.Normal |> kerningValue'
        static member None = FssTypes.None' |> kerningValue'

    /// <summary>Specifies use of font-kerning.</summary>
    /// <param name="fontKerning">
    ///     can be:
    ///     - <c> Auto </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontKerning' (fontKerning: FssTypes.IFontKerning) = FontKerning.Value(fontKerning)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
    let private fontLanguageOverrideValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontLanguageOverride value
    let private fontLanguageOverrideValue' value = value |> fontLanguageOverrideToString |> fontLanguageOverrideValue

    type FontLanguageOverride =
        static member Value (languageOverride: FssTypes.IFontLanguageOverride) = languageOverride |> fontLanguageOverrideValue'
        static member Value (languageOverride: string) = $"\"{languageOverride}\"" |> fontLanguageOverrideValue
        static member Normal = FssTypes.Normal |> fontLanguageOverrideValue'
        static member Inherit = FssTypes.Inherit |> fontLanguageOverrideValue'
        static member Initial = FssTypes.Initial |> fontLanguageOverrideValue'
        static member Unset = FssTypes.Unset |> fontLanguageOverrideValue'

    /// <summary>Specifies language specific glyphs.</summary>
    /// <param name="languageOverride">
    ///     can be:
    ///     - <c> Normal </c>
    ///     - <c> Initial </c>
    ///     - <c> Inherit </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontLanguageOverride' (languageOverride: FssTypes.IFontLanguageOverride) = FontLanguageOverride.Value(languageOverride)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    let private fontSynthesisValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontSynthesis value
    let private fontSynthesisValue' value = value |> fontSynthesisToString |> fontSynthesisValue

    type FontSynthesis =
        static member Value (synthesis: FssTypes.IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member Weight = FssTypes.Font.Weight |> fontSynthesisValue'
        static member Style = FssTypes.Font.Style |> fontSynthesisValue'
        static member WeightStyle = FssTypes.Font.WeightStyle |> fontSynthesisValue'
        static member None = FssTypes.None' |> fontSynthesisValue'

    /// <summary>Specifies which missing typefaces can be synthesized by the browser.</summary>
    /// <param name="synthesis">
    ///     can be:
    ///     - <c> FontSynthesis </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FontSynthesis' (synthesis: FssTypes.IFontSynthesis) = FontSynthesis.Value(synthesis)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    let private fontVariantPositionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantPosition value
    let private fontVariantPositionValue' value = value |> fontVariantPositionToString |> fontVariantPositionValue

    type FontVariantPosition =
        static member Value (variantPosition: FssTypes.IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member Sub = FssTypes.Font.VariantPosition.Sub |> fontVariantPositionValue'
        static member Super = FssTypes.Font.VariantPosition.Super |> fontVariantPositionValue'
        static member Normal = FssTypes.Normal |> fontVariantPositionValue'
        static member Inherit = FssTypes.Inherit |> fontVariantPositionValue'
        static member Initial = FssTypes.Initial |> fontVariantPositionValue'
        static member Unset = FssTypes.Unset |> fontVariantPositionValue'

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
    let FontVariantPosition' (variantPosition: FssTypes.IFontVariantPosition) = FontVariantPosition.Value(variantPosition)












