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
                    [ PointerEvents.VisiblePainted ]
                    ["pointerEvents" ==> "visiblePainted"]
                test
                    "PointerEvents VisibleFill"
                    [ PointerEvents.VisibleFill ]
                    ["pointerEvents" ==> "visibleFill"]
                test
                    "PointerEvents VisibleStroke"
                    [ PointerEvents.VisibleStroke ]
                    ["pointerEvents" ==> "visibleStroke"]
                test
                    "PointerEvents Visible"
                    [ PointerEvents.Visible ]
                    ["pointerEvents" ==> "visible"]
                test
                    "PointerEvents Painted"
                    [ PointerEvents.Painted ]
                    ["pointerEvents" ==> "painted"]
                test
                    "PointerEvents Stroke"
                    [ PointerEvents.Stroke ]
                    ["pointerEvents" ==> "stroke"]
                test
                    "PointerEvents All"
                    [ PointerEvents.All ]
                    ["pointerEvents" ==> "all"]
                test
                    "PointerEvents none"
                    [ PointerEvents.None]
                    [ "pointerEvents" ==> "none" ]
                test
                    "PointerEvents auto"
                    [ PointerEvents.Auto]
                    [ "pointerEvents" ==> "auto" ]
                test
                    "PointerEvents inherit"
                    [ PointerEvents.Inherit]
                    [ "pointerEvents" ==> "inherit" ]
                test
                    "PointerEvents initial"
                    [ PointerEvents.Initial]
                    [ "pointerEvents" ==> "initial" ]
                test
                    "PointerEvents unset"
                    [ PointerEvents.Unset ]
                    [ "pointerEvents" ==> "unset" ]
            ]