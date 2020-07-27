namespace Fss

open Types
open Units.Angle
open Units.Size
open Utilities.Helpers
open Color

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
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
 
// https://developer.mozilla.org/en-US/docs/Web/CSS/linear-gradient
module LinearGradient = 
    open BackgroundPosition

    let value (v: ILinearGradient): string =
        match v with
            | :? Angle as a -> Units.Angle.value a
            | :? Size as s -> Units.Size.value s
            | :? CssColor as c -> Color.value c
            | :? BackgroundPosition as p -> sprintf "to %s" <| BackgroundPosition.value p
            | _ -> "Unknown linear gradient value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/radial-gradient
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

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
module BackgroundImage =
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

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
module BackgroundOrigin =
    open Global

    type BackgroundOrigin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface IBackgroundOrigin
        interface IBackgroundClip

    let private backgroundOriginValue (v: BackgroundOrigin): string =
        match v with
            | BorderBox -> "border-box"
            | PaddingBox -> "padding-box"
            | ContentBox -> "content-box"

    let value (v: IBackgroundOrigin): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundOrigin as b -> backgroundOriginValue b
            | _ -> "Unknown background origin" 

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
module BackgroundClip =
    open Global
    open BackgroundOrigin

    type BackgroundClip =
        | Text
        interface IBackgroundClip

    let private backgroundClipValue (v: BackgroundClip): string =
        match v with
            | Text -> "text"

    let value (v: IBackgroundClip): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundOrigin as b -> BackgroundOrigin.value b
            | :? BackgroundClip as b -> backgroundClipValue b
            | _ -> "Unknown background clip" 

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
module BackgroundRepeat =
    open Global

    type BackgroundRepeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface IBackgroundRepeat

    let private backgroundRepeatValue (v: BackgroundRepeat): string =
        match v with
            | RepeatX -> "repeat-x"
            | RepeatY -> "repeat-y"
            | Repeat -> "repeat"
            | Space -> "space"
            | Round -> "round"
            | NoRepeat -> "no-repeat"

    let value (v: IBackgroundRepeat): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundRepeat as b -> backgroundRepeatValue b
            | _ -> "Unknown background repeat" 


// https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
module BackgroundSize =
    open Global
    open Units.Size

    type BackgroundSize =
        | Cover
        | Contain
        interface IBackgroundSize

    let private backgroundSizeValue (v: BackgroundSize): string =
        match v with
            | Cover -> "cover"
            | Contain -> "contain"

    let value (v: IBackgroundSize): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Size as s -> Units.Size.value s
            | :? BackgroundSize as b -> backgroundSizeValue b
            | _ -> "Unknown background size" 

// https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
module BackgroundAttachment =
    open Global

    type BackgroundAttachment =
        | Scroll
        | Fixed
        | Local
        interface IBackgroundAttachment

    let private backgroundAttachmentValue (v: BackgroundAttachment): string =
        match v with
            | Scroll -> "scroll"
            | Fixed -> "fixed"
            | Local -> "local"

    let value (v: IBackgroundAttachment): string =
        match v with
            | :? Global as g -> Global.value g
            | :? BackgroundAttachment as b -> backgroundAttachmentValue b
            | _ -> "Unknown background attachment" 