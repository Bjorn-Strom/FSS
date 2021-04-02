namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module AspectRatio =
     let tests =
        testList "AspectRatio"
            [
                testCase
                    "AspectRatio"
                    [ AspectRatio.value(16, 9) ]
                    [ "aspectRatio" ==> "16 / 9" ]
                testCase
                    "AspectRatio inherit"
                    [ AspectRatio.inherit']
                    [ "aspectRatio" ==> "inherit" ]
                testCase
                    "AspectRatio initial"
                    [ AspectRatio.initial]
                    [ "aspectRatio" ==> "initial" ]
                testCase
                    "AspectRatio unset"
                    [ AspectRatio.unset ]
                    [ "aspectRatio" ==> "unset" ]
            ]