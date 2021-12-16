namespace FSSTests

open Fet
open Utils
open Fss

module Table =
    let tests =
        testList "table"
            [
                testCase
                    "Caption side top"
                    [CaptionSide.top]
                    "caption-side: top;"
                testCase
                    "Caption side bottom"
                    [CaptionSide.bottom]
                    "caption-side: bottom;"
                testCase
                    "Caption side left"
                    [CaptionSide.left]
                    "caption-side: left;"
                testCase
                    "Caption side right"
                    [CaptionSide.right]
                    "caption-side: right;"
                testCase
                    "Caption side top-outside"
                    [CaptionSide.topOutside]
                    "caption-side: top-outside;"
                testCase
                    "Caption side bottom-outside"
                    [CaptionSide.bottomOutside]
                    "caption-side: bottom-outside;"
                testCase
                    "Caption side inherit"
                    [CaptionSide.inherit']
                    "caption-side: inherit;"
                testCase
                    "Caption side initial"
                    [CaptionSide.initial]
                    "caption-side: initial;"
                testCase
                    "Caption side unset"
                    [CaptionSide.unset]
                    "caption-side: unset;"
                testCase
                    "Caption side revert"
                    [CaptionSide.revert]
                    "caption-side: revert;"
                testCase
                    "Empty Cells show"
                    [EmptyCells.show]
                    "empty-cells: show;"
                testCase
                    "Empty Cells hide"
                    [EmptyCells.hide]
                    "empty-cells: hide;"
                testCase
                    "Empty Cells inherit"
                    [EmptyCells.inherit']
                    "empty-cells: inherit;"
                testCase
                    "Empty Cells initial"
                    [EmptyCells.initial]
                    "empty-cells: initial;"
                testCase
                    "Empty Cells unset"
                    [EmptyCells.unset]
                    "empty-cells: unset;"
                testCase
                    "Empty Cells revert"
                    [EmptyCells.revert]
                    "empty-cells: revert;"
                testCase
                    "Table Layout fixed"
                    [TableLayout.fixed']
                    "table-layout: fixed;"
                testCase
                    "Table Layout auto"
                    [TableLayout.auto]
                    "table-layout: auto;"
                testCase
                    "Table Layout inherit"
                    [TableLayout.inherit']
                    "table-layout: inherit;"
                testCase
                    "Table Layout initial"
                    [TableLayout.initial]
                    "table-layout: initial;"
                testCase
                    "Table Layout unset"
                    [TableLayout.unset]
                    "table-layout: unset;"
                testCase
                    "Table Layout revert"
                    [TableLayout.revert]
                    "table-layout: revert;"
            ]