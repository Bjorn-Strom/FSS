namespace Fss

open Fable.Core.JsInterop
open Utilities.Helpers

module Media =
    let private deviceLabel (d: Types.Media.Device): string =
        match d with
            | Types.Media.Not n -> sprintf "not %s" (duToLowercase n)
            | Types.Media.Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: Types.Media.Pointer): string = duToLowercase p
    let private colorGamut (c: Types.Media.ColorGamut): string = duToLowercase c
    let private displayMode (dm: Types.Media.DisplayMode): string = duToLowercase  dm
    let private lightLevel (ll: Types.Media.LightLevel): string = duToLowercase ll
    let private orientation (o: Types.Media.Orientation): string = duToLowercase o
    let private overflowBlock (ob: Types.Media.OverflowBlock): string = duToKebab ob
    let private colorScheme (cs: Types.Media.ColorScheme): string = duToLowercase cs
    let private contrast (c: Types.Media.Contrast): string = duToKebab c
    let private scan (s: Types.Media.Scan): string = duToLowercase s
    let private scripting (s: Types.Media.Scripting): string = duToKebab s
    let private update (u: Types.Media.Update): string = duToLowercase u
    let mediaFeature (features: Types.Media.Feature list): string =
        let stringifyMedia (v: Types.Media.Feature): string =
            match v with
                | Types.Media.AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | Types.Media.AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | Types.Media.AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | Types.Media.MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | Types.Media.MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | Types.Media.Feature.Color                ->
                    if List.length features >= 1 then
                        sprintf "and (color)"
                    else
                        sprintf "(color)"
                | Types.Media.MinColor                   c -> sprintf "(min-color: %d)" c
                | Types.Media.MaxColor                   c -> sprintf "(max-color: %d)" c
                | Types.Media.ColorGamut                 c -> sprintf "(color-gamut: %s)" <| colorGamut c
                | Types.Media.ColorIndex                 c -> sprintf "(color-index: %d)" c
                | Types.Media.MinColorIndex              c -> sprintf "(min-color-index: %d)" c
                | Types.Media.MaxColorIndex              c -> sprintf "(max-color-index: %d)" c
                | Types.Media.DisplayMode                d -> sprintf "(display-mode: %s)" <| displayMode d
                | Types.Media.ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | Types.Media.Grid                       g -> sprintf "(grid: %s)" <| if g then "1" else "0"
                | Types.Media.Height                     h -> sprintf "(height: %s)" <| Types.unitHelpers.sizeToString h
                | Types.Media.MinHeight                  s -> sprintf "(min-height: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Media.MaxHeight                  s -> sprintf "(max-height: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Media.Width                      s -> sprintf "(width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Media.MinWidth                   s -> sprintf "(min-width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Media.MaxWidth                   s -> sprintf "(max-width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Media.Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | Types.Media.InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | Types.Media.LightLevel                 l -> sprintf "(light-level: %s)" <| lightLevel l
                | Types.Media.Monochrome                 m -> sprintf "(monochrome: %d)" m
                | Types.Media.MinMonochrome              m -> sprintf "(min-monochrome: %d)" m
                | Types.Media.MaxMonochrome              m -> sprintf "(max-monochrome: %d)" m
                | Types.Media.Orientation                o -> sprintf "(orientation: %s)" <| orientation o
                | Types.Media.OverflowBlock              o -> sprintf "(overflow-block: %s)" <| overflowBlock o
                | Types.Media.OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | Types.Media.Pointer                    p -> sprintf "(pointer: %s)" <| pointer p
                | Types.Media.PrefersColorScheme         p -> sprintf "(prefers-color-scheme: %s)" <| colorScheme p
                | Types.Media.PrefersContrast            c -> sprintf "(prefers-contrast: %s)" <| contrast c
                | Types.Media.PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | Types.Media.PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference"
                | Types.Media.Resolution                 r -> sprintf "(resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.Media.MinResolution              r -> sprintf "(min-resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.Media.MaxResolution              r -> sprintf "(max-resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.Media.Scan                       s -> sprintf "(scan: %s)" <| scan s
                | Types.Media.Scripting                  s -> sprintf "(scripting: %s)" <| scripting s
                | Types.Media.Update                     u -> sprintf "(update: %s)" <| update u

        features
        |> List.map stringifyMedia
        |> String.concat " and "

    type Media =
        static member Media (features: Types.Media.Feature list, attributeList) =
            mediaFeature features |> sprintf "@media %s" ==> attributeList |> Types.CssProperty
        static member Media (device: Types.Media.Device, features: Types.Media.Feature list, attributeList) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> attributeList |> Types.CssProperty
