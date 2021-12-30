namespace Fss

namespace Fss.FssTypes

[<AutoOpen>]
module Color =
    type Color =
        | Black
        | Silver
        | Gray
        | White
        | Maroon
        | Red
        | Purple
        | Fuchsia
        | Green
        | Lime
        | Olive
        | Yellow
        | Navy
        | Blue
        | Teal
        | Aqua
        | Orange
        | AliceBlue
        | AntiqueWhite
        | AquaMarine
        | Azure
        | Beige
        | Bisque
        | BlanchedAlmond
        | BlueViolet
        | Brown
        | Burlywood
        | CadetBlue
        | Chartreuse
        | Chocolate
        | Coral
        | CornflowerBlue
        | Cornsilk
        | Crimson
        | Cyan
        | DarkBlue
        | DarkCyan
        | DarkGoldenrod
        | DarkGray
        | DarkGreen
        | DarkKhaki
        | DarkMagenta
        | DarkOliveGreen
        | DarkOrange
        | DarkOrchid
        | DarkRed
        | DarkSalmon
        | DarkSeaGreen
        | DarkSlateBlue
        | DarkSlateGray
        | DarkTurquoise
        | DarkViolet
        | DeepPink
        | DeepSkyBlue
        | DimGrey
        | DodgerBlue
        | FireBrick
        | FloralWhite
        | ForestGreen
        | Gainsboro
        | GhostWhite
        | Gold
        | Goldenrod
        | GreenYellow
        | Grey
        | Honeydew
        | HotPink
        | IndianRed
        | Indigo
        | Ivory
        | Khaki
        | Lavender
        | LavenderBlush
        | LawnGreen
        | LemonChiffon
        | LightBlue
        | LightCoral
        | LightCyan
        | LightGoldenrodYellow
        | LightGray
        | LightGreen
        | LightGrey
        | LightPink
        | LightSalmon
        | LightSeaGreen
        | LightSkyBlue
        | LightSlateGrey
        | LightSteelBlue
        | LightYellow
        | LimeGreen
        | Linen
        | Magenta
        | MediumAquamarine
        | MediumBlue
        | MediumOrchid
        | MediumPurple
        | MediumSeaGreen
        | MediumSlateBlue
        | MediumSpringGreen
        | MediumTurquoise
        | MediumVioletRed
        | MidnightBlue
        | MintCream
        | MistyRose
        | Moccasin
        | NavajoWhite
        | OldLace
        | Olivedrab
        | OrangeRed
        | Orchid
        | PaleGoldenrod
        | PaleGreen
        | PaleTurquoise
        | PaleVioletred
        | PapayaWhip
        | Peachpuff
        | Peru
        | Pink
        | Plum
        | PowderBlue
        | RosyBrown
        | RoyalBlue
        | SaddleBrown
        | Salmon
        | SandyBrown
        | SeaGreen
        | SeaShell
        | Sienna
        | SkyBlue
        | SlateBlue
        | SlateGray
        | Snow
        | SpringGreen
        | SteelBlue
        | Tan
        | Thistle
        | Tomato
        | Turquoise
        | Violet
        | Wheat
        | WhiteSmoke
        | YellowGreen
        | RebeccaPurple
        | Transparent
        | CurrentColor
        | Rgb of Red: int * Green: int * Blue: int
        | Rgba of Red: int * Green: int * Blue: int * Alpha: float
        | Hex of string
        | Hsl of Hue: int * Saturation: int * Lightness: int
        | Hsla of Hue: int * Saturation: int * Lightness: int * Alpha: float
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Rgb (red, green, blue) -> $"rgb({red}, {green}, {blue})"
                | Rgba (red, green, blue, alpha) -> $"rgba({red}, {green}, {blue}, {alpha})"
                | Hex hex -> hex
                | Hsl (hue, saturation, lightness) -> $"hsl({hue}, {saturation}%%, {lightness}%%)"
                | Hsla (hue, saturation, lightness, alpha) -> $"hsla({hue}, {saturation}%%, {lightness}%%, {alpha})"
                | _ -> this.ToString().ToLower()

    type ColorAdjust =
        | Economy
        | Exact
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

module colorHelpers =
    let internal hex (value: string) =
        if value.StartsWith "#" then
            value
        else
            $"#{value}"
        |> Hex

