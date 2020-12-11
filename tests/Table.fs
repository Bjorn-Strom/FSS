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
                    [CaptionSide.Top]
                    ["captionSide" ==> "top"]
                test
                    "Caption side bottom"
                    [CaptionSide.Bottom]
                    ["captionSide" ==> "bottom"]
                test
                    "Caption side left"
                    [CaptionSide.Left]
                    ["captionSide" ==> "left"]
                test
                    "Caption side right"
                    [CaptionSide.Right]
                    ["captionSide" ==> "right"]
                test
                    "Caption side top-outside"
                    [CaptionSide.TopOutside]
                    ["captionSide" ==> "top-outside"]
                test
                    "Caption side bottom-outside"
                    [CaptionSide.BottomOutside]
                    ["captionSide" ==> "bottom-outside"]
                test
                    "Caption side inherit"
                    [CaptionSide.Inherit]
                    ["captionSide" ==> "inherit"]
                test
                    "Caption side initial"
                    [CaptionSide.Initial]
                    ["captionSide" ==> "initial"]
                test
                    "Caption side unset"
                    [CaptionSide.Unset]
                    ["captionSide" ==> "unset"]
            ]