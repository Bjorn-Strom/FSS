namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/position
[<AutoOpen>]
module Position =

    let private positionedToString (positioned: FssTypes.IPositioned) =
        match positioned with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ ->  "Unknown position"

    let private verticalAlignToString (alignment: FssTypes.IVerticalAlign) =
        match alignment with
        | :? FssTypes.Position.VerticalAlign as v -> Utilities.Helpers.duToKebab v
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown vertical align"

    let private floatToString (float: FssTypes.IFloat) =
        match float with
        | :? FssTypes.Position.Float as v -> Utilities.Helpers.duToKebab v
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown float"

    let private directionToString (direction: FssTypes.IDirection) =
        match direction with
        | :? FssTypes.Position.Direction as d -> Utilities.Helpers.duToLowercase d
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown direction"

    let private positionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Position value
    let private positionValue' (value: FssTypes.Position.Position) =
        value
        |> Utilities.Helpers.duToKebab
        |> positionValue

    type Position =
        static member Value(position: Position) = position |> positionValue
        static member Static = FssTypes.Position.Static |> positionValue'
        static member Relative = FssTypes.Position.Relative |> positionValue'
        static member Absolute = FssTypes.Position.Absolute |> positionValue'
        static member Sticky = FssTypes.Position.Sticky |> positionValue'
        static member Fixed = FssTypes.Position.Fixed |> positionValue'

    /// <summary>Specifies how an element is to be positioned.</summary>
    /// <param name="position">How to position element</param>
    /// <returns>Css property for fss.</returns>
    let Position' (position: Position) = Position.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    let private topValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Top value
    let private topValue' value =
        value
        |> positionedToString
        |> topValue

    type Top =
        static member Value (top: FssTypes.IPositioned) = top |> topValue'
        static member Auto = FssTypes.Auto |> topValue'
        static member Inherit = FssTypes.Inherit |> topValue'
        static member Initial = FssTypes.Initial |> topValue'
        static member Unset = FssTypes.Unset |> topValue'

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
    let Top' (top: FssTypes.IPositioned) = Top.Value(top)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    let private rightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Right value
    let private rightValue' value =
        value
        |> positionedToString
        |> rightValue

    type Right =
        static member Value (right: FssTypes.IPositioned) = right |> rightValue'

        static member Auto = FssTypes.Auto |> rightValue'
        static member Inherit = FssTypes.Inherit |> rightValue'
        static member Initial = FssTypes.Initial |> rightValue'
        static member Unset = FssTypes.Unset |> rightValue'

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
    let Right' (right: FssTypes.IPositioned) = Right.Value(right)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    let private bottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Bottom value
    let private bottomValue' value =
        value
        |> positionedToString
        |> bottomValue

    type Bottom =
        static member Value (bottom: FssTypes.IPositioned) = bottom |> bottomValue'

        static member Auto = FssTypes.Auto |> bottomValue'
        static member Inherit = FssTypes.Inherit |> bottomValue'
        static member Initial = FssTypes.Initial |> bottomValue'
        static member Unset = FssTypes.Unset |> bottomValue'

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
    let Bottom' (bottom: FssTypes.IPositioned) = Bottom.Value(bottom)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    let private leftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Left value
    let private leftValue' value =
        value
        |> positionedToString
        |> leftValue

    type Left =
        static member Value (left: FssTypes.IPositioned) = left |> leftValue'

        static member Auto = FssTypes.Auto |> leftValue'
        static member Inherit = FssTypes.Inherit |> leftValue'
        static member Initial = FssTypes.Initial |> leftValue'
        static member Unset = FssTypes.Unset |> leftValue'

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
    let Left' (left: FssTypes.IPositioned) = Left.Value(left)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    let private verticalAlignValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.VerticalAlign value
    let private verticalAlignValue' value =
        value
        |> verticalAlignToString
        |> verticalAlignValue

    type VerticalAlign =
        static member Value (alignment: FssTypes.IVerticalAlign) = alignment |> verticalAlignValue'
        static member Baseline = FssTypes.Position.VerticalAlign.Baseline |> verticalAlignValue'
        static member Sub = FssTypes.Position.VerticalAlign.Sub |> verticalAlignValue'
        static member Super = FssTypes.Position.VerticalAlign.Super |> verticalAlignValue'
        static member TextTop = FssTypes.Position.VerticalAlign.TextTop |> verticalAlignValue'
        static member TextBottom = FssTypes.Position.VerticalAlign.TextBottom |> verticalAlignValue'
        static member Middle = FssTypes.Position.VerticalAlign.Middle |> verticalAlignValue'
        static member Top = FssTypes.Position.VerticalAlign.Top |> verticalAlignValue'
        static member Bottom = FssTypes.Position.VerticalAlign.Bottom |> verticalAlignValue'

        static member Inherit = FssTypes.Inherit |> verticalAlignValue'
        static member Initial = FssTypes.Initial |> verticalAlignValue'
        static member Unset = FssTypes.Unset |> verticalAlignValue'

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
    let VerticalAlign' (alignment: FssTypes.IVerticalAlign) = VerticalAlign.Value(alignment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Float value
    let private floatValue' value =
        value
        |> floatToString
        |> floatValue

    type Float =
        static member Value (float: FssTypes.IFloat) = float |> floatValue'
        static member Left = FssTypes.Position.Float.Left |> floatValue'
        static member Right = FssTypes.Position.Float.Right |> floatValue'
        static member InlineStart = FssTypes.Position.Float.InlineStart |> floatValue'
        static member InlineEnd = FssTypes.Position.Float.InlineEnd |> floatValue'

        static member None = FssTypes.None' |> floatValue'
        static member Inherit = FssTypes.Inherit |> floatValue'
        static member Initial = FssTypes.Initial |> floatValue'
        static member Unset = FssTypes.Unset |> floatValue'

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
    let Float' (float: FssTypes.IFloat) = Float.Value(float)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxSizing value
    let private boxSizingValue' (value: FssTypes.Position.BoxSizing) =
        value
        |> Utilities.Helpers.duToKebab
        |> boxSizingValue
    type BoxSizing =
        static member Value (boxSizing: FssTypes.Position.BoxSizing) = boxSizing |> boxSizingValue'
        static member ContentBox = FssTypes.Position.BoxSizing.ContentBox |> boxSizingValue'
        static member BorderBox = FssTypes.Position.BoxSizing.BorderBox |> boxSizingValue'

    /// <summary>Specifies how the total width and height of an elemenent is calculated.</summary>
    /// <param name="sizing"> How to calculate width and height How to calculate width. </param>
    /// <returns>Css property for fss.</returns>
    let BoxSizing' (sizing: FssTypes.Position.BoxSizing) = BoxSizing.Value(sizing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    let private directionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Direction value
    let private directionValue' value =
        value
        |> directionToString
        |> directionValue

    type Direction =
        static member Value (direction: FssTypes.IDirection) = direction |> directionValue'
        static member Rtl = FssTypes.Position.Direction.Rtl |> directionValue'
        static member Ltr = FssTypes.Position.Direction.Ltr |> directionValue'
        static member Inherit = FssTypes.Inherit |> directionValue'
        static member Initial = FssTypes.Initial |> directionValue'
        static member Unset = FssTypes.Unset |> directionValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> Direction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Direction' (direction: FssTypes.IDirection) = Direction.Value(direction)

