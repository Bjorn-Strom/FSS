namespace Fss

open Fable.Core

[<AutoOpen>]
module ScrollBehavior =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
    let private stringifyScrollBehavior (behavior: FssTypes.IScrollBehavior) =
        match behavior with
        | :? FssTypes.Scroll.ScrollBehavior as s -> Utilities.Helpers.duToKebab s
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private BehaviorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollBehavior
    let private BehaviorValue' = stringifyScrollBehavior >> BehaviorValue

    [<Erase>]
    type ScrollBehavior =
        static member value (behavior: FssTypes.IScrollBehavior) = behavior |> BehaviorValue'
        static member smooth = FssTypes.Scroll.ScrollBehavior.Smooth |> BehaviorValue'
        static member auto = FssTypes.Auto |> BehaviorValue'
        static member inherit' = FssTypes.Inherit |> BehaviorValue'
        static member initial = FssTypes.Initial |> BehaviorValue'
        static member unset = FssTypes.Unset |> BehaviorValue'

    /// <summary>Specifies the Behavior of scrolling.</summary>
    /// <param name="behavior">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollBehavior' = ScrollBehavior.value

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
[<AutoOpen>]
module ScrollMargin =
    let private scrollMarginToString (scrollMargin: FssTypes.IScrollMargin) =
        match scrollMargin with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown scrollMargin"

    let private scrollMarginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMargin
    let private scrollMarginValue' = scrollMarginToString >> scrollMarginValue

    [<Erase>]
    type ScrollMargin =
        static member value (width: FssTypes.IScrollMargin) = width |> scrollMarginValue'

        static member value (vertical: FssTypes.IScrollMargin, horizontal: FssTypes.IScrollMargin) =
            sprintf "%s %s"
                (scrollMarginToString vertical)
                (scrollMarginToString horizontal)
            |> scrollMarginValue
        static member value (top: FssTypes.IScrollMargin, auto: FssTypes.IScrollMargin, bottom: FssTypes.IScrollMargin) =
            sprintf "%s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString auto)
                (scrollMarginToString bottom)
            |> scrollMarginValue
        static member value (top: FssTypes.IScrollMargin, right: FssTypes.IScrollMargin, bottom: FssTypes.IScrollMargin, left: FssTypes.IScrollMargin) =
            sprintf "%s %s %s %s"
                (scrollMarginToString top)
                (scrollMarginToString right)
                (scrollMarginToString bottom)
                (scrollMarginToString left)
            |> scrollMarginValue
        static member inherit' = FssTypes.Inherit |> scrollMarginValue'
        static member initial = FssTypes.Initial |> scrollMarginValue'
        static member unset = FssTypes.Unset |> scrollMarginValue'

    /// <summary>Specifies the scroll margin on all sides of an element.</summary>
    /// <param name="scrollMargin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMargin' = ScrollMargin.value

    let private scrollMarginTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginTop
    let private scrollMarginTopValue' = scrollMarginToString >> scrollMarginTopValue

    [<Erase>]
    type ScrollMarginTop =
        static member value (top: FssTypes.IScrollMargin) = top |> scrollMarginTopValue'
        static member inherit' = FssTypes.Inherit |> scrollMarginTopValue'
        static member initial = FssTypes.Initial |> scrollMarginTopValue'
        static member unset = FssTypes.Unset |> scrollMarginTopValue'

    /// <summary>Specifies the scroll margin on top side of an element.</summary>
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginTop' = ScrollMarginTop.value

    let private scrollMarginRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginRight
    let private scrollMarginRightValue' = scrollMarginToString >> scrollMarginRightValue

    [<Erase>]
    type ScrollMarginRight =
        static member value (right: FssTypes.IScrollMargin) = right |> scrollMarginRightValue'
        static member inherit' = FssTypes.Inherit |> scrollMarginRightValue'
        static member initial = FssTypes.Initial |> scrollMarginRightValue'
        static member unset = FssTypes.Unset |> scrollMarginRightValue'

    /// <summary>Specifies the scroll margin on right side of an element.</summary>
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginRight' = ScrollMarginRight.value

    let private scrollMarginBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginBottom
    let private scrollMarginBottomValue' = scrollMarginToString >> scrollMarginBottomValue

    [<Erase>]
    type ScrollMarginBottom =
        static member value (bottom: FssTypes.IScrollMargin) = bottom |> scrollMarginBottomValue'
        static member inherit' = FssTypes.Inherit |> scrollMarginBottomValue'
        static member initial = FssTypes.Initial |> scrollMarginBottomValue'
        static member unset = FssTypes.Unset |> scrollMarginBottomValue'
    /// <summary>Specifies the scroll margin on bottom side of an element.</summary>
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginBottom' = ScrollMarginBottom.value

    let private scrollMarginLeftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginLeft
    let private scrollMarginLeftValue' = scrollMarginToString >> scrollMarginLeftValue

    [<Erase>]
    type ScrollMarginLeft =
        static member value (left: FssTypes.IScrollMargin) = left |> scrollMarginLeftValue'
        static member inherit' = FssTypes.Inherit |> scrollMarginLeftValue'
        static member initial = FssTypes.Initial |> scrollMarginLeftValue'
        static member unset = FssTypes.Unset |> scrollMarginLeftValue'

    /// <summary>Specifies the scroll margin on left side of an element.</summary>
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginLeft' = ScrollMarginLeft.value


// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding
[<AutoOpen>]
module ScrollPadding =
    let private scrollPaddingToString (scrollPadding: FssTypes.IScrollPadding) =
        match scrollPadding with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as g -> FssTypes.masterTypeHelpers.keywordsToString g
        | _ -> "Unknown scrollPadding"

    let private scrollPaddingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPadding
    let private scrollPaddingValue' = scrollPaddingToString >> scrollPaddingValue

    [<Erase>]
    type ScrollPadding =
        static member value (width: FssTypes.IScrollPadding) = width |> scrollPaddingValue'

        static member value (vertical: FssTypes.IScrollPadding, horizontal: FssTypes.IScrollPadding) =
            sprintf "%s %s"
                (scrollPaddingToString vertical)
                (scrollPaddingToString horizontal)
            |> scrollPaddingValue
        static member value (top: FssTypes.IScrollPadding, auto: FssTypes.IScrollPadding, bottom: FssTypes.IScrollPadding) =
            sprintf "%s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString auto)
                (scrollPaddingToString bottom)
            |> scrollPaddingValue
        static member value (top: FssTypes.IScrollPadding, right: FssTypes.IScrollPadding, bottom: FssTypes.IScrollPadding, left: FssTypes.IScrollPadding) =
            sprintf "%s %s %s %s"
                (scrollPaddingToString top)
                (scrollPaddingToString right)
                (scrollPaddingToString bottom)
                (scrollPaddingToString left)
            |> scrollPaddingValue
        static member inherit' = FssTypes.Inherit |> scrollPaddingValue'
        static member initial = FssTypes.Initial |> scrollPaddingValue'
        static member unset = FssTypes.Unset |> scrollPaddingValue'

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
    let ScrollPadding' = ScrollPadding.value

    let private scrollPaddingTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingTop
    let private scrollPaddingTopValue' = scrollPaddingToString >> scrollPaddingTopValue

    [<Erase>]
    type ScrollPaddingTop =
        static member value (top: FssTypes.IScrollPadding) = top |> scrollPaddingTopValue'
        static member inherit' = FssTypes.Inherit |> scrollPaddingTopValue'
        static member initial = FssTypes.Initial |> scrollPaddingTopValue'
        static member unset = FssTypes.Unset |> scrollPaddingTopValue'

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
    let ScrollPaddingTop' = ScrollPaddingTop.value

    let private scrollPaddingRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingRight
    let private scrollPaddingRightValue' = scrollPaddingToString >> scrollPaddingRightValue

    [<Erase>]
    type ScrollPaddingRight =
        static member value (right: FssTypes.IScrollPadding) = right |> scrollPaddingRightValue'
        static member inherit' = FssTypes.Inherit |> scrollPaddingRightValue'
        static member initial = FssTypes.Initial |> scrollPaddingRightValue'
        static member unset = FssTypes.Unset |> scrollPaddingRightValue'

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
    let ScrollPaddingRight' = ScrollPaddingRight.value

    let private scrollPaddingBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingBottom
    let private scrollPaddingBottomValue' = scrollPaddingToString >> scrollPaddingBottomValue

    [<Erase>]
    type ScrollPaddingBottom =
        static member value (bottom: FssTypes.IScrollPadding) = bottom |> scrollPaddingBottomValue'
        static member inherit' = FssTypes.Inherit |> scrollPaddingBottomValue'
        static member initial = FssTypes.Initial |> scrollPaddingBottomValue'
        static member unset = FssTypes.Unset |> scrollPaddingBottomValue'
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
    let ScrollPaddingBottom' = ScrollPaddingBottom.value

    let private scrollPaddingLeftValue  = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingLeft
    let private scrollPaddingLeftValue' = scrollPaddingToString >> scrollPaddingLeftValue

    [<Erase>]
    type ScrollPaddingLeft =
        static member value (left: FssTypes.IScrollPadding) = left |> scrollPaddingLeftValue'
        static member inherit' = FssTypes.Inherit |> scrollPaddingLeftValue'
        static member initial = FssTypes.Initial |> scrollPaddingLeftValue'
        static member unset = FssTypes.Unset |> scrollPaddingLeftValue'

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
    let ScrollPaddingLeft' = ScrollPaddingLeft.value

