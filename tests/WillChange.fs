namespace FSSTests

open Fet
open Utils
open Fss

module WillChange =
     let tests =
        testList "WillChange"
            [
                testCase
                    "Will change ident"
                    [ WillChange.value "opacity" ]
                    "will-change: opacity;"
                testCase
                    "Will change idents"
                    [ WillChange.value ["left"; "top"] ]
                    "will-change: left, top;"
                testCase
                    "Will change contents"
                    [ WillChange.contents ]
                    "will-change: contents;"
                testCase
                    "Will change scroll position"
                    [ WillChange.scrollPosition ]
                    "will-change: scroll-position;"
                testCase
                    "Will change auto"
                    [ WillChange.auto ]
                    "will-change: auto;"
                testCase
                    "Will change initial"
                    [ WillChange.initial ]
                    "will-change: initial;"
                testCase
                    "Will change inherit"
                    [ WillChange.inherit' ]
                    "will-change: inherit;"
                testCase
                    "Will change unset"
                    [ WillChange.unset ]
                    "will-change: unset;"
                testCase
                    "Will change revert"
                    [ WillChange.revert ]
                    "will-change: revert;"
            ]