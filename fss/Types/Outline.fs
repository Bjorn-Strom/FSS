namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Outline =
        type Width =
            | Thin
            | Medium
            | Thick
            interface IOutlineWidth

        type Style =
            | Hidden
            | Dotted
            | Dashed
            | Solid
            | Double
            | Groove
            | Ridge
            | Inset
            | Outset
            interface IOutlineStyle
