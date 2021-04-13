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
    type Width =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> widthValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> widthValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> widthValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> widthValue'
        static member minContent = FssTypes.ContentSize.MinContent |> widthValue'

        static member auto = FssTypes.Auto |> widthValue'
        static member inherit' = FssTypes.Inherit |> widthValue'
        static member initial = FssTypes.Initial |> widthValue'
        static member unset = FssTypes.Unset |> widthValue'

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
    type MinWidth =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> minWidthValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> minWidthValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> minWidthValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> minWidthValue'
        static member minContent = FssTypes.ContentSize.MinContent |> minWidthValue'

        static member auto = FssTypes.Auto |> minWidthValue'
        static member inherit' = FssTypes.Inherit |> minWidthValue'
        static member initial = FssTypes.Initial |> minWidthValue'
        static member unset = FssTypes.Unset |> minWidthValue'

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
    type MaxWidth =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> maxWidthValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> maxWidthValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> maxWidthValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> maxWidthValue'
        static member minContent = FssTypes.ContentSize.MinContent |> maxWidthValue'

        static member auto = FssTypes.Auto |> maxWidthValue'
        static member inherit' = FssTypes.Inherit |> maxWidthValue'
        static member initial = FssTypes.Initial |> maxWidthValue'
        static member unset = FssTypes.Unset |> maxWidthValue'

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
    type Height =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> heightValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> heightValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> heightValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> heightValue'
        static member minContent = FssTypes.ContentSize.MinContent |> heightValue'

        static member auto = FssTypes.Auto |> heightValue'
        static member inherit' = FssTypes.Inherit |> heightValue'
        static member initial = FssTypes.Initial |> heightValue'
        static member unset = FssTypes.Unset |> heightValue'

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
    type MinHeight =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> minHeightValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> minHeightValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> minHeightValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> minHeightValue'
        static member minContent = FssTypes.ContentSize.MinContent |> minHeightValue'

        static member auto = FssTypes.Auto |> minHeightValue'
        static member inherit' = FssTypes.Inherit |> minHeightValue'
        static member initial = FssTypes.Initial |> minHeightValue'
        static member unset = FssTypes.Unset |> minHeightValue'

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
    type MaxHeight =
        static member fitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> maxHeightValue
        static member value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> maxHeightValue
        static member value (contentSize: FssTypes.IContentSize) = contentSize |> maxHeightValue'
        static member maxContent = FssTypes.ContentSize.MaxContent |> maxHeightValue'
        static member minContent = FssTypes.ContentSize.MinContent |> maxHeightValue'

        static member auto = FssTypes.Auto |> maxHeightValue'
        static member inherit' = FssTypes.Inherit |> maxHeightValue'
        static member initial = FssTypes.Initial |> maxHeightValue'
        static member unset = FssTypes.Unset |> maxHeightValue'

    /// Specifies max height of element.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let MaxHeight': (FssTypes.IContentSize -> FssTypes.CssProperty) = MaxHeight.value
