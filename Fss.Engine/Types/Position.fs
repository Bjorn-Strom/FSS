namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this


    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type BoxSizing =
        | ContentBox
        | BorderBox
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Direction =
        | Rtl
        | Ltr
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Break =
        | Avoid
        | Always
        | All
        | AvoidPage
        | Page
        | Left
        | Right
        | Recto
        | Verso
        | AvoidColumn
        | Column
        | AvoidRegion
        | Region
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type BreakInside =
        | Avoid
        | AvoidPage
        | AvoidColumn
        | AvoidRegion
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module PositionClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/position
    type Position(property) =
        inherit CssRule(property)
        member this.static' = (property, Position.Static) |> Rule
        member this.relative = (property, Position.Relative) |> Rule
        member this.absolute = (property, Position.Absolute) |> Rule
        member this.sticky = (property, Position.Sticky) |> Rule
        member this.fixed' = (property, Position.Fixed) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    type TopRightBottomLeft(property) =
        inherit CssRuleWithAutoLength(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    type VerticalAlign(property) =
        inherit CssRuleWithLength(property)
        member this.baseline = (property, Position.Baseline) |> Rule
        member this.sub = (property, Position.Sub) |> Rule
        member this.super = (property, Position.Super) |> Rule
        member this.textTop = (property, Position.TextTop) |> Rule
        member this.textBottom = (property, Position.TextBottom) |> Rule
        member this.middle = (property, Position.Middle) |> Rule
        member this.top = (property, Position.Top) |> Rule
        member this.bottom = (property, Position.Bottom) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    type Float(property) =
        inherit CssRuleWithNone(property)
        member this.left = (property, Position.Left) |> Rule
        member this.right = (property, Position.Right) |> Rule
        member this.inlineStart = (property, Position.InlineStart) |> Rule
        member this.inlineEnd = (property, Position.InlineEnd) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    type BoxSizing(property) =
        inherit CssRule(property)
        member this.borderBox = (property, Position.BorderBox) |> Rule
        member this.contentBox = (property, Position.ContentBox) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    type Direction(property) =
        inherit CssRule(property)
        member this.rtl = (property, Position.Rtl) |> Rule
        member this.ltr = (property, Position.Ltr) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    type Break(property) =
        inherit CssRuleWithAuto(property)
        member this.avoid = (property, Position.Avoid) |> Rule
        member this.always = (property, Position.Always) |> Rule
        member this.all = (property, Position.All) |> Rule
        member this.avoidPage = (property, Position.AvoidPage) |> Rule
        member this.page = (property, Position.Page) |> Rule
        member this.left = (property, Position.Left) |> Rule
        member this.right = (property, Position.Right) |> Rule
        member this.recto = (property, Position.Recto) |> Rule
        member this.verso = (property, Position.Verso) |> Rule
        member this.avoidColumn = (property, Position.AvoidColumn) |> Rule
        member this.column = (property, Position.Column) |> Rule
        member this.avoidRegion = (property, Position.AvoidRegion) |> Rule
        member this.region = (property, Position.Region) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    type BreakInside(property) =
        inherit CssRuleWithAuto(property)
        member this.avoid = (property, Position.Avoid) |> Rule
        member this.avoidPage = (property, Position.AvoidPage) |> Rule
        member this.avoidColumn = (property, Position.AvoidColumn) |> Rule
        member this.avoidRegion = (property, Position.AvoidRegion) |> Rule

[<RequireQualifiedAccess>]
module WritingMode =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module WritingModeClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    type WritingMode(property) =
        inherit CssRule(property)
        member this.horizontalTb = (property, WritingMode.HorizontalTb) |> Rule
        member this.verticalRl = (property, WritingMode.VerticalRl) |> Rule
        member this.verticalLr = (property, WritingMode.VerticalLr) |> Rule
