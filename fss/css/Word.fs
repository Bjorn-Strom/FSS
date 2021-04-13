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
    /// Specifies length of space between words.
    type WordSpacing =
        static member value (spacing: FssTypes.IWordSpacing) = spacing |> spacingCssValue'

        static member normal = FssTypes.Normal |> spacingCssValue'
        static member initial = FssTypes.Initial |> spacingCssValue'
        static member inherit' = FssTypes.Inherit |> spacingCssValue'
        static member unset = FssTypes.Unset |> spacingCssValue'

    /// Specifies length of space between words.
    /// Valid parameters:
    /// - Length
    /// - Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let WordSpacing' = WordSpacing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.WordBreak
    let private breakCssValue' = breakToString >> breakCssValue

    [<Erase>]
    /// Specify when line breaks should happen.
    type WordBreak =
        static member value (spacing: FssTypes.IWordBreak) = spacing |> breakCssValue'
        static member wordBreak = FssTypes.WordBreak.WordBreak |> breakCssValue'
        static member breakAll = FssTypes.WordBreak.BreakAll |> breakCssValue'
        static member keepAll = FssTypes.WordBreak.KeepAll |> breakCssValue'

        static member normal = FssTypes.Normal |> breakCssValue'
        static member initial = FssTypes.Initial |> breakCssValue'
        static member inherit' = FssTypes.Inherit |> breakCssValue'
        static member unset = FssTypes.Unset |> breakCssValue'

    /// Specify when line breaks should happen.
    /// Valid parameters:
    /// - WordBreak
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let WordBreak' = WordBreak.value

