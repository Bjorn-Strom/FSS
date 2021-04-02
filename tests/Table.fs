namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Table =
    let tests =
        testList "table"
            [
                testCase
                    "Caption side top"
                    [CaptionSide.top]
                    ["captionSide" ==> "top"]
                testCase
                    "Caption side bottom"
                    [CaptionSide.bottom]
                    ["captionSide" ==> "bottom"]
                testCase
                    "Caption side left"
                    [CaptionSide.left]
                    ["captionSide" ==> "left"]
                testCase
                    "Caption side right"
                    [CaptionSide.right]
                    ["captionSide" ==> "right"]
                testCase
                    "Caption side top-outside"
                    [CaptionSide.topOutside]
                    ["captionSide" ==> "top-outside"]
                testCase
                    "Caption side bottom-outside"
                    [CaptionSide.bottomOutside]
                    ["captionSide" ==> "bottom-outside"]
                testCase
                    "Caption side inherit"
                    [CaptionSide.inherit']
                    ["captionSide" ==> "inherit"]
                testCase
                    "Caption side initial"
                    [CaptionSide.initial]
                    ["captionSide" ==> "initial"]
                testCase
                    "Caption side unset"
                    [CaptionSide.unset]
                    ["captionSide" ==> "unset"]
                testCase
                    "Empty Cells show"
                    [EmptyCells.show]
                    ["emptyCells" ==> "show"]
                testCase
                    "Empty Cells hide"
                    [EmptyCells.hide]
                    ["emptyCells" ==> "hide"]
                testCase
                    "Empty Cells inherit"
                    [EmptyCells.inherit']
                    ["emptyCells" ==> "inherit"]
                testCase
                    "Empty Cells initial"
                    [EmptyCells.initial]
                    ["emptyCells" ==> "initial"]
                testCase
                    "Empty Cells unset"
                    [EmptyCells.unset]
                    ["emptyCells" ==> "unset"]
                testCase
                    "Table Layout fixed"
                    [TableLayout.fixed']
                    ["tableLayout" ==> "fixed"]
                testCase
                    "Table Layout auto"
                    [TableLayout.auto]
                    ["tableLayout" ==> "auto"]
                testCase
                    "Table Layout inherit"
                    [TableLayout.inherit']
                    ["tableLayout" ==> "inherit"]
                testCase
                    "Table Layout initial"
                    [TableLayout.initial]
                    ["tableLayout" ==> "initial"]
                testCase
                    "Table Layout unset"
                    [TableLayout.unset]
                    ["tableLayout" ==> "unset"]
            ]