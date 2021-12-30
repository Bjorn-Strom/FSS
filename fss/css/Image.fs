namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module ObjectFit =
    /// Specifies how the content should be resized to fit its container.
    let ObjectFit = ImageClasses.ObjectFit(Property.ObjectFit)
    /// Specifies the alignment within the elements box
    let ObjectPosition = ImageClasses.ObjectPosition(Property.ObjectPosition)
    /// Specifies how an image is to be resized
    let ImageRendering = ImageClasses.ImageRendering(Property.ImageRendering)
