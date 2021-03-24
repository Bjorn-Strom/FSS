namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Color =
    let tests =
        testList "Colors"
            [
                test
                    "Color adjust exact"
                    [ColorAdjust.exact]
                    ["colorAdjust" ==> "exact"]
                test
                    "Color adjust economy"
                    [ColorAdjust.economy]
                    ["colorAdjust" ==> "economy"]
                test
                    "Color named color"
                    [ Color.aliceBlue ]
                    [ "color" ==> "#f0f8ff"]
                test
                    "Color RGB"
                    [ Color.rgb 255 0 0 ]
                    ["color" ==> "rgb(255, 0, 0)"]
                test
                    "Color RBGA"
                    [ Color.rgba 255 0 0 0.5 ]
                    ["color" ==> "rgba(255, 0, 0, 0.500000)"]
                test
                    "Color HEX no #"
                    [ Color.hex "ff0000" ]
                    ["color" ==> "#ff0000"]
                test
                    "Color HEX with alpha"
                    [ Color.hex "#ff000080" ]
                    ["color" ==> "#ff000080"]
                test
                    "Color HSL"
                    [ Color.hsl 120 1.0 0.5 ]
                    ["color" ==> "hsl(120, 100%, 50%)"]
                test
                    "Color HSLA"
                    [ Color.hsla 120 1.0 0.5 0.5 ]
                    ["color" ==> "hsla(120, 100%, 50%, 50%)"]
                test
                    "Color Inherit"
                    [ Color.inherit' ]
                    ["color" ==> "inherit"]
                test
                    "Color Initial"
                    [ Color.initial ]
                    ["color" ==> "initial"]
                test
                    "Color Unset"
                    [ Color.unset ]
                    ["color" ==> "unset"]
                test
                    "Color Value"
                    [Color' (rgb 1 2 3)]
                    ["color"  ==> "rgb(1, 2, 3)"]
            ]