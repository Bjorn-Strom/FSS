namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Scroll =
    type ScrollBehavior =
        | Smooth
        interface ICssValue with
            member this.Stringify() = "smooth"

    type OverscrollBehavior =
        | Contain
        interface ICssValue with
            member this.Stringify() = "contain"

    type SnapType =
        | X
        | Y
        | Block
        | Inline
        | Both
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Viewport =
        | Mandatory of SnapType
        | Proximity of SnapType
        interface ICssValue with
            member this.Stringify() =
                match this with
                | Mandatory s -> $"{(s :> ICssValue).Stringify()} mandatory"
                | Proximity s -> $"{(s :> ICssValue).Stringify()} proximity"

    type SnapAlign =
        | Start
        | End
        | Center
        | Double of SnapAlign * SnapAlign
        interface ICssValue with
            member this.Stringify() =
                match this with
                | Double (first, second) -> $"{(first :> ICssValue).Stringify()} {(second :> ICssValue).Stringify()}"
                | _ -> this.ToString().ToLower()

    type SnapStop =
        | Normal
        | Always
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module ScrollClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
        type ScrollBehavior(property) =
            inherit CssRuleWithAuto(property)
            member this.smooth = (property, Smooth) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
        type ScrollMargin(property) =
            inherit DirectionalLength(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin-top
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin-right
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin-bottom
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin-left
        type ScrollMarginDirection(property) =
            inherit CssRuleWithLength(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding
        type ScrollPadding(property) =
            inherit DirectionalLength(property)
            member this.auto = (property, Auto)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding-top
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding-right
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding-bottom
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding-left
        type ScrollPaddingDirection(property) =
            inherit CssRuleWithLength(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
        type OverScrollBehavior(property) =
            inherit CssRuleWithAutoNone(property)
            member this.contain = (property, Contain) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
        type ScrollSnapType(property) =
            inherit CssRuleWithNone(property)
            member this.x = (property, X) |> Rule
            member this.y = (property, Y) |> Rule
            member this.block = (property, Block) |> Rule
            member this.inline' = (property, Inline) |> Rule
            member this.both = (property, Both) |> Rule
            member this.mandatory(snapType: SnapType) = (property, Mandatory snapType) |> Rule
            member this.proximity(snapType: SnapType) = (property, Proximity snapType) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-align
        type ScrollSnapAlign(property) =
            inherit CssRuleWithNone(property)

            member this.value(first: SnapAlign, second: SnapAlign) =
                (property, Double(first, second)) |> Rule

            member this.start = (property, Start) |> Rule
            member this.end' = (property, End) |> Rule
            member this.center = (property, Center) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-stop
        type ScrollSnapStop(property) =
            inherit CssRuleWithNormal(property)
            member this.always = (property, Always) |> Rule
