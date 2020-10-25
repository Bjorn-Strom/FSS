namespace Fss

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
        | Value of int

    type RepeatContent =
        | Name of string
        interface IRepeat
        
    type Repeat =
        | Repeat     of RepeatTypes * IRepeat
        | RepeatMany of RepeatTypes * IRepeat list
        interface IRepeat
        interface IGridTemplateColumns
        interface IGridTemplateRows
    
    type AutoFlow =
        | Row
        | Column
        | Dense
        interface IGridAutoFlow

    type TemplateArea =
        | TemplateArea of string list list
        interface IGridTemplateAreas
        
    type Subgrid =
        | Subgrid
        interface IGridTemplateColumns
        interface IGridTemplateRows
        
    type Gap =
        | Gap of IGridRowGap * IGridColumnGap
        interface IGridGap
        
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

    let private repeatTypes (v: RepeatTypes) =
        match v with
        | Value v -> string v
        | _ -> duToKebab v 
                
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