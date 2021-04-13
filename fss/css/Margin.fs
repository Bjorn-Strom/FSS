namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: FssTypes.IMargin) =
        match margin with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown margin"

    let private marginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Margin
    let private marginValue' = marginToString >> marginValue

    [<Erase>]
    /// Specifies the margin on all sides of an element.
    let Margin = FssTypes.Margin.Margin(marginToString, marginValue, marginValue')

    /// Specifies the margin on all sides of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let Margin' = Margin.value
    let private marginTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginTop
    let private marginTopValue' = marginToString >> marginTopValue

    [<Erase>]
    /// Specifies the margin on top side of an element.
    let MarginTop = FssTypes.Margin.MarginSide(marginTopValue')

    /// Specifies the margin on top side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginTop' = MarginTop.value

    let private marginRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginRight
    let private marginRightValue' = marginToString >> marginRightValue

    [<Erase>]
    /// Specifies the margin on right side of an element.
    let MarginRight = FssTypes.Margin.MarginSide(marginRightValue')

    /// Specifies the margin on right side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginRight' = MarginRight.value

    let private marginBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBottom
    let private marginBottomValue' = marginToString >> marginBottomValue

    [<Erase>]
    /// Specifies the margin on bottom side of an element.
    let MarginBottom = FssTypes.Margin.MarginSide(marginBottomValue')

    /// Specifies the margin on bottom side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginBottom' = MarginBottom.value

    let private marginLeftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginLeft
    let private marginLeftValue' = marginToString >> marginLeftValue

    [<Erase>]
    /// Specifies the margin on left side of an element.
    let MarginLeft = FssTypes.Margin.MarginSide(marginLeftValue')

    /// Specifies the margin on left side of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginLeft' = MarginLeft.value

    let private marginInlineStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineStart
    let private marginInlineStartValue' = marginToString >> marginInlineStartValue

    [<Erase>]
    let MarginInlineStart = FssTypes.Margin.MarginSide(marginInlineStartValue')

    /// Specifies the amount of space along the outer starting edge of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginInlineStart' = MarginInlineStart.value

    let private marginInlineEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineEnd
    let private marginInlineEndValue' = marginToString >> marginInlineEndValue

    [<Erase>]
    /// Specifies the amount of space along the outer ending edge of an element.
    let MarginInlineEnd = FssTypes.Margin.MarginSide(marginInlineEndValue')

    /// Specifies the amount of space along the outer ending edge of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginInlineEnd' = MarginInlineEnd.value

    let private marginBlockStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockStart
    let private marginBlockStartValue' = marginToString >> marginBlockStartValue

    [<Erase>]
    /// Specifies the amount of start margin of an element.
    let MarginBlockStart = FssTypes.Margin.MarginSide(marginBlockStartValue')

    /// Specifies the amount of start margin of an element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginBlockStart' = MarginBlockStart.value

    let private marginBlockEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockEnd
    let private marginBlockEndValue' = marginToString >> marginBlockEndValue

    [<Erase>]
    /// Specifies the amount of end margin of an element
    let MarginBlockEnd = FssTypes.Margin.MarginSide(marginBlockEndValue')

    /// Specifies the amount of end margin of an element
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MarginBlockEnd' = MarginBlockEnd.value