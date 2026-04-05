namespace FSSTests

open Fet
open Utils
open Fss

module ContentSizeTests =
    let tests =
        testList "Content size"
            [
                testCase
                    "Width px"
                    [ Width.value (px 100) ]
                    "{width:100px;}"
                testCase
                    "Width percent"
                    [ Width.value (pct 25) ]
                    "{width:25%;}"
                testCase
                    "Width max content"
                    [ Width.maxContent ]
                    "{width:max-content;}"
                testCase
                    "Width min content"
                    [ Width.minContent ]
                    "{width:min-content;}"
                testCase
                    "Width fit content"
                    [ Width.fitContent (px 100) ]
                    "{width:fit-content(100px);}"
                testCase
                    "Width auto"
                    [ Width.auto ]
                    "{width:auto;}"
                testCase
                    "Width initial"
                    [ Width.initial ]
                    "{width:initial;}"
                testCase
                    "Width inherit"
                    [ Width.inherit' ]
                    "{width:inherit;}"
                testCase
                    "Width unset"
                    [ Width.unset ]
                    "{width:unset;}"
                testCase
                    "Width revert"
                    [ Width.revert ]
                    "{width:revert;}"
                testCase
                    "Height px"
                    [ Height.value (px 100) ]
                    "{height:100px;}"
                testCase
                    "Height percent"
                    [ Height.value (pct 25) ]
                    "{height:25%;}"
                testCase
                    "Height max content"
                    [ Height.maxContent ]
                    "{height:max-content;}"
                testCase
                    "Height min content"
                    [ Height.minContent ]
                    "{height:min-content;}"
                testCase
                    "Height fit content"
                    [ Height.fitContent (px 100) ]
                    "{height:fit-content(100px);}"
                testCase
                    "Height auto"
                    [ Height.auto ]
                    "{height:auto;}"
                testCase
                    "Height initial"
                    [ Height.initial ]
                    "{height:initial;}"
                testCase
                    "Height inherit"
                    [ Height.inherit' ]
                    "{height:inherit;}"
                testCase
                    "Height unset"
                    [ Height.unset ]
                    "{height:unset;}"
                testCase
                    "Height revert"
                    [ Height.revert ]
                    "{height:revert;}"
                testCase
                    "MinWidth px"
                    [ MinWidth.value (px 100) ]
                    "{min-width:100px;}"
                testCase
                    "MinWidth percent"
                    [ MinWidth.value (pct 25) ]
                    "{min-width:25%;}"
                testCase
                    "MinWidth max content"
                    [ MinWidth.maxContent ]
                    "{min-width:max-content;}"
                testCase
                    "MinWidth min content"
                    [ MinWidth.minContent ]
                    "{min-width:min-content;}"
                testCase
                    "MinWidth fit content"
                    [ MinWidth.fitContent (px 100) ]
                    "{min-width:fit-content(100px);}"
                testCase
                    "MinWidth auto"
                    [ MinWidth.auto ]
                    "{min-width:auto;}"
                testCase
                    "MinWidth initial"
                    [ MinWidth.initial ]
                    "{min-width:initial;}"
                testCase
                    "MinWidth inherit"
                    [ MinWidth.inherit' ]
                    "{min-width:inherit;}"
                testCase
                    "MinWidth unset"
                    [ MinWidth.unset ]
                    "{min-width:unset;}"
                testCase
                    "MinWidth revert"
                    [ MinWidth.revert ]
                    "{min-width:revert;}"
                testCase
                    "MinHeight px"
                    [ MinHeight.value (px 100) ]
                    "{min-height:100px;}"
                testCase
                    "MinHeight percent"
                    [ MinHeight.value (pct 25) ]
                    "{min-height:25%;}"
                testCase
                    "MinHeight max content"
                    [ MinHeight.maxContent ]
                    "{min-height:max-content;}"
                testCase
                    "MinHeight min content"
                    [ MinHeight.minContent ]
                    "{min-height:min-content;}"
                testCase
                    "MinHeight fit content"
                    [ MinHeight.fitContent (px 100) ]
                    "{min-height:fit-content(100px);}"
                testCase
                    "MinHeight auto"
                    [ MinHeight.auto ]
                    "{min-height:auto;}"
                testCase
                    "MinHeight initial"
                    [ MinHeight.initial ]
                    "{min-height:initial;}"
                testCase
                    "MinHeight inherit"
                    [ MinHeight.inherit' ]
                    "{min-height:inherit;}"
                testCase
                    "MinHeight unset"
                    [ MinHeight.unset ]
                    "{min-height:unset;}"
                testCase
                    "MinHeight revert"
                    [ MinHeight.revert ]
                    "{min-height:revert;}"
                // Logical size properties
                testCase
                    "InlineSize px"
                    [ InlineSize.value (px 200) ]
                    "{inline-size:200px;}"
                testCase
                    "InlineSize auto"
                    [ InlineSize.auto ]
                    "{inline-size:auto;}"
                testCase
                    "InlineSize max-content"
                    [ InlineSize.maxContent ]
                    "{inline-size:max-content;}"
                testCase
                    "InlineSize min-content"
                    [ InlineSize.minContent ]
                    "{inline-size:min-content;}"
                testCase
                    "InlineSize inherit"
                    [ InlineSize.inherit' ]
                    "{inline-size:inherit;}"
                testCase
                    "BlockSize px"
                    [ BlockSize.value (px 100) ]
                    "{block-size:100px;}"
                testCase
                    "BlockSize auto"
                    [ BlockSize.auto ]
                    "{block-size:auto;}"
                testCase
                    "BlockSize pct"
                    [ BlockSize.value (pct 50) ]
                    "{block-size:50%;}"
                testCase
                    "BlockSize inherit"
                    [ BlockSize.inherit' ]
                    "{block-size:inherit;}"
                testCase
                    "MinInlineSize px"
                    [ MinInlineSize.value (px 100) ]
                    "{min-inline-size:100px;}"
                testCase
                    "MinBlockSize px"
                    [ MinBlockSize.value (px 50) ]
                    "{min-block-size:50px;}"
                testCase
                    "MaxInlineSize px"
                    [ MaxInlineSize.value (px 500) ]
                    "{max-inline-size:500px;}"
                testCase
                    "MaxBlockSize px"
                    [ MaxBlockSize.value (px 300) ]
                    "{max-block-size:300px;}"
                // Dynamic/Small/Large viewport units
                testCase
                    "Height dvh"
                    [ Height.value (dvh 100) ]
                    "{height:100dvh;}"
                testCase
                    "Width dvw"
                    [ Width.value (dvw 100) ]
                    "{width:100dvw;}"
                testCase
                    "Height svh"
                    [ Height.value (svh 100) ]
                    "{height:100svh;}"
                testCase
                    "Width svw"
                    [ Width.value (svw 100) ]
                    "{width:100svw;}"
                testCase
                    "Height lvh"
                    [ Height.value (lvh 100) ]
                    "{height:100lvh;}"
                testCase
                    "Width lvw"
                    [ Width.value (lvw 100) ]
                    "{width:100lvw;}"
                testCase
                    "MinHeight dvh"
                    [ MinHeight.value (dvh 50) ]
                    "{min-height:50dvh;}"
                testCase
                    "MaxWidth svw"
                    [ MaxWidth.value (svw 80) ]
                    "{max-width:80svw;}"
                // Container query units
                testCase
                    "Width cqw"
                    [ Width.value (cqw 50) ]
                    "{width:50cqw;}"
                testCase
                    "Height cqh"
                    [ Height.value (cqh 100) ]
                    "{height:100cqh;}"
                testCase
                    "Width cqi"
                    [ Width.value (cqi 75) ]
                    "{width:75cqi;}"
                testCase
                    "Height cqb"
                    [ Height.value (cqb 50) ]
                    "{height:50cqb;}"
            ]
