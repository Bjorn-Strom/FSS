namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All
        | Not of Device
        | Only of Device
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Screen -> "screen"
                | Speech -> "speech"
                | Print -> "print"
                | All -> "all"
                | Not d -> $"not {stringifyICssValue d}"
                | Only  d -> $"only {stringifyICssValue d}"

    type Pointer =
        | Course
        | Fine
        | None
        member this.Stringify() =
            match this with
            | Course -> "course"
            | Fine -> "fine"
            | None -> "none"

    type ColorGamut =
        | SRGB
        | P3
        | REC2020
        member this.Stringify() =
            match this with
            | SRGB -> "srgb"
            | P3 -> "p3"
            | REC2020 -> "rec2020"

    type DisplayMode =
        | Fullscreen
        | Standalone
        | MinimalUi
        | Browser
        member this.Stringify() =
            match this with
            | Fullscreen -> "fullscreen"
            | Standalone -> "standalone"
            | MinimalUi -> "minimal-ui"
            | Browser -> "browser"

    type LightLevel =
        | Dim
        | Washed
        member this.Stringify() =
            match this with
            | Dim -> "dim"
            | Washed -> "washed"

    type Orientation =
        | Landscape
        | Portrait
        member this.Stringify() =
            match this with
            | Landscape -> "landscape"
            | Portrait -> "portrait"

    type OverflowBlock =
        | None
        | Scrolled
        | OptionalPaged
        | Paged
        member this.Stringify() =
            match this with
            | None -> "none"
            | Scrolled -> "scrolled"
            | OptionalPaged -> "optional-paged"
            | Paged -> "paged"

    type ColorScheme =
        | Light
        | Dark
        member this.Stringify() =
            match this with
            | Light -> "light"
            | Dark -> "dark"

    type Contrast =
        | NoPreference
        | High
        | Low
        member this.Stringify() =
            match this with
            | NoPreference -> "no-preference"
            | High -> "high"
            | Low -> "low"

    type Scan =
        | Interlace
        | Progressive
        member this.Stringify() =
            match this with
            | Interlace -> "interlace"
            | Progressive -> "progressive"

    type Scripting =
        | None
        | InitialOnly
        | Enabled
        member this.Stringify() =
            match this with
            | None -> "none"
            | InitialOnly -> "initial-only"
            | Enabled -> "enabled"

    type Update =
        | None
        | Slow
        | Fast
        member this.Stringify() =
            match this with
            | None -> "none"
            | Slow -> "slow"
            | Fast -> "fast"

    type Feature =
        | AnyHover of bool
        | AnyPointer of Pointer
        | AspectRatio of int * int
        | MinAspectRatio of int * int
        | MaxAspectRatio of int * int
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
        | Height of Length
        | MinHeight of Length
        | MaxHeight of Length
        | Width of Length
        | MinWidth of Length
        | MaxWidth of Length
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
        override this.ToString() =
            match this with
            | AnyHover bool -> $"any-hover:{bool}"
            | AnyPointer pointer -> $"any-pointer:{pointer.Stringify()}"
            | AspectRatio (x, y) -> $"aspect-ratio:{x}/{y}"
            | MinAspectRatio (x, y) -> $"min-aspect-ratio:{x}/{y}"
            | MaxAspectRatio (x, y) -> $"max-aspect-ratio:{x}/{y}"
            | Color -> "color"
            | MinColor int -> $"min-color:{int}"
            | MaxColor int -> $"max-color:{int}"
            | ColorGamut colorGamut -> $"color-gamut:{colorGamut.Stringify()}"
            | ColorIndex int -> $"color-index:{int}"
            | MinColorIndex int -> $"min-color-index:{int}"
            | MaxColorIndex int -> $"max-color-index:{int}"
            | DisplayMode displayMode -> $"display-mode:{displayMode}"
            | ForcedColors bool -> $"forced-colors:{bool}"
            | Grid bool -> $"grid:{bool.ToString().ToLower()}"
            | Height length -> $"height:{lengthPercentageString length}"
            | MinHeight length -> $"min-height:{lengthPercentageString length}"
            | MaxHeight length -> $"max-height:{lengthPercentageString length}"
            | Width length -> $"width:{lengthPercentageString length}"
            | MinWidth length -> $"min-width:{lengthPercentageString length}"
            | MaxWidth length -> $"max-width:{lengthPercentageString length}"
            | Hover bool -> $"hover:{bool}"
            | InvertedColors bool -> $"inverted-colors:{bool}"
            | LightLevel lightLevel -> $"light-level:{lightLevel.Stringify()}"
            | Monochrome int -> $"monochrome:{int}"
            | MinMonochrome int -> $"min-monochrome:{int}"
            | MaxMonochrome int -> $"max-monochrome:{int}"
            | Orientation orientation -> $"orientation:{orientation.Stringify()}"
            | OverflowBlock overflowBlock -> $"overflow-block:{overflowBlock.Stringify()}"
            | OverflowInline bool -> $"overflow-inline:{bool}"
            | Pointer pointer -> $"pointer:{pointer.Stringify()}"
            | PrefersColorScheme colorScheme -> $"preferred-color-scheme:{colorScheme.Stringify()}"
            | PrefersContrast contrast -> $"contrast:{contrast.Stringify}"
            | PrefersReducedMotion bool -> $"prefers-reduced-motion:{bool}"
            | PrefersReducedTransparency bool -> $"prefers-reduced-transparency:{bool}"
            | Resolution resolution -> $"resolution:{stringifyICssValue resolution}"
            | MinResolution resolution -> $"min-resolution:{stringifyICssValue resolution}"
            | MaxResolution resolution -> $"max-resolution:{stringifyICssValue resolution}"
            | Scan scan -> $"scan:{scan.Stringify()}"
            | Scripting scripting -> $"scripting:{scripting.Stringify()}"
            | Update update -> $"update:{update.Stringify()}"

    type MediaQueryMaster =
        | MediaQuery of Feature list * Rule list
        | MediaQueryFor of Device * Feature list * Rule list
        interface ICssValue with
            member this.StringifyCss() = ""


[<RequireQualifiedAccess>]
module MediaClasses =
    type Media() =
        member this.query (features: Media.Feature list) (rules: Rule list) =
            (Property.Media, Media.MediaQuery(features, rules))
            |> Rule

        member this.queryFor (device: Media.Device) (features: Media.Feature list)  (rules: Rule list) =
            (Property.Media, Media.MediaQueryFor(device, features, rules))
            |> Rule
