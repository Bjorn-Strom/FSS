namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Overflow =
    type Overflow =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Wrap =
        | BreakWord
        | Anywhere
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module OverflowClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-x
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-x
    type OverflowClass(property) =
        inherit CssRuleWithAuto(property)
        member this.value (overflowX: Overflow.Overflow, overflowY: Overflow.Overflow) =
            let value =
                $"{stringifyICssValue overflowX} {stringifyICssValue overflowY}"
                |> String
            (property, value) |> Rule
        member this.visible = (property, Overflow.Visible) |> Rule
        member this.hidden = (property, Overflow.Hidden) |> Rule
        member this.clip = (property, Overflow.Clip) |> Rule
        member this.scroll = (property, Overflow.Scroll) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    type OverflowWrap(property) =
        inherit CssRuleWithNormal(property)
        member this.breakWord = (property, Overflow.BreakWord) |> Rule
        member this.anywhere = (property, Overflow.Anywhere) |> Rule