[<AutoOpen>]
module OverscrollBehaviorX =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
    let private stringifyBehavior (behavior: FssTypes.IOverscrollBehaviorX) =
        match behavior with
        | :? FssTypes.Scroll.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private overscrollBehaviour = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverscrollBehaviorX
    let private overscrollBehaviour': (FssTypes.IOverscrollBehaviorX -> FssTypes.CssProperty) = stringifyBehavior >> overscrollBehaviour

    [<Erase>]
    type OverscrollBehaviorX =
        static member value (behavior: FssTypes.IOverscrollBehaviorX) = behavior |> overscrollBehaviour'
        static member auto = FssTypes.Auto |> overscrollBehaviour'
        static member contain = FssTypes.Scroll.OverscrollBehavior.Contain |> overscrollBehaviour'
        static member inherit' = FssTypes.Inherit |> overscrollBehaviour'
        static member initial = FssTypes.Initial |> overscrollBehaviour'
        static member unset = FssTypes.Unset |> overscrollBehaviour'

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
    let OverscrollBehaviorX' = OverscrollBehaviorX.value

[<AutoOpen>]
module OverscrollBehaviorY =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-y
    let private stringifyBehavior (behavior: FssTypes.IOverscrollBehaviorY) =
        match behavior with
        | :? FssTypes.Scroll.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private overscrollBehaviour = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverscrollBehaviorY
    let private overscrollBehaviour': (FssTypes.IOverscrollBehaviorY -> FssTypes.CssProperty) = stringifyBehavior >> overscrollBehaviour

    [<Erase>]
    type OverscrollBehaviorY =
        static member value (behavior: FssTypes.IOverscrollBehaviorY) = behavior |> overscrollBehaviour'
        static member auto = FssTypes.Auto |> overscrollBehaviour'
        static member contain = FssTypes.Scroll.OverscrollBehavior.Contain |> overscrollBehaviour'
        static member inherit' = FssTypes.Inherit |> overscrollBehaviour'
        static member initial = FssTypes.Initial |> overscrollBehaviour'
        static member unset = FssTypes.Unset |> overscrollBehaviour'

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
    let OverscrollBehaviorY' = OverscrollBehaviorY.value
