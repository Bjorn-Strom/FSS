namespace Fss

open Fss

[<RequireQualifiedAccess>]
module CursorType =
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

    let private cursorToString (cursor: ICursor) =
        match cursor with
        | :? CursorType.Cursor as c -> Utilities.Helpers.duToKebab c
        | :? Auto -> GlobalValue.auto
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
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

        static member Default = CursorType.Default |> cursorValue'
        static member ContextMenu = CursorType.ContextMenu |> cursorValue'
        static member Help = CursorType.Help |> cursorValue'
        static member Pointer = CursorType.Pointer |> cursorValue'
        static member Progress = CursorType.Progress |> cursorValue'
        static member Wait = CursorType.Wait |> cursorValue'
        static member Cell = CursorType.Cell |> cursorValue'
        static member Crosshair = CursorType.Crosshair |> cursorValue'
        static member Text = CursorType.Text |> cursorValue'
        static member VerticalText = CursorType.VerticalText |> cursorValue'
        static member Alias = CursorType.Alias |> cursorValue'
        static member Copy = CursorType.Copy |> cursorValue'
        static member Move = CursorType.Move |> cursorValue'
        static member NoDrop = CursorType.NoDrop |> cursorValue'
        static member NotAllowed = CursorType.NotAllowed |> cursorValue'
        static member AllScroll = CursorType.AllScroll |> cursorValue'
        static member ColResize = CursorType.ColResize |> cursorValue'
        static member RowResize = CursorType.RowResize |> cursorValue'
        static member NResize = CursorType.NResize |> cursorValue'
        static member EResize = CursorType.EResize |> cursorValue'
        static member SResize = CursorType.SResize |> cursorValue'
        static member WResize = CursorType.WResize |> cursorValue'
        static member NsResize = CursorType.NsResize |> cursorValue'
        static member EwResize = CursorType.EwResize |> cursorValue'
        static member NeResize = CursorType.NeResize |> cursorValue'
        static member NwResize = CursorType.NwResize |> cursorValue'
        static member SeResize = CursorType.SeResize |> cursorValue'
        static member SwResize = CursorType.SwResize |> cursorValue'
        static member NeswResize = CursorType.NeswResize |> cursorValue'
        static member NwseResize = CursorType.NwseResize |> cursorValue'

        static member Auto = Auto |> cursorValue'
        static member Inherit = Inherit |> cursorValue'
        static member Initial = Initial |> cursorValue'
        static member Unset = Unset |> cursorValue'
        static member None = None |> cursorValue'

    /// <summary>Specifies how elements behave before a generated box.</summary>
    /// <param name="cursor">
    ///     can be:
    ///     - <c> Cursor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Cursor' (cursor: ICursor) = Cursor.Value(cursor)
