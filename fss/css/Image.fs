namespace Fss

[<AutoOpen>]
module ImageTypes =
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

    type Side =
        | ClosestSide
        | ClosestCorner
        | FarthestSide
        | FarthestCorner

    type Shape =
        | Circle
        | Ellipse

    type ColorStop =
        | ColorStop of CSSColor * ILengthPercentage
        | ColorStop2 of (CSSColor * ILengthPercentage * ILengthPercentage)
        interface IColorStop

module Image =
    let private sideOrCornerValue (value: SideOrCorner) = Utilities.Helpers.duToSpaced value
    let private positionValue (value: ImagePosition) = Utilities.Helpers.duToSpaced value
    let private sideValue (value: Side) = Utilities.Helpers.duToKebab value

    let private colorAndStopToString (colorStop: IColorStop) =
        let stringifyColorStop =
            function
                | ColorStop (c, s) -> sprintf "%s %s" (CSSColorValue.color c) (Units.LengthPercentage.value s)
                | ColorStop2 (c, s1, s2) -> sprintf "%s %s %s" (CSSColorValue.color c) (Units.LengthPercentage.value s1) (Units.LengthPercentage.value s2)

        match colorStop with
        | :? CSSColor as c -> CSSColorValue.color c
        | :? ColorStop as cs -> stringifyColorStop cs
        | _ -> "Unknown color and stop"

    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
             sprintf "linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
             sprintf "linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member LinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
             sprintf "linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
             sprintf "linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member LinearGradient (angle: Units.Angle.Angle, (colors: IColorStop list)) =
             sprintf "linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, (colors: IColorStop list)) =
             sprintf "linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

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
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
             sprintf "repeating-linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
             sprintf "repeating-linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
             sprintf "repeating-linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
             sprintf "repeating-linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, (colors: IColorStop list)) =
             sprintf "repeating-linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, (colors: IColorStop list)) =
             sprintf "repeating-linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
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

        static member RadialGradient (start: CSSColor, last: CSSColor) =
             sprintf "radial-gradient(%s, %s)"
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RadialGradient (start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (colors: CSSColor list) =
             sprintf "radial-gradient(%s)"
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RadialGradient (colorsAndStop: IColorStop list) =
             sprintf "radial-gradient(%s)"
                   (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
             sprintf "radial-gradient(%A, %s, %s)"
                shape
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A, %s, %s)"
                shape
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, colors: CSSColor list) =
             sprintf "radial-gradient(%A, %s)"
                shape
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RadialGradient (shape: Shape, colorsAndStop: IColorStop list) =
             sprintf "radial-gradient(%A, %s)"
                shape
                (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                shape
                (positionValue position)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RadialGradient (shape: Shape, position: ImagePosition, (start: IColorStop), (last: IColorStop)) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                shape
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
             sprintf "radial-gradient(%A %s, %s)"
                shape
                (positionValue position)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: IColorStop list) =
             sprintf "radial-gradient(%A %s, %s)"
                shape
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                shape
                (sideValue side)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                shape
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
             sprintf "radial-gradient(%A %s, %s)"
                shape
                (sideValue side)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RadialGradient (shape: Shape, side: Side, colorsAndStop: IColorStop list) =
             sprintf "radial-gradient(%A %s, %s)"
                shape
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
             sprintf "radial-gradient(%A %s %s, %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: IColorStop, last: IColorStop) =
             sprintf "radial-gradient(%A %s %s, %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
             sprintf "radial-gradient(%A %s %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: IColorStop list) =
             sprintf "radial-gradient(%A %s %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RepeatingRadialGradient (start: CSSColor, last: CSSColor) =
             sprintf "repeating-radial-gradient(%s, %s)"
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingRadialGradient (start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (colors: CSSColor list) =
             sprintf "repeating-radial-gradient(%s)"
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingRadialGradient (colorsAndStop: IColorStop list) =
             sprintf "repeating-radial-gradient(%s)"
                   (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
             sprintf "repeating-radial-gradient(%A, %s, %s)"
                shape
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingRadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A, %s, %s)"
                shape
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, colors: CSSColor list) =
             sprintf "repeating-radial-gradient(%A, %s)"
                shape
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingRadialGradient (shape: Shape, colorsAndStop: IColorStop list) =
             sprintf "repeating-radial-gradient(%A, %s)"
                   shape
                   (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                shape
                (positionValue position)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, (start: IColorStop), (last: IColorStop)) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                shape
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                shape
                (positionValue position)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: IColorStop list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                shape
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                shape
                (sideValue side)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                shape
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                shape
                (sideValue side)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colorsAndStop: IColorStop list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                shape
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
             sprintf "repeating-radial-gradient(%A %s %s, %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (CSSColorValue.color start)
                (CSSColorValue.color last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: IColorStop, last: IColorStop) =
             sprintf "repeating-radial-gradient(%A %s %s, %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
             sprintf "repeating-radial-gradient(%A %s %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma CSSColorValue.color colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: IColorStop list) =
             sprintf "repeating-radial-gradient(%A %s %s, %s)"
                shape
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colorsAndStop)



