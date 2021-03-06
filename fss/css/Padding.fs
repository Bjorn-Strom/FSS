namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/padding
[<AutoOpen>]
module Padding =
    let private paddingToString (padding: IPadding) =
        match padding with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown padding"

    let private paddingValue value = PropertyValue.cssValue Property.Padding value
    let private paddingValue' value =
        value
        |> paddingToString
        |> paddingValue

    type Padding =
        static member Value (width: IPadding) = width |> paddingValue'

        static member Value (vertical: IPadding, horizontal: IPadding) =
            sprintf "%s %s"
                (paddingToString vertical)
                (paddingToString horizontal)
            |> paddingValue
        static member Value (top: IPadding, horizontal: IPadding, bottom: IPadding) =
            sprintf "%s %s %s"
                (paddingToString top)
                (paddingToString horizontal)
                (paddingToString bottom)
            |> paddingValue
        static member Value (top: IPadding, right: IPadding, bottom: IPadding, left: IPadding) =
            sprintf "%s %s %s %s"
                (paddingToString top)
                (paddingToString right)
                (paddingToString bottom)
                (paddingToString left)
            |> paddingValue

        static member Auto = Auto |> paddingValue'
        static member Inherit = Inherit |> paddingValue'
        static member Initial = Initial |> paddingValue'
        static member Unset = Unset |> paddingValue'

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
    let Padding' (padding: IPadding) = Padding.Value(padding)

    let private paddingTopValue value = PropertyValue.cssValue Property.PaddingTop value
    let private paddingTopValue' value =
        value
        |> paddingToString
        |> paddingTopValue
    type PaddingTop =
        static member Value (top: IPadding) = top |> paddingTopValue'
        static member Auto = Auto |> paddingTopValue'
        static member Inherit = Inherit |> paddingTopValue'
        static member Initial = Initial |> paddingTopValue'
        static member Unset = Unset |> paddingTopValue'

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
    let PaddingTop' (top: IPadding) = PaddingTop.Value(top)

    let private paddingRightValue value = PropertyValue.cssValue Property.PaddingRight value
    let private paddingRightValue' value =
        value
        |> paddingToString
        |> paddingRightValue
    type PaddingRight =
        static member Value (right: IPadding) = right |> paddingRightValue'
        static member Auto = Auto |> paddingRightValue'
        static member Inherit = Inherit |> paddingRightValue'
        static member Initial = Initial |> paddingRightValue'
        static member Unset = Unset |> paddingRightValue'

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
    let PaddingRight' (right: IPadding) = PaddingRight.Value(right)

    let private paddingBottomValue value = PropertyValue.cssValue Property.PaddingBottom value
    let private paddingBottomValue' value =
        value
        |> paddingToString
        |> paddingBottomValue
    type PaddingBottom =
        static member Value (bottom: IPadding) = bottom |> paddingBottomValue'
        static member Auto = Auto |> paddingBottomValue'
        static member Inherit = Inherit |> paddingBottomValue'
        static member Initial = Initial |> paddingBottomValue'
        static member Unset = Unset |> paddingBottomValue'

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
    let PaddingBottom' (bottom: IPadding) = PaddingBottom.Value(bottom)

    let private paddingLeftValue value = PropertyValue.cssValue Property.PaddingLeft value
    let private paddingLeftValue' value =
        value
        |> paddingToString
        |> paddingLeftValue
    type PaddingLeft =
        static member Value (left: IPadding) = left |> paddingLeftValue'
        static member Auto = Auto |> paddingLeftValue'
        static member Inherit = Inherit |> paddingLeftValue'
        static member Initial = Initial |> paddingLeftValue'
        static member Unset = Unset |> paddingLeftValue'

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
    let PaddingLeft' (left: IPadding) = PaddingLeft.Value(left)

    let private paddingInlineStartValue value = PropertyValue.cssValue Property.PaddingInlineStart value
    let private paddingInlineStartValue' value =
        value
        |> paddingToString
        |> paddingInlineStartValue

    type PaddingInlineStart =
        static member Value (padding: IPadding) = padding |> paddingInlineStartValue'
        static member Auto = Auto |> paddingInlineStartValue'
        static member Inherit = Inherit |> paddingInlineStartValue'
        static member Initial = Initial |> paddingInlineStartValue'
        static member Unset = Unset |> paddingInlineStartValue'

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
    let PaddingInlineStart' (padding: IPadding) = PaddingInlineStart.Value(padding)

    let private paddingInlineEndValue value = PropertyValue.cssValue Property.PaddingInlineEnd value
    let private paddingInlineEndValue' value =
        value
        |> paddingToString
        |> paddingInlineEndValue

    type PaddingInlineEnd =
        static member Value (padding: IPadding) = padding |> paddingInlineEndValue'
        static member Auto = Auto |> paddingInlineEndValue'
        static member Inherit = Inherit |> paddingInlineEndValue'
        static member Initial = Initial |> paddingInlineEndValue'
        static member Unset = Unset |> paddingInlineEndValue'

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
    let PaddingInlineEnd' (padding: IPadding) = PaddingInlineEnd.Value(padding)

    let private paddingBlockStartValue value = PropertyValue.cssValue Property.PaddingBlockStart value
    let private paddingBlockStartValue' value =
        value
        |> paddingToString
        |> paddingBlockStartValue

    type PaddingBlockStart =
        static member Value (padding: IPadding) = padding |> paddingBlockStartValue'
        static member Auto = Auto |> paddingBlockStartValue'
        static member Inherit = Inherit |> paddingBlockStartValue'
        static member Initial = Initial |> paddingBlockStartValue'
        static member Unset = Unset |> paddingBlockStartValue'

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
    let PaddingBlockStart' (padding: IPadding) = PaddingBlockStart.Value(padding)

    let private paddingBlockEndValue value = PropertyValue.cssValue Property.PaddingBlockEnd value
    let private paddingBlockEndValue' value =
        value
        |> paddingToString
        |> paddingBlockEndValue

    type PaddingBlockEnd =
        static member Value (padding: IPadding) = padding |> paddingBlockEndValue'
        static member Auto = Auto |> paddingBlockEndValue'
        static member Inherit = Inherit |> paddingBlockEndValue'
        static member Initial = Initial |> paddingBlockEndValue'
        static member Unset = Unset |> paddingBlockEndValue'

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
    let PaddingBlockEnd' (padding: IPadding) = PaddingBlockEnd.Value(padding)