namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Column =
    let tests =
        testList "Column"
            [
                testCase
                    "Column Width px"
                    [ColumnWidth' (px 60)]
                    ["columnWidth" ==> "60px"]
                testCase
                    "Column Width em"
                    [ColumnWidth' (em 15.5)]
                    ["columnWidth" ==> "15.5em"]
                testCase
                    "Column Width vw"
                    [ColumnWidth' (vw 3.3)]
                    ["columnWidth" ==> "3.3vw"]
                testCase
                    "Column Width auto"
                    [ColumnWidth.auto]
                    ["columnWidth" ==> "auto"]
                testCase
                    "Column Width inherit"
                    [ColumnWidth.inherit']
                    ["columnWidth" ==> "inherit"]
                testCase
                    "Column Width initial"
                    [ColumnWidth.initial]
                    ["columnWidth" ==> "initial"]
                testCase
                    "Column Width unset"
                    [ColumnWidth.unset]
                    ["columnWidth" ==> "unset"]
                testCase
                    "Column balance"
                    [ColumnFill.balance]
                    ["columnFill" ==> "balance"]
                testCase
                    "Column fill balance all"
                    [ColumnFill.balanceAll]
                    ["columnFill" ==> "balance-all"]
                testCase
                    "Column fill auto"
                    [ColumnFill.auto]
                    ["columnFill" ==> "auto"]
                testCase
                    "Column fill inherit"
                    [ColumnFill.inherit']
                    ["columnFill" ==> "inherit"]
                testCase
                    "Column fill initial"
                    [ColumnFill.initial]
                    ["columnFill" ==> "initial"]
                testCase
                    "Column fill unset"
                    [ColumnFill.unset]
                    ["columnFill" ==> "unset"]
                testCase
                    "Column gap normal"
                    [ColumnGap.normal]
                    ["columnGap" ==> "normal"]
                testCase
                    "Column gap px"
                    [ColumnGap' (px 3)]
                    ["columnGap" ==> "3px"]
                testCase
                    "Column gap em"
                    [ColumnGap' (em 2.5)]
                    ["columnGap" ==> "2.5em"]
                testCase
                    "Column gap percent"
                    [ColumnGap' (pct 3)]
                    ["columnGap" ==> "3%"]
                testCase
                    "Column gap inherit"
                    [ColumnGap.inherit']
                    ["columnGap" ==> "inherit"]
                testCase
                    "Column gap initial"
                    [ColumnGap.initial]
                    ["columnGap" ==> "initial"]
                testCase
                    "Column gap unset"
                    [ColumnGap.unset]
                    ["columnGap" ==> "unset"]
                testCase
                    "Column span all"
                    [ColumnSpan.all]
                    ["columnSpan" ==> "all"]
                testCase
                    "Column span none"
                    [ColumnSpan.none]
                    ["columnSpan" ==> "none"]
                testCase
                    "Column span inherit"
                    [ColumnSpan.inherit']
                    ["columnSpan" ==> "inherit"]
                testCase
                    "Column span initial"
                    [ColumnSpan.initial]
                    ["columnSpan" ==> "initial"]
                testCase
                    "Column span unset"
                    [ColumnSpan.unset]
                    ["columnSpan" ==> "unset"]
                testCase
                    "Columns Inherit"
                    [Columns.inherit']
                    ["columns" ==> "inherit"]
                testCase
                    "Columns Initial"
                    [Columns.initial]
                    ["columns" ==> "initial"]
                testCase
                    "Columns Unset"
                    [Columns.unset]
                    ["columns" ==> "unset"]
                testCase
                    "Column rule Inherit"
                    [ColumnRule.inherit']
                    ["columnRule" ==> "inherit"]
                testCase
                    "Column rule Initial"
                    [ColumnRule.initial]
                    ["columnRule" ==> "initial"]
                testCase
                    "Column rule Unset"
                    [ColumnRule.unset]
                    ["columnRule" ==> "unset"]
                testCase
                    "Column rule width thin"
                    [ColumnRuleWidth.thin]
                    ["columnRuleWidth" ==> "thin"]
                testCase
                    "Column rule width medium"
                    [ColumnRuleWidth.medium]
                    ["columnRuleWidth" ==> "medium"]
                testCase
                    "Column rule width thick"
                    [ColumnRuleWidth.thick]
                    ["columnRuleWidth" ==> "thick"]
                testCase
                    "Column rule width px"
                    [ColumnRuleWidth' (px 1)]
                    ["columnRuleWidth" ==> "1px"]
                testCase
                    "Column rule width em"
                    [ColumnRuleWidth' (em 2.5)]
                    ["columnRuleWidth" ==> "2.5em"]
                testCase
                    "Column rule width Inherit"
                    [ColumnRuleWidth.inherit']
                    ["columnRuleWidth" ==> "inherit"]
                testCase
                    "Column rule width Initial"
                    [ColumnRuleWidth.initial]
                    ["columnRuleWidth" ==> "initial"]
                testCase
                    "Column rule width Unset"
                    [ColumnRuleWidth.unset]
                    ["columnRuleWidth" ==> "unset"]
                testCase
                    "Column rule style hidden"
                    [ ColumnRuleStyle.hidden ]
                    [ "columnRuleStyle" ==> "hidden" ]
                testCase
                    "Column rule style dotted"
                    [ ColumnRuleStyle.dotted ]
                    [ "columnRuleStyle" ==> "dotted" ]
                testCase
                    "Column rule style dashed"
                    [ ColumnRuleStyle.dashed ]
                    [ "columnRuleStyle" ==> "dashed" ]
                testCase
                    "Column rule style solid"
                    [ ColumnRuleStyle.solid ]
                    [ "columnRuleStyle" ==> "solid" ]
                testCase
                    "Column rule style double"
                    [ ColumnRuleStyle.double ]
                    [ "columnRuleStyle" ==> "double" ]
                testCase
                    "Column rule style groove"
                    [ ColumnRuleStyle.groove ]
                    [ "columnRuleStyle" ==> "groove" ]
                testCase
                    "Column rule style ridge"
                    [ ColumnRuleStyle.ridge ]
                    [ "columnRuleStyle" ==> "ridge" ]
                testCase
                    "Column rule style inset"
                    [ ColumnRuleStyle.inset ]
                    [ "columnRuleStyle" ==> "inset" ]
                testCase
                    "Column rule style outset"
                    [ ColumnRuleStyle.outset ]
                    [ "columnRuleStyle" ==> "outset" ]
                testCase
                    "Column rule style none"
                    [ ColumnRuleStyle.none ]
                    [ "columnRuleStyle" ==> "none" ]
                testCase
                    "Column rule style initial"
                    [ ColumnRuleStyle.initial ]
                    [ "columnRuleStyle" ==> "initial" ]
                testCase
                    "Column rule style inherit"
                    [ ColumnRuleStyle.inherit' ]
                    [ "columnRuleStyle" ==> "inherit" ]
                testCase
                    "Column rule style unset"
                    [ ColumnRuleStyle.unset ]
                    [ "columnRuleStyle" ==> "unset" ]
                testCase
                    "Column rule color red"
                    [ ColumnRuleColor.red ]
                    [ "columnRuleColor" ==> "#ff0000" ]
                testCase
                    "Column rule color initial"
                    [ ColumnRuleColor.initial ]
                    [ "columnRuleColor" ==> "initial" ]
                testCase
                    "Column rule color inherit"
                    [ ColumnRuleColor.inherit' ]
                    [ "columnRuleColor" ==> "inherit" ]
                testCase
                    "Column rule color unset"
                    [ ColumnRuleColor.unset ]
                    [ "columnRuleColor" ==> "unset" ]
                testCase
                    "Column count number"
                    [ColumnCount' (FssTypes.CssInt 3)]
                    ["columnCount" ==> "3"]
                testCase
                    "Column count auto"
                    [ColumnCount.auto]
                    ["columnCount" ==> "auto"]
                testCase
                    "Column count inherit"
                    [ColumnCount.inherit']
                    ["columnCount" ==> "inherit"]
                testCase
                    "Column count initial"
                    [ColumnCount.initial]
                    ["columnCount" ==> "initial"]
                testCase
                    "Column count unset"
                    [ColumnCount.unset]
                    ["columnCount" ==> "unset"]
            ]