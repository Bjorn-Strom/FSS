namespace Fss

[<RequireQualifiedAccess>]
module ColorTypes =
    type ColorAdjust =
        | Economy
        | Exact

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = PropertyValue.cssValue Property.ColorAdjust value
    let private colorAdjustCssValue' (value: ColorTypes.ColorAdjust) =
        value
        |> Utilities.Helpers.duToLowercase
        |> colorAdjustCssValue

    type ColorAdjust =
        static member Value (adjust: ColorTypes.ColorAdjust) = adjust |> colorAdjustCssValue'
        static member Economy = ColorTypes.Economy |> colorAdjustCssValue'
        static member Exact = ColorTypes.Exact |> colorAdjustCssValue'

    let ColorAdjust' (adjust: ColorTypes.ColorAdjust) = adjust |> ColorAdjust.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue value = PropertyValue.cssValue Property.Color value
    type Color =
        static member black = colorCssValue <| CssColorValue.color CssColor.black
        static member silver = colorCssValue <| CssColorValue.color CssColor.silver
        static member gray = colorCssValue <| CssColorValue.color CssColor.gray
        static member white = colorCssValue <| CssColorValue.color CssColor.white
        static member maroon = colorCssValue <| CssColorValue.color CssColor.maroon
        static member red = colorCssValue <| CssColorValue.color CssColor.red
        static member purple = colorCssValue <| CssColorValue.color CssColor.purple
        static member fuchsia = colorCssValue <| CssColorValue.color CssColor.fuchsia
        static member green = colorCssValue <| CssColorValue.color CssColor.green
        static member lime = colorCssValue <| CssColorValue.color CssColor.lime
        static member olive = colorCssValue <| CssColorValue.color CssColor.olive
        static member yellow = colorCssValue <| CssColorValue.color CssColor.yellow
        static member navy = colorCssValue <| CssColorValue.color CssColor.navy
        static member blue = colorCssValue <| CssColorValue.color CssColor.blue
        static member teal = colorCssValue <| CssColorValue.color CssColor.teal
        static member aqua = colorCssValue <| CssColorValue.color CssColor.aqua
        static member orange = colorCssValue <| CssColorValue.color CssColor.orange
        static member aliceBlue = colorCssValue <| CssColorValue.color CssColor.aliceBlue
        static member antiqueWhite = colorCssValue <| CssColorValue.color CssColor.antiqueWhite
        static member aquaMarine = colorCssValue <| CssColorValue.color CssColor.aquaMarine
        static member azure = colorCssValue <| CssColorValue.color CssColor.azure
        static member beige = colorCssValue <| CssColorValue.color CssColor.beige
        static member bisque = colorCssValue <| CssColorValue.color CssColor.bisque
        static member blanchedAlmond = colorCssValue <| CssColorValue.color CssColor.blanchedAlmond
        static member blueViolet = colorCssValue <| CssColorValue.color CssColor.blueViolet
        static member brown = colorCssValue <| CssColorValue.color CssColor.brown
        static member burlywood = colorCssValue <| CssColorValue.color CssColor.burlywood
        static member cadetBlue = colorCssValue <| CssColorValue.color CssColor.cadetBlue
        static member chartreuse = colorCssValue <| CssColorValue.color CssColor.chartreuse
        static member chocolate = colorCssValue <| CssColorValue.color CssColor.chocolate
        static member coral = colorCssValue <| CssColorValue.color CssColor.coral
        static member cornflowerBlue = colorCssValue <| CssColorValue.color CssColor.cornflowerBlue
        static member cornsilk = colorCssValue <| CssColorValue.color CssColor.cornsilk
        static member crimson = colorCssValue <| CssColorValue.color CssColor.crimson
        static member cyan = colorCssValue <| CssColorValue.color CssColor.cyan
        static member darkBlue = colorCssValue <| CssColorValue.color CssColor.darkBlue
        static member darkCyan = colorCssValue <| CssColorValue.color CssColor.darkCyan
        static member darkGoldenrod = colorCssValue <| CssColorValue.color CssColor.darkGoldenrod
        static member darkGray = colorCssValue <| CssColorValue.color CssColor.darkGray
        static member darkGreen = colorCssValue <| CssColorValue.color CssColor.darkGreen
        static member darkKhaki = colorCssValue <| CssColorValue.color CssColor.darkKhaki
        static member darkMagenta = colorCssValue <| CssColorValue.color CssColor.darkMagenta
        static member darkOliveGreen = colorCssValue <| CssColorValue.color CssColor.darkOliveGreen
        static member darkOrange = colorCssValue <| CssColorValue.color CssColor.darkOrange
        static member darkOrchid = colorCssValue <| CssColorValue.color CssColor.darkOrchid
        static member darkRed = colorCssValue <| CssColorValue.color CssColor.darkRed
        static member darkSalmon = colorCssValue <| CssColorValue.color CssColor.darkSalmon
        static member darkSeaGreen = colorCssValue <| CssColorValue.color CssColor.darkSeaGreen
        static member darkSlateBlue = colorCssValue <| CssColorValue.color CssColor.darkSlateBlue
        static member darkSlateGray = colorCssValue <| CssColorValue.color CssColor.darkSlateGray
        static member darkTurquoise = colorCssValue <| CssColorValue.color CssColor.darkTurquoise
        static member darkViolet = colorCssValue <| CssColorValue.color CssColor.darkViolet
        static member deepPink = colorCssValue <| CssColorValue.color CssColor.deepPink
        static member deepSkyBlue = colorCssValue <| CssColorValue.color CssColor.deepSkyBlue
        static member dimGrey = colorCssValue <| CssColorValue.color CssColor.dimGrey
        static member dodgerBlue = colorCssValue <| CssColorValue.color CssColor.dodgerBlue
        static member fireBrick = colorCssValue <| CssColorValue.color CssColor.fireBrick
        static member floralWhite = colorCssValue <| CssColorValue.color CssColor.floralWhite
        static member forestGreen = colorCssValue <| CssColorValue.color CssColor.forestGreen
        static member gainsboro = colorCssValue <| CssColorValue.color CssColor.gainsboro
        static member ghostWhite = colorCssValue <| CssColorValue.color CssColor.ghostWhite
        static member gold = colorCssValue <| CssColorValue.color CssColor.gold
        static member goldenrod = colorCssValue <| CssColorValue.color CssColor.goldenrod
        static member greenYellow = colorCssValue <| CssColorValue.color CssColor.greenYellow
        static member grey = colorCssValue <| CssColorValue.color CssColor.grey
        static member honeydew = colorCssValue <| CssColorValue.color CssColor.honeydew
        static member hotPink = colorCssValue <| CssColorValue.color CssColor.hotPink
        static member indianRed = colorCssValue <| CssColorValue.color CssColor.indianRed
        static member indigo = colorCssValue <| CssColorValue.color CssColor.indigo
        static member ivory = colorCssValue <| CssColorValue.color CssColor.ivory
        static member khaki = colorCssValue <| CssColorValue.color CssColor.khaki
        static member lavender = colorCssValue <| CssColorValue.color CssColor.lavender
        static member lavenderBlush = colorCssValue <| CssColorValue.color CssColor.lavenderBlush
        static member lawnGreen = colorCssValue <| CssColorValue.color CssColor.lawnGreen
        static member lemonChiffon = colorCssValue <| CssColorValue.color CssColor.lemonChiffon
        static member lightBlue = colorCssValue <| CssColorValue.color CssColor.lightBlue
        static member lightCoral = colorCssValue <| CssColorValue.color CssColor.lightCoral
        static member lightCyan = colorCssValue <| CssColorValue.color CssColor.lightCyan
        static member lightGoldenrodYellow = colorCssValue <| CssColorValue.color CssColor.lightGoldenrodYellow
        static member lightGray = colorCssValue <| CssColorValue.color CssColor.lightGray
        static member lightGreen = colorCssValue <| CssColorValue.color CssColor.lightGreen
        static member lightGrey = colorCssValue <| CssColorValue.color CssColor.lightGrey
        static member lightPink = colorCssValue <| CssColorValue.color CssColor.lightPink
        static member lightSalmon = colorCssValue <| CssColorValue.color CssColor.lightSalmon
        static member lightSeaGreen = colorCssValue <| CssColorValue.color CssColor.lightSeaGreen
        static member lightSkyBlue = colorCssValue <| CssColorValue.color CssColor.lightSkyBlue
        static member lightSlateGrey = colorCssValue <| CssColorValue.color CssColor.lightSlateGrey
        static member lightSteelBlue = colorCssValue <| CssColorValue.color CssColor.lightSteelBlue
        static member lightYellow = colorCssValue <| CssColorValue.color CssColor.lightYellow
        static member limeGreen = colorCssValue <| CssColorValue.color CssColor.limeGreen
        static member linen = colorCssValue <| CssColorValue.color CssColor.linen
        static member magenta = colorCssValue <| CssColorValue.color CssColor.magenta
        static member mediumAquamarine = colorCssValue <| CssColorValue.color CssColor.mediumAquamarine
        static member mediumBlue = colorCssValue <| CssColorValue.color CssColor.mediumBlue
        static member mediumOrchid = colorCssValue <| CssColorValue.color CssColor.mediumOrchid
        static member mediumPurple = colorCssValue <| CssColorValue.color CssColor.mediumPurple
        static member mediumSeaGreen = colorCssValue <| CssColorValue.color CssColor.mediumSeaGreen
        static member mediumSlateBlue = colorCssValue <| CssColorValue.color CssColor.mediumSlateBlue
        static member mediumSpringGreen = colorCssValue <| CssColorValue.color CssColor.mediumSpringGreen
        static member mediumTurquoise = colorCssValue <| CssColorValue.color CssColor.mediumTurquoise
        static member mediumVioletRed = colorCssValue <| CssColorValue.color CssColor.mediumVioletRed
        static member midnightBlue = colorCssValue <| CssColorValue.color CssColor.midnightBlue
        static member mintCream = colorCssValue <| CssColorValue.color CssColor.mintCream
        static member mistyRose = colorCssValue <| CssColorValue.color CssColor.mistyRose
        static member moccasin = colorCssValue <| CssColorValue.color CssColor.moccasin
        static member navajoWhite = colorCssValue <| CssColorValue.color CssColor.navajoWhite
        static member oldLace = colorCssValue <| CssColorValue.color CssColor.oldLace
        static member olivedrab = colorCssValue <| CssColorValue.color CssColor.olivedrab
        static member orangeRed = colorCssValue <| CssColorValue.color CssColor.orangeRed
        static member orchid = colorCssValue <| CssColorValue.color CssColor.orchid
        static member paleGoldenrod = colorCssValue <| CssColorValue.color CssColor.paleGoldenrod
        static member paleGreen = colorCssValue <| CssColorValue.color CssColor.paleGreen
        static member paleTurquoise = colorCssValue <| CssColorValue.color CssColor.paleTurquoise
        static member paleVioletred = colorCssValue <| CssColorValue.color CssColor.paleVioletred
        static member papayaWhip = colorCssValue <| CssColorValue.color CssColor.papayaWhip
        static member peachpuff = colorCssValue <| CssColorValue.color CssColor.peachpuff
        static member peru = colorCssValue <| CssColorValue.color CssColor.peru
        static member pink = colorCssValue <| CssColorValue.color CssColor.pink
        static member plum = colorCssValue <| CssColorValue.color CssColor.plum
        static member powderBlue = colorCssValue <| CssColorValue.color CssColor.powderBlue
        static member rosyBrown = colorCssValue <| CssColorValue.color CssColor.rosyBrown
        static member royalBlue = colorCssValue <| CssColorValue.color CssColor.royalBlue
        static member saddleBrown = colorCssValue <| CssColorValue.color CssColor.saddleBrown
        static member salmon = colorCssValue <| CssColorValue.color CssColor.salmon
        static member sandyBrown = colorCssValue <| CssColorValue.color CssColor.sandyBrown
        static member seaGreen = colorCssValue <| CssColorValue.color CssColor.seaGreen
        static member seaShell = colorCssValue <| CssColorValue.color CssColor.seaShell
        static member sienna = colorCssValue <| CssColorValue.color CssColor.sienna
        static member skyBlue = colorCssValue <| CssColorValue.color CssColor.skyBlue
        static member slateBlue = colorCssValue <| CssColorValue.color CssColor.slateBlue
        static member slateGray = colorCssValue <| CssColorValue.color CssColor.slateGray
        static member snow = colorCssValue <| CssColorValue.color CssColor.snow
        static member springGreen = colorCssValue <| CssColorValue.color CssColor.springGreen
        static member steelBlue = colorCssValue <| CssColorValue.color CssColor.steelBlue
        static member tan = colorCssValue <| CssColorValue.color CssColor.tan
        static member thistle = colorCssValue <| CssColorValue.color CssColor.thistle
        static member tomato = colorCssValue <| CssColorValue.color CssColor.tomato
        static member turquoise = colorCssValue <| CssColorValue.color CssColor.turquoise
        static member violet = colorCssValue <| CssColorValue.color CssColor.violet
        static member wheat = colorCssValue <| CssColorValue.color CssColor.wheat
        static member whiteSmoke = colorCssValue <| CssColorValue.color CssColor.whiteSmoke
        static member yellowGreen = colorCssValue <| CssColorValue.color CssColor.yellowGreen
        static member rebeccaPurple = colorCssValue <| CssColorValue.color CssColor.rebeccaPurple
        static member Rgb r g b =
            colorCssValue <| CssColorValue.color (CssColor.Rgb(r, g, b))
        static member Rgba r g b a =
            colorCssValue <| CssColorValue.color (CssColor.Rgba(r, g, b, a))
        static member Hex value =
            colorCssValue <| CssColorValue.color (CssColor.Hex value)
        static member Hsl h s l =
            colorCssValue <| CssColorValue.color (CssColor.Hsl(h, s, l))
        static member Hsla h s l a =
            colorCssValue <| CssColorValue.color (CssColor.Hsla (h, s, l, a))
        static member Value (color: CssColor) = colorCssValue <| CssColorValue.color color
        static member transparent = colorCssValue <| CssColorValue.color CssColor.transparent
        static member currentColor = colorCssValue <| CssColorValue.color CssColor.currentColor
        static member Revert = colorCssValue "revert"

        static member Inherit = Inherit |> GlobalValue.global' |> colorCssValue
        static member Initial = Initial |> GlobalValue.global' |> colorCssValue
        static member Unset = Unset |> GlobalValue.global' |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The CSSColor to apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: CssColor) = Color.Value(color)

