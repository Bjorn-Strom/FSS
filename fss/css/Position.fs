namespace Fss

module PositionType =
    type PositionType =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed

    type VerticalAlignType =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface IVerticalAlign

    type FloatType =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface IFloat

    type BoxSizingType =
        | ContentBox
        | BorderBox

    type Direction =
        | Rtl
        | Ltr
        interface IDirection

// https://developer.mozilla.org/en-US/docs/Web/CSS/position
[<AutoOpen>]
module Position =
    open PositionType
    let private positionToString =
        function
            | Static -> "static"
            | Relative -> "relative"
            | Absolute -> "absolute"
            | Sticky -> "sticky"
            | Fixed -> "fixed"

    let private positionedToString (positioned: IPositioned) =
        match positioned with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Auto -> GlobalValue.auto
        | :? Keywords as k -> GlobalValue.keywords k
        | _ ->  "Unknown position"

    let private verticalAlignToString (alignment: IVerticalAlign) =
        let stringifyAlignment =
            function
                | Baseline -> "baseline"
                | Sub -> "sub"
                | Super -> "super"
                | TextTop -> "text-top"
                | TextBottom -> "text-bottom"
                | Middle -> "middle"
                | Top -> "top"
                | Bottom -> "bottom"

        match alignment with
        | :? VerticalAlignType as v -> stringifyAlignment v
        | :? Keywords as k -> GlobalValue.keywords k
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown vertical align"

    let private floatToString (float: IFloat) =
        let stringifyFloat =
            function
                | Left -> "left"
                | Right -> "right"
                | InlineStart -> "inline-start"
                | InlineEnd -> "inline-end"

        match float with
        | :? FloatType as v -> stringifyFloat v
        | :? Keywords as k -> GlobalValue.keywords k
        | :? None -> GlobalValue.none
        | _ -> "Unknown float"

    let private boxSizingToString =
        function
            | ContentBox -> "content-box"
            | BorderBox -> "border-box"

    let private directionToString (direction: IDirection) =
        let stringifyDirection =
            function
                | Rtl -> "rtl"
                | Ltr -> "ltr"

        match direction with
        | :? Direction as d -> stringifyDirection d
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown direction"

    let private positionValue value = PropertyValue.cssValue Property.Position value
    let private positionValue' value =
        value
        |> positionToString
        |> positionValue

    type Position =
        static member Value(position: PositionType) = position |> positionValue
        static member Static = Static |> positionValue'
        static member Relative = Relative |> positionValue'
        static member Absolute = Absolute |> positionValue'
        static member Sticky = Sticky |> positionValue'
        static member Fixed = Fixed |> positionValue'

    let Position' (position: PositionType) = Position.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    let private topValue value = PropertyValue.cssValue Property.Top value
    let private topValue' value =
        value
        |> positionedToString
        |> topValue

    type Top =
        static member Value (top: IPositioned) = top |> topValue'
        static member Auto = Auto |> topValue'
        static member Inherit = Inherit |> topValue'
        static member Initial = Initial |> topValue'
        static member Unset = Unset |> topValue'

    let Top' (top: IPositioned) = Top.Value(top)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    let private rightValue value = PropertyValue.cssValue Property.Right value
    let private rightValue' value =
        value
        |> positionedToString
        |> rightValue

    type Right =
        static member Value (right: IPositioned) = right |> rightValue'

        static member Auto = Auto |> rightValue'
        static member Inherit = Inherit |> rightValue'
        static member Initial = Initial |> rightValue'
        static member Unset = Unset |> rightValue'

    let Right' (right: IPositioned) = Right.Value(right)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    let private bottomValue value = PropertyValue.cssValue Property.Bottom value
    let private bottomValue' value =
        value
        |> positionedToString
        |> bottomValue

    type Bottom =
        static member Value (bottom: IPositioned) = bottom |> bottomValue'

        static member Auto = Auto |> bottomValue'
        static member Inherit = Inherit |> bottomValue'
        static member Initial = Initial |> bottomValue'
        static member Unset = Unset |> bottomValue'

    let Bottom' (bottom: IPositioned) = Bottom.Value(bottom)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    let private leftValue value = PropertyValue.cssValue Property.Left value
    let private leftValue' value =
        value
        |> positionedToString
        |> leftValue

    type Left =
        static member Value (left: IPositioned) = left |> leftValue'

        static member Auto = Auto |> leftValue'
        static member Inherit = Inherit |> leftValue'
        static member Initial = Initial |> leftValue'
        static member Unset = Unset |> leftValue'

    let Left' (left: IPositioned) = Left.Value(left)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    let private verticalAlignValue value = PropertyValue.cssValue Property.VerticalAlign value
    let private verticalAlignValue' value =
        value
        |> verticalAlignToString
        |> verticalAlignValue

    type VerticalAlign =
        static member Value (alignment: IVerticalAlign) = alignment |> verticalAlignValue'
        static member Baseline = Baseline |> verticalAlignValue'
        static member Sub = Sub |> verticalAlignValue'
        static member Super = Super |> verticalAlignValue'
        static member TextTop = TextTop |> verticalAlignValue'
        static member TextBottom = TextBottom |> verticalAlignValue'
        static member Middle = Middle |> verticalAlignValue'
        static member Top = VerticalAlignType.Top |> verticalAlignValue'
        static member Bottom = VerticalAlignType.Bottom |> verticalAlignValue'

        static member Inherit = Inherit |> verticalAlignValue'
        static member Initial = Initial |> verticalAlignValue'
        static member Unset = Unset |> verticalAlignValue'

    let VerticalAlign' (alignment: IVerticalAlign) = VerticalAlign.Value(alignment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue value = PropertyValue.cssValue Property.Float value
    let private floatValue' value =
        value
        |> floatToString
        |> floatValue

    type Float =
        static member Value (float: IFloat) = float |> floatValue'
        static member Left = FloatType.Left |> floatValue'
        static member Right = FloatType.Right |> floatValue'
        static member InlineStart = InlineStart |> floatValue'
        static member InlineEnd = InlineEnd |> floatValue'

        static member None = None |> floatValue'
        static member Inherit = Inherit |> floatValue'
        static member Initial = Initial |> floatValue'
        static member Unset = Unset |> floatValue'

    let Float' (float: IFloat) = Float.Value(float)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue value = PropertyValue.cssValue Property.BoxSizing value
    let private boxSizingValue' value =
        value
        |> boxSizingToString
        |> boxSizingValue
    type BoxSizing =
        static member Value (boxSizing: BoxSizingType) = boxSizing |> boxSizingValue'
        static member ContentBox = ContentBox |> boxSizingValue'
        static member BorderBox = BorderBox |> boxSizingValue'

    let BoxSizing' (sizing: BoxSizingType) = BoxSizing.Value(sizing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    let private directionValue value = PropertyValue.cssValue Property.Direction value
    let private directionValue' value =
        value
        |> directionToString
        |> directionValue

    type Direction =
        static member Value (direction: IDirection) = direction |> directionValue'
        static member Rtl = Rtl |> directionValue'
        static member Ltr = Ltr |> directionValue'
        static member Inherit = Inherit |> directionValue'
        static member Initial = Initial |> directionValue'
        static member Unset = Unset |> directionValue'

    let Direction' (direction: IDirection) = Direction.Value(direction)