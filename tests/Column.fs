namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss.Global
open Utils
open Fss

module Column =
    let tests =
        testList "Column"
            [
                test
                    "Column Width px"
                    [ColumnWidth' (px 60)]
                    ["columnWidth" ==> "60px"]
                test
                    "Column Width em"
                    [ColumnWidth' (em 15.5)]
                    ["columnWidth" ==> "15.5em"]
                test
                    "Column Width vw"
                    [ColumnWidth' (vw 3.3)]
                    ["columnWidth" ==> "3.3vw"]
                test
                    "Column Width auto"
                    [ColumnWidth.Auto]
                    ["columnWidth" ==> "auto"]
                test
                    "Column Width inherit"
                    [ColumnWidth.Inherit]
                    ["columnWidth" ==> "inherit"]
                test
                    "Column Width initial"
                    [ColumnWidth.Initial]
                    ["columnWidth" ==> "initial"]
                test
                    "Column Width unset"
                    [ColumnWidth.Unset]
                    ["columnWidth" ==> "unset"]
                test
                    "Column balance"
                    [ColumnFill.Balance]
                    ["columnFill" ==> "balance"]
                test
                    "Column fill balance all"
                    [ColumnFill.BalanceAll]
                    ["columnFill" ==> "balance-all"]
                test
                    "Column fill auto"
                    [ColumnFill.Auto]
                    ["columnFill" ==> "auto"]
                test
                    "Column fill inherit"
                    [ColumnFill.Inherit]
                    ["columnFill" ==> "inherit"]
                test
                    "Column fill initial"
                    [ColumnFill.Initial]
                    ["columnFill" ==> "initial"]
                test
                    "Column fill unset"
                    [ColumnFill.Unset]
                    ["columnFill" ==> "unset"]
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
                    "Columns Inherit"
                    [Columns.Inherit]
                    ["columns" ==> "inherit"]
                test
                    "Columns Initial"
                    [Columns.Initial]
                    ["columns" ==> "initial"]
                test
                    "Columns Unset"
                    [Columns.Unset]
                    ["columns" ==> "unset"]
                test
                    "Column rule Inherit"
                    [ColumnRule.Inherit]
                    ["columnRule" ==> "inherit"]
                test
                    "Column rule Initial"
                    [ColumnRule.Initial]
                    ["columnRule" ==> "initial"]
                test
                    "Column rule Unset"
                    [ColumnRule.Unset]
                    ["columnRule" ==> "unset"]
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
                test
                    "Column rule style hidden"
                    [ ColumnRuleStyle.Hidden ]
                    [ "columnRuleStyle" ==> "hidden" ]
                test
                    "Column rule style dotted"
                    [ ColumnRuleStyle.Dotted ]
                    [ "columnRuleStyle" ==> "dotted" ]
                test
                    "Column rule style dashed"
                    [ ColumnRuleStyle.Dashed ]
                    [ "columnRuleStyle" ==> "dashed" ]
                test
                    "Column rule style solid"
                    [ ColumnRuleStyle.Solid ]
                    [ "columnRuleStyle" ==> "solid" ]
                test
                    "Column rule style double"
                    [ ColumnRuleStyle.Double ]
                    [ "columnRuleStyle" ==> "double" ]
                test
                    "Column rule style groove"
                    [ ColumnRuleStyle.Groove ]
                    [ "columnRuleStyle" ==> "groove" ]
                test
                    "Column rule style ridge"
                    [ ColumnRuleStyle.Ridge ]
                    [ "columnRuleStyle" ==> "ridge" ]
                test
                    "Column rule style inset"
                    [ ColumnRuleStyle.Inset ]
                    [ "columnRuleStyle" ==> "inset" ]
                test
                    "Column rule style outset"
                    [ ColumnRuleStyle.Outset ]
                    [ "columnRuleStyle" ==> "outset" ]
                test
                    "Column rule style none"
                    [ ColumnRuleStyle.None ]
                    [ "columnRuleStyle" ==> "none" ]
                test
                    "Column rule style initial"
                    [ ColumnRuleStyle.Initial ]
                    [ "columnRuleStyle" ==> "initial" ]
                test
                    "Column rule style inherit"
                    [ ColumnRuleStyle.Inherit ]
                    [ "columnRuleStyle" ==> "inherit" ]
                test
                    "Column rule style unset"
                    [ ColumnRuleStyle.Unset ]
                    [ "columnRuleStyle" ==> "unset" ]
                test
                    "Column rule color red"
                    [ ColumnRuleColor.red ]
                    [ "columnRuleColor" ==> "#ff0000" ]
                test
                    "Column rule color initial"
                    [ ColumnRuleColor.Initial ]
                    [ "columnRuleColor" ==> "initial" ]
                test
                    "Column rule color inherit"
                    [ ColumnRuleColor.Inherit ]
                    [ "columnRuleColor" ==> "inherit" ]
                test
                    "Column rule color unset"
                    [ ColumnRuleColor.Unset ]
                    [ "columnRuleColor" ==> "unset" ]
                test
                    "Column count number"
                    [ColumnCount' (CssInt 3)]
                    ["columnCount" ==> "3"]
                test
                    "Column count auto"
                    [ColumnCount.Auto]
                    ["columnCount" ==> "auto"]
                test
                    "Column count inherit"
                    [ColumnCount.Inherit]
                    ["columnCount" ==> "inherit"]
                test
                    "Column count initial"
                    [ColumnCount.Initial]
                    ["columnCount" ==> "initial"]
                test
                    "Column count unset"
                    [ColumnCount.Unset]
                    ["columnCount" ==> "unset"]
            ]