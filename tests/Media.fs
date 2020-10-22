namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Media =
       let tests =
        testList "Media"
            [
                testNested
                    "Media query with min width and min height"
                    [
                        MediaQuery
                            [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ]
                            [ BackgroundColor Color.red ]
                    ]
                    ["@media (min-width: 500px) and (max-width: 700px)" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "Media query min height only"
                    [
                        MediaQuery
                            [ Media.MinHeight (px 700) ]
                            [ BackgroundColor Color.pink ]
                    ]
                    ["@media (min-height: 700px)" ==> "[backgroundColor, #ffc0cb]"]

                test
                    ""
                    [
                        MediaQueryFor Media.Print
                            []
                            [
                                MarginTop (px 200)
                                Transform (Transform.Rotate (deg 45.0))
                                BackgroundColor Color.indianRed
                            ]
                    ]
                    ["" ==> ""]

                test
                    ""
                    [
                        MediaQueryFor Media.Print
                            []
                            [
                                MarginTop (px 200)
                                Transform (Transform.Rotate (deg 45.0))
                                BackgroundColor Color.indianRed
                            ]
                    ]
                    ["" ==> ""]

                test
                    ""
                    [
                        MediaQueryFor (Media.Not Media.All)
                            [ Media.Color ]
                            [
                                MarginTop (px 200)
                                Transform (Transform.Rotate (deg 45.0))
                                BackgroundColor Color.indianRed
                            ]
                    ]
                    ["" ==> ""]

                test
                    ""
                    [
                        MediaQueryFor (Media.Only Media.Screen)
                            [
                                Media.Color
                                Media.Pointer Media.Fine
                                Media.Scan Media.Interlace
                                Media.Grid true
                            ]
                            [
                                MarginTop (px 200)
                                Transform (Transform.Rotate (deg 45.0))
                                BackgroundColor Color.indianRed
                            ]
                    ]
                    ["" ==> ""]

            ]
