namespace Fss

open Fss.Types

module Grid =
    type MinMax =
        | MinMax of IMinMax * IMinMax
        interface IMinMax
        interface IGridAutoColumns
        interface IGridAutoRows
    
    type AutoFlow =
        | Row
        | Column
        | Dense
        interface IGridAutoFlow

    type TemplateArea =
        | TemplateArea of string list list
        interface IGridTemplateAreas

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