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
        | Position of int * int
        | Percent of Units.Percent.Percent

    type Side =
        | ClosestSide
        | ClosestCorner
        | FarthestSide
        | FarthestCorner

    type Shape =
        | Circle of ImagePosition
        | Ellipse of ImagePosition

    type ColorStop =
        | Color of CSSColor
        | ColorStop of CSSColor * ILengthPercentage
        | ColorStop2 of (CSSColor * ILengthPercentage * ILengthPercentage)
        interface IColorStop

module Image =
    let private sideOrCornerValue (value: SideOrCorner) = Utilities.Helpers.duToSpaced value
    let private positionValue (value: ImagePosition) =
        match value with
        | Position (x,y) -> sprintf "at %d, %d" x y
        | Percent p -> sprintf "at %s" (Units.Percent.value p)
        | _ -> Utilities.Helpers.duToSpaced value
    let private sideValue (value: Side) = Utilities.Helpers.duToKebab value
    let private shapeValue (value: Shape) =
        match value with
        | Circle position -> sprintf "circle %s" (positionValue position)
        | Ellipse position -> sprintf "ellipse %s" (positionValue position)

    let private colorAndStopToString (colorStop: IColorStop) =
        let stringifyColorStop =
            function
                | Color c -> CSSColorValue.color c
                | ColorStop (c, s) -> sprintf "%s %s" (CSSColorValue.color c) (Units.LengthPercentage.value s)
                | ColorStop2 (c, s1, s2) -> sprintf "%s %s %s" (CSSColorValue.color c) (Units.LengthPercentage.value s1) (Units.LengthPercentage.value s2)

        match colorStop with
        | :? ColorStop as cs -> stringifyColorStop cs
        | _ -> "Unknown color and stop"

    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (start: ColorStop, last: ColorStop) =
            sprintf "linear-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (angle: Units.Angle.Angle, start: ColorStop, last: ColorStop) =
            sprintf "linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: ColorStop, last: ColorStop) =
             sprintf "linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member LinearGradient (colors: ColorStop list) =
            sprintf "linear-gradient(%s)" <| Utilities.Helpers.combineComma colorAndStopToString colors
        static member LinearGradient (angle: Units.Angle.Angle, colors: ColorStop list) =
            sprintf "linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: ColorStop list) =
             sprintf "linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

        static member RepeatingLinearGradient (start: ColorStop, last: ColorStop) =
            sprintf "repeating-linear-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: ColorStop, last: ColorStop) =
            sprintf "repeating-linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: ColorStop, last: ColorStop) =
             sprintf "repeating-linear-gradient(%s, %s, %s)"
                (sideOrCornerValue sideOrCorner)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingLinearGradient (colors: ColorStop list) =
            sprintf "repeating-linear-gradient(%s)" <| Utilities.Helpers.combineComma colorAndStopToString colors
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: ColorStop list) =
            sprintf "repeating-linear-gradient(%s, %s)"
                (Units.Angle.value angle)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: ColorStop list) =
             sprintf "repeating-linear-gradient(%s, %s)"
                (sideOrCornerValue sideOrCorner)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

        static member RadialGradient (start: ColorStop, last: ColorStop) =
             sprintf "radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (colors: ColorStop list) =
             sprintf "radial-gradient(%s)" (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, start: ColorStop, last: ColorStop) =
             sprintf "radial-gradient(%A, %s, %s)"
                (shapeValue shape)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, colors: ColorStop list) =
             sprintf "radial-gradient(%A, %s)" (shapeValue shape) (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, position: ImagePosition, start: ColorStop, last: ColorStop) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: ColorStop list) =
            sprintf "radial-gradient(%A %s, %s)"
               (shapeValue shape)
               (positionValue position)
               (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, side: Side, start: ColorStop, last: ColorStop) =
             sprintf "radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, side: Side, colors: ColorStop list) =
             sprintf "radial-gradient(%A %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: ColorStop, last: ColorStop) =
             sprintf "radial-gradient(%A %s %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: ColorStop list) =
             sprintf "radial-gradient(%A %s %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colors)

        static member RepeatingRadialGradient (start: ColorStop, last: ColorStop) =
             sprintf "repeating-radial-gradient(%s, %s)"
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (colors: ColorStop list) =
             sprintf "repeating-radial-gradient(%s)" (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, start: ColorStop, last: ColorStop) =
             sprintf "repeating-radial-gradient(%A, %s, %s)"
                (shapeValue shape)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, colors: ColorStop list) =
             sprintf "repeating-radial-gradient(%A, %s)" (shapeValue shape) (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, start: ColorStop, last: ColorStop) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: ColorStop list) =
            sprintf "repeating-radial-gradient(%A %s, %s)"
               (shapeValue shape)
               (positionValue position)
               (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: ColorStop, last: ColorStop) =
             sprintf "repeating-radial-gradient(%A %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: ColorStop list) =
             sprintf "repeating-radial-gradient(%A %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: ColorStop, last: ColorStop) =
             sprintf "repeating-radial-gradient(%A %s %s, %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (colorAndStopToString start)
                (colorAndStopToString last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: ColorStop list) =
             sprintf "repeating-radial-gradient(%A %s %s, %s)"
                (shapeValue shape)
                (sideValue side)
                (positionValue position)
                (Utilities.Helpers.combineComma colorAndStopToString colors)
        (*
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



*)