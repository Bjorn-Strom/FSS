namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Table =
    let tests =
        testList "table"
            [
                test
                    "Caption side top"
                    [CaptionSide.top]
                    ["captionSide" ==> "top"]
                test
                    "Caption side bottom"
                    [CaptionSide.bottom]
                    ["captionSide" ==> "bottom"]
                test
                    "Caption side left"
                    [CaptionSide.left]
                    ["captionSide" ==> "left"]
                test
                    "Caption side right"
                    [CaptionSide.right]
                    ["captionSide" ==> "right"]
                test
                    "Caption side top-outside"
                    [CaptionSide.topOutside]
                    ["captionSide" ==> "top-outside"]
                test
                    "Caption side bottom-outside"
                    [CaptionSide.bottomOutside]
                    ["captionSide" ==> "bottom-outside"]
                test
                    "Caption side inherit"
                    [CaptionSide.inherit']
                    ["captionSide" ==> "inherit"]
                test
                    "Caption side initial"
                    [CaptionSide.initial]
                    ["captionSide" ==> "initial"]
                test
                    "Caption side unset"
                    [CaptionSide.unset]
                    ["captionSide" ==> "unset"]
                test
                    "Empty Cells show"
                    [EmptyCells.show]
                    ["emptyCells" ==> "show"]
                test
                    "Empty Cells hide"
                    [EmptyCells.hide]
                    ["emptyCells" ==> "hide"]
                test
                    "Empty Cells inherit"
                    [EmptyCells.inherit']
                    ["emptyCells" ==> "inherit"]
                test
                    "Empty Cells initial"
                    [EmptyCells.initial]
                    ["emptyCells" ==> "initial"]
                test
                    "Empty Cells unset"
                    [EmptyCells.unset]
                    ["emptyCells" ==> "unset"]
                test
                    "Table Layout fixed"
                    [TableLayout.fixed']
                    ["tableLayout" ==> "fixed"]
                test
                    "Table Layout auto"
                    [TableLayout.auto]
                    ["tableLayout" ==> "auto"]
                test
                    "Table Layout inherit"
                    [TableLayout.inherit']
                    ["tableLayout" ==> "inherit"]
                test
                    "Table Layout initial"
                    [TableLayout.initial]
                    ["tableLayout" ==> "initial"]
                test
                    "Table Layout unset"
                    [TableLayout.unset]
                    ["tableLayout" ==> "unset"]
            ]