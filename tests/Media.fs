namespace FSSTests

open Fss
open Fable.Mocha
open Fable.Core.JsInterop
open Utils

module Media =
    let tests =
       testList "Media"
            [
                testMedia
                    "Media query with min width and min height"
                    [ FssTypes.Media.MinWidth (px 500); FssTypes.Media.MaxWidth (px 700) ]
                    [ BackgroundColor.red ]
                    ("@media (min-width: 500px) and (max-width: 700px)" ==> "[backgroundColor,#ff0000]")
                testMedia
                    "Media query min height only"
                        [ FssTypes.Media.MinHeight (px 700) ]
                        [ BackgroundColor.pink ]
                        ("@media (min-height: 700px)" ==> "[backgroundColor,#ffc0cb]")
                testMediaFor
                    "Media query for print"
                        (FssTypes.Media.Print)
                        []
                        [
                            MarginTop' (px 200)
                            Transforms
                                [
                                Transform.rotate (deg 45.0)
                                    ]
                            BackgroundColor.indianRed
                            ]
                    ("@media print " ==> "[marginTop,200px; transform,rotate(45.00deg); backgroundColor,#cd5c5c]")
                testMediaFor
                    "Media not all"
                        (FssTypes.Media.Not FssTypes.Media.Device.All)
                        [ FssTypes.Media.Feature.Color ]
                        [MarginTop' (px 200) ]
                        ("@media not all and (color)" ==> "[marginTop,200px]")
                testMediaFor
                    "Media query only screen"
                    (FssTypes.Media.Only FssTypes.Media.Device.Screen)
                    [
                        FssTypes.Media.Feature.Color
                        FssTypes.Media.Feature.Pointer FssTypes.Media.Fine
                        FssTypes.Media.Feature.Scan FssTypes.Media.Interlace
                        FssTypes.Media.Feature.Grid true
                    ]
                    [
                        MarginTop' (px 200)
                        Transforms
                            [
                                Transform.rotate (deg 45.0)
                            ]
                        BackgroundColor.indianRed
                    ]
                    ("@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: 1)"
                    ==>
                    "[marginTop,200px; transform,rotate(45.00deg); backgroundColor,#cd5c5c]")
            ]
