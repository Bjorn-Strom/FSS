namespace Fss

namespace Fss.Types

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
        /// Overflowing content is not clipped, may be rendered outside of padding box
        member this.visible = (property, Overflow.Visible) |> Rule
        /// Overflowing content is hidden
        member this.hidden = (property, Overflow.Hidden) |> Rule
        /// Overflowing content is hidden and scrolling is forbidden
        member this.clip = (property, Overflow.Clip) |> Rule
        /// Overflowing content will be scrollable
        member this.scroll = (property, Overflow.Scroll) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    type OverflowWrap(property) =
        inherit CssRuleWithNormal(property)
        /// To prevent overflow a long string of characters can be broken anywhere
        /// without taking soft wrap opportunities under consideration
        member this.breakWord = (property, Overflow.BreakWord) |> Rule
        /// To prevent overflow a long string of characters can be broken anywhere
        member this.anywhere = (property, Overflow.Anywhere) |> Rule
