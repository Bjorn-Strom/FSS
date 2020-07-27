namespace Fss

open Types
open Units.Angle
open Units.Size
open Utilities.Helpers
open Color

module BackgroundPosition =
    type BackgroundPosition =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface IBackgroundPosition
        interface ILinearGradient
        interface IRadialGradient

    let private backgroundPositionValue (value: BackgroundPosition): string =
        match value with
            | Top -> "top"
            | Bottom -> "bottom"
            | Left -> "left"
            | Right -> "right"
            | Center -> "center"

    let value (v: IBackgroundPosition): string =
        match v with
            | :? Size as s -> Units.Size.value s
            | :? BackgroundPosition as position -> backgroundPositionValue position
            | _ -> "Unknown background position"
 
module LinearGradient = 
    open BackgroundPosition

    let value (v: ILinearGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? BackgroundPosition as p -> sprintf "to %s" <| BackgroundPosition.value p
            | _ -> "Unknown linear gradient value"

module RadialGradient =
    type Shape =
        | Circle
        | Ellipse
        | CircleAt of IBackgroundPosition list
        | EllipseAt of IBackgroundPosition list
        interface IRadialGradient

    let shapeValue (v: Shape): string =
        match v with
            | Circle -> "circle"
            | Ellipse -> "ellipse"
            | CircleAt positions -> sprintf "circle at %s" <| combineWs positions BackgroundPosition.value
            | EllipseAt positions -> sprintf "ellipse at %s" <| combineWs positions BackgroundPosition.value

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

    let value (v: IRadialGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? Side as s -> sideValue s
            | :? Shape as s -> shapeValue s
            | _ -> "Unknown radial gradient value"

module BackgroundImage =
    open Units.Size
    open Types

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