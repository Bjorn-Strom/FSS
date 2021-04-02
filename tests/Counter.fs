namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Counter =
    let sampleCounterStyle =
        counterStyle
            [
                Counter.System.alphabetic
            ]

    let tests =
        testList "Counter"
            [
                testCase
                    "CounterReset reset"
                    [ CounterReset.reset sampleCounterStyle]
                    [ "counterReset" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                testCase
                    "CounterReset reset to"
                    [ CounterReset.resetTo sampleCounterStyle 5]
                    [ "counterReset" ==> sprintf "%s 5" (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                testCase
                    "CounterReset none"
                    [ CounterReset.none]
                    [ "counterReset" ==> "none" ]
                testCase
                    "CounterReset inherit"
                    [ CounterReset.inherit']
                    [ "counterReset" ==> "inherit" ]
                testCase
                    "CounterReset initial"
                    [ CounterReset.initial]
                    [ "counterReset" ==> "initial" ]
                testCase
                    "CounterReset unset"
                    [ CounterReset.unset ]
                    [ "counterReset" ==> "unset" ]
                testCase
                    "CounterIncrement increment"
                    [ CounterIncrement.increment sampleCounterStyle]
                    [ "counterIncrement" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                testCase
                    "CounterIncrement increment to"
                    [ CounterIncrement.incrementTo sampleCounterStyle 5]
                    [ "counterIncrement" ==> sprintf "%s 5"(FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle)]
                testCase
                    "CounterIncrement none"
                    [ CounterIncrement.none]
                    [ "counterIncrement" ==> "none" ]
                testCase
                    "CounterIncrement inherit"
                    [ CounterIncrement.inherit']
                    [ "counterIncrement" ==> "inherit" ]
                testCase
                    "CounterIncrement initial"
                    [ CounterIncrement.initial]
                    [ "counterIncrement" ==> "initial" ]
                testCase
                    "CounterIncrement unset"
                    [ CounterIncrement.unset ]
                    [ "counterIncrement" ==> "unset" ]
            ]