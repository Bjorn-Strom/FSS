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
        static member Value (visibility: FssTypes.IVisibility) = visibility |> visibilityValue'
        static member Visible = FssTypes.Visibility.Visible |> visibilityValue'
        static member Hidden = FssTypes.Visibility.Hidden |> visibilityValue'
        static member Collapse = FssTypes.Visibility.Collapse |> visibilityValue'

        static member Inherit = FssTypes.Inherit |> visibilityValue'
        static member Initial = FssTypes.Initial |> visibilityValue'
        static member Unset = FssTypes.Unset |> visibilityValue'

    /// <summary>Specifies if an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> Visibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Visibility' (visibility: FssTypes.IVisibility) = Visibility.Value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member Value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of an element.</summary>
    /// <param name="opacity"> </param>
    /// <returns>Css property for fss.</returns>
    let Opacity' (opacity: float) = Opacity.Value(opacity)


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
        static member Value(order: FssTypes.IPaintOrder) = order |> paintOrderValue'
        static member Value(o1: FssTypes.IPaintOrder, o2: FssTypes.IPaintOrder) =
            sprintf "%s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
            |> paintOrderValue
        static member Value(o1: FssTypes.IPaintOrder, o2: FssTypes.IPaintOrder, o3: FssTypes.IPaintOrder) =
            sprintf "%s %s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
                (paintOrderToString o3)
            |> paintOrderValue
        static member Stroke = FssTypes.Visibility.PaintOrder.Stroke |> paintOrderValue'
        static member Markers = FssTypes.Visibility.PaintOrder.Markers |> paintOrderValue'
        static member Fill = FssTypes.Visibility.PaintOrder.Fill |> paintOrderValue'
        static member Normal = FssTypes.Normal |> paintOrderValue'

    /// <summary>Specifies in which order the fill and strokes are drawn.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> PaintOrder </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaintOrder' (order: FssTypes.IPaintOrder) = PaintOrder.Value(order)

