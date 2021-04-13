namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/padding
[<AutoOpen>]
module Padding =
    let private paddingToString (padding: FssTypes.IPadding) =
        match padding with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown padding"

    let private paddingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Padding
    let private paddingValue' = paddingToString >> paddingValue

    [<Erase>]
    /// Specifies the padding on all sides of an element.
    let Padding = FssTypes.Padding.Padding(paddingToString, paddingValue, paddingValue')

    /// Specifies the padding on all sides of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let Padding' = Padding.value

    let private paddingTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingTop
    let private paddingTopValue' = paddingToString >> paddingTopValue

    [<Erase>]
    /// Specifies the padding on top sides of an element.
    let PaddingTop = FssTypes.Padding.PaddingSide(paddingTopValue')

    /// Specifies the padding on top sides of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingTop' = PaddingTop.value

    let private paddingRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingRight
    let private paddingRightValue' = paddingToString >> paddingRightValue

    [<Erase>]
    /// Specifies the padding on right side of an element.
    let PaddingRight = FssTypes.Padding.PaddingSide(paddingRightValue')
    /// Specifies the padding on right side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingRight' = PaddingRight.value

    let private paddingBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBottom
    let private paddingBottomValue' = paddingToString >> paddingBottomValue

    [<Erase>]
    /// Specifies the padding on bottom side of an element.
    let PaddingBottom = FssTypes.Padding.PaddingSide(paddingBottomValue')

    /// Specifies the padding on bottom side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingBottom' = PaddingBottom.value

    let private paddingLeftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingLeft
    let private paddingLeftValue' = paddingToString >> paddingLeftValue

    [<Erase>]
    /// Specifies the padding on left side of an element.
    let PaddingLeft = FssTypes.Padding.PaddingSide(paddingLeftValue')

    /// Specifies the padding on left side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingLeft' = PaddingLeft.value

    let private paddingInlineStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineStart
    let private paddingInlineStartValue' = paddingToString >> paddingInlineStartValue

    [<Erase>]
    /// Specifies the amount of space along the outer starting edge of an element.
    let PaddingInlineStart = FssTypes.Padding.PaddingSide(paddingInlineStartValue')

    /// Specifies the amount of space along the outer starting edge of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingInlineStart' = PaddingInlineStart.value

    let private paddingInlineEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingInlineEnd
    let private paddingInlineEndValue' = paddingToString >> paddingInlineEndValue

    [<Erase>]
    /// Specifies the amount of space along the outer ending edge of an element.
    let PaddingInlineEnd = FssTypes.Padding.PaddingSide(paddingInlineEndValue')

    /// Specifies the amount of space along the outer ending edge of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingInlineEnd' = PaddingInlineEnd.value

    let private paddingBlockStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockStart
    let private paddingBlockStartValue' = paddingToString >> paddingBlockStartValue

    [<Erase>]
    /// Specifies the amount of start padding of an element.
    let PaddingBlockStart = FssTypes.Padding.PaddingSide(paddingBlockStartValue')

    /// Specifies the amount of start padding of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingBlockStart' = PaddingBlockStart.value

    let private paddingBlockEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PaddingBlockEnd
    let private paddingBlockEndValue' = paddingToString >> paddingBlockEndValue

    [<Erase>]
    /// Specifies the amount of end padding of an element
    let PaddingBlockEnd = FssTypes.Padding.PaddingSide(paddingBlockEndValue')

    /// Specifies the amount of end padding of an element
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let PaddingBlockEnd' = PaddingBlockEnd.value