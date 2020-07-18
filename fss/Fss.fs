namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fss.Color
open Fss.Units
open Fss.Fonts
open Fss.Border.BorderStyle
open Fss.Border.BorderWidth
open Fss.Utilities.Types

module Main =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let private css' x = css(x) 

    let value (v: ICss): string =
        match v with
            | :? CssColor as c -> Color.value c
            | :? Unit as c -> Units.value c
            | :? FontSize as f -> Fonts.value f
            | :? BorderStyle as b -> Border.BorderStyle.value b
            | :? BorderWidth as b -> Border.BorderWidth.value b
            | _ -> "Unknown CSS"

    type CSSAttribute =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSAttribute list
        | FontSize of ICss
        | Border of ICss list
        | BorderStyle of BorderStyle list
        | BorderWidth of ICss list

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
                | Label l -> "label" ==> l
                | Color c -> "color" ==> Color.value c
                | BackgroundColor bc -> "background-color" ==> Color.value bc
                | Hover h -> ":hover" ==> createPOJO h
                | FontSize f -> "font-size" ==> value f
                | Border b -> "border" ==> evalCssListToString b value
                | BorderStyle bss -> "border-style" ==> evalCssListToString bss Border.BorderStyle.value
                | BorderWidth bws -> "border-width" ==> evalCssListToString bws value)
        |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'


