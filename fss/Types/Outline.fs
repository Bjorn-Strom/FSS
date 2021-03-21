namespace Fss

namespace Fss.Types
    type OutlineWidth =
        | Thin
        | Medium
        | Thick
        interface IOutlineWidth

    type OutlineStyle =
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
