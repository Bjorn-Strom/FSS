namespace Fss

open Fable.Core.JsInterop

open FssTypes
open Utilities.Helpers

module Media =
    let private deviceLabel (d: Media.Device): string =
        match d with
            | Media.Not  n -> sprintf "not %s" (duToLowercase n)
            | Media.Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: Media.Pointer): string = duToLowercase p
    let private colorGamut (c: Media.ColorGamut): string = duToLowercase c
    let private displayMode (dm: Media.DisplayMode): string = duToLowercase  dm
    let private lightLevel (ll: Media.LightLevel): string = duToLowercase ll
    let private orientation (o: Media.Orientation): string = duToLowercase o
    let private overflowBlock (ob: Media.OverflowBlock): string = duToKebab ob
    let private colorScheme (cs: Media.ColorScheme): string = duToLowercase cs
    let private contrast (c: Media.Contrast): string = duToKebab c
    let private scan (s: Media.Scan): string = duToLowercase s
    let private scripting (s: Media.Scripting): string = duToKebab s
    let private update (u: Media.Update): string = duToLowercase u
    let mediaFeature (features: Media.MediaFeature list): string =
        let stringifyMedia (v: Media.MediaFeature): string =
            match v with
                | Media.AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | Media.AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | Media.AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | Media.MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | Media.MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | Media.Color                        ->
                    if List.length features >= 1 then
                        sprintf "and (color)"
                    else
                        sprintf "(color)"
                | Media.MinColor                   c -> sprintf "(min-color: %d)" c
                | Media.MaxColor                   c -> sprintf "(max-color: %d)" c
                | Media.ColorGamut                 c -> sprintf "(color-gamut: %s)" <| colorGamut c
                | Media.ColorIndex                 c -> sprintf "(color-index: %d)" c
                | Media.MinColorIndex              c -> sprintf "(min-color-index: %d)" c
                | Media.MaxColorIndex              c -> sprintf "(max-color-index: %d)" c
                | Media.DisplayMode                d -> sprintf "(display-mode: %s)" <| displayMode d
                | Media.ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | Media.Grid                       g -> sprintf "(grid: %s)" <| if g then "1" else "0"
                | Media.Height                     h -> sprintf "(height: %s)" <| Units.Size.value h
                | Media.MinHeight                  s -> sprintf "(min-height: %s)" <| Units.Size.value s
                | Media.MaxHeight                  s -> sprintf "(max-height: %s)" <| Units.Size.value s
                | Media.Width                      s -> sprintf "(width: %s)" <| Units.Size.value s
                | Media.MinWidth                   s -> sprintf "(min-width: %s)" <| Units.Size.value s
                | Media.MaxWidth                   s -> sprintf "(max-width: %s)" <| Units.Size.value s
                | Media.Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | Media.InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | Media.LightLevel                 l -> sprintf "(light-level: %s)" <| lightLevel l
                | Media.Monochrome                 m -> sprintf "(monochrome: %d)" m
                | Media.MinMonochrome              m -> sprintf "(min-monochrome: %d)" m
                | Media.MaxMonochrome              m -> sprintf "(max-monochrome: %d)" m
                | Media.Orientation                o -> sprintf "(orientation: %s)" <| orientation o
                | Media.OverflowBlock              o -> sprintf "(overflow-block: %s)" <| overflowBlock o
                | Media.OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | Media.Pointer                    p -> sprintf "(pointer: %s)" <| pointer p
                | Media.PrefersColorScheme         p -> sprintf "(prefers-color-scheme: %s)" <| colorScheme p
                | Media.PrefersContrast            c -> sprintf "(prefers-contrast: %s)" <| contrast c
                | Media.PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | Media.PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference"
                | Media.Resolution                 r -> sprintf "(resolution: %s)" <| Units.Resolution.value r
                | Media.MinResolution              r -> sprintf "(min-resolution: %s)" <| Units.Resolution.value r
                | Media.MaxResolution              r -> sprintf "(max-resolution: %s)" <| Units.Resolution.value r
                | Media.Scan                       s -> sprintf "(scan: %s)" <| scan s
                | Media.Scripting                  s -> sprintf "(scripting: %s)" <| scripting s
                | Media.Update                     u -> sprintf "(update: %s)" <| update u

        features
        |> List.map stringifyMedia
        |> String.concat " and "

    type Media =
        static member Media (features: Media.MediaFeature list, attributeList: CssProperty list) =
            mediaFeature features |> sprintf "@media %s" ==> attributeList |> CssProperty
        static member Media (device: Media.Device, features: Media.MediaFeature list, attributeList: CssProperty list) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> attributeList |> CssProperty
