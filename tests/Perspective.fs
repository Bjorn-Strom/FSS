namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Perspective =
    let tests =
        testList "Perspective"
            [
                testCase
                    "Perspective px"
                    [ Perspective' (px 100) ]
                    ["perspective" ==> "100px"]
                testCase
                    "Perspective em"
                    [ Perspective' (em 3.5) ]
                    ["perspective" ==> "3.5em"]
                testCase
                    "Perspective none"
                    [ Perspective.none ]
                    ["perspective" ==> "none"]
                testCase
                    "Perspective inherit"
                    [ Perspective.inherit']
                    [ "perspective" ==> "inherit" ]
                testCase
                    "Perspective initial"
                    [ Perspective.initial]
                    ["perspective" ==> "initial" ]
                testCase
                    "Perspective unset"
                    [ Perspective.unset]
                    ["perspective" ==> "unset"]
                testCase
                    "Perspective x"
                    [ PerspectiveOrigin.value <| pct 100 ]
                    ["perspectiveOrigin" ==> "100%"]
                testCase
                    "Perspective x y"
                    [ PerspectiveOrigin.value (pct 100, pct 50) ]
                    ["perspectiveOrigin" ==> "100% 50%"]
                testCase
                    "Perspective origin inherit"
                    [ PerspectiveOrigin.inherit']
                    [ "perspectiveOrigin" ==> "inherit" ]
                testCase
                    "Perspective origin initial"
                    [ PerspectiveOrigin.initial]
                    ["perspectiveOrigin" ==> "initial" ]
                testCase
                    "Perspective origin unset"
                    [ PerspectiveOrigin.unset]
                    ["perspectiveOrigin" ==> "unset"]
                testCase
                    "BackfaceVisibility hidden"
                    [ BackfaceVisibility.hidden]
                    [ "backfaceVisibility" ==> "hidden" ]
                testCase
                    "BackfaceVisibility visible"
                    [ BackfaceVisibility.visible]
                    [ "backfaceVisibility" ==> "visible" ]
                testCase
                    "BackfaceVisibility inherit"
                    [ BackfaceVisibility.inherit']
                    [ "backfaceVisibility" ==> "inherit" ]
                testCase
                    "BackfaceVisibility initial"
                    [ BackfaceVisibility.initial]
                    ["backfaceVisibility" ==> "initial" ]
                testCase
                    "BackfaceVisibility unset"
                    [ BackfaceVisibility.unset]
                    ["backfaceVisibility" ==> "unset"]
            ]