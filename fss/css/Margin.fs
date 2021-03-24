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
        static member Value (width: FssTypes.IMargin) = width |> marginValue'

        static member Value (vertical: FssTypes.IMargin, horizontal: FssTypes.IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member Value (top: FssTypes.IMargin, auto: FssTypes.IMargin, bottom: FssTypes.IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member Value (top: FssTypes.IMargin, right: FssTypes.IMargin, bottom: FssTypes.IMargin, left: FssTypes.IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member Auto = FssTypes.Auto |> marginValue'
        static member Inherit = FssTypes.Inherit |> marginValue'
        static member Initial = FssTypes.Initial |> marginValue'
        static member Unset = FssTypes.Unset |> marginValue'

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
    let Margin' (margin: FssTypes.IMargin) = Margin.Value(margin)

    let private marginTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginTop value
    let private marginTopValue' value =
        value
        |> marginToString
        |> marginTopValue
    type MarginTop =
        static member Value (top: FssTypes.IMargin) = top |> marginTopValue'
        static member Auto = FssTypes.Auto |> marginTopValue'
        static member Inherit = FssTypes.Inherit |> marginTopValue'
        static member Initial = FssTypes.Initial |> marginTopValue'
        static member Unset = FssTypes.Unset |> marginTopValue'

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
    let MarginTop' (top: FssTypes.IMargin) = MarginTop.Value(top)

    let private marginRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue

    type MarginRight =
        static member Value (right: FssTypes.IMargin) = right |> marginRightValue'
        static member Auto = FssTypes.Auto |> marginRightValue'
        static member Inherit = FssTypes.Inherit |> marginRightValue'
        static member Initial = FssTypes.Initial |> marginRightValue'
        static member Unset = FssTypes.Unset |> marginRightValue'

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
    let MarginRight' (right: FssTypes.IMargin) = MarginRight.Value(right)

    let private marginBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBottom value
    let private marginBottomValue' value =
        value
        |> marginToString
        |> marginBottomValue
    type MarginBottom =
        static member Value (bottom: FssTypes.IMargin) = bottom |> marginBottomValue'
        static member Auto = FssTypes.Auto |> marginBottomValue'
        static member Inherit = FssTypes.Inherit |> marginBottomValue'
        static member Initial = FssTypes.Initial |> marginBottomValue'
        static member Unset = FssTypes.Unset |> marginBottomValue'

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
    let MarginBottom' (bottom: FssTypes.IMargin) = MarginBottom.Value(bottom)

    let private marginLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue

    type MarginLeft =
        static member Value (left: FssTypes.IMargin) = left |> marginLeftValue'
        static member Auto = FssTypes.Auto |> marginLeftValue'
        static member Inherit = FssTypes.Inherit |> marginLeftValue'
        static member Initial = FssTypes.Initial |> marginLeftValue'
        static member Unset = FssTypes.Unset |> marginLeftValue'

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

    let MarginLeft' (left: FssTypes.IMargin) = MarginLeft.Value(left)

    let private marginInlineStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineStart value
    let private marginInlineStartValue' value =
        value
        |> marginToString
        |> marginInlineStartValue

    type MarginInlineStart =
        static member Value (margin: FssTypes.IMargin) = margin |> marginInlineStartValue'
        static member Auto = FssTypes.Auto |> marginInlineStartValue'
        static member Inherit = FssTypes.Inherit |> marginInlineStartValue'
        static member Initial = FssTypes.Initial |> marginInlineStartValue'
        static member Unset = FssTypes.Unset |> marginInlineStartValue'

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
    let MarginInlineStart' (margin: FssTypes.IMargin) = MarginInlineStart.Value(margin)

    let private marginInlineEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineEnd value
    let private marginInlineEndValue' value =
        value
        |> marginToString
        |> marginInlineEndValue

    type MarginInlineEnd =
        static member Value (margin: FssTypes.IMargin) = margin |> marginInlineEndValue'
        static member Auto = FssTypes.Auto |> marginInlineEndValue'
        static member Inherit = FssTypes.Inherit |> marginInlineEndValue'
        static member Initial = FssTypes.Initial |> marginInlineEndValue'
        static member Unset = FssTypes.Unset |> marginInlineEndValue'

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
    let MarginInlineEnd' (margin: FssTypes.IMargin) = MarginInlineEnd.Value(margin)

    let private marginBlockStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockStart value
    let private marginBlockStartValue' value =
        value
        |> marginToString
        |> marginBlockStartValue

    type MarginBlockStart =
        static member Value (margin: FssTypes.IMargin) = margin |> marginBlockStartValue'
        static member Auto = FssTypes.Auto |> marginBlockStartValue'
        static member Inherit = FssTypes.Inherit |> marginBlockStartValue'
        static member Initial = FssTypes.Initial |> marginBlockStartValue'
        static member Unset = FssTypes.Unset |> marginBlockStartValue'

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
    let MarginBlockStart' (margin: FssTypes.IMargin) = MarginBlockStart.Value(margin)

    let private marginBlockEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockEnd value
    let private marginBlockEndValue' value =
        value
        |> marginToString
        |> marginBlockEndValue

    type MarginBlockEnd =
        static member Value (margin: FssTypes.IMargin) = margin |> marginBlockEndValue'
        static member Auto = FssTypes.Auto |> marginBlockEndValue'
        static member Inherit = FssTypes.Inherit |> marginBlockEndValue'
        static member Initial = FssTypes.Initial |> marginBlockEndValue'
        static member Unset = FssTypes.Unset |> marginBlockEndValue'

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
    let MarginBlockEnd' (margin: FssTypes.IMargin) = MarginBlockEnd.Value(margin)