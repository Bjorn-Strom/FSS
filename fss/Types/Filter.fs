namespace FssTypes

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

module Filter =
    let stringifyFilter (filter: Filter) =
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
        |> Fss.Utilities.Helpers.combineWs stringifyFilter

