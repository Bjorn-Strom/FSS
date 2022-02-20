namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Visibility =
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type BackfaceVisibility =
        | Visible
        | Hidden
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module VisibilityClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
    type Visibility(property) =
        inherit CssRule(property)
        /// The element is visible
        member this.visible = (property, Visibility.Visible) |> Rule
        /// The element is not visible
        member this.hidden = (property, Visibility.Hidden) |> Rule
        /// For table rows, columns, column groups and row groups the rows or column are hidden and their space removed.
        /// For flex items they are hidden and they space removed
        /// For anything else they are hidden
        member this.collapse = (property, Visibility.Collapse) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
    type Opacity(property) =
        inherit CssRule(property)

        member this.value(opacity: float) =
            let value =
                if opacity > 1 then 1.0
                else if opacity < 0 then 0.0
                else opacity

            (property, Float value) |> Rule

        member this.value(opacity: Percent) = (property, opacity) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/z-index
    type ZIndex(property) =
        inherit CssRuleWithAuto(property)
        member this.value(zindex: int) = (property, Int zindex) |> Rule


[<RequireQualifiedAccess>]
module PaintOrder =
    type PaintOrder =
        | Stroke
        | Markers
        | Fill
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

// https://developer.mozilla.org/en-US/docs/Web/CSS/paint-order
[<RequireQualifiedAccess>]
module PaintOrderClasses =
    type PaintOrderClass(property) =
        inherit CssRuleWithValueFunctions<PaintOrder.PaintOrder>(property, " ")
        member this.stroke = (property, PaintOrder.Stroke) |> Rule
        member this.markers = (property, PaintOrder.Markers) |> Rule
        member this.fill = (property, PaintOrder.Fill) |> Rule
        member this.normal = (property, Normal) |> Rule