namespace Fss

open Fable.Core

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
    let private captionSideValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.CaptionSide
    let private captionSideValue' = captionSideToString >> captionSideValue

    [<Erase>]
    type CaptionSide =
        static member value (captionSide: FssTypes.ICaptionSide) = captionSide |> captionSideValue'
        static member top = FssTypes.Table.CaptionSide.Top |> captionSideValue'
        static member bottom = FssTypes.Table.CaptionSide.Bottom |> captionSideValue'
        static member left = FssTypes.Table.CaptionSide.Left |> captionSideValue'
        static member right = FssTypes.Table.CaptionSide.Right |> captionSideValue'
        static member topOutside = FssTypes.Table.CaptionSide.TopOutside |> captionSideValue'
        static member bottomOutside = FssTypes.Table.CaptionSide.BottomOutside |> captionSideValue'
        static member inherit' = FssTypes.Inherit |> captionSideValue'
        static member initial = FssTypes.Initial |> captionSideValue'
        static member unset = FssTypes.Unset |> captionSideValue'

    /// <summary>Specifies which side the caption of a table will be.</summary>
    /// <param name="captionSide">
    ///     can be:
    ///     - <c> CaptionSide </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let CaptionSide' = CaptionSide.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
    let private emptyCellsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.EmptyCells
    let private emptyCellsValue' = emptyCellsToString >> emptyCellsValue
    [<Erase>]
    type EmptyCells =
        static member value (emptyCells: FssTypes.IEmptyCells) = emptyCells |> emptyCellsValue'
        static member show = FssTypes.Table.EmptyCells.Show |> emptyCellsValue'
        static member hide = FssTypes.Table.EmptyCells.Hide |> emptyCellsValue'
        static member inherit' = FssTypes.Inherit |> emptyCellsValue'
        static member initial = FssTypes.Initial |> emptyCellsValue'
        static member unset = FssTypes.Unset |> emptyCellsValue'

    /// <summary>Specifies whether or not emtpy cells should have borders.</summary>
    /// <param name="emptyCells">
    ///     can be:
    ///     - <c> EmptyCells </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let EmptyCells' = EmptyCells.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    let private tableLayoutValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.TableLayout
    let private tableLayoutValue' = tableLayoutToString >> tableLayoutValue

    [<Erase>]
    type TableLayout =
        static member value (layout: FssTypes.ITableLayout) = layout |> tableLayoutValue'
        static member fixed' = FssTypes.Table.Layout.Fixed |> tableLayoutValue'
        static member auto = FssTypes.Auto |> tableLayoutValue'
        static member inherit' = FssTypes.Inherit |> tableLayoutValue'
        static member initial = FssTypes.Initial |> tableLayoutValue'
        static member unset = FssTypes.Unset |> tableLayoutValue'

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
    let TableLayout' = TableLayout.value
