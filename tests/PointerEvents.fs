namespace FSSTests

open Fet
open Utils
open Fss

module PointerEvents =
     let tests =
        testList "PointerEvents"
            [
                testCase
                    "PointerEvents VisiblePainted"
                    [ PointerEvents.visiblePainted ]
                    "{ pointer-events: visiblepainted; }"
                testCase
                    "PointerEvents VisibleFill"
                    [ PointerEvents.visibleFill ]
                    "{ pointer-events: visiblefill; }"
                testCase
                    "PointerEvents VisibleStroke"
                    [ PointerEvents.visibleStroke ]
                    "{ pointer-events: visiblestroke; }"
                testCase
                    "PointerEvents Visible"
                    [ PointerEvents.visible ]
                    "{ pointer-events: visible; }"
                testCase
                    "PointerEvents Painted"
                    [ PointerEvents.painted ]
                    "{ pointer-events: painted; }"
                testCase
                    "PointerEvents Stroke"
                    [ PointerEvents.stroke ]
                    "{ pointer-events: stroke; }"
                testCase
                    "PointerEvents All"
                    [ PointerEvents.all ]
                    "{ pointer-events: all; }"
                testCase
                    "PointerEvents none"
                    [ PointerEvents.none]
                     "{ pointer-events: none; }" 
                testCase
                    "PointerEvents auto"
                    [ PointerEvents.auto]
                     "{ pointer-events: auto; }" 
                testCase
                    "PointerEvents inherit"
                    [ PointerEvents.inherit']
                     "{ pointer-events: inherit; }" 
                testCase
                    "PointerEvents initial"
                    [ PointerEvents.initial]
                     "{ pointer-events: initial; }" 
                testCase
                    "PointerEvents unset"
                    [ PointerEvents.unset ]
                     "{ pointer-events: unset; }" 
            ]