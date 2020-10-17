namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module ListStyle =
    let sampleCounterStyle =
        counterStyle
            [
                System Counter.Alphabetic
            ]

    let tests =
        testList "List style"
            [
                test
                    "List style image url"
                    [ ListStyleImage (ListStyle.Url "foofoo.jpg") ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]

                test
                    "List style image None"
                    [ ListStyleImage None ]
                    [ "listStyleImage" ==> "none" ]

                test
                    "List style image Initial"
                    [ ListStyleImage Initial ]
                    [ "listStyleImage" ==> "initial" ]

                test
                    "List style image Inherit"
                    [ ListStyleImage Inherit ]
                    [ "listStyleImage" ==> "inherit" ]

                test
                    "List style image Unset"
                    [ ListStyleImage Unset ]
                    [ "listStyleImage" ==> "unset" ]

                test
                    "List style position inside"
                    [ ListStylePosition ListStyle.Inside]
                    [ "listStylePosition" ==> "inside" ]

                test
                    "List style position outside"
                    [ ListStylePosition ListStyle.Outside ]
                    [ "listStylePosition" ==> "outside" ]

                test
                    "List style position Initial"
                    [ ListStylePosition Initial ]
                    [ "listStylePosition" ==> "initial" ]

                test
                    "List style position Inherit"
                    [ ListStylePosition Inherit ]
                    [ "listStylePosition" ==> "inherit" ]

                test
                    "List style position Unset"
                    [ ListStylePosition Unset ]
                    [ "listStylePosition" ==> "unset" ]

                test
                    "List style type Disc"
                    [ ListStyleType ListStyle.Disc ]
                    [ "listStyleType" ==> "disc" ]

                test
                    "List style type Circle"
                    [ ListStyleType ListStyle.Circle ]
                    [ "listStyleType" ==> "circle" ]

                test
                    "List style type Square"
                    [ ListStyleType ListStyle.Square ]
                    [ "listStyleType" ==> "square" ]

                test
                    "List style type Decimal"
                    [ ListStyleType ListStyle.Decimal ]
                    [ "listStyleType" ==> "decimal" ]

                test
                    "List style type Georgian"
                    [ ListStyleType ListStyle.Georgian ]
                    [ "listStyleType" ==> "georgian" ]

                test
                    "List style type TradChineseInformal"
                    [ ListStyleType ListStyle.TradChineseInformal ]
                    [ "listStyleType" ==> "trad-chinese-informal" ]

                test
                    "List style type Kannada"
                    [ ListStyleType ListStyle.Kannada ]
                    [ "listStyleType" ==> "kannada" ]

                test
                    "List style type string"
                    [ ListStyleType (ListStyle.String "-") ]
                    [ "listStyleType" ==> "'-'" ]

                test
                    "List style type custom"
                    [ ListStyleType (ListStyle.Custom sampleCounterStyle) ]
                    [ "listStyleType" ==> "a1013904226" ]

                test
                    "List style type Initial"
                    [ ListStyleType Initial ]
                    [ "listStyleType" ==> "initial" ]

                test
                    "List style type Inherit"
                    [ ListStyleType Inherit ]
                    [ "listStyleType" ==> "inherit" ]

                test
                    "List style type Unset"
                    [ ListStyleType Unset ]
                    [ "listStyleType" ==> "unset" ]

            ]