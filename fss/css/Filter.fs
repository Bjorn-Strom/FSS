namespace Fss

[<AutoOpen>]
module Filter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    let private stringifyFilter (filter: FssTypes.IFilter) =
        match filter with
        | :? FssTypes.Filter.Filter as f -> FssTypes.filterHelpers.stringifyFilter f
        | :? FssTypes.Keywords as g -> FssTypes.masterTypeHelpers.keywordsToString g
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown filter"

    let private filterValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Filter value
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

        static member None = FssTypes.None' |> filterValue'
        static member Inherit = FssTypes.Inherit |> filterValue'
        static member Initial = FssTypes.Initial |> filterValue'
        static member Unset = FssTypes.Unset |> filterValue'

    /// Supply a list of filters to be applied to the element.
    let Filters (filters: FssTypes.Filter.Filter list): FssTypes.CssProperty =
        filters
        |> Utilities.Helpers.combineWs FssTypes.filterHelpers.stringifyFilter
        |> filterValue

[<AutoOpen>]
module BackdropFilter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/backdrop-filter
    let private stringifyFilter (backdropFilter: FssTypes.IBackdropFilter) =
        match backdropFilter with
        | :? FssTypes.Filter.Filter as f -> FssTypes.filterHelpers.stringifyFilter f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown backdrop filter"

    let private backdropFilterValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackdropFilter value
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

        static member None = FssTypes.None' |> backdropFilterValue'
        static member Inherit = FssTypes.Inherit |> backdropFilterValue'
        static member Initial = FssTypes.Initial |> backdropFilterValue'
        static member Unset = FssTypes.Unset |> backdropFilterValue'

    /// Supply a list of filters to be applied to the element.
    let BackdropFilters (backdropFilters: FssTypes.Filter.Filter list): FssTypes.CssProperty =
        backdropFilters
        |> Utilities.Helpers.combineWs FssTypes.filterHelpers.stringifyFilter
        |> backdropFilterValue