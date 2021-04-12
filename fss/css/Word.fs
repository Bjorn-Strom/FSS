namespace Fss

open Fable.Core

module Word =
    let private spacingToString (spacing: FssTypes.IWordSpacing) =
        match spacing with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
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
    let private spacingCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.WordSpacing
    let private spacingCssValue' = spacingToString >> spacingCssValue

    [<Erase>]
    type WordSpacing =
        static member value (spacing: FssTypes.IWordSpacing) = spacing |> spacingCssValue'

        static member normal = FssTypes.Normal |> spacingCssValue'
        static member initial = FssTypes.Initial |> spacingCssValue'
        static member inherit' = FssTypes.Inherit |> spacingCssValue'
        static member unset = FssTypes.Unset |> spacingCssValue'

    /// <summary>Specifies length of space between words.</summary>
    /// <param name="spacing">
    ///     can be:
    ///     - <c> Length </c>
    ///     - <c> Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let WordSpacing' = WordSpacing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.WordBreak
    let private breakCssValue' = breakToString >> breakCssValue

    [<Erase>]
    type WordBreak =
        static member value (spacing: FssTypes.IWordBreak) = spacing |> breakCssValue'
        static member wordBreak = FssTypes.WordBreak.WordBreak |> breakCssValue'
        static member breakAll = FssTypes.WordBreak.BreakAll |> breakCssValue'
        static member keepAll = FssTypes.WordBreak.KeepAll |> breakCssValue'

        static member normal = FssTypes.Normal |> breakCssValue'
        static member initial = FssTypes.Initial |> breakCssValue'
        static member inherit' = FssTypes.Inherit |> breakCssValue'
        static member unset = FssTypes.Unset |> breakCssValue'

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
    let WordBreak' = WordBreak.value

