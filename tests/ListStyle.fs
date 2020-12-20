namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module ListStyle =
    let sampleCounterStyle =
        counterStyle
            [
                Counter.System.Alphabetic
            ]

    let tests =
        testList "List style"
            [
                test
                    "List style None"
                    [ ListStyle.None ]
                    [ "listStyle" ==> "none" ]
                test
                    "List style Initial"
                    [ ListStyle.Initial ]
                    [ "listStyle" ==> "initial" ]
                test
                    "List style Inherit"
                    [ ListStyle.Inherit ]
                    [ "listStyle" ==> "inherit" ]
                test
                    "List style Unset"
                    [ ListStyle.Unset ]
                    [ "listStyle" ==> "unset" ]
                test
                    "List style image url"
                    [ ListStyleImage.Url "foofoo.jpg" ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]
                test
                    "List style image None"
                    [ ListStyleImage.None ]
                    [ "listStyleImage" ==> "none" ]
                test
                    "List style image Initial"
                    [ ListStyleImage.Initial ]
                    [ "listStyleImage" ==> "initial" ]
                test
                    "List style image Inherit"
                    [ ListStyleImage.Inherit ]
                    [ "listStyleImage" ==> "inherit" ]
                test
                    "List style image Unset"
                    [ ListStyleImage.Unset ]
                    [ "listStyleImage" ==> "unset" ]
                test
                    "List style position inside"
                    [ ListStylePosition.Inside]
                    [ "listStylePosition" ==> "inside" ]
                test
                    "List style position outside"
                    [ ListStylePosition.Outside ]
                    [ "listStylePosition" ==> "outside" ]
                test
                    "List style position Initial"
                    [ ListStylePosition.Initial ]
                    [ "listStylePosition" ==> "initial" ]
                test
                    "List style position Inherit"
                    [ ListStylePosition.Inherit ]
                    [ "listStylePosition" ==> "inherit" ]
                test
                    "List style position Unset"
                    [ ListStylePosition.Unset ]
                    [ "listStylePosition" ==> "unset" ]
                test
                    "List style type Disc"
                    [ ListStyleType.Disc ]
                    [ "listStyleType" ==> "disc" ]
                test
                    "List style type Circle"
                    [ ListStyleType.Circle ]
                    [ "listStyleType" ==> "circle" ]
                test
                    "List style type Square"
                    [ ListStyleType.Square ]
                    [ "listStyleType" ==> "square" ]
                test
                    "List style type Decimal"
                    [ ListStyleType.Decimal ]
                    [ "listStyleType" ==> "decimal" ]
                test
                    "List style type Georgian"
                    [ ListStyleType.Georgian ]
                    [ "listStyleType" ==> "georgian" ]
                test
                    "List style type TradChineseInformal"
                    [ ListStyleType.TradChineseInformal ]
                    [ "listStyleType" ==> "trad-chinese-informal" ]
                test
                    "List style type Kannada"
                    [ ListStyleType.Kannada ]
                    [ "listStyleType" ==> "kannada" ]
                test
                    "List style type string"
                    [ ListStyleType' (CssString "-") ]
                    [ "listStyleType" ==> "'-'" ]
                test
                    "List style type custom"
                    [ ListStyleType' sampleCounterStyle ]
                    [ "listStyleType" ==> "_223772456" ]
                test
                    "List style type None"
                    [ ListStyleType.None ]
                    [ "listStyleType" ==> "none" ]
                test
                    "List style type Initial"
                    [ ListStyleType.Initial ]
                    [ "listStyleType" ==> "initial" ]
                test
                    "List style type Inherit"
                    [ ListStyleType.Inherit ]
                    [ "listStyleType" ==> "inherit" ]
                test
                    "List style type Unset"
                    [ ListStyleType.Unset ]
                    [ "listStyleType" ==> "unset" ]
            ]