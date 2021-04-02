namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Resize =
    let tests =
        testList "Resize"
            [
                testCase
                    "Resize Value"
                    [Resize' FssTypes.Resize.Block]
                    ["resize" ==> "block"]
                testCase
                    "Resize Both"
                    [Resize.both]
                    ["resize" ==> "both"]
                testCase
                    "Resize Horizontal"
                    [Resize.horizontal]
                    ["resize" ==> "horizontal"]
                testCase
                    "Resize Vertical"
                    [Resize.vertical]
                    ["resize" ==> "vertical"]
                testCase
                    "Resize Inline"
                    [Resize.inline']
                    ["resize" ==> "inline"]
                testCase
                    "Resize Block"
                    [Resize.block]
                    ["resize" ==> "block"]
                testCase
                    "Resize None"
                    [Resize.none]
                    ["resize" ==> "none"]
                testCase
                    "Resize Initial"
                    [Resize.initial]
                    ["resize" ==> "initial"]
                testCase
                    "Resize Inherit"
                    [Resize.inherit']
                    ["resize" ==> "inherit"]
                testCase
                    "Resize Unset"
                    [Resize.unset]
                    ["resize" ==> "unset"]
            ]
