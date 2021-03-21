namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type WordBreak =
        | WordBreak
        | BreakAll
        | KeepAll
        interface Types.IWordBreak