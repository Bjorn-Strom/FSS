namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Column =
    let tests =
        testList "Column"
            [
                test
                    "Column gap normal"
                    [ColumnGap.Normal]
                    ["columnGap" ==> "normal"]
                test
                    "Column gap px"
                    [ColumnGap' (px 3)]
                    ["columnGap" ==> "3px"]
                test
                    "Column gap em"
                    [ColumnGap' (em 2.5)]
                    ["columnGap" ==> "2.5em"]
                test
                    "Column gap percent"
                    [ColumnGap' (pct 3)]
                    ["columnGap" ==> "3%"]
                test
                    "Column gap inherit"
                    [ColumnGap.Inherit]
                    ["columnGap" ==> "inherit"]
                test
                    "Column gap initial"
                    [ColumnGap.Initial]
                    ["columnGap" ==> "initial"]
                test
                    "Column gap unset"
                    [ColumnGap.Unset]
                    ["columnGap" ==> "unset"]
                test
                    "Column span all"
                    [ColumnSpan.All]
                    ["columnSpan" ==> "all"]
                test
                    "Column span none"
                    [ColumnSpan.None]
                    ["columnSpan" ==> "none"]
                test
                    "Column span inherit"
                    [ColumnSpan.Inherit]
                    ["columnSpan" ==> "inherit"]
                test
                    "Column span initial"
                    [ColumnSpan.Initial]
                    ["columnSpan" ==> "initial"]
                test
                    "Column span unset"
                    [ColumnSpan.Unset]
                    ["columnSpan" ==> "unset"]
                test
                    "Column rule width thin"
                    [ColumnRuleWidth.Thin]
                    ["columnRuleWidth" ==> "thin"]
                test
                    "Column rule width medium"
                    [ColumnRuleWidth.Medium]
                    ["columnRuleWidth" ==> "medium"]
                test
                    "Column rule width thick"
                    [ColumnRuleWidth.Thick]
                    ["columnRuleWidth" ==> "thick"]
                test
                    "Column rule width px"
                    [ColumnRuleWidth' (px 1)]
                    ["columnRuleWidth" ==> "1px"]
                test
                    "Column rule width em"
                    [ColumnRuleWidth' (em 2.5)]
                    ["columnRuleWidth" ==> "2.5em"]
                test
                    "Column rule width Inherit"
                    [ColumnRuleWidth.Inherit]
                    ["columnRuleWidth" ==> "inherit"]
                test
                    "Column rule width Initial"
                    [ColumnRuleWidth.Initial]
                    ["columnRuleWidth" ==> "initial"]
                test
                    "Column rule width Unset"
                    [ColumnRuleWidth.Unset]
                    ["columnRuleWidth" ==> "unset"]
            ]