namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module MixBlendMode =
     let tests =
        testList "MixBlendMode"
            [
                test
                    "Mix blend mode Multiply"
                    [ MixBlendMode.multiply]
                    ["mixBlendMode" ==> "multiply"]
                test
                    "Mix blend mode Screen"
                    [ MixBlendMode.screen]
                    ["mixBlendMode" ==> "screen"]
                test
                    "Mix blend mode Overlay"
                    [ MixBlendMode.overlay]
                    ["mixBlendMode" ==> "overlay"]
                test
                    "Mix blend mode Darken"
                    [ MixBlendMode.darken]
                    ["mixBlendMode" ==> "darken"]
                test
                    "Mix blend mode Lighten"
                    [ MixBlendMode.lighten]
                    ["mixBlendMode" ==> "lighten"]
                test
                    "Mix blend mode ColorDodge"
                    [ MixBlendMode.colorDodge]
                    ["mixBlendMode" ==> "color-dodge"]
                test
                    "Mix blend mode ColorBurn"
                    [ MixBlendMode.colorBurn]
                    ["mixBlendMode" ==> "color-burn"]
                test
                    "Mix blend mode HardLight"
                    [ MixBlendMode.hardLight]
                    ["mixBlendMode" ==> "hard-light"]
                test
                    "Mix blend mode SoftLight"
                    [ MixBlendMode.softLight]
                    ["mixBlendMode" ==> "soft-light"]
                test
                    "Mix blend mode Difference"
                    [ MixBlendMode.difference]
                    ["mixBlendMode" ==> "difference"]
                test
                    "Mix blend mode Exclusion"
                    [ MixBlendMode.exclusion]
                    ["mixBlendMode" ==> "exclusion"]
                test
                    "Mix blend mode Hue"
                    [ MixBlendMode.hue]
                    ["mixBlendMode" ==> "hue"]
                test
                    "Mix blend mode Saturation"
                    [ MixBlendMode.saturation]
                    ["mixBlendMode" ==> "saturation"]
                test
                    "Mix blend mode Color"
                    [ MixBlendMode.color]
                    ["mixBlendMode" ==> "color"]
                test
                    "Mix blend mode Luminosity"
                    [ MixBlendMode.luminosity]
                    ["mixBlendMode" ==> "luminosity"]
                test
                    "mix blend mode normal"
                    [ MixBlendMode.normal ]
                    [ "mixBlendMode" ==> "normal" ]
                test
                    "mix blend mode inherit"
                    [ MixBlendMode.inherit' ]
                    [ "mixBlendMode" ==> "inherit" ]
                test
                    "mix blend mode initial"
                    [ MixBlendMode.initial ]
                    [ "mixBlendMode" ==> "initial" ]
                test
                    "mix blend mode unset"
                    [ MixBlendMode.unset ]
                    [ "mixBlendMode" ==> "unset" ]
            ]
