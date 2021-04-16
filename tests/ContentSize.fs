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
                testCase
                    "MaxWidth px"
                    [ MaxWidth' (px 100) ]
                    ["maxWidth" ==> "100px"]
                testCase
                    "MaxWidth percent"
                    [ MaxWidth' (pct 25) ]
                    ["maxWidth" ==> "25%"]
                testCase
                    "MaxWidth max content"
                    [ MaxWidth.maxContent ]
                    ["maxWidth" ==> "max-content"]
                testCase
                    "MaxWidth min content"
                    [ MaxWidth.minContent ]
                    ["maxWidth" ==> "min-content"]
                testCase
                    "MaxWidth fit content"
                    [ MaxWidth.fitContent (px 100) ]
                    ["maxWidth" ==> "fit-content(100px)"]
                testCase
                    "MaxWidth auto"
                    [ MaxWidth.auto ]
                    ["maxWidth" ==> "auto"]
                testCase
                    "MaxWidth initial"
                    [ MaxWidth.initial ]
                    ["maxWidth" ==> "initial"]
                testCase
                    "MaxWidth inherit"
                    [ MaxWidth.inherit' ]
                    ["maxWidth" ==> "inherit"]
                testCase
                    "MaxWidth unset"
                    [ MaxWidth.unset ]
                    ["maxWidth" ==> "unset"]
                testCase
                    "MaxHeight px"
                    [ MaxHeight' (px 100) ]
                    ["maxHeight" ==> "100px"]
                testCase
                    "MaxHeight percent"
                    [ MaxHeight' (pct 25) ]
                    ["maxHeight" ==> "25%"]
                testCase
                    "MaxHeight max content"
                    [ MaxHeight.maxContent ]
                    ["maxHeight" ==> "max-content"]
                testCase
                    "MaxHeight min content"
                    [ MaxHeight.minContent ]
                    ["maxHeight" ==> "min-content"]
                testCase
                    "MaxHeight fit content"
                    [ MaxHeight.fitContent (px 100) ]
                    ["maxHeight" ==> "fit-content(100px)"]
                testCase
                    "MaxHeight auto"
                    [ MaxHeight.auto ]
                    ["maxHeight" ==> "auto"]
                testCase
                    "MaxHeight initial"
                    [ MaxHeight.initial ]
                    ["maxHeight" ==> "initial"]
                testCase
                    "MaxHeight inherit"
                    [ MaxHeight.inherit' ]
                    ["maxHeight" ==> "inherit"]
                testCase
                    "MaxHeight unset"
                    [ MaxHeight.unset ]
                    ["maxHeight" ==> "unset"]
                testCase
                    "MinWidth px"
                    [ MinWidth' (px 100) ]
                    ["minWidth" ==> "100px"]
                testCase
                    "MinWidth percent"
                    [ MinWidth' (pct 25) ]
                    ["minWidth" ==> "25%"]
                testCase
                    "MinWidth max content"
                    [ MinWidth.maxContent ]
                    ["minWidth" ==> "max-content"]
                testCase
                    "MinWidth min content"
                    [ MinWidth.minContent ]
                    ["minWidth" ==> "min-content"]
                testCase
                    "MinWidth fit content"
                    [ MinWidth.fitContent (px 100) ]
                    ["minWidth" ==> "fit-content(100px)"]
                testCase
                    "MinWidth auto"
                    [ MinWidth.auto ]
                    ["minWidth" ==> "auto"]
                testCase
                    "MinWidth initial"
                    [ MinWidth.initial ]
                    ["minWidth" ==> "initial"]
                testCase
                    "MinWidth inherit"
                    [ MinWidth.inherit' ]
                    ["minWidth" ==> "inherit"]
                testCase
                    "MinWidth unset"
                    [ MinWidth.unset ]
                    ["minWidth" ==> "unset"]
                testCase
                    "MinHeight px"
                    [ MinHeight' (px 100) ]
                    ["minHeight" ==> "100px"]
                testCase
                    "MinHeight percent"
                    [ MinHeight' (pct 25) ]
                    ["minHeight" ==> "25%"]
                testCase
                    "MinHeight max content"
                    [ MinHeight.maxContent ]
                    ["minHeight" ==> "max-content"]
                testCase
                    "MinHeight min content"
                    [ MinHeight.minContent ]
                    ["minHeight" ==> "min-content"]
                testCase
                    "MinHeight fit content"
                    [ MinHeight.fitContent (px 100) ]
                    ["minHeight" ==> "fit-content(100px)"]
                testCase
                    "MinHeight auto"
                    [ MinHeight.auto ]
                    ["minHeight" ==> "auto"]
                testCase
                    "MinHeight initial"
                    [ MinHeight.initial ]
                    ["minHeight" ==> "initial"]
                testCase
                    "MinHeight inherit"
                    [ MinHeight.inherit' ]
                    ["minHeight" ==> "inherit"]
                testCase
                    "MinHeight unset"
                    [ MinHeight.unset ]
                    ["minHeight" ==> "unset"]
            ]