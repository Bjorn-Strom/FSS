namespace Fss

open Fable.Core.JsInterop
open Utilities.Helpers

module Media =
    let private deviceLabel (d: Types.Device): string =
        match d with
            | Types.Not n -> sprintf "not %s" (duToLowercase n)
            | Types.Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: Types.Pointer): string = duToLowercase p
    let private colorGamut (c: Types.ColorGamut): string = duToLowercase c
    let private displayMode (dm: Types.DisplayMode): string = duToLowercase  dm
    let private lightLevel (ll: Types.LightLevel): string = duToLowercase ll
    let private orientation (o: Types.Orientation): string = duToLowercase o
    let private overflowBlock (ob: Types.OverflowBlock): string = duToKebab ob
    let private colorScheme (cs: Types.ColorScheme): string = duToLowercase cs
    let private contrast (c: Types.Contrast): string = duToKebab c
    let private scan (s: Types.Scan): string = duToLowercase s
    let private scripting (s: Types.Scripting): string = duToKebab s
    let private update (u: Types.Update): string = duToLowercase u
    let mediaFeature (features: Types.MediaFeature list): string =
        let stringifyMedia (v: Types.MediaFeature): string =
            match v with
                | Types.AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | Types.AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | Types.AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | Types.MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | Types.MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | Types.MediaFeature.Color'                        ->
                    if List.length features >= 1 then
                        sprintf "and (color)"
                    else
                        sprintf "(color)"
                | Types.MinColor                   c -> sprintf "(min-color: %d)" c
                | Types.MaxColor                   c -> sprintf "(max-color: %d)" c
                | Types.ColorGamut                 c -> sprintf "(color-gamut: %s)" <| colorGamut c
                | Types.ColorIndex                 c -> sprintf "(color-index: %d)" c
                | Types.MinColorIndex              c -> sprintf "(min-color-index: %d)" c
                | Types.MaxColorIndex              c -> sprintf "(max-color-index: %d)" c
                | Types.DisplayMode                d -> sprintf "(display-mode: %s)" <| displayMode d
                | Types.ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | Types.MediaFeature.Grid          g -> sprintf "(grid: %s)" <| if g then "1" else "0"
                | Types.Height                     h -> sprintf "(height: %s)" <| Types.unitHelpers.sizeToString h
                | Types.MinHeight                  s -> sprintf "(min-height: %s)" <| Types.unitHelpers.sizeToString s
                | Types.MaxHeight                  s -> sprintf "(max-height: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Width                      s -> sprintf "(width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.MinWidth                   s -> sprintf "(min-width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.MaxWidth                   s -> sprintf "(max-width: %s)" <| Types.unitHelpers.sizeToString s
                | Types.Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | Types.InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | Types.LightLevel                 l -> sprintf "(light-level: %s)" <| lightLevel l
                | Types.Monochrome                 m -> sprintf "(monochrome: %d)" m
                | Types.MinMonochrome              m -> sprintf "(min-monochrome: %d)" m
                | Types.MaxMonochrome              m -> sprintf "(max-monochrome: %d)" m
                | Types.Orientation                o -> sprintf "(orientation: %s)" <| orientation o
                | Types.OverflowBlock              o -> sprintf "(overflow-block: %s)" <| overflowBlock o
                | Types.OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | Types.MediaFeature.Pointer       p -> sprintf "(pointer: %s)" <| pointer p
                | Types.PrefersColorScheme         p -> sprintf "(prefers-color-scheme: %s)" <| colorScheme p
                | Types.PrefersContrast            c -> sprintf "(prefers-contrast: %s)" <| contrast c
                | Types.PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | Types.PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference"
                | Types.Resolution                 r -> sprintf "(resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.MinResolution              r -> sprintf "(min-resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.MaxResolution              r -> sprintf "(max-resolution: %s)" <| Types.unitHelpers.resolutionToString r
                | Types.Scan                       s -> sprintf "(scan: %s)" <| scan s
                | Types.Scripting                  s -> sprintf "(scripting: %s)" <| scripting s
                | Types.Update                     u -> sprintf "(update: %s)" <| update u

        features
        |> List.map stringifyMedia
        |> String.concat " and "

    type Media =
        static member Media (features: Types.MediaFeature list, attributeList: Types.CssProperty list) =
            mediaFeature features |> sprintf "@media %s" ==> attributeList |> Types.CssProperty
        static member Media (device: Types.Device, features: Types.MediaFeature list, attributeList: Types.CssProperty list) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> attributeList |> Types.CssProperty
