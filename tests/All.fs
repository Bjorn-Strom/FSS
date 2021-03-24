namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module All =
     let tests =
        testList "All"
            [
                test
                    "All inherit"
                    [ All.inherit']
                    [ "all" ==> "inherit" ]
                test
                    "All initial"
                    [ All.initial]
                    [ "all" ==> "initial" ]
                test
                    "All unset"
                    [ All.unset ]
                    [ "all" ==> "unset" ]
            ]