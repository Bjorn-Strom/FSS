namespace Fss

open Fable.Core.JsInterop
open Utilities.Helpers

module Media =
    let deviceLabel (d: FssTypes.Media.Device): string =
        match d with
            | FssTypes.Media.Not n -> sprintf "not %s" (duToLowercase n)
            | FssTypes.Media.Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: FssTypes.Media.Pointer): string = duToLowercase p
    let private colorGamut (c: FssTypes.Media.ColorGamut): string = duToLowercase c
    let private displayMode (dm: FssTypes.Media.DisplayMode): string = duToLowercase  dm
    let private lightLevel (ll: FssTypes.Media.LightLevel): string = duToLowercase ll
    let private orientation (o: FssTypes.Media.Orientation): string = duToLowercase o
    let private overflowBlock (ob: FssTypes.Media.OverflowBlock): string = duToKebab ob
    let private colorScheme (cs: FssTypes.Media.ColorScheme): string = duToLowercase cs
    let private contrast (c: FssTypes.Media.Contrast): string = duToKebab c
    let private scan (s: FssTypes.Media.Scan): string = duToLowercase s
    let private scripting (s: FssTypes.Media.Scripting): string = duToKebab s
    let private update (u: FssTypes.Media.Update): string = duToLowercase u
    let mediaFeature (features: FssTypes.Media.Feature list): string =
        let stringifyMedia (v: FssTypes.Media.Feature): string =
            match v with
                | FssTypes.Media.AnyHover                   h -> sprintf "(any-hover: %s)" <| if h then "hover" else "none"
                | FssTypes.Media.AnyPointer                 p -> sprintf "(any-pointer: %s)" <| pointer p
                | FssTypes.Media.AspectRatio                r -> sprintf "(aspect-ratio: %d)" r
                | FssTypes.Media.MinAspectRatio             r -> sprintf "(min-aspect-ratio: %d)" r
                | FssTypes.Media.MaxAspectRatio             r -> sprintf "(max-aspect-ratio: %d)" r
                | FssTypes.Media.Feature.Color                ->
                    if List.length features >= 1 then
                        sprintf "and (color)"
                    else
                        sprintf "(color)"
                | FssTypes.Media.MinColor                   c -> sprintf "(min-color: %d)" c
                | FssTypes.Media.MaxColor                   c -> sprintf "(max-color: %d)" c
                | FssTypes.Media.ColorGamut                 c -> sprintf "(color-gamut: %s)" <| colorGamut c
                | FssTypes.Media.ColorIndex                 c -> sprintf "(color-index: %d)" c
                | FssTypes.Media.MinColorIndex              c -> sprintf "(min-color-index: %d)" c
                | FssTypes.Media.MaxColorIndex              c -> sprintf "(max-color-index: %d)" c
                | FssTypes.Media.DisplayMode                d -> sprintf "(display-mode: %s)" <| displayMode d
                | FssTypes.Media.ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | FssTypes.Media.Grid                       g -> sprintf "(grid: %s)" <| if g then "1" else "0"
                | FssTypes.Media.Height                     h -> sprintf "(height: %s)" <| FssTypes.unitHelpers.sizeToString h
                | FssTypes.Media.MinHeight                  s -> sprintf "(min-height: %s)" <| FssTypes.unitHelpers.sizeToString s
                | FssTypes.Media.MaxHeight                  s -> sprintf "(max-height: %s)" <| FssTypes.unitHelpers.sizeToString s
                | FssTypes.Media.Width                      s -> sprintf "(width: %s)" <| FssTypes.unitHelpers.sizeToString s
                | FssTypes.Media.MinWidth                   s -> sprintf "(min-width: %s)" <| FssTypes.unitHelpers.sizeToString s
                | FssTypes.Media.MaxWidth                   s -> sprintf "(max-width: %s)" <| FssTypes.unitHelpers.sizeToString s
                | FssTypes.Media.Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | FssTypes.Media.InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | FssTypes.Media.LightLevel                 l -> sprintf "(light-level: %s)" <| lightLevel l
                | FssTypes.Media.Monochrome                 m -> sprintf "(monochrome: %d)" m
                | FssTypes.Media.MinMonochrome              m -> sprintf "(min-monochrome: %d)" m
                | FssTypes.Media.MaxMonochrome              m -> sprintf "(max-monochrome: %d)" m
                | FssTypes.Media.Orientation                o -> sprintf "(orientation: %s)" <| orientation o
                | FssTypes.Media.OverflowBlock              o -> sprintf "(overflow-block: %s)" <| overflowBlock o
                | FssTypes.Media.OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | FssTypes.Media.Pointer                    p -> sprintf "(pointer: %s)" <| pointer p
                | FssTypes.Media.PrefersColorScheme         p -> sprintf "(prefers-color-scheme: %s)" <| colorScheme p
                | FssTypes.Media.PrefersContrast            c -> sprintf "(prefers-contrast: %s)" <| contrast c
                | FssTypes.Media.PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | FssTypes.Media.PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference"
                | FssTypes.Media.Resolution                 r -> sprintf "(resolution: %s)" <| FssTypes.unitHelpers.resolutionToString r
                | FssTypes.Media.MinResolution              r -> sprintf "(min-resolution: %s)" <| FssTypes.unitHelpers.resolutionToString r
                | FssTypes.Media.MaxResolution              r -> sprintf "(max-resolution: %s)" <| FssTypes.unitHelpers.resolutionToString r
                | FssTypes.Media.Scan                       s -> sprintf "(scan: %s)" <| scan s
                | FssTypes.Media.Scripting                  s -> sprintf "(scripting: %s)" <| scripting s
                | FssTypes.Media.Update                     u -> sprintf "(update: %s)" <| update u

        features
        |> List.map stringifyMedia
        |> String.concat " and "

    type Media =
        static member Media (features: FssTypes.Media.Feature list, attributeList) =
            mediaFeature features |> sprintf "@media %s" ==> attributeList |> FssTypes.CssProperty
        static member Media (device: FssTypes.Media.Device, features: FssTypes.Media.Feature list, attributeList) =
            sprintf "@media %s %s" (deviceLabel device) (mediaFeature features)  ==> attributeList |> FssTypes.CssProperty
