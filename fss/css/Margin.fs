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
    ///     - <c> Global </c> 
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
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Global </c> 
    ///     - <c> Auto </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginTop' (top: IMargin) = MarginTop.Value(top)

    let private marginRightValue value = PropertyValue.cssValue Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue

    /// <summary>Specifies the margin on right side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Global </c> 
    ///     - <c> Auto </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    type MarginRight =
        static member Value (right: IMargin) = right |> marginRightValue'
        static member Auto = Auto |> marginRightValue'
        static member Inherit = Inherit |> marginRightValue'
        static member Initial = Initial |> marginRightValue'
        static member Unset = Unset |> marginRightValue'
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
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Global </c> 
    ///     - <c> Auto </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBottom' (bottom: IMargin) = MarginBottom.Value(bottom)

    let private marginLeftValue value = PropertyValue.cssValue Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue

    /// <summary>Specifies the margin on left side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Global </c> 
    ///     - <c> Auto </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    type MarginLeft =
        static member Value (left: IMargin) = left |> marginLeftValue'
        static member Auto = Auto |> marginLeftValue'
        static member Inherit = Inherit |> marginLeftValue'
        static member Initial = Initial |> marginLeftValue'
        static member Unset = Unset |> marginLeftValue'

    let MarginLeft' (left: IMargin) = MarginLeft.Value(left)


// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
[<AutoOpen>]
module ScrollMargin =
    let private scrollMarginToString (scrollMargin: IScrollMargin) =
        match scrollMargin with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown scrollMargin"

    let private scrollMarginValue value = PropertyValue.cssValue Property.ScrollMargin value
    let private scrollMarginValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginValue

    type ScrollMargin =
        static member Value (width: IScrollMargin) = width |> scrollMarginValue'

        static member Value (vertical: IScrollMargin, horizontal: IScrollMargin) =
            sprintf "%s %s"
                (scrollMarginToString vertical)
                (scrollMarginToString horizontal)
            |> scrollMarginValue
        static member Value (top: IScrollMargin, auto: IScrollMargin, bottom: IScrollMargin) =
            sprintf "%s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString auto)
                (scrollMarginToString bottom)
            |> scrollMarginValue
        static member Value (top: IScrollMargin, right: IScrollMargin, bottom: IScrollMargin, left: IScrollMargin) =
            sprintf "%s %s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString right)
                (scrollMarginToString bottom)
                (scrollMarginToString left)
            |> scrollMarginValue
        static member Inherit = Inherit |> scrollMarginValue'
        static member Initial = Initial |> scrollMarginValue'
        static member Unset = Unset |> scrollMarginValue'

    /// <summary>Specifies the scroll margin on all sides of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Global </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMargin' (scrollMargin: IScrollMargin) = ScrollMargin.Value(scrollMargin)

    let private scrollMarginTopValue value = PropertyValue.cssValue Property.ScrollMarginTop value
    let private scrollMarginTopValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginTopValue
    type ScrollMarginTop =
        static member Value (top: IScrollMargin) = top |> scrollMarginTopValue'
        static member Inherit = Inherit |> scrollMarginTopValue'
        static member Initial = Initial |> scrollMarginTopValue'
        static member Unset = Unset |> scrollMarginTopValue'

    /// <summary>Specifies the scroll margin on top side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Global </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginTop' (top: IScrollMargin) = ScrollMarginTop.Value(top)

    let private scrollMarginRightValue value = PropertyValue.cssValue Property.ScrollMarginRight value
    let private scrollMarginRightValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginRightValue
    type ScrollMarginRight =
        static member Value (right: IScrollMargin) = right |> scrollMarginRightValue'
        static member Inherit = Inherit |> scrollMarginRightValue'
        static member Initial = Initial |> scrollMarginRightValue'
        static member Unset = Unset |> scrollMarginRightValue'

    /// <summary>Specifies the scroll margin on right side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Global </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginRight' (right: IScrollMargin) = ScrollMarginRight.Value(right)

    let private scrollMarginBottomValue value = PropertyValue.cssValue Property.ScrollMarginBottom value
    let private scrollMarginBottomValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginBottomValue
    type ScrollMarginBottom =
        static member Value (bottom: IScrollMargin) = bottom |> scrollMarginBottomValue'
        static member Inherit = Inherit |> scrollMarginBottomValue'
        static member Initial = Initial |> scrollMarginBottomValue'
        static member Unset = Unset |> scrollMarginBottomValue'
    /// <summary>Specifies the scroll margin on bottom side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Global </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginBottom' (bottom: IScrollMargin) = ScrollMarginBottom.Value(bottom)

    let private scrollMarginLeftValue value = PropertyValue.cssValue Property.ScrollMarginLeft value
    let private scrollMarginLeftValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginLeftValue
    type ScrollMarginLeft =
        static member Value (left: IScrollMargin) = left |> scrollMarginLeftValue'
        static member Inherit = Inherit |> scrollMarginLeftValue'
        static member Initial = Initial |> scrollMarginLeftValue'
        static member Unset = Unset |> scrollMarginLeftValue'

    /// <summary>Specifies the scroll margin on left side of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Global </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginLeft' (left: IScrollMargin) = ScrollMarginLeft.Value(left)
