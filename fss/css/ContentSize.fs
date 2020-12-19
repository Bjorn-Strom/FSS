namespace Fss

open Fss

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
        | FitContent of ILengthPercentage
        interface IContentSize
        interface IGridAutoRows
        interface IGridAutoColumns

    let contentSizeToString (contentSize: IContentSize) =
        let stringifyContent content =
            match content with
                | FitContent f -> sprintf "fit-content(%s)" (Units.LengthPercentage.value f)
                | _ -> Utilities.Helpers.duToKebab content

        match contentSize with
        | :? ContentSize as c -> stringifyContent c
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown content size"

    let private widthValue value = PropertyValue.cssValue Property.Width value
    let private widthValue' value =
        value
        |> contentSizeToString
        |> widthValue

    type Width =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> widthValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> widthValue
        static member Value (contentSize: IContentSize) = contentSize |> widthValue'
        static member MaxContent = MaxContent |> widthValue'
        static member MinContent = MinContent |> widthValue'

        static member Auto = Auto |> widthValue'
        static member Inherit = Inherit |> widthValue'
        static member Initial = Initial |> widthValue'
        static member Unset = Unset |> widthValue'

    let Width' (size: ILengthPercentage) = Width.Value(size)

    let private minWidthValue value = PropertyValue.cssValue Property.MinWidth value
    let private minWidthValue' value =
        value
        |> contentSizeToString
        |> minWidthValue

    type MinWidth =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> minWidthValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> minWidthValue
        static member Value (contentSize: IContentSize) = contentSize |> minWidthValue'
        static member MaxContent = MaxContent |> minWidthValue'
        static member MinContent = MinContent |> minWidthValue'

        static member Auto = Auto |> minWidthValue'
        static member Inherit = Inherit |> minWidthValue'
        static member Initial = Initial |> minWidthValue'
        static member Unset = Unset |> minWidthValue'

    let MinWidth' (minWidth: ILengthPercentage) = MinWidth.Value(minWidth)

    let private maxWidthValue value = PropertyValue.cssValue Property.MaxWidth value
    let private maxWidthValue' value =
        value
        |> contentSizeToString
        |> maxWidthValue

    type MaxWidth =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> maxWidthValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> maxWidthValue
        static member Value (contentSize: IContentSize) = contentSize |> maxWidthValue'
        static member MaxContent = MaxContent |> maxWidthValue'
        static member MinContent = MinContent |> maxWidthValue'

        static member Auto = Auto |> maxWidthValue'
        static member Inherit = Inherit |> maxWidthValue'
        static member Initial = Initial |> maxWidthValue'
        static member Unset = Unset |> maxWidthValue'

    let MaxWidth' (maxWidth: ILengthPercentage) = MaxWidth.Value(maxWidth)

    let private heightValue value = PropertyValue.cssValue Property.Height value
    let private heightValue' value =
        value
        |> contentSizeToString
        |> heightValue

    type Height =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> heightValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> heightValue
        static member Value (contentSize: IContentSize) = contentSize |> heightValue'
        static member MaxContent = MaxContent |> heightValue'
        static member MinContent = MinContent |> heightValue'

        static member Auto = Auto |> heightValue'
        static member Inherit = Inherit |> heightValue'
        static member Initial = Initial |> heightValue'
        static member Unset = Unset |> heightValue'

    let Height' (height: ILengthPercentage) = Height.Value(height)

    let private minHeightValue value = PropertyValue.cssValue Property.MinHeight value
    let private minHeightValue' value =
        value
        |> contentSizeToString
        |> minHeightValue

    type MinHeight =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> minHeightValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> minHeightValue
        static member Value (contentSize: IContentSize) = contentSize |> minHeightValue'
        static member MaxContent = MaxContent |> minHeightValue'
        static member MinContent = MinContent |> minHeightValue'

        static member Auto = Auto |> minHeightValue'
        static member Inherit = Inherit |> minHeightValue'
        static member Initial = Initial |> minHeightValue'
        static member Unset = Unset |> minHeightValue'

    let MinHeight' (minHeight: ILengthPercentage) = MinHeight.Value(minHeight)

    let private maxHeightValue value = PropertyValue.cssValue Property.MaxHeight value
    let private maxHeightValue' value =
        value
        |> contentSizeToString
        |> maxHeightValue

    type MaxHeight =
        static member FitContent (contentSize: ILengthPercentage) =
            sprintf "fit-content(%s)" (Units.LengthPercentage.value contentSize)
            |> maxHeightValue
        static member Value (size: ILengthPercentage) = Units.LengthPercentage.value size |> maxHeightValue
        static member Value (contentSize: IContentSize) = contentSize |> maxHeightValue'
        static member MaxContent = MaxContent |> maxHeightValue'
        static member MinContent = MinContent |> maxHeightValue'

        static member Auto = Auto |> maxHeightValue'
        static member Inherit = Inherit |> maxHeightValue'
        static member Initial = Initial |> maxHeightValue'
        static member Unset = Unset |> maxHeightValue'

    let MaxHeight' (maxHeight: ILengthPercentage) = MaxHeight.Value(maxHeight)
