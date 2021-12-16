namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Column =
    type Span =
        | All
        interface ICssValue with
            member this.Stringify() = "all"

    type RuleWidth =
        | Thin
        | Medium
        | Thick
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type RuleStyle =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Fill =
        | Balance
        | BalanceAll
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module ColumnClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
        type Columns(property) =
            inherit CssRule(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
        type ColumnGap(property) =
            inherit CssRuleWithLengthNormal(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
        type ColumnSpan(property) =
            inherit CssRuleWithNone(property)
            member this.all = (property, All) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
        type ColumnRule(property) =
            inherit CssRule(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
        type ColumnRuleWidth(property) =
            inherit CssRuleWithLength(property)
            member this.thin = (property, Thin) |> Rule
            member this.medium = (property, Medium) |> Rule
            member this.thick = (property, Thick) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
        type ColumnRuleStyle(property) =
            inherit CssRuleWithNone(property)
            member this.hidden = (property, Hidden) |> Rule
            member this.dotted = (property, Dotted) |> Rule
            member this.dashed = (property, Dashed) |> Rule
            member this.solid = (property, Solid) |> Rule
            member this.double = (property, Double) |> Rule
            member this.groove = (property, Groove) |> Rule
            member this.ridge = (property, Ridge) |> Rule
            member this.inset = (property, Inset) |> Rule
            member this.outset = (property, Outset) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
        type ColumnRuleColor(property) =
            inherit ColorClass.Color(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
        type ColumnCount(property) =
            inherit CssRuleWithAuto(property)
            member this.value(count: int) = (property, Int count) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
        type ColumnFill(property) =
            inherit CssRuleWithAuto(property)
            member this.balance = (property, Balance) |> Rule
            member this.balanceAll = (property, BalanceAll) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
        type ColumnWidth(property) =
            inherit CssRuleWithAutoLength(property)
