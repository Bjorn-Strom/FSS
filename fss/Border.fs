namespace Fss.Border

open Fss

module BorderStyle =
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
        | None
        interface Utilities.Types.ICss

    let value v =
        match v with
            | Hidden -> "hidden"
            | Dotted -> "dotted"
            | Dashed -> "dashed"
            | Solid -> "solid"
            | Double -> "double"
            | Groove -> "groove"
            | Ridge -> "ridge"
            | Inset -> "inset"
            | Outset -> "outset"
            | None -> "none"

module BorderWidth =
    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface Utilities.Types.ICss

    let value v =
        match v with
            | Thin -> "thin"
            | Medium -> "medium"
            | Thick -> "thick"