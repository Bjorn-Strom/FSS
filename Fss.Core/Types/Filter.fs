namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Filter =
    type Filter =
        | Blur of Length
        | Brightness of Percent
        | Contrast of Percent
        | DropShadow of Length * Length * Length * Color
        | DropShadowInvert of Length * Length * Length * Color * Percent
        | Grayscale of Percent
        | HueRotate of Angle
        | Invert of Percent
        | Opacity of Percent
        | Saturate of Percent
        | Sepia of Percent
        | Filters of Filter list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Blur blur -> $"blur({lengthPercentageString blur})"
                | Brightness brightness -> $"brightness({lengthPercentageString brightness})"
                | Contrast contrast -> $"contrast({lengthPercentageString contrast})"
                | DropShadow (x, y, blur, color) ->
                    $"drop-shadow({lengthPercentageString x} {lengthPercentageString y} {lengthPercentageString blur} {stringifyICssValue color})"
                | DropShadowInvert (x, y, blur, color, invert) ->
                    $"drop-shadow({lengthPercentageString x} {lengthPercentageString y} {lengthPercentageString blur} {stringifyICssValue color}) invert({lengthPercentageString invert})"
                | Grayscale grayscale -> $"grayscale({lengthPercentageString grayscale})"
                | HueRotate contrast -> $"hue-rotate({stringifyICssValue contrast})"
                | Invert invert -> $"invert({lengthPercentageString invert})"
                | Opacity opacity -> $"opacity({lengthPercentageString opacity})"
                | Saturate saturate -> $"saturate({lengthPercentageString saturate})"
                | Sepia sepia -> $"sepia({lengthPercentageString sepia})"
                | Filters filters ->
                    filters
                    |> List.map stringifyICssValue
                    |> String.concat " "

[<RequireQualifiedAccess>]
module FilterClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/filter
    type FilterClass(property) =
        inherit CssRuleWithNone(property)
        member this.value(filters: Filter.Filter list) = (property, Filter.Filters filters) |> Rule
        /// URI pointing to a filter
        member this.url(url: string) = (property, UrlMaster url) |> Rule
        /// Applies Gaussian blur to the input image
        member this.blur(blur: Length) = (property, Filter.Blur blur) |> Rule
        /// Applies a linear multiplier to the input image
        member this.brightness(brightness: Percent) = (property, Filter.Brightness brightness) |> Rule
        /// Adjusts the contrast of the input image
        member this.contrast(contrast: Percent) = (property, Filter.Contrast contrast) |> Rule
        /// Applies a drop shadow effect to the input image
        member this.dropShadow(x: Length, y: Length, blur: Length, color: Color) = (property, Filter.DropShadow(x, y, blur, color)) |> Rule
        /// Applies a drop shadow effect to the input image
        member this.dropShadow(x: Length, y: Length, blur: Length, color: Color, invert: Percent) = (property, Filter.DropShadowInvert(x, y, blur, color, invert)) |> Rule
        /// Converts the image to grayscale
        member this.grayscale(grayscale: Percent) = (property, Filter.Grayscale grayscale) |> Rule
        /// Applies hue rotation to input image
        member this.hueRotate(hueRotate: Angle) = (property, Filter.HueRotate hueRotate) |> Rule
        /// Inverts the samples of the input image
        member this.invert(invert: Percent) = (property, Filter.Invert invert) |> Rule
        /// Applies transparency to the samples in the input image
        member this.opacity(opacity: Percent) = (property, Filter.Opacity opacity) |> Rule
        /// Saturates the input image
        member this.saturate(saturate: Percent) = (property, Filter.Saturate saturate) |> Rule
        /// Converts the input image to sepia
        member this.sepia(sepia: Percent) = (property, Filter.Sepia sepia) |> Rule