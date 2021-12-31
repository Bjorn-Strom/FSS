namespace FSSTests

open Fet
open Utils
open Fss

module Margin =
    let tests =
        testList "Margin"
            [
                testCase
                    "Margin top px"
                    [ MarginTop.value (px 10)]
                    "{ margin-top: 10px; }"
                testCase
                    "Margin top pct"
                    [ MarginTop.value (pct 10)]
                    "{ margin-top: 10%; }"
                testCase
                    "Margin top inherit"
                    [ MarginTop.inherit' ]
                    "{ margin-top: inherit; }"
                testCase
                    "Margin top initial"
                    [ MarginTop.initial ]
                    "{ margin-top: initial; }"
                testCase
                    "Margin top unset"
                    [ MarginTop.unset ]
                    "{ margin-top: unset; }"
                testCase
                    "Margin top revert"
                    [ MarginTop.revert ]
                    "{ margin-top: revert; }"
                testCase
                    "Margin right px"
                    [ MarginRight.value (px 10)]
                    "{ margin-right: 10px; }"
                testCase
                    "Margin right pct"
                    [ MarginRight.value (pct 10)]
                    "{ margin-right: 10%; }"
                testCase
                    "Margin right inherit"
                    [ MarginRight.inherit' ]
                    "{ margin-right: inherit; }"
                testCase
                    "Margin right initial"
                    [ MarginRight.initial ]
                    "{ margin-right: initial; }"
                testCase
                    "Margin right unset"
                    [ MarginRight.unset ]
                    "{ margin-right: unset; }"
                testCase
                    "Margin right revert"
                    [ MarginRight.revert ]
                    "{ margin-right: revert; }"
                testCase
                    "Margin bottom px"
                    [ MarginBottom.value (px 10)]
                    "{ margin-bottom: 10px; }"
                testCase
                    "Margin bottom pct"
                    [ MarginBottom.value (pct 10)]
                    "{ margin-bottom: 10%; }"
                testCase
                    "Margin bottom inherit"
                    [ MarginBottom.inherit' ]
                    "{ margin-bottom: inherit; }"
                testCase
                    "Margin bottom initial"
                    [ MarginBottom.initial ]
                    "{ margin-bottom: initial; }"
                testCase
                    "Margin bottom unset"
                    [ MarginBottom.unset ]
                    "{ margin-bottom: unset; }"
                testCase
                    "Margin bottom revert"
                    [ MarginBottom.revert ]
                    "{ margin-bottom: revert; }"
                testCase
                    "Margin left px"
                    [ MarginLeft.value (px 10)]
                    "{ margin-left: 10px; }"
                testCase
                    "Margin left pct"
                    [ MarginLeft.value (pct 10)]
                    "{ margin-left: 10%; }"
                testCase
                    "Margin left inherit"
                    [ MarginLeft.inherit' ]
                    "{ margin-left: inherit; }"
                testCase
                    "Margin left initial"
                    [ MarginLeft.initial ]
                    "{ margin-left: initial; }"
                testCase
                    "Margin left unset"
                    [ MarginLeft.unset ]
                    "{ margin-left: unset; }"
                testCase
                    "Margin left revert"
                    [ MarginLeft.revert ]
                    "{ margin-left: revert; }"
                testCase
                    "Margin px"
                    [ Margin.value (px 10)]
                    "{ margin: 10px; }"
                testCase
                    "Margin pct"
                    [ Margin.value (pct 10)]
                    "{ margin: 10%; }"
                testCase
                    "Margin em"
                    [ Margin.value (em 10.0)]
                    "{ margin: 10em; }"
                testCase
                    "Margin auto"
                    [ Margin.auto]
                    "{ margin: auto; }"
                testCase
                    "Margin inherit"
                    [ Margin.inherit']
                    "{ margin: inherit; }"
                testCase
                    "Margin initial"
                    [ Margin.initial]
                    "{ margin: initial; }"
                testCase
                    "Margin unset"
                    [ Margin.unset ]
                    "{ margin: unset; }"
                testCase
                    "Margin revert"
                    [ Margin.revert ]
                    "{ margin: revert; }"
                testCase
                    "Margins multiple"
                    [ Margin.value (px 10, px 20, px 30, px 40) ]
                    "{ margin: 10px 20px 30px 40px; }"
                testCase
                    "Margin inline start 5%"
                    [ MarginInlineStart.value (pct 5)]
                    "{ margin-inline-start: 5%; }"
                testCase
                    "Margin inline start 1em"
                    [ MarginInlineStart.value (em 1)]
                    "{ margin-inline-start: 1em; }"
                testCase
                    "Margin inline start 10px"
                    [ MarginInlineStart.value (px 10)]
                    "{ margin-inline-start: 10px; }"
                testCase
                    "Margin inline start initial"
                    [ MarginInlineStart.initial]
                    "{ margin-inline-start: initial; }"
                testCase
                    "Margin inline start unset"
                    [ MarginInlineStart.unset ]
                    "{ margin-inline-start: unset; }"
                testCase
                    "Margin inline start inherit"
                    [ MarginInlineStart.inherit']
                    "{ margin-inline-start: inherit; }"
                testCase
                    "Margin inline start initial"
                    [ MarginInlineStart.initial]
                    "{ margin-inline-start: initial; }"
                testCase
                    "Margin inline start unset"
                    [ MarginInlineStart.unset ]
                    "{ margin-inline-start: unset; }"
                testCase
                    "Margin inline start revert"
                    [ MarginInlineStart.revert ]
                    "{ margin-inline-start: revert; }"
                testCase
                    "Margin inline end 5%"
                    [ MarginInlineEnd.value (pct 5)]
                    "{ margin-inline-end: 5%; }"
                testCase
                    "Margin inline end 1em"
                    [ MarginInlineEnd.value (em 1)]
                    "{ margin-inline-end: 1em; }"
                testCase
                    "Margin inline end 10px"
                    [ MarginInlineEnd.value (px 10)]
                    "{ margin-inline-end: 10px; }"
                testCase
                    "Margin inline end initial"
                    [ MarginInlineEnd.initial]
                    "{ margin-inline-end: initial; }"
                testCase
                    "Margin inline end unset"
                    [ MarginInlineEnd.unset ]
                    "{ margin-inline-end: unset; }"
                testCase
                    "Margin inline end inherit"
                    [ MarginInlineEnd.inherit']
                    "{ margin-inline-end: inherit; }"
                testCase
                    "Margin inline end revert"
                    [ MarginInlineEnd.revert]
                    "{ margin-inline-end: revert; }"
                testCase
                    "Margin block start 5%"
                    [ MarginBlockStart.value (pct 5)]
                    "{ margin-block-start: 5%; }"
                testCase
                    "Margin block start 1em"
                    [ MarginBlockStart.value (em 1)]
                    "{ margin-block-start: 1em; }"
                testCase
                    "Margin block start 10px"
                    [ MarginBlockStart.value (px 10)]
                    "{ margin-block-start: 10px; }"
                testCase
                    "Margin block start initial"
                    [ MarginBlockStart.initial]
                    "{ margin-block-start: initial; }"
                testCase
                    "Margin block start unset"
                    [ MarginBlockStart.unset ]
                    "{ margin-block-start: unset; }"
                testCase
                    "Margin block start inherit"
                    [ MarginBlockStart.inherit']
                    "{ margin-block-start: inherit; }"
                testCase
                    "Margin block start initial"
                    [ MarginBlockStart.initial]
                    "{ margin-block-start: initial; }"
                testCase
                    "Margin block start unset"
                    [ MarginBlockStart.unset ]
                    "{ margin-block-start: unset; }"
                testCase
                    "Margin block end 5%"
                    [ MarginBlockEnd.value (pct 5)]
                    "{ margin-block-end: 5%; }"
                testCase
                    "Margin block end 1em"
                    [ MarginBlockEnd.value (em 1)]
                    "{ margin-block-end: 1em; }"
                testCase
                    "Margin block end 10px"
                    [ MarginBlockEnd.value (px 10)]
                    "{ margin-block-end: 10px; }"
                testCase
                    "Margin block end initial"
                    [ MarginBlockEnd.initial]
                    "{ margin-block-end: initial; }"
                testCase
                    "Margin block end unset"
                    [ MarginBlockEnd.unset ]
                    "{ margin-block-end: unset; }"
                testCase
                    "Margin block end inherit"
                    [ MarginBlockEnd.inherit']
                    "{ margin-block-end: inherit; }"
                testCase
                    "Margin block end initial"
                    [ MarginBlockEnd.initial]
                    "{ margin-block-end: initial; }"
                testCase
                    "Margin block end unset"
                    [ MarginBlockEnd.unset ]
                    "{ margin-block-end: unset; }"
            ]