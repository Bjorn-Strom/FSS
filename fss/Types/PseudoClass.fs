namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module PseudoClass =
        type NthChildType =
            | Odd
            | Even
            interface INthChild

