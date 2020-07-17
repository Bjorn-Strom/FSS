namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fss.Color
open Fss.Units
open Fss.Fonts

module Main =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let private css' x = css(x) 

    let value (v: Utilities.Types.ICss): string =
        match v with
            | :? Unit as c -> Units.value c
            | :? FontSize as f -> Fonts.value f
            | _ -> "Unknown CSS"

    type CSSAttribute =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSAttribute list
        | FontSize of Utilities.Types.ICss

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
                | Label l -> "label" ==> l
                | Color c -> "color" ==> Color.value c
                | BackgroundColor bc -> "background-color" ==> Color.value bc
                | Hover h -> ":hover" ==> createPOJO h
                | FontSize f -> "font-size" ==> value f)
        |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'
