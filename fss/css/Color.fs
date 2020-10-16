
namespace Fss

open Global
open Types

module Color =
    type CssColor =
        | CssColor of string
        interface IColor
        interface ILinearGradient
        interface IRadialGradient
        interface IBorderColor
        interface ITextEmphasisColor
        interface IBackgroundColor

    let private colorValue (CssColor c) = c

    let value (v: IColor): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? CssColor as c -> colorValue c
            | _ -> "Unknown font size"

    let black = Utilities.Color.hex "000000" |> CssColor
    let silver = Utilities.Color.hex "c0c0c0" |> CssColor
    let gray = Utilities.Color.hex "808080" |> CssColor
    let white = Utilities.Color.hex "ffffff" |> CssColor
    let maroon = Utilities.Color.hex "800000" |> CssColor
    let red = Utilities.Color.hex "ff0000" |> CssColor
    let purple = Utilities.Color.hex "800080" |> CssColor
    let fuchsia = Utilities.Color.hex "ff00ff" |> CssColor
    let green = Utilities.Color.hex "008000" |> CssColor
    let lime = Utilities.Color.hex "00ff00" |> CssColor
    let olive = Utilities.Color.hex "808000" |> CssColor
    let yellow = Utilities.Color.hex "ffff00" |> CssColor
    let navy = Utilities.Color.hex "000080" |> CssColor
    let blue = Utilities.Color.hex "0000ff" |> CssColor
    let teal = Utilities.Color.hex "008080" |> CssColor
    let aqua = Utilities.Color.hex "00ffff" |> CssColor
    let orange = Utilities.Color.hex "ffa500" |> CssColor
    let aliceBlue = Utilities.Color.hex "f0f8ff" |> CssColor
    let antiqueWhite = Utilities.Color.hex "faebd7" |> CssColor
    let aquaMarine = Utilities.Color.hex "7fffd4" |> CssColor
    let azure = Utilities.Color.hex "f0ffff" |> CssColor
    let beige = Utilities.Color.hex "f5f5dc" |> CssColor
    let bisque = Utilities.Color.hex "ffe4c4" |> CssColor
    let blanchedAlmond = Utilities.Color.hex "ffebcd" |> CssColor
    let blueViolet = Utilities.Color.hex "8a2be2" |> CssColor
    let brown = Utilities.Color.hex "a52a2a" |> CssColor
    let burlywood = Utilities.Color.hex "deb887" |> CssColor
    let cadetBlue = Utilities.Color.hex "5f9ea0" |> CssColor
    let chartreuse = Utilities.Color.hex "7fff00" |> CssColor
    let chocolate = Utilities.Color.hex "d2691e" |> CssColor
    let coral = Utilities.Color.hex "ff7f50" |> CssColor
    let cornflowerBlue = Utilities.Color.hex "6495ed" |> CssColor
    let cornsilk = Utilities.Color.hex "fff8dc" |> CssColor
    let crimson = Utilities.Color.hex "dc143c" |> CssColor
    let cyan = Utilities.Color.hex "00ffff" |> CssColor
    let darkBlue = Utilities.Color.hex "00008b" |> CssColor
    let darkCyan = Utilities.Color.hex "008b8b" |> CssColor
    let darkGoldenrod = Utilities.Color.hex "b8860b" |> CssColor
    let darkGray = Utilities.Color.hex "a9a9a9" |> CssColor
    let darkGreen = Utilities.Color.hex "006400" |> CssColor
    let darkKhaki = Utilities.Color.hex "bdb76b" |> CssColor
    let darkMagenta = Utilities.Color.hex "8b008b" |> CssColor
    let darkOliveGreen = Utilities.Color.hex "556b2f" |> CssColor
    let darkOrange = Utilities.Color.hex "ff8c00" |> CssColor
    let darkOrchid = Utilities.Color.hex "9932cc" |> CssColor
    let darkRed = Utilities.Color.hex "8b0000" |> CssColor
    let darkSalmon = Utilities.Color.hex "e9967a" |> CssColor
    let darkSeaGreen = Utilities.Color.hex "8fbc8f" |> CssColor
    let darkSlateBlue = Utilities.Color.hex "483d8b" |> CssColor
    let darkSlateGray = Utilities.Color.hex "2f4f4f" |> CssColor
    let darkTurquoise = Utilities.Color.hex "00ced1" |> CssColor
    let darkViolet = Utilities.Color.hex "9400d3" |> CssColor
    let deepPink = Utilities.Color.hex "ff1493" |> CssColor
    let deepSkyBlue = Utilities.Color.hex "00bfff" |> CssColor
    let dimGrey = Utilities.Color.hex "696969" |> CssColor
    let dodgerBlue = Utilities.Color.hex "1e90ff" |> CssColor
    let fireBrick = Utilities.Color.hex "b22222" |> CssColor
    let floralWhite = Utilities.Color.hex "fffaf0" |> CssColor
    let forestGreen = Utilities.Color.hex "228b22" |> CssColor
    let gainsboro = Utilities.Color.hex "dcdcdc" |> CssColor
    let ghostWhite = Utilities.Color.hex "f8f8ff" |> CssColor
    let gold = Utilities.Color.hex "ffd700" |> CssColor
    let goldenrod = Utilities.Color.hex "daa520" |> CssColor
    let greenYellow = Utilities.Color.hex "adff2f" |> CssColor
    let grey = Utilities.Color.hex "808080" |> CssColor
    let honeydew = Utilities.Color.hex "f0fff0" |> CssColor
    let hotPink = Utilities.Color.hex "ff69b4" |> CssColor
    let indianRed = Utilities.Color.hex "cd5c5c" |> CssColor
    let indigo = Utilities.Color.hex "4b0082" |> CssColor
    let ivory = Utilities.Color.hex "fffff0" |> CssColor
    let khaki = Utilities.Color.hex "f0e68c" |> CssColor
    let lavender = Utilities.Color.hex "e6e6fa" |> CssColor
    let lavenderBlush = Utilities.Color.hex "fff0f5" |> CssColor
    let lawnGreen = Utilities.Color.hex "7cfc00" |> CssColor
    let lemonChiffon = Utilities.Color.hex "fffacd" |> CssColor
    let lightBlue = Utilities.Color.hex "add8e6" |> CssColor
    let lightCoral = Utilities.Color.hex "f08080" |> CssColor
    let lightCyan = Utilities.Color.hex "e0ffff" |> CssColor
    let lightGoldenrodYellow = Utilities.Color.hex "fafad2" |> CssColor
    let lightGray = Utilities.Color.hex "d3d3d3" |> CssColor
    let lightGreen = Utilities.Color.hex "90ee90" |> CssColor
    let lightGrey = Utilities.Color.hex "d3d3d3" |> CssColor
    let lightPink = Utilities.Color.hex "ffb6c1" |> CssColor
    let lightSalmon = Utilities.Color.hex "ffa07a" |> CssColor
    let lightSeaGreen = Utilities.Color.hex "20b2aa" |> CssColor
    let lightSkyBlue = Utilities.Color.hex "87cefa" |> CssColor
    let lightSlateGrey = Utilities.Color.hex "778899" |> CssColor
    let lightSteelBlue = Utilities.Color.hex "b0c4de" |> CssColor
    let lightYellow = Utilities.Color.hex "ffffe0" |> CssColor
    let limeGreen = Utilities.Color.hex "32cd32" |> CssColor
    let linen = Utilities.Color.hex "faf0e6" |> CssColor
    let magenta = Utilities.Color.hex "ff00ff" |> CssColor
    let mediumAquamarine = Utilities.Color.hex "66cdaa" |> CssColor
    let mediumBlue = Utilities.Color.hex "0000cd" |> CssColor
    let mediumOrchid = Utilities.Color.hex "ba55d3" |> CssColor
    let mediumPurple = Utilities.Color.hex "9370db" |> CssColor
    let mediumSeaGreen = Utilities.Color.hex "3cb371" |> CssColor
    let mediumSlateBlue = Utilities.Color.hex "7b68ee" |> CssColor
    let mediumSpringGreen = Utilities.Color.hex "00fa9a" |> CssColor
    let mediumTurquoise = Utilities.Color.hex "48d1cc" |> CssColor
    let mediumVioletRed = Utilities.Color.hex "c71585" |> CssColor
    let midnightBlue = Utilities.Color.hex "191970" |> CssColor
    let mintCream = Utilities.Color.hex "f5fffa" |> CssColor
    let mistyRose = Utilities.Color.hex "ffe4e1" |> CssColor
    let moccasin = Utilities.Color.hex "ffe4b5" |> CssColor
    let navajoWhite = Utilities.Color.hex "ffdead" |> CssColor
    let oldLace = Utilities.Color.hex "fdf5e6" |> CssColor
    let olivedrab = Utilities.Color.hex "6b8e23" |> CssColor
    let orangeRed = Utilities.Color.hex "ff4500" |> CssColor
    let orchid = Utilities.Color.hex "da70d6" |> CssColor
    let paleGoldenrod = Utilities.Color.hex "eee8aa" |> CssColor
    let paleGreen = Utilities.Color.hex "98fb98" |> CssColor
    let paleTurquoise = Utilities.Color.hex "afeeee" |> CssColor
    let paleVioletred = Utilities.Color.hex "db7093" |> CssColor
    let papayaWhip = Utilities.Color.hex "ffefd5" |> CssColor
    let peachpuff = Utilities.Color.hex "ffdab9" |> CssColor
    let peru = Utilities.Color.hex "cd853f" |> CssColor
    let pink = Utilities.Color.hex "ffc0cb" |> CssColor
    let plum = Utilities.Color.hex "dda0dd" |> CssColor
    let powderBlue = Utilities.Color.hex "b0e0e6" |> CssColor
    let rosyBrown = Utilities.Color.hex "bc8f8f" |> CssColor
    let royalBlue = Utilities.Color.hex "4169e1" |> CssColor
    let saddleBrown = Utilities.Color.hex "8b4513" |> CssColor
    let salmon = Utilities.Color.hex "fa8072" |> CssColor
    let sandyBrown = Utilities.Color.hex "f4a460" |> CssColor
    let seaGreen = Utilities.Color.hex "2e8b57" |> CssColor
    let seaShell = Utilities.Color.hex "fff5ee" |> CssColor
    let sienna = Utilities.Color.hex "a0522d" |> CssColor
    let skyBlue = Utilities.Color.hex "87ceeb" |> CssColor
    let slateBlue = Utilities.Color.hex "6a5acd" |> CssColor
    let slateGray = Utilities.Color.hex "708090" |> CssColor
    let snow = Utilities.Color.hex "fffafa" |> CssColor
    let springGreen = Utilities.Color.hex "00ff7f" |> CssColor
    let steelBlue = Utilities.Color.hex "4682b4" |> CssColor
    let tan = Utilities.Color.hex "d2b48c" |> CssColor
    let thistle = Utilities.Color.hex "d8bfd8" |> CssColor
    let tomato = Utilities.Color.hex "ff6347" |> CssColor
    let turquoise = Utilities.Color.hex "40e0d0" |> CssColor
    let violet = Utilities.Color.hex "ee82ee" |> CssColor
    let wheat = Utilities.Color.hex "f5deb3" |> CssColor
    let whiteSmoke = Utilities.Color.hex "f5f5f5" |> CssColor
    let yellowGreen = Utilities.Color.hex "9acd32" |> CssColor
    let rebeccaPurple = Utilities.Color.hex "663399" |> CssColor
    let transparent = Utilities.Color.rgba 0 0 0 0.0 |> CssColor
    let currentColor = "currentColor" |> CssColor