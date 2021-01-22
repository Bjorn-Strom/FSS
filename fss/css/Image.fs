namespace Fss

[<AutoOpen>]
module Image =
    type SideOrCorner =
        | ToTop
        | ToTopRight
        | ToTopLeft
        | ToRight
        | ToBottom
        | ToBottomRight
        | ToBottomLeft
        | ToLeft

    type ImagePosition =
        | AtTop
        | AtTopRight
        | AtTopLeft
        | AtTopCenter
        | AtRightTop
        | AtRightBottom
        | AtBottom
        | AtBottomRight
        | AtBottomLeft
        | AtBottomCenter
        | AtCenter
        | AtCenterRight
        | AtCenterLeft
        | AtCenterBottom
        | AtLeft
        | Position of int * int
        | Percent of Units.Percent.Percent

    type Side =
        | ClosestSide
        | ClosestCorner
        | FarthestSide
        | FarthestCorner

    type Shape =
        | Circle
        | Ellipse
        | CircleAt of ImagePosition
        | EllipseAt of ImagePosition

    type ColorStop =
        | ColorStop of CssColor * ILengthPercentage
        | ColorStop2 of (CssColor * ILengthPercentage * ILengthPercentage)
        interface IColorStop

    let private sideOrCornerValue (value: SideOrCorner) = Utilities.Helpers.duToSpaced value
    let private positionValue (value: ImagePosition) =
        match value with
        | Position (x,y) -> sprintf "at %d, %d" x y
        | Percent p -> sprintf "at %s" (Units.Percent.value p)
        | _ -> Utilities.Helpers.duToSpaced value
    let private sideValue (value: Side) = Utilities.Helpers.duToKebab value
    let private shapeValue (value: Shape) =
        match value with
        | CircleAt position -> sprintf "circle %s" (positionValue position)
        | EllipseAt position -> sprintf "ellipse %s" (positionValue position)
        | _ -> Utilities.Helpers.duToLowercase value


    let private colorAndStopToString (colorStop: IColorStop) =
        let stringifyColorStop =
            function
                | ColorStop (c, s) -> sprintf "%s %s" (CssColorValue.color c) (Units.LengthPercentage.value s)
                | ColorStop2 (c, s1, s2) -> sprintf "%s %s %s" (CssColorValue.color c) (Units.LengthPercentage.value s1) (Units.LengthPercentage.value s2)

        match colorStop with
        | :? CssColor as c -> CssColorValue.color c
        | :? ColorStop as cs -> stringifyColorStop cs
        | _ -> "Unknown color and stop"

    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (start: IColorStop, last: IColorStop) =
            sprintf "linear-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            sprintf "linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
             sprintf "linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (colors: IColorStop list) =
            sprintf "linear-gradient(%s)" <| Utilities.Helpers.combineComma colorAndStopToString colors
        static member LinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            sprintf "linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
             sprintf "linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CssColor list) =
             sprintf "linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma CssColorValue.color colors)

        static member RepeatingLinearGradient (start: IColorStop, last: IColorStop) =
            sprintf "repeating-linear-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            sprintf "repeating-linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
             sprintf "repeating-linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (colors: IColorStop list) =
            sprintf "repeating-linear-gradient(%s)" <| Utilities.Helpers.combineComma colorAndStopToString colors
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            sprintf "repeating-linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
             sprintf "repeating-linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

        static member RadialGradient (start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (colors: IColorStop list) =
             sprintf "radial-gradient(%s)" (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (side: Side, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A, %s, %s)"
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A, %s, %s)"
                (shapeValue shape)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (side: Side, colors: IColorStop list) =
             sprintf "radial-gradient(%A, %s)" (sideValue side) (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, colors: IColorStop list) =
             sprintf "radial-gradient(%A, %s)" (shapeValue shape) (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
             sprintf "radial-gradient(%A %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

        static member RepeatingRadialGradient (start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (colors: IColorStop list) =
             sprintf "repeating-radial-gradient(%s)" (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A, %s, %s)"
                (shapeValue shape)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, colors: IColorStop list) =
             sprintf "repeating-radial-gradient(%A, %s)" (shapeValue shape) (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A %s %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: IColorStop list) =
             sprintf "repeating-radial-gradient(%A %s %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colors)