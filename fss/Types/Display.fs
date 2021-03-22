namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Display =
        type Display =
            | Inline
            | InlineBlock
            | Block
            | RunIn
            | Flex
            | Grid
            | FlowRoot
            | Table
            | TableCell
            | TableColumn
            | TableColumnGroup
            | TableHeaderGroup
            | TableRowGroup
            | TableFooterGroup
            | TableRow
            | TableCaption
            interface IDisplay

