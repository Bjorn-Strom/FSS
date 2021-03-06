namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Counter =
    let sampleCounterStyle =
        counterStyle
            [
                Counter.System.Alphabetic
            ]

    let tests =
        testList "Counter"
            [
                test
                    "CounterReset reset"
                    [ CounterReset.Reset sampleCounterStyle]
                    [ "counterReset" ==> (counterValue sampleCounterStyle) ]
                test
                    "CounterReset reset to"
                    [ CounterReset.ResetTo sampleCounterStyle 5]
                    [ "counterReset" ==> sprintf "%s 5" (counterValue sampleCounterStyle) ]
                test
                    "CounterReset none"
                    [ CounterReset.None]
                    [ "counterReset" ==> "none" ]
                test
                    "CounterReset inherit"
                    [ CounterReset.Inherit]
                    [ "counterReset" ==> "inherit" ]
                test
                    "CounterReset initial"
                    [ CounterReset.Initial]
                    [ "counterReset" ==> "initial" ]
                test
                    "CounterReset unset"
                    [ CounterReset.Unset ]
                    [ "counterReset" ==> "unset" ]
                test
                    "CounterIncrement increment"
                    [ CounterIncrement.Increment sampleCounterStyle]
                    [ "counterIncrement" ==> (counterValue sampleCounterStyle) ]
                test
                    "CounterIncrement increment to"
                    [ CounterIncrement.IncrementTo sampleCounterStyle 5]
                    [ "counterIncrement" ==> sprintf "%s 5"(counterValue sampleCounterStyle)]
                test
                    "CounterIncrement none"
                    [ CounterIncrement.None]
                    [ "counterIncrement" ==> "none" ]
                test
                    "CounterIncrement inherit"
                    [ CounterIncrement.Inherit]
                    [ "counterIncrement" ==> "inherit" ]
                test
                    "CounterIncrement initial"
                    [ CounterIncrement.Initial]
                    [ "counterIncrement" ==> "initial" ]
                test
                    "CounterIncrement unset"
                    [ CounterIncrement.Unset ]
                    [ "counterIncrement" ==> "unset" ]
            ]