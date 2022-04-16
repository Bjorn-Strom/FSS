namespace Feliz

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz.ReactApi

[<RequireQualifiedAccess>]
module DateParsing =
    open System
    let (|Between|_|) (x: int) (y: int) (input: int) =
        if input >= x && input <= y
        then Some()
        else None
    let isLeapYear (year: int) = DateTime.IsLeapYear(year)

    let (|Int|_|) (input: string) =
        try (Some (int input))
        with _ -> None
    /// <summary>Parses a specific yyyy-MM-dd or yyyy-MM-ddTHH:mm date format that comes out of an input element with type="date"</summary>
    let parse (input: string) : Option<DateTime> =
        try
            if String.IsNullOrWhiteSpace input then None
            else
            let parts = input.Split('-')
            let year, month, day, hour, minute =
                match parts with
                | [| Int year; Int month |] -> year, month, 1, 0, 0
                | [| Int year; Int month; Int day |] -> year, month, day, 0, 0
                | [| Int year; Int month; day |] ->
                    if day.Contains("T") then
                        match day.Split('T') with
                        | [| Int parsedDay; time |] ->
                            match time.Split ':' with
                            | [| Int hour; Int minute |] ->
                                match hour, minute with
                                | Between 0 59, Between 0 59 -> year, month, parsedDay, hour, minute
                                | _ ->
                                    -1, 1, 1, 0, 0
                            | _ ->
                                -1, 1, 1, 0, 0
                        | _ ->
                            -1, 1, 1, 0, 0
                    else
                        -1, 1, 1, 0, 0
                | _ ->
                    -1, 1, 1, 0, 0
            if year <= 0 then
                None
            else
                match month, day with
                | 2, Between 1 29 when isLeapYear year -> Some (DateTime(year, month, day, hour, minute, 0))
                | 2, Between 1 28 when not (isLeapYear year) -> Some (DateTime(year, month, day, hour, minute, 0))
                | (1 | 3 | 5 | 7 | 8 | 10 | 12), Between 1 31 -> Some (DateTime(year, month, day, hour, minute, 0))
                | (4 | 6 | 9 | 11), Between 1 30 -> Some (DateTime(year, month, day, hour, minute, 0))
                | _ -> None
        with
        | _ -> None

[<RequireQualifiedAccess>]
module Interop =
    let reactApi : IReactApi = importDefault "react"
    #if FABLE_COMPILER_3
    let inline reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
    #else
    let reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
    #endif
    let inline mkAttr (key: string) (value: obj) : IReactProperty = unbox (key, value)
    [<Emit "undefined">]
    let undefined : obj = jsNative
    let inline mkStyle (key: string) (value: obj) : IStyleAttribute = unbox (key, value)
    let inline svgAttribute (key: string) (value: obj) : ISvgAttribute = unbox (key, value)
    let inline reactElementWithChild (name: string) (child: 'a) =
        reactElement name (createObj [ "children" ==> ResizeArray [| child |] ])
    let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) =
        reactElement name (createObj [ "children" ==> reactApi.Children.toArray (Array.ofSeq children) ])
    let inline createElement name (properties: IReactProperty list) : ReactElement =
        reactElement name (createObj !!properties)
    let inline createSvgElement name (properties: ISvgAttribute list) : ReactElement =
        reactElement name (createObj !!properties)

    [<Emit "typeof $0 === 'number'">]
    let isTypeofNumber (x: obj) : bool = jsNative
