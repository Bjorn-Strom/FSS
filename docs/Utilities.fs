namespace Docs

module Utilities =
    open Microsoft.FSharp.Reflection
    open System

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