namespace Fss

module ColorTypes =
    type ColorAdjust =
        | Economy
        | Exact

[<AutoOpen>]
module Color =
    open ColorTypes
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = PropertyValue.cssValue Property.ColorAdjust value
    let private colorAdjustCssValue' (value: ColorAdjust) =
        value
        |> Utilities.Helpers.duToLowercase
        |> colorAdjustCssValue

    type ColorAdjust =
        static member Value (adjust: ColorTypes.ColorAdjust) = adjust |> colorAdjustCssValue'
        static member Economy = Economy |> colorAdjustCssValue'
        static member Exact = Exact |> colorAdjustCssValue'

    let ColorAdjust' (adjust: ColorTypes.ColorAdjust) = adjust |> ColorAdjust.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue value = PropertyValue.cssValue Property.Color value
    type Color =
        static member black = colorCssValue <| CSSColorValue.color CSSColor.black
        static member silver = colorCssValue <| CSSColorValue.color CSSColor.silver
        static member gray = colorCssValue <| CSSColorValue.color CSSColor.gray
        static member white = colorCssValue <| CSSColorValue.color CSSColor.white
        static member maroon = colorCssValue <| CSSColorValue.color CSSColor.maroon
        static member red = colorCssValue <| CSSColorValue.color CSSColor.red
        static member purple = colorCssValue <| CSSColorValue.color CSSColor.purple
        static member fuchsia = colorCssValue <| CSSColorValue.color CSSColor.fuchsia
        static member green = colorCssValue <| CSSColorValue.color CSSColor.green
        static member lime = colorCssValue <| CSSColorValue.color CSSColor.lime
        static member olive = colorCssValue <| CSSColorValue.color CSSColor.olive
        static member yellow = colorCssValue <| CSSColorValue.color CSSColor.yellow
        static member navy = colorCssValue <| CSSColorValue.color CSSColor.navy
        static member blue = colorCssValue <| CSSColorValue.color CSSColor.blue
        static member teal = colorCssValue <| CSSColorValue.color CSSColor.teal
        static member aqua = colorCssValue <| CSSColorValue.color CSSColor.aqua
        static member orange = colorCssValue <| CSSColorValue.color CSSColor.orange
        static member aliceBlue = colorCssValue <| CSSColorValue.color CSSColor.aliceBlue
        static member antiqueWhite = colorCssValue <| CSSColorValue.color CSSColor.antiqueWhite
        static member aquaMarine = colorCssValue <| CSSColorValue.color CSSColor.aquaMarine
        static member azure = colorCssValue <| CSSColorValue.color CSSColor.azure
        static member beige = colorCssValue <| CSSColorValue.color CSSColor.beige
        static member bisque = colorCssValue <| CSSColorValue.color CSSColor.bisque
        static member blanchedAlmond = colorCssValue <| CSSColorValue.color CSSColor.blanchedAlmond
        static member blueViolet = colorCssValue <| CSSColorValue.color CSSColor.blueViolet
        static member brown = colorCssValue <| CSSColorValue.color CSSColor.brown
        static member burlywood = colorCssValue <| CSSColorValue.color CSSColor.burlywood
        static member cadetBlue = colorCssValue <| CSSColorValue.color CSSColor.cadetBlue
        static member chartreuse = colorCssValue <| CSSColorValue.color CSSColor.chartreuse
        static member chocolate = colorCssValue <| CSSColorValue.color CSSColor.chocolate
        static member coral = colorCssValue <| CSSColorValue.color CSSColor.coral
        static member cornflowerBlue = colorCssValue <| CSSColorValue.color CSSColor.cornflowerBlue
        static member cornsilk = colorCssValue <| CSSColorValue.color CSSColor.cornsilk
        static member crimson = colorCssValue <| CSSColorValue.color CSSColor.crimson
        static member cyan = colorCssValue <| CSSColorValue.color CSSColor.cyan
        static member darkBlue = colorCssValue <| CSSColorValue.color CSSColor.darkBlue
        static member darkCyan = colorCssValue <| CSSColorValue.color CSSColor.darkCyan
        static member darkGoldenrod = colorCssValue <| CSSColorValue.color CSSColor.darkGoldenrod
        static member darkGray = colorCssValue <| CSSColorValue.color CSSColor.darkGray
        static member darkGreen = colorCssValue <| CSSColorValue.color CSSColor.darkGreen
        static member darkKhaki = colorCssValue <| CSSColorValue.color CSSColor.darkKhaki
        static member darkMagenta = colorCssValue <| CSSColorValue.color CSSColor.darkMagenta
        static member darkOliveGreen = colorCssValue <| CSSColorValue.color CSSColor.darkOliveGreen
        static member darkOrange = colorCssValue <| CSSColorValue.color CSSColor.darkOrange
        static member darkOrchid = colorCssValue <| CSSColorValue.color CSSColor.darkOrchid
        static member darkRed = colorCssValue <| CSSColorValue.color CSSColor.darkRed
        static member darkSalmon = colorCssValue <| CSSColorValue.color CSSColor.darkSalmon
        static member darkSeaGreen = colorCssValue <| CSSColorValue.color CSSColor.darkSeaGreen
        static member darkSlateBlue = colorCssValue <| CSSColorValue.color CSSColor.darkSlateBlue
        static member darkSlateGray = colorCssValue <| CSSColorValue.color CSSColor.darkSlateGray
        static member darkTurquoise = colorCssValue <| CSSColorValue.color CSSColor.darkTurquoise
        static member darkViolet = colorCssValue <| CSSColorValue.color CSSColor.darkViolet
        static member deepPink = colorCssValue <| CSSColorValue.color CSSColor.deepPink
        static member deepSkyBlue = colorCssValue <| CSSColorValue.color CSSColor.deepSkyBlue
        static member dimGrey = colorCssValue <| CSSColorValue.color CSSColor.dimGrey
        static member dodgerBlue = colorCssValue <| CSSColorValue.color CSSColor.dodgerBlue
        static member fireBrick = colorCssValue <| CSSColorValue.color CSSColor.fireBrick
        static member floralWhite = colorCssValue <| CSSColorValue.color CSSColor.floralWhite
        static member forestGreen = colorCssValue <| CSSColorValue.color CSSColor.forestGreen
        static member gainsboro = colorCssValue <| CSSColorValue.color CSSColor.gainsboro
        static member ghostWhite = colorCssValue <| CSSColorValue.color CSSColor.ghostWhite
        static member gold = colorCssValue <| CSSColorValue.color CSSColor.gold
        static member goldenrod = colorCssValue <| CSSColorValue.color CSSColor.goldenrod
        static member greenYellow = colorCssValue <| CSSColorValue.color CSSColor.greenYellow
        static member grey = colorCssValue <| CSSColorValue.color CSSColor.grey
        static member honeydew = colorCssValue <| CSSColorValue.color CSSColor.honeydew
        static member hotPink = colorCssValue <| CSSColorValue.color CSSColor.hotPink
        static member indianRed = colorCssValue <| CSSColorValue.color CSSColor.indianRed
        static member indigo = colorCssValue <| CSSColorValue.color CSSColor.indigo
        static member ivory = colorCssValue <| CSSColorValue.color CSSColor.ivory
        static member khaki = colorCssValue <| CSSColorValue.color CSSColor.khaki
        static member lavender = colorCssValue <| CSSColorValue.color CSSColor.lavender
        static member lavenderBlush = colorCssValue <| CSSColorValue.color CSSColor.lavenderBlush
        static member lawnGreen = colorCssValue <| CSSColorValue.color CSSColor.lawnGreen
        static member lemonChiffon = colorCssValue <| CSSColorValue.color CSSColor.lemonChiffon
        static member lightBlue = colorCssValue <| CSSColorValue.color CSSColor.lightBlue
        static member lightCoral = colorCssValue <| CSSColorValue.color CSSColor.lightCoral
        static member lightCyan = colorCssValue <| CSSColorValue.color CSSColor.lightCyan
        static member lightGoldenrodYellow = colorCssValue <| CSSColorValue.color CSSColor.lightGoldenrodYellow
        static member lightGray = colorCssValue <| CSSColorValue.color CSSColor.lightGray
        static member lightGreen = colorCssValue <| CSSColorValue.color CSSColor.lightGreen
        static member lightGrey = colorCssValue <| CSSColorValue.color CSSColor.lightGrey
        static member lightPink = colorCssValue <| CSSColorValue.color CSSColor.lightPink
        static member lightSalmon = colorCssValue <| CSSColorValue.color CSSColor.lightSalmon
        static member lightSeaGreen = colorCssValue <| CSSColorValue.color CSSColor.lightSeaGreen
        static member lightSkyBlue = colorCssValue <| CSSColorValue.color CSSColor.lightSkyBlue
        static member lightSlateGrey = colorCssValue <| CSSColorValue.color CSSColor.lightSlateGrey
        static member lightSteelBlue = colorCssValue <| CSSColorValue.color CSSColor.lightSteelBlue
        static member lightYellow = colorCssValue <| CSSColorValue.color CSSColor.lightYellow
        static member limeGreen = colorCssValue <| CSSColorValue.color CSSColor.limeGreen
        static member linen = colorCssValue <| CSSColorValue.color CSSColor.linen
        static member magenta = colorCssValue <| CSSColorValue.color CSSColor.magenta
        static member mediumAquamarine = colorCssValue <| CSSColorValue.color CSSColor.mediumAquamarine
        static member mediumBlue = colorCssValue <| CSSColorValue.color CSSColor.mediumBlue
        static member mediumOrchid = colorCssValue <| CSSColorValue.color CSSColor.mediumOrchid
        static member mediumPurple = colorCssValue <| CSSColorValue.color CSSColor.mediumPurple
        static member mediumSeaGreen = colorCssValue <| CSSColorValue.color CSSColor.mediumSeaGreen
        static member mediumSlateBlue = colorCssValue <| CSSColorValue.color CSSColor.mediumSlateBlue
        static member mediumSpringGreen = colorCssValue <| CSSColorValue.color CSSColor.mediumSpringGreen
        static member mediumTurquoise = colorCssValue <| CSSColorValue.color CSSColor.mediumTurquoise
        static member mediumVioletRed = colorCssValue <| CSSColorValue.color CSSColor.mediumVioletRed
        static member midnightBlue = colorCssValue <| CSSColorValue.color CSSColor.midnightBlue
        static member mintCream = colorCssValue <| CSSColorValue.color CSSColor.mintCream
        static member mistyRose = colorCssValue <| CSSColorValue.color CSSColor.mistyRose
        static member moccasin = colorCssValue <| CSSColorValue.color CSSColor.moccasin
        static member navajoWhite = colorCssValue <| CSSColorValue.color CSSColor.navajoWhite
        static member oldLace = colorCssValue <| CSSColorValue.color CSSColor.oldLace
        static member olivedrab = colorCssValue <| CSSColorValue.color CSSColor.olivedrab
        static member orangeRed = colorCssValue <| CSSColorValue.color CSSColor.orangeRed
        static member orchid = colorCssValue <| CSSColorValue.color CSSColor.orchid
        static member paleGoldenrod = colorCssValue <| CSSColorValue.color CSSColor.paleGoldenrod
        static member paleGreen = colorCssValue <| CSSColorValue.color CSSColor.paleGreen
        static member paleTurquoise = colorCssValue <| CSSColorValue.color CSSColor.paleTurquoise
        static member paleVioletred = colorCssValue <| CSSColorValue.color CSSColor.paleVioletred
        static member papayaWhip = colorCssValue <| CSSColorValue.color CSSColor.papayaWhip
        static member peachpuff = colorCssValue <| CSSColorValue.color CSSColor.peachpuff
        static member peru = colorCssValue <| CSSColorValue.color CSSColor.peru
        static member pink = colorCssValue <| CSSColorValue.color CSSColor.pink
        static member plum = colorCssValue <| CSSColorValue.color CSSColor.plum
        static member powderBlue = colorCssValue <| CSSColorValue.color CSSColor.powderBlue
        static member rosyBrown = colorCssValue <| CSSColorValue.color CSSColor.rosyBrown
        static member royalBlue = colorCssValue <| CSSColorValue.color CSSColor.royalBlue
        static member saddleBrown = colorCssValue <| CSSColorValue.color CSSColor.saddleBrown
        static member salmon = colorCssValue <| CSSColorValue.color CSSColor.salmon
        static member sandyBrown = colorCssValue <| CSSColorValue.color CSSColor.sandyBrown
        static member seaGreen = colorCssValue <| CSSColorValue.color CSSColor.seaGreen
        static member seaShell = colorCssValue <| CSSColorValue.color CSSColor.seaShell
        static member sienna = colorCssValue <| CSSColorValue.color CSSColor.sienna
        static member skyBlue = colorCssValue <| CSSColorValue.color CSSColor.skyBlue
        static member slateBlue = colorCssValue <| CSSColorValue.color CSSColor.slateBlue
        static member slateGray = colorCssValue <| CSSColorValue.color CSSColor.slateGray
        static member snow = colorCssValue <| CSSColorValue.color CSSColor.snow
        static member springGreen = colorCssValue <| CSSColorValue.color CSSColor.springGreen
        static member steelBlue = colorCssValue <| CSSColorValue.color CSSColor.steelBlue
        static member tan = colorCssValue <| CSSColorValue.color CSSColor.tan
        static member thistle = colorCssValue <| CSSColorValue.color CSSColor.thistle
        static member tomato = colorCssValue <| CSSColorValue.color CSSColor.tomato
        static member turquoise = colorCssValue <| CSSColorValue.color CSSColor.turquoise
        static member violet = colorCssValue <| CSSColorValue.color CSSColor.violet
        static member wheat = colorCssValue <| CSSColorValue.color CSSColor.wheat
        static member whiteSmoke = colorCssValue <| CSSColorValue.color CSSColor.whiteSmoke
        static member yellowGreen = colorCssValue <| CSSColorValue.color CSSColor.yellowGreen
        static member rebeccaPurple = colorCssValue <| CSSColorValue.color CSSColor.rebeccaPurple
        static member Rgb r g b =
            colorCssValue <| CSSColorValue.color (CSSColor.Rgb(r, g, b))
        static member Rgba r g b a =
            colorCssValue <| CSSColorValue.color (CSSColor.Rgba(r, g, b, a))
        static member Hex value =
            colorCssValue <| CSSColorValue.color (CSSColor.Hex value)
        static member Hsl h s l =
            colorCssValue <| CSSColorValue.color (CSSColor.Hsl(h, s, l))
        static member Hsla h s l a =
            colorCssValue <| CSSColorValue.color (CSSColor.Hsla (h, s, l, a))
        static member Value (color: CSSColor) = colorCssValue <| CSSColorValue.color color
        static member transparent = colorCssValue <| CSSColorValue.color CSSColor.transparent
        static member currentColor = colorCssValue <| CSSColorValue.color CSSColor.currentColor
        static member Revert = colorCssValue "revert"

        static member Inherit = Inherit |> GlobalValue.global' |> colorCssValue
        static member Initial = Initial |> GlobalValue.global' |> colorCssValue
        static member Unset = Unset |> GlobalValue.global' |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The CSSColor to apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: CSSColor) = Color.Value(color)

