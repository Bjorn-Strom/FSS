namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module CursorClasses =
        type CursorParent(property) =
            inherit CssRuleWithAutoNone(property)
            member this.value(url: string) = (property, Url url) |> Rule
            member this.value(cursor: Cursor) = (property, cursor) |> Rule
            member this.url(url: string) =
                (property, url |> Url) |> Rule
            member this.url(url: string, x: int, y: int) =
                let value = $"url({url}) {x} {y}"
                (property, value |> String) |> Rule
            member this.default' = (property, Default) |> Rule
            member this.contextMenu = (property, ContextMenu) |> Rule
            member this.help = (property, Help) |> Rule
            member this.pointer = (property, Pointer) |> Rule
            member this.progress = (property, Progress) |> Rule
            member this.wait = (property, Wait) |> Rule
            member this.cell = (property, Cell) |> Rule
            member this.crosshair = (property, Crosshair) |> Rule
            member this.text = (property, Text) |> Rule
            member this.verticalText = (property, VerticalText) |> Rule
            member this.alias = (property, Alias) |> Rule
            member this.copy = (property, Copy) |> Rule
            member this.move = (property, Move) |> Rule
            member this.noDrop = (property, NoDrop) |> Rule
            member this.notAllowed = (property, NotAllowed) |> Rule
            member this.allScroll = (property, AllScroll) |> Rule
            member this.colResize = (property, ColResize) |> Rule
            member this.rowResize = (property, RowResize) |> Rule
            member this.nResize = (property, NResize) |> Rule
            member this.eResize = (property, EResize) |> Rule
            member this.sResize = (property, SResize) |> Rule
            member this.wResize = (property, WResize) |> Rule
            member this.nsResize = (property, NsResize) |> Rule
            member this.ewResize = (property, EwResize) |> Rule
            member this.neResize = (property, NeResize) |> Rule
            member this.nwResize = (property, NwResize) |> Rule
            member this.seResize = (property, SeResize) |> Rule
            member this.swResize = (property, SwResize) |> Rule
            member this.neswResize = (property, NeswResize) |> Rule
            member this.nwseResize = (property, NwseResize) |> Rule
