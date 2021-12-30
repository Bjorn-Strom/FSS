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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module MixBlendModeClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    type MixBlendMode(property) =
        inherit CssRuleWithNormal(property)
        member this.multiply = (property, MixBlendMode.Multiply) |> Rule
        member this.screen = (property, MixBlendMode.Screen) |> Rule
        member this.overlay = (property, MixBlendMode.Overlay) |> Rule
        member this.darken = (property, MixBlendMode.Darken) |> Rule
        member this.lighten = (property, MixBlendMode.Lighten) |> Rule
        member this.colorDodge = (property, MixBlendMode.ColorDodge) |> Rule
        member this.colorBurn = (property, MixBlendMode.ColorBurn) |> Rule
        member this.hardLight = (property, MixBlendMode.HardLight) |> Rule
        member this.softLight = (property, MixBlendMode.SoftLight) |> Rule
        member this.difference = (property, MixBlendMode.Difference) |> Rule
        member this.exclusion = (property, MixBlendMode.Exclusion) |> Rule
        member this.hue = (property, MixBlendMode.Hue) |> Rule
        member this.saturation = (property, MixBlendMode.Saturation) |> Rule
        member this.color = (property, MixBlendMode.Color) |> Rule
        member this.luminosity = (property, MixBlendMode.Luminosity) |> Rule
