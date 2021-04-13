namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    let private visibilityValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Visibility
    let private visibilityValue' = FssTypes.visibilityHelpers.visibilityToString >> visibilityValue

    [<Erase>]
    /// Specifies if an element is visible.
    type Visibility =
        static member value (visibility: FssTypes.IVisibility) = visibility |> visibilityValue'
        static member visible = FssTypes.Visibility.Visible |> visibilityValue'
        static member hidden = FssTypes.Visibility.Hidden |> visibilityValue'
        static member collapse = FssTypes.Visibility.Collapse |> visibilityValue'

        static member inherit' = FssTypes.Inherit |> visibilityValue'
        static member initial = FssTypes.Initial |> visibilityValue'
        static member unset = FssTypes.Unset |> visibilityValue'

    /// Specifies if an element is visible.
    /// Valid parameters:
    /// - Visibility
    /// - Inherit
    /// - Initial
    /// - Unset
    let Visibility' = Visibility.value

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    [<Erase>]
    /// Specifies the opacity of an element.
    type Opacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// Specifies the opacity of an element.
    let Opacity' = Opacity.value


[<AutoOpen>]
module PaintOrder =
    let private paintOrderToString (paintOrder: FssTypes.IPaintOrder) =
        match paintOrder with
        | :? FssTypes.Visibility.PaintOrder as p -> Utilities.Helpers.duToLowercase p
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "unknown paint order"

    let private paintOrderValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaintOrder
    let private paintOrderValue' = paintOrderToString >> paintOrderValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
    [<Erase>]
    /// Specifies in which order the fill and strokes are drawn.
    type PaintOrder =
        static member value(order: FssTypes.IPaintOrder) = order |> paintOrderValue'
        static member value(o1: FssTypes.IPaintOrder, o2: FssTypes.IPaintOrder) =
            sprintf "%s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
            |> paintOrderValue
        static member value(o1: FssTypes.IPaintOrder, o2: FssTypes.IPaintOrder, o3: FssTypes.IPaintOrder) =
            sprintf "%s %s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
                (paintOrderToString o3)
            |> paintOrderValue
        static member stroke = FssTypes.Visibility.PaintOrder.Stroke |> paintOrderValue'
        static member markers = FssTypes.Visibility.PaintOrder.Markers |> paintOrderValue'
        static member fill = FssTypes.Visibility.PaintOrder.Fill |> paintOrderValue'
        static member normal = FssTypes.Normal |> paintOrderValue'

    /// Specifies in which order the fill and strokes are drawn.
    /// - PaintOrder
    /// - Normal
    let PaintOrder' = PaintOrder.value

