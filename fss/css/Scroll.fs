namespace Fss

[<AutoOpen>]
module ScrollBehavior =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
    let private stringifyScrollBehavior (behavior: FssTypes.IScrollBehavior) =
        match behavior with
        | :? FssTypes.Scroll.ScrollBehavior as s -> Utilities.Helpers.duToKebab s
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private BehaviorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollBehavior value
    let private BehaviorValue' value =
        value
        |> stringifyScrollBehavior
        |> BehaviorValue

    type ScrollBehavior =
        static member Value (behavior: FssTypes.IScrollBehavior) = behavior |> BehaviorValue'
        static member Smooth = FssTypes.Scroll.ScrollBehavior.Smooth |> BehaviorValue'
        static member Auto = FssTypes.Auto |> BehaviorValue'
        static member Inherit = FssTypes.Inherit |> BehaviorValue'
        static member Initial = FssTypes.Initial |> BehaviorValue'
        static member Unset = FssTypes.Unset |> BehaviorValue'

    /// <summary>Specifies the Behavior of scrolling.</summary>
    /// <param name="behavior">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollBehavior' (behavior: FssTypes.IScrollBehavior) = behavior |> ScrollBehavior.Value

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
[<AutoOpen>]
module ScrollMargin =
    let private scrollMarginToString (scrollMargin: FssTypes.IScrollMargin) =
        match scrollMargin with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown scrollMargin"

    let private scrollMarginValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMargin value
    let private scrollMarginValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginValue

    type ScrollMargin =
        static member Value (width: FssTypes.IScrollMargin) = width |> scrollMarginValue'

        static member Value (vertical: FssTypes.IScrollMargin, horizontal: FssTypes.IScrollMargin) =
            sprintf "%s %s"
                (scrollMarginToString vertical)
                (scrollMarginToString horizontal)
            |> scrollMarginValue
        static member Value (top: FssTypes.IScrollMargin, auto: FssTypes.IScrollMargin, bottom: FssTypes.IScrollMargin) =
            sprintf "%s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString auto)
                (scrollMarginToString bottom)
            |> scrollMarginValue
        static member Value (top: FssTypes.IScrollMargin, right: FssTypes.IScrollMargin, bottom: FssTypes.IScrollMargin, left: FssTypes.IScrollMargin) =
            sprintf "%s %s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString right)
                (scrollMarginToString bottom)
                (scrollMarginToString left)
            |> scrollMarginValue
        static member Inherit = FssTypes.Inherit |> scrollMarginValue'
        static member Initial = FssTypes.Initial |> scrollMarginValue'
        static member Unset = FssTypes.Unset |> scrollMarginValue'

    /// <summary>Specifies the scroll margin on all sides of an element.</summary>
    /// <param name="scrollMargin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMargin' (scrollMargin: FssTypes.IScrollMargin) = ScrollMargin.Value(scrollMargin)

    let private scrollMarginTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginTop value
    let private scrollMarginTopValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginTopValue
    type ScrollMarginTop =
        static member Value (top: FssTypes.IScrollMargin) = top |> scrollMarginTopValue'
        static member Inherit = FssTypes.Inherit |> scrollMarginTopValue'
        static member Initial = FssTypes.Initial |> scrollMarginTopValue'
        static member Unset = FssTypes.Unset |> scrollMarginTopValue'

    /// <summary>Specifies the scroll margin on top side of an element.</summary>
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginTop' (top: FssTypes.IScrollMargin) = ScrollMarginTop.Value(top)

    let private scrollMarginRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginRight value
    let private scrollMarginRightValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginRightValue
    type ScrollMarginRight =
        static member Value (right: FssTypes.IScrollMargin) = right |> scrollMarginRightValue'
        static member Inherit = FssTypes.Inherit |> scrollMarginRightValue'
        static member Initial = FssTypes.Initial |> scrollMarginRightValue'
        static member Unset = FssTypes.Unset |> scrollMarginRightValue'

    /// <summary>Specifies the scroll margin on right side of an element.</summary>
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginRight' (right: FssTypes.IScrollMargin) = ScrollMarginRight.Value(right)

    let private scrollMarginBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginBottom value
    let private scrollMarginBottomValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginBottomValue
    type ScrollMarginBottom =
        static member Value (bottom: FssTypes.IScrollMargin) = bottom |> scrollMarginBottomValue'
        static member Inherit = FssTypes.Inherit |> scrollMarginBottomValue'
        static member Initial = FssTypes.Initial |> scrollMarginBottomValue'
        static member Unset = FssTypes.Unset |> scrollMarginBottomValue'
    /// <summary>Specifies the scroll margin on bottom side of an element.</summary>
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginBottom' (bottom: FssTypes.IScrollMargin) = ScrollMarginBottom.Value(bottom)

    let private scrollMarginLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginLeft value
    let private scrollMarginLeftValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginLeftValue
    type ScrollMarginLeft =
        static member Value (left: FssTypes.IScrollMargin) = left |> scrollMarginLeftValue'
        static member Inherit = FssTypes.Inherit |> scrollMarginLeftValue'
        static member Initial = FssTypes.Initial |> scrollMarginLeftValue'
        static member Unset = FssTypes.Unset |> scrollMarginLeftValue'

    /// <summary>Specifies the scroll margin on left side of an element.</summary>
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginLeft' (left: FssTypes.IScrollMargin) = ScrollMarginLeft.Value(left)


// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding
[<AutoOpen>]
module ScrollPadding =
    let private scrollPaddingToString (scrollPadding: FssTypes.IScrollPadding) =
        match scrollPadding with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as g -> FssTypes.masterTypeHelpers.keywordsToString g
        | _ -> "Unknown scrollPadding"

    let private scrollPaddingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPadding value
    let private scrollPaddingValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingValue

    type ScrollPadding =
        static member Value (width: FssTypes.IScrollPadding) = width |> scrollPaddingValue'

        static member Value (vertical: FssTypes.IScrollPadding, horizontal: FssTypes.IScrollPadding) =
            sprintf "%s %s"
                (scrollPaddingToString vertical)
                (scrollPaddingToString horizontal)
            |> scrollPaddingValue
        static member Value (top: FssTypes.IScrollPadding, auto: FssTypes.IScrollPadding, bottom: FssTypes.IScrollPadding) =
            sprintf "%s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString auto)
                (scrollPaddingToString bottom)
            |> scrollPaddingValue
        static member Value (top: FssTypes.IScrollPadding, right: FssTypes.IScrollPadding, bottom: FssTypes.IScrollPadding, left: FssTypes.IScrollPadding) =
            sprintf "%s %s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString right)
                (scrollPaddingToString bottom)
                (scrollPaddingToString left)
            |> scrollPaddingValue
        static member Inherit = FssTypes.Inherit |> scrollPaddingValue'
        static member Initial = FssTypes.Initial |> scrollPaddingValue'
        static member Unset = FssTypes.Unset |> scrollPaddingValue'

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
    let ScrollPadding' (scrollPadding: FssTypes.IScrollPadding) = ScrollPadding.Value(scrollPadding)

    let private scrollPaddingTopValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingTop value
    let private scrollPaddingTopValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingTopValue
    type ScrollPaddingTop =
        static member Value (top: FssTypes.IScrollPadding) = top |> scrollPaddingTopValue'
        static member Inherit = FssTypes.Inherit |> scrollPaddingTopValue'
        static member Initial = FssTypes.Initial |> scrollPaddingTopValue'
        static member Unset = FssTypes.Unset |> scrollPaddingTopValue'

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
    let ScrollPaddingTop' (top: FssTypes.IScrollPadding) = ScrollPaddingTop.Value(top)

    let private scrollPaddingRightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingRight value
    let private scrollPaddingRightValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingRightValue
    type ScrollPaddingRight =
        static member Value (right: FssTypes.IScrollPadding) = right |> scrollPaddingRightValue'
        static member Inherit = FssTypes.Inherit |> scrollPaddingRightValue'
        static member Initial = FssTypes.Initial |> scrollPaddingRightValue'
        static member Unset = FssTypes.Unset |> scrollPaddingRightValue'

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
    let ScrollPaddingRight' (right: FssTypes.IScrollPadding) = ScrollPaddingRight.Value(right)

    let private scrollPaddingBottomValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingBottom value
    let private scrollPaddingBottomValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingBottomValue
    type ScrollPaddingBottom =
        static member Value (bottom: FssTypes.IScrollPadding) = bottom |> scrollPaddingBottomValue'
        static member Inherit = FssTypes.Inherit |> scrollPaddingBottomValue'
        static member Initial = FssTypes.Initial |> scrollPaddingBottomValue'
        static member Unset = FssTypes.Unset |> scrollPaddingBottomValue'
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
    let ScrollPaddingBottom' (bottom: FssTypes.IScrollPadding) = ScrollPaddingBottom.Value(bottom)

    let private scrollPaddingLeftValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingLeft value
    let private scrollPaddingLeftValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingLeftValue
    type ScrollPaddingLeft =
        static member Value (left: FssTypes.IScrollPadding) = left |> scrollPaddingLeftValue'
        static member Inherit = FssTypes.Inherit |> scrollPaddingLeftValue'
        static member Initial = FssTypes.Initial |> scrollPaddingLeftValue'
        static member Unset = FssTypes.Unset |> scrollPaddingLeftValue'

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
    let ScrollPaddingLeft' (left: FssTypes.IScrollPadding) = ScrollPaddingLeft.Value(left)

