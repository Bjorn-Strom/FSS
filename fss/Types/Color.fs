namespace Fss

namespace Fss.FssTypes

    [<AutoOpen>]
    module Color =
        type ColorType =
            | ColorType of string
            interface ITextDecorationColor
            interface ITextEmphasisColor
            interface IBorderColor
            interface IOutlineColor
            interface IColumnRuleColor
            interface ICaretColor
            interface IColorStop
            interface IColor
            interface IBackgroundColor

        type ColorBase<'a> (valueFunction: ColorType -> 'a) =
            member this.black = Fss.Utilities.Color.hex "000000" |> ColorType |> valueFunction
            member this.silver = Fss.Utilities.Color.hex "c0c0c0" |> ColorType |> valueFunction
            member this.gray = Fss.Utilities.Color.hex "808080" |> ColorType |> valueFunction
            member this.white = Fss.Utilities.Color.hex "ffffff" |> ColorType |> valueFunction
            member this.maroon = Fss.Utilities.Color.hex "800000" |> ColorType |> valueFunction
            member this.red = Fss.Utilities.Color.hex "ff0000" |> ColorType |> valueFunction
            member this.purple = Fss.Utilities.Color.hex "800080" |> ColorType |> valueFunction
            member this.fuchsia = Fss.Utilities.Color.hex "ff00ff" |> ColorType |> valueFunction
            member this.green = Fss.Utilities.Color.hex "008000" |> ColorType |> valueFunction
            member this.lime = Fss.Utilities.Color.hex "00ff00" |> ColorType |> valueFunction
            member this.olive = Fss.Utilities.Color.hex "808000" |> ColorType |> valueFunction
            member this.yellow = Fss.Utilities.Color.hex "ffff00" |> ColorType |> valueFunction
            member this.navy = Fss.Utilities.Color.hex "000080" |> ColorType |> valueFunction
            member this.blue = Fss.Utilities.Color.hex "0000ff" |> ColorType |> valueFunction
            member this.teal = Fss.Utilities.Color.hex "008080" |> ColorType |> valueFunction
            member this.aqua = Fss.Utilities.Color.hex "00ffff" |> ColorType |> valueFunction
            member this.orange = Fss.Utilities.Color.hex "ffa500" |> ColorType |> valueFunction
            member this.aliceBlue = Fss.Utilities.Color.hex "f0f8ff" |> ColorType |> valueFunction
            member this.antiqueWhite = Fss.Utilities.Color.hex "faebd7" |> ColorType |> valueFunction
            member this.aquaMarine = Fss.Utilities.Color.hex "7fffd4" |> ColorType |> valueFunction
            member this.azure = Fss.Utilities.Color.hex "f0ffff" |> ColorType |> valueFunction
            member this.beige = Fss.Utilities.Color.hex "f5f5dc" |> ColorType |> valueFunction
            member this.bisque = Fss.Utilities.Color.hex "ffe4c4" |> ColorType |> valueFunction
            member this.blanchedAlmond = Fss.Utilities.Color.hex "ffebcd" |> ColorType |> valueFunction
            member this.blueViolet = Fss.Utilities.Color.hex "8a2be2" |> ColorType |> valueFunction
            member this.brown = Fss.Utilities.Color.hex "a52a2a" |> ColorType |> valueFunction
            member this.burlywood = Fss.Utilities.Color.hex "deb887" |> ColorType |> valueFunction
            member this.cadetBlue = Fss.Utilities.Color.hex "5f9ea0" |> ColorType |> valueFunction
            member this.chartreuse = Fss.Utilities.Color.hex "7fff00" |> ColorType |> valueFunction
            member this.chocolate = Fss.Utilities.Color.hex "d2691e" |> ColorType |> valueFunction
            member this.coral = Fss.Utilities.Color.hex "ff7f50" |> ColorType |> valueFunction
            member this.cornflowerBlue = Fss.Utilities.Color.hex "6495ed" |> ColorType |> valueFunction
            member this.cornsilk = Fss.Utilities.Color.hex "fff8dc" |> ColorType |> valueFunction
            member this.crimson = Fss.Utilities.Color.hex "dc143c" |> ColorType |> valueFunction
            member this.cyan = Fss.Utilities.Color.hex "00ffff" |> ColorType |> valueFunction
            member this.darkBlue = Fss.Utilities.Color.hex "00008b" |> ColorType |> valueFunction
            member this.darkCyan = Fss.Utilities.Color.hex "008b8b" |> ColorType |> valueFunction
            member this.darkGoldenrod = Fss.Utilities.Color.hex "b8860b" |> ColorType |> valueFunction
            member this.darkGray = Fss.Utilities.Color.hex "a9a9a9" |> ColorType |> valueFunction
            member this.darkGreen = Fss.Utilities.Color.hex "006400" |> ColorType |> valueFunction
            member this.darkKhaki = Fss.Utilities.Color.hex "bdb76b" |> ColorType |> valueFunction
            member this.darkMagenta = Fss.Utilities.Color.hex "8b008b" |> ColorType |> valueFunction
            member this.darkOliveGreen = Fss.Utilities.Color.hex "556b2f" |> ColorType |> valueFunction
            member this.darkOrange = Fss.Utilities.Color.hex "ff8c00" |> ColorType |> valueFunction
            member this.darkOrchid = Fss.Utilities.Color.hex "9932cc" |> ColorType |> valueFunction
            member this.darkRed = Fss.Utilities.Color.hex "8b0000" |> ColorType |> valueFunction
            member this.darkSalmon = Fss.Utilities.Color.hex "e9967a" |> ColorType |> valueFunction
            member this.darkSeaGreen = Fss.Utilities.Color.hex "8fbc8f" |> ColorType |> valueFunction
            member this.darkSlateBlue = Fss.Utilities.Color.hex "483d8b" |> ColorType |> valueFunction
            member this.darkSlateGray = Fss.Utilities.Color.hex "2f4f4f" |> ColorType |> valueFunction
            member this.darkTurquoise = Fss.Utilities.Color.hex "00ced1" |> ColorType |> valueFunction
            member this.darkViolet = Fss.Utilities.Color.hex "9400d3" |> ColorType |> valueFunction
            member this.deepPink = Fss.Utilities.Color.hex "ff1493" |> ColorType |> valueFunction
            member this.deepSkyBlue = Fss.Utilities.Color.hex "00bfff" |> ColorType |> valueFunction
            member this.dimGrey = Fss.Utilities.Color.hex "696969" |> ColorType |> valueFunction
            member this.dodgerBlue = Fss.Utilities.Color.hex "1e90ff" |> ColorType |> valueFunction
            member this.fireBrick = Fss.Utilities.Color.hex "b22222" |> ColorType |> valueFunction
            member this.floralWhite = Fss.Utilities.Color.hex "fffaf0" |> ColorType |> valueFunction
            member this.forestGreen = Fss.Utilities.Color.hex "228b22" |> ColorType |> valueFunction
            member this.gainsboro = Fss.Utilities.Color.hex "dcdcdc" |> ColorType |> valueFunction
            member this.ghostWhite = Fss.Utilities.Color.hex "f8f8ff" |> ColorType |> valueFunction
            member this.gold = Fss.Utilities.Color.hex "ffd700" |> ColorType |> valueFunction
            member this.goldenrod = Fss.Utilities.Color.hex "daa520" |> ColorType |> valueFunction
            member this.greenYellow = Fss.Utilities.Color.hex "adff2f" |> ColorType |> valueFunction
            member this.grey = Fss.Utilities.Color.hex "808080" |> ColorType |> valueFunction
            member this.honeydew = Fss.Utilities.Color.hex "f0fff0" |> ColorType |> valueFunction
            member this.hotPink = Fss.Utilities.Color.hex "ff69b4" |> ColorType |> valueFunction
            member this.indianRed = Fss.Utilities.Color.hex "cd5c5c" |> ColorType |> valueFunction
            member this.indigo = Fss.Utilities.Color.hex "4b0082" |> ColorType |> valueFunction
            member this.ivory = Fss.Utilities.Color.hex "fffff0" |> ColorType |> valueFunction
            member this.khaki = Fss.Utilities.Color.hex "f0e68c" |> ColorType |> valueFunction
            member this.lavender = Fss.Utilities.Color.hex "e6e6fa" |> ColorType |> valueFunction
            member this.lavenderBlush = Fss.Utilities.Color.hex "fff0f5" |> ColorType |> valueFunction
            member this.lawnGreen = Fss.Utilities.Color.hex "7cfc00" |> ColorType |> valueFunction
            member this.lemonChiffon = Fss.Utilities.Color.hex "fffacd" |> ColorType |> valueFunction
            member this.lightBlue = Fss.Utilities.Color.hex "add8e6" |> ColorType |> valueFunction
            member this.lightCoral = Fss.Utilities.Color.hex "f08080" |> ColorType |> valueFunction
            member this.lightCyan = Fss.Utilities.Color.hex "e0ffff" |> ColorType |> valueFunction
            member this.lightGoldenrodYellow = Fss.Utilities.Color.hex "fafad2" |> ColorType |> valueFunction
            member this.lightGray = Fss.Utilities.Color.hex "d3d3d3" |> ColorType |> valueFunction
            member this.lightGreen = Fss.Utilities.Color.hex "90ee90" |> ColorType |> valueFunction
            member this.lightGrey = Fss.Utilities.Color.hex "d3d3d3" |> ColorType |> valueFunction
            member this.lightPink = Fss.Utilities.Color.hex "ffb6c1" |> ColorType |> valueFunction
            member this.lightSalmon = Fss.Utilities.Color.hex "ffa07a" |> ColorType |> valueFunction
            member this.lightSeaGreen = Fss.Utilities.Color.hex "20b2aa" |> ColorType |> valueFunction
            member this.lightSkyBlue = Fss.Utilities.Color.hex "87cefa" |> ColorType |> valueFunction
            member this.lightSlateGrey = Fss.Utilities.Color.hex "778899" |> ColorType |> valueFunction
            member this.lightSteelBlue = Fss.Utilities.Color.hex "b0c4de" |> ColorType |> valueFunction
            member this.lightYellow = Fss.Utilities.Color.hex "ffffe0" |> ColorType |> valueFunction
            member this.limeGreen = Fss.Utilities.Color.hex "32cd32" |> ColorType |> valueFunction
            member this.linen = Fss.Utilities.Color.hex "faf0e6" |> ColorType |> valueFunction
            member this.magenta = Fss.Utilities.Color.hex "ff00ff" |> ColorType |> valueFunction
            member this.mediumAquamarine = Fss.Utilities.Color.hex "66cdaa" |> ColorType |> valueFunction
            member this.mediumBlue = Fss.Utilities.Color.hex "0000cd" |> ColorType |> valueFunction
            member this.mediumOrchid = Fss.Utilities.Color.hex "ba55d3" |> ColorType |> valueFunction
            member this.mediumPurple = Fss.Utilities.Color.hex "9370db" |> ColorType |> valueFunction
            member this.mediumSeaGreen = Fss.Utilities.Color.hex "3cb371" |> ColorType |> valueFunction
            member this.mediumSlateBlue = Fss.Utilities.Color.hex "7b68ee" |> ColorType |> valueFunction
            member this.mediumSpringGreen = Fss.Utilities.Color.hex "00fa9a" |> ColorType |> valueFunction
            member this.mediumTurquoise = Fss.Utilities.Color.hex "48d1cc" |> ColorType |> valueFunction
            member this.mediumVioletRed = Fss.Utilities.Color.hex "c71585" |> ColorType |> valueFunction
            member this.midnightBlue = Fss.Utilities.Color.hex "191970" |> ColorType |> valueFunction
            member this.mintCream = Fss.Utilities.Color.hex "f5fffa" |> ColorType |> valueFunction
            member this.mistyRose = Fss.Utilities.Color.hex "ffe4e1" |> ColorType |> valueFunction
            member this.moccasin = Fss.Utilities.Color.hex "ffe4b5" |> ColorType |> valueFunction
            member this.navajoWhite = Fss.Utilities.Color.hex "ffdead" |> ColorType |> valueFunction
            member this.oldLace = Fss.Utilities.Color.hex "fdf5e6" |> ColorType |> valueFunction
            member this.olivedrab = Fss.Utilities.Color.hex "6b8e23" |> ColorType |> valueFunction
            member this.orangeRed = Fss.Utilities.Color.hex "ff4500" |> ColorType |> valueFunction
            member this.orchid = Fss.Utilities.Color.hex "da70d6" |> ColorType |> valueFunction
            member this.paleGoldenrod = Fss.Utilities.Color.hex "eee8aa" |> ColorType |> valueFunction
            member this.paleGreen = Fss.Utilities.Color.hex "98fb98" |> ColorType |> valueFunction
            member this.paleTurquoise = Fss.Utilities.Color.hex "afeeee" |> ColorType |> valueFunction
            member this.paleVioletred = Fss.Utilities.Color.hex "db7093" |> ColorType |> valueFunction
            member this.papayaWhip = Fss.Utilities.Color.hex "ffefd5" |> ColorType |> valueFunction
            member this.peachpuff = Fss.Utilities.Color.hex "ffdab9" |> ColorType |> valueFunction
            member this.peru = Fss.Utilities.Color.hex "cd853f" |> ColorType |> valueFunction
            member this.pink = Fss.Utilities.Color.hex "ffc0cb" |> ColorType |> valueFunction
            member this.plum = Fss.Utilities.Color.hex "dda0dd" |> ColorType |> valueFunction
            member this.powderBlue = Fss.Utilities.Color.hex "b0e0e6" |> ColorType |> valueFunction
            member this.rosyBrown = Fss.Utilities.Color.hex "bc8f8f" |> ColorType |> valueFunction
            member this.royalBlue = Fss.Utilities.Color.hex "4169e1" |> ColorType |> valueFunction
            member this.saddleBrown = Fss.Utilities.Color.hex "8b4513" |> ColorType |> valueFunction
            member this.salmon = Fss.Utilities.Color.hex "fa8072" |> ColorType |> valueFunction
            member this.sandyBrown = Fss.Utilities.Color.hex "f4a460" |> ColorType |> valueFunction
            member this.seaGreen = Fss.Utilities.Color.hex "2e8b57" |> ColorType |> valueFunction
            member this.seaShell = Fss.Utilities.Color.hex "fff5ee" |> ColorType |> valueFunction
            member this.sienna = Fss.Utilities.Color.hex "a0522d" |> ColorType |> valueFunction
            member this.skyBlue = Fss.Utilities.Color.hex "87ceeb" |> ColorType |> valueFunction
            member this.slateBlue = Fss.Utilities.Color.hex "6a5acd" |> ColorType |> valueFunction
            member this.slateGray = Fss.Utilities.Color.hex "708090" |> ColorType |> valueFunction
            member this.snow = Fss.Utilities.Color.hex "fffafa" |> ColorType |> valueFunction
            member this.springGreen = Fss.Utilities.Color.hex "00ff7f" |> ColorType |> valueFunction
            member this.steelBlue = Fss.Utilities.Color.hex "4682b4" |> ColorType |> valueFunction
            member this.tan = Fss.Utilities.Color.hex "d2b48c" |> ColorType |> valueFunction
            member this.thistle = Fss.Utilities.Color.hex "d8bfd8" |> ColorType |> valueFunction
            member this.tomato = Fss.Utilities.Color.hex "ff6347" |> ColorType |> valueFunction
            member this.turquoise = Fss.Utilities.Color.hex "40e0d0" |> ColorType |> valueFunction
            member this.violet = Fss.Utilities.Color.hex "ee82ee" |> ColorType |> valueFunction
            member this.wheat = Fss.Utilities.Color.hex "f5deb3" |> ColorType |> valueFunction
            member this.whiteSmoke = Fss.Utilities.Color.hex "f5f5f5" |> ColorType |> valueFunction
            member this.yellowGreen = Fss.Utilities.Color.hex "9acd32" |> ColorType |> valueFunction
            member this.rebeccaPurple = Fss.Utilities.Color.hex "663399" |> ColorType |> valueFunction
            member this.transparent = Fss.Utilities.Color.rgba 0 0 0 0.0 |> ColorType |> valueFunction
            member this.currentColor = "currentColor" |> ColorType |> valueFunction
            member this.rgb r g b = Fss.Utilities.Color.rgb r g b |> ColorType |> valueFunction
            member this.rgba r g b a = Fss.Utilities.Color.rgba r g b a |> ColorType |> valueFunction
            member this.hex (value: string) = Fss.Utilities.Color.hex value |> ColorType |> valueFunction
            member this.hsl h s l = Fss.Utilities.Color.hsl h s l |> ColorType |> valueFunction
            member this.hsla h s l a = Fss.Utilities.Color.hsla h s l a |> ColorType |> valueFunction

        let Color = ColorBase<ColorType>(id)

        type ColorClass (valueFunction: IColor -> CssProperty) =
            inherit ColorBase<CssProperty>(valueFunction)
            member this.value color = color |> valueFunction
            member this.inherit' = Inherit |> valueFunction
            member this.initial = Initial |> valueFunction
            member this.unset = Unset |> valueFunction

        type ColorAdjust =
            | Economy
            | Exact

        [<AutoOpen>]
        module colorHelpers =
            let internal colorToString (ColorType c) = c
