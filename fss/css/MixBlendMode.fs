namespace Fss

open Fable.Core

[<AutoOpen>]
module MixBlendMode =
    let private blendModeToString (blendMode: FssTypes.IMixBlendMode) =
        match blendMode with
        | :? FssTypes.MixBlendMode.MixBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mix blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mix-blend-mode
    let private mixBlendModeCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MixBlendMode
    let private mixBlendModeCssValue' = blendModeToString >> mixBlendModeCssValue

    [<Erase>]
    type MixBlendMode =
        static member value(mixBlendMode: FssTypes.IMixBlendMode) = mixBlendMode |> mixBlendModeCssValue'

        static member multiply = FssTypes.MixBlendMode.Multiply |> mixBlendModeCssValue'
        static member screen = FssTypes.MixBlendMode.Screen |> mixBlendModeCssValue'
        static member overlay = FssTypes.MixBlendMode.Overlay |> mixBlendModeCssValue'
        static member darken = FssTypes.MixBlendMode.Darken |> mixBlendModeCssValue'
        static member lighten = FssTypes.MixBlendMode.Lighten |> mixBlendModeCssValue'
        static member colorDodge = FssTypes.MixBlendMode.ColorDodge |> mixBlendModeCssValue'
        static member colorBurn = FssTypes.MixBlendMode.ColorBurn |> mixBlendModeCssValue'
        static member hardLight = FssTypes.MixBlendMode.HardLight |> mixBlendModeCssValue'
        static member softLight = FssTypes.MixBlendMode.SoftLight |> mixBlendModeCssValue'
        static member difference = FssTypes.MixBlendMode.Difference |> mixBlendModeCssValue'
        static member exclusion = FssTypes.MixBlendMode.Exclusion |> mixBlendModeCssValue'
        static member hue = FssTypes.MixBlendMode.Hue |> mixBlendModeCssValue'
        static member saturation = FssTypes.MixBlendMode.Saturation |> mixBlendModeCssValue'
        static member color = FssTypes.MixBlendMode.Color |> mixBlendModeCssValue'
        static member luminosity = FssTypes.MixBlendMode.Luminosity |> mixBlendModeCssValue'

        static member normal = FssTypes.Normal |> mixBlendModeCssValue'
        static member inherit' = FssTypes.Inherit |> mixBlendModeCssValue'
        static member initial = FssTypes.Initial |> mixBlendModeCssValue'
        static member unset = FssTypes.Unset |> mixBlendModeCssValue'

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
    let MixBlendMode' = MixBlendMode.value
