namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Outline =
    let tests =
        testList "Outline"
            [
                testCase
                    "Outline offset px"
                    [ OutlineOffset.value <| px 3 ]
                    [ "outlineOffset" ==> "3px" ]
                testCase
                    "Outline offset em"
                    [ OutlineOffset' <| em 0.2 ]
                    [ "outlineOffset" ==> "0.2em" ]
                testCase
                    "Outline offset initial"
                    [ OutlineOffset.initial ]
                    [ "outlineOffset" ==> "initial" ]
                testCase
                    "Outline offset inherit"
                    [ OutlineOffset.inherit' ]
                    [ "outlineOffset" ==> "inherit" ]
                testCase
                    "Outline offset unset"
                    [ OutlineOffset.unset ]
                    [ "outlineOffset" ==> "unset" ]
                testCase
                    "Outline initial"
                    [ Outline.initial ]
                    [ "outline" ==> "initial" ]
                testCase
                    "Outline inherit"
                    [ Outline.inherit' ]
                    [ "outline" ==> "inherit" ]
                testCase
                    "Outline unset"
                    [ Outline.unset ]
                    [ "outline" ==> "unset" ]
                testCase
                    "Outline width px"
                    [ OutlineWidth' (px 40) ]
                    [ "outlineWidth" ==> "40px" ]
                testCase
                    "Outline width thin"
                    [ OutlineWidth.thin ]
                    [ "outlineWidth" ==> "thin" ]
                testCase
                    "Outline width medium"
                    [ OutlineWidth.medium ]
                    [ "outlineWidth" ==> "medium" ]
                testCase
                    "Outline width thick"
                    [ OutlineWidth.thick ]
                    [ "outlineWidth" ==> "thick" ]
                testCase
                    "Outline width initial"
                    [ OutlineWidth.initial ]
                    [ "outlineWidth" ==> "initial" ]
                testCase
                    "Outline width inherit"
                    [ OutlineWidth.inherit' ]
                    [ "outlineWidth" ==> "inherit" ]
                testCase
                    "Outline width unset"
                    [ OutlineWidth.unset ]
                    [ "outlineWidth" ==> "unset" ]
                testCase
                    "Outline style hidden"
                    [ OutlineStyle.hidden ]
                    [ "outlineStyle" ==> "hidden" ]
                testCase
                    "Outline style dotted"
                    [ OutlineStyle.dotted ]
                    [ "outlineStyle" ==> "dotted" ]
                testCase
                    "Outline style dashed"
                    [ OutlineStyle.dashed ]
                    [ "outlineStyle" ==> "dashed" ]
                testCase
                    "Outline style solid"
                    [ OutlineStyle.solid ]
                    [ "outlineStyle" ==> "solid" ]
                testCase
                    "Outline style double"
                    [ OutlineStyle.double ]
                    [ "outlineStyle" ==> "double" ]
                testCase
                    "Outline style groove"
                    [ OutlineStyle.groove ]
                    [ "outlineStyle" ==> "groove" ]
                testCase
                    "Outline style ridge"
                    [ OutlineStyle.ridge ]
                    [ "outlineStyle" ==> "ridge" ]
                testCase
                    "Outline style inset"
                    [ OutlineStyle.inset ]
                    [ "outlineStyle" ==> "inset" ]
                testCase
                    "Outline style outset"
                    [ OutlineStyle.outset ]
                    [ "outlineStyle" ==> "outset" ]
                testCase
                    "Outline style none"
                    [ OutlineStyle.none ]
                    [ "outlineStyle" ==> "none" ]
                testCase
                    "Outline style initial"
                    [ OutlineStyle.initial ]
                    [ "outlineStyle" ==> "initial" ]
                testCase
                    "Outline style inherit"
                    [ OutlineStyle.inherit' ]
                    [ "outlineStyle" ==> "inherit" ]
                testCase
                    "Outline style unset"
                    [ OutlineStyle.unset ]
                    [ "outlineStyle" ==> "unset" ]
                testCase
                    "Outline color hex"
                    [OutlineColor.hex "f92525"]
                    ["outlineColor" ==> "#f92525"]
                testCase
                    "Outline color rgb"
                    [OutlineColor.rgb 30 222 121]
                    ["outlineColor" ==> "rgb(30, 222, 121)"]
                testCase
                    "Outline color blue"
                    [OutlineColor.blue]
                    ["outlineColor" ==> "#0000ff"]
                testCase
                    "Outline color inherit"
                    [OutlineColor.inherit']
                    ["outlineColor" ==> "inherit"]
                testCase
                    "Outline color initial"
                    [OutlineColor.initial]
                    ["outlineColor" ==> "initial"]
                testCase
                    "Outline color unset"
                    [OutlineColor.unset ]
                    ["outlineColor" ==> "unset"]
                testCase
                    "Outline Color Value"
                    [OutlineColor' (rgb 1 2 3)]
                    ["outlineColor"  ==> "rgb(1, 2, 3)"]
            ]