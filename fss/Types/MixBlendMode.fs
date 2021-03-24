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
            interface IMixBlendMode

