namespace FssTypes

type CaptionSide =
    | Top
    | Bottom
    | Left
    | Right
    | TopOutside
    | BottomOutside
    interface ICaptionSide

type EmptyCells =
    | Show
    | Hide
    interface IEmptyCells

type TableLayout =
    | Fixed
    interface ITableLayout

