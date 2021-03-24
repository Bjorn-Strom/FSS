namespace Fss

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
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid gap"

    let private gridRowGapToString (gap: FssTypes.IGridRowGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid row gap"

    let private gridColumnGapToString (gap: FssTypes.IGridColumnGap) =
        match gap with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown grid column gap"

    let private templateColumnToString (templateColumn: FssTypes.IGridTemplateColumns) =
        match templateColumn with
        | :? FssTypes.Grid.GridTemplateColumns as g -> Utilities.Helpers.duToLowercase g
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
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
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | _ -> "Unknown grid template row"

    let private autoColumnsToString (autoColumns: FssTypes.IGridAutoColumns) =
        match autoColumns with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
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
            | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
            | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
            | :? FssTypes.Grid.MinMax as m -> FssTypes.Grid.minMaxToString m
            | :? FssTypes.Grid.Repeat as r -> FssTypes.Grid.repeatToString r
            | _ -> "Unknown template type"

    let private autoRowsToString (autoRows: FssTypes.IGridAutoRows) =
        match autoRows with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Fraction as f -> FssTypes.unitHelpers.fractionToString f
        | :? FssTypes.ContentSize.ContentSize as c -> FssTypes.contentSizeHelpers.contentSizeToString c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Grid.MinMax as m -> FssTypes.Grid.minMaxToString m
        | _ -> "Unknown grid auto row"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    let private autoFlowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoFlow value
    let private autoFlowValue' value =
        value
        |> autoFlowToString
        |> autoFlowValue
    type GridAutoFlow =
        static member Value (autoFlow: FssTypes.IGridAutoFlow) = autoFlow |> autoFlowValue'
        static member Row = FssTypes.Grid.GridAutoFlow.Row |> autoFlowValue'
        static member Column = FssTypes.Grid.GridAutoFlow.Column |> autoFlowValue'
        static member Dense = FssTypes.Grid.GridAutoFlow.Dense |> autoFlowValue'
        static member RowDense = FssTypes.Grid.GridAutoFlow.RowDense |> autoFlowValue'
        static member ColumnDense = FssTypes.Grid.GridAutoFlow.ColumnDense |> autoFlowValue'

        static member Inherit = FssTypes.Inherit |> autoFlowValue'
        static member Initial = FssTypes.Initial |> autoFlowValue'
        static member Unset = FssTypes.Unset |> autoFlowValue'

    /// <summary>Specifies how the auto placement algorithm works.</summary>
    /// <param name="flow">
    ///     can be:
    ///     - <c> GridAutoFlow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoFlow' (flow: FssTypes.IGridAutoFlow) = GridAutoFlow.Value(flow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-areas

    let private templateAreaValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateAreas value
    let private templateAreaValue' value =
        value
        |> templateAreaToString
        |> templateAreaValue
    type GridTemplateAreas =
        static member Value(area: FssTypes.IGridTemplateArea) = area |> templateAreaValue'
        static member Value (areas: string list) =
            areas
            |> String.concat " "
            |> sprintf "\"%s\""
            |> templateAreaValue
        static member Value (areas: string list list) =
            areas
            |> List.map (fun x ->
                x
                |> String.concat " "
                |> sprintf "\"%s\"")
            |> String.concat " "
            |> templateAreaValue
        static member None = FssTypes.None' |> templateAreaValue'
        static member Inherit = FssTypes.Inherit |> templateAreaValue'
        static member Initial = FssTypes.Initial |> templateAreaValue'
        static member Unset = FssTypes.Unset |> templateAreaValue'

    /// <summary>Resets grid template area.</summary>
    /// <param name="areas">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateAreas' (areas: FssTypes.IGridTemplateArea) = GridTemplateAreas.Value(areas)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/gap
    let private gridGapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridGap value
    let private gridGapValue' value =
        value
        |> gridGapToString
        |> gridGapValue
    type GridGap =
        static member Value (gap: FssTypes.IGridGap) = gap |> gridGapValue'
        static member Value(rowGap: FssTypes.IGridGap, columnGap: FssTypes.IGridGap) =
            sprintf "%s %s"
                (gridGapToString rowGap)
                (gridGapToString columnGap)
            |> gridGapValue
        static member Inherit = FssTypes.Inherit |> gridGapValue'
        static member Initial = FssTypes.Initial |> gridGapValue'
        static member Unset = FssTypes.Unset |> gridGapValue'

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
    let GridGap' (gap: FssTypes.IGridGap) = GridGap.Value(gap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/row-gap
    let private gridRowGapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowGap value
    let private gridRowGapValue' value =
        value
        |> gridRowGapToString
        |> gridRowGapValue
    type GridRowGap =
        static member Value (gap: FssTypes.IGridRowGap) = gap |> gridRowGapValue'
        static member Inherit = FssTypes.Inherit |> gridRowGapValue'
        static member Initial = FssTypes.Initial |> gridRowGapValue'
        static member Unset = FssTypes.Unset |> gridRowGapValue'
        static member Normal = FssTypes.Normal |> gridRowGapValue'

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
    let GridRowGap' (rowGap: FssTypes.IGridRowGap) = GridRowGap.Value(rowGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private gridColumnGapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnGap value
    let private gridColumnGapValue' value =
        value
        |> gridColumnGapToString
        |> gridColumnGapValue
    type GridColumnGap =
        static member Value (gap: FssTypes.IGridColumnGap) = gap |> gridColumnGapValue'
        static member Inherit = FssTypes.Inherit |> gridColumnGapValue'
        static member Initial = FssTypes.Initial |> gridColumnGapValue'
        static member Unset = FssTypes.Unset |> gridColumnGapValue'
        static member Normal = FssTypes.Normal |> gridColumnGapValue'

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
    let GridColumnGap' (columnGap: FssTypes.IGridColumnGap) = GridColumnGap.Value(columnGap)

    // Grid position
    type GridPosition =
        static member Value (position: FssTypes.IGridPosition) = position
        static member Ident ident = ident |> FssTypes.Grid.Ident
        static member Value (value: int) = value |> FssTypes.Grid.Value
        static member IdentValue (ident: string, value: int) = FssTypes.Grid.IdentValue(ident, value)
        static member ValueIdentSpan (value: int, ident: string) = FssTypes.Grid.ValueIdentSpan(value, ident)
        static member Span (value: int) = sprintf "span %d" value |> FssTypes.Grid.Span
        static member Span (ident: string) = sprintf "span %s" ident |> FssTypes.Grid.Span
        static member Span (value: int, ident: string) = sprintf "%d %s span" value ident |> FssTypes.Grid.Span

        static member Auto = FssTypes.Auto
        static member Inherit = FssTypes.Inherit
        static member Initial = FssTypes.Initial
        static member Unset = FssTypes.Unset

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
    let GridPosition' (position: FssTypes.IGridPosition) = GridPosition.Value(position)

    let private gridRowStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowStart value
    let private gridRowStartValue' value =
        value
        |> gridPositionToString
        |> gridRowStartValue
    type GridRowStart =
        static member Ident ident = GridPosition.Ident(ident) |> gridRowStartValue'
        static member Value (value: int) = GridPosition.Value value |> gridRowStartValue'
        static member IdentValue (ident: string, value: int) = GridPosition.IdentValue(ident, value) |> gridRowStartValue'
        static member ValueIdentSpan (value: int, ident: string) = GridPosition.ValueIdentSpan(value, ident) |> gridRowStartValue'
        static member Span (value: int) = GridPosition.Span value |> gridRowStartValue'
        static member Span (ident: string) = GridPosition.Span ident |> gridRowStartValue'
        static member Span (value: int, ident: string) = GridPosition.Span(value, ident) |> gridRowStartValue'

        static member Auto = GridPosition.Auto |> gridRowStartValue'
        static member Inherit = GridPosition.Inherit |> gridRowStartValue'
        static member Initial = GridPosition.Initial |> gridRowStartValue'
        static member Unset = GridPosition.Unset |> gridRowStartValue'

    /// <summary>Specifies start position in grid row.</summary>
    /// <param name="rowStart">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridRowStart' (rowStart: int) = GridRowStart.Value(rowStart)

    let private gridRowEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRowEnd value
    let private gridRowEndValue' value =
        value
        |> gridPositionToString
        |> gridRowEndValue
    type GridRowEnd =
        static member Ident ident = GridPosition.Ident(ident) |> gridRowEndValue'
        static member Value (value: int) = GridPosition.Value value |> gridRowEndValue'
        static member IdentValue (ident: string, value: int) = GridPosition.IdentValue(ident, value) |> gridRowEndValue'
        static member ValueIdentSpan (value: int, ident: string) = GridPosition.ValueIdentSpan(value, ident) |> gridRowEndValue'
        static member Span (value: int) = GridPosition.Span value |> gridRowEndValue'
        static member Span (ident: string) = GridPosition.Span ident |> gridRowEndValue'
        static member Span (value: int, ident: string) = GridPosition.Span(value, ident) |> gridRowEndValue'

        static member Auto = GridPosition.Auto |> gridRowEndValue'
        static member Inherit = GridPosition.Inherit |> gridRowEndValue'
        static member Initial = GridPosition.Initial |> gridRowEndValue'
        static member Unset = GridPosition.Unset |> gridRowEndValue'

    /// <summary>Specifies end position in grid row.</summary>
    /// <param name="rowEnd">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridRowEnd' (rowEnd: int) = GridRowEnd.Value(rowEnd)

    let private gridRowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridRow value
    let private gridRowValue' value =
        value
        |> gridPositionToString
        |> gridRowValue
    type GridRow =
        static member Value (row: FssTypes.IGridPosition) = row |> gridRowValue'
        static member Value (rowStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s" (gridPositionToString rowStart) (gridPositionToString rowEnd) |> gridRowValue

        static member Auto = GridPosition.Auto |> gridRowValue'
        static member Inherit = GridPosition.Inherit |> gridRowValue'
        static member Initial = GridPosition.Initial |> gridRowValue'
        static member Unset = GridPosition.Unset |> gridRowValue'

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
    let GridRow' (row: FssTypes.IGridPosition) = GridRow.Value(row)

    let private gridColumnStartValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnStart value
    let private gridColumnStartValue' value =
        value
        |> gridPositionToString
        |> gridColumnStartValue
    type GridColumnStart =
        static member Ident ident = GridPosition.Ident(ident) |> gridColumnStartValue'
        static member Value (value: int) = GridPosition.Value value |> gridColumnStartValue'
        static member IdentValue (ident: string, value: int) = GridPosition.IdentValue(ident, value) |> gridColumnStartValue'
        static member ValueIdentSpan (value: int, ident: string) = GridPosition.ValueIdentSpan(value, ident) |> gridColumnStartValue'
        static member Span (value: int) = GridPosition.Span value |> gridColumnStartValue'
        static member Span (ident: string) = GridPosition.Span ident |> gridColumnStartValue'
        static member Span (value: int, ident: string) = GridPosition.Span(value, ident) |> gridColumnStartValue'

        static member Auto = GridPosition.Auto |> gridColumnStartValue'
        static member Inherit = GridPosition.Inherit |> gridColumnStartValue'
        static member Initial = GridPosition.Initial |> gridColumnStartValue'
        static member Unset = GridPosition.Unset |> gridColumnStartValue'

    /// <summary>Specifies start position in grid column.</summary>
    /// <param name="columnStart">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridColumnStart' (columnStart: int) = GridColumnStart.Value(columnStart)

    let private gridColumnEndValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumnEnd value
    let private gridColumnEndValue' value =
        value
        |> gridPositionToString
        |> gridColumnEndValue
    type GridColumnEnd =
        static member Ident ident = GridPosition.Ident(ident) |> gridColumnEndValue'
        static member Value (value: int) = GridPosition.Value value |> gridColumnEndValue'
        static member IdentValue (ident: string, value: int) = GridPosition.IdentValue(ident, value) |> gridColumnEndValue'
        static member ValueIdentSpan (value: int, ident: string) = GridPosition.ValueIdentSpan(value, ident) |> gridColumnEndValue'
        static member Span (value: int) = GridPosition.Span value |> gridColumnEndValue'
        static member Span (ident: string) = GridPosition.Span ident |> gridColumnEndValue'
        static member Span (value: int, ident: string) = GridPosition.Span(value, ident) |> gridColumnEndValue'

        static member Auto = GridPosition.Auto |> gridColumnEndValue'
        static member Inherit = GridPosition.Inherit |> gridColumnEndValue'
        static member Initial = GridPosition.Initial |> gridColumnEndValue'
        static member Unset = GridPosition.Unset |> gridColumnEndValue'

    /// <summary>Specifies end position in grid column.</summary>
    /// <param name="columnEnd">Number which specifies location</param>
    /// <returns>Css property for fss.</returns>
    let GridColumnEnd' (columnEnd: int) = GridColumnEnd.Value(columnEnd)

    let private gridColumnValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridColumn value
    let private gridColumnValue' value =
        value
        |> gridPositionToString
        |> gridColumnValue

    type GridColumn =
        static member Value (column: FssTypes.IGridPosition) = column |> gridColumnValue'
        static member Value (columnStart: FssTypes.IGridPosition, columnEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString columnStart)
                (gridPositionToString columnEnd)
            |> gridColumnValue
        static member Auto = GridPosition.Auto |> gridColumnValue'
        static member Inherit = GridPosition.Inherit |> gridColumnValue'
        static member Initial = GridPosition.Initial |> gridColumnValue'
        static member Unset = GridPosition.Unset |> gridColumnValue'

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
    let GridColumn' (column: FssTypes.IGridPosition) = GridColumn.Value(column)

    let private gridAreaValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridArea value
    let private gridAreaValue' value =
        value
        |> gridPositionToString
        |> gridAreaValue

    type GridArea =
        static member Value (value: FssTypes.IGridPosition) =
            sprintf "%s"
                (gridPositionToString value)
            |> gridAreaValue
        static member Value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
            |> gridAreaValue
        static member Value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
            |> gridAreaValue
        static member Value (rowStart: FssTypes.IGridPosition, columnStart: FssTypes.IGridPosition, rowEnd: FssTypes.IGridPosition, columnEnd: FssTypes.IGridPosition) =
            sprintf "%s / %s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
                (gridPositionToString columnEnd)
            |> gridAreaValue
        static member Auto = GridPosition.Auto |> gridAreaValue'
        static member Inherit = GridPosition.Inherit |> gridAreaValue'
        static member Initial = GridPosition.Initial |> gridAreaValue'
        static member Unset = GridPosition.Unset |> gridAreaValue'

    /// <summary>Specifies position in grid by area name.</summary>
    /// <param name="area">Area name</param>
    /// <returns>Css property for fss.</returns>
    let GridArea' (area: string) = GridArea.Value(GridPosition.Ident area)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-rows
    let private templateRowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateRows value
    let private templateRowValue' value =
        value
        |> templateRowToString
        |> templateRowValue
    type GridTemplateRows =
        static member Value (templateRow: FssTypes.IGridTemplateRows) = templateRow |> templateRowValue'
        static member Value (length: FssTypes.IGridTemplateRows, fraction: FssTypes.IGridTemplateRows) =
            sprintf "%s %s"
                (templateRowToString length)
                (templateRowToString fraction)
            |> templateRowValue
        static member Values (values: FssTypes.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateRowValue
        static member MinMax (min: FssTypes.ILengthPercentage, max: FssTypes.Fraction) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member MinMax (min: FssTypes.ILengthPercentage, max: FssTypes.ILengthPercentage) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member MinMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.Size) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member MinMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateRowValue
        static member FitContent (value: FssTypes.ILengthPercentage) =
            FssTypes.unitHelpers.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateRowValue
        static member Repeat (value: int, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Repeat (value: int, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Repeat (value: int, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Repeat (value: FssTypes.Grid.RepeatType, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Repeat (value: FssTypes.Grid.RepeatType, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Repeat (value: FssTypes.Grid.RepeatType, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateRowValue
        static member Subgrid = FssTypes.Grid.GridTemplateRows.Subgrid |> templateRowValue'
        static member Masonry = FssTypes.Grid.GridTemplateRows.Masonry |> templateRowValue'
        static member None = FssTypes.None' |> templateRowValue'
        static member Auto = FssTypes.Auto |> templateRowValue'
        static member Inherit = FssTypes.Inherit |> templateRowValue'
        static member Initial = FssTypes.Initial |> templateRowValue'
        static member Unset = FssTypes.Unset |> templateRowValue'

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
    let GridTemplateRows' (templateRows: FssTypes.IGridTemplateRows) = GridTemplateRows.Value(templateRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-columns
    let private templateColumnValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridTemplateColumns value
    let private templateColumnValue' value =
        value
        |> templateColumnToString
        |> templateColumnValue
    type GridTemplateColumns =
        static member Value (templateColumn: FssTypes.IGridTemplateColumns) = templateColumn |> templateColumnValue'
        static member Value (length: FssTypes.IGridTemplateColumns, fraction: FssTypes.IGridTemplateColumns) =
            sprintf "%s %s"
                (templateColumnToString length)
                (templateColumnToString fraction)
            |> templateColumnValue
        static member Values (values: FssTypes.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateColumnValue
        static member MinMax (min: FssTypes.ILengthPercentage, max: FssTypes.Fraction) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member MinMax (min: FssTypes.ILengthPercentage, max: FssTypes.ILengthPercentage) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member MinMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.Size) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member MinMax (min: FssTypes.ContentSize.ContentSize, max: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.MinMax.MinMax(min, max)
            |> FssTypes.Grid.minMaxToString
            |> templateColumnValue
        static member FitContent (value: FssTypes.ILengthPercentage) =
            FssTypes.unitHelpers.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateColumnValue
        static member Repeat (value: int, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Repeat (value: int, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Repeat (value: int, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Repeat (value: FssTypes.Grid.RepeatType, fraction: FssTypes.Fraction) =
            FssTypes.Grid.Repeat.Repeat(value, fraction)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Repeat (value: FssTypes.Grid.RepeatType, length: FssTypes.ILengthPercentage) =
            FssTypes.Grid.Repeat.Repeat(value, length)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Repeat (value: FssTypes.Grid.RepeatType, contentSize: FssTypes.ContentSize.ContentSize) =
            FssTypes.Grid.Repeat.Repeat(value, contentSize)
            |> FssTypes.Grid.repeatToString
            |> templateColumnValue
        static member Subgrid = FssTypes.Grid.Subgrid |> templateColumnValue'
        static member Masonry = FssTypes.Grid.Masonry |> templateColumnValue'
        static member None = FssTypes.None' |> templateColumnValue'
        static member Auto = FssTypes.Auto |> templateColumnValue'
        static member Inherit = FssTypes.Inherit |> templateColumnValue'
        static member Initial = FssTypes.Initial |> templateColumnValue'
        static member Unset = FssTypes.Unset |> templateColumnValue'

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
    let GridTemplateColumns' (templateColumns: FssTypes.IGridTemplateColumns) = GridTemplateColumns.Value(templateColumns)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    let private autoRowsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoRows value
    let private autoRowsValue' value =
        value
        |> autoRowsToString
        |> autoRowsValue
    type GridAutoRows =
        static member Value (autoRow: FssTypes.IGridAutoRows) = autoRow |> autoRowsValue'
        static member Values (values: FssTypes.IGridAutoRows list) = Utilities.Helpers.combineWs autoRowsToString values |> autoRowsValue
        static member MaxContent = FssTypes.ContentSize.MaxContent |> autoRowsValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> autoRowsValue'
        static member FitContent (contentSize: FssTypes.ILengthPercentage) = FssTypes.ContentSize.FitContent(contentSize) |> autoRowsValue'

        static member Auto = FssTypes.Auto |> autoRowsValue'
        static member Inherit = FssTypes.Inherit |> autoRowsValue'
        static member Initial = FssTypes.Initial |> autoRowsValue'
        static member Unset = FssTypes.Unset |> autoRowsValue'

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
    let GridAutoRows' (autoRows: FssTypes.IGridAutoRows) = GridAutoRows.Value(autoRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    let private autoColumnsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.GridAutoColumns value
    let private autoColumnsValue' value =
        value
        |> autoColumnsToString
        |> autoColumnsValue
    type GridAutoColumns =
        static member Value (autoColumn: FssTypes.IGridAutoColumns) = autoColumn |> autoColumnsValue'
        static member Values (values: FssTypes.IGridAutoColumns list) = Utilities.Helpers.combineWs autoColumnsToString values |> autoColumnsValue
        static member MaxContent = FssTypes.ContentSize.MaxContent |> autoColumnsValue'
        static member MinContent = FssTypes.ContentSize.MinContent |> autoColumnsValue'
        static member FitContent (contentSize: FssTypes.ILengthPercentage) = FssTypes.ContentSize.FitContent(contentSize) |> autoColumnsValue'

        static member Auto = FssTypes.Auto |> autoColumnsValue'
        static member Inherit = FssTypes.Inherit |> autoColumnsValue'
        static member Initial = FssTypes.Initial |> autoColumnsValue'
        static member Unset = FssTypes.Unset |> autoColumnsValue'

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
    let GridAutoColumns' (autoColumns: FssTypes.IGridAutoColumns) = GridAutoColumns.Value(autoColumns)
