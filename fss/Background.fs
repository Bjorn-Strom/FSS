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
    type BackgroundPosition =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface IBackgroundPosition
        interface ILinearGradient

    let private backgroundPositionValue (v: IBackgroundPosition): string =
        match v with
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? BackgroundPosition as position -> duToLowercase position
            | _ -> "Unknown background position"
     
 
    // https://developer.mozilla.org/en-US/docs/Web/CSS/linear-gradient
    let private compareLinearGradient (v: ILinearGradient): int =
        match v with
            | :? Angle -> 0
            | :? Size -> 1
            | :? Percent -> 1
            | :? CssColor -> 1
            | :? BackgroundPosition -> 0
            | _ -> 1

    let private linearGradientValue (v: ILinearGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? CssColor as c -> Color.value c
            | :? BackgroundPosition as p -> sprintf "to %s" <| backgroundPositionValue p
            | _ -> "Unknown linear gradient value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/radial-gradient
    type Side =
        | ClosestCorner
        | ClosestSide
        | FarthestCorner
        | FarthestSide
        interface IRadialGradient

    let private sideValue (v: Side): string = duToKebab v

    type Shape =
        | Circle
        | Ellipse
        | CircleSide of Side
        | EllipseSide of Side
        | CircleAt of IBackgroundPosition list
        | EllipseAt of IBackgroundPosition list
        interface IRadialGradient

    let private shapeValue (v: Shape): string =
        match v with
            | Circle -> "circle"
            | Ellipse -> "ellipse"
            | CircleSide side -> sprintf "circle %s" <| sideValue side
            | EllipseSide side -> sprintf "ellipse %s" <| sideValue side
            | CircleAt positions -> sprintf "circle at %s" <| combineWs positions backgroundPositionValue
            | EllipseAt positions -> sprintf "ellipse at %s" <| combineWs positions backgroundPositionValue

    let private compareRadialGradient (v: IRadialGradient): int =
        match v with 
            | :? Angle -> 0
            | :? Size -> 1
            | :? Percent -> 1
            | :? CssColor -> 1
            | :? Side -> 0
            | :? Shape -> 0
            | _ -> 0

    let private radialGradientValue (v: IRadialGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? CssColor as c -> Color.value c
            | :? Side as s -> sideValue s
            | :? Shape as s -> shapeValue s
            | _ -> "Unknown radial gradient value"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    type BackgroundImage =
        | Url of string
        | LinearGradient of ILinearGradient list
        | RadialGradient of IRadialGradient list
        | RepeatingLinearGradient of ILinearGradient list
        | RepeatingRadialGradient of IRadialGradient list

    let private combineGradient (value: ILinearGradient -> string) (list: ILinearGradient list): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Size || elem :? Percent  then 
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let private combineGradient2 (value: IRadialGradient -> string) (list: IRadialGradient list): string =
        list
        |> List.fold (fun acc elem ->
            if Seq.isEmpty acc then
                value elem
            else if elem :? Size || elem :? Percent then 
                sprintf "%s %s" acc (value elem)
            else
                sprintf "%s, %s" acc (value elem)) ""

    let value (v: BackgroundImage): string =
        match v with
            | Url u -> sprintf "url(%s)" u
            | LinearGradient g -> sprintf "linear-gradient(%s)"  (g |> List.sortBy compareLinearGradient |> combineGradient linearGradientValue)
            | RadialGradient g -> sprintf "radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradientValue)
            | RepeatingLinearGradient g -> sprintf "repeating-linear-gradient(%s)" (g |> List.sortBy compareLinearGradient |> combineGradient linearGradientValue)
            | RepeatingRadialGradient g -> sprintf "repeating-radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradientValue)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    type BackgroundOrigin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface IBackgroundOrigin
        interface IBackgroundClip

    let private backgroundOriginValue (v: IBackgroundOrigin): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundOrigin as b -> duToKebab b
            | _ -> "Unknown background origin" 

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    type BackgroundClip =
        | Text
        interface IBackgroundClip

    let private backgroundClipValue (v: IBackgroundClip): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundOrigin as b -> duToString b
            | :? BackgroundClip as b -> duToString b
            | _ -> "Unknown background clip" 

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    type BackgroundRepeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface IBackgroundRepeat

    let private backgroundRepeatValue (v: IBackgroundRepeat): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundRepeat as b -> duToKebab b
            | _ -> "Unknown background repeat" 


    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    type BackgroundSize =
        | Cover
        | Contain
        interface IBackgroundSize

    let private backgroundSizeValue (v: IBackgroundSize): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? BackgroundSize as b -> duToLowercase b
            | _ -> "Unknown background size" 

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    type BackgroundAttachment =
        | Scroll
        | Fixed
        | Local
        interface IBackgroundAttachment

    let private backgroundAttachmentValue (v: IBackgroundAttachment): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundAttachment as b -> duToLowercase b
            | _ -> "Unknown background attachment" 