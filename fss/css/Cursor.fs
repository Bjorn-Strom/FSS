namespace Fss
open FssTypes

[<AutoOpen>]
module Cursor =
    let private cursorToString (cursor: ICursor) =
        match cursor with
        | :? Cursor.Cursor as c -> Utilities.Helpers.duToKebab c
        | :? Auto -> GlobalValue.auto
        | :? None' -> GlobalValue.none
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

        static member Default = Cursor.Default |> cursorValue'
        static member ContextMenu = Cursor.ContextMenu |> cursorValue'
        static member Help = Cursor.Help |> cursorValue'
        static member Pointer = Cursor.Pointer |> cursorValue'
        static member Progress = Cursor.Progress |> cursorValue'
        static member Wait = Cursor.Wait |> cursorValue'
        static member Cell = Cursor.Cell |> cursorValue'
        static member Crosshair = Cursor.Crosshair |> cursorValue'
        static member Text = Cursor.Text |> cursorValue'
        static member VerticalText = Cursor.VerticalText |> cursorValue'
        static member Alias = Cursor.Alias |> cursorValue'
        static member Copy = Cursor.Copy |> cursorValue'
        static member Move = Cursor.Move |> cursorValue'
        static member NoDrop = Cursor.NoDrop |> cursorValue'
        static member NotAllowed = Cursor.NotAllowed |> cursorValue'
        static member AllScroll = Cursor.AllScroll |> cursorValue'
        static member ColResize = Cursor.ColResize |> cursorValue'
        static member RowResize = Cursor.RowResize |> cursorValue'
        static member NResize = Cursor.NResize |> cursorValue'
        static member EResize = Cursor.EResize |> cursorValue'
        static member SResize = Cursor.SResize |> cursorValue'
        static member WResize = Cursor.WResize |> cursorValue'
        static member NsResize = Cursor.NsResize |> cursorValue'
        static member EwResize = Cursor.EwResize |> cursorValue'
        static member NeResize = Cursor.NeResize |> cursorValue'
        static member NwResize = Cursor.NwResize |> cursorValue'
        static member SeResize = Cursor.SeResize |> cursorValue'
        static member SwResize = Cursor.SwResize |> cursorValue'
        static member NeswResize = Cursor.NeswResize |> cursorValue'
        static member NwseResize = Cursor.NwseResize |> cursorValue'

        static member Auto = Auto |> cursorValue'
        static member Inherit = Inherit |> cursorValue'
        static member Initial = Initial |> cursorValue'
        static member Unset = Unset |> cursorValue'
        static member None = None' |> cursorValue'

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
