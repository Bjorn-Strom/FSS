namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Grid =
        type GridAutoFlow =
            | Row
            | Column
            | Dense
            | RowDense
            | ColumnDense
            interface IGridAutoFlow

        type GridTemplateColumns =
            | Subgrid
            | Masonry
            interface IGridTemplateColumns

        type GridPosition =
            | Value of int
            | Ident of string
            | IdentValue of string * int
            | ValueIdentSpan of int * string
            | Span of string
            interface IGridPosition

        type GridTemplateRows =
            | Subgrid
            | Masonry
            interface IGridTemplateRows

        type RepeatType =
            | AutoFill
            | AutoFit


        // https://developer.mozilla.org/en-US/docs/Web/CSS/minmax
        type MinMax =
            | MinMaxGrid of string
            interface IGridAutoRows
            interface IGridAutoColumns
            static member MinMax (min: ILengthPercentage, max: Fraction) =
                sprintf "minmax(%s, %s)" (lengthPercentageToString min) (fractionToString max)
                |> MinMaxGrid
            static member MinMax (min: ILengthPercentage, max: ILengthPercentage) =
                sprintf "minmax(%s, %s)" (lengthPercentageToString min) (lengthPercentageToString max)
                |> MinMaxGrid
            static member MinMax (min: Size, max: ContentSize.ContentSize) =
                sprintf "minmax(%s, %s)" (sizeToString min) (contentSizeToString max)
                |> MinMaxGrid
            static member MinMax (min: Percent, max: ContentSize.ContentSize) =
                sprintf "minmax(%s, %s)" (percentToString min) (contentSizeToString max)
                |> MinMaxGrid
            static member MinMax (min: ContentSize.ContentSize, max: Size) =
                sprintf "minmax(%s, %s)" (contentSizeToString min) (sizeToString max)
                |> MinMaxGrid
            static member MinMax (min: ContentSize.ContentSize, max: ContentSize.ContentSize) =
                sprintf "minmax(%s, %s)" (contentSizeToString min) (contentSizeToString max)
                |> MinMaxGrid
            static member MinMax (min: ILengthPercentage, contentSize: ContentSize.ContentSize) =
                sprintf "minmax(%s, %s)"
                    (lengthPercentageToString min)
                    (contentSizeToString contentSize)
                |> MinMaxGrid
            static member MinMax ( contentSize: ContentSize.ContentSize, min: ILengthPercentage) =
                sprintf "minmax(%s, %s)"
                    (contentSizeToString contentSize)
                    (lengthPercentageToString min)
                |> MinMaxGrid
            static member MinMax ( contentSize: ContentSize.ContentSize, min: Fraction) =
                sprintf "minmax(%s, %s)"
                    (contentSizeToString contentSize)
                    (fractionToString min)
                |> MinMaxGrid
            interface ITemplateType

        let private repeatTypeToString (repeat: RepeatType) = Fss.Utilities.Helpers.duToKebab repeat
        let internal minMaxToString (MinMaxGrid m) = m

        // https://developer.mozilla.org/en-US/docs/Web/CSS/repeat
        type Repeat =
            | GridRepeat of string
            static member Repeat (value: int, fraction: Fraction) =
                sprintf "repeat(%d, %s)" value (fractionToString fraction)
                |> GridRepeat
            static member Repeat (value: int, length: ILengthPercentage) =
                sprintf "repeat(%d, %s)" value (lengthPercentageToString length)
                |> GridRepeat
            static member Repeat (value: int, contentSize: ContentSize.ContentSize) =
                sprintf "repeat(%d, %s)" value (contentSizeToString contentSize)
                |> GridRepeat
            static member Repeat (value: int, contentSizes: ContentSize.ContentSize list) =
                sprintf "repeat(%d, %s)"
                    value
                    (Fss.Utilities.Helpers.combineWs contentSizeToString contentSizes)
                |> GridRepeat
            static member Repeat (value: int, sizes: ILengthPercentage list) =
                sprintf "repeat(%d, %s)"
                    value
                    (Fss.Utilities.Helpers.combineWs lengthPercentageToString sizes)
                |> GridRepeat
            static member Repeat (value: RepeatType, fraction: Fraction) =
                sprintf "repeat(%s, %s)" (repeatTypeToString value) (fractionToString fraction)
                |> GridRepeat
            static member Repeat (value: RepeatType, length: ILengthPercentage) =
                sprintf "repeat(%s, %s)" (repeatTypeToString value) (lengthPercentageToString length)
                |> GridRepeat
            static member Repeat (value: RepeatType, contentSize: ContentSize.ContentSize) =
                sprintf "repeat(%s, %s)" (repeatTypeToString value) (contentSizeToString contentSize)
                |> GridRepeat
            static member Repeat (value: int, minMax: MinMax) =
                sprintf "repeat(%d, %s)" value (minMaxToString minMax)
                |> GridRepeat
            static member Repeat (value: int, sizes: Size list) =
                sprintf "repeat(%d, %s)"
                    value
                    (Fss.Utilities.Helpers.combineWs sizeToString sizes)
                |> GridRepeat
            static member Repeat (value: int, sizes: Percent list) =
                sprintf "repeat(%d, %s)"
                    value
                    (Fss.Utilities.Helpers.combineWs percentToString sizes)
                |> GridRepeat

            interface ITemplateType

        let internal repeatToString (GridRepeat g) = g
