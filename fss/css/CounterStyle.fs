namespace Fss

open Fable.Core
open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    [<Erase>]
    type System =
        static member cyclic = "system" ==> "cyclic" |> FssTypes.CounterProperty
        static member numeric = "system" ==> "numeric" |> FssTypes.CounterProperty
        static member alphabetic ="system" ==> "alphabetic" |> FssTypes.CounterProperty
        static member symbolic = "system" ==> "symbolic" |> FssTypes.CounterProperty
        static member additive = "system" ==> "additive" |> FssTypes.CounterProperty
        static member fixed' = "system" ==> "fixed" |> FssTypes.CounterProperty
        static member fixedValue (value: int) =
            "system" ==> sprintf "fixed %d" value |> FssTypes.CounterProperty
        static member extends (extend: FssTypes.ListStyle.Type) =
            "system" ==> sprintf "extends %s" (Utilities.Helpers.duToKebab extend) |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    [<Erase>]
    type Negative =
        static member negative (first: string) =
            "negative" ==> first |> FssTypes.CounterProperty
        static member negative (first: string, second: string) =
            "negative" ==> sprintf "\"%s\" \"%s\"" first second |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    [<Erase>]
    type Prefix =
        static member value (value: string) = "prefix" ==> value |> FssTypes.CounterProperty
        static member url (url: string) = "prefix" ==> sprintf "url(%s)" url |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    [<Erase>]
    type Suffix =
        static member value (value: string) = "suffix" ==> sprintf "'%s'" value |> FssTypes.CounterProperty
        static member url (url: string) = "suffix" ==> sprintf "url(%s)" url |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    [<Erase>]
    type Range =
        static member value (v1: int, v2: int) = "range" ==> sprintf "%d %d" v1 v2 |> FssTypes.CounterProperty
        static member value (v1: int, range: Range) = "range" ==> sprintf "%d %A" v1 range |> FssTypes.CounterProperty
        static member value (r1: Range, r2: Range) = "range" ==> sprintf "%A %A" r1 r2 |> FssTypes.CounterProperty
        static member value (range: Range, value: string) = "range" ==>  sprintf "%A %s" range value |> FssTypes.CounterProperty
        static member infinite = "range" ==> "infinite" |> FssTypes.CounterProperty
        static member auto = "range" ==> "auto" |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    [<Erase>]
    type Pad =
        static member pad (value: int, symbol: string) = "pad" ==> sprintf "%d \"%s\"" value symbol |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    [<Erase>]
    type Symbols =
        static member strings(strings: string list) =
                "symbols" ==>
                (strings
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " ") |> FssTypes.CounterProperty
        static member urls (urls: string list) =
            "symbols" ==>
            (urls
            |> List.map (fun u -> sprintf "url('%s')" u)
            |> String.concat " ") |> FssTypes.CounterProperty
        static member custom (custom: FssTypes.Counter.Style) = "symbols" ==> FssTypes.counterStyleHelpers.counterStyleToString custom |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    [<Erase>]
    type AdditiveSymbolType =
        | Symbol of string
        | Url of string

    let private stringifyAdditiveSymbols =
        function
            | Symbol s -> sprintf "\"%s\"" s
            | Url u -> sprintf "url(%s)" u

    [<Erase>]
    type AdditiveSymbol =
        static member value (symbols: (int * AdditiveSymbolType) list) =
             "additiveSymbols" ==>
                (symbols
                |> List.map (fun (n, s) -> sprintf "%d %s" n (stringifyAdditiveSymbols s))
                |> String.concat ", ") |> FssTypes.CounterProperty

    let AdditiveSymbol' (symbols: (int * AdditiveSymbolType) list) = AdditiveSymbol.value(symbols)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    [<Erase>]
    type SpeakAs =
        static member auto = "speak-as" ==> "auto" |> FssTypes.CounterProperty
        static member bullets = "speak-as" ==> "bullets" |> FssTypes.CounterProperty
        static member numbers = "speak-as" ==> "numbers" |> FssTypes.CounterProperty
        static member words = "speak-as" ==> "words" |> FssTypes.CounterProperty
        static member spellOut = "speak-as" ==> "spell-out" |> FssTypes.CounterProperty
        static member counterStyle (counter: FssTypes.Counter.Style) = "speak-as" ==> FssTypes.counterStyleHelpers.counterStyleToString counter |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-reset
    let private counterResetToString (reset: FssTypes.ICounterReset) =
        let stringifyReset =
            function
                | FssTypes.Counter.Reset counter -> FssTypes.counterStyleHelpers.counterStyleToString counter
                | FssTypes.Counter.ResetTo (counter, number) -> sprintf "%A %d" (FssTypes.counterStyleHelpers.counterStyleToString counter) number

        match reset with
        | :? FssTypes.Counter.Reset as cr -> stringifyReset cr
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown counter reset"

    let private counterResetValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.CounterReset value
    let private counterResetValue' value =
        value
        |> counterResetToString
        |> counterResetValue

    [<Erase>]
    type CounterReset =
        static member value (counterReset: FssTypes.ICounterReset) = counterReset |> counterResetValue'
        static member reset (counter: FssTypes.Counter.Style) = counter |> FssTypes.Counter.Reset |> counterResetValue'
        static member resetTo (counter: FssTypes.Counter.Style) (value: int) = FssTypes.Counter.ResetTo(counter, value) |> counterResetValue'
        static member none = FssTypes.None' |> counterResetValue'
        static member inherit' = FssTypes.Inherit |> counterResetValue'
        static member initial = FssTypes.Initial |> counterResetValue'
        static member unset = FssTypes.Unset |> counterResetValue'

    let CounterReset' (counterReset: FssTypes.Counter.Style) = counterReset |> FssTypes.Counter.Reset |> CounterReset.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-increment
    let private counterIncrementToString (increment: FssTypes.ICounterIncrement) =
        let stringifyIncrement =
            function
                | FssTypes.Counter.Increment counter -> FssTypes.counterStyleHelpers.counterStyleToString counter
                | FssTypes.Counter.Add (counter, number) -> sprintf "%A %d" (FssTypes.counterStyleHelpers.counterStyleToString counter) number

        match increment with
        | :? FssTypes.Counter.Increment as cr -> stringifyIncrement cr
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown counter increment"

    let private counterIncrementValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.CounterIncrement value
    let private counterIncrementValue' value =
        value
        |> counterIncrementToString
        |> counterIncrementValue

    [<Erase>]
    type CounterIncrement =
        static member value (counterIncrement: FssTypes.ICounterIncrement) = counterIncrement |> counterIncrementValue'
        static member increment (counter: FssTypes.Counter.Style) = counter |> FssTypes.Counter.Increment |> counterIncrementValue'
        static member incrementTo (counter: FssTypes.Counter.Style) (value: int) = FssTypes.Counter.Add(counter, value) |> counterIncrementValue'
        static member none = FssTypes.None' |> counterIncrementValue'
        static member inherit' = FssTypes.Inherit |> counterIncrementValue'
        static member initial = FssTypes.Initial |> counterIncrementValue'
        static member unset = FssTypes.Unset |> counterIncrementValue'

    let CounterIncrement' (counterIncrement: FssTypes.Counter.Style) = counterIncrement |> FssTypes.Counter.Increment |> CounterIncrement.value

    let createCounterObject (attributeList: FssTypes.CounterProperty list) counterName =
        createObj
            [
                sprintf "@counter-style %s"
                    counterName ==> createObj (attributeList |> List.map FssTypes.masterTypeHelpers.CounterValue)
            ]
