namespace Fss

namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module Flex =
    type AlignContent =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        interface ICssValue with
            member this.StringifyCss() = 
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | SpaceBetween -> "space-between"
                | SpaceAround -> "space-around"
                | SpaceEvenly -> "space-evenly"

    type AlignItems =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | SelfStart -> "self-start"
                | SelfEnd -> "self-end"

    type AlignSelf =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | SelfStart -> "self-start"
                | SelfEnd -> "self-end"

    type JustifyContent =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        | Left
        | Right
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | SpaceBetween -> "space-between"
                | SpaceAround -> "space-around"
                | SpaceEvenly -> "space-evenly"
                | Left -> "left"
                | Right -> "right"

    type JustifyItems =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | Left
        | Right
        | SelfStart
        | SelfEnd
        | Legacy
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | Left -> "left"
                | Right -> "right"
                | SelfStart -> "self-start"
                | SelfEnd -> "self-end"
                | Legacy -> "legacy"

    type JustifySelf =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Start -> "start"
                | End -> "end"
                | FlexStart -> "flex-start"
                | FlexEnd -> "flex-end"
                | Center -> "center"
                | Baseline -> "baseline"
                | FirstBaseline -> "first-baseline"
                | LastBaseline -> "last-baseline"
                | Stretch -> "stretch"
                | Safe -> "safe"
                | Unsafe -> "unsafe"
                | SelfStart -> "self-start"
                | SelfEnd -> "self-end"

    type Wrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | NoWrap -> "no-wrap"
                | Wrap -> "wrap"
                | WrapReverse -> "wrap-reverse"

    type Direction =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Row -> "row"
                | RowReverse -> "row-reverse"
                | Column -> "column"
                | ColumnReverse -> "column-reverse"

    type Basis =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Fill -> "fill"
                | MaxContent -> "max-content"
                | MinContent -> "min-content"
                | FitContent -> "fit-content"
                | Content -> "content"

