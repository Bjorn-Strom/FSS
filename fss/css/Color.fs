namespace Fss

open Fable.Core

[<AutoOpen>]
module Color =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/color-adjust
    let private colorAdjustCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColorAdjust
    let private colorAdjustCssValue' = Utilities.Helpers.duToLowercase >> colorAdjustCssValue
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

    let ColorAdjust' = ColorAdjust.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/color
    let private colorCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Color
    let private colorCssValue' = colorToString >> colorCssValue

    let Color = FssTypes.Color.ColorClass(colorCssValue')

    /// <summary>Sets the color of text and text decoration. </summary>
    /// <param name="color">The FssTypes.ColorTypeto apply</param>
    /// <returns>Css property for fss.</returns>
    let Color' (color: FssTypes.Color.ColorType) = Color.value(color)

