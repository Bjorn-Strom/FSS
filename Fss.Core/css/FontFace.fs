namespace Fss

open Fss.Types

[<RequireQualifiedAccess>]
module FontFace =
    /// Specifies the resource containing the font data.
    let Src = FontFaceClasses.Src(FontFaceProperty.Src)
    /// Specifies how a font face is displayed when it is ready to use
    let FontDisplay = FontFaceClasses.FontDisplay(FontFaceProperty.FontDisplay)
    ///
    let FontStyle = FontFaceClasses.FontStyle(FontFaceProperty.FontStyle)
    ///
    let FontStretch = FontFaceClasses.FontStretch(FontFaceProperty.FontStretch)
    ///
    let FontWeight = FontFaceClasses.FontWeight(FontFaceProperty.FontWeight)
    ///
    let SizeAdjust = FontFaceClasses.SizeAdjust(FontFaceProperty.SizeAdjust)
    ///
    let UnicodeRange = FontFaceClasses.UnicodeRange(FontFaceProperty.UnicodeRange)
    ///
    let LineGapOverride = FontFaceClasses.LineGapOverride(FontFaceProperty.LineGapOverride)
    ///
    let FontVariationSettings = FontFaceClasses.FontVariationSettings(FontFaceProperty.FontVariationSettings)
    ///
    let AscentOverride = FontFaceClasses.AscentDescentOverride(FontFaceProperty.AscentOverride)
    ///
    let DescentOverride = FontFaceClasses.AscentDescentOverride(FontFaceProperty.DescentOverride)
    ///
    let FontFamily = FontFaceClasses.FontFamily(FontFaceProperty.FontFamily)
