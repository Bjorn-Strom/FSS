namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module BoxShadow =
     let tests =
        testList "BoxShadow"
            [
                testCase
                    "BoxShadow color"
                    [
                        BoxShadows
                            [
                                BoxShadow.color(px 10, px 10, FssTypes.Color.Color.blue)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px #0000ff" ]
                testCase
                    "BoxShadow blur color"
                    [
                        BoxShadows
                            [
                                BoxShadow.blurColor(px 10, px 10, em 1.5, FssTypes.Color.Color.red)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px 1.5em #ff0000" ]
                testCase
                    "BoxShadow blur spread color"
                    [
                        BoxShadows
                            [
                                BoxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, FssTypes.Color.Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "1px 100px 1.5vh 1px #d2691e" ]
                testCase
                    "Multiple box shadows"
                    [
                        BoxShadows
                            [
                                BoxShadow.color(px 10, px 10, FssTypes.Color.Color.blue)
                                BoxShadow.blurColor(px 10, px 10, px 10, FssTypes.Color.Color.blue)
                                BoxShadow.blurSpreadColor(px 10, px 10, px 10, px 10, FssTypes.Color.Color.blue)
                                BoxShadow.color(px 3, px 3, FssTypes.Color.Color.red)
                                BoxShadow.blurColor(em -1., px 0, em 0.4, FssTypes.Color.Color.olive)
                            ]
                    ]
                    ["boxShadow" ==> "10px 10px #0000ff, 10px 10px 10px #0000ff, 10px 10px 10px 10px #0000ff, 3px 3px #ff0000, -1.0em 0px 0.4em #808000"]
                testCase
                    "BoxShadow invert"
                    [
                        BoxShadows
                            [
                                BoxShadow.Inset <| BoxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, FssTypes.Color.Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "inset 1px 100px 1.5vh 1px #d2691e" ]
            ]
