namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Resize =
        type Resize =
            | Both
            | Horizontal
            | Vertical
            | Block
            | Inline
            interface IResize

