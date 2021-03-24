namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Column =
        type Span =
            | All
            interface IColumnSpan

        type RuleWidth =
            | Thin
            | Medium
            | Thick
            interface IColumnRuleWidth

        type RuleStyle =
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

        type Fill =
            | Balance
            | BalanceAll
            interface IColumnFill