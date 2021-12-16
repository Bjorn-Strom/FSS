namespace Fss

namespace Fss.FssTypes

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
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module DisplayClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/display
        type DisplayClass(property) =
            inherit CssRuleWithNone(property)
            member this.value(display: Display) = (property, display) |> Rule
            member this.inline' = (property, Inline) |> Rule
            member this.inlineBlock = (property, InlineBlock) |> Rule
            member this.block = (property, Block) |> Rule
            member this.runIn = (property, RunIn) |> Rule
            member this.flex = (property, Flex) |> Rule
            member this.grid = (property, Grid) |> Rule
            member this.flowRoot = (property, FlowRoot) |> Rule
            member this.table = (property, Table) |> Rule
            member this.tableCell = (property, TableCell) |> Rule
            member this.tableColumn = (property, TableColumn) |> Rule
            member this.tableColumnGroup = (property, TableColumnGroup) |> Rule
            member this.tableHeaderGroup = (property, TableHeaderGroup) |> Rule
            member this.tableRowGroup = (property, TableRowGroup) |> Rule
            member this.tableFooterGroup = (property, TableFooterGroup) |> Rule
            member this.tableRow = (property, TableRow) |> Rule
            member this.tableCaption = (property, TableCaption) |> Rule
