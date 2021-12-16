namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Overflow =
    type Overflow =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Wrap =
        | BreakWord
        | Anywhere
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module OverflowClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-x
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-x
        type OverflowClass(property) =
            inherit CssRuleWithAuto(property)
            member this.value (overflowX: Overflow, overflowY: Overflow) =
                let value =
                    $"{(overflowX :> ICssValue).Stringify()} {(overflowY :> ICssValue).Stringify()}"
                    |> String
                (property, value) |> Rule
            member this.visible = (property, Visible) |> Rule
            member this.hidden = (property, Hidden) |> Rule
            member this.clip = (property, Clip) |> Rule
            member this.scroll = (property, Scroll) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
        type OverflowWrap(property) =
            inherit CssRuleWithNormal(property)
            member this.breakWord = (property, BreakWord) |> Rule
            member this.anywhere = (property, Anywhere) |> Rule
