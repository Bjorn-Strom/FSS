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
                    [Cursor None]
                    [ "cursor" ==> "none"]
                    
                test
                    "Cursor auto"
                    [Cursor Auto]
                    [ "cursor" ==> "auto"]
                    
                test
                    "Cursor inherit"
                    [Cursor Inherit]
                    [ "cursor" ==> "inherit"]
                    
                test
                    "Cursor initial"
                    [Cursor Initial]
                    [ "cursor" ==> "initial"]
                
                test
                    "Cursor unset"
                    [Cursor Unset]
                    [ "cursor" ==> "unset"]
                
                test
                    "Cursor alias"
                    [Cursor Cursor.Alias]
                    [ "cursor" ==> "alias"]
                                    
                test
                    "Cursor ContextMenu"
                    [Cursor Cursor.ContextMenu]
                    [ "cursor" ==> "context-menu"]
                    
                test
                    "Cursor Help"
                    [Cursor Cursor.Help]
                    [ "cursor" ==> "help"]
                    
                test
                    "Cursor Pointer"
                    [Cursor Cursor.Pointer]
                    [ "cursor" ==> "pointer"]
                    
                test
                    "Cursor Progress"
                    [Cursor Cursor.Progress]
                    [ "cursor" ==> "progress"]
                    
                test
                    "Cursor Wait"
                    [Cursor Cursor.Wait]
                    [ "cursor" ==> "wait"]
                    
                test
                    "Cursor Cell"
                    [Cursor Cursor.Cell]
                    [ "cursor" ==> "cell"]
                    
                test
                    "Cursor Crosshair"
                    [Cursor Cursor.Crosshair]
                    [ "cursor" ==> "crosshair"]
                    
                test
                    "Cursor Text"
                    [Cursor Cursor.Text]
                    [ "cursor" ==> "text"]
                    
                test
                    "Cursor VerticalText"
                    [Cursor Cursor.VerticalText]
                    [ "cursor" ==> "vertical-text"]
                    
                test
                    "Cursor Alias"
                    [Cursor Cursor.Alias]
                    [ "cursor" ==> "alias"]
                    
                test
                    "Cursor Copy"
                    [Cursor Cursor.Copy]
                    [ "cursor" ==> "copy"]
                    
                test
                    "Cursor Move"
                    [Cursor Cursor.Move]
                    [ "cursor" ==> "move"]
                    
                test
                    "Cursor NoDrop"
                    [Cursor Cursor.NoDrop]
                    [ "cursor" ==> "no-drop"]
                    
                test
                    "Cursor NotAllowed"
                    [Cursor Cursor.NotAllowed]
                    [ "cursor" ==> "not-allowed"]
                    
                test
                    "Cursor AllScroll"
                    [Cursor Cursor.AllScroll]
                    [ "cursor" ==> "all-scroll"]
                    
                test
                    "Cursor ColResize"
                    [Cursor Cursor.ColResize]
                    [ "cursor" ==> "col-resize"]
                    
                test
                    "Cursor RowResize"
                    [Cursor Cursor.RowResize]
                    [ "cursor" ==> "row-resize"]
                    
                test
                    "Cursor NResize"
                    [Cursor Cursor.NResize]
                    [ "cursor" ==> "n-resize"]
                    
                test
                    "Cursor EResize"
                    [Cursor Cursor.EResize]
                    [ "cursor" ==> "e-resize"]
                    
                test
                    "Cursor SResize"
                    [Cursor Cursor.SResize]
                    [ "cursor" ==> "s-resize"]
                    
                test
                    "Cursor WResize"
                    [Cursor Cursor.WResize]
                    [ "cursor" ==> "w-resize"]
                    
                test
                    "Cursor NsResize"
                    [Cursor Cursor.NsResize]
                    [ "cursor" ==> "ns-resize"]
                    
                test
                    "Cursor EwResize"
                    [Cursor Cursor.EwResize]
                    [ "cursor" ==> "ew-resize"]
                    
                test
                    "Cursor NeResize"
                    [Cursor Cursor.NeResize]
                    [ "cursor" ==> "ne-resize"]
                    
                test
                    "Cursor NwResize"
                    [Cursor Cursor.NwResize]
                    [ "cursor" ==> "nw-resize"]
                    
                test
                    "Cursor SeResize"
                    [Cursor Cursor.SeResize]
                    [ "cursor" ==> "se-resize"]
                    
                test
                    "Cursor SwResize"
                    [Cursor Cursor.SwResize]
                    [ "cursor" ==> "sw-resize"]
                    
                test
                    "Cursor NeswResize"
                    [Cursor Cursor.NeswResize]
                    [ "cursor" ==> "nesw-resize"]
                    
                test
                    "Cursor NwseResize"
                    [Cursor Cursor.NwseResize]
                    [ "cursor" ==> "nwse-resize"]
            ]