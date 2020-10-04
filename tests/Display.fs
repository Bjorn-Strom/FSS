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
                        [ Display Display.Inline]
                        ["display" ==> "inline"]

                    test
                        "Display inline-block"
                        [ Display Display.InlineBlock]
                        ["display" ==> "inline-block"]

                    test
                        "Display block"
                        [ Display Display.Block]
                        ["display" ==> "block"]

                    test
                        "Display run-in"
                        [ Display Display.RunIn]
                        ["display" ==> "run-in"]

                    test
                        "Display flex"
                        [ Display Display.Flex]
                        ["display" ==> "flex"]

                    test
                        "Display grid"
                        [ Display Display.Grid]
                        ["display" ==> "grid"]

                    test
                        "Display flow-root"
                        [ Display Display.FlowRoot]
                        ["display" ==> "flow-root"]

                    test
                        "Display table"
                        [ Display Display.Table]
                        ["display" ==> "table"]

                    test
                        "Display table-cell"
                        [ Display Display.TableCell]
                        ["display" ==> "table-cell"]

                    test
                        "Display table-column"
                        [ Display Display.TableColumn]
                        ["display" ==> "table-column"]

                    test
                        "Display table-column-group"
                        [ Display Display.TableColumnGroup]
                        ["display" ==> "table-column-group"]

                    test
                        "Display table-header-group"
                        [ Display Display.TableHeaderGroup]
                        ["display" ==> "table-header-group"]

                    test
                        "Display table row group"
                        [ Display Display.TableRowGroup]
                        ["display" ==> "table-row-group"]

                    test
                        "table footer group"
                        [ Display Display.TableFooterGroup]
                        ["display" ==> "table-footer-group"]

                    test
                        "Display table row"
                        [ Display Display.TableRow]
                        ["display" ==> "table-row"]

                    test
                        "Display table-caption"
                        [ Display Display.TableCaption]
                        ["display" ==> "table-caption"]

                    test
                        "Display none"
                        [ Display None]
                        ["display" ==> "none"]
            ]