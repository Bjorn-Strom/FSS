namespace FSSTests

open Fet
open Utils
open Fss

module Padding =
    let tests =
        testList "Padding"
            [
                testCase
                    "Padding top px"
                    [ PaddingTop.value (px 10)]
                    "padding-top: 10px;"
                testCase
                    "Padding top pct"
                    [ PaddingTop.value (pct 10)]
                    "padding-top: 10%;"
                testCase
                    "Padding top inherit"
                    [ PaddingTop.inherit' ]
                    "padding-top: inherit;"
                testCase
                    "Padding top initial"
                    [ PaddingTop.initial ]
                    "padding-top: initial;"
                testCase
                    "Padding top unset"
                    [ PaddingTop.unset ]
                    "padding-top: unset;"
                testCase
                    "Padding top revert"
                    [ PaddingTop.revert ]
                    "padding-top: revert;"
                testCase
                    "Padding right px"
                    [ PaddingRight.value (px 10)]
                    "padding-right: 10px;"
                testCase
                    "Padding right pct"
                    [ PaddingRight.value (pct 10)]
                    "padding-right: 10%;"
                testCase
                    "Padding right inherit"
                    [ PaddingRight.inherit' ]
                    "padding-right: inherit;"
                testCase
                    "Padding right initial"
                    [ PaddingRight.initial ]
                    "padding-right: initial;"
                testCase
                    "Padding right unset"
                    [ PaddingRight.unset ]
                    "padding-right: unset;"
                testCase
                    "Padding right revert"
                    [ PaddingRight.revert ]
                    "padding-right: revert;"
                testCase
                    "Padding bottom px"
                    [ PaddingBottom.value (px 10)]
                    "padding-bottom: 10px;"
                testCase
                    "Padding bottom pct"
                    [ PaddingBottom.value (pct 10)]
                    "padding-bottom: 10%;"
                testCase
                    "Padding bottom inherit"
                    [ PaddingBottom.inherit' ]
                    "padding-bottom: inherit;"
                testCase
                    "Padding bottom initial"
                    [ PaddingBottom.initial ]
                    "padding-bottom: initial;"
                testCase
                    "Padding bottom unset"
                    [ PaddingBottom.unset ]
                    "padding-bottom: unset;"
                testCase
                    "Padding bottom revert"
                    [ PaddingBottom.revert ]
                    "padding-bottom: revert;"
                testCase
                    "Padding left px"
                    [ PaddingLeft.value (px 10)]
                    "padding-left: 10px;"
                testCase
                    "Padding left pct"
                    [ PaddingLeft.value (pct 10)]
                    "padding-left: 10%;"
                testCase
                    "Padding left inherit"
                    [ PaddingLeft.inherit' ]
                    "padding-left: inherit;"
                testCase
                    "Padding left initial"
                    [ PaddingLeft.initial ]
                    "padding-left: initial;"
                testCase
                    "Padding left unset"
                    [ PaddingLeft.unset ]
                    "padding-left: unset;"
                testCase
                    "Padding left revert"
                    [ PaddingLeft.revert ]
                    "padding-left: revert;"
                testCase
                    "Padding px"
                    [ Padding.value (px 10)]
                    "padding: 10px;"
                testCase
                    "Padding pct"
                    [ Padding.value (pct 10)]
                    "padding: 10%;"
                testCase
                    "Padding em"
                    [ Padding.value (em 10.0)]
                    "padding: 10em;"
                testCase
                    "Padding auto"
                    [ Padding.auto]
                    "padding: auto;"
                testCase
                    "Padding inherit"
                    [ Padding.inherit']
                    "padding: inherit;"
                testCase
                    "Padding initial"
                    [ Padding.initial]
                    "padding: initial;"
                testCase
                    "Padding unset"
                    [ Padding.unset ]
                    "padding: unset;"
                testCase
                    "Padding revert"
                    [ Padding.revert ]
                    "padding: revert;"
                testCase
                    "Paddings multiple"
                    [ Padding.value (px 10, px 20, px 30, px 40) ]
                    "padding: 10px 20px 30px 40px;"
                testCase
                    "Padding inline start 5%"
                    [ PaddingInlineStart.value (pct 5)]
                    "padding-inline-start: 5%;"
                testCase
                    "Padding inline start 1em"
                    [ PaddingInlineStart.value (em 1)]
                    "padding-inline-start: 1em;"
                testCase
                    "Padding inline start 10px"
                    [ PaddingInlineStart.value (px 10)]
                    "padding-inline-start: 10px;"
                testCase
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    "padding-inline-start: initial;"
                testCase
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    "padding-inline-start: unset;"
                testCase
                    "Padding inline start inherit"
                    [ PaddingInlineStart.inherit']
                    "padding-inline-start: inherit;"
                testCase
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    "padding-inline-start: initial;"
                testCase
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    "padding-inline-start: unset;"
                testCase
                    "Padding inline start revert"
                    [ PaddingInlineStart.revert ]
                    "padding-inline-start: revert;"
                testCase
                    "Padding inline end 5%"
                    [ PaddingInlineEnd.value (pct 5)]
                    "padding-inline-end: 5%;"
                testCase
                    "Padding inline end 1em"
                    [ PaddingInlineEnd.value (em 1)]
                    "padding-inline-end: 1em;"
                testCase
                    "Padding inline end 10px"
                    [ PaddingInlineEnd.value (px 10)]
                    "padding-inline-end: 10px;"
                testCase
                    "Padding inline end initial"
                    [ PaddingInlineEnd.initial]
                    "padding-inline-end: initial;"
                testCase
                    "Padding inline end unset"
                    [ PaddingInlineEnd.unset ]
                    "padding-inline-end: unset;"
                testCase
                    "Padding inline end inherit"
                    [ PaddingInlineEnd.inherit']
                    "padding-inline-end: inherit;"
                testCase
                    "Padding inline end revert"
                    [ PaddingInlineEnd.revert]
                    "padding-inline-end: revert;"
                testCase
                    "Padding block start 5%"
                    [ PaddingBlockStart.value (pct 5)]
                    "padding-block-start: 5%;"
                testCase
                    "Padding block start 1em"
                    [ PaddingBlockStart.value (em 1)]
                    "padding-block-start: 1em;"
                testCase
                    "Padding block start 10px"
                    [ PaddingBlockStart.value (px 10)]
                    "padding-block-start: 10px;"
                testCase
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    "padding-block-start: initial;"
                testCase
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    "padding-block-start: unset;"
                testCase
                    "Padding block start inherit"
                    [ PaddingBlockStart.inherit']
                    "padding-block-start: inherit;"
                testCase
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    "padding-block-start: initial;"
                testCase
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    "padding-block-start: unset;"
                testCase
                    "Padding block end 5%"
                    [ PaddingBlockEnd.value (pct 5)]
                    "padding-block-end: 5%;"
                testCase
                    "Padding block end 1em"
                    [ PaddingBlockEnd.value (em 1)]
                    "padding-block-end: 1em;"
                testCase
                    "Padding block end 10px"
                    [ PaddingBlockEnd.value (px 10)]
                    "padding-block-end: 10px;"
                testCase
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    "padding-block-end: initial;"
                testCase
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    "padding-block-end: unset;"
                testCase
                    "Padding block end inherit"
                    [ PaddingBlockEnd.inherit']
                    "padding-block-end: inherit;"
                testCase
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    "padding-block-end: initial;"
                testCase
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    "padding-block-end: unset;"
            ]