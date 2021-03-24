namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                test
                    "Paint order normal"
                    [PaintOrder.normal]
                    ["paintOrder" ==> "normal"]
                test
                    "Paint order stroke"
                    [PaintOrder.stroke]
                    ["paintOrder" ==> "stroke"]
                test
                    "Paint order markers"
                    [PaintOrder.markers]
                    ["paintOrder" ==> "markers"]
                test
                    "Paint order stroke fill"
                    [PaintOrder.value(FssTypes.Visibility.PaintOrder.Stroke, FssTypes.Visibility.PaintOrder.Fill)]
                    ["paintOrder" ==> "stroke fill"]
                test
                    "Paint order markers stroke fill"
                    [PaintOrder.value(FssTypes.Visibility.PaintOrder.Markers, FssTypes.Visibility.PaintOrder.Stroke, FssTypes.Visibility.PaintOrder.Fill)]
                    ["paintOrder" ==> "markers stroke fill"]
                test
                    "Paint order normal"
                    [PaintOrder.normal]
                    ["paintOrder" ==> "normal"]

                test
                    "Visibility hidden"
                    [ Visibility.hidden]
                    ["visibility" ==> "hidden"]
                test
                    "Visibility collapse"
                    [ Visibility.collapse]
                    ["visibility" ==> "collapse"]
                test
                    "Visibility visible"
                    [ Visibility.visible]
                    ["visibility" ==> "visible"]
                test
                    "Opacity 1"
                    [ Opacity' 1.0 ]
                    ["opacity" ==> "1"]
                test
                    "Opacity 0"
                    [ Opacity' 0.0]
                    ["opacity" ==> "0"]
                test
                    "Opacity 50%"
                    [ Opacity' 0.5 ]
                    ["opacity" ==> "0.5"]
                test
                    "Opacity -10 should be 0"
                    [ Opacity' -10.0 ]
                    ["opacity" ==> "0"]
                test
                    "Opacity 10 should be 1"
                    [ Opacity' 10.0 ]
                    ["opacity" ==> "1"]
                test
                    "Opacity 1.5 should be 1"
                    [ Opacity' 1.5 ]
                    ["opacity" ==> "1"]
                test
                    "Overflow-X visible"
                    [OverflowX.visible]
                    ["overflowX" ==> "visible"]
                test
                    "Overflow-X hidden"
                    [OverflowX.hidden]
                    ["overflowX" ==> "hidden"]
                test
                    "Overflow-X Clip"
                    [OverflowX.clip]
                    ["overflowX" ==> "clip"]
                test
                    "Overflow-X Scroll"
                    [OverflowX.scroll]
                    ["overflowX" ==> "scroll"]
                test
                    "Overflow-X Auto"
                    [OverflowX.auto]
                    ["overflowX" ==> "auto"]
                test
                    "Overflow-X inherit"
                    [OverflowX.inherit']
                    ["overflowX" ==> "inherit"]
                test
                    "Overflow-X initial"
                    [OverflowX.initial]
                    ["overflowX" ==> "initial"]
                test
                    "Overflow-X unset"
                    [OverflowX.unset]
                    ["overflowX" ==> "unset"]
                test
                    "OverflowY visible"
                    [OverflowY.visible]
                    ["overflowY" ==> "visible"]
                test
                    "OverflowY hidden"
                    [OverflowY.hidden]
                    ["overflowY" ==> "hidden"]
                test
                    "OverflowY Clip"
                    [OverflowY.clip]
                    ["overflowY" ==> "clip"]
                test
                    "OverflowY Scroll"
                    [OverflowY.scroll]
                    ["overflowY" ==> "scroll"]
                test
                    "OverflowY Auto"
                    [OverflowY.auto]
                    ["overflowY" ==> "auto"]
                test
                    "OverflowY inherit"
                    [OverflowY.inherit']
                    ["overflowY" ==> "inherit"]
                test
                    "OverflowY initial"
                    [OverflowY.initial]
                    ["overflowY" ==> "initial"]
                test
                    "OverflowY unset"
                    [OverflowY.unset]
                    ["overflowY" ==> "unset"]
                test
                    "Overflow visible visible"
                    [Overflow.value (FssTypes.Overflow.Visible, FssTypes.Overflow.Visible)]
                    ["overflow" ==> "visible visible"]
                test
                    "OverflowXY hidden hidden"
                    [Overflow.value (FssTypes.Overflow.Hidden, FssTypes.Overflow.Hidden)]
                    ["overflow" ==> "hidden hidden"]
                test
                    "Overflow Clip clip"
                    [Overflow.value (FssTypes.Overflow.Clip, FssTypes.Overflow.Clip)]
                    ["overflow" ==> "clip clip"]
                test
                    "Overflow scroll Scroll"
                    [Overflow.value (FssTypes.Overflow.Scroll, FssTypes.Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]
                test
                    "OverflowWrap break-word"
                    [OverflowWrap.breakWord]
                    ["overflowWrap" ==> "break-word"]
                test
                    "OverflowWrap anywhere"
                    [OverflowWrap.anywhere]
                    ["overflowWrap" ==> "anywhere"]
                test
                    "OverflowWrap normal"
                    [OverflowWrap.normal]
                    ["overflowWrap" ==> "normal"]
                test
                    "OverflowWrap inherit"
                    [OverflowWrap.inherit']
                    ["overflowWrap" ==> "inherit"]
                test
                    "OverflowWrap initial"
                    [OverflowWrap.initial]
                    ["overflowWrap" ==> "initial"]
                test
                    "OverflowWrap unset"
                    [OverflowWrap.unset]
                    ["overflowWrap" ==> "unset"]

        ]