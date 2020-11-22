namespace Fss

module DisplayType =
    type DisplayType =
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

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
    open DisplayType

    let private displayToString (display: IDisplay) =
        let stringifyDisplay =
            function
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

        match display with
        | :? DisplayType as t -> stringifyDisplay t
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown display type"

    let private displayValue value = PropertyValue.cssValue Property.Display value
    let private displayValue' value =
        value
        |> displayToString
        |> displayValue

    type Display =
        static member Value (display: IDisplay) = display |> displayValue'
        static member Inline = Inline |> displayValue'
        static member InlineBlock = InlineBlock |> displayValue'
        static member Block = Block |> displayValue'
        static member RunIn = RunIn |> displayValue'
        static member Flex = Flex |> displayValue'
        static member Grid = Grid |> displayValue'
        static member FlowRoot = FlowRoot |> displayValue'
        static member Table = Table |> displayValue'
        static member TableCell = TableCell |> displayValue'
        static member TableColumn = TableColumn |> displayValue'
        static member TableColumnGroup = TableColumnGroup |> displayValue'
        static member TableHeaderGroup = TableHeaderGroup |> displayValue'
        static member TableRowGroup = TableRowGroup |> displayValue'
        static member TableFooterGroup = TableFooterGroup |> displayValue'
        static member TableRow = TableRow |> displayValue'
        static member TableCaption = TableCaption |> displayValue'

        static member None = None |> displayValue'
        static member Inherit = Inherit |> displayValue'
        static member Initial = Initial |> displayValue'
        static member Unset = Unset |> displayValue'

    let Display' (display: IDisplay) = Display.Value(display)