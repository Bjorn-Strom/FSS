namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Media =
    type Device =
        | Screen
        | Speech
        | Print
        | All
        | Not of Device
        | Only of Device

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
        override this.ToString() = Fss.Utilities.Helpers.toKebabCase this

    type LightLevel =
        | Dim
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
            | AnyHover bool -> $"any-hover: {bool}"
            | AnyPointer pointer -> $"any-pointer: {pointer.ToString().ToLower()}"
            | AspectRatio (x, y) -> $"aspect-ratio: {x}/{y}"
            | MinAspectRatio (x, y) -> $"min-aspect-ratio: {x}/{y}"
            | MaxAspectRatio (x, y) -> $"max-aspect-ratio {x}/{y}"
            | Color -> "color"
            | MinColor int -> $"min-color: {int}"
            | MaxColor int -> $"max-color: {int}"
            | ColorGamut colorGamut -> $"color-gamut: {colorGamut.ToString()}"
            | ColorIndex int -> $"color-index: {int}"
            | MinColorIndex int -> $"min-color-index: {int}"
            | MaxColorIndex int -> $"max-color-index: {int}"
            | DisplayMode displayMode -> $"display-mode: {displayMode}"
            | ForcedColors bool -> $"forced-colors: {bool}"
            | Grid bool -> $"grid: {bool}"
            | Height length -> $"height: {lengthPercentageString length}"
            | MinHeight length -> $"min-height: {lengthPercentageString length}"
            | MaxHeight length -> $"max-height: {lengthPercentageString length}"
            | Width length -> $"width: {lengthPercentageString length}"
            | MinWidth length -> $"min-width: {lengthPercentageString length}"
            | MaxWidth length -> $"max-width: {lengthPercentageString length}"
            | Hover bool -> $"hover: {bool}"
            | InvertedColors bool -> $"inverted-colors: {bool}"
            | LightLevel lightLevel -> $"light-level: {lightLevel.ToString().ToLower()}"
            | Monochrome int -> $"monochrome: {int}"
            | MinMonochrome int -> $"min-monochrome: {int}"
            | MaxMonochrome int -> $"max-monochrome: {int}"
            | Orientation orientation -> $"orientation: {orientation.ToString().ToLower()}"
            | OverflowBlock overflowBlock -> $"overflow-block: {Fss.Utilities.Helpers.toKebabCase overflowBlock}"
            | OverflowInline bool -> $"overflow-inline: {bool}"
            | Pointer pointer -> $"pointer: {pointer.ToString().ToLower()}"
            | PrefersColorScheme colorScheme -> $"preferred-color-scheme: {colorScheme.ToString().ToLower()}"
            | PrefersContrast contrast -> $"contrast: {Fss.Utilities.Helpers.toKebabCase contrast}"
            | PrefersReducedMotion bool -> $"prefers-reduced-motion: {bool}"
            | PrefersReducedTransparency bool -> $"prefers-reduced-transparency: {bool}"
            | Resolution resolution -> $"resolution: {(resolution :> ICssValue).Stringify()}"
            | MinResolution resolution -> $"min-resolution: {(resolution :> ICssValue).Stringify()}"
            | MaxResolution resolution -> $"max-resolution: {(resolution :> ICssValue).Stringify()}"
            | Scan scan -> $"scan: {scan.ToString().ToLower()}"
            | Scripting scripting -> $"scripting: {Fss.Utilities.Helpers.toKebabCase scripting}"
            | Update update -> $"update: {update.ToString().ToLower()}"


    // TODO: FIND BETTER PLACE FOR ALL THESE
    type MediaQuery =
        | MediaQuery of Feature list * Rule list
        interface ICssValue with
            member this.Stringify() =
                match this with
                | MediaQuery (features, rules) ->
                    let features =
                        features
                        |> List.map (fun x -> x.ToString())
                        |> String.concat " and "

                    let rules =
                        rules
                        |> List.map
                            (fun (name, property) ->
                                $"{Fss.Utilities.Helpers.toKebabCase name}: {property.Stringify()};")
                        |> String.concat ""

                    $"({features}) | {{ {rules} }}"

    [<RequireQualifiedAccess>]
    module MediaClasses =
        type Media() =
            member this.query (features: Feature list) (rules: Rule list) =
                (Property.Media, MediaQuery(features, rules))
                |> Rule
