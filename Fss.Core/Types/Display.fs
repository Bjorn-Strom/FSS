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
        interface ICssValue with
            member this.StringifyCss() = //Fss.Utilities.Helpers.toKebabCase this
                match this with
                | Inline -> "inline"
                | InlineBlock -> "inline-block"
                | Block -> "block"
                | RunIn -> "run-in"
                | Flex -> "flex"
                | Grid -> "grid"
                | FlowRoot -> "flow-root"
                | Table -> "table"
                | TableCell -> "table-cell"
                | TableColumn -> "table-column"
                | TableColumnGroup -> "table-column-group"
                | TableHeaderGroup -> "table-header-group"
                | TableRowGroup -> "table-row-group"
                | TableFooterGroup -> "table-footer-group"
                | TableRow -> "table-row"
                | TableCaption -> "table-caption"

[<RequireQualifiedAccess>]
module DisplayClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
    type DisplayClass(property) =
        inherit CssRuleWithNone(property)
        member this.value(display: Display.Display) = (property, display) |> Rule
        /// Inline elements do not create line breaks
        member this.inline' = (property, Display.Inline) |> Rule
        /// Inline-Block does not create line breaks, will also respect width and height settings
        member this.inlineBlock = (property, Display.InlineBlock) |> Rule
        /// Block elements start on a new line and takes up as much width as they can
        member this.block = (property, Display.Block) |> Rule
        /// TODO: Find out what this does
        member this.runIn = (property, Display.RunIn) |> Rule
        /// Element is a flexbox
        member this.flex = (property, Display.Flex) |> Rule
        /// Element is a grid
        member this.grid = (property, Display.Grid) |> Rule
        /// TODO: Find out what this does
        member this.flowRoot = (property, Display.FlowRoot) |> Rule
        /// Makes the element behave as a table
        member this.table = (property, Display.Table) |> Rule
        /// Makes the element behave as a table cell
        member this.tableCell = (property, Display.TableCell) |> Rule
        /// Makes the element behave as a table <col> element
        member this.tableColumn = (property, Display.TableColumn) |> Rule
        /// Makes the element behave as a table <column> element
        member this.tableColumnGroup = (property, Display.TableColumnGroup) |> Rule
        /// Makes the element behave as a table <header> element
        member this.tableHeaderGroup = (property, Display.TableHeaderGroup) |> Rule
        /// Makes the element behave as a table <row> element
        member this.tableRowGroup = (property, Display.TableRowGroup) |> Rule
        /// Makes the element behave as a table <footer> element
        member this.tableFooterGroup = (property, Display.TableFooterGroup) |> Rule
        /// Makes the element behave as a table <tr> element
        member this.tableRow = (property, Display.TableRow) |> Rule
        /// Makes the element behave as a table <caption> element
        member this.tableCaption = (property, Display.TableCaption) |> Rule
