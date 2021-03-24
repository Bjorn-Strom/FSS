namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        static member Cyclic = "system" ==> "cyclic" |> FssTypes.CounterProperty
        static member Numeric = "system" ==> "numeric" |> FssTypes.CounterProperty
        static member Alphabetic ="system" ==> "alphabetic" |> FssTypes.CounterProperty
        static member Symbolic = "system" ==> "symbolic" |> FssTypes.CounterProperty
        static member Additive = "system" ==> "additive" |> FssTypes.CounterProperty
        static member Fixed = "system" ==> "fixed" |> FssTypes.CounterProperty
        static member FixedValue (value: int) =
            "system" ==> sprintf "fixed %d" value |> FssTypes.CounterProperty
        static member Extends (extend: FssTypes.ListStyle.Type) =
            "system" ==> sprintf "extends %s" (Utilities.Helpers.duToKebab extend) |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        static member Negative (first: string) =
            "negative" ==> first |> FssTypes.CounterProperty
        static member Negative (first: string, second: string) =
            "negative" ==> sprintf "\"%s\" \"%s\"" first second |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    type Prefix =
        static member Value (value: string) = "prefix" ==> value |> FssTypes.CounterProperty
        static member Url (url: string) = "prefix" ==> sprintf "url(%s)" url |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type Suffix =
        static member Value (value: string) = "suffix" ==> sprintf "'%s'" value |> FssTypes.CounterProperty
        static member Url (url: string) = "suffix" ==> sprintf "url(%s)" url |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        static member Value (v1: int, v2: int) = "range" ==> sprintf "%d %d" v1 v2 |> FssTypes.CounterProperty
        static member Value (v1: int, range: Range) = "range" ==> sprintf "%d %A" v1 range |> FssTypes.CounterProperty
        static member Value (r1: Range, r2: Range) = "range" ==> sprintf "%A %A" r1 r2 |> FssTypes.CounterProperty
        static member Value (range: Range, value: string) = "range" ==>  sprintf "%A %s" range value |> FssTypes.CounterProperty
        static member Infinite = "range" ==> "infinite" |> FssTypes.CounterProperty
        static member Auto = "range" ==> "auto" |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type Pad =
        static member pad (value: int, symbol: string) = "pad" ==> sprintf "%d \"%s\"" value symbol |> FssTypes.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        static member Strings(strings: string list) =
                "symbols" ==>
                (strings
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " ") |> FssTypes.CounterProperty
        static member Urls (urls: string list) =
            "symbols" ==>
            (urls
            |> List.map (fun u -> sprintf "url('%s')" u)
            |> String.concat " ") |> FssTypes.CounterProperty
        static member Custom (custom: FssTypes.Counter.Style) = "symbols" ==> FssTypes.counterStyleHelpers.counterStyleToString custom |> FssTypes.CounterProperty

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
                |> String.concat ", ") |> FssTypes.CounterProperty

    let AdditiveSymbol' (symbols: (int * AdditiveSymbolType) list) = AdditiveSymbol.Value(symbols)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        static member Auto = "speak-as" ==> "auto" |> FssTypes.CounterProperty
        static member Bullets = "speak-as" ==> "bullets" |> FssTypes.CounterProperty
        static member Numbers = "speak-as" ==> "numbers" |> FssTypes.CounterProperty
        static member Words = "speak-as" ==> "words" |> FssTypes.CounterProperty
        static member SpellOut = "speak-as" ==> "spell-out" |> FssTypes.CounterProperty
        static member CounterStyle (counter: FssTypes.Counter.Style) = "speak-as" ==> FssTypes.counterStyleHelpers.counterStyleToString counter |> FssTypes.CounterProperty

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

    type CounterReset =
        static member Value (counterReset: FssTypes.ICounterReset) = counterReset |> counterResetValue'
        static member Reset (counter: FssTypes.Counter.Style) = counter |> FssTypes.Counter.Reset |> counterResetValue'
        static member ResetTo (counter: FssTypes.Counter.Style) (value: int) = FssTypes.Counter.ResetTo(counter, value) |> counterResetValue'
        static member None = FssTypes.None' |> counterResetValue'
        static member Inherit = FssTypes.Inherit |> counterResetValue'
        static member Initial = FssTypes.Initial |> counterResetValue'
        static member Unset = FssTypes.Unset |> counterResetValue'

    let CounterReset' (counterReset: FssTypes.Counter.Style) = counterReset |> FssTypes.Counter.Reset |> CounterReset.Value

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

    type CounterIncrement =
        static member Value (counterIncrement: FssTypes.ICounterIncrement) = counterIncrement |> counterIncrementValue'
        static member Increment (counter: FssTypes.Counter.Style) = counter |> FssTypes.Counter.Increment |> counterIncrementValue'
        static member IncrementTo (counter: FssTypes.Counter.Style) (value: int) = FssTypes.Counter.Add(counter, value) |> counterIncrementValue'
        static member None = FssTypes.None' |> counterIncrementValue'
        static member Inherit = FssTypes.Inherit |> counterIncrementValue'
        static member Initial = FssTypes.Initial |> counterIncrementValue'
        static member Unset = FssTypes.Unset |> counterIncrementValue'

    let CounterIncrement' (counterIncrement: FssTypes.Counter.Style) = counterIncrement |> FssTypes.Counter.Increment |> CounterIncrement.Value

    let createCounterObject (attributeList: FssTypes.CounterProperty list) counterName =
        createObj
            [
                sprintf "@counter-style %s"
                    counterName ==> createObj (attributeList |> List.map FssTypes.masterTypeHelpers.CounterValue)
            ]
