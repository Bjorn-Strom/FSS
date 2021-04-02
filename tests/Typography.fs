namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Typography =
     let tests =
        testList "Typography"
            [
                testCase
                    "Orphans number"
                    [ Orphans' (FssTypes.CssInt 2)]
                    [ "orphans" ==> "2" ]
                testCase
                    "Orphans inherit"
                    [ Orphans.inherit']
                    [ "orphans" ==> "inherit" ]
                testCase
                    "Orphans initial"
                    [ Orphans.initial]
                    [ "orphans" ==> "initial" ]
                testCase
                    "Orphans unset"
                    [ Orphans.unset ]
                    [ "orphans" ==> "unset" ]
                testCase
                    "Widows number"
                    [ Widows' (FssTypes.CssInt 2)]
                    [ "widows" ==> "2" ]
                testCase
                    "Widows inherit"
                    [ Widows.inherit']
                    [ "widows" ==> "inherit" ]
                testCase
                    "Widows initial"
                    [ Widows.initial]
                    [ "widows" ==> "initial" ]
                testCase
                    "Widows unset"
                    [ Widows.unset ]
                    [ "widows" ==> "unset" ]
            ]