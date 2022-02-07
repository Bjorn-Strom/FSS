namespace Fss

namespace Fss.Types

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Wrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Direction =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Basis =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module FlexClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    type FlexDirection(property) =
        inherit CssRule(property)
        member this.value(direction: Flex.Direction) = (property, direction) |> Rule
        member this.row = (property, Flex.Row) |> Rule
        member this.rowReverse = (property, Flex.RowReverse) |> Rule
        member this.column = (property, Flex.Column) |> Rule
        member this.columnReverse = (property, Flex.ColumnReverse) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    type FlexWrap(property) =
        inherit CssRule(property)
        member this.value(wrap: Flex.Wrap) = (property, wrap) |> Rule
        member this.noWrap = (property, Flex.NoWrap) |> Rule
        member this.wrap = (property, Flex.Wrap) |> Rule
        member this.wrapReverse = (property, Flex.WrapReverse) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    type FlexBasis(property) =
        inherit CssRuleWithAutoLength(property)
        member this.fill = (property, Flex.Fill) |> Rule
        member this.maxContent = (property, Flex.MaxContent) |> Rule
        member this.minContent = (property, Flex.MinContent) |> Rule
        member this.fitContent = (property, Flex.FitContent) |> Rule
        member this.content = (property, Flex.Content) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    type JustifyContent(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.JustifyContent.Start) |> Rule
        member this.end' = (property, Flex.JustifyContent.End) |> Rule

        member this.flexStart =
            (property, Flex.JustifyContent.FlexStart) |> Rule

        member this.flexEnd =
            (property, Flex.JustifyContent.FlexEnd) |> Rule

        member this.center =
            (property, Flex.JustifyContent.Center) |> Rule

        member this.baseline =
            (property, Flex.JustifyContent.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.JustifyContent.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.JustifyContent.LastBaseline) |> Rule

        member this.stretch =
            (property, Flex.JustifyContent.Stretch) |> Rule

        member this.safe = (property, Flex.JustifyContent.Safe) |> Rule

        member this.unsafe =
            (property, Flex.JustifyContent.Unsafe) |> Rule

        member this.spaceBetween =
            (property, Flex.JustifyContent.SpaceBetween) |> Rule

        member this.spaceAround =
            (property, Flex.JustifyContent.SpaceAround) |> Rule

        member this.spaceEvenly =
            (property, Flex.JustifyContent.SpaceEvenly) |> Rule

        member this.left = (property, Flex.JustifyContent.Left) |> Rule
        member this.right = (property, Flex.JustifyContent.Right) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    type JustifySelf(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.JustifySelf.Start) |> Rule
        member this.end' = (property, Flex.JustifySelf.End) |> Rule

        member this.flexStart =
            (property, Flex.JustifySelf.FlexStart) |> Rule

        member this.flexEnd = (property, Flex.JustifySelf.FlexEnd) |> Rule
        member this.center = (property, Flex.JustifySelf.Center) |> Rule
        member this.baseline = (property, Flex.JustifySelf.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.JustifySelf.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.JustifySelf.LastBaseline) |> Rule

        member this.stretch = (property, Flex.JustifySelf.Stretch) |> Rule
        member this.safe = (property, Flex.JustifySelf.Safe) |> Rule
        member this.unsafe = (property, Flex.JustifySelf.Unsafe) |> Rule

        member this.selfStart =
            (property, Flex.JustifySelf.SelfStart) |> Rule

        member this.selfEnd = (property, Flex.JustifySelf.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    type JustifyItems(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.JustifyItems.Start) |> Rule
        member this.end' = (property, Flex.JustifyItems.End) |> Rule

        member this.flexStart =
            (property, Flex.JustifyItems.FlexStart) |> Rule

        member this.flexEnd = (property, Flex.JustifyItems.FlexEnd) |> Rule
        member this.center = (property, Flex.JustifyItems.Center) |> Rule

        member this.baseline =
            (property, Flex.JustifyItems.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.JustifyItems.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.JustifyItems.LastBaseline) |> Rule

        member this.stretch = (property, Flex.JustifyItems.Stretch) |> Rule
        member this.safe = (property, Flex.JustifyItems.Safe) |> Rule
        member this.unsafe = (property, Flex.JustifyItems.Unsafe) |> Rule
        member this.left = (property, Flex.JustifyItems.Left) |> Rule
        member this.right = (property, Flex.JustifyItems.Right) |> Rule

        member this.selfStart =
            (property, Flex.JustifyItems.SelfStart) |> Rule

        member this.selfEnd = (property, Flex.JustifyItems.SelfEnd) |> Rule
        member this.legacy = (property, Flex.JustifyItems.Legacy) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    type AlignSelf(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.AlignSelf.Start) |> Rule
        member this.end' = (property, Flex.AlignSelf.End) |> Rule
        member this.flexStart = (property, Flex.AlignSelf.FlexStart) |> Rule
        member this.flexEnd = (property, Flex.AlignSelf.FlexEnd) |> Rule
        member this.center = (property, Flex.AlignSelf.Center) |> Rule
        member this.baseline = (property, Flex.AlignSelf.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.AlignSelf.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.AlignSelf.LastBaseline) |> Rule

        member this.stretch = (property, Flex.AlignSelf.Stretch) |> Rule
        member this.safe = (property, Flex.AlignSelf.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignSelf.Unsafe) |> Rule
        member this.selfStart = (property, Flex.AlignSelf.SelfStart) |> Rule
        member this.selfEnd = (property, Flex.AlignSelf.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    type AlignItems(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.AlignItems.Start) |> Rule
        member this.end' = (property, Flex.AlignItems.End) |> Rule
        member this.flexStart = (property, Flex.AlignItems.FlexStart) |> Rule
        member this.flexEnd = (property, Flex.AlignItems.FlexEnd) |> Rule
        member this.center = (property, Flex.AlignItems.Center) |> Rule
        member this.baseline = (property, Flex.AlignItems.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.AlignItems.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.AlignItems.LastBaseline) |> Rule

        member this.stretch = (property, Flex.AlignItems.Stretch) |> Rule
        member this.safe = (property, Flex.AlignItems.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignItems.Unsafe) |> Rule
        member this.selfStart = (property, Flex.AlignItems.SelfStart) |> Rule
        member this.selfEnd = (property, Flex.AlignItems.SelfEnd) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    type AlignContent(property) =
        inherit CssRuleWithNormal(property)
        member this.start = (property, Flex.Start) |> Rule
        member this.end' = (property, Flex.End) |> Rule

        member this.flexStart =
            (property, Flex.AlignContent.FlexStart) |> Rule

        member this.flexEnd = (property, Flex.AlignContent.FlexEnd) |> Rule
        member this.center = (property, Flex.AlignContent.Center) |> Rule

        member this.baseline =
            (property, Flex.AlignContent.Baseline) |> Rule

        member this.firstBaseline =
            (property, Flex.AlignContent.FirstBaseline) |> Rule

        member this.lastBaseline =
            (property, Flex.AlignContent.LastBaseline) |> Rule

        member this.stretch = (property, Flex.AlignContent.Stretch) |> Rule
        member this.safe = (property, Flex.AlignContent.Safe) |> Rule
        member this.unsafe = (property, Flex.AlignContent.Unsafe) |> Rule

        member this.spaceBetween =
            (property, Flex.AlignContent.SpaceBetween) |> Rule

        member this.spaceAround =
            (property, Flex.AlignContent.SpaceAround) |> Rule

        member this.spaceEvenly =
            (property, Flex.AlignContent.SpaceEvenly) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    type Order(property) =
        inherit CssRule(property)
        member this.value(order: int) = (property, Int order) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    type FlexShrinkGrow(property) =
        inherit CssRule(property)
        member this.value(grow: float) = (property, Float grow) |> Rule
