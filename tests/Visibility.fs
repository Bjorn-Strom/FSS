namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                test
                    "Visibility hidden"
                    [ Visibility Visibility.Hidden]
                    ["visibility" ==> "hidden"]

                test
                    "Visibility collapse"
                    [ Visibility Visibility.Collapse]
                    ["visibility" ==> "collapse"]

                test
                    "Visibility visible"
                    [ Visibility Visibility.Visible]
                    ["visibility" ==> "visible"]

                test
                    "Opacity 1"
                    [ Opacity (Opacity.Opacity 1.0) ]
                    ["opacity" ==> "1"]

                test
                    "Opacity 0"
                    [ Opacity (Opacity.Opacity 0.0)]
                    ["opacity" ==> "0"]

                test
                    "Opacity 50%"
                    [ Opacity (Opacity.Opacity 0.5)]
                    ["opacity" ==> "0.5"]

                test
                    "Opacity -10 should be 0"
                    [ Opacity (Opacity.Opacity -10.0)]
                    ["opacity" ==> "0"]

                test
                    "Opacity 10 should be 1"
                    [ Opacity (Opacity.Opacity 10.0)]
                    ["opacity" ==> "1"]

                test
                    "Opacity 1.5 should be 1"
                    [ Opacity (Opacity.Opacity 1.5)]
                    ["opacity" ==> "1"]
                    
                    
                    
                    
                test
                    "Overflow-X visible"
                    [OverflowX Overflow.Visible]
                    ["overflow-x" ==> "visible"]
                    
                test
                    "Overflow-X hidden"
                    [OverflowX Overflow.Hidden]
                    ["overflow-x" ==> "hidden"]
                    
                test
                    "Overflow-X Clip"
                    [OverflowX Overflow.Clip]
                    ["overflow-x" ==> "clip"]
                    
                test
                    "Overflow-X Scroll"
                    [OverflowX Overflow.Scroll]
                    ["overflow-x" ==> "scroll"]

                test
                    "Overflow-X Auto"
                    [OverflowX Auto]
                    ["overflow-x" ==> "auto"]
                    
                test
                    "Overflow-X inherit"
                    [OverflowX Inherit]
                    ["overflow-x" ==> "inherit"]
                    
                test
                    "Overflow-X initial"
                    [OverflowX Initial]
                    ["overflow-x" ==> "initial"]
                    
                test
                    "Overflow-X unset"
                    [OverflowX Unset]
                    ["overflow-x" ==> "unset"]
                    
                test
                    "Overflow-y visible"
                    [OverflowY Overflow.Visible]
                    ["overflow-y" ==> "visible"]
                    
                test
                    "Overflow-y hidden"
                    [OverflowY Overflow.Hidden]
                    ["overflow-y" ==> "hidden"]
                    
                test
                    "Overflow-y Clip"
                    [OverflowY Overflow.Clip]
                    ["overflow-y" ==> "clip"]
                    
                test
                    "Overflow-y Scroll"
                    [OverflowY Overflow.Scroll]
                    ["overflow-y" ==> "scroll"]

                test
                    "Overflow-y Auto"
                    [OverflowY Auto]
                    ["overflow-y" ==> "auto"]
                    
                test
                    "Overflow-y inherit"
                    [OverflowY Inherit]
                    ["overflow-y" ==> "inherit"]
                    
                test
                    "Overflow-y initial"
                    [OverflowY Initial]
                    ["overflow-y" ==> "initial"]
                    
                test
                    "Overflow-y unset"
                    [OverflowY Unset]
                    ["overflow-y" ==> "unset"]
                    
                test
                    "OverflowXY visible"
                    [OverflowXY (Overflow.Visible,Overflow.Visible)]
                    ["overflow" ==> "visible visible"]
                    
                test
                    "OverflowXY hidden"
                    [OverflowXY (Overflow.Hidden,Overflow.Hidden)]
                    ["overflow" ==> "hidden hidden"]
                    
                test
                    "OverflowXY Clip"
                    [OverflowXY (Overflow.Clip,Overflow.Clip)]
                    ["overflow" ==> "clip clip"]
                    
                test
                    "OverflowXY Scroll"
                    [OverflowXY (Overflow.Scroll,Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]

                test
                    "OverflowXY Auto"
                    [OverflowXY (Auto,Auto)]
                    ["overflow" ==> "auto auto"]
                    
                test
                    "OverflowXY inherit"
                    [OverflowXY (Inherit,Inherit)]
                    ["overflow" ==> "inherit inherit"]
                    
                test
                    "OverflowXY initial"
                    [OverflowXY (Initial,Initial)]
                    ["overflow" ==> "initial initial"]
                    
                test
                    "OverflowXY unset"
                    [OverflowXY (Unset,Unset)]
                    ["overflow" ==> "unset unset"]
        ]