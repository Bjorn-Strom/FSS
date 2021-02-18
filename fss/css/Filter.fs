namespace Fss

[<RequireQualifiedAccess>]
module FilterType =
    type Filter =
        | Url of string
        | Blur of int
        | Brightness of Units.Percent.Percent
        | Contrast of Units.Percent.Percent
        | DropShadow of int * int * int * CssColor * Units.Percent.Percent
        | Grayscale of Units.Percent.Percent
        | HueRotate of int
        | Invert of Units.Percent.Percent
        | Opacity of Units.Percent.Percent
        | Saturate of Units.Percent.Percent
        | Sepia of Units.Percent.Percent
        interface IFilter
        interface IBackdropFilter

    let stringifyFilter filter =
        match filter with
            | Url u -> $"url(\"{u}\")"
            | Blur b -> $"blur({b}px)"
            | Brightness b -> $"brightness({Units.Percent.value b})"
            | Contrast c -> $"contrast({Units.Percent.value c})"
            | DropShadow (x, y, b, c, i)  -> $"drop-shadow({x}px {y}px {b}px {CssColorValue.color c}) invert({Units.Percent.value i})"
            | Grayscale g -> $"grayscale({Units.Percent.value g})"
            | HueRotate h -> $"hue-rotate({h}deg)"
            | Invert i -> $"invert({Units.Percent.value i})"
            | Opacity o -> $"opacity({Units.Percent.value o})"
            | Saturate s -> $"saturate({Units.Percent.value s})"
            | Sepia s -> $"sepia({Units.Percent.value s})"

    let stringifyFilters filters =
        filters
        |> Utilities.Helpers.combineWs stringifyFilter

[<AutoOpen>]
module Filter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    let private stringifyFilter (filter: IFilter) =
        match filter with
        | :? FilterType.Filter as f -> FilterType.stringifyFilter f
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown filter"

    let private filterValue value = PropertyValue.cssValue Property.Filter value
    let private filterValue' value =
        value
        |> stringifyFilter
        |> filterValue

    type Filter =
        static member Url url  = FilterType.Url url
        static member Blur blur = FilterType.Blur blur
        static member Brightness brightness = FilterType.Brightness brightness
        static member Contrast contrast = FilterType.Contrast contrast
        static member DropShadow x y blur color invert = FilterType.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = FilterType.Grayscale grayScale
        static member HueRotate hueRotate = FilterType.HueRotate hueRotate
        static member Invert invert = FilterType.Invert invert
        static member Opacity opacity = FilterType.Opacity opacity
        static member Saturate saturate = FilterType.Saturate saturate
        static member Sepia sepia = FilterType.Sepia sepia

        static member None = None' |> filterValue'
        static member Inherit = Inherit |> filterValue'
        static member Initial = Initial |> filterValue'
        static member Unset = Unset |> filterValue'

    /// Supply a list of filters to be applied to the element.
    let Filters (filters: FilterType.Filter list): CSSProperty =
        filters
        |> Utilities.Helpers.combineWs FilterType.stringifyFilter
        |> filterValue

[<AutoOpen>]
module BackdropFilter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/backdrop-filter
    let private stringifyFilter (backdropFilter: IBackdropFilter) =
        match backdropFilter with
        | :? FilterType.Filter as f -> FilterType.stringifyFilter f
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown backdrop filter"

    let private backdropFilterValue value = PropertyValue.cssValue Property.BackdropFilter value
    let private backdropFilterValue' value =
        value
        |> stringifyFilter
        |> backdropFilterValue

    type BackdropFilter =
        static member Url url = FilterType.Url url
        static member Blur blur = FilterType.Blur blur
        static member Brightness brightness = FilterType.Brightness brightness
        static member Contrast contrast = FilterType.Contrast contrast
        static member DropShadow x y blur color invert = FilterType.DropShadow(x,y,blur,color, invert)
        static member Grayscale grayScale = FilterType.Grayscale grayScale
        static member HueRotate hueRotate = FilterType.HueRotate hueRotate
        static member Invert invert = FilterType.Invert invert
        static member Opacity opacity = FilterType.Opacity opacity
        static member Saturate saturate = FilterType.Saturate saturate
        static member Sepia sepia = FilterType.Sepia sepia

        static member None = None' |> backdropFilterValue'
        static member Inherit = Inherit |> backdropFilterValue'
        static member Initial = Initial |> backdropFilterValue'
        static member Unset = Unset |> backdropFilterValue'

    /// Supply a list of filters to be applied to the element.
    let BackdropFilters (backdropFilters: FilterType.Filter list): CSSProperty =
        backdropFilters
        |> Utilities.Helpers.combineWs FilterType.stringifyFilter
        |> backdropFilterValue