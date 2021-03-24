namespace Fss

module Word =
    let private spacingToString (spacing: FssTypes.IWordSpacing) =
        match spacing with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown word spacing"

    let private breakToString (break': FssTypes.IWordBreak) =
        match break' with
        | :? FssTypes.WordBreak.WordBreak as w -> Utilities.Helpers.duToKebab w
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown word break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-spacing
    let private spacingCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.WordSpacing value
    let private spacingCssValue' value =
        value
        |> spacingToString
        |> spacingCssValue

    type WordSpacing =
        static member Value (spacing: FssTypes.IWordSpacing) = spacing |> spacingCssValue'

        static member Normal = FssTypes.Normal |> spacingCssValue'
        static member Initial = FssTypes.Initial |> spacingCssValue'
        static member Inherit = FssTypes.Inherit |> spacingCssValue'
        static member Unset = FssTypes.Unset |> spacingCssValue'

    /// <summary>Specifies length of space between words.</summary>
    /// <param name="spacing">
    ///     can be:
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WordSpacing' (spacing: FssTypes.IWordSpacing) = WordSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.WordBreak value
    let private breakCssValue' value =
        value
        |> breakToString
        |> breakCssValue

    type WordBreak =
        static member Value (spacing: FssTypes.IWordBreak) = spacing |> breakCssValue'
        static member WordBreak = FssTypes.WordBreak.WordBreak |> breakCssValue'
        static member BreakAll = FssTypes.WordBreak.BreakAll |> breakCssValue'
        static member KeepAll = FssTypes.WordBreak.KeepAll |> breakCssValue'

        static member Normal = FssTypes.Normal |> breakCssValue'
        static member Initial = FssTypes.Initial |> breakCssValue'
        static member Inherit = FssTypes.Inherit |> breakCssValue'
        static member Unset = FssTypes.Unset |> breakCssValue'

    /// <summary>Specify when line breaks should happen.</summary>
    /// <param name="break'">
    ///     can be:
    ///     - <c> WordBreak </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WordBreak' (break': FssTypes.IWordBreak) = WordBreak.Value(break')

