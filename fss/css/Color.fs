namespace Fss

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColorAdjust value
    let private colorAdjustCssValue' (value: FssTypes.ColorAdjust) =
        value
        |> Utilities.Helpers.duToLowercase
        |> colorAdjustCssValue

    type ColorAdjust =
        static member Value (adjust: FssTypes.ColorAdjust) = adjust |> colorAdjustCssValue'
        static member Economy = FssTypes.Economy |> colorAdjustCssValue'
        static member Exact = FssTypes.Exact |> colorAdjustCssValue'

    let ColorAdjust' (adjust: FssTypes.ColorAdjust) = adjust |> ColorAdjust.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue value =
        value
        |> FssTypes.propertyHelpers.cssValue FssTypes.Property.Color
    let private colorCssValue' value =
        value
        |> FssTypes.colorHelpers.colorToString
        |> colorCssValue
    type Color =
        static member black = FssTypes.Color.black |> colorCssValue'
        static member silver = FssTypes.Color.silver |> colorCssValue'
        static member gray = FssTypes.Color.gray |> colorCssValue'
        static member white = FssTypes.Color.white |> colorCssValue'
        static member maroon = FssTypes.Color.maroon |> colorCssValue'
        static member red = FssTypes.Color.red |> colorCssValue'
        static member purple = FssTypes.Color.purple |> colorCssValue'
        static member fuchsia = FssTypes.Color.fuchsia |> colorCssValue'
        static member green = FssTypes.Color.green |> colorCssValue'
        static member lime = FssTypes.Color.lime |> colorCssValue'
        static member olive = FssTypes.Color.olive |> colorCssValue'
        static member yellow = FssTypes.Color.yellow |> colorCssValue'
        static member navy = FssTypes.Color.navy |> colorCssValue'
        static member blue = FssTypes.Color.blue |> colorCssValue'
        static member teal = FssTypes.Color.teal |> colorCssValue'
        static member aqua = FssTypes.Color.aqua |> colorCssValue'
        static member orange = FssTypes.Color.orange |> colorCssValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> colorCssValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> colorCssValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> colorCssValue'
        static member azure = FssTypes.Color.azure |> colorCssValue'
        static member beige = FssTypes.Color.beige |> colorCssValue'
        static member bisque = FssTypes.Color.bisque |> colorCssValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> colorCssValue'
        static member blueViolet = FssTypes.Color.blueViolet |> colorCssValue'
        static member brown = FssTypes.Color.brown |> colorCssValue'
        static member burlywood = FssTypes.Color.burlywood |> colorCssValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> colorCssValue'
        static member chartreuse = FssTypes.Color.chartreuse |> colorCssValue'
        static member chocolate = FssTypes.Color.chocolate |> colorCssValue'
        static member coral = FssTypes.Color.coral |> colorCssValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> colorCssValue'
        static member cornsilk = FssTypes.Color.cornsilk |> colorCssValue'
        static member crimson = FssTypes.Color.crimson |> colorCssValue'
        static member cyan = FssTypes.Color.cyan |> colorCssValue'
        static member darkBlue = FssTypes.Color.darkBlue |> colorCssValue'
        static member darkCyan = FssTypes.Color.darkCyan |> colorCssValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> colorCssValue'
        static member darkGray = FssTypes.Color.darkGray |> colorCssValue'
        static member darkGreen = FssTypes.Color.darkGreen |> colorCssValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> colorCssValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> colorCssValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> colorCssValue'
        static member darkOrange = FssTypes.Color.darkOrange |> colorCssValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> colorCssValue'
        static member darkRed = FssTypes.Color.darkRed |> colorCssValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> colorCssValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> colorCssValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> colorCssValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> colorCssValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> colorCssValue'
        static member darkViolet = FssTypes.Color.darkViolet |> colorCssValue'
        static member deepPink = FssTypes.Color.deepPink |> colorCssValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> colorCssValue'
        static member dimGrey = FssTypes.Color.dimGrey |> colorCssValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> colorCssValue'
        static member fireBrick = FssTypes.Color.fireBrick |> colorCssValue'
        static member floralWhite = FssTypes.Color.floralWhite |> colorCssValue'
        static member forestGreen = FssTypes.Color.forestGreen |> colorCssValue'
        static member gainsboro = FssTypes.Color.gainsboro |> colorCssValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> colorCssValue'
        static member gold = FssTypes.Color.gold |> colorCssValue'
        static member goldenrod = FssTypes.Color.goldenrod |> colorCssValue'
        static member greenYellow = FssTypes.Color.greenYellow |> colorCssValue'
        static member grey = FssTypes.Color.grey |> colorCssValue'
        static member honeydew = FssTypes.Color.honeydew |> colorCssValue'
        static member hotPink = FssTypes.Color.hotPink |> colorCssValue'
        static member indianRed = FssTypes.Color.indianRed |> colorCssValue'
        static member indigo = FssTypes.Color.indigo |> colorCssValue'
        static member ivory = FssTypes.Color.ivory |> colorCssValue'
        static member khaki = FssTypes.Color.khaki |> colorCssValue'
        static member lavender = FssTypes.Color.lavender |> colorCssValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> colorCssValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> colorCssValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> colorCssValue'
        static member lightBlue = FssTypes.Color.lightBlue |> colorCssValue'
        static member lightCoral = FssTypes.Color.lightCoral |> colorCssValue'
        static member lightCyan = FssTypes.Color.lightCyan |> colorCssValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> colorCssValue'
        static member lightGray = FssTypes.Color.lightGray |> colorCssValue'
        static member lightGreen = FssTypes.Color.lightGreen |> colorCssValue'
        static member lightGrey = FssTypes.Color.lightGrey |> colorCssValue'
        static member lightPink = FssTypes.Color.lightPink |> colorCssValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> colorCssValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> colorCssValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> colorCssValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> colorCssValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> colorCssValue'
        static member lightYellow = FssTypes.Color.lightYellow |> colorCssValue'
        static member limeGreen = FssTypes.Color.limeGreen |> colorCssValue'
        static member linen = FssTypes.Color.linen |> colorCssValue'
        static member magenta = FssTypes.Color.magenta |> colorCssValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> colorCssValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> colorCssValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> colorCssValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> colorCssValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> colorCssValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> colorCssValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> colorCssValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> colorCssValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> colorCssValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> colorCssValue'
        static member mintCream = FssTypes.Color.mintCream |> colorCssValue'
        static member mistyRose = FssTypes.Color.mistyRose |> colorCssValue'
        static member moccasin = FssTypes.Color.moccasin |> colorCssValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> colorCssValue'
        static member oldLace = FssTypes.Color.oldLace |> colorCssValue'
        static member olivedrab = FssTypes.Color.olivedrab |> colorCssValue'
        static member orangeRed = FssTypes.Color.orangeRed |> colorCssValue'
        static member orchid = FssTypes.Color.orchid |> colorCssValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> colorCssValue'
        static member paleGreen = FssTypes.Color.paleGreen |> colorCssValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> colorCssValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> colorCssValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> colorCssValue'
        static member peachpuff = FssTypes.Color.peachpuff |> colorCssValue'
        static member peru = FssTypes.Color.peru |> colorCssValue'
        static member pink = FssTypes.Color.pink |> colorCssValue'
        static member plum = FssTypes.Color.plum |> colorCssValue'
        static member powderBlue = FssTypes.Color.powderBlue |> colorCssValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> colorCssValue'
        static member royalBlue = FssTypes.Color.royalBlue |> colorCssValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> colorCssValue'
        static member salmon = FssTypes.Color.salmon |> colorCssValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> colorCssValue'
        static member seaGreen = FssTypes.Color.seaGreen |> colorCssValue'
        static member seaShell = FssTypes.Color.seaShell |> colorCssValue'
        static member sienna = FssTypes.Color.sienna |> colorCssValue'
        static member skyBlue = FssTypes.Color.skyBlue |> colorCssValue'
        static member slateBlue = FssTypes.Color.slateBlue |> colorCssValue'
        static member slateGray = FssTypes.Color.slateGray |> colorCssValue'
        static member snow = FssTypes.Color.snow |> colorCssValue'
        static member springGreen = FssTypes.Color.springGreen |> colorCssValue'
        static member steelBlue = FssTypes.Color.steelBlue |> colorCssValue'
        static member tan = FssTypes.Color.tan |> colorCssValue'
        static member thistle = FssTypes.Color.thistle |> colorCssValue'
        static member tomato = FssTypes.Color.tomato |> colorCssValue'
        static member turquoise = FssTypes.Color.turquoise |> colorCssValue'
        static member violet = FssTypes.Color.violet |> colorCssValue'
        static member wheat = FssTypes.Color.wheat |> colorCssValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> colorCssValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> colorCssValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> colorCssValue'
        static member Rgb r g b =
              FssTypes.Color.Rgb(r, g, b) |> colorCssValue'
        static member Rgba r g b a =
              FssTypes.Color.Rgba(r, g, b, a) |> colorCssValue'
        static member Hex value =
              FssTypes.Color.Hex value |> colorCssValue'
        static member Hsl h s l =
              FssTypes.Color.Hsl(h, s, l) |> colorCssValue'
        static member Hsla h s l a =
              FssTypes.Color.Hsla (h, s, l, a) |> colorCssValue'
        static member Value (color: FssTypes.ColorTypeFoo) = color |> colorCssValue'
        static member transparent = FssTypes.Color.transparent |> colorCssValue'
        static member currentColor = FssTypes.Color.currentColor |> colorCssValue'
        static member Revert = colorCssValue "revert"

        static member Inherit = FssTypes.Inherit |> FssTypes.masterTypeHelpers.keywordsToString |> colorCssValue
        static member Initial = FssTypes.Initial |> FssTypes.masterTypeHelpers.keywordsToString |> colorCssValue
        static member Unset = FssTypes.Unset |> FssTypes.masterTypeHelpers.keywordsToString |> colorCssValue

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The FssTypes.ColorTypeFooto apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: FssTypes.ColorTypeFoo) = Color.Value(color)

