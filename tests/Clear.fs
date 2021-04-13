namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Clear =
     let tests =
        testList "Clear"
            [
                testCase
                    "Clear none"
                    [ Clear.none]
                    [ "clear" ==> "none" ]
                testCase
                    "Clear inherit"
                    [ Clear.inherit']
                    [ "clear" ==> "inherit" ]
                testCase
                    "Clear initial"
                    [ Clear.initial]
                    [ "clear" ==> "initial" ]
                testCase
                    "Clear unset"
                    [ Clear.unset ]
                    [ "clear" ==> "unset" ]
            ]