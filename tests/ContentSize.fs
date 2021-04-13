namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module ContentSize =
    let tests =
        testList "Content size"
            [
                testCase
                    "Width px"
                    [ Width' (px 100) ]
                    ["width" ==> "100px"]
                testCase
                    "Width percent"
                    [ Width' (pct 25) ]
                    ["width" ==> "25%"]
                testCase
                    "Width max content"
                    [ Width.maxContent ]
                    ["width" ==> "max-content"]
                testCase
                    "Width min content"
                    [ Width.minContent ]
                    ["width" ==> "min-content"]
                testCase
                    "Width fit content"
                    [ Width.fitContent (px 100) ]
                    ["width" ==> "fit-content(100px)"]
                testCase
                    "Width auto"
                    [ Width.auto ]
                    ["width" ==> "auto"]
                testCase
                    "Width initial"
                    [ Width.initial ]
                    ["width" ==> "initial"]
                testCase
                    "Width inherit"
                    [ Width.inherit' ]
                    ["width" ==> "inherit"]
                testCase
                    "Width unset"
                    [ Width.unset ]
                    ["width" ==> "unset"]
                testCase
                    "Height px"
                    [ Height' (px 100) ]
                    ["height" ==> "100px"]
                testCase
                    "Height percent"
                    [ Height' (pct 25) ]
                    ["height" ==> "25%"]
                testCase
                    "Height max content"
                    [ Height.maxContent ]
                    ["height" ==> "max-content"]
                testCase
                    "Height min content"
                    [ Height.minContent ]
                    ["height" ==> "min-content"]
                testCase
                    "Height fit content"
                    [ Height.fitContent (px 100) ]
                    ["height" ==> "fit-content(100px)"]
                testCase
                    "Height auto"
                    [ Height.auto ]
                    ["height" ==> "auto"]
                testCase
                    "Height initial"
                    [ Height.initial ]
                    ["height" ==> "initial"]
                testCase
                    "Height inherit"
                    [ Height.inherit' ]
                    ["height" ==> "inherit"]
                testCase
                    "Height unset"
                    [ Height.unset ]
                    ["height" ==> "unset"]
            ]