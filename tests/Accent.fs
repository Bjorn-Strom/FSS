namespace FSSTests

open Fet
open Utils
open Fss

module AccentTests =
    let tests =
        testList "Accent"
            [
                testCase
                    "accent-color auto"
                    [ AccentColor.auto ]
                    "{accent-color:auto;}"
                testCase
                    "accent-color red"
                    [ AccentColor.red ]
                    "{accent-color:red;}"
                testCase
                    "accent-color green"
                    [ AccentColor.green ]
                    "{accent-color:green;}"
                testCase
                    "accent-color blue"
                    [ AccentColor.blue ]
                    "{accent-color:blue;}"
                testCase
                    "accent-color rgb"
                    [ AccentColor.rgb 100 200 50 ]
                    "{accent-color:rgb(100,200,50);}"
                testCase
                    "accent-color rgba"
                    [ AccentColor.rgba 100 200 50 0.5 ]
                    "{accent-color:rgba(100,200,50,0.5);}"
                testCase
                    "accent-color hex"
                    [ AccentColor.hex "ff6347" ]
                    "{accent-color:#ff6347;}"
                testCase
                    "accent-color hsl"
                    [ AccentColor.hsl 120 50 50 ]
                    "{accent-color:hsl(120,50%,50%);}"
                testCase
                    "accent-color hsla"
                    [ AccentColor.hsla 120 50 50 0.8 ]
                    "{accent-color:hsla(120,50%,50%,0.8);}"
                testCase
                    "accent-color transparent"
                    [ AccentColor.transparent ]
                    "{accent-color:transparent;}"
                testCase
                    "accent-color currentColor"
                    [ AccentColor.currentColor ]
                    "{accent-color:currentcolor;}"
                testCase
                    "accent-color inherit"
                    [ AccentColor.inherit' ]
                    "{accent-color:inherit;}"
                testCase
                    "accent-color initial"
                    [ AccentColor.initial ]
                    "{accent-color:initial;}"
                testCase
                    "accent-color unset"
                    [ AccentColor.unset ]
                    "{accent-color:unset;}"
                testCase
                    "accent-color revert"
                    [ AccentColor.revert ]
                    "{accent-color:revert;}"
            ]
