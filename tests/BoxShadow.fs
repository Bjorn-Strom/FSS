namespace FSSTests

open Fet
open Utils
open Fss

module BoxShadow =
     let tests =
        testList "BoxShadow"
            [
                testCase
                    "BoxShadow color"
                    [ BoxShadow.value(px 10, px 10, FssTypes.Color.Blue) ]
                    "box-shadow: 10px 10px blue;"
                testCase
                    "BoxShadow blur color"
                    [ BoxShadow.value(px 10, px 10, em 1.5, FssTypes.Color.Red) ]
                    "box-shadow: 10px 10px 1.5em red;"
                testCase
                    "BoxShadow blur spread color"
                    [ BoxShadow.value(px 1, px 100, vh 1.5, px 1, FssTypes.Color.Chocolate) ]
                    "box-shadow: 1px 100px 1.5vh 1px chocolate;"
                testCase
                    "Multiple box shadows"
                    [
                        BoxShadow.value
                            [
                                FssTypes.BoxShadow.Color(px 10, px 10, FssTypes.Color.Blue)
                                FssTypes.BoxShadow.BlurColor(px 10, px 10, px 10, FssTypes.Color.Blue)
                                FssTypes.BoxShadow.BlurSpreadColor(px 10, px 10, px 10, px 10, FssTypes.Color.Blue)
                                FssTypes.BoxShadow.Color(px 3, px 3, FssTypes.Color.Red)
                                FssTypes.BoxShadow.BlurColor(em -1., px 0, em 0.4, FssTypes.Color.Olive)
                            ]
                    ]
                    "box-shadow: 10px 10px blue, 10px 10px 10px blue, 10px 10px 10px 10px blue, 3px 3px red, -1em 0px 0.4em olive;"
                testCase
                    "BoxShadow invert"
                    [ BoxShadow.Inset <| FssTypes.BoxShadow.BlurSpreadColor(px 1, px 100, vh 1.5, px 1, FssTypes.Color.Chocolate) ]
                    "box-shadow: inset 1px 100px 1.5vh 1px chocolate;"
                testCase
                    "BoxShadow initial"
                    [ BoxShadow.initial ]
                    "box-shadow: initial;"
                testCase
                    "BoxShadow inherit"
                    [ BoxShadow.inherit' ]
                    "box-shadow: inherit;"
                testCase
                    "BoxShadow unset"
                    [ BoxShadow.unset ]
                    "box-shadow: unset;"
                testCase
                    "BoxShadow revert"
                    [ BoxShadow.revert ]
                    "box-shadow: revert;"
            ]
