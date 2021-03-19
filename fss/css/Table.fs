namespace Fss

[<RequireQualifiedAccess>]
module TableType =
    type CaptionSide =
        | Top
        | Bottom
        | Left
        | Right
        | TopOutside
        | BottomOutside
        interface ICaptionSide

    type EmptyCells =
        | Show
        | Hide
        interface IEmptyCells

    type TableLayout =
        | Fixed
        interface ITableLayout

[<AutoOpen>]
module Table =
    let private captionSideToString (captionSide: ICaptionSide) =
        match captionSide with
        | :? TableType.CaptionSide as c -> Utilities.Helpers.duToKebab c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown caption side"

    let private emptyCellsToString (emptyCells: IEmptyCells) =
        match emptyCells with
        | :? TableType.EmptyCells as e -> Utilities.Helpers.duToLowercase e
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown empty cells"

    let private tableLayoutToString (tableLayout: ITableLayout) =
        match tableLayout with
        | :? TableType.TableLayout as t -> Utilities.Helpers.duToLowercase t
        | :? Auto -> GlobalValue.auto
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown table layout"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    let private captionSideValue value = PropertyValue.cssValue Property.CaptionSide value
    let private captionSideValue' value =
        value
        |> captionSideToString
        |> captionSideValue

    type CaptionSide =
        static member Value (captionSide: ICaptionSide) = captionSide |> captionSideValue'
        static member Top = TableType.Top |> captionSideValue'
        static member Bottom = TableType.Bottom |> captionSideValue'
        static member Left = TableType.Left |> captionSideValue'
        static member Right = TableType.Right |> captionSideValue'
        static member TopOutside = TableType.TopOutside |> captionSideValue'
        static member BottomOutside = TableType.BottomOutside |> captionSideValue'
        static member Inherit = Inherit |> captionSideValue'
        static member Initial = Initial |> captionSideValue'
        static member Unset = Unset |> captionSideValue'

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
    let private emptyCellsValue value = PropertyValue.cssValue Property.EmptyCells value
    let private emptyCellsValue' value =
        value
        |> emptyCellsToString
        |> emptyCellsValue
    type EmptyCells =
        static member Value (emptyCells: IEmptyCells) = emptyCells |> emptyCellsValue'
        static member Show = TableType.Show |> emptyCellsValue'
        static member Hide = TableType.Hide |> emptyCellsValue'
        static member Inherit = Inherit |> emptyCellsValue'
        static member Initial = Initial |> emptyCellsValue'
        static member Unset = Unset |> emptyCellsValue'

    /// <summary>Specifies whether or not emtpy cells should have borders.</summary>
    /// <param name="emptyCells">
    ///     can be:
    ///     - <c> EmptyCells </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let EmptyCells' (emptyCells: IEmptyCells) = emptyCells |> EmptyCells.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    let private tableLayoutValue value = PropertyValue.cssValue Property.TableLayout value
    let private tableLayoutValue' value =
        value
        |> tableLayoutToString
        |> tableLayoutValue

    type TableLayout =
        static member Value (layout: ITableLayout) = layout |> tableLayoutValue'
        static member Fixed = TableType.Fixed |> tableLayoutValue'
        static member Auto = Auto |> tableLayoutValue'
        static member Inherit = Inherit |> tableLayoutValue'
        static member Initial = Initial |> tableLayoutValue'
        static member Unset = Unset |> tableLayoutValue'

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
