namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Typography =
     let tests =
        testList "Typography"
            [
                test
                    "Orphans number"
                    [ Orphans' (FssTypes.CssInt 2)]
                    [ "orphans" ==> "2" ]
                test
                    "Orphans inherit"
                    [ Orphans.inherit']
                    [ "orphans" ==> "inherit" ]
                test
                    "Orphans initial"
                    [ Orphans.initial]
                    [ "orphans" ==> "initial" ]
                test
                    "Orphans unset"
                    [ Orphans.unset ]
                    [ "orphans" ==> "unset" ]
                test
                    "Widows number"
                    [ Widows' (FssTypes.CssInt 2)]
                    [ "widows" ==> "2" ]
                test
                    "Widows inherit"
                    [ Widows.inherit']
                    [ "widows" ==> "inherit" ]
                test
                    "Widows initial"
                    [ Widows.initial]
                    [ "widows" ==> "initial" ]
                test
                    "Widows unset"
                    [ Widows.unset ]
                    [ "widows" ==> "unset" ]
            ]