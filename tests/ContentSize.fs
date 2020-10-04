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
                    [ Width (px 100) ]
                    ["width" ==> "100px"]

                test
                    "Width percent"
                    [ Width (pct 25) ]
                    ["width" ==> "25%"]


                test
                    "Width max content"
                    [ Width ContentSize.MaxContent ]
                    ["width" ==> "max-content"]

                test
                    "Width min content"
                    [ Width ContentSize.MinContent ]
                    ["width" ==> "min-content"]

                test
                    "Width fit content"
                    [ Width (ContentSize.FitContent(px 100)) ]
                    ["width" ==> "fit-content(100px)"]

                test
                    "Width auto"
                    [ Width Auto ]
                    ["width" ==> "auto"]

                test
                    "Width initial"
                    [ Width Initial ]
                    ["width" ==> "initial"]

                test
                    "Width inherit"
                    [ Width Inherit ]
                    ["width" ==> "inherit"]

                test
                    "Width unset"
                    [ Width Unset ]
                    ["width" ==> "unset"]

                test
                    "Height px"
                    [ Height (px 100) ]
                    ["height" ==> "100px"]

                test
                    "Height percent"
                    [ Height (pct 25) ]
                    ["height" ==> "25%"]


                test
                    "Height max content"
                    [ Height ContentSize.MaxContent ]
                    ["height" ==> "max-content"]

                test
                    "Height min content"
                    [ Height ContentSize.MinContent ]
                    ["height" ==> "min-content"]

                test
                    "Height fit content"
                    [ Height (ContentSize.FitContent(px 100)) ]
                    ["height" ==> "fit-content(100px)"]

                test
                    "Height auto"
                    [ Height Auto ]
                    ["height" ==> "auto"]

                test
                    "Height initial"
                    [ Height Initial ]
                    ["height" ==> "initial"]

                test
                    "Height inherit"
                    [ Height Inherit ]
                    ["height" ==> "inherit"]

                test
                    "Height unset"
                    [ Height Unset ]
                    ["height" ==> "unset"]
            ]