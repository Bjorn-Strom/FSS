namespace Fss

[<RequireQualifiedAccess>]
module Types =
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
        interface Types.IVerticalAlign

    type Float' =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface Types.IFloat

    type BoxSizing =
        | ContentBox
        | BorderBox

    type Direction =
        | Rtl
        | Ltr
        interface Types.IDirection

    type BreakAfter =
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
        interface Types.IBreakAfter

    type BreakBefore =
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
        interface Types.IBreakBefore

    type BreakInside =
        | Avoid
        | AvoidPage
        | AvoidColumn
        | AvoidRegion
        interface Types.IBreakInside
