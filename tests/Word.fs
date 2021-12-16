namespace FSSTests

open Fet
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
                    "word-spacing: normal;"
                testCase
                    "Word spacing px"
                    [WordSpacing.value (px 3 )]
                    "word-spacing: 3px;"
                testCase
                    "Word Spacing em"
                    [WordSpacing.value (em 0.3)]
                    "word-spacing: 0.3em;"
                testCase
                    "Word Spacing pct"
                    [WordSpacing.value (pct 50)]
                    "word-spacing: 50%;"
                testCase
                    "Word spacing inherit"
                    [WordSpacing.inherit']
                    "word-spacing: inherit;"
                testCase
                    "Word spacing initial"
                    [WordSpacing.initial]
                    "word-spacing: initial;"
                testCase
                    "Word spacing unset"
                    [WordSpacing.unset]
                    "word-spacing: unset;"
                testCase
                    "Word spacing revert"
                    [WordSpacing.revert]
                    "word-spacing: revert;"
                testCase
                    "Word break word break"
                    [WordBreak.wordBreak]
                    "word-break: word-break;"
                testCase
                    "Word Spacing break all"
                    [WordBreak.breakAll]
                    "word-break: break-all;"
                testCase
                    "Word Spacing keep all"
                    [WordBreak.keepAll]
                    "word-break: keep-all;"
                testCase
                    "Word break normal"
                    [WordBreak.normal]
                    "word-break: normal;"
                testCase
                    "Word break inherit"
                    [WordBreak.inherit']
                    "word-break: inherit;"
                testCase
                    "Word break initial"
                    [WordBreak.initial]
                    "word-break: initial;"
                testCase
                    "Word break unset"
                    [WordBreak.unset]
                    "word-break: unset;"
                testCase
                    "Word break revert"
                    [WordBreak.revert]
                    "word-break: revert;"
            ]