namespace Fss

open Utilities.Helpers

module Cursor =
    type CursorType =
        | Auto
        | Default
        | None
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

    type Cursor = 
        | Cursor of CursorType
        | CursorUrl of string * CursorType
        | CursorUrlPosition of string * int * int * CursorType

    let value (v: Cursor): string =
        match v with
            | Cursor cursor                         -> duToKebab cursor
            | CursorUrl (url, cursor)               -> sprintf "url(%s) %s" url (duToKebab cursor)
            | CursorUrlPosition (url, x, y, cursor) -> sprintf "url(%s) %d %d %s" url x y (duToKebab cursor)