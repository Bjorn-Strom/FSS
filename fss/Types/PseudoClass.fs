namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type NthChildType =
        | Odd
        | Even
        interface Types.INthChild

