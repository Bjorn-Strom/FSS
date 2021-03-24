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
                    [ Perspective.none ]
                    ["perspective" ==> "none"]
                test
                    "Perspective inherit"
                    [ Perspective.inherit']
                    [ "perspective" ==> "inherit" ]
                test
                    "Perspective initial"
                    [ Perspective.initial]
                    ["perspective" ==> "initial" ]
                test
                    "Perspective unset"
                    [ Perspective.unset]
                    ["perspective" ==> "unset"]
                test
                    "Perspective x"
                    [ PerspectiveOrigin.value <| pct 100 ]
                    ["perspectiveOrigin" ==> "100%"]
                test
                    "Perspective x y"
                    [ PerspectiveOrigin.value (pct 100, pct 50) ]
                    ["perspectiveOrigin" ==> "100% 50%"]
                test
                    "Perspective origin inherit"
                    [ PerspectiveOrigin.inherit']
                    [ "perspectiveOrigin" ==> "inherit" ]
                test
                    "Perspective origin initial"
                    [ PerspectiveOrigin.initial]
                    ["perspectiveOrigin" ==> "initial" ]
                test
                    "Perspective origin unset"
                    [ PerspectiveOrigin.unset]
                    ["perspectiveOrigin" ==> "unset"]
                test
                    "BackfaceVisibility hidden"
                    [ BackfaceVisibility.hidden]
                    [ "backfaceVisibility" ==> "hidden" ]
                test
                    "BackfaceVisibility visible"
                    [ BackfaceVisibility.visible]
                    [ "backfaceVisibility" ==> "visible" ]
                test
                    "BackfaceVisibility inherit"
                    [ BackfaceVisibility.inherit']
                    [ "backfaceVisibility" ==> "inherit" ]
                test
                    "BackfaceVisibility initial"
                    [ BackfaceVisibility.initial]
                    ["backfaceVisibility" ==> "initial" ]
                test
                    "BackfaceVisibility unset"
                    [ BackfaceVisibility.unset]
                    ["backfaceVisibility" ==> "unset"]
            ]