namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/position
[<AutoOpen>]
module Position =

    let private positionedToString (positioned: Types.IPositioned) =
        match positioned with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ ->  "Unknown position"

    let private verticalAlignToString (alignment: Types.IVerticalAlign) =
        match alignment with
        | :? Types.VerticalAlign as v -> Utilities.Helpers.duToKebab v
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | _ -> "Unknown vertical align"

    let private floatToString (float: Types.IFloat) =
        match float with
        | :? Types.Float' as v -> Utilities.Helpers.duToKebab v
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown float"

    let private directionToString (direction: Types.IDirection) =
        match direction with
        | :? Types.Direction as d -> Utilities.Helpers.duToLowercase d
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown direction"

    let private positionValue value = Types.propertyHelpers.cssValue Types.Property.Position value
    let private positionValue' (value: Types.Position) =
        value
        |> Utilities.Helpers.duToKebab
        |> positionValue

    type Position =
        static member Value(position: Position) = position |> positionValue
        static member Static = Types.Position.Static |> positionValue'
        static member Relative = Types.Position.Relative |> positionValue'
        static member Absolute = Types.Position.Absolute |> positionValue'
        static member Sticky = Types.Position.Sticky |> positionValue'
        static member Fixed = Types.Position.Fixed |> positionValue'

    /// <summary>Specifies how an element is to be positioned.</summary>
    /// <param name="position">How to position element</param>
    /// <returns>Css property for fss.</returns>
    let Position' (position: Position) = Position.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    let private topValue value = Types.propertyHelpers.cssValue Types.Property.Top value
    let private topValue' value =
        value
        |> positionedToString
        |> topValue

    type Top =
        static member Value (top: Types.IPositioned) = top |> topValue'
        static member Auto = Types.Auto |> topValue'
        static member Inherit = Types.Inherit |> topValue'
        static member Initial = Types.Initial |> topValue'
        static member Unset = Types.Unset |> topValue'

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
    let Top' (top: Types.IPositioned) = Top.Value(top)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    let private rightValue value = Types.propertyHelpers.cssValue Types.Property.Right value
    let private rightValue' value =
        value
        |> positionedToString
        |> rightValue

    type Right =
        static member Value (right: Types.IPositioned) = right |> rightValue'

        static member Auto = Types.Auto |> rightValue'
        static member Inherit = Types.Inherit |> rightValue'
        static member Initial = Types.Initial |> rightValue'
        static member Unset = Types.Unset |> rightValue'

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
    let Right' (right: Types.IPositioned) = Right.Value(right)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    let private bottomValue value = Types.propertyHelpers.cssValue Types.Property.Bottom value
    let private bottomValue' value =
        value
        |> positionedToString
        |> bottomValue

    type Bottom =
        static member Value (bottom: Types.IPositioned) = bottom |> bottomValue'

        static member Auto = Types.Auto |> bottomValue'
        static member Inherit = Types.Inherit |> bottomValue'
        static member Initial = Types.Initial |> bottomValue'
        static member Unset = Types.Unset |> bottomValue'

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
    let Bottom' (bottom: Types.IPositioned) = Bottom.Value(bottom)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    let private leftValue value = Types.propertyHelpers.cssValue Types.Property.Left value
    let private leftValue' value =
        value
        |> positionedToString
        |> leftValue

    type Left =
        static member Value (left: Types.IPositioned) = left |> leftValue'

        static member Auto = Types.Auto |> leftValue'
        static member Inherit = Types.Inherit |> leftValue'
        static member Initial = Types.Initial |> leftValue'
        static member Unset = Types.Unset |> leftValue'

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
    let Left' (left: Types.IPositioned) = Left.Value(left)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    let private verticalAlignValue value = Types.propertyHelpers.cssValue Types.Property.VerticalAlign value
    let private verticalAlignValue' value =
        value
        |> verticalAlignToString
        |> verticalAlignValue

    type VerticalAlign =
        static member Value (alignment: Types.IVerticalAlign) = alignment |> verticalAlignValue'
        static member Baseline = Types.VerticalAlign.Baseline |> verticalAlignValue'
        static member Sub = Types.VerticalAlign.Sub |> verticalAlignValue'
        static member Super = Types.VerticalAlign.Super |> verticalAlignValue'
        static member TextTop = Types.VerticalAlign.TextTop |> verticalAlignValue'
        static member TextBottom = Types.VerticalAlign.TextBottom |> verticalAlignValue'
        static member Middle = Types.VerticalAlign.Middle |> verticalAlignValue'
        static member Top = Types.VerticalAlign.Top |> verticalAlignValue'
        static member Bottom = Types.VerticalAlign.Bottom |> verticalAlignValue'

        static member Inherit = Types.Inherit |> verticalAlignValue'
        static member Initial = Types.Initial |> verticalAlignValue'
        static member Unset = Types.Unset |> verticalAlignValue'

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
    let VerticalAlign' (alignment: Types.IVerticalAlign) = VerticalAlign.Value(alignment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    let private floatValue value = Types.propertyHelpers.cssValue Types.Property.Float value
    let private floatValue' value =
        value
        |> floatToString
        |> floatValue

    type Float =
        static member Value (float: Types.IFloat) = float |> floatValue'
        static member Left = Types.Float'.Left |> floatValue'
        static member Right = Types.Float'.Right |> floatValue'
        static member InlineStart = Types.Float'.InlineStart |> floatValue'
        static member InlineEnd = Types.Float'.InlineEnd |> floatValue'

        static member None = Types.None' |> floatValue'
        static member Inherit = Types.Inherit |> floatValue'
        static member Initial = Types.Initial |> floatValue'
        static member Unset = Types.Unset |> floatValue'

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
    let Float' (float: Types.IFloat) = Float.Value(float)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    let private boxSizingValue value = Types.propertyHelpers.cssValue Types.Property.BoxSizing value
    let private boxSizingValue' (value: Types.BoxSizing) =
        value
        |> Utilities.Helpers.duToKebab
        |> boxSizingValue
    type BoxSizing =
        static member Value (boxSizing: Types.BoxSizing) = boxSizing |> boxSizingValue'
        static member ContentBox = Types.BoxSizing.ContentBox |> boxSizingValue'
        static member BorderBox = Types.BoxSizing.BorderBox |> boxSizingValue'

    /// <summary>Specifies how the total width and height of an elemenent is calculated.</summary>
    /// <param name="sizing"> How to calculate width and height How to calculate width. </param>
    /// <returns>Css property for fss.</returns>
    let BoxSizing' (sizing: Types.BoxSizing) = BoxSizing.Value(sizing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    let private directionValue value = Types.propertyHelpers.cssValue Types.Property.Direction value
    let private directionValue' value =
        value
        |> directionToString
        |> directionValue

    type Direction =
        static member Value (direction: Types.IDirection) = direction |> directionValue'
        static member Rtl = Types.Direction.Rtl |> directionValue'
        static member Ltr = Types.Direction.Ltr |> directionValue'
        static member Inherit = Types.Inherit |> directionValue'
        static member Initial = Types.Initial |> directionValue'
        static member Unset = Types.Unset |> directionValue'

    /// <summary>Specifies element float.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> Direction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Direction' (direction: Types.IDirection) = Direction.Value(direction)

