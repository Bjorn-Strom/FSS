namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/padding
module Padding =
    open Units.Size
    open Units.Percent
    open Types
    open Global
    
    module Padding =
        type Padding =
            | Padding of Size
            interface IPadding
    
        let private paddingValue (v: Padding): string =
            match v with
                | Padding s -> Units.Size.value s
    
        let value (v: IPadding): string =
            match v with
                | :? Global as g -> Global.value g
                | :? Size as s -> Units.Size.value s
                | :? Percent as p -> Units.Percent.value p
                | :? Padding as p -> paddingValue p
                | _ -> "Unknown padding size"