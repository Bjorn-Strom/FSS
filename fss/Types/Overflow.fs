namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Overflow =
        type Overflow =
            | Visible
            | Hidden
            | Clip
            | Scroll
            interface IOverflow

        type Wrap =
            | BreakWord
            | Anywhere
            interface IOverflowWrap
