namespace Fss

open FssTypes

[<AutoOpen>]
module ScrollBehavior =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-behavior
    let private stringifyScrollBehavior (behavior: IScrollBehavior) =
        match behavior with
        | :? ScrollBehavior as s -> Utilities.Helpers.duToKebab s
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown all"

    let private BehaviorValue value = Types.cssValue Types.Property.ScrollBehavior value
    let private BehaviorValue' value =
        value
        |> stringifyScrollBehavior
        |> BehaviorValue

    type ScrollBehavior =
        static member Value (behavior: IScrollBehavior) = behavior |> BehaviorValue'
        static member Smooth = Types.ScrollBehavior.Smooth |> BehaviorValue'
        static member Auto = Types.Auto |> BehaviorValue'
        static member Inherit = Types.Inherit |> BehaviorValue'
        static member Initial = Types.Initial |> BehaviorValue'
        static member Unset = Types.Unset |> BehaviorValue'

    /// <summary>Specifies the Behavior of scrolling.</summary>
    /// <param name="behavior">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ScrollBehavior' (behavior: IScrollBehavior) = behavior |> ScrollBehavior.Value

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
[<AutoOpen>]
module ScrollMargin =
    let private scrollMarginToString (scrollMargin: IScrollMargin) =
        match scrollMargin with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown scrollMargin"

    let private scrollMarginValue value = Types.cssValue Types.Property.ScrollMargin value
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
        static member Inherit = Types.Inherit |> scrollMarginValue'
        static member Initial = Types.Initial |> scrollMarginValue'
        static member Unset = Types.Unset |> scrollMarginValue'

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

    let private scrollMarginTopValue value = Types.cssValue Types.Property.ScrollMarginTop value
    let private scrollMarginTopValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginTopValue
    type ScrollMarginTop =
        static member Value (top: IScrollMargin) = top |> scrollMarginTopValue'
        static member Inherit = Types.Inherit |> scrollMarginTopValue'
        static member Initial = Types.Initial |> scrollMarginTopValue'
        static member Unset = Types.Unset |> scrollMarginTopValue'

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

    let private scrollMarginRightValue value = Types.cssValue Types.Property.ScrollMarginRight value
    let private scrollMarginRightValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginRightValue
    type ScrollMarginRight =
        static member Value (right: IScrollMargin) = right |> scrollMarginRightValue'
        static member Inherit = Types.Inherit |> scrollMarginRightValue'
        static member Initial = Types.Initial |> scrollMarginRightValue'
        static member Unset = Types.Unset |> scrollMarginRightValue'

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

    let private scrollMarginBottomValue value = Types.cssValue Types.Property.ScrollMarginBottom value
    let private scrollMarginBottomValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginBottomValue
    type ScrollMarginBottom =
        static member Value (bottom: IScrollMargin) = bottom |> scrollMarginBottomValue'
        static member Inherit = Types.Inherit |> scrollMarginBottomValue'
        static member Initial = Types.Initial |> scrollMarginBottomValue'
        static member Unset = Types.Unset |> scrollMarginBottomValue'
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

    let private scrollMarginLeftValue value = Types.cssValue Types.Property.ScrollMarginLeft value
    let private scrollMarginLeftValue' value =
        value
        |> scrollMarginToString
        |> scrollMarginLeftValue
    type ScrollMarginLeft =
        static member Value (left: IScrollMargin) = left |> scrollMarginLeftValue'
        static member Inherit = Types.Inherit |> scrollMarginLeftValue'
        static member Initial = Types.Initial |> scrollMarginLeftValue'
        static member Unset = Types.Unset |> scrollMarginLeftValue'

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
        | :? Types.Size as s -> Types.sizeToString s
        | :? Global as g -> GlobalValue.Types.keywordsToString g
        | _ -> "Unknown scrollPadding"

    let private scrollPaddingValue value = Types.cssValue Types.Property.ScrollPadding value
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
        static member Inherit = Types.Inherit |> scrollPaddingValue'
        static member Initial = Types.Initial |> scrollPaddingValue'
        static member Unset = Types.Unset |> scrollPaddingValue'

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

    let private scrollPaddingTopValue value = Types.cssValue Types.Property.ScrollPaddingTop value
    let private scrollPaddingTopValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingTopValue
    type ScrollPaddingTop =
        static member Value (top: IScrollPadding) = top |> scrollPaddingTopValue'
        static member Inherit = Types.Inherit |> scrollPaddingTopValue'
        static member Initial = Types.Initial |> scrollPaddingTopValue'
        static member Unset = Types.Unset |> scrollPaddingTopValue'

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

    let private scrollPaddingRightValue value = Types.cssValue Types.Property.ScrollPaddingRight value
    let private scrollPaddingRightValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingRightValue
    type ScrollPaddingRight =
        static member Value (right: IScrollPadding) = right |> scrollPaddingRightValue'
        static member Inherit = Types.Inherit |> scrollPaddingRightValue'
        static member Initial = Types.Initial |> scrollPaddingRightValue'
        static member Unset = Types.Unset |> scrollPaddingRightValue'

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

    let private scrollPaddingBottomValue value = Types.cssValue Types.Property.ScrollPaddingBottom value
    let private scrollPaddingBottomValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingBottomValue
    type ScrollPaddingBottom =
        static member Value (bottom: IScrollPadding) = bottom |> scrollPaddingBottomValue'
        static member Inherit = Types.Inherit |> scrollPaddingBottomValue'
        static member Initial = Types.Initial |> scrollPaddingBottomValue'
        static member Unset = Types.Unset |> scrollPaddingBottomValue'
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

    let private scrollPaddingLeftValue value = Types.cssValue Types.Property.ScrollPaddingLeft value
    let private scrollPaddingLeftValue' value =
        value
        |> scrollPaddingToString
        |> scrollPaddingLeftValue
    type ScrollPaddingLeft =
        static member Value (left: IScrollPadding) = left |> scrollPaddingLeftValue'
        static member Inherit = Types.Inherit |> scrollPaddingLeftValue'
        static member Initial = Types.Initial |> scrollPaddingLeftValue'
        static member Unset = Types.Unset |> scrollPaddingLeftValue'

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

