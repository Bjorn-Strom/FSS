namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module All =
     let tests =
        testList "All"
            [
                testCase
                    "All inherit"
                    [ All.inherit']
                    [ "all" ==> "inherit" ]
                testCase
                    "All initial"
                    [ All.initial]
                    [ "all" ==> "initial" ]
                testCase
                    "All unset"
                    [ All.unset ]
                    [ "all" ==> "unset" ]
            ]