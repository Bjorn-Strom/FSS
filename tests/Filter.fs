namespace FSSTests

open Fet
open Fss
open Utils

module Filter =
     let tests =
        testList "Filter"
            [
                testCase
                    "Filter Url"
                    [ Filter.url "someFilter"  ]
                    "{ filter: url(someFilter); }" 
                testCase
                    "Filter blur"
                    [ Filter.blur (px 50) ]
                    "{ filter: blur(50px); }" 
                testCase
                    "Filter brightness"
                    [ Filter.brightness <| pct 40 ]
                    "{ filter: brightness(40%); }" 
                testCase
                    "Filter contras"
                    [ Filter.contrast <| pct 40 ] 
                    "{ filter: contrast(40%); }" 
                testCase
                    "Filter drop shadow with invert"
                    [ Filter.dropShadow(px 16, px 16, px 20, FssTypes.Color.Color.Red)  ]
                    "{ filter: drop-shadow(16px 16px 20px red); }"
                testCase
                    "Filter drop shadow with invert"
                    [ Filter.dropShadow(px 16, px 16, px 20, FssTypes.Color.Color.Red, pct 5)  ]
                    "{ filter: drop-shadow(16px 16px 20px red) invert(5%); }" 
                testCase
                    "Filter grayscale"
                    [ Filter.grayscale <| pct 50 ]
                    "{ filter: grayscale(50%); }" 
                testCase
                    "Filter hue-rotate"
                    [ Filter.hueRotate <| deg 90 ]
                    "{ filter: hue-rotate(90deg); }" 
                testCase
                    "Filter invert"
                    [ Filter.invert <| pct 75 ]
                    "{ filter: invert(75%); }" 
                testCase
                    "Filter opacity"
                    [ Filter.opacity <| pct 25 ]
                    "{ filter: opacity(25%); }" 
                testCase
                    "Filter saturate"
                    [ Filter.saturate <| pct 30 ]
                    "{ filter: saturate(30%); }" 
                testCase
                    "Filter sepia"
                    [ Filter.sepia <| pct 60 ]
                    "{ filter: sepia(60%); }" 
                testCase
                    "Filter multiple"
                    [ Filter.value  [ FssTypes.Filter.Contrast (pct 175);  FssTypes.Filter.Brightness (pct 3)  ] ]
                    "{ filter: contrast(175%) brightness(3%); }" 
                testCase
                    "Filter none"
                    [ Filter.none ]
                    "{ filter: none; }" 
                testCase
                    "Filter inherit"
                    [ Filter.inherit' ]
                    "{ filter: inherit; }" 
                testCase
                    "Filter initial"
                    [ Filter.initial ]
                    "{ filter: initial; }" 
                testCase
                    "Filter unset"
                    [ Filter.unset ]
                    "{ filter: unset; }"
                testCase
                    "BackdropFilter Url"
                    [ BackdropFilter.url("someFilter") ]
                    "{ backdrop-filter: url(someFilter); }" 
                testCase
                    "BackdropFilter blur"
                    [ BackdropFilter.blur <| px 50 ]
                    "{ backdrop-filter: blur(50px); }" 
                testCase
                    "BackdropFilter brightness"
                    [ BackdropFilter.brightness <| pct 40 ]
                    "{ backdrop-filter: brightness(40%); }" 
                testCase
                    "BackdropFilter contrast"
                    [ BackdropFilter.contrast <| pct 40 ]
                    "{ backdrop-filter: contrast(40%); }" 
                testCase
                    "BackdropFilter multiple"
                    [ BackdropFilter.value  [ FssTypes.Filter.Contrast (pct 175);  FssTypes.Filter.Brightness (pct 3)  ] ]
                    "{ backdrop-filter: contrast(175%) brightness(3%); }" 
                testCase
                    "BackdropFilter grayscale"
                    [ BackdropFilter.grayscale <| pct 50 ] 
                    "{ backdrop-filter: grayscale(50%); }" 
                testCase
                    "BackdropFilter hue-rotate"
                    [ BackdropFilter.hueRotate <| deg 90 ] 
                    "{ backdrop-filter: hue-rotate(90deg); }" 
                testCase
                    "BackdropFilter invert"
                    [ BackdropFilter.invert <| pct 75 ]
                    "{ backdrop-filter: invert(75%); }" 
                testCase
                    "BackdropFilter opacity"
                    [ BackdropFilter.opacity <| pct 25 ]
                    "{ backdrop-filter: opacity(25%); }" 
                testCase
                    "BackdropFilter saturate"
                    [ BackdropFilter.saturate <| pct 30 ]
                    "{ backdrop-filter: saturate(30%); }" 
                testCase
                    "BackdropFilter sepia"
                    [ BackdropFilter.sepia <| pct 60 ]
                    "{ backdrop-filter: sepia(60%); }" 
                testCase
                    "BackdropFilter none"
                    [ BackdropFilter.none ]
                    "{ backdrop-filter: none; }" 
                testCase
                    "BackdropFilter inherit"
                    [ BackdropFilter.inherit' ]
                    "{ backdrop-filter: inherit; }" 
                testCase
                    "BackdropFilter initial"
                    [ BackdropFilter.initial ]
                    "{ backdrop-filter: initial; }" 
                testCase
                    "BackdropFilter unset"
                    [ BackdropFilter.unset ]
                    "{ backdrop-filter: unset; }" 
                testCase
                    "BackdropFilter revert"
                    [ BackdropFilter.revert ]
                    "{ backdrop-filter: revert; }" 
            ]