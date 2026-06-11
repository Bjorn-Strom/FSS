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

[<RequireQualifiedAccess>]
module FNV_1A =
    let private prime = 0x01000193
    let seed = 0x811C9DC5

    /// Feed a string into an existing hash state (for incremental hashing)
    let hashInto (state: int) (string: string) =
        let mutable h = state
        for i in 0 .. string.Length-1 do
            h <- h ^^^ int (string[i])
            h <- h * prime
        h

    let hash (string: string) =
        hashInto seed string