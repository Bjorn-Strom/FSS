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
                    [Resize.Both]
                    ["resize" ==> "both"]
                test
                    "Resize Horizontal"
                    [Resize.Horizontal]
                    ["resize" ==> "horizontal"]
                test
                    "Resize Vertical"
                    [Resize.Vertical]
                    ["resize" ==> "vertical"]
                test
                    "Resize Inline"
                    [Resize.Inline]
                    ["resize" ==> "inline"]
                test
                    "Resize Block"
                    [Resize.Block]
                    ["resize" ==> "block"]
                test
                    "Resize None"
                    [Resize.None]
                    ["resize" ==> "none"]
                test
                    "Resize Initial"
                    [Resize.Initial]
                    ["resize" ==> "initial"]
                test
                    "Resize Inherit"
                    [Resize.Inherit]
                    ["resize" ==> "inherit"]
                test
                    "Resize Unset"
                    [Resize.Unset]
                    ["resize" ==> "unset"]
            ]
