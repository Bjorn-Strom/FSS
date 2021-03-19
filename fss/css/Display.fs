namespace Fss
open FssTypes

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display

    let private displayToString (display: IDisplay) =
        match display with
        | :? Display.Display as t -> Utilities.Helpers.duToKebab t
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
        static member Inline = Display.Inline |> displayValue'
        static member InlineBlock = Display.InlineBlock |> displayValue'
        static member Block = Display.Block |> displayValue'
        static member RunIn = Display.RunIn |> displayValue'
        static member Flex = Display.Flex |> displayValue'
        static member Grid = Display.Grid |> displayValue'
        static member FlowRoot = Display.FlowRoot |> displayValue'
        static member Table = Display.Table |> displayValue'
        static member TableCell = Display.TableCell |> displayValue'
        static member TableColumn = Display.TableColumn |> displayValue'
        static member TableColumnGroup = Display.TableColumnGroup |> displayValue'
        static member TableHeaderGroup = Display.TableHeaderGroup |> displayValue'
        static member TableRowGroup = Display.TableRowGroup |> displayValue'
        static member TableFooterGroup = Display.TableFooterGroup |> displayValue'
        static member TableRow = Display.TableRow |> displayValue'
        static member TableCaption = Display.TableCaption |> displayValue'

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