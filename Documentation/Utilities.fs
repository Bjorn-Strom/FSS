module Utilities

open System

let internal combine (separator: string) (value: string) : string =
    value
    |> Seq.fold
        (fun acc element ->
            if Char.IsUpper(char element) && acc.Length = 0 then
                acc + (string element)
            else if Char.IsUpper(char element) && acc.Length <> 0 then
                sprintf "%s%s%s" acc separator (string element)
            else
                acc + (string element))
        ""

let inline internal duToSpaced (x: 'a) = x.ToString() |> combine " "
