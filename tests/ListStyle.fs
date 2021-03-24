namespace FSSTests

open Fable.Mocha
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
                test
                    "List style None"
                    [ ListStyle.none ]
                    [ "listStyle" ==> "none" ]
                test
                    "List style Initial"
                    [ ListStyle.initial ]
                    [ "listStyle" ==> "initial" ]
                test
                    "List style Inherit"
                    [ ListStyle.inherit' ]
                    [ "listStyle" ==> "inherit" ]
                test
                    "List style Unset"
                    [ ListStyle.unset ]
                    [ "listStyle" ==> "unset" ]
                test
                    "List style image url"
                    [ ListStyleImage.url "foofoo.jpg" ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]
                test
                    "List style image None"
                    [ ListStyleImage.none ]
                    [ "listStyleImage" ==> "none" ]
                test
                    "List style image Initial"
                    [ ListStyleImage.initial ]
                    [ "listStyleImage" ==> "initial" ]
                test
                    "List style image Inherit"
                    [ ListStyleImage.inherit' ]
                    [ "listStyleImage" ==> "inherit" ]
                test
                    "List style image Unset"
                    [ ListStyleImage.unset ]
                    [ "listStyleImage" ==> "unset" ]
                test
                    "List style position inside"
                    [ ListStylePosition.inside]
                    [ "listStylePosition" ==> "inside" ]
                test
                    "List style position outside"
                    [ ListStylePosition.outside ]
                    [ "listStylePosition" ==> "outside" ]
                test
                    "List style position Initial"
                    [ ListStylePosition.initial ]
                    [ "listStylePosition" ==> "initial" ]
                test
                    "List style position Inherit"
                    [ ListStylePosition.inherit' ]
                    [ "listStylePosition" ==> "inherit" ]
                test
                    "List style position Unset"
                    [ ListStylePosition.unset ]
                    [ "listStylePosition" ==> "unset" ]
                test
                    "List style type Disc"
                    [ ListStyleType.disc ]
                    [ "listStyleType" ==> "disc" ]
                test
                    "List style type Circle"
                    [ ListStyleType.circle ]
                    [ "listStyleType" ==> "circle" ]
                test
                    "List style type Square"
                    [ ListStyleType.square ]
                    [ "listStyleType" ==> "square" ]
                test
                    "List style type Decimal"
                    [ ListStyleType.decimal ]
                    [ "listStyleType" ==> "decimal" ]
                test
                    "List style type Georgian"
                    [ ListStyleType.georgian ]
                    [ "listStyleType" ==> "georgian" ]
                test
                    "List style type TradChineseInformal"
                    [ ListStyleType.tradChineseInformal ]
                    [ "listStyleType" ==> "trad-chinese-informal" ]
                test
                    "List style type Kannada"
                    [ ListStyleType.kannada ]
                    [ "listStyleType" ==> "kannada" ]
                test
                    "List style type string"
                    [ ListStyleType' (FssTypes.CssString "-") ]
                    [ "listStyleType" ==> "'-'" ]
                test
                    "List style type custom"
                    [ ListStyleType' sampleCounterStyle ]
                    [ "listStyleType" ==> (FssTypes.counterStyleHelpers.counterStyleToString sampleCounterStyle) ]
                test
                    "List style type None"
                    [ ListStyleType.none ]
                    [ "listStyleType" ==> "none" ]
                test
                    "List style type Initial"
                    [ ListStyleType.initial ]
                    [ "listStyleType" ==> "initial" ]
                test
                    "List style type Inherit"
                    [ ListStyleType.inherit' ]
                    [ "listStyleType" ==> "inherit" ]
                test
                    "List style type Unset"
                    [ ListStyleType.unset ]
                    [ "listStyleType" ==> "unset" ]
            ]