namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Display =
    let tests =
        testList "Display"
            [
                test
                    "Display inline"
                    [ Display.inline' ]
                    ["display" ==> "inline"]
                test
                    "Display inline-block"
                    [ Display.inlineBlock]
                    ["display" ==> "inline-block"]
                test
                    "Display block"
                    [ Display.block]
                    ["display" ==> "block"]
                test
                    "Display run-in"
                    [ Display.runIn]
                    ["display" ==> "run-in"]
                test
                    "Display flex"
                    [ Display.flex]
                    ["display" ==> "flex"]
                test
                    "Display grid"
                    [ Display.grid]
                    ["display" ==> "grid"]
                test
                    "Display flow-root"
                    [ Display.flowRoot]
                    ["display" ==> "flow-root"]
                test
                    "Display table"
                    [ Display.table]
                    ["display" ==> "table"]
                test
                    "Display table-cell"
                    [ Display.tableCell]
                    ["display" ==> "table-cell"]
                test
                    "Display table-column"
                    [ Display.tableColumn]
                    ["display" ==> "table-column"]
                test
                    "Display table-column-group"
                    [ Display.tableColumnGroup]
                    ["display" ==> "table-column-group"]
                test
                    "Display table-header-group"
                    [ Display.tableHeaderGroup]
                    ["display" ==> "table-header-group"]
                test
                    "Display table row group"
                    [ Display.tableRowGroup]
                    ["display" ==> "table-row-group"]
                test
                    "table footer group"
                    [ Display.tableFooterGroup]
                    ["display" ==> "table-footer-group"]
                test
                    "Display table row"
                    [ Display.tableRow]
                    ["display" ==> "table-row"]
                test
                    "Display table-caption"
                    [ Display.tableCaption]
                    ["display" ==> "table-caption"]
                test
                    "Display none"
                    [ Display.none]
                    ["display" ==> "none"]
                test
                    "Display none"
                    [ Display' FssTypes.Display.Grid]
                    ["display" ==> "grid"]
            ]