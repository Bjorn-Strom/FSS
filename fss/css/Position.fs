namespace Fss

module PositionType =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface IVerticalAlign

    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface IFloat

    type BoxSizing =
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

    let private positionedToString (positioned: IPositioned) =
        match positioned with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ ->  "Unknown position"

    let private verticalAlignToString (alignment: IVerticalAlign) =
        match alignment with
        | :? VerticalAlign as v -> Utilities.Helpers.duToKebab v
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown vertical align"

    let private floatToString (float: IFloat) =
        match float with
        | :? Float as v -> Utilities.Helpers.duToKebab v
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown float"

    let private directionToString (direction: IDirection) =
        match direction with
        | :? Direction as d -> Utilities.Helpers.duToLowercase d
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown direction"

    let private positionValue value = PropertyValue.cssValue Property.Position value
    let private positionValue' (value: Position) =
        value
        |> Utilities.Helpers.duToKebab
        |> positionValue

    type Position =
        static member Value(position: Position) = position |> positionValue
        static member Static = Static |> positionValue'
        static member Relative = Relative |> positionValue'
        static member Absolute = Absolute |> positionValue'
        static member Sticky = Sticky |> positionValue'
        static member Fixed = Fixed |> positionValue'

    /// <summary>Specifies how an element is to be positioned.</summary>
    /// <param name="position">How to position element</param>
    /// <returns>Css property for fss.</returns>
    let Position' (position: Position) = Position.Value(position)

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

    /// <summary>Specifies vertical position of element.</summary>
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies horizontal position of element.</summary>
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies vertial position of element.</summary>
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies vertical alignment.</summary>
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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
        static member Top = PositionType.VerticalAlign.Top |> verticalAlignValue'
        static member Bottom = PositionType.VerticalAlign.Bottom |> verticalAlignValue'

        static member Inherit = Inherit |> verticalAlignValue'
        static member Initial = Initial |> verticalAlignValue'
        static member Unset = Unset |> verticalAlignValue'

    /// <summary>Specifies vertical alignment.</summary>
    /// <param name="alignment">
    ///     can be:
    ///     - <c> VerticalAlign </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let VerticalAlign' (alignment: IVerticalAlign) = VerticalAlign.Value(alignment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue value = PropertyValue.cssValue Property.Float value
    let private floatValue' value =
        value
        |> floatToString
        |> floatValue

    type Float =
        static member Value (float: IFloat) = float |> floatValue'
        static member Left = PositionType.Float.Left |> floatValue'
        static member Right = PositionType.Float.Right |> floatValue'
        static member InlineStart = InlineStart |> floatValue'
        static member InlineEnd = InlineEnd |> floatValue'

        static member None = None |> floatValue'
        static member Inherit = Inherit |> floatValue'
        static member Initial = Initial |> floatValue'
        static member Unset = Unset |> floatValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="float">
    ///     can be:
    ///     - <c> Float </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Float' (float: IFloat) = Float.Value(float)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue value = PropertyValue.cssValue Property.BoxSizing value
    let private boxSizingValue' (value: BoxSizing) =
        value
        |> Utilities.Helpers.duToKebab
        |> boxSizingValue
    type BoxSizing =
        static member Value (boxSizing: PositionType.BoxSizing) = boxSizing |> boxSizingValue'
        static member ContentBox = ContentBox |> boxSizingValue'
        static member BorderBox = BorderBox |> boxSizingValue'

    /// <summary>Specifies how the total width and height of an elemenent is calculated.</summary>
    /// <param name="sizing"> How to calculate width and height How to calculate width. </param>
    /// <returns>Css property for fss.</returns>
    let BoxSizing' (sizing: PositionType.BoxSizing) = BoxSizing.Value(sizing)

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

    /// <summary>Specifies element float.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> Direction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Direction' (direction: IDirection) = Direction.Value(direction)

module WritingModeType =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface IWritingMode

[<AutoOpen>]
module WritingMode =
    open WritingModeType

    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    let private writingModeToString (writingMode: IWritingMode) =
        match writingMode with
        | :? WritingMode as w -> Utilities.Helpers.duToKebab w
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown writing mode"

    let private writingModeValue value = PropertyValue.cssValue Property.WritingMode value
    let private writingModeValue' value =
        value
        |> writingModeToString
        |> writingModeValue

    type WritingMode =
        static member Value (writingMode: IWritingMode) = writingMode |> writingModeValue'

        static member HorizontalTb = HorizontalTb |> writingModeValue'
        static member VerticalRl = VerticalRl |> writingModeValue'
        static member VerticalLr = VerticalLr |> writingModeValue'
        static member Inherit = Inherit |> writingModeValue'
        static member Initial = Initial |> writingModeValue'
        static member Unset = Unset |> writingModeValue'

    /// <summary>Specifies direction elements are written.</summary>
    /// <param name="writingMode">
    ///     can be:
    ///     - <c> WritingMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WritingMode' (writingMode: IWritingMode) = writingMode |> WritingMode.Value

module BreakTypes =
    type BreakAfter =
        | Avoid
        | Always
        | All
        | AvoidPage
        | Page
        | Left
        | Right
        | Recto
        | Verso
        | AvoidColumn
        | Column
        | AvoidRegion
        | Region
        interface IBreakAfter

    type BreakBefore =
        | Avoid
        | Always
        | All
        | AvoidPage
        | Page
        | Left
        | Right
        | Recto
        | Verso
        | AvoidColumn
        | Column
        | AvoidRegion
        | Region
        interface IBreakBefore

    type BreakInside =
        | Avoid
        | AvoidPage
        | AvoidColumn
        | AvoidRegion
        interface IBreakInside

