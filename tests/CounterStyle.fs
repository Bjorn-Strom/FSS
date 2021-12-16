namespace FSSTests

open Fet
open Utils
open Fss

module Counter =
    let tests =
        testList "Counter"
            [
                testCounterCase 
                    "System Cyclic"
                    [System.cyclic]
                    "system: cyclic;"
                testCounterCase 
                    "System Numeric"
                    [System.numeric]
                    "system: numeric;"
                testCounterCase 
                    "System Alphabetic"
                    [System.alphabetic]
                    "system: alphabetic;"
                testCounterCase 
                    "System Symbolic"
                    [System.symbolic]
                    "system: symbolic;"
                testCounterCase 
                    "System Additive"
                    [System.additive]
                    "system: additive;"
                testCounterCase 
                    "System Fixed"
                    [System.fixed']
                    "system: fixed;"
                testCounterCase 
                    "System Fixed value"
                    [System.fixedValue 4]
                    "system: fixed 4;"
                testCounterCase 
                    "System extends"
                    [System.extends "foo"]
                    "system: extends foo;"
                testCounterCase 
                    "Negative one"
                    [Negative.value "-"]
                    "negative: \"-\";"
                testCounterCase 
                    "Negative two"
                    [Negative.value ("(", ")")]
                    "negative: \"(\" \")\";"
                testCounterCase
                    "prefix value"
                    [Prefix.value ">>"]
                    "prefix: \">>\";"
                testCounterCase
                    "prefix value"
                    [Prefix.value "Page " ]
                    "prefix: \"Page \";"
                testCounterCase
                    "prefix value"
                    [Prefix.url "bullet.png" ]
                    "prefix: url(bullet.png);"
                testCounterCase
                    "suffix value"
                    [Suffix.value ">>"]
                    "suffix: \">>\";"
                testCounterCase
                    "suffix value"
                    [Suffix.value "Page " ]
                    "suffix: \"Page \";"
                testCounterCase
                    "suffix value"
                    [Suffix.url "bullet.png" ]
                    "suffix: url(bullet.png);"
                testCounterCase
                    "range auto"
                    [Range.auto ]
                    "range: auto;"
                testCounterCase
                    "range values"
                    [Range.value (2, 5) ]
                    "range: 2 5;"
                testCounterCase
                    "range values"
                    [Range.value [Fss.FssTypes.Counter.Infinite, Fss.FssTypes.Counter.Range' 5] ]
                    "range: infinite 5;"
                testCounterCase
                    "range values"
                    [Range.value [Fss.FssTypes.Counter.Range' 2, Fss.FssTypes.Counter.Range' 5; Fss.FssTypes.Counter.Range' 8, Fss.FssTypes.Counter.Range' 10] ]
                    "range: 2 5, 8 10;"
                testCounterCase
                    "range values"
                    [Range.value [Fss.FssTypes.Counter.Infinite, Fss.FssTypes.Counter.Range' 6; Fss.FssTypes.Counter.Range' 10, Fss.FssTypes.Counter.Infinite] ]
                    "range: infinite 6, 10 infinite;"
                testCounterCase
                    "pad value"
                    [Pad.value (3, "0") ]
                    "pad: 3 \"0\";"
                testCounterCase
                    "symbols string"
                    [Symbols.value "A B C D E" ]
                    "symbols: A B C D E;"
                testCounterCase
                    "symbols string"
                    [Symbols.value "some-numbers" ]
                    "symbols: some-numbers;"
                testCounterCase
                    "symbols string list"
                    [Symbols.value [ "0"; "1"; "2"; "4"; "5"; "6"; "7"; "8"; "9" ] ]
                    "symbols: \"0\" \"1\" \"2\" \"4\" \"5\" \"6\" \"7\" \"8\" \"9\";"
                testCounterCase
                    "symbols image list"
                    [Symbols.value [ Fss.FssTypes.Image.Image.Url "first.svg"; Fss.FssTypes.Image.Image.Url "second.svg"; Fss.FssTypes.Image.Image.Url "third.svg"  ] ]
                    "symbols: url(first.svg) url(second.svg) url(third.svg);"
                testCounterCase
                    "speak-as auto"
                    [ SpeakAs.auto ]
                    "speak-as: auto;"
                testCounterCase
                    "speak-as bullets"
                    [ SpeakAs.bullets ]
                    "speak-as: bullets;"
                testCounterCase
                    "speak-as numbers"
                    [ SpeakAs.numbers ]
                    "speak-as: numbers;"
                testCounterCase
                    "speak-as words"
                    [ SpeakAs.words ]
                    "speak-as: words;"
                testCounterCase
                    "speak-as spell out"
                    [ SpeakAs.spellOut ]
                    "speak-as: spell-out;"
                testCounterCase
                    "speak-as value"
                    [ SpeakAs.value "foo" ]
                    "speak-as: foo;"
                    
            ]