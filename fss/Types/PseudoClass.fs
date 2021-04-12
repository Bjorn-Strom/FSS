namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module PseudoClass =
        type Nth =
            | Odd
            | Even
            interface INth

