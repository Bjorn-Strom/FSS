namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Color =
    let tests =
        testList "Colors"
            [
                testCase
                    "Color adjust exact"
                    [ColorAdjust.exact]
                    ["colorAdjust" ==> "exact"]
                testCase
                    "Color adjust economy"
                    [ColorAdjust.economy]
                    ["colorAdjust" ==> "economy"]
                testCase
                    "Color named color"
                    [ Color.aliceBlue ]
                    [ "color" ==> "#f0f8ff"]
                testCase
                    "Color RGB"
                    [ Color.rgb 255 0 0 ]
                    ["color" ==> "rgb(255, 0, 0)"]
                testCase
                    "Color RBGA"
                    [ Color.rgba 255 0 0 0.5 ]
                    ["color" ==> "rgba(255, 0, 0, 0.500000)"]
                testCase
                    "Color HEX no #"
                    [ Color.hex "ff0000" ]
                    ["color" ==> "#ff0000"]
                testCase
                    "Color HEX with alpha"
                    [ Color.hex "#ff000080" ]
                    ["color" ==> "#ff000080"]
                testCase
                    "Color HSL"
                    [ Color.hsl 120 1.0 0.5 ]
                    ["color" ==> "hsl(120, 100%, 50%)"]
                testCase
                    "Color HSLA"
                    [ Color.hsla 120 1.0 0.5 0.5 ]
                    ["color" ==> "hsla(120, 100%, 50%, 50%)"]
                testCase
                    "Color Inherit"
                    [ Color.inherit' ]
                    ["color" ==> "inherit"]
                testCase
                    "Color Initial"
                    [ Color.initial ]
                    ["color" ==> "initial"]
                testCase
                    "Color Unset"
                    [ Color.unset ]
                    ["color" ==> "unset"]
                testCase
                    "Color Value"
                    [Color' (rgb 1 2 3)]
                    ["color"  ==> "rgb(1, 2, 3)"]
            ]