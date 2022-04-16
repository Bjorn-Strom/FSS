namespace Fss

open Fss.Types

[<AutoOpen>]
module Font =
    /// Specifies which missing typefaces can be synthesized by the browser.
    let FontSynthesis = FontClasses.FontSynthesis(Property.CssProperty.FontSynthesis)
    /// Controls the use of language-specific glyph
    let FontLanguageOverride = FontClasses.FontLanguageOverride(Property.CssProperty.FontLanguageOverride)
    /// Specifies use of font-kerning.
    let FontKerning = FontClasses.FontKerning(Property.CssProperty.FontKerning)
    /// Sets size of font.
    let FontSize = FontClasses.FontSize(Property.CssProperty.FontSize)
    /// Specifies width of text characters to be wider or narrower default width.
    let FontStretch = FontClasses.FontStretch(Property.CssProperty.FontStretch)
    /// Specifies which style to use on a font.
    let FontStyle = FontClasses.FontStyle(Property.CssProperty.FontStyle)
    /// Specifies weight(boldness) of font.
    let FontWeight = FontClasses.FontWeight(Property.CssProperty.FontWeight)
    /// Specifies the amount of space above and below inline elements.
    let LineHeight = FontClasses.LineHeight(Property.CssProperty.LineHeight)
    /// Specifies how some asian languages wrap text on newlines.
    let LineBreak = FontClasses.LineBreak(Property.CssProperty.LineBreak)
    /// Sets horizontal spacing between text characters.
    let LetterSpacing = FontClasses.LetterSpacing(Property.CssProperty.LetterSpacing)
    /// Specify which font to use
    let FontFamily = FontClasses.FontFamily(Property.CssProperty.FontFamily)
    /// Specify more advanced typographic settings.
    let FontFeatureSettings = FontClasses.FontFeatureSettings(Property.CssProperty.FontFeatureSettings)
    /// Specifies numeric glyphs.
    let FontVariantNumeric = FontClasses.FontVariantNumeric(Property.CssProperty.FontVariantNumeric)
    /// Specify alternate glyphs for capital letters.
    let FontVariantCaps = FontClasses.FontVariantCaps(Property.CssProperty.FontVariantCaps)
    /// Specifies alternate glyphs for East Asian languages.
    let FontVariantEastAsian = FontClasses.FontVariantEastAsian(Property.CssProperty.FontVariantEastAsian)
    /// Specifies which ligatures are used.
    let FontVariantLigatures = FontClasses.FontVariantLigatures(Property.CssProperty.FontVariantLigatures)
    /// Specifies which missing typefaces can be synthesized by the browser.
    let FontVariantPosition = FontClasses.FontVariantPosition(Property.CssProperty.FontVariantPosition)
