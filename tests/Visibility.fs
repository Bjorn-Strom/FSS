namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open FssTypes
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                test
                    "Paint order normal"
                    [PaintOrder.Normal]
                    ["paintOrder" ==> "normal"]
                test
                    "Paint order stroke"
                    [PaintOrder.Stroke]
                    ["paintOrder" ==> "stroke"]
                test
                    "Paint order markers"
                    [PaintOrder.Markers]
                    ["paintOrder" ==> "markers"]
                test
                    "Paint order stroke fill"
                    [PaintOrder.Value(Stroke, FssTypes.PaintOrder.Fill)]
                    ["paintOrder" ==> "stroke fill"]
                test
                    "Paint order markers stroke fill"
                    [PaintOrder.Value(Markers, Stroke, FssTypes.PaintOrder.Fill)]
                    ["paintOrder" ==> "markers stroke fill"]
                test
                    "Paint order normal"
                    [PaintOrder.Normal]
                    ["paintOrder" ==> "normal"]

                test
                    "Visibility hidden"
                    [ Visibility.Hidden]
                    ["visibility" ==> "hidden"]
                test
                    "Visibility collapse"
                    [ Visibility.Collapse]
                    ["visibility" ==> "collapse"]
                test
                    "Visibility visible"
                    [ Visibility.Visible]
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
                    [OverflowX.Visible]
                    ["overflowX" ==> "visible"]
                test
                    "Overflow-X hidden"
                    [OverflowX.Hidden]
                    ["overflowX" ==> "hidden"]
                test
                    "Overflow-X Clip"
                    [OverflowX.Clip]
                    ["overflowX" ==> "clip"]
                test
                    "Overflow-X Scroll"
                    [OverflowX.Scroll]
                    ["overflowX" ==> "scroll"]
                test
                    "Overflow-X Auto"
                    [OverflowX.Auto]
                    ["overflowX" ==> "auto"]
                test
                    "Overflow-X inherit"
                    [OverflowX.Inherit]
                    ["overflowX" ==> "inherit"]
                test
                    "Overflow-X initial"
                    [OverflowX.Initial]
                    ["overflowX" ==> "initial"]
                test
                    "Overflow-X unset"
                    [OverflowX.Unset]
                    ["overflowX" ==> "unset"]
                test
                    "OverflowY visible"
                    [OverflowY.Visible]
                    ["overflowY" ==> "visible"]
                test
                    "OverflowY hidden"
                    [OverflowY.Hidden]
                    ["overflowY" ==> "hidden"]
                test
                    "OverflowY Clip"
                    [OverflowY.Clip]
                    ["overflowY" ==> "clip"]
                test
                    "OverflowY Scroll"
                    [OverflowY.Scroll]
                    ["overflowY" ==> "scroll"]
                test
                    "OverflowY Auto"
                    [OverflowY.Auto]
                    ["overflowY" ==> "auto"]
                test
                    "OverflowY inherit"
                    [OverflowY.Inherit]
                    ["overflowY" ==> "inherit"]
                test
                    "OverflowY initial"
                    [OverflowY.Initial]
                    ["overflowY" ==> "initial"]
                test
                    "OverflowY unset"
                    [OverflowY.Unset]
                    ["overflowY" ==> "unset"]
                test
                    "Overflow visible visible"
                    [Overflow.Value (FssTypes.Overflow.Visible, FssTypes.Overflow.Visible)]
                    ["overflow" ==> "visible visible"]
                test
                    "OverflowXY hidden hidden"
                    [Overflow.Value (FssTypes.Overflow.Hidden, FssTypes.Overflow.Hidden)]
                    ["overflow" ==> "hidden hidden"]
                test
                    "Overflow Clip clip"
                    [Overflow.Value (FssTypes.Overflow.Clip, FssTypes.Overflow.Clip)]
                    ["overflow" ==> "clip clip"]
                test
                    "Overflow scroll Scroll"
                    [Overflow.Value (FssTypes.Overflow.Scroll, FssTypes.Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]
                test
                    "OverflowWrap break-word"
                    [OverflowWrap.BreakWord]
                    ["overflowWrap" ==> "break-word"]
                test
                    "OverflowWrap anywhere"
                    [OverflowWrap.Anywhere]
                    ["overflowWrap" ==> "anywhere"]
                test
                    "OverflowWrap normal"
                    [OverflowWrap.Normal]
                    ["overflowWrap" ==> "normal"]
                test
                    "OverflowWrap inherit"
                    [OverflowWrap.Inherit]
                    ["overflowWrap" ==> "inherit"]
                test
                    "OverflowWrap initial"
                    [OverflowWrap.Initial]
                    ["overflowWrap" ==> "initial"]
                test
                    "OverflowWrap unset"
                    [OverflowWrap.Unset]
                    ["overflowWrap" ==> "unset"]

        ]