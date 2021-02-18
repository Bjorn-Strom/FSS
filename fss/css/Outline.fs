namespace Fss

open Fss.CssColor

[<RequireQualifiedAccess>]
module OutlineTypes =
    type OutlineWidth =
        | Thin
        | Medium
        | Thick
        interface IOutlineWidth

    type OutlineStyle =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface IOutlineStyle

[<AutoOpen>]
module Outline  =

    let private outlineToString (color: IOutline) =
        match color with
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown outline"

    let private outlineColorToString (color: IOutlineColor) =
        match color with
        | :? CssColor as c -> CssColorValue.color c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown outline color"

    let private outlineWidthToString (width: IOutlineWidth) =
        match width with
            | :? OutlineTypes.OutlineWidth as c -> Utilities.Helpers.duToLowercase c
            | :? Global as g -> GlobalValue.global' g
            | :? Units.Size.Size as s -> Units.Size.value s
            | _ -> "Unknown outline width"

    let private outlineStyleToString (style: IOutlineStyle) =
        match style with
            | :? OutlineTypes.OutlineStyle as c -> Utilities.Helpers.duToLowercase c
            | :? Global as g -> GlobalValue.global' g
            | :? None' -> GlobalValue.none
            | _ -> "Unknown outline style"

    let private outlineOffsetToString (style: IOutlineOffset) =
        match style with
            | :? Global as g -> GlobalValue.global' g
            | :? Units.Size.Size as s -> Units.Size.value s
            | _ -> "Unknown outline offset"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    let private outlineValue value = PropertyValue.cssValue Property.Outline value
    let private outlineValue' value =
        value
        |> outlineToString
        |> outlineValue

    type Outline =
        static member Value (outline: IOutline) = outline |> outlineValue'

        static member None = None' |> outlineValue'
        static member Inherit = Inherit |> outlineValue'
        static member Initial = Initial |> outlineValue'
        static member Unset = Unset |> outlineValue'

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
    let private colorValue value = PropertyValue.cssValue Property.OutlineColor value
    let private colorValue' value =
        value
        |> outlineColorToString
        |> colorValue

    type OutlineColor =
        static member Value (color: IOutlineColor) = color |> colorValue'
        static member black = CssColor.black |> colorValue'
        static member silver = CssColor.silver |> colorValue'
        static member gray = CssColor.gray |> colorValue'
        static member white = CssColor.white |> colorValue'
        static member maroon = CssColor.maroon |> colorValue'
        static member red = CssColor.red |> colorValue'
        static member purple = CssColor.purple |> colorValue'
        static member fuchsia = CssColor.fuchsia |> colorValue'
        static member green = CssColor.green |> colorValue'
        static member lime = CssColor.lime |> colorValue'
        static member olive = CssColor.olive |> colorValue'
        static member yellow = CssColor.yellow |> colorValue'
        static member navy = CssColor.navy |> colorValue'
        static member blue = CssColor.blue |> colorValue'
        static member teal = CssColor.teal |> colorValue'
        static member aqua = CssColor.aqua |> colorValue'
        static member orange = CssColor.orange |> colorValue'
        static member aliceBlue = CssColor.aliceBlue |> colorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> colorValue'
        static member aquaMarine = CssColor.aquaMarine |> colorValue'
        static member azure = CssColor.azure |> colorValue'
        static member beige = CssColor.beige |> colorValue'
        static member bisque = CssColor.bisque |> colorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> colorValue'
        static member blueViolet = CssColor.blueViolet |> colorValue'
        static member brown = CssColor.brown |> colorValue'
        static member burlywood = CssColor.burlywood |> colorValue'
        static member cadetBlue = CssColor.cadetBlue |> colorValue'
        static member chartreuse = CssColor.chartreuse |> colorValue'
        static member chocolate = CssColor.chocolate |> colorValue'
        static member coral = CssColor.coral |> colorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> colorValue'
        static member cornsilk = CssColor.cornsilk |> colorValue'
        static member crimson = CssColor.crimson |> colorValue'
        static member cyan = CssColor.cyan |> colorValue'
        static member darkBlue = CssColor.darkBlue |> colorValue'
        static member darkCyan = CssColor.darkCyan |> colorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> colorValue'
        static member darkGray = CssColor.darkGray |> colorValue'
        static member darkGreen = CssColor.darkGreen |> colorValue'
        static member darkKhaki = CssColor.darkKhaki |> colorValue'
        static member darkMagenta = CssColor.darkMagenta |> colorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> colorValue'
        static member darkOrange = CssColor.darkOrange |> colorValue'
        static member darkOrchid = CssColor.darkOrchid |> colorValue'
        static member darkRed = CssColor.darkRed |> colorValue'
        static member darkSalmon = CssColor.darkSalmon |> colorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> colorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> colorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> colorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> colorValue'
        static member darkViolet = CssColor.darkViolet |> colorValue'
        static member deepPink = CssColor.deepPink |> colorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> colorValue'
        static member dimGrey = CssColor.dimGrey |> colorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> colorValue'
        static member fireBrick = CssColor.fireBrick |> colorValue'
        static member floralWhite = CssColor.floralWhite |> colorValue'
        static member forestGreen = CssColor.forestGreen |> colorValue'
        static member gainsboro = CssColor.gainsboro |> colorValue'
        static member ghostWhite = CssColor.ghostWhite |> colorValue'
        static member gold = CssColor.gold |> colorValue'
        static member goldenrod = CssColor.goldenrod |> colorValue'
        static member greenYellow = CssColor.greenYellow |> colorValue'
        static member grey = CssColor.grey |> colorValue'
        static member honeydew = CssColor.honeydew |> colorValue'
        static member hotPink = CssColor.hotPink |> colorValue'
        static member indianRed = CssColor.indianRed |> colorValue'
        static member indigo = CssColor.indigo |> colorValue'
        static member ivory = CssColor.ivory |> colorValue'
        static member khaki = CssColor.khaki |> colorValue'
        static member lavender = CssColor.lavender |> colorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> colorValue'
        static member lawnGreen = CssColor.lawnGreen |> colorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> colorValue'
        static member lightBlue = CssColor.lightBlue |> colorValue'
        static member lightCoral = CssColor.lightCoral |> colorValue'
        static member lightCyan = CssColor.lightCyan |> colorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> colorValue'
        static member lightGray = CssColor.lightGray |> colorValue'
        static member lightGreen = CssColor.lightGreen |> colorValue'
        static member lightGrey = CssColor.lightGrey |> colorValue'
        static member lightPink = CssColor.lightPink |> colorValue'
        static member lightSalmon = CssColor.lightSalmon |> colorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> colorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> colorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> colorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> colorValue'
        static member lightYellow = CssColor.lightYellow |> colorValue'
        static member limeGreen = CssColor.limeGreen |> colorValue'
        static member linen = CssColor.linen |> colorValue'
        static member magenta = CssColor.magenta |> colorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> colorValue'
        static member mediumBlue = CssColor.mediumBlue |> colorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> colorValue'
        static member mediumPurple = CssColor.mediumPurple |> colorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> colorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> colorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> colorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> colorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> colorValue'
        static member midnightBlue = CssColor.midnightBlue |> colorValue'
        static member mintCream = CssColor.mintCream |> colorValue'
        static member mistyRose = CssColor.mistyRose |> colorValue'
        static member moccasin = CssColor.moccasin |> colorValue'
        static member navajoWhite = CssColor.navajoWhite |> colorValue'
        static member oldLace = CssColor.oldLace |> colorValue'
        static member olivedrab = CssColor.olivedrab |> colorValue'
        static member orangeRed = CssColor.orangeRed |> colorValue'
        static member orchid = CssColor.orchid |> colorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> colorValue'
        static member paleGreen = CssColor.paleGreen |> colorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> colorValue'
        static member paleVioletred = CssColor.paleVioletred |> colorValue'
        static member papayaWhip = CssColor.papayaWhip |> colorValue'
        static member peachpuff = CssColor.peachpuff |> colorValue'
        static member peru = CssColor.peru |> colorValue'
        static member pink = CssColor.pink |> colorValue'
        static member plum = CssColor.plum |> colorValue'
        static member powderBlue = CssColor.powderBlue |> colorValue'
        static member rosyBrown = CssColor.rosyBrown |> colorValue'
        static member royalBlue = CssColor.royalBlue |> colorValue'
        static member saddleBrown = CssColor.saddleBrown |> colorValue'
        static member salmon = CssColor.salmon |> colorValue'
        static member sandyBrown = CssColor.sandyBrown |> colorValue'
        static member seaGreen = CssColor.seaGreen |> colorValue'
        static member seaShell = CssColor.seaShell |> colorValue'
        static member sienna = CssColor.sienna |> colorValue'
        static member skyBlue = CssColor.skyBlue |> colorValue'
        static member slateBlue = CssColor.slateBlue |> colorValue'
        static member slateGray = CssColor.slateGray |> colorValue'
        static member snow = CssColor.snow |> colorValue'
        static member springGreen = CssColor.springGreen |> colorValue'
        static member steelBlue = CssColor.steelBlue |> colorValue'
        static member tan = CssColor.tan |> colorValue'
        static member thistle = CssColor.thistle |> colorValue'
        static member tomato = CssColor.tomato |> colorValue'
        static member turquoise = CssColor.turquoise |> colorValue'
        static member violet = CssColor.violet |> colorValue'
        static member wheat = CssColor.wheat |> colorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> colorValue'
        static member yellowGreen = CssColor.yellowGreen |> colorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> colorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> colorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> colorValue'
        static member Hex value = CssColor.Hex value |> colorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> colorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> colorValue'
        static member transparent = CssColor.transparent |> colorValue'
        static member currentColor = CssColor.currentColor |> colorValue'

        static member Inherit = Inherit |> colorValue'
        static member Initial = Initial |> colorValue'
        static member Unset = Unset |> colorValue'

    /// <summary>Sets color of outline.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> CssColor </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineColor' (color: IOutlineColor) = OutlineColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue value = PropertyValue.cssValue Property.OutlineWidth value
    let private outlineWidthValue' value =
        value
        |> outlineWidthToString
        |> outlineWidthValue

    type OutlineWidth =
        static member Value (width: IOutlineWidth) = width |> outlineWidthValue'
        static member Thin = OutlineTypes.Thin |> outlineWidthValue'
        static member Medium = OutlineTypes.Medium |> outlineWidthValue'
        static member Thick = OutlineTypes.Thick |> outlineWidthValue'

        static member Inherit = Inherit |> outlineWidthValue'
        static member Initial = Initial |> outlineWidthValue'
        static member Unset = Unset |> outlineWidthValue'


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
    let private outlineStyleValue value = PropertyValue.cssValue Property.OutlineStyle value
    let private outlineStyleValue' value =
        value
        |> outlineStyleToString
        |> outlineStyleValue

    type OutlineStyle =
        static member Value (style: IOutlineStyle) = style |> outlineStyleValue'
        static member Hidden = OutlineTypes.Hidden |> outlineStyleValue'
        static member Dotted = OutlineTypes.Dotted |> outlineStyleValue'
        static member Dashed = OutlineTypes.Dashed |> outlineStyleValue'
        static member Solid = OutlineTypes.Solid |> outlineStyleValue'
        static member Double = OutlineTypes.Double |> outlineStyleValue'
        static member Groove = OutlineTypes.Groove |> outlineStyleValue'
        static member Ridge = OutlineTypes.Ridge |> outlineStyleValue'
        static member Inset = OutlineTypes.Inset |> outlineStyleValue'
        static member Outset = OutlineTypes.Outset |> outlineStyleValue'

        static member None = None' |> outlineStyleValue'
        static member Inherit = Inherit |> outlineStyleValue'
        static member Initial = Initial |> outlineStyleValue'
        static member Unset = Unset |> outlineStyleValue'

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
    let private outlineOffsetValue value = PropertyValue.cssValue Property.OutlineOffset value
    let private outlineOffsetValue' value =
        value
        |> outlineOffsetToString
        |> outlineOffsetValue

    type OutlineOffset =
        static member Value (offset: IOutlineOffset) = offset |> outlineOffsetValue'
        static member Inherit = Inherit |> outlineOffsetValue'
        static member Initial = Initial |> outlineOffsetValue'
        static member Unset = Unset |> outlineOffsetValue'

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