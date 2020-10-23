namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss
open Fss.Keyframes

module Keyframes =
    let tests =
        let animationSample =
                [
                    frame 0 [ BackgroundColor Color.red ]
                    frame 100 [ BackgroundColor Color.blue ]
                ]

        testList "Keyframes"
            [
                testKeyframes
                    ""
                    animationSample
                    ["" ==> ""]
            ]
