namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        static member Cyclic = "system" ==> "cyclic" |> Types.CounterProperty
        static member Numeric = "system" ==> "numeric" |> Types.CounterProperty
        static member Alphabetic ="system" ==> "alphabetic" |> Types.CounterProperty
        static member Symbolic = "system" ==> "symbolic" |> Types.CounterProperty
        static member Additive = "system" ==> "additive" |> Types.CounterProperty
        static member Fixed = "system" ==> "fixed" |> Types.CounterProperty
        static member FixedValue (value: int) =
            "system" ==> sprintf "fixed %d" value |> Types.CounterProperty
        static member Extends (extend: Types.ListStyleType) =
            "system" ==> sprintf "extends %s" (Utilities.Helpers.duToKebab extend) |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        static member Negative (first: string) =
            "negative" ==> first |> Types.CounterProperty
        static member Negative (first: string, second: string) =
            "negative" ==> sprintf "\"%s\" \"%s\"" first second |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    type Prefix =
        static member Value (value: string) = "prefix" ==> value |> Types.CounterProperty
        static member Url (url: string) = "prefix" ==> sprintf "url(%s)" url |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type Suffix =
        static member Value (value: string) = "suffix" ==> sprintf "'%s'" value |> Types.CounterProperty
        static member Url (url: string) = "suffix" ==> sprintf "url(%s)" url |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        static member Value (v1: int, v2: int) = "range" ==> sprintf "%d %d" v1 v2 |> Types.CounterProperty
        static member Value (v1: int, range: Range) = "range" ==> sprintf "%d %A" v1 range |> Types.CounterProperty
        static member Value (r1: Range, r2: Range) = "range" ==> sprintf "%A %A" r1 r2 |> Types.CounterProperty
        static member Value (range: Range, value: string) = "range" ==>  sprintf "%A %s" range value |> Types.CounterProperty
        static member Infinite = "range" ==> "infinite" |> Types.CounterProperty
        static member Auto = "range" ==> "auto" |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type Pad =
        static member pad (value: int, symbol: string) = "pad" ==> sprintf "%d \"%s\"" value symbol |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        static member Strings(strings: string list) =
                "symbols" ==>
                (strings
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " ") |> Types.CounterProperty
        static member Urls (urls: string list) =
            "symbols" ==>
            (urls
            |> List.map (fun u -> sprintf "url('%s')" u)
            |> String.concat " ") |> Types.CounterProperty
        static member Custom (custom: Types.CounterStyle) = "symbols" ==> Types.counterStyleHelpers.counterStyleToString custom |> Types.CounterProperty

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
                |> String.concat ", ") |> Types.CounterProperty

    let AdditiveSymbol' (symbols: (int * AdditiveSymbolType) list) = AdditiveSymbol.Value(symbols)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        static member Auto = "speak-as" ==> "auto" |> Types.CounterProperty
        static member Bullets = "speak-as" ==> "bullets" |> Types.CounterProperty
        static member Numbers = "speak-as" ==> "numbers" |> Types.CounterProperty
        static member Words = "speak-as" ==> "words" |> Types.CounterProperty
        static member SpellOut = "speak-as" ==> "spell-out" |> Types.CounterProperty
        static member CounterStyle (counter: Types.CounterStyle) = "speak-as" ==> Types.counterStyleHelpers.counterStyleToString counter |> Types.CounterProperty

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-reset
    let private counterResetToString (reset: Types.ICounterReset) =
        let stringifyReset =
            function
                | Types.Reset counter -> Types.counterStyleHelpers.counterStyleToString counter
                | Types.ResetTo (counter, number) -> sprintf "%A %d" (Types.counterStyleHelpers.counterStyleToString counter) number

        match reset with
        | :? Types.CounterReset as cr -> stringifyReset cr
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown counter reset"

    let private counterResetValue value = Types.propertyHelpers.cssValue Types.Property.CounterReset value
    let private counterResetValue' value =
        value
        |> counterResetToString
        |> counterResetValue

    type CounterReset =
        static member Value (counterReset: Types.ICounterReset) = counterReset |> counterResetValue'
        static member Reset (counter: Types.CounterStyle) = counter |> Types.Reset |> counterResetValue'
        static member ResetTo (counter: Types.CounterStyle) (value: int) = Types.ResetTo(counter, value) |> counterResetValue'
        static member None = Types.None' |> counterResetValue'
        static member Inherit = Types.Inherit |> counterResetValue'
        static member Initial = Types.Initial |> counterResetValue'
        static member Unset = Types.Unset |> counterResetValue'

    let CounterReset' (counterReset: Types.CounterStyle) = counterReset |> Types.Reset |> CounterReset.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-increment
    let private counterIncrementToString (increment: Types.ICounterIncrement) =
        let stringifyIncrement =
            function
                | Types.Increment counter -> Types.counterStyleHelpers.counterStyleToString counter
                | Types.CounterIncrement.Add (counter, number) -> sprintf "%A %d" (Types.counterStyleHelpers.counterStyleToString counter) number

        match increment with
        | :? Types.CounterIncrement as cr -> stringifyIncrement cr
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown counter increment"

    let private counterIncrementValue value = Types.propertyHelpers.cssValue Types.Property.CounterIncrement value
    let private counterIncrementValue' value =
        value
        |> counterIncrementToString
        |> counterIncrementValue

    type CounterIncrement =
        static member Value (counterIncrement: Types.ICounterIncrement) = counterIncrement |> counterIncrementValue'
        static member Increment (counter: Types.CounterStyle) = counter |> Types.Increment |> counterIncrementValue'
        static member IncrementTo (counter: Types.CounterStyle) (value: int) = Types.CounterIncrement.Add(counter, value) |> counterIncrementValue'
        static member None = Types.None' |> counterIncrementValue'
        static member Inherit = Types.Inherit |> counterIncrementValue'
        static member Initial = Types.Initial |> counterIncrementValue'
        static member Unset = Types.Unset |> counterIncrementValue'

    let CounterIncrement' (counterIncrement: Types.CounterStyle) = counterIncrement |> Types.Increment |> CounterIncrement.Value

    let createCounterObject (attributeList: Types.CounterProperty list) counterName =
        createObj
            [
                sprintf "@counter-style %s"
                    counterName ==> createObj (attributeList |> List.map Types.masterTypeHelpers.CounterValue)
            ]
