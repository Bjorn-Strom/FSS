namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module PointerEvents =
     let tests =
        testList "PointerEvents"
            [
                testCase
                    "PointerEvents VisiblePainted"
                    [ PointerEvents.visiblePainted ]
                    ["pointerEvents" ==> "visiblePainted"]
                testCase
                    "PointerEvents VisibleFill"
                    [ PointerEvents.visibleFill ]
                    ["pointerEvents" ==> "visibleFill"]
                testCase
                    "PointerEvents VisibleStroke"
                    [ PointerEvents.visibleStroke ]
                    ["pointerEvents" ==> "visibleStroke"]
                testCase
                    "PointerEvents Visible"
                    [ PointerEvents.visible ]
                    ["pointerEvents" ==> "visible"]
                testCase
                    "PointerEvents Painted"
                    [ PointerEvents.painted ]
                    ["pointerEvents" ==> "painted"]
                testCase
                    "PointerEvents Stroke"
                    [ PointerEvents.stroke ]
                    ["pointerEvents" ==> "stroke"]
                testCase
                    "PointerEvents All"
                    [ PointerEvents.all ]
                    ["pointerEvents" ==> "all"]
                testCase
                    "PointerEvents none"
                    [ PointerEvents.none]
                    [ "pointerEvents" ==> "none" ]
                testCase
                    "PointerEvents auto"
                    [ PointerEvents.auto]
                    [ "pointerEvents" ==> "auto" ]
                testCase
                    "PointerEvents inherit"
                    [ PointerEvents.inherit']
                    [ "pointerEvents" ==> "inherit" ]
                testCase
                    "PointerEvents initial"
                    [ PointerEvents.initial]
                    [ "pointerEvents" ==> "initial" ]
                testCase
                    "PointerEvents unset"
                    [ PointerEvents.unset ]
                    [ "pointerEvents" ==> "unset" ]
            ]