namespace Fss

open FssTypes
[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: IMixBlendMode) =
        match blendMode with
        | :? MixBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown mix blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    let private mixBlendModeCssValue value = PropertyValue.cssValue Property.MixBlendMode value
    let private mixBlendModeCssValue' value =
        value
        |> blendModeToString
        |> mixBlendModeCssValue

    type MixBlendMode =
        static member Value(mixBlendMode: IMixBlendMode) = mixBlendMode |> mixBlendModeCssValue'

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
