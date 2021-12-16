namespace FSSTests

open Fet
open Utils
open Fss

module Caret =
    let tests =
        testList "Caret"
            [
                testCase
                    "caret color rgb"
                    [ CaretColor.rgb 255 0 0 ]
                    "caret-color: rgb(255, 0, 0);"
                testCase
                    "caret color hsl"
                    [ CaretColor.hsl 255 0 0 ]
                    "caret-color: hsl(255, 0%, 0%);"
                testCase
                    "caret color green"
                    [ CaretColor.green ]
                    "caret-color: green;"
                testCase
                    "Caret Color Auto"
                    [CaretColor.auto]
                    "caret-color: auto;"
            ]