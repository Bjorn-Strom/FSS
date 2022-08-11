namespace FSSTests

open Fet
open Utils
open Fss

module TypographyTests =
     let tests =
        testList "Typography"
            [
                testCase
                    "Orphans number"
                    [ Orphans.value 2]
                    "{orphans:2;}"
                testCase
                    "Orphans inherit"
                    [ Orphans.inherit']
                    "{orphans:inherit;}"
                testCase
                    "Orphans initial"
                    [ Orphans.initial]
                    "{orphans:initial;}"
                testCase
                    "Orphans unset"
                    [ Orphans.unset ]
                    "{orphans:unset;}"
                testCase
                    "Orphans revert"
                    [ Orphans.revert ]
                    "{orphans:revert;}"
                testCase
                    "Widows number"
                    [ Widows.value 2]
                    "{widows:2;}"
                testCase
                    "Widows inherit"
                    [ Widows.inherit']
                    "{widows:inherit;}"
                testCase
                    "Widows initial"
                    [ Widows.initial]
                    "{widows:initial;}"
                testCase
                    "Widows unset"
                    [ Widows.unset ]
                    "{widows:unset;}"
                testCase
                    "Widows revert"
                    [ Widows.revert ]
                    "{widows:revert;}"
            ]
