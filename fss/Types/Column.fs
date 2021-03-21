namespace Fss

namespace Fss.Types
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