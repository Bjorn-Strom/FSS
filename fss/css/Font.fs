namespace Fss

open Fable.Core

[<AutoOpen>]
module Font =
    let private fontSizeToString (fontSize: FssTypes.IFontSize) =
        match fontSize with
        | :? FssTypes.Font.Size as f -> Utilities.Helpers.duToKebab f
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
    let private sizeCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontSize
    let private sizeCssValue' = fontSizeToString >> sizeCssValue
    [<Erase>]
    /// Sets size of font.
    type FontSize =
        static member value (value: FssTypes.IFontSize) = value |> sizeCssValue'
        static member xxSmall = FssTypes.Font.XxSmall |> sizeCssValue'
        static member xSmall = FssTypes.Font.XSmall |> sizeCssValue'
        static member small = FssTypes.Font.Small |> sizeCssValue'
        static member medium = FssTypes.Font.Size.Medium |> sizeCssValue'
        static member large = FssTypes.Font.Large |> sizeCssValue'
        static member xLarge = FssTypes.Font.XLarge |> sizeCssValue'
        static member xxLarge = FssTypes.Font.XxLarge |> sizeCssValue'
        static member xxxLarge = FssTypes.Font.XxxLarge |> sizeCssValue'
        static member smaller = FssTypes.Font.Smaller |> sizeCssValue'
        static member larger = FssTypes.Font.Larger |> sizeCssValue'

        static member inherit' = FssTypes.Inherit |> sizeCssValue'
        static member initial = FssTypes.Initial |> sizeCssValue'
        static member unset = FssTypes.Unset |> sizeCssValue'

    /// Sets size of font.
    /// Valid parameters:
    /// - FontSize
    /// - Length
    /// - Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let FontSize' = FontSize.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-style
    let private styleCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStyle
    let private styleCssValue' = FssTypes.fontHelpers.fontStyleToString >> styleCssValue

    [<Erase>]
    /// Specifies which style to use on a font.
    type FontStyle =
        static member value (fontStyle: FssTypes.IFontStyle) = fontStyle |> styleCssValue'
        static member oblique (angle: FssTypes.Angle) = FssTypes.Font.Oblique angle |> styleCssValue'
        static member italic = FssTypes.Font.Italic |> styleCssValue'

        static member normal = FssTypes.Normal |> styleCssValue'
        static member inherit' = FssTypes.Inherit |> styleCssValue'
        static member initial = FssTypes.Initial |> styleCssValue'
        static member unset = FssTypes.Unset |> styleCssValue'

    /// Specifies which style to use on a font.
    /// Valid parameters:
    /// - FontStyle
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal

    /// <returns>Css property for fss.</returns>
    let FontStyle' = FontStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-stretch
    let private stretchCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStretch
    let private stretchCssValue' = FssTypes.fontHelpers.fontStretchToString >> stretchCssValue

    [<Erase>]
    /// Specifies width of text characters to be wider or narrower default width.
    type FontStretch =
        static member value (fontStretch: FssTypes.IFontStretch) = fontStretch |> stretchCssValue'
        static member value (percent: FssTypes.Percent) =
            FssTypes.unitHelpers.percentToString percent
            |> stretchCssValue
        static member semiCondensed = FssTypes.Font.SemiCondensed |> stretchCssValue'
        static member condensed = FssTypes.Font.Condensed |> stretchCssValue'
        static member extraCondensed = FssTypes.Font.ExtraCondensed |> stretchCssValue'
        static member ultraCondensed = FssTypes.Font.UltraCondensed |> stretchCssValue'
        static member semiExpanded = FssTypes.Font.SemiExpanded |> stretchCssValue'
        static member expanded = FssTypes.Font.Expanded |> stretchCssValue'
        static member extraExpanded = FssTypes.Font.ExtraExpanded |> stretchCssValue'
        static member ultraExpanded = FssTypes.Font.UltraExpanded |> stretchCssValue'
        static member normal = FssTypes.Normal |> stretchCssValue'
        static member inherit' = FssTypes.Inherit |> stretchCssValue'
        static member initial = FssTypes.Initial |> stretchCssValue'
        static member unset = FssTypes.Unset |> stretchCssValue'

    /// Specifies width of text characters to be wider or narrower than default width.
    /// Valid parameters:
    /// - FontStretch
    /// - Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let FontStretch' = FontStretch.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    let private weightCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontWeight
    let private weightCssValue' = FssTypes.fontHelpers.fontWeightToString >> weightCssValue

    [<Erase>]
    /// Specifies weight(boldness) of font.
    type FontWeight =
        static member value (fontWeight: FssTypes.IFontWeight) = fontWeight |> weightCssValue'
        static member bold = FssTypes.Font.Bold |> weightCssValue'
        static member lighter = FssTypes.Font.Lighter |> weightCssValue'
        static member bolder = FssTypes.Font.Bolder |> weightCssValue'

        static member normal = FssTypes.Normal |> weightCssValue'
        static member inherit' = FssTypes.Inherit |> weightCssValue'
        static member initial = FssTypes.Initial |> weightCssValue'
        static member unset = FssTypes.Unset |> weightCssValue'

    /// Specifies weight(boldness) of font.
    /// Valid parameters:
    /// - FontWeight
    /// - CssInt
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let FontWeight' = FontWeight.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    let private heightCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.LineHeight
    let private heightCssValue' = lineHeightToString >> heightCssValue

    [<Erase>]
    /// Specifies the amount of space above and below inline elements.
    type LineHeight =
        static member value (height: FssTypes.ILineHeight) = height |> heightCssValue'

        static member normal = FssTypes.Normal |> heightCssValue'
        static member inherit' = FssTypes.Inherit |> heightCssValue'
        static member initial = FssTypes.Initial |>  heightCssValue'
        static member unset = FssTypes.Unset |>  heightCssValue'

    /// Specifies the amount of space above and below inline elements.
    /// Valid parameters
    /// - CssFloat
    /// - Length
    /// - Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let LineHeight' = LineHeight.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/line-break
    let private breakCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.LineBreak
    let private breakCssValue' = lineBreakToString >> breakCssValue

    [<Erase>]
    /// Specifies how some asian languages wrap text on newlines.
    type LineBreak =
        static member value (break': FssTypes.ILineBreak) = break' |> breakCssValue'
        static member loose = FssTypes.Font.Loose |> breakCssValue'
        static member strict = FssTypes.Font.Strict |> breakCssValue'
        static member anywhere = FssTypes.Font.LineBreak.Anywhere |> breakCssValue'

        static member normal = FssTypes.Normal |> breakCssValue'
        static member auto = FssTypes.Auto |> breakCssValue'
        static member inherit' = FssTypes.Inherit |> breakCssValue'
        static member initial = FssTypes.Initial |>  breakCssValue'
        static member unset = FssTypes.Unset |>  breakCssValue'

    /// Specifies how some asian languages wrap text on newlines.
    /// Valid parameters:
    /// - LineBreak
    /// - Auto
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let LineBreak' = LineBreak.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/letter-spacing
    let private spacingCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.LetterSpacing
    let private spacingCssValue' = letterSpacingToString >> spacingCssValue

    [<Erase>]
    /// Sets horizontal spacing between text characters.
    type LetterSpacing =
        static member value (spacing: FssTypes.ILetterSpacing) = spacing |> spacingCssValue'

        static member normal = FssTypes.Normal |> spacingCssValue'
        static member inherit' = FssTypes.Inherit |> spacingCssValue'
        static member initial = FssTypes.Initial |>  spacingCssValue'
        static member unset = FssTypes.Unset |>  spacingCssValue'

    /// Sets horizontal spacing between text characters.
    /// Valid parameters:
    /// - Length
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let LetterSpacing' = LetterSpacing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    let private displayCssValue: (string -> FssTypes.CssProperty) = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay
    let private displayCssValue' = FssTypes.fontHelpers.fontDisplayToString >> FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay

    [<Erase>]
    /// Specifies how a font is loaded and displayed.
    type FontDisplay =
        static member value (fontDisplay: FssTypes.IFontDisplay) = fontDisplay |> displayCssValue'
        static member block = FssTypes.Font.Display.Block |> displayCssValue'
        static member swap = FssTypes.Font.Swap |> displayCssValue'
        static member fallback = FssTypes.Font.Fallback |> displayCssValue'
        static member optional = FssTypes.Font.Optional |> displayCssValue'

        static member auto = FssTypes.Auto |> displayCssValue'

    /// Specifies how a font is loaded and displayed.
    /// Valid parameters:
    /// - FontDisplay
    /// - Auto
    let FontDisplay' = FontDisplay.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-family
    let private familyCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontFamily
    let private familyCssValue' = familyToString >> familyCssValue

    [<Erase>]
    /// Specify which font to use on the.
    type FontFamily =
        static member value (fontFamily: FssTypes.IFontFamily) = fontFamily |> familyCssValue'
        static member values (families: FssTypes.IFontFamily list) =
            families
            |> Utilities.Helpers.combineComma familyToString
            |> familyCssValue
        static member font (font: FssTypes.Font.Family) = font |> familyCssValue'
        static member custom (font: string) = familyCssValue font
        static member serif = FssTypes.Font.Serif |> familyCssValue'
        static member sansSerif = FssTypes.Font.SansSerif |> familyCssValue'
        static member monospace = FssTypes.Font.Monospace |> familyCssValue'
        static member cursive = FssTypes.Font.Cursive |> familyCssValue'

        static member inherit' = FssTypes.Inherit |> familyCssValue'
        static member initial = FssTypes.Initial |> familyCssValue'
        static member unset = FssTypes.Unset |> familyCssValue'

    /// Specify which font to use on the.
    /// Valid parameters:
    /// - FontFamily
    /// - Inherit
    /// - Initial
    /// - Unset
    let FontFamily'  = FontFamily.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-feature-settings
    let private featureSettingCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontFeatureSettings
    let private featureSettingCssValue' = featureSettingToString >> featureSettingCssValue

    [<Erase>]
    /// Specify more advanced typographic settings.
    type FontFeatureSetting =
        static member value (featureSetting: FssTypes.IFontFeatureSetting) = featureSetting |> featureSettingCssValue'
        static member liga (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Liga switch |> featureSettingCssValue'
        static member dlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Dlig switch |> featureSettingCssValue'
        static member onum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Onum switch |> featureSettingCssValue'
        static member lnum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Lnum switch |> featureSettingCssValue'
        static member tnum (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Tnum switch |> featureSettingCssValue'
        static member zero (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Zero switch |> featureSettingCssValue'
        static member frac (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Frac switch |> featureSettingCssValue'
        static member sups (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Sups switch |> featureSettingCssValue'
        static member subs (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Subs switch |> featureSettingCssValue'
        static member smcp (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Smcp switch |> featureSettingCssValue'
        static member c2sc (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.C2sc switch |> featureSettingCssValue'
        static member case (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Case switch |> featureSettingCssValue'
        static member hlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Hlig switch |> featureSettingCssValue'
        static member calt (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Calt switch |> featureSettingCssValue'
        static member swsh (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Swsh switch |> featureSettingCssValue'
        static member hist (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Hist switch |> featureSettingCssValue'
        static member ss  (n:int, switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Ss (n, switch) |> featureSettingCssValue'
        static member kern (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Kern switch |> featureSettingCssValue'
        static member locl (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Locl switch |> featureSettingCssValue'
        static member rlig (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Rlig switch |> featureSettingCssValue'
        static member medi (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Medi switch |> featureSettingCssValue'
        static member init (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Init switch |> featureSettingCssValue'
        static member isol (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Isol switch |> featureSettingCssValue'
        static member fina (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Fina switch |> featureSettingCssValue'
        static member mark (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Mark switch |> featureSettingCssValue'
        static member mkmk (switch: FssTypes.Font.SettingSwitch) = FssTypes.Font.Mkmk switch |> featureSettingCssValue'

        static member inherit' = FssTypes.Inherit |> featureSettingCssValue'
        static member initial = FssTypes.Initial |> featureSettingCssValue'
        static member unset = FssTypes.Unset |> featureSettingCssValue'

    /// Specify more advanced typographic settings.
    /// Valid parameters:
    /// - FontFeatureSetting
    /// - Inherit
    /// - Initial
    /// - Unset
    let FontFeatureSetting' = FontFeatureSetting.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-numeric
    let private variantNumericCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantNumeric
    let private variantNumericCssValue' = variantNumericToString >> variantNumericCssValue

    [<Erase>]
    /// Specifies numeric glyphs.
    type FontVariantNumeric =
        static member value (variantNumeric: FssTypes.IFontVariantNumeric) = variantNumeric |>  variantNumericCssValue'
        static member ordinal = FssTypes.Font.Ordinal |> variantNumericCssValue'
        static member slashedZero = FssTypes.Font.SlashedZero |> variantNumericCssValue'
        static member liningNums = FssTypes.Font.LiningNums |> variantNumericCssValue'
        static member oldstyleNums = FssTypes.Font.OldstyleNums |> variantNumericCssValue'
        static member proportionalNums = FssTypes.Font.ProportionalNums |> variantNumericCssValue'
        static member tabularNums = FssTypes.Font.TabularNums |> variantNumericCssValue'
        static member diagonalFractions = FssTypes.Font.DiagonalFractions |> variantNumericCssValue'
        static member stackedFractions = FssTypes.Font.StackedFractions |> variantNumericCssValue'

        static member normal = FssTypes.Normal |> variantNumericCssValue'
        static member inherit' = FssTypes.Inherit |> variantNumericCssValue'
        static member initial = FssTypes.Initial |> variantNumericCssValue'
        static member unset = FssTypes.Unset |> variantNumericCssValue'

    /// Specifies numeric glyphs.
    /// Valid parameters:
    /// - FontFeatureSetting
    /// - Inherit
    /// - Initial
    /// - Unset
    let FontVariantNumeric' = FontVariantNumeric.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-caps
    let private variantCapsCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantCaps
    let private variantCapsCssValue' = fontVariantCapsToString >> variantCapsCssValue

    [<Erase>]
    /// Specify alternate glyphs for capital letters.
    type FontVariantCaps =
        static member value (variantCaps: FssTypes.IFontVariantCaps) = variantCaps |> variantCapsCssValue'
        static member smallCaps = FssTypes.Font.SmallCaps |> variantCapsCssValue'
        static member allSmallCaps = FssTypes.Font.AllSmallCaps |> variantCapsCssValue'
        static member petiteCaps = FssTypes.Font.PetiteCaps |> variantCapsCssValue'
        static member allPetiteCaps = FssTypes.Font.AllPetiteCaps |> variantCapsCssValue'
        static member unicase = FssTypes.Font.Unicase |> variantCapsCssValue'
        static member titlingCaps = FssTypes.Font.TitlingCaps |> variantCapsCssValue'

        static member normal = FssTypes.Normal |> variantCapsCssValue'
        static member inherit' = FssTypes.Inherit |> variantCapsCssValue'
        static member initial = FssTypes.Initial |> variantCapsCssValue'
        static member unset = FssTypes.Unset |> variantCapsCssValue'

    /// Specify alternate glyphs for capital letters.
    /// Valid parameters:
    /// - FontVariantCaps
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let FontVariantCaps' = FontVariantCaps.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantEastAsianCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantEastAsian
    let private variantEastAsianCssValue' = variantEastAsianToString >> variantEastAsianCssValue

    [<Erase>]
    /// Specifies alternate glyphs for East Asian languages.
    type FontVariantEastAsian =
        static member value (variant: FssTypes.IFontVariantEastAsian) = variant |> variantEastAsianCssValue'
        static member ruby = FssTypes.Font.Ruby |> variantEastAsianCssValue'
        static member jis78 = FssTypes.Font.Jis78 |> variantEastAsianCssValue'
        static member jis83 = FssTypes.Font.Jis83 |> variantEastAsianCssValue'
        static member jis90 = FssTypes.Font.Jis90 |> variantEastAsianCssValue'
        static member jis04 = FssTypes.Font.Jis04 |> variantEastAsianCssValue'
        static member simplified = FssTypes.Font.Simplified |> variantEastAsianCssValue'
        static member traditional = FssTypes.Font.Traditional |> variantEastAsianCssValue'
        static member fullWidth = FssTypes.Font.VariantEastAsian.FullWidth |> variantEastAsianCssValue'
        static member proportionalWidth = FssTypes.Font.ProportionalWidth |> variantEastAsianCssValue'

        static member normal = FssTypes.Normal |> variantEastAsianCssValue'
        static member inherit' = FssTypes.Inherit |> variantEastAsianCssValue'
        static member initial = FssTypes.Initial |> variantEastAsianCssValue'
        static member unset = FssTypes.Unset |> variantEastAsianCssValue'

    /// Specifies alternate glyphs for East Asian languages.
    /// Valid parameters:
    /// - FontVariantEastAsian
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let FontVariantEastAsian' = FontVariantEastAsian.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-east-asian
    let private variantLigatureCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantLigatures
    let private variantLigatureCssValue' = variantLigatureToString >> variantLigatureCssValue

    [<Erase>]
    /// Specifies which ligatures are used.
    type FontVariantLigatures =
        static member value (variant: FssTypes.IFontVariantLigature) = variant |> variantLigatureCssValue'
        static member commonLigatures = FssTypes.Font.CommonLigatures |> variantLigatureCssValue'
        static member noCommonLigatures = FssTypes.Font.NoCommonLigatures |> variantLigatureCssValue'
        static member discretionaryLigatures = FssTypes.Font.DiscretionaryLigatures |> variantLigatureCssValue'
        static member noDiscretionaryLigatures = FssTypes.Font.NoDiscretionaryLigatures |> variantLigatureCssValue'
        static member historicalLigatures = FssTypes.Font.HistoricalLigatures |> variantLigatureCssValue'
        static member noHistoricalLigatures = FssTypes.Font.NoHistoricalLigatures |> variantLigatureCssValue'
        static member contextual = FssTypes.Font.Contextual |> variantLigatureCssValue'
        static member noContextual = FssTypes.Font.NoContextual |> variantLigatureCssValue'

        static member normal = FssTypes.Normal |> variantLigatureCssValue'
        static member none = FssTypes.None' |> variantLigatureCssValue'
        static member inherit' = FssTypes.Inherit |> variantLigatureCssValue'
        static member initial = FssTypes.Initial |> variantLigatureCssValue'
        static member unset = FssTypes.Unset |> variantLigatureCssValue'

    /// Specifies which ligatures are used.
    /// Valid parameters:
    /// - FontVariantLigature
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    /// - None
    let FontVariantLigatures' = FontVariantLigatures.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-kerning
    let private kerningValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontKerning
    let private kerningValue' = fontKerningTostring >> kerningValue

    [<Erase>]
    /// Specifies use of font-kerning.
    type FontKerning =
        static member value (fontKerning: FssTypes.IFontKerning) = fontKerning |> kerningValue'
        static member auto = FssTypes.Auto |> kerningValue'
        static member normal = FssTypes.Normal |> kerningValue'
        static member none = FssTypes.None' |> kerningValue'

    /// Specifies use of font-kerning.
    /// Valid parameters:
    /// - Auto
    /// - Normal
    /// - None
    let FontKerning' (fontKerning: FssTypes.IFontKerning) = FontKerning.value(fontKerning)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-language-override
    let private fontLanguageOverrideValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontLanguageOverride
    let private fontLanguageOverrideValue' =  fontLanguageOverrideToString >> fontLanguageOverrideValue

    [<Erase>]
    /// Specifies language specific glyphs.
    type FontLanguageOverride =
        static member value (languageOverride: FssTypes.IFontLanguageOverride) = languageOverride |> fontLanguageOverrideValue'
        static member value (languageOverride: string) = $"\"{languageOverride}\"" |> fontLanguageOverrideValue
        static member normal = FssTypes.Normal |> fontLanguageOverrideValue'
        static member inherit' = FssTypes.Inherit |> fontLanguageOverrideValue'
        static member initial = FssTypes.Initial |> fontLanguageOverrideValue'
        static member unset = FssTypes.Unset |> fontLanguageOverrideValue'

    /// Specifies language specific glyphs.
    /// Valid parameters:
    /// - Normal
    /// - Initial
    /// - Inherit
    /// - Unset
    let FontLanguageOverride': (FssTypes.IFontLanguageOverride -> FssTypes.CssProperty) = FontLanguageOverride.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-synthesis
    let private fontSynthesisValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontSynthesis
    let private fontSynthesisValue' = fontSynthesisToString >> fontSynthesisValue

    [<Erase>]
    /// Specifies which missing typefaces can be synthesized by the browser.
    type FontSynthesis =
        static member value (synthesis: FssTypes.IFontSynthesis) = synthesis |> fontSynthesisValue'
        static member weight = FssTypes.Font.Weight |> fontSynthesisValue'
        static member style = FssTypes.Font.Style |> fontSynthesisValue'
        static member weightStyle = FssTypes.Font.WeightStyle |> fontSynthesisValue'
        static member none = FssTypes.None' |> fontSynthesisValue'

    /// Specifies which missing typefaces can be synthesized by the browser.
    /// Valid parameters:
    /// - FontSynthesis
    /// - None
    let FontSynthesis' (synthesis: FssTypes.IFontSynthesis) = FontSynthesis.value(synthesis)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant-position
    let private fontVariantPositionValue  = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontVariantPosition
    let private fontVariantPositionValue' = fontVariantPositionToString >> fontVariantPositionValue

    [<Erase>]
    /// Specifies which missing typefaces can be synthesized by the browser.
    type FontVariantPosition =
        static member value (variantPosition: FssTypes.IFontVariantPosition) = variantPosition |> fontVariantPositionValue'
        static member sub = FssTypes.Font.VariantPosition.Sub |> fontVariantPositionValue'
        static member super = FssTypes.Font.VariantPosition.Super |> fontVariantPositionValue'
        static member normal = FssTypes.Normal |> fontVariantPositionValue'
        static member inherit' = FssTypes.Inherit |> fontVariantPositionValue'
        static member initial = FssTypes.Initial |> fontVariantPositionValue'
        static member unset = FssTypes.Unset |> fontVariantPositionValue'

    /// Specifies which missing typefaces can be synthesized by the browser.
    /// Valid parameters:
    /// - FontVariantPosition
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let FontVariantPosition' = FontVariantPosition.value












