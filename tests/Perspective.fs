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
                    "Perspective x"
                    [ PerspectiveOrigin.Value <| pct 100 ]
                    ["perspectiveOrigin" ==> "100%"]
                test
                    "Perspective x y"
                    [ PerspectiveOrigin.Value (pct 100, pct 50) ]
                    ["perspectiveOrigin" ==> "100% 50%"]
                test
                    "Perspective origin inherit"
                    [ PerspectiveOrigin.Inherit]
                    [ "perspectiveOrigin" ==> "inherit" ]
                test
                    "Perspective origin initial"
                    [ PerspectiveOrigin.Initial]
                    ["perspectiveOrigin" ==> "initial" ]
                test
                    "Perspective origin unset"
                    [ PerspectiveOrigin.Unset]
                    ["perspectiveOrigin" ==> "unset"]
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