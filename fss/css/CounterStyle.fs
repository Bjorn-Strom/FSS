namespace Fss

open Fss.FssTypes

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
    let Fallback = Counter.CounterClasses.FallbackClass()

    /// Resets a given counter to a given value
    let CounterReset =
        Counter.CounterClasses.CounterReset(Property.CounterReset)
    /// Sets a given counter to a given value
    let CounterSet =
        Counter.CounterClasses.CounterSet(Property.CounterSet)
    /// Increases or decreases the value of a counter
    let CounterIncrement =
        Counter.CounterClasses.CounterIncrement(Property.CounterIncrement)
