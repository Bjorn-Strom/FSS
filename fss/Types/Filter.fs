namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Filter =
        | Url of string
        | Blur of int
        | Brightness of Types.Percent
        | Contrast of Types.Percent
        | DropShadow of int * int * int * Types.Color * Types.Percent
        | Grayscale of Types.Percent
        | HueRotate of int
        | Invert of Types.Percent
        | Opacity of Types.Percent
        | Saturate of Types.Percent
        | Sepia of Types.Percent
        interface Types.IFilter
        interface Types.IBackdropFilter

    module Filter =
        let stringifyFilter (filter: Filter) =
            match filter with
                | Url u -> $"url(\"{u}\")"
                | Blur b -> $"blur({b}px)"
                | Brightness b -> $"brightness({Types.percentToString b})"
                | Contrast c -> $"contrast({Types.percentToString c})"
                | DropShadow (x, y, b, c, i)  -> $"drop-shadow({x}px {y}px {b}px {Types.colorToString c}) invert({Types.percentToString i})"
                | Grayscale g -> $"grayscale({Types.percentToString g})"
                | HueRotate h -> $"hue-rotate({h}deg)"
                | Invert i -> $"invert({Types.percentToString i})"
                | Opacity o -> $"opacity({Types.percentToString o})"
                | Saturate s -> $"saturate({Types.percentToString s})"
                | Sepia s -> $"sepia({Types.percentToString s})"

        let stringifyFilters filters =
            filters
            |> Fss.Utilities.Helpers.combineWs stringifyFilter

