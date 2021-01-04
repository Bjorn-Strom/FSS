namespace Fss

module TextTypes =
    type TextAlign =
        | Left
        | Right
        | Center
        | Justify
        | JustifyAll
        | Start
        | End
        | MatchParent
        interface ITextAlign

    type TextAlignLast =
        | Start
        | End
        | Left
        | Right
        | Center
        | Justify
        interface ITextAlignLast

    type TextDecorationLine =
        | Overline
        | Underline
        | LineThrough
        | Blink
        interface ITextDecorationLine

    type TextDecorationThickness =
        | TextDecorationThickness
        interface ITextDecorationThickness

    type TextDecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ITextDecorationStyle

    type DecorationSkip =
        | Objects
        | Spaces
        | Edges
        | BoxDecoration
        | LeadingSpaces
        | TrailingSpaces
        interface ITextDecorationSkip

    type TextDecorationSkipInk =
        | TextDecorationSkipInk
        interface ITextDecorationSkipInk

    type TextTransform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ITextTransform

    type TextIndent =
        | Hanging
        | EachLine
        interface ITextIndent

    type TextShadow =
        | Shadow  of ITextShadow
        | Shadow2 of Units.Size.Size * Units.Size.Size
        | Shadow3 of Units.Size.Size * Units.Size.Size * CSSColor
        | Shadow4 of Units.Size.Size * Units.Size.Size * Units.Size.Size * CSSColor
        interface ITextShadow

    type TextOverflow =
        | Clip
        | Ellipsis
        interface ITextOverflow

    type EmphasisPosition =
        | Over
        | Under
        | Right
        | Left
        interface ITextEmphasisPosition

    type TextEmphasisStyle =
        | Filled
        | Open
        | Dot
        | Circle
        | DoubleCircle
        | Triangle
        | FilledSesame
        | OpenSesame
        interface ITextEmphasisStyle

    type UnderlinePosition =
        | FromFont
        | Under
        | Left
        | Right
        | AutoPos
        | Above
        | Below
        interface ITextUnderlinePosition

    type TextEmphasisColor =
        | TextEmphasisColor of CSSColor
        interface ITextEmphasisColor

    type Hyphens =
        | Manual
        interface IHyphens

    type TextOrientation =
        | Mixed
        | Upright
        | SidewaysRight
        | Sideways
        | UseGlyphOrientation
        interface ITextOrientation

    type TextRendering =
        | OptimizeSpeed
        | OptimizeLegibility
        | GeometricPrecision
        interface ITextRendering

    type TextJustify =
        | InterWord
        | InterCharacter
        interface ITextJustify

    type WhiteSpace =
        | NoWrap
        | Pre
        | PreWrap
        | PreLine
        | BreakSpaces
        interface IWhiteSpace

    type UserSelect =
        | Text
        | Contain
        | All
        | Element
        interface IUserSelect

