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
            member this.StringifyCss() =
                match this with
                | Top -> "top"
                | Bottom -> "bottom"
                | Left -> "left"
                | Right -> "right"
                | TopOutside -> "top-outside"
                | BottomOutside -> "bottom-outside"

    type EmptyCells =
        | Show
        | Hide
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Show -> "show"
                | Hide -> "hide"

    type Layout =
        | Fixed
        interface ICssValue with
            member this.StringifyCss() = "fixed"

[<RequireQualifiedAccess>]
module TableClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    type CaptionSide(property) =
        inherit CssRule(property)
        /// The top of the caption box should be placed above the table
        member this.top = (property, Table.Top) |> Rule
        /// The top of the caption box should be placed below the table
        member this.bottom = (property, Table.Bottom) |> Rule
        /// The top of the caption box should be placed below the table
        member this.left = (property, Table.Left) |> Rule
        member this.right = (property, Table.Right) |> Rule
        member this.topOutside = (property, Table.TopOutside) |> Rule
        member this.bottomOutside = (property, Table.BottomOutside) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
    type EmptyCells(property) =
        inherit CssRule(property)
        /// Borders and backgrounds drawn like in normal cells
        member this.show = (property, Table.Show) |> Rule
        /// No borders or backgrounds are drawn
        member this.hide = (property, Table.Hide) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    type TableLayout(property) =
        inherit CssRuleWithAuto(property)
        member this.fixed' = (property, Table.Fixed) |> Rule
