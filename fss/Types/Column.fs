namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type ColumnSpan =
        | All
        interface Types.IColumnSpan

    type ColumnRuleWidth =
        | Thin
        | Medium
        | Thick
        interface Types.IColumnRuleWidth

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
        interface Types.IColumnRuleStyle

    type ColumnFill =
        | Balance
        | BalanceAll
        interface Types.IColumnFill