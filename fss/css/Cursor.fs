namespace Fss
open FssTypes

[<AutoOpen>]
module Cursor =
    let private cursorToString (cursor: ICursor) =
        match cursor with
        | :? Cursor as c -> Utilities.Helpers.duToKebab c
        | :? Auto -> auto
        | :? None' -> none
        | :? Global as g -> global' g
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

        static member Default = FssTypes.Cursor.Default |> cursorValue'
        static member ContextMenu = FssTypes.Cursor.ContextMenu |> cursorValue'
        static member Help = FssTypes.Cursor.Help |> cursorValue'
        static member Pointer = FssTypes.Cursor.Pointer |> cursorValue'
        static member Progress = FssTypes.Cursor.Progress |> cursorValue'
        static member Wait = FssTypes.Cursor.Wait |> cursorValue'
        static member Cell = FssTypes.Cursor.Cell |> cursorValue'
        static member Crosshair = FssTypes.Cursor.Crosshair |> cursorValue'
        static member Text = FssTypes.Cursor.Text |> cursorValue'
        static member VerticalText = FssTypes.Cursor.VerticalText |> cursorValue'
        static member Alias = FssTypes.Cursor.Alias |> cursorValue'
        static member Copy = FssTypes.Cursor.Copy |> cursorValue'
        static member Move = FssTypes.Cursor.Move |> cursorValue'
        static member NoDrop = FssTypes.Cursor.NoDrop |> cursorValue'
        static member NotAllowed = FssTypes.Cursor.NotAllowed |> cursorValue'
        static member AllScroll = FssTypes.Cursor.AllScroll |> cursorValue'
        static member ColResize = FssTypes.Cursor.ColResize |> cursorValue'
        static member RowResize = FssTypes.Cursor.RowResize |> cursorValue'
        static member NResize = FssTypes.Cursor.NResize |> cursorValue'
        static member EResize = FssTypes.Cursor.EResize |> cursorValue'
        static member SResize = FssTypes.Cursor.SResize |> cursorValue'
        static member WResize = FssTypes.Cursor.WResize |> cursorValue'
        static member NsResize = FssTypes.Cursor.NsResize |> cursorValue'
        static member EwResize = FssTypes.Cursor.EwResize |> cursorValue'
        static member NeResize = FssTypes.Cursor.NeResize |> cursorValue'
        static member NwResize = FssTypes.Cursor.NwResize |> cursorValue'
        static member SeResize = FssTypes.Cursor.SeResize |> cursorValue'
        static member SwResize = FssTypes.Cursor.SwResize |> cursorValue'
        static member NeswResize = FssTypes.Cursor.NeswResize |> cursorValue'
        static member NwseResize = FssTypes.Cursor.NwseResize |> cursorValue'

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
