namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Caret =
    let tests =
        testList "Caret"
            [
                testCase
                    "caret color rgb"
                    [ CaretColor.rgb 255 0 0 ]
                    ["caretColor" ==> "rgb(255, 0, 0)"]
                testCase
                    "caret color hsl"
                    [ CaretColor.hsl 255 0. 0. ]
                    ["caretColor" ==> "hsl(255, 0%, 0%)"]
                testCase
                    "caret color green"
                    [ CaretColor.green ]
                    ["caretColor" ==> "#008000"]
                testCase
                    "Caret Color Auto"
                    [CaretColor.auto]
                    ["caretColor" ==> "auto"]
            ]