namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type EmptyCells =
        | Show
        | Hide
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Layout =
        | Fixed
        interface ICssValue with
            member this.Stringify() = "fixed"

    [<RequireQualifiedAccess>]
    module TableClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
        type CaptionSide(property) =
            inherit CssRule(property)
            member this.top = (property, Top) |> Rule
            member this.bottom = (property, Bottom) |> Rule
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.topOutside = (property, TopOutside) |> Rule
            member this.bottomOutside = (property, BottomOutside) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
        type EmptyCells(property) =
            inherit CssRule(property)
            member this.show = (property, Show) |> Rule
            member this.hide = (property, Hide) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
        type TableLayout(property) =
            inherit CssRuleWithAuto(property)
            member this.fixed' = (property, Fixed) |> Rule
