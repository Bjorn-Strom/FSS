namespace FSSTests

open Fet
open Utils
open Fss

module ContentSize =
    let tests =
        testList "Content size"
            [
                testCase
                    "Width px"
                    [ Width.value (px 100) ]
                    "width: 100px;"
                testCase
                    "Width percent"
                    [ Width.value (pct 25) ]
                    "width: 25%;"
                testCase
                    "Width max content"
                    [ Width.maxContent ]
                    "width: max-content;"
                testCase
                    "Width min content"
                    [ Width.minContent ]
                    "width: min-content;"
                testCase
                    "Width fit content"
                    [ Width.fitContent (px 100) ]
                    "width: fit-content(100px);"
                testCase
                    "Width auto"
                    [ Width.auto ]
                    "width: auto;"
                testCase
                    "Width initial"
                    [ Width.initial ]
                    "width: initial;"
                testCase
                    "Width inherit"
                    [ Width.inherit' ]
                    "width: inherit;"
                testCase
                    "Width unset"
                    [ Width.unset ]
                    "width: unset;"
                testCase
                    "Width revert"
                    [ Width.revert ]
                    "width: revert;"
                testCase
                    "Height px"
                    [ Height.value (px 100) ]
                    "height: 100px;"
                testCase
                    "Height percent"
                    [ Height.value (pct 25) ]
                    "height: 25%;"
                testCase
                    "Height max content"
                    [ Height.maxContent ]
                    "height: max-content;"
                testCase
                    "Height min content"
                    [ Height.minContent ]
                    "height: min-content;"
                testCase
                    "Height fit content"
                    [ Height.fitContent (px 100) ]
                    "height: fit-content(100px);"
                testCase
                    "Height auto"
                    [ Height.auto ]
                    "height: auto;"
                testCase
                    "Height initial"
                    [ Height.initial ]
                    "height: initial;"
                testCase
                    "Height inherit"
                    [ Height.inherit' ]
                    "height: inherit;"
                testCase
                    "Height unset"
                    [ Height.unset ]
                    "height: unset;"
                testCase
                    "Height revert"
                    [ Height.revert ]
                    "height: revert;"
                testCase
                    "MinWidth px"
                    [ MinWidth.value (px 100) ]
                    "min-width: 100px;"
                testCase
                    "MinWidth percent"
                    [ MinWidth.value (pct 25) ]
                    "min-width: 25%;"
                testCase
                    "MinWidth max content"
                    [ MinWidth.maxContent ]
                    "min-width: max-content;"
                testCase
                    "MinWidth min content"
                    [ MinWidth.minContent ]
                    "min-width: min-content;"
                testCase
                    "MinWidth fit content"
                    [ MinWidth.fitContent (px 100) ]
                    "min-width: fit-content(100px);"
                testCase
                    "MinWidth auto"
                    [ MinWidth.auto ]
                    "min-width: auto;"
                testCase
                    "MinWidth initial"
                    [ MinWidth.initial ]
                    "min-width: initial;"
                testCase
                    "MinWidth inherit"
                    [ MinWidth.inherit' ]
                    "min-width: inherit;"
                testCase
                    "MinWidth unset"
                    [ MinWidth.unset ]
                    "min-width: unset;"
                testCase
                    "MinWidth revert"
                    [ MinWidth.revert ]
                    "min-width: revert;"
                testCase
                    "MinHeight px"
                    [ MinHeight.value (px 100) ]
                    "min-height: 100px;"
                testCase
                    "MinHeight percent"
                    [ MinHeight.value (pct 25) ]
                    "min-height: 25%;"
                testCase
                    "MinHeight max content"
                    [ MinHeight.maxContent ]
                    "min-height: max-content;"
                testCase
                    "MinHeight min content"
                    [ MinHeight.minContent ]
                    "min-height: min-content;"
                testCase
                    "MinHeight fit content"
                    [ MinHeight.fitContent (px 100) ]
                    "min-height: fit-content(100px);"
                testCase
                    "MinHeight auto"
                    [ MinHeight.auto ]
                    "min-height: auto;"
                testCase
                    "MinHeight initial"
                    [ MinHeight.initial ]
                    "min-height: initial;"
                testCase
                    "MinHeight inherit"
                    [ MinHeight.inherit' ]
                    "min-height: inherit;"
                testCase
                    "MinHeight unset"
                    [ MinHeight.unset ]
                    "min-height: unset;"
                testCase
                    "MinHeight revert"
                    [ MinHeight.revert ]
                    "min-height: revert;"
            ]