namespace Fss.Utilities

open Microsoft.FSharp.Reflection
open System

module Helpers =
    let toLowerAndCombine (separator: string) (value: string): string =
        value
        |> Seq.fold (fun acc element ->
        if Char.IsUpper(char element) && acc.Length = 0 then
            acc + (string <| Char.ToLower(element))
        else if Char.IsUpper(char element) && acc.Length <> 0 then
            sprintf "%s%s%s" acc separator (string <| Char.ToLower(element))
        else
            acc + (string element)) ""

    let pascalToCamelCase (value: string): string = sprintf "%c%s" (Char.ToLower(value.[0])) value.[1..]
    let pascalToKebabCase (value: string): string = toLowerAndCombine "-" value

    let inline duToString (x:'a): string=
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name

    let inline duToLowercase (x: 'a) = (duToString x).ToLower()

    let inline duToKebab (x: 'a) =
        x
        |> duToString
        |> toLowerAndCombine "-"

    let inline duToCamel (x: 'a) =
        x
        |> duToString
        |> pascalToCamelCase

    let inline duToSpaced (x: 'a) =
        x
        |> duToString
        |> toLowerAndCombine " "

    let toPsuedoClass (value: string): string = sprintf ":%s" value
    let toPsuedoElement (value: string): string = sprintf "::%s" value

    let combineList (list: 'a list) (value: 'a -> string) (seperator: string) =
        list
        |> List.map value
        |> String.concat seperator
    let combineWs (value: 'a -> string) (list: 'a list) = combineList list value " "
    let combineComma (value: 'a -> string) (list: 'a list) = combineList list value ", "

    let clamp min max value =
        if value > max then
            max
        else if value < min then
            min
        else
            value


    let inline stringifyShorthand (shortList: 'a option list): string =
            shortList
            |> List.filter(fun x -> x.IsSome)
            |> List.map (fun x -> if x.IsSome then x.Value else "")
            |> String.concat " "

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
