namespace Fss

open Fable.Core

[<AutoOpen>]
module Outline  =

    let private outlineToString (color: FssTypes.IOutline) =
        match color with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown outline"

    let private outlineColorToString (color: FssTypes.IOutlineColor) =
        match color with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown outline color"

    let private outlineWidthToString (width: FssTypes.IOutlineWidth) =
        match width with
            | :? FssTypes.Outline.Width as c -> Utilities.Helpers.duToLowercase c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
            | _ -> "Unknown outline width"

    let private outlineStyleToString (style: FssTypes.IOutlineStyle) =
        match style with
            | :? FssTypes.Outline.Style as c -> Utilities.Helpers.duToLowercase c
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
            | _ -> "Unknown outline style"

    let private outlineOffsetToString (style: FssTypes.IOutlineOffset) =
        match style with
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
            | _ -> "Unknown outline offset"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    let private outlineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Outline
    let private outlineValue' = outlineToString >> outlineValue

    [<Erase>]
    type Outline =
        static member value (outline: FssTypes.IOutline) = outline |> outlineValue'

        static member none = FssTypes.None' |> outlineValue'
        static member inherit' = FssTypes.Inherit |> outlineValue'
        static member initial = FssTypes.Initial |> outlineValue'
        static member unset = FssTypes.Unset |> outlineValue'

    /// <summary>Resets outline.</summary>
    /// <param name="outline">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Outline' = Outline.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    let private colorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineColor
    let private colorValue' = outlineColorToString >> colorValue

    let OutlineColor = FssTypes.OutlineColorClass(colorValue')
    /// <summary>Sets color of outline.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineColor' = OutlineColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineWidth
    let private outlineWidthValue' = outlineWidthToString >> outlineWidthValue

    [<Erase>]
    type OutlineWidth =
        static member value (width: FssTypes.IOutlineWidth) = width |> outlineWidthValue'
        static member thin = FssTypes.Outline.Width.Thin |> outlineWidthValue'
        static member medium = FssTypes.Outline.Width.Medium |> outlineWidthValue'
        static member thick = FssTypes.Outline.Width.Thick |> outlineWidthValue'

        static member inherit' = FssTypes.Inherit |> outlineWidthValue'
        static member initial = FssTypes.Initial |> outlineWidthValue'
        static member unset = FssTypes.Unset |> outlineWidthValue'


    /// <summary>Sets width of outline.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> OutlineWidth </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineWidth' = OutlineWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    let private outlineStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineStyle
    let private outlineStyleValue' = outlineStyleToString >> outlineStyleValue

    [<Erase>]
    type OutlineStyle =
        static member value (style: FssTypes.IOutlineStyle) = style |> outlineStyleValue'
        static member hidden = FssTypes.Outline.Style.Hidden |> outlineStyleValue'
        static member dotted = FssTypes.Outline.Style.Dotted |> outlineStyleValue'
        static member dashed = FssTypes.Outline.Style.Dashed |> outlineStyleValue'
        static member solid = FssTypes.Outline.Style.Solid |> outlineStyleValue'
        static member double = FssTypes.Outline.Style.Double |> outlineStyleValue'
        static member groove = FssTypes.Outline.Style.Groove |> outlineStyleValue'
        static member ridge = FssTypes.Outline.Style.Ridge |> outlineStyleValue'
        static member inset = FssTypes.Outline.Style.Inset |> outlineStyleValue'
        static member outset = FssTypes.Outline.Style.Outset |> outlineStyleValue'

        static member none = FssTypes.None' |> outlineStyleValue'
        static member inherit' = FssTypes.Inherit |> outlineStyleValue'
        static member initial = FssTypes.Initial |> outlineStyleValue'
        static member unset = FssTypes.Unset |> outlineStyleValue'

    /// <summary>Sets style of outline.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> OutlineStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineStyle' = OutlineStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
    let private outlineOffsetValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineOffset
    let private outlineOffsetValue' = outlineOffsetToString >> outlineOffsetValue

    [<Erase>]
    type OutlineOffset =
        static member value (offset: FssTypes.IOutlineOffset) = offset |> outlineOffsetValue'
        static member inherit' = FssTypes.Inherit |> outlineOffsetValue'
        static member initial = FssTypes.Initial |> outlineOffsetValue'
        static member unset = FssTypes.Unset |> outlineOffsetValue'

    /// <summary>Sets offset of outline.</summary>
    /// <param name="offset">
    ///     can be:
    ///     - <c> OutlineOffset </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OutlineOffset' = OutlineOffset.value