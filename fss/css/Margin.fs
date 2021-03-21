namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: Types.IMargin) =
        match margin with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | _ -> "Unknown margin"

    let private marginValue value = Types.propertyHelpers.cssValue Types.Property.Margin value
    let private marginValue' value =
        value
        |> marginToString
        |> marginValue

    type Margin =
        static member Value (width: Types.IMargin) = width |> marginValue'

        static member Value (vertical: Types.IMargin, horizontal: Types.IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member Value (top: Types.IMargin, auto: Types.IMargin, bottom: Types.IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member Value (top: Types.IMargin, right: Types.IMargin, bottom: Types.IMargin, left: Types.IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member Auto = Types.Auto |> marginValue'
        static member Inherit = Types.Inherit |> marginValue'
        static member Initial = Types.Initial |> marginValue'
        static member Unset = Types.Unset |> marginValue'

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
    let Margin' (margin: Types.IMargin) = Margin.Value(margin)

    let private marginTopValue value = Types.propertyHelpers.cssValue Types.Property.MarginTop value
    let private marginTopValue' value =
        value
        |> marginToString
        |> marginTopValue
    type MarginTop =
        static member Value (top: Types.IMargin) = top |> marginTopValue'
        static member Auto = Types.Auto |> marginTopValue'
        static member Inherit = Types.Inherit |> marginTopValue'
        static member Initial = Types.Initial |> marginTopValue'
        static member Unset = Types.Unset |> marginTopValue'

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
    let MarginTop' (top: Types.IMargin) = MarginTop.Value(top)

    let private marginRightValue value = Types.propertyHelpers.cssValue Types.Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue

    type MarginRight =
        static member Value (right: Types.IMargin) = right |> marginRightValue'
        static member Auto = Types.Auto |> marginRightValue'
        static member Inherit = Types.Inherit |> marginRightValue'
        static member Initial = Types.Initial |> marginRightValue'
        static member Unset = Types.Unset |> marginRightValue'

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
    let MarginRight' (right: Types.IMargin) = MarginRight.Value(right)

    let private marginBottomValue value = Types.propertyHelpers.cssValue Types.Property.MarginBottom value
    let private marginBottomValue' value =
        value
        |> marginToString
        |> marginBottomValue
    type MarginBottom =
        static member Value (bottom: Types.IMargin) = bottom |> marginBottomValue'
        static member Auto = Types.Auto |> marginBottomValue'
        static member Inherit = Types.Inherit |> marginBottomValue'
        static member Initial = Types.Initial |> marginBottomValue'
        static member Unset = Types.Unset |> marginBottomValue'

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
    let MarginBottom' (bottom: Types.IMargin) = MarginBottom.Value(bottom)

    let private marginLeftValue value = Types.propertyHelpers.cssValue Types.Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue

    type MarginLeft =
        static member Value (left: Types.IMargin) = left |> marginLeftValue'
        static member Auto = Types.Auto |> marginLeftValue'
        static member Inherit = Types.Inherit |> marginLeftValue'
        static member Initial = Types.Initial |> marginLeftValue'
        static member Unset = Types.Unset |> marginLeftValue'

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

    let MarginLeft' (left: Types.IMargin) = MarginLeft.Value(left)

    let private marginInlineStartValue value = Types.propertyHelpers.cssValue Types.Property.MarginInlineStart value
    let private marginInlineStartValue' value =
        value
        |> marginToString
        |> marginInlineStartValue

    type MarginInlineStart =
        static member Value (margin: Types.IMargin) = margin |> marginInlineStartValue'
        static member Auto = Types.Auto |> marginInlineStartValue'
        static member Inherit = Types.Inherit |> marginInlineStartValue'
        static member Initial = Types.Initial |> marginInlineStartValue'
        static member Unset = Types.Unset |> marginInlineStartValue'

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
    let MarginInlineStart' (margin: Types.IMargin) = MarginInlineStart.Value(margin)

    let private marginInlineEndValue value = Types.propertyHelpers.cssValue Types.Property.MarginInlineEnd value
    let private marginInlineEndValue' value =
        value
        |> marginToString
        |> marginInlineEndValue

    type MarginInlineEnd =
        static member Value (margin: Types.IMargin) = margin |> marginInlineEndValue'
        static member Auto = Types.Auto |> marginInlineEndValue'
        static member Inherit = Types.Inherit |> marginInlineEndValue'
        static member Initial = Types.Initial |> marginInlineEndValue'
        static member Unset = Types.Unset |> marginInlineEndValue'

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
    let MarginInlineEnd' (margin: Types.IMargin) = MarginInlineEnd.Value(margin)

    let private marginBlockStartValue value = Types.propertyHelpers.cssValue Types.Property.MarginBlockStart value
    let private marginBlockStartValue' value =
        value
        |> marginToString
        |> marginBlockStartValue

    type MarginBlockStart =
        static member Value (margin: Types.IMargin) = margin |> marginBlockStartValue'
        static member Auto = Types.Auto |> marginBlockStartValue'
        static member Inherit = Types.Inherit |> marginBlockStartValue'
        static member Initial = Types.Initial |> marginBlockStartValue'
        static member Unset = Types.Unset |> marginBlockStartValue'

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
    let MarginBlockStart' (margin: Types.IMargin) = MarginBlockStart.Value(margin)

    let private marginBlockEndValue value = Types.propertyHelpers.cssValue Types.Property.MarginBlockEnd value
    let private marginBlockEndValue' value =
        value
        |> marginToString
        |> marginBlockEndValue

    type MarginBlockEnd =
        static member Value (margin: Types.IMargin) = margin |> marginBlockEndValue'
        static member Auto = Types.Auto |> marginBlockEndValue'
        static member Inherit = Types.Inherit |> marginBlockEndValue'
        static member Initial = Types.Initial |> marginBlockEndValue'
        static member Unset = Types.Unset |> marginBlockEndValue'

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
    let MarginBlockEnd' (margin: Types.IMargin) = MarginBlockEnd.Value(margin)