namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: IMargin) =
        match margin with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown margin"

    let private marginValue value = PropertyValue.cssValue Property.Margin value
    let private marginValue' value =
        value
        |> marginToString
        |> marginValue

    type Margin =
        static member Value (width: IMargin) = width |> marginValue'

        static member Value (vertical: IMargin, horizontal: IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member Value (top: IMargin, auto: IMargin, bottom: IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member Value (top: IMargin, right: IMargin, bottom: IMargin, left: IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member Auto = Auto |> marginValue'
        static member Inherit = Inherit |> marginValue'
        static member Initial = Initial |> marginValue'
        static member Unset = Unset |> marginValue'

    /// <summary>Specifies the margin on all sides of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Margin' (margin: IMargin) = Margin.Value(margin)

    let private marginTopValue value = PropertyValue.cssValue Property.MarginTop value
    let private marginTopValue' value =
        value
        |> marginToString
        |> marginTopValue
    type MarginTop =
        static member Value (top: IMargin) = top |> marginTopValue'
        static member Auto = Auto |> marginTopValue'
        static member Inherit = Inherit |> marginTopValue'
        static member Initial = Initial |> marginTopValue'
        static member Unset = Unset |> marginTopValue'

    /// <summary>Specifies the margin on top side of an element.</summary>
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
    let MarginTop' (top: IMargin) = MarginTop.Value(top)

    let private marginRightValue value = PropertyValue.cssValue Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue

    type MarginRight =
        static member Value (right: IMargin) = right |> marginRightValue'
        static member Auto = Auto |> marginRightValue'
        static member Inherit = Inherit |> marginRightValue'
        static member Initial = Initial |> marginRightValue'
        static member Unset = Unset |> marginRightValue'

    /// <summary>Specifies the margin on right side of an element.</summary>
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
    let MarginRight' (right: IMargin) = MarginRight.Value(right)

    let private marginBottomValue value = PropertyValue.cssValue Property.MarginBottom value
    let private marginBottomValue' value =
        value
        |> marginToString
        |> marginBottomValue
    type MarginBottom =
        static member Value (bottom: IMargin) = bottom |> marginBottomValue'
        static member Auto = Auto |> marginBottomValue'
        static member Inherit = Inherit |> marginBottomValue'
        static member Initial = Initial |> marginBottomValue'
        static member Unset = Unset |> marginBottomValue'

    /// <summary>Specifies the margin on bottom side of an element.</summary>
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
    let MarginBottom' (bottom: IMargin) = MarginBottom.Value(bottom)

    let private marginLeftValue value = PropertyValue.cssValue Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue

    type MarginLeft =
        static member Value (left: IMargin) = left |> marginLeftValue'
        static member Auto = Auto |> marginLeftValue'
        static member Inherit = Inherit |> marginLeftValue'
        static member Initial = Initial |> marginLeftValue'
        static member Unset = Unset |> marginLeftValue'

    /// <summary>Specifies the margin on left side of an element.</summary>
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

    let MarginLeft' (left: IMargin) = MarginLeft.Value(left)

    let private marginInlineStartValue value = PropertyValue.cssValue Property.MarginInlineStart value
    let private marginInlineStartValue' value =
        value
        |> marginToString
        |> marginInlineStartValue

    type MarginInlineStart =
        static member Value (margin: IMargin) = margin |> marginInlineStartValue'
        static member Auto = Auto |> marginInlineStartValue'
        static member Inherit = Inherit |> marginInlineStartValue'
        static member Initial = Initial |> marginInlineStartValue'
        static member Unset = Unset |> marginInlineStartValue'

    /// <summary>Specifies the amount of space along the outer starting edge of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginInlineStart' (margin: IMargin) = MarginInlineStart.Value(margin)

    let private marginInlineEndValue value = PropertyValue.cssValue Property.MarginInlineEnd value
    let private marginInlineEndValue' value =
        value
        |> marginToString
        |> marginInlineEndValue

    type MarginInlineEnd =
        static member Value (margin: IMargin) = margin |> marginInlineEndValue'
        static member Auto = Auto |> marginInlineEndValue'
        static member Inherit = Inherit |> marginInlineEndValue'
        static member Initial = Initial |> marginInlineEndValue'
        static member Unset = Unset |> marginInlineEndValue'

    /// <summary>Specifies the amount of space along the outer ending edge of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginInlineEnd' (margin: IMargin) = MarginInlineEnd.Value(margin)

    let private marginBlockStartValue value = PropertyValue.cssValue Property.MarginBlockStart value
    let private marginBlockStartValue' value =
        value
        |> marginToString
        |> marginBlockStartValue

    type MarginBlockStart =
        static member Value (margin: IMargin) = margin |> marginBlockStartValue'
        static member Auto = Auto |> marginBlockStartValue'
        static member Inherit = Inherit |> marginBlockStartValue'
        static member Initial = Initial |> marginBlockStartValue'
        static member Unset = Unset |> marginBlockStartValue'

    /// <summary>Specifies the amount of start margin of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBlockStart' (margin: IMargin) = MarginBlockStart.Value(margin)

    let private marginBlockEndValue value = PropertyValue.cssValue Property.MarginBlockEnd value
    let private marginBlockEndValue' value =
        value
        |> marginToString
        |> marginBlockEndValue

    type MarginBlockEnd =
        static member Value (margin: IMargin) = margin |> marginBlockEndValue'
        static member Auto = Auto |> marginBlockEndValue'
        static member Inherit = Inherit |> marginBlockEndValue'
        static member Initial = Initial |> marginBlockEndValue'
        static member Unset = Unset |> marginBlockEndValue'

    /// <summary>Specifies the amount of end margin of an element </summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBlockEnd' (margin: IMargin) = MarginBlockEnd.Value(margin)