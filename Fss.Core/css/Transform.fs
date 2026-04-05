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
    /// Standalone translate property. Independently animatable.
    let Translate = TransformClasses.TranslateProperty(Property.Translate)
    /// Standalone rotate property. Independently animatable.
    let Rotate = TransformClasses.RotateProperty(Property.Rotate)
    /// Standalone scale property. Independently animatable.
    let Scale = TransformClasses.ScaleProperty(Property.Scale)