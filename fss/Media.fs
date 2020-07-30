namespace Fss

open Fable.Core.JsInterop

open Units.Size
open Units.Resolution
open Utilities.Helpers

module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All

    let deviceLabel (d: Device): string = (duToString d).ToLower()

    type Pointer =
        | Course
        | Fine
        | None

    let pointerValue (p: Pointer): string = (duToString p).ToLower()

    type ColorGamut =
        | SRGB
        | P3
        | REC2020

    let colorGamutValue (c: ColorGamut): string = (duToString c).ToLower()

    type DisplayMode =
        | Fullscreen
        | Standalone 
        | MinimalUi
        | Browser
    
    let displayModeValue (dm: DisplayMode): string = (duToString dm) |> pascalToKebabCase 

    type LightLevel =
        | Dim
        | Normal
        | Washed

    let lightLevelValue (ll: LightLevel): string = (duToString ll).ToLower()

    type Orientation =
        | Landscape
        | Portrait

    let orientationValue (o: Orientation): string = (duToString o).ToLower()

    type OverflowBlock =
        | None
        | Scrolled
        | OptionalPaged
        | Paged

    let overflowBlockValue (ob: OverflowBlock): string = (duToString ob) |> pascalToKebabCase 

    type ColorScheme =
        | Light
        | Dark

    let colorSchemeValue (cs: ColorScheme): string = (duToString cs).ToLower()

    type Contrast =
        | NoPreference
        | High
        | Low

    let contrastValue (c: Contrast): string = (duToString c) |> pascalToKebabCase 

    type Scan =
        | Interlace
        | Progressive
    
    let scanValue (s: Scan): string = (duToString s).ToLower()

    type Scripting =
        | None
        | InitialOnly
        | Enabled

    let scriptingValue (s: Contrast): string = (duToString s) |> pascalToKebabCase 

    type Update =
        | None
        | Slow
        | Fast

    let updateValue (u: Update): string = (duToString u).ToLower()

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


        