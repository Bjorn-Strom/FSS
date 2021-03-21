namespace Fss

[<AutoOpen>]
module Column =

    let private columnGapToString (gap: Types.IColumnGap) =
        match gap with
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | _ -> "Unknown column gap"

    let private columnSpanToString (span: Types.IColumnSpan) =
        let stringifyColumnSpan =
            function
                | Types.ColumnSpan.All -> "all"

        match span with
        | :? Types.ColumnSpan as c -> stringifyColumnSpan c
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown column span"

    let private columnsToString(columns: Types.IColumns) =
        match columns with
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown columns"

    let private columnRuleToString(columnRule: Types.IColumnRule) =
        match columnRule with
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule"

    let private columnRuleWidthToString (ruleWidth: Types.IColumnRuleWidth) =
        match ruleWidth with
        | :? Types.ColumnRuleWidth as w -> Utilities.Helpers.duToLowercase w
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: Types.IColumnRuleStyle) =
        match style with
        | :? Types.ColumnRuleStyle as b -> Utilities.Helpers.duToLowercase b
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column style"

    let private columnRuleColorToString (columnColor: Types.IColumnRuleColor) =
        match columnColor with
        | :? Types.Color as c -> Types.colorHelpers.colorToString c
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule color"

    let private columnCountToString (columnCount: Types.IColumnCount) =
        match columnCount with
        | :? Types.CssInt as i -> Types.masterTypeHelpers.IntToString i
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column count"

    let private columnFillToString (columnFill: Types.IColumnFill) =
        match columnFill with
        | :? Types.ColumnFill as c -> Utilities.Helpers.duToKebab c
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column fill"

    let private columnWidthToString (columnWidth: Types.IColumnWidth) =
        match columnWidth with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column width"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue value = Types.propertyHelpers.cssValue Types.Property.ColumnGap value
    let private columnGapValue' value =
        value
        |> columnGapToString
        |> columnGapValue
    type ColumnGap =
        static member Value (gap: Types.IColumnGap) = gap |> columnGapValue'
        static member Inherit = Types.Inherit |> columnGapValue'
        static member Initial = Types.Initial |> columnGapValue'
        static member Unset = Types.Unset |> columnGapValue'
        static member Normal = Types.Normal |> columnGapValue'

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
    let ColumnGap' (columnGap: Types.IColumnGap) = ColumnGap.Value(columnGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue value = Types.propertyHelpers.cssValue Types.Property.ColumnSpan value
    let private columnSpanValue' value =
        value
        |> columnSpanToString
        |> columnSpanValue

    type ColumnSpan =
        static member Value(span: Types.IColumnSpan) = span |> columnSpanValue'
        static member All = Types.ColumnSpan.All |> columnSpanValue'
        static member Inherit = Types.Inherit |> columnSpanValue'
        static member Initial = Types.Initial |> columnSpanValue'
        static member Unset = Types.Unset |> columnSpanValue'
        static member None = Types.None' |> columnSpanValue'

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
    let ColumnSpan' (span: Types.IColumnSpan) = ColumnSpan.Value(span)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/columns
    let private columnsValue value = Types.propertyHelpers.cssValue Types.Property.Columns value
    let private columnsValue' value =
        value
        |> columnsToString
        |> columnsValue

    type Columns =
        static member Value (columns: Types.IColumns) = columns |> columnsValue'
        static member Inherit = Types.Inherit |> columnsValue'
        static member Initial = Types.Initial |> columnsValue'
        static member Unset = Types.Unset |> columnsValue'

    /// <summary>Resets columns.</summary>
    /// <param name="columns">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Columns' (columns: Types.IColumns) = columns |> Columns.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    let private columnRuleValue value = Types.propertyHelpers.cssValue Types.Property.ColumnRule value
    let private columnRuleValue' value =
        value
        |> columnRuleToString
        |> columnRuleValue

    type ColumnRule =
        static member Value (rule: Types.IColumnRule) = rule |> columnRuleValue'
        static member Inherit = Types.Inherit |> columnRuleValue'
        static member Initial = Types.Initial |> columnRuleValue'
        static member Unset = Types.Unset |> columnRuleValue'

    /// <summary>Resets column rule.</summary>
    /// <param name="rule">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRule' (rule: Types.IColumnRule) = rule |> ColumnRule.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue value = Types.propertyHelpers.cssValue Types.Property.ColumnRuleWidth value
    let private columnRuleWidthValue' value =
        value
        |> columnRuleWidthToString
        |> columnRuleWidthValue

    type ColumnRuleWidth =
        static member Value (ruleWidth: Types.IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member Thin = Types.ColumnRuleWidth.Thin |> columnRuleWidthValue'
        static member Medium = Types.ColumnRuleWidth.Medium |> columnRuleWidthValue'
        static member Thick = Types.ColumnRuleWidth.Thick |> columnRuleWidthValue'
        static member Inherit = Types.Inherit |> columnRuleWidthValue'
        static member Initial = Types.Initial |> columnRuleWidthValue'
        static member Unset = Types.Unset |> columnRuleWidthValue'

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
    let ColumnRuleWidth' (ruleWidth: Types.IColumnRuleWidth) = ruleWidth |> ColumnRuleWidth.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue value = Types.propertyHelpers.cssValue Types.Property.ColumnRuleStyle value
    let private styleValue' value =
        value
        |> columnRuleStyleToString
        |> styleValue

    type ColumnRuleStyle =
        static member Value (style: Types.IColumnRuleStyle) = style |> styleValue'
        static member Hidden = Types.ColumnRuleStyle.Hidden |> styleValue'
        static member Dotted = Types.ColumnRuleStyle.Dotted |> styleValue'
        static member Dashed = Types.ColumnRuleStyle.Dashed |> styleValue'
        static member Solid = Types.ColumnRuleStyle.Solid |> styleValue'
        static member Double = Types.ColumnRuleStyle.Double |> styleValue'
        static member Groove = Types.ColumnRuleStyle.Groove |> styleValue'
        static member Ridge = Types.ColumnRuleStyle.Ridge |> styleValue'
        static member Inset = Types.ColumnRuleStyle.Inset |> styleValue'
        static member Outset = Types.ColumnRuleStyle.Outset |> styleValue'

        static member None = Types.None' |> styleValue'
        static member Inherit = Types.Inherit |> styleValue'
        static member Initial = Types.Initial |> styleValue'
        static member Unset = Types.Unset |> styleValue'

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
    let ColumnRuleStyle' (style: Types.IColumnRuleStyle) = ColumnRuleStyle.Value(style)

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue value = Types.propertyHelpers.cssValue Types.Property.ColumnRuleColor value
    let private columnRuleColorValue' value =
        value
        |> columnRuleColorToString
        |> columnRuleColorValue

    type ColumnRuleColor =
        static member Value (color: Types.IColumnRuleColor) = color |> columnRuleColorValue'
        static member black = Types.Color.black |> columnRuleColorValue'
        static member silver = Types.Color.silver |> columnRuleColorValue'
        static member gray = Types.Color.gray |> columnRuleColorValue'
        static member white = Types.Color.white |> columnRuleColorValue'
        static member maroon = Types.Color.maroon |> columnRuleColorValue'
        static member red = Types.Color.red |> columnRuleColorValue'
        static member purple = Types.Color.purple |> columnRuleColorValue'
        static member fuchsia = Types.Color.fuchsia |> columnRuleColorValue'
        static member green = Types.Color.green |> columnRuleColorValue'
        static member lime = Types.Color.lime |> columnRuleColorValue'
        static member olive = Types.Color.olive |> columnRuleColorValue'
        static member yellow = Types.Color.yellow |> columnRuleColorValue'
        static member navy = Types.Color.navy |> columnRuleColorValue'
        static member blue = Types.Color.blue |> columnRuleColorValue'
        static member teal = Types.Color.teal |> columnRuleColorValue'
        static member aqua = Types.Color.aqua |> columnRuleColorValue'
        static member orange = Types.Color.orange |> columnRuleColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> columnRuleColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> columnRuleColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> columnRuleColorValue'
        static member azure = Types.Color.azure |> columnRuleColorValue'
        static member beige = Types.Color.beige |> columnRuleColorValue'
        static member bisque = Types.Color.bisque |> columnRuleColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> columnRuleColorValue'
        static member blueViolet = Types.Color.blueViolet |> columnRuleColorValue'
        static member brown = Types.Color.brown |> columnRuleColorValue'
        static member burlywood = Types.Color.burlywood |> columnRuleColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> columnRuleColorValue'
        static member chartreuse = Types.Color.chartreuse |> columnRuleColorValue'
        static member chocolate = Types.Color.chocolate |> columnRuleColorValue'
        static member coral = Types.Color.coral |> columnRuleColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> columnRuleColorValue'
        static member cornsilk = Types.Color.cornsilk |> columnRuleColorValue'
        static member crimson = Types.Color.crimson |> columnRuleColorValue'
        static member cyan = Types.Color.cyan |> columnRuleColorValue'
        static member darkBlue = Types.Color.darkBlue |> columnRuleColorValue'
        static member darkCyan = Types.Color.darkCyan |> columnRuleColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> columnRuleColorValue'
        static member darkGray = Types.Color.darkGray |> columnRuleColorValue'
        static member darkGreen = Types.Color.darkGreen |> columnRuleColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> columnRuleColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> columnRuleColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> columnRuleColorValue'
        static member darkOrange = Types.Color.darkOrange |> columnRuleColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> columnRuleColorValue'
        static member darkRed = Types.Color.darkRed |> columnRuleColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> columnRuleColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> columnRuleColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> columnRuleColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> columnRuleColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> columnRuleColorValue'
        static member darkViolet = Types.Color.darkViolet |> columnRuleColorValue'
        static member deepPink = Types.Color.deepPink |> columnRuleColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> columnRuleColorValue'
        static member dimGrey = Types.Color.dimGrey |> columnRuleColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> columnRuleColorValue'
        static member fireBrick = Types.Color.fireBrick |> columnRuleColorValue'
        static member floralWhite = Types.Color.floralWhite |> columnRuleColorValue'
        static member forestGreen = Types.Color.forestGreen |> columnRuleColorValue'
        static member gainsboro = Types.Color.gainsboro |> columnRuleColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> columnRuleColorValue'
        static member gold = Types.Color.gold |> columnRuleColorValue'
        static member goldenrod = Types.Color.goldenrod |> columnRuleColorValue'
        static member greenYellow = Types.Color.greenYellow |> columnRuleColorValue'
        static member grey = Types.Color.grey |> columnRuleColorValue'
        static member honeydew = Types.Color.honeydew |> columnRuleColorValue'
        static member hotPink = Types.Color.hotPink |> columnRuleColorValue'
        static member indianRed = Types.Color.indianRed |> columnRuleColorValue'
        static member indigo = Types.Color.indigo |> columnRuleColorValue'
        static member ivory = Types.Color.ivory |> columnRuleColorValue'
        static member khaki = Types.Color.khaki |> columnRuleColorValue'
        static member lavender = Types.Color.lavender |> columnRuleColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> columnRuleColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> columnRuleColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> columnRuleColorValue'
        static member lightBlue = Types.Color.lightBlue |> columnRuleColorValue'
        static member lightCoral = Types.Color.lightCoral |> columnRuleColorValue'
        static member lightCyan = Types.Color.lightCyan |> columnRuleColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> columnRuleColorValue'
        static member lightGray = Types.Color.lightGray |> columnRuleColorValue'
        static member lightGreen = Types.Color.lightGreen |> columnRuleColorValue'
        static member lightGrey = Types.Color.lightGrey |> columnRuleColorValue'
        static member lightPink = Types.Color.lightPink |> columnRuleColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> columnRuleColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> columnRuleColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> columnRuleColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> columnRuleColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> columnRuleColorValue'
        static member lightYellow = Types.Color.lightYellow |> columnRuleColorValue'
        static member limeGreen = Types.Color.limeGreen |> columnRuleColorValue'
        static member linen = Types.Color.linen |> columnRuleColorValue'
        static member magenta = Types.Color.magenta |> columnRuleColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> columnRuleColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> columnRuleColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> columnRuleColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> columnRuleColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> columnRuleColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> columnRuleColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> columnRuleColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> columnRuleColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> columnRuleColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> columnRuleColorValue'
        static member mintCream = Types.Color.mintCream |> columnRuleColorValue'
        static member mistyRose = Types.Color.mistyRose |> columnRuleColorValue'
        static member moccasin = Types.Color.moccasin |> columnRuleColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> columnRuleColorValue'
        static member oldLace = Types.Color.oldLace |> columnRuleColorValue'
        static member olivedrab = Types.Color.olivedrab |> columnRuleColorValue'
        static member orangeRed = Types.Color.orangeRed |> columnRuleColorValue'
        static member orchid = Types.Color.orchid |> columnRuleColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> columnRuleColorValue'
        static member paleGreen = Types.Color.paleGreen |> columnRuleColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> columnRuleColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> columnRuleColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> columnRuleColorValue'
        static member peachpuff = Types.Color.peachpuff |> columnRuleColorValue'
        static member peru = Types.Color.peru |> columnRuleColorValue'
        static member pink = Types.Color.pink |> columnRuleColorValue'
        static member plum = Types.Color.plum |> columnRuleColorValue'
        static member powderBlue = Types.Color.powderBlue |> columnRuleColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> columnRuleColorValue'
        static member royalBlue = Types.Color.royalBlue |> columnRuleColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> columnRuleColorValue'
        static member salmon = Types.Color.salmon |> columnRuleColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> columnRuleColorValue'
        static member seaGreen = Types.Color.seaGreen |> columnRuleColorValue'
        static member seaShell = Types.Color.seaShell |> columnRuleColorValue'
        static member sienna = Types.Color.sienna |> columnRuleColorValue'
        static member skyBlue = Types.Color.skyBlue |> columnRuleColorValue'
        static member slateBlue = Types.Color.slateBlue |> columnRuleColorValue'
        static member slateGray = Types.Color.slateGray |> columnRuleColorValue'
        static member snow = Types.Color.snow |> columnRuleColorValue'
        static member springGreen = Types.Color.springGreen |> columnRuleColorValue'
        static member steelBlue = Types.Color.steelBlue |> columnRuleColorValue'
        static member tan = Types.Color.tan |> columnRuleColorValue'
        static member thistle = Types.Color.thistle |> columnRuleColorValue'
        static member tomato = Types.Color.tomato |> columnRuleColorValue'
        static member turquoise = Types.Color.turquoise |> columnRuleColorValue'
        static member violet = Types.Color.violet |> columnRuleColorValue'
        static member wheat = Types.Color.wheat |> columnRuleColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> columnRuleColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> columnRuleColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> columnRuleColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> columnRuleColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> columnRuleColorValue'
        static member Hex value = Types.Color.Hex value |> columnRuleColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> columnRuleColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> columnRuleColorValue'
        static member transparent = Types.Color.transparent |> columnRuleColorValue'
        static member currentColor = Types.Color.currentColor |> columnRuleColorValue'

        static member Inherit = Types.Inherit |> columnRuleColorValue'
        static member Initial = Types.Initial |> columnRuleColorValue'
        static member Unset = Types.Unset |> columnRuleColorValue'

    /// <summary>Specifies color of the line drawn between columns.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleColor' (color: Types.IColumnRuleColor) = ColumnRuleColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
    let private columnCountValue value = Types.propertyHelpers.cssValue Types.Property.ColumnCount value
    let private columnCountValue' value =
        value
        |> columnCountToString
        |> columnCountValue

    type ColumnCount =
        static member Value(columnCount: Types.IColumnCount) = columnCount |> columnCountValue'
        static member Auto = Types.Auto |> columnCountValue'
        static member Inherit = Types.Inherit |> columnCountValue'
        static member Initial = Types.Initial |> columnCountValue'
        static member Unset = Types.Unset |> columnCountValue'

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
    let ColumnCount' (columnCount: Types.IColumnCount) = ColumnCount.Value(columnCount)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue value = Types.propertyHelpers.cssValue Types.Property.ColumnFill value
    let private columnFillValue' value =
        value
        |> columnFillToString
        |> columnFillValue

    type ColumnFill =
        static member Value(columnFill: Types.IColumnFill) = columnFill |> columnFillValue'
        static member Balance = Types.ColumnFill.Balance |> columnFillValue'
        static member BalanceAll = Types.ColumnFill.BalanceAll |> columnFillValue'
        static member Auto = Types.Auto |> columnFillValue'
        static member Inherit = Types.Inherit |> columnFillValue'
        static member Initial = Types.Initial |> columnFillValue'
        static member Unset = Types.Unset |> columnFillValue'

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
    let ColumnFill' (columnFill: Types.IColumnFill) = ColumnFill.Value(columnFill)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    let private columnWidthValue value = Types.propertyHelpers.cssValue Types.Property.ColumnWidth value
    let private columnWidthValue' value =
        value
        |> columnWidthToString
        |> columnWidthValue

    type ColumnWidth =
        static member Value(columnWidth: Types.IColumnWidth) = columnWidth |> columnWidthValue'
        static member Auto = Types.Auto |> columnWidthValue'
        static member Inherit = Types.Inherit |> columnWidthValue'
        static member Initial = Types.Initial |> columnWidthValue'
        static member Unset = Types.Unset |> columnWidthValue'

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
    let ColumnWidth' (columnWidth: Types.IColumnWidth) = ColumnWidth.Value(columnWidth)