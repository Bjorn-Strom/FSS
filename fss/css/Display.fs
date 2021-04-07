namespace Fss

open Fable.Core

[<AutoOpen>]
module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
    let private displayToString (display: FssTypes.IDisplay) =
        match display with
        | :? FssTypes.Display.Display as t -> Utilities.Helpers.duToKebab t
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown display type"

    let private displayValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Display
    let private displayValue' = displayToString >> displayValue

    [<Erase>]
    type Display =
        static member value (display: FssTypes.IDisplay) = display |> displayValue'
        static member inline' = FssTypes.Display.Inline |> displayValue'
        static member inlineBlock = FssTypes.Display.InlineBlock |> displayValue'
        static member block = FssTypes.Display.Block |> displayValue'
        static member runIn = FssTypes.Display.RunIn |> displayValue'
        static member flex = FssTypes.Display.Flex |> displayValue'
        static member grid = FssTypes.Display.Grid |> displayValue'
        static member flowRoot = FssTypes.Display.FlowRoot |> displayValue'
        static member table = FssTypes.Display.Table |> displayValue'
        static member tableCell = FssTypes.Display.TableCell |> displayValue'
        static member tableColumn = FssTypes.Display.TableColumn |> displayValue'
        static member tableColumnGroup = FssTypes.Display.TableColumnGroup |> displayValue'
        static member tableHeaderGroup = FssTypes.Display.TableHeaderGroup |> displayValue'
        static member tableRowGroup = FssTypes.Display.TableRowGroup |> displayValue'
        static member tableFooterGroup = FssTypes.Display.TableFooterGroup |> displayValue'
        static member tableRow = FssTypes.Display.TableRow |> displayValue'
        static member tableCaption = FssTypes.Display.TableCaption |> displayValue'

        static member none = FssTypes.None' |> displayValue'
        static member inherit' = FssTypes.Inherit |> displayValue'
        static member initial = FssTypes.Initial |> displayValue'
        static member unset = FssTypes.Unset |> displayValue'

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
    let Display' = Display.value