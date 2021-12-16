namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Text =
    /// Specifies the horizontal alignment of text.
    let TextAlign =
        Text.TextClasses.TextAlign(Property.TextAlign)
    /// Specifies the horizontal alignment of the last line of text.
    let TextAlignLast =
        Text.TextClasses.TextAlign(Property.TextAlignLast)
    /// Resets text decoration.
    let TextDecoration =
        Text.TextClasses.TextDecoration(Property.TextDecoration)
    /// Specifies how to decorate text.
    let TextDecorationLine =
        Text.TextClasses.TextDecorationLine(Property.TextDecorationLine)
    /// Specifies what parts of decoration should be skipped.
    let TextDecorationSkip =
        Text.TextClasses.TextDecorationSkip(Property.TextDecorationSkip)
    /// Specifies thickness of text decoration.
    let TextDecorationThickness =
        Text.TextClasses.TextDecorationThickness(Property.TextDecorationThickness)
    /// Specifies style of text decoration.
    let TextDecorationStyle =
        Text.TextClasses.TextDecorationStyle(Property.TextDecorationStyle)
    /// Specifies what parts of decoration should be skipped.
    let TextDecorationSkipInk =
        Text.TextClasses.TextDecorationSkipInk(Property.TextDecorationSkipInk)
    /// Specifies what parts of text to capitalize.
    let TextTransform =
        Text.TextClasses.TextTransform(Property.TextTransform)
    /// Specifies how much indentation is put before lines of text.
    let TextIndent =
        Text.TextClasses.TextIndent(Property.TextIndent)
    /// Supply a list of text shadows to apply to the text
    let TextShadow =
        Text.TextClasses.TextShadow(Property.TextShadow)
    /// If there is hidden content this specifies how that is signalled.
    let TextOverflow =
        Text.TextClasses.TextOverflow(Property.TextOverflow)
    /// Specifies emphasis marks to text.
    let TextEmphasis =
        Text.TextClasses.TextEmphasis(Property.TextEmphasis)
    /// Specifies where emphasis marks are drawn.
    let TextEmphasisPosition =
        Text.TextClasses.TextEmphasisPosition(Property.TextEmphasisPosition)
    /// Specifies style of text emphasis.
    let TextEmphasisStyle =
        Text.TextClasses.TextEmphasisStyle(Property.TextEmphasisStyle)
    /// Specifies the position of text underline.
    let TextUnderlinePosition =
        Text.TextClasses.TextUnderlinePosition(Property.TextUnderlinePosition)
    /// Specifies the offset of text underline.
    let TextUnderlineOffset =
        Text.TextClasses.TextUnderlineOffset(Property.TextUnderlineOffset)
    /// Specifies how to render quotation marks.
    let Quotes = Text.TextClasses.Quotes(Property.Quotes)
    /// Specifies words will be hyphenated when text wraps.
    let Hyphens =
        Text.TextClasses.Hyphens(Property.Hyphens)
    /// Specifies color of text decoration.
    let TextDecorationColor =
        Text.TextClasses.TextDecorationColor(Property.TextDecorationColor)
    /// Specifies color of text emphasis.
    let TextEmphasisColor =
        Text.TextClasses.TextEmphasisColor(Property.TextEmphasisColor)
    /// Controls the text inflation on some mobile browsers.
    let TextSizeAdjust =
        Text.TextClasses.TextSizeAdjust(Property.TextSizeAdjust)
    /// Specifies the width of tab characters.
    let TabSize =
        Text.TextClasses.TabSize(Property.TabSize)
    /// Sets the orientation of the text characters.
    let TextOrientation =
        Text.TextClasses.TextOrientation(Property.TextOrientation)
    /// Specifies how to render text.
    let TextRendering =
        Text.TextClasses.TextRendering(Property.TextRendering)
    /// Specifies how to justify text.
    let TextJustify =
        Text.TextClasses.TextJustify(Property.TextJustify)
    /// Specifies how white space is handled.
    let WhiteSpace =
        Text.TextClasses.WhiteSpace(Property.WhiteSpace)
    /// Specifies whether the user can select text.
    let UserSelect =
        Text.TextClasses.UserSelect(Property.UserSelect)
    /// Specifies whether the user can select text.
    let HangingPunctuation =
        Text.TextClasses.HangingPunctuationClass(Property.HangingPunctuation)
