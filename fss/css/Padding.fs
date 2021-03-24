namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/padding
[<AutoOpen>]
module Padding =
    let private paddingToString (padding: FssTypes.IPadding) =
        match padding with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown padding"

    let private paddingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Padding value
    let private paddingValue' value =
        value
        |> paddingToString
        |> paddingValue

    type Padding =
        static member value (width: FssTypes.IPadding) = width |> paddingValue'

        static member value (vertical: FssTypes.IPadding, horizontal: FssTypes.IPadding) =
            sprintf "%s %s"
                (paddingToString vertical)
                (paddingToString horizontal)
            |> paddingValue
        static member value (top: FssTypes.IPadding, horizontal: FssTypes.IPadding, bottom: FssTypes.IPadding) =
            sprintf "%s %s %s"
                (paddingToString top)
                (paddingToString horizontal)
                (paddingToString bottom)
            |> paddingValue
        static member value (top: FssTypes.IPadding, right: FssTypes.IPadding, bottom: FssTypes.IPadding, left: FssTypes.IPadding) =
            sprintf "%s %s %s %s"
                (paddingToString top)
                (paddingToString right)
                (paddingToString bottom)
                (paddingToString left)
            |> paddingValue

        static member auto = FssTypes.Auto |> paddingValue'
        static member inherit' = FssTypes.Inherit |> paddingValue'
        static member initial = FssTypes.Initial |> paddingValue'
        static member unset = FssTypes.Unset |> paddingValue'

    /// <summary>Specifies the padding on all sides of an element.</summary>
    /// <param name="padding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Padding' (padding: FssTypes.IPadding) = Padding.value(padding)

    let private paddingTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingTop value
    let private paddingTopValue' value =
        value
        |> paddingToString
        |> paddingTopValue
    type PaddingTop =
        static member value (top: FssTypes.IPadding) = top |> paddingTopValue'
        static member auto = FssTypes.Auto |> paddingTopValue'
        static member inherit' = FssTypes.Inherit |> paddingTopValue'
        static member initial = FssTypes.Initial |> paddingTopValue'
        static member unset = FssTypes.Unset |> paddingTopValue'

    /// <summary>Specifies the padding on top sides of an element.</summary>
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
    let PaddingTop' (top: FssTypes.IPadding) = PaddingTop.value(top)

    let private paddingRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingRight value
    let private paddingRightValue' value =
        value
        |> paddingToString
        |> paddingRightValue
    type PaddingRight =
        static member value (right: FssTypes.IPadding) = right |> paddingRightValue'
        static member auto = FssTypes.Auto |> paddingRightValue'
        static member inherit' = FssTypes.Inherit |> paddingRightValue'
        static member initial = FssTypes.Initial |> paddingRightValue'
        static member unset = FssTypes.Unset |> paddingRightValue'

    /// <summary>Specifies the padding on right side of an element.</summary>
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
    let PaddingRight' (right: FssTypes.IPadding) = PaddingRight.value(right)

    let private paddingBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBottom value
    let private paddingBottomValue' value =
        value
        |> paddingToString
        |> paddingBottomValue
    type PaddingBottom =
        static member value (bottom: FssTypes.IPadding) = bottom |> paddingBottomValue'
        static member auto = FssTypes.Auto |> paddingBottomValue'
        static member inherit' = FssTypes.Inherit |> paddingBottomValue'
        static member initial = FssTypes.Initial |> paddingBottomValue'
        static member unset = FssTypes.Unset |> paddingBottomValue'

    /// <summary>Specifies the padding on bottom side of an element.</summary>
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
    let PaddingBottom' (bottom: FssTypes.IPadding) = PaddingBottom.value(bottom)

    let private paddingLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingLeft value
    let private paddingLeftValue' value =
        value
        |> paddingToString
        |> paddingLeftValue
    type PaddingLeft =
        static member value (left: FssTypes.IPadding) = left |> paddingLeftValue'
        static member auto = FssTypes.Auto |> paddingLeftValue'
        static member inherit' = FssTypes.Inherit |> paddingLeftValue'
        static member initial = FssTypes.Initial |> paddingLeftValue'
        static member unset = FssTypes.Unset |> paddingLeftValue'

    /// <summary>Specifies the padding on left side of an element.</summary>
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
    let PaddingLeft' (left: FssTypes.IPadding) = PaddingLeft.value(left)

    let private paddingInlineStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineStart value
    let private paddingInlineStartValue' value =
        value
        |> paddingToString
        |> paddingInlineStartValue

    type PaddingInlineStart =
        static member value (padding: FssTypes.IPadding) = padding |> paddingInlineStartValue'
        static member auto = FssTypes.Auto |> paddingInlineStartValue'
        static member inherit' = FssTypes.Inherit |> paddingInlineStartValue'
        static member initial = FssTypes.Initial |> paddingInlineStartValue'
        static member unset = FssTypes.Unset |> paddingInlineStartValue'

    /// <summary>Specifies the amount of space along the outer starting edge of an element.</summary>
    /// <param name="padding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaddingInlineStart' (padding: FssTypes.IPadding) = PaddingInlineStart.value(padding)

    let private paddingInlineEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineEnd value
    let private paddingInlineEndValue' value =
        value
        |> paddingToString
        |> paddingInlineEndValue

    type PaddingInlineEnd =
        static member value (padding: FssTypes.IPadding) = padding |> paddingInlineEndValue'
        static member auto = FssTypes.Auto |> paddingInlineEndValue'
        static member inherit' = FssTypes.Inherit |> paddingInlineEndValue'
        static member initial = FssTypes.Initial |> paddingInlineEndValue'
        static member unset = FssTypes.Unset |> paddingInlineEndValue'

    /// <summary>Specifies the amount of space along the outer ending edge of an element.</summary>
    /// <param name="padding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaddingInlineEnd' (padding: FssTypes.IPadding) = PaddingInlineEnd.value(padding)

    let private paddingBlockStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockStart value
    let private paddingBlockStartValue' value =
        value
        |> paddingToString
        |> paddingBlockStartValue

    type PaddingBlockStart =
        static member value (padding: FssTypes.IPadding) = padding |> paddingBlockStartValue'
        static member auto = FssTypes.Auto |> paddingBlockStartValue'
        static member inherit' = FssTypes.Inherit |> paddingBlockStartValue'
        static member initial = FssTypes.Initial |> paddingBlockStartValue'
        static member unset = FssTypes.Unset |> paddingBlockStartValue'

    /// <summary>Specifies the amount of start padding of an element.</summary>
    /// <param name="padding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaddingBlockStart' (padding: FssTypes.IPadding) = PaddingBlockStart.value(padding)

    let private paddingBlockEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockEnd value
    let private paddingBlockEndValue' value =
        value
        |> paddingToString
        |> paddingBlockEndValue

    type PaddingBlockEnd =
        static member value (padding: FssTypes.IPadding) = padding |> paddingBlockEndValue'
        static member auto = FssTypes.Auto |> paddingBlockEndValue'
        static member inherit' = FssTypes.Inherit |> paddingBlockEndValue'
        static member initial = FssTypes.Initial |> paddingBlockEndValue'
        static member unset = FssTypes.Unset |> paddingBlockEndValue'

    /// <summary>Specifies the amount of end padding of an element </summary>
    /// <param name="padding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PaddingBlockEnd' (padding: FssTypes.IPadding) = PaddingBlockEnd.value(padding)