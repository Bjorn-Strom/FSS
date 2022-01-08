namespace Fss

open Fss.Types

[<AutoOpen>]
module Text =
    /// Specifies the horizontal alignment of text.
    let TextAlign = TextClasses.TextAlign(Property.TextAlign)
    /// Specifies the horizontal alignment of the last line of text.
    let TextAlignLast = TextClasses.TextAlign(Property.TextAlignLast)
    /// Resets text decoration.
    let TextDecoration = TextClasses.TextDecoration(Property.TextDecoration)
    /// Specifies how to decorate text.
    let TextDecorationLine = TextClasses.TextDecorationLine(Property.TextDecorationLine)
    /// Specifies what parts of decoration should be skipped.
    let TextDecorationSkip = TextClasses.TextDecorationSkip(Property.TextDecorationSkip)
    /// Specifies thickness of text decoration.
    let TextDecorationThickness = TextClasses.TextDecorationThickness(Property.TextDecorationThickness)
    /// Specifies style of text decoration.
    let TextDecorationStyle = TextClasses.TextDecorationStyle(Property.TextDecorationStyle)
    /// Specifies what parts of decoration should be skipped.
    let TextDecorationSkipInk = TextClasses.TextDecorationSkipInk(Property.TextDecorationSkipInk)
    /// Specifies what parts of text to capitalize.
    let TextTransform = TextClasses.TextTransform(Property.TextTransform)
    /// Specifies how much indentation is put before lines of text.
    let TextIndent = TextClasses.TextIndent(Property.TextIndent)
    /// Supply a list of text shadows to apply to the text
    let TextShadow = TextClasses.TextShadow(Property.TextShadow)
    /// If there is hidden content this specifies how that is signalled.
    let TextOverflow = TextClasses.TextOverflow(Property.TextOverflow)
    /// Specifies emphasis marks to text.
    let TextEmphasis = TextClasses.TextEmphasis(Property.TextEmphasis)
    /// Specifies where emphasis marks are drawn.
    let TextEmphasisPosition = TextClasses.TextEmphasisPosition(Property.TextEmphasisPosition)
    /// Specifies style of text emphasis.
    let TextEmphasisStyle = TextClasses.TextEmphasisStyle(Property.TextEmphasisStyle)
    /// Specifies the position of text underline.
    let TextUnderlinePosition = TextClasses.TextUnderlinePosition(Property.TextUnderlinePosition)
    /// Specifies the offset of text underline.
    let TextUnderlineOffset = TextClasses.TextUnderlineOffset(Property.TextUnderlineOffset)
    /// Specifies how to render quotation marks.
    let Quotes = TextClasses.Quotes(Property.Quotes)
    /// Specifies words will be hyphenated when text wraps.
    let Hyphens = TextClasses.Hyphens(Property.Hyphens)
    /// Specifies color of text decoration.
    let TextDecorationColor = TextClasses.TextDecorationColor(Property.TextDecorationColor)
    /// Specifies color of text emphasis.
    let TextEmphasisColor = TextClasses.TextEmphasisColor(Property.TextEmphasisColor)
    /// Controls the text inflation on some mobile browsers.
    let TextSizeAdjust = TextClasses.TextSizeAdjust(Property.TextSizeAdjust)
    /// Specifies the width of tab characters.
    let TabSize = TextClasses.TabSize(Property.TabSize)
    /// Sets the orientation of the text characters.
    let TextOrientation = TextClasses.TextOrientation(Property.TextOrientation)
    /// Specifies how to render text.
    let TextRendering = TextClasses.TextRendering(Property.TextRendering)
    /// Specifies how to justify text.
    let TextJustify = TextClasses.TextJustify(Property.TextJustify)
    /// Specifies how white space is handled.
    let WhiteSpace = TextClasses.WhiteSpace(Property.WhiteSpace)
    /// Specifies whether the user can select text.
    let UserSelect = TextClasses.UserSelect(Property.UserSelect)
    /// Specifies whether the user can select text.
    let HangingPunctuation = TextClasses.HangingPunctuationClass(Property.HangingPunctuation)
