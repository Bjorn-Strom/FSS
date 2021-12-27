namespace FSSTests

open Fet
open Utils
open Fss

module ListStyle =
    let tests =
        testList "List style"
            [
                testCase
                    "List style None"
                    [ ListStyle.none ]
                    "list-style: none;"
                testCase
                    "List style Initial"
                    [ ListStyle.initial ]
                    "list-style: initial;"
                testCase
                    "List style Inherit"
                    [ ListStyle.inherit' ]
                    "list-style: inherit;"
                testCase
                    "List style Unset"
                    [ ListStyle.unset ]
                    "list-style: unset;"
                testCase
                    "List style revert"
                    [ ListStyle.revert ]
                    "list-style: revert;"
                testCase
                    "List style image url"
                    [ ListStyleImage.url "foofoo.jpg" ]
                    "list-style-image: url(foofoo.jpg);"
                testCase
                    "List style image None"
                    [ ListStyleImage.none ]
                    "list-style-image: none;"
                testCase
                    "List style image Initial"
                    [ ListStyleImage.initial ]
                    "list-style-image: initial;"
                testCase
                    "List style image Inherit"
                    [ ListStyleImage.inherit' ]
                    "list-style-image: inherit;"
                testCase
                    "List style image Unset"
                    [ ListStyleImage.unset ]
                    "list-style-image: unset;"
                testCase
                    "List style image revert"
                    [ ListStyleImage.revert ]
                    "list-style-image: revert;"
                testCase
                    "List style position inside"
                    [ ListStylePosition.inside]
                    "list-style-position: inside;"
                testCase
                    "List style position outside"
                    [ ListStylePosition.outside ]
                    "list-style-position: outside;"
                testCase
                    "List style position Initial"
                    [ ListStylePosition.initial ]
                    "list-style-position: initial;"
                testCase
                    "List style position Inherit"
                    [ ListStylePosition.inherit' ]
                    "list-style-position: inherit;"
                testCase
                    "List style position Unset"
                    [ ListStylePosition.unset ]
                    "list-style-position: unset;"
                testCase
                    "List style position revert"
                    [ ListStylePosition.revert ]
                    "list-style-position: revert;"
                testCase
                    "List style type Disc"
                    [ ListStyleType.disc ]
                    "list-style-type: disc;"
                testCase
                    "List style type Circle"
                    [ ListStyleType.circle ]
                    "list-style-type: circle;"
                testCase
                    "List style type Square"
                    [ ListStyleType.square ]
                    "list-style-type: square;"
                testCase
                    "List style type Decimal"
                    [ ListStyleType.decimal ]
                    "list-style-type: decimal;"
                testCase
                    "List style type Georgian"
                    [ ListStyleType.georgian ]
                    "list-style-type: georgian;"
                testCase
                    "List style type TradChineseInformal"
                    [ ListStyleType.tradChineseInformal ]
                    "list-style-type: trad-chinese-informal;"
                testCase
                    "List style type Kannada"
                    [ ListStyleType.kannada ]
                    "list-style-type: kannada;"
                testCase
                    "List style type string"
                    [ ListStyleType.string "-" ]
                    "list-style-type: '-';"
                testCase
                    "List style type string"
                    [ ListStyleType.ident "Some list style" ]
                    "list-style-type: Some list style;"
                testCase
                    "List style type None"
                    [ ListStyleType.none ]
                    "list-style-type: none;"
                testCase
                    "List style type Initial"
                    [ ListStyleType.initial ]
                    "list-style-type: initial;"
                testCase
                    "List style type Inherit"
                    [ ListStyleType.inherit' ]
                    "list-style-type: inherit;"
                testCase
                    "List style type Unset"
                    [ ListStyleType.unset ]
                    "list-style-type: unset;"
                testCase
                    "List style type revert"
                    [ ListStyleType.revert ]
                    "list-style-type: revert;"
            ]