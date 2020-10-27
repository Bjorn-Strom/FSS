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
                    "Outline width px"
                    [ OutlineWidth (px 40) ]
                    [ "outlineWidth" ==> "40px" ]

                test
                    "Outline width thin"
                    [ OutlineWidth Outline.Thin ]
                    [ "outlineWidth" ==> "thin" ]

                test
                    "Outline width medium"
                    [ OutlineWidth Outline.Medium ]
                    [ "outlineWidth" ==> "medium" ]

                test
                    "Outline width thick"
                    [ OutlineWidth Outline.Thick ]
                    [ "outlineWidth" ==> "thick" ]

                test
                    "Outline width initial"
                    [ OutlineWidth Initial ]
                    [ "outlineWidth" ==> "initial" ]

                test
                    "Outline width inherit"
                    [ OutlineWidth Inherit ]
                    [ "outlineWidth" ==> "inherit" ]

                test
                    "Outline width unset"
                    [ OutlineWidth Unset ]
                    [ "outlineWidth" ==> "unset" ]

                test
                    "Outline style hidden"
                    [ OutlineStyle Outline.Hidden ]
                    [
                        "outlineStyle" ==> "hidden"
                    ]

                test
                    "Outline style dotted"
                    [ OutlineStyle Outline.Dotted ]
                    [
                        "outlineStyle" ==> "dotted"
                    ]

                test
                    "Outline style dashed"
                    [ OutlineStyle Outline.Dashed ]
                    [
                        "outlineStyle" ==> "dashed"
                    ]

                test
                    "Outline style solid"
                    [ OutlineStyle Outline.Solid ]
                    [
                        "outlineStyle" ==> "solid"
                    ]

                test
                    "Outline style double"
                    [ OutlineStyle Outline.Double ]
                    [
                        "outlineStyle" ==> "double"
                    ]

                test
                    "Outline style groove"
                    [ OutlineStyle Outline.Groove ]
                    [
                        "outlineStyle" ==> "groove"
                    ]

                test
                    "Outline style ridge"
                    [ OutlineStyle Outline.Ridge ]
                    [
                        "outlineStyle" ==> "ridge"
                    ]

                test
                    "Outline style inset"
                    [ OutlineStyle Outline.Inset ]
                    [
                        "outlineStyle" ==> "inset"
                    ]

                test
                    "Outline style outset"
                    [ OutlineStyle Outline.Outset ]
                    [
                        "outlineStyle" ==> "outset"
                    ]

                test
                    "Outline style none"
                    [ OutlineStyle None ]
                    [
                        "outlineStyle" ==> "none"
                    ]

                test
                    "Outline style initial"
                    [ OutlineStyle Initial ]
                    [
                        "outlineStyle" ==> "initial"
                    ]

                test
                    "Outline style inherit"
                    [ OutlineStyle Inherit ]
                    [
                        "outlineStyle" ==> "inherit"
                    ]

                test
                    "Outline style unset"
                    [ OutlineStyle Unset ]
                    [
                        "outlineStyle" ==> "unset"
                    ]

                test
                    "Outline color hex"
                    [OutlineColor (hex "f92525")]
                    ["outlineColor" ==> "#f92525"]

                test
                    "Outline color rgb"
                    [OutlineColor (rgb 30 222 121)]
                    ["outlineColor" ==> "rgb(30, 222, 121)"]

                test
                    "Outline color blue"
                    [OutlineColor Color.blue]
                    ["outlineColor" ==> "#0000ff"]

                test
                    "Outline color invert"
                    [OutlineColor Outline.Invert]
                    ["outlineColor" ==> "invert"]

                test
                    "Outline color inherit"
                    [OutlineColor Inherit]
                    ["outlineColor" ==> "inherit"]

                test
                    "Outline color initial"
                    [OutlineColor Initial]
                    ["outlineColor" ==> "initial"]

                test
                    "Outline color unset"
                    [OutlineColor Unset]
                    ["outlineColor" ==> "unset"]

            ]