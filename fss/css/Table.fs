namespace Fss

[<AutoOpen>]
module Table =
    let private captionSideToString (captionSide: FssTypes.ICaptionSide) =
        match captionSide with
        | :? FssTypes.Table.CaptionSide as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown caption side"

    let private emptyCellsToString (emptyCells: FssTypes.IEmptyCells) =
        match emptyCells with
        | :? FssTypes.Table.EmptyCells as e -> Utilities.Helpers.duToLowercase e
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown empty cells"

    let private tableLayoutToString (tableLayout: FssTypes.ITableLayout) =
        match tableLayout with
        | :? FssTypes.Table.Layout as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown table layout"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    let private captionSideValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.CaptionSide value
    let private captionSideValue' value =
        value
        |> captionSideToString
        |> captionSideValue

    type CaptionSide =
        static member Value (captionSide: FssTypes.ICaptionSide) = captionSide |> captionSideValue'
        static member Top = FssTypes.Table.CaptionSide.Top |> captionSideValue'
        static member Bottom = FssTypes.Table.CaptionSide.Bottom |> captionSideValue'
        static member Left = FssTypes.Table.CaptionSide.Left |> captionSideValue'
        static member Right = FssTypes.Table.CaptionSide.Right |> captionSideValue'
        static member TopOutside = FssTypes.Table.CaptionSide.TopOutside |> captionSideValue'
        static member BottomOutside = FssTypes.Table.CaptionSide.BottomOutside |> captionSideValue'
        static member Inherit = FssTypes.Inherit |> captionSideValue'
        static member Initial = FssTypes.Initial |> captionSideValue'
        static member Unset = FssTypes.Unset |> captionSideValue'

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
    let private emptyCellsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.EmptyCells value
    let private emptyCellsValue' value =
        value
        |> emptyCellsToString
        |> emptyCellsValue
    type EmptyCells =
        static member Value (emptyCells: FssTypes.IEmptyCells) = emptyCells |> emptyCellsValue'
        static member Show = FssTypes.Table.EmptyCells.Show |> emptyCellsValue'
        static member Hide = FssTypes.Table.EmptyCells.Hide |> emptyCellsValue'
        static member Inherit = FssTypes.Inherit |> emptyCellsValue'
        static member Initial = FssTypes.Initial |> emptyCellsValue'
        static member Unset = FssTypes.Unset |> emptyCellsValue'

    /// <summary>Specifies whether or not emtpy cells should have borders.</summary>
    /// <param name="emptyCells">
    ///     can be:
    ///     - <c> EmptyCells </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let EmptyCells' (emptyCells: FssTypes.IEmptyCells) = emptyCells |> EmptyCells.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    let private tableLayoutValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TableLayout value
    let private tableLayoutValue' value =
        value
        |> tableLayoutToString
        |> tableLayoutValue

    type TableLayout =
        static member Value (layout: FssTypes.ITableLayout) = layout |> tableLayoutValue'
        static member Fixed = FssTypes.Table.Layout.Fixed |> tableLayoutValue'
        static member Auto = FssTypes.Auto |> tableLayoutValue'
        static member Inherit = FssTypes.Inherit |> tableLayoutValue'
        static member Initial = FssTypes.Initial |> tableLayoutValue'
        static member Unset = FssTypes.Unset |> tableLayoutValue'

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
