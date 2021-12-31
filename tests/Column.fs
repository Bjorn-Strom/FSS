namespace FSSTests

open Fet
open Utils
open Fss

module Column =
    let tests =
        testList "Column"
            [
                testCase
                    "Column Width px"
                    [ColumnWidth.value (px 60)]
                    "{ column-width: 60px; }"
                testCase
                    "Column Width em"
                    [ColumnWidth.value (em 15.5)]
                    "{ column-width: 15.5em; }"
                testCase
                    "Column Width vw"
                    [ColumnWidth.value (vw 3.3)]
                    "{ column-width: 3.3vw; }"
                testCase
                    "Column Width auto"
                    [ColumnWidth.auto]
                    "{ column-width: auto; }"
                testCase
                    "Column Width inherit"
                    [ColumnWidth.inherit']
                    "{ column-width: inherit; }"
                testCase
                    "Column Width initial"
                    [ColumnWidth.initial]
                    "{ column-width: initial; }"
                testCase
                    "Column Width unset"
                    [ColumnWidth.unset]
                    "{ column-width: unset; }"
                testCase
                    "Column Width revert"
                    [ColumnWidth.revert]
                    "{ column-width: revert; }"
                testCase
                    "Column balance"
                    [ColumnFill.balance]
                    "{ column-fill: balance; }"
                testCase
                    "Column fill balance all"
                    [ColumnFill.balanceAll]
                    "{ column-fill: balance-all; }"
                testCase
                    "Column fill auto"
                    [ColumnFill.auto]
                    "{ column-fill: auto; }"
                testCase
                    "Column fill inherit"
                    [ColumnFill.inherit']
                    "{ column-fill: inherit; }"
                testCase
                    "Column fill initial"
                    [ColumnFill.initial]
                    "{ column-fill: initial; }"
                testCase
                    "Column fill unset"
                    [ColumnFill.unset]
                    "{ column-fill: unset; }"
                testCase
                    "Column fill revert"
                    [ColumnFill.revert]
                    "{ column-fill: revert; }"
                testCase
                    "Column gap normal"
                    [ColumnGap.normal]
                    "{ column-gap: normal; }"
                testCase
                    "Column gap px"
                    [ColumnGap.value (px 3)]
                    "{ column-gap: 3px; }"
                testCase
                    "Column gap em"
                    [ColumnGap.value (em 2.5)]
                    "{ column-gap: 2.5em; }"
                testCase
                    "Column gap percent"
                    [ColumnGap.value (pct 3)]
                    "{ column-gap: 3%; }"
                testCase
                    "Column gap inherit"
                    [ColumnGap.inherit']
                    "{ column-gap: inherit; }"
                testCase
                    "Column gap initial"
                    [ColumnGap.initial]
                    "{ column-gap: initial; }"
                testCase
                    "Column gap unset"
                    [ColumnGap.unset]
                    "{ column-gap: unset; }"
                testCase
                    "Column gap revert"
                    [ColumnGap.revert]
                    "{ column-gap: revert; }"
                testCase
                    "Column span all"
                    [ColumnSpan.all]
                    "{ column-span: all; }"
                testCase
                    "Column span none"
                    [ColumnSpan.none]
                    "{ column-span: none; }"
                testCase
                    "Column span inherit"
                    [ColumnSpan.inherit']
                    "{ column-span: inherit; }"
                testCase
                    "Column span initial"
                    [ColumnSpan.initial]
                    "{ column-span: initial; }"
                testCase
                    "Column span unset"
                    [ColumnSpan.unset]
                    "{ column-span: unset; }"
                testCase
                    "Columns Inherit"
                    [Columns.inherit']
                    "{ columns: inherit; }"
                testCase
                    "Columns Initial"
                    [Columns.initial]
                    "{ columns: initial; }"
                testCase
                    "Columns unset"
                    [Columns.unset]
                    "{ columns: unset; }"
                testCase
                    "Columns revert"
                    [Columns.revert]
                    "{ columns: revert; }"
                testCase
                    "Column rule Inherit"
                    [ColumnRule.inherit']
                    "{ column-rule: inherit; }"
                testCase
                    "Column rule Initial"
                    [ColumnRule.initial]
                    "{ column-rule: initial; }"
                testCase
                    "Column rule unset"
                    [ColumnRule.unset]
                    "{ column-rule: unset; }"
                testCase
                    "Column rule revert"
                    [ColumnRule.revert]
                    "{ column-rule: revert; }"
                testCase
                    "Column rule width thin"
                    [ColumnRuleWidth.thin]
                    "{ column-rule-width: thin; }"
                testCase
                    "Column rule width medium"
                    [ColumnRuleWidth.medium]
                    "{ column-rule-width: medium; }"
                testCase
                    "Column rule width thick"
                    [ColumnRuleWidth.thick]
                    "{ column-rule-width: thick; }"
                testCase
                    "Column rule width px"
                    [ColumnRuleWidth.value (px 1)]
                    "{ column-rule-width: 1px; }"
                testCase
                    "Column rule width em"
                    [ColumnRuleWidth.value (em 2.5)]
                    "{ column-rule-width: 2.5em; }"
                testCase
                    "Column rule width Inherit"
                    [ColumnRuleWidth.inherit']
                    "{ column-rule-width: inherit; }"
                testCase
                    "Column rule width Initial"
                    [ColumnRuleWidth.initial]
                    "{ column-rule-width: initial; }"
                testCase
                    "Column rule width Unset"
                    [ColumnRuleWidth.unset]
                    "{ column-rule-width: unset; }"
                testCase
                    "Column rule width revert"
                    [ColumnRuleWidth.revert]
                    "{ column-rule-width: revert; }"
                testCase
                    "Column rule style hidden"
                    [ ColumnRuleStyle.hidden ]
                     "{ column-rule-style: hidden; }" 
                testCase
                    "Column rule style dotted"
                    [ ColumnRuleStyle.dotted ]
                     "{ column-rule-style: dotted; }" 
                testCase
                    "Column rule style dashed"
                    [ ColumnRuleStyle.dashed ]
                     "{ column-rule-style: dashed; }" 
                testCase
                    "Column rule style solid"
                    [ ColumnRuleStyle.solid ]
                     "{ column-rule-style: solid; }" 
                testCase
                    "Column rule style double"
                    [ ColumnRuleStyle.double ]
                     "{ column-rule-style: double; }" 
                testCase
                    "Column rule style groove"
                    [ ColumnRuleStyle.groove ]
                     "{ column-rule-style: groove; }" 
                testCase
                    "Column rule style ridge"
                    [ ColumnRuleStyle.ridge ]
                     "{ column-rule-style: ridge; }" 
                testCase
                    "Column rule style inset"
                    [ ColumnRuleStyle.inset ]
                     "{ column-rule-style: inset; }" 
                testCase
                    "Column rule style outset"
                    [ ColumnRuleStyle.outset ]
                     "{ column-rule-style: outset; }" 
                testCase
                    "Column rule style none"
                    [ ColumnRuleStyle.none ]
                     "{ column-rule-style: none; }" 
                testCase
                    "Column rule style revert"
                    [ ColumnRuleStyle.revert ]
                     "{ column-rule-style: revert; }" 
                testCase
                    "Column rule style initial"
                    [ ColumnRuleStyle.initial ]
                     "{ column-rule-style: initial; }" 
                testCase
                    "Column rule style inherit"
                    [ ColumnRuleStyle.inherit' ]
                     "{ column-rule-style: inherit; }" 
                testCase
                    "Column rule style unset"
                    [ ColumnRuleStyle.unset ]
                     "{ column-rule-style: unset; }" 
                testCase
                    "Column rule color red"
                    [ ColumnRuleColor.red ]
                     "{ column-rule-color: red; }" 
                testCase
                    "Column rule color initial"
                    [ ColumnRuleColor.initial ]
                     "{ column-rule-color: initial; }" 
                testCase
                    "Column rule color inherit"
                    [ ColumnRuleColor.inherit' ]
                     "{ column-rule-color: inherit; }" 
                testCase
                    "Column rule color unset"
                    [ ColumnRuleColor.unset ]
                     "{ column-rule-color: unset; }" 
                testCase
                    "Column rule color revert"
                    [ ColumnRuleColor.revert ]
                     "{ column-rule-color: revert; }" 
                testCase
                    "Column count number"
                    [ColumnCount.value 3 ]
                    "{ column-count: 3; }"
                testCase
                    "Column count auto"
                    [ColumnCount.auto]
                    "{ column-count: auto; }"
                testCase
                    "Column count inherit"
                    [ColumnCount.inherit']
                    "{ column-count: inherit; }"
                testCase
                    "Column count initial"
                    [ColumnCount.initial]
                    "{ column-count: initial; }"
                testCase
                    "Column count unset"
                    [ColumnCount.unset]
                    "{ column-count: unset; }"
                testCase
                    "Column count revert"
                    [ColumnCount.revert]
                    "{ column-count: revert; }"
            ]