namespace Fss

open Fss
open Utilities.Types
open Utilities.Global  

module BorderWidth =
    open Units.Size

    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface IBorderWidth
        interface IGlobal

    let private borderWidthValue (v: BorderWidth): string =
        match v with
            | Thin -> "thin"
            | Medium -> "medium"
            | Thick -> "thick"

    let value (v: IBorderWidth): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? BorderWidth as b -> borderWidthValue b
            | :? Size as s -> Units.Size.value s
            | _ -> "Unknown border width"

module BorderStyle =
    open BorderWidth

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
        interface IBorderStyle
        interface IGlobal
                    
    let private borderStyleValue (v: BorderStyle): string =
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
            
    let value (v: IBorderStyle): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? BorderStyle as b -> borderStyleValue b
            | _ -> "Unknown border style"  