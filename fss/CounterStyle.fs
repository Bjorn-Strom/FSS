namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style
[<AutoOpen>]
module Counter =
    open Fable.Core.JsInterop
    
    open Utilities.Helpers
    open Types
    open Global
    
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        | Cyclic
        | Numeric
        | Alphabetic
        | Symbolic
        | Additive
        | Fixed
        | FixedValue of int
        | Extends of CounterStyle
        
    let private system (s: System): string =
        match s with
            | FixedValue v -> sprintf "fixed %i" v
            | Extends    e -> sprintf "extends %s" (counterValue e)
            | _ -> duToKebab s
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        | Negative1 of string
        | Negative2 of string * string
    
    let private negative (s: Negative): string =
        match s with
            | Negative1 s        -> s
            | Negative2 (s1, s2) -> sprintf "\"%s\" \"%s\"" s1 s2
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type Affix =
        | String of string
        | Url of string
        
    type Prefix = Affix
    type Suffix = Affix
    
    let private affix (s: Affix): string =
        match s with
            | String s -> sprintf "'%s'" s
            | Url    u -> sprintf "url(%s)" u
        
    let private prefix p = affix p
    let private suffix s = affix s
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        | RangeValues      of int * int
        | RangeValueString of int * string
        | RangeStrings     of string * string
        interface IRange
        
    let private range (s: IRange): string =
        let stringifyRange (r: Range): string =
            match r with
                | RangeValues (v1, v2) -> sprintf "%i %i" v1 v2
                | RangeValueString (v, s) -> sprintf "%i %s" v s
                | RangeStrings (s1, s2) -> sprintf "%s %s" s1 s2
                
        match s with
            | :? Auto  as a -> GlobalValue.auto a
            | :? Range as r -> stringifyRange r
            | _ -> "unknown range value"
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type Pad =
        | Pad of int * char
    
    let private pad (s: Pad): string =
        match s with
            | Pad (i, c) -> sprintf "%i \"%c\"" i c
            
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        | Strings of string list
        | Urls of string list
        | Custom of string
        
    let private symbols (s: Symbols) =
        match s with
            | Strings sl ->
                sl
                |> List.map (fun s -> sprintf "\"%s\"" s)
                |> String.concat " "
            | Urls    ul ->
                ul
                |> List.map (fun u -> sprintf "url('%s')" u)
                |> String.concat " "
            | Custom  c  -> c
            
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    type AdditiveSymbol =
        | AdditiveSymbolString of int * string
        | AdditiveSymbolUrl of int * string
    
    let private additiveSymbol (s: AdditiveSymbol): string =
        match s with
            | AdditiveSymbolString (i, s) -> sprintf "%i \"%s\"" i s
            | AdditiveSymbolUrl    (i, u) -> sprintf "%i url(\"%s\")" i u
            
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        | Bullets
        | Numbers
        | Words
        | SpellOut
        | Custom of string
        interface ISpeakAs
        
    let private speakAs (s: ISpeakAs): string =
        let stringifySpeakAs (s: SpeakAs): string =
            match s with
                | Custom c -> c
                | _ -> duToKebab s
                
        match s with
            | :? Auto    as a -> GlobalValue.auto a
            | :? SpeakAs as s -> stringifySpeakAs s
            | _ -> "unknown speak as value"
            
    type CounterProperty =
        | System           of System
        | Negative         of Negative
        | Prefix           of Prefix
        | Suffix           of Suffix
        | Range            of IRange
        | Ranges           of IRange list
        | Pad              of Pad
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/fallback
        | Fallback         of string
        | Symbols          of Symbols
        | AdditiveSymbol   of AdditiveSymbol
        | AdditiveSymbols  of AdditiveSymbol list
        | SpeakAs          of ISpeakAs
        
    let createCounterStyleObject (counterName: string) (attributeList: CounterProperty list) =
        let innerStyle =
            attributeList
            |> List.map(
                           function
                               | System          s  -> "system"           ==> system s
                               | Negative        n  -> "negative"         ==> negative n
                               | Prefix          p  -> "prefix"           ==> prefix p
                               | Suffix          s  -> "suffix"           ==> suffix s
                               | Range           r  -> "range"            ==> range r
                               | Ranges          rs -> "range"            ==> combineComma range rs
                               | Pad             p  -> "pad"              ==> pad p
                               | Fallback        f  -> "fallback"         ==> f
                               | Symbols         s  -> "symbols"          ==> symbols s
                               | AdditiveSymbol  a  -> "additive-symbols" ==> additiveSymbol a
                               | AdditiveSymbols al -> "additive-symbols" ==> combineComma additiveSymbol al
                               | SpeakAs         s  -> "speak-as"         ==> speakAs s
                       )
        
        createObj
            [
                sprintf "@counter-style %s" counterName ==>
                    createObj innerStyle
            ]
        