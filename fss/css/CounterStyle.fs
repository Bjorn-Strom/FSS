namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    type CounterStyle =
        | CounterStyle of string
        interface IContent
        interface IListStyleType

    let counterValue (CounterStyle c) = c
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        static member Cyclic = "system" ==> "cyclic"
        static member Numeric = "system" ==> "numeric"
        static member Alphabetic ="system" ==> "alphabetic"
        static member Symbolic = "system" ==> "symbolic"
        static member Additive = "system" ==> "additive"
        static member Fixed () = "system" ==> "fixed"
        static member Fixed (value: int) =
            "system" ==> sprintf "fixed %d" value
        static member Extends (system: System) =
            "system" ==> sprintf "extends %s" (string system)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        static member Negative (first: string) =
            "negative" ==> first
        static member Negative (first: string, second: string) =
            "negative" ==> sprintf "\"%s\" \"%s\"" first second

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    type Prefix =
        static member Value (value: string) = "prefix" ==> value
        static member Url (url: string) = "prefix" ==> sprintf "url(%s)" url

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type Suffix =
        static member Value (value: string) = "suffix" ==> value
        static member Url (url: string) = "suffix" ==> sprintf "url(%s)" url

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        static member Value (v1: int, v2: int) = "range" ==> sprintf "%d %d" v1 v2
        static member Value (v1: int, range: Range) = "range" ==> sprintf "%d %A" v1 range
        static member Value (r1: Range, r2: Range) = "range" ==> sprintf "%A %A" r1 r2
        static member Value (range: Range, value: string) = "range" ==>  sprintf "%A %s" range value
        static member Infinite = "range" ==> "infinite"
        static member Auto = "range" ==> "auto"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type Pad =
        static member pad (value: int, symbol: string) = "pad" ==> sprintf "%d \"%s\"" value symbol

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        static member Strings(strings: string list) =
                "symbols" ==>
                (strings
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " ")
        static member Urls (urls: string list) =
            "symbols" ==>
            (urls
            |> List.map (fun u -> sprintf "url('%s')" u)
            |> String.concat " ")
        static member Custom (custom: CounterStyle) = "symbols" ==> counterValue custom

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    type AdditiveSymbolType =
        | Symbol of string
        | Url of string

    let private stringifyAdditiveSymbols =
        function
            | Symbol s -> sprintf "\"%s\"" s
            | Url u -> sprintf "url(%s)" u

    type AdditiveSymbol =
        static member Value (symbols: (int * AdditiveSymbolType) list) =
             "additiveSymbols" ==>
                (symbols
                |> List.map (fun (n, s) -> sprintf "%d %s" n (stringifyAdditiveSymbols s))
                |> String.concat ", ")

    let AdditiveSymbol' (symbols: (int * AdditiveSymbolType) list) = AdditiveSymbol.Value(symbols)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        static member Auto = "speak-as" ==> "auto"
        static member Bullets = "speak-as" ==> "bullets"
        static member Numbers = "speak-as" ==> "numbers"
        static member Words = "speak-as" ==> "words"
        static member SpellOut = "speak-as" ==> "spell-out"
        static member CounterStyle (counter: CounterStyle) = "speak-as" ==> counterValue counter

