namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss.Word
open Utils
open Fss

module Caret =
    let tests =
        testList "Caret"
            [
                test
                    "caret color rgb"
                    [ CaretColor.rgb 255 0 0 ]
                    ["caretColor" ==> "rgb(255, 0, 0)"]
                test
                    "caret color hsl"
                    [ CaretColor.hsl 255 0. 0. ]
                    ["caretColor" ==> "hsl(255, 0%, 0%)"]
                test
                    "caret color green"
                    [ CaretColor.green ]
                    ["caretColor" ==> "#008000"]
                test
                    "Caret Color Auto"
                    [CaretColor.auto]
                    ["caretColor" ==> "auto"]
            ]