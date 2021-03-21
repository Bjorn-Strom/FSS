namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/padding
[<AutoOpen>]
module Padding =
    let private paddingToString (padding: Types.IPadding) =
        match padding with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown padding"

    let private paddingValue value = Types.cssValue Types.Property.Padding value
    let private paddingValue' value =
        value
        |> paddingToString
        |> paddingValue

    type Padding =
        static member Value (width: Types.IPadding) = width |> paddingValue'

        static member Value (vertical: Types.IPadding, horizontal: Types.IPadding) =
            sprintf "%s %s"
                (paddingToString vertical)
                (paddingToString horizontal)
            |> paddingValue
        static member Value (top: Types.IPadding, horizontal: Types.IPadding, bottom: Types.IPadding) =
            sprintf "%s %s %s"
                (paddingToString top)
                (paddingToString horizontal)
                (paddingToString bottom)
            |> paddingValue
        static member Value (top: Types.IPadding, right: Types.IPadding, bottom: Types.IPadding, left: Types.IPadding) =
            sprintf "%s %s %s %s"
                (paddingToString top)
                (paddingToString right)
                (paddingToString bottom)
                (paddingToString left)
            |> paddingValue

        static member Auto = Types.Auto |> paddingValue'
        static member Inherit = Types.Inherit |> paddingValue'
        static member Initial = Types.Initial |> paddingValue'
        static member Unset = Types.Unset |> paddingValue'

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
    let Padding' (padding: Types.IPadding) = Padding.Value(padding)

    let private paddingTopValue value = Types.cssValue Types.Property.PaddingTop value
    let private paddingTopValue' value =
        value
        |> paddingToString
        |> paddingTopValue
    type PaddingTop =
        static member Value (top: Types.IPadding) = top |> paddingTopValue'
        static member Auto = Types.Auto |> paddingTopValue'
        static member Inherit = Types.Inherit |> paddingTopValue'
        static member Initial = Types.Initial |> paddingTopValue'
        static member Unset = Types.Unset |> paddingTopValue'

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
    let PaddingTop' (top: Types.IPadding) = PaddingTop.Value(top)

    let private paddingRightValue value = Types.cssValue Types.Property.PaddingRight value
    let private paddingRightValue' value =
        value
        |> paddingToString
        |> paddingRightValue
    type PaddingRight =
        static member Value (right: Types.IPadding) = right |> paddingRightValue'
        static member Auto = Types.Auto |> paddingRightValue'
        static member Inherit = Types.Inherit |> paddingRightValue'
        static member Initial = Types.Initial |> paddingRightValue'
        static member Unset = Types.Unset |> paddingRightValue'

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
    let PaddingRight' (right: Types.IPadding) = PaddingRight.Value(right)

    let private paddingBottomValue value = Types.cssValue Types.Property.PaddingBottom value
    let private paddingBottomValue' value =
        value
        |> paddingToString
        |> paddingBottomValue
    type PaddingBottom =
        static member Value (bottom: Types.IPadding) = bottom |> paddingBottomValue'
        static member Auto = Types.Auto |> paddingBottomValue'
        static member Inherit = Types.Inherit |> paddingBottomValue'
        static member Initial = Types.Initial |> paddingBottomValue'
        static member Unset = Types.Unset |> paddingBottomValue'

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
    let PaddingBottom' (bottom: Types.IPadding) = PaddingBottom.Value(bottom)

    let private paddingLeftValue value = Types.cssValue Types.Property.PaddingLeft value
    let private paddingLeftValue' value =
        value
        |> paddingToString
        |> paddingLeftValue
    type PaddingLeft =
        static member Value (left: Types.IPadding) = left |> paddingLeftValue'
        static member Auto = Types.Auto |> paddingLeftValue'
        static member Inherit = Types.Inherit |> paddingLeftValue'
        static member Initial = Types.Initial |> paddingLeftValue'
        static member Unset = Types.Unset |> paddingLeftValue'

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
    let PaddingLeft' (left: Types.IPadding) = PaddingLeft.Value(left)

    let private paddingInlineStartValue value = Types.cssValue Types.Property.PaddingInlineStart value
    let private paddingInlineStartValue' value =
        value
        |> paddingToString
        |> paddingInlineStartValue

    type PaddingInlineStart =
        static member Value (padding: Types.IPadding) = padding |> paddingInlineStartValue'
        static member Auto = Types.Auto |> paddingInlineStartValue'
        static member Inherit = Types.Inherit |> paddingInlineStartValue'
        static member Initial = Types.Initial |> paddingInlineStartValue'
        static member Unset = Types.Unset |> paddingInlineStartValue'

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
    let PaddingInlineStart' (padding: Types.IPadding) = PaddingInlineStart.Value(padding)

    let private paddingInlineEndValue value = Types.cssValue Types.Property.PaddingInlineEnd value
    let private paddingInlineEndValue' value =
        value
        |> paddingToString
        |> paddingInlineEndValue

    type PaddingInlineEnd =
        static member Value (padding: Types.IPadding) = padding |> paddingInlineEndValue'
        static member Auto = Types.Auto |> paddingInlineEndValue'
        static member Inherit = Types.Inherit |> paddingInlineEndValue'
        static member Initial = Types.Initial |> paddingInlineEndValue'
        static member Unset = Types.Unset |> paddingInlineEndValue'

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
    let PaddingInlineEnd' (padding: Types.IPadding) = PaddingInlineEnd.Value(padding)

    let private paddingBlockStartValue value = Types.cssValue Types.Property.PaddingBlockStart value
    let private paddingBlockStartValue' value =
        value
        |> paddingToString
        |> paddingBlockStartValue

    type PaddingBlockStart =
        static member Value (padding: Types.IPadding) = padding |> paddingBlockStartValue'
        static member Auto = Types.Auto |> paddingBlockStartValue'
        static member Inherit = Types.Inherit |> paddingBlockStartValue'
        static member Initial = Types.Initial |> paddingBlockStartValue'
        static member Unset = Types.Unset |> paddingBlockStartValue'

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
    let PaddingBlockStart' (padding: Types.IPadding) = PaddingBlockStart.Value(padding)

    let private paddingBlockEndValue value = Types.cssValue Types.Property.PaddingBlockEnd value
    let private paddingBlockEndValue' value =
        value
        |> paddingToString
        |> paddingBlockEndValue

    type PaddingBlockEnd =
        static member Value (padding: Types.IPadding) = padding |> paddingBlockEndValue'
        static member Auto = Types.Auto |> paddingBlockEndValue'
        static member Inherit = Types.Inherit |> paddingBlockEndValue'
        static member Initial = Types.Initial |> paddingBlockEndValue'
        static member Unset = Types.Unset |> paddingBlockEndValue'

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
    let PaddingBlockEnd' (padding: Types.IPadding) = PaddingBlockEnd.Value(padding)