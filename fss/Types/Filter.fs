namespace Fss

namespace Fss.Types
    type Filter =
        | Url of string
        | Blur of int
        | Brightness of Percent
        | Contrast of Percent
        | DropShadow of int * int * int * Color * Percent
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
        let stringifyFilter (filter: Filter) =
            match filter with
                | Url u -> $"url(\"{u}\")"
                | Blur b -> $"blur({b}px)"
                | Brightness b -> $"brightness({percentToString b})"
                | Contrast c -> $"contrast({percentToString c})"
                | DropShadow (x, y, b, c, i)  -> $"drop-shadow({x}px {y}px {b}px {colorToString c}) invert({percentToString i})"
                | Grayscale g -> $"grayscale({percentToString g})"
                | HueRotate h -> $"hue-rotate({h}deg)"
                | Invert i -> $"invert({percentToString i})"
                | Opacity o -> $"opacity({percentToString o})"
                | Saturate s -> $"saturate({percentToString s})"
                | Sepia s -> $"sepia({percentToString s})"

        let stringifyFilters filters =
            filters
            |> Fss.Utilities.Helpers.combineWs stringifyFilter

