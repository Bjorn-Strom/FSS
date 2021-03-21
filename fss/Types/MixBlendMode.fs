namespace Fss

[<RequireQualifiedAccess>]
module Types =
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
        | Color'
        | Luminosity
        interface Types.IMixBlendMode

