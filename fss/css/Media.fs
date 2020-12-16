namespace Fss

open Fable.Core.JsInterop

open Utilities.Helpers

module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All
        | Not of Device
        | Only of Device

    let private deviceLabel (d: Device): string =
        match d with
            | Not  n -> sprintf "not %s" (duToLowercase n)
            | Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    type Pointer =
        | Course
        | Fine
        | None

    let private pointer (p: Pointer): string = duToLowercase p

    type ColorGamut =
        | SRGB
        | P3
        | REC2020

    let private colorGamut (c: ColorGamut): string = duToLowercase c

    type DisplayMode =
        | Fullscreen
        | Standalone
        | MinimalUi
        | Browser

    let private displayMode (dm: DisplayMode): string = duToLowercase  dm

    type LightLevel =
        | Dim
        | Normal
        | Washed

    let private lightLevel (ll: LightLevel): string = duToLowercase ll

    type Orientation =
        | Landscape
        | Portrait

    let private orientation (o: Orientation): string = duToLowercase o

    type OverflowBlock =
        | None
        | Scrolled
        | OptionalPaged
        | Paged

    let private overflowBlock (ob: OverflowBlock): string = duToKebab ob

    type ColorScheme =
        | Light
        | Dark

    let private colorScheme (cs: ColorScheme): string = duToLowercase cs

    type Contrast =
        | NoPreference
        | High
        | Low

    let private contrast (c: Contrast): string = duToKebab c

    type Scan =
        | Interlace
        | Progressive
    let private scan (s: Scan): string = duToLowercase s

    type Scripting =
        | None
        | InitialOnly
        | Enabled

    let private scripting (s: Scripting): string = duToKebab s

    type Update =
        | None
        | Slow
        | Fast
    let private update (u: Update): string = duToLowercase u

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

    let mediaFeature (features: MediaFeature list): string =
        let stringifyMedia (v: MediaFeature): string =
            match v with
                | AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | Color                        ->
                    if List.length features >= 1 then
                        sprintf "and (color)"
                    else
                        sprintf "(color)"
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

    type Media =
        static member Media (features: MediaFeature list, attributeList: CSSProperty list) =
            mediaFeature features |> sprintf "@media %s" ==> (attributeList |> List.map GlobalValue.CSSValue) |> CSSProperty
        static member Media (device: Device, features: MediaFeature list, attributeList: CSSProperty list) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> (attributeList |> List.map GlobalValue.CSSValue) |> CSSProperty
