namespace FSSTests

open Fet
open Utils
open Fss

module ColorTests =
    let tests =
        testList "Colors"
            [
                testCase
                    "Color adjust exact"
                    [ColorAdjust.exact]
                    "{ color-adjust: exact; }"
                testCase
                    "Color adjust economy"
                    [ColorAdjust.economy]
                    "{ color-adjust: economy; }"
                testCase
                    "ColorAdjust Inherit"
                    [ ColorAdjust.inherit' ]
                    "{ color-adjust: inherit; }"
                testCase
                    "ColorAdjust Initial"
                    [ ColorAdjust.initial ]
                    "{ color-adjust: initial; }"
                testCase
                    "ColorAdjust Unset"
                    [ ColorAdjust.unset ]
                    "{ color-adjust: unset; }"
                testCase
                    "ColorAdjust revert"
                    [ ColorAdjust.revert ]
                    "{ color-adjust: revert; }"
                testCase
                    "Color named color"
                    [ Color.aliceBlue ]
                    "{ color: aliceblue; }"
                testCase
                    "Color RGB"
                    [ Color.rgb 255 0 0 ]
                    "{ color: rgb(255, 0, 0); }"
                testCase
                    "Color RBGA"
                    [ Color.rgba 255 0 0 0.5 ]
                    "{ color: rgba(255, 0, 0, 0.5); }"
                testCase
                    "Color HEX no #"
                    [ Color.hex "ff0000" ]
                    "{ color: #ff0000; }"
                testCase
                    "Color HEX with alpha"
                    [ Color.hex "#ff000080" ]
                    "{ color: #ff000080; }"
                testCase
                    "Color HSL"
                    [ Color.hsl 120 100 50 ]
                    "{ color: hsl(120, 100%, 50%); }"
                    
                testCase
                    "Color HSLA"
                    [ Color.hsla 120 100 50 50 ]
                    "{ color: hsla(120, 100%, 50%, 50); }"
                    
                testCase
                    "Color Inherit"
                    [ Color.inherit' ]
                    "{ color: inherit; }"
                testCase
                    "Color Initial"
                    [ Color.initial ]
                    "{ color: initial; }"
                testCase
                    "Color Unset"
                    [ Color.unset ]
                    "{ color: unset; }"
                testCase
                    "Color revert"
                    [ Color.revert ]
                    "{ color: revert; }"
                testCase
                    "Color Value"
                    [Color.value (rgb 1 2 3)]
                    "{ color: rgb(1, 2, 3); }"
            ;]