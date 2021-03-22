namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Table =
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

        type Layout =
            | Fixed
            interface ITableLayout

