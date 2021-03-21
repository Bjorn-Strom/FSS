namespace Fss

open FssTypes

[<AutoOpen>]
module Outline  =

    let private outlineToString (color: IOutline) =
        match color with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown outline"

    let private outlineColorToString (color: IOutlineColor) =
        match color with
        | :? Types.Color as c -> Types.colorToString c
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown outline color"

    let private outlineWidthToString (width: IOutlineWidth) =
        match width with
            | :? OutlineWidth as c -> Utilities.Helpers.duToLowercase c
            | :? Types.Keywords as k -> Types.keywordsToString k
            | :? Types.Size as s -> Types.sizeToString s
            | _ -> "Unknown outline width"

    let private outlineStyleToString (style: IOutlineStyle) =
        match style with
            | :? OutlineStyle as c -> Utilities.Helpers.duToLowercase c
            | :? Types.Keywords as k -> Types.keywordsToString k
            | :? Types.None' -> Types.none
            | _ -> "Unknown outline style"

    let private outlineOffsetToString (style: IOutlineOffset) =
        match style with
            | :? Types.Keywords as k -> Types.keywordsToString k
            | :? Types.Size as s -> Types.sizeToString s
            | _ -> "Unknown outline offset"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    let private outlineValue value = Types.cssValue Types.Property.Outline value
    let private outlineValue' value =
        value
        |> outlineToString
        |> outlineValue

    type Outline =
        static member Value (outline: IOutline) = outline |> outlineValue'

        static member None = Types.None' |> outlineValue'
        static member Inherit = Types.Inherit |> outlineValue'
        static member Initial = Types.Initial |> outlineValue'
        static member Unset = Types.Unset |> outlineValue'

    /// <summary>Resets outline.</summary>
    /// <param name="outline">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Outline' (outline: IOutline) = Outline.Value(outline)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    let private colorValue value = Types.cssValue Types.Property.OutlineColor value
    let private colorValue' value =
        value
        |> outlineColorToString
        |> colorValue

    type OutlineColor =
        static member Value (color: IOutlineColor) = color |> colorValue'
        static member black = Types.Color.black |> colorValue'
        static member silver = Types.Color.silver |> colorValue'
        static member gray = Types.Color.gray |> colorValue'
        static member white = Types.Color.white |> colorValue'
        static member maroon = Types.Color.maroon |> colorValue'
        static member red = Types.Color.red |> colorValue'
        static member purple = Types.Color.purple |> colorValue'
        static member fuchsia = Types.Color.fuchsia |> colorValue'
        static member green = Types.Color.green |> colorValue'
        static member lime = Types.Color.lime |> colorValue'
        static member olive = Types.Color.olive |> colorValue'
        static member yellow = Types.Color.yellow |> colorValue'
        static member navy = Types.Color.navy |> colorValue'
        static member blue = Types.Color.blue |> colorValue'
        static member teal = Types.Color.teal |> colorValue'
        static member aqua = Types.Color.aqua |> colorValue'
        static member orange = Types.Color.orange |> colorValue'
        static member aliceBlue = Types.Color.aliceBlue |> colorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> colorValue'
        static member aquaMarine = Types.Color.aquaMarine |> colorValue'
        static member azure = Types.Color.azure |> colorValue'
        static member beige = Types.Color.beige |> colorValue'
        static member bisque = Types.Color.bisque |> colorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> colorValue'
        static member blueViolet = Types.Color.blueViolet |> colorValue'
        static member brown = Types.Color.brown |> colorValue'
        static member burlywood = Types.Color.burlywood |> colorValue'
        static member cadetBlue = Types.Color.cadetBlue |> colorValue'
        static member chartreuse = Types.Color.chartreuse |> colorValue'
        static member chocolate = Types.Color.chocolate |> colorValue'
        static member coral = Types.Color.coral |> colorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> colorValue'
        static member cornsilk = Types.Color.cornsilk |> colorValue'
        static member crimson = Types.Color.crimson |> colorValue'
        static member cyan = Types.Color.cyan |> colorValue'
        static member darkBlue = Types.Color.darkBlue |> colorValue'
        static member darkCyan = Types.Color.darkCyan |> colorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> colorValue'
        static member darkGray = Types.Color.darkGray |> colorValue'
        static member darkGreen = Types.Color.darkGreen |> colorValue'
        static member darkKhaki = Types.Color.darkKhaki |> colorValue'
        static member darkMagenta = Types.Color.darkMagenta |> colorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> colorValue'
        static member darkOrange = Types.Color.darkOrange |> colorValue'
        static member darkOrchid = Types.Color.darkOrchid |> colorValue'
        static member darkRed = Types.Color.darkRed |> colorValue'
        static member darkSalmon = Types.Color.darkSalmon |> colorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> colorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> colorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> colorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> colorValue'
        static member darkViolet = Types.Color.darkViolet |> colorValue'
        static member deepPink = Types.Color.deepPink |> colorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> colorValue'
        static member dimGrey = Types.Color.dimGrey |> colorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> colorValue'
        static member fireBrick = Types.Color.fireBrick |> colorValue'
        static member floralWhite = Types.Color.floralWhite |> colorValue'
        static member forestGreen = Types.Color.forestGreen |> colorValue'
        static member gainsboro = Types.Color.gainsboro |> colorValue'
        static member ghostWhite = Types.Color.ghostWhite |> colorValue'
        static member gold = Types.Color.gold |> colorValue'
        static member goldenrod = Types.Color.goldenrod |> colorValue'
        static member greenYellow = Types.Color.greenYellow |> colorValue'
        static member grey = Types.Color.grey |> colorValue'
        static member honeydew = Types.Color.honeydew |> colorValue'
        static member hotPink = Types.Color.hotPink |> colorValue'
        static member indianRed = Types.Color.indianRed |> colorValue'
        static member indigo = Types.Color.indigo |> colorValue'
        static member ivory = Types.Color.ivory |> colorValue'
        static member khaki = Types.Color.khaki |> colorValue'
        static member lavender = Types.Color.lavender |> colorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> colorValue'
        static member lawnGreen = Types.Color.lawnGreen |> colorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> colorValue'
        static member lightBlue = Types.Color.lightBlue |> colorValue'
        static member lightCoral = Types.Color.lightCoral |> colorValue'
        static member lightCyan = Types.Color.lightCyan |> colorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> colorValue'
        static member lightGray = Types.Color.lightGray |> colorValue'
        static member lightGreen = Types.Color.lightGreen |> colorValue'
        static member lightGrey = Types.Color.lightGrey |> colorValue'
        static member lightPink = Types.Color.lightPink |> colorValue'
        static member lightSalmon = Types.Color.lightSalmon |> colorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> colorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> colorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> colorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> colorValue'
        static member lightYellow = Types.Color.lightYellow |> colorValue'
        static member limeGreen = Types.Color.limeGreen |> colorValue'
        static member linen = Types.Color.linen |> colorValue'
        static member magenta = Types.Color.magenta |> colorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> colorValue'
        static member mediumBlue = Types.Color.mediumBlue |> colorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> colorValue'
        static member mediumPurple = Types.Color.mediumPurple |> colorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> colorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> colorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> colorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> colorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> colorValue'
        static member midnightBlue = Types.Color.midnightBlue |> colorValue'
        static member mintCream = Types.Color.mintCream |> colorValue'
        static member mistyRose = Types.Color.mistyRose |> colorValue'
        static member moccasin = Types.Color.moccasin |> colorValue'
        static member navajoWhite = Types.Color.navajoWhite |> colorValue'
        static member oldLace = Types.Color.oldLace |> colorValue'
        static member olivedrab = Types.Color.olivedrab |> colorValue'
        static member orangeRed = Types.Color.orangeRed |> colorValue'
        static member orchid = Types.Color.orchid |> colorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> colorValue'
        static member paleGreen = Types.Color.paleGreen |> colorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> colorValue'
        static member paleVioletred = Types.Color.paleVioletred |> colorValue'
        static member papayaWhip = Types.Color.papayaWhip |> colorValue'
        static member peachpuff = Types.Color.peachpuff |> colorValue'
        static member peru = Types.Color.peru |> colorValue'
        static member pink = Types.Color.pink |> colorValue'
        static member plum = Types.Color.plum |> colorValue'
        static member powderBlue = Types.Color.powderBlue |> colorValue'
        static member rosyBrown = Types.Color.rosyBrown |> colorValue'
        static member royalBlue = Types.Color.royalBlue |> colorValue'
        static member saddleBrown = Types.Color.saddleBrown |> colorValue'
        static member salmon = Types.Color.salmon |> colorValue'
        static member sandyBrown = Types.Color.sandyBrown |> colorValue'
        static member seaGreen = Types.Color.seaGreen |> colorValue'
        static member seaShell = Types.Color.seaShell |> colorValue'
        static member sienna = Types.Color.sienna |> colorValue'
        static member skyBlue = Types.Color.skyBlue |> colorValue'
        static member slateBlue = Types.Color.slateBlue |> colorValue'
        static member slateGray = Types.Color.slateGray |> colorValue'
        static member snow = Types.Color.snow |> colorValue'
        static member springGreen = Types.Color.springGreen |> colorValue'
        static member steelBlue = Types.Color.steelBlue |> colorValue'
        static member tan = Types.Color.tan |> colorValue'
        static member thistle = Types.Color.thistle |> colorValue'
        static member tomato = Types.Color.tomato |> colorValue'
        static member turquoise = Types.Color.turquoise |> colorValue'
        static member violet = Types.Color.violet |> colorValue'
        static member wheat = Types.Color.wheat |> colorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> colorValue'
        static member yellowGreen = Types.Color.yellowGreen |> colorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> colorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> colorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> colorValue'
        static member Hex value = Types.Color.Hex value |> colorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> colorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> colorValue'
        static member transparent = Types.Color.transparent |> colorValue'
        static member currentColor = Types.Color.currentColor |> colorValue'

        static member Inherit = Types.Inherit |> colorValue'
        static member Initial = Types.Initial |> colorValue'
        static member Unset = Types.Unset |> colorValue'

    /// <summary>Sets color of outline.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Types.Color </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineColor' (color: IOutlineColor) = OutlineColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue value = Types.cssValue Types.Property.OutlineWidth value
    let private outlineWidthValue' value =
        value
        |> outlineWidthToString
        |> outlineWidthValue

    type OutlineWidth =
        static member Value (width: IOutlineWidth) = width |> outlineWidthValue'
        static member Thin = Types.OutlineWidth.Thin |> outlineWidthValue'
        static member Medium = Types.OutlineWidth.Medium |> outlineWidthValue'
        static member Thick = Types.OutlineWidth.Thick |> outlineWidthValue'

        static member Inherit = Types.Inherit |> outlineWidthValue'
        static member Initial = Types.Initial |> outlineWidthValue'
        static member Unset = Types.Unset |> outlineWidthValue'


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
    let OutlineWidth' (width: IOutlineWidth) = OutlineWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    let private outlineStyleValue value = Types.cssValue Types.Property.OutlineStyle value
    let private outlineStyleValue' value =
        value
        |> outlineStyleToString
        |> outlineStyleValue

    type OutlineStyle =
        static member Value (style: IOutlineStyle) = style |> outlineStyleValue'
        static member Hidden = Types.OutlineStyle.Hidden |> outlineStyleValue'
        static member Dotted = Types.OutlineStyle.Dotted |> outlineStyleValue'
        static member Dashed = Types.OutlineStyle.Dashed |> outlineStyleValue'
        static member Solid = Types.OutlineStyle.Solid |> outlineStyleValue'
        static member Double = Types.OutlineStyle.Double |> outlineStyleValue'
        static member Groove = Types.OutlineStyle.Groove |> outlineStyleValue'
        static member Ridge = Types.OutlineStyle.Ridge |> outlineStyleValue'
        static member Inset = Types.OutlineStyle.Inset |> outlineStyleValue'
        static member Outset = Types.OutlineStyle.Outset |> outlineStyleValue'

        static member None = Types.None' |> outlineStyleValue'
        static member Inherit = Types.Inherit |> outlineStyleValue'
        static member Initial = Types.Initial |> outlineStyleValue'
        static member Unset = Types.Unset |> outlineStyleValue'

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
    let OutlineStyle' (style: IOutlineStyle) = OutlineStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
    let private outlineOffsetValue value = Types.cssValue Types.Property.OutlineOffset value
    let private outlineOffsetValue' value =
        value
        |> outlineOffsetToString
        |> outlineOffsetValue

    type OutlineOffset =
        static member Value (offset: IOutlineOffset) = offset |> outlineOffsetValue'
        static member Inherit = Types.Inherit |> outlineOffsetValue'
        static member Initial = Types.Initial |> outlineOffsetValue'
        static member Unset = Types.Unset |> outlineOffsetValue'

    /// <summary>Sets offset of outline.</summary>
    /// <param name="offset">
    ///     can be:
    ///     - <c> OutlineOffset </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineOffset' (offset: IOutlineOffset) = OutlineOffset.Value(offset)