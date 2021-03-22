namespace Fss

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = Types.propertyHelpers.cssValue Types.Property.ColorAdjust value
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
    let private colorCssValue value =
        value
        |> Types.propertyHelpers.cssValue Types.Property.Color
    let private colorCssValue' value =
        value
        |> Types.colorHelpers.colorToString
        |> colorCssValue
    type Color =
        static member black = Types.Color.black |> colorCssValue'
        static member silver = Types.Color.silver |> colorCssValue'
        static member gray = Types.Color.gray |> colorCssValue'
        static member white = Types.Color.white |> colorCssValue'
        static member maroon = Types.Color.maroon |> colorCssValue'
        static member red = Types.Color.red |> colorCssValue'
        static member purple = Types.Color.purple |> colorCssValue'
        static member fuchsia = Types.Color.fuchsia |> colorCssValue'
        static member green = Types.Color.green |> colorCssValue'
        static member lime = Types.Color.lime |> colorCssValue'
        static member olive = Types.Color.olive |> colorCssValue'
        static member yellow = Types.Color.yellow |> colorCssValue'
        static member navy = Types.Color.navy |> colorCssValue'
        static member blue = Types.Color.blue |> colorCssValue'
        static member teal = Types.Color.teal |> colorCssValue'
        static member aqua = Types.Color.aqua |> colorCssValue'
        static member orange = Types.Color.orange |> colorCssValue'
        static member aliceBlue = Types.Color.aliceBlue |> colorCssValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> colorCssValue'
        static member aquaMarine = Types.Color.aquaMarine |> colorCssValue'
        static member azure = Types.Color.azure |> colorCssValue'
        static member beige = Types.Color.beige |> colorCssValue'
        static member bisque = Types.Color.bisque |> colorCssValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> colorCssValue'
        static member blueViolet = Types.Color.blueViolet |> colorCssValue'
        static member brown = Types.Color.brown |> colorCssValue'
        static member burlywood = Types.Color.burlywood |> colorCssValue'
        static member cadetBlue = Types.Color.cadetBlue |> colorCssValue'
        static member chartreuse = Types.Color.chartreuse |> colorCssValue'
        static member chocolate = Types.Color.chocolate |> colorCssValue'
        static member coral = Types.Color.coral |> colorCssValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> colorCssValue'
        static member cornsilk = Types.Color.cornsilk |> colorCssValue'
        static member crimson = Types.Color.crimson |> colorCssValue'
        static member cyan = Types.Color.cyan |> colorCssValue'
        static member darkBlue = Types.Color.darkBlue |> colorCssValue'
        static member darkCyan = Types.Color.darkCyan |> colorCssValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> colorCssValue'
        static member darkGray = Types.Color.darkGray |> colorCssValue'
        static member darkGreen = Types.Color.darkGreen |> colorCssValue'
        static member darkKhaki = Types.Color.darkKhaki |> colorCssValue'
        static member darkMagenta = Types.Color.darkMagenta |> colorCssValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> colorCssValue'
        static member darkOrange = Types.Color.darkOrange |> colorCssValue'
        static member darkOrchid = Types.Color.darkOrchid |> colorCssValue'
        static member darkRed = Types.Color.darkRed |> colorCssValue'
        static member darkSalmon = Types.Color.darkSalmon |> colorCssValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> colorCssValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> colorCssValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> colorCssValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> colorCssValue'
        static member darkViolet = Types.Color.darkViolet |> colorCssValue'
        static member deepPink = Types.Color.deepPink |> colorCssValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> colorCssValue'
        static member dimGrey = Types.Color.dimGrey |> colorCssValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> colorCssValue'
        static member fireBrick = Types.Color.fireBrick |> colorCssValue'
        static member floralWhite = Types.Color.floralWhite |> colorCssValue'
        static member forestGreen = Types.Color.forestGreen |> colorCssValue'
        static member gainsboro = Types.Color.gainsboro |> colorCssValue'
        static member ghostWhite = Types.Color.ghostWhite |> colorCssValue'
        static member gold = Types.Color.gold |> colorCssValue'
        static member goldenrod = Types.Color.goldenrod |> colorCssValue'
        static member greenYellow = Types.Color.greenYellow |> colorCssValue'
        static member grey = Types.Color.grey |> colorCssValue'
        static member honeydew = Types.Color.honeydew |> colorCssValue'
        static member hotPink = Types.Color.hotPink |> colorCssValue'
        static member indianRed = Types.Color.indianRed |> colorCssValue'
        static member indigo = Types.Color.indigo |> colorCssValue'
        static member ivory = Types.Color.ivory |> colorCssValue'
        static member khaki = Types.Color.khaki |> colorCssValue'
        static member lavender = Types.Color.lavender |> colorCssValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> colorCssValue'
        static member lawnGreen = Types.Color.lawnGreen |> colorCssValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> colorCssValue'
        static member lightBlue = Types.Color.lightBlue |> colorCssValue'
        static member lightCoral = Types.Color.lightCoral |> colorCssValue'
        static member lightCyan = Types.Color.lightCyan |> colorCssValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> colorCssValue'
        static member lightGray = Types.Color.lightGray |> colorCssValue'
        static member lightGreen = Types.Color.lightGreen |> colorCssValue'
        static member lightGrey = Types.Color.lightGrey |> colorCssValue'
        static member lightPink = Types.Color.lightPink |> colorCssValue'
        static member lightSalmon = Types.Color.lightSalmon |> colorCssValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> colorCssValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> colorCssValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> colorCssValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> colorCssValue'
        static member lightYellow = Types.Color.lightYellow |> colorCssValue'
        static member limeGreen = Types.Color.limeGreen |> colorCssValue'
        static member linen = Types.Color.linen |> colorCssValue'
        static member magenta = Types.Color.magenta |> colorCssValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> colorCssValue'
        static member mediumBlue = Types.Color.mediumBlue |> colorCssValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> colorCssValue'
        static member mediumPurple = Types.Color.mediumPurple |> colorCssValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> colorCssValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> colorCssValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> colorCssValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> colorCssValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> colorCssValue'
        static member midnightBlue = Types.Color.midnightBlue |> colorCssValue'
        static member mintCream = Types.Color.mintCream |> colorCssValue'
        static member mistyRose = Types.Color.mistyRose |> colorCssValue'
        static member moccasin = Types.Color.moccasin |> colorCssValue'
        static member navajoWhite = Types.Color.navajoWhite |> colorCssValue'
        static member oldLace = Types.Color.oldLace |> colorCssValue'
        static member olivedrab = Types.Color.olivedrab |> colorCssValue'
        static member orangeRed = Types.Color.orangeRed |> colorCssValue'
        static member orchid = Types.Color.orchid |> colorCssValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> colorCssValue'
        static member paleGreen = Types.Color.paleGreen |> colorCssValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> colorCssValue'
        static member paleVioletred = Types.Color.paleVioletred |> colorCssValue'
        static member papayaWhip = Types.Color.papayaWhip |> colorCssValue'
        static member peachpuff = Types.Color.peachpuff |> colorCssValue'
        static member peru = Types.Color.peru |> colorCssValue'
        static member pink = Types.Color.pink |> colorCssValue'
        static member plum = Types.Color.plum |> colorCssValue'
        static member powderBlue = Types.Color.powderBlue |> colorCssValue'
        static member rosyBrown = Types.Color.rosyBrown |> colorCssValue'
        static member royalBlue = Types.Color.royalBlue |> colorCssValue'
        static member saddleBrown = Types.Color.saddleBrown |> colorCssValue'
        static member salmon = Types.Color.salmon |> colorCssValue'
        static member sandyBrown = Types.Color.sandyBrown |> colorCssValue'
        static member seaGreen = Types.Color.seaGreen |> colorCssValue'
        static member seaShell = Types.Color.seaShell |> colorCssValue'
        static member sienna = Types.Color.sienna |> colorCssValue'
        static member skyBlue = Types.Color.skyBlue |> colorCssValue'
        static member slateBlue = Types.Color.slateBlue |> colorCssValue'
        static member slateGray = Types.Color.slateGray |> colorCssValue'
        static member snow = Types.Color.snow |> colorCssValue'
        static member springGreen = Types.Color.springGreen |> colorCssValue'
        static member steelBlue = Types.Color.steelBlue |> colorCssValue'
        static member tan = Types.Color.tan |> colorCssValue'
        static member thistle = Types.Color.thistle |> colorCssValue'
        static member tomato = Types.Color.tomato |> colorCssValue'
        static member turquoise = Types.Color.turquoise |> colorCssValue'
        static member violet = Types.Color.violet |> colorCssValue'
        static member wheat = Types.Color.wheat |> colorCssValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> colorCssValue'
        static member yellowGreen = Types.Color.yellowGreen |> colorCssValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> colorCssValue'
        static member Rgb r g b =
              Types.Color.Rgb(r, g, b) |> colorCssValue'
        static member Rgba r g b a =
              Types.Color.Rgba(r, g, b, a) |> colorCssValue'
        static member Hex value =
              Types.Color.Hex value |> colorCssValue'
        static member Hsl h s l =
              Types.Color.Hsl(h, s, l) |> colorCssValue'
        static member Hsla h s l a =
              Types.Color.Hsla (h, s, l, a) |> colorCssValue'
        static member Value (color: Types.ColorTypeFoo) = color |> colorCssValue'
        static member transparent = Types.Color.transparent |> colorCssValue'
        static member currentColor = Types.Color.currentColor |> colorCssValue'
        static member Revert = colorCssValue "revert"

        static member Inherit = Types.Inherit |> Types.masterTypeHelpers.keywordsToString |> colorCssValue
        static member Initial = Types.Initial |> Types.masterTypeHelpers.keywordsToString |> colorCssValue
        static member Unset = Types.Unset |> Types.masterTypeHelpers.keywordsToString |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The Types.ColorTypeFooto apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: Types.ColorTypeFoo) = Color.Value(color)

