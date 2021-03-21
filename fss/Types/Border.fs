namespace FssTypes

type BorderWidth =
    | Thin
    | Medium
    | Thick
    interface IBorderWidth

type BorderStyle =
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

type BorderCollapse =
    | Collapse
    | Separate
    interface IBorderCollapse

type BorderImageOutset =
    | BorderImageOutset of float
    interface IBorderImageOutset

type BorderImageRepeat =
    | Stretch
    | Repeat
    | Round
    | Space
    interface IBorderRepeat

type BorderImageSlice =
    | Value of float
    | Fill
    interface IBorderImageSlice

