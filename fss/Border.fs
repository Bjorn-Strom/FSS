namespace Fss

open Fss
open Types
open Global  
open Utilities.Helpers

module BorderWidth =
    open Units.Size
    open Units.Percent

    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface IBorderWidth
        interface IGlobal

    let private borderWidthValue (v: BorderWidth): string = duToLowercase v

    let value (v: IBorderWidth): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BorderWidth as b -> borderWidthValue b
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
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
                    
    let private borderStyleValue (v: BorderStyle): string = duToLowercase v
            
    let value (v: IBorderStyle): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BorderStyle as b -> borderStyleValue b
            | _ -> "Unknown border style"  