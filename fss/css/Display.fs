namespace Fss
open FssTypes

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display

    let private displayToString (display: IDisplay) =
        match display with
        | :? Display as t -> Utilities.Helpers.duToKebab t
        | :? None' -> none
        | :? Global as g -> global' g
        | _ -> "Unknown display type"

    let private displayValue value = PropertyValue.cssValue Property.Display value
    let private displayValue' value =
        value
        |> displayToString
        |> displayValue

    type Display =
        static member Value (display: IDisplay) = display |> displayValue'
        static member Inline = FssTypes.Display.Inline |> displayValue'
        static member InlineBlock = FssTypes.Display.InlineBlock |> displayValue'
        static member Block = FssTypes.Display.Block |> displayValue'
        static member RunIn = FssTypes.Display.RunIn |> displayValue'
        static member Flex = FssTypes.Display.Flex |> displayValue'
        static member Grid = FssTypes.Display.Grid |> displayValue'
        static member FlowRoot = FssTypes.Display.FlowRoot |> displayValue'
        static member Table = FssTypes.Display.Table |> displayValue'
        static member TableCell = FssTypes.Display.TableCell |> displayValue'
        static member TableColumn = FssTypes.Display.TableColumn |> displayValue'
        static member TableColumnGroup = FssTypes.Display.TableColumnGroup |> displayValue'
        static member TableHeaderGroup = FssTypes.Display.TableHeaderGroup |> displayValue'
        static member TableRowGroup = FssTypes.Display.TableRowGroup |> displayValue'
        static member TableFooterGroup = FssTypes.Display.TableFooterGroup |> displayValue'
        static member TableRow = FssTypes.Display.TableRow |> displayValue'
        static member TableCaption = FssTypes.Display.TableCaption |> displayValue'

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