namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                test
                    "Visibility hidden"
                    [ Visibility Visibility.Hidden]
                    ["visibility" ==> "hidden"]

                test
                    "Visibility collapse"
                    [ Visibility Visibility.Collapse]
                    ["visibility" ==> "collapse"]

                test
                    "Visibility visible"
                    [ Visibility Visibility.Visible]
                    ["visibility" ==> "visible"]

                test
                    "Opacity 1"
                    [ Opacity (Opacity.Opacity 1.0) ]
                    ["opacity" ==> "1"]

                test
                    "Opacity 0"
                    [ Opacity (Opacity.Opacity 0.0)]
                    ["opacity" ==> "0"]

                test
                    "Opacity 50%"
                    [ Opacity (Opacity.Opacity 0.5)]
                    ["opacity" ==> "0.5"]

                test
                    "Opacity -10 should be 0"
                    [ Opacity (Opacity.Opacity -10.0)]
                    ["opacity" ==> "0"]

                test
                    "Opacity 10 should be 1"
                    [ Opacity (Opacity.Opacity 10.0)]
                    ["opacity" ==> "1"]

                test
                    "Opacity 1.5 should be 1"
                    [ Opacity (Opacity.Opacity 1.5)]
                    ["opacity" ==> "1"]
        ]