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
                    [ CaretColor.Rgb 255 0 0 ]
                    ["caretColor" ==> "rgb(255, 0, 0)"]
                test
                    "caret color hsl"
                    [ CaretColor.Hsl 255 0. 0. ]
                    ["caretColor" ==> "hsl(255, 0%, 0%)"]
                test
                    "caret color green"
                    [ CaretColor.green ]
                    ["caretColor" ==> "#008000"]
                test
                    "Caret Color Auto"
                    [CaretColor.Auto]
                    ["caretColor" ==> "auto"]
            ]