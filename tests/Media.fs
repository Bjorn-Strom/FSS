namespace FSSTests

open Fss
open Fable.Mocha
open Fable.Core.JsInterop
open Utils

module Media =
    let tests =
       testList "Media"
            [
                testNested
                    "Media query with min width and min height"
                    [
                        MediaQuery
                            [ Types.Media.MinWidth (px 500); Types.Media.MaxWidth (px 700) ]
                            [ BackgroundColor.red ]
                    ]
                    ["@media (min-width: 500px) and (max-width: 700px)" ==> "backgroundColor,#ff0000"]
                testNested
                    "Media query min height only"
                    [
                        MediaQuery
                            [ Types.Media.MinHeight (px 700) ]
                            [ BackgroundColor.pink ]
                    ]
                    ["@media (min-height: 700px)" ==> "backgroundColor,#ffc0cb"]
                testNested
                    "Media query for print"
                    [
                        MediaQueryFor Types.Media.Print []
                            [
                                MarginTop' (px 200)
                                Transforms
                                    [
                                        Transform.Rotate (deg 45.0)
                                    ]
                                BackgroundColor.indianRed
                            ]
                    ]
                    ["@media print " ==> "marginTop,200px,transform,rotate(45.00deg),backgroundColor,#cd5c5c"]
                testNested
                    "Media not all"
                    [
                        MediaQueryFor (Types.Media.Not Types.Media.Device.All) [ Types.Media.Feature.Color ] [ MarginTop' (px 200) ]
                    ]
                    ["@media not all and (color)" ==> "marginTop,200px"]
                testNested
                    "Media query only screen"
                    [
                        MediaQueryFor (Types.Media.Only Types.Media.Device.Screen)
                            [
                                Types.Media.Feature.Color
                                Types.Media.Feature.Pointer Types.Media.Fine
                                Types.Media.Feature.Scan Types.Media.Interlace
                                Types.Media.Feature.Grid true
                            ]
                            [
                                MarginTop' (px 200)
                                Transforms
                                    [
                                        Transform.Rotate (deg 45.0)
                                    ]
                                BackgroundColor.indianRed
                            ]
                    ]
                    [
                        "@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: 1)"
                        ==>
                        "marginTop,200px,transform,rotate(45.00deg),backgroundColor,#cd5c5c"
                    ]
            ]
