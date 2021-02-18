namespace Fss

[<RequireQualifiedAccess>]
module MixBlendModeTypes =
    type MixBlendMode =
        | Multiply
        | Screen
        | Overlay
        | Darken
        | Lighten
        | ColorDodge
        | ColorBurn
        | HardLight
        | SoftLight
        | Difference
        | Exclusion
        | Hue
        | Saturation
        | Color
        | Luminosity
        interface IMixBlendMode

[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: IMixBlendMode) =
        match blendMode with
        | :? MixBlendModeTypes.MixBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mix blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    let private mixBlendModeCssValue value = PropertyValue.cssValue Property.MixBlendMode value
    let private mixBlendModeCssValue' value =
        value
        |> blendModeToString
        |> mixBlendModeCssValue

    type MixBlendMode =
        static member Value(mixBlendMode: IMixBlendMode) = mixBlendMode |> mixBlendModeCssValue'

        static member Multiply = MixBlendModeTypes.Multiply |> mixBlendModeCssValue'
        static member Screen = MixBlendModeTypes.Screen |> mixBlendModeCssValue'
        static member Overlay = MixBlendModeTypes.Overlay |> mixBlendModeCssValue'
        static member Darken = MixBlendModeTypes.Darken |> mixBlendModeCssValue'
        static member Lighten = MixBlendModeTypes.Lighten |> mixBlendModeCssValue'
        static member ColorDodge = MixBlendModeTypes.ColorDodge |> mixBlendModeCssValue'
        static member ColorBurn = MixBlendModeTypes.ColorBurn |> mixBlendModeCssValue'
        static member HardLight = MixBlendModeTypes.HardLight |> mixBlendModeCssValue'
        static member SoftLight = MixBlendModeTypes.SoftLight |> mixBlendModeCssValue'
        static member Difference = MixBlendModeTypes.Difference |> mixBlendModeCssValue'
        static member Exclusion = MixBlendModeTypes.Exclusion |> mixBlendModeCssValue'
        static member Hue = MixBlendModeTypes.Hue |> mixBlendModeCssValue'
        static member Saturation = MixBlendModeTypes.Saturation |> mixBlendModeCssValue'
        static member Color = MixBlendModeTypes.Color |> mixBlendModeCssValue'
        static member Luminosity = MixBlendModeTypes.Luminosity |> mixBlendModeCssValue'

        static member Normal = Normal |> mixBlendModeCssValue'
        static member Inherit = Inherit |> mixBlendModeCssValue'
        static member Initial = Initial |> mixBlendModeCssValue'
        static member Unset = Unset |> mixBlendModeCssValue'

    /// <summary>Specifies how an elements content should blend with its parent.</summary>
    /// <param name="mixBlendMode">
    ///     can be:
    ///     - <c> MixBlendMode </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MixBlendMode' (mixBlendMode: IMixBlendMode) = mixBlendMode |> MixBlendMode.Value
