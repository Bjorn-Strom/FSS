namespace FssTypes

type Overflow =
    | Visible
    | Hidden
    | Clip
    | Scroll
    interface IOverflow

type OverflowWrap =
    | BreakWord
    | Anywhere
    interface IOverflowWrap
