namespace Fss
open FssTypes

module Word =
    let private spacingToString (spacing: IWordSpacing) =
        match spacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown word spacing"

    let private breakToString (break': IWordBreak) =
        match break' with
        | :? Word.WordBreak as w -> Utilities.Helpers.duToKebab w
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown word break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-spacing
    let private spacingCssValue value = PropertyValue.cssValue Property.WordSpacing value
    let private spacingCssValue' value =
        value
        |> spacingToString
        |> spacingCssValue

    type WordSpacing =
        static member Value (spacing: IWordSpacing) = spacing |> spacingCssValue'

        static member Normal = Normal |> spacingCssValue'
        static member Initial = Initial |> spacingCssValue'
        static member Inherit = Inherit |> spacingCssValue'
        static member Unset = Unset |> spacingCssValue'

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
    let WordSpacing' (spacing: IWordSpacing) = WordSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue value = PropertyValue.cssValue Property.WordBreak value
    let private breakCssValue' value =
        value
        |> breakToString
        |> breakCssValue

    type WordBreak =
        static member Value (spacing: IWordBreak) = spacing |> breakCssValue'
        static member WordBreak = Word.WordBreak |> breakCssValue'
        static member BreakAll = Word.BreakAll |> breakCssValue'
        static member KeepAll = Word.KeepAll |> breakCssValue'

        static member Normal = Normal |> breakCssValue'
        static member Initial = Initial |> breakCssValue'
        static member Inherit = Inherit |> breakCssValue'
        static member Unset = Unset |> breakCssValue'

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
    let WordBreak' (break': IWordBreak) = WordBreak.Value(break')

