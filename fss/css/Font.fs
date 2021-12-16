namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Font =
    // TODO: Add font display to font face
    /// Specifies which missing typefaces can be synthesized by the browser.
    let FontSynthesis =
        Font.FontClasses.FontSynthesis(Property.FontSynthesis)
    /// Controls the use of language-specific glyph
    let FontLanguageOverride =
        Font.FontClasses.FontLanguageOverride(Property.FontLanguageOverride)
    /// Specifies use of font-kerning.
    let FontKerning =
        Font.FontClasses.FontKerning(Property.FontKerning)
    /// Sets size of font.
    let FontSize =
        Font.FontClasses.FontSize(Property.FontSize)
    /// Specifies width of text characters to be wider or narrower default width.
    let FontStretch =
        Font.FontClasses.FontStretch(Property.FontStretch)
    /// Specifies which style to use on a font.
    let FontStyle =
        Font.FontClasses.FontStyle(Property.FontStyle)
    /// Specifies weight(boldness) of font.
    let FontWeight =
        Font.FontClasses.FontWeight(Property.FontWeight)
    /// Specifies the amount of space above and below inline elements.
    let LineHeight =
        Font.FontClasses.LineHeight(Property.LineHeight)
    /// Specifies how some asian languages wrap text on newlines.
    let LineBreak =
        Font.FontClasses.LineBreak(Property.LineBreak)
    /// Sets horizontal spacing between text characters.
    let LetterSpacing =
        Font.FontClasses.LetterSpacing(Property.LetterSpacing)
    /// Specify which font to use
    let FontFamily =
        Font.FontClasses.FontFamily(Property.FontFamily)
    /// Specify more advanced typographic settings.
    let FontFeatureSettings =
        Font.FontClasses.FontFeatureSettings(Property.FontFeatureSettings)
    /// Specifies numeric glyphs.
    let FontVariantNumeric =
        Font.FontClasses.FontVariantNumeric(Property.FontVariantNumeric)
    /// Specify alternate glyphs for capital letters.
    let FontVariantCaps =
        Font.FontClasses.FontVariantCaps(Property.FontVariantCaps)
    /// Specifies alternate glyphs for East Asian languages.
    let FontVariantEastAsian =
        Font.FontClasses.FontVariantEastAsian(Property.FontVariantEastAsian)
    /// Specifies which ligatures are used.
    let FontVariantLigatures =
        Font.FontClasses.FontVariantLigatures(Property.FontVariantLigatures)
    /// Specifies which missing typefaces can be synthesized by the browser.
    let FontVariantPosition =
        Font.FontClasses.FontVariantPosition(Property.FontVariantPosition)