[<RequireQualifiedAccess>]
module ColorClass =
    type Color(property) =
        inherit CssRule(property)
        member this.value(color: Color.Color) = (property, color) |> Rule
        member this.black = (property, Black) |> Rule
        member this.silver = (property, Silver) |> Rule
        member this.gray = (property, Gray) |> Rule
        member this.white = (property, White) |> Rule
        member this.maroon = (property, Maroon) |> Rule
        member this.red = (property, Red) |> Rule
        member this.purple = (property, Purple) |> Rule
        member this.fuchsia = (property, Fuchsia) |> Rule
        member this.green = (property, Green) |> Rule
        member this.lime = (property, Lime) |> Rule
        member this.olive = (property, Olive) |> Rule
        member this.yellow = (property, Yellow) |> Rule
        member this.navy = (property, Navy) |> Rule
        member this.blue = (property, Blue) |> Rule
        member this.teal = (property, Teal) |> Rule
        member this.aqua = (property, Aqua) |> Rule
        member this.orange = (property, Orange) |> Rule
        member this.aliceBlue = (property, AliceBlue) |> Rule
        member this.antiqueWhite = (property, AntiqueWhite) |> Rule
        member this.aquaMarine = (property, AquaMarine) |> Rule
        member this.azure = (property, Azure) |> Rule
        member this.beige = (property, Beige) |> Rule
        member this.bisque = (property, Bisque) |> Rule
        member this.blanchedAlmond = (property, BlanchedAlmond) |> Rule
        member this.blueViolet = (property, BlueViolet) |> Rule
        member this.brown = (property, Brown) |> Rule
        member this.burlywood = (property, Burlywood) |> Rule
        member this.cadetBlue = (property, CadetBlue) |> Rule
        member this.chartreuse = (property, Chartreuse) |> Rule
        member this.chocolate = (property, Chocolate) |> Rule
        member this.coral = (property, Coral) |> Rule
        member this.cornflowerBlue = (property, CornflowerBlue) |> Rule
        member this.cornsilk = (property, Cornsilk) |> Rule
        member this.crimson = (property, Crimson) |> Rule
        member this.cyan = (property, Cyan) |> Rule
        member this.darkBlue = (property, DarkBlue) |> Rule
        member this.darkCyan = (property, DarkCyan) |> Rule
        member this.darkGoldenrod = (property, DarkGoldenrod) |> Rule
        member this.darkGray = (property, DarkGray) |> Rule
        member this.darkGreen = (property, DarkGreen) |> Rule
        member this.darkKhaki = (property, DarkKhaki) |> Rule
        member this.darkMagenta = (property, DarkMagenta) |> Rule
        member this.darkOliveGreen = (property, DarkOliveGreen) |> Rule
        member this.darkOrange = (property, DarkOrange) |> Rule
        member this.darkOrchid = (property, DarkOrchid) |> Rule
        member this.darkRed = (property, DarkRed) |> Rule
        member this.darkSalmon = (property, DarkSalmon) |> Rule
        member this.darkSeaGreen = (property, DarkSeaGreen) |> Rule
        member this.darkSlateBlue = (property, DarkSlateBlue) |> Rule
        member this.darkSlateGray = (property, DarkSlateGray) |> Rule
        member this.darkTurquoise = (property, DarkTurquoise) |> Rule
        member this.darkViolet = (property, DarkViolet) |> Rule
        member this.deepPink = (property, DeepPink) |> Rule
        member this.deepSkyBlue = (property, DeepSkyBlue) |> Rule
        member this.dimGrey = (property, DimGrey) |> Rule
        member this.dodgerBlue = (property, DodgerBlue) |> Rule
        member this.fireBrick = (property, FireBrick) |> Rule
        member this.floralWhite = (property, FloralWhite) |> Rule
        member this.forestGreen = (property, ForestGreen) |> Rule
        member this.gainsboro = (property, Gainsboro) |> Rule
        member this.ghostWhite = (property, GhostWhite) |> Rule
        member this.gold = (property, Gold) |> Rule
        member this.goldenrod = (property, Goldenrod) |> Rule
        member this.greenYellow = (property, GreenYellow) |> Rule
        member this.grey = (property, Grey) |> Rule
        member this.honeydew = (property, Honeydew) |> Rule
        member this.hotPink = (property, HotPink) |> Rule
        member this.indianRed = (property, IndianRed) |> Rule
        member this.indigo = (property, Indigo) |> Rule
        member this.ivory = (property, Ivory) |> Rule
        member this.khaki = (property, Khaki) |> Rule
        member this.lavender = (property, Lavender) |> Rule
        member this.lavenderBlush = (property, LavenderBlush) |> Rule
        member this.lawnGreen = (property, LawnGreen) |> Rule
        member this.lemonChiffon = (property, LemonChiffon) |> Rule
        member this.lightBlue = (property, LightBlue) |> Rule
        member this.lightCoral = (property, LightCoral) |> Rule
        member this.lightCyan = (property, LightCyan) |> Rule
        member this.lightGoldenrodYellow = (property, LightGoldenrodYellow) |> Rule
        member this.lightGray = (property, LightGray) |> Rule
        member this.lightGreen = (property, LightGreen) |> Rule
        member this.lightGrey = (property, LightGrey) |> Rule
        member this.lightPink = (property, LightPink) |> Rule
        member this.lightSalmon = (property, LightSalmon) |> Rule
        member this.lightSeaGreen = (property, LightSeaGreen) |> Rule
        member this.lightSkyBlue = (property, LightSkyBlue) |> Rule
        member this.lightSlateGrey = (property, LightSlateGrey) |> Rule
        member this.lightSteelBlue = (property, LightSteelBlue) |> Rule
        member this.lightYellow = (property, LightYellow) |> Rule
        member this.limeGreen = (property, LimeGreen) |> Rule
        member this.linen = (property, Linen) |> Rule
        member this.magenta = (property, Magenta) |> Rule
        member this.mediumAquamarine = (property, MediumAquamarine) |> Rule
        member this.mediumBlue = (property, MediumBlue) |> Rule
        member this.mediumOrchid = (property, MediumOrchid) |> Rule
        member this.mediumPurple = (property, MediumPurple) |> Rule
        member this.mediumSeaGreen = (property, MediumSeaGreen) |> Rule
        member this.mediumSlateBlue = (property, MediumSlateBlue) |> Rule
        member this.mediumSpringGreen = (property, MediumSpringGreen) |> Rule
        member this.mediumTurquoise = (property, MediumTurquoise) |> Rule
        member this.mediumVioletRed = (property, MediumVioletRed) |> Rule
        member this.midnightBlue = (property, MidnightBlue) |> Rule
        member this.mintCream = (property, MintCream) |> Rule
        member this.mistyRose = (property, MistyRose) |> Rule
        member this.moccasin = (property, Moccasin) |> Rule
        member this.navajoWhite = (property, NavajoWhite) |> Rule
        member this.oldLace = (property, OldLace) |> Rule
        member this.olivedrab = (property, Olivedrab) |> Rule
        member this.orangeRed = (property, OrangeRed) |> Rule
        member this.orchid = (property, Orchid) |> Rule
        member this.paleGoldenrod = (property, PaleGoldenrod) |> Rule
        member this.paleGreen = (property, PaleGreen) |> Rule
        member this.paleTurquoise = (property, PaleTurquoise) |> Rule
        member this.paleVioletred = (property, PaleVioletred) |> Rule
        member this.papayaWhip = (property, PapayaWhip) |> Rule
        member this.peachpuff = (property, Peachpuff) |> Rule
        member this.peru = (property, Peru) |> Rule
        member this.pink = (property, Pink) |> Rule
        member this.plum = (property, Plum) |> Rule
        member this.powderBlue = (property, PowderBlue) |> Rule
        member this.rosyBrown = (property, RosyBrown) |> Rule
        member this.royalBlue = (property, RoyalBlue) |> Rule
        member this.saddleBrown = (property, SaddleBrown) |> Rule
        member this.salmon = (property, Salmon) |> Rule
        member this.sandyBrown = (property, SandyBrown) |> Rule
        member this.seaGreen = (property, SeaGreen) |> Rule
        member this.seaShell = (property, SeaShell) |> Rule
        member this.sienna = (property, Sienna) |> Rule
        member this.skyBlue = (property, SkyBlue) |> Rule
        member this.slateBlue = (property, SlateBlue) |> Rule
        member this.slateGray = (property, SlateGray) |> Rule
        member this.snow = (property, Snow) |> Rule
        member this.springGreen = (property, SpringGreen) |> Rule
        member this.steelBlue = (property, SteelBlue) |> Rule
        member this.tan = (property, Tan) |> Rule
        member this.thistle = (property, Thistle) |> Rule
        member this.tomato = (property, Tomato) |> Rule
        member this.turquoise = (property, Turquoise) |> Rule
        member this.violet = (property, Violet) |> Rule
        member this.wheat = (property, Wheat) |> Rule
        member this.whiteSmoke = (property, WhiteSmoke) |> Rule
        member this.yellowGreen = (property, YellowGreen) |> Rule
        member this.rebeccaPurple = (property, RebeccaPurple) |> Rule
        member this.transparent = (property, Transparent) |> Rule
        member this.currentColor = (property, CurrentColor) |> Rule

        member this.rgb red green blue =
            (property, Rgb(red, green, blue)) |> Rule

        member this.rgba red green blue alpha =
            (property, Rgba(red, green, blue, alpha)) |> Rule

        member this.hex(value: string) = (property, colorHelpers.hex value) |> Rule

        member this.hsl hue saturation lightness =
            (property, Hsl(hue, saturation, lightness))
            |> Rule

        member this.hsla hue saturation lightness alpha =
            (property, Hsla(hue, saturation, lightness, alpha))
            |> Rule

    type ColorAdjust(property) =
        inherit CssRule(property)
        member this.value(adjust: Color.ColorAdjust) = (property, adjust) |> Rule
        member this.exact = (property, Exact) |> Rule
        member this.economy = (property, Economy) |> Rule
