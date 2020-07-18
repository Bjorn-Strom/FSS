namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fss.Color
open Fss.Units
open Fss.Fonts
open Fss.Border
open Fss.BorderStyle
open Fss.BorderWidth
open Fss.BorderRadius
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
            | :? BorderStyle as b -> BorderStyle.value b
            | :? BorderWidth as b -> BorderWidth.value b
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
        | BorderTopWidth of ICss
        | BorderRightWidth of ICss
        | BorderBottomWidth of ICss
        | BorderLeftWidth of ICss

        | BorderRadius of ICss list
        | BorderTopLeftRadius of ICss list
        | BorderTopRightRadius of ICss list
        | BorderBottomRightRadius of ICss list
        | BorderBottomLeftRadius of ICss list

    let label = "label"
    let hover = ":hover"

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
                | Label l -> label ==> l
                | Color c -> color ==> Color.value c
                | BackgroundColor bc -> backgroundColor ==> Color.value bc
                | Hover h -> hover ==> createPOJO h
                | FontSize f -> fontSize ==> value f

                | Border b -> border ==> evalCssListToString b value
                | BorderStyle bss -> borderStyle ==> evalCssListToString bss BorderStyle.value

                | BorderWidth bws -> borderWidth ==> evalCssListToString bws value
                | BorderTopWidth bw -> borderTopWidth ==> value bw
                | BorderRightWidth bw -> borderRightWidth ==> value bw
                | BorderBottomWidth bw -> borderBottomWidth ==> value bw
                | BorderLeftWidth bw -> borderLeftWidth ==> value bw
               
                | BorderRadius br -> borderRadius ==> evalCssListToString br value
                | BorderTopLeftRadius br -> borderTopLeftRadius ==> evalCssListToString br value
                | BorderTopRightRadius br -> borderTopRightRadius ==> evalCssListToString br value
                | BorderBottomRightRadius br -> borderBottomRightRadius ==> evalCssListToString br value
                | BorderBottomLeftRadius br -> borderBottomLeftRadius ==> evalCssListToString br value)
        |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'


