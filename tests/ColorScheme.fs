namespace FSSTests

open Fet
open Utils
open Fss

module ColorSchemeTests =
    let tests =
        testList "ColorScheme"
            [
                testCase
                    "color-scheme normal"
                    [ ColorScheme.normal ]
                    "{color-scheme:normal;}"
                testCase
                    "color-scheme light"
                    [ ColorScheme.light ]
                    "{color-scheme:light;}"
                testCase
                    "color-scheme dark"
                    [ ColorScheme.dark ]
                    "{color-scheme:dark;}"
                testCase
                    "color-scheme light dark"
                    [ ColorScheme.lightDark ]
                    "{color-scheme:light dark;}"
                testCase
                    "color-scheme dark light"
                    [ ColorScheme.darkLight ]
                    "{color-scheme:dark light;}"
                testCase
                    "color-scheme only light"
                    [ ColorScheme.onlyLight ]
                    "{color-scheme:only light;}"
                testCase
                    "color-scheme only dark"
                    [ ColorScheme.onlyDark ]
                    "{color-scheme:only dark;}"
                testCase
                    "color-scheme inherit"
                    [ ColorScheme.inherit' ]
                    "{color-scheme:inherit;}"
                testCase
                    "color-scheme initial"
                    [ ColorScheme.initial ]
                    "{color-scheme:initial;}"
                testCase
                    "color-scheme unset"
                    [ ColorScheme.unset ]
                    "{color-scheme:unset;}"
                testCase
                    "color-scheme revert"
                    [ ColorScheme.revert ]
                    "{color-scheme:revert;}"
            ]
