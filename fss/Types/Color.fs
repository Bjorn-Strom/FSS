namespace Fss

namespace Fss.Types
   type ColorTypeFoo =
        | ColorTypeFoo of string
        interface ITextDecorationColor
        interface ITextEmphasisColor
        interface IBorderColor
        interface IOutlineColor
        interface IColumnRuleColor
        interface ICaretColor
        interface IColorStop

    type Color =
        static member black = Fss.Utilities.Color.hex "000000" |> ColorTypeFoo
        static member silver = Fss.Utilities.Color.hex "c0c0c0" |> ColorTypeFoo
        static member gray = Fss.Utilities.Color.hex "808080" |> ColorTypeFoo
        static member white = Fss.Utilities.Color.hex "ffffff" |> ColorTypeFoo
        static member maroon = Fss.Utilities.Color.hex "800000" |> ColorTypeFoo
        static member red = Fss.Utilities.Color.hex "ff0000" |> ColorTypeFoo
        static member purple = Fss.Utilities.Color.hex "800080" |> ColorTypeFoo
        static member fuchsia = Fss.Utilities.Color.hex "ff00ff" |> ColorTypeFoo
        static member green = Fss.Utilities.Color.hex "008000" |> ColorTypeFoo
        static member lime = Fss.Utilities.Color.hex "00ff00" |> ColorTypeFoo
        static member olive = Fss.Utilities.Color.hex "808000" |> ColorTypeFoo
        static member yellow = Fss.Utilities.Color.hex "ffff00" |> ColorTypeFoo
        static member navy = Fss.Utilities.Color.hex "000080" |> ColorTypeFoo
        static member blue = Fss.Utilities.Color.hex "0000ff" |> ColorTypeFoo
        static member teal = Fss.Utilities.Color.hex "008080" |> ColorTypeFoo
        static member aqua = Fss.Utilities.Color.hex "00ffff" |> ColorTypeFoo
        static member orange = Fss.Utilities.Color.hex "ffa500" |> ColorTypeFoo
        static member aliceBlue = Fss.Utilities.Color.hex "f0f8ff" |> ColorTypeFoo
        static member antiqueWhite = Fss.Utilities.Color.hex "faebd7" |> ColorTypeFoo
        static member aquaMarine = Fss.Utilities.Color.hex "7fffd4" |> ColorTypeFoo
        static member azure = Fss.Utilities.Color.hex "f0ffff" |> ColorTypeFoo
        static member beige = Fss.Utilities.Color.hex "f5f5dc" |> ColorTypeFoo
        static member bisque = Fss.Utilities.Color.hex "ffe4c4" |> ColorTypeFoo
        static member blanchedAlmond = Fss.Utilities.Color.hex "ffebcd" |> ColorTypeFoo
        static member blueViolet = Fss.Utilities.Color.hex "8a2be2" |> ColorTypeFoo
        static member brown = Fss.Utilities.Color.hex "a52a2a" |> ColorTypeFoo
        static member burlywood = Fss.Utilities.Color.hex "deb887" |> ColorTypeFoo
        static member cadetBlue = Fss.Utilities.Color.hex "5f9ea0" |> ColorTypeFoo
        static member chartreuse = Fss.Utilities.Color.hex "7fff00" |> ColorTypeFoo
        static member chocolate = Fss.Utilities.Color.hex "d2691e" |> ColorTypeFoo
        static member coral = Fss.Utilities.Color.hex "ff7f50" |> ColorTypeFoo
        static member cornflowerBlue = Fss.Utilities.Color.hex "6495ed" |> ColorTypeFoo
        static member cornsilk = Fss.Utilities.Color.hex "fff8dc" |> ColorTypeFoo
        static member crimson = Fss.Utilities.Color.hex "dc143c" |> ColorTypeFoo
        static member cyan = Fss.Utilities.Color.hex "00ffff" |> ColorTypeFoo
        static member darkBlue = Fss.Utilities.Color.hex "00008b" |> ColorTypeFoo
        static member darkCyan = Fss.Utilities.Color.hex "008b8b" |> ColorTypeFoo
        static member darkGoldenrod = Fss.Utilities.Color.hex "b8860b" |> ColorTypeFoo
        static member darkGray = Fss.Utilities.Color.hex "a9a9a9" |> ColorTypeFoo
        static member darkGreen = Fss.Utilities.Color.hex "006400" |> ColorTypeFoo
        static member darkKhaki = Fss.Utilities.Color.hex "bdb76b" |> ColorTypeFoo
        static member darkMagenta = Fss.Utilities.Color.hex "8b008b" |> ColorTypeFoo
        static member darkOliveGreen = Fss.Utilities.Color.hex "556b2f" |> ColorTypeFoo
        static member darkOrange = Fss.Utilities.Color.hex "ff8c00" |> ColorTypeFoo
        static member darkOrchid = Fss.Utilities.Color.hex "9932cc" |> ColorTypeFoo
        static member darkRed = Fss.Utilities.Color.hex "8b0000" |> ColorTypeFoo
        static member darkSalmon = Fss.Utilities.Color.hex "e9967a" |> ColorTypeFoo
        static member darkSeaGreen = Fss.Utilities.Color.hex "8fbc8f" |> ColorTypeFoo
        static member darkSlateBlue = Fss.Utilities.Color.hex "483d8b" |> ColorTypeFoo
        static member darkSlateGray = Fss.Utilities.Color.hex "2f4f4f" |> ColorTypeFoo
        static member darkTurquoise = Fss.Utilities.Color.hex "00ced1" |> ColorTypeFoo
        static member darkViolet = Fss.Utilities.Color.hex "9400d3" |> ColorTypeFoo
        static member deepPink = Fss.Utilities.Color.hex "ff1493" |> ColorTypeFoo
        static member deepSkyBlue = Fss.Utilities.Color.hex "00bfff" |> ColorTypeFoo
        static member dimGrey = Fss.Utilities.Color.hex "696969" |> ColorTypeFoo
        static member dodgerBlue = Fss.Utilities.Color.hex "1e90ff" |> ColorTypeFoo
        static member fireBrick = Fss.Utilities.Color.hex "b22222" |> ColorTypeFoo
        static member floralWhite = Fss.Utilities.Color.hex "fffaf0" |> ColorTypeFoo
        static member forestGreen = Fss.Utilities.Color.hex "228b22" |> ColorTypeFoo
        static member gainsboro = Fss.Utilities.Color.hex "dcdcdc" |> ColorTypeFoo
        static member ghostWhite = Fss.Utilities.Color.hex "f8f8ff" |> ColorTypeFoo
        static member gold = Fss.Utilities.Color.hex "ffd700" |> ColorTypeFoo
        static member goldenrod = Fss.Utilities.Color.hex "daa520" |> ColorTypeFoo
        static member greenYellow = Fss.Utilities.Color.hex "adff2f" |> ColorTypeFoo
        static member grey = Fss.Utilities.Color.hex "808080" |> ColorTypeFoo
        static member honeydew = Fss.Utilities.Color.hex "f0fff0" |> ColorTypeFoo
        static member hotPink = Fss.Utilities.Color.hex "ff69b4" |> ColorTypeFoo
        static member indianRed = Fss.Utilities.Color.hex "cd5c5c" |> ColorTypeFoo
        static member indigo = Fss.Utilities.Color.hex "4b0082" |> ColorTypeFoo
        static member ivory = Fss.Utilities.Color.hex "fffff0" |> ColorTypeFoo
        static member khaki = Fss.Utilities.Color.hex "f0e68c" |> ColorTypeFoo
        static member lavender = Fss.Utilities.Color.hex "e6e6fa" |> ColorTypeFoo
        static member lavenderBlush = Fss.Utilities.Color.hex "fff0f5" |> ColorTypeFoo
        static member lawnGreen = Fss.Utilities.Color.hex "7cfc00" |> ColorTypeFoo
        static member lemonChiffon = Fss.Utilities.Color.hex "fffacd" |> ColorTypeFoo
        static member lightBlue = Fss.Utilities.Color.hex "add8e6" |> ColorTypeFoo
        static member lightCoral = Fss.Utilities.Color.hex "f08080" |> ColorTypeFoo
        static member lightCyan = Fss.Utilities.Color.hex "e0ffff" |> ColorTypeFoo
        static member lightGoldenrodYellow = Fss.Utilities.Color.hex "fafad2" |> ColorTypeFoo
        static member lightGray = Fss.Utilities.Color.hex "d3d3d3" |> ColorTypeFoo
        static member lightGreen = Fss.Utilities.Color.hex "90ee90" |> ColorTypeFoo
        static member lightGrey = Fss.Utilities.Color.hex "d3d3d3" |> ColorTypeFoo
        static member lightPink = Fss.Utilities.Color.hex "ffb6c1" |> ColorTypeFoo
        static member lightSalmon = Fss.Utilities.Color.hex "ffa07a" |> ColorTypeFoo
        static member lightSeaGreen = Fss.Utilities.Color.hex "20b2aa" |> ColorTypeFoo
        static member lightSkyBlue = Fss.Utilities.Color.hex "87cefa" |> ColorTypeFoo
        static member lightSlateGrey = Fss.Utilities.Color.hex "778899" |> ColorTypeFoo
        static member lightSteelBlue = Fss.Utilities.Color.hex "b0c4de" |> ColorTypeFoo
        static member lightYellow = Fss.Utilities.Color.hex "ffffe0" |> ColorTypeFoo
        static member limeGreen = Fss.Utilities.Color.hex "32cd32" |> ColorTypeFoo
        static member linen = Fss.Utilities.Color.hex "faf0e6" |> ColorTypeFoo
        static member magenta = Fss.Utilities.Color.hex "ff00ff" |> ColorTypeFoo
        static member mediumAquamarine = Fss.Utilities.Color.hex "66cdaa" |> ColorTypeFoo
        static member mediumBlue = Fss.Utilities.Color.hex "0000cd" |> ColorTypeFoo
        static member mediumOrchid = Fss.Utilities.Color.hex "ba55d3" |> ColorTypeFoo
        static member mediumPurple = Fss.Utilities.Color.hex "9370db" |> ColorTypeFoo
        static member mediumSeaGreen = Fss.Utilities.Color.hex "3cb371" |> ColorTypeFoo
        static member mediumSlateBlue = Fss.Utilities.Color.hex "7b68ee" |> ColorTypeFoo
        static member mediumSpringGreen = Fss.Utilities.Color.hex "00fa9a" |> ColorTypeFoo
        static member mediumTurquoise = Fss.Utilities.Color.hex "48d1cc" |> ColorTypeFoo
        static member mediumVioletRed = Fss.Utilities.Color.hex "c71585" |> ColorTypeFoo
        static member midnightBlue = Fss.Utilities.Color.hex "191970" |> ColorTypeFoo
        static member mintCream = Fss.Utilities.Color.hex "f5fffa" |> ColorTypeFoo
        static member mistyRose = Fss.Utilities.Color.hex "ffe4e1" |> ColorTypeFoo
        static member moccasin = Fss.Utilities.Color.hex "ffe4b5" |> ColorTypeFoo
        static member navajoWhite = Fss.Utilities.Color.hex "ffdead" |> ColorTypeFoo
        static member oldLace = Fss.Utilities.Color.hex "fdf5e6" |> ColorTypeFoo
        static member olivedrab = Fss.Utilities.Color.hex "6b8e23" |> ColorTypeFoo
        static member orangeRed = Fss.Utilities.Color.hex "ff4500" |> ColorTypeFoo
        static member orchid = Fss.Utilities.Color.hex "da70d6" |> ColorTypeFoo
        static member paleGoldenrod = Fss.Utilities.Color.hex "eee8aa" |> ColorTypeFoo
        static member paleGreen = Fss.Utilities.Color.hex "98fb98" |> ColorTypeFoo
        static member paleTurquoise = Fss.Utilities.Color.hex "afeeee" |> ColorTypeFoo
        static member paleVioletred = Fss.Utilities.Color.hex "db7093" |> ColorTypeFoo
        static member papayaWhip = Fss.Utilities.Color.hex "ffefd5" |> ColorTypeFoo
        static member peachpuff = Fss.Utilities.Color.hex "ffdab9" |> ColorTypeFoo
        static member peru = Fss.Utilities.Color.hex "cd853f" |> ColorTypeFoo
        static member pink = Fss.Utilities.Color.hex "ffc0cb" |> ColorTypeFoo
        static member plum = Fss.Utilities.Color.hex "dda0dd" |> ColorTypeFoo
        static member powderBlue = Fss.Utilities.Color.hex "b0e0e6" |> ColorTypeFoo
        static member rosyBrown = Fss.Utilities.Color.hex "bc8f8f" |> ColorTypeFoo
        static member royalBlue = Fss.Utilities.Color.hex "4169e1" |> ColorTypeFoo
        static member saddleBrown = Fss.Utilities.Color.hex "8b4513" |> ColorTypeFoo
        static member salmon = Fss.Utilities.Color.hex "fa8072" |> ColorTypeFoo
        static member sandyBrown = Fss.Utilities.Color.hex "f4a460" |> ColorTypeFoo
        static member seaGreen = Fss.Utilities.Color.hex "2e8b57" |> ColorTypeFoo
        static member seaShell = Fss.Utilities.Color.hex "fff5ee" |> ColorTypeFoo
        static member sienna = Fss.Utilities.Color.hex "a0522d" |> ColorTypeFoo
        static member skyBlue = Fss.Utilities.Color.hex "87ceeb" |> ColorTypeFoo
        static member slateBlue = Fss.Utilities.Color.hex "6a5acd" |> ColorTypeFoo
        static member slateGray = Fss.Utilities.Color.hex "708090" |> ColorTypeFoo
        static member snow = Fss.Utilities.Color.hex "fffafa" |> ColorTypeFoo
        static member springGreen = Fss.Utilities.Color.hex "00ff7f" |> ColorTypeFoo
        static member steelBlue = Fss.Utilities.Color.hex "4682b4" |> ColorTypeFoo
        static member tan = Fss.Utilities.Color.hex "d2b48c" |> ColorTypeFoo
        static member thistle = Fss.Utilities.Color.hex "d8bfd8" |> ColorTypeFoo
        static member tomato = Fss.Utilities.Color.hex "ff6347" |> ColorTypeFoo
        static member turquoise = Fss.Utilities.Color.hex "40e0d0" |> ColorTypeFoo
        static member violet = Fss.Utilities.Color.hex "ee82ee" |> ColorTypeFoo
        static member wheat = Fss.Utilities.Color.hex "f5deb3" |> ColorTypeFoo
        static member whiteSmoke = Fss.Utilities.Color.hex "f5f5f5" |> ColorTypeFoo
        static member yellowGreen = Fss.Utilities.Color.hex "9acd32" |> ColorTypeFoo
        static member rebeccaPurple = Fss.Utilities.Color.hex "663399" |> ColorTypeFoo
        static member transparent = Fss.Utilities.Color.rgba 0 0 0 0.0 |> ColorTypeFoo
        static member currentColor = "currentColor" |> ColorTypeFoo
        static member Rgb (r: int, g: int, b: int) = Fss.Utilities.Color.rgb r g b |> ColorTypeFoo
        static member Rgba (r: int, g: int, b: int, a: float) = Fss.Utilities.Color.rgba r g b a |> ColorTypeFoo
        static member Hex (value: string) = Fss.Utilities.Color.hex value |> ColorTypeFoo
        static member Hsl (h: int, s: float, l: float) = Fss.Utilities.Color.hsl h s l |> ColorTypeFoo
        static member Hsla (h: int, s: float, l: float, a: float) = Fss.Utilities.Color.hsla h s l a |> ColorTypeFoo

    type ColorAdjust =
        | Economy
        | Exact

    [<AutoOpen>]
    module colorHelpers =
        let internal colorToString (ColorTypeFoo c) = c
