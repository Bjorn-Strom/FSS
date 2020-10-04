namespace Fss

open Types
open Units.Angle
open Units.Size
open Units.Percent
open Utilities.Helpers
open Color
open Global

module Background =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    type Position =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface IBackgroundPosition
        interface ILinearGradient

    // https://developer.mozilla.org/en-US/docs/Web/CSS/radial-gradient
    type Side =
        | ClosestCorner
        | ClosestSide
        | FarthestCorner
        | FarthestSide
        interface IRadialGradient

    type Shape =
        | Circle
        | Ellipse
        | CircleSide of Side
        | EllipseSide of Side
        | CircleAt of IBackgroundPosition list
        | EllipseAt of IBackgroundPosition list
        interface IRadialGradient

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    type Image =
        | Url of string
        | LinearGradient of ILinearGradient list
        | RadialGradient of IRadialGradient list
        | RepeatingLinearGradient of ILinearGradient list
        | RepeatingRadialGradient of IRadialGradient list

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    type Origin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface IBackgroundOrigin

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    type Clip =
        | BorderBox
        | PaddingBox
        | ContentBox
        | Text
        interface IBackgroundClip

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    type Repeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface IBackgroundRepeat

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    type Size =
        | Cover
        | Contain
        interface IBackgroundSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    type Attachment =
        | Scroll
        | Fixed
        | Local
        interface IBackgroundAttachment

module BackgroundValues =
    open Background

    let position (v: IBackgroundPosition): string =
        match v with
            | :? Global          as g -> GlobalValue.globalValue g
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? Position        as position -> duToLowercase position
            | _ -> "Unknown background position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/linear-gradient
    let private compareLinearGradient (v: ILinearGradient): int =
        match v with
            | :? Angle -> 0
            | :? Units.Size.Size -> 1
            | :? Percent -> 1
            | :? CssColor -> 1
            | :? Position -> 0
            | _ -> 1

    let private linearGradient (v: ILinearGradient): string =
        match v with
            | :? Angle           as a -> Units.Angle.value a
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? CssColor        as c -> Color.value c
            | :? Position        as p -> sprintf "to %s" <| position p
            | _ -> "Unknown linear gradient value"

    let private shape (v: Shape): string =
        match v with
            | Circle -> "circle"
            | Ellipse -> "ellipse"
            | CircleSide side -> sprintf "circle %s" <| duToKebab side
            | EllipseSide side -> sprintf "ellipse %s" <| duToKebab side
            | CircleAt positions -> sprintf "circle at %s" <| combineWs position positions
            | EllipseAt positions -> sprintf "ellipse at %s" <| combineWs position positions

    let private compareRadialGradient (v: IRadialGradient): int =
        match v with
            | :? Angle -> 0
            | :? Units.Size.Size -> 1
            | :? Percent -> 1
            | :? CssColor -> 1
            | :? Side -> 0
            | :? Shape -> 0
            | _ -> 0

    let private radialGradient (v: IRadialGradient): string =
        match v with
            | :? Angle           as a -> Units.Angle.value a
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? CssColor        as c -> Color.value c
            | :? Side            as s -> duToKebab s
            | :? Shape           as s -> shape s
            | _ -> "Unknown radial gradient value"

    let private combineGradient (value: ILinearGradient -> string) (list: ILinearGradient list): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Units.Size.Size || elem :? Percent  then
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let private combineGradient2 (value: IRadialGradient -> string) (list: IRadialGradient list): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Units.Size.Size || elem :? Percent then
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let backgroundImage (v: Image): string =
        match v with
            | Url u -> sprintf "url(%s)" u
            | LinearGradient g -> sprintf "linear-gradient(%s)"  (g |> List.sortBy compareLinearGradient |> combineGradient linearGradient)
            | RadialGradient g -> sprintf "radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradient)
            | RepeatingLinearGradient g -> sprintf "repeating-linear-gradient(%s)" (g |> List.sortBy compareLinearGradient |> combineGradient linearGradient)
            | RepeatingRadialGradient g -> sprintf "repeating-radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradient)

    let backgroundOrigin (v: IBackgroundOrigin): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Origin as b -> duToKebab b
            | _ -> "Unknown background origin"

    let backgroundClip (v: IBackgroundClip): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Clip as b -> duToKebab b
            | _ -> "Unknown background clip"

    let backgroundRepeat (v: IBackgroundRepeat): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Repeat as b -> duToKebab b
            | _ -> "Unknown background repeat"

    let backgroundSize (v: IBackgroundSize): string =
        match v with
            | :? Global          as g -> GlobalValue.globalValue g
            | :? Auto            as a -> GlobalValue.auto a
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? Size            as b -> duToLowercase b
            | _ -> "Unknown background size"

    let backgroundAttachment (v: IBackgroundAttachment): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Attachment as b -> duToLowercase b
            | _ -> "Unknown background attachment"