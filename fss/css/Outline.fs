namespace Fss

[<AutoOpen>]
module Outline  =

    let private outlineToString (color: FssTypes.IOutline) =
        match color with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown outline"

    let private outlineColorToString (color: FssTypes.IOutlineColor) =
        match color with
        | :? FssTypes.ColorType as c -> FssTypes.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown outline color"

    let private outlineWidthToString (width: FssTypes.IOutlineWidth) =
        match width with
            | :? FssTypes.Outline.Width as c -> Utilities.Helpers.duToLowercase c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
            | _ -> "Unknown outline width"

    let private outlineStyleToString (style: FssTypes.IOutlineStyle) =
        match style with
            | :? FssTypes.Outline.Style as c -> Utilities.Helpers.duToLowercase c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
            | _ -> "Unknown outline style"

    let private outlineOffsetToString (style: FssTypes.IOutlineOffset) =
        match style with
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
            | _ -> "Unknown outline offset"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    let private outlineValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Outline value
    let private outlineValue' value =
        value
        |> outlineToString
        |> outlineValue

    type Outline =
        static member Value (outline: FssTypes.IOutline) = outline |> outlineValue'

        static member None = FssTypes.None' |> outlineValue'
        static member Inherit = FssTypes.Inherit |> outlineValue'
        static member Initial = FssTypes.Initial |> outlineValue'
        static member Unset = FssTypes.Unset |> outlineValue'

    /// <summary>Resets outline.</summary>
    /// <param name="outline">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Outline' (outline: FssTypes.IOutline) = Outline.Value(outline)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    let private colorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineColor value
    let private colorValue' value =
        value
        |> outlineColorToString
        |> colorValue

    type OutlineColor =
        static member Value (color: FssTypes.IOutlineColor) = color |> colorValue'
        static member black = FssTypes.Color.black |> colorValue'
        static member silver = FssTypes.Color.silver |> colorValue'
        static member gray = FssTypes.Color.gray |> colorValue'
        static member white = FssTypes.Color.white |> colorValue'
        static member maroon = FssTypes.Color.maroon |> colorValue'
        static member red = FssTypes.Color.red |> colorValue'
        static member purple = FssTypes.Color.purple |> colorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> colorValue'
        static member green = FssTypes.Color.green |> colorValue'
        static member lime = FssTypes.Color.lime |> colorValue'
        static member olive = FssTypes.Color.olive |> colorValue'
        static member yellow = FssTypes.Color.yellow |> colorValue'
        static member navy = FssTypes.Color.navy |> colorValue'
        static member blue = FssTypes.Color.blue |> colorValue'
        static member teal = FssTypes.Color.teal |> colorValue'
        static member aqua = FssTypes.Color.aqua |> colorValue'
        static member orange = FssTypes.Color.orange |> colorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> colorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> colorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> colorValue'
        static member azure = FssTypes.Color.azure |> colorValue'
        static member beige = FssTypes.Color.beige |> colorValue'
        static member bisque = FssTypes.Color.bisque |> colorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> colorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> colorValue'
        static member brown = FssTypes.Color.brown |> colorValue'
        static member burlywood = FssTypes.Color.burlywood |> colorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> colorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> colorValue'
        static member chocolate = FssTypes.Color.chocolate |> colorValue'
        static member coral = FssTypes.Color.coral |> colorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> colorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> colorValue'
        static member crimson = FssTypes.Color.crimson |> colorValue'
        static member cyan = FssTypes.Color.cyan |> colorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> colorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> colorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> colorValue'
        static member darkGray = FssTypes.Color.darkGray |> colorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> colorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> colorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> colorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> colorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> colorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> colorValue'
        static member darkRed = FssTypes.Color.darkRed |> colorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> colorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> colorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> colorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> colorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> colorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> colorValue'
        static member deepPink = FssTypes.Color.deepPink |> colorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> colorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> colorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> colorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> colorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> colorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> colorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> colorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> colorValue'
        static member gold = FssTypes.Color.gold |> colorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> colorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> colorValue'
        static member grey = FssTypes.Color.grey |> colorValue'
        static member honeydew = FssTypes.Color.honeydew |> colorValue'
        static member hotPink = FssTypes.Color.hotPink |> colorValue'
        static member indianRed = FssTypes.Color.indianRed |> colorValue'
        static member indigo = FssTypes.Color.indigo |> colorValue'
        static member ivory = FssTypes.Color.ivory |> colorValue'
        static member khaki = FssTypes.Color.khaki |> colorValue'
        static member lavender = FssTypes.Color.lavender |> colorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> colorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> colorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> colorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> colorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> colorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> colorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> colorValue'
        static member lightGray = FssTypes.Color.lightGray |> colorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> colorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> colorValue'
        static member lightPink = FssTypes.Color.lightPink |> colorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> colorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> colorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> colorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> colorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> colorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> colorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> colorValue'
        static member linen = FssTypes.Color.linen |> colorValue'
        static member magenta = FssTypes.Color.magenta |> colorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> colorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> colorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> colorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> colorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> colorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> colorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> colorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> colorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> colorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> colorValue'
        static member mintCream = FssTypes.Color.mintCream |> colorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> colorValue'
        static member moccasin = FssTypes.Color.moccasin |> colorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> colorValue'
        static member oldLace = FssTypes.Color.oldLace |> colorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> colorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> colorValue'
        static member orchid = FssTypes.Color.orchid |> colorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> colorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> colorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> colorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> colorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> colorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> colorValue'
        static member peru = FssTypes.Color.peru |> colorValue'
        static member pink = FssTypes.Color.pink |> colorValue'
        static member plum = FssTypes.Color.plum |> colorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> colorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> colorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> colorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> colorValue'
        static member salmon = FssTypes.Color.salmon |> colorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> colorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> colorValue'
        static member seaShell = FssTypes.Color.seaShell |> colorValue'
        static member sienna = FssTypes.Color.sienna |> colorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> colorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> colorValue'
        static member slateGray = FssTypes.Color.slateGray |> colorValue'
        static member snow = FssTypes.Color.snow |> colorValue'
        static member springGreen = FssTypes.Color.springGreen |> colorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> colorValue'
        static member tan = FssTypes.Color.tan |> colorValue'
        static member thistle = FssTypes.Color.thistle |> colorValue'
        static member tomato = FssTypes.Color.tomato |> colorValue'
        static member turquoise = FssTypes.Color.turquoise |> colorValue'
        static member violet = FssTypes.Color.violet |> colorValue'
        static member wheat = FssTypes.Color.wheat |> colorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> colorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> colorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> colorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> colorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> colorValue'
        static member Hex value = FssTypes.Color.Hex value |> colorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> colorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> colorValue'
        static member transparent = FssTypes.Color.transparent |> colorValue'
        static member currentColor = FssTypes.Color.currentColor |> colorValue'

        static member Inherit = FssTypes.Inherit |> colorValue'
        static member Initial = FssTypes.Initial |> colorValue'
        static member Unset = FssTypes.Unset |> colorValue'

    /// <summary>Sets color of outline.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineColor' (color: FssTypes.IOutlineColor) = OutlineColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineWidth value
    let private outlineWidthValue' value =
        value
        |> outlineWidthToString
        |> outlineWidthValue

    type OutlineWidth =
        static member Value (width: FssTypes.IOutlineWidth) = width |> outlineWidthValue'
        static member Thin = FssTypes.Outline.Width.Thin |> outlineWidthValue'
        static member Medium = FssTypes.Outline.Width.Medium |> outlineWidthValue'
        static member Thick = FssTypes.Outline.Width.Thick |> outlineWidthValue'

        static member Inherit = FssTypes.Inherit |> outlineWidthValue'
        static member Initial = FssTypes.Initial |> outlineWidthValue'
        static member Unset = FssTypes.Unset |> outlineWidthValue'


    /// <summary>Sets width of outline.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> OutlineWidth </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineWidth' (width: FssTypes.IOutlineWidth) = OutlineWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    let private outlineStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineStyle value
    let private outlineStyleValue' value =
        value
        |> outlineStyleToString
        |> outlineStyleValue

    type OutlineStyle =
        static member Value (style: FssTypes.IOutlineStyle) = style |> outlineStyleValue'
        static member Hidden = FssTypes.Outline.Style.Hidden |> outlineStyleValue'
        static member Dotted = FssTypes.Outline.Style.Dotted |> outlineStyleValue'
        static member Dashed = FssTypes.Outline.Style.Dashed |> outlineStyleValue'
        static member Solid = FssTypes.Outline.Style.Solid |> outlineStyleValue'
        static member Double = FssTypes.Outline.Style.Double |> outlineStyleValue'
        static member Groove = FssTypes.Outline.Style.Groove |> outlineStyleValue'
        static member Ridge = FssTypes.Outline.Style.Ridge |> outlineStyleValue'
        static member Inset = FssTypes.Outline.Style.Inset |> outlineStyleValue'
        static member Outset = FssTypes.Outline.Style.Outset |> outlineStyleValue'

        static member None = FssTypes.None' |> outlineStyleValue'
        static member Inherit = FssTypes.Inherit |> outlineStyleValue'
        static member Initial = FssTypes.Initial |> outlineStyleValue'
        static member Unset = FssTypes.Unset |> outlineStyleValue'

    /// <summary>Sets style of outline.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> OutlineStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineStyle' (style: FssTypes.IOutlineStyle) = OutlineStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
    let private outlineOffsetValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineOffset value
    let private outlineOffsetValue' value =
        value
        |> outlineOffsetToString
        |> outlineOffsetValue

    type OutlineOffset =
        static member Value (offset: FssTypes.IOutlineOffset) = offset |> outlineOffsetValue'
        static member Inherit = FssTypes.Inherit |> outlineOffsetValue'
        static member Initial = FssTypes.Initial |> outlineOffsetValue'
        static member Unset = FssTypes.Unset |> outlineOffsetValue'

    /// <summary>Sets offset of outline.</summary>
    /// <param name="offset">
    ///     can be:
    ///     - <c> OutlineOffset </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineOffset' (offset: FssTypes.IOutlineOffset) = OutlineOffset.Value(offset)