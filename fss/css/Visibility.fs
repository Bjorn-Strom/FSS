namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    let private visibilityValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Visibility value
    let private visibilityValue' value =
        value
        |> FssTypes.visibilityHelpers.visibilityToString
        |> visibilityValue

    type Visibility =
        static member value (visibility: FssTypes.IVisibility) = visibility |> visibilityValue'
        static member visible = FssTypes.Visibility.Visible |> visibilityValue'
        static member hidden = FssTypes.Visibility.Hidden |> visibilityValue'
        static member collapse = FssTypes.Visibility.Collapse |> visibilityValue'

        static member inherit' = FssTypes.Inherit |> visibilityValue'
        static member initial = FssTypes.Initial |> visibilityValue'
        static member unset = FssTypes.Unset |> visibilityValue'

    /// <summary>Specifies if an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> Visibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Visibility' (visibility: FssTypes.IVisibility) = Visibility.value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of an element.</summary>
    /// <param name="opacity"> </param>
    /// <returns>Css property for fss.</returns>
    let Opacity' (opacity: float) = Opacity.value(opacity)


[<AutoOpen>]
module PaintOrder =
    let private paintOrderToString (paintOrder: FssTypes.IPaintOrder) =
        match paintOrder with
        | :? FssTypes.Visibility.PaintOrder as p -> Utilities.Helpers.duToLowercase p
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | _ -> "unknown paint order"

    let private paintOrderValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaintOrder value
    let private paintOrderValue' value =
        value
        |> paintOrderToString
        |> paintOrderValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
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

    /// <summary>Specifies in which order the fill and strokes are drawn.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> PaintOrder </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaintOrder' (order: FssTypes.IPaintOrder) = PaintOrder.value(order)

