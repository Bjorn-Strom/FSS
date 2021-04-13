namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module ListStyle =
    let sampleCounterStyle =
        counterStyle
            [
                Counter.System.alphabetic
            ]

    let tests =
        testList "List style"
            [
                testCase
                    "List style None"
                    [ ListStyle.none ]
                    [ "listStyle" ==> "none" ]
                testCase
                    "List style Initial"
                    [ ListStyle.initial ]
                    [ "listStyle" ==> "initial" ]
                testCase
                    "List style Inherit"
                    [ ListStyle.inherit' ]
                    [ "listStyle" ==> "inherit" ]
                testCase
                    "List style Unset"
                    [ ListStyle.unset ]
                    [ "listStyle" ==> "unset" ]
                testCase
                    "List style image url"
                    [ ListStyleImage.url "foofoo.jpg" ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]
                testCase
                    "List style image None"
                    [ ListStyleImage.none ]
                    [ "listStyleImage" ==> "none" ]
                testCase
                    "List style image Initial"
                    [ ListStyleImage.initial ]
                    [ "listStyleImage" ==> "initial" ]
                testCase
                    "List style image Inherit"
                    [ ListStyleImage.inherit' ]
                    [ "listStyleImage" ==> "inherit" ]
                testCase
                    "List style image Unset"
                    [ ListStyleImage.unset ]
                    [ "listStyleImage" ==> "unset" ]
                testCase
                    "List style position inside"
                    [ ListStylePosition.inside]
                    [ "listStylePosition" ==> "inside" ]
                testCase
                    "List style position outside"
                    [ ListStylePosition.outside ]
                    [ "listStylePosition" ==> "outside" ]
                testCase
                    "List style position Initial"
                    [ ListStylePosition.initial ]
                    [ "listStylePosition" ==> "initial" ]
                testCase
                    "List style position Inherit"
                    [ ListStylePosition.inherit' ]
                    [ "listStylePosition" ==> "inherit" ]
                testCase
                    "List style position Unset"
                    [ ListStylePosition.unset ]
                    [ "listStylePosition" ==> "unset" ]
                testCase
                    "List style type Disc"
                    [ ListStyleType.disc ]
                    [ "listStyleType" ==> "disc" ]
                testCase
                    "List style type Circle"
                    [ ListStyleType.circle ]
                    [ "listStyleType" ==> "circle" ]
                testCase
                    "List style type Square"
                    [ ListStyleType.square ]
                    [ "listStyleType" ==> "square" ]
                testCase
                    "List style type Decimal"
                    [ ListStyleType.decimal ]
                    [ "listStyleType" ==> "decimal" ]
                testCase
                    "List style type Georgian"
                    [ ListStyleType.georgian ]
                    [ "listStyleType" ==> "georgian" ]
                testCase
                    "List style type TradChineseInformal"
                    [ ListStyleType.tradChineseInformal ]
                    [ "listStyleType" ==> "trad-chinese-informal" ]
                testCase
                    "List style type Kannada"
                    [ ListStyleType.kannada ]
                    [ "listStyleType" ==> "kannada" ]
                testCase
                    "List style type string"
                    [ ListStyleType' (FssTypes.CssString "-") ]
                    [ "listStyleType" ==> "'-'" ]
                testCase
                    "List style type custom"
                    [ ListStyleType' sampleCounterStyle ]
                    [ "listStyleType" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                testCase
                    "List style type None"
                    [ ListStyleType.none ]
                    [ "listStyleType" ==> "none" ]
                testCase
                    "List style type Initial"
                    [ ListStyleType.initial ]
                    [ "listStyleType" ==> "initial" ]
                testCase
                    "List style type Inherit"
                    [ ListStyleType.inherit' ]
                    [ "listStyleType" ==> "inherit" ]
                testCase
                    "List style type Unset"
                    [ ListStyleType.unset ]
                    [ "listStyleType" ==> "unset" ]
            ]