namespace Fss.Utilities

open System

module Helpers =
    let internal toLowerAndCombine (separator: string) (value: string) : string =
        value
        |> Seq.fold
            (fun acc element ->
                if Char.IsUpper(char element) && acc.Length = 0 then
                    acc + (string <| Char.ToLower(element))
                else if Char.IsUpper(char element) && acc.Length <> 0 then
                    sprintf "%s%s%s" acc separator (string <| Char.ToLower(element))
                else
                    acc + (string element))
            ""

    let internal toKebabCase (x: 'a) = x.ToString() |> toLowerAndCombine "-"
    let internal toSpacedCase (x: 'a) = x.ToString() |> toLowerAndCombine " " 

[<RequireQualifiedAccess>]
module FNV_1A =
    let private prime = 0x811C9DC5
    let hash (string: string) =
        let mutable hash = 0
        for i in 0 .. string.Length-1 do
            hash <- hash ^^^ int (string[i])
            hash <- hash * prime
            
        hash