namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
[<AutoOpen>]
module ContentSize =

    let private widthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Width
    let private widthValue' = FssTypes.contentSizeHelpers.contentSizeToString >> widthValue

    [<Erase>]
    /// Specifies width of element.
    let Width = FssTypes.ContentSize.ContentSizeClass(widthValue, widthValue')

    /// Specifies width of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let Width': (FssTypes.ILengthPercentage -> FssTypes.CssProperty) = Width.value

    let private minWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MinWidth
    let private minWidthValue' = FssTypes.contentSizeHelpers.contentSizeToString >> minWidthValue

    [<Erase>]
    /// Specifies minimum width of element.
    let MinWidth = FssTypes.ContentSize.ContentSizeClass(minWidthValue, minWidthValue')

    /// Specifies minimum width of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MinWidth': (FssTypes.IContentSize -> FssTypes.CssProperty) = MinWidth.value

    let private maxWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaxWidth
    let private maxWidthValue' = FssTypes.contentSizeHelpers.contentSizeToString >> maxWidthValue

    [<Erase>]
    /// Specifies maximum width of element.
    let MaxWidth = FssTypes.ContentSize.ContentSizeClass(maxWidthValue, maxWidthValue')

    /// Specifies maximum width of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MaxWidth': (FssTypes.ILengthPercentage -> FssTypes.CssProperty) = MaxWidth.value

    let private heightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Height
    let private heightValue' = FssTypes.contentSizeHelpers.contentSizeToString >> heightValue

    [<Erase>]
    /// Specifies height of element.
    let Height = FssTypes.ContentSize.ContentSizeClass(heightValue, heightValue')

    /// Specifies height of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let Height': (FssTypes.ILengthPercentage -> FssTypes.CssProperty) = Height.value

    let private minHeightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MinHeight
    let private minHeightValue' = FssTypes.contentSizeHelpers.contentSizeToString >> minHeightValue

    [<Erase>]
    /// Specifies min height of element.
    let MinHeight = FssTypes.ContentSize.ContentSizeClass(minHeightValue, minHeightValue')

    /// Specifies min height of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MinHeight': (FssTypes.IContentSize -> FssTypes.CssProperty) = MinHeight.value

    let private maxHeightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaxHeight
    let private maxHeightValue' = FssTypes.contentSizeHelpers.contentSizeToString >> maxHeightValue

    [<Erase>]
    /// Specifies max height of element.
    let MaxHeight = FssTypes.ContentSize.ContentSizeClass(maxHeightValue, maxHeightValue')

    /// Specifies max height of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MaxHeight': (FssTypes.IContentSize -> FssTypes.CssProperty) = MaxHeight.value
