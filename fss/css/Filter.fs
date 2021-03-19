namespace Fss

open FssTypes

[<AutoOpen>]
module Filter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    let private stringifyFilter (filter: IFilter) =
        match filter with
        | :?Filter.Filter as f -> Filter.stringifyFilter f
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown filter"

    let private filterValue value = PropertyValue.cssValue Property.Filter value
    let private filterValue' value =
        value
        |> stringifyFilter
        |> filterValue

    type Filter =
        static member Url url  = Filter.Url url
        static member Blur blur = Filter.Blur blur
        static member Brightness brightness = Filter.Brightness brightness
        static member Contrast contrast = Filter.Contrast contrast
        static member DropShadow x y blur color invert = Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = Filter.Grayscale grayScale
        static member HueRotate hueRotate = Filter.HueRotate hueRotate
        static member Invert invert = Filter.Invert invert
        static member Opacity opacity = Filter.Opacity opacity
        static member Saturate saturate = Filter.Saturate saturate
        static member Sepia sepia = Filter.Sepia sepia

        static member None = None' |> filterValue'
        static member Inherit = Inherit |> filterValue'
        static member Initial = Initial |> filterValue'
        static member Unset = Unset |> filterValue'

    /// Supply a list of filters to be applied to the element.
    let Filters (filters: Filter.Filter list): CssProperty =
        filters
        |> Utilities.Helpers.combineWs Filter.stringifyFilter
        |> filterValue

[<AutoOpen>]
module BackdropFilter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/backdrop-filter
    let private stringifyFilter (backdropFilter: IBackdropFilter) =
        match backdropFilter with
        | :? FssTypes.Filter.Filter as f -> Filter.stringifyFilter f
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown backdrop filter"

    let private backdropFilterValue value = PropertyValue.cssValue Property.BackdropFilter value
    let private backdropFilterValue' value =
        value
        |> stringifyFilter
        |> backdropFilterValue

    type BackdropFilter =
        static member Url url = Filter.Url url
        static member Blur blur = Filter.Blur blur
        static member Brightness brightness = Filter.Brightness brightness
        static member Contrast contrast = Filter.Contrast contrast
        static member DropShadow x y blur color invert = Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = Filter.Grayscale grayScale
        static member HueRotate hueRotate = Filter.HueRotate hueRotate
        static member Invert invert = Filter.Invert invert
        static member Opacity opacity = Filter.Opacity opacity
        static member Saturate saturate = Filter.Saturate saturate
        static member Sepia sepia = Filter.Sepia sepia

        static member None = None' |> backdropFilterValue'
        static member Inherit = Inherit |> backdropFilterValue'
        static member Initial = Initial |> backdropFilterValue'
        static member Unset = Unset |> backdropFilterValue'

    /// Supply a list of filters to be applied to the element.
    let BackdropFilters (backdropFilters: FssTypes.Filter.Filter list): CssProperty =
        backdropFilters
        |> Utilities.Helpers.combineWs Filter.stringifyFilter
        |> backdropFilterValue