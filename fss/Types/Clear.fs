namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Clear =
        type Clear =
            | Left
            | Right
            | Both
            | InlineStart
            | InlineEnd
            interface IClear

