namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
[<AutoOpen>]
module ContentSize =

    let private widthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Width value
    let private widthValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> widthValue

    type Width =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> widthValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> widthValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> widthValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> widthValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> widthValue'

        static member Auto = FssTypes.Auto |> widthValue'
        static member Inherit = FssTypes.Inherit |> widthValue'
        static member Initial = FssTypes.Initial |> widthValue'
        static member Unset = FssTypes.Unset |> widthValue'

    /// <summary>Specifies width of element.</summary>
    /// <param name="size">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Width' (size: FssTypes.ILengthPercentage) = Width.Value(size)

    let private minWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MinWidth value
    let private minWidthValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> minWidthValue

    type MinWidth =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> minWidthValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> minWidthValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> minWidthValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> minWidthValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> minWidthValue'

        static member Auto = FssTypes.Auto |> minWidthValue'
        static member Inherit = FssTypes.Inherit |> minWidthValue'
        static member Initial = FssTypes.Initial |> minWidthValue'
        static member Unset = FssTypes.Unset |> minWidthValue'

    /// <summary>Specifies minimum width of element.</summary>
    /// <param name="minWidth">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MinWidth' (minWidth: FssTypes.ILengthPercentage) = MinWidth.Value(minWidth)

    let private maxWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaxWidth value
    let private maxWidthValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> maxWidthValue

    type MaxWidth =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> maxWidthValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> maxWidthValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> maxWidthValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> maxWidthValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> maxWidthValue'

        static member Auto = FssTypes.Auto |> maxWidthValue'
        static member Inherit = FssTypes.Inherit |> maxWidthValue'
        static member Initial = FssTypes.Initial |> maxWidthValue'
        static member Unset = FssTypes.Unset |> maxWidthValue'

    /// <summary>Specifies maximum width of element.</summary>
    /// <param name="maxWidth">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaxWidth' (maxWidth: FssTypes.ILengthPercentage) = MaxWidth.Value(maxWidth)

    let private heightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Height value
    let private heightValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> heightValue

    type Height =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> heightValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> heightValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> heightValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> heightValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> heightValue'

        static member Auto = FssTypes.Auto |> heightValue'
        static member Inherit = FssTypes.Inherit |> heightValue'
        static member Initial = FssTypes.Initial |> heightValue'
        static member Unset = FssTypes.Unset |> heightValue'

    /// <summary>Specifies height of element.</summary>
    /// <param name="height">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Height' (height: FssTypes.ILengthPercentage) = Height.Value(height)

    let private minHeightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MinHeight value
    let private minHeightValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> minHeightValue

    type MinHeight =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> minHeightValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> minHeightValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> minHeightValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> minHeightValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> minHeightValue'

        static member Auto = FssTypes.Auto |> minHeightValue'
        static member Inherit = FssTypes.Inherit |> minHeightValue'
        static member Initial = FssTypes.Initial |> minHeightValue'
        static member Unset = FssTypes.Unset |> minHeightValue'

    /// <summary>Specifies min height of element.</summary>
    /// <param name="minHeight">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MinHeight' (minHeight: FssTypes.ILengthPercentage) = MinHeight.Value(minHeight)

    let private maxHeightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaxHeight value
    let private maxHeightValue' value =
        value
        |> FssTypes.contentSizeHelpers.contentSizeToString
        |> maxHeightValue

    type MaxHeight =
        static member FitContent (contentSize: FssTypes.ILengthPercentage) =
            sprintf "fit-content(%s)" (FssTypes.unitHelpers.lengthPercentageToString contentSize)
            |> maxHeightValue
        static member Value (size: FssTypes.ILengthPercentage) = FssTypes.unitHelpers.lengthPercentageToString size |> maxHeightValue
        static member Value (contentSize: FssTypes.IContentSize) = contentSize |> maxHeightValue'
        static member MaxContent = FssTypes.ContentSize.MaxContent |> maxHeightValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> maxHeightValue'

        static member Auto = FssTypes.Auto |> maxHeightValue'
        static member Inherit = FssTypes.Inherit |> maxHeightValue'
        static member Initial = FssTypes.Initial |> maxHeightValue'
        static member Unset = FssTypes.Unset |> maxHeightValue'

    /// <summary>Specifies max height of element.</summary>
    /// <param name="maxHeight">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaxHeight' (maxHeight: FssTypes.ILengthPercentage) = MaxHeight.Value(maxHeight)
