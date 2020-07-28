namespace Fss
open Fss.Units.Size
open Fss.Units.Resolution

module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All

    let private deviceValue (d: Device): string =
        match d with
            | Screen -> "screen"
            | Speech -> "speech"
            | Print -> "print"
            | All -> "all"

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

    type MediaFeatures =
        | AnyHover of bool
        | AnyPointer of Pointer
        | AspectRatio of int
        | Color of int
        | MinColor of int
        | MaxColor of int
        | ColorGamut of ColorGamut
        | ColorIndex of int
        | MinColorIndex of int
        | MaxColorIndex of int
        | DisplayMode of DisplayMode
        | ForcedColors of bool
        | Grid of bool
        | Height of Size
        | MinHeight of Size
        | MaxHeight of Size
        | Width of Size
        | MinWidth of Size
        | MaxWidth of Size
        | Hover of bool
        | InvertedColors of bool
        | LightLevel of LightLevel
        | Monochrome of int
        | Orientation of Orientation
        | OverflowBlock of OverflowBlock
        | OverflowInline of bool
        | Pointer of Pointer
        | PrefersColorScheme of ColorScheme
        | PrefersContrast of Contrast
        | PrefersReducedMotion of bool
        | PrefersReducedTransparency of bool
        | Resolution of Resolution
        | MinResolution of Resolution
        | MaxResolution of Resolution
        | Scan of Scan
        | Scripting of Scripting
        | Update of Update
