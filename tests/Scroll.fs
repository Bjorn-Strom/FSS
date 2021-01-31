namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Scroll =
     let tests =
        testList "Scroll"
            [
                test
                    "ScrollBehavior auto"
                    [ ScrollBehavior.Auto]
                    [ "scrollBehavior" ==> "auto" ]
                test
                    "ScrollBehavior smooth"
                    [ ScrollBehavior.Smooth]
                    [ "scrollBehavior" ==> "smooth" ]
                test
                    "ScrollBehavior inherit"
                    [ ScrollBehavior.Inherit]
                    [ "scrollBehavior" ==> "inherit" ]
                test
                    "ScrollBehavior initial"
                    [ ScrollBehavior.Initial]
                    [ "scrollBehavior" ==> "initial" ]
                test
                    "ScrollBehavior unset"
                    [ ScrollBehavior.Unset ]
                    [ "scrollBehavior" ==> "unset" ]
                test
                    "OverscrollBehaviorX contain"
                    [ OverscrollBehaviorX.Contain]
                    [ "overscrollBehaviorX" ==> "contain" ]
                test
                    "OverscrollBehaviorX auto"
                    [ OverscrollBehaviorX.Auto]
                    [ "overscrollBehaviorX" ==> "auto" ]
                test
                    "OverscrollBehaviorX inherit"
                    [ OverscrollBehaviorX.Inherit]
                    [ "overscrollBehaviorX" ==> "inherit" ]
                test
                    "OverscrollBehaviorX initial"
                    [ OverscrollBehaviorX.Initial]
                    [ "overscrollBehaviorX" ==> "initial" ]
                test
                    "OverscrollBehaviorX unset"
                    [ OverscrollBehaviorX.Unset ]
                    [ "overscrollBehaviorX" ==> "unset" ]
                test
                    "OverscrollBehaviorY contain"
                    [ OverscrollBehaviorY.Contain]
                    [ "overscrollBehaviorY" ==> "contain" ]
                test
                    "OverscrollBehaviorY auto"
                    [ OverscrollBehaviorY.Auto]
                    [ "overscrollBehaviorY" ==> "auto" ]
                test
                    "OverscrollBehaviorY inherit"
                    [ OverscrollBehaviorY.Inherit]
                    [ "overscrollBehaviorY" ==> "inherit" ]
                test
                    "OverscrollBehaviorY initial"
                    [ OverscrollBehaviorY.Initial]
                    [ "overscrollBehaviorY" ==> "initial" ]
                test
                    "OverscrollBehaviorY unset"
                    [ OverscrollBehaviorY.Unset ]
                    [ "overscrollBehaviorY" ==> "unset" ]
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
                test
                    "ScrollMargin top px"
                    [ ScrollMarginTop' (px 10)]
                    ["scrollMarginTop" ==> "10px"]
                test
                    "ScrollMargin right px"
                    [ ScrollMarginRight' (px 10)]
                    ["scrollMarginRight" ==> "10px"]
                test
                    "ScrollMargin bottom px"
                    [ ScrollMarginBottom' (px 10)]
                    ["scrollMarginBottom" ==> "10px"]
                test
                    "ScrollMargin left px"
                    [ ScrollMarginLeft' (px 10)]
                    ["scrollMarginLeft" ==> "10px"]
                test
                    "ScrollMargin px"
                    [ ScrollMargin' (px 10)]
                    [ "scrollMargin" ==> "10px" ]
                test
                    "ScrollMargin em"
                    [ ScrollMargin' (em 10.0)]
                    [ "scrollMargin" ==> "10.0em" ]
                test
                    "ScrollMargin inherit"
                    [ ScrollMargin.Inherit]
                    [ "scrollMargin" ==> "inherit" ]
                test
                    "ScrollMargin initial"
                    [ ScrollMargin.Initial]
                    [ "scrollMargin" ==> "initial" ]
                test
                    "ScrollMargin unset"
                    [ ScrollMargin.Unset ]
                    [ "scrollMargin" ==> "unset" ]
                test
                    "ScrollMargins multiple"
                    [ ScrollMargin.Value (px 10, px 20, px 30, px 40) ]
                    [ "scrollMargin" ==> "10px 20px 30px 40px" ]
            ]