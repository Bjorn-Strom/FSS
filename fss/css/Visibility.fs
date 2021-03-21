namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    let private visibilityValue value = Types.propertyHelpers.cssValue Types.Property.Visibility value
    let private visibilityValue' value =
        value
        |> Types.visibilityHelpers.visibilityToString
        |> visibilityValue

    type Visibility =
        static member Value (visibility: Types.IVisibility) = visibility |> visibilityValue'
        static member Visible = Types.Visibility.Visible |> visibilityValue'
        static member Hidden = Types.Visibility.Hidden |> visibilityValue'
        static member Collapse = Types.Visibility.Collapse |> visibilityValue'

        static member Inherit = Types.Inherit |> visibilityValue'
        static member Initial = Types.Initial |> visibilityValue'
        static member Unset = Types.Unset |> visibilityValue'

    /// <summary>Specifies if an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> Visibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Visibility' (visibility: Types.IVisibility) = Visibility.Value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member Value value =
            Types.propertyHelpers.cssValue Types.Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of an element.</summary>
    /// <param name="opacity"> </param>
    /// <returns>Css property for fss.</returns>
    let Opacity' (opacity: float) = Opacity.Value(opacity)


[<AutoOpen>]
module PaintOrder =
    let private paintOrderToString (paintOrder: Types.IPaintOrder) =
        match paintOrder with
        | :? Types.PaintOrder as p -> Utilities.Helpers.duToLowercase p
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | _ -> "unknown paint order"

    let private paintOrderValue value = Types.propertyHelpers.cssValue Types.Property.PaintOrder value
    let private paintOrderValue' value =
        value
        |> paintOrderToString
        |> paintOrderValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
    type PaintOrder =
        static member Value(order: Types.IPaintOrder) = order |> paintOrderValue'
        static member Value(o1: Types.IPaintOrder, o2: Types.IPaintOrder) =
            sprintf "%s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
            |> paintOrderValue
        static member Value(o1: Types.IPaintOrder, o2: Types.IPaintOrder, o3: Types.IPaintOrder) =
            sprintf "%s %s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
                (paintOrderToString o3)
            |> paintOrderValue
        static member Stroke = Types.PaintOrder.Stroke |> paintOrderValue'
        static member Markers = Types.PaintOrder.Markers |> paintOrderValue'
        static member Fill = Types.PaintOrder.Fill |> paintOrderValue'
        static member Normal = Types.Normal |> paintOrderValue'

    /// <summary>Specifies in which order the fill and strokes are drawn.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> PaintOrder </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaintOrder' (order: Types.IPaintOrder) = PaintOrder.Value(order)

