namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Filter =
     let tests =
        testList "Filter"
            [
                test
                    "Filter Url"
                    [ Filter.Url "someFilter"]
                    [ "filter" ==> "url(\"someFilter\")" ]
                test
                    "Filter blur"
                    [ Filter.Blur 50 ]
                    [ "filter" ==> "blur(50px)" ]
                test
                    "Filter brightness"
                    [ Filter.Brightness <| pct 40 ]
                    [ "filter" ==> "brightness(40%)" ]
                test
                    "Filter contrast"
                    [ Filter.Contrast <| pct 40 ]
                    [ "filter" ==> "contrast(40%)" ]
                test
                    "Filter drop shadow"
                    [ Filter.DropShadow 16 16 20 CssColor.red (pct 5)  ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "Filter grayscale"
                    [ Filter.Grayscale <| pct 50 ]
                    [ "filter" ==> "grayscale(50%)" ]
                test
                    "Filter hue-rotate"
                    [ Filter.HueRotate 90 ]
                    [ "filter" ==> "hue-rotate(90deg)" ]
                test
                    "Filter invert"
                    [ Filter.Invert <| pct 75 ]
                    [ "filter" ==> "invert(75%)" ]
                test
                    "Filter opacity"
                    [ Filter.Opacity <| pct 25 ]
                    [ "filter" ==> "opacity(25%)" ]
                test
                    "Filter saturate"
                    [ Filter.Saturate <| pct 30 ]
                    [ "filter" ==> "saturate(30%)" ]
                test
                    "Filter sepia"
                    [ Filter.Sepia <| pct 60 ]
                    [ "filter" ==> "sepia(60%)" ]
                test
                    "Filter multiple"
                    [ Filter.Values [ FilterType.Contrast <| pct 175; FilterType.Brightness <| pct 3  ] ]
                    [ "filter" ==> "contrast(175%) brightness(3%)" ]
                test
                    "Filter none"
                    [ Filter.None]
                    [ "filter" ==> "none" ]
                test
                    "Filter inherit"
                    [ Filter.Inherit]
                    [ "filter" ==> "inherit" ]
                test
                    "Filter initial"
                    [ Filter.Initial]
                    [ "filter" ==> "initial" ]
                test
                    "Filter unset"
                    [ Filter.Unset ]
                    [ "filter" ==> "unset" ]
            ]