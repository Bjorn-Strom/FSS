namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Fss
open Utils

module Filter =
     let tests =
        testList "Filter"
            [
                testCase
                    "Filter Url"
                    [ Filters [ Filter.url "someFilter" ] ]
                    [ "filter" ==> "url(\"someFilter\")" ]
                testCase
                    "Filter blur"
                    [ Filters [ Filter.blur 50 ] ]
                    [ "filter" ==> "blur(50px)" ]
                testCase
                    "Filter brightness"
                    [ Filters [ Filter.brightness <| pct 40 ] ]
                    [ "filter" ==> "brightness(40%)" ]
                testCase
                    "Filter contras"
                    [ Filters [ Filter.contrast <| pct 40 ] ]
                    [ "filter" ==> "contrast(40%)" ]
                testCase
                    "Filter drop shadow"
                    [ Filters [ Filter.dropShadow 16 16 20 FssTypes.Color.red (pct 5)  ] ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                testCase
                    "Filter grayscale"
                    [ Filters [ Filter.grayscale <| pct 50 ] ]
                    [ "filter" ==> "grayscale(50%)" ]
                testCase
                    "Filter hue-rotate"
                    [ Filters [ Filter.hueRotate 90 ] ]
                    [ "filter" ==> "hue-rotate(90deg)" ]
                testCase
                    "Filter invert"
                    [ Filters [ Filter.invert <| pct 75 ] ]
                    [ "filter" ==> "invert(75%)" ]
                testCase
                    "Filter opacity"
                    [ Filters [ Filter.opacity <| pct 25 ] ]
                    [ "filter" ==> "opacity(25%)" ]
                testCase
                    "Filter saturate"
                    [ Filters [ Filter.saturate <| pct 30 ] ]
                    [ "filter" ==> "saturate(30%)" ]
                testCase
                    "Filter sepia"
                    [ Filters [ Filter.sepia <| pct 60 ] ]
                    [ "filter" ==> "sepia(60%)" ]
                testCase
                    "Filter multiple"
                    [ Filters  [ Filter.contrast <| pct 175; Filter.brightness <| pct 3  ] ]
                    [ "filter" ==> "contrast(175%) brightness(3%)" ]
                testCase
                    "Filter none"
                    [ Filter.none ]
                    [ "filter" ==> "none" ]
                testCase
                    "Filter inherit"
                    [ Filter.inherit' ]
                    [ "filter" ==> "inherit" ]
                testCase
                    "Filter initial"
                    [ Filter.initial ]
                    [ "filter" ==> "initial" ]
                testCase
                    "Filter unset"
                    [ Filter.unset ]
                    [ "filter" ==> "unset" ]
                testCase
                    "BackdropFilter Url"
                    [ BackdropFilters [ Filter.url "someFilter" ] ]
                    [ "backdropFilter" ==> "url(\"someFilter\")" ]
                testCase
                    "BackdropFilter blur"
                    [ BackdropFilters [ Filter.blur 50 ] ]
                    [ "backdropFilter" ==> "blur(50px)" ]
                testCase
                    "BackdropFilter brightness"
                    [ BackdropFilters [ Filter.brightness <| pct 40 ] ]
                    [ "backdropFilter" ==> "brightness(40%)" ]
                testCase
                    "BackdropFilter contrast"
                    [ BackdropFilters [ Filter.contrast <| pct 40 ] ]
                    [ "backdropFilter" ==> "contrast(40%)" ]
                testCase
                    "BackdropFilter drop shadow"
                    [ BackdropFilters [ Filter.dropShadow 16 16 20 FssTypes.Color.red (pct 5)  ] ]
                    [ "backdropFilter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                testCase
                    "BackdropFilter grayscale"
                    [ BackdropFilters [ Filter.grayscale <| pct 50 ] ]
                    [ "backdropFilter" ==> "grayscale(50%)" ]
                testCase
                    "BackdropFilter hue-rotate"
                    [ BackdropFilters [ Filter.hueRotate 90 ] ]
                    [ "backdropFilter" ==> "hue-rotate(90deg)" ]
                testCase
                    "BackdropFilter invert"
                    [ BackdropFilters [ Filter.invert <| pct 75 ] ]
                    [ "backdropFilter" ==> "invert(75%)" ]
                testCase
                    "BackdropFilter opacity"
                    [ BackdropFilters [ Filter.opacity <| pct 25 ] ]
                    [ "backdropFilter" ==> "opacity(25%)" ]
                testCase
                    "BackdropFilter saturate"
                    [ BackdropFilters [ Filter.saturate <| pct 30 ] ]
                    [ "backdropFilter" ==> "saturate(30%)" ]
                testCase
                    "BackdropFilter sepia"
                    [ BackdropFilters [ Filter.sepia <| pct 60 ] ]
                    [ "backdropFilter" ==> "sepia(60%)" ]
                testCase
                    "BackdropFilter multiple"
                    [ BackdropFilters  [ Filter.contrast <| pct 175; Filter.brightness <| pct 3  ] ]
                    [ "backdropFilter" ==> "contrast(175%) brightness(3%)" ]
                testCase
                    "BackdropFilter none"
                    [ BackdropFilter.none ]
                    [ "backdropFilter" ==> "none" ]
                testCase
                    "BackdropFilter inherit"
                    [ BackdropFilter.inherit' ]
                    [ "backdropFilter" ==> "inherit" ]
                testCase
                    "BackdropFilter initial"
                    [ BackdropFilter.initial ]
                    [ "backdropFilter" ==> "initial" ]
                testCase
                    "BackdropFilter unset"
                    [ BackdropFilter.unset ]
                    [ "backdropFilter" ==> "unset" ]
            ]