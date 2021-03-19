namespace FssTypes

[<RequireQualifiedAccess>]
module Overflow =
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
