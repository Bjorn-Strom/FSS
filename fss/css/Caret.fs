namespace Fss

[<AutoOpen>]
module Caret =
    let private caretColorToString (caretColor: FssTypes.ICaretColor) =
        match caretColor with
        | :? FssTypes.ColorType as c -> FssTypes.colorHelpers.colorToString c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown caret color"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caret-color
    let private caretColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.CaretColor value
    let private caretColorValue' value =
        value
        |> caretColorToString
        |> caretColorValue
    type CaretColor =
        static member value (color: FssTypes.ICaretColor) = color |> caretColorValue'
        static member black = FssTypes.Color.black |> caretColorValue'
        static member silver = FssTypes.Color.silver |> caretColorValue'
        static member gray = FssTypes.Color.gray |> caretColorValue'
        static member white = FssTypes.Color.white |> caretColorValue'
        static member maroon = FssTypes.Color.maroon |> caretColorValue'
        static member red = FssTypes.Color.red |> caretColorValue'
        static member purple = FssTypes.Color.purple |> caretColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> caretColorValue'
        static member green = FssTypes.Color.green |> caretColorValue'
        static member lime = FssTypes.Color.lime |> caretColorValue'
        static member olive = FssTypes.Color.olive |> caretColorValue'
        static member yellow = FssTypes.Color.yellow |> caretColorValue'
        static member navy = FssTypes.Color.navy |> caretColorValue'
        static member blue = FssTypes.Color.blue |> caretColorValue'
        static member teal = FssTypes.Color.teal |> caretColorValue'
        static member aqua = FssTypes.Color.aqua |> caretColorValue'
        static member orange = FssTypes.Color.orange |> caretColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> caretColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> caretColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> caretColorValue'
        static member azure = FssTypes.Color.azure |> caretColorValue'
        static member beige = FssTypes.Color.beige |> caretColorValue'
        static member bisque = FssTypes.Color.bisque |> caretColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> caretColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> caretColorValue'
        static member brown = FssTypes.Color.brown |> caretColorValue'
        static member burlywood = FssTypes.Color.burlywood |> caretColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> caretColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> caretColorValue'
        static member chocolate = FssTypes.Color.chocolate |> caretColorValue'
        static member coral = FssTypes.Color.coral |> caretColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> caretColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> caretColorValue'
        static member crimson = FssTypes.Color.crimson |> caretColorValue'
        static member cyan = FssTypes.Color.cyan |> caretColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> caretColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> caretColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> caretColorValue'
        static member darkGray = FssTypes.Color.darkGray |> caretColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> caretColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> caretColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> caretColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> caretColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> caretColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> caretColorValue'
        static member darkRed = FssTypes.Color.darkRed |> caretColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> caretColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> caretColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> caretColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> caretColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> caretColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> caretColorValue'
        static member deepPink = FssTypes.Color.deepPink |> caretColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> caretColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> caretColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> caretColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> caretColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> caretColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> caretColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> caretColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> caretColorValue'
        static member gold = FssTypes.Color.gold |> caretColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> caretColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> caretColorValue'
        static member grey = FssTypes.Color.grey |> caretColorValue'
        static member honeydew = FssTypes.Color.honeydew |> caretColorValue'
        static member hotPink = FssTypes.Color.hotPink |> caretColorValue'
        static member indianRed = FssTypes.Color.indianRed |> caretColorValue'
        static member indigo = FssTypes.Color.indigo |> caretColorValue'
        static member ivory = FssTypes.Color.ivory |> caretColorValue'
        static member khaki = FssTypes.Color.khaki |> caretColorValue'
        static member lavender = FssTypes.Color.lavender |> caretColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> caretColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> caretColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> caretColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> caretColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> caretColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> caretColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> caretColorValue'
        static member lightGray = FssTypes.Color.lightGray |> caretColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> caretColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> caretColorValue'
        static member lightPink = FssTypes.Color.lightPink |> caretColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> caretColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> caretColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> caretColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> caretColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> caretColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> caretColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> caretColorValue'
        static member linen = FssTypes.Color.linen |> caretColorValue'
        static member magenta = FssTypes.Color.magenta |> caretColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> caretColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> caretColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> caretColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> caretColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> caretColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> caretColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> caretColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> caretColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> caretColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> caretColorValue'
        static member mintCream = FssTypes.Color.mintCream |> caretColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> caretColorValue'
        static member moccasin = FssTypes.Color.moccasin |> caretColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> caretColorValue'
        static member oldLace = FssTypes.Color.oldLace |> caretColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> caretColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> caretColorValue'
        static member orchid = FssTypes.Color.orchid |> caretColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> caretColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> caretColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> caretColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> caretColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> caretColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> caretColorValue'
        static member peru = FssTypes.Color.peru |> caretColorValue'
        static member pink = FssTypes.Color.pink |> caretColorValue'
        static member plum = FssTypes.Color.plum |> caretColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> caretColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> caretColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> caretColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> caretColorValue'
        static member salmon = FssTypes.Color.salmon |> caretColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> caretColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> caretColorValue'
        static member seaShell = FssTypes.Color.seaShell |> caretColorValue'
        static member sienna = FssTypes.Color.sienna |> caretColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> caretColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> caretColorValue'
        static member slateGray = FssTypes.Color.slateGray |> caretColorValue'
        static member snow = FssTypes.Color.snow |> caretColorValue'
        static member springGreen = FssTypes.Color.springGreen |> caretColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> caretColorValue'
        static member tan = FssTypes.Color.tan |> caretColorValue'
        static member thistle = FssTypes.Color.thistle |> caretColorValue'
        static member tomato = FssTypes.Color.tomato |> caretColorValue'
        static member turquoise = FssTypes.Color.turquoise |> caretColorValue'
        static member violet = FssTypes.Color.violet |> caretColorValue'
        static member wheat = FssTypes.Color.wheat |> caretColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> caretColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> caretColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> caretColorValue'
        static member rgb r g b = FssTypes.Color.rgb(r, g, b) |> caretColorValue'
        static member rgba r g b a = FssTypes.Color.rgba(r, g, b, a) |> caretColorValue'
        static member hex value = FssTypes.Color.hex value |> caretColorValue'
        static member hsl h s l = FssTypes.Color.hsl(h, s, l) |> caretColorValue'
        static member hsla h s l a  = FssTypes.Color.hsla (h, s, l, a) |> caretColorValue'
        static member transparent = FssTypes.Color.transparent |> caretColorValue'
        static member currentColor = FssTypes.Color.currentColor |> caretColorValue'

        static member auto = FssTypes.Auto |> caretColorValue'

    /// <summary>Specifies caret color.</summary>
    /// <param name="caretColor">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let CaretColor' (caretColor: FssTypes.ICaretColor) = CaretColor.value caretColor