[<AutoOpen>]
module Break =
    open BreakTypes

    let private breakAfterToString (breakAfter: IBreakAfter) =
        match breakAfter with
        | :? BreakAfter as w -> Utilities.Helpers.duToKebab w
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown break after"

    let private breakBeforeToString (breakBefore: IBreakBefore) =
        match breakBefore with
        | :? BreakBefore as w -> Utilities.Helpers.duToKebab w
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown break before"

    let private breakInsideToString (breakInside: IBreakInside) =
        match breakInside with
        | :? BreakInside as w -> Utilities.Helpers.duToKebab w
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown break before"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    let private breakAfterValue value = PropertyValue.cssValue Property.BreakAfter value
    let private breakAfterValue' value =
        value
        |> breakAfterToString
        |> breakAfterValue

    type BreakAfter =
        static member Value (breakAfter: IBreakAfter) = breakAfter |> breakAfterValue'
        static member Avoid = BreakTypes.BreakAfter.Avoid |> breakAfterValue'
        static member Always = BreakTypes.BreakAfter.Always |> breakAfterValue'
        static member All = BreakTypes.BreakAfter.All |> breakAfterValue'
        static member AvoidPage = BreakTypes.BreakAfter.AvoidPage |> breakAfterValue'
        static member Page = BreakTypes.BreakAfter.Page |> breakAfterValue'
        static member Left = BreakTypes.BreakAfter.Left |> breakAfterValue'
        static member Right = BreakTypes.BreakAfter.Right |> breakAfterValue'
        static member Recto = BreakTypes.BreakAfter.Recto |> breakAfterValue'
        static member Verso = BreakTypes.BreakAfter.Verso |> breakAfterValue'
        static member AvoidColumn = BreakTypes.BreakAfter.AvoidColumn |> breakAfterValue'
        static member Column = BreakTypes.BreakAfter.Column |> breakAfterValue'
        static member AvoidRegion = BreakTypes.BreakAfter.AvoidRegion |> breakAfterValue'
        static member Region = BreakTypes.BreakAfter.Region |> breakAfterValue'

        static member Auto = Auto |> breakAfterValue'
        static member Inherit = Inherit |> breakAfterValue'
        static member Initial = Initial |> breakAfterValue'
        static member Unset = Unset |> breakAfterValue'

    /// <summary>Specifies how elements behave after a generated box.</summary>
    /// <param name="breakAfter">
    ///     can be:
    ///     - <c> BreakAfter </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakAfter' (breakAfter: IBreakAfter) = breakAfter |> BreakAfter.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    let private breakBeforeValue value = PropertyValue.cssValue Property.BreakBefore value
    let private breakBeforeValue' value =
        value
        |> breakBeforeToString
        |> breakBeforeValue

    type BreakBefore =
        static member Value (breakBefore: IBreakBefore) = breakBefore |> breakBeforeValue'
        static member Avoid = BreakTypes.BreakBefore.Avoid |> breakBeforeValue'
        static member Always = BreakTypes.BreakBefore.Always |> breakBeforeValue'
        static member All = BreakTypes.BreakBefore.All |> breakBeforeValue'
        static member AvoidPage = BreakTypes.BreakBefore.AvoidPage |> breakBeforeValue'
        static member Page = BreakTypes.BreakBefore.Page |> breakBeforeValue'
        static member Left = BreakTypes.BreakBefore.Left |> breakBeforeValue'
        static member Right = BreakTypes.BreakBefore.Right |> breakBeforeValue'
        static member Recto = BreakTypes.BreakBefore.Recto |> breakBeforeValue'
        static member Verso = BreakTypes.BreakBefore.Verso |> breakBeforeValue'
        static member AvoidColumn = BreakTypes.BreakBefore.AvoidColumn |> breakBeforeValue'
        static member Column = BreakTypes.BreakBefore.Column |> breakBeforeValue'
        static member AvoidRegion = BreakTypes.BreakBefore.AvoidRegion |> breakBeforeValue'
        static member Region = BreakTypes.BreakBefore.Region |> breakBeforeValue'

        static member Auto = Auto |> breakBeforeValue'
        static member Inherit = Inherit |> breakBeforeValue'
        static member Initial = Initial |> breakBeforeValue'
        static member Unset = Unset |> breakBeforeValue'

    /// <summary>Specifies how elements behave before a generated box.</summary>
    /// <param name="breakBefore">
    ///     can be:
    ///     - <c> BreakBefore </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakBefore' (breakBefore: IBreakBefore) = breakBefore |> BreakBefore.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    let private breakInsideValue value = PropertyValue.cssValue Property.BreakInside value
    let private breakInsideValue' value =
        value
        |> breakInsideToString
        |> breakInsideValue

    type BreakInside =
        static member Value (breakInside: IBreakInside) = breakInside |> breakInsideValue'
        static member Avoid = BreakTypes.BreakInside.Avoid |> breakInsideValue'
        static member AvoidPage = BreakTypes.BreakInside.AvoidPage |> breakInsideValue'
        static member AvoidColumn = BreakTypes.BreakInside.AvoidColumn |> breakInsideValue'
        static member AvoidRegion = BreakTypes.BreakInside.AvoidRegion |> breakInsideValue'

        static member Auto = Auto |> breakInsideValue'
        static member Inherit = Inherit |> breakInsideValue'
        static member Initial = Initial |> breakInsideValue'
        static member Unset = Unset |> breakInsideValue'

    /// <summary>Specifies how elements behave inside a generated box.</summary>
    /// <param name="breakInside">
    ///     can be:
    ///     - <c> BreakInside </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BreakInside' (breakInside: IBreakInside) = breakInside |> BreakInside.Value

