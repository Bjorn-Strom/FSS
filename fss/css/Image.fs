namespace Fss

module Image =
    open Types
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    type Position =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface IImagePosition
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
        | CircleAt of IImagePosition list
        | EllipseAt of IImagePosition list
        interface IRadialGradient

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    type Image  =
        | Url of string
        | LinearGradient of ILinearGradient list
        | RadialGradient of IRadialGradient list
        | RepeatingLinearGradient of ILinearGradient list
        | RepeatingRadialGradient of IRadialGradient list
        interface IImage
        interface IContent
    
module ImageValue =
    open Types
    open Image
    open Global
    open Color
    open Units.Percent
    open Units.Angle
    open Utilities.Helpers
    
    let position (v: IImagePosition): string =
        match v with
            | :? Global          as g -> GlobalValue.globalValue g
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? Position        as position -> duToLowercase position
            | _ -> "Unknown background position"

    let color (v: IBackgroundColor): string =
        match v with
            | :? CssColor as c -> Color.value c
            | _ -> "Unknown background color"


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

    let linearGradientValue g = sprintf "linear-gradient(%s)"  (g |> List.sortBy compareLinearGradient |> combineGradient linearGradient)

    
    let image (v: IImage): string =
        let stringifyImage (b: Image) =
            match b with
            | Url u -> sprintf "url(%s)" u
            | LinearGradient g -> linearGradientValue g
            | RadialGradient g -> sprintf "radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradient)
            | RepeatingLinearGradient g -> sprintf "repeating-linear-gradient(%s)" (g |> List.sortBy compareLinearGradient |> combineGradient linearGradient)
            | RepeatingRadialGradient g -> sprintf "repeating-radial-gradient(%s)" (g |> List.sortBy compareRadialGradient |> combineGradient2 radialGradient)

        match v with
            | :? Image  as i -> stringifyImage i
            | :? Global as g -> GlobalValue.globalValue g
            | :? None   as n -> GlobalValue.none n
            | _ -> "unknown background image"