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
    /// Specifies the Behavior of scrolling.
    type ScrollBehavior =
        static member value (behavior: FssTypes.IScrollBehavior) = behavior |> BehaviorValue'
        static member smooth = FssTypes.Scroll.ScrollBehavior.Smooth |> BehaviorValue'
        static member auto = FssTypes.Auto |> BehaviorValue'
        static member inherit' = FssTypes.Inherit |> BehaviorValue'
        static member initial = FssTypes.Initial |> BehaviorValue'
        static member unset = FssTypes.Unset |> BehaviorValue'

    /// Specifies the Behavior of scrolling.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollBehavior' = ScrollBehavior.value

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-margin
[<AutoOpen>]
module ScrollMargin =
    let private scrollMarginToString (scrollMargin: FssTypes.IScrollMargin) =
        match scrollMargin with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown scrollMargin"

    let private scrollMarginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMargin
    let private scrollMarginValue' = scrollMarginToString >> scrollMarginValue

    [<Erase>]
    /// Specifies the scroll margin on all sides of an element.
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

    /// Specifies the scroll margin on all sides of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollMargin' = ScrollMargin.value

    let private scrollMarginTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginTop
    let private scrollMarginTopValue' = scrollMarginToString >> scrollMarginTopValue

    [<Erase>]
    /// Specifies the scroll margin on top side of an element.
    let ScrollMarginTop = FssTypes.Scroll.ScrollMargin(scrollMarginTopValue')

    /// Specifies the scroll margin on top side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollMarginTop' = ScrollMarginTop.value

    let private scrollMarginRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginRight
    let private scrollMarginRightValue' = scrollMarginToString >> scrollMarginRightValue

    [<Erase>]
    /// Specifies the scroll margin on right side of an element.
    let ScrollMarginRight = FssTypes.Scroll.ScrollMargin(scrollMarginRightValue')

    /// Specifies the scroll margin on right side of an element.
    /// - Units.Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollMarginRight' = ScrollMarginRight.value

    let private scrollMarginBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginBottom
    let private scrollMarginBottomValue' = scrollMarginToString >> scrollMarginBottomValue

    [<Erase>]
    /// Specifies the scroll margin on bottom side of an element.
    let ScrollMarginBottom = FssTypes.Scroll.ScrollMargin(scrollMarginBottomValue')

    /// Specifies the scroll margin on bottom side of an element.
    /// - Units.Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollMarginBottom' = ScrollMarginBottom.value

    let private scrollMarginLeftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollMarginLeft
    let private scrollMarginLeftValue' = scrollMarginToString >> scrollMarginLeftValue

    [<Erase>]
    /// Specifies the scroll margin on left side of an element.
    let ScrollMarginLeft = FssTypes.Scroll.ScrollMargin(scrollMarginLeftValue')

    /// Specifies the scroll margin on left side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ScrollMarginLeft' = ScrollMarginLeft.value

// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-padding
[<AutoOpen>]
module ScrollPadding =
    let private scrollPaddingToString (scrollPadding: FssTypes.IScrollPadding) =
        match scrollPadding with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as g -> FssTypes.masterTypeHelpers.keywordsToString g
        | _ -> "Unknown scrollPadding"

    let private scrollPaddingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPadding
    let private scrollPaddingValue' = scrollPaddingToString >> scrollPaddingValue

    [<Erase>]
    /// Specifies the scroll padding on all sides of an element.
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

    /// Specifies the scroll padding on all sides of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ScrollPadding' = ScrollPadding.value

    let private scrollPaddingTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingTop
    let private scrollPaddingTopValue' = scrollPaddingToString >> scrollPaddingTopValue

    [<Erase>]
    /// Specifies the scroll padding on top side of an element.
    type ScrollPaddingTop =
        static member value (top: FssTypes.IScrollPadding) = top |> scrollPaddingTopValue'
        static member inherit' = FssTypes.Inherit |> scrollPaddingTopValue'
        static member initial = FssTypes.Initial |> scrollPaddingTopValue'
        static member unset = FssTypes.Unset |> scrollPaddingTopValue'

    /// Specifies the scroll padding on top side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ScrollPaddingTop' = ScrollPaddingTop.value

    let private scrollPaddingRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingRight
    let private scrollPaddingRightValue' = scrollPaddingToString >> scrollPaddingRightValue

    [<Erase>]
    /// Specifies the scroll padding on right side of an element.
    let ScrollPaddingRight = FssTypes.Scroll.ScrollPadding(scrollPaddingRightValue')

    /// Specifies the scroll padding on right side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ScrollPaddingRight' = ScrollPaddingRight.value

    let private scrollPaddingBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingBottom
    let private scrollPaddingBottomValue' = scrollPaddingToString >> scrollPaddingBottomValue

    [<Erase>]
    /// Specifies the scroll padding on bottom side of an element.
    let ScrollPaddingBottom = FssTypes.Scroll.ScrollPadding(scrollPaddingBottomValue')

    /// Specifies the scroll padding on bottom side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ScrollPaddingBottom' = ScrollPaddingBottom.value

    let private scrollPaddingLeftValue  = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollPaddingLeft
    let private scrollPaddingLeftValue' = scrollPaddingToString >> scrollPaddingLeftValue

    [<Erase>]
    /// Specifies the scroll padding on left side of an element.
    let ScrollPaddingLeft = FssTypes.Scroll.ScrollPadding(scrollPaddingLeftValue')

    /// Specifies the scroll padding on left side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
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

    /// Specify browser behavior when scroll hits horizontal boundary.
    /// Valid parameters:
    /// - OverscrollBehavior
    /// - Auto
    /// - Inherit
    /// - Initial
    /// - Unset
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

    /// Specify browser behavior when scroll hits vertical boundary.
    /// Valid parameters:
    /// - OverscrollBehavior
    /// - Auto
    /// - Inherit
    /// - Initial
    /// - Unset
    let OverscrollBehaviorY' = OverscrollBehaviorY.value

[<AutoOpen>]
module ScrollSnapType =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
    let private stringifySnap (snap: FssTypes.IScrollSnapType) =
        match snap with
        | :? FssTypes.Scroll.SnapType.Type as s -> Utilities.Helpers.duToLowercase s
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown scroll snap type"

    let private snapType = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollSnapType
    let private snapType': (FssTypes.IScrollSnapType -> FssTypes.CssProperty) = stringifySnap >> snapType

    type ScrollSnapType =
        static member value (type': FssTypes.IScrollSnapType) = type' |> snapType'
        static member value (type': FssTypes.Scroll.SnapType.Type, viewPort: FssTypes.Scroll.SnapType.Viewport) =
            $"{stringifySnap type'} {Utilities.Helpers.duToLowercase viewPort}" |> snapType

        static member x = FssTypes.Scroll.SnapType.X |> snapType'
        static member y = FssTypes.Scroll.SnapType.Y |> snapType'
        static member block = FssTypes.Scroll.SnapType.Block |> snapType'
        static member inline' = FssTypes.Scroll.SnapType.Inline |> snapType'
        static member both = FssTypes.Scroll.SnapType.Both |> snapType'

        static member none = FssTypes.None' |> snapType'
        static member inherit' = FssTypes.Inherit |> snapType'
        static member initial = FssTypes.Initial |> snapType'
        static member unset = FssTypes.Unset |> snapType'

    let ScrollSnapType' snapType viewPort = ScrollSnapType.value(snapType, viewPort)

[<AutoOpen>]
module ScrollSnapAlign =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
    let private stringifySnap (snap: FssTypes.IScrollSnapAlign) =
        match snap with
        | :? FssTypes.Scroll.SnapAlign as s -> Utilities.Helpers.duToLowercase s
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown scroll snap align"

    let private snapAlign = FssTypes.propertyHelpers.cssValue FssTypes.Property.ScrollSnapAlign
    let private snapAlign': (FssTypes.IScrollSnapAlign -> FssTypes.CssProperty) = stringifySnap >> snapAlign

    type ScrollSnapAlign =
        static member value (align: FssTypes.IScrollSnapAlign) = align |> snapAlign'
        static member value (block: FssTypes.Scroll.SnapAlign, inline': FssTypes.Scroll.SnapAlign) =
            $"{stringifySnap block} {stringifySnap inline'}" |> snapAlign

        static member start = FssTypes.Scroll.SnapAlign.Start |> snapAlign'
        static member end' = FssTypes.Scroll.SnapAlign.End |> snapAlign'
        static member center = FssTypes.Scroll.SnapAlign.Center |> snapAlign'

        static member none = FssTypes.None' |> snapAlign'
        static member inherit' = FssTypes.Inherit |> snapAlign'
        static member initial = FssTypes.Initial |> snapAlign'
        static member unset = FssTypes.Unset |> snapAlign'

    let ScrollSnapAlign' block inline' = ScrollSnapAlign.value(block, inline')