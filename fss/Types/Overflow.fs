namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Overflow =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface Types.IOverflow

    type OverflowWrap =
        | BreakWord
        | Anywhere
        interface Types.IOverflowWrap
