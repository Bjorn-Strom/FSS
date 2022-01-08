namespace Fss

open Fss.Types

[<AutoOpen>]
module Mask =
    /// Specifies which area is affected by a mask.
    let MaskClip = MaskClasses.MaskClip(Property.MaskClip)
    /// Allows composing of masks with masks under it.
    let MaskComposite = MaskClasses.MaskComposite(Property.MaskComposite)
    /// Specifies an image to use as a mask
    let MaskImage = MaskClasses.MaskImage(Property.MaskImage)
    /// Specifies the mdoe of the mask
    let MaskMode = MaskClasses.MaskMode(Property.MaskMode)
    /// Specifies the origin of the mask
    let MaskOrigin = MaskClasses.MaskOrigin(Property.MaskOrigin)
    /// Specifies the position of the mask
    let MaskPosition = MaskClasses.MaskPosition(Property.MaskPosition)
    /// Specifies how masks are repeated
    let MaskRepeat = MaskClasses.MaskRepeat(Property.MaskRepeat)
    /// Specifies size of masks
    let MaskSize = MaskClasses.MaskSize(Property.MaskSize)
