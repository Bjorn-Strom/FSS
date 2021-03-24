namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Resize =
    let tests =
        testList "Resize"
            [
                test
                    "Resize Value"
                    [Resize' FssTypes.Resize.Block]
                    ["resize" ==> "block"]
                test
                    "Resize Both"
                    [Resize.both]
                    ["resize" ==> "both"]
                test
                    "Resize Horizontal"
                    [Resize.horizontal]
                    ["resize" ==> "horizontal"]
                test
                    "Resize Vertical"
                    [Resize.vertical]
                    ["resize" ==> "vertical"]
                test
                    "Resize Inline"
                    [Resize.inline']
                    ["resize" ==> "inline"]
                test
                    "Resize Block"
                    [Resize.block]
                    ["resize" ==> "block"]
                test
                    "Resize None"
                    [Resize.none]
                    ["resize" ==> "none"]
                test
                    "Resize Initial"
                    [Resize.initial]
                    ["resize" ==> "initial"]
                test
                    "Resize Inherit"
                    [Resize.inherit']
                    ["resize" ==> "inherit"]
                test
                    "Resize Unset"
                    [Resize.unset]
                    ["resize" ==> "unset"]
            ]
