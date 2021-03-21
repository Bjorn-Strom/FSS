namespace FssTypes

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

type Repeat =
    | AutoFill
    | AutoFit


