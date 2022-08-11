namespace FSSTests

open Fet
open Utils
open Fss

module AllTests =
     let tests =
        testList "All"
            [
                testCase
                    "All inherit"
                    [ All.inherit']
                    "{all:inherit;}"
                testCase
                    "All initial"
                    [ All.initial]
                    "{all:initial;}"
                testCase
                    "All unset"
                    [ All.unset ]
                    "{all:unset;}"
                testCase
                    "All revert"
                    [ All.revert ]
                    "{all:revert;}"
            ]
