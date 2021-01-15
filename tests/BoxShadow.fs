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
                    [ BoxShadow.Color(px 10, px 10, CssColor.blue)]
                    [ "boxShadow" ==> "10px 10px #0000ff" ]
                test
                    "BoxShadow blur color"
                    [ BoxShadow.BlurColor(px 10, px 10, em 1.5, CssColor.red)]
                    [ "boxShadow" ==> "10px 10px 1.5em #ff0000" ]
                test
                    "BoxShadow blur spread color"
                    [ BoxShadow.BlurSpreadColor(px 1, px 100, vh 1.5, px 1, CssColor.chocolate)]
                    [ "boxShadow" ==> "1px 100px 1.5vh 1px #d2691e" ]
                test
                    "Multiple box shadows"
                    [
                        BoxShadow.Values(
                            [
                                BoxShadowType.Color(px 10, px 10, CssColor.blue)
                                BoxShadowType.BlurColor(px 10, px 10, px 10, CssColor.blue)
                                BoxShadowType.BlurSpreadColor(px 10, px 10, px 10, px 10, CssColor.blue)
                                BoxShadowType.Color(px 3, px 3, CssColor.red)
                                BoxShadowType.BlurColor(em -1., px 0, em 0.4, CssColor.olive)
                            ])
                    ]
                    ["boxShadow" ==> "10px 10px #0000ff, 10px 10px 10px #0000ff, 10px 10px 10px 10px #0000ff, 3px 3px #ff0000, -1.0em 0px 0.4em #808000"]
                test
                    "BoxShadow none"
                    [ BoxShadow.None]
                    [ "boxShadow" ==> "none" ]
                test
                    "BoxShadow inherit"
                    [ BoxShadow.Inherit]
                    [ "boxShadow" ==> "inherit" ]
                test
                    "BoxShadow initial"
                    [ BoxShadow.Initial]
                    [ "boxShadow" ==> "initial" ]
                test
                    "BoxShadow unset"
                    [ BoxShadow.Unset ]
                    [ "boxShadow" ==> "unset" ]
            ]