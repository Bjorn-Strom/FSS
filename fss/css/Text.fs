namespace Fss

[<AutoOpen>]
module Text =
    let private textAlignToString (alignment: Types.ITextAlign) =
        match alignment with
        | :? Types.TextAlign as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown text alignment"

    let private textAlignLastToString (alignment: Types.ITextAlignLast) =
        match alignment with
        | :? Types.TextAlignLast as t -> Utilities.Helpers.duToLowercase t
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown text alignment last"

    let private decorationLineToString (decorationLine: Types.ITextDecorationLine) =
        match decorationLine with
        | :? Types.TextDecorationLine as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown text decoration line"

    let private thicknessToString (thickness: Types.ITextDecorationThickness) =
        match thickness with
        | :? Types.TextDecorationThickness -> "from-font"
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown text decoration thickness"

    let private decorationToString (decoration: Types.ITextDecoration) =
        match decoration with
        | :? Types.None' -> Types.none
        | _ -> "Unknown text decoration"

    let private decorationStyleToString (style: Types.ITextDecorationStyle) =
        match style with
        | :? Types.TextDecorationStyle as t -> Utilities.Helpers.duToLowercase t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown text decoration style"

    let private decorationSkipToString (skip: Types.ITextDecorationSkip) =
        match skip with
        | :? Types.DecorationSkip as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown text decoration skip"

    let private decorationSkipInkToString (skipInk: Types.ITextDecorationSkipInk) =
        match skipInk with
        | :? Types.TextDecorationSkipInk -> "all"
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown text decoration skip ink"

    let private textTransformToString (transform: Types.ITextTransform) =
        match transform with
        | :? Types.TextTransform as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown text transform"

    let private indentToString (indent: Types.ITextIndent) =
        match indent with
        | :? Types.TextIndent as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown text indent"

    let private textShadowToString =
        function
            | Types.XY (x,y) -> sprintf "%s %s" (Types.sizeToString x) (Types.sizeToString y)
            | Types.ColorXY (c,x,y) -> sprintf "%s %s %s" (Types.colorToString c) (Types.sizeToString x) (Types.sizeToString y)
            | Types.ColorXYBlur (c,x,y,b) ->
                sprintf "%s %s %s %s"
                    (Types.colorToString c)
                    (Types.sizeToString x)
                    (Types.sizeToString y)
                    (Types.sizeToString b)

    let private emphasisToString (emphasis: Types.ITextEmphasis) =
        match emphasis with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "unknown text emphasis"

    let private emphasisPositionToString (emphasisPosition: Types.ITextEmphasisPosition) =
        match emphasisPosition with
        | :? Types.EmphasisPosition as e -> Utilities.Helpers.duToLowercase e
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown text emphasis position"

    let private textOverflowToString (overflow: Types.ITextOverflow) =
        match overflow with
        | :? Types.TextOverflow as t -> Utilities.Helpers.duToLowercase t
        | :? Types.String as s -> Types.StringToString s |> sprintf "\"%s\""
        | _ -> "Unknown text overflow"

    let private emphasisStyleToString (emphasisStyle: Types.ITextEmphasisStyle) =
        let stringifyStyle (style: Types.TextEmphasisStyle) =
            match style with
                | FilledSesame -> "filled sesame"
                | OpenSesame -> "open sesame"
                | _ -> Utilities.Helpers.duToKebab style

        match emphasisStyle with
        | :? Types.TextEmphasisStyle as t -> stringifyStyle t
        | :? Types.String as s -> Types.StringToString s |> sprintf "'%s'"
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "unknown text emphasis style"

    let private underlinePositionToString (underlinePosition: Types.ITextUnderlinePosition) =
        match underlinePosition with
        | :? Types.UnderlinePosition as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | _ -> "unknown text underline position"

    let private textEmphasisColorToString (color: Types.ITextEmphasisColor) =
        match color with
            | :? Types.Color as c -> Types.colorToString c
            | :? Types.Keywords as k -> Types.keywordsToString k
            | _ -> "unknown text emphasis color"

    let private underlineOffsetToString (underlineOffset: Types.ITextUnderlineOffset) =
        match underlineOffset with
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "unknown text underline offset"

    let private quoteToString (quote: Types.IQuotes) =
        match quote with
        | :? Types.String as s -> Types.StringToString s
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown quotes"

    let private hyphensToString (hyphens: Types.IHyphens) =
        match hyphens with
        | :? Types.Hyphens -> "manual"
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown hyphens"

    let private textDecorationColorToString (color: Types.ITextDecorationColor) =
        match color with
            | :? Types.Color as c -> Types.colorToString c
            | :? Types.Keywords as k -> Types.keywordsToString k
            | _ -> "unknown text decoration color"

    let private textSizeAdjustToString (size: Types.ITextSizeAdjust) =
        match size with
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown text size adjust"

    let private tabSizeToString (tabSize: Types.ITabSize) =
        match tabSize with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Int as i -> Types.IntToString i
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown tab size"

    let private textOrientationToString (textOrientation: Types.ITextOrientation) =
        match textOrientation with
        | :? Types.TextOrientation as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown text orientation"

    let private textRenderingToString (textRendering: Types.ITextRendering) =
        match textRendering with
        | :? Types.TextRendering as t -> Utilities.Helpers.duToKebab t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown text rendering"

    let private textJustifyToString (textJustify: Types.ITextJustify) =
        match textJustify with
        | :? Types.TextJustify as j -> Utilities.Helpers.duToKebab j
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown text justification"

    let private whitespaceToString (whitespace: Types.IWhiteSpace) =
        match whitespace with
        | :? Types.WhiteSpace as ws -> Utilities.Helpers.duToKebab ws
        | :? Types.Normal -> Types.normal
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown whitespace"

    let private userSelectToString (userSelect: Types.IUserSelect) =
        match userSelect with
        | :? Types.UserSelect as u -> Utilities.Helpers.duToLowercase u
        | :? Types.None' -> Types.none
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown user select"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    let private alignCssValue value = Types.cssValue Types.Property.TextAlign value
    let private alignCssValue' value =
        value
        |> textAlignToString
        |> alignCssValue
    type TextAlign =
        static member Value (textAlign: Types.ITextAlign) = textAlign |> alignCssValue'
        static member Left = Types.TextAlign.Left |> alignCssValue'
        static member Right = Types.TextAlign.Right |> alignCssValue'
        static member Center = Types.TextAlign.Center |> alignCssValue'
        static member Justify = Types.TextAlign.Justify |> alignCssValue'
        static member JustifyAll = Types.JustifyAll |> alignCssValue'
        static member Start = Types.TextAlign.Start |> alignCssValue'
        static member End = Types.TextAlign.End |> alignCssValue'
        static member MatchParent = Types.MatchParent |> alignCssValue'

        static member Inherit = Types.Inherit |> alignCssValue'
        static member Initial = Types.Initial |> alignCssValue'
        static member Unset = Types.Unset |> alignCssValue'

    /// <summary>Specifies the horizontal alignment of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlign' (align: Types.ITextAlign) = TextAlign.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
    let private alignLastCssValue value = Types.cssValue Types.Property.TextAlignLast value
    let private alignLastCssValue' value =
        value
        |> textAlignLastToString
        |> alignLastCssValue
    type TextAlignLast =
        static member Value (textAlign: Types.ITextAlignLast) = textAlign |> alignLastCssValue'
        static member Left = Types.TextAlignLast.Left |> alignLastCssValue'
        static member Right = Types.TextAlignLast.Right |> alignLastCssValue'
        static member Center = Types.TextAlignLast.Center |> alignLastCssValue'
        static member Justify = Types.TextAlignLast.Justify |> alignLastCssValue'
        static member Start = Types.TextAlignLast.Start |> alignLastCssValue'
        static member End = Types.TextAlignLast.End |> alignLastCssValue'

        static member Inherit = Types.Inherit |> alignLastCssValue'
        static member Initial = Types.Initial |> alignLastCssValue'
        static member Unset = Types.Unset |> alignLastCssValue'

    /// <summary>Specifies the horizontal alignment of the last line of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlignLast' (align: Types.ITextAlignLast) = TextAlignLast.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
    let private decorationValue value = Types.cssValue Types.Property.TextDecoration value
    let private decorationValue' value =
        value
        |> decorationToString
        |> decorationValue
    type TextDecoration =
        static member Value (value: Types.ITextDecoration) = value |> decorationValue'
        static member None = Types.None' |> decorationValue'

    /// <summary>Resets text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecoration' (decoration: Types.ITextDecoration) = TextDecoration.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    let private lineCssValue value = Types.cssValue Types.Property.TextDecorationLine value
    let private lineCssValue' value =
        value
        |> decorationLineToString
        |> lineCssValue
    type TextDecorationLine =
        static member Value (value: Types.ITextDecorationLine) = value |> lineCssValue'
        static member Value (v1: Types.ITextDecorationLine, v2: Types.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s" (decorationLineToString v1) (decorationLineToString v2)
        static member Value (v1: Types.ITextDecorationLine, v2: Types.ITextDecorationLine, v3: Types.ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s %s" (decorationLineToString v1) (decorationLineToString v2) (decorationLineToString v3)
        static member Underline = Types.Underline |> lineCssValue'
        static member Overline = Types.Overline |> lineCssValue'
        static member LineThrough = Types.LineThrough |> lineCssValue'
        static member Blink = Types.Blink |> lineCssValue'

        static member Inherit = Types.Inherit |> lineCssValue'
        static member Initial = Types.Initial |> lineCssValue'
        static member Unset = Types.Unset |> lineCssValue'
        static member None = Types.None' |> lineCssValue'

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
    let TextDecorationLine' (decoration: Types.ITextDecorationLine) = TextDecorationLine.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    let private thicknessValue value = Types.cssValue Types.Property.TextDecorationThickness value
    let private thicknessValue' value =
        value
        |> thicknessToString
        |> thicknessValue
    type TextDecorationThickness =
        static member Value (thickness: Types.ITextDecorationThickness) = thickness |> thicknessValue'
        static member FromFont = Types.TextDecorationThickness |> thicknessValue'

        static member Auto = Types.Auto |> thicknessValue'
        static member Inherit = Types.Inherit |> thicknessValue'
        static member Initial = Types.Initial |> thicknessValue'
        static member Unset = Types.Unset |> thicknessValue'

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
    let TextDecorationThickness' (thickness: Types.ITextDecorationThickness) = TextDecorationThickness.Value(thickness)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    let private decorationStyleValue value = Types.cssValue Types.Property.TextDecorationStyle value
    let private decorationStyleValue' value =
        value
        |> decorationStyleToString
        |> decorationStyleValue
    type TextDecorationStyle =
        static member Value(style: Types.ITextDecorationStyle) = style |> decorationStyleValue'
        static member Solid = Types.TextDecorationStyle.Solid |> decorationStyleValue'
        static member Double = Types.TextDecorationStyle.Double |> decorationStyleValue'
        static member Dotted = Types.TextDecorationStyle.Dotted |> decorationStyleValue'
        static member Dashed = Types.TextDecorationStyle.Dashed |> decorationStyleValue'
        static member Wavy = Types.Wavy |> decorationStyleValue'

        static member Inherit = Types.Inherit |> decorationStyleValue'
        static member Initial = Types.Initial |> decorationStyleValue'
        static member Unset = Types.Unset |> decorationStyleValue'

    /// <summary>Specifies style of text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationStyle' (decoration: Types.ITextDecorationStyle) = TextDecorationStyle.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    let private skipValue value = Types.cssValue Types.Property.TextDecorationSkip value
    let private skipValue' value =
        value
        |> decorationSkipToString
        |> skipValue

    type TextDecorationSkip =
        static member Value (value: Types.ITextDecorationSkip) = value |> skipValue'
        static member Value (v1: Types.ITextDecorationSkip, v2: Types.ITextDecorationSkip) =
            sprintf "%s %s" (decorationSkipToString v1) (decorationSkipToString v2) |> skipValue
        static member Value (v1: Types.ITextDecorationSkip, v2: Types.ITextDecorationSkip, v3: Types.ITextDecorationSkip) =
            sprintf "%s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) |> skipValue
        static member Value (v1: Types.ITextDecorationSkip, v2: Types.ITextDecorationSkip, v3: Types.ITextDecorationSkip, v4: Types.ITextDecorationSkip) =
            sprintf "%s %s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) (decorationSkipToString v4) |> skipValue

        static member Objects = Types.Objects |> skipValue'
        static member Spaces = Types.Spaces |> skipValue'
        static member LeadingSpaces = Types.LeadingSpaces |> skipValue'
        static member TrailingSpaces = Types.TrailingSpaces |> skipValue'
        static member Edges = Types.Edges |> skipValue'
        static member BoxDecoration = Types.BoxDecoration |> skipValue'

        static member Inherit = Types.Inherit |> skipValue'
        static member Initial = Types.Initial |> skipValue'
        static member Unset = Types.Unset |> skipValue'
        static member None = Types.None' |> skipValue'

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
    let TextDecorationSkip' (skip: Types.ITextDecorationSkip) = TextDecorationSkip.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    let private skipInkValue value = Types.cssValue Types.Property.TextDecorationSkipInk value
    let private skipInkValue' value =
        value
        |> decorationSkipInkToString
        |> skipInkValue
    type TextDecorationSkipInk =
        static member Value(skipInk: Types.ITextDecorationSkipInk) = skipInk |> skipInkValue'
        static member All = Types.TextDecorationSkipInk |> skipInkValue'

        static member Inherit = Types.Inherit |> skipInkValue'
        static member Initial = Types.Initial |> skipInkValue'
        static member Unset = Types.Unset |> skipInkValue'
        static member None = Types.None' |> skipInkValue'
        static member Auto = Types.Auto |> skipInkValue'

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
    let TextDecorationSkipInk' (skip: Types.ITextDecorationSkipInk) = TextDecorationSkipInk.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    let private transformValue value = Types.cssValue Types.Property.TextTransform value
    let private transformValue' value =
        value
        |> textTransformToString
        |> transformValue
    type TextTransform =
        static member Value (transform: Types.ITextTransform) = transform |> transformValue'
        static member Capitalize = Types.Capitalize |> transformValue'
        static member Uppercase = Types.Uppercase |> transformValue'
        static member Lowercase = Types.Lowercase |> transformValue'
        static member FullWidth = Types.FullWidth |> transformValue'
        static member FullSizeKana = Types.FullSizeKana |> transformValue'

        static member Inherit = Types.Inherit |> transformValue'
        static member Initial = Types.Initial |> transformValue'
        static member Unset = Types.Unset |> transformValue'
        static member None = Types.None' |> transformValue'

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
    let TextTransform' (transform: Types.ITextTransform) = TextTransform.Value(transform)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    let private indentCssValue value = Types.cssValue Types.Property.TextIndent value
    let private indentCssValue' value =
        value
        |> indentToString
        |> indentCssValue
    type TextIndent =
        static member Value (indent: Types.ITextIndent) = indent |> indentCssValue'
        static member Value (i1: Types.ITextIndent, i2: Types.ITextIndent) = sprintf "%s %s" (indentToString i1) (indentToString i2) |> indentCssValue
        static member Value (i1: Types.ITextIndent, i2: Types.ITextIndent, i3: Types.ITextIndent) =
            sprintf "%s %s %s" (indentToString i1) (indentToString i2) (indentToString i3) |> indentCssValue

        static member Hanging = Types.Hanging |> indentCssValue'
        static member EachLine = Types.EachLine |> indentCssValue'

        static member Inherit = Types.Inherit |> indentCssValue'
        static member Initial = Types.Initial |> indentCssValue'
        static member Unset = Types.Unset |> indentCssValue'

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
    let TextIndent' (indent: Types.ITextIndent) = TextIndent.Value(indent)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    let private shadowValue value = Types.cssValue Types.Property.TextShadow value

    type TextShadow =
        static member XY (xOffset: Types.Size, yOffset: Types.Size) =
            Types.XY(xOffset,yOffset)
        static member ColorXY (color: Types.Color, xOffset: Types.Size, yOffset: Types.Size) =
            Types.ColorXY(color, xOffset, yOffset)
        static member ColorXYBlur (xOffset: Types.Size, yOffset: Types.Size, blurRadius: Types.Size, color: Types.Color) =
            Types.ColorXYBlur (color, xOffset, yOffset, blurRadius)

    /// Supply a list of text shadows to apply to the text
    let TextShadows (shadows: Types.TextShadow list) =
        shadows
        |> Utilities.Helpers.combineComma textShadowToString
        |> shadowValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
    let private overflowValue value = Types.cssValue Types.Property.TextOverflow value
    let private overflowValue' value =
        value
        |> textOverflowToString
        |> overflowValue
    type TextOverflow =
        static member Value (overflow: Types.ITextOverflow) = overflow |> overflowValue'

        static member Clip = Types.TextOverflow.Clip |> overflowValue'
        static member Ellipsis = Types.Ellipsis |> overflowValue'

    /// <summary>If there is hidden content this specifies how that is signalled.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> TextOverflow </c>
    ///     - <c> CssString </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOverflow' (overflow: Types.ITextOverflow) = TextOverflow.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    let private emphasisValue value = Types.cssValue Types.Property.TextEmphasis value
    let private emphasisValue' value =
        value
        |> emphasisToString
        |> emphasisValue

    type TextEmphasis =
        static member Value (emphasis: Types.ITextEmphasis) = emphasis |> emphasisValue'

        static member None = Types.None' |> emphasisValue'
        static member Inherit = Types.Inherit |> emphasisValue'
        static member Initial = Types.Initial |> emphasisValue'
        static member Unset = Types.Unset |> emphasisValue'

    /// <summary>Specifies emphasis marks to text.</summary>
    /// <param name="emphasis">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasis' (emphasis: Types.ITextEmphasis) = TextEmphasis.Value emphasis

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    let private emphasisPositionValue value = Types.cssValue Types.Property.TextEmphasisPosition value
    let private emphasisPositionValue' value =
        value
        |> emphasisPositionToString
        |> emphasisPositionValue

    type TextEmphasisPosition =
        static member Value (v1: Types.ITextEmphasisPosition, v2: Types.ITextEmphasisPosition) =
            sprintf "%s %s" (emphasisPositionToString v1) (emphasisPositionToString v2)
            |> emphasisPositionValue

        static member Inherit = Types.Inherit |> emphasisPositionValue'
        static member Initial = Types.Initial |> emphasisPositionValue'
        static member Unset = Types.Unset |> emphasisPositionValue'

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
    let TextEmphasisPosition' (e1: Types.ITextEmphasisPosition) (e2: Types.ITextEmphasisPosition) = TextEmphasisPosition.Value(e1, e2)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    let private emphasisStyleValue value = Types.cssValue Types.Property.TextEmphasisStyle value
    let private emphasisStyleValue' value =
        value
        |> emphasisStyleToString
        |> emphasisStyleValue
    type TextEmphasisStyle =
        static member Value (emphasisStyle: Types.ITextEmphasisStyle) = emphasisStyle |> emphasisStyleValue'
        static member Filled = Types.Filled |> emphasisStyleValue'
        static member Open = Types.Open |> emphasisStyleValue'
        static member Dot = Types.Dot |> emphasisStyleValue'
        static member Circle = Types.TextEmphasisStyle.Circle |> emphasisStyleValue'
        static member DoubleCircle = Types.DoubleCircle |> emphasisStyleValue'
        static member Triangle = Types.Triangle |> emphasisStyleValue'
        static member FilledSesame = Types.FilledSesame |> emphasisStyleValue'
        static member OpenSesame = Types.OpenSesame |> emphasisStyleValue'

        static member None = Types.None' |> emphasisStyleValue'
        static member Inherit = Types.Inherit |> emphasisStyleValue'
        static member Initial = Types.Initial |> emphasisStyleValue'
        static member Unset = Types.Unset |> emphasisStyleValue'

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
    let TextEmphasisStyle' (style: Types.ITextEmphasisStyle) = TextEmphasisStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    let private underlinePositionCssValue value = Types.cssValue Types.Property.TextUnderlinePosition value
    let private underlinePositionCssValue' value =
        value
        |> underlinePositionToString
        |> underlinePositionCssValue

    type TextUnderlinePosition =
        static member Value (underlinePosition: Types.ITextUnderlinePosition) =
            underlinePosition |> underlinePositionCssValue'
        static member Value (v1: Types.ITextUnderlinePosition, v2: Types.ITextUnderlinePosition) =
            sprintf "%s %s" (underlinePositionToString v1) (underlinePositionToString v2) |> underlinePositionCssValue

        static member FromFont = Types.UnderlinePosition.FromFont |> underlinePositionCssValue'
        static member Under = Types.UnderlinePosition.Under |> underlinePositionCssValue'
        static member Left = Types.UnderlinePosition.Left |> underlinePositionCssValue'
        static member Right = Types.UnderlinePosition.Right |> underlinePositionCssValue'
        static member AutoPos = Types.UnderlinePosition.AutoPos  |> underlinePositionCssValue'
        static member Above = Types.UnderlinePosition.Above |> underlinePositionCssValue'
        static member Below = Types.UnderlinePosition.Below |> underlinePositionCssValue'

        static member Auto = Types.Auto |> underlinePositionCssValue'
        static member Inherit = Types.Inherit |> underlinePositionCssValue'
        static member Initial = Types.Initial |> underlinePositionCssValue'
        static member Unset = Types.Unset |> underlinePositionCssValue'

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
    let TextUnderlinePosition' (position: Types.ITextUnderlinePosition) = TextUnderlinePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
    let private offsetValue value = Types.cssValue Types.Property.TextUnderlineOffset value
    let private offsetValue' value =
        value
        |> underlineOffsetToString
        |> offsetValue
    type TextUnderlineOffset =
        static member Value (underlineOffset: Types.ITextUnderlineOffset) = underlineOffset |> offsetValue'
        static member Inherit = Types.Inherit |> offsetValue'
        static member Initial = Types.Initial |> offsetValue'
        static member Unset = Types.Unset |> offsetValue'
        static member Auto = Types.Auto |> offsetValue'

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
    let TextUnderlineOffset' (offset: Types.ITextUnderlineOffset) = TextUnderlineOffset.Value(offset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/quotes
    let private quoteValue value = Types.cssValue Types.Property.Quotes value
    let private quoteValue' value =
        value
        |> quoteToString
        |> quoteValue
    type Quotes =
        static member Value (quote: Types.IQuotes) =
            quote
            |> quoteValue'
        static member Value (openQuote: Types.IQuotes, closeQuote: Types.IQuotes) =
            quoteValue
            <| sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote)
        static member Value (openCloseQuotes: ((Types.IQuotes * Types.IQuotes) list)) =
            openCloseQuotes
            |> List.map (fun (openQuote, closeQuote) ->
                sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote))
            |> String.concat " "
            |> quoteValue

        static member None = Types.None' |> quoteValue'
        static member Auto = Types.Auto |> quoteValue'
        static member Inherit = Types.Inherit |> quoteValue'
        static member Initial = Types.Initial |> quoteValue'
        static member Unset = Types.Unset |> quoteValue'

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
    let Quotes' (quotes: Types.IQuotes) = Quotes.Value(quotes)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/hyphens
    let private hyphensValue value = Types.cssValue Types.Property.Hyphens value
    let private hyphensValue' value =
        value
        |> hyphensToString
        |> hyphensValue
    type Hyphens =
        static member Value (hyphens: Types.IHyphens) = hyphens |> hyphensValue'
        static member Manual = Types.Manual |> hyphensValue'
        static member Auto = Types.Auto |> hyphensValue'
        static member None = Types.None' |> hyphensValue'
        static member Inherit = Types.Inherit |> hyphensValue'
        static member Initial = Types.Initial |> hyphensValue'
        static member Unset = Types.Unset |> hyphensValue'

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
    let Hyphens' (hyphens: Types.IHyphens) = Hyphens.Value(hyphens)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-color
    let private textDecorationColorValue value = Types.cssValue Types.Property.TextDecorationColor value
    let private textDecorationColorValue' value =
        value
        |> textDecorationColorToString
        |> textDecorationColorValue
    type TextDecorationColor =
        static member Value (color: Types.ITextDecorationColor) = color |> textDecorationColorValue'

        static member black = Types.Color.black |> textDecorationColorValue'
        static member silver = Types.Color.silver |> textDecorationColorValue'
        static member gray = Types.Color.gray |> textDecorationColorValue'
        static member white = Types.Color.white |> textDecorationColorValue'
        static member maroon = Types.Color.maroon |> textDecorationColorValue'
        static member red = Types.Color.red |> textDecorationColorValue'
        static member purple = Types.Color.purple |> textDecorationColorValue'
        static member fuchsia = Types.Color.fuchsia |> textDecorationColorValue'
        static member green = Types.Color.green |> textDecorationColorValue'
        static member lime = Types.Color.lime |> textDecorationColorValue'
        static member olive = Types.Color.olive |> textDecorationColorValue'
        static member yellow = Types.Color.yellow |> textDecorationColorValue'
        static member navy = Types.Color.navy |> textDecorationColorValue'
        static member blue = Types.Color.blue |> textDecorationColorValue'
        static member teal = Types.Color.teal |> textDecorationColorValue'
        static member aqua = Types.Color.aqua |> textDecorationColorValue'
        static member orange = Types.Color.orange |> textDecorationColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> textDecorationColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> textDecorationColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> textDecorationColorValue'
        static member azure = Types.Color.azure |> textDecorationColorValue'
        static member beige = Types.Color.beige |> textDecorationColorValue'
        static member bisque = Types.Color.bisque |> textDecorationColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> textDecorationColorValue'
        static member blueViolet = Types.Color.blueViolet |> textDecorationColorValue'
        static member brown = Types.Color.brown |> textDecorationColorValue'
        static member burlywood = Types.Color.burlywood |> textDecorationColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> textDecorationColorValue'
        static member chartreuse = Types.Color.chartreuse |> textDecorationColorValue'
        static member chocolate = Types.Color.chocolate |> textDecorationColorValue'
        static member coral = Types.Color.coral |> textDecorationColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> textDecorationColorValue'
        static member cornsilk = Types.Color.cornsilk |> textDecorationColorValue'
        static member crimson = Types.Color.crimson |> textDecorationColorValue'
        static member cyan = Types.Color.cyan |> textDecorationColorValue'
        static member darkBlue = Types.Color.darkBlue |> textDecorationColorValue'
        static member darkCyan = Types.Color.darkCyan |> textDecorationColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> textDecorationColorValue'
        static member darkGray = Types.Color.darkGray |> textDecorationColorValue'
        static member darkGreen = Types.Color.darkGreen |> textDecorationColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> textDecorationColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> textDecorationColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> textDecorationColorValue'
        static member darkOrange = Types.Color.darkOrange |> textDecorationColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> textDecorationColorValue'
        static member darkRed = Types.Color.darkRed |> textDecorationColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> textDecorationColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> textDecorationColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> textDecorationColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> textDecorationColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> textDecorationColorValue'
        static member darkViolet = Types.Color.darkViolet |> textDecorationColorValue'
        static member deepPink = Types.Color.deepPink |> textDecorationColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> textDecorationColorValue'
        static member dimGrey = Types.Color.dimGrey |> textDecorationColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> textDecorationColorValue'
        static member fireBrick = Types.Color.fireBrick |> textDecorationColorValue'
        static member floralWhite = Types.Color.floralWhite |> textDecorationColorValue'
        static member forestGreen = Types.Color.forestGreen |> textDecorationColorValue'
        static member gainsboro = Types.Color.gainsboro |> textDecorationColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> textDecorationColorValue'
        static member gold = Types.Color.gold |> textDecorationColorValue'
        static member goldenrod = Types.Color.goldenrod |> textDecorationColorValue'
        static member greenYellow = Types.Color.greenYellow |> textDecorationColorValue'
        static member grey = Types.Color.grey |> textDecorationColorValue'
        static member honeydew = Types.Color.honeydew |> textDecorationColorValue'
        static member hotPink = Types.Color.hotPink |> textDecorationColorValue'
        static member indianRed = Types.Color.indianRed |> textDecorationColorValue'
        static member indigo = Types.Color.indigo |> textDecorationColorValue'
        static member ivory = Types.Color.ivory |> textDecorationColorValue'
        static member khaki = Types.Color.khaki |> textDecorationColorValue'
        static member lavender = Types.Color.lavender |> textDecorationColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> textDecorationColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> textDecorationColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> textDecorationColorValue'
        static member lightBlue = Types.Color.lightBlue |> textDecorationColorValue'
        static member lightCoral = Types.Color.lightCoral |> textDecorationColorValue'
        static member lightCyan = Types.Color.lightCyan |> textDecorationColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> textDecorationColorValue'
        static member lightGray = Types.Color.lightGray |> textDecorationColorValue'
        static member lightGreen = Types.Color.lightGreen |> textDecorationColorValue'
        static member lightGrey = Types.Color.lightGrey |> textDecorationColorValue'
        static member lightPink = Types.Color.lightPink |> textDecorationColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> textDecorationColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> textDecorationColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> textDecorationColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> textDecorationColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> textDecorationColorValue'
        static member lightYellow = Types.Color.lightYellow |> textDecorationColorValue'
        static member limeGreen = Types.Color.limeGreen |> textDecorationColorValue'
        static member linen = Types.Color.linen |> textDecorationColorValue'
        static member magenta = Types.Color.magenta |> textDecorationColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> textDecorationColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> textDecorationColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> textDecorationColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> textDecorationColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> textDecorationColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> textDecorationColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> textDecorationColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> textDecorationColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> textDecorationColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> textDecorationColorValue'
        static member mintCream = Types.Color.mintCream |> textDecorationColorValue'
        static member mistyRose = Types.Color.mistyRose |> textDecorationColorValue'
        static member moccasin = Types.Color.moccasin |> textDecorationColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> textDecorationColorValue'
        static member oldLace = Types.Color.oldLace |> textDecorationColorValue'
        static member olivedrab = Types.Color.olivedrab |> textDecorationColorValue'
        static member orangeRed = Types.Color.orangeRed |> textDecorationColorValue'
        static member orchid = Types.Color.orchid |> textDecorationColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> textDecorationColorValue'
        static member paleGreen = Types.Color.paleGreen |> textDecorationColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> textDecorationColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> textDecorationColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> textDecorationColorValue'
        static member peachpuff = Types.Color.peachpuff |> textDecorationColorValue'
        static member peru = Types.Color.peru |> textDecorationColorValue'
        static member pink = Types.Color.pink |> textDecorationColorValue'
        static member plum = Types.Color.plum |> textDecorationColorValue'
        static member powderBlue = Types.Color.powderBlue |> textDecorationColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> textDecorationColorValue'
        static member royalBlue = Types.Color.royalBlue |> textDecorationColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> textDecorationColorValue'
        static member salmon = Types.Color.salmon |> textDecorationColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> textDecorationColorValue'
        static member seaGreen = Types.Color.seaGreen |> textDecorationColorValue'
        static member seaShell = Types.Color.seaShell |> textDecorationColorValue'
        static member sienna = Types.Color.sienna |> textDecorationColorValue'
        static member skyBlue = Types.Color.skyBlue |> textDecorationColorValue'
        static member slateBlue = Types.Color.slateBlue |> textDecorationColorValue'
        static member slateGray = Types.Color.slateGray |> textDecorationColorValue'
        static member snow = Types.Color.snow |> textDecorationColorValue'
        static member springGreen = Types.Color.springGreen |> textDecorationColorValue'
        static member steelBlue = Types.Color.steelBlue |> textDecorationColorValue'
        static member tan = Types.Color.tan |> textDecorationColorValue'
        static member thistle = Types.Color.thistle |> textDecorationColorValue'
        static member tomato = Types.Color.tomato |> textDecorationColorValue'
        static member turquoise = Types.Color.turquoise |> textDecorationColorValue'
        static member violet = Types.Color.violet |> textDecorationColorValue'
        static member wheat = Types.Color.wheat |> textDecorationColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> textDecorationColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> textDecorationColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> textDecorationColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> textDecorationColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> textDecorationColorValue'
        static member Hex value = Types.Color.Hex value |> textDecorationColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> textDecorationColorValue'
        static member Hsla h s l a = Types.Color.Hsla (h, s, l, a) |> textDecorationColorValue'
        static member transparent = Types.Color.transparent |> textDecorationColorValue'
        static member currentColor = Types.Color.currentColor |> textDecorationColorValue'

        static member Inherit = Types.Inherit |> textDecorationColorValue'
        static member Initial = Types.Initial |> textDecorationColorValue'
        static member Unset = Types.Unset |> textDecorationColorValue'

    /// <summary>Specifies color of text decoration.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationColor' (color: Types.ITextDecorationColor) = TextDecorationColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-color
    let private emphasisColorValue value = Types.cssValue Types.Property.TextEmphasisColor value
    let private emphasisColorValue' value =
        value
        |> textEmphasisColorToString
        |> emphasisColorValue
    type TextEmphasisColor =
        static member Value (color: Types.ITextEmphasisColor) = color |> emphasisColorValue'
        static member black = Types.Color.black |> emphasisColorValue'
        static member silver = Types.Color.silver |> emphasisColorValue'
        static member gray = Types.Color.gray |> emphasisColorValue'
        static member white = Types.Color.white |> emphasisColorValue'
        static member maroon = Types.Color.maroon |> emphasisColorValue'
        static member red = Types.Color.red |> emphasisColorValue'
        static member purple = Types.Color.purple |> emphasisColorValue'
        static member fuchsia = Types.Color.fuchsia |> emphasisColorValue'
        static member green = Types.Color.green |> emphasisColorValue'
        static member lime = Types.Color.lime |> emphasisColorValue'
        static member olive = Types.Color.olive |> emphasisColorValue'
        static member yellow = Types.Color.yellow |> emphasisColorValue'
        static member navy = Types.Color.navy |> emphasisColorValue'
        static member blue = Types.Color.blue |> emphasisColorValue'
        static member teal = Types.Color.teal |> emphasisColorValue'
        static member aqua = Types.Color.aqua |> emphasisColorValue'
        static member orange = Types.Color.orange |> emphasisColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> emphasisColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> emphasisColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> emphasisColorValue'
        static member azure = Types.Color.azure |> emphasisColorValue'
        static member beige = Types.Color.beige |> emphasisColorValue'
        static member bisque = Types.Color.bisque |> emphasisColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> emphasisColorValue'
        static member blueViolet = Types.Color.blueViolet |> emphasisColorValue'
        static member brown = Types.Color.brown |> emphasisColorValue'
        static member burlywood = Types.Color.burlywood |> emphasisColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> emphasisColorValue'
        static member chartreuse = Types.Color.chartreuse |> emphasisColorValue'
        static member chocolate = Types.Color.chocolate |> emphasisColorValue'
        static member coral = Types.Color.coral |> emphasisColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> emphasisColorValue'
        static member cornsilk = Types.Color.cornsilk |> emphasisColorValue'
        static member crimson = Types.Color.crimson |> emphasisColorValue'
        static member cyan = Types.Color.cyan |> emphasisColorValue'
        static member darkBlue = Types.Color.darkBlue |> emphasisColorValue'
        static member darkCyan = Types.Color.darkCyan |> emphasisColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> emphasisColorValue'
        static member darkGray = Types.Color.darkGray |> emphasisColorValue'
        static member darkGreen = Types.Color.darkGreen |> emphasisColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> emphasisColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> emphasisColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> emphasisColorValue'
        static member darkOrange = Types.Color.darkOrange |> emphasisColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> emphasisColorValue'
        static member darkRed = Types.Color.darkRed |> emphasisColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> emphasisColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> emphasisColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> emphasisColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> emphasisColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> emphasisColorValue'
        static member darkViolet = Types.Color.darkViolet |> emphasisColorValue'
        static member deepPink = Types.Color.deepPink |> emphasisColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> emphasisColorValue'
        static member dimGrey = Types.Color.dimGrey |> emphasisColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> emphasisColorValue'
        static member fireBrick = Types.Color.fireBrick |> emphasisColorValue'
        static member floralWhite = Types.Color.floralWhite |> emphasisColorValue'
        static member forestGreen = Types.Color.forestGreen |> emphasisColorValue'
        static member gainsboro = Types.Color.gainsboro |> emphasisColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> emphasisColorValue'
        static member gold = Types.Color.gold |> emphasisColorValue'
        static member goldenrod = Types.Color.goldenrod |> emphasisColorValue'
        static member greenYellow = Types.Color.greenYellow |> emphasisColorValue'
        static member grey = Types.Color.grey |> emphasisColorValue'
        static member honeydew = Types.Color.honeydew |> emphasisColorValue'
        static member hotPink = Types.Color.hotPink |> emphasisColorValue'
        static member indianRed = Types.Color.indianRed |> emphasisColorValue'
        static member indigo = Types.Color.indigo |> emphasisColorValue'
        static member ivory = Types.Color.ivory |> emphasisColorValue'
        static member khaki = Types.Color.khaki |> emphasisColorValue'
        static member lavender = Types.Color.lavender |> emphasisColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> emphasisColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> emphasisColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> emphasisColorValue'
        static member lightBlue = Types.Color.lightBlue |> emphasisColorValue'
        static member lightCoral = Types.Color.lightCoral |> emphasisColorValue'
        static member lightCyan = Types.Color.lightCyan |> emphasisColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> emphasisColorValue'
        static member lightGray = Types.Color.lightGray |> emphasisColorValue'
        static member lightGreen = Types.Color.lightGreen |> emphasisColorValue'
        static member lightGrey = Types.Color.lightGrey |> emphasisColorValue'
        static member lightPink = Types.Color.lightPink |> emphasisColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> emphasisColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> emphasisColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> emphasisColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> emphasisColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> emphasisColorValue'
        static member lightYellow = Types.Color.lightYellow |> emphasisColorValue'
        static member limeGreen = Types.Color.limeGreen |> emphasisColorValue'
        static member linen = Types.Color.linen |> emphasisColorValue'
        static member magenta = Types.Color.magenta |> emphasisColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> emphasisColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> emphasisColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> emphasisColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> emphasisColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> emphasisColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> emphasisColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> emphasisColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> emphasisColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> emphasisColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> emphasisColorValue'
        static member mintCream = Types.Color.mintCream |> emphasisColorValue'
        static member mistyRose = Types.Color.mistyRose |> emphasisColorValue'
        static member moccasin = Types.Color.moccasin |> emphasisColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> emphasisColorValue'
        static member oldLace = Types.Color.oldLace |> emphasisColorValue'
        static member olivedrab = Types.Color.olivedrab |> emphasisColorValue'
        static member orangeRed = Types.Color.orangeRed |> emphasisColorValue'
        static member orchid = Types.Color.orchid |> emphasisColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> emphasisColorValue'
        static member paleGreen = Types.Color.paleGreen |> emphasisColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> emphasisColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> emphasisColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> emphasisColorValue'
        static member peachpuff = Types.Color.peachpuff |> emphasisColorValue'
        static member peru = Types.Color.peru |> emphasisColorValue'
        static member pink = Types.Color.pink |> emphasisColorValue'
        static member plum = Types.Color.plum |> emphasisColorValue'
        static member powderBlue = Types.Color.powderBlue |> emphasisColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> emphasisColorValue'
        static member royalBlue = Types.Color.royalBlue |> emphasisColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> emphasisColorValue'
        static member salmon = Types.Color.salmon |> emphasisColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> emphasisColorValue'
        static member seaGreen = Types.Color.seaGreen |> emphasisColorValue'
        static member seaShell = Types.Color.seaShell |> emphasisColorValue'
        static member sienna = Types.Color.sienna |> emphasisColorValue'
        static member skyBlue = Types.Color.skyBlue |> emphasisColorValue'
        static member slateBlue = Types.Color.slateBlue |> emphasisColorValue'
        static member slateGray = Types.Color.slateGray |> emphasisColorValue'
        static member snow = Types.Color.snow |> emphasisColorValue'
        static member springGreen = Types.Color.springGreen |> emphasisColorValue'
        static member steelBlue = Types.Color.steelBlue |> emphasisColorValue'
        static member tan = Types.Color.tan |> emphasisColorValue'
        static member thistle = Types.Color.thistle |> emphasisColorValue'
        static member tomato = Types.Color.tomato |> emphasisColorValue'
        static member turquoise = Types.Color.turquoise |> emphasisColorValue'
        static member violet = Types.Color.violet |> emphasisColorValue'
        static member wheat = Types.Color.wheat |> emphasisColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> emphasisColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> emphasisColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> emphasisColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> emphasisColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> emphasisColorValue'
        static member Hex value = Types.Color.Hex value |> emphasisColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> emphasisColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> emphasisColorValue'
        static member transparent = Types.Color.transparent |> emphasisColorValue'
        static member currentColor = Types.Color.currentColor |> emphasisColorValue'

        static member Inherit = Types.Inherit |> emphasisColorValue'
        static member Initial = Types.Initial |> emphasisColorValue'
        static member Unset = Types.Unset |> emphasisColorValue'

    /// <summary>Specifies color of text emphasis.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisColor' (color: Types.ITextEmphasisColor) = TextEmphasisColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-size-adjust
    let private textSizeAdjustValue value = Types.cssValue Types.Property.TextSizeAdjust value
    let private textSizeAdjustValue' value = value |> textSizeAdjustToString |> textSizeAdjustValue

    type TextSizeAdjust =
        static member Value (textSize: Types.ITextSizeAdjust) = textSize |> textSizeAdjustValue'
        static member Auto = Types.Auto |> textSizeAdjustValue'
        static member None = Types.None' |> textSizeAdjustValue'
        static member Inherit = Types.Inherit |> textSizeAdjustValue'
        static member Initial = Types.Initial |> textSizeAdjustValue'
        static member Unset = Types.Unset |> textSizeAdjustValue'

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
    let private tabSizeValue value = Types.cssValue Types.Property.TabSize value
    let private tabSizeValue' value = value |> tabSizeToString |> tabSizeValue

    type TabSize =
        static member Value (tabSize: Types.ITabSize) = tabSize |> tabSizeValue'
        static member Inherit = Types.Inherit |> tabSizeValue'
        static member Initial = Types.Initial |> tabSizeValue'
        static member Unset = Types.Unset |> tabSizeValue'

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
    let private textOrientationValue value = Types.cssValue Types.Property.TextOrientation value
    let private textOrientationValue' value = value |> textOrientationToString |> textOrientationValue

    type TextOrientation =
        static member Value (orientation: Types.ITextOrientation) = orientation |> textOrientationValue'
        static member Mixed = Types.Mixed |> textOrientationValue'
        static member Upright = Types.Upright |> textOrientationValue'
        static member SidewaysRight = Types.SidewaysRight |> textOrientationValue'
        static member Sideways = Types.Sideways |> textOrientationValue'
        static member UseGlyphOrientation = Types.UseGlyphOrientation |> textOrientationValue'
        static member Inherit = Types.Inherit |> textOrientationValue'
        static member Initial = Types.Initial |> textOrientationValue'
        static member Unset = Types.Unset |> textOrientationValue'

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
    let private textRenderingValue value = Types.cssValue Types.Property.TextRendering value
    let private textRenderingValue' value = value |> textRenderingToString |> textRenderingValue

    type TextRendering =
        static member Value (rendering: Types.ITextRendering) = rendering |> textRenderingValue'
        static member OptimizeSpeed = Types.OptimizeSpeed |> textRenderingValue'
        static member OptimizeLegibility = Types.OptimizeLegibility |> textRenderingValue'
        static member GeometricPrecision = Types.GeometricPrecision |> textRenderingValue'
        static member Auto = Types.Auto |> textRenderingValue'
        static member Inherit = Types.Inherit |> textRenderingValue'
        static member Initial = Types.Initial |> textRenderingValue'
        static member Unset = Types.Unset |> textRenderingValue'

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
    let private textJustifyValue value = Types.cssValue Types.Property.TextJustify value
    let private textJustifyValue' value = value |> textJustifyToString |> textJustifyValue

    type TextJustify =
        static member Value (justification: Types.ITextJustify) = justification |> textJustifyValue'
        static member InterWord = Types.InterWord |> textJustifyValue'
        static member InterCharacter = Types.InterCharacter |> textJustifyValue'
        static member Auto = Types.Auto |> textJustifyValue'
        static member None = Types.None' |> textJustifyValue'

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
    let private whiteSpaceValue value = Types.cssValue Types.Property.WhiteSpace value
    let private whiteSpaceValue' value = value |> whitespaceToString |> whiteSpaceValue

    type WhiteSpace =
        static member Value (whitespace: Types.IWhiteSpace) = whitespace |> whiteSpaceValue'
        static member NoWrap = Types.WhiteSpace.NoWrap |> whiteSpaceValue'
        static member Pre = Types.Pre |> whiteSpaceValue'
        static member PreWrap = Types.PreWrap |> whiteSpaceValue'
        static member PreLine = Types.PreLine |> whiteSpaceValue'
        static member BreakSpaces = Types.BreakSpaces |> whiteSpaceValue'
        static member Normal = Types.Normal |> whiteSpaceValue'
        static member Inherit = Types.Inherit |> whiteSpaceValue'
        static member Initial = Types.Initial |> whiteSpaceValue'
        static member Unset = Types.Unset |> whiteSpaceValue'

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
    let private userSelectValue value = Types.cssValue Types.Property.UserSelect value
    let private userSelectValue' value = value |> userSelectToString |> userSelectValue

    type UserSelect =
        static member Value (whitespace: Types.IUserSelect) = whitespace |> userSelectValue'
        static member Text = Types.UserSelect.Text |> userSelectValue'
        static member Contain = Types.UserSelect.Contain |> userSelectValue'
        static member All = Types.UserSelect.All |> userSelectValue'
        static member None = Types.None' |> userSelectValue'
        static member Auto = Types.Auto |> userSelectValue'
        static member Inherit = Types.Inherit |> userSelectValue'
        static member Initial = Types.Initial |> userSelectValue'
        static member Unset = Types.Unset |> userSelectValue'

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