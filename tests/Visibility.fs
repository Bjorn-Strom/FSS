namespace FSSTests

open Fet
open Utils
open Fss

module Visibility =
     let tests =
        testList "Visibility" [
                testCase
                    "Paint order normal"
                    [PaintOrder.normal]
                    "paint-order: normal;"
                testCase
                    "Paint order stroke"
                    [PaintOrder.stroke]
                    "paint-order: stroke;"
                testCase
                    "Paint order markers"
                    [PaintOrder.markers]
                    "paint-order: markers;"
                testCase
                    "Paint order fill"
                    [PaintOrder.fill]
                    "paint-order: fill;"
                testCase
                    "Paint order stroke fill"
                    [PaintOrder.value [FssTypes.PaintOrder.Stroke; FssTypes.PaintOrder.Fill]]
                    "paint-order: stroke fill;"
                testCase
                    "Paint order markers stroke fill"
                    [PaintOrder.value [FssTypes.PaintOrder.Markers; FssTypes.PaintOrder.Stroke; FssTypes.PaintOrder.Fill] ]
                    "paint-order: markers stroke fill;"
                testCase
                    "Paint order normal"
                    [PaintOrder.normal]
                    "paint-order: normal;"
                testCase
                    "PaintOrder inherit"
                    [PaintOrder.inherit']
                    "paint-order: inherit;"
                testCase
                    "PaintOrder initial"
                    [PaintOrder.initial]
                    "paint-order: initial;"
                testCase
                    "PaintOrder unset"
                    [PaintOrder.unset]
                    "paint-order: unset;"
                testCase
                    "PaintOrder revert"
                    [PaintOrder.revert]
                    "paint-order: revert;"
                testCase
                    "Visibility hidden"
                    [ Visibility.hidden]
                    "visibility: hidden;"
                testCase
                    "Visibility collapse"
                    [ Visibility.collapse]
                    "visibility: collapse;"
                testCase
                    "Visibility visible"
                    [ Visibility.visible]
                    "visibility: visible;"
                testCase
                    "Visibility inherit"
                    [Visibility.inherit']
                    "visibility: inherit;"
                testCase
                    "Visibility initial"
                    [Visibility.initial]
                    "visibility: initial;"
                testCase
                    "Visibility unset"
                    [Visibility.unset]
                    "visibility: unset;"
                testCase
                    "Visibility revert"
                    [Visibility.revert]
                    "visibility: revert;"
                testCase
                    "Opacity 1"
                    [ Opacity.value 1.0 ]
                    "opacity: 1;"
                testCase
                    "Opacity 0"
                    [ Opacity.value 0.0]
                    "opacity: 0;"
                testCase
                    "Opacity 50%"
                    [ Opacity.value 0.5 ]
                    "opacity: 0.5;"
                testCase
                    "Opacity -10 should be 0"
                    [ Opacity.value -10.0 ]
                    "opacity: 0;"
                testCase
                    "Opacity 10 should be 1"
                    [ Opacity.value 10.0 ]
                    "opacity: 1;"
                testCase
                    "Opacity 1.5 should be 1"
                    [ Opacity.value 1.5 ]
                    "opacity: 1;"
                testCase
                    "Opacity percent"
                    [ Opacity.value (pct 80) ]
                    "opacity: 80%;"
                testCase
                    "Opacity inherit"
                    [Opacity.inherit']
                    "opacity: inherit;"
                testCase
                    "Opacity initial"
                    [Opacity.initial]
                    "opacity: initial;"
                testCase
                    "Opacity unset"
                    [Opacity.unset]
                    "opacity: unset;"
                testCase
                    "Opacity revert"
                    [Opacity.revert]
                    "opacity: revert;"
                testCase
                    "ZIndex 0"
                    [ZIndex.value 0]
                    "z-index: 0;"
                testCase
                    "ZIndex 3"
                    [ZIndex.value 3]
                    "z-index: 3;"
                testCase
                    "ZIndex 289"
                    [ZIndex.value 289]
                    "z-index: 289;"
                testCase
                    "ZIndex -1"
                    [ZIndex.value -1]
                    "z-index: -1;"
                testCase
                    "ZIndex value auto"
                    [ZIndex.auto]
                    "z-index: auto;"
                testCase
                    "ZIndex auto"
                    [ZIndex.auto]
                    "z-index: auto;"
                testCase
                    "ZIndex inherit"
                    [ZIndex.inherit']
                    "z-index: inherit;"
                testCase
                    "ZIndex initial"
                    [ZIndex.initial]
                    "z-index: initial;"
                testCase
                    "ZIndex unset"
                    [ZIndex.unset]
                    "z-index: unset;"
                testCase
                    "ZIndex revert"
                    [ZIndex.revert]
                    "z-index: revert;"
        ]