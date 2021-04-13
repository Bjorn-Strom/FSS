namespace Fss

open Fable.Core

[<AutoOpen>]
module Column =
    let private columnGapToString (gap: FssTypes.IColumnGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
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
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown column width"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnGap
    let private columnGapValue' = columnGapToString >> columnGapValue

    [<Erase>]
    /// Sets gap width between element.
    type ColumnGap =
        static member Value (gap: FssTypes.IColumnGap) = gap |> columnGapValue'
        static member inherit' = FssTypes.Inherit |> columnGapValue'
        static member initial = FssTypes.Initial |> columnGapValue'
        static member unset = FssTypes.Unset |> columnGapValue'
        static member normal = FssTypes.Normal |> columnGapValue'

    /// Sets gap width between element.
    /// Valid parameters:
    /// - Size
    /// - Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let ColumnGap' = ColumnGap.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnSpan
    let private columnSpanValue' = columnSpanToString >> columnSpanValue

    [<Erase>]
    /// Sets gap width between element.
    type ColumnSpan =
        static member value(span: FssTypes.IColumnSpan) = span |> columnSpanValue'
        static member all = FssTypes.Column.Span.All |> columnSpanValue'
        static member inherit' = FssTypes.Inherit |> columnSpanValue'
        static member initial = FssTypes.Initial |> columnSpanValue'
        static member unset = FssTypes.Unset |> columnSpanValue'
        static member none = FssTypes.None' |> columnSpanValue'

    /// Sets gap width between element.
    /// Valid parameters:
    /// - ColumnSpan
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let ColumnSpan' = ColumnSpan.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/columns
    let private columnsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Columns
    let private columnsValue' = columnsToString >> columnsValue

    [<Erase>]
    /// Resets columns.
    type Columns =
        static member value (columns: FssTypes.IColumns) = columns |> columnsValue'
        static member inherit' = FssTypes.Inherit |> columnsValue'
        static member initial = FssTypes.Initial |> columnsValue'
        static member unset = FssTypes.Unset |> columnsValue'

    /// Resets columns.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    let Columns' = Columns.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule
    let private columnRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRule
    let private columnRuleValue' = columnRuleToString >> columnRuleValue

    [<Erase>]
    /// Resets column rule.
    type ColumnRule =
        static member value (rule: FssTypes.IColumnRule) = rule |> columnRuleValue'
        static member inherit' = FssTypes.Inherit |> columnRuleValue'
        static member initial = FssTypes.Initial |> columnRuleValue'
        static member unset = FssTypes.Unset |> columnRuleValue'

    /// Resets column rule.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    let ColumnRule' = ColumnRule.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleWidth
    let private columnRuleWidthValue' = columnRuleWidthToString >> columnRuleWidthValue

    [<Erase>]
    /// Specifies width of the line drawn between columns.
    type ColumnRuleWidth =
        static member value (ruleWidth: FssTypes.IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member thin = FssTypes.Column.RuleWidth.Thin |> columnRuleWidthValue'
        static member medium = FssTypes.Column.RuleWidth.Medium |> columnRuleWidthValue'
        static member thick = FssTypes.Column.RuleWidth.Thick |> columnRuleWidthValue'
        static member inherit' = FssTypes.Inherit |> columnRuleWidthValue'
        static member initial = FssTypes.Initial |> columnRuleWidthValue'
        static member unset = FssTypes.Unset |> columnRuleWidthValue'

    /// Specifies width of the line drawn between columns.
    /// Valid parameters:
    /// - ColumnRuleWidth
    /// - Size
    /// - Inherit
    /// - Initial
    /// - Unset
    let ColumnRuleWidth' = ColumnRuleWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleStyle
    let private styleValue' = columnRuleStyleToString >> styleValue

    [<Erase>]
    /// Specifies style of the line drawn between columns.
    type ColumnRuleStyle =
        static member value (style: FssTypes.IColumnRuleStyle) = style |> styleValue'
        static member hidden = FssTypes.Column.RuleStyle.Hidden |> styleValue'
        static member dotted = FssTypes.Column.RuleStyle.Dotted |> styleValue'
        static member dashed = FssTypes.Column.RuleStyle.Dashed |> styleValue'
        static member solid = FssTypes.Column.RuleStyle.Solid |> styleValue'
        static member double = FssTypes.Column.RuleStyle.Double |> styleValue'
        static member groove = FssTypes.Column.RuleStyle.Groove |> styleValue'
        static member ridge = FssTypes.Column.RuleStyle.Ridge |> styleValue'
        static member inset = FssTypes.Column.RuleStyle.Inset |> styleValue'
        static member outset = FssTypes.Column.RuleStyle.Outset |> styleValue'

        static member none = FssTypes.None' |> styleValue'
        static member inherit' = FssTypes.Inherit |> styleValue'
        static member initial = FssTypes.Initial |> styleValue'
        static member unset = FssTypes.Unset |> styleValue'

    /// Specifies style of the line drawn between columns.
    /// Valid parameters:
    /// - ColumnRuleStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let ColumnRuleStyle' = ColumnRuleStyle.value

     // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-color
    let private columnRuleColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnRuleColor
    let private columnRuleColorValue' = columnRuleColorToString >> columnRuleColorValue

    /// Specifies color of the line drawn between columns.
    let ColumnRuleColor = FssTypes.ColumnRuleColorClass(columnRuleColorValue')

    /// Specifies color of the line drawn between columns.
    /// Valid parameters:
    /// - Color
    /// - Inherit
    /// - Initial
    /// - Unset
    let ColumnRuleColor' = ColumnRuleColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-count
    let private columnCountValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnCount
    let private columnCountValue' = columnCountToString >> columnCountValue

    [<Erase>]
    /// Specifies number of column to break content into.
    type ColumnCount =
        static member value(columnCount: FssTypes.IColumnCount) = columnCount |> columnCountValue'
        static member auto = FssTypes.Auto |> columnCountValue'
        static member inherit' = FssTypes.Inherit |> columnCountValue'
        static member initial = FssTypes.Initial |> columnCountValue'
        static member unset = FssTypes.Unset |> columnCountValue'

    /// Specifies number of column to break content into.
    /// Valid parameters:
    /// - CssInt
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ColumnCount' = ColumnCount.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-fill
    let private columnFillValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnFill
    let private columnFillValue' = columnFillToString >> columnFillValue

    [<Erase>]
    /// Specifies how content fills columns.
    type ColumnFill =
        static member value(columnFill: FssTypes.IColumnFill) = columnFill |> columnFillValue'
        static member balance = FssTypes.Column.Fill.Balance |> columnFillValue'
        static member balanceAll = FssTypes.Column.Fill.BalanceAll |> columnFillValue'
        static member auto = FssTypes.Auto |> columnFillValue'
        static member inherit' = FssTypes.Inherit |> columnFillValue'
        static member initial = FssTypes.Initial |> columnFillValue'
        static member unset = FssTypes.Unset |> columnFillValue'

    /// Specifies how content fills columns.
    /// Valid parameters:
    /// - ColumnFill
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ColumnFill' = ColumnFill.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-width
    let private columnWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColumnWidth
    let private columnWidthValue' = columnWidthToString >> columnWidthValue

    [<Erase>]
    /// Specifies width of line drawn between column.
    type ColumnWidth =
        static member value(columnWidth: FssTypes.IColumnWidth) = columnWidth |> columnWidthValue'
        static member auto = FssTypes.Auto |> columnWidthValue'
        static member inherit' = FssTypes.Inherit |> columnWidthValue'
        static member initial = FssTypes.Initial |> columnWidthValue'
        static member unset = FssTypes.Unset |> columnWidthValue'

    /// Specifies width of line drawn between column.
    /// Valid parameters:
    /// - Size
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let ColumnWidth' = ColumnWidth.value