[<RequireQualifiedAccess>]
module FlexClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    type FlexDirection(property) =
        inherit CssRule(property)
        member this.value(direction: Flex.Direction) = (property, direction) |> Rule
        /// Sets the axis to be the horizontal
        member this.row = (property, Flex.Row) |> Rule
        /// Sets the axis to be the same as horizontal but reverse
        member this.rowReverse = (property, Flex.RowReverse) |> Rule
        /// Sets the axis to be the vertical
        member this.column = (property, Flex.Column) |> Rule
        /// Sets the axis to be the vertical but reverse
        member this.columnReverse = (property, Flex.ColumnReverse) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    type FlexWrap(property) =
        inherit CssRule(property)
        member this.value(wrap: Flex.Wrap) = (property, wrap) |> Rule
        /// Elements are laid out in a single line, can cause overflow
        member this.noWrap = (property, Flex.NoWrap) |> Rule
        /// In case of overflow the items will break into multiple lines
        member this.wrap = (property, Flex.Wrap) |> Rule
        /// In case of overflow the items will break into multiple lines but will be reversed
        member this.wrapReverse = (property, Flex.WrapReverse) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    type FlexBasis(property) =
        inherit CssRuleWithAutoLength(property)
        member this.fill = (property, Flex.Fill) |> Rule
        member this.maxContent = (property, Flex.MaxContent) |> Rule
        member this.minContent = (property, Flex.MinContent) |> Rule
        member this.fitContent = (property, Flex.FitContent) |> Rule
        /// Automatic sizing based on flex content
        member this.content = (property, Flex.Content) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    type JustifyContent(property) =
        inherit CssRuleWithNormal(property)
        /// Items are packed to the start of the axis regardless of reverse
        member this.start = (property, Flex.JustifyContent.Start) |> Rule
        /// Items are packed to the end of the axis regardless of reverse
        member this.end' = (property, Flex.JustifyContent.End) |> Rule
        /// Items are packed to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.JustifyContent.FlexStart) |> Rule
        /// Items are packed to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.JustifyContent.FlexEnd) |> Rule
        /// Items are packed in the center of the main axis
        member this.center = (property, Flex.JustifyContent.Center) |> Rule
        member this.baseline = (property, Flex.JustifyContent.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.JustifyContent.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.JustifyContent.LastBaseline) |> Rule
        member this.stretch = (property, Flex.JustifyContent.Stretch) |> Rule
        member this.safe = (property, Flex.JustifyContent.Safe) |> Rule
        member this.unsafe = (property, Flex.JustifyContent.Unsafe) |> Rule
        /// Items are evenly distributed along the main axis, spacing between items are the same
        /// with the first item being at the start and the last item at the end
        member this.spaceBetween = (property, Flex.JustifyContent.SpaceBetween) |> Rule
        /// Items are evenly distributed along the main axis with equal space around then
        member this.spaceAround = (property, Flex.JustifyContent.SpaceAround) |> Rule
        /// Items are evenly distributed along the main axis with equal space around then
        /// after the first and before the last element
        member this.spaceEvenly = (property, Flex.JustifyContent.SpaceEvenly) |> Rule
        /// Items are packed to each other on the left edge of the container
        member this.left = (property, Flex.JustifyContent.Left) |> Rule
        /// Items are packed to each other on the right edge of the container
        member this.right = (property, Flex.JustifyContent.Right) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    type JustifySelf(property) =
        inherit CssRuleWithNormal(property)
        /// The element is packed toward the start of its container regardless of reverse
        member this.start = (property, Flex.JustifySelf.Start) |> Rule
        /// The element is packed toward the end of its container regardless of reverse
        member this.end' = (property, Flex.JustifySelf.End) |> Rule
        /// Item is packed to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.JustifySelf.FlexStart) |> Rule
        /// Item is packed to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.JustifySelf.FlexEnd) |> Rule
        /// Item are packed in the center of the main axis
        member this.center = (property, Flex.JustifySelf.Center) |> Rule
        member this.baseline = (property, Flex.JustifySelf.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.JustifySelf.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.JustifySelf.LastBaseline) |> Rule
        member this.stretch = (property, Flex.JustifySelf.Stretch) |> Rule
        member this.safe = (property, Flex.JustifySelf.Safe) |> Rule
        member this.unsafe = (property, Flex.JustifySelf.Unsafe) |> Rule
        /// Item is packed along its own starting edge
        member this.selfStart = (property, Flex.JustifySelf.SelfStart) |> Rule
        /// Item is packed along its own ending edge
        member this.selfEnd = (property, Flex.JustifySelf.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    type JustifyItems(property) =
        inherit CssRuleWithNormal(property)
        /// Items are packed to the start of the axis regardless of reverse
        member this.start = (property, Flex.JustifyItems.Start) |> Rule
        /// Items are packed to the end of the axis regardless of reverse
        member this.end' = (property, Flex.JustifyItems.End) |> Rule
        /// Items are packed to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.JustifyItems.FlexStart) |> Rule
        /// Items are packed to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.JustifyItems.FlexEnd) |> Rule
        member this.center = (property, Flex.JustifyItems.Center) |> Rule
        /// Items are packed in the center of the main axis
        member this.baseline = (property, Flex.JustifyItems.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.JustifyItems.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.JustifyItems.LastBaseline) |> Rule
        member this.stretch = (property, Flex.JustifyItems.Stretch) |> Rule
        member this.safe = (property, Flex.JustifyItems.Safe) |> Rule
        member this.unsafe = (property, Flex.JustifyItems.Unsafe) |> Rule
        /// Items are packed to each other on the left edge of the container
        member this.left = (property, Flex.JustifyItems.Left) |> Rule
        /// Items are packed to each other on the right edge of the container
        member this.right = (property, Flex.JustifyItems.Right) |> Rule
        /// Packed on the start side of the item
        member this.selfStart = (property, Flex.JustifyItems.SelfStart) |> Rule
        // Packed on the end side of the item 
        member this.selfEnd = (property, Flex.JustifyItems.SelfEnd) |> Rule
        member this.legacy = (property, Flex.JustifyItems.Legacy) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    type AlignSelf(property) =
        inherit CssRuleWithNormal(property)
        /// Aligns the items to the start of the axis regardless of reverse
        member this.start = (property, Flex.AlignSelf.Start) |> Rule
        /// Aligns the items to the end of the axis regardless of reverse
        member this.end' = (property, Flex.AlignSelf.End) |> Rule
        /// Aligns the items to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.AlignSelf.FlexStart) |> Rule
        /// Aligns the items to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.AlignSelf.FlexEnd) |> Rule
        /// Aligns the items to the center of the main axis
        member this.center = (property, Flex.AlignSelf.Center) |> Rule
        member this.baseline = (property, Flex.AlignSelf.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.AlignSelf.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.AlignSelf.LastBaseline) |> Rule
        member this.stretch = (property, Flex.AlignSelf.Stretch) |> Rule
        member this.safe = (property, Flex.AlignSelf.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignSelf.Unsafe) |> Rule
        /// Item is aligned along its own starting edge
        member this.selfStart = (property, Flex.AlignSelf.SelfStart) |> Rule
        /// Item is aligned along its own ending edge
        member this.selfEnd = (property, Flex.AlignSelf.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    type AlignItems(property) =
        inherit CssRuleWithNormal(property)
        /// Aligns the item to the start of the axis regardless of reverse
        member this.start = (property, Flex.AlignItems.Start) |> Rule
        /// Aligns the item to the end of the axis regardless of reverse
        member this.end' = (property, Flex.AlignItems.End) |> Rule
        /// Aligns the item to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.AlignItems.FlexStart) |> Rule
        /// Aligns the items to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.AlignItems.FlexEnd) |> Rule
        /// Aligns the items to the center of the main axis
        member this.center = (property, Flex.AlignItems.Center) |> Rule
        member this.baseline = (property, Flex.AlignItems.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.AlignItems.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.AlignItems.LastBaseline) |> Rule
        member this.stretch = (property, Flex.AlignItems.Stretch) |> Rule
        member this.safe = (property, Flex.AlignItems.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignItems.Unsafe) |> Rule
        /// Item is aligned along its own starting edge
        member this.selfStart = (property, Flex.AlignItems.SelfStart) |> Rule
        /// Item is aligned along its own ending edge
        member this.selfEnd = (property, Flex.AlignItems.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    type AlignContent(property) =
        inherit CssRuleWithNormal(property)
        /// Aligns the items to the start of the axis regardless of reverse
        member this.start = (property, Flex.Start) |> Rule
        /// Aligns the items to the end of the axis regardless of reverse
        member this.end' = (property, Flex.End) |> Rule
        /// Aligns the items to the start of the axis and takes reverse into account
        member this.flexStart = (property, Flex.AlignContent.FlexStart) |> Rule
        /// Aligns the items to the end of the axis and takes reverse into account
        member this.flexEnd = (property, Flex.AlignContent.FlexEnd) |> Rule
        /// Aligns the items to the center of the main axis
        member this.center = (property, Flex.AlignContent.Center) |> Rule
        member this.baseline = (property, Flex.AlignContent.Baseline) |> Rule
        member this.firstBaseline = (property, Flex.AlignContent.FirstBaseline) |> Rule
        member this.lastBaseline = (property, Flex.AlignContent.LastBaseline) |> Rule
        member this.stretch = (property, Flex.AlignContent.Stretch) |> Rule
        member this.safe = (property, Flex.AlignContent.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignContent.Unsafe) |> Rule
        /// Items are evenly distributed along the main axis, spacing between items are the same
        /// with the first item being at the start and the last item at the end
        member this.spaceBetween = (property, Flex.AlignContent.SpaceBetween) |> Rule
        /// Items are evenly distributed along the main axis with equal space around then
        member this.spaceAround = (property, Flex.AlignContent.SpaceAround) |> Rule
        /// Items are aligned to each other on the left edge of the container
        member this.spaceEvenly = (property, Flex.AlignContent.SpaceEvenly) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    type Order(property) =
        inherit CssRule(property)
        member this.value(order: int) = (property, Int order) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    type FlexShrinkGrow(property) =
        inherit CssRule(property)
        member this.value(grow: float) = (property, Float grow) |> Rule
