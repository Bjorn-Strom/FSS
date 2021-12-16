namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes
open Microsoft.FSharp.Core

[<RequireQualifiedAccess>]
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this


    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type BoxSizing =
        | ContentBox
        | BorderBox
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Direction =
        | Rtl
        | Ltr
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type BreakInside =
        | Avoid
        | AvoidPage
        | AvoidColumn
        | AvoidRegion
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module PositionClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/position
        type Position(property) =
            inherit CssRule(property)
            member this.static' = (property, Static) |> Rule
            member this.relative = (property, Relative) |> Rule
            member this.absolute = (property, Absolute) |> Rule
            member this.sticky = (property, Sticky) |> Rule
            member this.fixed' = (property, Fixed) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/top
        // https://developer.mozilla.org/en-US/docs/Web/CSS/right
        // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
        // https://developer.mozilla.org/en-US/docs/Web/CSS/left
        type TopRightBottomLeft(property) =
            inherit CssRuleWithAutoLength(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
        type VerticalAlign(property) =
            inherit CssRuleWithLength(property)
            member this.baseline = (property, Baseline) |> Rule
            member this.sub = (property, Sub) |> Rule
            member this.super = (property, Super) |> Rule
            member this.textTop = (property, TextTop) |> Rule
            member this.textBottom = (property, TextBottom) |> Rule
            member this.middle = (property, Middle) |> Rule
            member this.top = (property, Top) |> Rule
            member this.bottom = (property, Bottom) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/float
        type Float(property) =
            inherit CssRuleWithNone(property)
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.inlineStart = (property, InlineStart) |> Rule
            member this.inlineEnd = (property, InlineEnd) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
        type BoxSizing(property) =
            inherit CssRule(property)
            member this.borderBox = (property, BorderBox) |> Rule
            member this.contentBox = (property, ContentBox) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
        type Direction(property) =
            inherit CssRule(property)
            member this.rtl = (property, Rtl) |> Rule
            member this.ltr = (property, Ltr) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
        // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
        type Break(property) =
            inherit CssRuleWithAuto(property)
            member this.avoid = (property, Avoid) |> Rule
            member this.always = (property, Always) |> Rule
            member this.all = (property, All) |> Rule
            member this.avoidPage = (property, AvoidPage) |> Rule
            member this.page = (property, Page) |> Rule
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.recto = (property, Recto) |> Rule
            member this.verso = (property, Verso) |> Rule
            member this.avoidColumn = (property, AvoidColumn) |> Rule
            member this.column = (property, Column) |> Rule
            member this.avoidRegion = (property, AvoidRegion) |> Rule
            member this.region = (property, Region) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
        type BreakInside(property) =
            inherit CssRuleWithAuto(property)
            member this.avoid = (property, Avoid) |> Rule
            member this.avoidPage = (property, AvoidPage) |> Rule
            member this.avoidColumn = (property, AvoidColumn) |> Rule
            member this.avoidRegion = (property, AvoidRegion) |> Rule

[<RequireQualifiedAccess>]
module WritingMode =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module WritingModeClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
        type WritingMode(property) =
            inherit CssRule(property)
            member this.horizontalTb = (property, HorizontalTb) |> Rule
            member this.verticalRl = (property, VerticalRl) |> Rule
            member this.verticalLr = (property, VerticalLr) |> Rule
