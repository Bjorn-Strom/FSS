namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module PointerEvents =
     let tests =
        testList "PointerEvents"
            [
                test
                    "PointerEvents VisiblePainted"
                    [ PointerEvents.visiblePainted ]
                    ["pointerEvents" ==> "visiblePainted"]
                test
                    "PointerEvents VisibleFill"
                    [ PointerEvents.visibleFill ]
                    ["pointerEvents" ==> "visibleFill"]
                test
                    "PointerEvents VisibleStroke"
                    [ PointerEvents.visibleStroke ]
                    ["pointerEvents" ==> "visibleStroke"]
                test
                    "PointerEvents Visible"
                    [ PointerEvents.visible ]
                    ["pointerEvents" ==> "visible"]
                test
                    "PointerEvents Painted"
                    [ PointerEvents.painted ]
                    ["pointerEvents" ==> "painted"]
                test
                    "PointerEvents Stroke"
                    [ PointerEvents.stroke ]
                    ["pointerEvents" ==> "stroke"]
                test
                    "PointerEvents All"
                    [ PointerEvents.all ]
                    ["pointerEvents" ==> "all"]
                test
                    "PointerEvents none"
                    [ PointerEvents.none]
                    [ "pointerEvents" ==> "none" ]
                test
                    "PointerEvents auto"
                    [ PointerEvents.auto]
                    [ "pointerEvents" ==> "auto" ]
                test
                    "PointerEvents inherit"
                    [ PointerEvents.inherit']
                    [ "pointerEvents" ==> "inherit" ]
                test
                    "PointerEvents initial"
                    [ PointerEvents.initial]
                    [ "pointerEvents" ==> "initial" ]
                test
                    "PointerEvents unset"
                    [ PointerEvents.unset ]
                    [ "pointerEvents" ==> "unset" ]
            ]