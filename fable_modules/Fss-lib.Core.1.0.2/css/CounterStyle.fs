﻿namespace Fss

open Fss.Types

[<AutoOpen>]
module Counter =
    let System = CounterClasses.SystemClass()
    let Negative = CounterClasses.NegativeClass()

    let Prefix =
        CounterClasses.FixClass(Property.CounterProperty.Prefix)

    let Suffix =
        CounterClasses.FixClass(Property.CounterProperty.Suffix)

    let Range = CounterClasses.RangeClass()
    let Pad = CounterClasses.PadClass()
    let Symbols = CounterClasses.SymbolsClass()

    let AdditiveSymbols =
        CounterClasses.AdditiveSymbolsClass()

    let SpeakAs = CounterClasses.SpeakAsClass()
    let Fallback = CounterClasses.FallbackClass()

    /// Resets a given counter to a given value
    let CounterReset =
        CounterClasses.CounterReset(Property.CounterReset)
    /// Sets a given counter to a given value
    let CounterSet =
        CounterClasses.CounterSet(Property.CounterSet)
    /// Increases or decreases the value of a counter
    let CounterIncrement =
        CounterClasses.CounterIncrement(Property.CounterIncrement)
    /// Gives label to generated CSS string.
    let CounterLabel (label: string) =
        (Property.CounterProperty.NameLabel, NameLabel.NameLabel(label.Replace(" ", "")))
        |> CounterRule
