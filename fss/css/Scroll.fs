namespace Fss

open Fss
open Fss

[<RequireQualifiedAccess>]
module ScrollBehaviorTypes =
    type ScrollBehavior =
        | Smooth
        interface IScrollBehavior

[<AutoOpen>]
module ScrollBehavior =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
    let private stringifyScrollBehavior (behavior: IScrollBehavior) =
        match behavior with
        | :? ScrollBehaviorTypes.ScrollBehavior as s -> Utilities.Helpers.duToKebab s
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown all"

    let private BehaviorValue value = PropertyValue.cssValue Property.ScrollBehavior value
    let private BehaviorValue' value =
        value
        |> stringifyScrollBehavior
        |> BehaviorValue

    type ScrollBehavior =
        static member Value (behavior: IScrollBehavior) = behavior |> BehaviorValue'
        static member Smooth = ScrollBehaviorTypes.Smooth |> BehaviorValue'
        static member Auto = Auto |> BehaviorValue'
        static member Inherit = Inherit |> BehaviorValue'
        static member Initial = Initial |> BehaviorValue'
        static member Unset = Unset |> BehaviorValue'

    /// <summary>Specifies the Behavior of scrolling.</summary>
    /// <param name="behavior">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private ScrollBehavior' (behavior: IScrollBehavior) = behavior |> ScrollBehavior.Value

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
    /// <param name="scrollMargin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
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
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
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
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
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
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
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
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollMarginLeft' (left: IScrollMargin) = ScrollMarginLeft.Value(left)


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



[<RequireQualifiedAccess>]
module OverscrollBehaviorTypes =
    type OverscrollBehavior =
        | Contain
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY

[<AutoOpen>]
module OverscrollBehaviorX =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
    let private stringifyBehavior (behavior: IOverscrollBehaviorX) =
        match behavior with
        | :? OverscrollBehaviorTypes.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown all"

    let private overscrollBehaviour value = PropertyValue.cssValue Property.OverscrollBehaviorX value
    let private overscrollBehaviour' value =
        value
        |> stringifyBehavior
        |> overscrollBehaviour

    type OverscrollBehaviorX =
        static member Value (behavior: IOverscrollBehaviorX) = behavior |> overscrollBehaviour
        static member Auto = Auto |> overscrollBehaviour'
        static member Contain = OverscrollBehaviorTypes.Contain |> overscrollBehaviour'
        static member Inherit = Inherit |> overscrollBehaviour'
        static member Initial = Initial |> overscrollBehaviour'
        static member Unset = Unset |> overscrollBehaviour'

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
    let private OverscrollBehaviorX' (behavior: IOverscrollBehaviorX) = behavior |> OverscrollBehaviorX.Value

    [<AutoOpen>]
    module OverscrollBehaviorY =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-y
        let private stringifyBehavior (behavior: IOverscrollBehaviorY) =
            match behavior with
            | :? OverscrollBehaviorTypes.OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
            | :? Auto -> GlobalValue.auto
            | :? Global as g -> GlobalValue.global' g
            | _ -> "Unknown all"

        let private overscrollBehaviour value = PropertyValue.cssValue Property.OverscrollBehaviorY value
        let private overscrollBehaviour' value =
            value
            |> stringifyBehavior
            |> overscrollBehaviour

        type OverscrollBehaviorY =
            static member Value (behavior: IOverscrollBehaviorY) = behavior |> overscrollBehaviour
            static member Auto = Auto |> overscrollBehaviour'
            static member Contain = OverscrollBehaviorTypes.Contain |> overscrollBehaviour'
            static member Inherit = Inherit |> overscrollBehaviour'
            static member Initial = Initial |> overscrollBehaviour'
            static member Unset = Unset |> overscrollBehaviour'

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
        let private OverscrollBehaviorY' (behavior: IOverscrollBehaviorY) = behavior |> OverscrollBehaviorY.Value
