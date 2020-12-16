namespace Fss

module CursorTypes =
    type Cursor =
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

[<AutoOpen>]
module Cursor =
    open CursorTypes

    let private cursorToString (cursor: ICursor) =
        let stringifyCursor =
            function
                | Default -> "default"
                | ContextMenu -> "context-menu"
                | Help -> "help"
                | Pointer -> "pointer"
                | Progress -> "progress"
                | Wait -> "wait"
                | Cell -> "cell"
                | Crosshair -> "crosshair"
                | Text -> "text"
                | VerticalText -> "vertical-text"
                | Alias -> "alias"
                | Copy -> "copy"
                | Move -> "move"
                | NoDrop -> "no-drop"
                | NotAllowed -> "not-allowed"
                | AllScroll -> "all-scroll"
                | ColResize -> "col-resize"
                | RowResize -> "row-resize"
                | NResize -> "n-resize"
                | EResize -> "e-resize"
                | SResize -> "s-resize"
                | WResize -> "w-resize"
                | NsResize -> "ns-resize"
                | EwResize -> "ew-resize"
                | NeResize -> "ne-resize"
                | NwResize -> "nw-resize"
                | SeResize -> "se-resize"
                | SwResize -> "sw-resize"
                | NeswResize -> "nesw-resize"
                | NwseResize -> "nwse-resize"

        match cursor with
        | :? Cursor as c -> stringifyCursor c
        | :? Auto -> GlobalValue.auto
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown cursor"

    let private cursorValue value = PropertyValue.cssValue Property.Cursor value
    let private cursorValue' value =
        value
        |> cursorToString
        |> cursorValue

    type Cursor =
        static member Value (url: string) = sprintf "url(%s)" url |> cursorValue
        static member Value (url: string, x: int, y: int) = sprintf "url(%s) %d %d" url x y |> cursorValue
        static member Value (cursor: ICursor) = cursor |> cursorValue'

        static member Default = Default |> cursorValue'
        static member ContextMenu = ContextMenu |> cursorValue'
        static member Help = Help |> cursorValue'
        static member Pointer = Pointer |> cursorValue'
        static member Progress = Progress |> cursorValue'
        static member Wait = Wait |> cursorValue'
        static member Cell = Cell |> cursorValue'
        static member Crosshair = Crosshair |> cursorValue'
        static member Text = Text |> cursorValue'
        static member VerticalText = VerticalText |> cursorValue'
        static member Alias = Alias |> cursorValue'
        static member Copy = Copy |> cursorValue'
        static member Move = Move |> cursorValue'
        static member NoDrop = NoDrop |> cursorValue'
        static member NotAllowed = NotAllowed |> cursorValue'
        static member AllScroll = AllScroll |> cursorValue'
        static member ColResize = ColResize |> cursorValue'
        static member RowResize = RowResize |> cursorValue'
        static member NResize = NResize |> cursorValue'
        static member EResize = EResize |> cursorValue'
        static member SResize = SResize |> cursorValue'
        static member WResize = WResize |> cursorValue'
        static member NsResize = NsResize |> cursorValue'
        static member EwResize = EwResize |> cursorValue'
        static member NeResize = NeResize |> cursorValue'
        static member NwResize = NwResize |> cursorValue'
        static member SeResize = SeResize |> cursorValue'
        static member SwResize = SwResize |> cursorValue'
        static member NeswResize = NeswResize |> cursorValue'
        static member NwseResize = NwseResize |> cursorValue'

        static member Auto = Auto |> cursorValue'
        static member Inherit = Inherit |> cursorValue'
        static member Initial = Initial |> cursorValue'
        static member Unset = Unset |> cursorValue'
        static member None = None |> cursorValue'

    let Cursor' (cursor: ICursor) = Cursor.Value(cursor)
