namespace Fss
open FssTypes

[<AutoOpen>]
module Grid =
     // https://developer.mozilla.org/en-US/docs/Web/CSS/minmax
    type MinMax =
        | MinMaxGrid of string
        interface IGridAutoRows
        interface IGridAutoColumns
        static member MinMax (min: ILengthPercentage, max: Units.Fraction.Fraction) =
            sprintf "minmax(%s, %s)" (Units.LengthPercentage.value min) (Units.Fraction.value max)
            |> MinMaxGrid
        static member MinMax (min: ILengthPercentage, max: ILengthPercentage) =
            sprintf "minmax(%s, %s)" (Units.LengthPercentage.value min) (Units.LengthPercentage.value max)
            |> MinMaxGrid
        static member MinMax (min: Units.Size.Size, max: ContentSize) =
            sprintf "minmax(%s, %s)" (Units.Size.value min) (contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: Units.Percent.Percent, max: ContentSize) =
            sprintf "minmax(%s, %s)" (Units.Percent.value min) (contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: ContentSize, max: Units.Size.Size) =
            sprintf "minmax(%s, %s)" (contentSizeToString min) (Units.Size.value max)
            |> MinMaxGrid
        static member MinMax (min: ContentSize, max: ContentSize) =
            sprintf "minmax(%s, %s)" (contentSizeToString min) (contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: ILengthPercentage, contentSize: ContentSize) =
            sprintf "minmax(%s, %s)"
                (Units.LengthPercentage.value min)
                (contentSizeToString contentSize)
            |> MinMaxGrid
        static member MinMax ( contentSize: ContentSize, min: ILengthPercentage) =
            sprintf "minmax(%s, %s)"
                (contentSizeToString contentSize)
                (Units.LengthPercentage.value min)
            |> MinMaxGrid
        static member MinMax ( contentSize: ContentSize, min: Units.Fraction.Fraction) =
            sprintf "minmax(%s, %s)"
                (contentSizeToString contentSize)
                (Units.Fraction.value min)
            |> MinMaxGrid
        interface ITemplateType

    let private minMaxToString (MinMaxGrid m) = m
    let private repeatValue (repeat: Grid.Repeat) = Utilities.Helpers.duToKebab repeat

    // https://developer.mozilla.org/en-US/docs/Web/CSS/repeat
    type Repeat =
        | GridRepeat of string
        static member Repeat (value: int, fraction: Units.Fraction.Fraction) =
            sprintf "repeat(%d, %s)" value (Units.Fraction.value fraction)
            |> GridRepeat
        static member Repeat (value: int, length: ILengthPercentage) =
            sprintf "repeat(%d, %s)" value (Units.LengthPercentage.value length)
            |> GridRepeat
        static member Repeat (value: int, contentSize: ContentSize) =
            sprintf "repeat(%d, %s)" value (contentSizeToString contentSize)
            |> GridRepeat
        static member Repeat (value: int, contentSizes: ContentSize list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs contentSizeToString contentSizes)
            |> GridRepeat
        static member Repeat (value: int, sizes: ILengthPercentage list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Units.LengthPercentage.value sizes)
            |> GridRepeat
        static member Repeat (value: Grid.Repeat, fraction: Units.Fraction.Fraction) =
            sprintf "repeat(%s, %s)" (repeatValue value) (Units.Fraction.value fraction)
            |> GridRepeat
        static member Repeat (value: Grid.Repeat, length: ILengthPercentage) =
            sprintf "repeat(%s, %s)" (repeatValue value) (Units.LengthPercentage.value length)
            |> GridRepeat
        static member Repeat (value: Grid.Repeat, contentSize: ContentSize) =
            sprintf "repeat(%s, %s)" (repeatValue value) (contentSizeToString contentSize)
            |> GridRepeat
        static member Repeat (value: int, minMax: MinMax) =
            sprintf "repeat(%d, %s)" value (minMaxToString minMax)
            |> GridRepeat
        static member Repeat (value: int, sizes: Units.Size.Size list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Units.Size.value sizes)
            |> GridRepeat
        static member Repeat (value: int, sizes: Units.Percent.Percent list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Units.Percent.value sizes)
            |> GridRepeat

        interface ITemplateType

    let private autoFlowToString (autoFlow: IGridAutoFlow) =
        match autoFlow with
        | :? Grid.GridAutoFlow as g -> Utilities.Helpers.duToSpaced g
        | :? Global as g ->  GlobalValue.global' g
        | _ -> "Unknown grid auto flow"

    let private templateAreaToString (area: IGridTemplateArea) =
        match area with
        | :? Global as g -> GlobalValue.global' g
        | :? None'-> GlobalValue.none
        | _ -> "Unknown grid template area"

    let private gridGapToString (gap: IGridGap) =
        match gap with
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown grid gap"

    let private gridRowGapToString (gap: IGridRowGap) =
        match gap with
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown grid row gap"

    let private gridColumnGapToString (gap: IGridColumnGap) =
        match gap with
        | :? Global as g -> GlobalValue.global' g
        | :? Normal -> GlobalValue.normal
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown grid column gap"

    let private templateColumnToString (templateColumn: IGridTemplateColumns) =
        match templateColumn with
        | :? Grid.GridTemplateColumns as g -> Utilities.Helpers.duToLowercase g
        | :? Auto -> GlobalValue.auto
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Fraction.Fraction as f -> Units.Fraction.value f
        | _ -> "Unkown grid template column"

    let private gridPositionToString (position: IGridPosition) =
        let stringifyGridPosition =
            function
                | Grid.Value v -> string v
                | Grid.Ident i -> i
                | Grid.IdentValue (i, v) -> sprintf "%s %d" i v
                | Grid.ValueIdentSpan (v, i) -> sprintf "%d %s span" v i
                | Grid.Span s -> s

        match position with
        | :? Grid.GridPosition as g -> stringifyGridPosition g
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown grid position"

    let private templateRowToString (templateRow: IGridTemplateRows) =
        match templateRow with
        | :? Grid.GridTemplateRows as g -> Utilities.Helpers.duToLowercase g
        | :? Auto -> GlobalValue.auto
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Fraction.Fraction as f -> Units.Fraction.value f
        | _ -> "Unknown grid template row"

    let private autoColumnsToString (autoColumns: IGridAutoColumns) =
        match autoColumns with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Units.Fraction.Fraction as f -> Units.Fraction.value f
        | :? ContentSize as c -> contentSizeToString c
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | :? MinMax as m -> minMaxToString m
        | _ -> "Unknown grid auto column"

    let private repeatToString (GridRepeat g) = g

    let private templateTypeValue (i: ITemplateType) =
        match i with
            | :? Units.Percent.Percent as p -> Units.Percent.value p
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Units.Fraction.Fraction as f -> Units.Fraction.value f
            | :? MinMax as m -> minMaxToString m
            | :? Repeat as r -> repeatToString r
            | _ -> "Unknown template type"

    let private autoRowsToString (autoRows: IGridAutoRows) =
        match autoRows with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Units.Fraction.Fraction as f -> Units.Fraction.value f
        | :? ContentSize as c -> contentSizeToString c
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | :? MinMax as m -> minMaxToString m
        | _ -> "Unknown grid auto row"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    let private autoFlowValue value = PropertyValue.cssValue Property.GridAutoFlow value
    let private autoFlowValue' value =
        value
        |> autoFlowToString
        |> autoFlowValue
    type GridAutoFlow =
        static member Value (autoFlow: IGridAutoFlow) = autoFlow |> autoFlowValue'
        static member Row = Grid.Row |> autoFlowValue'
        static member Column = Grid.Column |> autoFlowValue'
        static member Dense = Grid.Dense |> autoFlowValue'
        static member RowDense = Grid.RowDense |> autoFlowValue'
        static member ColumnDense = Grid.ColumnDense |> autoFlowValue'

        static member Inherit = Inherit |> autoFlowValue'
        static member Initial = Initial |> autoFlowValue'
        static member Unset = Unset |> autoFlowValue'

    /// <summary>Specifies how the auto placement algorithm works.</summary>
    /// <param name="flow">
    ///     can be:
    ///     - <c> GridAutoFlow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridAutoFlow' (flow: IGridAutoFlow) = GridAutoFlow.Value(flow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-areas

    let private templateAreaValue value = PropertyValue.cssValue Property.GridTemplateAreas value
    let private templateAreaValue' value =
        value
        |> templateAreaToString
        |> templateAreaValue
    type GridTemplateAreas =
        static member Value(area: IGridTemplateArea) = area |> templateAreaValue'
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
        static member None = None' |> templateAreaValue'
        static member Inherit = Inherit |> templateAreaValue'
        static member Initial = Initial |> templateAreaValue'
        static member Unset = Unset |> templateAreaValue'

    /// <summary>Resets grid template area.</summary>
    /// <param name="areas">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let GridTemplateAreas' (areas: IGridTemplateArea) = GridTemplateAreas.Value(areas)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/gap
    let private gridGapValue value = PropertyValue.cssValue Property.GridGap value
    let private gridGapValue' value =
        value
        |> gridGapToString
        |> gridGapValue
    type GridGap =
        static member Value (gap: IGridGap) = gap |> gridGapValue'
        static member Value(rowGap: IGridGap, columnGap: IGridGap) =
            sprintf "%s %s"
                (gridGapToString rowGap)
                (gridGapToString columnGap)
            |> gridGapValue
        static member Inherit = Inherit |> gridGapValue'
        static member Initial = Initial |> gridGapValue'
        static member Unset = Unset |> gridGapValue'

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
    let GridGap' (gap: IGridGap) = GridGap.Value(gap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/row-gap
    let private gridRowGapValue value = PropertyValue.cssValue Property.GridRowGap value
    let private gridRowGapValue' value =
        value
        |> gridRowGapToString
        |> gridRowGapValue
    type GridRowGap =
        static member Value (gap: IGridRowGap) = gap |> gridRowGapValue'
        static member Inherit = Inherit |> gridRowGapValue'
        static member Initial = Initial |> gridRowGapValue'
        static member Unset = Unset |> gridRowGapValue'
        static member Normal = Normal |> gridRowGapValue'

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
    let GridRowGap' (rowGap: IGridRowGap) = GridRowGap.Value(rowGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private gridColumnGapValue value = PropertyValue.cssValue Property.GridColumnGap value
    let private gridColumnGapValue' value =
        value
        |> gridColumnGapToString
        |> gridColumnGapValue
    type GridColumnGap =
        static member Value (gap: IGridColumnGap) = gap |> gridColumnGapValue'
        static member Inherit = Inherit |> gridColumnGapValue'
        static member Initial = Initial |> gridColumnGapValue'
        static member Unset = Unset |> gridColumnGapValue'
        static member Normal = Normal |> gridColumnGapValue'

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
    let GridColumnGap' (columnGap: IGridColumnGap) = GridColumnGap.Value(columnGap)

    // Grid position
    type GridPosition =
        static member Value (position: IGridPosition) = position
        static member Ident ident = ident |>Grid.Ident
        static member Value (value: int) = value |>Grid.Value
        static member IdentValue (ident: string, value: int) = Grid.IdentValue(ident, value)
        static member ValueIdentSpan (value: int, ident: string) = Grid.ValueIdentSpan(value, ident)
        static member Span (value: int) = sprintf "span %d" value |>Grid.Span
        static member Span (ident: string) = sprintf "span %s" ident |>Grid.Span
        static member Span (value: int, ident: string) = sprintf "%d %s span" value ident |>Grid.Span

        static member Auto = Auto
        static member Inherit = Inherit
        static member Initial = Initial
        static member Unset = Unset

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
    let GridPosition' (position: IGridPosition) = GridPosition.Value(position)

    let private gridRowStartValue value = PropertyValue.cssValue Property.GridRowStart value
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

    let private gridRowEndValue value = PropertyValue.cssValue Property.GridRowEnd value
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

    let private gridRowValue value = PropertyValue.cssValue Property.GridRow value
    let private gridRowValue' value =
        value
        |> gridPositionToString
        |> gridRowValue
    type GridRow =
        static member Value (row: IGridPosition) = row |> gridRowValue'
        static member Value (rowStart: IGridPosition, rowEnd: IGridPosition) =
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
    let GridRow' (row: IGridPosition) = GridRow.Value(row)

    let private gridColumnStartValue value = PropertyValue.cssValue Property.GridColumnStart value
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

    let private gridColumnEndValue value = PropertyValue.cssValue Property.GridColumnEnd value
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

    let private gridColumnValue value = PropertyValue.cssValue Property.GridColumn value
    let private gridColumnValue' value =
        value
        |> gridPositionToString
        |> gridColumnValue

    type GridColumn =
        static member Value (column: IGridPosition) = column |> gridColumnValue'
        static member Value (columnStart: IGridPosition, columnEnd: IGridPosition) =
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
    let GridColumn' (column: IGridPosition) = GridColumn.Value(column)

    let private gridAreaValue value = PropertyValue.cssValue Property.GridArea value
    let private gridAreaValue' value =
        value
        |> gridPositionToString
        |> gridAreaValue

    type GridArea =
        static member Value (value: IGridPosition) =
            sprintf "%s"
                (gridPositionToString value)
            |> gridAreaValue
        static member Value (rowStart: IGridPosition, columnStart: IGridPosition) =
            sprintf "%s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
            |> gridAreaValue
        static member Value (rowStart: IGridPosition, columnStart: IGridPosition, rowEnd: IGridPosition) =
            sprintf "%s / %s / %s"
                (gridPositionToString rowStart)
                (gridPositionToString columnStart)
                (gridPositionToString rowEnd)
            |> gridAreaValue
        static member Value (rowStart: IGridPosition, columnStart: IGridPosition, rowEnd: IGridPosition, columnEnd: IGridPosition) =
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
    let private templateRowValue value = PropertyValue.cssValue Property.GridTemplateRows value
    let private templateRowValue' value =
        value
        |> templateRowToString
        |> templateRowValue
    type GridTemplateRows =
        static member Value (templateRow: IGridTemplateRows) = templateRow |> templateRowValue'
        static member Value (length: IGridTemplateRows, fraction: IGridTemplateRows) =
            sprintf "%s %s"
                (templateRowToString length)
                (templateRowToString fraction)
            |> templateRowValue
        static member Values (values: ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateRowValue
        static member MinMax (min: ILengthPercentage, max: Units.Fraction.Fraction) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateRowValue
        static member MinMax (min: ILengthPercentage, max: ILengthPercentage) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateRowValue
        static member MinMax (min: ContentSize, max: Units.Size.Size) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateRowValue
        static member MinMax (min: ContentSize, max: ContentSize) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateRowValue
        static member FitContent (value: ILengthPercentage) =
            Units.LengthPercentage.value value
            |> sprintf "fit-content(%s)"
            |> templateRowValue
        static member Repeat (value: int, fraction: Units.Fraction.Fraction) =
            Repeat.Repeat(value, fraction)
            |> repeatToString
            |> templateRowValue
        static member Repeat (value: int, length: ILengthPercentage) =
            Repeat.Repeat(value, length)
            |> repeatToString
            |> templateRowValue
        static member Repeat (value: int, contentSize: ContentSize) =
            Repeat.Repeat(value, contentSize)
            |> repeatToString
            |> templateRowValue
        static member Repeat (value: Grid.Repeat, fraction: Units.Fraction.Fraction) =
            Repeat.Repeat(value, fraction)
            |> repeatToString
            |> templateRowValue
        static member Repeat (value: Grid.Repeat, length: ILengthPercentage) =
            Repeat.Repeat(value, length)
            |> repeatToString
            |> templateRowValue
        static member Repeat (value: Grid.Repeat, contentSize: ContentSize) =
            Repeat.Repeat(value, contentSize)
            |> repeatToString
            |> templateRowValue
        static member Subgrid = Grid.GridTemplateRows.Subgrid |> templateRowValue'
        static member Masonry = Grid.GridTemplateRows.Masonry |> templateRowValue'
        static member None = None' |> templateRowValue'
        static member Auto = Auto |> templateRowValue'
        static member Inherit = Inherit |> templateRowValue'
        static member Initial = Initial |> templateRowValue'
        static member Unset = Unset |> templateRowValue'

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
    let GridTemplateRows' (templateRows: IGridTemplateRows) = GridTemplateRows.Value(templateRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-columns
    let private templateColumnValue value = PropertyValue.cssValue Property.GridTemplateColumns value
    let private templateColumnValue' value =
        value
        |> templateColumnToString
        |> templateColumnValue
    type GridTemplateColumns =
        static member Value (templateColumn: IGridTemplateColumns) = templateColumn |> templateColumnValue'
        static member Value (length: IGridTemplateColumns, fraction: IGridTemplateColumns) =
            sprintf "%s %s"
                (templateColumnToString length)
                (templateColumnToString fraction)
            |> templateColumnValue
        static member Values (values: ITemplateType list) =
            Utilities.Helpers.combineWs templateTypeValue values
            |> templateColumnValue
        static member MinMax (min: ILengthPercentage, max: Units.Fraction.Fraction) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateColumnValue
        static member MinMax (min: ILengthPercentage, max: ILengthPercentage) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateColumnValue
        static member MinMax (min: ContentSize, max: Units.Size.Size) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateColumnValue
        static member MinMax (min: ContentSize, max: ContentSize) =
            MinMax.MinMax(min, max)
            |> minMaxToString
            |> templateColumnValue
        static member FitContent (value: ILengthPercentage) =
            Units.LengthPercentage.value value
            |> sprintf "fit-content(%s)"
            |> templateColumnValue
        static member Repeat (value: int, fraction: Units.Fraction.Fraction) =
            Repeat.Repeat(value, fraction)
            |> repeatToString
            |> templateColumnValue
        static member Repeat (value: int, length: ILengthPercentage) =
            Repeat.Repeat(value, length)
            |> repeatToString
            |> templateColumnValue
        static member Repeat (value: int, contentSize: ContentSize) =
            Repeat.Repeat(value, contentSize)
            |> repeatToString
            |> templateColumnValue
        static member Repeat (value: Grid.Repeat, fraction: Units.Fraction.Fraction) =
            Repeat.Repeat(value, fraction)
            |> repeatToString
            |> templateColumnValue
        static member Repeat (value: Grid.Repeat, length: ILengthPercentage) =
            Repeat.Repeat(value, length)
            |> repeatToString
            |> templateColumnValue
        static member Repeat (value: Grid.Repeat, contentSize: ContentSize) =
            Repeat.Repeat(value, contentSize)
            |> repeatToString
            |> templateColumnValue
        static member Subgrid = Grid.Subgrid |> templateColumnValue'
        static member Masonry = Grid.Masonry |> templateColumnValue'
        static member None = None' |> templateColumnValue'
        static member Auto = Auto |> templateColumnValue'
        static member Inherit = Inherit |> templateColumnValue'
        static member Initial = Initial |> templateColumnValue'
        static member Unset = Unset |> templateColumnValue'

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
    let GridTemplateColumns' (templateColumns: IGridTemplateColumns) = GridTemplateColumns.Value(templateColumns)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    let private autoRowsValue value = PropertyValue.cssValue Property.GridAutoRows value
    let private autoRowsValue' value =
        value
        |> autoRowsToString
        |> autoRowsValue
    type GridAutoRows =
        static member Value (autoRow: IGridAutoRows) = autoRow |> autoRowsValue'
        static member Values (values: IGridAutoRows list) = Utilities.Helpers.combineWs autoRowsToString values |> autoRowsValue
        static member MaxContent = MaxContent |> autoRowsValue'
        static member MinContent = MinContent |> autoRowsValue'
        static member FitContent (contentSize: ILengthPercentage) = FitContent(contentSize) |> autoRowsValue'

        static member Auto = Auto |> autoRowsValue'
        static member Inherit = Inherit |> autoRowsValue'
        static member Initial = Initial |> autoRowsValue'
        static member Unset = Unset |> autoRowsValue'

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
    let GridAutoRows' (autoRows: IGridAutoRows) = GridAutoRows.Value(autoRows)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    let private autoColumnsValue value = PropertyValue.cssValue Property.GridAutoColumns value
    let private autoColumnsValue' value =
        value
        |> autoColumnsToString
        |> autoColumnsValue
    type GridAutoColumns =
        static member Value (autoColumn: IGridAutoColumns) = autoColumn |> autoColumnsValue'
        static member Values (values: IGridAutoColumns list) = Utilities.Helpers.combineWs autoColumnsToString values |> autoColumnsValue
        static member MaxContent = MaxContent |> autoColumnsValue'
        static member MinContent = MinContent |> autoColumnsValue'
        static member FitContent (contentSize: ILengthPercentage) = FitContent(contentSize) |> autoColumnsValue'

        static member Auto = Auto |> autoColumnsValue'
        static member Inherit = Inherit |> autoColumnsValue'
        static member Initial = Initial |> autoColumnsValue'
        static member Unset = Unset |> autoColumnsValue'

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
    let GridAutoColumns' (autoColumns: IGridAutoColumns) = GridAutoColumns.Value(autoColumns)
