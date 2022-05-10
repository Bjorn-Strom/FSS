namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Cursor =
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
        | Grab
        | Grabbing
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
        | ZoomIn
        | ZoomOut
        interface ICssValue with
            member this.StringifyCss() =
                match this with
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
                | Grab -> "grab"
                | Grabbing -> "grabbing"
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
                | ZoomIn -> "zoom-in"
                | ZoomOut -> "zoom-out"

[<RequireQualifiedAccess>]
module CursorClasses =
    type CursorParent(property) =
        inherit CssRuleWithAutoNone(property)
        member this.value(url: string) = (property, UrlMaster url) |> Rule
        member this.value(cursor: Cursor.Cursor) = (property, cursor) |> Rule
        member this.url(url: string) =
            (property, url |> UrlMaster) |> Rule
        member this.url(url: string, x: int, y: int) =
            let value = $"url({url}) {x} {y}"
            (property, value |> String) |> Rule
        /// Platform specific cursor
        member this.default' = (property, Cursor.Default) |> Rule
        /// A context menu is available
        member this.contextMenu = (property, Cursor.ContextMenu) |> Rule
        /// Help information is available
        member this.help = (property, Cursor.Help) |> Rule
        /// Cursor indicating a link
        member this.pointer = (property, Cursor.Pointer) |> Rule
        /// Program is busy but the user can interact the interface
        member this.progress = (property, Cursor.Progress) |> Rule
        /// Program is busy but the user can not interact the interface
        member this.wait = (property, Cursor.Wait) |> Rule
        /// The table or set of cells can be selected
        member this.cell = (property, Cursor.Cell) |> Rule
        /// Indicates selection in a bitmap
        member this.crosshair = (property, Cursor.Crosshair) |> Rule
        /// Text can be selected
        member this.text = (property, Cursor.Text) |> Rule
        /// Text can be selected
        member this.verticalText = (property, Cursor.VerticalText) |> Rule
        /// An alias or shortcut will be created
        member this.alias = (property, Cursor.Alias) |> Rule
        /// Something that can be copied
        member this.copy = (property, Cursor.Copy) |> Rule
        /// Something that can be moved
        member this.move = (property, Cursor.Move) |> Rule
        /// An item may not be dropped at the current location
        member this.noDrop = (property, Cursor.NoDrop) |> Rule
        /// The request action will not be carried out
        member this.notAllowed = (property, Cursor.NotAllowed) |> Rule
        /// Something that can be grabbed
        member this.grab = (property, Cursor.Grab) |> Rule
        /// Something is currently being grabbed
        member this.grabbing = (property, Cursor.Grabbing) |> Rule
        /// Something can be scrolled in any direction
        member this.allScroll = (property, Cursor.AllScroll) |> Rule
        /// Column can be resized horizontally
        member this.colResize = (property, Cursor.ColResize) |> Rule
        /// Row can be resized vertically
        member this.rowResize = (property, Cursor.RowResize) |> Rule
        /// An edge can be moved north
        member this.nResize = (property, Cursor.NResize) |> Rule
        /// An edge can be moved east
        member this.eResize = (property, Cursor.EResize) |> Rule
        /// An edge can be moved south
        member this.sResize = (property, Cursor.SResize) |> Rule
        /// An edge can be moved wst
        member this.wResize = (property, Cursor.WResize) |> Rule
        /// An edge can be moved north or south
        member this.nsResize = (property, Cursor.NsResize) |> Rule
        /// An edge can be moved east or west
        member this.ewResize = (property, Cursor.EwResize) |> Rule
        /// An edge can be moved north east
        member this.neResize = (property, Cursor.NeResize) |> Rule
        /// An edge can be moved north west
        member this.nwResize = (property, Cursor.NwResize) |> Rule
        /// An edge can be moved south east
        member this.seResize = (property, Cursor.SeResize) |> Rule
        /// An edge can be moved south west
        member this.swResize = (property, Cursor.SwResize) |> Rule
        /// An edge can be moved north east or south west
        member this.neswResize = (property, Cursor.NeswResize) |> Rule
        /// An edge can be moved north west or south east
        member this.nwseResize = (property, Cursor.NwseResize) |> Rule
        /// Something can be zoomed in
        member this.zoomIn = (property, Cursor.ZoomIn) |> Rule
        /// Something can be zoomed out
        member this.zoomOut = (property, Cursor.ZoomOut) |> Rule
