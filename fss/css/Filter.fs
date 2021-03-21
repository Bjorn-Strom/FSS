namespace Fss

open FssTypes

[<AutoOpen>]
module Filter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    let private stringifyFilter (filter: IFilter) =
        match filter with
        | :? Filter as f -> Filter.stringifyFilter f
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown filter"

    let private filterValue value = PropertyValue.cssValue Property.Filter value
    let private filterValue' value =
        value
        |> stringifyFilter
        |> filterValue

    type Filter =
        static member Url url  = FssTypes.Filter.Url url
        static member Blur blur = FssTypes.Filter.Blur blur
        static member Brightness brightness = FssTypes.Filter.Brightness brightness
        static member Contrast contrast = FssTypes.Filter.Contrast contrast
        static member DropShadow x y blur color invert = FssTypes.Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = FssTypes.Filter.Grayscale grayScale
        static member HueRotate hueRotate = FssTypes.Filter.HueRotate hueRotate
        static member Invert invert = FssTypes.Filter.Invert invert
        static member Opacity opacity = FssTypes.Filter.Opacity opacity
        static member Saturate saturate = FssTypes.Filter.Saturate saturate
        static member Sepia sepia = FssTypes.Filter.Sepia sepia

        static member None = None' |> filterValue'
        static member Inherit = Inherit |> filterValue'
        static member Initial = Initial |> filterValue'
        static member Unset = Unset |> filterValue'

    /// Supply a list of filters to be applied to the element.
    let Filters (filters: FssTypes.Filter list): CssProperty =
        filters
        |> Utilities.Helpers.combineWs Filter.stringifyFilter
        |> filterValue

[<AutoOpen>]
module BackdropFilter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/backdrop-filter
    let private stringifyFilter (backdropFilter: IBackdropFilter) =
        match backdropFilter with
        | :? FssTypes.Filter as f -> Filter.stringifyFilter f
        | :? Global as g -> global' g
        | :? None' -> none
        | _ -> "Unknown backdrop filter"

    let private backdropFilterValue value = PropertyValue.cssValue Property.BackdropFilter value
    let private backdropFilterValue' value =
        value
        |> stringifyFilter
        |> backdropFilterValue

    type BackdropFilter =
        static member Url url = FssTypes.Filter.Url url
        static member Blur blur = FssTypes.Filter.Blur blur
        static member Brightness brightness = FssTypes.Filter.Brightness brightness
        static member Contrast contrast = FssTypes.Filter.Contrast contrast
        static member DropShadow x y blur color invert = FssTypes.Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = FssTypes.Filter.Grayscale grayScale
        static member HueRotate hueRotate = FssTypes.Filter.HueRotate hueRotate
        static member Invert invert = FssTypes.Filter.Invert invert
        static member Opacity opacity = FssTypes.Filter.Opacity opacity
        static member Saturate saturate = FssTypes.Filter.Saturate saturate
        static member Sepia sepia = FssTypes.Filter.Sepia sepia

        static member None = None' |> backdropFilterValue'
        static member Inherit = Inherit |> backdropFilterValue'
        static member Initial = Initial |> backdropFilterValue'
        static member Unset = Unset |> backdropFilterValue'

    /// Supply a list of filters to be applied to the element.
    let BackdropFilters (backdropFilters: FssTypes.Filter list): CssProperty =
        backdropFilters
        |> Utilities.Helpers.combineWs Filter.stringifyFilter
        |> backdropFilterValue