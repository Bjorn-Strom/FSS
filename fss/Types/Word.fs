namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module WordBreak =
        type WordBreak =
            | WordBreak
            | BreakAll
            | KeepAll
            interface IWordBreak