namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module AspectRatio =
     let tests =
        testList "AspectRatio"
            [
                test
                    "AspectRatio"
                    [ AspectRatio.Value(16, 9) ]
                    [ "aspectRatio" ==> "16 / 9" ]
                test
                    "AspectRatio inherit"
                    [ AspectRatio.Inherit]
                    [ "aspectRatio" ==> "inherit" ]
                test
                    "AspectRatio initial"
                    [ AspectRatio.Initial]
                    [ "aspectRatio" ==> "initial" ]
                test
                    "AspectRatio unset"
                    [ AspectRatio.Unset ]
                    [ "aspectRatio" ==> "unset" ]
            ]