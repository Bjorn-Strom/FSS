namespace Fss

open Fss

module Border =
    let border = "border"

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
        interface Utilities.Types.ICSSProperty

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

    let borderStyle = "border-style"

module BorderWidth =
    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface Utilities.Types.ICSSProperty

    let value v =
        match v with
            | Thin -> "thin"
            | Medium -> "medium"
            | Thick -> "thick"

    let borderWidth = "border-width"
    let borderTopWidth = "border-top-width"
    let borderRightWidth = "border-right-width"
    let borderBottomWidth = "border-bottom-width"
    let borderLeftWidth = "border-left-width"

module BorderRadius =
    let borderRadius = "border-radius"
    let borderTopLeftRadius = "border-top-left-radius"
    let borderTopRightRadius = "border-top-right-radius"
    let borderBottomRightRadius = "border-bottom-right-radius"
    let borderBottomLeftRadius = "border-bottom-left-radius"


module BorderColor =
    let borderColor = "border-color"
    let borderTopColor = "border-top-color"
    let borderRightColor = "border-right-color"
    let borderBottomColor = "border-bottom-color"
    let borderLeftColor = "border-left-color"