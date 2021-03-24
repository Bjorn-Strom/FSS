namespace Fss

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
            | FssTypes.Text.ColorXY (c,x,y) -> sprintf "%s %s %s" (FssTypes.colorHelpers.colorToString c) (FssTypes.unitHelpers.sizeToString x) (FssTypes.unitHelpers.sizeToString y)
            | FssTypes.Text.ColorXYBlur (c,x,y,b) ->
                sprintf "%s %s %s %s"
                    (FssTypes.colorHelpers.colorToString c)
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
            | :? FssTypes.ColorTypeFoo as c -> FssTypes.colorHelpers.colorToString c
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
            | :? FssTypes.ColorTypeFoo as c -> FssTypes.colorHelpers.colorToString c
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    let private alignCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAlign value
    let private alignCssValue' value =
        value
        |> textAlignToString
        |> alignCssValue
    type TextAlign =
        static member Value (textAlign: FssTypes.ITextAlign) = textAlign |> alignCssValue'
        static member Left = FssTypes.Text.Align.Left |> alignCssValue'
        static member Right = FssTypes.Text.Align.Right |> alignCssValue'
        static member Center = FssTypes.Text.Align.Center |> alignCssValue'
        static member Justify = FssTypes.Text.Align.Justify |> alignCssValue'
        static member JustifyAll = FssTypes.Text.JustifyAll |> alignCssValue'
        static member Start = FssTypes.Text.Align.Start |> alignCssValue'
        static member End = FssTypes.Text.Align.End |> alignCssValue'
        static member MatchParent = FssTypes.Text.MatchParent |> alignCssValue'

        static member Inherit = FssTypes.Inherit |> alignCssValue'
        static member Initial = FssTypes.Initial |> alignCssValue'
        static member Unset = FssTypes.Unset |> alignCssValue'

    /// <summary>Specifies the horizontal alignment of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlign' (align: FssTypes.ITextAlign) = TextAlign.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
    let private alignLastCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAlignLast value
    let private alignLastCssValue' value =
        value
        |> textAlignLastToString
        |> alignLastCssValue
    type TextAlignLast =
        static member Value (textAlign: FssTypes.ITextAlignLast) = textAlign |> alignLastCssValue'
        static member Left = FssTypes.Text.AlignLast.Left |> alignLastCssValue'
        static member Right = FssTypes.Text.AlignLast.Right |> alignLastCssValue'
        static member Center = FssTypes.Text.AlignLast.Center |> alignLastCssValue'
        static member Justify = FssTypes.Text.AlignLast.Justify |> alignLastCssValue'
        static member Start = FssTypes.Text.AlignLast.Start |> alignLastCssValue'
        static member End = FssTypes.Text.AlignLast.End |> alignLastCssValue'

        static member Inherit = FssTypes.Inherit |> alignLastCssValue'
        static member Initial = FssTypes.Initial |> alignLastCssValue'
        static member Unset = FssTypes.Unset |> alignLastCssValue'

    /// <summary>Specifies the horizontal alignment of the last line of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlignLast' (align: FssTypes.ITextAlignLast) = TextAlignLast.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
    let private decorationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecoration value
    let private decorationValue' value =
        value
        |> decorationToString
        |> decorationValue
    type TextDecoration =
        static member Value (value: FssTypes.ITextDecoration) = value |> decorationValue'
        static member None = FssTypes.None' |> decorationValue'

    /// <summary>Resets text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecoration' (decoration: FssTypes.ITextDecoration) = TextDecoration.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    let private lineCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationLine value
    let private lineCssValue' value =
        value
        |> decorationLineToString
        |> lineCssValue
    type TextDecorationLine =
        static member Value (value: FssTypes.ITextDecorationLine) = value |> lineCssValue'
        static member Value (v1: FssTypes.ITextDecorationLine, v2: FssTypes.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s" (decorationLineToString v1) (decorationLineToString v2)
        static member Value (v1: FssTypes.ITextDecorationLine, v2: FssTypes.ITextDecorationLine, v3: FssTypes.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s %s" (decorationLineToString v1) (decorationLineToString v2) (decorationLineToString v3)
        static member Underline = FssTypes.Text.Underline |> lineCssValue'
        static member Overline = FssTypes.Text.Overline |> lineCssValue'
        static member LineThrough = FssTypes.Text.LineThrough |> lineCssValue'
        static member Blink = FssTypes.Text.Blink |> lineCssValue'

        static member Inherit = FssTypes.Inherit |> lineCssValue'
        static member Initial = FssTypes.Initial |> lineCssValue'
        static member Unset = FssTypes.Unset |> lineCssValue'
        static member None = FssTypes.None' |> lineCssValue'

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
    let TextDecorationLine' (decoration: FssTypes.ITextDecorationLine) = TextDecorationLine.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    let private thicknessValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationThickness value
    let private thicknessValue' value =
        value
        |> thicknessToString
        |> thicknessValue
    type TextDecorationThickness =
        static member Value (thickness: FssTypes.ITextDecorationThickness) = thickness |> thicknessValue'
        static member FromFont = FssTypes.Text.DecorationThickness |> thicknessValue'

        static member Auto = FssTypes.Auto |> thicknessValue'
        static member Inherit = FssTypes.Inherit |> thicknessValue'
        static member Initial = FssTypes.Initial |> thicknessValue'
        static member Unset = FssTypes.Unset |> thicknessValue'

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
    let TextDecorationThickness' (thickness: FssTypes.ITextDecorationThickness) = TextDecorationThickness.Value(thickness)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    let private decorationStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationStyle value
    let private decorationStyleValue' value =
        value
        |> decorationStyleToString
        |> decorationStyleValue
    type TextDecorationStyle =
        static member Value(style: FssTypes.ITextDecorationStyle) = style |> decorationStyleValue'
        static member Solid = FssTypes.Text.DecorationStyle.Solid |> decorationStyleValue'
        static member Double = FssTypes.Text.DecorationStyle.Double |> decorationStyleValue'
        static member Dotted = FssTypes.Text.DecorationStyle.Dotted |> decorationStyleValue'
        static member Dashed = FssTypes.Text.DecorationStyle.Dashed |> decorationStyleValue'
        static member Wavy = FssTypes.Text.Wavy |> decorationStyleValue'

        static member Inherit = FssTypes.Inherit |> decorationStyleValue'
        static member Initial = FssTypes.Initial |> decorationStyleValue'
        static member Unset = FssTypes.Unset |> decorationStyleValue'

    /// <summary>Specifies style of text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationStyle' (decoration: FssTypes.ITextDecorationStyle) = TextDecorationStyle.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    let private skipValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationSkip value
    let private skipValue' value =
        value
        |> decorationSkipToString
        |> skipValue

    type TextDecorationSkip =
        static member Value (value: FssTypes.ITextDecorationSkip) = value |> skipValue'
        static member Value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s" (decorationSkipToString v1) (decorationSkipToString v2) |> skipValue
        static member Value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip, v3: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) |> skipValue
        static member Value (v1: FssTypes.ITextDecorationSkip, v2: FssTypes.ITextDecorationSkip, v3: FssTypes.ITextDecorationSkip, v4: FssTypes.ITextDecorationSkip) =
            sprintf "%s %s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) (decorationSkipToString v4) |> skipValue

        static member Objects = FssTypes.Text.Objects |> skipValue'
        static member Spaces = FssTypes.Text.Spaces |> skipValue'
        static member LeadingSpaces = FssTypes.Text.LeadingSpaces |> skipValue'
        static member TrailingSpaces = FssTypes.Text.TrailingSpaces |> skipValue'
        static member Edges = FssTypes.Text.Edges |> skipValue'
        static member BoxDecoration = FssTypes.Text.BoxDecoration |> skipValue'

        static member Inherit = FssTypes.Inherit |> skipValue'
        static member Initial = FssTypes.Initial |> skipValue'
        static member Unset = FssTypes.Unset |> skipValue'
        static member None = FssTypes.None' |> skipValue'

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
    let TextDecorationSkip' (skip: FssTypes.ITextDecorationSkip) = TextDecorationSkip.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    let private skipInkValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationSkipInk value
    let private skipInkValue' value =
        value
        |> decorationSkipInkToString
        |> skipInkValue
    type TextDecorationSkipInk =
        static member Value(skipInk: FssTypes.ITextDecorationSkipInk) = skipInk |> skipInkValue'
        static member All = FssTypes.Text.DecorationSkipInk |> skipInkValue'

        static member Inherit = FssTypes.Inherit |> skipInkValue'
        static member Initial = FssTypes.Initial |> skipInkValue'
        static member Unset = FssTypes.Unset |> skipInkValue'
        static member None = FssTypes.None' |> skipInkValue'
        static member Auto = FssTypes.Auto |> skipInkValue'

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
    let TextDecorationSkipInk' (skip: FssTypes.ITextDecorationSkipInk) = TextDecorationSkipInk.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    let private transformValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextTransform value
    let private transformValue' value =
        value
        |> textTransformToString
        |> transformValue
    type TextTransform =
        static member Value (transform: FssTypes.ITextTransform) = transform |> transformValue'
        static member Capitalize = FssTypes.Text.Capitalize |> transformValue'
        static member Uppercase = FssTypes.Text.Uppercase |> transformValue'
        static member Lowercase = FssTypes.Text.Lowercase |> transformValue'
        static member FullWidth = FssTypes.Text.FullWidth |> transformValue'
        static member FullSizeKana = FssTypes.Text.FullSizeKana |> transformValue'

        static member Inherit = FssTypes.Inherit |> transformValue'
        static member Initial = FssTypes.Initial |> transformValue'
        static member Unset = FssTypes.Unset |> transformValue'
        static member None = FssTypes.None' |> transformValue'

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
    let TextTransform' (transform: FssTypes.ITextTransform) = TextTransform.Value(transform)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    let private indentCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextIndent value
    let private indentCssValue' value =
        value
        |> indentToString
        |> indentCssValue
    type TextIndent =
        static member Value (indent: FssTypes.ITextIndent) = indent |> indentCssValue'
        static member Value (i1: FssTypes.ITextIndent, i2: FssTypes.ITextIndent) = sprintf "%s %s" (indentToString i1) (indentToString i2) |> indentCssValue
        static member Value (i1: FssTypes.ITextIndent, i2: FssTypes.ITextIndent, i3: FssTypes.ITextIndent) =
            sprintf "%s %s %s" (indentToString i1) (indentToString i2) (indentToString i3) |> indentCssValue

        static member Hanging = FssTypes.Text.Hanging |> indentCssValue'
        static member EachLine = FssTypes.Text.EachLine |> indentCssValue'

        static member Inherit = FssTypes.Inherit |> indentCssValue'
        static member Initial = FssTypes.Initial |> indentCssValue'
        static member Unset = FssTypes.Unset |> indentCssValue'

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
    let TextIndent' (indent: FssTypes.ITextIndent) = TextIndent.Value(indent)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    let private shadowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextShadow value

    type TextShadow =
        static member XY (xOffset: FssTypes.Size, yOffset: FssTypes.Size) =
            FssTypes.Text.XY(xOffset,yOffset)
        static member ColorXY (color: FssTypes.ColorTypeFoo, xOffset: FssTypes.Size, yOffset: FssTypes.Size) =
            FssTypes.Text.ColorXY(color, xOffset, yOffset)
        static member ColorXYBlur (xOffset: FssTypes.Size, yOffset: FssTypes.Size, blurRadius: FssTypes.Size, color: FssTypes.ColorTypeFoo) =
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
    type TextOverflow =
        static member Value (overflow: FssTypes.ITextOverflow) = overflow |> overflowValue'

        static member Clip = FssTypes.Text.Overflow.Clip |> overflowValue'
        static member Ellipsis = FssTypes.Text.Ellipsis |> overflowValue'

    /// <summary>If there is hidden content this specifies how that is signalled.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> TextOverflow </c>
    ///     - <c> CssString </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOverflow' (overflow: FssTypes.ITextOverflow) = TextOverflow.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    let private emphasisValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasis value
    let private emphasisValue' value =
        value
        |> emphasisToString
        |> emphasisValue

    type TextEmphasis =
        static member Value (emphasis: FssTypes.ITextEmphasis) = emphasis |> emphasisValue'

        static member None = FssTypes.None' |> emphasisValue'
        static member Inherit = FssTypes.Inherit |> emphasisValue'
        static member Initial = FssTypes.Initial |> emphasisValue'
        static member Unset = FssTypes.Unset |> emphasisValue'

    /// <summary>Specifies emphasis marks to text.</summary>
    /// <param name="emphasis">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasis' (emphasis: FssTypes.ITextEmphasis) = TextEmphasis.Value emphasis

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    let private emphasisPositionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisPosition value
    let private emphasisPositionValue' value =
        value
        |> emphasisPositionToString
        |> emphasisPositionValue

    type TextEmphasisPosition =
        static member Value (v1: FssTypes.ITextEmphasisPosition, v2: FssTypes.ITextEmphasisPosition) =
            sprintf "%s %s" (emphasisPositionToString v1) (emphasisPositionToString v2)
            |> emphasisPositionValue

        static member Inherit = FssTypes.Inherit |> emphasisPositionValue'
        static member Initial = FssTypes.Initial |> emphasisPositionValue'
        static member Unset = FssTypes.Unset |> emphasisPositionValue'

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
    let TextEmphasisPosition' (e1: FssTypes.ITextEmphasisPosition) (e2: FssTypes.ITextEmphasisPosition) = TextEmphasisPosition.Value(e1, e2)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    let private emphasisStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisStyle value
    let private emphasisStyleValue' value =
        value
        |> emphasisStyleToString
        |> emphasisStyleValue
    type TextEmphasisStyle =
        static member Value (emphasisStyle: FssTypes.ITextEmphasisStyle) = emphasisStyle |> emphasisStyleValue'
        static member Filled = FssTypes.Text.Filled |> emphasisStyleValue'
        static member Open = FssTypes.Text.Open |> emphasisStyleValue'
        static member Dot = FssTypes.Text.Dot |> emphasisStyleValue'
        static member Circle = FssTypes.Text.EmphasisStyle.Circle |> emphasisStyleValue'
        static member DoubleCircle = FssTypes.Text.DoubleCircle |> emphasisStyleValue'
        static member Triangle = FssTypes.Text.Triangle |> emphasisStyleValue'
        static member FilledSesame = FssTypes.Text.FilledSesame |> emphasisStyleValue'
        static member OpenSesame = FssTypes.Text.OpenSesame |> emphasisStyleValue'

        static member None = FssTypes.None' |> emphasisStyleValue'
        static member Inherit = FssTypes.Inherit |> emphasisStyleValue'
        static member Initial = FssTypes.Initial |> emphasisStyleValue'
        static member Unset = FssTypes.Unset |> emphasisStyleValue'

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
    let TextEmphasisStyle' (style: FssTypes.ITextEmphasisStyle) = TextEmphasisStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    let private underlinePositionCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextUnderlinePosition value
    let private underlinePositionCssValue' value =
        value
        |> underlinePositionToString
        |> underlinePositionCssValue

    type TextUnderlinePosition =
        static member Value (underlinePosition: FssTypes.ITextUnderlinePosition) =
            underlinePosition |> underlinePositionCssValue'
        static member Value (v1: FssTypes.ITextUnderlinePosition, v2: FssTypes.ITextUnderlinePosition) =
            sprintf "%s %s" (underlinePositionToString v1) (underlinePositionToString v2) |> underlinePositionCssValue

        static member FromFont = FssTypes.Text.UnderlinePosition.FromFont |> underlinePositionCssValue'
        static member Under = FssTypes.Text.UnderlinePosition.Under |> underlinePositionCssValue'
        static member Left = FssTypes.Text.UnderlinePosition.Left |> underlinePositionCssValue'
        static member Right = FssTypes.Text.UnderlinePosition.Right |> underlinePositionCssValue'
        static member AutoPos = FssTypes.Text.UnderlinePosition.AutoPos  |> underlinePositionCssValue'
        static member Above = FssTypes.Text.UnderlinePosition.Above |> underlinePositionCssValue'
        static member Below = FssTypes.Text.UnderlinePosition.Below |> underlinePositionCssValue'

        static member Auto = FssTypes.Auto |> underlinePositionCssValue'
        static member Inherit = FssTypes.Inherit |> underlinePositionCssValue'
        static member Initial = FssTypes.Initial |> underlinePositionCssValue'
        static member Unset = FssTypes.Unset |> underlinePositionCssValue'

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
    let TextUnderlinePosition' (position: FssTypes.ITextUnderlinePosition) = TextUnderlinePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
    let private offsetValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextUnderlineOffset value
    let private offsetValue' value =
        value
        |> underlineOffsetToString
        |> offsetValue
    type TextUnderlineOffset =
        static member Value (underlineOffset: FssTypes.ITextUnderlineOffset) = underlineOffset |> offsetValue'
        static member Inherit = FssTypes.Inherit |> offsetValue'
        static member Initial = FssTypes.Initial |> offsetValue'
        static member Unset = FssTypes.Unset |> offsetValue'
        static member Auto = FssTypes.Auto |> offsetValue'

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
    let TextUnderlineOffset' (offset: FssTypes.ITextUnderlineOffset) = TextUnderlineOffset.Value(offset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/quotes
    let private quoteValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Quotes value
    let private quoteValue' value =
        value
        |> quoteToString
        |> quoteValue
    type Quotes =
        static member Value (quote: FssTypes.IQuotes) =
            quote
            |> quoteValue'
        static member Value (openQuote: FssTypes.IQuotes, closeQuote: FssTypes.IQuotes) =
            quoteValue
            <| sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote)
        static member Value (openCloseQuotes: ((FssTypes.IQuotes * FssTypes.IQuotes) list)) =
            openCloseQuotes
            |> List.map (fun (openQuote, closeQuote) ->
                sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote))
            |> String.concat " "
            |> quoteValue

        static member None = FssTypes.None' |> quoteValue'
        static member Auto = FssTypes.Auto |> quoteValue'
        static member Inherit = FssTypes.Inherit |> quoteValue'
        static member Initial = FssTypes.Initial |> quoteValue'
        static member Unset = FssTypes.Unset |> quoteValue'

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
    let Quotes' (quotes: FssTypes.IQuotes) = Quotes.Value(quotes)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/hyphens
    let private hyphensValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Hyphens value
    let private hyphensValue' value =
        value
        |> hyphensToString
        |> hyphensValue
    type Hyphens =
        static member Value (hyphens: FssTypes.IHyphens) = hyphens |> hyphensValue'
        static member Manual = FssTypes.Text.Manual |> hyphensValue'
        static member Auto = FssTypes.Auto |> hyphensValue'
        static member None = FssTypes.None' |> hyphensValue'
        static member Inherit = FssTypes.Inherit |> hyphensValue'
        static member Initial = FssTypes.Initial |> hyphensValue'
        static member Unset = FssTypes.Unset |> hyphensValue'

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
    let Hyphens' (hyphens: FssTypes.IHyphens) = Hyphens.Value(hyphens)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-color
    let private textDecorationColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextDecorationColor value
    let private textDecorationColorValue' value =
        value
        |> textDecorationColorToString
        |> textDecorationColorValue
    type TextDecorationColor =
        static member Value (color: FssTypes.ITextDecorationColor) = color |> textDecorationColorValue'

        static member black = FssTypes.Color.black |> textDecorationColorValue'
        static member silver = FssTypes.Color.silver |> textDecorationColorValue'
        static member gray = FssTypes.Color.gray |> textDecorationColorValue'
        static member white = FssTypes.Color.white |> textDecorationColorValue'
        static member maroon = FssTypes.Color.maroon |> textDecorationColorValue'
        static member red = FssTypes.Color.red |> textDecorationColorValue'
        static member purple = FssTypes.Color.purple |> textDecorationColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> textDecorationColorValue'
        static member green = FssTypes.Color.green |> textDecorationColorValue'
        static member lime = FssTypes.Color.lime |> textDecorationColorValue'
        static member olive = FssTypes.Color.olive |> textDecorationColorValue'
        static member yellow = FssTypes.Color.yellow |> textDecorationColorValue'
        static member navy = FssTypes.Color.navy |> textDecorationColorValue'
        static member blue = FssTypes.Color.blue |> textDecorationColorValue'
        static member teal = FssTypes.Color.teal |> textDecorationColorValue'
        static member aqua = FssTypes.Color.aqua |> textDecorationColorValue'
        static member orange = FssTypes.Color.orange |> textDecorationColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> textDecorationColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> textDecorationColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> textDecorationColorValue'
        static member azure = FssTypes.Color.azure |> textDecorationColorValue'
        static member beige = FssTypes.Color.beige |> textDecorationColorValue'
        static member bisque = FssTypes.Color.bisque |> textDecorationColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> textDecorationColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> textDecorationColorValue'
        static member brown = FssTypes.Color.brown |> textDecorationColorValue'
        static member burlywood = FssTypes.Color.burlywood |> textDecorationColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> textDecorationColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> textDecorationColorValue'
        static member chocolate = FssTypes.Color.chocolate |> textDecorationColorValue'
        static member coral = FssTypes.Color.coral |> textDecorationColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> textDecorationColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> textDecorationColorValue'
        static member crimson = FssTypes.Color.crimson |> textDecorationColorValue'
        static member cyan = FssTypes.Color.cyan |> textDecorationColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> textDecorationColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> textDecorationColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> textDecorationColorValue'
        static member darkGray = FssTypes.Color.darkGray |> textDecorationColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> textDecorationColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> textDecorationColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> textDecorationColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> textDecorationColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> textDecorationColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> textDecorationColorValue'
        static member darkRed = FssTypes.Color.darkRed |> textDecorationColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> textDecorationColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> textDecorationColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> textDecorationColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> textDecorationColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> textDecorationColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> textDecorationColorValue'
        static member deepPink = FssTypes.Color.deepPink |> textDecorationColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> textDecorationColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> textDecorationColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> textDecorationColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> textDecorationColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> textDecorationColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> textDecorationColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> textDecorationColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> textDecorationColorValue'
        static member gold = FssTypes.Color.gold |> textDecorationColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> textDecorationColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> textDecorationColorValue'
        static member grey = FssTypes.Color.grey |> textDecorationColorValue'
        static member honeydew = FssTypes.Color.honeydew |> textDecorationColorValue'
        static member hotPink = FssTypes.Color.hotPink |> textDecorationColorValue'
        static member indianRed = FssTypes.Color.indianRed |> textDecorationColorValue'
        static member indigo = FssTypes.Color.indigo |> textDecorationColorValue'
        static member ivory = FssTypes.Color.ivory |> textDecorationColorValue'
        static member khaki = FssTypes.Color.khaki |> textDecorationColorValue'
        static member lavender = FssTypes.Color.lavender |> textDecorationColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> textDecorationColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> textDecorationColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> textDecorationColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> textDecorationColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> textDecorationColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> textDecorationColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> textDecorationColorValue'
        static member lightGray = FssTypes.Color.lightGray |> textDecorationColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> textDecorationColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> textDecorationColorValue'
        static member lightPink = FssTypes.Color.lightPink |> textDecorationColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> textDecorationColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> textDecorationColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> textDecorationColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> textDecorationColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> textDecorationColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> textDecorationColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> textDecorationColorValue'
        static member linen = FssTypes.Color.linen |> textDecorationColorValue'
        static member magenta = FssTypes.Color.magenta |> textDecorationColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> textDecorationColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> textDecorationColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> textDecorationColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> textDecorationColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> textDecorationColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> textDecorationColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> textDecorationColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> textDecorationColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> textDecorationColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> textDecorationColorValue'
        static member mintCream = FssTypes.Color.mintCream |> textDecorationColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> textDecorationColorValue'
        static member moccasin = FssTypes.Color.moccasin |> textDecorationColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> textDecorationColorValue'
        static member oldLace = FssTypes.Color.oldLace |> textDecorationColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> textDecorationColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> textDecorationColorValue'
        static member orchid = FssTypes.Color.orchid |> textDecorationColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> textDecorationColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> textDecorationColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> textDecorationColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> textDecorationColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> textDecorationColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> textDecorationColorValue'
        static member peru = FssTypes.Color.peru |> textDecorationColorValue'
        static member pink = FssTypes.Color.pink |> textDecorationColorValue'
        static member plum = FssTypes.Color.plum |> textDecorationColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> textDecorationColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> textDecorationColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> textDecorationColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> textDecorationColorValue'
        static member salmon = FssTypes.Color.salmon |> textDecorationColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> textDecorationColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> textDecorationColorValue'
        static member seaShell = FssTypes.Color.seaShell |> textDecorationColorValue'
        static member sienna = FssTypes.Color.sienna |> textDecorationColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> textDecorationColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> textDecorationColorValue'
        static member slateGray = FssTypes.Color.slateGray |> textDecorationColorValue'
        static member snow = FssTypes.Color.snow |> textDecorationColorValue'
        static member springGreen = FssTypes.Color.springGreen |> textDecorationColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> textDecorationColorValue'
        static member tan = FssTypes.Color.tan |> textDecorationColorValue'
        static member thistle = FssTypes.Color.thistle |> textDecorationColorValue'
        static member tomato = FssTypes.Color.tomato |> textDecorationColorValue'
        static member turquoise = FssTypes.Color.turquoise |> textDecorationColorValue'
        static member violet = FssTypes.Color.violet |> textDecorationColorValue'
        static member wheat = FssTypes.Color.wheat |> textDecorationColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> textDecorationColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> textDecorationColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> textDecorationColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> textDecorationColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> textDecorationColorValue'
        static member Hex value = FssTypes.Color.Hex value |> textDecorationColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> textDecorationColorValue'
        static member Hsla h s l a = FssTypes.Color.Hsla (h, s, l, a) |> textDecorationColorValue'
        static member transparent = FssTypes.Color.transparent |> textDecorationColorValue'
        static member currentColor = FssTypes.Color.currentColor |> textDecorationColorValue'

        static member Inherit = FssTypes.Inherit |> textDecorationColorValue'
        static member Initial = FssTypes.Initial |> textDecorationColorValue'
        static member Unset = FssTypes.Unset |> textDecorationColorValue'

    /// <summary>Specifies color of text decoration.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorTypeFoo</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationColor' (color: FssTypes.ITextDecorationColor) = TextDecorationColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-color
    let private emphasisColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextEmphasisColor value
    let private emphasisColorValue' value =
        value
        |> textEmphasisColorToString
        |> emphasisColorValue
    type TextEmphasisColor =
        static member Value (color: FssTypes.ITextEmphasisColor) = color |> emphasisColorValue'
        static member black = FssTypes.Color.black |> emphasisColorValue'
        static member silver = FssTypes.Color.silver |> emphasisColorValue'
        static member gray = FssTypes.Color.gray |> emphasisColorValue'
        static member white = FssTypes.Color.white |> emphasisColorValue'
        static member maroon = FssTypes.Color.maroon |> emphasisColorValue'
        static member red = FssTypes.Color.red |> emphasisColorValue'
        static member purple = FssTypes.Color.purple |> emphasisColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> emphasisColorValue'
        static member green = FssTypes.Color.green |> emphasisColorValue'
        static member lime = FssTypes.Color.lime |> emphasisColorValue'
        static member olive = FssTypes.Color.olive |> emphasisColorValue'
        static member yellow = FssTypes.Color.yellow |> emphasisColorValue'
        static member navy = FssTypes.Color.navy |> emphasisColorValue'
        static member blue = FssTypes.Color.blue |> emphasisColorValue'
        static member teal = FssTypes.Color.teal |> emphasisColorValue'
        static member aqua = FssTypes.Color.aqua |> emphasisColorValue'
        static member orange = FssTypes.Color.orange |> emphasisColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> emphasisColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> emphasisColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> emphasisColorValue'
        static member azure = FssTypes.Color.azure |> emphasisColorValue'
        static member beige = FssTypes.Color.beige |> emphasisColorValue'
        static member bisque = FssTypes.Color.bisque |> emphasisColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> emphasisColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> emphasisColorValue'
        static member brown = FssTypes.Color.brown |> emphasisColorValue'
        static member burlywood = FssTypes.Color.burlywood |> emphasisColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> emphasisColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> emphasisColorValue'
        static member chocolate = FssTypes.Color.chocolate |> emphasisColorValue'
        static member coral = FssTypes.Color.coral |> emphasisColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> emphasisColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> emphasisColorValue'
        static member crimson = FssTypes.Color.crimson |> emphasisColorValue'
        static member cyan = FssTypes.Color.cyan |> emphasisColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> emphasisColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> emphasisColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> emphasisColorValue'
        static member darkGray = FssTypes.Color.darkGray |> emphasisColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> emphasisColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> emphasisColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> emphasisColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> emphasisColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> emphasisColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> emphasisColorValue'
        static member darkRed = FssTypes.Color.darkRed |> emphasisColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> emphasisColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> emphasisColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> emphasisColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> emphasisColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> emphasisColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> emphasisColorValue'
        static member deepPink = FssTypes.Color.deepPink |> emphasisColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> emphasisColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> emphasisColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> emphasisColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> emphasisColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> emphasisColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> emphasisColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> emphasisColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> emphasisColorValue'
        static member gold = FssTypes.Color.gold |> emphasisColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> emphasisColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> emphasisColorValue'
        static member grey = FssTypes.Color.grey |> emphasisColorValue'
        static member honeydew = FssTypes.Color.honeydew |> emphasisColorValue'
        static member hotPink = FssTypes.Color.hotPink |> emphasisColorValue'
        static member indianRed = FssTypes.Color.indianRed |> emphasisColorValue'
        static member indigo = FssTypes.Color.indigo |> emphasisColorValue'
        static member ivory = FssTypes.Color.ivory |> emphasisColorValue'
        static member khaki = FssTypes.Color.khaki |> emphasisColorValue'
        static member lavender = FssTypes.Color.lavender |> emphasisColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> emphasisColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> emphasisColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> emphasisColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> emphasisColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> emphasisColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> emphasisColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> emphasisColorValue'
        static member lightGray = FssTypes.Color.lightGray |> emphasisColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> emphasisColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> emphasisColorValue'
        static member lightPink = FssTypes.Color.lightPink |> emphasisColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> emphasisColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> emphasisColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> emphasisColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> emphasisColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> emphasisColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> emphasisColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> emphasisColorValue'
        static member linen = FssTypes.Color.linen |> emphasisColorValue'
        static member magenta = FssTypes.Color.magenta |> emphasisColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> emphasisColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> emphasisColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> emphasisColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> emphasisColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> emphasisColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> emphasisColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> emphasisColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> emphasisColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> emphasisColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> emphasisColorValue'
        static member mintCream = FssTypes.Color.mintCream |> emphasisColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> emphasisColorValue'
        static member moccasin = FssTypes.Color.moccasin |> emphasisColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> emphasisColorValue'
        static member oldLace = FssTypes.Color.oldLace |> emphasisColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> emphasisColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> emphasisColorValue'
        static member orchid = FssTypes.Color.orchid |> emphasisColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> emphasisColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> emphasisColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> emphasisColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> emphasisColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> emphasisColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> emphasisColorValue'
        static member peru = FssTypes.Color.peru |> emphasisColorValue'
        static member pink = FssTypes.Color.pink |> emphasisColorValue'
        static member plum = FssTypes.Color.plum |> emphasisColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> emphasisColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> emphasisColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> emphasisColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> emphasisColorValue'
        static member salmon = FssTypes.Color.salmon |> emphasisColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> emphasisColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> emphasisColorValue'
        static member seaShell = FssTypes.Color.seaShell |> emphasisColorValue'
        static member sienna = FssTypes.Color.sienna |> emphasisColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> emphasisColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> emphasisColorValue'
        static member slateGray = FssTypes.Color.slateGray |> emphasisColorValue'
        static member snow = FssTypes.Color.snow |> emphasisColorValue'
        static member springGreen = FssTypes.Color.springGreen |> emphasisColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> emphasisColorValue'
        static member tan = FssTypes.Color.tan |> emphasisColorValue'
        static member thistle = FssTypes.Color.thistle |> emphasisColorValue'
        static member tomato = FssTypes.Color.tomato |> emphasisColorValue'
        static member turquoise = FssTypes.Color.turquoise |> emphasisColorValue'
        static member violet = FssTypes.Color.violet |> emphasisColorValue'
        static member wheat = FssTypes.Color.wheat |> emphasisColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> emphasisColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> emphasisColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> emphasisColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> emphasisColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> emphasisColorValue'
        static member Hex value = FssTypes.Color.Hex value |> emphasisColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> emphasisColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> emphasisColorValue'
        static member transparent = FssTypes.Color.transparent |> emphasisColorValue'
        static member currentColor = FssTypes.Color.currentColor |> emphasisColorValue'

        static member Inherit = FssTypes.Inherit |> emphasisColorValue'
        static member Initial = FssTypes.Initial |> emphasisColorValue'
        static member Unset = FssTypes.Unset |> emphasisColorValue'

    /// <summary>Specifies color of text emphasis.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorTypeFoo</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisColor' (color: FssTypes.ITextEmphasisColor) = TextEmphasisColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-size-adjust
    let private textSizeAdjustValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextSizeAdjust value
    let private textSizeAdjustValue' value = value |> textSizeAdjustToString |> textSizeAdjustValue

    type TextSizeAdjust =
        static member Value (textSize: FssTypes.ITextSizeAdjust) = textSize |> textSizeAdjustValue'
        static member Auto = FssTypes.Auto |> textSizeAdjustValue'
        static member None = FssTypes.None' |> textSizeAdjustValue'
        static member Inherit = FssTypes.Inherit |> textSizeAdjustValue'
        static member Initial = FssTypes.Initial |> textSizeAdjustValue'
        static member Unset = FssTypes.Unset |> textSizeAdjustValue'

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
    let TextSizeAdjust' textSize = TextSizeAdjust.Value textSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/tab-size
    let private tabSizeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TabSize value
    let private tabSizeValue' value = value |> tabSizeToString |> tabSizeValue

    type TabSize =
        static member Value (tabSize: FssTypes.ITabSize) = tabSize |> tabSizeValue'
        static member Inherit = FssTypes.Inherit |> tabSizeValue'
        static member Initial = FssTypes.Initial |> tabSizeValue'
        static member Unset = FssTypes.Unset |> tabSizeValue'

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
    let TabSize' tabSize = TabSize.Value tabSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-orientation
    let private textOrientationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextOrientation value
    let private textOrientationValue' value = value |> textOrientationToString |> textOrientationValue

    type TextOrientation =
        static member Value (orientation: FssTypes.ITextOrientation) = orientation |> textOrientationValue'
        static member Mixed = FssTypes.Text.Mixed |> textOrientationValue'
        static member Upright = FssTypes.Text.Upright |> textOrientationValue'
        static member SidewaysRight = FssTypes.Text.SidewaysRight |> textOrientationValue'
        static member Sideways = FssTypes.Text.Sideways |> textOrientationValue'
        static member UseGlyphOrientation = FssTypes.Text.UseGlyphOrientation |> textOrientationValue'
        static member Inherit = FssTypes.Inherit |> textOrientationValue'
        static member Initial = FssTypes.Initial |> textOrientationValue'
        static member Unset = FssTypes.Unset |> textOrientationValue'

    /// <summary>Sets the orientation of the text characters.</summary>
    /// <param name="orientation">
    ///     can be:
    ///     - <c> TextOrientation </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOrientation' orientation = TextOrientation.Value orientation

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
    let private textRenderingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextRendering value
    let private textRenderingValue' value = value |> textRenderingToString |> textRenderingValue

    type TextRendering =
        static member Value (rendering: FssTypes.ITextRendering) = rendering |> textRenderingValue'
        static member OptimizeSpeed = FssTypes.Text.OptimizeSpeed |> textRenderingValue'
        static member OptimizeLegibility = FssTypes.Text.OptimizeLegibility |> textRenderingValue'
        static member GeometricPrecision = FssTypes.Text.GeometricPrecision |> textRenderingValue'
        static member Auto = FssTypes.Auto |> textRenderingValue'
        static member Inherit = FssTypes.Inherit |> textRenderingValue'
        static member Initial = FssTypes.Initial |> textRenderingValue'
        static member Unset = FssTypes.Unset |> textRenderingValue'

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
    let TextRendering' rendering = TextRendering.Value rendering

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
    let private textJustifyValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextJustify value
    let private textJustifyValue' value = value |> textJustifyToString |> textJustifyValue

    type TextJustify =
        static member Value (justification: FssTypes.ITextJustify) = justification |> textJustifyValue'
        static member InterWord = FssTypes.Text.InterWord |> textJustifyValue'
        static member InterCharacter = FssTypes.Text.InterCharacter |> textJustifyValue'
        static member Auto = FssTypes.Auto |> textJustifyValue'
        static member None = FssTypes.None' |> textJustifyValue'

    /// <summary>Specifies how to justify text.</summary>
    /// <param name="justification">
    ///     can be:
    ///     - <c> TextJustify </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextJustify' justification = TextJustify.Value justification

    // https://developer.mozilla.org/en-US/docs/Web/CSS/white-space
    let private whiteSpaceValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.WhiteSpace value
    let private whiteSpaceValue' value = value |> whitespaceToString |> whiteSpaceValue

    type WhiteSpace =
        static member Value (whitespace: FssTypes.IWhiteSpace) = whitespace |> whiteSpaceValue'
        static member NoWrap = FssTypes.Text.WhiteSpace.NoWrap |> whiteSpaceValue'
        static member Pre = FssTypes.Text.Pre |> whiteSpaceValue'
        static member PreWrap = FssTypes.Text.PreWrap |> whiteSpaceValue'
        static member PreLine = FssTypes.Text.PreLine |> whiteSpaceValue'
        static member BreakSpaces = FssTypes.Text.BreakSpaces |> whiteSpaceValue'
        static member Normal = FssTypes.Normal |> whiteSpaceValue'
        static member Inherit = FssTypes.Inherit |> whiteSpaceValue'
        static member Initial = FssTypes.Initial |> whiteSpaceValue'
        static member Unset = FssTypes.Unset |> whiteSpaceValue'

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
    let WhiteSpace' whitespace = WhiteSpace.Value whitespace

    // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
    let private userSelectValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.UserSelect value
    let private userSelectValue' value = value |> userSelectToString |> userSelectValue

    type UserSelect =
        static member Value (whitespace: FssTypes.IUserSelect) = whitespace |> userSelectValue'
        static member Text = FssTypes.Text.UserSelect.Text |> userSelectValue'
        static member Contain = FssTypes.Text.UserSelect.Contain |> userSelectValue'
        static member All = FssTypes.Text.UserSelect.All |> userSelectValue'
        static member None = FssTypes.None' |> userSelectValue'
        static member Auto = FssTypes.Auto |> userSelectValue'
        static member Inherit = FssTypes.Inherit |> userSelectValue'
        static member Initial = FssTypes.Initial |> userSelectValue'
        static member Unset = FssTypes.Unset |> userSelectValue'

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
    let UserSelect' userSelect = UserSelect.Value userSelect