namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module MixBlendMode =
    type MixBlendMode =
        | Multiply
        | Screen
        | Overlay
        | Darken
        | Lighten
        | ColorDodge
        | ColorBurn
        | HardLight
        | SoftLight
        | Difference
        | Exclusion
        | Hue
        | Saturation
        | Color
        | Luminosity
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

// https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
// FIXME: This and BackgroundBlendMode are quite similar
[<RequireQualifiedAccess>]
module MixBlendModeClasses =
    type MixBlendMode(property) =
        inherit CssRuleWithNormal(property)
        /// The final color is the result of multiplying the top and bottom colors
        member this.multiply = (property, MixBlendMode.Multiply) |> Rule
        /// The final color is the result of inverting the color, multiplying them and inverting that value
        member this.screen = (property, MixBlendMode.Screen) |> Rule
        /// The final color is multiply if the bottom color is darker and screen if it is lighter
        member this.overlay = (property, MixBlendMode.Overlay) |> Rule
        /// The final color is composed of the darkest values from each color channel
        member this.darken = (property, MixBlendMode.Darken) |> Rule
        /// The final color is composed of the lightest values from each color channel
        member this.lighten = (property, MixBlendMode.Lighten) |> Rule
        /// The final color is the result of dividing the bottom color by the inverse of the top color
        member this.colorDodge = (property, MixBlendMode.ColorDodge) |> Rule
        /// The final color is the result of inverting the bottom color dividing the value by teh top color and inverting it
        member this.colorBurn = (property, MixBlendMode.ColorBurn) |> Rule
        /// The final color is the result of multiply if the top color is darker and screen if it is ligher
        member this.hardLight = (property, MixBlendMode.HardLight) |> Rule
        /// Similar to hard light but softer
        member this.softLight = (property, MixBlendMode.SoftLight) |> Rule
        /// The final color is the result of subtracting the darker of the two colors from the lighter one
        member this.difference = (property, MixBlendMode.Difference) |> Rule
        /// Similar to difference but with less contrast
        member this.exclusion = (property, MixBlendMode.Exclusion) |> Rule
        /// The final color has the hue of the top color while using the saturation and luminosity of the bottom color
        member this.hue = (property, MixBlendMode.Hue) |> Rule
        /// The final color has the saturation of the top color, while using the hue and luminosity of the bottom color
        member this.saturation = (property, MixBlendMode.Saturation) |> Rule
        /// The final color has the hue and saturation of the top color, while using the luminosity of the bottom color
        member this.color = (property, MixBlendMode.Color) |> Rule
        /// The final color has the luminosity of the top color while using the hue and saturation of the bottom color
        member this.luminosity = (property, MixBlendMode.Luminosity) |> Rule
