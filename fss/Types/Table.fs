namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type CaptionSide =
        | Top
        | Bottom
        | Left
        | Right
        | TopOutside
        | BottomOutside
        interface Types.ICaptionSide

    type EmptyCells =
        | Show
        | Hide
        interface Types.IEmptyCells

    type TableLayout =
        | Fixed
        interface Types.ITableLayout

