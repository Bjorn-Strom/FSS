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
                    [ Display.Inline ]
                    ["display" ==> "inline"]
                test
                    "Display inline-block"
                    [ Display.InlineBlock]
                    ["display" ==> "inline-block"]
                test
                    "Display block"
                    [ Display.Block]
                    ["display" ==> "block"]
                test
                    "Display run-in"
                    [ Display.RunIn]
                    ["display" ==> "run-in"]
                test
                    "Display flex"
                    [ Display.Flex]
                    ["display" ==> "flex"]
                test
                    "Display grid"
                    [ Display.Grid]
                    ["display" ==> "grid"]
                test
                    "Display flow-root"
                    [ Display.FlowRoot]
                    ["display" ==> "flow-root"]
                test
                    "Display table"
                    [ Display.Table]
                    ["display" ==> "table"]
                test
                    "Display table-cell"
                    [ Display.TableCell]
                    ["display" ==> "table-cell"]
                test
                    "Display table-column"
                    [ Display.TableColumn]
                    ["display" ==> "table-column"]
                test
                    "Display table-column-group"
                    [ Display.TableColumnGroup]
                    ["display" ==> "table-column-group"]
                test
                    "Display table-header-group"
                    [ Display.TableHeaderGroup]
                    ["display" ==> "table-header-group"]
                test
                    "Display table row group"
                    [ Display.TableRowGroup]
                    ["display" ==> "table-row-group"]
                test
                    "table footer group"
                    [ Display.TableFooterGroup]
                    ["display" ==> "table-footer-group"]
                test
                    "Display table row"
                    [ Display.TableRow]
                    ["display" ==> "table-row"]
                test
                    "Display table-caption"
                    [ Display.TableCaption]
                    ["display" ==> "table-caption"]
                test
                    "Display none"
                    [ Display.None]
                    ["display" ==> "none"]
                test
                    "Display none"
                    [ Display' FssTypes.Display.Grid]
                    ["display" ==> "grid"]
            ]