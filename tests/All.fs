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
                    [ All.Inherit]
                    [ "all" ==> "inherit" ]
                test
                    "All initial"
                    [ All.Initial]
                    [ "all" ==> "initial" ]
                test
                    "All unset"
                    [ All.Unset ]
                    [ "all" ==> "unset" ]
            ]