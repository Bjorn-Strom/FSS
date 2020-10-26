namespace Fss

open Fss.Global
open Fss.Types

module Grid =
    type MinMax =
        | MinMax of IMinMax * IMinMax
        interface IMinMax
        interface IGridAutoColumns
        interface IGridAutoRows
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IRepeat

    type RepeatTypes =
        | AutoFill
        | AutoFit
        interface IRepeatTypes

    type RepeatContent =
        | Name of string
        interface IRepeat

    type Repeat =
        | Repeat     of IRepeatTypes * IRepeat
        | RepeatMany of IRepeatTypes * IRepeat list
        interface IRepeat
        interface IGridTemplateColumns
        interface IGridTemplateRows

    type AutoFlow =
        | Rows
        | Columns
        | Dense
        interface IGridAutoFlow

    type TemplateArea =
        | TemplateArea of Ident list list
        interface IGridTemplateAreas

    type Subgrid =
        | Subgrid
        interface IGridTemplateColumns
        interface IGridTemplateRows

    type Gap =
        | Gap of IGridRowGap * IGridColumnGap
        interface IGridGap

    type Span =
        | Span of int
        interface IGridRowStart
        interface IGridRowEnd
        interface IGridColumnStart
        interface IGridColumnEnd

    type Row =
        | Row of IGridRowStart * IGridRowEnd
        interface IGridRow

    let Row (s: IGridRowStart) (e: IGridRowEnd) = Row(s, e) :> IGridRow

    type Column =
        | Column of IGridColumnStart * IGridColumnEnd
        interface IGridColumn

    let Column value1 value2 = Column(value1, value2) :> IGridColumn

