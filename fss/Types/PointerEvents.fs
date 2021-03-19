namespace FssTypes

[<RequireQualifiedAccess>]
module PointerEvents =
    type PointerEvents =
        | VisiblePainted
        | VisibleFill
        | VisibleStroke
        | Visible
        | Painted
        | Stroke
        | All
        interface IPointerEvents
