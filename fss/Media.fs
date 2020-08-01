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
        | MinAspectRatio of int
        | MaxAspectRatio of int
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
        | Resolution of Resolution
        | MinResolution of Resolution
        | MaxResolution of Resolution
        | Scan of Scan
        | Scripting of Scripting
        | Update of Update

    let private mediaFeatureValue (v: MediaFeature): string =
        match v with
            | AnyHover                   h -> sprintf "any-hover: %s" <| if h then "hover" else "none"
            | AnyPointer                 p -> sprintf "any-pointer: %s" <| pointerValue p
            | AspectRatio                r -> sprintf "aspect-ratio: %d" r
            | MinAspectRatio             r -> sprintf "min-aspect-ratio: %d" r
            | MaxAspectRatio             r -> sprintf "max-aspect-ratio: %d" r
            | Color                      c -> sprintf "color: %d"  c
            | MinColor                   c -> sprintf "min-color: %d" c
            | MaxColor                   c -> sprintf "max-color: %d" c
            | ColorGamut                 c -> sprintf "color-gamut: %s" <| colorGamutValue c
            | ColorIndex                 c -> sprintf "color-index: %d" c
            | MinColorIndex              c -> sprintf "min-color-index: %d" c
            | MaxColorIndex              c -> sprintf "max-color-index: %d" c
            | DisplayMode                d -> sprintf "display-mode: %s" <| displayModeValue d
            | ForcedColors               f -> sprintf "forced-colors: %s" <| if f then "active" else "none"
            | Grid                       g -> sprintf "grid: %s" <| if g then "1" else "0"
            | Height                     h -> sprintf "height: %s" <| Units.Size.value h 
            | MinHeight                  s -> sprintf "(min-height: %s)" <| Units.Size.value s
            | MaxHeight                  s -> sprintf "(max-height: %s)" <| Units.Size.value s
            | Width                      s -> sprintf "width: %s" <| Units.Size.value s
            | MinWidth                   s -> sprintf "(min-width: %s)" <| Units.Size.value s
            | MaxWidth                   s -> sprintf "(max-width: %s)" <| Units.Size.value s
            | Hover                      h -> sprintf "hover %s" <| if h then "hover" else "none"
            | InvertedColors             c -> sprintf "inverted-colors: %s" <| if c then "inverted" else "none"
            | LightLevel                 l -> sprintf "light-level: %s" <| lightLevelValue l
            | Monochrome                 m -> sprintf "monochrome: %d" m 
            | MinMonochrome              m -> sprintf "min-monochrome: %d" m 
            | MaxMonochrome              m -> sprintf "max-monochrome: %d" m 
            | Orientation                o -> sprintf "orientation: %s" <| orientationValue o
            | OverflowBlock              o -> sprintf "overflow-block: %s" <| overflowBlockValue o
            | OverflowInline             o -> sprintf "overflow-inline: %s" <| if o then "scroll" else "none"
            | Pointer                    p -> sprintf "pointer: %s" <| pointerValue p
            | PrefersColorScheme         p -> sprintf "prefers-color-scheme: %s" <| colorSchemeValue p
            | PrefersContrast            c -> sprintf "prefers-contrast: %s" <| contrastValue c
            | PrefersReducedMotion       p -> sprintf "prefers-reduced-motion: %s" <| if p then "reduce" else "no-preference"
            | PrefersReducedTransparency p -> sprintf "prefers-reduced-transparency: %s" <| if p then "reduce" else "no-preference" 
            | Resolution                 r -> sprintf "resolution: %s" <| Units.Resolution.value r
            | MinResolution              r -> sprintf "min-resolution: %s" <| Units.Resolution.value r 
            | MaxResolution              r -> sprintf "max-resolution: %s" <| Units.Resolution.value r
            | Scan                       s -> sprintf "scan: %s" <| scanValue s
            | Scripting                  s -> sprintf "scripting: %s" <| scriptingValue s
            | Update                     u -> sprintf "update: %s" <| updateValue u

    let featureLabel (features: MediaFeature list): string =
        features
        |> List.map mediaFeatureValue
        |> String.concat " and "


        