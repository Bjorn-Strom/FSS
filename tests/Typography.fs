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
                    [ Orphans.Inherit]
                    [ "orphans" ==> "inherit" ]
                test
                    "Orphans initial"
                    [ Orphans.Initial]
                    [ "orphans" ==> "initial" ]
                test
                    "Orphans unset"
                    [ Orphans.Unset ]
                    [ "orphans" ==> "unset" ]
                test
                    "Widows number"
                    [ Widows' (FssTypes.CssInt 2)]
                    [ "widows" ==> "2" ]
                test
                    "Widows inherit"
                    [ Widows.Inherit]
                    [ "widows" ==> "inherit" ]
                test
                    "Widows initial"
                    [ Widows.Initial]
                    [ "widows" ==> "initial" ]
                test
                    "Widows unset"
                    [ Widows.Unset ]
                    [ "widows" ==> "unset" ]
            ]