namespace Fss

open Utilities.Types

open Units.Angle
open Units.Size
open Color

// Trekk disse ut. Én til radial én til linear

module Gradient =
    type Position =
        | Top
        | TopRight
        | TopLeft
        | Bottom
        | BottomLeft
        | BottomRight
        | Left
        | Right
        interface ILinearGradient
        interface IRadialGradient

    let positionValue (v: Position): string =
        match v with
            | Top -> "to top"
            | TopRight -> "to right top"
            | TopLeft -> "to left top"
            | Bottom -> "to bottom"
            | BottomLeft -> "to left bottom"
            | BottomRight -> "to right bottom"
            | Left -> "to left"
            | Right -> "to right"

    type Side =
        | ClosestCorner
        | ClosestSide
        | FarthestCorner
        | FarthestSide
        interface IRadialGradient

    let sideValue (v: Side): string =
        match v with
            | ClosestCorner -> "closest-corner"
            | ClosestSide -> "cosest-side"
            | FarthestCorner -> "farthest-corner"
            | FarthestSide -> "farthest-side"

    type Shape =
        | Circle
        | Ellipse 
        interface IRadialGradient

    let shapeValue (v: Shape): string =
        match v with
            | Circle -> "circle"
            | Ellipse -> "ellipse"

module LinearGradient = 
    open Gradient

    let value (v: ILinearGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? Position as p -> positionValue p
            | _ -> "Unknown linear gradient value"

module RadialGradient =
    open Gradient

    let value (v: IRadialGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? Position as p -> positionValue p
            | :? Side as s -> sideValue s
            | :? Shape as s -> shapeValue s
            | _ -> "Unknown radial gradient value"


module BackgroundImage =
    open Units.Size
    open Utilities.Types

    type BackgroundImage =
        | Url of string
        | LinearGradient of ILinearGradient list
        | RadialGradient of IRadialGradient list
        | RepeatingLinearGradient of ILinearGradient list
        | RepeatingRadialGradient of IRadialGradient list

    let private combineGradient (list: ILinearGradient list) (value: ILinearGradient -> string): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Size then 
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let private combineGradient2 (list: IRadialGradient list) (value: IRadialGradient -> string): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Size then 
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let value (v: BackgroundImage): string =
        match v with
            | Url u -> sprintf "url(%s)" u
            | LinearGradient g -> sprintf "linear-gradient(%s)" <| combineGradient g LinearGradient.value
            | RadialGradient g -> sprintf "radial-gradient(%s)" <| combineGradient2 g RadialGradient.value
            | RepeatingLinearGradient g -> sprintf "repeating-linear-gradient(%s)" <| combineGradient g LinearGradient.value
            | RepeatingRadialGradient g -> sprintf "repeating-radial-gradient(%s)" <| combineGradient2 g RadialGradient.value