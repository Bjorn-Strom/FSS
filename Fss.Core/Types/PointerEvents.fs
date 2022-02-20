namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module PointerEvents =
    type PointerEvents =
        | VisiblePainted
        | VisibleFill
        | VisibleStroke
        | Visible
        | Painted
        | Stroke
        | All
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module PointerEventClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/pointer-events
    type PointerEvent(property) =
        inherit CssRuleWithAutoNone(property)
        /// Pointer is only visible when the visibility property is set to visible
        member this.visiblePainted = (property, PointerEvents.VisiblePainted) |> Rule
        /// Pointer is only visible when the visibility property is set to visible the content
        member this.visibleFill = (property, PointerEvents.VisibleFill) |> Rule
        /// Pointer is only visible when the visibility property is set to visible and the cursor is over the stroke
        member this.visibleStroke = (property, PointerEvents.VisibleStroke) |> Rule
        /// Pointer is only visible when the visibility property is set to visible the content
        member this.visible = (property, PointerEvents.Visible) |> Rule
        /// Pointer is visible when it is over the interior
        member this.painted = (property, PointerEvents.Painted) |> Rule
        /// Pointer is visible when it is over the stroke
        member this.stroke = (property, PointerEvents.Stroke) |> Rule
        /// Pointer is always visible
        member this.all = (property, PointerEvents.All) |> Rule
