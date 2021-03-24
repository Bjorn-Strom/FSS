namespace Fss

[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: FssTypes.IMixBlendMode) =
        match blendMode with
        | :? FssTypes.MixBlendMode.MixBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mix blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    let private mixBlendModeCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MixBlendMode value
    let private mixBlendModeCssValue' value =
        value
        |> blendModeToString
        |> mixBlendModeCssValue

    type MixBlendMode =
        static member Value(mixBlendMode: FssTypes.IMixBlendMode) = mixBlendMode |> mixBlendModeCssValue'

        static member Multiply = FssTypes.MixBlendMode.Multiply |> mixBlendModeCssValue'
        static member Screen = FssTypes.MixBlendMode.Screen |> mixBlendModeCssValue'
        static member Overlay = FssTypes.MixBlendMode.Overlay |> mixBlendModeCssValue'
        static member Darken = FssTypes.MixBlendMode.Darken |> mixBlendModeCssValue'
        static member Lighten = FssTypes.MixBlendMode.Lighten |> mixBlendModeCssValue'
        static member ColorDodge = FssTypes.MixBlendMode.ColorDodge |> mixBlendModeCssValue'
        static member ColorBurn = FssTypes.MixBlendMode.ColorBurn |> mixBlendModeCssValue'
        static member HardLight = FssTypes.MixBlendMode.HardLight |> mixBlendModeCssValue'
        static member SoftLight = FssTypes.MixBlendMode.SoftLight |> mixBlendModeCssValue'
        static member Difference = FssTypes.MixBlendMode.Difference |> mixBlendModeCssValue'
        static member Exclusion = FssTypes.MixBlendMode.Exclusion |> mixBlendModeCssValue'
        static member Hue = FssTypes.MixBlendMode.Hue |> mixBlendModeCssValue'
        static member Saturation = FssTypes.MixBlendMode.Saturation |> mixBlendModeCssValue'
        static member Color = FssTypes.MixBlendMode.Color |> mixBlendModeCssValue'
        static member Luminosity = FssTypes.MixBlendMode.Luminosity |> mixBlendModeCssValue'

        static member Normal = FssTypes.Normal |> mixBlendModeCssValue'
        static member Inherit = FssTypes.Inherit |> mixBlendModeCssValue'
        static member Initial = FssTypes.Initial |> mixBlendModeCssValue'
        static member Unset = FssTypes.Unset |> mixBlendModeCssValue'

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
    let MixBlendMode' (mixBlendMode: FssTypes.IMixBlendMode) = mixBlendMode |> MixBlendMode.Value
