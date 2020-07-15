namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fss.Color

module Main =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let private css' x = css(x) 

    type CSSAttribute =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSAttribute list

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
            | Label l -> "label" ==> l
            | Color c -> "color" ==> value c
            | BackgroundColor bc -> "background-color" ==> value bc
            | Hover h -> ":hover" ==> createPOJO h)
        |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'
