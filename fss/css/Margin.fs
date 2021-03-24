namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: FssTypes.IMargin) =
        match margin with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown margin"

    let private marginValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Margin value
    let private marginValue' value =
        value
        |> marginToString
        |> marginValue

    type Margin =
        static member value (width: FssTypes.IMargin) = width |> marginValue'

        static member value (vertical: FssTypes.IMargin, horizontal: FssTypes.IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member value (top: FssTypes.IMargin, auto: FssTypes.IMargin, bottom: FssTypes.IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member value (top: FssTypes.IMargin, right: FssTypes.IMargin, bottom: FssTypes.IMargin, left: FssTypes.IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member auto = FssTypes.Auto |> marginValue'
        static member inherit' = FssTypes.Inherit |> marginValue'
        static member initial = FssTypes.Initial |> marginValue'
        static member unset = FssTypes.Unset |> marginValue'

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
    let Margin' (margin: FssTypes.IMargin) = Margin.value(margin)

    let private marginTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginTop value
    let private marginTopValue' value =
        value
        |> marginToString
        |> marginTopValue
    type MarginTop =
        static member value (top: FssTypes.IMargin) = top |> marginTopValue'
        static member auto = FssTypes.Auto |> marginTopValue'
        static member inherit' = FssTypes.Inherit |> marginTopValue'
        static member initial = FssTypes.Initial |> marginTopValue'
        static member unset = FssTypes.Unset |> marginTopValue'

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
    let MarginTop' (top: FssTypes.IMargin) = MarginTop.value(top)

    let private marginRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue

    type MarginRight =
        static member value (right: FssTypes.IMargin) = right |> marginRightValue'
        static member auto = FssTypes.Auto |> marginRightValue'
        static member inherit' = FssTypes.Inherit |> marginRightValue'
        static member initial = FssTypes.Initial |> marginRightValue'
        static member unset = FssTypes.Unset |> marginRightValue'

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
    let MarginRight' (right: FssTypes.IMargin) = MarginRight.value(right)

    let private marginBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBottom value
    let private marginBottomValue' value =
        value
        |> marginToString
        |> marginBottomValue
    type MarginBottom =
        static member value (bottom: FssTypes.IMargin) = bottom |> marginBottomValue'
        static member auto = FssTypes.Auto |> marginBottomValue'
        static member inherit' = FssTypes.Inherit |> marginBottomValue'
        static member initial = FssTypes.Initial |> marginBottomValue'
        static member unset = FssTypes.Unset |> marginBottomValue'

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
    let MarginBottom' (bottom: FssTypes.IMargin) = MarginBottom.value(bottom)

    let private marginLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue

    type MarginLeft =
        static member value (left: FssTypes.IMargin) = left |> marginLeftValue'
        static member auto = FssTypes.Auto |> marginLeftValue'
        static member inherit' = FssTypes.Inherit |> marginLeftValue'
        static member initial = FssTypes.Initial |> marginLeftValue'
        static member unset = FssTypes.Unset |> marginLeftValue'

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

    let MarginLeft' (left: FssTypes.IMargin) = MarginLeft.value(left)

    let private marginInlineStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineStart value
    let private marginInlineStartValue' value =
        value
        |> marginToString
        |> marginInlineStartValue

    type MarginInlineStart =
        static member value (margin: FssTypes.IMargin) = margin |> marginInlineStartValue'
        static member auto = FssTypes.Auto |> marginInlineStartValue'
        static member inherit' = FssTypes.Inherit |> marginInlineStartValue'
        static member initial = FssTypes.Initial |> marginInlineStartValue'
        static member unset = FssTypes.Unset |> marginInlineStartValue'

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
    let MarginInlineStart' (margin: FssTypes.IMargin) = MarginInlineStart.value(margin)

    let private marginInlineEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineEnd value
    let private marginInlineEndValue' value =
        value
        |> marginToString
        |> marginInlineEndValue

    type MarginInlineEnd =
        static member value (margin: FssTypes.IMargin) = margin |> marginInlineEndValue'
        static member auto = FssTypes.Auto |> marginInlineEndValue'
        static member inherit' = FssTypes.Inherit |> marginInlineEndValue'
        static member initial = FssTypes.Initial |> marginInlineEndValue'
        static member unset = FssTypes.Unset |> marginInlineEndValue'

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
    let MarginInlineEnd' (margin: FssTypes.IMargin) = MarginInlineEnd.value(margin)

    let private marginBlockStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockStart value
    let private marginBlockStartValue' value =
        value
        |> marginToString
        |> marginBlockStartValue

    type MarginBlockStart =
        static member value (margin: FssTypes.IMargin) = margin |> marginBlockStartValue'
        static member auto = FssTypes.Auto |> marginBlockStartValue'
        static member inherit' = FssTypes.Inherit |> marginBlockStartValue'
        static member initial = FssTypes.Initial |> marginBlockStartValue'
        static member unset = FssTypes.Unset |> marginBlockStartValue'

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
    let MarginBlockStart' (margin: FssTypes.IMargin) = MarginBlockStart.value(margin)

    let private marginBlockEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockEnd value
    let private marginBlockEndValue' value =
        value
        |> marginToString
        |> marginBlockEndValue

    type MarginBlockEnd =
        static member value (margin: FssTypes.IMargin) = margin |> marginBlockEndValue'
        static member auto = FssTypes.Auto |> marginBlockEndValue'
        static member inherit' = FssTypes.Inherit |> marginBlockEndValue'
        static member initial = FssTypes.Initial |> marginBlockEndValue'
        static member unset = FssTypes.Unset |> marginBlockEndValue'

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
    let MarginBlockEnd' (margin: FssTypes.IMargin) = MarginBlockEnd.value(margin)