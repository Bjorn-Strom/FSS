namespace FSSTests

open Fet
open Utils
open Fss

module AspectRatioTests =
     let tests =
        testList "AspectRatio"
            [
                testCase
                    "AspectRatio"
                    [ AspectRatio.value(9) ]
                    "{aspect-ratio:9;}"
                testCase
                    "AspectRatio"
                    [ AspectRatio.value(16, 9) ]
                    "{aspect-ratio:16/9;}"
                testCase
                    "AspectRatio inherit"
                    [ AspectRatio.inherit']
                    "{aspect-ratio:inherit;}"
                testCase
                    "AspectRatio initial"
                    [ AspectRatio.initial]
                    "{aspect-ratio:initial;}"
                testCase
                    "AspectRatio unset"
                    [ AspectRatio.unset ]
                    "{aspect-ratio:unset;}"
                testCase
                    "AspectRatio revert"
                    [ AspectRatio.revert ]
                    "{aspect-ratio:revert;}"
            ]
