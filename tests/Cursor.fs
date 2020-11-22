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
                    [Cursor.None]
                    [ "cursor" ==> "none"]
                test
                    "Cursor auto"
                    [Cursor.Auto]
                    [ "cursor" ==> "auto"]
                test
                    "Cursor inherit"
                    [Cursor.Inherit]
                    [ "cursor" ==> "inherit"]
                test
                    "Cursor initial"
                    [Cursor.Initial]
                    [ "cursor" ==> "initial"]
                test
                    "Cursor unset"
                    [Cursor.Unset]
                    [ "cursor" ==> "unset"]
                test
                    "Cursor alias"
                    [Cursor.Alias]
                    [ "cursor" ==> "alias"]
                test
                    "Cursor ContextMenu"
                    [Cursor.ContextMenu]
                    [ "cursor" ==> "context-menu"]
                test
                    "Cursor Help"
                    [Cursor.Help]
                    [ "cursor" ==> "help"]
                test
                    "Cursor Pointer"
                    [Cursor.Pointer]
                    [ "cursor" ==> "pointer"]
                test
                    "Cursor Progress"
                    [Cursor.Progress]
                    [ "cursor" ==> "progress"]
                test
                    "Cursor Wait"
                    [Cursor.Wait]
                    [ "cursor" ==> "wait"]
                test
                    "Cursor Cell"
                    [Cursor.Cell]
                    [ "cursor" ==> "cell"]
                test
                    "Cursor Crosshair"
                    [Cursor.Crosshair]
                    [ "cursor" ==> "crosshair"]
                test
                    "Cursor Text"
                    [Cursor.Text]
                    [ "cursor" ==> "text"]
                test
                    "Cursor VerticalText"
                    [Cursor.VerticalText]
                    [ "cursor" ==> "vertical-text"]
                test
                    "Cursor Alias"
                    [Cursor.Alias]
                    [ "cursor" ==> "alias"]
                test
                    "Cursor Copy"
                    [Cursor.Copy]
                    [ "cursor" ==> "copy"]
                test
                    "Cursor Move"
                    [Cursor.Move]
                    [ "cursor" ==> "move"]
                test
                    "Cursor NoDrop"
                    [Cursor.NoDrop]
                    [ "cursor" ==> "no-drop"]
                    
                test
                    "Cursor NotAllowed"
                    [Cursor.NotAllowed]
                    [ "cursor" ==> "not-allowed"]
                    
                test
                    "Cursor AllScroll"
                    [Cursor.AllScroll]
                    [ "cursor" ==> "all-scroll"]
                    
                test
                    "Cursor ColResize"
                    [Cursor.ColResize]
                    [ "cursor" ==> "col-resize"]
                    
                test
                    "Cursor RowResize"
                    [Cursor.RowResize]
                    [ "cursor" ==> "row-resize"]
                    
                test
                    "Cursor NResize"
                    [Cursor.NResize]
                    [ "cursor" ==> "n-resize"]
                    
                test
                    "Cursor EResize"
                    [Cursor.EResize]
                    [ "cursor" ==> "e-resize"]
                    
                test
                    "Cursor SResize"
                    [Cursor.SResize]
                    [ "cursor" ==> "s-resize"]
                    
                test
                    "Cursor WResize"
                    [Cursor.WResize]
                    [ "cursor" ==> "w-resize"]
                    
                test
                    "Cursor NsResize"
                    [Cursor.NsResize]
                    [ "cursor" ==> "ns-resize"]
                    
                test
                    "Cursor EwResize"
                    [Cursor.EwResize]
                    [ "cursor" ==> "ew-resize"]
                    
                test
                    "Cursor NeResize"
                    [Cursor.NeResize]
                    [ "cursor" ==> "ne-resize"]
                    
                test
                    "Cursor NwResize"
                    [Cursor.NwResize]
                    [ "cursor" ==> "nw-resize"]
                    
                test
                    "Cursor SeResize"
                    [Cursor.SeResize]
                    [ "cursor" ==> "se-resize"]
                    
                test
                    "Cursor SwResize"
                    [Cursor.SwResize]
                    [ "cursor" ==> "sw-resize"]
                    
                test
                    "Cursor NeswResize"
                    [Cursor.NeswResize]
                    [ "cursor" ==> "nesw-resize"]
                    
                test
                    "Cursor NwseResize"
                    [Cursor.NwseResize]
                    [ "cursor" ==> "nwse-resize"]
            ]