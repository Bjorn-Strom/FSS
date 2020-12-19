namespace Fss

module ColumnType =
    type ColumnSpan =
        | All
        interface IColumnSpan

    type ColumnRuleWidth =
        | Thin
        | Medium
        | Thick
        interface IColumnRuleWidth

    type ColumnRuleStyle =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface IColumnRuleStyle

    type ColumnFill =
        | Balance
        | BalanceAll
        interface IColumnFill

[<AutoOpen>]
module Column =
    open ColumnType

    let private columnGapToString (gap: IColumnGap) =
        match gap with
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown column gap"

    let private columnSpanToString (span: IColumnSpan) =
        let stringifyColumnSpan =
            function
                | All -> "all"

        match span with
        | :? ColumnSpan as c -> stringifyColumnSpan c
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown column span"

    let private columnsToString(columns: IColumns) =
        match columns with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown columns"

    let private columnRuleToString(columnRule: IColumnRule) =
        match columnRule with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column rule"

    let private columnRuleWidthToString (ruleWidth: IColumnRuleWidth) =
        match ruleWidth with
        | :? ColumnRuleWidth as w -> Utilities.Helpers.duToLowercase w
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: IColumnRuleStyle) =
        match style with
        | :? ColumnRuleStyle as b -> Utilities.Helpers.duToLowercase b
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column style"

    let private columnRuleColorToString (columnColor: IColumnRuleColor) =
        match columnColor with
        | :? CSSColor as c -> CSSColorValue.color c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column rule color"

    let private columnCountToString (columnCount: IColumnCount) =
        match columnCount with
        | :? CssInt as i -> GlobalValue.int i
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column count"

    let private columnFillToString (columnFill: IColumnFill) =
        match columnFill with
        | :? ColumnFill as c -> Utilities.Helpers.duToKebab c
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column fill"

    let private columnWidthToString (columnWidth: IColumnWidth) =
        match columnWidth with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column width"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue value = PropertyValue.cssValue Property.ColumnGap value
    let private columnGapValue' value =
        value
        |> columnGapToString
        |> columnGapValue
    type ColumnGap =
        static member Value (gap: IColumnGap) = gap |> columnGapValue'
        static member Inherit = Inherit |> columnGapValue'
        static member Initial = Initial |> columnGapValue'
        static member Unset = Unset |> columnGapValue'
        static member Normal = Normal |> columnGapValue'

    let ColumnGap' (columnGap: IColumnGap) = ColumnGap.Value(columnGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue value = PropertyValue.cssValue Property.ColumnSpan value
    let private columnSpanValue' value =
        value
        |> columnSpanToString
        |> columnSpanValue

    type ColumnSpan =
        static member Value(span: IColumnSpan) = span |> columnSpanValue'
        static member All = All |> columnSpanValue'
        static member Inherit = Inherit |> columnSpanValue'
        static member Initial = Initial |> columnSpanValue'
        static member Unset = Unset |> columnSpanValue'
        static member None = None |> columnSpanValue'

    let ColumnSpan' (span: IColumnSpan) = ColumnSpan.Value(span)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/columns
    let private columnsValue value = PropertyValue.cssValue Property.Columns value
    let private columnsValue' value =
        value
        |> columnsToString
        |> columnsValue

    type Columns =
        static member Value (columns: IColumns) = columns |> columnsValue'
        static member Inherit = Inherit |> columnsValue'
        static member Initial = Initial |> columnsValue'
        static member Unset = Unset |> columnsValue'

    let Columns' (columns: IColumns) = columns |> Columns.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    let private columnRuleValue value = PropertyValue.cssValue Property.ColumnRule value
    let private columnRuleValue' value =
        value
        |> columnRuleToString
        |> columnRuleValue

    type ColumnRule =
        static member Value (rule: IColumnRule) = rule |> columnRuleValue'
        static member Inherit = Inherit |> columnRuleValue'
        static member Initial = Initial |> columnRuleValue'
        static member Unset = Unset |> columnRuleValue'

    let ColumnRule' (rule: IColumnRule) = rule |> ColumnRule.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue value = PropertyValue.cssValue Property.ColumnRuleWidth value
    let private columnRuleWidthValue' value =
        value
        |> columnRuleWidthToString
        |> columnRuleWidthValue

    type ColumnRuleWidth =
        static member Value (ruleWidth: IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member Thin = Thin |> columnRuleWidthValue'
        static member Medium = Medium |> columnRuleWidthValue'
        static member Thick = Thick |> columnRuleWidthValue'
        static member Inherit = Inherit |> columnRuleWidthValue'
        static member Initial = Initial |> columnRuleWidthValue'
        static member Unset = Unset |> columnRuleWidthValue'

    let ColumnRuleWidth' (ruleWidth: IColumnRuleWidth) = ruleWidth |> ColumnRuleWidth.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue value = PropertyValue.cssValue Property.ColumnRuleStyle value
    let private styleValue' value =
        value
        |> columnRuleStyleToString
        |> styleValue

    type ColumnRuleStyle =
        static member Value (style: IColumnRuleStyle) = style |> styleValue'
        static member Hidden = Hidden |> styleValue'
        static member Dotted = Dotted |> styleValue'
        static member Dashed = Dashed |> styleValue'
        static member Solid = Solid |> styleValue'
        static member Double = Double |> styleValue'
        static member Groove = Groove |> styleValue'
        static member Ridge = Ridge |> styleValue'
        static member Inset = Inset |> styleValue'
        static member Outset = Outset |> styleValue'

        static member None = None |> styleValue'
        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    let ColumnRuleStyle' (style: IColumnRuleStyle) = ColumnRuleStyle.Value(style)

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue value = PropertyValue.cssValue Property.ColumnRuleColor value
    let private columnRuleColorValue' value =
        value
        |> columnRuleColorToString
        |> columnRuleColorValue

    type ColumnRuleColor =
        static member Value (color: IColumnRuleColor) = color |> columnRuleColorValue'
        static member black = CSSColor.black |> columnRuleColorValue'
        static member silver = CSSColor.silver |> columnRuleColorValue'
        static member gray = CSSColor.gray |> columnRuleColorValue'
        static member white = CSSColor.white |> columnRuleColorValue'
        static member maroon = CSSColor.maroon |> columnRuleColorValue'
        static member red = CSSColor.red |> columnRuleColorValue'
        static member purple = CSSColor.purple |> columnRuleColorValue'
        static member fuchsia = CSSColor.fuchsia |> columnRuleColorValue'
        static member green = CSSColor.green |> columnRuleColorValue'
        static member lime = CSSColor.lime |> columnRuleColorValue'
        static member olive = CSSColor.olive |> columnRuleColorValue'
        static member yellow = CSSColor.yellow |> columnRuleColorValue'
        static member navy = CSSColor.navy |> columnRuleColorValue'
        static member blue = CSSColor.blue |> columnRuleColorValue'
        static member teal = CSSColor.teal |> columnRuleColorValue'
        static member aqua = CSSColor.aqua |> columnRuleColorValue'
        static member orange = CSSColor.orange |> columnRuleColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> columnRuleColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> columnRuleColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> columnRuleColorValue'
        static member azure = CSSColor.azure |> columnRuleColorValue'
        static member beige = CSSColor.beige |> columnRuleColorValue'
        static member bisque = CSSColor.bisque |> columnRuleColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> columnRuleColorValue'
        static member blueViolet = CSSColor.blueViolet |> columnRuleColorValue'
        static member brown = CSSColor.brown |> columnRuleColorValue'
        static member burlywood = CSSColor.burlywood |> columnRuleColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> columnRuleColorValue'
        static member chartreuse = CSSColor.chartreuse |> columnRuleColorValue'
        static member chocolate = CSSColor.chocolate |> columnRuleColorValue'
        static member coral = CSSColor.coral |> columnRuleColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> columnRuleColorValue'
        static member cornsilk = CSSColor.cornsilk |> columnRuleColorValue'
        static member crimson = CSSColor.crimson |> columnRuleColorValue'
        static member cyan = CSSColor.cyan |> columnRuleColorValue'
        static member darkBlue = CSSColor.darkBlue |> columnRuleColorValue'
        static member darkCyan = CSSColor.darkCyan |> columnRuleColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> columnRuleColorValue'
        static member darkGray = CSSColor.darkGray |> columnRuleColorValue'
        static member darkGreen = CSSColor.darkGreen |> columnRuleColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> columnRuleColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> columnRuleColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> columnRuleColorValue'
        static member darkOrange = CSSColor.darkOrange |> columnRuleColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> columnRuleColorValue'
        static member darkRed = CSSColor.darkRed |> columnRuleColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> columnRuleColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> columnRuleColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> columnRuleColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> columnRuleColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> columnRuleColorValue'
        static member darkViolet = CSSColor.darkViolet |> columnRuleColorValue'
        static member deepPink = CSSColor.deepPink |> columnRuleColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> columnRuleColorValue'
        static member dimGrey = CSSColor.dimGrey |> columnRuleColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> columnRuleColorValue'
        static member fireBrick = CSSColor.fireBrick |> columnRuleColorValue'
        static member floralWhite = CSSColor.floralWhite |> columnRuleColorValue'
        static member forestGreen = CSSColor.forestGreen |> columnRuleColorValue'
        static member gainsboro = CSSColor.gainsboro |> columnRuleColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> columnRuleColorValue'
        static member gold = CSSColor.gold |> columnRuleColorValue'
        static member goldenrod = CSSColor.goldenrod |> columnRuleColorValue'
        static member greenYellow = CSSColor.greenYellow |> columnRuleColorValue'
        static member grey = CSSColor.grey |> columnRuleColorValue'
        static member honeydew = CSSColor.honeydew |> columnRuleColorValue'
        static member hotPink = CSSColor.hotPink |> columnRuleColorValue'
        static member indianRed = CSSColor.indianRed |> columnRuleColorValue'
        static member indigo = CSSColor.indigo |> columnRuleColorValue'
        static member ivory = CSSColor.ivory |> columnRuleColorValue'
        static member khaki = CSSColor.khaki |> columnRuleColorValue'
        static member lavender = CSSColor.lavender |> columnRuleColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> columnRuleColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> columnRuleColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> columnRuleColorValue'
        static member lightBlue = CSSColor.lightBlue |> columnRuleColorValue'
        static member lightCoral = CSSColor.lightCoral |> columnRuleColorValue'
        static member lightCyan = CSSColor.lightCyan |> columnRuleColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> columnRuleColorValue'
        static member lightGray = CSSColor.lightGray |> columnRuleColorValue'
        static member lightGreen = CSSColor.lightGreen |> columnRuleColorValue'
        static member lightGrey = CSSColor.lightGrey |> columnRuleColorValue'
        static member lightPink = CSSColor.lightPink |> columnRuleColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> columnRuleColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> columnRuleColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> columnRuleColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> columnRuleColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> columnRuleColorValue'
        static member lightYellow = CSSColor.lightYellow |> columnRuleColorValue'
        static member limeGreen = CSSColor.limeGreen |> columnRuleColorValue'
        static member linen = CSSColor.linen |> columnRuleColorValue'
        static member magenta = CSSColor.magenta |> columnRuleColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> columnRuleColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> columnRuleColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> columnRuleColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> columnRuleColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> columnRuleColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> columnRuleColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> columnRuleColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> columnRuleColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> columnRuleColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> columnRuleColorValue'
        static member mintCream = CSSColor.mintCream |> columnRuleColorValue'
        static member mistyRose = CSSColor.mistyRose |> columnRuleColorValue'
        static member moccasin = CSSColor.moccasin |> columnRuleColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> columnRuleColorValue'
        static member oldLace = CSSColor.oldLace |> columnRuleColorValue'
        static member olivedrab = CSSColor.olivedrab |> columnRuleColorValue'
        static member orangeRed = CSSColor.orangeRed |> columnRuleColorValue'
        static member orchid = CSSColor.orchid |> columnRuleColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> columnRuleColorValue'
        static member paleGreen = CSSColor.paleGreen |> columnRuleColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> columnRuleColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> columnRuleColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> columnRuleColorValue'
        static member peachpuff = CSSColor.peachpuff |> columnRuleColorValue'
        static member peru = CSSColor.peru |> columnRuleColorValue'
        static member pink = CSSColor.pink |> columnRuleColorValue'
        static member plum = CSSColor.plum |> columnRuleColorValue'
        static member powderBlue = CSSColor.powderBlue |> columnRuleColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> columnRuleColorValue'
        static member royalBlue = CSSColor.royalBlue |> columnRuleColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> columnRuleColorValue'
        static member salmon = CSSColor.salmon |> columnRuleColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> columnRuleColorValue'
        static member seaGreen = CSSColor.seaGreen |> columnRuleColorValue'
        static member seaShell = CSSColor.seaShell |> columnRuleColorValue'
        static member sienna = CSSColor.sienna |> columnRuleColorValue'
        static member skyBlue = CSSColor.skyBlue |> columnRuleColorValue'
        static member slateBlue = CSSColor.slateBlue |> columnRuleColorValue'
        static member slateGray = CSSColor.slateGray |> columnRuleColorValue'
        static member snow = CSSColor.snow |> columnRuleColorValue'
        static member springGreen = CSSColor.springGreen |> columnRuleColorValue'
        static member steelBlue = CSSColor.steelBlue |> columnRuleColorValue'
        static member tan = CSSColor.tan |> columnRuleColorValue'
        static member thistle = CSSColor.thistle |> columnRuleColorValue'
        static member tomato = CSSColor.tomato |> columnRuleColorValue'
        static member turquoise = CSSColor.turquoise |> columnRuleColorValue'
        static member violet = CSSColor.violet |> columnRuleColorValue'
        static member wheat = CSSColor.wheat |> columnRuleColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> columnRuleColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> columnRuleColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> columnRuleColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> columnRuleColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> columnRuleColorValue'
        static member Hex value = CSSColor.Hex value |> columnRuleColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> columnRuleColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> columnRuleColorValue'
        static member transparent = CSSColor.transparent |> columnRuleColorValue'
        static member currentColor = CSSColor.currentColor |> columnRuleColorValue'

        static member Inherit = Inherit |> columnRuleColorValue'
        static member Initial = Initial |> columnRuleColorValue'
        static member Unset = Unset |> columnRuleColorValue'

    let ColumnRuleColor' (color: IColumnRuleColor) = ColumnRuleColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
    let private columnCountValue value = PropertyValue.cssValue Property.ColumnCount value
    let private columnCountValue' value =
        value
        |> columnCountToString
        |> columnCountValue

    type ColumnCount =
        static member Value(columnCount: IColumnCount) = columnCount |> columnCountValue'
        static member Auto = Auto |> columnCountValue'
        static member Inherit = Inherit |> columnCountValue'
        static member Initial = Initial |> columnCountValue'
        static member Unset = Unset |> columnCountValue'

    let ColumnCount' (columnCount: IColumnCount) = ColumnCount.Value(columnCount)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue value = PropertyValue.cssValue Property.ColumnFill value
    let private columnFillValue' value =
        value
        |> columnFillToString
        |> columnFillValue

    type ColumnFill =
        static member Value(columnFill: IColumnFill) = columnFill |> columnFillValue'
        static member Balance = Balance |> columnFillValue'
        static member BalanceAll = BalanceAll |> columnFillValue'
        static member Auto = Auto |> columnFillValue'
        static member Inherit = Inherit |> columnFillValue'
        static member Initial = Initial |> columnFillValue'
        static member Unset = Unset |> columnFillValue'

    let ColumnFill' (columnFill: IColumnFill) = ColumnFill.Value(columnFill)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    let private columnWidthValue value = PropertyValue.cssValue Property.ColumnWidth value
    let private columnWidthValue' value =
        value
        |> columnWidthToString
        |> columnWidthValue

    type ColumnWidth =
        static member Value(columnWidth: IColumnWidth) = columnWidth |> columnWidthValue'
        static member Auto = Auto |> columnWidthValue'
        static member Inherit = Inherit |> columnWidthValue'
        static member Initial = Initial |> columnWidthValue'
        static member Unset = Unset |> columnWidthValue'

    let ColumnWidth' (columnWidth: IColumnWidth) = ColumnWidth.Value(columnWidth)