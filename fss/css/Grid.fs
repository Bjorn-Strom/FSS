namespace Fss

open Fable.Core

[<AutoOpen>]
module Grid =
    let private autoFlowToString (autoFlow: FssTypes.IGridAutoFlow) =
        match autoFlow with
        | :? FssTypes.Grid.GridAutoFlow as g -> Utilities.Helpers.duToSpaced g
        | :? FssTypes.Keywords as k ->  FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown grid auto flow"

    let private templateAreaToString (area: FssTypes.IGridTemplateArea) =
        match area with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None'-> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown grid template area"

    let private gridGapToString (gap: FssTypes.IGridGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid gap"

    let private gridRowGapToString (gap: FssTypes.IGridRowGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid row gap"

    let private gridColumnGapToString (gap: FssTypes.IGridColumnGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid column gap"

    let private templateColumnToString (templateColumn: FssTypes.IGridTemplateColumns) =
        match templateColumn with
        | :? FssTypes.Grid.GridTemplateColumns as g -> Utilities.Helpers.duToLowercase g
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | _ -> "Unkown grid template column"

    let private gridPositionToString (position: FssTypes.IGridPosition) =
        let stringifyGridPosition =
            function
                | FssTypes.Grid.Value v -> string v
                | FssTypes.Grid.Ident i -> i
                | FssTypes.Grid.IdentValue (i, v) -> sprintf "%s %d" i v
                | FssTypes.Grid.ValueIdentSpan (v, i) -> sprintf "%d %s span" v i
                | FssTypes.Grid.Span s -> s

        match position with
        | :? FssTypes.Grid.GridPosition as g -> stringifyGridPosition g
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown grid position"

    let private templateRowToString (templateRow: FssTypes.IGridTemplateRows) =
        match templateRow with
        | :? FssTypes.Grid.GridTemplateRows as g -> Utilities.Helpers.duToLowercase g
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | _ -> "Unknown grid template row"

    let private autoColumnsToString (autoColumns: FssTypes.IGridAutoColumns) =
        match autoColumns with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | :? FssTypes.ContentSize.ContentSize as c -> FssTypes.contentSizeHelpers.contentSizeToString c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Grid.MinMax as m -> FssTypes.Grid.minMaxToString m
        | _ -> "Unknown grid auto column"


    let private templateTypeValue (i: FssTypes.ITemplateType) =
        match i with
            | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
            | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
            | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
            | :? FssTypes.Grid.MinMax as m -> FssTypes.Grid.minMaxToString m
            | :? FssTypes.Grid.Repeat as r -> FssTypes.Grid.repeatToString r
            | _ -> "Unknown template type"

    let private autoRowsToString (autoRows: FssTypes.IGridAutoRows) =
        match autoRows with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | :? FssTypes.ContentSize.ContentSize as c -> FssTypes.contentSizeHelpers.contentSizeToString c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Grid.MinMax as m -> FssTypes.Grid.minMaxToString m
        | _ -> "Unknown grid auto row"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    let private autoFlowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoFlow
    let private autoFlowValue' = autoFlowToString >> autoFlowValue
    [<Erase>]
    type GridAutoFlow =
        static member value (autoFlow: FssTypes.IGridAutoFlow) = autoFlow |> autoFlowValue'
        static member row = FssTypes.Grid.GridAutoFlow.Row |> autoFlowValue'
        static member column = FssTypes.Grid.GridAutoFlow.Column |> autoFlowValue'
        static member dense = FssTypes.Grid.GridAutoFlow.Dense |> autoFlowValue'
        static member rowDense = FssTypes.Grid.GridAutoFlow.RowDense |> autoFlowValue'
        static member columnDense = FssTypes.Grid.GridAutoFlow.ColumnDense |> autoFlowValue'

        static member inherit' = FssTypes.Inherit |> autoFlowValue'
        static member initial = FssTypes.Initial |> autoFlowValue'
        static member unset = FssTypes.Unset |> autoFlowValue'

    /// <summary>Specifies how the auto placement algorithm works.</summary>
    /// <param name="flow">
    ///     can be:
    ///     - <c> GridAutoFlow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoFlow' = GridAutoFlow.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-areas
    let private templateAreaValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateAreas
    let private templateAreaValue' = templateAreaToString >> templateAreaValue
    [<Erase>]
    type GridTemplateAreas =
        static member value(area: FssTypes.IGridTemplateArea) = area |> templateAreaValue'
        static member value (areas: string list) =
            areas
            |> String.concat " "
            |> sprintf "\"%s\""
            |> templateAreaValue
        static member value (areas: string list list) =
            areas
            |> List.map (fun x ->
                x
                |> String.concat " "
                |> sprintf "\"%s\"")
            |> String.concat " "
            |> templateAreaValue
        static member none = FssTypes.None' |> templateAreaValue'
        static member inherit' = FssTypes.Inherit |> templateAreaValue'
        static member initial = FssTypes.Initial |> templateAreaValue'
        static member unset = FssTypes.Unset |> templateAreaValue'

    /// <summary>Resets grid template area.</summary>
    /// <param name="areas">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateAreas': (FssTypes.IGridTemplateArea -> FssTypes.CssProperty) = GridTemplateAreas.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/gap
    let private gridGapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridGap
    let private gridGapValue' = gridGapToString >> gridGapValue
    [<Erase>]
    type GridGap =
        static member value (gap: FssTypes.IGridGap) = gap |> gridGapValue'
        static member value(rowGap: FssTypes.IGridGap, columnGap: FssTypes.IGridGap) =
            sprintf "%s %s"
                (gridGapToString rowGap)
                (gridGapToString columnGap)
            |> gridGapValue
        static member inherit' = FssTypes.Inherit |> gridGapValue'
        static member initial = FssTypes.Initial |> gridGapValue'
        static member unset = FssTypes.Unset |> gridGapValue'

    /// <summary>Specifies gap between rows and column in grid.</summary>
    /// <param name="gap">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridGap' = GridGap.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/row-gap
    let private gridRowGapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowGap
    let private gridRowGapValue' = gridRowGapToString >> gridRowGapValue
    [<Erase>]
    type GridRowGap =
        static member value (gap: FssTypes.IGridRowGap) = gap |> gridRowGapValue'
        static member inherit' = FssTypes.Inherit |> gridRowGapValue'
        static member initial = FssTypes.Initial |> gridRowGapValue'
        static member unset = FssTypes.Unset |> gridRowGapValue'
        static member normal = FssTypes.Normal |> gridRowGapValue'

    /// <summary>Specifies gap between rows in grid.</summary>
    /// <param name="rowGap">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridRowGap' = GridRowGap.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private gridColumnGapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnGap
    let private gridColumnGapValue' = gridColumnGapToString >> gridColumnGapValue
    [<Erase>]
    type GridColumnGap =
        static member value (gap: FssTypes.IGridColumnGap) = gap |> gridColumnGapValue'
        static member inherit' = FssTypes.Inherit |> gridColumnGapValue'
        static member initial = FssTypes.Initial |> gridColumnGapValue'
        static member unset = FssTypes.Unset |> gridColumnGapValue'
        static member normal = FssTypes.Normal |> gridColumnGapValue'

    /// <summary>Specifies gap between columns in grid.</summary>
    /// <param name="columnGap">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridColumnGap' = GridColumnGap.value

    // Grid position
    [<Erase>]
    type GridPosition =
        static member value (position: FssTypes.IGridPosition) = position
        static member ident ident = ident |> FssTypes.Grid.Ident
        static member value (value: int) = value |> FssTypes.Grid.Value
        static member identValue (ident: string, value: int) = FssTypes.Grid.IdentValue(ident, value)
        static member valueIdentSpan (value: int, ident: string) = FssTypes.Grid.ValueIdentSpan(value, ident)
        static member span (value: int) = sprintf "span %d" value |> FssTypes.Grid.Span
        static member span (ident: string) = sprintf "span %s" ident |> FssTypes.Grid.Span
        static member span (value: int, ident: string) = sprintf "%d %s span" value ident |> FssTypes.Grid.Span

        static member auto = FssTypes.Auto
        static member inherit' = FssTypes.Inherit
        static member initial = FssTypes.Initial
        static member unset = FssTypes.Unset

    /// <summary>Specifies gap between columns in grid.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> GridPosition </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridPosition' (position: FssTypes.IGridPosition) = GridPosition.value(position)

    let private gridRowStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowStart
    let private gridRowStartValue': (FssTypes.IGridPosition -> FssTypes.CssProperty) = gridPositionToString >> gridRowStartValue
    [<Erase>]
    type GridRowStart =
        static member ident ident = GridPosition.ident(ident) |> gridRowStartValue'
        static member value (value: int) = GridPosition.value value |> gridRowStartValue'
        static member identValue (ident: string, value: int) = GridPosition.identValue(ident, value) |> gridRowStartValue'
        static member valueIdentSpan (value: int, ident: string) = GridPosition.valueIdentSpan(value, ident) |> gridRowStartValue'
        static member span (value: int) = GridPosition.span value |> gridRowStartValue'
        static member span (ident: string) = GridPosition.span ident |> gridRowStartValue'
        static member span (value: int, ident: string) = GridPosition.span(value, ident) |> gridRowStartValue'

        static member auto = GridPosition.auto |> gridRowStartValue'
        static member inherit' = GridPosition.inherit' |> gridRowStartValue'
        static member initial = GridPosition.initial |> gridRowStartValue'
        static member unset = GridPosition.unset |> gridRowStartValue'

    /// <summary>Specifies start position in grid row.</summary>
    /// <param name="rowStart">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridRowStart' = GridRowStart.value

    let private gridRowEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowEnd
    let private gridRowEndValue': (FssTypes.IGridPosition -> FssTypes.CssProperty) = gridPositionToString >> gridRowEndValue
    [<Erase>]
    type GridRowEnd =
        static member ident ident = GridPosition.ident(ident) |> gridRowEndValue'
        static member value (value: int) = GridPosition.value value |> gridRowEndValue'
        static member identValue (ident: string, value: int) = GridPosition.identValue(ident, value) |> gridRowEndValue'
        static member valueIdentSpan (value: int, ident: string) = GridPosition.valueIdentSpan(value, ident) |> gridRowEndValue'
        static member span (value: int) = GridPosition.span value |> gridRowEndValue'
        static member span (ident: string) = GridPosition.span ident |> gridRowEndValue'
        static member span (value: int, ident: string) = GridPosition.span(value, ident) |> gridRowEndValue'

        static member auto = GridPosition.auto |> gridRowEndValue'
        static member inherit' = GridPosition.inherit' |> gridRowEndValue'
        static member initial = GridPosition.initial |> gridRowEndValue'
        static member unset = GridPosition.unset |> gridRowEndValue'

    /// <summary>Specifies end position in grid row.</summary>
    /// <param name="rowEnd">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridRowEnd' = GridRowEnd.value

    let private gridRowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRow
    let private gridRowValue' = gridPositionToString >> gridRowValue
    [<Erase>]
    type GridRow =
        static member value (row: FssTypes.IGridPosition) = row |> gridRowValue'
        static member value (rowStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s" (gridPositionToString rowStart) (gridPositionToString rowEnd) |> gridRowValue

        static member auto = GridPosition.auto |> gridRowValue'
        static member inherit' = GridPosition.inherit' |> gridRowValue'
        static member initial = GridPosition.initial |> gridRowValue'
        static member unset = GridPosition.unset |> gridRowValue'

    /// <summary>Specifies position in gird by row.</summary>
    /// <param name="row">
    ///     can be:
    ///     - <c> GridPosition </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridRow' = GridRow.value

    let private gridColumnStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnStart
    let private gridColumnStartValue': (FssTypes.IGridPosition -> FssTypes.CssProperty) = gridPositionToString >> gridColumnStartValue
    [<Erase>]
    type GridColumnStart =
        static member ident ident = GridPosition.ident(ident) |> gridColumnStartValue'
        static member value (value: int) = GridPosition.value value |> gridColumnStartValue'
        static member identValue (ident: string, value: int) = GridPosition.identValue(ident, value) |> gridColumnStartValue'
        static member valueIdentSpan (value: int, ident: string) = GridPosition.valueIdentSpan(value, ident) |> gridColumnStartValue'
        static member span (value: int) = GridPosition.span value |> gridColumnStartValue'
        static member span (ident: string) = GridPosition.span ident |> gridColumnStartValue'
        static member span (value: int, ident: string) = GridPosition.span(value, ident) |> gridColumnStartValue'

        static member auto = GridPosition.auto |> gridColumnStartValue'
        static member inherit' = GridPosition.inherit' |> gridColumnStartValue'
        static member initial = GridPosition.initial |> gridColumnStartValue'
        static member unset = GridPosition.unset |> gridColumnStartValue'

    /// <summary>Specifies start position in grid column.</summary>
    /// <param name="columnStart">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridColumnStart' = GridColumnStart.value

    let private gridColumnEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnEnd
    let private gridColumnEndValue': (FssTypes.IGridPosition -> FssTypes.CssProperty) = gridPositionToString >> gridColumnEndValue
    [<Erase>]
    type GridColumnEnd =
        static member ident ident = GridPosition.ident(ident) |> gridColumnEndValue'
        static member value (value: int) = GridPosition.value value |> gridColumnEndValue'
        static member identValue (ident: string, value: int) = GridPosition.identValue(ident, value) |> gridColumnEndValue'
        static member valueIdentSpan (value: int, ident: string) = GridPosition.valueIdentSpan(value, ident) |> gridColumnEndValue'
        static member span (value: int) = GridPosition.span value |> gridColumnEndValue'
        static member span (ident: string) = GridPosition.span ident |> gridColumnEndValue'
        static member span (value: int, ident: string) = GridPosition.span(value, ident) |> gridColumnEndValue'

        static member auto = GridPosition.auto |> gridColumnEndValue'
        static member inherit' = GridPosition.inherit' |> gridColumnEndValue'
        static member initial = GridPosition.initial |> gridColumnEndValue'
        static member unset = GridPosition.unset |> gridColumnEndValue'

    /// <summary>Specifies end position in grid column.</summary>
    /// <param name="columnEnd">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridColumnEnd' = GridColumnEnd.value

    let private gridColumnValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumn
    let private gridColumnValue' = gridPositionToString >> gridColumnValue

    [<Erase>]
    type GridColumn =
        static member value (column: FssTypes.IGridPosition) = column |> gridColumnValue'
        static member value (columnStart: FssTypes.IGridPosition, columnEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString columnStart)
                (gridPositionToString columnEnd)
            |> gridColumnValue
        static member auto = GridPosition.auto |> gridColumnValue'
        static member inherit' = GridPosition.inherit' |> gridColumnValue'
        static member initial = GridPosition.initial |> gridColumnValue'
        static member unset = GridPosition.unset |> gridColumnValue'

    /// <summary>Specifies position in grid by column.</summary>
    /// <param name="column">
    ///     can be:
    ///     - <c> GridPosition </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridColumn' = GridColumn.value

    let private gridAreaValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridArea
    let private gridAreaValue': (FssTypes.IGridPosition -> FssTypes.CssProperty) = gridPositionToString >> gridAreaValue

    [<Erase>]
    type GridArea =
        static member value (value: FssTypes.IGridPosition) =
            sprintf "%s"
                (gridPositionToString value)
            |> gridAreaValue
        static member value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
            |> gridAreaValue
        static member value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
            |> gridAreaValue
        static member value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition, columnEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
                (gridPositionToString columnEnd)
            |> gridAreaValue
        static member auto = GridPosition.auto |> gridAreaValue'
        static member inherit' = GridPosition.inherit' |> gridAreaValue'
        static member initial = GridPosition.initial |> gridAreaValue'
        static member unset = GridPosition.unset |> gridAreaValue'

    /// <summary>Specifies position in grid by area name.</summary>
    /// <param name="area">Area name</param>
    /// <returns>Css property for fss.</returns>
    let GridArea' = GridPosition.ident >> GridArea.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-rows
    let private templateRowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateRows
    let private templateRowValue' = templateRowToString >> templateRowValue
    [<Erase>]
    type GridTemplateRows =
        static member value (templateRow: FssTypes.IGridTemplateRows) = templateRow |> templateRowValue'
        static member value (length: FssTypes.IGridTemplateRows, fraction: FssTypes.IGridTemplateRows) =
            sprintf "%s %s"
                (templateRowToString length)
                (templateRowToString fraction)
            |> templateRowValue
        static member values (values: FssTypes.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateRowValue
        static member minMax (min: FssTypes.ILengthPercentage, max: FssTypes.Fraction) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member minMax (min: FssTypes.ILengthPercentage, max: FssTypes.ILengthPercentage) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member minMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.Length) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member minMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member fitContent (value: FssTypes.ILengthPercentage) =
            FssTypes.unitHelpers.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateRowValue
        static member repeat (value: int, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member repeat (value: int, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member repeat (value: int, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member repeat (value: FssTypes.Grid.RepeatType, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member repeat (value: FssTypes.Grid.RepeatType, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member repeat (value: FssTypes.Grid.RepeatType, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member subgrid = FssTypes.Grid.GridTemplateRows.Subgrid |> templateRowValue'
        static member masonry = FssTypes.Grid.GridTemplateRows.Masonry |> templateRowValue'
        static member none = FssTypes.None' |> templateRowValue'
        static member auto = FssTypes.Auto |> templateRowValue'
        static member inherit' = FssTypes.Inherit |> templateRowValue'
        static member initial = FssTypes.Initial |> templateRowValue'
        static member unset = FssTypes.Unset |> templateRowValue'

    /// <summary>Defines grid rows.</summary>
    /// <param name="templateRows">
    ///     can be:
    ///     - <c> GridTemplateRows </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> None </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateRows' = GridTemplateRows.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-columns
    let private templateColumnValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateColumns
    let private templateColumnValue' = templateColumnToString >> templateColumnValue
    [<Erase>]
    type GridTemplateColumns =
        static member value (templateColumn: FssTypes.IGridTemplateColumns) = templateColumn |> templateColumnValue'
        static member value (length: FssTypes.IGridTemplateColumns, fraction: FssTypes.IGridTemplateColumns) =
            sprintf "%s %s"
                (templateColumnToString length)
                (templateColumnToString fraction)
            |> templateColumnValue
        static member values (values: FssTypes.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateColumnValue
        static member minMax (min: FssTypes.ILengthPercentage, max: FssTypes.Fraction) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member minMax (min: FssTypes.ILengthPercentage, max: FssTypes.ILengthPercentage) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member minMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.Length) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member minMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member fitContent (value: FssTypes.ILengthPercentage) =
            FssTypes.unitHelpers.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateColumnValue
        static member repeat (value: int, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member repeat (value: int, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member repeat (value: int, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member repeat (value: FssTypes.Grid.RepeatType, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member repeat (value: FssTypes.Grid.RepeatType, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member repeat (value: FssTypes.Grid.RepeatType, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member subgrid = FssTypes.Grid.Subgrid |> templateColumnValue'
        static member masonry = FssTypes.Grid.Masonry |> templateColumnValue'
        static member none = FssTypes.None' |> templateColumnValue'
        static member auto = FssTypes.Auto |> templateColumnValue'
        static member inherit' = FssTypes.Inherit |> templateColumnValue'
        static member initial = FssTypes.Initial |> templateColumnValue'
        static member unset = FssTypes.Unset |> templateColumnValue'

    /// <summary>Defines grid columns.</summary>
    /// <param name="templateColumns">
    ///     can be:
    ///     - <c> GridTemplateColumns </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> None </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateColumns' = GridTemplateColumns.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    let private autoRowsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoRows
    let private autoRowsValue' = autoRowsToString >> autoRowsValue
    [<Erase>]
    type GridAutoRows =
        static member value (autoRow: FssTypes.IGridAutoRows) = autoRow |> autoRowsValue'
        static member values (values: FssTypes.IGridAutoRows list) = Utilities.Helpers.combineWs autoRowsToString values |> autoRowsValue
        static member maxContent = FssTypes.ContentSize.MaxContent |> autoRowsValue'
        static member minContent = FssTypes.ContentSize.MinContent |> autoRowsValue'
        static member fitContent (contentSize: FssTypes.ILengthPercentage) = FssTypes.ContentSize.FitContent(contentSize) |> autoRowsValue'

        static member auto = FssTypes.Auto |> autoRowsValue'
        static member inherit' = FssTypes.Inherit |> autoRowsValue'
        static member initial = FssTypes.Initial |> autoRowsValue'
        static member unset = FssTypes.Unset |> autoRowsValue'

    /// <summary>Defines auto generated grid row.</summary>
    /// <param name="autoRows">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Units.Fraction </c>
    ///     - <c> ContentSize </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> MinMax </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoRows' = GridAutoRows.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    let private autoColumnsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoColumns
    let private autoColumnsValue' = autoColumnsToString >> autoColumnsValue
    [<Erase>]
    type GridAutoColumns =
        static member value (autoColumn: FssTypes.IGridAutoColumns) = autoColumn |> autoColumnsValue'
        static member values (values: FssTypes.IGridAutoColumns list) = Utilities.Helpers.combineWs autoColumnsToString values |> autoColumnsValue
        static member maxContent = FssTypes.ContentSize.MaxContent |> autoColumnsValue'
        static member minContent = FssTypes.ContentSize.MinContent |> autoColumnsValue'
        static member fitContent (contentSize: FssTypes.ILengthPercentage) = FssTypes.ContentSize.FitContent(contentSize) |> autoColumnsValue'

        static member auto = FssTypes.Auto |> autoColumnsValue'
        static member inherit' = FssTypes.Inherit |> autoColumnsValue'
        static member initial = FssTypes.Initial |> autoColumnsValue'
        static member unset = FssTypes.Unset |> autoColumnsValue'

    /// <summary>Defines auto generated grid column.</summary>
    /// <param name="autoColumns">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Units.Fraction </c>
    ///     - <c> ContentSize </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> MinMax </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoColumns' = GridAutoColumns.value
