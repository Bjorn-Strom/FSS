namespace Fss

open Fable.Core.JsInterop

open FssTypes
open Utilities.Helpers

module Media =
    let private deviceLabel (d: Device): string =
        match d with
            | Not n -> sprintf "not %s" (duToLowercase n)
            | Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: Pointer): string = duToLowercase p
    let private colorGamut (c: ColorGamut): string = duToLowercase c
    let private displayMode (dm: DisplayMode): string = duToLowercase  dm
    let private lightLevel (ll: LightLevel): string = duToLowercase ll
    let private orientation (o: Orientation): string = duToLowercase o
    let private overflowBlock (ob: OverflowBlock): string = duToKebab ob
    let private colorScheme (cs: ColorScheme): string = duToLowercase cs
    let private contrast (c: Contrast): string = duToKebab c
    let private scan (s: Scan): string = duToLowercase s
    let private scripting (s: Scripting): string = duToKebab s
    let private update (u: Update): string = duToLowercase u
    let mediaFeature (features: MediaFeature list): string =
        let stringifyMedia (v: MediaFeature): string =
            match v with
                | AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | MediaFeature.Color                        ->
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
                | Height                     h -> sprintf "(height: %s)" <| Types.sizeToString h
                | MinHeight                  s -> sprintf "(min-height: %s)" <| Types.sizeToString s
                | MaxHeight                  s -> sprintf "(max-height: %s)" <| Types.sizeToString s
                | Width                      s -> sprintf "(width: %s)" <| Types.sizeToString s
                | MinWidth                   s -> sprintf "(min-width: %s)" <| Types.sizeToString s
                | MaxWidth                   s -> sprintf "(max-width: %s)" <| Types.sizeToString s
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
        static member Media (features: MediaFeature list, attributeList: CssProperty list) =
            mediaFeature features |> sprintf "@media %s" ==> attributeList |> CssProperty
        static member Media (device: Device, features: MediaFeature list, attributeList: CssProperty list) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> attributeList |> CssProperty
