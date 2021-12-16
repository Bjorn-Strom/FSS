namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Mask =
    /// Specifies which area is affected by a mask.
    let MaskClip =
        Mask.MaskClasses.MaskClip(Property.MaskClip)
    /// Allows composing of masks with masks under it.
    let MaskComposite =
        Mask.MaskClasses.MaskComposite(Property.MaskComposite)
    /// Specifies an image to use as a mask
    let MaskImage =
        Mask.MaskClasses.MaskImage(Property.MaskImage)
    /// Specifies the mdoe of the mask
    let MaskMode =
        Mask.MaskClasses.MaskMode(Property.MaskMode)
    /// Specifies the origin of the mask
    let MaskOrigin =
        Mask.MaskClasses.MaskOrigin(Property.MaskOrigin)
    /// Specifies the position of the mask
    let MaskPosition =
        Mask.MaskClasses.MaskPosition(Property.MaskPosition)
    /// Specifies how masks are repeated
    let MaskRepeat =
        Mask.MaskClasses.MaskRepeat(Property.MaskRepeat)
    /// Specifies size of masks
    let MaskSize =
        Mask.MaskClasses.MaskSize(Property.MaskSize)
