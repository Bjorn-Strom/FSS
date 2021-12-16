namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Wrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Direction =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Basis =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module FlexClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
        type FlexDirection(property) =
            inherit CssRule(property)
            member this.value(direction: Direction) = (property, direction) |> Rule
            member this.row = (property, Row) |> Rule
            member this.rowReverse = (property, RowReverse) |> Rule
            member this.column = (property, Column) |> Rule
            member this.columnReverse = (property, ColumnReverse) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
        type FlexWrap(property) =
            inherit CssRule(property)
            member this.value(wrap: Wrap) = (property, wrap) |> Rule
            member this.noWrap = (property, NoWrap) |> Rule
            member this.wrap = (property, Wrap) |> Rule
            member this.wrapReverse = (property, WrapReverse) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
        type FlexBasis(property) =
            inherit CssRuleWithAutoLength(property)
            member this.fill = (property, Fill) |> Rule
            member this.maxContent = (property, MaxContent) |> Rule
            member this.minContent = (property, MinContent) |> Rule
            member this.fitContent = (property, FitContent) |> Rule
            member this.content = (property, Content) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
        type JustifyContent(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, JustifyContent.Start) |> Rule
            member this.end' = (property, JustifyContent.End) |> Rule

            member this.flexStart =
                (property, JustifyContent.FlexStart) |> Rule

            member this.flexEnd =
                (property, JustifyContent.FlexEnd) |> Rule

            member this.center =
                (property, JustifyContent.Center) |> Rule

            member this.baseline =
                (property, JustifyContent.Baseline) |> Rule

            member this.firstBaseline =
                (property, JustifyContent.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, JustifyContent.LastBaseline) |> Rule

            member this.stretch =
                (property, JustifyContent.Stretch) |> Rule

            member this.safe = (property, JustifyContent.Safe) |> Rule

            member this.unsafe =
                (property, JustifyContent.Unsafe) |> Rule

            member this.spaceBetween =
                (property, JustifyContent.SpaceBetween) |> Rule

            member this.spaceAround =
                (property, JustifyContent.SpaceAround) |> Rule

            member this.spaceEvenly =
                (property, JustifyContent.SpaceEvenly) |> Rule

            member this.left = (property, JustifyContent.Left) |> Rule
            member this.right = (property, JustifyContent.Right) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
        type JustifySelf(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, JustifySelf.Start) |> Rule
            member this.end' = (property, JustifySelf.End) |> Rule

            member this.flexStart =
                (property, JustifySelf.FlexStart) |> Rule

            member this.flexEnd = (property, JustifySelf.FlexEnd) |> Rule
            member this.center = (property, JustifySelf.Center) |> Rule
            member this.baseline = (property, JustifySelf.Baseline) |> Rule

            member this.firstBaseline =
                (property, JustifySelf.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, JustifySelf.LastBaseline) |> Rule

            member this.stretch = (property, JustifySelf.Stretch) |> Rule
            member this.safe = (property, JustifySelf.Safe) |> Rule
            member this.unsafe = (property, JustifySelf.Unsafe) |> Rule

            member this.selfStart =
                (property, JustifySelf.SelfStart) |> Rule

            member this.selfEnd = (property, JustifySelf.SelfEnd) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
        type JustifyItems(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, JustifyItems.Start) |> Rule
            member this.end' = (property, JustifyItems.End) |> Rule

            member this.flexStart =
                (property, JustifyItems.FlexStart) |> Rule

            member this.flexEnd = (property, JustifyItems.FlexEnd) |> Rule
            member this.center = (property, JustifyItems.Center) |> Rule

            member this.baseline =
                (property, JustifyItems.Baseline) |> Rule

            member this.firstBaseline =
                (property, JustifyItems.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, JustifyItems.LastBaseline) |> Rule

            member this.stretch = (property, JustifyItems.Stretch) |> Rule
            member this.safe = (property, JustifyItems.Safe) |> Rule
            member this.unsafe = (property, JustifyItems.Unsafe) |> Rule
            member this.left = (property, JustifyItems.Left) |> Rule
            member this.right = (property, JustifyItems.Right) |> Rule

            member this.selfStart =
                (property, JustifyItems.SelfStart) |> Rule

            member this.selfEnd = (property, JustifyItems.SelfEnd) |> Rule
            member this.legacy = (property, JustifyItems.Legacy) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
        type AlignSelf(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, AlignSelf.Start) |> Rule
            member this.end' = (property, AlignSelf.End) |> Rule
            member this.flexStart = (property, AlignSelf.FlexStart) |> Rule
            member this.flexEnd = (property, AlignSelf.FlexEnd) |> Rule
            member this.center = (property, AlignSelf.Center) |> Rule
            member this.baseline = (property, AlignSelf.Baseline) |> Rule

            member this.firstBaseline =
                (property, AlignSelf.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, AlignSelf.LastBaseline) |> Rule

            member this.stretch = (property, AlignSelf.Stretch) |> Rule
            member this.safe = (property, AlignSelf.Safe) |> Rule
            member this.unsafe = (property, AlignSelf.Unsafe) |> Rule
            member this.selfStart = (property, AlignSelf.SelfStart) |> Rule
            member this.selfEnd = (property, AlignSelf.SelfEnd) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
        type AlignItems(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, AlignItems.Start) |> Rule
            member this.end' = (property, AlignItems.End) |> Rule
            member this.flexStart = (property, AlignItems.FlexStart) |> Rule
            member this.flexEnd = (property, AlignItems.FlexEnd) |> Rule
            member this.center = (property, AlignItems.Center) |> Rule
            member this.baseline = (property, AlignItems.Baseline) |> Rule

            member this.firstBaseline =
                (property, AlignItems.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, AlignItems.LastBaseline) |> Rule

            member this.stretch = (property, AlignItems.Stretch) |> Rule
            member this.safe = (property, AlignItems.Safe) |> Rule
            member this.unsafe = (property, AlignItems.Unsafe) |> Rule
            member this.selfStart = (property, AlignItems.SelfStart) |> Rule
            member this.selfEnd = (property, AlignItems.SelfEnd) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
        type AlignContent(property) =
            inherit CssRuleWithNormal(property)
            member this.start = (property, Start) |> Rule
            member this.end' = (property, End) |> Rule

            member this.flexStart =
                (property, AlignContent.FlexStart) |> Rule

            member this.flexEnd = (property, AlignContent.FlexEnd) |> Rule
            member this.center = (property, AlignContent.Center) |> Rule

            member this.baseline =
                (property, AlignContent.Baseline) |> Rule

            member this.firstBaseline =
                (property, AlignContent.FirstBaseline) |> Rule

            member this.lastBaseline =
                (property, AlignContent.LastBaseline) |> Rule

            member this.stretch = (property, AlignContent.Stretch) |> Rule
            member this.safe = (property, AlignContent.Safe) |> Rule
            member this.unsafe = (property, AlignContent.Unsafe) |> Rule

            member this.spaceBetween =
                (property, AlignContent.SpaceBetween) |> Rule

            member this.spaceAround =
                (property, AlignContent.SpaceAround) |> Rule

            member this.spaceEvenly =
                (property, AlignContent.SpaceEvenly) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/order
        type Order(property) =
            inherit CssRule(property)
            member this.value(order: int) = (property, Int order) |> Rule

        // Todo: Kan byttes ut med en Float klasse?
        // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
        // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
        type FlexShrinkGrow(property) =
            inherit CssRule(property)
            member this.value(grow: float) = (property, Float grow) |> Rule
