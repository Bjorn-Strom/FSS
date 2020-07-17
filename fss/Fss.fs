namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fss.Color
open Fss.Units

module Main =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let private css' x = css(x) 

    type CSSAttribute =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSAttribute list
        | Foo of Unit

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
            | Label l -> "label" ==> l
            | Color c -> "color" ==> Color.value c
            | BackgroundColor bc -> "background-color" ==> Color.value bc
            | Hover h -> ":hover" ==> createPOJO h
            | Foo u -> "test" ==> Units.value u)
        |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'
