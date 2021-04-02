namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Display =
    let tests =
        testList "Display"
            [
                testCase
                    "Display inline"
                    [ Display.inline' ]
                    ["display" ==> "inline"]
                testCase
                    "Display inline-block"
                    [ Display.inlineBlock]
                    ["display" ==> "inline-block"]
                testCase
                    "Display block"
                    [ Display.block]
                    ["display" ==> "block"]
                testCase
                    "Display run-in"
                    [ Display.runIn]
                    ["display" ==> "run-in"]
                testCase
                    "Display flex"
                    [ Display.flex]
                    ["display" ==> "flex"]
                testCase
                    "Display grid"
                    [ Display.grid]
                    ["display" ==> "grid"]
                testCase
                    "Display flow-root"
                    [ Display.flowRoot]
                    ["display" ==> "flow-root"]
                testCase
                    "Display table"
                    [ Display.table]
                    ["display" ==> "table"]
                testCase
                    "Display table-cell"
                    [ Display.tableCell]
                    ["display" ==> "table-cell"]
                testCase
                    "Display table-column"
                    [ Display.tableColumn]
                    ["display" ==> "table-column"]
                testCase
                    "Display table-column-group"
                    [ Display.tableColumnGroup]
                    ["display" ==> "table-column-group"]
                testCase
                    "Display table-header-group"
                    [ Display.tableHeaderGroup]
                    ["display" ==> "table-header-group"]
                testCase
                    "Display table row group"
                    [ Display.tableRowGroup]
                    ["display" ==> "table-row-group"]
                testCase
                    "table footer group"
                    [ Display.tableFooterGroup]
                    ["display" ==> "table-footer-group"]
                testCase
                    "Display table row"
                    [ Display.tableRow]
                    ["display" ==> "table-row"]
                testCase
                    "Display table-caption"
                    [ Display.tableCaption]
                    ["display" ==> "table-caption"]
                testCase
                    "Display none"
                    [ Display.none]
                    ["display" ==> "none"]
                testCase
                    "Display none"
                    [ Display' FssTypes.Display.Grid]
                    ["display" ==> "grid"]
            ]