namespace FssTypes

[<RequireQualifiedAccess>]
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface IVerticalAlign

    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface IFloat

    type BoxSizing =
        | ContentBox
        | BorderBox

    type Direction =
        | Rtl
        | Ltr
        interface IDirection

