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
                    [ MixBlendMode.Multiply]
                    ["mixBlendMode" ==> "multiply"]
                test
                    "Mix blend mode Screen"
                    [ MixBlendMode.Screen]
                    ["mixBlendMode" ==> "screen"]
                test
                    "Mix blend mode Overlay"
                    [ MixBlendMode.Overlay]
                    ["mixBlendMode" ==> "overlay"]
                test
                    "Mix blend mode Darken"
                    [ MixBlendMode.Darken]
                    ["mixBlendMode" ==> "darken"]
                test
                    "Mix blend mode Lighten"
                    [ MixBlendMode.Lighten]
                    ["mixBlendMode" ==> "lighten"]
                test
                    "Mix blend mode ColorDodge"
                    [ MixBlendMode.ColorDodge]
                    ["mixBlendMode" ==> "color-dodge"]
                test
                    "Mix blend mode ColorBurn"
                    [ MixBlendMode.ColorBurn]
                    ["mixBlendMode" ==> "color-burn"]
                test
                    "Mix blend mode HardLight"
                    [ MixBlendMode.HardLight]
                    ["mixBlendMode" ==> "hard-light"]
                test
                    "Mix blend mode SoftLight"
                    [ MixBlendMode.SoftLight]
                    ["mixBlendMode" ==> "soft-light"]
                test
                    "Mix blend mode Difference"
                    [ MixBlendMode.Difference]
                    ["mixBlendMode" ==> "difference"]
                test
                    "Mix blend mode Exclusion"
                    [ MixBlendMode.Exclusion]
                    ["mixBlendMode" ==> "exclusion"]
                test
                    "Mix blend mode Hue"
                    [ MixBlendMode.Hue]
                    ["mixBlendMode" ==> "hue"]
                test
                    "Mix blend mode Saturation"
                    [ MixBlendMode.Saturation]
                    ["mixBlendMode" ==> "saturation"]
                test
                    "Mix blend mode Color"
                    [ MixBlendMode.Color]
                    ["mixBlendMode" ==> "color"]
                test
                    "Mix blend mode Luminosity"
                    [ MixBlendMode.Luminosity]
                    ["mixBlendMode" ==> "luminosity"]
                test
                    "mix blend mode normal"
                    [ MixBlendMode.Normal ]
                    [ "mixBlendMode" ==> "normal" ]
                test
                    "mix blend mode inherit"
                    [ MixBlendMode.Inherit ]
                    [ "mixBlendMode" ==> "inherit" ]
                test
                    "mix blend mode initial"
                    [ MixBlendMode.Initial ]
                    [ "mixBlendMode" ==> "initial" ]
                test
                    "mix blend mode unset"
                    [ MixBlendMode.Unset ]
                    [ "mixBlendMode" ==> "unset" ]
            ]
