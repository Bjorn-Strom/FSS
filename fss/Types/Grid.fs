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

    type Repeat =
        | AutoFill
        | AutoFit


