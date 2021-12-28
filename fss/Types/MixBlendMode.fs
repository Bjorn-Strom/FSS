namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module MixBlendModeClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
        type MixBlendMode(property) =
            inherit CssRuleWithNormal(property)
            member this.multiply = (property, Multiply) |> Rule
            member this.screen = (property, Screen) |> Rule
            member this.overlay = (property, Overlay) |> Rule
            member this.darken = (property, Darken) |> Rule
            member this.lighten = (property, Lighten) |> Rule
            member this.colorDodge = (property, ColorDodge) |> Rule
            member this.colorBurn = (property, ColorBurn) |> Rule
            member this.hardLight = (property, HardLight) |> Rule
            member this.softLight = (property, SoftLight) |> Rule
            member this.difference = (property, Difference) |> Rule
            member this.exclusion = (property, Exclusion) |> Rule
            member this.hue = (property, Hue) |> Rule
            member this.saturation = (property, Saturation) |> Rule
            member this.color = (property, Color) |> Rule
            member this.luminosity = (property, Luminosity) |> Rule
