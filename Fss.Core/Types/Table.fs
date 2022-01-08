namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Table =
    type CaptionSide =
        | Top
        | Bottom
        | Left
        | Right
        | TopOutside
        | BottomOutside
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type EmptyCells =
        | Show
        | Hide
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Layout =
        | Fixed
        interface ICssValue with
            member this.StringifyCss() = "fixed"

[<RequireQualifiedAccess>]
module TableClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    type CaptionSide(property) =
        inherit CssRule(property)
        member this.top = (property, Table.Top) |> Rule
        member this.bottom = (property, Table.Bottom) |> Rule
        member this.left = (property, Table.Left) |> Rule
        member this.right = (property, Table.Right) |> Rule
        member this.topOutside = (property, Table.TopOutside) |> Rule
        member this.bottomOutside = (property, Table.BottomOutside) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
    type EmptyCells(property) =
        inherit CssRule(property)
        member this.show = (property, Table.Show) |> Rule
        member this.hide = (property, Table.Hide) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    type TableLayout(property) =
        inherit CssRuleWithAuto(property)
        member this.fixed' = (property, Table.Fixed) |> Rule
