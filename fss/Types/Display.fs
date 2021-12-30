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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module DisplayClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
    type DisplayClass(property) =
        inherit CssRuleWithNone(property)
        member this.value(display: Display.Display) = (property, display) |> Rule
        member this.inline' = (property, Display.Inline) |> Rule
        member this.inlineBlock = (property, Display.InlineBlock) |> Rule
        member this.block = (property, Display.Block) |> Rule
        member this.runIn = (property, Display.RunIn) |> Rule
        member this.flex = (property, Display.Flex) |> Rule
        member this.grid = (property, Display.Grid) |> Rule
        member this.flowRoot = (property, Display.FlowRoot) |> Rule
        member this.table = (property, Display.Table) |> Rule
        member this.tableCell = (property, Display.TableCell) |> Rule
        member this.tableColumn = (property, Display.TableColumn) |> Rule
        member this.tableColumnGroup = (property, Display.TableColumnGroup) |> Rule
        member this.tableHeaderGroup = (property, Display.TableHeaderGroup) |> Rule
        member this.tableRowGroup = (property, Display.TableRowGroup) |> Rule
        member this.tableFooterGroup = (property, Display.TableFooterGroup) |> Rule
        member this.tableRow = (property, Display.TableRow) |> Rule
        member this.tableCaption = (property, Display.TableCaption) |> Rule