module WritingModeType =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface FssTypes.IWritingMode

[<AutoOpen>]
module WritingMode =
    open WritingModeType

    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    let private writingModeToString (writingMode: FssTypes.IWritingMode) =
        match writingMode with
        | :? WritingMode as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown writing mode"

    let private writingModeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.WritingMode value
    let private writingModeValue' value =
        value
        |> writingModeToString
        |> writingModeValue

    type WritingMode =
        static member Value (writingMode: FssTypes.IWritingMode) = writingMode |> writingModeValue'

        static member HorizontalTb = HorizontalTb |> writingModeValue'
        static member VerticalRl = VerticalRl |> writingModeValue'
        static member VerticalLr = VerticalLr |> writingModeValue'
        static member Inherit = FssTypes.Inherit |> writingModeValue'
        static member Initial = FssTypes.Initial |> writingModeValue'
        static member Unset = FssTypes.Unset |> writingModeValue'

    /// <summary>Specifies direction elements are written.</summary>
    /// <param name="writingMode">
    ///     can be:
    ///     - <c> WritingMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WritingMode' (writingMode: FssTypes.IWritingMode) = writingMode |> WritingMode.Value


[<AutoOpen>]
module Break =
    let private breakAfterToString (breakAfter: FssTypes.IBreakAfter) =
        match breakAfter with
        | :? FssTypes.Position.BreakAfter as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break after"

    let private breakBeforeToString (breakBefore: FssTypes.IBreakBefore) =
        match breakBefore with
        | :? FssTypes.Position.BreakBefore as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    let private breakInsideToString (breakInside: FssTypes.IBreakInside) =
        match breakInside with
        | :? FssTypes.Position.BreakInside as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    let private breakAfterValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakAfter value
    let private breakAfterValue' value =
        value
        |> breakAfterToString
        |> breakAfterValue

    type BreakAfter =
        static member Value (breakAfter: FssTypes.IBreakAfter) = breakAfter |> breakAfterValue'
        static member Avoid = FssTypes.Position.BreakAfter.Avoid |> breakAfterValue'
        static member Always = FssTypes.Position.BreakAfter.Always |> breakAfterValue'
        static member All = FssTypes.Position.BreakAfter.All |> breakAfterValue'
        static member AvoidPage = FssTypes.Position.BreakAfter.AvoidPage |> breakAfterValue'
        static member Page = FssTypes.Position.BreakAfter.Page |> breakAfterValue'
        static member Left = FssTypes.Position.BreakAfter.Left |> breakAfterValue'
        static member Right = FssTypes.Position.BreakAfter.Right |> breakAfterValue'
        static member Recto = FssTypes.Position.BreakAfter.Recto |> breakAfterValue'
        static member Verso = FssTypes.Position.BreakAfter.Verso |> breakAfterValue'
        static member AvoidColumn = FssTypes.Position.BreakAfter.AvoidColumn |> breakAfterValue'
        static member Column = FssTypes.Position.BreakAfter.Column |> breakAfterValue'
        static member AvoidRegion = FssTypes.Position.BreakAfter.AvoidRegion |> breakAfterValue'
        static member Region = FssTypes.Position.BreakAfter.Region |> breakAfterValue'

        static member Auto = FssTypes.Auto |> breakAfterValue'
        static member Inherit = FssTypes.Inherit |> breakAfterValue'
        static member Initial = FssTypes.Initial |> breakAfterValue'
        static member Unset = FssTypes.Unset |> breakAfterValue'

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
    let BreakAfter' (breakAfter: FssTypes.IBreakAfter) = breakAfter |> BreakAfter.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    let private breakBeforeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakBefore value
    let private breakBeforeValue' value =
        value
        |> breakBeforeToString
        |> breakBeforeValue

    type BreakBefore =
        static member Value (breakBefore: FssTypes.IBreakBefore) = breakBefore |> breakBeforeValue'
        static member Avoid = FssTypes.Position.BreakBefore.Avoid |> breakBeforeValue'
        static member Always = FssTypes.Position.BreakBefore.Always |> breakBeforeValue'
        static member All = FssTypes.Position.BreakBefore.All |> breakBeforeValue'
        static member AvoidPage = FssTypes.Position.BreakBefore.AvoidPage |> breakBeforeValue'
        static member Page = FssTypes.Position.BreakBefore.Page |> breakBeforeValue'
        static member Left = FssTypes.Position.BreakBefore.Left |> breakBeforeValue'
        static member Right = FssTypes.Position.BreakBefore.Right |> breakBeforeValue'
        static member Recto = FssTypes.Position.BreakBefore.Recto |> breakBeforeValue'
        static member Verso = FssTypes.Position.BreakBefore.Verso |> breakBeforeValue'
        static member AvoidColumn = FssTypes.Position.BreakBefore.AvoidColumn |> breakBeforeValue'
        static member Column = FssTypes.Position.BreakBefore.Column |> breakBeforeValue'
        static member AvoidRegion = FssTypes.Position.BreakBefore.AvoidRegion |> breakBeforeValue'
        static member Region = FssTypes.Position.BreakBefore.Region |> breakBeforeValue'

        static member Auto = FssTypes.Auto |> breakBeforeValue'
        static member Inherit = FssTypes.Inherit |> breakBeforeValue'
        static member Initial = FssTypes.Initial |> breakBeforeValue'
        static member Unset = FssTypes.Unset |> breakBeforeValue'

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
    let BreakBefore' (breakBefore: FssTypes.IBreakBefore) = breakBefore |> BreakBefore.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    let private breakInsideValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakInside value
    let private breakInsideValue' value =
        value
        |> breakInsideToString
        |> breakInsideValue

    type BreakInside =
        static member Value (breakInside: FssTypes.IBreakInside) = breakInside |> breakInsideValue'
        static member Avoid = FssTypes.Position.BreakInside.Avoid |> breakInsideValue'
        static member AvoidPage = FssTypes.Position.BreakInside.AvoidPage |> breakInsideValue'
        static member AvoidColumn = FssTypes.Position.BreakInside.AvoidColumn |> breakInsideValue'
        static member AvoidRegion = FssTypes.Position.BreakInside.AvoidRegion |> breakInsideValue'

        static member Auto = FssTypes.Auto |> breakInsideValue'
        static member Inherit = FssTypes.Inherit |> breakInsideValue'
        static member Initial = FssTypes.Initial |> breakInsideValue'
        static member Unset = FssTypes.Unset |> breakInsideValue'

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
    let BreakInside' (breakInside: FssTypes.IBreakInside) = breakInside |> BreakInside.Value

