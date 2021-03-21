namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface Types.IBorderWidth

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
        interface Types.IBorderStyle

    type BorderCollapse =
        | Collapse
        | Separate
        interface Types.IBorderCollapse

    type BorderImageOutset =
        | BorderImageOutset of float
        interface Types.IBorderImageOutset

    type BorderImageRepeat =
        | Stretch
        | Repeat
        | Round
        | Space
        interface Types.IBorderRepeat

    type BorderImageSlice =
        | Value of float
        | Fill
        interface Types.IBorderImageSlice

