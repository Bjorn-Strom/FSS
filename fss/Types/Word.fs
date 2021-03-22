namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module WordBreak =
        type WordBreak =
            | WordBreak
            | BreakAll
            | KeepAll
            interface IWordBreak