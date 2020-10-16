namespace Fss

open Utilities.Helpers
open Types

module Cursor =
    type CursorType =
        | Default
        | ContextMenu
        | Help
        | Pointer
        | Progress
        | Wait
        | Cell
        | Crosshair
        | Text
        | VerticalText
        | Alias
        | Copy
        | Move
        | NoDrop
        | NotAllowed
        | AllScroll
        | ColResize
        | RowResize
        | NResize
        | EResize
        | SResize
        | WResize
        | NsResize
        | EwResize
        | NeResize
        | NwResize
        | SeResize
        | SwResize
        | NeswResize
        | NwseResize
        interface ICursor

    type Cursor = 
        | Cursor of CursorType
        | CursorUrl of string * CursorType
        | CursorUrlPosition of string * int * int * CursorType
        interface ICursor

module CursorValue =
    open Cursor
    open Global
    
    let cursor (v: ICursor): string =
        let stringifyCursor (c: Cursor): string =
            match c with
                | Cursor cursor                         -> duToKebab cursor
                | CursorUrl (url, cursor)               -> sprintf "url(%s) %s" url (duToKebab cursor)
                | CursorUrlPosition (url, x, y, cursor) -> sprintf "url(%s) %d %d %s" url x y (duToKebab cursor)
        
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Auto       as a -> GlobalValue.auto a
            | :? None       as n -> GlobalValue.none n
            | :? Cursor     as c -> stringifyCursor c
            | :? CursorType as c -> duToKebab c
            | _ -> "Unknown cursor"
