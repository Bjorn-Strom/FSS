namespace Fss

[<AutoOpen>]
module Cursor =
    let private cursorToString (cursor: Types.ICursor) =
        match cursor with
        | :? Types.Cursor as c -> Utilities.Helpers.duToKebab c
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown cursor"

    let private cursorValue value = Types.propertyHelpers.cssValue Types.Property.Cursor value
    let private cursorValue' value =
        value
        |> cursorToString
        |> cursorValue

    type Cursor =
        static member Value (url: string) = sprintf "url(%s)" url |> cursorValue
        static member Value (url: string, x: int, y: int) = sprintf "url(%s) %d %d" url x y |> cursorValue
        static member Value (cursor: Types.ICursor) = cursor |> cursorValue'

        static member Default = Types.Cursor.Default |> cursorValue'
        static member ContextMenu = Types.Cursor.ContextMenu |> cursorValue'
        static member Help = Types.Cursor.Help |> cursorValue'
        static member Pointer = Types.Cursor.Pointer |> cursorValue'
        static member Progress = Types.Cursor.Progress |> cursorValue'
        static member Wait = Types.Cursor.Wait |> cursorValue'
        static member Cell = Types.Cursor.Cell |> cursorValue'
        static member Crosshair = Types.Cursor.Crosshair |> cursorValue'
        static member Text = Types.Cursor.Text |> cursorValue'
        static member VerticalText = Types.Cursor.VerticalText |> cursorValue'
        static member Alias = Types.Cursor.Alias |> cursorValue'
        static member Copy = Types.Cursor.Copy |> cursorValue'
        static member Move = Types.Cursor.Move |> cursorValue'
        static member NoDrop = Types.Cursor.NoDrop |> cursorValue'
        static member NotAllowed = Types.Cursor.NotAllowed |> cursorValue'
        static member AllScroll = Types.Cursor.AllScroll |> cursorValue'
        static member ColResize = Types.Cursor.ColResize |> cursorValue'
        static member RowResize = Types.Cursor.RowResize |> cursorValue'
        static member NResize = Types.Cursor.NResize |> cursorValue'
        static member EResize = Types.Cursor.EResize |> cursorValue'
        static member SResize = Types.Cursor.SResize |> cursorValue'
        static member WResize = Types.Cursor.WResize |> cursorValue'
        static member NsResize = Types.Cursor.NsResize |> cursorValue'
        static member EwResize = Types.Cursor.EwResize |> cursorValue'
        static member NeResize = Types.Cursor.NeResize |> cursorValue'
        static member NwResize = Types.Cursor.NwResize |> cursorValue'
        static member SeResize = Types.Cursor.SeResize |> cursorValue'
        static member SwResize = Types.Cursor.SwResize |> cursorValue'
        static member NeswResize = Types.Cursor.NeswResize |> cursorValue'
        static member NwseResize = Types.Cursor.NwseResize |> cursorValue'

        static member Auto = Types.Auto |> cursorValue'
        static member Inherit = Types.Inherit |> cursorValue'
        static member Initial = Types.Initial |> cursorValue'
        static member Unset = Types.Unset |> cursorValue'
        static member None = Types.None' |> cursorValue'

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
    let Cursor' (cursor: Types.ICursor) = Cursor.Value(cursor)
