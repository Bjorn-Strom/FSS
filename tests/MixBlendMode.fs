namespace FSSTests

open Fet
open Utils
open Fss

module MixBlendMode =
     let tests =
        testList "MixBlendMode"
            [
                testCase
                    "Mix blend mode Multiply"
                    [ MixBlendMode.multiply]
                    "mix-blend-mode: multiply;"
                testCase
                    "Mix blend mode Screen"
                    [ MixBlendMode.screen]
                    "mix-blend-mode: screen;"
                testCase
                    "Mix blend mode Overlay"
                    [ MixBlendMode.overlay]
                    "mix-blend-mode: overlay;"
                testCase
                    "Mix blend mode Darken"
                    [ MixBlendMode.darken]
                    "mix-blend-mode: darken;"
                testCase
                    "Mix blend mode Lighten"
                    [ MixBlendMode.lighten]
                    "mix-blend-mode: lighten;"
                testCase
                    "Mix blend mode ColorDodge"
                    [ MixBlendMode.colorDodge]
                    "mix-blend-mode: color-dodge;"
                testCase
                    "Mix blend mode ColorBurn"
                    [ MixBlendMode.colorBurn]
                    "mix-blend-mode: color-burn;"
                testCase
                    "Mix blend mode HardLight"
                    [ MixBlendMode.hardLight]
                    "mix-blend-mode: hard-light;"
                testCase
                    "Mix blend mode SoftLight"
                    [ MixBlendMode.softLight]
                    "mix-blend-mode: soft-light;"
                testCase
                    "Mix blend mode Difference"
                    [ MixBlendMode.difference]
                    "mix-blend-mode: difference;"
                testCase
                    "Mix blend mode Exclusion"
                    [ MixBlendMode.exclusion]
                    "mix-blend-mode: exclusion;"
                testCase
                    "Mix blend mode Hue"
                    [ MixBlendMode.hue]
                    "mix-blend-mode: hue;"
                testCase
                    "Mix blend mode Saturation"
                    [ MixBlendMode.saturation]
                    "mix-blend-mode: saturation;"
                testCase
                    "Mix blend mode Color"
                    [ MixBlendMode.color]
                    "mix-blend-mode: color;"
                testCase
                    "Mix blend mode Luminosity"
                    [ MixBlendMode.luminosity]
                    "mix-blend-mode: luminosity;"
                testCase
                    "mix blend mode normal"
                    [ MixBlendMode.normal ]
                     "mix-blend-mode: normal;" 
                testCase
                    "mix blend mode inherit"
                    [ MixBlendMode.inherit' ]
                     "mix-blend-mode: inherit;" 
                testCase
                    "mix blend mode initial"
                    [ MixBlendMode.initial ]
                     "mix-blend-mode: initial;" 
                testCase
                    "mix blend mode unset"
                    [ MixBlendMode.unset ]
                     "mix-blend-mode: unset;" 
                testCase
                    "mix blend mode revert"
                    [ MixBlendMode.revert ]
                     "mix-blend-mode: revert;" 
            ]
