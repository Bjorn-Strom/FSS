namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Clear =
        type Clear =
            | Left
            | Right
            | Both
            | InlineStart
            | InlineEnd
            interface IClear