[<AutoOpen>]
module OverscrollBehaviorX =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-x
    let private stringifyBehavior (behavior: IOverscrollBehaviorX) =
        match behavior with
        | :? OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown all"

    let private overscrollBehaviour value = Types.cssValue Types.Property.OverscrollBehaviorX value
    let private overscrollBehaviour' value =
        value
        |> stringifyBehavior
        |> overscrollBehaviour

    type OverscrollBehaviorX =
        static member Value (behavior: IOverscrollBehaviorX) = behavior |> overscrollBehaviour
        static member Auto = Types.Auto |> overscrollBehaviour'
        static member Contain = OverscrollBehavior.Contain |> overscrollBehaviour'
        static member Inherit = Types.Inherit |> overscrollBehaviour'
        static member Initial = Types.Initial |> overscrollBehaviour'
        static member Unset = Types.Unset |> overscrollBehaviour'

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
    let OverscrollBehaviorX' (behavior: IOverscrollBehaviorX) = behavior |> OverscrollBehaviorX.Value

    [<AutoOpen>]
    module OverscrollBehaviorY =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/overscroll-behavior-y
        let private stringifyBehavior (behavior: IOverscrollBehaviorY) =
            match behavior with
            | :? OverscrollBehavior as o -> Utilities.Helpers.duToLowercase o
            | :? Types.Auto -> Types.auto
            | :? Types.Keywords as k -> Types.keywordsToString k
            | _ -> "Unknown all"

        let private overscrollBehaviour value = Types.cssValue Types.Property.OverscrollBehaviorY value
        let private overscrollBehaviour' value =
            value
            |> stringifyBehavior
            |> overscrollBehaviour

        type OverscrollBehaviorY =
            static member Value (behavior: IOverscrollBehaviorY) = behavior |> overscrollBehaviour
            static member Auto = Types.Auto |> overscrollBehaviour'
            static member Contain = OverscrollBehavior.Contain |> overscrollBehaviour'
            static member Inherit = Types.Inherit |> overscrollBehaviour'
            static member Initial = Types.Initial |> overscrollBehaviour'
            static member Unset = Types.Unset |> overscrollBehaviour'

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
        let OverscrollBehaviorY' (behavior: IOverscrollBehaviorY) = behavior |> OverscrollBehaviorY.Value