[<AutoOpen>]
module Text =
    open TextTypes

    let private textAlignToString (alignment: ITextAlign) =
        match alignment with
        | :? TextAlign as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown text alignment"

    let private textAlignLastToString (alignment: ITextAlignLast) =
        match alignment with
        | :? TextAlignLast as t -> Utilities.Helpers.duToLowercase t
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown text alignment last"

    let private decorationLineToString (decorationLine: ITextDecorationLine) =
        match decorationLine with
        | :? TextDecorationLine as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown text decoration line"

    let private thicknessToString (thickness: ITextDecorationThickness) =
        match thickness with
        | :? TextDecorationThickness -> "from-font"
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown text decoration thickness"

    let private decorationToString (decoration: ITextDecoration) =
        match decoration with
        | :? None -> GlobalValue.none
        | _ -> "Unknown text decoration"

    let private decorationStyleToString (style: ITextDecorationStyle) =
        match style with
        | :? TextDecorationStyle as t -> Utilities.Helpers.duToLowercase t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown text decoration style"

    let private decorationSkipToString (skip: ITextDecorationSkip) =
        match skip with
        | :? DecorationSkip as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown text decoration skip"

    let private decorationSkipInkToString (skipInk: ITextDecorationSkipInk) =
        match skipInk with
        | :? TextDecorationSkipInk -> "all"
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown text decoration skip ink"

    let private textTransformToString (transform: ITextTransform) =
        match transform with
        | :? TextTransform as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown text transform"

    let private indentToString (indent: ITextIndent) =
        match indent with
        | :? TextIndent as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown text indent"

    let private textShadowToString (shadow: ITextShadow) =
        let stringifyTextShadow =
            function
                | Shadow2 (x,y) -> sprintf "%s %s" (Units.Size.value x) (Units.Size.value y)
                | Shadow3 (x,y,c) -> sprintf "%s %s %s" (Units.Size.value x) (Units.Size.value y) (CSSColorValue.color c)
                | Shadow4 (x,y,b,c) ->
                    sprintf "%s %s %s %s"
                        (Units.Size.value x)
                        (Units.Size.value y)
                        (Units.Size.value b)
                        (CSSColorValue.color c)
                | _ -> "Should be a keyword"

        match shadow with
            | :? TextShadow as t -> stringifyTextShadow t
            | :? Global as g -> GlobalValue.global' g
            | _ -> "unknown text shadow"

    let private emphasisToString (emphasis: ITextEmphasis) =
        match emphasis with
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "unknown text emphasis"

    let private emphasisPositionToString (emphasisPosition: ITextEmphasisPosition) =
        match emphasisPosition with
        | :? EmphasisPosition as e -> Utilities.Helpers.duToLowercase e
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown text emphasis position"

    let private textOverflowToString (overflow: ITextOverflow) =
        match overflow with
        | :? TextOverflow as t -> Utilities.Helpers.duToLowercase t
        | :? CssString as s -> GlobalValue.string s |> sprintf "\"%s\""
        | _ -> "Unknown text overflow"

    let private emphasisStyleToString (emphasisStyle: ITextEmphasisStyle) =
        let stringifyStyle style =
            match style with
                | FilledSesame -> "filled sesame"
                | OpenSesame -> "open sesame"
                | _ -> Utilities.Helpers.duToKebab style

        match emphasisStyle with
        | :? TextEmphasisStyle as t -> stringifyStyle t
        | :? CssString as s -> GlobalValue.string s |> sprintf "'%s'"
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "unknown text emphasis style"

    let private underlinePositionToString (underlinePosition: ITextUnderlinePosition) =
        match underlinePosition with
        | :? UnderlinePosition as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "unknown text underline position"

    let private textEmphasisColorToString (color: ITextEmphasisColor) =
        match color with
            | :? CSSColor as c -> CSSColorValue.color c
            | :? Global as g -> GlobalValue.global' g
            | _ -> "unknown text emphasis color"

    let private underlineOffsetToString (underlineOffset: ITextUnderlineOffset) =
        match underlineOffset with
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "unknown text underline offset"

    let private quoteToString (quote: IQuotes) =
        match quote with
        | :? CssString as s -> GlobalValue.string s
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown quotes"

    let private hyphensToString (hyphens: IHyphens) =
        match hyphens with
        | :? Hyphens -> "manual"
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown hyphens"

    let private textDecorationColorToString (color: ITextDecorationColor) =
        match color with
            | :? CSSColor as c -> CSSColorValue.color c
            | :? Global as g -> GlobalValue.global' g
            | _ -> "unknown text decoration color"

    let private textSizeAdjustToString (size: ITextSizeAdjust) =
        match size with
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown text size adjust"

    let private tabSizeToString (tabSize: ITabSize) =
        match tabSize with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? CssInt as i -> GlobalValue.int i
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown tab size"

    let private textOrientationToString (textOrientation: ITextOrientation) =
        match textOrientation with
        | :? TextOrientation as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown text orientation"

    let private textRenderingToString (textRendering: ITextRendering) =
        match textRendering with
        | :? TextRendering as t -> Utilities.Helpers.duToKebab t
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown text rendering"

    let private textJustifyToString (textJustify: ITextJustify) =
        match textJustify with
        | :? TextJustify as j -> Utilities.Helpers.duToKebab j
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown text justification"

    let private whitespaceToString (whitespace: IWhiteSpace) =
        match whitespace with
        | :? WhiteSpace as ws -> Utilities.Helpers.duToKebab ws
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown whitespace"

    let private userSelectToString (userSelect: IUserSelect) =
        match userSelect with
        | :? UserSelect as u -> Utilities.Helpers.duToLowercase u
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown user select"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    let private alignCssValue value = PropertyValue.cssValue Property.TextAlign value
    let private alignCssValue' value =
        value
        |> textAlignToString
        |> alignCssValue
    type TextAlign =
        static member Value (textAlign: ITextAlign) = textAlign |> alignCssValue'
        static member Left = TextTypes.TextAlign.Left |> alignCssValue'
        static member Right = TextTypes.TextAlign.Right |> alignCssValue'
        static member Center = TextTypes.TextAlign.Center |> alignCssValue'
        static member Justify = TextTypes.TextAlign.Justify |> alignCssValue'
        static member JustifyAll = JustifyAll |> alignCssValue'
        static member Start = TextTypes.TextAlign.Start |> alignCssValue'
        static member End = TextTypes.TextAlign.End |> alignCssValue'
        static member MatchParent = MatchParent |> alignCssValue'

        static member Inherit = Inherit |> alignCssValue'
        static member Initial = Initial |> alignCssValue'
        static member Unset = Unset |> alignCssValue'

    /// <summary>Specifies the horizontal alignment of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlign' (align: ITextAlign) = TextAlign.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
    let private alignLastCssValue value = PropertyValue.cssValue Property.TextAlignLast value
    let private alignLastCssValue' value =
        value
        |> textAlignLastToString
        |> alignLastCssValue
    type TextAlignLast =
        static member Value (textAlign: ITextAlignLast) = textAlign |> alignLastCssValue'
        static member Left = TextTypes.TextAlignLast.Left |> alignLastCssValue'
        static member Right = TextTypes.TextAlignLast.Right |> alignLastCssValue'
        static member Center = TextTypes.TextAlignLast.Center |> alignLastCssValue'
        static member Justify = TextTypes.TextAlignLast.Justify |> alignLastCssValue'
        static member Start = TextTypes.TextAlignLast.Start |> alignLastCssValue'
        static member End = TextTypes.TextAlignLast.End |> alignLastCssValue'

        static member Inherit = Inherit |> alignLastCssValue'
        static member Initial = Initial |> alignLastCssValue'
        static member Unset = Unset |> alignLastCssValue'

    /// <summary>Specifies the horizontal alignment of the last line of text.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> TextAlign </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAlignLast' (align: ITextAlignLast) = TextAlignLast.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
    let private decorationValue value = PropertyValue.cssValue Property.TextDecoration value
    let private decorationValue' value =
        value
        |> decorationToString
        |> decorationValue
    type TextDecoration =
        static member Value (value: ITextDecoration) = value |> decorationValue'
        static member None = None |> decorationValue'

    /// <summary>Resets text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecoration' (decoration: ITextDecoration) = TextDecoration.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    let private lineCssValue value = PropertyValue.cssValue Property.TextDecorationLine value
    let private lineCssValue' value =
        value
        |> decorationLineToString
        |> lineCssValue
    type TextDecorationLine =
        static member Value (value: ITextDecorationLine) = value |> lineCssValue'
        static member Value (v1: ITextDecorationLine, v2: ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s" (string v1) (decorationLineToString v2)
        static member Value (v1: ITextDecorationLine, v2: ITextDecorationLine, v3: ITextDecorationLine) =
            lineCssValue <| sprintf "%s %s %s" (decorationLineToString v1) (decorationLineToString v2) (decorationLineToString v3)
        static member Underline = Underline |> lineCssValue'
        static member Overline = Overline |> lineCssValue'
        static member LineThrough = LineThrough |> lineCssValue'
        static member Blink = Blink |> lineCssValue'

        static member Inherit = Inherit |> lineCssValue'
        static member Initial = Initial |> lineCssValue'
        static member Unset = Unset |> lineCssValue'
        static member None = None |> lineCssValue'

    /// <summary>Specifies how to decorate text.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationLine </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationLine' (decoration: ITextDecorationLine) = TextDecorationLine.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    let private thicknessValue value = PropertyValue.cssValue Property.TextDecorationThickness value
    let private thicknessValue' value =
        value
        |> thicknessToString
        |> thicknessValue
    type TextDecorationThickness =
        static member Value (thickness: ITextDecorationThickness) = thickness |> thicknessValue'
        static member FromFont = TextDecorationThickness.TextDecorationThickness |> thicknessValue'

        static member Auto = Auto |> thicknessValue'
        static member Inherit = Inherit |> thicknessValue'
        static member Initial = Initial |> thicknessValue'
        static member Unset = Unset |> thicknessValue'

    /// <summary>Specifies thickness of text decoration.</summary>
    /// <param name="thickness">
    ///     can be:
    ///     - <c> TextDecorationThickness </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationThickness' (thickness: ITextDecorationThickness) = TextDecorationThickness.Value(thickness)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    let private decorationStyleValue value = PropertyValue.cssValue Property.TextDecorationStyle value
    let private decorationStyleValue' value =
        value
        |> decorationStyleToString
        |> decorationStyleValue
    type TextDecorationStyle =
        static member Value(style: ITextDecorationStyle) = style |> decorationStyleValue'
        static member Solid = Solid |> decorationStyleValue'
        static member Double = Double |> decorationStyleValue'
        static member Dotted = Dotted |> decorationStyleValue'
        static member Dashed = Dashed |> decorationStyleValue'
        static member Wavy = Wavy |> decorationStyleValue'

        static member Inherit = Inherit |> decorationStyleValue'
        static member Initial = Initial |> decorationStyleValue'
        static member Unset = Unset |> decorationStyleValue'

    /// <summary>Specifies style of text decoration.</summary>
    /// <param name="decoration">
    ///     can be:
    ///     - <c> TextDecorationStyle </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationStyle' (decoration: ITextDecorationStyle) = TextDecorationStyle.Value(decoration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    let private skipValue value = PropertyValue.cssValue Property.TextDecorationSkip value
    let private skipValue' value =
        value
        |> decorationSkipToString
        |> skipValue

    type TextDecorationSkip =
        static member Value (value: ITextDecorationSkip) = value |> skipValue'
        static member Value (v1: ITextDecorationSkip, v2: ITextDecorationSkip) =
            sprintf "%s %s" (decorationSkipToString v1) (decorationSkipToString v2) |> skipValue
        static member Value (v1: ITextDecorationSkip, v2: ITextDecorationSkip, v3: ITextDecorationSkip) =
            sprintf "%s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) |> skipValue
        static member Value (v1: ITextDecorationSkip, v2: ITextDecorationSkip, v3: ITextDecorationSkip, v4: ITextDecorationSkip) =
            sprintf "%s %s %s %s" (decorationSkipToString v1) (decorationSkipToString v2) (decorationSkipToString v3) (decorationSkipToString v4) |> skipValue

        static member Objects =  Objects |> skipValue'
        static member Spaces = Spaces |> skipValue'
        static member LeadingSpaces = LeadingSpaces |> skipValue'
        static member TrailingSpaces = TrailingSpaces |> skipValue'
        static member Edges = Edges |> skipValue'
        static member BoxDecoration = BoxDecoration |> skipValue'

        static member Inherit = Inherit |> skipValue'
        static member Initial = Initial |> skipValue'
        static member Unset = Unset |> skipValue'
        static member None = None |> skipValue'

    /// <summary>Specifies what parts of decoration should be skipped.</summary>
    /// <param name="skip">
    ///     can be:
    ///     - <c> TextDecorationSkip </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationSkip' (skip: ITextDecorationSkip) = TextDecorationSkip.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    let private skipInkValue value = PropertyValue.cssValue Property.TextDecorationSkipInk value
    let private skipInkValue' value =
        value
        |> decorationSkipInkToString
        |> skipInkValue
    type TextDecorationSkipInk =
        static member Value(skipInk: ITextDecorationSkipInk) = skipInk |> skipInkValue'
        static member All = TextTypes.TextDecorationSkipInk |> skipInkValue'

        static member Inherit = Inherit |> skipInkValue'
        static member Initial = Initial |> skipInkValue'
        static member Unset = Unset |> skipInkValue'
        static member None = None |> skipInkValue'
        static member Auto = Auto |> skipInkValue'

    /// <summary>Specifies what parts of decoration should be skipped.</summary>
    /// <param name="skip">
    ///     can be:
    ///     - <c> TextDecorationSkipInk </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationSkipInk' (skip: ITextDecorationSkipInk) = TextDecorationSkipInk.Value(skip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    let private transformValue value = PropertyValue.cssValue Property.TextTransform value
    let private transformValue' value =
        value
        |> textTransformToString
        |> transformValue
    type TextTransform =
        static member Value (transform: ITextTransform) = transform |> transformValue'
        static member Capitalize = Capitalize |> transformValue'
        static member Uppercase = Uppercase |> transformValue'
        static member Lowercase = Lowercase |> transformValue'
        static member FullWidth = FullWidth |> transformValue'
        static member FullSizeKana = FullSizeKana |> transformValue'

        static member Inherit = Inherit |> transformValue'
        static member Initial = Initial |> transformValue'
        static member Unset = Unset |> transformValue'
        static member None = None |> transformValue'

    /// <summary>Specifies what parts of text to capitalize.</summary>
    /// <param name="transform">
    ///     can be:
    ///     - <c> TextTransform </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextTransform' (transform: ITextTransform) = TextTransform.Value(transform)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    let private indentCssValue value = PropertyValue.cssValue Property.TextIndent value
    let private indentCssValue' value =
        value
        |> indentToString
        |> indentCssValue
    type TextIndent =
        static member Value (indent: ITextIndent) = indent |> indentCssValue'
        static member Value (i1: ITextIndent, i2: ITextIndent) = sprintf "%s %s" (indentToString i1) (indentToString i2) |> indentCssValue
        static member Value (i1: ITextIndent, i2: ITextIndent, i3: ITextIndent) =
            sprintf "%s %s %s" (indentToString i1) (indentToString i2) (indentToString i3) |> indentCssValue

        static member Hanging = Hanging |> indentCssValue'
        static member EachLine = EachLine |> indentCssValue'

        static member Inherit = Inherit |> indentCssValue'
        static member Initial = Initial |> indentCssValue'
        static member Unset = Unset |> indentCssValue'

    /// <summary>Specifies how much indentation is put before lines of text.</summary>
    /// <param name="indent">
    ///     can be:
    ///     - <c> TextIndent </c>
    ///     - <c> Global </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextIndent' (indent: ITextIndent) = TextIndent.Value(indent)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    let private shadowValue value = PropertyValue.cssValue Property.TextShadow value
    let private shadowValue' value =
        value
        |> textShadowToString
        |> shadowValue
    let private shadowValues (values: TextShadow list) =
        values
        |> Utilities.Helpers.combineComma textShadowToString
        |> shadowValue

    type TextShadow =
        static member Value (shadow: ITextShadow) = shadow |> shadowValue'
        static member Value (xOffset: Units.Size.Size, yOffset: Units.Size.Size) =
            Shadow2(xOffset,yOffset) |> shadowValue'
        static member Value (xOffset: Units.Size.Size, yOffset: Units.Size.Size, color: CSSColor) =
            Shadow3(xOffset, yOffset, color) |> shadowValue'
        static member Value (xOffset: Units.Size.Size, yOffset: Units.Size.Size, blurRadius: Units.Size.Size, color: CSSColor) =
            Shadow4 (xOffset, yOffset, blurRadius, color) |> shadowValue'
        static member Value (shadows: TextTypes.TextShadow list) = shadowValues shadows
        static member Inherit = Inherit |> shadowValue'
        static member Initial = Initial |> shadowValue'
        static member Unset = Unset |> shadowValue'

    /// <summary>Adds shadow to text.</summary>
    /// <param name="shadow">
    ///     can be:
    ///     - <c> TextShadow </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextShadow' (shadow: ITextShadow) = TextShadow.Value(shadow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
    let private overflowValue value = PropertyValue.cssValue Property.TextOverflow value
    let private overflowValue' value =
        value
        |> textOverflowToString
        |> overflowValue
    type TextOverflow =
        static member Value (overflow: ITextOverflow) = overflow |> overflowValue'

        static member Clip = Clip |> overflowValue'
        static member Ellipsis = Ellipsis |> overflowValue'

    /// <summary>If there is hidden content this specifies how that is signalled.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> TextOverflow </c>
    ///     - <c> CssString </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOverflow' (overflow: ITextOverflow) = TextOverflow.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    let private emphasisValue value = PropertyValue.cssValue Property.TextEmphasis value
    let private emphasisValue' value =
        value
        |> emphasisToString
        |> emphasisValue

    type TextEmphasis =
        static member Value (emphasis: ITextEmphasis) = emphasis |> emphasisValue'

        static member None = None |> emphasisValue'
        static member Inherit = Inherit |> emphasisValue'
        static member Initial = Initial |> emphasisValue'
        static member Unset = Unset |> emphasisValue'

    /// <summary>Specifies emphasis marks to text.</summary>
    /// <param name="emphasis">
    ///     can be:
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasis' (emphasis: ITextEmphasis) = TextEmphasis.Value emphasis

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    let private emphasisPositionValue value = PropertyValue.cssValue Property.TextEmphasisPosition value
    let private emphasisPositionValue' value =
        value
        |> emphasisPositionToString
        |> emphasisPositionValue

    type TextEmphasisPosition =
        static member Value (v1: ITextEmphasisPosition, v2: ITextEmphasisPosition) =
            sprintf "%s %s" (emphasisPositionToString v1) (emphasisPositionToString v2)
            |> emphasisPositionValue

        static member Inherit = Inherit |> emphasisPositionValue'
        static member Initial = Initial |> emphasisPositionValue'
        static member Unset = Unset |> emphasisPositionValue'

    /// <summary>Specifies where emphasis marks are drawn.</summary>
    /// <param name="e1"> </param>
    /// <param name="e2"> </param>
    /// Both params can be:
    ///     - <c> TextEmphasisStyle </c>
    ///     - <c> CssString </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisPosition' (e1: ITextEmphasisPosition) (e2: ITextEmphasisPosition) = TextEmphasisPosition.Value(e1, e2)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    let private emphasisStyleValue value = PropertyValue.cssValue Property.TextEmphasisStyle value
    let private emphasisStyleValue' value =
        value
        |> emphasisStyleToString
        |> emphasisStyleValue
    type TextEmphasisStyle =
        static member Value (emphasisStyle: ITextEmphasisStyle) = emphasisStyle |> emphasisStyleValue'
        static member Filled = Filled |> emphasisStyleValue'
        static member Open = Open |> emphasisStyleValue'
        static member Dot =  Dot |> emphasisStyleValue'
        static member Circle = Circle |> emphasisStyleValue'
        static member DoubleCircle = DoubleCircle |> emphasisStyleValue'
        static member Triangle = Triangle |> emphasisStyleValue'
        static member FilledSesame = FilledSesame |> emphasisStyleValue'
        static member OpenSesame = OpenSesame |> emphasisStyleValue'

        static member None = None |> emphasisStyleValue'
        static member Inherit = Inherit |> emphasisStyleValue'
        static member Initial = Initial |> emphasisStyleValue'
        static member Unset = Unset |> emphasisStyleValue'

    /// <summary>Specifies style of text emphasis.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> TextEmphasisStyle </c>
    ///     - <c> CssString </c>
    ///     - <c> Global </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisStyle' (style: ITextEmphasisStyle) = TextEmphasisStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    let private underlinePositionCssValue value = PropertyValue.cssValue Property.TextUnderlinePosition value
    let private underlinePositionCssValue' value =
        value
        |> underlinePositionToString
        |> underlinePositionCssValue

    type TextUnderlinePosition =
        static member Value (underlinePosition: ITextUnderlinePosition) =
            underlinePosition |> underlinePositionCssValue'
        static member Value (v1: ITextUnderlinePosition, v2: ITextUnderlinePosition) =
            sprintf "%s %s" (underlinePositionToString v1) (underlinePositionToString v2) |> underlinePositionCssValue

        static member FromFont = FromFont |> underlinePositionCssValue'
        static member Under = Under |> underlinePositionCssValue'
        static member Left = Left |> underlinePositionCssValue'
        static member Right = Right |> underlinePositionCssValue'
        static member AutoPos = AutoPos  |> underlinePositionCssValue'
        static member Above = Above |> underlinePositionCssValue'
        static member Below = Below |> underlinePositionCssValue'

        static member Auto = Auto |> underlinePositionCssValue'
        static member Inherit = Inherit |> underlinePositionCssValue'
        static member Initial = Initial |> underlinePositionCssValue'
        static member Unset = Unset |> underlinePositionCssValue'

    /// <summary>Specifies the position of text underline.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> UnderlinePosition </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextUnderlinePosition' (position: ITextUnderlinePosition) = TextUnderlinePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
    let private offsetValue value = PropertyValue.cssValue Property.TextUnderlineOffset value
    let private offsetValue' value =
        value
        |> underlineOffsetToString
        |> offsetValue
    type TextUnderlineOffset =
        static member Value (underlineOffset: ITextUnderlineOffset) = underlineOffset |> offsetValue'
        static member Inherit = Inherit |> offsetValue'
        static member Initial = Initial |> offsetValue'
        static member Unset = Unset |> offsetValue'
        static member Auto = Auto |> offsetValue'

    /// <summary>Specifies the offset of text underline.</summary>
    /// <param name="offset">
    ///     can be:
    ///     - <c> Size  </c>
    ///     - <c> Percent  </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextUnderlineOffset' (offset: ITextUnderlineOffset) = TextUnderlineOffset.Value(offset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/quotes
    let private quoteValue value = PropertyValue.cssValue Property.Quotes value
    let private quoteValue' value =
        value
        |> quoteToString
        |> quoteValue
    type Quotes =
        static member Value (quote: IQuotes) =
            quote
            |> quoteValue'
        static member Value (openQuote: IQuotes, closeQuote: IQuotes) =
            quoteValue
            <| sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote)
        static member Value (openCloseQuotes: ((IQuotes * IQuotes) list)) =
            openCloseQuotes
            |> List.map (fun (openQuote, closeQuote) ->
                sprintf "\"%s\" \"%s\"" (quoteToString openQuote) (quoteToString closeQuote))
            |> String.concat " "
            |> quoteValue

        static member None = None |> quoteValue'
        static member Auto = Auto |> quoteValue'
        static member Inherit = Inherit |> quoteValue'
        static member Initial = Initial |> quoteValue'
        static member Unset = Unset |> quoteValue'

    /// <summary>Specifies how to render quotation marks.</summary>
    /// <param name="quotes">
    ///     can be:
    ///     - <c> CssString  </c>
    ///     - <c> None  </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Quotes' (quotes: IQuotes) = Quotes.Value(quotes)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/hyphens
    let private hyphensValue value = PropertyValue.cssValue Property.Hyphens value
    let private hyphensValue' value =
        value
        |> hyphensToString
        |> hyphensValue
    type Hyphens =
        static member Value (hyphens: IHyphens) = hyphens |> hyphensValue'
        static member Manual = Manual |> hyphensValue'
        static member Auto = Auto |> hyphensValue'
        static member None = None |> hyphensValue'
        static member Inherit = Inherit |> hyphensValue'
        static member Initial = Initial |> hyphensValue'
        static member Unset = Unset |> hyphensValue'

    /// <summary>Specifies words will be hyphenated when text wraps.</summary>
    /// <param name="hyphens">
    ///     can be:
    ///     - <c> Hyphens  </c>
    ///     - <c> None  </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Hyphens' (hyphens: IHyphens) = Hyphens.Value(hyphens)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-color
    let private textDecorationColorValue value = PropertyValue.cssValue Property.TextDecorationColor value
    let private textDecorationColorValue' value =
        value
        |> textDecorationColorToString
        |> textDecorationColorValue
    type TextDecorationColor =
        static member Value (color: ITextDecorationColor) = color |> textDecorationColorValue'

        static member black = CSSColor.black |> textDecorationColorValue'
        static member silver = CSSColor.silver |> textDecorationColorValue'
        static member gray = CSSColor.gray |> textDecorationColorValue'
        static member white = CSSColor.white |> textDecorationColorValue'
        static member maroon = CSSColor.maroon |> textDecorationColorValue'
        static member red = CSSColor.red |> textDecorationColorValue'
        static member purple = CSSColor.purple |> textDecorationColorValue'
        static member fuchsia = CSSColor.fuchsia |> textDecorationColorValue'
        static member green = CSSColor.green |> textDecorationColorValue'
        static member lime = CSSColor.lime |> textDecorationColorValue'
        static member olive = CSSColor.olive |> textDecorationColorValue'
        static member yellow = CSSColor.yellow |> textDecorationColorValue'
        static member navy = CSSColor.navy |> textDecorationColorValue'
        static member blue = CSSColor.blue |> textDecorationColorValue'
        static member teal = CSSColor.teal |> textDecorationColorValue'
        static member aqua = CSSColor.aqua |> textDecorationColorValue'
        static member orange = CSSColor.orange |> textDecorationColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> textDecorationColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> textDecorationColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> textDecorationColorValue'
        static member azure = CSSColor.azure |> textDecorationColorValue'
        static member beige = CSSColor.beige |> textDecorationColorValue'
        static member bisque = CSSColor.bisque |> textDecorationColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> textDecorationColorValue'
        static member blueViolet = CSSColor.blueViolet |> textDecorationColorValue'
        static member brown = CSSColor.brown |> textDecorationColorValue'
        static member burlywood = CSSColor.burlywood |> textDecorationColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> textDecorationColorValue'
        static member chartreuse = CSSColor.chartreuse |> textDecorationColorValue'
        static member chocolate = CSSColor.chocolate |> textDecorationColorValue'
        static member coral = CSSColor.coral |> textDecorationColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> textDecorationColorValue'
        static member cornsilk = CSSColor.cornsilk |> textDecorationColorValue'
        static member crimson = CSSColor.crimson |> textDecorationColorValue'
        static member cyan = CSSColor.cyan |> textDecorationColorValue'
        static member darkBlue = CSSColor.darkBlue |> textDecorationColorValue'
        static member darkCyan = CSSColor.darkCyan |> textDecorationColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> textDecorationColorValue'
        static member darkGray = CSSColor.darkGray |> textDecorationColorValue'
        static member darkGreen = CSSColor.darkGreen |> textDecorationColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> textDecorationColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> textDecorationColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> textDecorationColorValue'
        static member darkOrange = CSSColor.darkOrange |> textDecorationColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> textDecorationColorValue'
        static member darkRed = CSSColor.darkRed |> textDecorationColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> textDecorationColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> textDecorationColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> textDecorationColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> textDecorationColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> textDecorationColorValue'
        static member darkViolet = CSSColor.darkViolet |> textDecorationColorValue'
        static member deepPink = CSSColor.deepPink |> textDecorationColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> textDecorationColorValue'
        static member dimGrey = CSSColor.dimGrey |> textDecorationColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> textDecorationColorValue'
        static member fireBrick = CSSColor.fireBrick |> textDecorationColorValue'
        static member floralWhite = CSSColor.floralWhite |> textDecorationColorValue'
        static member forestGreen = CSSColor.forestGreen |> textDecorationColorValue'
        static member gainsboro = CSSColor.gainsboro |> textDecorationColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> textDecorationColorValue'
        static member gold = CSSColor.gold |> textDecorationColorValue'
        static member goldenrod = CSSColor.goldenrod |> textDecorationColorValue'
        static member greenYellow = CSSColor.greenYellow |> textDecorationColorValue'
        static member grey = CSSColor.grey |> textDecorationColorValue'
        static member honeydew = CSSColor.honeydew |> textDecorationColorValue'
        static member hotPink = CSSColor.hotPink |> textDecorationColorValue'
        static member indianRed = CSSColor.indianRed |> textDecorationColorValue'
        static member indigo = CSSColor.indigo |> textDecorationColorValue'
        static member ivory = CSSColor.ivory |> textDecorationColorValue'
        static member khaki = CSSColor.khaki |> textDecorationColorValue'
        static member lavender = CSSColor.lavender |> textDecorationColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> textDecorationColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> textDecorationColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> textDecorationColorValue'
        static member lightBlue = CSSColor.lightBlue |> textDecorationColorValue'
        static member lightCoral = CSSColor.lightCoral |> textDecorationColorValue'
        static member lightCyan = CSSColor.lightCyan |> textDecorationColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> textDecorationColorValue'
        static member lightGray = CSSColor.lightGray |> textDecorationColorValue'
        static member lightGreen = CSSColor.lightGreen |> textDecorationColorValue'
        static member lightGrey = CSSColor.lightGrey |> textDecorationColorValue'
        static member lightPink = CSSColor.lightPink |> textDecorationColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> textDecorationColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> textDecorationColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> textDecorationColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> textDecorationColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> textDecorationColorValue'
        static member lightYellow = CSSColor.lightYellow |> textDecorationColorValue'
        static member limeGreen = CSSColor.limeGreen |> textDecorationColorValue'
        static member linen = CSSColor.linen |> textDecorationColorValue'
        static member magenta = CSSColor.magenta |> textDecorationColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> textDecorationColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> textDecorationColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> textDecorationColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> textDecorationColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> textDecorationColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> textDecorationColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> textDecorationColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> textDecorationColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> textDecorationColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> textDecorationColorValue'
        static member mintCream = CSSColor.mintCream |> textDecorationColorValue'
        static member mistyRose = CSSColor.mistyRose |> textDecorationColorValue'
        static member moccasin = CSSColor.moccasin |> textDecorationColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> textDecorationColorValue'
        static member oldLace = CSSColor.oldLace |> textDecorationColorValue'
        static member olivedrab = CSSColor.olivedrab |> textDecorationColorValue'
        static member orangeRed = CSSColor.orangeRed |> textDecorationColorValue'
        static member orchid = CSSColor.orchid |> textDecorationColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> textDecorationColorValue'
        static member paleGreen = CSSColor.paleGreen |> textDecorationColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> textDecorationColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> textDecorationColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> textDecorationColorValue'
        static member peachpuff = CSSColor.peachpuff |> textDecorationColorValue'
        static member peru = CSSColor.peru |> textDecorationColorValue'
        static member pink = CSSColor.pink |> textDecorationColorValue'
        static member plum = CSSColor.plum |> textDecorationColorValue'
        static member powderBlue = CSSColor.powderBlue |> textDecorationColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> textDecorationColorValue'
        static member royalBlue = CSSColor.royalBlue |> textDecorationColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> textDecorationColorValue'
        static member salmon = CSSColor.salmon |> textDecorationColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> textDecorationColorValue'
        static member seaGreen = CSSColor.seaGreen |> textDecorationColorValue'
        static member seaShell = CSSColor.seaShell |> textDecorationColorValue'
        static member sienna = CSSColor.sienna |> textDecorationColorValue'
        static member skyBlue = CSSColor.skyBlue |> textDecorationColorValue'
        static member slateBlue = CSSColor.slateBlue |> textDecorationColorValue'
        static member slateGray = CSSColor.slateGray |> textDecorationColorValue'
        static member snow = CSSColor.snow |> textDecorationColorValue'
        static member springGreen = CSSColor.springGreen |> textDecorationColorValue'
        static member steelBlue = CSSColor.steelBlue |> textDecorationColorValue'
        static member tan = CSSColor.tan |> textDecorationColorValue'
        static member thistle = CSSColor.thistle |> textDecorationColorValue'
        static member tomato = CSSColor.tomato |> textDecorationColorValue'
        static member turquoise = CSSColor.turquoise |> textDecorationColorValue'
        static member violet = CSSColor.violet |> textDecorationColorValue'
        static member wheat = CSSColor.wheat |> textDecorationColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> textDecorationColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> textDecorationColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> textDecorationColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> textDecorationColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> textDecorationColorValue'
        static member Hex value = CSSColor.Hex value |> textDecorationColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> textDecorationColorValue'
        static member Hsla h s l a = CSSColor.Hsla (h, s, l, a) |> textDecorationColorValue'
        static member transparent = CSSColor.transparent |> textDecorationColorValue'
        static member currentColor = CSSColor.currentColor |> textDecorationColorValue'

        static member Inherit = Inherit |> textDecorationColorValue'
        static member Initial = Initial |> textDecorationColorValue'
        static member Unset = Unset |> textDecorationColorValue'

    /// <summary>Specifies color of text decoration.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CSSColor </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextDecorationColor' (color: ITextDecorationColor) = TextDecorationColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-color
    let private emphasisColorValue value = PropertyValue.cssValue Property.TextEmphasisColor value
    let private emphasisColorValue' value =
        value
        |> textEmphasisColorToString
        |> emphasisColorValue
    type TextEmphasisColor =
        static member Value (color: ITextEmphasisColor) = color |> emphasisColorValue'
        static member black = CSSColor.black |> emphasisColorValue'
        static member silver = CSSColor.silver |> emphasisColorValue'
        static member gray = CSSColor.gray |> emphasisColorValue'
        static member white = CSSColor.white |> emphasisColorValue'
        static member maroon = CSSColor.maroon |> emphasisColorValue'
        static member red = CSSColor.red |> emphasisColorValue'
        static member purple = CSSColor.purple |> emphasisColorValue'
        static member fuchsia = CSSColor.fuchsia |> emphasisColorValue'
        static member green = CSSColor.green |> emphasisColorValue'
        static member lime = CSSColor.lime |> emphasisColorValue'
        static member olive = CSSColor.olive |> emphasisColorValue'
        static member yellow = CSSColor.yellow |> emphasisColorValue'
        static member navy = CSSColor.navy |> emphasisColorValue'
        static member blue = CSSColor.blue |> emphasisColorValue'
        static member teal = CSSColor.teal |> emphasisColorValue'
        static member aqua = CSSColor.aqua |> emphasisColorValue'
        static member orange = CSSColor.orange |> emphasisColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> emphasisColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> emphasisColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> emphasisColorValue'
        static member azure = CSSColor.azure |> emphasisColorValue'
        static member beige = CSSColor.beige |> emphasisColorValue'
        static member bisque = CSSColor.bisque |> emphasisColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> emphasisColorValue'
        static member blueViolet = CSSColor.blueViolet |> emphasisColorValue'
        static member brown = CSSColor.brown |> emphasisColorValue'
        static member burlywood = CSSColor.burlywood |> emphasisColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> emphasisColorValue'
        static member chartreuse = CSSColor.chartreuse |> emphasisColorValue'
        static member chocolate = CSSColor.chocolate |> emphasisColorValue'
        static member coral = CSSColor.coral |> emphasisColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> emphasisColorValue'
        static member cornsilk = CSSColor.cornsilk |> emphasisColorValue'
        static member crimson = CSSColor.crimson |> emphasisColorValue'
        static member cyan = CSSColor.cyan |> emphasisColorValue'
        static member darkBlue = CSSColor.darkBlue |> emphasisColorValue'
        static member darkCyan = CSSColor.darkCyan |> emphasisColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> emphasisColorValue'
        static member darkGray = CSSColor.darkGray |> emphasisColorValue'
        static member darkGreen = CSSColor.darkGreen |> emphasisColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> emphasisColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> emphasisColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> emphasisColorValue'
        static member darkOrange = CSSColor.darkOrange |> emphasisColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> emphasisColorValue'
        static member darkRed = CSSColor.darkRed |> emphasisColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> emphasisColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> emphasisColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> emphasisColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> emphasisColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> emphasisColorValue'
        static member darkViolet = CSSColor.darkViolet |> emphasisColorValue'
        static member deepPink = CSSColor.deepPink |> emphasisColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> emphasisColorValue'
        static member dimGrey = CSSColor.dimGrey |> emphasisColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> emphasisColorValue'
        static member fireBrick = CSSColor.fireBrick |> emphasisColorValue'
        static member floralWhite = CSSColor.floralWhite |> emphasisColorValue'
        static member forestGreen = CSSColor.forestGreen |> emphasisColorValue'
        static member gainsboro = CSSColor.gainsboro |> emphasisColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> emphasisColorValue'
        static member gold = CSSColor.gold |> emphasisColorValue'
        static member goldenrod = CSSColor.goldenrod |> emphasisColorValue'
        static member greenYellow = CSSColor.greenYellow |> emphasisColorValue'
        static member grey = CSSColor.grey |> emphasisColorValue'
        static member honeydew = CSSColor.honeydew |> emphasisColorValue'
        static member hotPink = CSSColor.hotPink |> emphasisColorValue'
        static member indianRed = CSSColor.indianRed |> emphasisColorValue'
        static member indigo = CSSColor.indigo |> emphasisColorValue'
        static member ivory = CSSColor.ivory |> emphasisColorValue'
        static member khaki = CSSColor.khaki |> emphasisColorValue'
        static member lavender = CSSColor.lavender |> emphasisColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> emphasisColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> emphasisColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> emphasisColorValue'
        static member lightBlue = CSSColor.lightBlue |> emphasisColorValue'
        static member lightCoral = CSSColor.lightCoral |> emphasisColorValue'
        static member lightCyan = CSSColor.lightCyan |> emphasisColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> emphasisColorValue'
        static member lightGray = CSSColor.lightGray |> emphasisColorValue'
        static member lightGreen = CSSColor.lightGreen |> emphasisColorValue'
        static member lightGrey = CSSColor.lightGrey |> emphasisColorValue'
        static member lightPink = CSSColor.lightPink |> emphasisColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> emphasisColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> emphasisColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> emphasisColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> emphasisColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> emphasisColorValue'
        static member lightYellow = CSSColor.lightYellow |> emphasisColorValue'
        static member limeGreen = CSSColor.limeGreen |> emphasisColorValue'
        static member linen = CSSColor.linen |> emphasisColorValue'
        static member magenta = CSSColor.magenta |> emphasisColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> emphasisColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> emphasisColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> emphasisColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> emphasisColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> emphasisColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> emphasisColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> emphasisColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> emphasisColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> emphasisColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> emphasisColorValue'
        static member mintCream = CSSColor.mintCream |> emphasisColorValue'
        static member mistyRose = CSSColor.mistyRose |> emphasisColorValue'
        static member moccasin = CSSColor.moccasin |> emphasisColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> emphasisColorValue'
        static member oldLace = CSSColor.oldLace |> emphasisColorValue'
        static member olivedrab = CSSColor.olivedrab |> emphasisColorValue'
        static member orangeRed = CSSColor.orangeRed |> emphasisColorValue'
        static member orchid = CSSColor.orchid |> emphasisColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> emphasisColorValue'
        static member paleGreen = CSSColor.paleGreen |> emphasisColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> emphasisColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> emphasisColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> emphasisColorValue'
        static member peachpuff = CSSColor.peachpuff |> emphasisColorValue'
        static member peru = CSSColor.peru |> emphasisColorValue'
        static member pink = CSSColor.pink |> emphasisColorValue'
        static member plum = CSSColor.plum |> emphasisColorValue'
        static member powderBlue = CSSColor.powderBlue |> emphasisColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> emphasisColorValue'
        static member royalBlue = CSSColor.royalBlue |> emphasisColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> emphasisColorValue'
        static member salmon = CSSColor.salmon |> emphasisColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> emphasisColorValue'
        static member seaGreen = CSSColor.seaGreen |> emphasisColorValue'
        static member seaShell = CSSColor.seaShell |> emphasisColorValue'
        static member sienna = CSSColor.sienna |> emphasisColorValue'
        static member skyBlue = CSSColor.skyBlue |> emphasisColorValue'
        static member slateBlue = CSSColor.slateBlue |> emphasisColorValue'
        static member slateGray = CSSColor.slateGray |> emphasisColorValue'
        static member snow = CSSColor.snow |> emphasisColorValue'
        static member springGreen = CSSColor.springGreen |> emphasisColorValue'
        static member steelBlue = CSSColor.steelBlue |> emphasisColorValue'
        static member tan = CSSColor.tan |> emphasisColorValue'
        static member thistle = CSSColor.thistle |> emphasisColorValue'
        static member tomato = CSSColor.tomato |> emphasisColorValue'
        static member turquoise = CSSColor.turquoise |> emphasisColorValue'
        static member violet = CSSColor.violet |> emphasisColorValue'
        static member wheat = CSSColor.wheat |> emphasisColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> emphasisColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> emphasisColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> emphasisColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> emphasisColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> emphasisColorValue'
        static member Hex value = CSSColor.Hex value |> emphasisColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> emphasisColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> emphasisColorValue'
        static member transparent = CSSColor.transparent |> emphasisColorValue'
        static member currentColor = CSSColor.currentColor |> emphasisColorValue'

        static member Inherit = Inherit |> emphasisColorValue'
        static member Initial = Initial |> emphasisColorValue'
        static member Unset = Unset |> emphasisColorValue'

    /// <summary>Specifies color of text emphasis.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CSSColor </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextEmphasisColor' (color: ITextEmphasisColor) = TextEmphasisColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-size-adjust
    let private textSizeAdjustValue value = PropertyValue.cssValue Property.TextSizeAdjust value
    let private textSizeAdjustValue' value = value |> textSizeAdjustToString |> textSizeAdjustValue

    type TextSizeAdjust =
        static member Value (textSize: ITextSizeAdjust) = textSize |> textSizeAdjustValue'
        static member Auto = Auto |> textSizeAdjustValue'
        static member None = None |> textSizeAdjustValue'
        static member Inherit = Inherit |> textSizeAdjustValue'
        static member Initial = Initial |> textSizeAdjustValue'
        static member Unset = Unset |> textSizeAdjustValue'

    /// <summary>Controls the text inflation on some mobile browsers.</summary>
    /// <param name="textSize">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextSizeAdjust' textSize = TextSizeAdjust.Value textSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/tab-size
    let private tabSizeValue value = PropertyValue.cssValue Property.TabSize value
    let private tabSizeValue' value = value |> tabSizeToString |> tabSizeValue

    type TabSize =
        static member Value (tabSize: ITabSize) = tabSize |> tabSizeValue'
        static member Inherit = Inherit |> tabSizeValue'
        static member Initial = Initial |> tabSizeValue'
        static member Unset = Unset |> tabSizeValue'

    /// <summary>Specifies the width of tab characters.</summary>
    /// <param name="tabSize">
    ///     can be:
    ///     - <c> Size </c>
    ///     - <c> CssInt </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TabSize' tabSize = TabSize.Value tabSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-orientation
    let private textOrientationValue value = PropertyValue.cssValue Property.TextOrientation value
    let private textOrientationValue' value = value |> textOrientationToString |> textOrientationValue

    type TextOrientation =
        static member Value (orientation: ITextOrientation) = orientation |> textOrientationValue'
        static member Mixed = Mixed |> textOrientationValue'
        static member Upright = Upright |> textOrientationValue'
        static member SidewaysRight = SidewaysRight |> textOrientationValue'
        static member Sideways = Sideways |> textOrientationValue'
        static member UseGlyphOrientation = UseGlyphOrientation |> textOrientationValue'
        static member Inherit = Inherit |> textOrientationValue'
        static member Initial = Initial |> textOrientationValue'
        static member Unset = Unset |> textOrientationValue'

    /// <summary>Sets the orientation of the text characters.</summary>
    /// <param name="orientation">
    ///     can be:
    ///     - <c> TextOrientation </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextOrientation' orientation = TextOrientation.Value orientation

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
    let private textRenderingValue value = PropertyValue.cssValue Property.TextRendering value
    let private textRenderingValue' value = value |> textRenderingToString |> textRenderingValue

    type TextRendering =
        static member Value (rendering: ITextRendering) = rendering |> textRenderingValue'
        static member OptimizeSpeed = OptimizeSpeed |> textRenderingValue'
        static member OptimizeLegibility = OptimizeLegibility |> textRenderingValue'
        static member GeometricPrecision = GeometricPrecision |> textRenderingValue'
        static member Auto = Auto |> textRenderingValue'
        static member Inherit = Inherit |> textRenderingValue'
        static member Initial = Initial |> textRenderingValue'
        static member Unset = Unset |> textRenderingValue'

    /// <summary>Specifies how to render text.</summary>
    /// <param name="rendering">
    ///     can be:
    ///     - <c> TextRendering </c>
    ///     - <c> Global </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextRendering' rendering = TextRendering.Value rendering

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
    let private textJustifyValue value = PropertyValue.cssValue Property.TextJustify value
    let private textJustifyValue' value = value |> textJustifyToString |> textJustifyValue

    type TextJustify =
        static member Value (justification: ITextJustify) = justification |> textJustifyValue'
        static member InterWord = InterWord |> textJustifyValue'
        static member InterCharacter = InterCharacter |> textJustifyValue'
        static member Auto = Auto |> textJustifyValue'
        static member None = None |> textJustifyValue'

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
    let private whiteSpaceValue value = PropertyValue.cssValue Property.WhiteSpace value
    let private whiteSpaceValue' value = value |> whitespaceToString |> whiteSpaceValue

    type WhiteSpace =
        static member Value (whitespace: IWhiteSpace) = whitespace |> whiteSpaceValue'
        static member NoWrap = NoWrap |> whiteSpaceValue'
        static member Pre = Pre |> whiteSpaceValue'
        static member PreWrap = PreWrap |> whiteSpaceValue'
        static member PreLine = PreLine |> whiteSpaceValue'
        static member BreakSpaces = BreakSpaces |> whiteSpaceValue'
        static member Normal = Normal |> whiteSpaceValue'
        static member Inherit = Inherit |> whiteSpaceValue'
        static member Initial = Initial |> whiteSpaceValue'
        static member Unset = Unset |> whiteSpaceValue'

    /// <summary>Specifies how white space is handled.</summary>
    /// <param name="whitespace">
    ///     can be:
    ///     - <c> WhiteSpace </c>
    ///     - <c> Normal </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WhiteSpace' whitespace = WhiteSpace.Value whitespace

    // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
    let private userSelectValue value = PropertyValue.cssValue Property.UserSelect value
    let private userSelectValue' value = value |> userSelectToString |> userSelectValue

    type UserSelect =
        static member Value (whitespace: IUserSelect) = whitespace |> userSelectValue'
        static member Text = Text |> userSelectValue'
        static member Contain = Contain |> userSelectValue'
        static member All = All |> userSelectValue'
        static member None = None |> userSelectValue'
        static member Auto = Auto |> userSelectValue'
        static member Inherit = Inherit |> userSelectValue'
        static member Initial = Initial |> userSelectValue'
        static member Unset = Unset |> userSelectValue'

    /// <summary>Specifies whether the user can select text.</summary>
    /// <param name="userSelect">
    ///     can be:
    ///     - <c> UserSelect </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    ///     - <c> Global </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let UserSelect' userSelect = UserSelect.Value userSelect