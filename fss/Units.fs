namespace Fss

// https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
module Units =
    type Unit =
        | Px of string
        | In of string
        | Cm of string
        | Mm of string
        | Pt of string
        | Pc of string
        | Pct of string
        | Em of string
        | Rem of string
        | Ex of string
        | Ch of string
        | Vw of string
        | Vh of string
        | VMax of string
        | Vmin of string
        interface Utilities.Types.ICss

    let value (u: Unit) = 
        match u with 
            | Px p -> p
            | In i -> i
            | Cm c -> c
            | Mm m -> m
            | Pt p -> p
            | Pc p -> p
            | Pct p -> p
            | Em e -> e
            | Rem r -> r
            | Ex e -> e
            | Ch c -> c
            | Vw v -> v
            | Vh v -> v
            | VMax v -> v
            | Vmin v -> v

    // Absolute
    let px (v: int): Unit = sprintf "%dpx"v |> Px
    let inc (v: float): Unit = sprintf "%.1fin" v |> In
    let cm (v: float): Unit = sprintf "%.1fcm" v |> Cm
    let mm (v: float): Unit = sprintf "%.1fmm" v |> Mm
    let pt (v: float): Unit = sprintf "%.1fpt" v |> Pt
    let pc (v: float): Unit = sprintf "%.1fpc" v |> Pc

    // Relative
    let pct (v: int): Unit = sprintf "%d%%" v |> Pct
    let em (v: float): Unit = sprintf "%.1fem" v |> Em
    let rem (v: float): Unit = sprintf "%.1frem" v |> Rem
    let ex (v: float): Unit = sprintf "%.1fex" v |> Ex
    let ch (v: float): Unit = sprintf "%.1fch" v |> Ch
    let vw (v: float): Unit = sprintf "%.1fvw" v |> Vw
    let vh (v: float): Unit = sprintf "%.1fvh" v |> Vh
    let vmax (v: float): Unit = sprintf "%.1fvmax" v |> VMax
    let vmin (v: float): Unit = sprintf "%.1fvmin" v |> Vmin
