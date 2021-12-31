namespace FSSTests

open Fet
open Utils
open Fss

module Outline =
    let tests =
        testList "Outline"
            [
                testCase
                    "Outline offset px"
                    [ OutlineOffset.value (px 3) ]
                     "{ outline-offset: 3px; }" 
                testCase
                    "Outline offset em"
                    [ OutlineOffset.value (em 0.2) ]
                     "{ outline-offset: 0.2em; }" 
                testCase
                    "Outline offset initial"
                    [ OutlineOffset.initial ]
                     "{ outline-offset: initial; }" 
                testCase
                    "Outline offset inherit"
                    [ OutlineOffset.inherit' ]
                     "{ outline-offset: inherit; }" 
                testCase
                    "Outline offset unset"
                    [ OutlineOffset.unset ]
                     "{ outline-offset: unset; }" 
                testCase
                    "Outline offset revert"
                    [ OutlineOffset.revert ]
                     "{ outline-offset: revert; }" 
                testCase
                    "Outline initial"
                    [ Outline.initial ]
                     "{ outline: initial; }" 
                testCase
                    "Outline inherit"
                    [ Outline.inherit' ]
                     "{ outline: inherit; }" 
                testCase
                    "Outline unset"
                    [ Outline.unset ]
                     "{ outline: unset; }" 
                testCase
                    "Outline revert"
                    [ Outline.revert ]
                     "{ outline: revert; }" 
                testCase
                    "Outline width px"
                    [ OutlineWidth.value (px 40) ]
                     "{ outline-width: 40px; }" 
                testCase
                    "Outline width thin"
                    [ OutlineWidth.thin ]
                     "{ outline-width: thin; }" 
                testCase
                    "Outline width medium"
                    [ OutlineWidth.medium ]
                     "{ outline-width: medium; }" 
                testCase
                    "Outline width thick"
                    [ OutlineWidth.thick ]
                     "{ outline-width: thick; }" 
                testCase
                    "Outline width initial"
                    [ OutlineWidth.initial ]
                     "{ outline-width: initial; }" 
                testCase
                    "Outline width inherit"
                    [ OutlineWidth.inherit' ]
                     "{ outline-width: inherit; }" 
                testCase
                    "Outline width unset"
                    [ OutlineWidth.unset ]
                     "{ outline-width: unset; }" 
                testCase
                    "Outline width revert"
                    [ OutlineWidth.revert ]
                     "{ outline-width: revert; }" 
                testCase
                    "Outline style hidden"
                    [ OutlineStyle.hidden ]
                     "{ outline-style: hidden; }" 
                testCase
                    "Outline style dotted"
                    [ OutlineStyle.dotted ]
                     "{ outline-style: dotted; }" 
                testCase
                    "Outline style dashed"
                    [ OutlineStyle.dashed ]
                     "{ outline-style: dashed; }" 
                testCase
                    "Outline style solid"
                    [ OutlineStyle.solid ]
                     "{ outline-style: solid; }" 
                testCase
                    "Outline style double"
                    [ OutlineStyle.double ]
                     "{ outline-style: double; }" 
                testCase
                    "Outline style groove"
                    [ OutlineStyle.groove ]
                     "{ outline-style: groove; }" 
                testCase
                    "Outline style ridge"
                    [ OutlineStyle.ridge ]
                     "{ outline-style: ridge; }" 
                testCase
                    "Outline style inset"
                    [ OutlineStyle.inset ]
                     "{ outline-style: inset; }" 
                testCase
                    "Outline style outset"
                    [ OutlineStyle.outset ]
                     "{ outline-style: outset; }" 
                testCase
                    "Outline style none"
                    [ OutlineStyle.none ]
                     "{ outline-style: none; }" 
                testCase
                    "Outline style initial"
                    [ OutlineStyle.initial ]
                     "{ outline-style: initial; }" 
                testCase
                    "Outline style inherit"
                    [ OutlineStyle.inherit' ]
                     "{ outline-style: inherit; }" 
                testCase
                    "Outline style unset"
                    [ OutlineStyle.unset ]
                     "{ outline-style: unset; }" 
                testCase
                    "Outline style revert"
                    [ OutlineStyle.revert ]
                     "{ outline-style: revert; }" 
                testCase
                    "Outline color hex"
                    [OutlineColor.hex "f92525"]
                    "{ outline-color: #f92525; }"
                testCase
                    "Outline color rgb"
                    [OutlineColor.rgb 30 222 121]
                    "{ outline-color: rgb(30, 222, 121); }"
                testCase
                    "Outline color blue"
                    [OutlineColor.blue]
                    "{ outline-color: blue; }"
                testCase
                    "Outline color inherit"
                    [OutlineColor.inherit']
                    "{ outline-color: inherit; }"
                testCase
                    "Outline color initial"
                    [OutlineColor.initial]
                    "{ outline-color: initial; }"
                testCase
                    "Outline color unset"
                    [OutlineColor.unset ]
                    "{ outline-color: unset; }"
                testCase
                    "Outline color revert"
                    [OutlineColor.revert ]
                    "{ outline-color: revert; }"
                testCase
                    "Outline Color Value"
                    [OutlineColor.value (rgb 1 2 3)]
                    "{ outline-color: rgb(1, 2, 3); }"
            ]