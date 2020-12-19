namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Padding =
     let tests =
        testList "Padding"
            [
                test
                    "Padding top px"
                    [ PaddingTop' (px 10)]
                    ["paddingTop" ==> "10px"]
                test
                    "Padding right px"
                    [ PaddingRight' (px 10)]
                    ["paddingRight" ==> "10px"]
                test
                    "Padding bottom px"
                    [ PaddingBottom' (px 10)]
                    ["paddingBottom" ==> "10px"]
                test
                    "Padding left px"
                    [ PaddingLeft' (px 10)]
                    ["paddingLeft" ==> "10px"]
                test
                    "Padding px"
                    [ Padding' (px 10)]
                    [ "padding" ==> "10px" ]
                test
                    "Padding pct"
                    [ Padding' (pct 10)]
                    [ "padding" ==> "10%" ]
                test
                    "Padding em"
                    [ Padding' (em 10.0)]
                    [ "padding" ==> "10.0em" ]
                test
                    "Padding auto"
                    [ Padding.Auto]
                    [ "padding" ==> "auto" ]
                test
                    "Padding inherit"
                    [ Padding.Inherit]
                    [ "padding" ==> "inherit" ]
                test
                    "Padding initial"
                    [ Padding.Initial]
                    [ "padding" ==> "initial" ]
                test
                    "Padding unset"
                    [ Padding.Unset ]
                    [ "padding" ==> "unset" ]
                test
                    "Paddings multiple"
                    [ Padding.Value (px 10, px 20, px 30, px 40) ]
                    [ "padding" ==> "10px 20px 30px 40px" ]
                test
                    "ScrollPadding top px"
                    [ ScrollPaddingTop' (px 10)]
                    ["scrollPaddingTop" ==> "10px"]
                test
                    "ScrollPadding right px"
                    [ ScrollPaddingRight' (px 10)]
                    ["scrollPaddingRight" ==> "10px"]
                test
                    "ScrollPadding bottom px"
                    [ ScrollPaddingBottom' (px 10)]
                    ["scrollPaddingBottom" ==> "10px"]
                test
                    "ScrollPadding left px"
                    [ ScrollPaddingLeft' (px 10)]
                    ["scrollPaddingLeft" ==> "10px"]
                test
                    "ScrollPadding px"
                    [ ScrollPadding' (px 10)]
                    [ "scrollPadding" ==> "10px" ]
                test
                    "ScrollPadding em"
                    [ ScrollPadding' (em 10.0)]
                    [ "scrollPadding" ==> "10.0em" ]
                test
                    "ScrollPadding inherit"
                    [ ScrollPadding.Inherit]
                    [ "scrollPadding" ==> "inherit" ]
                test
                    "ScrollPadding initial"
                    [ ScrollPadding.Initial]
                    [ "scrollPadding" ==> "initial" ]
                test
                    "ScrollPadding unset"
                    [ ScrollPadding.Unset ]
                    [ "scrollPadding" ==> "unset" ]
                test
                    "ScrollPaddings multiple"
                    [ ScrollPadding.Value (px 10, px 20, px 30, px 40) ]
                    [ "scrollPadding" ==> "10px 20px 30px 40px" ]
            ]