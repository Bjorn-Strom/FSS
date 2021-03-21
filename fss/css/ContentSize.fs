namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
[<AutoOpen>]
module ContentSize =
    type ContentSize =
        | MaxContent
        | MinContent
        | FitContent of Types.ILengthPercentage
        interface Types.IContentSize
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns

    let contentSizeToString (contentSize: Types.IContentSize) =
        let stringifyContent content =
            match content with
                | FitContent f -> sprintf "fit-content(%s)" (Types.lengthPercentageToString f)
                | _ -> Utilities.Helpers.duToKebab content

        match contentSize with
        | :? ContentSize as c -> stringifyContent c
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown content size"

    let private widthValue value = Types.cssValue Types.Property.Width value
    let private widthValue' value =
        value
        |> contentSizeToString
        |> widthValue

    type Width =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> widthValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> widthValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> widthValue'
        static member MaxContent = MaxContent |> widthValue'
        static member MinContent = MinContent |> widthValue'

        static member Auto = Types.Auto |> widthValue'
        static member Inherit = Types.Inherit |> widthValue'
        static member Initial = Types.Initial |> widthValue'
        static member Unset = Types.Unset |> widthValue'

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
    let Width' (size: Types.ILengthPercentage) = Width.Value(size)

    let private minWidthValue value = Types.cssValue Types.Property.MinWidth value
    let private minWidthValue' value =
        value
        |> contentSizeToString
        |> minWidthValue

    type MinWidth =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> minWidthValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> minWidthValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> minWidthValue'
        static member MaxContent = MaxContent |> minWidthValue'
        static member MinContent = MinContent |> minWidthValue'

        static member Auto = Types.Auto |> minWidthValue'
        static member Inherit = Types.Inherit |> minWidthValue'
        static member Initial = Types.Initial |> minWidthValue'
        static member Unset = Types.Unset |> minWidthValue'

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
    let MinWidth' (minWidth: Types.ILengthPercentage) = MinWidth.Value(minWidth)

    let private maxWidthValue value = Types.cssValue Types.Property.MaxWidth value
    let private maxWidthValue' value =
        value
        |> contentSizeToString
        |> maxWidthValue

    type MaxWidth =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> maxWidthValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> maxWidthValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> maxWidthValue'
        static member MaxContent = MaxContent |> maxWidthValue'
        static member MinContent = MinContent |> maxWidthValue'

        static member Auto = Types.Auto |> maxWidthValue'
        static member Inherit = Types.Inherit |> maxWidthValue'
        static member Initial = Types.Initial |> maxWidthValue'
        static member Unset = Types.Unset |> maxWidthValue'

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
    let MaxWidth' (maxWidth: Types.ILengthPercentage) = MaxWidth.Value(maxWidth)

    let private heightValue value = Types.cssValue Types.Property.Height value
    let private heightValue' value =
        value
        |> contentSizeToString
        |> heightValue

    type Height =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> heightValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> heightValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> heightValue'
        static member MaxContent = MaxContent |> heightValue'
        static member MinContent = MinContent |> heightValue'

        static member Auto = Types.Auto |> heightValue'
        static member Inherit = Types.Inherit |> heightValue'
        static member Initial = Types.Initial |> heightValue'
        static member Unset = Types.Unset |> heightValue'

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
    let Height' (height: Types.ILengthPercentage) = Height.Value(height)

    let private minHeightValue value = Types.cssValue Types.Property.MinHeight value
    let private minHeightValue' value =
        value
        |> contentSizeToString
        |> minHeightValue

    type MinHeight =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> minHeightValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> minHeightValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> minHeightValue'
        static member MaxContent = MaxContent |> minHeightValue'
        static member MinContent = MinContent |> minHeightValue'

        static member Auto = Types.Auto |> minHeightValue'
        static member Inherit = Types.Inherit |> minHeightValue'
        static member Initial = Types.Initial |> minHeightValue'
        static member Unset = Types.Unset |> minHeightValue'

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
    let MinHeight' (minHeight: Types.ILengthPercentage) = MinHeight.Value(minHeight)

    let private maxHeightValue value = Types.cssValue Types.Property.MaxHeight value
    let private maxHeightValue' value =
        value
        |> contentSizeToString
        |> maxHeightValue

    type MaxHeight =
        static member FitContent (contentSize: Types.ILengthPercentage) =
            sprintf "fit-content(%s)" (Types.lengthPercentageToString contentSize)
            |> maxHeightValue
        static member Value (size: Types.ILengthPercentage) = Types.lengthPercentageToString size |> maxHeightValue
        static member Value (contentSize: Types.IContentSize) = contentSize |> maxHeightValue'
        static member MaxContent = MaxContent |> maxHeightValue'
        static member MinContent = MinContent |> maxHeightValue'

        static member Auto = Types.Auto |> maxHeightValue'
        static member Inherit = Types.Inherit |> maxHeightValue'
        static member Initial = Types.Initial |> maxHeightValue'
        static member Unset = Types.Unset |> maxHeightValue'

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
    let MaxHeight' (maxHeight: Types.ILengthPercentage) = MaxHeight.Value(maxHeight)
