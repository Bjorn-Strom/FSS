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
                    [ Clear.none]
                    [ "clear" ==> "none" ]
                test
                    "Clear inherit"
                    [ Clear.inherit']
                    [ "clear" ==> "inherit" ]
                test
                    "Clear initial"
                    [ Clear.initial]
                    [ "clear" ==> "initial" ]
                test
                    "Clear unset"
                    [ Clear.unset ]
                    [ "clear" ==> "unset" ]
            ]