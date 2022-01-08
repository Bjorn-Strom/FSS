namespace Fss

open Fss.Types

[<AutoOpen>]
module Column =
    /// Sets gap width between element.
    let ColumnGap = ColumnClasses.ColumnGap(Property.ColumnGap)
    /// Sets gap width between element.
    let ColumnSpan = ColumnClasses.ColumnSpan(Property.ColumnSpan)
    /// Resets column rule.
    let ColumnRule = ColumnClasses.ColumnRule(Property.ColumnRule)
    /// Specifies width of the line drawn between columns.
    let ColumnRuleWidth = ColumnClasses.ColumnRuleWidth(Property.ColumnRuleWidth)
    /// Specifies style of the line drawn between columns.
    let ColumnRuleStyle = ColumnClasses.ColumnRuleStyle(Property.ColumnRuleStyle)
    /// Specifies color of the line drawn between columns.
    let ColumnRuleColor = ColumnClasses.ColumnRuleColor(Property.ColumnRuleColor)
    /// Specifies number of column to break content into.
    let ColumnCount = ColumnClasses.ColumnCount(Property.ColumnCount)
    /// Specifies how content fills columns.
    let ColumnFill = ColumnClasses.ColumnFill(Property.ColumnFill)
    /// Specifies width of line drawn between column.
    let ColumnWidth = ColumnClasses.ColumnWidth(Property.ColumnWidth)
    /// Resets columns.
    let Columns = ColumnClasses.Columns(Property.Columns)
