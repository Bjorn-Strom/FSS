namespace Fss

open Fss
open Types
open Global  
open Utilities.Helpers

module Border =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface IBorderWidth

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
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
        
module BorderValue =
    open Border
    open Units.Size
    open Units.Percent

    let borderWidth (v: IBorderWidth): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? BorderWidth as b -> duToLowercase b
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | _ -> "Unknown border width"

    let borderStyle (v: IBorderStyle): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? BorderStyle as b -> duToLowercase b
            | _ -> "Unknown border style"
            
    let borderRadius (v: IBorderRadius): string =
        match v with
            | :? Size    as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? Global  as g -> GlobalValue.globalValue g
            | _ -> "Unknown border radius"
            
    let borderColor (v: IBorderColor): string =
        match v with
            | :? Color.CssColor as c -> Color.value c
            | :? Global         as g -> GlobalValue.globalValue g
            | _ -> "Unknown border color"