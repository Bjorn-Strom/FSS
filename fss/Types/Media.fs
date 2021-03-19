namespace FssTypes

[<RequireQualifiedAccess>]
module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All
        | Not of Device
        | Only of Device

    type Pointer =
        | Course
        | Fine
        | None

    type ColorGamut =
        | SRGB
        | P3
        | REC2020

    type DisplayMode =
        | Fullscreen
        | Standalone
        | MinimalUi
        | Browser

    type LightLevel =
        | Dim
        | Normal
        | Washed

    type Orientation =
        | Landscape
        | Portrait

    type OverflowBlock =
        | None
        | Scrolled
        | OptionalPaged
        | Paged

    type ColorScheme =
        | Light
        | Dark

    type Contrast =
        | NoPreference
        | High
        | Low

    type Scan =
        | Interlace
        | Progressive

    type Scripting =
        | None
        | InitialOnly
        | Enabled

    type Update =
        | None
        | Slow
        | Fast

    type MediaFeature =
        | AnyHover of bool
        | AnyPointer of Pointer
        | AspectRatio of int
        | MinAspectRatio of int
        | MaxAspectRatio of int
        | Color
        | MinColor of int
        | MaxColor of int
        | ColorGamut of ColorGamut
        | ColorIndex of int
        | MinColorIndex of int
        | MaxColorIndex of int
        | DisplayMode of DisplayMode
        | ForcedColors of bool
        | Grid of bool
        | Height of Units.Size.Size
        | MinHeight of Units.Size.Size
        | MaxHeight of Units.Size.Size
        | Width of Units.Size.Size
        | MinWidth of Units.Size.Size
        | MaxWidth of Units.Size.Size
        | Hover of bool
        | InvertedColors of bool
        | LightLevel of LightLevel
        | Monochrome of int
        | MinMonochrome of int
        | MaxMonochrome of int
        | Orientation of Orientation
        | OverflowBlock of OverflowBlock
        | OverflowInline of bool
        | Pointer of Pointer
        | PrefersColorScheme of ColorScheme
        | PrefersContrast of Contrast
        | PrefersReducedMotion of bool
        | PrefersReducedTransparency of bool
        | Resolution of Units.Resolution.Resolution
        | MinResolution of Units.Resolution.Resolution
        | MaxResolution of Units.Resolution.Resolution
        | Scan of Scan
        | Scripting of Scripting
        | Update of Update

