namespace src

open Fable.Core
open Fable.Core.JsInterop

module Arithmetic =
    let add x y = x + y
    let multiply x y = x * y
    let divide x y = x / y
    let subtract x y = x - y

module Helper =
    let rgb r g b = sprintf "rgb(%d, %d, %d)" r g b
    let hex value = sprintf "#%s" value

module Color =
    type Color = Color of string

    let rgb r g b = Helper.rgb r g b |> Color

    let hex value = Helper.hex value |> Color

    let value (Color c) = c

    let black = hex "000000"
    let silver = hex "c0c0c0"
    let gray = hex "808080"
    let white = hex "ffffff"
    let maroon = hex "800000"
    let red = hex "ff0000"
    let purple = hex "800080"
    let fuchsia = hex "ff00ff"
    let green = hex "008000"
    let lime = hex "00ff00"
    let olive = hex "808000"
    let yellow = hex "ffff00"
    let navy = hex "000080"
    let blue = hex "0000ff"
    let teal = hex "008080"
    let aqua = hex "00ffff"
    let orange = hex "ffa500"
    let aliceblue = hex "f0f8ff"
    let antiquewhite = hex "faebd7"
    let aquamarine = hex "7fffd4"
    let azure = hex "f0ffff"
    let beige = hex "f5f5dc"
    let bisque = hex "ffe4c4"
    let blanchedalmond = hex "ffebcd"
    let blueviolet = hex "8a2be2"
    let brown = hex "a52a2a"
    let burlywood = hex "deb887"
    let cadetblue = hex "5f9ea0"
    let chartreuse = hex "7fff00"
    let chocolate = hex "d2691e"
    let coral = hex "ff7f50"
    let cornflowerblue = hex "6495ed"
    let cornsilk = hex "fff8dc"
    let crimson = hex "dc143c"
    let cyan = hex "00ffff"
    let darkblue = hex "00008b"
    let darkcyan = hex "008b8b"
    let darkgoldenrod = hex "b8860b"
    let darkgray = hex "a9a9a9"
    let darkgreen = hex "006400"
    let darkgrey = hex "a9a9a9"
    let darkkhaki = hex "bdb76b"
    let darkmagenta = hex "8b008b"
    let darkolivegreen = hex "556b2f"
    let darkorange = hex "ff8c00"
    let darkorchid = hex "9932cc"
    let darkred = hex "8b0000"
    let darksalmon = hex "e9967a"
    let darkseagreen = hex "8fbc8f"
    let darkslateblue = hex "483d8b"
    let darkslategray = hex "2f4f4f"
    let darkturquoise = hex "00ced1"
    let darkviolet = hex "9400d3"
    let deeppink = hex "ff1493"
    let deepskyblue = hex "00bfff"
    let dimgrey = hex "696969"
    let dodgerblue = hex "1e90ff"
    let firebrick = hex "b22222"
    let floralwhite = hex "fffaf0"
    let forestgreen = hex "228b22"
    let gainsboro = hex "dcdcdc"
    let ghostwhite = hex "f8f8ff"
    let gold = hex "ffd700"
    let goldenrod = hex "daa520"
    let greenyellow = hex "adff2f"
    let grey = hex "808080"
    let honeydew = hex "f0fff0"
    let hotpink = hex "ff69b4"
    let indianred = hex "cd5c5c"
    let indigo = hex "4b0082"
    let ivory = hex "fffff0"
    let khaki = hex "f0e68c"
    let lavender = hex "e6e6fa"
    let lavenderblush = hex "fff0f5"
    let lawngreen = hex "7cfc00"
    let lemonchiffon = hex "fffacd"
    let lightblue = hex "add8e6"
    let lightcoral = hex "f08080"
    let lightcyan = hex "e0ffff"
    let lightgoldenrodyellow = hex "fafad2"
    let lightgray = hex "d3d3d3"
    let lightgreen = hex "90ee90"
    let lightgrey = hex "d3d3d3"
    let lightpink = hex "ffb6c1"
    let lightsalmon = hex "ffa07a"
    let lightseagreen = hex "20b2aa"
    let lightskyblue = hex "87cefa"
    let lightslategray = hex "778899"
    let lightslategrey = hex "778899"
    let lightsteelblue = hex "b0c4de"
    let lightyellow = hex "ffffe0"
    let limegreen = hex "32cd32"
    let linen = hex "faf0e6"
    let magenta = hex "ff00ff"
    let mediumaquamarine = hex "66cdaa"
    let mediumblue = hex "0000cd"
    let mediumorchid = hex "ba55d3"
    let mediumpurple = hex "9370db"
    let mediumseagreen = hex "3cb371"
    let mediumslateblue = hex "7b68ee"
    let mediumspringgreen = hex "00fa9a"
    let mediumturquoise = hex "48d1cc"
    let mediumvioletred = hex "c71585"
    let midnightblue = hex "191970"
    let mintcream = hex "f5fffa"
    let mistyrose = hex "ffe4e1"
    let moccasin = hex "ffe4b5"
    let navajowhite = hex "ffdead"
    let oldlace = hex "fdf5e6"
    let olivedrab = hex "6b8e23"
    let orangered = hex "ff4500"
    let orchid = hex "da70d6"
    let palegoldenrod = hex "eee8aa"
    let palegreen = hex "98fb98"
    let paleturquoise = hex "afeeee"
    let palevioletred = hex "db7093"
    let papayawhip = hex "ffefd5"
    let peachpuff = hex "ffdab9"
    let peru = hex "cd853f"
    let pink = hex "ffc0cb"
    let plum = hex "dda0dd"
    let powderblue = hex "b0e0e6"
    let rosybrown = hex "bc8f8f"
    let royalblue = hex "4169e1"
    let saddlebrown = hex "8b4513"
    let salmon = hex "fa8072"
    let sandybrown = hex "f4a460"
    let seagreen = hex "2e8b57"
    let seashell = hex "fff5ee"
    let sienna = hex "a0522d"
    let skyblue = hex "87ceeb"
    let slateblue = hex "6a5acd"
    let slategray = hex "708090"
    let slategrey = hex "708090"
    let snow = hex "fffafa"
    let springgreen = hex "00ff7f"
    let steelblue = hex "4682b4"
    let tan = hex "d2b48c"
    let thistle = hex "d8bfd8"
    let tomato = hex "ff6347"
    let turquoise = hex "40e0d0"
    let violet = hex "ee82ee"
    let wheat = hex "f5deb3"
    let whitesmoke = hex "f5f5f5"
    let yellowgreen = hex "9acd32"
    let rebeccapurple = hex "663399"

module test =
    [<Import("css", from="glamor")>]
    let private glamorCss(x) = jsNative
    let private glamorCss' x = glamorCss(x) 

    open Color

    type CSSAttribute =
        | Color of Color
        | BackgroundColor of Color
        | Hover of CSSAttribute list

    let rec fss (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
            | Color c -> "color" ==> value c
            | BackgroundColor bc -> "background-color" ==> value bc
            | Hover h -> ":hover" ==> fss h)
        |> createObj
        |> glamorCss'