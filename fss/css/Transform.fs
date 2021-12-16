namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Transform =
    /// Specifies the origin of an elements transformation.
    let TransformOrigin = Transform.TransformClasses.TransformOrigin(Property.TransformOrigin)
    /// Specifies the whether children of an element are positioned flat or in 3d.
    let TransformStyle = Transform.TransformClasses.TransformStyle(Property.TransformStyle)
    /// Supply a list of transforms to be applied to the element.
    let Transform = Transform.TransformClasses.TransformClass(Property.Transform)
    
    (*
        let stringifyTransform = function

    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransformStyle
    let private styleValue' = styleToString >> styleValue

    
    type TransformStyle =
        static member value (value: FssTypes.ITransformStyle) = value |> styleValue'

        static member flat = FssTypes.Transform.Style.Flat |> styleValue'
        static member preserve3d = FssTypes.Transform.Style.Preserve3d |> styleValue'

        static member inherit' = FssTypes.Inherit |> styleValue'
        static member initial = FssTypes.Initial |> styleValue'
        static member unset = FssTypes.Unset |> styleValue'

    /// Specifies the whether children of an element are positioned flat or in 3d.
    /// Valid parameters
    /// - TransformStyle
    /// - Inherit
    /// - Initial
    /// - Unset
    let TransformStyle' = TransformStyle.value


    *)