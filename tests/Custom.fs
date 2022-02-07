namespace FSSTests

open Fet
open Utils
open Fss

module CustomTests =
     let tests =
        testList "Custom"
            [
                testCase
                    "Can set custom border"
                    [Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
                    "{ border: 4mm ridge rgba(170, 50, 220, .6); }"
            ]