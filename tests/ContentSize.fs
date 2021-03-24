namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module ContentSize =
    let tests =
        testList "Content size"
            [
                test
                    "Width px"
                    [ Width' (px 100) ]
                    ["width" ==> "100px"]
                test
                    "Width percent"
                    [ Width' (pct 25) ]
                    ["width" ==> "25%"]
                test
                    "Width max content"
                    [ Width.maxContent ]
                    ["width" ==> "max-content"]
                test
                    "Width min content"
                    [ Width.minContent ]
                    ["width" ==> "min-content"]
                test
                    "Width fit content"
                    [ Width.fitContent (px 100) ]
                    ["width" ==> "fit-content(100px)"]
                test
                    "Width auto"
                    [ Width.auto ]
                    ["width" ==> "auto"]
                test
                    "Width initial"
                    [ Width.initial ]
                    ["width" ==> "initial"]
                test
                    "Width inherit"
                    [ Width.inherit' ]
                    ["width" ==> "inherit"]
                test
                    "Width unset"
                    [ Width.unset ]
                    ["width" ==> "unset"]
                test
                    "Height px"
                    [ Height' (px 100) ]
                    ["height" ==> "100px"]
                test
                    "Height percent"
                    [ Height' (pct 25) ]
                    ["height" ==> "25%"]
                test
                    "Height max content"
                    [ Height.maxContent ]
                    ["height" ==> "max-content"]
                test
                    "Height min content"
                    [ Height.minContent ]
                    ["height" ==> "min-content"]
                test
                    "Height fit content"
                    [ Height.fitContent (px 100) ]
                    ["height" ==> "fit-content(100px)"]
                test
                    "Height auto"
                    [ Height.auto ]
                    ["height" ==> "auto"]
                test
                    "Height initial"
                    [ Height.initial ]
                    ["height" ==> "initial"]
                test
                    "Height inherit"
                    [ Height.inherit' ]
                    ["height" ==> "inherit"]
                test
                    "Height unset"
                    [ Height.unset ]
                    ["height" ==> "unset"]
            ]