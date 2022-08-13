namespace FSSTests

open Fet
open Utils
open Fss

module CounterTests =
    let tests =
        testList "Counter"
            [
                testCounterCase
                    "System Cyclic"
                    [System.cyclic]
                    "{system:cyclic;}"
                testCounterCase
                    "System Numeric"
                    [System.numeric]
                    "{system:numeric;}"
                testCounterCase
                    "System Alphabetic"
                    [System.alphabetic]
                    "{system:alphabetic;}"
                testCounterCase
                    "System Symbolic"
                    [System.symbolic]
                    "{system:symbolic;}"
                testCounterCase
                    "System Additive"
                    [System.additive]
                    "{system:additive;}"
                testCounterCase
                    "System Fixed"
                    [System.fixed']
                    "{system:fixed;}"
                testCounterCase
                    "System Fixed value"
                    [System.fixedValue 4]
                    "{system:fixed 4;}"
                testCounterCase
                    "System extends"
                    [System.extends "foo"]
                    "{system:extends foo;}"
                testCounterCase
                    "Negative one"
                    [Negative.value "-"]
                    "{negative:\"-\";}"
                testCounterCase
                    "Negative two"
                    [Negative.value ("(", ")")]
                    "{negative:\"(\" \")\";}"
                testCounterCase
                    "prefix value"
                    [Prefix.value ">>"]
                    "{prefix:\">>\";}"
                testCounterCase
                    "prefix value"
                    [Prefix.value "Page " ]
                    "{prefix:\"Page \";}"
                testCounterCase
                    "prefix value"
                    [Prefix.url "bullet.png" ]
                    "{prefix:url(bullet.png);}"
                testCounterCase
                    "suffix value"
                    [Suffix.value ">>"]
                    "{suffix:\">>\";}"
                testCounterCase
                    "suffix value"
                    [Suffix.value "Page " ]
                    "{suffix:\"Page \";}"
                testCounterCase
                    "suffix value"
                    [Suffix.url "bullet.png" ]
                    "{suffix:url(bullet.png);}"
                testCounterCase
                    "range auto"
                    [Range.auto ]
                    "{range:auto;}"
                testCounterCase
                    "range values"
                    [Range.value (2, 5) ]
                    "{range:2 5;}"
                testCounterCase
                    "range values"
                    [Range.value [Fss.Types.Counter.Infinite, Fss.Types.Counter.Range' 5] ]
                    "{range:infinite 5;}"
                testCounterCase
                    "range values"
                    [Range.value [Fss.Types.Counter.Range' 2, Fss.Types.Counter.Range' 5; Fss.Types.Counter.Range' 8, Fss.Types.Counter.Range' 10] ]
                    "{range:2 5,8 10;}"
                testCounterCase
                    "range values"
                    [Range.value [Fss.Types.Counter.Infinite, Fss.Types.Counter.Range' 6; Fss.Types.Counter.Range' 10, Fss.Types.Counter.Infinite] ]
                    "{range:infinite 6,10 infinite;}"
                testCounterCase
                    "pad value"
                    [Pad.value (3, "0") ]
                    "{pad:3 \"0\";}"
                testCounterCase
                    "symbols string"
                    [Symbols.value "A B C D E" ]
                    "{symbols:A B C D E;}"
                testCounterCase
                    "symbols string"
                    [Symbols.value "some-numbers" ]
                    "{symbols:some-numbers;}"
                testCounterCase
                    "symbols string list"
                    [Symbols.value [ "0"; "1"; "2"; "4"; "5"; "6"; "7"; "8"; "9" ] ]
                    "{symbols:\"0\" \"1\" \"2\" \"4\" \"5\" \"6\" \"7\" \"8\" \"9\";}"
                testCounterCase
                    "symbols image list"
                    [Symbols.value [ Fss.Types.Image.Image.Url "first.svg"; Fss.Types.Image.Image.Url "second.svg"; Fss.Types.Image.Image.Url "third.svg"  ] ]
                    "{symbols:url(first.svg) url(second.svg) url(third.svg);}"
                testCounterCase
                    "speak-as auto"
                    [ SpeakAs.auto ]
                    "{speak-as:auto;}"
                testCounterCase
                    "speak-as bullets"
                    [ SpeakAs.bullets ]
                    "{speak-as:bullets;}"
                testCounterCase
                    "speak-as numbers"
                    [ SpeakAs.numbers ]
                    "{speak-as:numbers;}"
                testCounterCase
                    "speak-as words"
                    [ SpeakAs.words ]
                    "{speak-as:words;}"
                testCounterCase
                    "speak-as spell out"
                    [ SpeakAs.spellOut ]
                    "{speak-as:spell-out;}"
                testCounterCase
                    "speak-as value"
                    [ SpeakAs.value "foo" ]
                    "{speak-as:foo;}"
                testCounterCase
                    "fallback lower alpha"
                    [ Fallback.lowerAlpha ]
                    "{fallback:lower-alpha;}"
                testCounterCase
                    "fallback custom gangnam style"
                    [ Fallback.customGangnamStyle ]
                    "{fallback:custom-gangnam-style;}"
                testCase
                    "Counter reset counter"
                    [ CounterReset.value "my-counter" ]
                    "{counter-reset:my-counter;}"
                testCase
                    "Counter reset counter value"
                    [ CounterReset.value("my-counter", -3) ]
                    "{counter-reset:my-counter -3;}"
                testCase
                    "Counter reset counter"
                    [ CounterReset.reversed "my-counter" ]
                    "{counter-reset:reversed(my-counter);}"
                testCase
                    "Counter reset counter value"
                    [ CounterReset.reversed("my-counter", -3) ]
                    "{counter-reset:reversed(my-counter) -3;}"
                testCase
                    "Counter reset none"
                    [ CounterReset.none ]
                    "{counter-reset:none;}"
                testCase
                    "Counter reset inherit"
                    [ CounterReset.inherit' ]
                    "{counter-reset:inherit;}"
                testCase
                    "Counter reset initial"
                    [ CounterReset.initial ]
                    "{counter-reset:initial;}"
                testCase
                    "Counter reset unset"
                    [ CounterReset.unset ]
                    "{counter-reset:unset;}"
                testCase
                    "Counter reset revert"
                    [ CounterReset.revert ]
                    "{counter-reset:revert;}"
                testCase
                    "Counter set counter"
                    [ CounterSet.value "my-counter" ]
                    "{counter-set:my-counter;}"
                testCase
                    "Counter set counter value"
                    [ CounterSet.value("my-counter", -3) ]
                    "{counter-set:my-counter -3;}"
                testCase
                    "Counter set none"
                    [ CounterSet.none ]
                    "{counter-set:none;}"
                testCase
                    "Counter set inherit"
                    [ CounterSet.inherit' ]
                    "{counter-set:inherit;}"
                testCase
                    "Counter set initial"
                    [ CounterSet.initial ]
                    "{counter-set:initial;}"
                testCase
                    "Counter set unset"
                    [ CounterSet.unset ]
                    "{counter-set:unset;}"
                testCase
                    "Counter set revert"
                    [ CounterSet.revert ]
                    "{counter-set:revert;}"
                testCase
                    "Counter increment counter"
                    [ CounterIncrement.value "my-counter" ]
                    "{counter-increment:my-counter;}"
                testCase
                    "Counter increment counter value"
                    [ CounterIncrement.value("my-counter", -3) ]
                    "{counter-increment:my-counter -3;}"
                testCase
                    "Counter increment none"
                    [ CounterIncrement.none ]
                    "{counter-increment:none;}"
                testCase
                    "Counter increment inherit"
                    [ CounterIncrement.inherit' ]
                    "{counter-increment:inherit;}"
                testCase
                    "Counter increment initial"
                    [ CounterIncrement.initial ]
                    "{counter-increment:initial;}"
                testCase
                    "Counter increment unset"
                    [ CounterIncrement.unset ]
                    "{counter-increment:unset;}"
                testCase
                    "Counter increment revert"
                    [ CounterIncrement.revert ]
                    "{counter-increment:revert;}"
            ]
