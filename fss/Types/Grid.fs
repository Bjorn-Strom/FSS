namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type GridAutoFlow =
        | Row
        | Column
        | Dense
        | RowDense
        | ColumnDense
        interface Types.IGridAutoFlow

    type GridTemplateColumns =
        | Subgrid
        | Masonry
        interface Types.IGridTemplateColumns

    type GridPosition =
        | Value of int
        | Ident of string
        | IdentValue of string * int
        | ValueIdentSpan of int * string
        | Span of string
        interface Types.IGridPosition

    type GridTemplateRows =
        | Subgrid
        | Masonry
        interface Types.IGridTemplateRows

    type RepeatType =
        | AutoFill
        | AutoFit

    let private repeatTypeToString (repeat: RepeatType) = Utilities.Helpers.duToKebab repeat

    // https://developer.mozilla.org/en-US/docs/Web/CSS/minmax
    type MinMax =
        | MinMaxGrid of string
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns
        static member MinMax (min: Types.ILengthPercentage, max: Types.Fraction) =
            sprintf "minmax(%s, %s)" (Types.lengthPercentageToString min) (Types.fractionToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.ILengthPercentage, max: Types.ILengthPercentage) =
            sprintf "minmax(%s, %s)" (Types.lengthPercentageToString min) (Types.lengthPercentageToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.Size, max: Types.ContentSize) =
            sprintf "minmax(%s, %s)" (Types.sizeToString min) (Types.contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.Percent, max: Types.ContentSize) =
            sprintf "minmax(%s, %s)" (Types.percentToString min) (Types.contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.ContentSize, max: Types.Size) =
            sprintf "minmax(%s, %s)" (Types.contentSizeToString min) (Types.sizeToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.ContentSize, max: Types.ContentSize) =
            sprintf "minmax(%s, %s)" (Types.contentSizeToString min) (Types.contentSizeToString max)
            |> MinMaxGrid
        static member MinMax (min: Types.ILengthPercentage, contentSize: Types.ContentSize) =
            sprintf "minmax(%s, %s)"
                (Types.lengthPercentageToString min)
                (Types.contentSizeToString contentSize)
            |> MinMaxGrid
        static member MinMax ( contentSize: Types.ContentSize, min: Types.ILengthPercentage) =
            sprintf "minmax(%s, %s)"
                (Types.contentSizeToString contentSize)
                (Types.lengthPercentageToString min)
            |> MinMaxGrid
        static member MinMax ( contentSize: Types.ContentSize, min: Types.Fraction) =
            sprintf "minmax(%s, %s)"
                (Types.contentSizeToString contentSize)
                (Types.fractionToString min)
            |> MinMaxGrid
        interface Types.ITemplateType

    let internal minMaxToString (MinMaxGrid m) = m

    // https://developer.mozilla.org/en-US/docs/Web/CSS/repeat
    type Repeat =
        | GridRepeat of string
        static member Repeat (value: int, fraction: Types.Fraction) =
            sprintf "repeat(%d, %s)" value (Types.fractionToString fraction)
            |> GridRepeat
        static member Repeat (value: int, length: Types.ILengthPercentage) =
            sprintf "repeat(%d, %s)" value (Types.lengthPercentageToString length)
            |> GridRepeat
        static member Repeat (value: int, contentSize: Types.ContentSize) =
            sprintf "repeat(%d, %s)" value (Types.contentSizeToString contentSize)
            |> GridRepeat
        static member Repeat (value: int, contentSizes: Types.ContentSize list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Types.contentSizeToString contentSizes)
            |> GridRepeat
        static member Repeat (value: int, sizes: Types.ILengthPercentage list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Types.lengthPercentageToString sizes)
            |> GridRepeat
        static member Repeat (value: RepeatType, fraction: Types.Fraction) =
            sprintf "repeat(%s, %s)" (repeatTypeToString value) (Types.fractionToString fraction)
            |> GridRepeat
        static member Repeat (value: RepeatType, length: Types.ILengthPercentage) =
            sprintf "repeat(%s, %s)" (repeatTypeToString value) (Types.lengthPercentageToString length)
            |> GridRepeat
        static member Repeat (value: RepeatType, contentSize: Types.ContentSize) =
            sprintf "repeat(%s, %s)" (repeatTypeToString value) (Types.contentSizeToString contentSize)
            |> GridRepeat
        static member Repeat (value: int, minMax: MinMax) =
            sprintf "repeat(%d, %s)" value (minMaxToString minMax)
            |> GridRepeat
        static member Repeat (value: int, sizes: Types.Size list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Types.sizeToString sizes)
            |> GridRepeat
        static member Repeat (value: int, sizes: Types.Percent list) =
            sprintf "repeat(%d, %s)"
                value
                (Utilities.Helpers.combineWs Types.percentToString sizes)
            |> GridRepeat

        interface Types.ITemplateType

    let internal repeatToString (GridRepeat g) = g

