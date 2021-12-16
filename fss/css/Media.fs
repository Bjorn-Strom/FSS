namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Media =
    let Media = Media.MediaClasses.Media()
    (*
    let deviceLabel (d: FssTypes.Media.Device): string =
        match d with
            | FssTypes.Media.Not n -> sprintf "not %s" (duToLowercase n)
            | FssTypes.Media.Only o -> sprintf "only %s" (duToLowercase o)
            | _  -> duToLowercase d

    let private pointer (p: FssTypes.Media.Pointer): string = duToLowercase p
    let private colorGamut (c: FssTypes.Media.ColorGamut): string = duToLowercase c
    let private displayMode (dm: FssTypes.Media.DisplayMode): string = duToLowercase dm
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
                | FssTypes.Media.AnyPointer                 p -> $"(any-pointer: {pointer p})"
                | FssTypes.Media.AspectRatio                r -> $"(aspect-ratio: {r})"
                | FssTypes.Media.MinAspectRatio             r -> $"(min-aspect-ratio: {r})"
                | FssTypes.Media.MaxAspectRatio             r -> $"(max-aspect-ratio: {r})"
                | FssTypes.Media.Feature.Color                -> $"(color)"
                | FssTypes.Media.MinColor                   c -> $"(min-color: {c})"
                | FssTypes.Media.MaxColor                   c -> $"(max-color: {c})"
                | FssTypes.Media.ColorGamut                 c -> $"(color-gamut: {colorGamut c})"
                | FssTypes.Media.ColorIndex                 c -> $"(color-index: {c})"
                | FssTypes.Media.MinColorIndex              c -> $"(min-color-index: {c})"
                | FssTypes.Media.MaxColorIndex              c -> $"(max-color-index: {c})"
                | FssTypes.Media.DisplayMode                d -> $"(display-mode: {displayMode d})"
                | FssTypes.Media.ForcedColors               f -> sprintf "(forced-colors: %s)" <| if f then "active" else "none"
                | FssTypes.Media.Grid                       g -> $"(grid: {if g then 1 else 0})"
                | FssTypes.Media.Height                     h -> $"(height: {FssTypes.unitHelpers.sizeToString h})"
                | FssTypes.Media.MinHeight                  s -> $"(min-height: {FssTypes.unitHelpers.sizeToString s})"
                | FssTypes.Media.MaxHeight                  s -> $"(max-height: {FssTypes.unitHelpers.sizeToString s})"
                | FssTypes.Media.Width                      s -> $"(width: {FssTypes.unitHelpers.sizeToString s})"
                | FssTypes.Media.MinWidth                   s -> $"(min-width: {FssTypes.unitHelpers.sizeToString s})"
                | FssTypes.Media.MaxWidth                   s -> $"(max-width: {FssTypes.unitHelpers.sizeToString s})"
                | FssTypes.Media.Hover                      h -> sprintf "(hover %s)" <| if h then "hover" else "none"
                | FssTypes.Media.InvertedColors             c -> sprintf "(inverted-colors: %s)" <| if c then "inverted" else "none"
                | FssTypes.Media.LightLevel                 l -> $"(light-level: {lightLevel l})"
                | FssTypes.Media.Monochrome                 m -> $"(monochrome: {m})"
                | FssTypes.Media.MinMonochrome              m -> $"(min-monochrome: {m})"
                | FssTypes.Media.MaxMonochrome              m -> $"(max-monochrome: {m})"
                | FssTypes.Media.Orientation                o -> $"(orientation: {orientation o})"
                | FssTypes.Media.OverflowBlock              o -> $"(overflow-block: {overflowBlock o})"
                | FssTypes.Media.OverflowInline             o -> sprintf "(overflow-inline: %s)" <| if o then "scroll" else "none"
                | FssTypes.Media.Pointer                    p -> $"(pointer: {pointer p})"
                | FssTypes.Media.PrefersColorScheme         p -> $"(prefers-color-scheme: {colorScheme p})"
                | FssTypes.Media.PrefersContrast            c -> $"(prefers-contrast: {contrast c})"
                | FssTypes.Media.PrefersReducedMotion       p -> sprintf "(prefers-reduced-motion: %s)" <| if p then "reduce" else "no-preference"
                | FssTypes.Media.PrefersReducedTransparency p -> sprintf "(prefers-reduced-transparency: %s)" <| if p then "reduce" else "no-preference"
                | FssTypes.Media.Resolution                 r -> $"(resolution: {FssTypes.unitHelpers.resolutionToString r})"
                | FssTypes.Media.MinResolution              r -> $"(min-resolution: {FssTypes.unitHelpers.resolutionToString r})"
                | FssTypes.Media.MaxResolution              r -> $"(max-resolution: {FssTypes.unitHelpers.resolutionToString r})"
                | FssTypes.Media.Scan                       s -> $"(scan: {scan s})"
                | FssTypes.Media.Scripting                  s -> $"(scripting: {scripting s})"
                | FssTypes.Media.Update                     u -> $"(update: {update u})"

        features
        |> List.map stringifyMedia
        |> String.concat " and "

    
    type Media =
        static member Media (features: FssTypes.Media.Feature list, attributeList) =
             //$"@media {mediaFeature features}" ==> attributeList |> FssTypes.CssProperty
            features :> obj
        static member Media (device: FssTypes.Media.Device, features: FssTypes.Media.Feature list, attributeList) =
            let ``and`` = if List.isEmpty features then "" else "and"
            //$"@media {deviceLabel device} {``and``} {mediaFeature features}" ==> attributeList |> FssTypes.CssProperty
            device :> obj
    *)
