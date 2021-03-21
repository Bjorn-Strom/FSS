namespace Fss

namespace Fss.Types
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
