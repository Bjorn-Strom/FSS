namespace Fss

open Units.Size
open Units.Resolution
open Utilities.Helpers

module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All

    let deviceLabel (d: Device): string = duToLowercase d

    type Pointer =
        | Course
        | Fine
        | None

    let pointerValue (p: Pointer): string = duToLowercase p

    type ColorGamut =
        | SRGB
        | P3
        | REC2020

    let colorGamutValue (c: ColorGamut): string = duToLowercase c

    type DisplayMode =
        | Fullscreen
        | Standalone 
        | MinimalUi
        | Browser
    
    let displayModeValue (dm: DisplayMode): string = duToKebab dm

    type LightLevel =
        | Dim
        | Normal
        | Washed

    let lightLevelValue (ll: LightLevel): string = duToLowercase ll

    type Orientation =
        | Landscape
        | Portrait

    let orientationValue (o: Orientation): string = duToLowercase o

    type OverflowBlock =
        | None
        | Scrolled
        | OptionalPaged
        | Paged

    let overflowBlockValue (ob: OverflowBlock): string = duToKebab ob

    type ColorScheme =
        | Light
        | Dark

    let colorSchemeValue (cs: ColorScheme): string = duToLowercase cs

    type Contrast =
        | NoPreference
        | High
        | Low

    let contrastValue (c: Contrast): string = duToKebab c

    type Scan =
        | Interlace
        | Progressive
    
    let scanValue (s: Scan): string = duToLowercase s

    type Scripting =
        | None
        | InitialOnly
        | Enabled

    let scriptingValue (s: Scripting): string = duToKebab s

    type Update =
        | None
        | Slow
        | Fast

    let updateValue (u: Update): string = duToLowercase u

    type MediaFeature =
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

    let private mediaFeatureValue (v: MediaFeature): string =
        match v with
            | MaxWidth s -> sprintf "(max-width: %s)" (Units.Size.value s)
            | MinWidth s -> sprintf "(min-width: %s)" (Units.Size.value s)
            | MaxHeight s -> sprintf "(max-height: %s)" (Units.Size.value s)
            | MinHeight s -> sprintf "(min-height: %s)" (Units.Size.value s)

    let featureLabel (features: MediaFeature list): string =
        features
        |> List.map mediaFeatureValue
        |> String.concat " and "


        