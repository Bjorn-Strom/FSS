namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                testCase
                    "Paint order normal"
                    [PaintOrder.normal]
                    ["paintOrder" ==> "normal"]
                testCase
                    "Paint order stroke"
                    [PaintOrder.stroke]
                    ["paintOrder" ==> "stroke"]
                testCase
                    "Paint order markers"
                    [PaintOrder.markers]
                    ["paintOrder" ==> "markers"]
                testCase
                    "Paint order stroke fill"
                    [PaintOrder.value(FssTypes.Visibility.PaintOrder.Stroke, FssTypes.Visibility.PaintOrder.Fill)]
                    ["paintOrder" ==> "stroke fill"]
                testCase
                    "Paint order markers stroke fill"
                    [PaintOrder.value(FssTypes.Visibility.PaintOrder.Markers, FssTypes.Visibility.PaintOrder.Stroke, FssTypes.Visibility.PaintOrder.Fill)]
                    ["paintOrder" ==> "markers stroke fill"]
                testCase
                    "Paint order normal"
                    [PaintOrder.normal]
                    ["paintOrder" ==> "normal"]

                testCase
                    "Visibility hidden"
                    [ Visibility.hidden]
                    ["visibility" ==> "hidden"]
                testCase
                    "Visibility collapse"
                    [ Visibility.collapse]
                    ["visibility" ==> "collapse"]
                testCase
                    "Visibility visible"
                    [ Visibility.visible]
                    ["visibility" ==> "visible"]
                testCase
                    "Opacity 1"
                    [ Opacity' 1.0 ]
                    ["opacity" ==> "1"]
                testCase
                    "Opacity 0"
                    [ Opacity' 0.0]
                    ["opacity" ==> "0"]
                testCase
                    "Opacity 50%"
                    [ Opacity' 0.5 ]
                    ["opacity" ==> "0.5"]
                testCase
                    "Opacity -10 should be 0"
                    [ Opacity' -10.0 ]
                    ["opacity" ==> "0"]
                testCase
                    "Opacity 10 should be 1"
                    [ Opacity' 10.0 ]
                    ["opacity" ==> "1"]
                testCase
                    "Opacity 1.5 should be 1"
                    [ Opacity' 1.5 ]
                    ["opacity" ==> "1"]
                testCase
                    "Overflow-X visible"
                    [OverflowX.visible]
                    ["overflowX" ==> "visible"]
                testCase
                    "Overflow-X hidden"
                    [OverflowX.hidden]
                    ["overflowX" ==> "hidden"]
                testCase
                    "Overflow-X Clip"
                    [OverflowX.clip]
                    ["overflowX" ==> "clip"]
                testCase
                    "Overflow-X Scroll"
                    [OverflowX.scroll]
                    ["overflowX" ==> "scroll"]
                testCase
                    "Overflow-X Auto"
                    [OverflowX.auto]
                    ["overflowX" ==> "auto"]
                testCase
                    "Overflow-X inherit"
                    [OverflowX.inherit']
                    ["overflowX" ==> "inherit"]
                testCase
                    "Overflow-X initial"
                    [OverflowX.initial]
                    ["overflowX" ==> "initial"]
                testCase
                    "Overflow-X unset"
                    [OverflowX.unset]
                    ["overflowX" ==> "unset"]
                testCase
                    "OverflowY visible"
                    [OverflowY.visible]
                    ["overflowY" ==> "visible"]
                testCase
                    "OverflowY hidden"
                    [OverflowY.hidden]
                    ["overflowY" ==> "hidden"]
                testCase
                    "OverflowY Clip"
                    [OverflowY.clip]
                    ["overflowY" ==> "clip"]
                testCase
                    "OverflowY Scroll"
                    [OverflowY.scroll]
                    ["overflowY" ==> "scroll"]
                testCase
                    "OverflowY Auto"
                    [OverflowY.auto]
                    ["overflowY" ==> "auto"]
                testCase
                    "OverflowY inherit"
                    [OverflowY.inherit']
                    ["overflowY" ==> "inherit"]
                testCase
                    "OverflowY initial"
                    [OverflowY.initial]
                    ["overflowY" ==> "initial"]
                testCase
                    "OverflowY unset"
                    [OverflowY.unset]
                    ["overflowY" ==> "unset"]
                testCase
                    "Overflow visible visible"
                    [Overflow.value (FssTypes.Overflow.Visible, FssTypes.Overflow.Visible)]
                    ["overflow" ==> "visible visible"]
                testCase
                    "OverflowXY hidden hidden"
                    [Overflow.value (FssTypes.Overflow.Hidden, FssTypes.Overflow.Hidden)]
                    ["overflow" ==> "hidden hidden"]
                testCase
                    "Overflow Clip clip"
                    [Overflow.value (FssTypes.Overflow.Clip, FssTypes.Overflow.Clip)]
                    ["overflow" ==> "clip clip"]
                testCase
                    "Overflow scroll Scroll"
                    [Overflow.value (FssTypes.Overflow.Scroll, FssTypes.Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]
                testCase
                    "OverflowWrap break-word"
                    [OverflowWrap.breakWord]
                    ["overflowWrap" ==> "break-word"]
                testCase
                    "OverflowWrap anywhere"
                    [OverflowWrap.anywhere]
                    ["overflowWrap" ==> "anywhere"]
                testCase
                    "OverflowWrap normal"
                    [OverflowWrap.normal]
                    ["overflowWrap" ==> "normal"]
                testCase
                    "OverflowWrap inherit"
                    [OverflowWrap.inherit']
                    ["overflowWrap" ==> "inherit"]
                testCase
                    "OverflowWrap initial"
                    [OverflowWrap.initial]
                    ["overflowWrap" ==> "initial"]
                testCase
                    "OverflowWrap unset"
                    [OverflowWrap.unset]
                    ["overflowWrap" ==> "unset"]

        ]