[<AutoOpen>]
module OverscrollBehaviorX =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
    let private stringifyBehavior (behavior: FssTypes.IOverscrollBehaviorX) =
        match behavior with
        | :? FssTypes.Scroll.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private overscrollBehaviour value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverscrollBehaviorX value
    let private overscrollBehaviour' value =
        value
        |> stringifyBehavior
        |> overscrollBehaviour

    type OverscrollBehaviorX =
        static member Value (behavior: FssTypes.IOverscrollBehaviorX) = behavior |> overscrollBehaviour
        static member Auto = FssTypes.Auto |> overscrollBehaviour'
        static member Contain = FssTypes.Scroll.OverscrollBehavior.Contain |> overscrollBehaviour'
        static member Inherit = FssTypes.Inherit |> overscrollBehaviour'
        static member Initial = FssTypes.Initial |> overscrollBehaviour'
        static member Unset = FssTypes.Unset |> overscrollBehaviour'

    /// <summary>Specify browser behavior when scroll hits horizontal boundry.</summary>
    /// <param name="behavior">
    ///     can be:
    ///     - <c> OverscrollBehavior </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OverscrollBehaviorX' (behavior: FssTypes.IOverscrollBehaviorX) = behavior |> OverscrollBehaviorX.Value

    [<AutoOpen>]
    module OverscrollBehaviorY =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-y
        let private stringifyBehavior (behavior: FssTypes.IOverscrollBehaviorY) =
            match behavior with
            | :? FssTypes.Scroll.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
            | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "Unknown all"

        let private overscrollBehaviour value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverscrollBehaviorY value
        let private overscrollBehaviour' value =
            value
            |> stringifyBehavior
            |> overscrollBehaviour

        type OverscrollBehaviorY =
            static member Value (behavior: FssTypes.IOverscrollBehaviorY) = behavior |> overscrollBehaviour
            static member Auto = FssTypes.Auto |> overscrollBehaviour'
            static member Contain = FssTypes.Scroll.OverscrollBehavior.Contain |> overscrollBehaviour'
            static member Inherit = FssTypes.Inherit |> overscrollBehaviour'
            static member Initial = FssTypes.Initial |> overscrollBehaviour'
            static member Unset = FssTypes.Unset |> overscrollBehaviour'

        /// <summary>Specify browser behavior when scroll hits vertical boundry.</summary>
        /// <param name="behavior">
        ///     can be:
        ///     - <c> OverscrollBehavior </c>
        ///     - <c> Auto </c>
        ///     - <c> Inherit </c>
        ///     - <c> Initial </c>
        ///     - <c> Unset </c>
        /// </param>
        /// <returns>Css property for fss.</returns>
        let OverscrollBehaviorY' (behavior: FssTypes.IOverscrollBehaviorY) = behavior |> OverscrollBehaviorY.Value
