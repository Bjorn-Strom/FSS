namespace Fss.Units

open Fss
open Types

// https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
module Size =
    type Size =
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
        interface IFontSize
        interface IBorderWidth
        interface IMargin
        interface IPadding
        interface IFlexBasis
        interface ILinearGradient
        interface IRadialGradient
        interface IBackgroundPosition
        interface IBackgroundSize
        interface IContentSize

    let value (u: Size) = 
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
    let px (v: int): Size = sprintf "%dpx" v |> Px
    let inc (v: float): Size = sprintf "%.1fin" v |> In
    let cm (v: float): Size = sprintf "%.1fcm" v |> Cm
    let mm (v: float): Size = sprintf "%.1fmm" v |> Mm
    let pt (v: float): Size = sprintf "%.1fpt" v |> Pt
    let pc (v: float): Size = sprintf "%.1fpc" v |> Pc

    // Relative
    let pct (v: int): Size = sprintf "%d%%" v |> Pct
    let em (v: float): Size = sprintf "%.1fem" v |> Em
    let rem (v: float): Size = sprintf "%.1frem" v |> Rem
    let ex (v: float): Size = sprintf "%.1fex" v |> Ex
    let ch (v: float): Size = sprintf "%.1fch" v |> Ch
    let vw (v: float): Size = sprintf "%.1fvw" v |> Vw
    let vh (v: float): Size = sprintf "%.1fvh" v |> Vh
    let vmax (v: float): Size = sprintf "%.1fvmax" v |> VMax
    let vmin (v: float): Size = sprintf "%.1fvmin" v |> Vmin

// https://developer.mozilla.org/en-US/docs/Web/CSS/angle
module Angle =
    type Angle =
        | Deg of string
        | Grad of string
        | Rad of string
        | Turn of string
        interface ITransform
        interface ILinearGradient
        interface IRadialGradient

    let value (u: Angle) = 
        match u with 
            | Deg d -> d
            | Grad g -> g
            | Rad r -> r
            | Turn t -> t

    let deg (v: float): Angle = sprintf "%.2fdeg" v |> Deg
    let grad (v: float): Angle = sprintf "%.2fgrad" v |> Grad
    let rad (v: float): Angle = sprintf "%.4frad" v |> Rad
    let turn (v: float): Angle = sprintf "%.2fturn" v |> Turn