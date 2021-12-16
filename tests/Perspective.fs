namespace FSSTests

open Fet
open Utils
open Fss

module Perspective =
    let tests =
        testList "Perspective"
            [
                testCase
                    "Perspective px"
                    [ Perspective.value (px 100) ]
                    "perspective: 100px;"
                testCase
                    "Perspective em"
                    [ Perspective.value (em 3.5) ]
                    "perspective: 3.5em;"
                testCase
                    "Perspective none"
                    [ Perspective.none ]
                    "perspective: none;"
                testCase
                    "Perspective inherit"
                    [ Perspective.inherit']
                     "perspective: inherit;" 
                testCase
                    "Perspective initial"
                    [ Perspective.initial]
                    "perspective: initial;" 
                testCase
                    "Perspective unset"
                    [ Perspective.unset]
                    "perspective: unset;"
                testCase
                    "Perspective revert"
                    [ Perspective.revert]
                    "perspective: revert;"
                testCase
                    "Perspective x"
                    [ PerspectiveOrigin.value (pct 100) ]
                    "perspective-origin: 100%;"
                testCase
                    "Perspective x y"
                    [ PerspectiveOrigin.value (pct 100, pct 50) ]
                    "perspective-origin: 100% 50%;"
                testCase
                    "Perspective origin inherit"
                    [ PerspectiveOrigin.inherit']
                     "perspective-origin: inherit;" 
                testCase
                    "Perspective origin initial"
                    [ PerspectiveOrigin.initial]
                    "perspective-origin: initial;" 
                testCase
                    "Perspective origin unset"
                    [ PerspectiveOrigin.unset]
                    "perspective-origin: unset;"
                testCase
                    "Perspective origin revert"
                    [ PerspectiveOrigin.revert]
                    "perspective-origin: revert;"
                testCase
                    "BackfaceVisibility hidden"
                    [ BackfaceVisibility.hidden]
                     "backface-visibility: hidden;" 
                testCase
                    "BackfaceVisibility visible"
                    [ BackfaceVisibility.visible]
                     "backface-visibility: visible;" 
                testCase
                    "BackfaceVisibility inherit"
                    [ BackfaceVisibility.inherit']
                     "backface-visibility: inherit;" 
                testCase
                    "BackfaceVisibility initial"
                    [ BackfaceVisibility.initial]
                    "backface-visibility: initial;" 
                testCase
                    "BackfaceVisibility unset"
                    [ BackfaceVisibility.unset]
                    "backface-visibility: unset;"
                testCase
                    "BackfaceVisibility revert"
                    [ BackfaceVisibility.revert]
                    "backface-visibility: revert;"
            ]