namespace Fss

[<RequireQualifiedAccess>]
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

    let private displayToString (display: IDisplay) =
        match display with
        | :? DisplayType.Display as t -> Utilities.Helpers.duToKebab t
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown display type"

    let private displayValue value = PropertyValue.cssValue Property.Display value
    let private displayValue' value =
        value
        |> displayToString
        |> displayValue

    type Display =
        static member Value (display: IDisplay) = display |> displayValue'
        static member Inline = DisplayType.Inline |> displayValue'
        static member InlineBlock = DisplayType.InlineBlock |> displayValue'
        static member Block = DisplayType.Block |> displayValue'
        static member RunIn = DisplayType.RunIn |> displayValue'
        static member Flex = DisplayType.Flex |> displayValue'
        static member Grid = DisplayType.Grid |> displayValue'
        static member FlowRoot = DisplayType.FlowRoot |> displayValue'
        static member Table = DisplayType.Table |> displayValue'
        static member TableCell = DisplayType.TableCell |> displayValue'
        static member TableColumn = DisplayType.TableColumn |> displayValue'
        static member TableColumnGroup = DisplayType.TableColumnGroup |> displayValue'
        static member TableHeaderGroup = DisplayType.TableHeaderGroup |> displayValue'
        static member TableRowGroup = DisplayType.TableRowGroup |> displayValue'
        static member TableFooterGroup = DisplayType.TableFooterGroup |> displayValue'
        static member TableRow = DisplayType.TableRow |> displayValue'
        static member TableCaption = DisplayType.TableCaption |> displayValue'

        static member None = None' |> displayValue'
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