namespace Fss

open Fable.Core

[<AutoOpen>]
module Cursor =
    let private cursorToString (cursor: FssTypes.ICursor) =
        match cursor with
        | :? FssTypes.Cursor.Cursor as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown cursor"

    let private cursorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Cursor value
    let private cursorValue' value =
        value
        |> cursorToString
        |> cursorValue

    [<Erase>]
    type Cursor =
        static member value (url: string) = sprintf "url(%s)" url |> cursorValue
        static member value (url: string, x: int, y: int) = sprintf "url(%s) %d %d" url x y |> cursorValue
        static member value (cursor: FssTypes.ICursor) = cursor |> cursorValue'

        static member default' = FssTypes.Cursor.Default |> cursorValue'
        static member contextMenu = FssTypes.Cursor.ContextMenu |> cursorValue'
        static member help = FssTypes.Cursor.Help |> cursorValue'
        static member pointer = FssTypes.Cursor.Pointer |> cursorValue'
        static member progress = FssTypes.Cursor.Progress |> cursorValue'
        static member wait = FssTypes.Cursor.Wait |> cursorValue'
        static member cell = FssTypes.Cursor.Cell |> cursorValue'
        static member crosshair = FssTypes.Cursor.Crosshair |> cursorValue'
        static member text = FssTypes.Cursor.Text |> cursorValue'
        static member verticalText = FssTypes.Cursor.VerticalText |> cursorValue'
        static member alias = FssTypes.Cursor.Alias |> cursorValue'
        static member copy = FssTypes.Cursor.Copy |> cursorValue'
        static member move = FssTypes.Cursor.Move |> cursorValue'
        static member noDrop = FssTypes.Cursor.NoDrop |> cursorValue'
        static member notAllowed = FssTypes.Cursor.NotAllowed |> cursorValue'
        static member allScroll = FssTypes.Cursor.AllScroll |> cursorValue'
        static member colResize = FssTypes.Cursor.ColResize |> cursorValue'
        static member rowResize = FssTypes.Cursor.RowResize |> cursorValue'
        static member nResize = FssTypes.Cursor.NResize |> cursorValue'
        static member eResize = FssTypes.Cursor.EResize |> cursorValue'
        static member sResize = FssTypes.Cursor.SResize |> cursorValue'
        static member wResize = FssTypes.Cursor.WResize |> cursorValue'
        static member nsResize = FssTypes.Cursor.NsResize |> cursorValue'
        static member ewResize = FssTypes.Cursor.EwResize |> cursorValue'
        static member neResize = FssTypes.Cursor.NeResize |> cursorValue'
        static member nwResize = FssTypes.Cursor.NwResize |> cursorValue'
        static member seResize = FssTypes.Cursor.SeResize |> cursorValue'
        static member swResize = FssTypes.Cursor.SwResize |> cursorValue'
        static member neswResize = FssTypes.Cursor.NeswResize |> cursorValue'
        static member nwseResize = FssTypes.Cursor.NwseResize |> cursorValue'

        static member auto = FssTypes.Auto |> cursorValue'
        static member inherit' = FssTypes.Inherit |> cursorValue'
        static member initial = FssTypes.Initial |> cursorValue'
        static member unset = FssTypes.Unset |> cursorValue'
        static member none = FssTypes.None' |> cursorValue'

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
    let Cursor' (cursor: FssTypes.ICursor) = Cursor.value(cursor)
