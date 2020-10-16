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

module MediaValue =
    open Media

    let deviceLabel (d: Device): string = duToLowercase d

    let pointer (p: Pointer): string = duToLowercase p

    let colorGamut (c: ColorGamut): string = duToLowercase c

    let displayMode (dm: DisplayMode): string = duToKebab dm

    let lightLevel (ll: LightLevel): string = duToLowercase ll

    let orientation (o: Orientation): string = duToLowercase o

    let overflowBlock (ob: OverflowBlock): string = duToKebab ob

    let colorScheme (cs: ColorScheme): string = duToLowercase cs

    let contrast (c: Contrast): string = duToKebab c

    let scan (s: Scan): string = duToLowercase s

    let scripting (s: Scripting): string = duToKebab s

    let update (u: Update): string = duToLowercase u

    let mediaFeature (features: MediaFeature list): string =
        let stringifyMedia (v: MediaFeature): string =
            match v with
                | AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | Color                      c -> sprintf "(color: %d)"  c
                | MinColor                   c -> sprintf "(min-color: %d)" c
                | MaxColor                   c -> sprintf "(max-color: %d)" c
                | ColorGamut                 c -> sprintf "(color-gamut: %s)" <| colorGamut c
                | ColorIndex                 c -> sprintf "(color-index: %d)" c
                | MinColorIndex              c -> sprintf "(min-color-index: %d)" c
                | MaxColorIndex              c -> sprintf "(max-color-index: %d)" c
                | DisplayMode                d -> sprintf "(display-mode: %s)" <| displayMode d
                | ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | Grid                       g -> sprintf "(grid: %s)" <| if g then "1" else "0"
                | Height                     h -> sprintf "(height: %s)" <| Units.Size.value h 
                | MinHeight                  s -> sprintf "(min-height: %s)" <| Units.Size.value s
                | MaxHeight                  s -> sprintf "(max-height: %s)" <| Units.Size.value s
                | Width                      s -> sprintf "(width: %s)" <| Units.Size.value s
                | MinWidth                   s -> sprintf "(min-width: %s)" <| Units.Size.value s
                | MaxWidth                   s -> sprintf "(max-width: %s)" <| Units.Size.value s
                | Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | LightLevel                 l -> sprintf "(light-level: %s)" <| lightLevel l
                | Monochrome                 m -> sprintf "(monochrome: %d)" m 
                | MinMonochrome              m -> sprintf "(min-monochrome: %d)" m 
                | MaxMonochrome              m -> sprintf "(max-monochrome: %d)" m 
                | Orientation                o -> sprintf "(orientation: %s)" <| orientation o
                | OverflowBlock              o -> sprintf "(overflow-block: %s)" <| overflowBlock o
                | OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | Pointer                    p -> sprintf "(pointer: %s)" <| pointer p
                | PrefersColorScheme         p -> sprintf "(prefers-color-scheme: %s)" <| colorScheme p
                | PrefersContrast            c -> sprintf "(prefers-contrast: %s)" <| contrast c
                | PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference" 
                | Resolution                 r -> sprintf "(resolution: %s)" <| Units.Resolution.value r
                | MinResolution              r -> sprintf "(min-resolution: %s)" <| Units.Resolution.value r 
                | MaxResolution              r -> sprintf "(max-resolution: %s)" <| Units.Resolution.value r
                | Scan                       s -> sprintf "(scan: %s)" <| scan s
                | Scripting                  s -> sprintf "(scripting: %s)" <| scripting s
                | Update                     u -> sprintf "(update: %s)" <| update u

        features
        |> List.map stringifyMedia
        |> String.concat " and "
    