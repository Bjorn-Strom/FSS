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
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module CursorClasses =
    type CursorParent(property) =
        inherit CssRuleWithAutoNone(property)
        member this.value(url: string) = (property, Url url) |> Rule
        member this.value(cursor: Cursor.Cursor) = (property, cursor) |> Rule
        member this.url(url: string) =
            (property, url |> Url) |> Rule
        member this.url(url: string, x: int, y: int) =
            let value = $"url({url}) {x} {y}"
            (property, value |> String) |> Rule
        member this.default' = (property, Cursor.Default) |> Rule
        member this.contextMenu = (property, Cursor.ContextMenu) |> Rule
        member this.help = (property, Cursor.Help) |> Rule
        member this.pointer = (property, Cursor.Pointer) |> Rule
        member this.progress = (property, Cursor.Progress) |> Rule
        member this.wait = (property, Cursor.Wait) |> Rule
        member this.cell = (property, Cursor.Cell) |> Rule
        member this.crosshair = (property, Cursor.Crosshair) |> Rule
        member this.text = (property, Cursor.Text) |> Rule
        member this.verticalText = (property, Cursor.VerticalText) |> Rule
        member this.alias = (property, Cursor.Alias) |> Rule
        member this.copy = (property, Cursor.Copy) |> Rule
        member this.move = (property, Cursor.Move) |> Rule
        member this.noDrop = (property, Cursor.NoDrop) |> Rule
        member this.notAllowed = (property, Cursor.NotAllowed) |> Rule
        member this.allScroll = (property, Cursor.AllScroll) |> Rule
        member this.colResize = (property, Cursor.ColResize) |> Rule
        member this.rowResize = (property, Cursor.RowResize) |> Rule
        member this.nResize = (property, Cursor.NResize) |> Rule
        member this.eResize = (property, Cursor.EResize) |> Rule
        member this.sResize = (property, Cursor.SResize) |> Rule
        member this.wResize = (property, Cursor.WResize) |> Rule
        member this.nsResize = (property, Cursor.NsResize) |> Rule
        member this.ewResize = (property, Cursor.EwResize) |> Rule
        member this.neResize = (property, Cursor.NeResize) |> Rule
        member this.nwResize = (property, Cursor.NwResize) |> Rule
        member this.seResize = (property, Cursor.SeResize) |> Rule
        member this.swResize = (property, Cursor.SwResize) |> Rule
        member this.neswResize = (property, Cursor.NeswResize) |> Rule
        member this.nwseResize = (property, Cursor.NwseResize) |> Rule
