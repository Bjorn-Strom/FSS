namespace Fss

open Utilities.Types

open Units.Angle
open Units.Size
open Color

module LinearGradient = 
    type LinearGradient =
        | ToTop
        | ToBottom
        | ToLeft
        | ToLeftTop
        | ToLeftBottom
        | ToRight
        | ToRightTop
        | ToRightBottom
        interface ILinearGradient

    let private gradientValue (v: LinearGradient): string =
        match v with
            | ToTop -> "to top"
            | ToBottom -> "to bottom"
            | ToLeft -> "to left"
            | ToLeftTop -> "to left top"
            | ToLeftBottom -> "to left bottom"
            | ToRight -> "to right"
            | ToRightTop -> "to right top"
            | ToRightBottom -> "to right bottom"

    let value (v: ILinearGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? LinearGradient as g -> gradientValue g
            | _ -> "Unknown gradient value"

module RadialGradient =
    open Units.Angle

    type RadialGradient =
        | None
        interface IRadialGradient

    let private gradientValue (v: RadialGradient): string =
        match v with
            | ToTop -> "top top"
            | ToBottom -> "to bottom"
            | ToLeft -> "to left"
            | ToLeftTop -> "to left top"
            | ToLeftBottom -> "to left bottom"
            | ToRight -> "to right"
            | ToRightTop -> "to right top"
            | ToRightBottom -> "to right bottom"

    let value (v: IRadialGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? RadialGradient as g -> gradientValue g
            | _ -> "Unknown gradient value"


module BackgroundImage =
    open Units.Size
    open Utilities.Types

    type BackgroundImage =
        | Url of string
        | LinearGradient of ILinearGradient list
        | RadialGradient of ILinearGradient list
        | RepeatingLinearGradient of IRadialGradient list
        | RepeatingRadialGradient of IRadialGradient list

    type Foo =
        inherit ILinearGradient
        inherit IRadialGradient

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
            | RadialGradient g -> sprintf "radial-gradient(%s)" <| combineGradient g LinearGradient.value
            | RepeatingLinearGradient g -> sprintf "repeating-linear-gradient(%s)" <| combineGradient2 g RadialGradient.value
            | RepeatingRadialGradient g -> sprintf "repeating-radial-gradient(%s)" <| combineGradient2 g RadialGradient.value