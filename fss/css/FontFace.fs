namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module FontFace =
    /// Specifies the resource containing the font data.
    let Src =
        FontFace.FontFaceClasses.Src(FontFaceProperty.Src)
    /// Specifies how a font face is displayed when it is ready to use
    let FontDisplay =
        FontFace.FontFaceClasses.FontDisplay(FontFaceProperty.FontDisplay)
    ///
    let FontStyle =
        FontFace.FontFaceClasses.FontStyle(FontFaceProperty.FontStyle)
    ///
    let FontStretch =
        FontFace.FontFaceClasses.FontStretch(FontFaceProperty.FontStretch)
    ///
    let FontWeight =
        FontFace.FontFaceClasses.FontWeight(FontFaceProperty.FontWeight)
    ///
    let SizeAdjust =
        FontFace.FontFaceClasses.SizeAdjust(FontFaceProperty.SizeAdjust)
    ///
    let UnicodeRange =
        FontFace.FontFaceClasses.UnicodeRange(FontFaceProperty.UnicodeRange)
    ///
    let LineGapOverride =
        FontFace.FontFaceClasses.LineGapOverride(FontFaceProperty.LineGapOverride)
    ///
    let FontVariationSettings =
        FontFace.FontFaceClasses.FontVariationSettings(FontFaceProperty.FontVariationSettings)
    ///
    let AscentOverride =
        FontFace.FontFaceClasses.AscentDescentOverride(FontFaceProperty.AscentOverride)
    ///
    let DescentOverride =
        FontFace.FontFaceClasses.AscentDescentOverride(FontFaceProperty.DescentOverride)
    ///
    let FontFamily =
        FontFace.FontFaceClasses.FontFamily(FontFaceProperty.FontFamily)
