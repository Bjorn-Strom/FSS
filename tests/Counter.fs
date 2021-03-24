namespace FSSTests

open Fable.Mocha
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
                test
                    "CounterReset reset"
                    [ CounterReset.reset sampleCounterStyle]
                    [ "counterReset" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                test
                    "CounterReset reset to"
                    [ CounterReset.resetTo sampleCounterStyle 5]
                    [ "counterReset" ==> sprintf "%s 5" (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                test
                    "CounterReset none"
                    [ CounterReset.none]
                    [ "counterReset" ==> "none" ]
                test
                    "CounterReset inherit"
                    [ CounterReset.inherit']
                    [ "counterReset" ==> "inherit" ]
                test
                    "CounterReset initial"
                    [ CounterReset.initial]
                    [ "counterReset" ==> "initial" ]
                test
                    "CounterReset unset"
                    [ CounterReset.unset ]
                    [ "counterReset" ==> "unset" ]
                test
                    "CounterIncrement increment"
                    [ CounterIncrement.increment sampleCounterStyle]
                    [ "counterIncrement" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                test
                    "CounterIncrement increment to"
                    [ CounterIncrement.incrementTo sampleCounterStyle 5]
                    [ "counterIncrement" ==> sprintf "%s 5"(FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle)]
                test
                    "CounterIncrement none"
                    [ CounterIncrement.none]
                    [ "counterIncrement" ==> "none" ]
                test
                    "CounterIncrement inherit"
                    [ CounterIncrement.inherit']
                    [ "counterIncrement" ==> "inherit" ]
                test
                    "CounterIncrement initial"
                    [ CounterIncrement.initial]
                    [ "counterIncrement" ==> "initial" ]
                test
                    "CounterIncrement unset"
                    [ CounterIncrement.unset ]
                    [ "counterIncrement" ==> "unset" ]
            ]