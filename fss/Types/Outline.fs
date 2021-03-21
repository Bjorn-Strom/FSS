namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type OutlineWidth =
        | Thin
        | Medium
        | Thick
        interface Types.IOutlineWidth

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
        interface Types.IOutlineStyle
