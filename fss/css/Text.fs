namespace Fss

open Fable.Core

[<AutoOpen>]
module Text =
    let private textAlignToString (alignment: FssTypes.ITextAlign) =
        match alignment with
        | :? FssTypes.Text.Align as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown text alignment"

    let private textAlignLastToString (alignment: FssTypes.ITextAlignLast) =
        match alignment with
        | :? FssTypes.Text.AlignLast as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown text alignment last"

    let private decorationLineToString (decorationLine: FssTypes.ITextDecorationLine) =
        match decorationLine with
        | :? FssTypes.Text.DecorationLine as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown text decoration line"

    let private thicknessToString (thickness: FssTypes.ITextDecorationThickness) =
        match thickness with
        | :? FssTypes.Text.DecorationThickness -> "from-font"
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown text decoration thickness"

    let private decorationToString (decoration: FssTypes.ITextDecoration) =
        match decoration with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown text decoration"

    let private decorationStyleToString (style: FssTypes.ITextDecorationStyle) =
        match style with
        | :? FssTypes.Text.DecorationStyle as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown text decoration style"

    let private decorationSkipToString (skip: FssTypes.ITextDecorationSkip) =
        match skip with
        | :? FssTypes.Text.DecorationSkip as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown text decoration skip"

    let private decorationSkipInkToString (skipInk: FssTypes.ITextDecorationSkipInk) =
        match skipInk with
        | :? FssTypes.Text.DecorationSkipInk -> "all"
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown text decoration skip ink"

    let private textTransformToString (transform: FssTypes.ITextTransform) =
        match transform with
        | :? FssTypes.Text.Transform as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown text transform"

    let private indentToString (indent: FssTypes.ITextIndent) =
        match indent with
        | :? FssTypes.Text.Indent as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown text indent"

    let private textShadowToString =
        function
            | FssTypes.Text.XY (x,y) -> sprintf "%s %s" (FssTypes.unitHelpers.sizeToString x) (FssTypes.unitHelpers.sizeToString y)
            | FssTypes.Text.ColorXY (c,x,y) -> sprintf "%s %s %s" (FssTypes.Color.colorHelpers.colorToString c) (FssTypes.unitHelpers.sizeToString x) (FssTypes.unitHelpers.sizeToString y)
            | FssTypes.Text.ColorXYBlur (c,x,y,b) ->
                sprintf "%s %s %s %s"
                    (FssTypes.Color.colorHelpers.colorToString c)
                    (FssTypes.unitHelpers.sizeToString x)
                    (FssTypes.unitHelpers.sizeToString y)
                    (FssTypes.unitHelpers.sizeToString b)

    let private emphasisToString (emphasis: FssTypes.ITextEmphasis) =
        match emphasis with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "unknown text emphasis"

    let private emphasisPositionToString (emphasisPosition: FssTypes.ITextEmphasisPosition) =
        match emphasisPosition with
        | :? FssTypes.Text.EmphasisPosition as e -> Utilities.Helpers.duToLowercase e
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown text emphasis position"

    let private textOverflowToString (overflow: FssTypes.ITextOverflow) =
        match overflow with
        | :? FssTypes.Text.Overflow as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s |> sprintf "\"%s\""
        | _ -> "Unknown text overflow"

    let private emphasisStyleToString (emphasisStyle: FssTypes.ITextEmphasisStyle) =
        let stringifyStyle (style: FssTypes.Text.EmphasisStyle) =
            match style with
            | FssTypes.Text.EmphasisStyle.FilledSesame -> "filled sesame"
            | FssTypes.Text.EmphasisStyle.OpenSesame -> "open sesame"
            | _ -> Utilities.Helpers.duToKebab style

        match emphasisStyle with
        | :? FssTypes.Text.EmphasisStyle as t -> stringifyStyle t
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s |> sprintf "'%s'"
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "unknown text emphasis style"

    let private underlinePositionToString (underlinePosition: FssTypes.ITextUnderlinePosition) =
        match underlinePosition with
        | :? FssTypes.Text.UnderlinePosition as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "unknown text underline position"

    let private textEmphasisColorToString (color: FssTypes.ITextEmphasisColor) =
        match color with
            | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "unknown text emphasis color"

    let private underlineOffsetToString (underlineOffset: FssTypes.ITextUnderlineOffset) =
        match underlineOffset with
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "unknown text underline offset"

    let private quoteToString (quote: FssTypes.IQuotes) =
        match quote with
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown quotes"

    let private hyphensToString (hyphens: FssTypes.IHyphens) =
        match hyphens with
        | :? FssTypes.Text.Hyphens -> "manual"
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown hyphens"

    let private textDecorationColorToString (color: FssTypes.ITextDecorationColor) =
        match color with
            | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "unknown text decoration color"

    let private textSizeAdjustToString (size: FssTypes.ITextSizeAdjust) =
        match size with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown text size adjust"

    let private tabSizeToString (tabSize: FssTypes.ITabSize) =
        match tabSize with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown tab size"

    let private textOrientationToString (textOrientation: FssTypes.ITextOrientation) =
        match textOrientation with
        | :? FssTypes.Text.Orientation as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown text orientation"

    let private textRenderingToString (textRendering: FssTypes.ITextRendering) =
        match textRendering with
        | :? FssTypes.Text.Rendering as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown text rendering"

    let private textJustifyToString (textJustify: FssTypes.ITextJustify) =
        match textJustify with
        | :? FssTypes.Text.Justify as j -> Utilities.Helpers.duToKebab j
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown text justification"

    let private whitespaceToString (whitespace: FssTypes.IWhiteSpace) =
        match whitespace with
        | :? FssTypes.Text.WhiteSpace as ws -> Utilities.Helpers.duToKebab ws
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown whitespace"

    let private userSelectToString (userSelect: FssTypes.IUserSelect) =
        match userSelect with
        | :? FssTypes.Text.UserSelect as u -> Utilities.Helpers.duToLowercase u
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown user select"

    let private hangingPunctuationToString (hangingPunctuation: FssTypes.IHangingPunctuation) =
        match hangingPunctuation with
        | :? FssTypes.Text.HangingPunctuation as hp -> Utilities.Helpers.duToKebab hp
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown hanging punctuation"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    let private alignCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAlign value
    let private alignCssValue' value =
        value
        |> textAlignToString
        |> alignCssValue
    [<Erase>]
    type TextAlign =
        static member value (textAlign: FssTypes.ITextAlign) = textAlign |> alignCssValue'
        static member left = FssTypes.Text.Align.Left |> alignCssValue'
        static member right = FssTypes.Text.Align.Right |> alignCssValue'
        static member center = FssTypes.Text.Align.Center |> alignCssValue'
        static member justify = FssTypes.Text.Align.Justify |> alignCssValue'
        static member justifyAll = FssTypes.Text.JustifyAll |> alignCssValue'
        static member start = FssTypes.Text.Align.Start |> alignCssValue'
        static member end' = FssTypes.Text.Align.End |> alignCssValue'
        static member matchParent = FssTypes.Text.MatchParent |> alignCssValue'

        static member inherit' = FssTypes.Inherit |> alignCssValue'
        static member initial = FssTypes.Initial |> alignCssValue'
        static member unset = FssTypes.Unset |> alignCssValue'

    /// <summary>Specifies the horizontal alignment of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlign' (align: FssTypes.ITextAlign) = TextAlign.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
    let private alignLastCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAlignLast value
    let private alignLastCssValue' value =
        value
        |> textAlignLastToString
        |> alignLastCssValue
    [<Erase>]
    type TextAlignLast =
        static member value (textAlign: FssTypes.ITextAlignLast) = textAlign |> alignLastCssValue'
        static member left = FssTypes.Text.AlignLast.Left |> alignLastCssValue'
        static member right = FssTypes.Text.AlignLast.Right |> alignLastCssValue'
        static member center = FssTypes.Text.AlignLast.Center |> alignLastCssValue'
        static member justify = FssTypes.Text.AlignLast.Justify |> alignLastCssValue'
        static member start = FssTypes.Text.AlignLast.Start |> alignLastCssValue'
        static member end' = FssTypes.Text.AlignLast.End |> alignLastCssValue'

        static member inherit' = FssTypes.Inherit |> alignLastCssValue'
        static member initial = FssTypes.Initial |> alignLastCssValue'
        static member unset = FssTypes.Unset |> alignLastCssValue'

    /// <summary>Specifies the horizontal alignment of the last line of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlignLast' (align: FssTypes.ITextAlignLast) = TextAlignLast.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
    let private decorationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecoration value
    let private decorationValue' value =
        value
        |> decorationToString
        |> decorationValue
    [<Erase>]
    type TextDecoration =
        static member value (value: FssTypes.ITextDecoration) = value |> decorationValue'
        static member none = FssTypes.None' |> decorationValue'

    /// <summary>Resets text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecoration' (decoration: FssTypes.ITextDecoration) = TextDecoration.value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    let private lineCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationLine value
    let private lineCssValue' value =
        value
        |> decorationLineToString
        |> lineCssValue
    [<Erase>]
    type TextDecorationLine =
        static member value (value: FssTypes.ITextDecorationLine) = value |> lineCssValue'
        static member value (v1: FssTypes.ITextDecorationLine, v2: FssTypes.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s" (decorationLineToString v1) (decorationLineToString v2)
        static member value (v1: FssTypes.ITextDecorationLine, v2: FssTypes.ITextDecorationLine, v3: FssTypes.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s %s" (decorationLineToString v1) (decorationLineToString v2) (decorationLineToString v3)
        static member underline = FssTypes.Text.Underline |> lineCssValue'
        static member overline = FssTypes.Text.Overline |> lineCssValue'
        static member lineThrough = FssTypes.Text.LineThrough |> lineCssValue'
        static member blink = FssTypes.Text.Blink |> lineCssValue'

        static member inherit' = FssTypes.Inherit |> lineCssValue'
        static member initial = FssTypes.Initial |> lineCssValue'
        static member unset = FssTypes.Unset |> lineCssValue'
        static member none = FssTypes.None' |> lineCssValue'

    /// <summary>Specifies how to decorate text.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationLine </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationLine' (decoration: FssTypes.ITextDecorationLine) = TextDecorationLine.value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    let private thicknessValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationThickness value
    let private thicknessValue' value =
        value
        |> thicknessToString
        |> thicknessValue
    [<Erase>]
    type TextDecorationThickness =
        static member value (thickness: FssTypes.ITextDecorationThickness) = thickness |> thicknessValue'
        static member fromFont = FssTypes.Text.DecorationThickness |> thicknessValue'

        static member auto = FssTypes.Auto |> thicknessValue'
        static member inherit' = FssTypes.Inherit |> thicknessValue'
        static member initial = FssTypes.Initial |> thicknessValue'
        static member unset = FssTypes.Unset |> thicknessValue'

    /// <summary>Specifies thickness of text decoration.</summary>
    /// <param name="thickness">
    ///     can be:
    ///     - <c> TextDecorationThickness </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationThickness' (thickness: FssTypes.ITextDecorationThickness) = TextDecorationThickness.value(thickness)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    let private decorationStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationStyle value
    let private decorationStyleValue' value =
        value
        |> decorationStyleToString
        |> decorationStyleValue
    [<Erase>]
    type TextDecorationStyle =
        static member value(style: FssTypes.ITextDecorationStyle) = style |> decorationStyleValue'
        static member solid = FssTypes.Text.DecorationStyle.Solid |> decorationStyleValue'
        static member double = FssTypes.Text.DecorationStyle.Double |> decorationStyleValue'
        static member dotted = FssTypes.Text.DecorationStyle.Dotted |> decorationStyleValue'
        static member dashed = FssTypes.Text.DecorationStyle.Dashed |> decorationStyleValue'
        static member wavy = FssTypes.Text.Wavy |> decorationStyleValue'

        static member inherit' = FssTypes.Inherit |> decorationStyleValue'
        static member initial = FssTypes.Initial |> decorationStyleValue'
        static member unset = FssTypes.Unset |> decorationStyleValue'

    /// <summary>Specifies style of text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationStyle' (decoration: FssTypes.ITextDecorationStyle) = TextDecorationStyle.value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    let private skipValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationSkip value
    let private skipValue' value =
        value
        |> decorationSkipToString
        |> skipValue

    [<Erase>]
    type TextDecorationSkip =
        static member value (value: FssTypes.ITextDecorationSkip) = value |> skipValue'
        static member value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s" (decorationSkipToString v1) (decorationSkipToString v2) |> skipValue
        static member value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip, v3: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) |> skipValue
        static member value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip, v3: FssTypes.ITextDecorationSkip, v4: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) (decorationSkipToString v4) |> skipValue

        static member objects = FssTypes.Text.Objects |> skipValue'
        static member spaces = FssTypes.Text.Spaces |> skipValue'
        static member leadingSpaces = FssTypes.Text.LeadingSpaces |> skipValue'
        static member trailingSpaces = FssTypes.Text.TrailingSpaces |> skipValue'
        static member edges = FssTypes.Text.Edges |> skipValue'
        static member boxDecoration = FssTypes.Text.BoxDecoration |> skipValue'

        static member inherit' = FssTypes.Inherit |> skipValue'
        static member initial = FssTypes.Initial |> skipValue'
        static member unset = FssTypes.Unset |> skipValue'
        static member none = FssTypes.None' |> skipValue'

    /// <summary>Specifies what parts of decoration should be skipped.</summary>
    /// <param name="skip">
    ///     can be:
    ///     - <c> TextDecorationSkip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationSkip' (skip: FssTypes.ITextDecorationSkip) = TextDecorationSkip.value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    let private skipInkValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationSkipInk value
    let private skipInkValue' value =
        value
        |> decorationSkipInkToString
        |> skipInkValue
    [<Erase>]
    type TextDecorationSkipInk =
        static member value(skipInk: FssTypes.ITextDecorationSkipInk) = skipInk |> skipInkValue'
        static member all = FssTypes.Text.DecorationSkipInk |> skipInkValue'

        static member inherit' = FssTypes.Inherit |> skipInkValue'
        static member initial = FssTypes.Initial |> skipInkValue'
        static member unset = FssTypes.Unset |> skipInkValue'
        static member none = FssTypes.None' |> skipInkValue'
        static member auto = FssTypes.Auto |> skipInkValue'

    /// <summary>Specifies what parts of decoration should be skipped.</summary>
    /// <param name="skip">
    ///     can be:
    ///     - <c> TextDecorationSkipInk </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationSkipInk' (skip: FssTypes.ITextDecorationSkipInk) = TextDecorationSkipInk.value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    let private transformValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextTransform value
    let private transformValue' value =
        value
        |> textTransformToString
        |> transformValue
    [<Erase>]
    type TextTransform =
        static member value (transform: FssTypes.ITextTransform) = transform |> transformValue'
        static member capitalize = FssTypes.Text.Capitalize |> transformValue'
        static member uppercase = FssTypes.Text.Uppercase |> transformValue'
        static member lowercase = FssTypes.Text.Lowercase |> transformValue'
        static member fullWidth = FssTypes.Text.FullWidth |> transformValue'
        static member fullSizeKana = FssTypes.Text.FullSizeKana |> transformValue'

        static member inherit' = FssTypes.Inherit |> transformValue'
        static member initial = FssTypes.Initial |> transformValue'
        static member unset = FssTypes.Unset |> transformValue'
        static member none = FssTypes.None' |> transformValue'

    /// <summary>Specifies what parts of text to capitalize.</summary>
    /// <param name="transform">
    ///     can be:
    ///     - <c> TextTransform </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextTransform' (transform: FssTypes.ITextTransform) = TextTransform.value(transform)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    let private indentCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextIndent value
    let private indentCssValue' value =
        value
        |> indentToString
        |> indentCssValue
    [<Erase>]
    type TextIndent =
        static member value (indent: FssTypes.ITextIndent) = indent |> indentCssValue'
        static member value (i1: FssTypes.ITextIndent, i2: FssTypes.ITextIndent) = sprintf "%s %s" (indentToString i1) (indentToString i2) |> indentCssValue
        static member value (i1: FssTypes.ITextIndent, i2: FssTypes.ITextIndent, i3: FssTypes.ITextIndent) =
            sprintf "%s %s %s" (indentToString i1) (indentToString i2) (indentToString i3) |> indentCssValue

        static member hanging = FssTypes.Text.Hanging |> indentCssValue'
        static member eachLine = FssTypes.Text.EachLine |> indentCssValue'

        static member inherit' = FssTypes.Inherit |> indentCssValue'
        static member initial = FssTypes.Initial |> indentCssValue'
        static member unset = FssTypes.Unset |> indentCssValue'

    /// <summary>Specifies how much indentation is put before lines of text.</summary>
    /// <param name="indent">
    ///     can be:
    ///     - <c> TextIndent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextIndent' (indent: FssTypes.ITextIndent) = TextIndent.value(indent)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    let private shadowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextShadow value

    [<Erase>]
    type TextShadow =
        static member xy (xOffset: FssTypes.Size, yOffset: FssTypes.Size) =
            FssTypes.Text.XY(xOffset,yOffset)
        static member colorXy (color: FssTypes.Color.ColorType, xOffset: FssTypes.Size, yOffset: FssTypes.Size) =
            FssTypes.Text.ColorXY(color, xOffset, yOffset)
        static member colorXyBlur (xOffset: FssTypes.Size, yOffset: FssTypes.Size, blurRadius: FssTypes.Size, color: FssTypes.Color.ColorType) =
            FssTypes.Text.ColorXYBlur (color, xOffset, yOffset, blurRadius)

    /// Supply a list of text shadows to apply to the text
    let TextShadows (shadows: FssTypes.Text.Shadow list) =
        shadows
        |> Utilities.Helpers.combineComma textShadowToString
        |> shadowValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
    let private overflowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextOverflow value
    let private overflowValue' value =
        value
        |> textOverflowToString
        |> overflowValue
    [<Erase>]
    type TextOverflow =
        static member value (overflow: FssTypes.ITextOverflow) = overflow |> overflowValue'

        static member clip = FssTypes.Text.Overflow.Clip |> overflowValue'
        static member ellipsis = FssTypes.Text.Ellipsis |> overflowValue'

    /// <summary>If there is hidden content this specifies how that is signalled.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> TextOverflow </c>
    ///     - <c> CssString </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOverflow' (overflow: FssTypes.ITextOverflow) = TextOverflow.value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    let private emphasisValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasis value
    let private emphasisValue' value =
        value
        |> emphasisToString
        |> emphasisValue

    [<Erase>]
    type TextEmphasis =
        static member value (emphasis: FssTypes.ITextEmphasis) = emphasis |> emphasisValue'

        static member none = FssTypes.None' |> emphasisValue'
        static member inherit' = FssTypes.Inherit |> emphasisValue'
        static member initial = FssTypes.Initial |> emphasisValue'
        static member unset = FssTypes.Unset |> emphasisValue'

    /// <summary>Specifies emphasis marks to text.</summary>
    /// <param name="emphasis">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasis' (emphasis: FssTypes.ITextEmphasis) = TextEmphasis.value emphasis

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    let private emphasisPositionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisPosition value
    let private emphasisPositionValue' value =
        value
        |> emphasisPositionToString
        |> emphasisPositionValue

    [<Erase>]
    type TextEmphasisPosition =
        static member value (v1: FssTypes.ITextEmphasisPosition, v2: FssTypes.ITextEmphasisPosition) =
            sprintf "%s %s" (emphasisPositionToString v1) (emphasisPositionToString v2)
            |> emphasisPositionValue

        static member inherit' = FssTypes.Inherit |> emphasisPositionValue'
        static member initial = FssTypes.Initial |> emphasisPositionValue'
        static member unset = FssTypes.Unset |> emphasisPositionValue'

    /// <summary>Specifies where emphasis marks are drawn.</summary>
    /// <param name="e1"> </param>
    /// <param name="e2"> </param>
    /// Both params can be:
    ///     - <c> TextEmphasisStyle </c>
    ///     - <c> CssString </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisPosition' (e1: FssTypes.ITextEmphasisPosition) (e2: FssTypes.ITextEmphasisPosition) = TextEmphasisPosition.value(e1, e2)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    let private emphasisStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisStyle value
    let private emphasisStyleValue' value =
        value
        |> emphasisStyleToString
        |> emphasisStyleValue
    [<Erase>]
    type TextEmphasisStyle =
        static member value (emphasisStyle: FssTypes.ITextEmphasisStyle) = emphasisStyle |> emphasisStyleValue'
        static member filled = FssTypes.Text.Filled |> emphasisStyleValue'
        static member open' = FssTypes.Text.Open |> emphasisStyleValue'
        static member dot = FssTypes.Text.Dot |> emphasisStyleValue'
        static member circle = FssTypes.Text.EmphasisStyle.Circle |> emphasisStyleValue'
        static member doubleCircle = FssTypes.Text.DoubleCircle |> emphasisStyleValue'
        static member triangle = FssTypes.Text.Triangle |> emphasisStyleValue'
        static member filledSesame = FssTypes.Text.FilledSesame |> emphasisStyleValue'
        static member openSesame = FssTypes.Text.OpenSesame |> emphasisStyleValue'

        static member none = FssTypes.None' |> emphasisStyleValue'
        static member inherit' = FssTypes.Inherit |> emphasisStyleValue'
        static member initial = FssTypes.Initial |> emphasisStyleValue'
        static member unset = FssTypes.Unset |> emphasisStyleValue'

    /// <summary>Specifies style of text emphasis.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> TextEmphasisStyle </c>
    ///     - <c> CssString </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisStyle' (style: FssTypes.ITextEmphasisStyle) = TextEmphasisStyle.value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    let private underlinePositionCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextUnderlinePosition value
    let private underlinePositionCssValue' value =
        value
        |> underlinePositionToString
        |> underlinePositionCssValue

    [<Erase>]
    type TextUnderlinePosition =
        static member value (underlinePosition: FssTypes.ITextUnderlinePosition) =
            underlinePosition |> underlinePositionCssValue'
        static member value (v1: FssTypes.ITextUnderlinePosition, v2: FssTypes.ITextUnderlinePosition) =
            sprintf "%s %s" (underlinePositionToString v1) (underlinePositionToString v2) |> underlinePositionCssValue

        static member fromFont = FssTypes.Text.UnderlinePosition.FromFont |> underlinePositionCssValue'
        static member under = FssTypes.Text.UnderlinePosition.Under |> underlinePositionCssValue'
        static member left = FssTypes.Text.UnderlinePosition.Left |> underlinePositionCssValue'
        static member right = FssTypes.Text.UnderlinePosition.Right |> underlinePositionCssValue'
        static member autoPos = FssTypes.Text.UnderlinePosition.AutoPos  |> underlinePositionCssValue'
        static member above = FssTypes.Text.UnderlinePosition.Above |> underlinePositionCssValue'
        static member below = FssTypes.Text.UnderlinePosition.Below |> underlinePositionCssValue'

        static member auto = FssTypes.Auto |> underlinePositionCssValue'
        static member inherit' = FssTypes.Inherit |> underlinePositionCssValue'
        static member initial = FssTypes.Initial |> underlinePositionCssValue'
        static member unset = FssTypes.Unset |> underlinePositionCssValue'

    /// <summary>Specifies the position of text underline.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> UnderlinePosition </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextUnderlinePosition' (position: FssTypes.ITextUnderlinePosition) = TextUnderlinePosition.value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
    let private offsetValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextUnderlineOffset value
    let private offsetValue' value =
        value
        |> underlineOffsetToString
        |> offsetValue
    [<Erase>]
    type TextUnderlineOffset =
        static member value (underlineOffset: FssTypes.ITextUnderlineOffset) = underlineOffset |> offsetValue'
        static member inherit' = FssTypes.Inherit |> offsetValue'
        static member initial = FssTypes.Initial |> offsetValue'
        static member unset = FssTypes.Unset |> offsetValue'
        static member auto = FssTypes.Auto |> offsetValue'

    /// <summary>Specifies the offset of text underline.</summary>
    /// <param name="offset">
    ///     can be:
    ///     - <c> Size  </c>
    ///     - <c> Percent  </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextUnderlineOffset' (offset: FssTypes.ITextUnderlineOffset) = TextUnderlineOffset.value(offset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/quotes
    let private quoteValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Quotes value
    let private quoteValue' value =
        value
        |> quoteToString
        |> quoteValue
    [<Erase>]
    type Quotes =
        static member value (quote: FssTypes.IQuotes) =
            quote
            |> quoteValue'
        static member value (openQuote: FssTypes.IQuotes, closeQuote: FssTypes.IQuotes) =
            quoteValue
            <| sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote)
        static member value (openCloseQuotes: ((FssTypes.IQuotes * FssTypes.IQuotes) list)) =
            openCloseQuotes
            |> List.map (fun (openQuote, closeQuote) ->
                sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote))
            |> String.concat " "
            |> quoteValue

        static member none = FssTypes.None' |> quoteValue'
        static member auto = FssTypes.Auto |> quoteValue'
        static member inherit' = FssTypes.Inherit |> quoteValue'
        static member initial = FssTypes.Initial |> quoteValue'
        static member unset = FssTypes.Unset |> quoteValue'

    /// <summary>Specifies how to render quotation marks.</summary>
    /// <param name="quotes">
    ///     can be:
    ///     - <c> CssString  </c>
    ///     - <c> None  </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Quotes' (quotes: FssTypes.IQuotes) = Quotes.value(quotes)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/hyphens
    let private hyphensValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Hyphens value
    let private hyphensValue' value =
        value
        |> hyphensToString
        |> hyphensValue
    [<Erase>]
    type Hyphens =
        static member value (hyphens: FssTypes.IHyphens) = hyphens |> hyphensValue'
        static member manual = FssTypes.Text.Manual |> hyphensValue'
        static member auto = FssTypes.Auto |> hyphensValue'
        static member none = FssTypes.None' |> hyphensValue'
        static member inherit' = FssTypes.Inherit |> hyphensValue'
        static member initial = FssTypes.Initial |> hyphensValue'
        static member unset = FssTypes.Unset |> hyphensValue'

    /// <summary>Specifies words will be hyphenated when text wraps.</summary>
    /// <param name="hyphens">
    ///     can be:
    ///     - <c> Hyphens  </c>
    ///     - <c> None  </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Hyphens' (hyphens: FssTypes.IHyphens) = Hyphens.value(hyphens)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-color
    let private textDecorationColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationColor value
    let private textDecorationColorValue' value =
        value
        |> textDecorationColorToString
        |> textDecorationColorValue

    let TextDecorationColor = FssTypes.TextDecorationColor (textDecorationColorValue')

    /// <summary>Specifies color of text decoration.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationColor' (color: FssTypes.ITextDecorationColor) = TextDecorationColor.value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-color
    let private emphasisColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisColor value
    let private emphasisColorValue' value =
        value
        |> textEmphasisColorToString
        |> emphasisColorValue


    let TextEmphasisColor = FssTypes.TextEmphasisColor (emphasisColorValue')

    /// <summary>Specifies color of text emphasis.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisColor' (color: FssTypes.ITextEmphasisColor) = TextEmphasisColor.value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-size-adjust
    let private textSizeAdjustValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextSizeAdjust value
    let private textSizeAdjustValue' value = value |> textSizeAdjustToString |> textSizeAdjustValue

    [<Erase>]
    type TextSizeAdjust =
        static member value (textSize: FssTypes.ITextSizeAdjust) = textSize |> textSizeAdjustValue'
        static member auto = FssTypes.Auto |> textSizeAdjustValue'
        static member none = FssTypes.None' |> textSizeAdjustValue'
        static member inherit' = FssTypes.Inherit |> textSizeAdjustValue'
        static member initial = FssTypes.Initial |> textSizeAdjustValue'
        static member unset = FssTypes.Unset |> textSizeAdjustValue'

    /// <summary>Controls the text inflation on some mobile browsers.</summary>
    /// <param name="textSize">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextSizeAdjust' textSize = TextSizeAdjust.value textSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/tab-size
    let private tabSizeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TabSize value
    let private tabSizeValue' value = value |> tabSizeToString |> tabSizeValue

    [<Erase>]
    type TabSize =
        static member value (tabSize: FssTypes.ITabSize) = tabSize |> tabSizeValue'
        static member inherit' = FssTypes.Inherit |> tabSizeValue'
        static member initial = FssTypes.Initial |> tabSizeValue'
        static member unset = FssTypes.Unset |> tabSizeValue'

    /// <summary>Specifies the width of tab characters.</summary>
    /// <param name="tabSize">
    ///     can be:
    ///     - <c> Size </c>
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TabSize' tabSize = TabSize.value tabSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-orientation
    let private textOrientationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextOrientation value
    let private textOrientationValue' value = value |> textOrientationToString |> textOrientationValue

    [<Erase>]
    type TextOrientation =
        static member value (orientation: FssTypes.ITextOrientation) = orientation |> textOrientationValue'
        static member mixed = FssTypes.Text.Mixed |> textOrientationValue'
        static member upright = FssTypes.Text.Upright |> textOrientationValue'
        static member sidewaysRight = FssTypes.Text.SidewaysRight |> textOrientationValue'
        static member sideways = FssTypes.Text.Sideways |> textOrientationValue'
        static member useGlyphOrientation = FssTypes.Text.UseGlyphOrientation |> textOrientationValue'
        static member inherit' = FssTypes.Inherit |> textOrientationValue'
        static member initial = FssTypes.Initial |> textOrientationValue'
        static member unset = FssTypes.Unset |> textOrientationValue'

    /// <summary>Sets the orientation of the text characters.</summary>
    /// <param name="orientation">
    ///     can be:
    ///     - <c> TextOrientation </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOrientation' orientation = TextOrientation.value orientation

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
    let private textRenderingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextRendering value
    let private textRenderingValue' value = value |> textRenderingToString |> textRenderingValue

    [<Erase>]
    type TextRendering =
        static member value (rendering: FssTypes.ITextRendering) = rendering |> textRenderingValue'
        static member optimizeSpeed = FssTypes.Text.OptimizeSpeed |> textRenderingValue'
        static member optimizeLegibility = FssTypes.Text.OptimizeLegibility |> textRenderingValue'
        static member geometricPrecision = FssTypes.Text.GeometricPrecision |> textRenderingValue'
        static member auto = FssTypes.Auto |> textRenderingValue'
        static member inherit' = FssTypes.Inherit |> textRenderingValue'
        static member initial = FssTypes.Initial |> textRenderingValue'
        static member unset = FssTypes.Unset |> textRenderingValue'

    /// <summary>Specifies how to render text.</summary>
    /// <param name="rendering">
    ///     can be:
    ///     - <c> TextRendering </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextRendering' rendering = TextRendering.value rendering

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
    let private textJustifyValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextJustify value
    let private textJustifyValue' value = value |> textJustifyToString |> textJustifyValue

    [<Erase>]
    type TextJustify =
        static member value (justification: FssTypes.ITextJustify) = justification |> textJustifyValue'
        static member interWord = FssTypes.Text.InterWord |> textJustifyValue'
        static member interCharacter = FssTypes.Text.InterCharacter |> textJustifyValue'
        static member auto = FssTypes.Auto |> textJustifyValue'
        static member none = FssTypes.None' |> textJustifyValue'

    /// <summary>Specifies how to justify text.</summary>
    /// <param name="justification">
    ///     can be:
    ///     - <c> TextJustify </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextJustify' justification = TextJustify.value justification

    // https://developer.mozilla.org/en-US/docs/Web/CSS/white-space
    let private whiteSpaceValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.WhiteSpace value
    let private whiteSpaceValue' value = value |> whitespaceToString |> whiteSpaceValue

    [<Erase>]
    type WhiteSpace =
        static member value (whitespace: FssTypes.IWhiteSpace) = whitespace |> whiteSpaceValue'
        static member noWrap = FssTypes.Text.WhiteSpace.NoWrap |> whiteSpaceValue'
        static member pre = FssTypes.Text.Pre |> whiteSpaceValue'
        static member preWrap = FssTypes.Text.PreWrap |> whiteSpaceValue'
        static member preLine = FssTypes.Text.PreLine |> whiteSpaceValue'
        static member breakSpaces = FssTypes.Text.BreakSpaces |> whiteSpaceValue'
        static member normal = FssTypes.Normal |> whiteSpaceValue'
        static member inherit' = FssTypes.Inherit |> whiteSpaceValue'
        static member initial = FssTypes.Initial |> whiteSpaceValue'
        static member unset = FssTypes.Unset |> whiteSpaceValue'

    /// <summary>Specifies how white space is handled.</summary>
    /// <param name="whitespace">
    ///     can be:
    ///     - <c> WhiteSpace </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WhiteSpace' whitespace = WhiteSpace.value whitespace

    // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
    let private userSelectValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.UserSelect value
    let private userSelectValue' value = value |> userSelectToString |> userSelectValue

    [<Erase>]
    type UserSelect =
        static member value (whitespace: FssTypes.IUserSelect) = whitespace |> userSelectValue'
        static member text = FssTypes.Text.UserSelect.Text |> userSelectValue'
        static member contain = FssTypes.Text.UserSelect.Contain |> userSelectValue'
        static member all = FssTypes.Text.UserSelect.All |> userSelectValue'
        static member none = FssTypes.None' |> userSelectValue'
        static member auto = FssTypes.Auto |> userSelectValue'
        static member inherit' = FssTypes.Inherit |> userSelectValue'
        static member initial = FssTypes.Initial |> userSelectValue'
        static member unset = FssTypes.Unset |> userSelectValue'

    /// <summary>Specifies whether the user can select text.</summary>
    /// <param name="userSelect">
    ///     can be:
    ///     - <c> UserSelect </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let UserSelect' userSelect = UserSelect.value userSelect

    // https://developer.mozilla.org/en-US/docs/Web/CSS/hanging-punctuation
    let private hangingPunctuationValue (value: string) = FssTypes.propertyHelpers.cssValue FssTypes.Property.HangingPunctuation value
    let private hangingPunctuationValue': FssTypes.IHangingPunctuation -> FssTypes.CssProperty = hangingPunctuationToString >> hangingPunctuationValue

    [<Erase>]
    type HangingPunctuation =
        static member value hangingPunctuation = hangingPunctuation |> hangingPunctuationValue'
        static member value (p1, p2) =
            $"{hangingPunctuationToString p1} {hangingPunctuationToString p2}"
            |> hangingPunctuationValue
        static member value (p1, p2, p3) =
            $"{hangingPunctuationToString p1} {hangingPunctuationToString p2} {hangingPunctuationToString p3}"
            |> hangingPunctuationValue
        static member first = FssTypes.Text.HangingPunctuation.First |> hangingPunctuationValue'
        static member last = FssTypes.Text.HangingPunctuation.Last |> hangingPunctuationValue'
        static member forceEnd = FssTypes.Text.HangingPunctuation.ForceEnd |> hangingPunctuationValue'
        static member allowEnd = FssTypes.Text.HangingPunctuation.AllowEnd |> hangingPunctuationValue'
        static member none = FssTypes.None' |> hangingPunctuationValue'
        static member inherit' = FssTypes.Inherit |> hangingPunctuationValue'
        static member initial = FssTypes.Initial |> hangingPunctuationValue'
        static member unset = FssTypes.Unset |> hangingPunctuationValue'

    /// <summary>Specifies whether a punctuation mark should hang at the start or end of a line.</summary>
    /// <param name="hangingPunctuation">
    ///     can be:
    ///     - <c> HangingPunctuation </c>
    ///     - <c> UserSelect </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let HangingPunctuation' hangingPunctuation = HangingPunctuation.value hangingPunctuation