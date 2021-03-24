namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Cursor =
    let tests =
        testList "Cursor"
            [
                test
                    "Cursor None"
                    [Cursor.none]
                    [ "cursor" ==> "none"]
                test
                    "Cursor auto"
                    [Cursor.auto]
                    [ "cursor" ==> "auto"]
                test
                    "Cursor inherit"
                    [Cursor.inherit']
                    [ "cursor" ==> "inherit"]
                test
                    "Cursor initial"
                    [Cursor.initial]
                    [ "cursor" ==> "initial"]
                test
                    "Cursor unset"
                    [Cursor.unset]
                    [ "cursor" ==> "unset"]
                test
                    "Cursor alias"
                    [Cursor.alias]
                    [ "cursor" ==> "alias"]
                test
                    "Cursor ContextMenu"
                    [Cursor.contextMenu]
                    [ "cursor" ==> "context-menu"]
                test
                    "Cursor Help"
                    [Cursor.help]
                    [ "cursor" ==> "help"]
                test
                    "Cursor Pointer"
                    [Cursor.pointer]
                    [ "cursor" ==> "pointer"]
                test
                    "Cursor Progress"
                    [Cursor.progress]
                    [ "cursor" ==> "progress"]
                test
                    "Cursor Wait"
                    [Cursor.wait]
                    [ "cursor" ==> "wait"]
                test
                    "Cursor Cell"
                    [Cursor.cell]
                    [ "cursor" ==> "cell"]
                test
                    "Cursor Crosshair"
                    [Cursor.crosshair]
                    [ "cursor" ==> "crosshair"]
                test
                    "Cursor Text"
                    [Cursor.text]
                    [ "cursor" ==> "text"]
                test
                    "Cursor VerticalText"
                    [Cursor.verticalText]
                    [ "cursor" ==> "vertical-text"]
                test
                    "Cursor Alias"
                    [Cursor.alias]
                    [ "cursor" ==> "alias"]
                test
                    "Cursor Copy"
                    [Cursor.copy]
                    [ "cursor" ==> "copy"]
                test
                    "Cursor Move"
                    [Cursor.move]
                    [ "cursor" ==> "move"]
                test
                    "Cursor NoDrop"
                    [Cursor.noDrop]
                    [ "cursor" ==> "no-drop"]
                test
                    "Cursor NotAllowed"
                    [Cursor.notAllowed]
                    [ "cursor" ==> "not-allowed"]
                test
                    "Cursor AllScroll"
                    [Cursor.allScroll]
                    [ "cursor" ==> "all-scroll"]
                test
                    "Cursor ColResize"
                    [Cursor.colResize]
                    [ "cursor" ==> "col-resize"]
                test
                    "Cursor RowResize"
                    [Cursor.rowResize]
                    [ "cursor" ==> "row-resize"]
                test
                    "Cursor NResize"
                    [Cursor.nResize]
                    [ "cursor" ==> "n-resize"]
                test
                    "Cursor EResize"
                    [Cursor.eResize]
                    [ "cursor" ==> "e-resize"]
                test
                    "Cursor SResize"
                    [Cursor.sResize]
                    [ "cursor" ==> "s-resize"]
                test
                    "Cursor WResize"
                    [Cursor.wResize]
                    [ "cursor" ==> "w-resize"]
                test
                    "Cursor NsResize"
                    [Cursor.nsResize]
                    [ "cursor" ==> "ns-resize"]
                test
                    "Cursor EwResize"
                    [Cursor.ewResize]
                    [ "cursor" ==> "ew-resize"]
                test
                    "Cursor NeResize"
                    [Cursor.neResize]
                    [ "cursor" ==> "ne-resize"]
                test
                    "Cursor NwResize"
                    [Cursor.nwResize]
                    [ "cursor" ==> "nw-resize"]
                test
                    "Cursor SeResize"
                    [Cursor.seResize]
                    [ "cursor" ==> "se-resize"]
                test
                    "Cursor SwResize"
                    [Cursor.swResize]
                    [ "cursor" ==> "sw-resize"]
                test
                    "Cursor NeswResize"
                    [Cursor.neswResize]
                    [ "cursor" ==> "nesw-resize"]
                test
                    "Cursor NwseResize"
                    [Cursor.nwseResize]
                    [ "cursor" ==> "nwse-resize"]
            ]