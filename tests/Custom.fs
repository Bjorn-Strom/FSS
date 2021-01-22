namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Custom =
     let tests =
        testList "Custom"
            [
                test
                    "Can set custom border"
                    [Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
                    [ "border" ==> "4mm ridge rgba(170, 50, 220, .6)" ]
            ]