module GridValue =
    open ContentSize
    open Units.Percent
    open Units.Size
    open Units.Fraction
    open Grid
    open Utilities.Helpers

    let minMax (MinMax (m1, m2)) =
        let minMaxValue (m: IMinMax) =
            match m with
            | :? Size        as s -> Units.Size.value s
            | :? Percent     as p -> Units.Percent.value p
            | :? ContentSize as c -> ContentSize.value c
            | :? Global.Auto as a -> GlobalValue.auto a
            | :? Fraction    as f -> Units.Fraction.value f
            | _ -> "Unknown min max value"

        sprintf "minmax(%s, %s)"
            (minMaxValue m1)
            (minMaxValue m2)

    let private repeatTypes (v: IRepeatTypes) =
        match v with
        | :? Global.Value as v -> GlobalValue.value v
        | :? RepeatTypes  as r -> duToKebab r
        | _ -> "Unknown repeat types"

    let repeat (v: Repeat) =
        let stringifyIRepeat (r: IRepeat) =
            match r with
            | :? Global.Auto   as a -> GlobalValue.auto a
            | :? ContentSize   as c -> ContentSize.value c
            | :? Percent       as p -> Units.Percent.value p
            | :? Size          as s -> Units.Size.value s
            | :? Fraction      as f -> Units.Fraction.value f
            | :? MinMax        as m -> minMax m
            | _ -> "Unknown repeat value"

        match v with
            | Repeat     (types, r)  -> sprintf "repeat(%s, %s)" (repeatTypes types) (stringifyIRepeat r)
            | RepeatMany (types, rs) -> sprintf "repeat(%s, %s)" (repeatTypes types) (combineWs stringifyIRepeat rs)

    let autoColumns (v: IGridAutoColumns) =
        match v with
        | :? ContentSize   as c -> ContentSize.value c
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | :? Fraction      as f -> Units.Fraction.value f
        | :? MinMax        as m -> minMax m
        | _ -> "Unknown grid auto columns"

    let autoRows (v: IGridAutoRows) =
        match v with
        | :? ContentSize   as c -> ContentSize.value c
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | :? Fraction      as f -> Units.Fraction.value f
        | :? MinMax        as m -> minMax m
        | _ -> "Unknown grid auto rows"

    let autoFlow (v: IGridAutoFlow) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? AutoFlow      as m -> duToLowercase m
        | _ -> "Unknown grid auto flow"

    let templateAreas (v: IGridTemplateAreas) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.None   as n -> GlobalValue.none n
        | :? TemplateArea  as t ->
            let (TemplateArea t) = t
            t
            |> List.map (fun x -> x |> List.map GlobalValue.ident)
            |> List.map (fun x -> ["\""] @ x @ ["\""])
            |> List.map (fun x -> String.concat " " x)
            |> String.concat " "
        | _ -> "Unknown grid template area"

    let templateColumns (v: IGridTemplateColumns) =
        match v with
        | :? ContentSize   as c -> ContentSize.value c
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.None   as n -> GlobalValue.none n
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | :? Fraction      as f -> Units.Fraction.value f
        | :? MinMax        as m -> minMax m
        | :? Repeat        as r -> repeat r
        | :? Subgrid       as s -> duToLowercase s
        | _ -> "Unknown grid template column"

    let templateRows (v: IGridTemplateRows) =
        match v with
        | :? ContentSize   as c -> ContentSize.value c
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.None   as n -> GlobalValue.none n
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | :? Fraction      as f -> Units.Fraction.value f
        | :? MinMax        as m -> minMax m
        | :? Repeat        as r -> repeat r
        | :? Subgrid       as s -> duToLowercase s
        | _ -> "Unknown grid template row"

    let columnGap (v: IGridColumnGap) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Normal as n -> GlobalValue.normal n
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | _ -> "Unknown grid column gap"

    let rowGap (v: IGridRowGap) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Normal as n -> GlobalValue.normal n
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | _ -> "Unknown grid row gap"

    let gap (v: IGridGap) =
        let stringifyGridGap (Gap (r, c)) =
            sprintf "%s %s" (rowGap r) (columnGap c)

        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Normal as n -> GlobalValue.normal n
        | :? Percent       as p -> Units.Percent.value p
        | :? Size          as s -> Units.Size.value s
        | :? Gap           as g -> stringifyGridGap g
        | _ -> "Unknown grid row gap"

    let private span (Span s) = sprintf "span %d" s

    let rowStart (v: IGridRowStart) =

        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Global.Value  as v -> GlobalValue.value v
        | :? Global.Ident  as i -> GlobalValue.ident i
        | :? Span          as s -> span s
        | _ -> "Unknown grid row start"

    let rowEnd (v: IGridRowEnd) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Global.Value  as v -> GlobalValue.value v
        | :? Global.Ident  as i -> GlobalValue.ident i
        | :? Span          as s -> span s
        | _ -> "Unknown grid row end"

    let row (v: IGridRow) =
        let stringifyRow (Row (s, e)) =
            sprintf "%s / %s" (rowStart s) (rowEnd e)

        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Row           as r -> stringifyRow r
        | _ -> "Unknown grid row"

    let columnStart (v: IGridColumnStart) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Global.Value  as v -> GlobalValue.value v
        | :? Global.Ident  as i -> GlobalValue.ident i
        | :? Span          as s -> span s
        | _ -> "Unknown grid column start"

    let columnEnd (v: IGridColumnEnd) =
        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Global.Value  as v -> GlobalValue.value v
        | :? Global.Ident  as i -> GlobalValue.ident i
        | :? Span          as s -> span s
        | _ -> "Unknown grid column end"

    let column (v: IGridColumn) =
        let stringifyColumn (Column (s, e)) =
            sprintf "%s / %s" (columnStart s) (columnEnd e)

        match v with
        | :? Global.Global as g -> GlobalValue.globalValue g
        | :? Global.Auto   as a -> GlobalValue.auto a
        | :? Column        as r -> stringifyColumn r
        | _ -> "Unknown grid column"

    let area (v: IGridArea) =
        match v with
        | :? Global.Ident as i -> GlobalValue.ident i
        | _ -> "Unknown grid area"