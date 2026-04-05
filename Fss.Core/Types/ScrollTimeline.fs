namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module ScrollTimeline =
    type Scroller =
        | Nearest
        | Root
        | Self
        member this.Stringify() =
            match this with
            | Nearest -> "nearest"
            | Root -> "root"
            | Self -> "self"

    type Axis =
        | Block
        | Inline
        | X
        | Y
        member this.Stringify() =
            match this with
            | Block -> "block"
            | Inline -> "inline"
            | X -> "x"
            | Y -> "y"

    type Timeline =
        | Auto
        | None'
        | Scroll of Scroller option * Axis option
        | View of Axis option
        | ViewWithInset of Axis * string
        | Named of string
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Auto -> "auto"
                | None' -> "none"
                | Scroll (scroller, axis) ->
                    match scroller, axis with
                    | Some s, Some a -> $"scroll({s.Stringify()} {a.Stringify()})"
                    | Some s, None -> $"scroll({s.Stringify()})"
                    | None, Some a -> $"scroll({a.Stringify()})"
                    | None, None -> "scroll()"
                | View (axis) ->
                    match axis with
                    | Some a -> $"view({a.Stringify()})"
                    | None -> "view()"
                | ViewWithInset (axis, inset) ->
                    $"view({axis.Stringify()} {inset})"
                | Named name -> name

    type RangeKeyword =
        | Normal
        | Cover
        | Contain
        | Entry
        | Exit
        | EntryCrossing
        | ExitCrossing
        member this.Stringify() =
            match this with
            | Normal -> "normal"
            | Cover -> "cover"
            | Contain -> "contain"
            | Entry -> "entry"
            | Exit -> "exit"
            | EntryCrossing -> "entry-crossing"
            | ExitCrossing -> "exit-crossing"

[<RequireQualifiedAccess>]
module ScrollTimelineClasses =
    type AnimationTimeline(property) =
        inherit CssRuleWithAutoNone(property)
        /// Scroll-driven timeline
        member this.scroll() =
            (property, ScrollTimeline.Scroll(None, None)) |> Rule
        /// Scroll-driven timeline with scroller
        member this.scroll(scroller: ScrollTimeline.Scroller) =
            (property, ScrollTimeline.Scroll(Some scroller, None)) |> Rule
        /// Scroll-driven timeline with axis
        member this.scroll(axis: ScrollTimeline.Axis) =
            (property, ScrollTimeline.Scroll(None, Some axis)) |> Rule
        /// Scroll-driven timeline with scroller and axis
        member this.scroll(scroller: ScrollTimeline.Scroller, axis: ScrollTimeline.Axis) =
            (property, ScrollTimeline.Scroll(Some scroller, Some axis)) |> Rule
        /// View-driven timeline
        member this.view() =
            (property, ScrollTimeline.View(None)) |> Rule
        /// View-driven timeline with axis
        member this.view(axis: ScrollTimeline.Axis) =
            (property, ScrollTimeline.View(Some axis)) |> Rule
        /// View-driven timeline with axis and inset
        member this.view(axis: ScrollTimeline.Axis, inset: string) =
            (property, ScrollTimeline.ViewWithInset(axis, inset)) |> Rule
        /// Named timeline reference
        member this.named(name: string) =
            (property, ScrollTimeline.Named(name)) |> Rule

    type ScrollTimelineName(property) =
        inherit CssRuleWithNone(property)
        member this.value(name: string) = (property, String name) |> Rule

    type ScrollTimelineAxis(property) =
        inherit CssRule(property)
        member this.block = (property, String "block") |> Rule
        member this.inline' = (property, String "inline") |> Rule
        member this.x = (property, String "x") |> Rule
        member this.y = (property, String "y") |> Rule

    type AnimationRange(property) =
        inherit CssRuleWithNormal(property)
        /// Set animation range with a keyword
        member this.value(keyword: ScrollTimeline.RangeKeyword) =
            (property, String (keyword.Stringify())) |> Rule
        /// Set animation range with keyword and percentage
        member this.value(keyword: ScrollTimeline.RangeKeyword, pct: Percent) =
            (property, String $"{keyword.Stringify()} {lengthPercentageString pct}") |> Rule
        /// Set animation range with start and end
        member this.value(startKeyword: ScrollTimeline.RangeKeyword, startPct: Percent, endKeyword: ScrollTimeline.RangeKeyword, endPct: Percent) =
            (property, String $"{startKeyword.Stringify()} {lengthPercentageString startPct} {endKeyword.Stringify()} {lengthPercentageString endPct}") |> Rule

    type AnimationRangeEndpoint(property) =
        inherit CssRuleWithNormal(property)
        member this.value(keyword: ScrollTimeline.RangeKeyword) =
            (property, String (keyword.Stringify())) |> Rule
        member this.value(keyword: ScrollTimeline.RangeKeyword, pct: Percent) =
            (property, String $"{keyword.Stringify()} {lengthPercentageString pct}") |> Rule
        member this.value(pct: Percent) =
            (property, lengthPercentageString pct |> String) |> Rule
