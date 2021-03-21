namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Clear =
        | Left
        | Right
        | Both
        | InlineStart
        | InlineEnd
        interface Types.IClear

