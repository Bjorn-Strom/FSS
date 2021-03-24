namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module BoxShadow =
     let tests =
        testList "BoxShadow"
            [
                test
                    "BoxShadow color"
                    [
                        BoxShadows
                            [
                                BoxShadow.color(px 10, px 10, FssTypes.Color.blue)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px #0000ff" ]
                test
                    "BoxShadow blur color"
                    [
                        BoxShadows
                            [
                                BoxShadow.blurColor(px 10, px 10, em 1.5, FssTypes.Color.red)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px 1.5em #ff0000" ]
                test
                    "BoxShadow blur spread color"
                    [
                        BoxShadows
                            [
                                BoxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, FssTypes.Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "1px 100px 1.5vh 1px #d2691e" ]
                test
                    "Multiple box shadows"
                    [
                        BoxShadows
                            [
                                BoxShadow.color(px 10, px 10, FssTypes.Color.blue)
                                BoxShadow.blurColor(px 10, px 10, px 10, FssTypes.Color.blue)
                                BoxShadow.blurSpreadColor(px 10, px 10, px 10, px 10, FssTypes.Color.blue)
                                BoxShadow.color(px 3, px 3, FssTypes.Color.red)
                                BoxShadow.blurColor(em -1., px 0, em 0.4, FssTypes.Color.olive)
                            ]
                    ]
                    ["boxShadow" ==> "10px 10px #0000ff, 10px 10px 10px #0000ff, 10px 10px 10px 10px #0000ff, 3px 3px #ff0000, -1.0em 0px 0.4em #808000"]
                test
                    "BoxShadow invert"
                    [
                        BoxShadows
                            [
                                BoxShadow.Inset <| BoxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, FssTypes.Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "inset 1px 100px 1.5vh 1px #d2691e" ]
            ]
