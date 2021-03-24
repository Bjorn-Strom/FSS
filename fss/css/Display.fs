namespace Fss

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display

    let private displayToString (display: FssTypes.IDisplay) =
        match display with
        | :? FssTypes.Display.Display as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown display type"

    let private displayValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Display value
    let private displayValue' value =
        value
        |> displayToString
        |> displayValue

    type Display =
        static member Value (display: FssTypes.IDisplay) = display |> displayValue'
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

        static member None = FssTypes.None' |> displayValue'
        static member Inherit = FssTypes.Inherit |> displayValue'
        static member Initial = FssTypes.Initial |> displayValue'
        static member Unset = FssTypes.Unset |> displayValue'

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
    let Display' (display: FssTypes.IDisplay) = Display.Value(display)