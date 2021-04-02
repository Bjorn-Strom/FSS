namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module MixBlendMode =
     let tests =
        testList "MixBlendMode"
            [
                testCase
                    "Mix blend mode Multiply"
                    [ MixBlendMode.multiply]
                    ["mixBlendMode" ==> "multiply"]
                testCase
                    "Mix blend mode Screen"
                    [ MixBlendMode.screen]
                    ["mixBlendMode" ==> "screen"]
                testCase
                    "Mix blend mode Overlay"
                    [ MixBlendMode.overlay]
                    ["mixBlendMode" ==> "overlay"]
                testCase
                    "Mix blend mode Darken"
                    [ MixBlendMode.darken]
                    ["mixBlendMode" ==> "darken"]
                testCase
                    "Mix blend mode Lighten"
                    [ MixBlendMode.lighten]
                    ["mixBlendMode" ==> "lighten"]
                testCase
                    "Mix blend mode ColorDodge"
                    [ MixBlendMode.colorDodge]
                    ["mixBlendMode" ==> "color-dodge"]
                testCase
                    "Mix blend mode ColorBurn"
                    [ MixBlendMode.colorBurn]
                    ["mixBlendMode" ==> "color-burn"]
                testCase
                    "Mix blend mode HardLight"
                    [ MixBlendMode.hardLight]
                    ["mixBlendMode" ==> "hard-light"]
                testCase
                    "Mix blend mode SoftLight"
                    [ MixBlendMode.softLight]
                    ["mixBlendMode" ==> "soft-light"]
                testCase
                    "Mix blend mode Difference"
                    [ MixBlendMode.difference]
                    ["mixBlendMode" ==> "difference"]
                testCase
                    "Mix blend mode Exclusion"
                    [ MixBlendMode.exclusion]
                    ["mixBlendMode" ==> "exclusion"]
                testCase
                    "Mix blend mode Hue"
                    [ MixBlendMode.hue]
                    ["mixBlendMode" ==> "hue"]
                testCase
                    "Mix blend mode Saturation"
                    [ MixBlendMode.saturation]
                    ["mixBlendMode" ==> "saturation"]
                testCase
                    "Mix blend mode Color"
                    [ MixBlendMode.color]
                    ["mixBlendMode" ==> "color"]
                testCase
                    "Mix blend mode Luminosity"
                    [ MixBlendMode.luminosity]
                    ["mixBlendMode" ==> "luminosity"]
                testCase
                    "mix blend mode normal"
                    [ MixBlendMode.normal ]
                    [ "mixBlendMode" ==> "normal" ]
                testCase
                    "mix blend mode inherit"
                    [ MixBlendMode.inherit' ]
                    [ "mixBlendMode" ==> "inherit" ]
                testCase
                    "mix blend mode initial"
                    [ MixBlendMode.initial ]
                    [ "mixBlendMode" ==> "initial" ]
                testCase
                    "mix blend mode unset"
                    [ MixBlendMode.unset ]
                    [ "mixBlendMode" ==> "unset" ]
            ]
