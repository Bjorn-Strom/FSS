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
        member this.visiblePainted = (property, PointerEvents.VisiblePainted) |> Rule
        member this.visibleFill = (property, PointerEvents.VisibleFill) |> Rule
        member this.visibleStroke = (property, PointerEvents.VisibleStroke) |> Rule
        member this.visible = (property, PointerEvents.Visible) |> Rule
        member this.painted = (property, PointerEvents.Painted) |> Rule
        member this.stroke = (property, PointerEvents.Stroke) |> Rule
        member this.all = (property, PointerEvents.All) |> Rule
