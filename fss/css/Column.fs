namespace Fss

[<RequireQualifiedAccess>]
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
                | ColumnType.All -> "all"

        match span with
        | :? ColumnType.ColumnSpan as c -> stringifyColumnSpan c
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
        | :? ColumnType.ColumnRuleWidth as w -> Utilities.Helpers.duToLowercase w
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: IColumnRuleStyle) =
        match style with
        | :? ColumnType.ColumnRuleStyle as b -> Utilities.Helpers.duToLowercase b
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown column style"

    let private columnRuleColorToString (columnColor: IColumnRuleColor) =
        match columnColor with
        | :? CssColor as c -> CssColorValue.color c
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
        | :? ColumnType.ColumnFill as c -> Utilities.Helpers.duToKebab c
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

    /// <summary>Sets gap width between element.</summary>
    /// <param name="columnGap">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnGap' (columnGap: IColumnGap) = ColumnGap.Value(columnGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue value = PropertyValue.cssValue Property.ColumnSpan value
    let private columnSpanValue' value =
        value
        |> columnSpanToString
        |> columnSpanValue

    type ColumnSpan =
        static member Value(span: IColumnSpan) = span |> columnSpanValue'
        static member All = ColumnType.All |> columnSpanValue'
        static member Inherit = Inherit |> columnSpanValue'
        static member Initial = Initial |> columnSpanValue'
        static member Unset = Unset |> columnSpanValue'
        static member None = None |> columnSpanValue'

    /// <summary>Sets gap width between element.</summary>
    /// <param name="span">
    ///     can be:
    ///     - <c> ColumnSpan </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Resets columns.</summary>
    /// <param name="columns">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Resets column rule.</summary>
    /// <param name="rule">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRule' (rule: IColumnRule) = rule |> ColumnRule.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue value = PropertyValue.cssValue Property.ColumnRuleWidth value
    let private columnRuleWidthValue' value =
        value
        |> columnRuleWidthToString
        |> columnRuleWidthValue

    type ColumnRuleWidth =
        static member Value (ruleWidth: IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member Thin = ColumnType.Thin |> columnRuleWidthValue'
        static member Medium = ColumnType.Medium |> columnRuleWidthValue'
        static member Thick = ColumnType.Thick |> columnRuleWidthValue'
        static member Inherit = Inherit |> columnRuleWidthValue'
        static member Initial = Initial |> columnRuleWidthValue'
        static member Unset = Unset |> columnRuleWidthValue'

    /// <summary>Specifies width of the line drawn between columns.</summary>
    /// <param name="ruleWidth">
    ///     can be:
    ///     - <c> ColumnRuleWidth </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleWidth' (ruleWidth: IColumnRuleWidth) = ruleWidth |> ColumnRuleWidth.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue value = PropertyValue.cssValue Property.ColumnRuleStyle value
    let private styleValue' value =
        value
        |> columnRuleStyleToString
        |> styleValue

    type ColumnRuleStyle =
        static member Value (style: IColumnRuleStyle) = style |> styleValue'
        static member Hidden = ColumnType.Hidden |> styleValue'
        static member Dotted = ColumnType.Dotted |> styleValue'
        static member Dashed = ColumnType.Dashed |> styleValue'
        static member Solid = ColumnType.Solid |> styleValue'
        static member Double = ColumnType.Double |> styleValue'
        static member Groove = ColumnType.Groove |> styleValue'
        static member Ridge = ColumnType.Ridge |> styleValue'
        static member Inset = ColumnType.Inset |> styleValue'
        static member Outset = ColumnType.Outset |> styleValue'

        static member None = None |> styleValue'
        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    /// <summary>Specifies style of the line drawn between columns.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> ColumnRuleStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleStyle' (style: IColumnRuleStyle) = ColumnRuleStyle.Value(style)

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue value = PropertyValue.cssValue Property.ColumnRuleColor value
    let private columnRuleColorValue' value =
        value
        |> columnRuleColorToString
        |> columnRuleColorValue

    type ColumnRuleColor =
        static member Value (color: IColumnRuleColor) = color |> columnRuleColorValue'
        static member black = CssColor.black |> columnRuleColorValue'
        static member silver = CssColor.silver |> columnRuleColorValue'
        static member gray = CssColor.gray |> columnRuleColorValue'
        static member white = CssColor.white |> columnRuleColorValue'
        static member maroon = CssColor.maroon |> columnRuleColorValue'
        static member red = CssColor.red |> columnRuleColorValue'
        static member purple = CssColor.purple |> columnRuleColorValue'
        static member fuchsia = CssColor.fuchsia |> columnRuleColorValue'
        static member green = CssColor.green |> columnRuleColorValue'
        static member lime = CssColor.lime |> columnRuleColorValue'
        static member olive = CssColor.olive |> columnRuleColorValue'
        static member yellow = CssColor.yellow |> columnRuleColorValue'
        static member navy = CssColor.navy |> columnRuleColorValue'
        static member blue = CssColor.blue |> columnRuleColorValue'
        static member teal = CssColor.teal |> columnRuleColorValue'
        static member aqua = CssColor.aqua |> columnRuleColorValue'
        static member orange = CssColor.orange |> columnRuleColorValue'
        static member aliceBlue = CssColor.aliceBlue |> columnRuleColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> columnRuleColorValue'
        static member aquaMarine = CssColor.aquaMarine |> columnRuleColorValue'
        static member azure = CssColor.azure |> columnRuleColorValue'
        static member beige = CssColor.beige |> columnRuleColorValue'
        static member bisque = CssColor.bisque |> columnRuleColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> columnRuleColorValue'
        static member blueViolet = CssColor.blueViolet |> columnRuleColorValue'
        static member brown = CssColor.brown |> columnRuleColorValue'
        static member burlywood = CssColor.burlywood |> columnRuleColorValue'
        static member cadetBlue = CssColor.cadetBlue |> columnRuleColorValue'
        static member chartreuse = CssColor.chartreuse |> columnRuleColorValue'
        static member chocolate = CssColor.chocolate |> columnRuleColorValue'
        static member coral = CssColor.coral |> columnRuleColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> columnRuleColorValue'
        static member cornsilk = CssColor.cornsilk |> columnRuleColorValue'
        static member crimson = CssColor.crimson |> columnRuleColorValue'
        static member cyan = CssColor.cyan |> columnRuleColorValue'
        static member darkBlue = CssColor.darkBlue |> columnRuleColorValue'
        static member darkCyan = CssColor.darkCyan |> columnRuleColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> columnRuleColorValue'
        static member darkGray = CssColor.darkGray |> columnRuleColorValue'
        static member darkGreen = CssColor.darkGreen |> columnRuleColorValue'
        static member darkKhaki = CssColor.darkKhaki |> columnRuleColorValue'
        static member darkMagenta = CssColor.darkMagenta |> columnRuleColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> columnRuleColorValue'
        static member darkOrange = CssColor.darkOrange |> columnRuleColorValue'
        static member darkOrchid = CssColor.darkOrchid |> columnRuleColorValue'
        static member darkRed = CssColor.darkRed |> columnRuleColorValue'
        static member darkSalmon = CssColor.darkSalmon |> columnRuleColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> columnRuleColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> columnRuleColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> columnRuleColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> columnRuleColorValue'
        static member darkViolet = CssColor.darkViolet |> columnRuleColorValue'
        static member deepPink = CssColor.deepPink |> columnRuleColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> columnRuleColorValue'
        static member dimGrey = CssColor.dimGrey |> columnRuleColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> columnRuleColorValue'
        static member fireBrick = CssColor.fireBrick |> columnRuleColorValue'
        static member floralWhite = CssColor.floralWhite |> columnRuleColorValue'
        static member forestGreen = CssColor.forestGreen |> columnRuleColorValue'
        static member gainsboro = CssColor.gainsboro |> columnRuleColorValue'
        static member ghostWhite = CssColor.ghostWhite |> columnRuleColorValue'
        static member gold = CssColor.gold |> columnRuleColorValue'
        static member goldenrod = CssColor.goldenrod |> columnRuleColorValue'
        static member greenYellow = CssColor.greenYellow |> columnRuleColorValue'
        static member grey = CssColor.grey |> columnRuleColorValue'
        static member honeydew = CssColor.honeydew |> columnRuleColorValue'
        static member hotPink = CssColor.hotPink |> columnRuleColorValue'
        static member indianRed = CssColor.indianRed |> columnRuleColorValue'
        static member indigo = CssColor.indigo |> columnRuleColorValue'
        static member ivory = CssColor.ivory |> columnRuleColorValue'
        static member khaki = CssColor.khaki |> columnRuleColorValue'
        static member lavender = CssColor.lavender |> columnRuleColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> columnRuleColorValue'
        static member lawnGreen = CssColor.lawnGreen |> columnRuleColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> columnRuleColorValue'
        static member lightBlue = CssColor.lightBlue |> columnRuleColorValue'
        static member lightCoral = CssColor.lightCoral |> columnRuleColorValue'
        static member lightCyan = CssColor.lightCyan |> columnRuleColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> columnRuleColorValue'
        static member lightGray = CssColor.lightGray |> columnRuleColorValue'
        static member lightGreen = CssColor.lightGreen |> columnRuleColorValue'
        static member lightGrey = CssColor.lightGrey |> columnRuleColorValue'
        static member lightPink = CssColor.lightPink |> columnRuleColorValue'
        static member lightSalmon = CssColor.lightSalmon |> columnRuleColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> columnRuleColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> columnRuleColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> columnRuleColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> columnRuleColorValue'
        static member lightYellow = CssColor.lightYellow |> columnRuleColorValue'
        static member limeGreen = CssColor.limeGreen |> columnRuleColorValue'
        static member linen = CssColor.linen |> columnRuleColorValue'
        static member magenta = CssColor.magenta |> columnRuleColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> columnRuleColorValue'
        static member mediumBlue = CssColor.mediumBlue |> columnRuleColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> columnRuleColorValue'
        static member mediumPurple = CssColor.mediumPurple |> columnRuleColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> columnRuleColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> columnRuleColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> columnRuleColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> columnRuleColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> columnRuleColorValue'
        static member midnightBlue = CssColor.midnightBlue |> columnRuleColorValue'
        static member mintCream = CssColor.mintCream |> columnRuleColorValue'
        static member mistyRose = CssColor.mistyRose |> columnRuleColorValue'
        static member moccasin = CssColor.moccasin |> columnRuleColorValue'
        static member navajoWhite = CssColor.navajoWhite |> columnRuleColorValue'
        static member oldLace = CssColor.oldLace |> columnRuleColorValue'
        static member olivedrab = CssColor.olivedrab |> columnRuleColorValue'
        static member orangeRed = CssColor.orangeRed |> columnRuleColorValue'
        static member orchid = CssColor.orchid |> columnRuleColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> columnRuleColorValue'
        static member paleGreen = CssColor.paleGreen |> columnRuleColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> columnRuleColorValue'
        static member paleVioletred = CssColor.paleVioletred |> columnRuleColorValue'
        static member papayaWhip = CssColor.papayaWhip |> columnRuleColorValue'
        static member peachpuff = CssColor.peachpuff |> columnRuleColorValue'
        static member peru = CssColor.peru |> columnRuleColorValue'
        static member pink = CssColor.pink |> columnRuleColorValue'
        static member plum = CssColor.plum |> columnRuleColorValue'
        static member powderBlue = CssColor.powderBlue |> columnRuleColorValue'
        static member rosyBrown = CssColor.rosyBrown |> columnRuleColorValue'
        static member royalBlue = CssColor.royalBlue |> columnRuleColorValue'
        static member saddleBrown = CssColor.saddleBrown |> columnRuleColorValue'
        static member salmon = CssColor.salmon |> columnRuleColorValue'
        static member sandyBrown = CssColor.sandyBrown |> columnRuleColorValue'
        static member seaGreen = CssColor.seaGreen |> columnRuleColorValue'
        static member seaShell = CssColor.seaShell |> columnRuleColorValue'
        static member sienna = CssColor.sienna |> columnRuleColorValue'
        static member skyBlue = CssColor.skyBlue |> columnRuleColorValue'
        static member slateBlue = CssColor.slateBlue |> columnRuleColorValue'
        static member slateGray = CssColor.slateGray |> columnRuleColorValue'
        static member snow = CssColor.snow |> columnRuleColorValue'
        static member springGreen = CssColor.springGreen |> columnRuleColorValue'
        static member steelBlue = CssColor.steelBlue |> columnRuleColorValue'
        static member tan = CssColor.tan |> columnRuleColorValue'
        static member thistle = CssColor.thistle |> columnRuleColorValue'
        static member tomato = CssColor.tomato |> columnRuleColorValue'
        static member turquoise = CssColor.turquoise |> columnRuleColorValue'
        static member violet = CssColor.violet |> columnRuleColorValue'
        static member wheat = CssColor.wheat |> columnRuleColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> columnRuleColorValue'
        static member yellowGreen = CssColor.yellowGreen |> columnRuleColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> columnRuleColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> columnRuleColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> columnRuleColorValue'
        static member Hex value = CssColor.Hex value |> columnRuleColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> columnRuleColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> columnRuleColorValue'
        static member transparent = CssColor.transparent |> columnRuleColorValue'
        static member currentColor = CssColor.currentColor |> columnRuleColorValue'

        static member Inherit = Inherit |> columnRuleColorValue'
        static member Initial = Initial |> columnRuleColorValue'
        static member Unset = Unset |> columnRuleColorValue'

    /// <summary>Specifies color of the line drawn between columns.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies number of column to break content into.</summary>
    /// <param name="columnCount">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnCount' (columnCount: IColumnCount) = ColumnCount.Value(columnCount)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue value = PropertyValue.cssValue Property.ColumnFill value
    let private columnFillValue' value =
        value
        |> columnFillToString
        |> columnFillValue

    type ColumnFill =
        static member Value(columnFill: IColumnFill) = columnFill |> columnFillValue'
        static member Balance = ColumnType.Balance |> columnFillValue'
        static member BalanceAll = ColumnType.BalanceAll |> columnFillValue'
        static member Auto = Auto |> columnFillValue'
        static member Inherit = Inherit |> columnFillValue'
        static member Initial = Initial |> columnFillValue'
        static member Unset = Unset |> columnFillValue'

    /// <summary>Specifies how content fills columns.</summary>
    /// <param name="columnFill">
    ///     can be:
    ///     - <c> ColumnFill </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies width of line drawn between column.</summary>
    /// <param name="columnWidth">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnWidth' (columnWidth: IColumnWidth) = ColumnWidth.Value(columnWidth)