namespace Fss

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = Types.cssValue Types.Property.ColorAdjust value
    let private colorAdjustCssValue' (value: Types.ColorAdjust) =
        value
        |> Utilities.Helpers.duToLowercase
        |> colorAdjustCssValue

    type ColorAdjust =
        static member Value (adjust: Types.ColorAdjust) = adjust |> colorAdjustCssValue'
        static member Economy = Types.Economy |> colorAdjustCssValue'
        static member Exact = Types.Exact |> colorAdjustCssValue'

    let ColorAdjust' (adjust: Types.ColorAdjust) = adjust |> ColorAdjust.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue value = Types.cssValue Types.Property.Property.Color value
    type Color =
        static member black = colorCssValue <| Types.colorToString Types.Color.black
        static member silver = colorCssValue <| Types.Color.silver
        static member gray = colorCssValue <| Types.Color.gray
        static member white = colorCssValue <| Types.Color.white
        static member maroon = colorCssValue <| Types.Color.maroon
        static member red = colorCssValue <| Types.Color.red
        static member purple = colorCssValue <| Types.Color.purple
        static member fuchsia = colorCssValue <| Types.Color.fuchsia
        static member green = colorCssValue <| Types.Color.green
        static member lime = colorCssValue <| Types.Color.lime
        static member olive = colorCssValue <| Types.Color.olive
        static member yellow = colorCssValue <| Types.Color.yellow
        static member navy = colorCssValue <| Types.Color.navy
        static member blue = colorCssValue <| Types.Color.blue
        static member teal = colorCssValue <| Types.Color.teal
        static member aqua = colorCssValue <| Types.Color.aqua
        static member orange = colorCssValue <| Types.Color.orange
        static member aliceBlue = colorCssValue <| Types.Color.aliceBlue
        static member antiqueWhite = colorCssValue <| Types.Color.antiqueWhite
        static member aquaMarine = colorCssValue <| Types.Color.aquaMarine
        static member azure = colorCssValue <| Types.Color.azure
        static member beige = colorCssValue <| Types.Color.beige
        static member bisque = colorCssValue <| Types.Color.bisque
        static member blanchedAlmond = colorCssValue <| Types.Color.blanchedAlmond
        static member blueViolet = colorCssValue <| Types.Color.blueViolet
        static member brown = colorCssValue <| Types.Color.brown
        static member burlywood = colorCssValue <| Types.Color.burlywood
        static member cadetBlue = colorCssValue <| Types.Color.cadetBlue
        static member chartreuse = colorCssValue <| Types.Color.chartreuse
        static member chocolate = colorCssValue <| Types.Color.chocolate
        static member coral = colorCssValue <| Types.Color.coral
        static member cornflowerBlue = colorCssValue <| Types.Color.cornflowerBlue
        static member cornsilk = colorCssValue <| Types.Color.cornsilk
        static member crimson = colorCssValue <| Types.Color.crimson
        static member cyan = colorCssValue <| Types.Color.cyan
        static member darkBlue = colorCssValue <| Types.Color.darkBlue
        static member darkCyan = colorCssValue <| Types.Color.darkCyan
        static member darkGoldenrod = colorCssValue <| Types.Color.darkGoldenrod
        static member darkGray = colorCssValue <| Types.Color.darkGray
        static member darkGreen = colorCssValue <| Types.Color.darkGreen
        static member darkKhaki = colorCssValue <| Types.Color.darkKhaki
        static member darkMagenta = colorCssValue <| Types.Color.darkMagenta
        static member darkOliveGreen = colorCssValue <| Types.Color.darkOliveGreen
        static member darkOrange = colorCssValue <| Types.Color.darkOrange
        static member darkOrchid = colorCssValue <| Types.Color.darkOrchid
        static member darkRed = colorCssValue <| Types.Color.darkRed
        static member darkSalmon = colorCssValue <| Types.Color.darkSalmon
        static member darkSeaGreen = colorCssValue <| Types.Color.darkSeaGreen
        static member darkSlateBlue = colorCssValue <| Types.Color.darkSlateBlue
        static member darkSlateGray = colorCssValue <| Types.Color.darkSlateGray
        static member darkTurquoise = colorCssValue <| Types.Color.darkTurquoise
        static member darkViolet = colorCssValue <| Types.Color.darkViolet
        static member deepPink = colorCssValue <| Types.Color.deepPink
        static member deepSkyBlue = colorCssValue <| Types.Color.deepSkyBlue
        static member dimGrey = colorCssValue <| Types.Color.dimGrey
        static member dodgerBlue = colorCssValue <| Types.Color.dodgerBlue
        static member fireBrick = colorCssValue <| Types.Color.fireBrick
        static member floralWhite = colorCssValue <| Types.Color.floralWhite
        static member forestGreen = colorCssValue <| Types.Color.forestGreen
        static member gainsboro = colorCssValue <| Types.Color.gainsboro
        static member ghostWhite = colorCssValue <| Types.Color.ghostWhite
        static member gold = colorCssValue <| Types.Color.gold
        static member goldenrod = colorCssValue <| Types.Color.goldenrod
        static member greenYellow = colorCssValue <| Types.Color.greenYellow
        static member grey = colorCssValue <| Types.Color.grey
        static member honeydew = colorCssValue <| Types.Color.honeydew
        static member hotPink = colorCssValue <| Types.Color.hotPink
        static member indianRed = colorCssValue <| Types.Color.indianRed
        static member indigo = colorCssValue <| Types.Color.indigo
        static member ivory = colorCssValue <| Types.Color.ivory
        static member khaki = colorCssValue <| Types.Color.khaki
        static member lavender = colorCssValue <| Types.Color.lavender
        static member lavenderBlush = colorCssValue <| Types.Color.lavenderBlush
        static member lawnGreen = colorCssValue <| Types.Color.lawnGreen
        static member lemonChiffon = colorCssValue <| Types.Color.lemonChiffon
        static member lightBlue = colorCssValue <| Types.Color.lightBlue
        static member lightCoral = colorCssValue <| Types.Color.lightCoral
        static member lightCyan = colorCssValue <| Types.Color.lightCyan
        static member lightGoldenrodYellow = colorCssValue <| Types.Color.lightGoldenrodYellow
        static member lightGray = colorCssValue <| Types.Color.lightGray
        static member lightGreen = colorCssValue <| Types.Color.lightGreen
        static member lightGrey = colorCssValue <| Types.Color.lightGrey
        static member lightPink = colorCssValue <| Types.Color.lightPink
        static member lightSalmon = colorCssValue <| Types.Color.lightSalmon
        static member lightSeaGreen = colorCssValue <| Types.Color.lightSeaGreen
        static member lightSkyBlue = colorCssValue <| Types.Color.lightSkyBlue
        static member lightSlateGrey = colorCssValue <| Types.Color.lightSlateGrey
        static member lightSteelBlue = colorCssValue <| Types.Color.lightSteelBlue
        static member lightYellow = colorCssValue <| Types.Color.lightYellow
        static member limeGreen = colorCssValue <| Types.Color.limeGreen
        static member linen = colorCssValue <| Types.Color.linen
        static member magenta = colorCssValue <| Types.Color.magenta
        static member mediumAquamarine = colorCssValue <| Types.Color.mediumAquamarine
        static member mediumBlue = colorCssValue <| Types.Color.mediumBlue
        static member mediumOrchid = colorCssValue <| Types.Color.mediumOrchid
        static member mediumPurple = colorCssValue <| Types.Color.mediumPurple
        static member mediumSeaGreen = colorCssValue <| Types.Color.mediumSeaGreen
        static member mediumSlateBlue = colorCssValue <| Types.Color.mediumSlateBlue
        static member mediumSpringGreen = colorCssValue <| Types.Color.mediumSpringGreen
        static member mediumTurquoise = colorCssValue <| Types.Color.mediumTurquoise
        static member mediumVioletRed = colorCssValue <| Types.Color.mediumVioletRed
        static member midnightBlue = colorCssValue <| Types.Color.midnightBlue
        static member mintCream = colorCssValue <| Types.Color.mintCream
        static member mistyRose = colorCssValue <| Types.Color.mistyRose
        static member moccasin = colorCssValue <| Types.Color.moccasin
        static member navajoWhite = colorCssValue <| Types.Color.navajoWhite
        static member oldLace = colorCssValue <| Types.Color.oldLace
        static member olivedrab = colorCssValue <| Types.Color.olivedrab
        static member orangeRed = colorCssValue <| Types.Color.orangeRed
        static member orchid = colorCssValue <| Types.Color.orchid
        static member paleGoldenrod = colorCssValue <| Types.Color.paleGoldenrod
        static member paleGreen = colorCssValue <| Types.Color.paleGreen
        static member paleTurquoise = colorCssValue <| Types.Color.paleTurquoise
        static member paleVioletred = colorCssValue <| Types.Color.paleVioletred
        static member papayaWhip = colorCssValue <| Types.Color.papayaWhip
        static member peachpuff = colorCssValue <| Types.Color.peachpuff
        static member peru = colorCssValue <| Types.Color.peru
        static member pink = colorCssValue <| Types.Color.pink
        static member plum = colorCssValue <| Types.Color.plum
        static member powderBlue = colorCssValue <| Types.Color.powderBlue
        static member rosyBrown = colorCssValue <| Types.Color.rosyBrown
        static member royalBlue = colorCssValue <| Types.Color.royalBlue
        static member saddleBrown = colorCssValue <| Types.Color.saddleBrown
        static member salmon = colorCssValue <| Types.Color.salmon
        static member sandyBrown = colorCssValue <| Types.Color.sandyBrown
        static member seaGreen = colorCssValue <| Types.Color.seaGreen
        static member seaShell = colorCssValue <| Types.Color.seaShell
        static member sienna = colorCssValue <| Types.Color.sienna
        static member skyBlue = colorCssValue <| Types.Color.skyBlue
        static member slateBlue = colorCssValue <| Types.Color.slateBlue
        static member slateGray = colorCssValue <| Types.Color.slateGray
        static member snow = colorCssValue <| Types.Color.snow
        static member springGreen = colorCssValue <| Types.Color.springGreen
        static member steelBlue = colorCssValue <| Types.Color.steelBlue
        static member tan = colorCssValue <| Types.Color.tan
        static member thistle = colorCssValue <| Types.Color.thistle
        static member tomato = colorCssValue <| Types.Color.tomato
        static member turquoise = colorCssValue <| Types.Color.turquoise
        static member violet = colorCssValue <| Types.Color.violet
        static member wheat = colorCssValue <| Types.Color.wheat
        static member whiteSmoke = colorCssValue <| Types.Color.whiteSmoke
        static member yellowGreen = colorCssValue <| Types.Color.yellowGreen
        static member rebeccaPurple = colorCssValue <| Types.Color.rebeccaPurple
        static member Rgb r g b =
            colorCssValue <| Types.Color.Rgb(r, g, b)
        static member Rgba r g b a =
            colorCssValue <| Types.Color.Rgba(r, g, b, a)
        static member Hex value =
            colorCssValue <| Types.Color.Hex value
        static member Hsl h s l =
            colorCssValue <| Types.Color.Hsl(h, s, l)
        static member Hsla h s l a =
            colorCssValue <| Types.Color.Hsla (h, s, l, a)
        static member Value (color: Types.Color) = colorCssValue <| Types.colorToString color
        static member transparent = colorCssValue <| Types.Color.transparent
        static member currentColor = colorCssValue <| Types.Color.currentColor
        static member Revert = colorCssValue "revert"

        static member Inherit = Types.Inherit |> Types.keywordsToString |> colorCssValue
        static member Initial = Types.Initial |> Types.keywordsToString |> colorCssValue
        static member Unset = Types.Unset |> Types.keywordsToString |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The Types.Color to apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: Types.Color) = Color.Value(color)

