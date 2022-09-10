namespace FSSTests

open Fet
open Utils
open Fss

module BoxShadowTests =
     let tests =
        testList "BoxShadow"
            [
                testCase
                    "BoxShadow color"
                    [ BoxShadow.value(px 10, px 10, Fss.Types.Color.Blue) ]
                    "{box-shadow:10px 10px blue;}"
                testCase
                    "BoxShadow blur color"
                    [ BoxShadow.value(px 10, px 10, em 1.5, Fss.Types.Color.Red) ]
                    "{box-shadow:10px 10px 1.5em red;}"
                testCase
                    "BoxShadow blur spread color"
                    [ BoxShadow.value(px 1, px 100, vh 1.5, px 1, Fss.Types.Color.Chocolate) ]
                    "{box-shadow:1px 100px 1.5vh 1px chocolate;}"
                testCase
                    "Multiple box shadows"
                    [
                        BoxShadow.value
                            [
                                Fss.Types.BoxShadow.Color(px 10, px 10, Fss.Types.Color.Blue)
                                Fss.Types.BoxShadow.BlurColor(px 10, px 10, px 10, Fss.Types.Color.Blue)
                                Fss.Types.BoxShadow.BlurSpreadColor(px 10, px 10, px 10, px 10, Fss.Types.Color.Blue)
                                Fss.Types.BoxShadow.Color(px 3, px 3, Fss.Types.Color.Red)
                                Fss.Types.BoxShadow.BlurColor(em -1., px 0, em 0.4, Fss.Types.Color.Olive)
                            ]
                    ]
                    "{box-shadow:10px 10px blue,10px 10px 10px blue,10px 10px 10px 10px blue,3px 3px red,-1em 0px 0.4em olive;}"
                testCase
                    "BoxShadow invert"
                    [ BoxShadow.Inset <| Fss.Types.BoxShadow.BlurSpreadColor(px 1, px 100, vh 1.5, px 1, Fss.Types.Color.Chocolate) ]
                    "{box-shadow:inset 1px 100px 1.5vh 1px chocolate;}"
                testCase
                    "BoxShadow initial"
                    [ BoxShadow.initial ]
                    "{box-shadow:initial;}"
                testCase
                    "BoxShadow inherit"
                    [ BoxShadow.inherit' ]
                    "{box-shadow:inherit;}"
                testCase
                    "BoxShadow unset"
                    [ BoxShadow.unset ]
                    "{box-shadow:unset;}"
                testCase
                    "BoxShadow revert"
                    [ BoxShadow.revert ]
                    "{box-shadow:revert;}"
            ]
