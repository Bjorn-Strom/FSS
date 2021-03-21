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
                    [ Filters [ Filter.Url "someFilter" ] ]
                    [ "filter" ==> "url(\"someFilter\")" ]
                test
                    "Filter blur"
                    [ Filters [ Filter.Blur 50 ] ]
                    [ "filter" ==> "blur(50px)" ]
                test
                    "Filter brightness"
                    [ Filters [ Filter.Brightness <| pct 40 ] ]
                    [ "filter" ==> "brightness(40%)" ]
                test
                    "Filter contras"
                    [ Filters [ Filter.Contrast <| pct 40 ] ]
                    [ "filter" ==> "contrast(40%)" ]
                test
                    "Filter drop shadow"
                    [ Filters [ Filter.DropShadow 16 16 20 Types.Color.red (pct 5)  ] ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "Filter grayscale"
                    [ Filters [ Filter.Grayscale <| pct 50 ] ]
                    [ "filter" ==> "grayscale(50%)" ]
                test
                    "Filter hue-rotate"
                    [ Filters [ Filter.HueRotate 90 ] ]
                    [ "filter" ==> "hue-rotate(90deg)" ]
                test
                    "Filter invert"
                    [ Filters [ Filter.Invert <| pct 75 ] ]
                    [ "filter" ==> "invert(75%)" ]
                test
                    "Filter opacity"
                    [ Filters [ Filter.Opacity <| pct 25 ] ]
                    [ "filter" ==> "opacity(25%)" ]
                test
                    "Filter saturate"
                    [ Filters [ Filter.Saturate <| pct 30 ] ]
                    [ "filter" ==> "saturate(30%)" ]
                test
                    "Filter sepia"
                    [ Filters [ Filter.Sepia <| pct 60 ] ]
                    [ "filter" ==> "sepia(60%)" ]
                test
                    "Filter multiple"
                    [ Filters  [ Filter.Contrast <| pct 175; Filter.Brightness <| pct 3  ] ]
                    [ "filter" ==> "contrast(175%) brightness(3%)" ]
                test
                    "Filter none"
                    [ Filter.None ]
                    [ "filter" ==> "none" ]
                test
                    "Filter inherit"
                    [ Filter.Inherit ]
                    [ "filter" ==> "inherit" ]
                test
                    "Filter initial"
                    [ Filter.Initial ]
                    [ "filter" ==> "initial" ]
                test
                    "Filter unset"
                    [ Filter.Unset ]
                    [ "filter" ==> "unset" ]
                test
                    "BackdropFilter Url"
                    [ BackdropFilters [ Filter.Url "someFilter" ] ]
                    [ "backdropFilter" ==> "url(\"someFilter\")" ]
                test
                    "BackdropFilter blur"
                    [ BackdropFilters [ Filter.Blur 50 ] ]
                    [ "backdropFilter" ==> "blur(50px)" ]
                test
                    "BackdropFilter brightness"
                    [ BackdropFilters [ Filter.Brightness <| pct 40 ] ]
                    [ "backdropFilter" ==> "brightness(40%)" ]
                test
                    "BackdropFilter contrast"
                    [ BackdropFilters [ Filter.Contrast <| pct 40 ] ]
                    [ "backdropFilter" ==> "contrast(40%)" ]
                test
                    "BackdropFilter drop shadow"
                    [ BackdropFilters [ Filter.DropShadow 16 16 20 Types.Color.red (pct 5)  ] ]
                    [ "backdropFilter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "BackdropFilter grayscale"
                    [ BackdropFilters [ Filter.Grayscale <| pct 50 ] ]
                    [ "backdropFilter" ==> "grayscale(50%)" ]
                test
                    "BackdropFilter hue-rotate"
                    [ BackdropFilters [ Filter.HueRotate 90 ] ]
                    [ "backdropFilter" ==> "hue-rotate(90deg)" ]
                test
                    "BackdropFilter invert"
                    [ BackdropFilters [ Filter.Invert <| pct 75 ] ]
                    [ "backdropFilter" ==> "invert(75%)" ]
                test
                    "BackdropFilter opacity"
                    [ BackdropFilters [ Filter.Opacity <| pct 25 ] ]
                    [ "backdropFilter" ==> "opacity(25%)" ]
                test
                    "BackdropFilter saturate"
                    [ BackdropFilters [ Filter.Saturate <| pct 30 ] ]
                    [ "backdropFilter" ==> "saturate(30%)" ]
                test
                    "BackdropFilter sepia"
                    [ BackdropFilters [ Filter.Sepia <| pct 60 ] ]
                    [ "backdropFilter" ==> "sepia(60%)" ]
                test
                    "BackdropFilter multiple"
                    [ BackdropFilters  [ Filter.Contrast <| pct 175; Filter.Brightness <| pct 3  ] ]
                    [ "backdropFilter" ==> "contrast(175%) brightness(3%)" ]
                test
                    "BackdropFilter none"
                    [ BackdropFilter.None ]
                    [ "backdropFilter" ==> "none" ]
                test
                    "BackdropFilter inherit"
                    [ BackdropFilter.Inherit ]
                    [ "backdropFilter" ==> "inherit" ]
                test
                    "BackdropFilter initial"
                    [ BackdropFilter.Initial ]
                    [ "backdropFilter" ==> "initial" ]
                test
                    "BackdropFilter unset"
                    [ BackdropFilter.Unset ]
                    [ "backdropFilter" ==> "unset" ]
            ]