namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module PointerEventClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/pointer-events
        type PointerEvent(property) =
            inherit CssRuleWithAutoNone(property)
            member this.visiblePainted = (property, VisiblePainted) |> Rule
            member this.visibleFill = (property, VisibleFill) |> Rule
            member this.visibleStroke = (property, VisibleStroke) |> Rule
            member this.visible = (property, Visible) |> Rule
            member this.painted = (property, Painted) |> Rule
            member this.stroke = (property, Stroke) |> Rule
            member this.all = (property, All) |> Rule
