namespace FSSTests

open Fet
open Utils
open Fss

module Cursor =
    let tests =
        testList "Cursor"
            [
                testCase
                    "Cursor url"
                    [Cursor.url "hand.cur"]
                    "{ cursor: url(hand.cur); }"
                testCase
                    "Cursor url with offset"
                    [Cursor.url ("hand.cur", 4, 12)]
                    "{ cursor: url(hand.cur) 4 12; }"
                testCase
                    "Cursor None"
                    [Cursor.none]
                    "{ cursor: none; }"
                testCase
                    "Cursor auto"
                    [Cursor.auto]
                    "{ cursor: auto; }"
                testCase
                    "Cursor inherit"
                    [Cursor.inherit']
                    "{ cursor: inherit; }"
                testCase
                    "Cursor initial"
                    [Cursor.initial]
                    "{ cursor: initial; }"
                testCase
                    "Cursor unset"
                    [Cursor.unset]
                    "{ cursor: unset; }"
                testCase
                    "Cursor revert"
                    [Cursor.revert]
                    "{ cursor: revert; }"
                testCase
                    "Cursor alias"
                    [Cursor.alias]
                    "{ cursor: alias; }"
                testCase
                    "Cursor ContextMenu"
                    [Cursor.contextMenu]
                    "{ cursor: context-menu; }"
                testCase
                    "Cursor Help"
                    [Cursor.help]
                    "{ cursor: help; }"
                testCase
                    "Cursor Pointer"
                    [Cursor.pointer]
                    "{ cursor: pointer; }"
                testCase
                    "Cursor Progress"
                    [Cursor.progress]
                    "{ cursor: progress; }"
                testCase
                    "Cursor Wait"
                    [Cursor.wait]
                    "{ cursor: wait; }"
                testCase
                    "Cursor Cell"
                    [Cursor.cell]
                    "{ cursor: cell; }"
                testCase
                    "Cursor Crosshair"
                    [Cursor.crosshair]
                    "{ cursor: crosshair; }"
                testCase
                    "Cursor Text"
                    [Cursor.text]
                    "{ cursor: text; }"
                testCase
                    "Cursor VerticalText"
                    [Cursor.verticalText]
                    "{ cursor: vertical-text; }"
                testCase
                    "Cursor Alias"
                    [Cursor.alias]
                    "{ cursor: alias; }"
                testCase
                    "Cursor Copy"
                    [Cursor.copy]
                    "{ cursor: copy; }"
                testCase
                    "Cursor Move"
                    [Cursor.move]
                    "{ cursor: move; }"
                testCase
                    "Cursor NoDrop"
                    [Cursor.noDrop]
                    "{ cursor: no-drop; }"
                testCase
                    "Cursor NotAllowed"
                    [Cursor.notAllowed]
                    "{ cursor: not-allowed; }"
                testCase
                    "Cursor AllScroll"
                    [Cursor.allScroll]
                    "{ cursor: all-scroll; }"
                testCase
                    "Cursor ColResize"
                    [Cursor.colResize]
                    "{ cursor: col-resize; }"
                testCase
                    "Cursor RowResize"
                    [Cursor.rowResize]
                    "{ cursor: row-resize; }"
                testCase
                    "Cursor NResize"
                    [Cursor.nResize]
                    "{ cursor: n-resize; }"
                testCase
                    "Cursor EResize"
                    [Cursor.eResize]
                    "{ cursor: e-resize; }"
                testCase
                    "Cursor SResize"
                    [Cursor.sResize]
                    "{ cursor: s-resize; }"
                testCase
                    "Cursor WResize"
                    [Cursor.wResize]
                    "{ cursor: w-resize; }"
                testCase
                    "Cursor NsResize"
                    [Cursor.nsResize]
                    "{ cursor: ns-resize; }"
                testCase
                    "Cursor EwResize"
                    [Cursor.ewResize]
                    "{ cursor: ew-resize; }"
                testCase
                    "Cursor NeResize"
                    [Cursor.neResize]
                    "{ cursor: ne-resize; }"
                testCase
                    "Cursor NwResize"
                    [Cursor.nwResize]
                    "{ cursor: nw-resize; }"
                testCase
                    "Cursor SeResize"
                    [Cursor.seResize]
                    "{ cursor: se-resize; }"
                testCase
                    "Cursor SwResize"
                    [Cursor.swResize]
                    "{ cursor: sw-resize; }"
                testCase
                    "Cursor NeswResize"
                    [Cursor.neswResize]
                    "{ cursor: nesw-resize; }"
                testCase
                    "Cursor NwseResize"
                    [Cursor.nwseResize]
                    "{ cursor: nwse-resize; }"
            ]