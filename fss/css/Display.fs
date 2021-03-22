namespace Fss

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display

    let private displayToString (display: Types.IDisplay) =
        match display with
        | :? Types.Display.Display as t -> Utilities.Helpers.duToKebab t
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown display type"

    let private displayValue value = Types.propertyHelpers.cssValue Types.Property.Display value
    let private displayValue' value =
        value
        |> displayToString
        |> displayValue

    type Display =
        static member Value (display: Types.IDisplay) = display |> displayValue'
        static member Inline = Types.Display.Inline |> displayValue'
        static member InlineBlock = Types.Display.InlineBlock |> displayValue'
        static member Block = Types.Display.Block |> displayValue'
        static member RunIn = Types.Display.RunIn |> displayValue'
        static member Flex = Types.Display.Flex |> displayValue'
        static member Grid = Types.Display.Grid |> displayValue'
        static member FlowRoot = Types.Display.FlowRoot |> displayValue'
        static member Table = Types.Display.Table |> displayValue'
        static member TableCell = Types.Display.TableCell |> displayValue'
        static member TableColumn = Types.Display.TableColumn |> displayValue'
        static member TableColumnGroup = Types.Display.TableColumnGroup |> displayValue'
        static member TableHeaderGroup = Types.Display.TableHeaderGroup |> displayValue'
        static member TableRowGroup = Types.Display.TableRowGroup |> displayValue'
        static member TableFooterGroup = Types.Display.TableFooterGroup |> displayValue'
        static member TableRow = Types.Display.TableRow |> displayValue'
        static member TableCaption = Types.Display.TableCaption |> displayValue'

        static member None = Types.None' |> displayValue'
        static member Inherit = Types.Inherit |> displayValue'
        static member Initial = Types.Initial |> displayValue'
        static member Unset = Types.Unset |> displayValue'

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
    let Display' (display: Types.IDisplay) = Display.Value(display)