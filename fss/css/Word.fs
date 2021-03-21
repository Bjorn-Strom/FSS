namespace Fss

module Word =
    let private spacingToString (spacing: Types.IWordSpacing) =
        match spacing with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown word spacing"

    let private breakToString (break': Types.IWordBreak) =
        match break' with
        | :? Types.WordBreak as w -> Utilities.Helpers.duToKebab w
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown word break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-spacing
    let private spacingCssValue value = Types.propertyHelpers.cssValue Types.Property.WordSpacing value
    let private spacingCssValue' value =
        value
        |> spacingToString
        |> spacingCssValue

    type WordSpacing =
        static member Value (spacing: Types.IWordSpacing) = spacing |> spacingCssValue'

        static member Normal = Types.Normal |> spacingCssValue'
        static member Initial = Types.Initial |> spacingCssValue'
        static member Inherit = Types.Inherit |> spacingCssValue'
        static member Unset = Types.Unset |> spacingCssValue'

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
    let WordSpacing' (spacing: Types.IWordSpacing) = WordSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue value = Types.propertyHelpers.cssValue Types.Property.WordBreak value
    let private breakCssValue' value =
        value
        |> breakToString
        |> breakCssValue

    type WordBreak =
        static member Value (spacing: Types.IWordBreak) = spacing |> breakCssValue'
        static member WordBreak = Types.WordBreak |> breakCssValue'
        static member BreakAll = Types.BreakAll |> breakCssValue'
        static member KeepAll = Types.KeepAll |> breakCssValue'

        static member Normal = Types.Normal |> breakCssValue'
        static member Initial = Types.Initial |> breakCssValue'
        static member Inherit = Types.Inherit |> breakCssValue'
        static member Unset = Types.Unset |> breakCssValue'

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
    let WordBreak' (break': Types.IWordBreak) = WordBreak.Value(break')

