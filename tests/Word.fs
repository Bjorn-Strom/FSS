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
                    [WordSpacing.normal]
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
                    [WordSpacing' FssTypes.Inherit]
                    ["wordSpacing" ==> "inherit"]
                test
                    "Word spacing inherit"
                    [WordSpacing.inherit']
                    ["wordSpacing" ==> "inherit"]
                test
                    "Word spacing initial"
                    [WordSpacing.initial]
                    ["wordSpacing" ==> "initial"]
                test
                    "Word spacing unset"
                    [WordSpacing.unset]
                    ["wordSpacing" ==> "unset"]
                test
                    "Word break word break"
                    [WordBreak.wordBreak]
                    ["wordBreak" ==> "word-break"]
                test
                    "Word Spacing break all"
                    [WordBreak.breakAll]
                    ["wordBreak" ==> "break-all"]
                test
                    "Word break normal"
                    [WordBreak.normal]
                    ["wordBreak" ==> "normal"]
                test
                    "Word Spacing inherit value"
                    [WordBreak' FssTypes.Inherit]
                    ["wordBreak" ==> "inherit"]
                test
                    "Word break inherit"
                    [WordBreak.inherit']
                    ["wordBreak" ==> "inherit"]
                test
                    "Word break initial"
                    [WordBreak.initial]
                    ["wordBreak" ==> "initial"]
                test
                    "Word break unset"
                    [WordBreak.unset]
                    ["wordBreak" ==> "unset"]
            ]