namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Column =
    type Span =
        | All
        interface ICssValue with
            member this.StringifyCss() = "all"

    type RuleWidth =
        | Thin
        | Medium
        | Thick
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

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
            member this.StringifyCss() = this.ToString().ToLower()

    type Fill =
        | Balance
        | BalanceAll
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

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
        member this.all = (property, Column.All) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    type ColumnRule(property) =
        inherit CssRule(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    type ColumnRuleWidth(property) =
        inherit CssRuleWithLength(property)
        member this.thin = (property, Column.Thin) |> Rule
        member this.medium = (property, Column.Medium) |> Rule
        member this.thick = (property, Column.Thick) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    type ColumnRuleStyle(property) =
        inherit CssRuleWithNone(property)
        member this.hidden = (property, Column.Hidden) |> Rule
        member this.dotted = (property, Column.Dotted) |> Rule
        member this.dashed = (property, Column.Dashed) |> Rule
        member this.solid = (property, Column.Solid) |> Rule
        member this.double = (property, Column.Double) |> Rule
        member this.groove = (property, Column.Groove) |> Rule
        member this.ridge = (property, Column.Ridge) |> Rule
        member this.inset = (property, Column.Inset) |> Rule
        member this.outset = (property, Column.Outset) |> Rule
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
        member this.balance = (property, Column.Balance) |> Rule
        member this.balanceAll = (property, Column.BalanceAll) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    type ColumnWidth(property) =
        inherit CssRuleWithAutoLength(property)