module WritingModeType =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface Types.IWritingMode

[<AutoOpen>]
module WritingMode =
    open WritingModeType

    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    let private writingModeToString (writingMode: Types.IWritingMode) =
        match writingMode with
        | :? WritingMode as w -> Utilities.Helpers.duToKebab w
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown writing mode"

    let private writingModeValue value = Types.propertyHelpers.cssValue Types.Property.WritingMode value
    let private writingModeValue' value =
        value
        |> writingModeToString
        |> writingModeValue

    type WritingMode =
        static member Value (writingMode: Types.IWritingMode) = writingMode |> writingModeValue'

        static member HorizontalTb = HorizontalTb |> writingModeValue'
        static member VerticalRl = VerticalRl |> writingModeValue'
        static member VerticalLr = VerticalLr |> writingModeValue'
        static member Inherit = Types.Inherit |> writingModeValue'
        static member Initial = Types.Initial |> writingModeValue'
        static member Unset = Types.Unset |> writingModeValue'

    /// <summary>Specifies direction elements are written.</summary>
    /// <param name="writingMode">
    ///     can be:
    ///     - <c> WritingMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WritingMode' (writingMode: Types.IWritingMode) = writingMode |> WritingMode.Value


[<AutoOpen>]
module Break =
    let private breakAfterToString (breakAfter: Types.IBreakAfter) =
        match breakAfter with
        | :? Types.BreakAfter as w -> Utilities.Helpers.duToKebab w
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break after"

    let private breakBeforeToString (breakBefore: Types.IBreakBefore) =
        match breakBefore with
        | :? Types.BreakBefore as w -> Utilities.Helpers.duToKebab w
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    let private breakInsideToString (breakInside: Types.IBreakInside) =
        match breakInside with
        | :? Types.BreakInside as w -> Utilities.Helpers.duToKebab w
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown break before"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    let private breakAfterValue value = Types.propertyHelpers.cssValue Types.Property.BreakAfter value
    let private breakAfterValue' value =
        value
        |> breakAfterToString
        |> breakAfterValue

    type BreakAfter =
        static member Value (breakAfter: Types.IBreakAfter) = breakAfter |> breakAfterValue'
        static member Avoid = Types.BreakAfter.Avoid |> breakAfterValue'
        static member Always = Types.BreakAfter.Always |> breakAfterValue'
        static member All = Types.BreakAfter.All |> breakAfterValue'
        static member AvoidPage = Types.BreakAfter.AvoidPage |> breakAfterValue'
        static member Page = Types.BreakAfter.Page |> breakAfterValue'
        static member Left = Types.BreakAfter.Left |> breakAfterValue'
        static member Right = Types.BreakAfter.Right |> breakAfterValue'
        static member Recto = Types.BreakAfter.Recto |> breakAfterValue'
        static member Verso = Types.BreakAfter.Verso |> breakAfterValue'
        static member AvoidColumn = Types.BreakAfter.AvoidColumn |> breakAfterValue'
        static member Column = Types.BreakAfter.Column |> breakAfterValue'
        static member AvoidRegion = Types.BreakAfter.AvoidRegion |> breakAfterValue'
        static member Region = Types.BreakAfter.Region |> breakAfterValue'

        static member Auto = Types.Auto |> breakAfterValue'
        static member Inherit = Types.Inherit |> breakAfterValue'
        static member Initial = Types.Initial |> breakAfterValue'
        static member Unset = Types.Unset |> breakAfterValue'

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
    let BreakAfter' (breakAfter: Types.IBreakAfter) = breakAfter |> BreakAfter.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    let private breakBeforeValue value = Types.propertyHelpers.cssValue Types.Property.BreakBefore value
    let private breakBeforeValue' value =
        value
        |> breakBeforeToString
        |> breakBeforeValue

    type BreakBefore =
        static member Value (breakBefore: Types.IBreakBefore) = breakBefore |> breakBeforeValue'
        static member Avoid = Types.BreakBefore.Avoid |> breakBeforeValue'
        static member Always = Types.BreakBefore.Always |> breakBeforeValue'
        static member All = Types.BreakBefore.All |> breakBeforeValue'
        static member AvoidPage = Types.BreakBefore.AvoidPage |> breakBeforeValue'
        static member Page = Types.BreakBefore.Page |> breakBeforeValue'
        static member Left = Types.BreakBefore.Left |> breakBeforeValue'
        static member Right = Types.BreakBefore.Right |> breakBeforeValue'
        static member Recto = Types.BreakBefore.Recto |> breakBeforeValue'
        static member Verso = Types.BreakBefore.Verso |> breakBeforeValue'
        static member AvoidColumn = Types.BreakBefore.AvoidColumn |> breakBeforeValue'
        static member Column = Types.BreakBefore.Column |> breakBeforeValue'
        static member AvoidRegion = Types.BreakBefore.AvoidRegion |> breakBeforeValue'
        static member Region = Types.BreakBefore.Region |> breakBeforeValue'

        static member Auto = Types.Auto |> breakBeforeValue'
        static member Inherit = Types.Inherit |> breakBeforeValue'
        static member Initial = Types.Initial |> breakBeforeValue'
        static member Unset = Types.Unset |> breakBeforeValue'

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
    let BreakBefore' (breakBefore: Types.IBreakBefore) = breakBefore |> BreakBefore.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    let private breakInsideValue value = Types.propertyHelpers.cssValue Types.Property.BreakInside value
    let private breakInsideValue' value =
        value
        |> breakInsideToString
        |> breakInsideValue

    type BreakInside =
        static member Value (breakInside: Types.IBreakInside) = breakInside |> breakInsideValue'
        static member Avoid = Types.BreakInside.Avoid |> breakInsideValue'
        static member AvoidPage = Types.BreakInside.AvoidPage |> breakInsideValue'
        static member AvoidColumn = Types.BreakInside.AvoidColumn |> breakInsideValue'
        static member AvoidRegion = Types.BreakInside.AvoidRegion |> breakInsideValue'

        static member Auto = Types.Auto |> breakInsideValue'
        static member Inherit = Types.Inherit |> breakInsideValue'
        static member Initial = Types.Initial |> breakInsideValue'
        static member Unset = Types.Unset |> breakInsideValue'

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
    let BreakInside' (breakInside: Types.IBreakInside) = breakInside |> BreakInside.Value

