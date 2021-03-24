namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss
open Utils

module Filter =
     let tests =
        testList "Filter"
            [
                test
                    "Filter Url"
                    [ Filters [ Filter.url "someFilter" ] ]
                    [ "filter" ==> "url(\"someFilter\")" ]
                test
                    "Filter blur"
                    [ Filters [ Filter.blur 50 ] ]
                    [ "filter" ==> "blur(50px)" ]
                test
                    "Filter brightness"
                    [ Filters [ Filter.brightness <| pct 40 ] ]
                    [ "filter" ==> "brightness(40%)" ]
                test
                    "Filter contras"
                    [ Filters [ Filter.contrast <| pct 40 ] ]
                    [ "filter" ==> "contrast(40%)" ]
                test
                    "Filter drop shadow"
                    [ Filters [ Filter.dropShadow 16 16 20 FssTypes.Color.red (pct 5)  ] ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "Filter grayscale"
                    [ Filters [ Filter.grayscale <| pct 50 ] ]
                    [ "filter" ==> "grayscale(50%)" ]
                test
                    "Filter hue-rotate"
                    [ Filters [ Filter.hueRotate 90 ] ]
                    [ "filter" ==> "hue-rotate(90deg)" ]
                test
                    "Filter invert"
                    [ Filters [ Filter.invert <| pct 75 ] ]
                    [ "filter" ==> "invert(75%)" ]
                test
                    "Filter opacity"
                    [ Filters [ Filter.opacity <| pct 25 ] ]
                    [ "filter" ==> "opacity(25%)" ]
                test
                    "Filter saturate"
                    [ Filters [ Filter.saturate <| pct 30 ] ]
                    [ "filter" ==> "saturate(30%)" ]
                test
                    "Filter sepia"
                    [ Filters [ Filter.sepia <| pct 60 ] ]
                    [ "filter" ==> "sepia(60%)" ]
                test
                    "Filter multiple"
                    [ Filters  [ Filter.contrast <| pct 175; Filter.brightness <| pct 3  ] ]
                    [ "filter" ==> "contrast(175%) brightness(3%)" ]
                test
                    "Filter none"
                    [ Filter.none ]
                    [ "filter" ==> "none" ]
                test
                    "Filter inherit"
                    [ Filter.inherit' ]
                    [ "filter" ==> "inherit" ]
                test
                    "Filter initial"
                    [ Filter.initial ]
                    [ "filter" ==> "initial" ]
                test
                    "Filter unset"
                    [ Filter.unset ]
                    [ "filter" ==> "unset" ]
                test
                    "BackdropFilter Url"
                    [ BackdropFilters [ Filter.url "someFilter" ] ]
                    [ "backdropFilter" ==> "url(\"someFilter\")" ]
                test
                    "BackdropFilter blur"
                    [ BackdropFilters [ Filter.blur 50 ] ]
                    [ "backdropFilter" ==> "blur(50px)" ]
                test
                    "BackdropFilter brightness"
                    [ BackdropFilters [ Filter.brightness <| pct 40 ] ]
                    [ "backdropFilter" ==> "brightness(40%)" ]
                test
                    "BackdropFilter contrast"
                    [ BackdropFilters [ Filter.contrast <| pct 40 ] ]
                    [ "backdropFilter" ==> "contrast(40%)" ]
                test
                    "BackdropFilter drop shadow"
                    [ BackdropFilters [ Filter.dropShadow 16 16 20 FssTypes.Color.red (pct 5)  ] ]
                    [ "backdropFilter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "BackdropFilter grayscale"
                    [ BackdropFilters [ Filter.grayscale <| pct 50 ] ]
                    [ "backdropFilter" ==> "grayscale(50%)" ]
                test
                    "BackdropFilter hue-rotate"
                    [ BackdropFilters [ Filter.hueRotate 90 ] ]
                    [ "backdropFilter" ==> "hue-rotate(90deg)" ]
                test
                    "BackdropFilter invert"
                    [ BackdropFilters [ Filter.invert <| pct 75 ] ]
                    [ "backdropFilter" ==> "invert(75%)" ]
                test
                    "BackdropFilter opacity"
                    [ BackdropFilters [ Filter.opacity <| pct 25 ] ]
                    [ "backdropFilter" ==> "opacity(25%)" ]
                test
                    "BackdropFilter saturate"
                    [ BackdropFilters [ Filter.saturate <| pct 30 ] ]
                    [ "backdropFilter" ==> "saturate(30%)" ]
                test
                    "BackdropFilter sepia"
                    [ BackdropFilters [ Filter.sepia <| pct 60 ] ]
                    [ "backdropFilter" ==> "sepia(60%)" ]
                test
                    "BackdropFilter multiple"
                    [ BackdropFilters  [ Filter.contrast <| pct 175; Filter.brightness <| pct 3  ] ]
                    [ "backdropFilter" ==> "contrast(175%) brightness(3%)" ]
                test
                    "BackdropFilter none"
                    [ BackdropFilter.none ]
                    [ "backdropFilter" ==> "none" ]
                test
                    "BackdropFilter inherit"
                    [ BackdropFilter.inherit' ]
                    [ "backdropFilter" ==> "inherit" ]
                test
                    "BackdropFilter initial"
                    [ BackdropFilter.initial ]
                    [ "backdropFilter" ==> "initial" ]
                test
                    "BackdropFilter unset"
                    [ BackdropFilter.unset ]
                    [ "backdropFilter" ==> "unset" ]
            ]