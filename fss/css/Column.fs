namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Column =
    /// Sets gap width between element.
    let ColumnGap =
        Column.ColumnClasses.ColumnGap(Property.ColumnGap)
    /// Sets gap width between element.
    let ColumnSpan =
        Column.ColumnClasses.ColumnSpan(Property.ColumnSpan)
    /// Resets column rule.
    let ColumnRule =
        Column.ColumnClasses.ColumnRule(Property.ColumnRule)
    /// Specifies width of the line drawn between columns.
    let ColumnRuleWidth =
        Column.ColumnClasses.ColumnRuleWidth(Property.ColumnRuleWidth)
    /// Specifies style of the line drawn between columns.
    let ColumnRuleStyle =
        Column.ColumnClasses.ColumnRuleStyle(Property.ColumnRuleStyle)
    /// Specifies color of the line drawn between columns.
    let ColumnRuleColor =
        Column.ColumnClasses.ColumnRuleColor(Property.ColumnRuleColor)
    /// Specifies number of column to break content into.
    let ColumnCount =
        Column.ColumnClasses.ColumnCount(Property.ColumnCount)
    /// Specifies how content fills columns.
    let ColumnFill =
        Column.ColumnClasses.ColumnFill(Property.ColumnFill)
    /// Specifies width of line drawn between column.
    let ColumnWidth =
        Column.ColumnClasses.ColumnWidth(Property.ColumnWidth)
    /// Resets columns.
    let Columns =
        Column.ColumnClasses.Columns(Property.Columns)
