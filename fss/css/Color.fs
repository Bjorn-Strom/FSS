namespace Fss

open Fable.Core

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColorAdjust value
    let private colorAdjustCssValue' (value: FssTypes.Color.ColorAdjust) =
        value
        |> Utilities.Helpers.duToLowercase
        |> colorAdjustCssValue
    let private colorToString (color: FssTypes.IColor) =
        match color with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown color"

    [<Erase>]
    type ColorAdjust =
        static member value (adjust: FssTypes.Color.ColorAdjust) = adjust |> colorAdjustCssValue'
        static member economy = FssTypes.Color.Economy |> colorAdjustCssValue'
        static member exact = FssTypes.Color.Exact |> colorAdjustCssValue'

    let ColorAdjust' (adjust: FssTypes.Color.ColorAdjust) = adjust |> ColorAdjust.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue value =
        value
        |> FssTypes.propertyHelpers.cssValue FssTypes.Property.Color
    let private colorCssValue' value =
        value
        |> colorToString
        |> colorCssValue

    let Color = FssTypes.Color.ColorClass(colorCssValue')

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The FssTypes.ColorTypeto apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: FssTypes.Color.ColorType) = Color.value(color)

