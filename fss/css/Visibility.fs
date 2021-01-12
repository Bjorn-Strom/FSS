namespace Fss

module VisibilityType =
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

    let visibilityToString (visibility: IVisibility) =
        match visibility with
        | :? Visibility as v -> Utilities.Helpers.duToLowercase v
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown visibility"

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    open VisibilityType

    let private visibilityValue value = PropertyValue.cssValue Property.Visibility value
    let private visibilityValue' value =
        value
        |> visibilityToString
        |> visibilityValue

    type Visibility =
        static member Value (visibility: IVisibility) = visibility |> visibilityValue'
        static member Visible = Visible |> visibilityValue'
        static member Hidden = Hidden |> visibilityValue'
        static member Collapse = Collapse |> visibilityValue'

        static member Inherit = Inherit |> visibilityValue'
        static member Initial = Initial |> visibilityValue'
        static member Unset = Unset |> visibilityValue'

    /// <summary>Specifies if an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> Visibility </c> 
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Visibility' (visibility: IVisibility) = Visibility.Value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member Value value =
            PropertyValue.cssValue Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of an element.</summary>
    /// <param name="opacity"> </param>
    /// <returns>Css property for fss.</returns>
    let Opacity' (opacity: float) = Opacity.Value(opacity)

module PaintOrderTypes =
    type PaintOrder =
        | Stroke
        | Markers
        | Fill
        interface IPaintOrder

[<AutoOpen>]
module PaintOrder =
    open PaintOrderTypes

    let private paintOrderToString (paintOrder: IPaintOrder) =
        match paintOrder with
        | :? PaintOrder as p -> Utilities.Helpers.duToLowercase p
        | :? Normal -> GlobalValue.normal
        | _ -> "unknown paint order"

    let private paintOrderValue value = PropertyValue.cssValue Property.PaintOrder value
    let private paintOrderValue' value =
        value
        |> paintOrderToString
        |> paintOrderValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
    type PaintOrder =
        static member Value(order: IPaintOrder) = order |> paintOrderValue'
        static member Value(o1: IPaintOrder, o2: IPaintOrder) =
            sprintf "%s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
            |> paintOrderValue
        static member Value(o1: IPaintOrder, o2: IPaintOrder, o3: IPaintOrder) =
            sprintf "%s %s %s"
                (paintOrderToString o1)
                (paintOrderToString o2)
                (paintOrderToString o3)
            |> paintOrderValue
        static member Stroke = Stroke |> paintOrderValue'
        static member Markers = Markers |> paintOrderValue'
        static member Fill = Fill |> paintOrderValue'
        static member Normal = Normal |> paintOrderValue'

    /// <summary>Specifies in which order the fill and strokes are drawn.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> PaintOrder </c> 
    ///     - <c> Normal </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaintOrder' (order: IPaintOrder) = PaintOrder.Value(order)

