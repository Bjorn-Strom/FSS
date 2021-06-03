namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Scroll =
     let tests =
        testList "Scroll"
            [
                testCase
                    "ScrollBehavior auto"
                    [ ScrollBehavior.auto]
                    [ "scrollBehavior" ==> "auto" ]
                testCase
                    "ScrollBehavior smooth"
                    [ ScrollBehavior.smooth]
                    [ "scrollBehavior" ==> "smooth" ]
                testCase
                    "ScrollBehavior inherit"
                    [ ScrollBehavior.inherit']
                    [ "scrollBehavior" ==> "inherit" ]
                testCase
                    "ScrollBehavior initial"
                    [ ScrollBehavior.initial]
                    [ "scrollBehavior" ==> "initial" ]
                testCase
                    "ScrollBehavior unset"
                    [ ScrollBehavior.unset ]
                    [ "scrollBehavior" ==> "unset" ]
                testCase
                    "OverscrollBehaviorX contain"
                    [ OverscrollBehaviorX.contain]
                    [ "overscrollBehaviorX" ==> "contain" ]
                testCase
                    "OverscrollBehaviorX auto"
                    [ OverscrollBehaviorX.auto]
                    [ "overscrollBehaviorX" ==> "auto" ]
                testCase
                    "OverscrollBehaviorX inherit"
                    [ OverscrollBehaviorX.inherit']
                    [ "overscrollBehaviorX" ==> "inherit" ]
                testCase
                    "OverscrollBehaviorX initial"
                    [ OverscrollBehaviorX.initial]
                    [ "overscrollBehaviorX" ==> "initial" ]
                testCase
                    "OverscrollBehaviorX unset"
                    [ OverscrollBehaviorX.unset ]
                    [ "overscrollBehaviorX" ==> "unset" ]
                testCase
                    "OverscrollBehaviorY contain"
                    [ OverscrollBehaviorY.contain]
                    [ "overscrollBehaviorY" ==> "contain" ]
                testCase
                    "OverscrollBehaviorY auto"
                    [ OverscrollBehaviorY.auto]
                    [ "overscrollBehaviorY" ==> "auto" ]
                testCase
                    "OverscrollBehaviorY inherit"
                    [ OverscrollBehaviorY.inherit']
                    [ "overscrollBehaviorY" ==> "inherit" ]
                testCase
                    "OverscrollBehaviorY initial"
                    [ OverscrollBehaviorY.initial]
                    [ "overscrollBehaviorY" ==> "initial" ]
                testCase
                    "OverscrollBehaviorY unset"
                    [ OverscrollBehaviorY.unset ]
                    [ "overscrollBehaviorY" ==> "unset" ]
                testCase
                    "ScrollPadding top px"
                    [ ScrollPaddingTop' (px 10)]
                    ["scrollPaddingTop" ==> "10px"]
                testCase
                    "ScrollPadding right px"
                    [ ScrollPaddingRight' (px 10)]
                    ["scrollPaddingRight" ==> "10px"]
                testCase
                    "ScrollPadding bottom px"
                    [ ScrollPaddingBottom' (px 10)]
                    ["scrollPaddingBottom" ==> "10px"]
                testCase
                    "ScrollPadding left px"
                    [ ScrollPaddingLeft' (px 10)]
                    ["scrollPaddingLeft" ==> "10px"]
                testCase
                    "ScrollPadding px"
                    [ ScrollPadding' (px 10)]
                    [ "scrollPadding" ==> "10px" ]
                testCase
                    "ScrollPadding em"
                    [ ScrollPadding' (em 10.0)]
                    [ "scrollPadding" ==> "10.0em" ]
                testCase
                    "ScrollPadding inherit"
                    [ ScrollPadding.inherit']
                    [ "scrollPadding" ==> "inherit" ]
                testCase
                    "ScrollPadding initial"
                    [ ScrollPadding.initial]
                    [ "scrollPadding" ==> "initial" ]
                testCase
                    "ScrollPadding unset"
                    [ ScrollPadding.unset ]
                    [ "scrollPadding" ==> "unset" ]
                testCase
                    "ScrollPaddings multiple"
                    [ ScrollPadding.value (px 10, px 20, px 30, px 40) ]
                    [ "scrollPadding" ==> "10px 20px 30px 40px" ]
                testCase
                    "ScrollMargin top px"
                    [ ScrollMarginTop' (px 10)]
                    ["scrollMarginTop" ==> "10px"]
                testCase
                    "ScrollMargin right px"
                    [ ScrollMarginRight' (px 10)]
                    ["scrollMarginRight" ==> "10px"]
                testCase
                    "ScrollMargin bottom px"
                    [ ScrollMarginBottom' (px 10)]
                    ["scrollMarginBottom" ==> "10px"]
                testCase
                    "ScrollMargin left px"
                    [ ScrollMarginLeft' (px 10)]
                    ["scrollMarginLeft" ==> "10px"]
                testCase
                    "ScrollMargin px"
                    [ ScrollMargin' (px 10)]
                    [ "scrollMargin" ==> "10px" ]
                testCase
                    "ScrollMargin em"
                    [ ScrollMargin' (em 10.0)]
                    [ "scrollMargin" ==> "10.0em" ]
                testCase
                    "ScrollMargin inherit"
                    [ ScrollMargin.inherit']
                    [ "scrollMargin" ==> "inherit" ]
                testCase
                    "ScrollMargin initial"
                    [ ScrollMargin.initial]
                    [ "scrollMargin" ==> "initial" ]
                testCase
                    "ScrollMargin unset"
                    [ ScrollMargin.unset ]
                    [ "scrollMargin" ==> "unset" ]
                testCase
                    "ScrollMargins multiple"
                    [ ScrollMargin.value (px 10, px 20, px 30, px 40) ]
                    [ "scrollMargin" ==> "10px 20px 30px 40px" ]
                testCase
                    "ScrollSnapType none"
                    [ ScrollSnapType.none ]
                    [ "scrollSnapType" ==> "none" ]
                testCase
                    "ScrollSnapType x"
                    [ ScrollSnapType.x ]
                    [ "scrollSnapType" ==> "x" ]
                testCase
                    "ScrollSnapType y"
                    [ ScrollSnapType.y ]
                    [ "scrollSnapType" ==> "y" ]
                testCase
                    "ScrollSnapType block"
                    [ ScrollSnapType.block ]
                    [ "scrollSnapType" ==> "block" ]
                testCase
                    "ScrollSnapType inline"
                    [ ScrollSnapType.inline' ]
                    [ "scrollSnapType" ==> "inline" ]
                testCase
                    "ScrollSnapType both"
                    [ ScrollSnapType.both ]
                    [ "scrollSnapType" ==> "both" ]
                testCase
                    "ScrollSnapType x mandatory"
                    [ ScrollSnapType' FssTypes.Scroll.SnapType.X FssTypes.Scroll.SnapType.Mandatory ]
                    [ "scrollSnapType" ==> "x mandatory" ]
                testCase
                    "ScrollSnapType x mandatory"
                    [ ScrollSnapType' FssTypes.Scroll.SnapType.Y FssTypes.Scroll.SnapType.Proximity ]
                    [ "scrollSnapType" ==> "y proximity" ]
                testCase
                    "ScrollSnapType both mandatory"
                    [ ScrollSnapType' FssTypes.Scroll.SnapType.Both FssTypes.Scroll.SnapType.Mandatory ]
                    [ "scrollSnapType" ==> "both mandatory" ]
                testCase
                    "ScrollSnapType inherit"
                    [ ScrollSnapType.inherit']
                    [ "scrollSnapType" ==> "inherit" ]
                testCase
                    "ScrollSnapType initial"
                    [ ScrollSnapType.initial]
                    [ "scrollSnapType" ==> "initial" ]
                testCase
                    "ScrollSnapType unset"
                    [ ScrollSnapType.unset ]
                    [ "scrollSnapType" ==> "unset" ]
                testCase
                    "ScrollSnapAlign start end"
                    [ ScrollSnapAlign.value(FssTypes.Scroll.SnapAlign.Start, FssTypes.Scroll.SnapAlign.End)]
                    [ "scrollSnapAlign" ==> "start end" ]
                testCase
                    "ScrollSnapAlign start"
                    [ ScrollSnapAlign.start]
                    [ "scrollSnapAlign" ==> "start" ]
                testCase
                    "ScrollSnapAlign end"
                    [ ScrollSnapAlign.end']
                    [ "scrollSnapAlign" ==> "end" ]
                testCase
                    "ScrollSnapAlign center"
                    [ ScrollSnapAlign.center]
                    [ "scrollSnapAlign" ==> "center" ]
                testCase
                    "ScrollSnapAlign none"
                    [ ScrollSnapAlign.none]
                    [ "scrollSnapAlign" ==> "none" ]
                testCase
                    "ScrollSnapAlign inherit"
                    [ ScrollSnapAlign.inherit' ]
                    [ "scrollSnapAlign" ==> "inherit" ]
                testCase
                    "ScrollSnapAlign initial"
                    [ ScrollSnapAlign.initial]
                    [ "scrollSnapAlign" ==> "initial" ]
                testCase
                    "ScrollSnapAlign unset"
                    [ ScrollSnapAlign.unset ]
                    [ "scrollSnapAlign" ==> "unset" ]
                testCase
                    "ScrollSnapStop normal"
                    [ ScrollSnapStop.normal]
                    [ "scrollSnapStop" ==> "normal" ]
                testCase
                    "ScrollSnapStop always"
                    [ ScrollSnapStop.always]
                    [ "scrollSnapStop" ==> "always" ]
                testCase
                    "ScrollSnapStop inherit"
                    [ ScrollSnapStop.inherit' ]
                    [ "scrollSnapStop" ==> "inherit" ]
                testCase
                    "ScrollSnapStop initial"
                    [ ScrollSnapStop.initial]
                    [ "scrollSnapStop" ==> "initial" ]
                testCase
                    "ScrollSnapStop unset"
                    [ ScrollSnapStop.unset ]
                    [ "scrollSnapStop" ==> "unset" ]
            ]