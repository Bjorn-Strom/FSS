namespace Fss

namespace Fss.FssTypes

type FontFaceProperty =
    | AscentOverride
    | DescentOverride
    | FontDisplay
    | FontFamily
    | FontStretch
    | FontStyle
    | FontWeight
    | FontVariant
    | FontFeatureSettings
    | FontVariationSettings
    | LineGapOverride
    | SizeAdjust
    | Src
    | UnicodeRange
    interface ICssValue with
        member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

type FontFaceRule = FontFaceProperty * IFontFaceValue

[<RequireQualifiedAccess>]
module FontFace =
    type Format =
        | Truetype of string
        | Opentype of string
        | EmpbeddedOpentype of string
        | Woff of string
        | Woff2 of string
        | Svg of string
        interface IFontFaceValue with
            member this.StringifyFontFace() =
                match this with
                | Truetype url -> $"url({url}) format('truetype')"
                | Opentype url -> $"url({url}) format('opentype')"
                | EmpbeddedOpentype url -> $"url({url}) format('empedded-opentype')"
                | Woff url -> $"url({url}) format('woff')"
                | Woff2 url -> $"url({url}) format('woff2')"
                | Svg url -> $"url({url}) format('svg')"

    type Display =
        | Block
        | Swap
        | Fallback
        | Optional
        interface IFontFaceValue with
            member this.StringifyFontFace() = this.ToString().ToLower()

    type Style =
        | Normal
        | Italic
        | Oblique
        | ObliqueAngle of Angle
        | ObliqueAngleRange of Angle * Angle
        interface IFontFaceValue with
            member this.StringifyFontFace() =
                match this with
                | ObliqueAngle angle -> $"oblique {stringifyICssValue angle}"
                | ObliqueAngleRange (angle, range) ->
                    $"oblique {stringifyICssValue angle} {stringifyICssValue range}"
                | _ -> this.ToString().ToLower()

    type Stretch =
        | UltraCondensed
        | ExtraCondensed
        | Condensed
        | SemiCondensed
        | Normal
        | SemiExpanded
        | Expanded
        | ExtraExpanded
        | UltraExpanded
        interface IFontFaceValue with
            member this.StringifyFontFace() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
// https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
module FontFaceClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/src
    type Src(property) =
        member this.url(url: string) = (property, Url url) |> FontFaceRule

        member this.truetype(url: string) =
            (property, FontFace.Truetype url) |> FontFaceRule

        member this.opentype(url: string) =
            (property, FontFace.Opentype url) |> FontFaceRule

        member this.empbeddedOpentype(url: string) =
            (property, FontFace.EmpbeddedOpentype url) |> FontFaceRule

        member this.woff(url: string) = (property, FontFace.Woff url) |> FontFaceRule
        member this.woff2(url: string) = (property, FontFace.Woff2 url) |> FontFaceRule
        member this.svg(url: string) = (property, FontFace.Svg url) |> FontFaceRule

        member this.sources(urls: string list) =
            let value =
                urls
                |> List.map (fun x -> (stringifyICssValue (Url x)))
                |> String.concat ", "
                |> String

            (property, value) |> FontFaceRule

        member this.sources(formatUrls: FontFace.Format list) =
            let value =
                formatUrls
                |> List.map stringifyIFontFaceValue
                |> String.concat ", "
                |> String

            (property, value) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-display
    type FontDisplay(property) =
        member this.auto = (property, Auto) |> FontFaceRule
        member this.block = (property, FontFace.Block) |> FontFaceRule
        member this.swap = (property, FontFace.Swap) |> FontFaceRule
        member this.fallback = (property, FontFace.Fallback) |> FontFaceRule
        member this.optional = (property, FontFace.Optional) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-style
    type FontStyle(property) =
        member this.normal = (property, FontFace.Style.Normal) |> FontFaceRule
        member this.italic = (property, FontFace.Italic) |> FontFaceRule
        member this.oblique = (property, FontFace.Oblique) |> FontFaceRule

        member this.obliqueAngle(angle: Angle) =
            (property, FontFace.ObliqueAngle angle) |> FontFaceRule

        member this.obliqueAngleRange(angle: Angle, range: Angle) =
            (property, FontFace.ObliqueAngleRange(angle, range))
            |> FontFaceRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-stretch
    type FontStretch(property) =
        member this.value(stretch: Percent) = (property, stretch) |> FontFaceRule

        member this.value(stretch: Percent list) =
            let value =
                stretch
                |> List.map stringifyICssValue
                |> String.concat " "
                |> String

            (property, value) |> FontFaceRule

        member this.ultraCondensed =
            (property, FontFace.UltraCondensed) |> FontFaceRule

        member this.extraCondensed =
            (property, FontFace.ExtraCondensed) |> FontFaceRule

        member this.condensed = (property, FontFace.Condensed) |> FontFaceRule

        member this.semiCondensed =
            (property, FontFace.SemiCondensed) |> FontFaceRule

        member this.normal = (property, FontFace.Normal) |> FontFaceRule
        member this.semiExpanded = (property, FontFace.SemiExpanded) |> FontFaceRule
        member this.expanded = (property, FontFace.Expanded) |> FontFaceRule

        member this.extraExpanded =
            (property, FontFace.ExtraExpanded) |> FontFaceRule

        member this.ultraExpanded =
            (property, FontFace.UltraExpanded) |> FontFaceRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-weight
    type FontWeight(property) =
        member this.value(weight: int) = (property, Int weight) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/size-adjust
    type SizeAdjust(property) =
        member this.value(adjust: Percent) = (property, adjust) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/unicode-range
    type UnicodeRange(property) =
        member this.value(range: string) =
            (property, String range) |> FontFaceRule

        member this.value(ranges: string list) =
            let value = ranges |> String.concat ", "
            (property, String value) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/line-gap-override
    type LineGapOverride(property) =
        member this.normal = (property, FontFace.Normal) |> FontFaceRule
        member this.value(adjust: Percent) = (property, adjust) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-variation-settings
    let private variationToString (setting, axis) = $"'{setting}' {axis}"

    type FontVariationSettings(property) =
        member this.normal = (property, FontFace.Normal) |> FontFaceRule

        member this.value(setting: string, axis: float) =
            (property, String <| variationToString (setting, axis))
            |> FontFaceRule

        member this.value(settings: (string * float) list) =
            let value =
                settings
                |> List.map variationToString
                |> String.concat ", "
                |> String

            (property, value) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/ascent-override
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/descent-override
    type AscentDescentOverride(property) =
        member this.normal = (property, FontFace.Normal) |> FontFaceRule
        member this.value(adjust: Percent) = (property, adjust) |> FontFaceRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face/font-family
    type FontFamily(property) =
        member this.ident(ident: string) =
            (property, String ident) |> FontFaceRule

        member this.string(string: string) =
            (property, Stringed string) |> FontFaceRule
