namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Clear =
     let tests =
        testList "Clear"
            [
                test
                    "Clear none"
                    [ Clear.None]
                    [ "clear" ==> "none" ]
                test
                    "Clear inherit"
                    [ Clear.Inherit]
                    [ "clear" ==> "inherit" ]
                test
                    "Clear initial"
                    [ Clear.Initial]
                    [ "clear" ==> "initial" ]
                test
                    "Clear unset"
                    [ Clear.Unset ]
                    [ "clear" ==> "unset" ]
            ]