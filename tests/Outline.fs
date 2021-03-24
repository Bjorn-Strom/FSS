namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Outline =
    let tests =
        testList "Outline"
            [
                test
                    "Outline offset px"
                    [ OutlineOffset.value <| px 3 ]
                    [ "outlineOffset" ==> "3px" ]
                test
                    "Outline offset em"
                    [ OutlineOffset' <| em 0.2 ]
                    [ "outlineOffset" ==> "0.2em" ]
                test
                    "Outline offset initial"
                    [ OutlineOffset.initial ]
                    [ "outlineOffset" ==> "initial" ]
                test
                    "Outline offset inherit"
                    [ OutlineOffset.inherit' ]
                    [ "outlineOffset" ==> "inherit" ]
                test
                    "Outline offset unset"
                    [ OutlineOffset.unset ]
                    [ "outlineOffset" ==> "unset" ]
                test
                    "Outline initial"
                    [ Outline.initial ]
                    [ "outline" ==> "initial" ]
                test
                    "Outline inherit"
                    [ Outline.inherit' ]
                    [ "outline" ==> "inherit" ]
                test
                    "Outline unset"
                    [ Outline.unset ]
                    [ "outline" ==> "unset" ]
                test
                    "Outline width px"
                    [ OutlineWidth' (px 40) ]
                    [ "outlineWidth" ==> "40px" ]
                test
                    "Outline width thin"
                    [ OutlineWidth.thin ]
                    [ "outlineWidth" ==> "thin" ]
                test
                    "Outline width medium"
                    [ OutlineWidth.medium ]
                    [ "outlineWidth" ==> "medium" ]
                test
                    "Outline width thick"
                    [ OutlineWidth.thick ]
                    [ "outlineWidth" ==> "thick" ]
                test
                    "Outline width initial"
                    [ OutlineWidth.initial ]
                    [ "outlineWidth" ==> "initial" ]
                test
                    "Outline width inherit"
                    [ OutlineWidth.inherit' ]
                    [ "outlineWidth" ==> "inherit" ]
                test
                    "Outline width unset"
                    [ OutlineWidth.unset ]
                    [ "outlineWidth" ==> "unset" ]
                test
                    "Outline style hidden"
                    [ OutlineStyle.hidden ]
                    [ "outlineStyle" ==> "hidden" ]
                test
                    "Outline style dotted"
                    [ OutlineStyle.dotted ]
                    [ "outlineStyle" ==> "dotted" ]
                test
                    "Outline style dashed"
                    [ OutlineStyle.dashed ]
                    [ "outlineStyle" ==> "dashed" ]
                test
                    "Outline style solid"
                    [ OutlineStyle.solid ]
                    [ "outlineStyle" ==> "solid" ]
                test
                    "Outline style double"
                    [ OutlineStyle.double ]
                    [ "outlineStyle" ==> "double" ]
                test
                    "Outline style groove"
                    [ OutlineStyle.groove ]
                    [ "outlineStyle" ==> "groove" ]
                test
                    "Outline style ridge"
                    [ OutlineStyle.ridge ]
                    [ "outlineStyle" ==> "ridge" ]
                test
                    "Outline style inset"
                    [ OutlineStyle.inset ]
                    [ "outlineStyle" ==> "inset" ]
                test
                    "Outline style outset"
                    [ OutlineStyle.outset ]
                    [ "outlineStyle" ==> "outset" ]
                test
                    "Outline style none"
                    [ OutlineStyle.none ]
                    [ "outlineStyle" ==> "none" ]
                test
                    "Outline style initial"
                    [ OutlineStyle.initial ]
                    [ "outlineStyle" ==> "initial" ]
                test
                    "Outline style inherit"
                    [ OutlineStyle.inherit' ]
                    [ "outlineStyle" ==> "inherit" ]
                test
                    "Outline style unset"
                    [ OutlineStyle.unset ]
                    [ "outlineStyle" ==> "unset" ]
                test
                    "Outline color hex"
                    [OutlineColor.hex "f92525"]
                    ["outlineColor" ==> "#f92525"]
                test
                    "Outline color rgb"
                    [OutlineColor.rgb 30 222 121]
                    ["outlineColor" ==> "rgb(30, 222, 121)"]
                test
                    "Outline color blue"
                    [OutlineColor.blue]
                    ["outlineColor" ==> "#0000ff"]
                test
                    "Outline color inherit"
                    [OutlineColor.inherit']
                    ["outlineColor" ==> "inherit"]
                test
                    "Outline color initial"
                    [OutlineColor.initial]
                    ["outlineColor" ==> "initial"]
                test
                    "Outline color unset"
                    [OutlineColor.unset ]
                    ["outlineColor" ==> "unset"]
                test
                    "Outline Color Value"
                    [OutlineColor' (rgb 1 2 3)]
                    ["outlineColor"  ==> "rgb(1, 2, 3)"]
            ]