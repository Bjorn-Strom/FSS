namespace Fss

open Fable.Core.JsInterop
open Fss

module CounterType =
    type CounterStyle =
        | CounterStyle of string
        interface IContent
        interface IListStyleType

    type CounterReset =
        | Reset of CounterStyle
        | ResetTo of CounterStyle * int
        interface ICounterReset

    type CounterIncrement =
        | Increment of CounterStyle
        | Add of CounterStyle * int
        interface ICounterIncrement

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    open CounterType

    let counterValue (CounterStyle c) = c
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        static member Cyclic = "system" ==> "cyclic" |> CounterProperty
        static member Numeric = "system" ==> "numeric" |> CounterProperty
        static member Alphabetic ="system" ==> "alphabetic" |> CounterProperty
        static member Symbolic = "system" ==> "symbolic" |> CounterProperty
        static member Additive = "system" ==> "additive" |> CounterProperty
        static member Fixed = "system" ==> "fixed" |> CounterProperty
        static member FixedValue (value: int) =
            "system" ==> sprintf "fixed %d" value |> CounterProperty
        static member Extends (system: System) =
            "system" ==> sprintf "extends %s" (string system) |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        static member Negative (first: string) =
            "negative" ==> first |> CounterProperty
        static member Negative (first: string, second: string) =
            "negative" ==> sprintf "\"%s\" \"%s\"" first second |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    type Prefix =
        static member Value (value: string) = "prefix" ==> value |> CounterProperty
        static member Url (url: string) = "prefix" ==> sprintf "url(%s)" url |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type Suffix =
        static member Value (value: string) = "suffix" ==> sprintf "'%s'" value |> CounterProperty
        static member Url (url: string) = "suffix" ==> sprintf "url(%s)" url |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        static member Value (v1: int, v2: int) = "range" ==> sprintf "%d %d" v1 v2 |> CounterProperty
        static member Value (v1: int, range: Range) = "range" ==> sprintf "%d %A" v1 range |> CounterProperty
        static member Value (r1: Range, r2: Range) = "range" ==> sprintf "%A %A" r1 r2 |> CounterProperty
        static member Value (range: Range, value: string) = "range" ==>  sprintf "%A %s" range value |> CounterProperty
        static member Infinite = "range" ==> "infinite" |> CounterProperty
        static member Auto = "range" ==> "auto" |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type Pad =
        static member pad (value: int, symbol: string) = "pad" ==> sprintf "%d \"%s\"" value symbol |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        static member Strings(strings: string list) =
                "symbols" ==>
                (strings
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " ") |> CounterProperty
        static member Urls (urls: string list) =
            "symbols" ==>
            (urls
            |> List.map (fun u -> sprintf "url('%s')" u)
            |> String.concat " ") |> CounterProperty
        static member Custom (custom: CounterStyle) = "symbols" ==> counterValue custom |> CounterProperty

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
                |> String.concat ", ") |> CounterProperty

    let AdditiveSymbol' (symbols: (int * AdditiveSymbolType) list) = AdditiveSymbol.Value(symbols)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        static member Auto = "speak-as" ==> "auto" |> CounterProperty
        static member Bullets = "speak-as" ==> "bullets" |> CounterProperty
        static member Numbers = "speak-as" ==> "numbers" |> CounterProperty
        static member Words = "speak-as" ==> "words" |> CounterProperty
        static member SpellOut = "speak-as" ==> "spell-out" |> CounterProperty
        static member CounterStyle (counter: CounterStyle) = "speak-as" ==> counterValue counter |> CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-reset
    let private counterResetToString (reset: ICounterReset) =
        let stringifyReset =
            function
                | Reset counter -> counterValue counter
                | ResetTo (counter, number) -> sprintf "%A %d" (counterValue counter) number

        match reset with
        | :? CounterReset as cr -> stringifyReset cr
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown counter reset"

    let private counterResetValue value = PropertyValue.cssValue Property.CounterReset value
    let private counterResetValue' value =
        value
        |> counterResetToString
        |> counterResetValue

    type CounterReset =
        static member Value (counterReset: ICounterReset) = counterReset |> counterResetValue'
        static member Reset (counter: CounterStyle) = counter |> Reset |> counterResetValue'
        static member ResetTo (counter: CounterStyle) (value: int) = ResetTo(counter, value) |> counterResetValue'
        static member None = None |> counterResetValue'
        static member Inherit = Inherit |> counterResetValue'
        static member Initial = Initial |> counterResetValue'
        static member Unset = Unset |> counterResetValue'

    let CounterReset' (counterReset: CounterStyle) = counterReset |> Reset |> CounterReset.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-increment
    let private counterIncrementToString (increment: ICounterIncrement) =
        let stringifyIncrement =
            function
                | Increment counter -> counterValue counter
                | Add (counter, number) -> sprintf "%A %d" (counterValue counter) number

        match increment with
        | :? CounterIncrement as cr -> stringifyIncrement cr
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown counter increment"

    let private counterIncrementValue value = PropertyValue.cssValue Property.CounterIncrement value
    let private counterIncrementValue' value =
        value
        |> counterIncrementToString
        |> counterIncrementValue

    type CounterIncrement =
        static member Value (counterIncrement: ICounterIncrement) = counterIncrement |> counterIncrementValue'
        static member Increment (counter: CounterStyle) = counter |> Increment |> counterIncrementValue'
        static member IncrementTo (counter: CounterStyle) (value: int) = Add(counter, value) |> counterIncrementValue'
        static member None = None |> counterIncrementValue'
        static member Inherit = Inherit |> counterIncrementValue'
        static member Initial = Initial |> counterIncrementValue'
        static member Unset = Unset |> counterIncrementValue'

    let CounterIncrement' (counterIncrement: CounterStyle) = counterIncrement |> Increment |> CounterIncrement.Value

    let createCounterObject (attributeList: CounterProperty list) counterName =
        createObj
            [
                sprintf "@counter-style %s"
                    counterName ==> createObj (attributeList |> List.map GlobalValue.CounterValue)
            ]
