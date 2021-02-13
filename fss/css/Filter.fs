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
        | :? None -> GlobalValue.none
        | _ -> "Unknown filter"

    let private filterValue value = PropertyValue.cssValue Property.Filter value
    let private filterValue' value =
        value
        |> stringifyFilter
        |> filterValue

    type Filter =
        static member Value (filter: IFilter) = filter |> filterValue'
        static member Values (filters: FilterType.Filter list) =
            filters |> FilterType.stringifyFilters |> filterValue
        static member Url url  = FilterType.Url url |> filterValue'
        static member Blur blur = FilterType.Blur blur |> filterValue'
        static member Brightness brightness = FilterType.Brightness brightness |> filterValue'
        static member Contrast contrast = FilterType.Contrast contrast |> filterValue'
        static member DropShadow x y blur color invert = FilterType.DropShadow(x,y,blur,color, invert) |> filterValue'
        static member Grayscale grayScale = FilterType.Grayscale grayScale |> filterValue'
        static member HueRotate hueRotate = FilterType.HueRotate hueRotate |> filterValue'
        static member Invert invert = FilterType.Invert invert |> filterValue'
        static member Opacity opacity = FilterType.Opacity opacity |> filterValue'
        static member Saturate saturate = FilterType.Saturate saturate |> filterValue'
        static member Sepia sepia = FilterType.Sepia sepia |> filterValue'

        static member None = None |> filterValue'
        static member Inherit = Inherit |> filterValue'
        static member Initial = Initial |> filterValue'
        static member Unset = Unset |> filterValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private Filter' (all: IFilter) = all |> Filter.Value
