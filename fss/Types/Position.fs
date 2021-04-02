namespace Fss

namespace Fss.FssTypes
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
            interface IBreakAfter

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
            interface IBreakBefore

        type BreakInside =
            | Avoid
            | AvoidPage
            | AvoidColumn
            | AvoidRegion
            interface IBreakInside

    [<RequireQualifiedAccess>]
    module WritingMode =
        type WritingMode =
            | HorizontalTb
            | VerticalRl
            | VerticalLr
            interface IWritingMode
