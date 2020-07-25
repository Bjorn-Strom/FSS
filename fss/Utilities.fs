namespace Fss.Utilities

open Browser

module Types =
    type IAnimation = interface end
    type ICSSProperty = interface end
    type CSSObject = CSSObject of obj

    let value (CSSObject o): obj = 
        console.log("Value: ", o)
        o

    let combineList (list: 'a list) (value: 'a -> string) (seperator: string) =
        list
        |> List.map value
        |> String.concat seperator

module Global =
    open Types

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        interface ICSSProperty

    let value (v: Global): string =
        match v with
            | Initial -> "initial"
            | Inherit -> "inherit"
            | Unset -> "unset"
            | Revert -> "revert"

module Converters =
    let floatToPercent (f: float): string = sprintf "%d%%" (int <| f * 100.0)

module Color =
    open Converters

    let rgb (r: int) (g: int) (b: int) = sprintf "rgb(%d, %d, %d)" r g b
    let rgba (r: int) (g: int) (b: int) (a: float) = sprintf "rgba(%d, %d, %d, %f)" r g b a
    let hex (value: string) =
        if value.StartsWith("#") then
            value
        else
            sprintf "#%s"value
    let hsl (h: int) (s: float) (l: float) = 
        sprintf "hsl(%d, %s, %s)" 
            h 
            (floatToPercent s)
            (floatToPercent l)
    let hsla (h: int) (s: float) (l: float) (a: float) = 
        sprintf "hsla(%d, %s, %s, %s)" 
            h 
            (floatToPercent s) 
            (floatToPercent l) 
            (floatToPercent a)
