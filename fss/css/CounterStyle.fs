namespace Fss

open Fss.FssTypes

// TODO:
// COunter reset
// COunter increment
// De tinga

[<AutoOpen>]
module Counter =
    let System = Counter.CounterClasses.SystemClass()
    let Negative = Counter.CounterClasses.NegativeClass()

    let Prefix =
        Counter.CounterClasses.FixClass(CounterProperty.Prefix)

    let Suffix =
        Counter.CounterClasses.FixClass(CounterProperty.Suffix)

    let Range = Counter.CounterClasses.RangeClass()
    let Pad = Counter.CounterClasses.PadClass()
    let Symbols = Counter.CounterClasses.SymbolsClass()

    let AdditiveSymbols =
        Counter.CounterClasses.AdditiveSymbolsClass()

    let SpeakAs = Counter.CounterClasses.SpeakAsClass()
