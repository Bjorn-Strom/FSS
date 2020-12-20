namespace Fss.Utilities

open Microsoft.FSharp.Reflection
open System

module Helpers =
    let internal toLowerAndCombine (separator: string) (value: string): string =
        value
        |> Seq.fold (fun acc element ->
        if Char.IsUpper(char element) && acc.Length = 0 then
            acc + (string <| Char.ToLower(element))
        else if Char.IsUpper(char element) && acc.Length <> 0 then
            sprintf "%s%s%s" acc separator (string <| Char.ToLower(element))
        else
            acc + (string element)) ""

    let internal pascalToCamelCase (value: string): string = sprintf "%c%s" (Char.ToLower(value.[0])) value.[1..]
    let internal pascalToKebabCase (value: string): string = toLowerAndCombine "-" value

    let inline internal duToString (x:'a): string=
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name

    let inline internal duToLowercase (x: 'a) = (duToString x).ToLower()

    let inline internal duToKebab (x: 'a) =
        x
        |> duToString
        |> toLowerAndCombine "-"

    let inline internal duToCamel (x: 'a) =
        x
        |> duToString
        |> pascalToCamelCase

    let inline internal duToSpaced (x: 'a) =
        x
        |> duToString
        |> toLowerAndCombine " "

    let internal toPsuedoClass (value: string): string = sprintf ":%s" value
    let internal toPsuedoElement (value: string): string = sprintf "::%s" value

    let internal combineList (list: 'a list) (value: 'a -> string) (seperator: string) =
        list
        |> List.map value
        |> String.concat seperator
    let internal combineWs (value: 'a -> string) (list: 'a list) = combineList list value " "
    let internal combineComma (value: 'a -> string) (list: 'a list) = combineList list value ", "

    let internal clamp min max value =
        if value > max then
            max
        else if value < min then
            min
        else
            value

module Converters =
    let internal floatToPercent (f: float): string = sprintf "%d%%" (int <| f * 100.0)

module Color =
    open Converters

    let internal rgb (r: int) (g: int) (b: int) = sprintf "rgb(%d, %d, %d)" r g b
    let internal rgba (r: int) (g: int) (b: int) (a: float) = sprintf "rgba(%d, %d, %d, %f)" r g b a
    let internal hex (value: string) =
        if value.StartsWith("#") then
            value
        else
            sprintf "#%s"value
    let internal hsl (h: int) (s: float) (l: float) =
        sprintf "hsl(%d, %s, %s)"
            h
            (floatToPercent s)
            (floatToPercent l)
    let internal hsla (h: int) (s: float) (l: float) (a: float) =
        sprintf "hsla(%d, %s, %s, %s)"
            h
            (floatToPercent s)
            (floatToPercent l)
            (floatToPercent a)
