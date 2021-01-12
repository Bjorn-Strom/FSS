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

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding
[<AutoOpen>]
module ScrollPadding =
    let private scrollPaddingToString (scrollPadding: IScrollPadding) =
        match scrollPadding with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown scrollPadding"

    let private scrollPaddingValue value = PropertyValue.cssValue Property.ScrollPadding value
    let private scrollPaddingValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingValue

    type ScrollPadding =
        static member Value (width: IScrollPadding) = width |> scrollPaddingValue'

        static member Value (vertical: IScrollPadding, horizontal: IScrollPadding) =
            sprintf "%s %s"
                (scrollPaddingToString vertical)
                (scrollPaddingToString horizontal)
            |> scrollPaddingValue
        static member Value (top: IScrollPadding, auto: IScrollPadding, bottom: IScrollPadding) =
            sprintf "%s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString auto)
                (scrollPaddingToString bottom)
            |> scrollPaddingValue
        static member Value (top: IScrollPadding, right: IScrollPadding, bottom: IScrollPadding, left: IScrollPadding) =
            sprintf "%s %s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString right)
                (scrollPaddingToString bottom)
                (scrollPaddingToString left)
            |> scrollPaddingValue
        static member Inherit = Inherit |> scrollPaddingValue'
        static member Initial = Initial |> scrollPaddingValue'
        static member Unset = Unset |> scrollPaddingValue'

    /// <summary>Specifies the scroll padding on all sides of an element.</summary>
    /// <param name="scrollPadding">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollPadding' (scrollPadding: IScrollPadding) = ScrollPadding.Value(scrollPadding)

    let private scrollPaddingTopValue value = PropertyValue.cssValue Property.ScrollPaddingTop value
    let private scrollPaddingTopValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingTopValue
    type ScrollPaddingTop =
        static member Value (top: IScrollPadding) = top |> scrollPaddingTopValue'
        static member Inherit = Inherit |> scrollPaddingTopValue'
        static member Initial = Initial |> scrollPaddingTopValue'
        static member Unset = Unset |> scrollPaddingTopValue'

    /// <summary>Specifies the scroll padding on top side of an element.</summary>
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
    let ScrollPaddingTop' (top: IScrollPadding) = ScrollPaddingTop.Value(top)

    let private scrollPaddingRightValue value = PropertyValue.cssValue Property.ScrollPaddingRight value
    let private scrollPaddingRightValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingRightValue
    type ScrollPaddingRight =
        static member Value (right: IScrollPadding) = right |> scrollPaddingRightValue'
        static member Inherit = Inherit |> scrollPaddingRightValue'
        static member Initial = Initial |> scrollPaddingRightValue'
        static member Unset = Unset |> scrollPaddingRightValue'

    /// <summary>Specifies the scroll padding on right side of an element.</summary>
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
    let ScrollPaddingRight' (right: IScrollPadding) = ScrollPaddingRight.Value(right)

    let private scrollPaddingBottomValue value = PropertyValue.cssValue Property.ScrollPaddingBottom value
    let private scrollPaddingBottomValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingBottomValue
    type ScrollPaddingBottom =
        static member Value (bottom: IScrollPadding) = bottom |> scrollPaddingBottomValue'
        static member Inherit = Inherit |> scrollPaddingBottomValue'
        static member Initial = Initial |> scrollPaddingBottomValue'
        static member Unset = Unset |> scrollPaddingBottomValue'
    /// <summary>Specifies the scroll padding on bottom side of an element.</summary>
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
    let ScrollPaddingBottom' (bottom: IScrollPadding) = ScrollPaddingBottom.Value(bottom)

    let private scrollPaddingLeftValue value = PropertyValue.cssValue Property.ScrollPaddingLeft value
    let private scrollPaddingLeftValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingLeftValue
    type ScrollPaddingLeft =
        static member Value (left: IScrollPadding) = left |> scrollPaddingLeftValue'
        static member Inherit = Inherit |> scrollPaddingLeftValue'
        static member Initial = Initial |> scrollPaddingLeftValue'
        static member Unset = Unset |> scrollPaddingLeftValue'

    /// <summary>Specifies the scroll padding on left side of an element.</summary>
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
    let ScrollPaddingLeft' (left: IScrollPadding) = ScrollPaddingLeft.Value(left)
