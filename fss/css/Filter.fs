namespace Fss

[<AutoOpen>]
module Filter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    let private stringifyFilter (filter: Types.IFilter) =
        match filter with
        | :? Types.Filter.Filter as f -> Types.filterHelpers.stringifyFilter f
        | :? Types.Keywords as g -> Types.masterTypeHelpers.keywordsToString g
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown filter"

    let private filterValue value = Types.propertyHelpers.cssValue Types.Property.Filter value
    let private filterValue' value =
        value
        |> stringifyFilter
        |> filterValue

    type Filter =
        static member Url url  = Types.Filter.Url url
        static member Blur blur = Types.Filter.Blur blur
        static member Brightness brightness = Types.Filter.Brightness brightness
        static member Contrast contrast = Types.Filter.Contrast contrast
        static member DropShadow x y blur color invert = Types.Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = Types.Filter.Grayscale grayScale
        static member HueRotate hueRotate = Types.Filter.HueRotate hueRotate
        static member Invert invert = Types.Filter.Invert invert
        static member Opacity opacity = Types.Filter.Opacity opacity
        static member Saturate saturate = Types.Filter.Saturate saturate
        static member Sepia sepia = Types.Filter.Sepia sepia

        static member None = Types.None' |> filterValue'
        static member Inherit = Types.Inherit |> filterValue'
        static member Initial = Types.Initial |> filterValue'
        static member Unset = Types.Unset |> filterValue'

    /// Supply a list of filters to be applied to the element.
    let Filters (filters: Types.Filter.Filter list): Types.CssProperty =
        filters
        |> Utilities.Helpers.combineWs Types.filterHelpers.stringifyFilter
        |> filterValue

[<AutoOpen>]
module BackdropFilter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/backdrop-filter
    let private stringifyFilter (backdropFilter: Types.IBackdropFilter) =
        match backdropFilter with
        | :? Types.Filter.Filter as f -> Types.filterHelpers.stringifyFilter f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown backdrop filter"

    let private backdropFilterValue value = Types.propertyHelpers.cssValue Types.Property.BackdropFilter value
    let private backdropFilterValue' value =
        value
        |> stringifyFilter
        |> backdropFilterValue

    type BackdropFilter =
        static member Url url = Types.Filter.Url url
        static member Blur blur = Types.Filter.Blur blur
        static member Brightness brightness = Types.Filter.Brightness brightness
        static member Contrast contrast = Types.Filter.Contrast contrast
        static member DropShadow x y blur color invert = Types.Filter.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = Types.Filter.Grayscale grayScale
        static member HueRotate hueRotate = Types.Filter.HueRotate hueRotate
        static member Invert invert = Types.Filter.Invert invert
        static member Opacity opacity = Types.Filter.Opacity opacity
        static member Saturate saturate = Types.Filter.Saturate saturate
        static member Sepia sepia = Types.Filter.Sepia sepia

        static member None = Types.None' |> backdropFilterValue'
        static member Inherit = Types.Inherit |> backdropFilterValue'
        static member Initial = Types.Initial |> backdropFilterValue'
        static member Unset = Types.Unset |> backdropFilterValue'

    /// Supply a list of filters to be applied to the element.
    let BackdropFilters (backdropFilters: Types.Filter.Filter list): Types.CssProperty =
        backdropFilters
        |> Utilities.Helpers.combineWs Types.filterHelpers.stringifyFilter
        |> backdropFilterValue