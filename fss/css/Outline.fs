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
    /// Resets outline.
    type Outline =
        static member value (outline: FssTypes.IOutline) = outline |> outlineValue'

        static member none = FssTypes.None' |> outlineValue'
        static member inherit' = FssTypes.Inherit |> outlineValue'
        static member initial = FssTypes.Initial |> outlineValue'
        static member unset = FssTypes.Unset |> outlineValue'

    /// Resets outline.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let Outline' = Outline.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    let private colorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineColor
    let private colorValue' = outlineColorToString >> colorValue

    /// Sets color of outline.
    let OutlineColor = FssTypes.OutlineColorClass(colorValue')

    /// Sets color of outline.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Color
    let OutlineColor' = OutlineColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    let private outlineWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineWidth
    let private outlineWidthValue' = outlineWidthToString >> outlineWidthValue

    [<Erase>]
    /// Sets width of outline.
    type OutlineWidth =
        static member value (width: FssTypes.IOutlineWidth) = width |> outlineWidthValue'
        static member thin = FssTypes.Outline.Width.Thin |> outlineWidthValue'
        static member medium = FssTypes.Outline.Width.Medium |> outlineWidthValue'
        static member thick = FssTypes.Outline.Width.Thick |> outlineWidthValue'

        static member inherit' = FssTypes.Inherit |> outlineWidthValue'
        static member initial = FssTypes.Initial |> outlineWidthValue'
        static member unset = FssTypes.Unset |> outlineWidthValue'

    /// Sets width of outline.
    /// Valid parameters:
    /// - OutlineWidth
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Units.Size
    let OutlineWidth' = OutlineWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    let private outlineStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineStyle
    let private outlineStyleValue' = outlineStyleToString >> outlineStyleValue

    [<Erase>]
    /// Sets style of outline.
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

    /// Sets style of outline.
    /// Valid parameters:
    /// - OutlineStyle
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let OutlineStyle' = OutlineStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
    let private outlineOffsetValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OutlineOffset
    let private outlineOffsetValue' = outlineOffsetToString >> outlineOffsetValue

    [<Erase>]
    /// Sets offset of outline.
    type OutlineOffset =
        static member value (offset: FssTypes.IOutlineOffset) = offset |> outlineOffsetValue'
        static member inherit' = FssTypes.Inherit |> outlineOffsetValue'
        static member initial = FssTypes.Initial |> outlineOffsetValue'
        static member unset = FssTypes.Unset |> outlineOffsetValue'

    /// Sets offset of outline.
    /// Valid parameters:
    /// - OutlineOffset
    /// - Inherit
    /// - Initial
    /// - Unset
    let OutlineOffset' = OutlineOffset.value