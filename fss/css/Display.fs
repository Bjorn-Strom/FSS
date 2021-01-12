namespace Fss

module DisplayType =
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

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
    open DisplayType

    let private displayToString (display: IDisplay) =
        match display with
        | :? Display as t -> Utilities.Helpers.duToKebab t
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
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

    /// <summary>Specifies the layout of the elements children.</summary>
    /// <param name="display">
    ///     can be:
    ///     - <c> Display </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Display' (display: IDisplay) = Display.Value(display)