namespace Fss

open Fss.Types

[<AutoOpen>]
module Transform =
    /// Specifies the origin of an elements transformation.
    let TransformOrigin = TransformClasses.TransformOrigin(Property.TransformOrigin)
    /// Specifies the whether children of an element are positioned flat or in 3d.
    let TransformStyle = TransformClasses.TransformStyle(Property.TransformStyle)
    /// Supply a list of transforms to be applied to the element.
    let Transform = TransformClasses.TransformClass(Property.Transform)