namespace Fss

[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: Types.IMixBlendMode) =
        match blendMode with
        | :? Types.MixBlendMode.MixBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mix blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    let private mixBlendModeCssValue value = Types.propertyHelpers.cssValue Types.Property.MixBlendMode value
    let private mixBlendModeCssValue' value =
        value
        |> blendModeToString
        |> mixBlendModeCssValue

    type MixBlendMode =
        static member Value(mixBlendMode: Types.IMixBlendMode) = mixBlendMode |> mixBlendModeCssValue'

        static member Multiply = Types.MixBlendMode.Multiply |> mixBlendModeCssValue'
        static member Screen = Types.MixBlendMode.Screen |> mixBlendModeCssValue'
        static member Overlay = Types.MixBlendMode.Overlay |> mixBlendModeCssValue'
        static member Darken = Types.MixBlendMode.Darken |> mixBlendModeCssValue'
        static member Lighten = Types.MixBlendMode.Lighten |> mixBlendModeCssValue'
        static member ColorDodge = Types.MixBlendMode.ColorDodge |> mixBlendModeCssValue'
        static member ColorBurn = Types.MixBlendMode.ColorBurn |> mixBlendModeCssValue'
        static member HardLight = Types.MixBlendMode.HardLight |> mixBlendModeCssValue'
        static member SoftLight = Types.MixBlendMode.SoftLight |> mixBlendModeCssValue'
        static member Difference = Types.MixBlendMode.Difference |> mixBlendModeCssValue'
        static member Exclusion = Types.MixBlendMode.Exclusion |> mixBlendModeCssValue'
        static member Hue = Types.MixBlendMode.Hue |> mixBlendModeCssValue'
        static member Saturation = Types.MixBlendMode.Saturation |> mixBlendModeCssValue'
        static member Color = Types.MixBlendMode.Color' |> mixBlendModeCssValue'
        static member Luminosity = Types.MixBlendMode.Luminosity |> mixBlendModeCssValue'

        static member Normal = Types.Normal |> mixBlendModeCssValue'
        static member Inherit = Types.Inherit |> mixBlendModeCssValue'
        static member Initial = Types.Initial |> mixBlendModeCssValue'
        static member Unset = Types.Unset |> mixBlendModeCssValue'

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
    let MixBlendMode' (mixBlendMode: Types.IMixBlendMode) = mixBlendMode |> MixBlendMode.Value
