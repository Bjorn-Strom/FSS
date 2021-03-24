namespace Fss

[<AutoOpen>]
module Column =
    let private columnGapToString (gap: FssTypes.IColumnGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown column gap"

    let private columnSpanToString (span: FssTypes.IColumnSpan) =
        let stringifyColumnSpan =
            function
                | FssTypes.Column.Span.All -> "all"

        match span with
        | :? FssTypes.Column.Span as c -> stringifyColumnSpan c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown column span"

    let private columnsToString(columns: FssTypes.IColumns) =
        match columns with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown columns"

    let private columnRuleToString(columnRule: FssTypes.IColumnRule) =
        match columnRule with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule"

    let private columnRuleWidthToString (ruleWidth: FssTypes.IColumnRuleWidth) =
        match ruleWidth with
        | :? FssTypes.Column.RuleWidth as w -> Utilities.Helpers.duToLowercase w
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: FssTypes.IColumnRuleStyle) =
        match style with
        | :? FssTypes.Column.RuleStyle as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column style"

    let private columnRuleColorToString (columnColor: FssTypes.IColumnRuleColor) =
        match columnColor with
        | :? FssTypes.ColorType as c -> FssTypes.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column rule color"

    let private columnCountToString (columnCount: FssTypes.IColumnCount) =
        match columnCount with
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column count"

    let private columnFillToString (columnFill: FssTypes.IColumnFill) =
        match columnFill with
        | :? FssTypes.Column.Fill as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column fill"

    let private columnWidthToString (columnWidth: FssTypes.IColumnWidth) =
        match columnWidth with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column width"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnGap value
    let private columnGapValue' value =
        value
        |> columnGapToString
        |> columnGapValue
    type ColumnGap =
        static member Value (gap: FssTypes.IColumnGap) = gap |> columnGapValue'
        static member Inherit = FssTypes.Inherit |> columnGapValue'
        static member Initial = FssTypes.Initial |> columnGapValue'
        static member Unset = FssTypes.Unset |> columnGapValue'
        static member Normal = FssTypes.Normal |> columnGapValue'

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
    let ColumnGap' (columnGap: FssTypes.IColumnGap) = ColumnGap.Value(columnGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnSpan value
    let private columnSpanValue' value =
        value
        |> columnSpanToString
        |> columnSpanValue

    type ColumnSpan =
        static member Value(span: FssTypes.IColumnSpan) = span |> columnSpanValue'
        static member All = FssTypes.Column.Span.All |> columnSpanValue'
        static member Inherit = FssTypes.Inherit |> columnSpanValue'
        static member Initial = FssTypes.Initial |> columnSpanValue'
        static member Unset = FssTypes.Unset |> columnSpanValue'
        static member None = FssTypes.None' |> columnSpanValue'

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
    let ColumnSpan' (span: FssTypes.IColumnSpan) = ColumnSpan.Value(span)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/columns
    let private columnsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Columns value
    let private columnsValue' value =
        value
        |> columnsToString
        |> columnsValue

    type Columns =
        static member Value (columns: FssTypes.IColumns) = columns |> columnsValue'
        static member Inherit = FssTypes.Inherit |> columnsValue'
        static member Initial = FssTypes.Initial |> columnsValue'
        static member Unset = FssTypes.Unset |> columnsValue'

    /// <summary>Resets columns.</summary>
    /// <param name="columns">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Columns' (columns: FssTypes.IColumns) = columns |> Columns.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    let private columnRuleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRule value
    let private columnRuleValue' value =
        value
        |> columnRuleToString
        |> columnRuleValue

    type ColumnRule =
        static member Value (rule: FssTypes.IColumnRule) = rule |> columnRuleValue'
        static member Inherit = FssTypes.Inherit |> columnRuleValue'
        static member Initial = FssTypes.Initial |> columnRuleValue'
        static member Unset = FssTypes.Unset |> columnRuleValue'

    /// <summary>Resets column rule.</summary>
    /// <param name="rule">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRule' (rule: FssTypes.IColumnRule) = rule |> ColumnRule.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleWidth value
    let private columnRuleWidthValue' value =
        value
        |> columnRuleWidthToString
        |> columnRuleWidthValue

    type ColumnRuleWidth =
        static member Value (ruleWidth: FssTypes.IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member Thin = FssTypes.Column.RuleWidth.Thin |> columnRuleWidthValue'
        static member Medium = FssTypes.Column.RuleWidth.Medium |> columnRuleWidthValue'
        static member Thick = FssTypes.Column.RuleWidth.Thick |> columnRuleWidthValue'
        static member Inherit = FssTypes.Inherit |> columnRuleWidthValue'
        static member Initial = FssTypes.Initial |> columnRuleWidthValue'
        static member Unset = FssTypes.Unset |> columnRuleWidthValue'

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
    let ColumnRuleWidth' (ruleWidth: FssTypes.IColumnRuleWidth) = ruleWidth |> ColumnRuleWidth.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleStyle value
    let private styleValue' value =
        value
        |> columnRuleStyleToString
        |> styleValue

    type ColumnRuleStyle =
        static member Value (style: FssTypes.IColumnRuleStyle) = style |> styleValue'
        static member Hidden = FssTypes.Column.RuleStyle.Hidden |> styleValue'
        static member Dotted = FssTypes.Column.RuleStyle.Dotted |> styleValue'
        static member Dashed = FssTypes.Column.RuleStyle.Dashed |> styleValue'
        static member Solid = FssTypes.Column.RuleStyle.Solid |> styleValue'
        static member Double = FssTypes.Column.RuleStyle.Double |> styleValue'
        static member Groove = FssTypes.Column.RuleStyle.Groove |> styleValue'
        static member Ridge = FssTypes.Column.RuleStyle.Ridge |> styleValue'
        static member Inset = FssTypes.Column.RuleStyle.Inset |> styleValue'
        static member Outset = FssTypes.Column.RuleStyle.Outset |> styleValue'

        static member None = FssTypes.None' |> styleValue'
        static member Inherit = FssTypes.Inherit |> styleValue'
        static member Initial = FssTypes.Initial |> styleValue'
        static member Unset = FssTypes.Unset |> styleValue'

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
    let ColumnRuleStyle' (style: FssTypes.IColumnRuleStyle) = ColumnRuleStyle.Value(style)

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleColor value
    let private columnRuleColorValue' value =
        value
        |> columnRuleColorToString
        |> columnRuleColorValue

    type ColumnRuleColor =
        static member Value (color: FssTypes.IColumnRuleColor) = color |> columnRuleColorValue'
        static member black = FssTypes.Color.black |> columnRuleColorValue'
        static member silver = FssTypes.Color.silver |> columnRuleColorValue'
        static member gray = FssTypes.Color.gray |> columnRuleColorValue'
        static member white = FssTypes.Color.white |> columnRuleColorValue'
        static member maroon = FssTypes.Color.maroon |> columnRuleColorValue'
        static member red = FssTypes.Color.red |> columnRuleColorValue'
        static member purple = FssTypes.Color.purple |> columnRuleColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> columnRuleColorValue'
        static member green = FssTypes.Color.green |> columnRuleColorValue'
        static member lime = FssTypes.Color.lime |> columnRuleColorValue'
        static member olive = FssTypes.Color.olive |> columnRuleColorValue'
        static member yellow = FssTypes.Color.yellow |> columnRuleColorValue'
        static member navy = FssTypes.Color.navy |> columnRuleColorValue'
        static member blue = FssTypes.Color.blue |> columnRuleColorValue'
        static member teal = FssTypes.Color.teal |> columnRuleColorValue'
        static member aqua = FssTypes.Color.aqua |> columnRuleColorValue'
        static member orange = FssTypes.Color.orange |> columnRuleColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> columnRuleColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> columnRuleColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> columnRuleColorValue'
        static member azure = FssTypes.Color.azure |> columnRuleColorValue'
        static member beige = FssTypes.Color.beige |> columnRuleColorValue'
        static member bisque = FssTypes.Color.bisque |> columnRuleColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> columnRuleColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> columnRuleColorValue'
        static member brown = FssTypes.Color.brown |> columnRuleColorValue'
        static member burlywood = FssTypes.Color.burlywood |> columnRuleColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> columnRuleColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> columnRuleColorValue'
        static member chocolate = FssTypes.Color.chocolate |> columnRuleColorValue'
        static member coral = FssTypes.Color.coral |> columnRuleColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> columnRuleColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> columnRuleColorValue'
        static member crimson = FssTypes.Color.crimson |> columnRuleColorValue'
        static member cyan = FssTypes.Color.cyan |> columnRuleColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> columnRuleColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> columnRuleColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> columnRuleColorValue'
        static member darkGray = FssTypes.Color.darkGray |> columnRuleColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> columnRuleColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> columnRuleColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> columnRuleColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> columnRuleColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> columnRuleColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> columnRuleColorValue'
        static member darkRed = FssTypes.Color.darkRed |> columnRuleColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> columnRuleColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> columnRuleColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> columnRuleColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> columnRuleColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> columnRuleColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> columnRuleColorValue'
        static member deepPink = FssTypes.Color.deepPink |> columnRuleColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> columnRuleColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> columnRuleColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> columnRuleColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> columnRuleColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> columnRuleColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> columnRuleColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> columnRuleColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> columnRuleColorValue'
        static member gold = FssTypes.Color.gold |> columnRuleColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> columnRuleColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> columnRuleColorValue'
        static member grey = FssTypes.Color.grey |> columnRuleColorValue'
        static member honeydew = FssTypes.Color.honeydew |> columnRuleColorValue'
        static member hotPink = FssTypes.Color.hotPink |> columnRuleColorValue'
        static member indianRed = FssTypes.Color.indianRed |> columnRuleColorValue'
        static member indigo = FssTypes.Color.indigo |> columnRuleColorValue'
        static member ivory = FssTypes.Color.ivory |> columnRuleColorValue'
        static member khaki = FssTypes.Color.khaki |> columnRuleColorValue'
        static member lavender = FssTypes.Color.lavender |> columnRuleColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> columnRuleColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> columnRuleColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> columnRuleColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> columnRuleColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> columnRuleColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> columnRuleColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> columnRuleColorValue'
        static member lightGray = FssTypes.Color.lightGray |> columnRuleColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> columnRuleColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> columnRuleColorValue'
        static member lightPink = FssTypes.Color.lightPink |> columnRuleColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> columnRuleColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> columnRuleColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> columnRuleColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> columnRuleColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> columnRuleColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> columnRuleColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> columnRuleColorValue'
        static member linen = FssTypes.Color.linen |> columnRuleColorValue'
        static member magenta = FssTypes.Color.magenta |> columnRuleColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> columnRuleColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> columnRuleColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> columnRuleColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> columnRuleColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> columnRuleColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> columnRuleColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> columnRuleColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> columnRuleColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> columnRuleColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> columnRuleColorValue'
        static member mintCream = FssTypes.Color.mintCream |> columnRuleColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> columnRuleColorValue'
        static member moccasin = FssTypes.Color.moccasin |> columnRuleColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> columnRuleColorValue'
        static member oldLace = FssTypes.Color.oldLace |> columnRuleColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> columnRuleColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> columnRuleColorValue'
        static member orchid = FssTypes.Color.orchid |> columnRuleColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> columnRuleColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> columnRuleColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> columnRuleColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> columnRuleColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> columnRuleColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> columnRuleColorValue'
        static member peru = FssTypes.Color.peru |> columnRuleColorValue'
        static member pink = FssTypes.Color.pink |> columnRuleColorValue'
        static member plum = FssTypes.Color.plum |> columnRuleColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> columnRuleColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> columnRuleColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> columnRuleColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> columnRuleColorValue'
        static member salmon = FssTypes.Color.salmon |> columnRuleColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> columnRuleColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> columnRuleColorValue'
        static member seaShell = FssTypes.Color.seaShell |> columnRuleColorValue'
        static member sienna = FssTypes.Color.sienna |> columnRuleColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> columnRuleColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> columnRuleColorValue'
        static member slateGray = FssTypes.Color.slateGray |> columnRuleColorValue'
        static member snow = FssTypes.Color.snow |> columnRuleColorValue'
        static member springGreen = FssTypes.Color.springGreen |> columnRuleColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> columnRuleColorValue'
        static member tan = FssTypes.Color.tan |> columnRuleColorValue'
        static member thistle = FssTypes.Color.thistle |> columnRuleColorValue'
        static member tomato = FssTypes.Color.tomato |> columnRuleColorValue'
        static member turquoise = FssTypes.Color.turquoise |> columnRuleColorValue'
        static member violet = FssTypes.Color.violet |> columnRuleColorValue'
        static member wheat = FssTypes.Color.wheat |> columnRuleColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> columnRuleColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> columnRuleColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> columnRuleColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> columnRuleColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> columnRuleColorValue'
        static member Hex value = FssTypes.Color.Hex value |> columnRuleColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> columnRuleColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> columnRuleColorValue'
        static member transparent = FssTypes.Color.transparent |> columnRuleColorValue'
        static member currentColor = FssTypes.Color.currentColor |> columnRuleColorValue'

        static member Inherit = FssTypes.Inherit |> columnRuleColorValue'
        static member Initial = FssTypes.Initial |> columnRuleColorValue'
        static member Unset = FssTypes.Unset |> columnRuleColorValue'

    /// <summary>Specifies color of the line drawn between columns.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColumnRuleColor' (color: FssTypes.IColumnRuleColor) = ColumnRuleColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
    let private columnCountValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnCount value
    let private columnCountValue' value =
        value
        |> columnCountToString
        |> columnCountValue

    type ColumnCount =
        static member Value(columnCount: FssTypes.IColumnCount) = columnCount |> columnCountValue'
        static member Auto = FssTypes.Auto |> columnCountValue'
        static member Inherit = FssTypes.Inherit |> columnCountValue'
        static member Initial = FssTypes.Initial |> columnCountValue'
        static member Unset = FssTypes.Unset |> columnCountValue'

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
    let ColumnCount' (columnCount: FssTypes.IColumnCount) = ColumnCount.Value(columnCount)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnFill value
    let private columnFillValue' value =
        value
        |> columnFillToString
        |> columnFillValue

    type ColumnFill =
        static member Value(columnFill: FssTypes.IColumnFill) = columnFill |> columnFillValue'
        static member Balance = FssTypes.Column.Fill.Balance |> columnFillValue'
        static member BalanceAll = FssTypes.Column.Fill.BalanceAll |> columnFillValue'
        static member Auto = FssTypes.Auto |> columnFillValue'
        static member Inherit = FssTypes.Inherit |> columnFillValue'
        static member Initial = FssTypes.Initial |> columnFillValue'
        static member Unset = FssTypes.Unset |> columnFillValue'

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
    let ColumnFill' (columnFill: FssTypes.IColumnFill) = ColumnFill.Value(columnFill)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    let private columnWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnWidth value
    let private columnWidthValue' value =
        value
        |> columnWidthToString
        |> columnWidthValue

    type ColumnWidth =
        static member Value(columnWidth: FssTypes.IColumnWidth) = columnWidth |> columnWidthValue'
        static member Auto = FssTypes.Auto |> columnWidthValue'
        static member Inherit = FssTypes.Inherit |> columnWidthValue'
        static member Initial = FssTypes.Initial |> columnWidthValue'
        static member Unset = FssTypes.Unset |> columnWidthValue'

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
    let ColumnWidth' (columnWidth: FssTypes.IColumnWidth) = ColumnWidth.Value(columnWidth)