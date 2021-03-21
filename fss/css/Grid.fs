namespace Fss

[<AutoOpen>]
module Grid =
    let private autoFlowToString (autoFlow: Types.IGridAutoFlow) =
        match autoFlow with
        | :? Types.GridAutoFlow as g -> Utilities.Helpers.duToSpaced g
        | :? Types.Keywords as k ->  Types.keywordsToString k
        | _ -> "Unknown grid auto flow"

    let private templateAreaToString (area: Types.IGridTemplateArea) =
        match area with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None'-> Types.none
        | _ -> "Unknown grid template area"

    let private gridGapToString (gap: Types.IGridGap) =
        match gap with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown grid gap"

    let private gridRowGapToString (gap: Types.IGridRowGap) =
        match gap with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown grid row gap"

    let private gridColumnGapToString (gap: Types.IGridColumnGap) =
        match gap with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Normal -> Types.normal
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown grid column gap"

    let private templateColumnToString (templateColumn: Types.IGridTemplateColumns) =
        match templateColumn with
        | :? Types.GridTemplateColumns as g -> Utilities.Helpers.duToLowercase g
        | :? Types.Auto -> Types.auto
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Fraction as f -> Types.fractionToString f
        | _ -> "Unkown grid template column"

    let private gridPositionToString (position: Types.IGridPosition) =
        let stringifyGridPosition =
            function
                | Types.Value v -> string v
                | Types.Ident i -> i
                | Types.IdentValue (i, v) -> sprintf "%s %d" i v
                | Types.ValueIdentSpan (v, i) -> sprintf "%d %s span" v i
                | Types.Span s -> s

        match position with
        | :? Types.GridPosition as g -> stringifyGridPosition g
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown grid position"

    let private templateRowToString (templateRow: Types.IGridTemplateRows) =
        match templateRow with
        | :? Types.GridTemplateRows as g -> Utilities.Helpers.duToLowercase g
        | :? Types.Auto -> Types.auto
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Fraction as f -> Types.fractionToString f
        | _ -> "Unknown grid template row"

    let private autoColumnsToString (autoColumns: Types.IGridAutoColumns) =
        match autoColumns with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Fraction as f -> Types.fractionToString f
        | :? Types.ContentSize as c -> Types.contentSizeToString c
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.MinMax as m -> Types.minMaxToString m
        | _ -> "Unknown grid auto column"


    let private templateTypeValue (i: Types.ITemplateType) =
        match i with
            | :? Types.Percent as p -> Types.percentToString p
            | :? Types.Size as s -> Types.sizeToString s
            | :? Types.Fraction as f -> Types.fractionToString f
            | :? Types.MinMax as m -> Types.minMaxToString m
            | :? Types.Repeat as r -> Types.repeatToString r
            | _ -> "Unknown template type"

    let private autoRowsToString (autoRows: Types.IGridAutoRows) =
        match autoRows with
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Fraction as f -> Types.fractionToString f
        | :? Types.ContentSize as c -> Types.contentSizeToString c
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.MinMax as m -> Types.minMaxToString m
        | _ -> "Unknown grid auto row"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    let private autoFlowValue value = Types.cssValue Types.Property.GridAutoFlow value
    let private autoFlowValue' value =
        value
        |> autoFlowToString
        |> autoFlowValue
    type GridAutoFlow =
        static member Value (autoFlow: Types.IGridAutoFlow) = autoFlow |> autoFlowValue'
        static member Row = Types.GridAutoFlow.Row |> autoFlowValue'
        static member Column = Types.GridAutoFlow.Column |> autoFlowValue'
        static member Dense = Types.GridAutoFlow.Dense |> autoFlowValue'
        static member RowDense = Types.GridAutoFlow.RowDense |> autoFlowValue'
        static member ColumnDense = Types.GridAutoFlow.ColumnDense |> autoFlowValue'

        static member Inherit = Types.Inherit |> autoFlowValue'
        static member Initial = Types.Initial |> autoFlowValue'
        static member Unset = Types.Unset |> autoFlowValue'

    /// <summary>Specifies how the auto placement algorithm works.</summary>
    /// <param name="flow">
    ///     can be:
    ///     - <c> GridAutoFlow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoFlow' (flow: Types.IGridAutoFlow) = GridAutoFlow.Value(flow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-areas

    let private templateAreaValue value = Types.cssValue Types.Property.GridTemplateAreas value
    let private templateAreaValue' value =
        value
        |> templateAreaToString
        |> templateAreaValue
    type GridTemplateAreas =
        static member Value(area: Types.IGridTemplateArea) = area |> templateAreaValue'
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
        static member None = Types.None' |> templateAreaValue'
        static member Inherit = Types.Inherit |> templateAreaValue'
        static member Initial = Types.Initial |> templateAreaValue'
        static member Unset = Types.Unset |> templateAreaValue'

    /// <summary>Resets grid template area.</summary>
    /// <param name="areas">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateAreas' (areas: Types.IGridTemplateArea) = GridTemplateAreas.Value(areas)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/gap
    let private gridGapValue value = Types.cssValue Types.Property.GridGap value
    let private gridGapValue' value =
        value
        |> gridGapToString
        |> gridGapValue
    type GridGap =
        static member Value (gap: Types.IGridGap) = gap |> gridGapValue'
        static member Value(rowGap: Types.IGridGap, columnGap: Types.IGridGap) =
            sprintf "%s %s"
                (gridGapToString rowGap)
                (gridGapToString columnGap)
            |> gridGapValue
        static member Inherit = Types.Inherit |> gridGapValue'
        static member Initial = Types.Initial |> gridGapValue'
        static member Unset = Types.Unset |> gridGapValue'

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
    let GridGap' (gap: Types.IGridGap) = GridGap.Value(gap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/row-gap
    let private gridRowGapValue value = Types.cssValue Types.Property.GridRowGap value
    let private gridRowGapValue' value =
        value
        |> gridRowGapToString
        |> gridRowGapValue
    type GridRowGap =
        static member Value (gap: Types.IGridRowGap) = gap |> gridRowGapValue'
        static member Inherit = Types.Inherit |> gridRowGapValue'
        static member Initial = Types.Initial |> gridRowGapValue'
        static member Unset = Types.Unset |> gridRowGapValue'
        static member Normal = Types.Normal |> gridRowGapValue'

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
    let GridRowGap' (rowGap: Types.IGridRowGap) = GridRowGap.Value(rowGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private gridColumnGapValue value = Types.cssValue Types.Property.GridColumnGap value
    let private gridColumnGapValue' value =
        value
        |> gridColumnGapToString
        |> gridColumnGapValue
    type GridColumnGap =
        static member Value (gap: Types.IGridColumnGap) = gap |> gridColumnGapValue'
        static member Inherit = Types.Inherit |> gridColumnGapValue'
        static member Initial = Types.Initial |> gridColumnGapValue'
        static member Unset = Types.Unset |> gridColumnGapValue'
        static member Normal = Types.Normal |> gridColumnGapValue'

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
    let GridColumnGap' (columnGap: Types.IGridColumnGap) = GridColumnGap.Value(columnGap)

    // Grid position
    type GridPosition =
        static member Value (position: Types.IGridPosition) = position
        static member Ident ident = ident |> Types.Ident
        static member Value (value: int) = value |> Types.Value
        static member IdentValue (ident: string, value: int) = Types.IdentValue(ident, value)
        static member ValueIdentSpan (value: int, ident: string) = Types.ValueIdentSpan(value, ident)
        static member Span (value: int) = sprintf "span %d" value |> Types.Span
        static member Span (ident: string) = sprintf "span %s" ident |> Types.Span
        static member Span (value: int, ident: string) = sprintf "%d %s span" value ident |> Types.Span

        static member Auto = Types.Auto
        static member Inherit = Types.Inherit
        static member Initial = Types.Initial
        static member Unset = Types.Unset

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
    let GridPosition' (position: Types.IGridPosition) = GridPosition.Value(position)

    let private gridRowStartValue value = Types.cssValue Types.Property.GridRowStart value
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

    let private gridRowEndValue value = Types.cssValue Types.Property.GridRowEnd value
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

    let private gridRowValue value = Types.cssValue Types.Property.GridRow value
    let private gridRowValue' value =
        value
        |> gridPositionToString
        |> gridRowValue
    type GridRow =
        static member Value (row: Types.IGridPosition) = row |> gridRowValue'
        static member Value (rowStart: Types.IGridPosition, rowEnd: Types.IGridPosition) =
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
    let GridRow' (row: Types.IGridPosition) = GridRow.Value(row)

    let private gridColumnStartValue value = Types.cssValue Types.Property.GridColumnStart value
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

    let private gridColumnEndValue value = Types.cssValue Types.Property.GridColumnEnd value
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

    let private gridColumnValue value = Types.cssValue Types.Property.GridColumn value
    let private gridColumnValue' value =
        value
        |> gridPositionToString
        |> gridColumnValue

    type GridColumn =
        static member Value (column: Types.IGridPosition) = column |> gridColumnValue'
        static member Value (columnStart: Types.IGridPosition, columnEnd: Types.IGridPosition) =
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
    let GridColumn' (column: Types.IGridPosition) = GridColumn.Value(column)

    let private gridAreaValue value = Types.cssValue Types.Property.GridArea value
    let private gridAreaValue' value =
        value
        |> gridPositionToString
        |> gridAreaValue

    type GridArea =
        static member Value (value: Types.IGridPosition) =
            sprintf "%s"
                (gridPositionToString value)
            |> gridAreaValue
        static member Value (rowStart: Types.IGridPosition, columnStart: Types.IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
            |> gridAreaValue
        static member Value (rowStart: Types.IGridPosition, columnStart: Types.IGridPosition, rowEnd: Types.IGridPosition) =
            sprintf "%s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
            |> gridAreaValue
        static member Value (rowStart: Types.IGridPosition, columnStart: Types.IGridPosition, rowEnd: Types.IGridPosition, columnEnd: Types.IGridPosition) =
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
    let private templateRowValue value = Types.cssValue Types.Property.GridTemplateRows value
    let private templateRowValue' value =
        value
        |> templateRowToString
        |> templateRowValue
    type GridTemplateRows =
        static member Value (templateRow: Types.IGridTemplateRows) = templateRow |> templateRowValue'
        static member Value (length: Types.IGridTemplateRows, fraction: Types.IGridTemplateRows) =
            sprintf "%s %s"
                (templateRowToString length)
                (templateRowToString fraction)
            |> templateRowValue
        static member Values (values: Types.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateRowValue
        static member MinMax (min: Types.ILengthPercentage, max: Types.Fraction) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateRowValue
        static member MinMax (min: Types.ILengthPercentage, max: Types.ILengthPercentage) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateRowValue
        static member MinMax (min: Types.ContentSize, max: Types.Size) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateRowValue
        static member MinMax (min: Types.ContentSize, max: Types.ContentSize) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateRowValue
        static member FitContent (value: Types.ILengthPercentage) =
            Types.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateRowValue
        static member Repeat (value: int, fraction: Types.Fraction) =
            Types.Repeat.Repeat(value, fraction)
            |> Types.repeatToString
            |> templateRowValue
        static member Repeat (value: int, length: Types.ILengthPercentage) =
            Types.Repeat.Repeat(value, length)
            |> Types.repeatToString
            |> templateRowValue
        static member Repeat (value: int, contentSize: Types.ContentSize) =
            Types.Repeat.Repeat(value, contentSize)
            |> Types.repeatToString
            |> templateRowValue
        static member Repeat (value: Types.RepeatType, fraction: Types.Fraction) =
            Types.Repeat.Repeat(value, fraction)
            |> Types.repeatToString
            |> templateRowValue
        static member Repeat (value: Types.RepeatType, length: Types.ILengthPercentage) =
            Types.Repeat.Repeat(value, length)
            |> Types.repeatToString
            |> templateRowValue
        static member Repeat (value: Types.RepeatType, contentSize: Types.ContentSize) =
            Types.Repeat.Repeat(value, contentSize)
            |> Types.repeatToString
            |> templateRowValue
        static member Subgrid = Types.GridTemplateRows.Subgrid |> templateRowValue'
        static member Masonry = Types.GridTemplateRows.Masonry |> templateRowValue'
        static member None = Types.None' |> templateRowValue'
        static member Auto = Types.Auto |> templateRowValue'
        static member Inherit = Types.Inherit |> templateRowValue'
        static member Initial = Types.Initial |> templateRowValue'
        static member Unset = Types.Unset |> templateRowValue'

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
    let GridTemplateRows' (templateRows: Types.IGridTemplateRows) = GridTemplateRows.Value(templateRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-columns
    let private templateColumnValue value = Types.cssValue Types.Property.GridTemplateColumns value
    let private templateColumnValue' value =
        value
        |> templateColumnToString
        |> templateColumnValue
    type GridTemplateColumns =
        static member Value (templateColumn: Types.IGridTemplateColumns) = templateColumn |> templateColumnValue'
        static member Value (length: Types.IGridTemplateColumns, fraction: Types.IGridTemplateColumns) =
            sprintf "%s %s"
                (templateColumnToString length)
                (templateColumnToString fraction)
            |> templateColumnValue
        static member Values (values: Types.ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateColumnValue
        static member MinMax (min: Types.ILengthPercentage, max: Types.Fraction) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateColumnValue
        static member MinMax (min: Types.ILengthPercentage, max: Types.ILengthPercentage) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateColumnValue
        static member MinMax (min: Types.ContentSize, max: Types.Size) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateColumnValue
        static member MinMax (min: Types.ContentSize, max: Types.ContentSize) =
            Types.MinMax.MinMax(min, max)
            |> Types.minMaxToString
            |> templateColumnValue
        static member FitContent (value: Types.ILengthPercentage) =
            Types.lengthPercentageToString value
            |> sprintf "fit-content(%s)"
            |> templateColumnValue
        static member Repeat (value: int, fraction: Types.Fraction) =
            Types.Repeat.Repeat(value, fraction)
            |> Types.repeatToString
            |> templateColumnValue
        static member Repeat (value: int, length: Types.ILengthPercentage) =
            Types.Repeat.Repeat(value, length)
            |> Types.repeatToString
            |> templateColumnValue
        static member Repeat (value: int, contentSize: Types.ContentSize) =
            Types.Repeat.Repeat(value, contentSize)
            |> Types.repeatToString
            |> templateColumnValue
        static member Repeat (value: Types.RepeatType, fraction: Types.Fraction) =
            Types.Repeat.Repeat(value, fraction)
            |> Types.repeatToString
            |> templateColumnValue
        static member Repeat (value: Types.RepeatType, length: Types.ILengthPercentage) =
            Types.Repeat.Repeat(value, length)
            |> Types.repeatToString
            |> templateColumnValue
        static member Repeat (value: Types.RepeatType, contentSize: Types.ContentSize) =
            Types.Repeat.Repeat(value, contentSize)
            |> Types.repeatToString
            |> templateColumnValue
        static member Subgrid = Types.Subgrid |> templateColumnValue'
        static member Masonry = Types.Masonry |> templateColumnValue'
        static member None = Types.None' |> templateColumnValue'
        static member Auto = Types.Auto |> templateColumnValue'
        static member Inherit = Types.Inherit |> templateColumnValue'
        static member Initial = Types.Initial |> templateColumnValue'
        static member Unset = Types.Unset |> templateColumnValue'

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
    let GridTemplateColumns' (templateColumns: Types.IGridTemplateColumns) = GridTemplateColumns.Value(templateColumns)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    let private autoRowsValue value = Types.cssValue Types.Property.GridAutoRows value
    let private autoRowsValue' value =
        value
        |> autoRowsToString
        |> autoRowsValue
    type GridAutoRows =
        static member Value (autoRow: Types.IGridAutoRows) = autoRow |> autoRowsValue'
        static member Values (values: Types.IGridAutoRows list) = Utilities.Helpers.combineWs autoRowsToString values |> autoRowsValue
        static member MaxContent = Types.ContentSize.MaxContent |> autoRowsValue'
        static member MinContent = Types.ContentSize.MinContent |> autoRowsValue'
        static member FitContent (contentSize: Types.ILengthPercentage) = Types.ContentSize.FitContent(contentSize) |> autoRowsValue'

        static member Auto = Types.Auto |> autoRowsValue'
        static member Inherit = Types.Inherit |> autoRowsValue'
        static member Initial = Types.Initial |> autoRowsValue'
        static member Unset = Types.Unset |> autoRowsValue'

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
    let GridAutoRows' (autoRows: Types.IGridAutoRows) = GridAutoRows.Value(autoRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    let private autoColumnsValue value = Types.cssValue Types.Property.GridAutoColumns value
    let private autoColumnsValue' value =
        value
        |> autoColumnsToString
        |> autoColumnsValue
    type GridAutoColumns =
        static member Value (autoColumn: Types.IGridAutoColumns) = autoColumn |> autoColumnsValue'
        static member Values (values: Types.IGridAutoColumns list) = Utilities.Helpers.combineWs autoColumnsToString values |> autoColumnsValue
        static member MaxContent = Types.ContentSize.MaxContent |> autoColumnsValue'
        static member MinContent = Types.ContentSize.MinContent |> autoColumnsValue'
        static member FitContent (contentSize: Types.ILengthPercentage) = Types.ContentSize.FitContent(contentSize) |> autoColumnsValue'

        static member Auto = Types.Auto |> autoColumnsValue'
        static member Inherit = Types.Inherit |> autoColumnsValue'
        static member Initial = Types.Initial |> autoColumnsValue'
        static member Unset = Types.Unset |> autoColumnsValue'

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
    let GridAutoColumns' (autoColumns: Types.IGridAutoColumns) = GridAutoColumns.Value(autoColumns)
