namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Filter =
        type Filter =
            | Url of string
            | Blur of int
            | Brightness of Percent
            | Contrast of Percent
            | DropShadow of int * int * int * ColorType * Percent
            | Grayscale of Percent
            | HueRotate of int
            | Invert of Percent
            | Opacity of Percent
            | Saturate of Percent
            | Sepia of Percent
            interface IFilter
            interface IBackdropFilter

    [<AutoOpen>]
    module filterHelpers =
        let stringifyFilter (filter: Filter.Filter) =
            match filter with
                | Filter.Url u -> $"url(\"{u}\")"
                | Filter.Blur b -> $"blur({b}px)"
                | Filter.Brightness b -> $"brightness({percentToString b})"
                | Filter.Contrast c -> $"contrast({percentToString c})"
                | Filter.DropShadow (x, y, b, c, i)  -> $"drop-shadow({x}px {y}px {b}px {colorToString c}) invert({percentToString i})"
                | Filter.Grayscale g -> $"grayscale({percentToString g})"
                | Filter.HueRotate h -> $"hue-rotate({h}deg)"
                | Filter.Invert i -> $"invert({percentToString i})"
                | Filter.Opacity o -> $"opacity({percentToString o})"
                | Filter.Saturate s -> $"saturate({percentToString s})"
                | Filter.Sepia s -> $"sepia({percentToString s})"

        let stringifyFilters filters =
            filters
            |> Fss.Utilities.Helpers.combineWs stringifyFilter

