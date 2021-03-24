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
        static member Value (width: FssTypes.IPadding) = width |> paddingValue'

        static member Value (vertical: FssTypes.IPadding, horizontal: FssTypes.IPadding) =
            sprintf "%s %s"
                (paddingToString vertical)
                (paddingToString horizontal)
            |> paddingValue
        static member Value (top: FssTypes.IPadding, horizontal: FssTypes.IPadding, bottom: FssTypes.IPadding) =
            sprintf "%s %s %s"
                (paddingToString top)
                (paddingToString horizontal)
                (paddingToString bottom)
            |> paddingValue
        static member Value (top: FssTypes.IPadding, right: FssTypes.IPadding, bottom: FssTypes.IPadding, left: FssTypes.IPadding) =
            sprintf "%s %s %s %s"
                (paddingToString top)
                (paddingToString right)
                (paddingToString bottom)
                (paddingToString left)
            |> paddingValue

        static member Auto = FssTypes.Auto |> paddingValue'
        static member Inherit = FssTypes.Inherit |> paddingValue'
        static member Initial = FssTypes.Initial |> paddingValue'
        static member Unset = FssTypes.Unset |> paddingValue'

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
    let Padding' (padding: FssTypes.IPadding) = Padding.Value(padding)

    let private paddingTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingTop value
    let private paddingTopValue' value =
        value
        |> paddingToString
        |> paddingTopValue
    type PaddingTop =
        static member Value (top: FssTypes.IPadding) = top |> paddingTopValue'
        static member Auto = FssTypes.Auto |> paddingTopValue'
        static member Inherit = FssTypes.Inherit |> paddingTopValue'
        static member Initial = FssTypes.Initial |> paddingTopValue'
        static member Unset = FssTypes.Unset |> paddingTopValue'

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
    let PaddingTop' (top: FssTypes.IPadding) = PaddingTop.Value(top)

    let private paddingRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingRight value
    let private paddingRightValue' value =
        value
        |> paddingToString
        |> paddingRightValue
    type PaddingRight =
        static member Value (right: FssTypes.IPadding) = right |> paddingRightValue'
        static member Auto = FssTypes.Auto |> paddingRightValue'
        static member Inherit = FssTypes.Inherit |> paddingRightValue'
        static member Initial = FssTypes.Initial |> paddingRightValue'
        static member Unset = FssTypes.Unset |> paddingRightValue'

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
    let PaddingRight' (right: FssTypes.IPadding) = PaddingRight.Value(right)

    let private paddingBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBottom value
    let private paddingBottomValue' value =
        value
        |> paddingToString
        |> paddingBottomValue
    type PaddingBottom =
        static member Value (bottom: FssTypes.IPadding) = bottom |> paddingBottomValue'
        static member Auto = FssTypes.Auto |> paddingBottomValue'
        static member Inherit = FssTypes.Inherit |> paddingBottomValue'
        static member Initial = FssTypes.Initial |> paddingBottomValue'
        static member Unset = FssTypes.Unset |> paddingBottomValue'

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
    let PaddingBottom' (bottom: FssTypes.IPadding) = PaddingBottom.Value(bottom)

    let private paddingLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingLeft value
    let private paddingLeftValue' value =
        value
        |> paddingToString
        |> paddingLeftValue
    type PaddingLeft =
        static member Value (left: FssTypes.IPadding) = left |> paddingLeftValue'
        static member Auto = FssTypes.Auto |> paddingLeftValue'
        static member Inherit = FssTypes.Inherit |> paddingLeftValue'
        static member Initial = FssTypes.Initial |> paddingLeftValue'
        static member Unset = FssTypes.Unset |> paddingLeftValue'

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
    let PaddingLeft' (left: FssTypes.IPadding) = PaddingLeft.Value(left)

    let private paddingInlineStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineStart value
    let private paddingInlineStartValue' value =
        value
        |> paddingToString
        |> paddingInlineStartValue

    type PaddingInlineStart =
        static member Value (padding: FssTypes.IPadding) = padding |> paddingInlineStartValue'
        static member Auto = FssTypes.Auto |> paddingInlineStartValue'
        static member Inherit = FssTypes.Inherit |> paddingInlineStartValue'
        static member Initial = FssTypes.Initial |> paddingInlineStartValue'
        static member Unset = FssTypes.Unset |> paddingInlineStartValue'

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
    let PaddingInlineStart' (padding: FssTypes.IPadding) = PaddingInlineStart.Value(padding)

    let private paddingInlineEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineEnd value
    let private paddingInlineEndValue' value =
        value
        |> paddingToString
        |> paddingInlineEndValue

    type PaddingInlineEnd =
        static member Value (padding: FssTypes.IPadding) = padding |> paddingInlineEndValue'
        static member Auto = FssTypes.Auto |> paddingInlineEndValue'
        static member Inherit = FssTypes.Inherit |> paddingInlineEndValue'
        static member Initial = FssTypes.Initial |> paddingInlineEndValue'
        static member Unset = FssTypes.Unset |> paddingInlineEndValue'

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
    let PaddingInlineEnd' (padding: FssTypes.IPadding) = PaddingInlineEnd.Value(padding)

    let private paddingBlockStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockStart value
    let private paddingBlockStartValue' value =
        value
        |> paddingToString
        |> paddingBlockStartValue

    type PaddingBlockStart =
        static member Value (padding: FssTypes.IPadding) = padding |> paddingBlockStartValue'
        static member Auto = FssTypes.Auto |> paddingBlockStartValue'
        static member Inherit = FssTypes.Inherit |> paddingBlockStartValue'
        static member Initial = FssTypes.Initial |> paddingBlockStartValue'
        static member Unset = FssTypes.Unset |> paddingBlockStartValue'

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
    let PaddingBlockStart' (padding: FssTypes.IPadding) = PaddingBlockStart.Value(padding)

    let private paddingBlockEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockEnd value
    let private paddingBlockEndValue' value =
        value
        |> paddingToString
        |> paddingBlockEndValue

    type PaddingBlockEnd =
        static member Value (padding: FssTypes.IPadding) = padding |> paddingBlockEndValue'
        static member Auto = FssTypes.Auto |> paddingBlockEndValue'
        static member Inherit = FssTypes.Inherit |> paddingBlockEndValue'
        static member Initial = FssTypes.Initial |> paddingBlockEndValue'
        static member Unset = FssTypes.Unset |> paddingBlockEndValue'

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
    let PaddingBlockEnd' (padding: FssTypes.IPadding) = PaddingBlockEnd.Value(padding)