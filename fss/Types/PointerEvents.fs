namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type PointerEvents =
        | VisiblePainted
        | VisibleFill
        | VisibleStroke
        | Visible
        | Painted
        | Stroke
        | All
        interface Types.IPointerEvents

