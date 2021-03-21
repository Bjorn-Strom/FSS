namespace Fss

[<AutoOpen>]
module Table =
    let private captionSideToString (captionSide: Types.ICaptionSide) =
        match captionSide with
        | :? Types.CaptionSide as c -> Utilities.Helpers.duToKebab c
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown caption side"

    let private emptyCellsToString (emptyCells: Types.IEmptyCells) =
        match emptyCells with
        | :? Types.EmptyCells as e -> Utilities.Helpers.duToLowercase e
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown empty cells"

    let private tableLayoutToString (tableLayout: Types.ITableLayout) =
        match tableLayout with
        | :? Types.TableLayout as t -> Utilities.Helpers.duToLowercase t
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown table layout"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    let private captionSideValue value = Types.cssValue Types.Property.CaptionSide value
    let private captionSideValue' value =
        value
        |> captionSideToString
        |> captionSideValue

    type CaptionSide =
        static member Value (captionSide: Types.ICaptionSide) = captionSide |> captionSideValue'
        static member Top = Types.CaptionSide.Top |> captionSideValue'
        static member Bottom = Types.CaptionSide.Bottom |> captionSideValue'
        static member Left = Types.CaptionSide.Left |> captionSideValue'
        static member Right = Types.CaptionSide.Right |> captionSideValue'
        static member TopOutside = Types.CaptionSide.TopOutside |> captionSideValue'
        static member BottomOutside = Types.CaptionSide.BottomOutside |> captionSideValue'
        static member Inherit = Types.Inherit |> captionSideValue'
        static member Initial = Types.Initial |> captionSideValue'
        static member Unset = Types.Unset |> captionSideValue'

    /// <summary>Specifies which side the caption of a table will be.</summary>
    /// <param name="captionSide">
    ///     can be:
    ///     - <c> CaptionSide </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let CaptionSide' captionSide = CaptionSide.Value captionSide

    // https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
    let private emptyCellsValue value = Types.cssValue Types.Property.EmptyCells value
    let private emptyCellsValue' value =
        value
        |> emptyCellsToString
        |> emptyCellsValue
    type EmptyCells =
        static member Value (emptyCells: Types.IEmptyCells) = emptyCells |> emptyCellsValue'
        static member Show = Types.EmptyCells.Show |> emptyCellsValue'
        static member Hide = Types.EmptyCells.Hide |> emptyCellsValue'
        static member Inherit = Types.Inherit |> emptyCellsValue'
        static member Initial = Types.Initial |> emptyCellsValue'
        static member Unset = Types.Unset |> emptyCellsValue'

    /// <summary>Specifies whether or not emtpy cells should have borders.</summary>
    /// <param name="emptyCells">
    ///     can be:
    ///     - <c> EmptyCells </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let EmptyCells' (emptyCells: Types.IEmptyCells) = emptyCells |> EmptyCells.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    let private tableLayoutValue value = Types.cssValue Types.Property.TableLayout value
    let private tableLayoutValue' value =
        value
        |> tableLayoutToString
        |> tableLayoutValue

    type TableLayout =
        static member Value (layout: Types.ITableLayout) = layout |> tableLayoutValue'
        static member Fixed = Types.TableLayout.Fixed |> tableLayoutValue'
        static member Auto = Types.Auto |> tableLayoutValue'
        static member Inherit = Types.Inherit |> tableLayoutValue'
        static member Initial = Types.Initial |> tableLayoutValue'
        static member Unset = Types.Unset |> tableLayoutValue'

    /// <summary>Specifies table layout.</summary>
    /// <param name="layout">
    ///     can be:
    ///     - <c> TableLayout </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TableLayout' layout = TableLayout.Value layout
