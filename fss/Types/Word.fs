namespace FssTypes

[<RequireQualifiedAccess>]
module Word =
    type WordBreak =
        | WordBreak
        | BreakAll
        | KeepAll
        interface IWordBreak