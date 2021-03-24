namespace Fss

namespace Fss.FssTypes
   type ColorType =
        | ColorType of string
        interface ITextDecorationColor
        interface ITextEmphasisColor
        interface IBorderColor
        interface IOutlineColor
        interface IColumnRuleColor
        interface ICaretColor
        interface IColorStop

    type Color =
        static member black = Fss.Utilities.Color.hex "000000" |> ColorType
        static member silver = Fss.Utilities.Color.hex "c0c0c0" |> ColorType
        static member gray = Fss.Utilities.Color.hex "808080" |> ColorType
        static member white = Fss.Utilities.Color.hex "ffffff" |> ColorType
        static member maroon = Fss.Utilities.Color.hex "800000" |> ColorType
        static member red = Fss.Utilities.Color.hex "ff0000" |> ColorType
        static member purple = Fss.Utilities.Color.hex "800080" |> ColorType
        static member fuchsia = Fss.Utilities.Color.hex "ff00ff" |> ColorType
        static member green = Fss.Utilities.Color.hex "008000" |> ColorType
        static member lime = Fss.Utilities.Color.hex "00ff00" |> ColorType
        static member olive = Fss.Utilities.Color.hex "808000" |> ColorType
        static member yellow = Fss.Utilities.Color.hex "ffff00" |> ColorType
        static member navy = Fss.Utilities.Color.hex "000080" |> ColorType
        static member blue = Fss.Utilities.Color.hex "0000ff" |> ColorType
        static member teal = Fss.Utilities.Color.hex "008080" |> ColorType
        static member aqua = Fss.Utilities.Color.hex "00ffff" |> ColorType
        static member orange = Fss.Utilities.Color.hex "ffa500" |> ColorType
        static member aliceBlue = Fss.Utilities.Color.hex "f0f8ff" |> ColorType
        static member antiqueWhite = Fss.Utilities.Color.hex "faebd7" |> ColorType
        static member aquaMarine = Fss.Utilities.Color.hex "7fffd4" |> ColorType
        static member azure = Fss.Utilities.Color.hex "f0ffff" |> ColorType
        static member beige = Fss.Utilities.Color.hex "f5f5dc" |> ColorType
        static member bisque = Fss.Utilities.Color.hex "ffe4c4" |> ColorType
        static member blanchedAlmond = Fss.Utilities.Color.hex "ffebcd" |> ColorType
        static member blueViolet = Fss.Utilities.Color.hex "8a2be2" |> ColorType
        static member brown = Fss.Utilities.Color.hex "a52a2a" |> ColorType
        static member burlywood = Fss.Utilities.Color.hex "deb887" |> ColorType
        static member cadetBlue = Fss.Utilities.Color.hex "5f9ea0" |> ColorType
        static member chartreuse = Fss.Utilities.Color.hex "7fff00" |> ColorType
        static member chocolate = Fss.Utilities.Color.hex "d2691e" |> ColorType
        static member coral = Fss.Utilities.Color.hex "ff7f50" |> ColorType
        static member cornflowerBlue = Fss.Utilities.Color.hex "6495ed" |> ColorType
        static member cornsilk = Fss.Utilities.Color.hex "fff8dc" |> ColorType
        static member crimson = Fss.Utilities.Color.hex "dc143c" |> ColorType
        static member cyan = Fss.Utilities.Color.hex "00ffff" |> ColorType
        static member darkBlue = Fss.Utilities.Color.hex "00008b" |> ColorType
        static member darkCyan = Fss.Utilities.Color.hex "008b8b" |> ColorType
        static member darkGoldenrod = Fss.Utilities.Color.hex "b8860b" |> ColorType
        static member darkGray = Fss.Utilities.Color.hex "a9a9a9" |> ColorType
        static member darkGreen = Fss.Utilities.Color.hex "006400" |> ColorType
        static member darkKhaki = Fss.Utilities.Color.hex "bdb76b" |> ColorType
        static member darkMagenta = Fss.Utilities.Color.hex "8b008b" |> ColorType
        static member darkOliveGreen = Fss.Utilities.Color.hex "556b2f" |> ColorType
        static member darkOrange = Fss.Utilities.Color.hex "ff8c00" |> ColorType
        static member darkOrchid = Fss.Utilities.Color.hex "9932cc" |> ColorType
        static member darkRed = Fss.Utilities.Color.hex "8b0000" |> ColorType
        static member darkSalmon = Fss.Utilities.Color.hex "e9967a" |> ColorType
        static member darkSeaGreen = Fss.Utilities.Color.hex "8fbc8f" |> ColorType
        static member darkSlateBlue = Fss.Utilities.Color.hex "483d8b" |> ColorType
        static member darkSlateGray = Fss.Utilities.Color.hex "2f4f4f" |> ColorType
        static member darkTurquoise = Fss.Utilities.Color.hex "00ced1" |> ColorType
        static member darkViolet = Fss.Utilities.Color.hex "9400d3" |> ColorType
        static member deepPink = Fss.Utilities.Color.hex "ff1493" |> ColorType
        static member deepSkyBlue = Fss.Utilities.Color.hex "00bfff" |> ColorType
        static member dimGrey = Fss.Utilities.Color.hex "696969" |> ColorType
        static member dodgerBlue = Fss.Utilities.Color.hex "1e90ff" |> ColorType
        static member fireBrick = Fss.Utilities.Color.hex "b22222" |> ColorType
        static member floralWhite = Fss.Utilities.Color.hex "fffaf0" |> ColorType
        static member forestGreen = Fss.Utilities.Color.hex "228b22" |> ColorType
        static member gainsboro = Fss.Utilities.Color.hex "dcdcdc" |> ColorType
        static member ghostWhite = Fss.Utilities.Color.hex "f8f8ff" |> ColorType
        static member gold = Fss.Utilities.Color.hex "ffd700" |> ColorType
        static member goldenrod = Fss.Utilities.Color.hex "daa520" |> ColorType
        static member greenYellow = Fss.Utilities.Color.hex "adff2f" |> ColorType
        static member grey = Fss.Utilities.Color.hex "808080" |> ColorType
        static member honeydew = Fss.Utilities.Color.hex "f0fff0" |> ColorType
        static member hotPink = Fss.Utilities.Color.hex "ff69b4" |> ColorType
        static member indianRed = Fss.Utilities.Color.hex "cd5c5c" |> ColorType
        static member indigo = Fss.Utilities.Color.hex "4b0082" |> ColorType
        static member ivory = Fss.Utilities.Color.hex "fffff0" |> ColorType
        static member khaki = Fss.Utilities.Color.hex "f0e68c" |> ColorType
        static member lavender = Fss.Utilities.Color.hex "e6e6fa" |> ColorType
        static member lavenderBlush = Fss.Utilities.Color.hex "fff0f5" |> ColorType
        static member lawnGreen = Fss.Utilities.Color.hex "7cfc00" |> ColorType
        static member lemonChiffon = Fss.Utilities.Color.hex "fffacd" |> ColorType
        static member lightBlue = Fss.Utilities.Color.hex "add8e6" |> ColorType
        static member lightCoral = Fss.Utilities.Color.hex "f08080" |> ColorType
        static member lightCyan = Fss.Utilities.Color.hex "e0ffff" |> ColorType
        static member lightGoldenrodYellow = Fss.Utilities.Color.hex "fafad2" |> ColorType
        static member lightGray = Fss.Utilities.Color.hex "d3d3d3" |> ColorType
        static member lightGreen = Fss.Utilities.Color.hex "90ee90" |> ColorType
        static member lightGrey = Fss.Utilities.Color.hex "d3d3d3" |> ColorType
        static member lightPink = Fss.Utilities.Color.hex "ffb6c1" |> ColorType
        static member lightSalmon = Fss.Utilities.Color.hex "ffa07a" |> ColorType
        static member lightSeaGreen = Fss.Utilities.Color.hex "20b2aa" |> ColorType
        static member lightSkyBlue = Fss.Utilities.Color.hex "87cefa" |> ColorType
        static member lightSlateGrey = Fss.Utilities.Color.hex "778899" |> ColorType
        static member lightSteelBlue = Fss.Utilities.Color.hex "b0c4de" |> ColorType
        static member lightYellow = Fss.Utilities.Color.hex "ffffe0" |> ColorType
        static member limeGreen = Fss.Utilities.Color.hex "32cd32" |> ColorType
        static member linen = Fss.Utilities.Color.hex "faf0e6" |> ColorType
        static member magenta = Fss.Utilities.Color.hex "ff00ff" |> ColorType
        static member mediumAquamarine = Fss.Utilities.Color.hex "66cdaa" |> ColorType
        static member mediumBlue = Fss.Utilities.Color.hex "0000cd" |> ColorType
        static member mediumOrchid = Fss.Utilities.Color.hex "ba55d3" |> ColorType
        static member mediumPurple = Fss.Utilities.Color.hex "9370db" |> ColorType
        static member mediumSeaGreen = Fss.Utilities.Color.hex "3cb371" |> ColorType
        static member mediumSlateBlue = Fss.Utilities.Color.hex "7b68ee" |> ColorType
        static member mediumSpringGreen = Fss.Utilities.Color.hex "00fa9a" |> ColorType
        static member mediumTurquoise = Fss.Utilities.Color.hex "48d1cc" |> ColorType
        static member mediumVioletRed = Fss.Utilities.Color.hex "c71585" |> ColorType
        static member midnightBlue = Fss.Utilities.Color.hex "191970" |> ColorType
        static member mintCream = Fss.Utilities.Color.hex "f5fffa" |> ColorType
        static member mistyRose = Fss.Utilities.Color.hex "ffe4e1" |> ColorType
        static member moccasin = Fss.Utilities.Color.hex "ffe4b5" |> ColorType
        static member navajoWhite = Fss.Utilities.Color.hex "ffdead" |> ColorType
        static member oldLace = Fss.Utilities.Color.hex "fdf5e6" |> ColorType
        static member olivedrab = Fss.Utilities.Color.hex "6b8e23" |> ColorType
        static member orangeRed = Fss.Utilities.Color.hex "ff4500" |> ColorType
        static member orchid = Fss.Utilities.Color.hex "da70d6" |> ColorType
        static member paleGoldenrod = Fss.Utilities.Color.hex "eee8aa" |> ColorType
        static member paleGreen = Fss.Utilities.Color.hex "98fb98" |> ColorType
        static member paleTurquoise = Fss.Utilities.Color.hex "afeeee" |> ColorType
        static member paleVioletred = Fss.Utilities.Color.hex "db7093" |> ColorType
        static member papayaWhip = Fss.Utilities.Color.hex "ffefd5" |> ColorType
        static member peachpuff = Fss.Utilities.Color.hex "ffdab9" |> ColorType
        static member peru = Fss.Utilities.Color.hex "cd853f" |> ColorType
        static member pink = Fss.Utilities.Color.hex "ffc0cb" |> ColorType
        static member plum = Fss.Utilities.Color.hex "dda0dd" |> ColorType
        static member powderBlue = Fss.Utilities.Color.hex "b0e0e6" |> ColorType
        static member rosyBrown = Fss.Utilities.Color.hex "bc8f8f" |> ColorType
        static member royalBlue = Fss.Utilities.Color.hex "4169e1" |> ColorType
        static member saddleBrown = Fss.Utilities.Color.hex "8b4513" |> ColorType
        static member salmon = Fss.Utilities.Color.hex "fa8072" |> ColorType
        static member sandyBrown = Fss.Utilities.Color.hex "f4a460" |> ColorType
        static member seaGreen = Fss.Utilities.Color.hex "2e8b57" |> ColorType
        static member seaShell = Fss.Utilities.Color.hex "fff5ee" |> ColorType
        static member sienna = Fss.Utilities.Color.hex "a0522d" |> ColorType
        static member skyBlue = Fss.Utilities.Color.hex "87ceeb" |> ColorType
        static member slateBlue = Fss.Utilities.Color.hex "6a5acd" |> ColorType
        static member slateGray = Fss.Utilities.Color.hex "708090" |> ColorType
        static member snow = Fss.Utilities.Color.hex "fffafa" |> ColorType
        static member springGreen = Fss.Utilities.Color.hex "00ff7f" |> ColorType
        static member steelBlue = Fss.Utilities.Color.hex "4682b4" |> ColorType
        static member tan = Fss.Utilities.Color.hex "d2b48c" |> ColorType
        static member thistle = Fss.Utilities.Color.hex "d8bfd8" |> ColorType
        static member tomato = Fss.Utilities.Color.hex "ff6347" |> ColorType
        static member turquoise = Fss.Utilities.Color.hex "40e0d0" |> ColorType
        static member violet = Fss.Utilities.Color.hex "ee82ee" |> ColorType
        static member wheat = Fss.Utilities.Color.hex "f5deb3" |> ColorType
        static member whiteSmoke = Fss.Utilities.Color.hex "f5f5f5" |> ColorType
        static member yellowGreen = Fss.Utilities.Color.hex "9acd32" |> ColorType
        static member rebeccaPurple = Fss.Utilities.Color.hex "663399" |> ColorType
        static member transparent = Fss.Utilities.Color.rgba 0 0 0 0.0 |> ColorType
        static member currentColor = "currentColor" |> ColorType
        static member Rgb (r: int, g: int, b: int) = Fss.Utilities.Color.rgb r g b |> ColorType
        static member Rgba (r: int, g: int, b: int, a: float) = Fss.Utilities.Color.rgba r g b a |> ColorType
        static member Hex (value: string) = Fss.Utilities.Color.hex value |> ColorType
        static member Hsl (h: int, s: float, l: float) = Fss.Utilities.Color.hsl h s l |> ColorType
        static member Hsla (h: int, s: float, l: float, a: float) = Fss.Utilities.Color.hsla h s l a |> ColorType

    type ColorAdjust =
        | Economy
        | Exact

    [<AutoOpen>]
    module colorHelpers =
        let internal colorToString (ColorType c) = c
