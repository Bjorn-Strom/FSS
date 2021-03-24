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
        static member value(position: Position) = position |> positionValue
        static member static' = FssTypes.Position.Static |> positionValue'
        static member relative = FssTypes.Position.Relative |> positionValue'
        static member absolute = FssTypes.Position.Absolute |> positionValue'
        static member sticky = FssTypes.Position.Sticky |> positionValue'
        static member fixed' = FssTypes.Position.Fixed |> positionValue'

    /// <summary>Specifies how an element is to be positioned.</summary>
    /// <param name="position">How to position element</param>
    /// <returns>Css property for fss.</returns>
    let Position' (position: Position) = Position.value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    let private topValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Top value
    let private topValue' value =
        value
        |> positionedToString
        |> topValue

    type Top =
        static member value (top: FssTypes.IPositioned) = top |> topValue'
        static member auto = FssTypes.Auto |> topValue'
        static member inherit' = FssTypes.Inherit |> topValue'
        static member initial = FssTypes.Initial |> topValue'
        static member unset = FssTypes.Unset |> topValue'

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
    let Top' (top: FssTypes.IPositioned) = Top.value(top)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    let private rightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Right value
    let private rightValue' value =
        value
        |> positionedToString
        |> rightValue

    type Right =
        static member value (right: FssTypes.IPositioned) = right |> rightValue'

        static member auto = FssTypes.Auto |> rightValue'
        static member inherit' = FssTypes.Inherit |> rightValue'
        static member initial = FssTypes.Initial |> rightValue'
        static member unset = FssTypes.Unset |> rightValue'

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
    let Right' (right: FssTypes.IPositioned) = Right.value(right)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    let private bottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Bottom value
    let private bottomValue' value =
        value
        |> positionedToString
        |> bottomValue

    type Bottom =
        static member value (bottom: FssTypes.IPositioned) = bottom |> bottomValue'

        static member auto = FssTypes.Auto |> bottomValue'
        static member inherit' = FssTypes.Inherit |> bottomValue'
        static member initial = FssTypes.Initial |> bottomValue'
        static member unset = FssTypes.Unset |> bottomValue'

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
    let Bottom' (bottom: FssTypes.IPositioned) = Bottom.value(bottom)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    let private leftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Left value
    let private leftValue' value =
        value
        |> positionedToString
        |> leftValue

    type Left =
        static member value (left: FssTypes.IPositioned) = left |> leftValue'

        static member auto = FssTypes.Auto |> leftValue'
        static member inherit' = FssTypes.Inherit |> leftValue'
        static member initial = FssTypes.Initial |> leftValue'
        static member unset = FssTypes.Unset |> leftValue'

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
    let Left' (left: FssTypes.IPositioned) = Left.value(left)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    let private verticalAlignValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.VerticalAlign value
    let private verticalAlignValue' value =
        value
        |> verticalAlignToString
        |> verticalAlignValue

    type VerticalAlign =
        static member value (alignment: FssTypes.IVerticalAlign) = alignment |> verticalAlignValue'
        static member baseline = FssTypes.Position.VerticalAlign.Baseline |> verticalAlignValue'
        static member sub = FssTypes.Position.VerticalAlign.Sub |> verticalAlignValue'
        static member super = FssTypes.Position.VerticalAlign.Super |> verticalAlignValue'
        static member textTop = FssTypes.Position.VerticalAlign.TextTop |> verticalAlignValue'
        static member textBottom = FssTypes.Position.VerticalAlign.TextBottom |> verticalAlignValue'
        static member middle = FssTypes.Position.VerticalAlign.Middle |> verticalAlignValue'
        static member top = FssTypes.Position.VerticalAlign.Top |> verticalAlignValue'
        static member bottom = FssTypes.Position.VerticalAlign.Bottom |> verticalAlignValue'

        static member inherit' = FssTypes.Inherit |> verticalAlignValue'
        static member initial = FssTypes.Initial |> verticalAlignValue'
        static member unset = FssTypes.Unset |> verticalAlignValue'

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
    let VerticalAlign' (alignment: FssTypes.IVerticalAlign) = VerticalAlign.value(alignment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Float value
    let private floatValue' value =
        value
        |> floatToString
        |> floatValue

    type Float =
        static member value (float: FssTypes.IFloat) = float |> floatValue'
        static member left = FssTypes.Position.Float.Left |> floatValue'
        static member right = FssTypes.Position.Float.Right |> floatValue'
        static member inlineStart = FssTypes.Position.Float.InlineStart |> floatValue'
        static member inlineEnd = FssTypes.Position.Float.InlineEnd |> floatValue'

        static member none = FssTypes.None' |> floatValue'
        static member inherit' = FssTypes.Inherit |> floatValue'
        static member initial = FssTypes.Initial |> floatValue'
        static member unset = FssTypes.Unset |> floatValue'

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
    let Float' (float: FssTypes.IFloat) = Float.value(float)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxSizing value
    let private boxSizingValue' (value: FssTypes.Position.BoxSizing) =
        value
        |> Utilities.Helpers.duToKebab
        |> boxSizingValue
    type BoxSizing =
        static member value (boxSizing: FssTypes.Position.BoxSizing) = boxSizing |> boxSizingValue'
        static member contentBox = FssTypes.Position.BoxSizing.ContentBox |> boxSizingValue'
        static member borderBox = FssTypes.Position.BoxSizing.BorderBox |> boxSizingValue'

    /// <summary>Specifies how the total width and height of an elemenent is calculated.</summary>
    /// <param name="sizing"> How to calculate width and height How to calculate width. </param>
    /// <returns>Css property for fss.</returns>
    let BoxSizing' (sizing: FssTypes.Position.BoxSizing) = BoxSizing.value(sizing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    let private directionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Direction value
    let private directionValue' value =
        value
        |> directionToString
        |> directionValue

    type Direction =
        static member value (direction: FssTypes.IDirection) = direction |> directionValue'
        static member rtl = FssTypes.Position.Direction.Rtl |> directionValue'
        static member ltr = FssTypes.Position.Direction.Ltr |> directionValue'
        static member inherit' = FssTypes.Inherit |> directionValue'
        static member initial = FssTypes.Initial |> directionValue'
        static member unset = FssTypes.Unset |> directionValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> Direction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Direction' (direction: FssTypes.IDirection) = Direction.value(direction)

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
        static member value (writingMode: FssTypes.IWritingMode) = writingMode |> writingModeValue'

        static member horizontalTb = HorizontalTb |> writingModeValue'
        static member verticalRl = VerticalRl |> writingModeValue'
        static member verticalLr = VerticalLr |> writingModeValue'
        static member inherit' = FssTypes.Inherit |> writingModeValue'
        static member initial = FssTypes.Initial |> writingModeValue'
        static member unset = FssTypes.Unset |> writingModeValue'

    /// <summary>Specifies direction elements are written.</summary>
    /// <param name="writingMode">
    ///     can be:
    ///     - <c> WritingMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WritingMode' (writingMode: FssTypes.IWritingMode) = writingMode |> WritingMode.value


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
        static member value (breakAfter: FssTypes.IBreakAfter) = breakAfter |> breakAfterValue'
        static member avoid = FssTypes.Position.BreakAfter.Avoid |> breakAfterValue'
        static member always = FssTypes.Position.BreakAfter.Always |> breakAfterValue'
        static member all = FssTypes.Position.BreakAfter.All |> breakAfterValue'
        static member avoidPage = FssTypes.Position.BreakAfter.AvoidPage |> breakAfterValue'
        static member page = FssTypes.Position.BreakAfter.Page |> breakAfterValue'
        static member left = FssTypes.Position.BreakAfter.Left |> breakAfterValue'
        static member right = FssTypes.Position.BreakAfter.Right |> breakAfterValue'
        static member recto = FssTypes.Position.BreakAfter.Recto |> breakAfterValue'
        static member verso = FssTypes.Position.BreakAfter.Verso |> breakAfterValue'
        static member avoidColumn = FssTypes.Position.BreakAfter.AvoidColumn |> breakAfterValue'
        static member column = FssTypes.Position.BreakAfter.Column |> breakAfterValue'
        static member avoidRegion = FssTypes.Position.BreakAfter.AvoidRegion |> breakAfterValue'
        static member region = FssTypes.Position.BreakAfter.Region |> breakAfterValue'

        static member auto = FssTypes.Auto |> breakAfterValue'
        static member inherit' = FssTypes.Inherit |> breakAfterValue'
        static member initial = FssTypes.Initial |> breakAfterValue'
        static member unset = FssTypes.Unset |> breakAfterValue'

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
    let BreakAfter' (breakAfter: FssTypes.IBreakAfter) = breakAfter |> BreakAfter.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    let private breakBeforeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakBefore value
    let private breakBeforeValue' value =
        value
        |> breakBeforeToString
        |> breakBeforeValue

    type BreakBefore =
        static member value (breakBefore: FssTypes.IBreakBefore) = breakBefore |> breakBeforeValue'
        static member avoid = FssTypes.Position.BreakBefore.Avoid |> breakBeforeValue'
        static member always = FssTypes.Position.BreakBefore.Always |> breakBeforeValue'
        static member all = FssTypes.Position.BreakBefore.All |> breakBeforeValue'
        static member avoidPage = FssTypes.Position.BreakBefore.AvoidPage |> breakBeforeValue'
        static member page = FssTypes.Position.BreakBefore.Page |> breakBeforeValue'
        static member left = FssTypes.Position.BreakBefore.Left |> breakBeforeValue'
        static member right = FssTypes.Position.BreakBefore.Right |> breakBeforeValue'
        static member recto = FssTypes.Position.BreakBefore.Recto |> breakBeforeValue'
        static member verso = FssTypes.Position.BreakBefore.Verso |> breakBeforeValue'
        static member avoidColumn = FssTypes.Position.BreakBefore.AvoidColumn |> breakBeforeValue'
        static member column = FssTypes.Position.BreakBefore.Column |> breakBeforeValue'
        static member avoidRegion = FssTypes.Position.BreakBefore.AvoidRegion |> breakBeforeValue'
        static member region = FssTypes.Position.BreakBefore.Region |> breakBeforeValue'

        static member auto = FssTypes.Auto |> breakBeforeValue'
        static member inherit' = FssTypes.Inherit |> breakBeforeValue'
        static member initial = FssTypes.Initial |> breakBeforeValue'
        static member unset = FssTypes.Unset |> breakBeforeValue'

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
    let BreakBefore' (breakBefore: FssTypes.IBreakBefore) = breakBefore |> BreakBefore.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    let private breakInsideValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BreakInside value
    let private breakInsideValue' value =
        value
        |> breakInsideToString
        |> breakInsideValue

    type BreakInside =
        static member value (breakInside: FssTypes.IBreakInside) = breakInside |> breakInsideValue'
        static member avoid = FssTypes.Position.BreakInside.Avoid |> breakInsideValue'
        static member avoidPage = FssTypes.Position.BreakInside.AvoidPage |> breakInsideValue'
        static member avoidColumn = FssTypes.Position.BreakInside.AvoidColumn |> breakInsideValue'
        static member avoidRegion = FssTypes.Position.BreakInside.AvoidRegion |> breakInsideValue'

        static member auto = FssTypes.Auto |> breakInsideValue'
        static member inherit' = FssTypes.Inherit |> breakInsideValue'
        static member initial = FssTypes.Initial |> breakInsideValue'
        static member unset = FssTypes.Unset |> breakInsideValue'

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
    let BreakInside' (breakInside: FssTypes.IBreakInside) = breakInside |> BreakInside.value

