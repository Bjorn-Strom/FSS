namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Border =
        type Width =
            | Thin
            | Medium
            | Thick
            interface IBorderWidth

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
            interface IBorderStyle

        type Collapse =
            | Collapse
            | Separate
            interface IBorderCollapse

        type ImageOutset =
            | ImageOutset of float
            interface IBorderImageOutset

        type ImageRepeat =
            | Stretch
            | Repeat
            | Round
            | Space
            interface IBorderRepeat

        type ImageSlice =
            | Value of float
            | Fill
            interface IBorderImageSlice

