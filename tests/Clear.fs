namespace FSSTests

open Fet
open Utils
open Fss

module Clear =
     let tests =
        testList "Clear"
            [
                testCase
                    "Clear none"
                    [ Clear.none]
                    "clear: none;"
                testCase
                    "Clear inherit"
                    [ Clear.inherit']
                    "clear: inherit;"
                testCase
                    "Clear initial"
                    [ Clear.initial]
                    "clear: initial;"
                testCase
                    "Clear unset"
                    [ Clear.unset ]
                    "clear: unset;"
                testCase
                    "Clear revert"
                    [ Clear.revert ]
                    "clear: revert;"
                testCase
                    "Clear left"
                    [ Clear.left ]
                    "clear: left;"
                testCase
                    "Clear right"
                    [ Clear.right ]
                    "clear: right;"
                testCase
                    "Clear both"
                    [ Clear.both ]
                    "clear: both;"
                testCase
                    "Clear inlineStart"
                    [ Clear.inlineStart ]
                    "clear: inline-start;"
                testCase
                    "Clear inlineEnd"
                    [ Clear.inlineEnd ]
                    "clear: inline-end;"
            ]