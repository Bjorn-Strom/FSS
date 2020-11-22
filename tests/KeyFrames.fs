namespace FSSTests

open Fable.Mocha
open Fss
open Utils

module Keyframes =
    let tests =
        let animationSample =
                [
                    frame 0
                        [
                            BackgroundColor.red
                            Color.blue
                        ]
                    frame 100
                        [
                            BackgroundColor.blue
                            Color.red
                        ]
                ]

        let multipleKeyframes =
            [
                frame 0
                    [
                        BackgroundColor.Hex "00FF00"
                        BackgroundSize' (px 2)
                    ]
                frame 50
                    [
                        Opacity' 0.
                    ]
                frame 100
                    [
                        BorderWidth' (px 5)
                        BackgroundColor.Rgb 11 22 33
                    ]
            ]

        testList "Keyframes"
            [
                testKeyframes
                    "Animation with 2 keyframes"
                    animationSample
                    [
                        "0% backgroundColor, #ff0000,color, #0000ff"
                        "100% backgroundColor, #0000ff,color, #ff0000"
                    ]

                testKeyframes
                    "Animation with multiple keyframes"
                    multipleKeyframes
                    [
                        "0% backgroundColor, #00FF00,backgroundSize, 2px"
                        "50% opacity, 0"
                        "100% borderWidth, 5px,backgroundColor, rgb(11, 22, 33)"
                    ]
            ]
