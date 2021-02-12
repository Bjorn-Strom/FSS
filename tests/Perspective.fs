namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Perspective =
    let tests =
        testList "Perspective"
            [
                test
                    "Perspective px"
                    [ Perspective' (px 100) ]
                    ["perspective" ==> "100px"]
                test
                    "Perspective em"
                    [ Perspective' (em 3.5) ]
                    ["perspective" ==> "3.5em"]
                test
                    "Perspective none"
                    [ Perspective.None ]
                    ["perspective" ==> "none"]
                test
                    "Perspective inherit"
                    [ Perspective.Inherit]
                    [ "perspective" ==> "inherit" ]
                test
                    "Perspective initial"
                    [ Perspective.Initial]
                    ["perspective" ==> "initial" ]
                test
                    "Perspective unset"
                    [ Perspective.Unset]
                    ["perspective" ==> "unset"]
                test
                    "BackfaceVisibility hidden"
                    [ BackfaceVisibility.Hidden]
                    [ "backfaceVisibility" ==> "hidden" ]
                test
                    "BackfaceVisibility visible"
                    [ BackfaceVisibility.Visible]
                    [ "backfaceVisibility" ==> "visible" ]
                test
                    "BackfaceVisibility inherit"
                    [ BackfaceVisibility.Inherit]
                    [ "backfaceVisibility" ==> "inherit" ]
                test
                    "BackfaceVisibility initial"
                    [ BackfaceVisibility.Initial]
                    ["backfaceVisibility" ==> "initial" ]
                test
                    "BackfaceVisibility unset"
                    [ BackfaceVisibility.Unset]
                    ["backfaceVisibility" ==> "unset"]
            ]