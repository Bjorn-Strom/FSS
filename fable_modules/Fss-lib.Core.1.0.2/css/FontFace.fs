namespace Fss

open Fss.Types

[<RequireQualifiedAccess>]
module FontFace =
    /// Specifies the resource containing the font data.
    let Src = FontFaceClasses.Src(Property.FontFaceProperty.Src)
    /// Specifies how a font face is displayed when it is ready to use
    let FontDisplay = FontFaceClasses.FontDisplay(Property.FontFaceProperty.FontDisplay)
    ///
    let FontStyle = FontFaceClasses.FontStyle(Property.FontFaceProperty.FontStyle)
    ///
    let FontStretch = FontFaceClasses.FontStretch(Property.FontFaceProperty.FontStretch)
    ///
    let FontWeight = FontFaceClasses.FontWeight(Property.FontFaceProperty.FontWeight)
    ///
    let SizeAdjust = FontFaceClasses.SizeAdjust(Property.FontFaceProperty.SizeAdjust)
    ///
    let UnicodeRange = FontFaceClasses.UnicodeRange(Property.FontFaceProperty.UnicodeRange)
    ///
    let LineGapOverride = FontFaceClasses.LineGapOverride(Property.FontFaceProperty.LineGapOverride)
    ///
    let FontVariationSettings = FontFaceClasses.FontVariationSettings(Property.FontFaceProperty.FontVariationSettings)
    ///
    let AscentOverride = FontFaceClasses.AscentDescentOverride(Property.FontFaceProperty.AscentOverride)
    ///
    let DescentOverride = FontFaceClasses.AscentDescentOverride(Property.FontFaceProperty.DescentOverride)
    ///
    let FontFamily = FontFaceClasses.FontFamily(Property.FontFaceProperty.FontFamily)
