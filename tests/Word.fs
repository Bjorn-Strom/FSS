namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss.Word
open Utils
open Fss

module Word =
    let tests =
        testList "Word"
            [
                test
                    "Word spacing normal"
                    [WordSpacing.Normal]
                    ["wordSpacing" ==> "normal"]
                test
                    "Word spacing px"
                    [WordSpacing' (px 3 )]
                    ["wordSpacing" ==> "3px"]
                test
                    "Word Spacing em"
                    [WordSpacing' (em 0.3)]
                    ["wordSpacing" ==> "0.3em"]
                test
                    "Word Spacing pct"
                    [WordSpacing' (pct 50)]
                    ["wordSpacing" ==> "50%"]
                test
                    "Word Spacing inherit value"
                    [WordSpacing' Inherit]
                    ["wordSpacing" ==> "inherit"]
                test
                    "Word spacing inherit"
                    [WordSpacing.Inherit]
                    ["wordSpacing" ==> "inherit"]
                    // inherit;
                test
                    "Word spacing initial"
                    [WordSpacing.Initial]
                    ["wordSpacing" ==> "initial"]
                    // initial;
                test
                    "Word spacing unset"
                    [WordSpacing.Unset]
                    ["wordSpacing" ==> "unset"]
                    // unset;
            ]