namespace Fss

open FssTypes
[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: IMixBlendMode) =
        match blendMode with
        | :? MixBlendMode.MixBlendMode as b -> Utilities.Helpers.duToKebab b
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

        static member Multiply = MixBlendMode.Multiply |> mixBlendModeCssValue'
        static member Screen = MixBlendMode.Screen |> mixBlendModeCssValue'
        static member Overlay = MixBlendMode.Overlay |> mixBlendModeCssValue'
        static member Darken = MixBlendMode.Darken |> mixBlendModeCssValue'
        static member Lighten = MixBlendMode.Lighten |> mixBlendModeCssValue'
        static member ColorDodge = MixBlendMode.ColorDodge |> mixBlendModeCssValue'
        static member ColorBurn = MixBlendMode.ColorBurn |> mixBlendModeCssValue'
        static member HardLight = MixBlendMode.HardLight |> mixBlendModeCssValue'
        static member SoftLight = MixBlendMode.SoftLight |> mixBlendModeCssValue'
        static member Difference = MixBlendMode.Difference |> mixBlendModeCssValue'
        static member Exclusion = MixBlendMode.Exclusion |> mixBlendModeCssValue'
        static member Hue = MixBlendMode.Hue |> mixBlendModeCssValue'
        static member Saturation = MixBlendMode.Saturation |> mixBlendModeCssValue'
        static member Color = MixBlendMode.Color |> mixBlendModeCssValue'
        static member Luminosity = MixBlendMode.Luminosity |> mixBlendModeCssValue'

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
