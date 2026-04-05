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
                    "{color-adjust:exact;}"
                testCase
                    "Color adjust economy"
                    [ColorAdjust.economy]
                    "{color-adjust:economy;}"
                testCase
                    "ColorAdjust Inherit"
                    [ ColorAdjust.inherit' ]
                    "{color-adjust:inherit;}"
                testCase
                    "ColorAdjust Initial"
                    [ ColorAdjust.initial ]
                    "{color-adjust:initial;}"
                testCase
                    "ColorAdjust Unset"
                    [ ColorAdjust.unset ]
                    "{color-adjust:unset;}"
                testCase
                    "ColorAdjust revert"
                    [ ColorAdjust.revert ]
                    "{color-adjust:revert;}"
                testCase
                    "Color named color"
                    [ Color.aliceBlue ]
                    "{color:aliceblue;}"
                testCase
                    "Color RGB"
                    [ Color.rgb 255 0 0 ]
                    "{color:rgb(255,0,0);}"
                testCase
                    "Color RBGA"
                    [ Color.rgba 255 0 0 0.5 ]
                    "{color:rgba(255,0,0,0.5);}"
                testCase
                    "Color HEX no #"
                    [ Color.hex "ff0000" ]
                    "{color:#ff0000;}"
                testCase
                    "Color HEX with alpha"
                    [ Color.hex "#ff000080" ]
                    "{color:#ff000080;}"
                testCase
                    "Color HSL"
                    [ Color.hsl 120 100 50 ]
                    "{color:hsl(120,100%,50%);}"
                testCase
                    "Color HSLA"
                    [ Color.hsla 120 100 50 50 ]
                    "{color:hsla(120,100%,50%,50);}"
                testCase
                    "Color Inherit"
                    [ Color.inherit' ]
                    "{color:inherit;}"
                testCase
                    "Color Initial"
                    [ Color.initial ]
                    "{color:initial;}"
                testCase
                    "Color Unset"
                    [ Color.unset ]
                    "{color:unset;}"
                testCase
                    "Color revert"
                    [ Color.revert ]
                    "{color:revert;}"
                testCase
                    "Color Value"
                    [Color.value (rgb 1 2 3)]
                    "{color:rgb(1,2,3);}"
                // HWB
                testCase
                    "Color HWB"
                    [ Color.hwb 194 0 0 ]
                    "{color:hwb(194 0% 0%);}"
                testCase
                    "Color HWB with alpha"
                    [ Color.hwba 194 0 0 0.5 ]
                    "{color:hwb(194 0% 0% / 0.5);}"
                // Lab
                testCase
                    "Color Lab"
                    [ Color.lab 50 40 59.5 ]
                    "{color:lab(50% 40 59.5);}"
                testCase
                    "Color Lab with alpha"
                    [ Color.laba 50 40 59.5 0.5 ]
                    "{color:lab(50% 40 59.5 / 0.5);}"
                // LCH
                testCase
                    "Color LCH"
                    [ Color.lch 52.2 72.2 50 ]
                    "{color:lch(52.2% 72.2 50);}"
                testCase
                    "Color LCH with alpha"
                    [ Color.lcha 52.2 72.2 50 0.5 ]
                    "{color:lch(52.2% 72.2 50 / 0.5);}"
                // Oklab
                testCase
                    "Color Oklab"
                    [ Color.oklab 0.59 0.1 0.08 ]
                    "{color:oklab(0.59 0.1 0.08);}"
                testCase
                    "Color Oklab with alpha"
                    [ Color.oklaba 0.59 0.1 0.08 0.5 ]
                    "{color:oklab(0.59 0.1 0.08 / 0.5);}"
                // Oklch
                testCase
                    "Color Oklch"
                    [ Color.oklch 0.7 0.15 50 ]
                    "{color:oklch(0.7 0.15 50);}"
                testCase
                    "Color Oklch with alpha"
                    [ Color.oklcha 0.7 0.15 50 0.5 ]
                    "{color:oklch(0.7 0.15 50 / 0.5);}"
                // Color-mix
                testCase
                    "Color color-mix srgb"
                    [ Color.colorMix "srgb" Fss.Types.Color.Red 50 Fss.Types.Color.Blue 50 ]
                    "{color:color-mix(in srgb,red 50%,blue 50%);}"
                testCase
                    "Color color-mix oklch"
                    [ Color.colorMix "oklch" Fss.Types.Color.White 30 Fss.Types.Color.Black 70 ]
                    "{color:color-mix(in oklch,white 30%,black 70%);}"
                // Standalone color functions
                testCase
                    "Color value oklch standalone"
                    [ Color.value (oklch 0.6 0.2 270) ]
                    "{color:oklch(0.6 0.2 270);}"
                testCase
                    "Color value hwb standalone"
                    [ Color.value (hwb 120 10 20) ]
                    "{color:hwb(120 10% 20%);}"
                testCase
                    "Color value lab standalone"
                    [ Color.value (lab 80 0 0) ]
                    "{color:lab(80% 0 0);}"
                testCase
                    "Color value lch standalone"
                    [ Color.value (lch 65 30 270) ]
                    "{color:lch(65% 30 270);}"
                testCase
                    "Color value oklab standalone"
                    [ Color.value (oklab 0.5 -0.1 0.1) ]
                    "{color:oklab(0.5 -0.1 0.1);}"
                testCase
                    "Color value colorMix standalone"
                    [ Color.value (colorMix "srgb" (Fss.Types.Color.Hex "#f00") 25 Fss.Types.Color.Blue 75) ]
                    "{color:color-mix(in srgb,#f00 25%,blue 75%);}"
                testCase
                    "Color light-dark"
                    [ Color.lightDark Fss.Types.Color.White Fss.Types.Color.Black ]
                    "{color:light-dark(white,black);}"
                testCase
                    "Color value lightDark standalone"
                    [ Color.value (lightDark Fss.Types.Color.Red Fss.Types.Color.Blue) ]
                    "{color:light-dark(red,blue);}"
            ;]
