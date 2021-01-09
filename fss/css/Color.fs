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
        static member black = colorCssValue <| CSSColorValue.color CssColor.black
        static member silver = colorCssValue <| CSSColorValue.color CssColor.silver
        static member gray = colorCssValue <| CSSColorValue.color CssColor.gray
        static member white = colorCssValue <| CSSColorValue.color CssColor.white
        static member maroon = colorCssValue <| CSSColorValue.color CssColor.maroon
        static member red = colorCssValue <| CSSColorValue.color CssColor.red
        static member purple = colorCssValue <| CSSColorValue.color CssColor.purple
        static member fuchsia = colorCssValue <| CSSColorValue.color CssColor.fuchsia
        static member green = colorCssValue <| CSSColorValue.color CssColor.green
        static member lime = colorCssValue <| CSSColorValue.color CssColor.lime
        static member olive = colorCssValue <| CSSColorValue.color CssColor.olive
        static member yellow = colorCssValue <| CSSColorValue.color CssColor.yellow
        static member navy = colorCssValue <| CSSColorValue.color CssColor.navy
        static member blue = colorCssValue <| CSSColorValue.color CssColor.blue
        static member teal = colorCssValue <| CSSColorValue.color CssColor.teal
        static member aqua = colorCssValue <| CSSColorValue.color CssColor.aqua
        static member orange = colorCssValue <| CSSColorValue.color CssColor.orange
        static member aliceBlue = colorCssValue <| CSSColorValue.color CssColor.aliceBlue
        static member antiqueWhite = colorCssValue <| CSSColorValue.color CssColor.antiqueWhite
        static member aquaMarine = colorCssValue <| CSSColorValue.color CssColor.aquaMarine
        static member azure = colorCssValue <| CSSColorValue.color CssColor.azure
        static member beige = colorCssValue <| CSSColorValue.color CssColor.beige
        static member bisque = colorCssValue <| CSSColorValue.color CssColor.bisque
        static member blanchedAlmond = colorCssValue <| CSSColorValue.color CssColor.blanchedAlmond
        static member blueViolet = colorCssValue <| CSSColorValue.color CssColor.blueViolet
        static member brown = colorCssValue <| CSSColorValue.color CssColor.brown
        static member burlywood = colorCssValue <| CSSColorValue.color CssColor.burlywood
        static member cadetBlue = colorCssValue <| CSSColorValue.color CssColor.cadetBlue
        static member chartreuse = colorCssValue <| CSSColorValue.color CssColor.chartreuse
        static member chocolate = colorCssValue <| CSSColorValue.color CssColor.chocolate
        static member coral = colorCssValue <| CSSColorValue.color CssColor.coral
        static member cornflowerBlue = colorCssValue <| CSSColorValue.color CssColor.cornflowerBlue
        static member cornsilk = colorCssValue <| CSSColorValue.color CssColor.cornsilk
        static member crimson = colorCssValue <| CSSColorValue.color CssColor.crimson
        static member cyan = colorCssValue <| CSSColorValue.color CssColor.cyan
        static member darkBlue = colorCssValue <| CSSColorValue.color CssColor.darkBlue
        static member darkCyan = colorCssValue <| CSSColorValue.color CssColor.darkCyan
        static member darkGoldenrod = colorCssValue <| CSSColorValue.color CssColor.darkGoldenrod
        static member darkGray = colorCssValue <| CSSColorValue.color CssColor.darkGray
        static member darkGreen = colorCssValue <| CSSColorValue.color CssColor.darkGreen
        static member darkKhaki = colorCssValue <| CSSColorValue.color CssColor.darkKhaki
        static member darkMagenta = colorCssValue <| CSSColorValue.color CssColor.darkMagenta
        static member darkOliveGreen = colorCssValue <| CSSColorValue.color CssColor.darkOliveGreen
        static member darkOrange = colorCssValue <| CSSColorValue.color CssColor.darkOrange
        static member darkOrchid = colorCssValue <| CSSColorValue.color CssColor.darkOrchid
        static member darkRed = colorCssValue <| CSSColorValue.color CssColor.darkRed
        static member darkSalmon = colorCssValue <| CSSColorValue.color CssColor.darkSalmon
        static member darkSeaGreen = colorCssValue <| CSSColorValue.color CssColor.darkSeaGreen
        static member darkSlateBlue = colorCssValue <| CSSColorValue.color CssColor.darkSlateBlue
        static member darkSlateGray = colorCssValue <| CSSColorValue.color CssColor.darkSlateGray
        static member darkTurquoise = colorCssValue <| CSSColorValue.color CssColor.darkTurquoise
        static member darkViolet = colorCssValue <| CSSColorValue.color CssColor.darkViolet
        static member deepPink = colorCssValue <| CSSColorValue.color CssColor.deepPink
        static member deepSkyBlue = colorCssValue <| CSSColorValue.color CssColor.deepSkyBlue
        static member dimGrey = colorCssValue <| CSSColorValue.color CssColor.dimGrey
        static member dodgerBlue = colorCssValue <| CSSColorValue.color CssColor.dodgerBlue
        static member fireBrick = colorCssValue <| CSSColorValue.color CssColor.fireBrick
        static member floralWhite = colorCssValue <| CSSColorValue.color CssColor.floralWhite
        static member forestGreen = colorCssValue <| CSSColorValue.color CssColor.forestGreen
        static member gainsboro = colorCssValue <| CSSColorValue.color CssColor.gainsboro
        static member ghostWhite = colorCssValue <| CSSColorValue.color CssColor.ghostWhite
        static member gold = colorCssValue <| CSSColorValue.color CssColor.gold
        static member goldenrod = colorCssValue <| CSSColorValue.color CssColor.goldenrod
        static member greenYellow = colorCssValue <| CSSColorValue.color CssColor.greenYellow
        static member grey = colorCssValue <| CSSColorValue.color CssColor.grey
        static member honeydew = colorCssValue <| CSSColorValue.color CssColor.honeydew
        static member hotPink = colorCssValue <| CSSColorValue.color CssColor.hotPink
        static member indianRed = colorCssValue <| CSSColorValue.color CssColor.indianRed
        static member indigo = colorCssValue <| CSSColorValue.color CssColor.indigo
        static member ivory = colorCssValue <| CSSColorValue.color CssColor.ivory
        static member khaki = colorCssValue <| CSSColorValue.color CssColor.khaki
        static member lavender = colorCssValue <| CSSColorValue.color CssColor.lavender
        static member lavenderBlush = colorCssValue <| CSSColorValue.color CssColor.lavenderBlush
        static member lawnGreen = colorCssValue <| CSSColorValue.color CssColor.lawnGreen
        static member lemonChiffon = colorCssValue <| CSSColorValue.color CssColor.lemonChiffon
        static member lightBlue = colorCssValue <| CSSColorValue.color CssColor.lightBlue
        static member lightCoral = colorCssValue <| CSSColorValue.color CssColor.lightCoral
        static member lightCyan = colorCssValue <| CSSColorValue.color CssColor.lightCyan
        static member lightGoldenrodYellow = colorCssValue <| CSSColorValue.color CssColor.lightGoldenrodYellow
        static member lightGray = colorCssValue <| CSSColorValue.color CssColor.lightGray
        static member lightGreen = colorCssValue <| CSSColorValue.color CssColor.lightGreen
        static member lightGrey = colorCssValue <| CSSColorValue.color CssColor.lightGrey
        static member lightPink = colorCssValue <| CSSColorValue.color CssColor.lightPink
        static member lightSalmon = colorCssValue <| CSSColorValue.color CssColor.lightSalmon
        static member lightSeaGreen = colorCssValue <| CSSColorValue.color CssColor.lightSeaGreen
        static member lightSkyBlue = colorCssValue <| CSSColorValue.color CssColor.lightSkyBlue
        static member lightSlateGrey = colorCssValue <| CSSColorValue.color CssColor.lightSlateGrey
        static member lightSteelBlue = colorCssValue <| CSSColorValue.color CssColor.lightSteelBlue
        static member lightYellow = colorCssValue <| CSSColorValue.color CssColor.lightYellow
        static member limeGreen = colorCssValue <| CSSColorValue.color CssColor.limeGreen
        static member linen = colorCssValue <| CSSColorValue.color CssColor.linen
        static member magenta = colorCssValue <| CSSColorValue.color CssColor.magenta
        static member mediumAquamarine = colorCssValue <| CSSColorValue.color CssColor.mediumAquamarine
        static member mediumBlue = colorCssValue <| CSSColorValue.color CssColor.mediumBlue
        static member mediumOrchid = colorCssValue <| CSSColorValue.color CssColor.mediumOrchid
        static member mediumPurple = colorCssValue <| CSSColorValue.color CssColor.mediumPurple
        static member mediumSeaGreen = colorCssValue <| CSSColorValue.color CssColor.mediumSeaGreen
        static member mediumSlateBlue = colorCssValue <| CSSColorValue.color CssColor.mediumSlateBlue
        static member mediumSpringGreen = colorCssValue <| CSSColorValue.color CssColor.mediumSpringGreen
        static member mediumTurquoise = colorCssValue <| CSSColorValue.color CssColor.mediumTurquoise
        static member mediumVioletRed = colorCssValue <| CSSColorValue.color CssColor.mediumVioletRed
        static member midnightBlue = colorCssValue <| CSSColorValue.color CssColor.midnightBlue
        static member mintCream = colorCssValue <| CSSColorValue.color CssColor.mintCream
        static member mistyRose = colorCssValue <| CSSColorValue.color CssColor.mistyRose
        static member moccasin = colorCssValue <| CSSColorValue.color CssColor.moccasin
        static member navajoWhite = colorCssValue <| CSSColorValue.color CssColor.navajoWhite
        static member oldLace = colorCssValue <| CSSColorValue.color CssColor.oldLace
        static member olivedrab = colorCssValue <| CSSColorValue.color CssColor.olivedrab
        static member orangeRed = colorCssValue <| CSSColorValue.color CssColor.orangeRed
        static member orchid = colorCssValue <| CSSColorValue.color CssColor.orchid
        static member paleGoldenrod = colorCssValue <| CSSColorValue.color CssColor.paleGoldenrod
        static member paleGreen = colorCssValue <| CSSColorValue.color CssColor.paleGreen
        static member paleTurquoise = colorCssValue <| CSSColorValue.color CssColor.paleTurquoise
        static member paleVioletred = colorCssValue <| CSSColorValue.color CssColor.paleVioletred
        static member papayaWhip = colorCssValue <| CSSColorValue.color CssColor.papayaWhip
        static member peachpuff = colorCssValue <| CSSColorValue.color CssColor.peachpuff
        static member peru = colorCssValue <| CSSColorValue.color CssColor.peru
        static member pink = colorCssValue <| CSSColorValue.color CssColor.pink
        static member plum = colorCssValue <| CSSColorValue.color CssColor.plum
        static member powderBlue = colorCssValue <| CSSColorValue.color CssColor.powderBlue
        static member rosyBrown = colorCssValue <| CSSColorValue.color CssColor.rosyBrown
        static member royalBlue = colorCssValue <| CSSColorValue.color CssColor.royalBlue
        static member saddleBrown = colorCssValue <| CSSColorValue.color CssColor.saddleBrown
        static member salmon = colorCssValue <| CSSColorValue.color CssColor.salmon
        static member sandyBrown = colorCssValue <| CSSColorValue.color CssColor.sandyBrown
        static member seaGreen = colorCssValue <| CSSColorValue.color CssColor.seaGreen
        static member seaShell = colorCssValue <| CSSColorValue.color CssColor.seaShell
        static member sienna = colorCssValue <| CSSColorValue.color CssColor.sienna
        static member skyBlue = colorCssValue <| CSSColorValue.color CssColor.skyBlue
        static member slateBlue = colorCssValue <| CSSColorValue.color CssColor.slateBlue
        static member slateGray = colorCssValue <| CSSColorValue.color CssColor.slateGray
        static member snow = colorCssValue <| CSSColorValue.color CssColor.snow
        static member springGreen = colorCssValue <| CSSColorValue.color CssColor.springGreen
        static member steelBlue = colorCssValue <| CSSColorValue.color CssColor.steelBlue
        static member tan = colorCssValue <| CSSColorValue.color CssColor.tan
        static member thistle = colorCssValue <| CSSColorValue.color CssColor.thistle
        static member tomato = colorCssValue <| CSSColorValue.color CssColor.tomato
        static member turquoise = colorCssValue <| CSSColorValue.color CssColor.turquoise
        static member violet = colorCssValue <| CSSColorValue.color CssColor.violet
        static member wheat = colorCssValue <| CSSColorValue.color CssColor.wheat
        static member whiteSmoke = colorCssValue <| CSSColorValue.color CssColor.whiteSmoke
        static member yellowGreen = colorCssValue <| CSSColorValue.color CssColor.yellowGreen
        static member rebeccaPurple = colorCssValue <| CSSColorValue.color CssColor.rebeccaPurple
        static member Rgb r g b =
            colorCssValue <| CSSColorValue.color (CssColor.Rgb(r, g, b))
        static member Rgba r g b a =
            colorCssValue <| CSSColorValue.color (CssColor.Rgba(r, g, b, a))
        static member Hex value =
            colorCssValue <| CSSColorValue.color (CssColor.Hex value)
        static member Hsl h s l =
            colorCssValue <| CSSColorValue.color (CssColor.Hsl(h, s, l))
        static member Hsla h s l a =
            colorCssValue <| CSSColorValue.color (CssColor.Hsla (h, s, l, a))
        static member Value (color: CssColor) = colorCssValue <| CSSColorValue.color color
        static member transparent = colorCssValue <| CSSColorValue.color CssColor.transparent
        static member currentColor = colorCssValue <| CSSColorValue.color CssColor.currentColor
        static member Revert = colorCssValue "revert"

        static member Inherit = Inherit |> GlobalValue.global' |> colorCssValue
        static member Initial = Initial |> GlobalValue.global' |> colorCssValue
        static member Unset = Unset |> GlobalValue.global' |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The CSSColor to apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: CssColor) = Color.Value(color)

