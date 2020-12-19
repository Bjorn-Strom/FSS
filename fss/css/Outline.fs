namespace Fss

open Fss.CSSColor

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
    open OutlineTypes

    let private outlineColorToString (color: IOutlineColor) =
        match color with
        | :? CSSColor as c -> CSSColorValue.color c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown outline color"

    let private outlineWidthToString (width: IOutlineWidth) =
        match width with
            | :? OutlineWidth as c -> Utilities.Helpers.duToLowercase c
            | :? Global as g -> GlobalValue.global' g
            | :? Units.Size.Size as s -> Units.Size.value s
            | _ -> "Unknown outline width"

    let private outlineStyleToString (style: IOutlineStyle) =
        match style with
            | :? OutlineStyle as c -> Utilities.Helpers.duToLowercase c
            | :? Global as g -> GlobalValue.global' g
            | :? None -> GlobalValue.none
            | _ -> "Unknown outline style"

    let private colorValue value = PropertyValue.cssValue Property.OutlineColor value
    let private colorValue' value =
        value
        |> outlineColorToString
        |> colorValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    type OutlineColor =
        static member Value (color: IOutlineColor) = color |> colorValue'
        static member black = CSSColor.black |> colorValue'
        static member silver = CSSColor.silver |> colorValue'
        static member gray = CSSColor.gray |> colorValue'
        static member white = CSSColor.white |> colorValue'
        static member maroon = CSSColor.maroon |> colorValue'
        static member red = CSSColor.red |> colorValue'
        static member purple = CSSColor.purple |> colorValue'
        static member fuchsia = CSSColor.fuchsia |> colorValue'
        static member green = CSSColor.green |> colorValue'
        static member lime = CSSColor.lime |> colorValue'
        static member olive = CSSColor.olive |> colorValue'
        static member yellow = CSSColor.yellow |> colorValue'
        static member navy = CSSColor.navy |> colorValue'
        static member blue = CSSColor.blue |> colorValue'
        static member teal = CSSColor.teal |> colorValue'
        static member aqua = CSSColor.aqua |> colorValue'
        static member orange = CSSColor.orange |> colorValue'
        static member aliceBlue = CSSColor.aliceBlue |> colorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> colorValue'
        static member aquaMarine = CSSColor.aquaMarine |> colorValue'
        static member azure = CSSColor.azure |> colorValue'
        static member beige = CSSColor.beige |> colorValue'
        static member bisque = CSSColor.bisque |> colorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> colorValue'
        static member blueViolet = CSSColor.blueViolet |> colorValue'
        static member brown = CSSColor.brown |> colorValue'
        static member burlywood = CSSColor.burlywood |> colorValue'
        static member cadetBlue = CSSColor.cadetBlue |> colorValue'
        static member chartreuse = CSSColor.chartreuse |> colorValue'
        static member chocolate = CSSColor.chocolate |> colorValue'
        static member coral = CSSColor.coral |> colorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> colorValue'
        static member cornsilk = CSSColor.cornsilk |> colorValue'
        static member crimson = CSSColor.crimson |> colorValue'
        static member cyan = CSSColor.cyan |> colorValue'
        static member darkBlue = CSSColor.darkBlue |> colorValue'
        static member darkCyan = CSSColor.darkCyan |> colorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> colorValue'
        static member darkGray = CSSColor.darkGray |> colorValue'
        static member darkGreen = CSSColor.darkGreen |> colorValue'
        static member darkKhaki = CSSColor.darkKhaki |> colorValue'
        static member darkMagenta = CSSColor.darkMagenta |> colorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> colorValue'
        static member darkOrange = CSSColor.darkOrange |> colorValue'
        static member darkOrchid = CSSColor.darkOrchid |> colorValue'
        static member darkRed = CSSColor.darkRed |> colorValue'
        static member darkSalmon = CSSColor.darkSalmon |> colorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> colorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> colorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> colorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> colorValue'
        static member darkViolet = CSSColor.darkViolet |> colorValue'
        static member deepPink = CSSColor.deepPink |> colorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> colorValue'
        static member dimGrey = CSSColor.dimGrey |> colorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> colorValue'
        static member fireBrick = CSSColor.fireBrick |> colorValue'
        static member floralWhite = CSSColor.floralWhite |> colorValue'
        static member forestGreen = CSSColor.forestGreen |> colorValue'
        static member gainsboro = CSSColor.gainsboro |> colorValue'
        static member ghostWhite = CSSColor.ghostWhite |> colorValue'
        static member gold = CSSColor.gold |> colorValue'
        static member goldenrod = CSSColor.goldenrod |> colorValue'
        static member greenYellow = CSSColor.greenYellow |> colorValue'
        static member grey = CSSColor.grey |> colorValue'
        static member honeydew = CSSColor.honeydew |> colorValue'
        static member hotPink = CSSColor.hotPink |> colorValue'
        static member indianRed = CSSColor.indianRed |> colorValue'
        static member indigo = CSSColor.indigo |> colorValue'
        static member ivory = CSSColor.ivory |> colorValue'
        static member khaki = CSSColor.khaki |> colorValue'
        static member lavender = CSSColor.lavender |> colorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> colorValue'
        static member lawnGreen = CSSColor.lawnGreen |> colorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> colorValue'
        static member lightBlue = CSSColor.lightBlue |> colorValue'
        static member lightCoral = CSSColor.lightCoral |> colorValue'
        static member lightCyan = CSSColor.lightCyan |> colorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> colorValue'
        static member lightGray = CSSColor.lightGray |> colorValue'
        static member lightGreen = CSSColor.lightGreen |> colorValue'
        static member lightGrey = CSSColor.lightGrey |> colorValue'
        static member lightPink = CSSColor.lightPink |> colorValue'
        static member lightSalmon = CSSColor.lightSalmon |> colorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> colorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> colorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> colorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> colorValue'
        static member lightYellow = CSSColor.lightYellow |> colorValue'
        static member limeGreen = CSSColor.limeGreen |> colorValue'
        static member linen = CSSColor.linen |> colorValue'
        static member magenta = CSSColor.magenta |> colorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> colorValue'
        static member mediumBlue = CSSColor.mediumBlue |> colorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> colorValue'
        static member mediumPurple = CSSColor.mediumPurple |> colorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> colorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> colorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> colorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> colorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> colorValue'
        static member midnightBlue = CSSColor.midnightBlue |> colorValue'
        static member mintCream = CSSColor.mintCream |> colorValue'
        static member mistyRose = CSSColor.mistyRose |> colorValue'
        static member moccasin = CSSColor.moccasin |> colorValue'
        static member navajoWhite = CSSColor.navajoWhite |> colorValue'
        static member oldLace = CSSColor.oldLace |> colorValue'
        static member olivedrab = CSSColor.olivedrab |> colorValue'
        static member orangeRed = CSSColor.orangeRed |> colorValue'
        static member orchid = CSSColor.orchid |> colorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> colorValue'
        static member paleGreen = CSSColor.paleGreen |> colorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> colorValue'
        static member paleVioletred = CSSColor.paleVioletred |> colorValue'
        static member papayaWhip = CSSColor.papayaWhip |> colorValue'
        static member peachpuff = CSSColor.peachpuff |> colorValue'
        static member peru = CSSColor.peru |> colorValue'
        static member pink = CSSColor.pink |> colorValue'
        static member plum = CSSColor.plum |> colorValue'
        static member powderBlue = CSSColor.powderBlue |> colorValue'
        static member rosyBrown = CSSColor.rosyBrown |> colorValue'
        static member royalBlue = CSSColor.royalBlue |> colorValue'
        static member saddleBrown = CSSColor.saddleBrown |> colorValue'
        static member salmon = CSSColor.salmon |> colorValue'
        static member sandyBrown = CSSColor.sandyBrown |> colorValue'
        static member seaGreen = CSSColor.seaGreen |> colorValue'
        static member seaShell = CSSColor.seaShell |> colorValue'
        static member sienna = CSSColor.sienna |> colorValue'
        static member skyBlue = CSSColor.skyBlue |> colorValue'
        static member slateBlue = CSSColor.slateBlue |> colorValue'
        static member slateGray = CSSColor.slateGray |> colorValue'
        static member snow = CSSColor.snow |> colorValue'
        static member springGreen = CSSColor.springGreen |> colorValue'
        static member steelBlue = CSSColor.steelBlue |> colorValue'
        static member tan = CSSColor.tan |> colorValue'
        static member thistle = CSSColor.thistle |> colorValue'
        static member tomato = CSSColor.tomato |> colorValue'
        static member turquoise = CSSColor.turquoise |> colorValue'
        static member violet = CSSColor.violet |> colorValue'
        static member wheat = CSSColor.wheat |> colorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> colorValue'
        static member yellowGreen = CSSColor.yellowGreen |> colorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> colorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> colorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> colorValue'
        static member Hex value = CSSColor.Hex value |> colorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> colorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> colorValue'
        static member transparent = CSSColor.transparent |> colorValue'
        static member currentColor = CSSColor.currentColor |> colorValue'

        static member Inherit = Inherit |> colorValue'
        static member Initial = Initial |> colorValue'
        static member Unset = Unset |> colorValue'

    let OutlineColor' (color: IOutlineColor) = OutlineColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue value = PropertyValue.cssValue Property.OutlineWidth value
    let private outlineWidthValue' value =
        value
        |> outlineWidthToString
        |> outlineWidthValue

    type OutlineWidth =
        static member Value (width: IOutlineWidth) = width |> outlineWidthValue'
        static member Thin = Thin |> outlineWidthValue'
        static member Medium = Medium |> outlineWidthValue'
        static member Thick = Thick |> outlineWidthValue'

        static member Inherit = Inherit |> outlineWidthValue'
        static member Initial = Initial |> outlineWidthValue'
        static member Unset = Unset |> outlineWidthValue'

    let OutlineWidth' (width: IOutlineWidth) = OutlineWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    let private outlineStyleValue value = PropertyValue.cssValue Property.OutlineStyle value
    let private outlineStyleValue' value =
        value
        |> outlineStyleToString
        |> outlineStyleValue

    type OutlineStyle =
        static member Value (style: IOutlineStyle) = style |> outlineStyleValue'
        static member Hidden = Hidden |> outlineStyleValue'
        static member Dotted = Dotted |> outlineStyleValue'
        static member Dashed = Dashed |> outlineStyleValue'
        static member Solid = Solid |> outlineStyleValue'
        static member Double = Double |> outlineStyleValue'
        static member Groove = Groove |> outlineStyleValue'
        static member Ridge = Ridge |> outlineStyleValue'
        static member Inset = Inset |> outlineStyleValue'
        static member Outset = Outset |> outlineStyleValue'

        static member None = None |> outlineStyleValue'
        static member Inherit = Inherit |> outlineStyleValue'
        static member Initial = Initial |> outlineStyleValue'
        static member Unset = Unset |> outlineStyleValue'

    let OutlineStyle' (style: IOutlineStyle) = OutlineStyle.Value(style)