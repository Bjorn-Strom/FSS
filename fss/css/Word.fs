namespace Fss

module WordTypes =
    type WordBreak =
        | WordBreak
        | BreakAll
        | KeepAll
        interface IWordBreak

module Word =
    open WordTypes

    let private spacingToString (spacing: IWordSpacing) =
        match spacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown word spacing"

    let private breakToString (break': IWordBreak) =
        let stringifyBreak =
            function
                | WordBreak -> "word-break"
                | BreakAll -> "break-all"
                | KeepAll -> "keep-all"

        match break' with
        | :? WordTypes.WordBreak as w -> stringifyBreak w
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

    let WordSpacing' (spacing: IWordSpacing) = WordSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    let private breakCssValue value = PropertyValue.cssValue Property.WordBreak value
    let private breakCssValue' value =
        value
        |> breakToString
        |> breakCssValue

    type WordBreak =
        static member Value (spacing: IWordBreak) = spacing |> breakCssValue'
        static member WordBreak = WordTypes.WordBreak |> breakCssValue'
        static member BreakAll = BreakAll |> breakCssValue'
        static member KeepAll = KeepAll |> breakCssValue'

        static member Normal = Normal |> breakCssValue'
        static member Initial = Initial |> breakCssValue'
        static member Inherit = Inherit |> breakCssValue'
        static member Unset = Unset |> breakCssValue'

    let WordBreak' (break': IWordBreak) = WordBreak.Value(break')

