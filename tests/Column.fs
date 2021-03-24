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
                    [ColumnWidth.auto]
                    ["columnWidth" ==> "auto"]
                test
                    "Column Width inherit"
                    [ColumnWidth.inherit']
                    ["columnWidth" ==> "inherit"]
                test
                    "Column Width initial"
                    [ColumnWidth.initial]
                    ["columnWidth" ==> "initial"]
                test
                    "Column Width unset"
                    [ColumnWidth.unset]
                    ["columnWidth" ==> "unset"]
                test
                    "Column balance"
                    [ColumnFill.balance]
                    ["columnFill" ==> "balance"]
                test
                    "Column fill balance all"
                    [ColumnFill.balanceAll]
                    ["columnFill" ==> "balance-all"]
                test
                    "Column fill auto"
                    [ColumnFill.auto]
                    ["columnFill" ==> "auto"]
                test
                    "Column fill inherit"
                    [ColumnFill.inherit']
                    ["columnFill" ==> "inherit"]
                test
                    "Column fill initial"
                    [ColumnFill.initial]
                    ["columnFill" ==> "initial"]
                test
                    "Column fill unset"
                    [ColumnFill.unset]
                    ["columnFill" ==> "unset"]
                test
                    "Column gap normal"
                    [ColumnGap.normal]
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
                    [ColumnGap.inherit']
                    ["columnGap" ==> "inherit"]
                test
                    "Column gap initial"
                    [ColumnGap.initial]
                    ["columnGap" ==> "initial"]
                test
                    "Column gap unset"
                    [ColumnGap.unset]
                    ["columnGap" ==> "unset"]
                test
                    "Column span all"
                    [ColumnSpan.all]
                    ["columnSpan" ==> "all"]
                test
                    "Column span none"
                    [ColumnSpan.none]
                    ["columnSpan" ==> "none"]
                test
                    "Column span inherit"
                    [ColumnSpan.inherit']
                    ["columnSpan" ==> "inherit"]
                test
                    "Column span initial"
                    [ColumnSpan.initial]
                    ["columnSpan" ==> "initial"]
                test
                    "Column span unset"
                    [ColumnSpan.unset]
                    ["columnSpan" ==> "unset"]
                test
                    "Columns Inherit"
                    [Columns.inherit']
                    ["columns" ==> "inherit"]
                test
                    "Columns Initial"
                    [Columns.initial]
                    ["columns" ==> "initial"]
                test
                    "Columns Unset"
                    [Columns.unset]
                    ["columns" ==> "unset"]
                test
                    "Column rule Inherit"
                    [ColumnRule.inherit']
                    ["columnRule" ==> "inherit"]
                test
                    "Column rule Initial"
                    [ColumnRule.initial]
                    ["columnRule" ==> "initial"]
                test
                    "Column rule Unset"
                    [ColumnRule.unset]
                    ["columnRule" ==> "unset"]
                test
                    "Column rule width thin"
                    [ColumnRuleWidth.thin]
                    ["columnRuleWidth" ==> "thin"]
                test
                    "Column rule width medium"
                    [ColumnRuleWidth.medium]
                    ["columnRuleWidth" ==> "medium"]
                test
                    "Column rule width thick"
                    [ColumnRuleWidth.thick]
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
                    [ColumnRuleWidth.inherit']
                    ["columnRuleWidth" ==> "inherit"]
                test
                    "Column rule width Initial"
                    [ColumnRuleWidth.initial]
                    ["columnRuleWidth" ==> "initial"]
                test
                    "Column rule width Unset"
                    [ColumnRuleWidth.unset]
                    ["columnRuleWidth" ==> "unset"]
                test
                    "Column rule style hidden"
                    [ ColumnRuleStyle.hidden ]
                    [ "columnRuleStyle" ==> "hidden" ]
                test
                    "Column rule style dotted"
                    [ ColumnRuleStyle.dotted ]
                    [ "columnRuleStyle" ==> "dotted" ]
                test
                    "Column rule style dashed"
                    [ ColumnRuleStyle.dashed ]
                    [ "columnRuleStyle" ==> "dashed" ]
                test
                    "Column rule style solid"
                    [ ColumnRuleStyle.solid ]
                    [ "columnRuleStyle" ==> "solid" ]
                test
                    "Column rule style double"
                    [ ColumnRuleStyle.double ]
                    [ "columnRuleStyle" ==> "double" ]
                test
                    "Column rule style groove"
                    [ ColumnRuleStyle.groove ]
                    [ "columnRuleStyle" ==> "groove" ]
                test
                    "Column rule style ridge"
                    [ ColumnRuleStyle.ridge ]
                    [ "columnRuleStyle" ==> "ridge" ]
                test
                    "Column rule style inset"
                    [ ColumnRuleStyle.inset ]
                    [ "columnRuleStyle" ==> "inset" ]
                test
                    "Column rule style outset"
                    [ ColumnRuleStyle.outset ]
                    [ "columnRuleStyle" ==> "outset" ]
                test
                    "Column rule style none"
                    [ ColumnRuleStyle.none ]
                    [ "columnRuleStyle" ==> "none" ]
                test
                    "Column rule style initial"
                    [ ColumnRuleStyle.initial ]
                    [ "columnRuleStyle" ==> "initial" ]
                test
                    "Column rule style inherit"
                    [ ColumnRuleStyle.inherit' ]
                    [ "columnRuleStyle" ==> "inherit" ]
                test
                    "Column rule style unset"
                    [ ColumnRuleStyle.unset ]
                    [ "columnRuleStyle" ==> "unset" ]
                test
                    "Column rule color red"
                    [ ColumnRuleColor.red ]
                    [ "columnRuleColor" ==> "#ff0000" ]
                test
                    "Column rule color initial"
                    [ ColumnRuleColor.initial ]
                    [ "columnRuleColor" ==> "initial" ]
                test
                    "Column rule color inherit"
                    [ ColumnRuleColor.inherit' ]
                    [ "columnRuleColor" ==> "inherit" ]
                test
                    "Column rule color unset"
                    [ ColumnRuleColor.unset ]
                    [ "columnRuleColor" ==> "unset" ]
                test
                    "Column count number"
                    [ColumnCount' (FssTypes.CssInt 3)]
                    ["columnCount" ==> "3"]
                test
                    "Column count auto"
                    [ColumnCount.auto]
                    ["columnCount" ==> "auto"]
                test
                    "Column count inherit"
                    [ColumnCount.inherit']
                    ["columnCount" ==> "inherit"]
                test
                    "Column count initial"
                    [ColumnCount.initial]
                    ["columnCount" ==> "initial"]
                test
                    "Column count unset"
                    [ColumnCount.unset]
                    ["columnCount" ==> "unset"]
            ]