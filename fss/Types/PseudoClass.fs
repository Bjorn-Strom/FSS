namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module PseudoClass =
        type NthChildType =
            | Odd
            | Even
            interface INthChild

