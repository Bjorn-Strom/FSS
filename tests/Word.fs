namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Fss.Word
open Utils
open Fss

module Word =
    let tests =
        testList "Word"
            [
                testCase
                    "Word spacing normal"
                    [WordSpacing.normal]
                    ["wordSpacing" ==> "normal"]
                testCase
                    "Word spacing px"
                    [WordSpacing' (px 3 )]
                    ["wordSpacing" ==> "3px"]
                testCase
                    "Word Spacing em"
                    [WordSpacing' (em 0.3)]
                    ["wordSpacing" ==> "0.3em"]
                testCase
                    "Word Spacing pct"
                    [WordSpacing' (pct 50)]
                    ["wordSpacing" ==> "50%"]
                testCase
                    "Word Spacing inherit value"
                    [WordSpacing' FssTypes.Inherit]
                    ["wordSpacing" ==> "inherit"]
                testCase
                    "Word spacing inherit"
                    [WordSpacing.inherit']
                    ["wordSpacing" ==> "inherit"]
                testCase
                    "Word spacing initial"
                    [WordSpacing.initial]
                    ["wordSpacing" ==> "initial"]
                testCase
                    "Word spacing unset"
                    [WordSpacing.unset]
                    ["wordSpacing" ==> "unset"]
                testCase
                    "Word break word break"
                    [WordBreak.wordBreak]
                    ["wordBreak" ==> "word-break"]
                testCase
                    "Word Spacing break all"
                    [WordBreak.breakAll]
                    ["wordBreak" ==> "break-all"]
                testCase
                    "Word break normal"
                    [WordBreak.normal]
                    ["wordBreak" ==> "normal"]
                testCase
                    "Word Spacing inherit value"
                    [WordBreak' FssTypes.Inherit]
                    ["wordBreak" ==> "inherit"]
                testCase
                    "Word break inherit"
                    [WordBreak.inherit']
                    ["wordBreak" ==> "inherit"]
                testCase
                    "Word break initial"
                    [WordBreak.initial]
                    ["wordBreak" ==> "initial"]
                testCase
                    "Word break unset"
                    [WordBreak.unset]
                    ["wordBreak" ==> "unset"]
            ]