namespace Fss

module Word =
    let private spacingToString (spacing: IWordSpacing) =
        match spacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown word spacing"

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


