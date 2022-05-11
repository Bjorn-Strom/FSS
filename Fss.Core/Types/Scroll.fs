namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Scroll =
    type ScrollBehavior =
        | Smooth
        interface ICssValue with
            member this.StringifyCss() = "smooth"

    type OverscrollBehavior =
        | Contain
        interface ICssValue with
            member this.StringifyCss() = "contain"

    type SnapType =
        | X
        | Y
        | Block
        | Inline
        | Both
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | X -> "x"
                | Y -> "y"
                | Block -> "block"
                | Inline -> "inline"
                | Both -> "both"

    type Viewport =
        | Mandatory of SnapType
        | Proximity of SnapType
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Mandatory s -> $"{stringifyICssValue s} mandatory"
                | Proximity s -> $"{stringifyICssValue s} proximity"

    type SnapAlign =
        | Start
        | End
        | Center
        | Double of SnapAlign * SnapAlign
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | Center -> "center"
                | Double (first, second) -> $"{stringifyICssValue first} {stringifyICssValue second}"

    type SnapStop =
        | Normal
        | Always
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Normal -> "normal"
                | Always -> "always"

[<RequireQualifiedAccess>]
module ScrollClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
    type ScrollBehavior(property) =
        inherit CssRuleWithAuto(property)
        member this.smooth = (property, Scroll.Smooth) |> Rule
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
        member this.contain = (property, Scroll.Contain) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
    type ScrollSnapType(property) =
        inherit CssRuleWithNone(property)
        /// Scroll container snaps to position in the horizontal axis only
        member this.x = (property, Scroll.X) |> Rule
        /// Scroll container snaps to position in the vertical axis only
        member this.y = (property, Scroll.Y) |> Rule
        /// Scroll container snaps to position in the block axis only
        member this.block = (property, Scroll.Block) |> Rule
        /// Scroll container snaps to position in the inline axis only
        member this.inline' = (property, Scroll.Inline) |> Rule
        /// Scroll container snaps to position in both horizontal an vertical axis
        member this.both = (property, Scroll.Both) |> Rule
        member this.mandatory(snapType: Scroll.SnapType) = (property, Scroll.Mandatory snapType) |> Rule
        member this.proximity(snapType: Scroll.SnapType) = (property, Scroll.Proximity snapType) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-align
    type ScrollSnapAlign(property) =
        inherit CssRuleWithNone(property)

        member this.value(first: Scroll.SnapAlign, second: Scroll.SnapAlign) = (property, Scroll.Double(first, second)) |> Rule
        member this.start = (property, Scroll.Start) |> Rule
        member this.end' = (property, Scroll.End) |> Rule
        member this.center = (property, Scroll.Center) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-stop
    type ScrollSnapStop(property) =
        inherit CssRuleWithNormal(property)
        member this.always = (property, Scroll.Always) |> Rule
