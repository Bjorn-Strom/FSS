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
                    [ AspectRatio.value(16, 9) ]
                    [ "aspectRatio" ==> "16 / 9" ]
                test
                    "AspectRatio inherit"
                    [ AspectRatio.inherit']
                    [ "aspectRatio" ==> "inherit" ]
                test
                    "AspectRatio initial"
                    [ AspectRatio.initial]
                    [ "aspectRatio" ==> "initial" ]
                test
                    "AspectRatio unset"
                    [ AspectRatio.unset ]
                    [ "aspectRatio" ==> "unset" ]
            ]