namespace Fss

open Fss.CssColor
open FssTypes

[<AutoOpen>]
module Border =

    let private radiusToString (radius: IBorderRadius) =
        match radius with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border radius"

    let private widthToString (width: IBorderWidth) =
        match width with
            | :? Border.BorderWidth as b -> Utilities.Helpers.duToLowercase b
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Global as g -> GlobalValue.global' g
            | _ -> "unknown border width"

    let private styleToString (style: IBorderStyle) =
        match style with
        | :? Border.BorderStyle as b -> Utilities.Helpers.duToLowercase b
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border style"

    let private collapseToString (collapse: IBorderCollapse) =
        match collapse with
        | :? Border.BorderCollapse as c -> Utilities.Helpers.duToLowercase c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border collapse"
    let private imageOutsetToString (imageOutset: IBorderImageOutset) =
        let stringifyOutset (Border.BorderImageOutset v) = string v

        match imageOutset with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Border.BorderImageOutset as i -> stringifyOutset i
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border image outset"

    let private repeatToString (repeat: IBorderRepeat) =
        match repeat with
        | :? Border.BorderImageRepeat as b -> Utilities.Helpers.duToLowercase b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border repeat"

    let private imageSliceToString (imageSlice: IBorderImageSlice) =
        let stringifySlice =
            function
                | Border.BorderImageSlice.Value i -> string i
                | Border.BorderImageSlice.Fill -> "fill"

        match imageSlice with
        | :? Border.BorderImageSlice as i -> stringifySlice i
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border image slice"

    let private borderColorToString (borderColor: IBorderColor) =
        match borderColor with
        | :? CssColor as c -> CssColorValue.color c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border color"

    let private spacingToString (spacing: IBorderSpacing) =
        match spacing with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border spacing"

    let private imageWidthToString (imageWidth: IBorderImageWidth) =
        match imageWidth with
        | :? CssFloat as f -> GlobalValue.float f
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown border image width"

    let private imageSourceToString (imageSource: IBorderImageSource) =
        match imageSource with
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border image source"

    let private borderToString (border: IBorder) =
            match border with
            | :? Global as g -> GlobalValue.global' g
            | :? None' -> GlobalValue.none
            | _ -> "Unknown border"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    let private borderValue value = PropertyValue.cssValue Property.Border value
    let private borderValue' value =
        value
        |> borderToString
        |> borderValue

    type Border =
        static member Value (border: IBorder) = border |> borderValue'
        static member None = None' |> borderValue'
        static member Inherit = Inherit |> borderValue'
        static member Initial = Initial |> borderValue'
        static member Unset = Unset |> borderValue'

    /// <summary>Resets border.</summary>
    /// <param name="border">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Border' border = border |> Border.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius
    let private radiusValue value = PropertyValue.cssValue Property.BorderRadius value
    let private radiusValue' value =
        value
        |> radiusToString
        |> radiusValue
    type BorderRadius =
        static member Value (radius: IBorderRadius) =
            sprintf "%s"
                (radiusToString radius)
                |> radiusValue
        static member Value (topLeftBottomRight: IBorderRadius, topRightBottomLeft: IBorderRadius) =
            sprintf "%s %s"
                (radiusToString topLeftBottomRight)
                (radiusToString topRightBottomLeft)
                |> radiusValue
        static member Value (topLeft: IBorderRadius, topRightBottomLeft: IBorderRadius, bottomRight: IBorderRadius) =
            sprintf "%s %s %s"
                (radiusToString topLeft)
                (radiusToString topRightBottomLeft)
                (radiusToString bottomRight)
                |> radiusValue
        static member Value (topLeft: IBorderRadius, topRight: IBorderRadius, bottomRight: IBorderRadius, bottomLeft: IBorderRadius) =
            sprintf "%s %s %s %s"
                (radiusToString topLeft)
                (radiusToString topRight)
                (radiusToString bottomRight)
                (radiusToString bottomLeft)
                |> radiusValue

        static member Inherit = Inherit |> radiusValue'
        static member Initial = Initial |> radiusValue'
        static member Unset = Unset |> radiusValue'

    /// <summary>Specifies roundness of border edge.</summary>
    /// <param name="radius">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRadius' (radius: IBorderRadius) = BorderRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-left-radius
    let private bottomLeftRadiusValue value = PropertyValue.cssValue Property.BorderBottomLeftRadius value
    let private bottomLeftRadiusValue' value =
        value
        |> radiusToString
        |> bottomLeftRadiusValue
    type BorderBottomLeftRadius =
        static member Value (horizontal: IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomLeftRadiusValue
        static member Value (horizontal: IBorderRadius, vertical: IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomLeftRadiusValue
        static member Inherit = Inherit |> bottomLeftRadiusValue'
        static member Initial = Initial |> bottomLeftRadiusValue'
        static member Unset = Unset |> bottomLeftRadiusValue'

    /// <summary>Specifies roundness of bottom left corner.</summary>
    /// <param name="radius">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomLeftRadius' (radius: IBorderRadius) = BorderBottomLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-right-radius
    let private bottomRightRadiusValue value = PropertyValue.cssValue Property.BorderBottomRightRadius value
    let private bottomRightRadiusValue' value =
        value
        |> radiusToString
        |> bottomRightRadiusValue
    type BorderBottomRightRadius =
        static member Value (horizontal: IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomRightRadiusValue
        static member Value (horizontal: IBorderRadius, vertical: IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomRightRadiusValue
        static member Inherit = Inherit |> bottomRightRadiusValue'
        static member Initial = Initial |> bottomRightRadiusValue'
        static member Unset = Unset |> bottomRightRadiusValue'

    /// <summary>Specifies roundness of bottom right corner.</summary>
    /// <param name="radius">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomRightRadius' (radius: IBorderRadius) = BorderBottomRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-left-radius
    let private topLeftRadiusValue value = PropertyValue.cssValue Property.BorderTopLeftRadius value
    let private topLeftRadiusValue' value =
        value
        |> radiusToString
        |> topLeftRadiusValue
    type BorderTopLeftRadius =
        static member Value (horizontal: IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topLeftRadiusValue
        static member Value (horizontal: IBorderRadius, vertical: IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topLeftRadiusValue
        static member Inherit = Inherit |> topLeftRadiusValue'
        static member Initial = Initial |> topLeftRadiusValue'
        static member Unset = Unset |> topLeftRadiusValue'

    /// <summary>Specifies roundness of top left corner.</summary>
    /// <param name="radius">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopLeftRadius' (radius: IBorderRadius) = BorderTopLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-right-radius
    let private topRightRadiusValue value = PropertyValue.cssValue Property.BorderTopRightRadius value
    let private topRightRadiusValue' value =
        value
        |> radiusToString
        |> topRightRadiusValue
    type BorderTopRightRadius =
        static member Value (horizontal: IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topRightRadiusValue
        static member Value (horizontal: IBorderRadius, vertical: IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topRightRadiusValue
        static member Inherit = Inherit |> topRightRadiusValue'
        static member Initial = Initial |> topRightRadiusValue'
        static member Unset = Unset |> topRightRadiusValue'

    /// <summary>Specifies roundness of top right corner.</summary>
    /// <param name="radius">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopRightRadius' (radius: IBorderRadius) = BorderTopRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    let private widthValue value = PropertyValue.cssValue Property.BorderWidth value
    let private widthValue' value =
        value
        |> widthToString
        |> widthValue

    type BorderWidth =
        static member Value (width: IBorderWidth) = widthValue (widthToString width)
        static member Value (vertical: IBorderWidth, horizontal: IBorderWidth) =
            sprintf "%s %s"
                (widthToString vertical)
                (widthToString horizontal)
            |> widthValue
        static member Value (top: IBorderWidth, horizontal: IBorderWidth, bottom: IBorderWidth) =
            sprintf "%s %s %s"
                (widthToString top)
                (widthToString horizontal)
                (widthToString bottom)
            |> widthValue
        static member Value (top: IBorderWidth, right: IBorderWidth, bottom: IBorderWidth, left: IBorderWidth) =
            sprintf "%s %s %s %s"
                (widthToString top)
                (widthToString right)
                (widthToString bottom)
                (widthToString left)
            |> widthValue

        static member Thin = Border.Thin |> widthValue'
        static member Medium = Border.Medium |> widthValue'
        static member Thick = Border.Thick |> widthValue'

        static member Inherit = Inherit |> widthValue'
        static member Initial = Initial |> widthValue'
        static member Unset = Unset |> widthValue'

    /// <summary>Specifies width of border.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> BorderWidth </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderWidth' (width: IBorderWidth) = BorderWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let private topWidthValue value = PropertyValue.cssValue Property.BorderTopWidth value
    let private topWidthValue' value =
        value
        |> widthToString
        |> topWidthValue
    type BorderTopWidth =
        static member Value (width: IBorderWidth) = width |> topWidthValue'
        static member Thin = Border.Thin |> topWidthValue
        static member Medium = Border.Medium |> topWidthValue
        static member Thick = Border.Thick |> topWidthValue

        static member Inherit = Inherit |> topWidthValue
        static member Initial = Initial |> topWidthValue
        static member Unset = Unset |> topWidthValue

    /// <summary>Specifies width of top border.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> BorderWidth </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopWidth' (width: IBorderWidth) = BorderTopWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue value = PropertyValue.cssValue Property.BorderRightWidth value
    let private rightWidthValue' value =
        value
        |> widthToString
        |> rightWidthValue
    type BorderRightWidth =
        static member Value (width: IBorderWidth) = width |> rightWidthValue'
        static member Thin = Border.Thin |> rightWidthValue
        static member Medium = Border.Medium |> rightWidthValue
        static member Thick = Border.Thick |> rightWidthValue

        static member Inherit = Inherit |> rightWidthValue
        static member Initial = Initial |> rightWidthValue
        static member Unset = Unset |> rightWidthValue

    /// <summary>Specifies width of right border.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> BorderWidth </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightWidth' (width: IBorderWidth) = BorderRightWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue value = PropertyValue.cssValue Property.BorderBottomWidth value
    let private bottomWidthValue' value =
        value
        |> widthToString
        |> bottomWidthValue
    type BorderBottomWidth =
        static member Value (width: IBorderWidth) = width |> bottomWidthValue'
        static member Thin = Border.Thin |> bottomWidthValue
        static member Medium = Border.Medium |> bottomWidthValue
        static member Thick = Border.Thick |> bottomWidthValue

        static member Inherit = Inherit |> bottomWidthValue
        static member Initial = Initial |> bottomWidthValue
        static member Unset = Unset |> bottomWidthValue

    /// <summary>Specifies width of bottom border.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> BorderWidth </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomWidth' (width: IBorderWidth) = BorderBottomWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue value = PropertyValue.cssValue Property.BorderLeftWidth value
    let private leftWidthValue' value =
        value
        |> widthToString
        |> leftWidthValue
    type BorderLeftWidth =
        static member Value (width: IBorderWidth) = width |> leftWidthValue'
        static member Thin = Border.Thin |> leftWidthValue
        static member Medium = Border.Medium |> leftWidthValue
        static member Thick = Border.Thick |> leftWidthValue

        static member Inherit = Inherit |> leftWidthValue
        static member Initial = Initial |> leftWidthValue
        static member Unset = Unset |> leftWidthValue

    /// <summary>Specifies width of left border.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> BorderWidth </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftWidth' (width: IBorderWidth) = BorderLeftWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    let private styleValue value = PropertyValue.cssValue Property.BorderStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue

    type BorderStyle =
        static member Value (style: IBorderStyle) = style |> styleValue'
        static member Value (vertical: IBorderStyle, horizontal: IBorderStyle) =
            sprintf "%s %s"
                (styleToString vertical)
                (styleToString horizontal)
            |> styleValue
        static member Value (top: IBorderStyle, horizontal: IBorderStyle, bottom: IBorderStyle) =
            sprintf "%s %s %s"
                (styleToString top)
                (styleToString horizontal)
                (styleToString bottom)
            |> styleValue
        static member Value (top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle, left: IBorderStyle) =
            sprintf "%s %s %s %s"
                (styleToString top)
                (styleToString right)
                (styleToString bottom)
                (styleToString left)
            |> styleValue

        static member Hidden = Border.Hidden |> styleValue'
        static member Dotted = Border.Dotted |> styleValue'
        static member Dashed = Border.Dashed |> styleValue'
        static member Solid = Border.Solid |> styleValue'
        static member Double = Border.Double |> styleValue'
        static member Groove = Border.Groove |> styleValue'
        static member Ridge = Border.Ridge |> styleValue'
        static member Inset = Border.Inset |> styleValue'
        static member Outset = Border.Outset |> styleValue'

        static member None = None' |> styleValue'
        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    /// <summary>Specifies style of border.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> BorderStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderStyle' (style: IBorderStyle) = BorderStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue value = PropertyValue.cssValue Property.BorderTopStyle value
    let private topStyleValue' value =
        value
        |> styleToString
        |> topStyleValue

    type BorderTopStyle =
        static member Value (style: IBorderStyle) = style |> topStyleValue'
        static member Hidden = Border.Hidden |> topStyleValue'
        static member Dotted = Border.Dotted |> topStyleValue'
        static member Dashed = Border.Dashed |> topStyleValue'
        static member Solid = Border.Solid |> topStyleValue'
        static member Double = Border.Double |> topStyleValue'
        static member Groove = Border.Groove |> topStyleValue'
        static member Ridge = Border.Ridge |> topStyleValue'
        static member Inset = Border.Inset |> topStyleValue'
        static member Outset = Border.Outset |> topStyleValue'

        static member None = None' |> topStyleValue'
        static member Inherit = Inherit |> topStyleValue'
        static member Initial = Initial |> topStyleValue'
        static member Unset = Unset |> topStyleValue'

    /// <summary>Specifies style of top border.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> BorderStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopStyle' (style: IBorderStyle) = BorderTopStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue value = PropertyValue.cssValue Property.BorderRightStyle value
    let private rightStyleValue' value =
        value
        |> styleToString
        |> rightStyleValue

    type BorderRightStyle =
        static member Value (style: IBorderStyle) = style |> rightStyleValue'
        static member Hidden = Border.Hidden |> rightStyleValue'
        static member Dotted = Border.Dotted |> rightStyleValue'
        static member Dashed = Border.Dashed |> rightStyleValue'
        static member Solid = Border.Solid |> rightStyleValue'
        static member Double = Border.Double |> rightStyleValue'
        static member Groove = Border.Groove |> rightStyleValue'
        static member Ridge = Border.Ridge |> rightStyleValue'
        static member Inset = Border.Inset |> rightStyleValue'
        static member Outset = Border.Outset |> rightStyleValue'

        static member None = None' |> rightStyleValue'
        static member Inherit = Inherit |> rightStyleValue'
        static member Initial = Initial |> rightStyleValue'
        static member Unset = Unset |> rightStyleValue'

    /// <summary>Specifies style of right border.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> BorderStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightStyle' (style: IBorderStyle) = BorderRightStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue value = PropertyValue.cssValue Property.BorderBottomStyle value
    let private bottomStyleValue' value =
        value
        |> styleToString
        |> bottomStyleValue

    type BorderBottomStyle =
        static member Value (style: IBorderStyle) = style |> bottomStyleValue'
        static member Hidden = Border.Hidden |> bottomStyleValue'
        static member Dotted = Border.Dotted |> bottomStyleValue'
        static member Dashed = Border.Dashed |> bottomStyleValue'
        static member Solid = Border.Solid |> bottomStyleValue'
        static member Double = Border.Double |> bottomStyleValue'
        static member Groove = Border.Groove |> bottomStyleValue'
        static member Ridge = Border.Ridge |> bottomStyleValue'
        static member Inset = Border.Inset |> bottomStyleValue'
        static member Outset = Border.Outset |> bottomStyleValue'

        static member None = None' |> bottomStyleValue'
        static member Inherit = Inherit |> bottomStyleValue'
        static member Initial = Initial |> bottomStyleValue'
        static member Unset = Unset |> bottomStyleValue'

    /// <summary>Specifies style of bottom border.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> BorderStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomStyle' (style: IBorderStyle) = BorderBottomStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue value = PropertyValue.cssValue Property.BorderLeftStyle value
    let private leftStyleValue' value =
        value
        |> styleToString
        |> leftStyleValue

    type BorderLeftStyle =
        static member Value (style: IBorderStyle) = style |> leftStyleValue'
        static member Hidden = Border.Hidden |> leftStyleValue'
        static member Dotted = Border.Dotted |> leftStyleValue'
        static member Dashed = Border.Dashed |> leftStyleValue'
        static member Solid = Border.Solid |> leftStyleValue'
        static member Double = Border.Double |> leftStyleValue'
        static member Groove = Border.Groove |> leftStyleValue'
        static member Ridge = Border.Ridge |> leftStyleValue'
        static member Inset = Border.Inset |> leftStyleValue'
        static member Outset = Border.Outset |> leftStyleValue'

        static member None = None' |> leftStyleValue'
        static member Inherit = Inherit |> leftStyleValue'
        static member Initial = Initial |> leftStyleValue'
        static member Unset = Unset |> leftStyleValue'

    /// <summary>Specifies style of left border.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> BorderStyle </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftStyle' (style: IBorderStyle) = BorderLeftStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue value = PropertyValue.cssValue Property.BorderCollapse value
    let private collapseValue' value =
        value
        |> collapseToString
        |> collapseValue

    type BorderCollapse =
        static member Value (collapse: IBorderCollapse) = collapse |> collapseValue'
        static member Collapse = Border.Collapse |> collapseValue'
        static member Separate = Border.Separate |> collapseValue'

        static member Inherit = Inherit |> collapseValue'
        static member Initial = Initial |> collapseValue'
        static member Unset = Unset |> collapseValue'

    /// <summary>Specifies whether cells inside a table have shared borders.</summary>
    /// <param name="collapse">
    ///     can be:
    ///     - <c> BorderCollapse </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderCollapse' (collapse: IBorderCollapse) =  BorderCollapse.Value(collapse)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    let private imageOutsetValue value = PropertyValue.cssValue Property.BorderImageOutset value
    let private imageOutsetValue' value =
        value
        |> imageOutsetToString
        |> imageOutsetValue

    type BorderImageOutset =
        static member Value (outset: IBorderImageOutset) = outset |> imageOutsetValue'
        static member Value (vertical: IBorderImageOutset, horizontal: IBorderImageOutset) =
            sprintf "%s %s" (imageOutsetToString vertical) (imageOutsetToString horizontal) |> imageOutsetValue
        static member Value (top: IBorderImageOutset, horizontal: IBorderImageOutset, bottom: IBorderImageOutset) =
            sprintf "%s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString horizontal)
                (imageOutsetToString bottom)
            |> imageOutsetValue
        static member Value (top: IBorderImageOutset, right: IBorderImageOutset, bottom: IBorderImageOutset, left: IBorderImageOutset) =
            sprintf "%s %s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString right)
                (imageOutsetToString bottom)
                (imageOutsetToString left)
            |> imageOutsetValue

        static member Inherit = Inherit |> imageOutsetValue'
        static member Initial = Initial |> imageOutsetValue'
        static member Unset = Unset |> imageOutsetValue'

    /// <summary>Specifies distance between elements border and border box.</summary>
    /// <param name="outset">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> BorderImageOutset </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageOutset' (outset: IBorderImageOutset) =  BorderImageOutset.Value(outset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    let private imageRepeatValue value = PropertyValue.cssValue Property.BorderImageRepeat value
    let private imageRepeatValue' value =
        value
        |> repeatToString
        |> imageRepeatValue
    type BorderImageRepeat =
        static member Value (repeat: IBorderRepeat) = repeat |> imageRepeatValue'
        static member Value (vertical: IBorderRepeat, horizontal: IBorderRepeat) =
            sprintf "%s %s" (repeatToString vertical) (repeatToString horizontal)
            |> imageRepeatValue
        static member Stretch = Border.Stretch |> imageRepeatValue'
        static member Repeat = Border.Repeat |> imageRepeatValue'
        static member Round = Border.Round |> imageRepeatValue'
        static member Space = Border.Space |> imageRepeatValue'

        static member Inherit = Inherit |> imageRepeatValue'
        static member Initial = Initial |> imageRepeatValue'
        static member Unset = Unset |> imageRepeatValue'

    /// <summary>Specifies how border image surrounds border box.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BorderImageRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageRepeat' (repeat: IBorderRepeat) = BorderImageRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue value = PropertyValue.cssValue Property.BorderImageSlice value
    let private imageSliceValue' value =
        value
        |> imageSliceToString
        |> imageSliceValue

    type BorderImageSlice =
        static member Fill = Border.Fill |> imageSliceValue'
        static member Value (imageSlice: IBorderImageSlice) = imageSlice |> imageSliceValue'
        static member Value (vertical: IBorderImageSlice, horizontal: IBorderImageSlice) =
            sprintf "%s %s" (imageSliceToString vertical) (imageSliceToString horizontal) |> imageSliceValue
        static member Value (w1: IBorderImageSlice, w2: IBorderImageSlice, w3: IBorderImageSlice) =
            sprintf "%s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
            |> imageSliceValue
        static member Value (w1: IBorderImageSlice, w2: IBorderImageSlice, w3: IBorderImageSlice, w4: IBorderImageSlice) =
            sprintf "%s %s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
                (imageSliceToString w4)
            |> imageSliceValue

        static member Inherit = Inherit |> imageSliceValue'
        static member Initial = Initial |> imageSliceValue'
        static member Unset = Unset |> imageSliceValue'

    /// <summary>Specifies how border image is divided into regions.</summary>
    /// <param name="slice">
    ///     can be:
    ///     - <c> BorderImageSlice </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageSlice' (slice: IBorderImageSlice) = BorderImageSlice.Value(slice)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    let private borderColorValue value = PropertyValue.cssValue Property.BorderColor value
    let private borderColorValue' value =
        value
        |> borderColorToString
        |> borderColorValue

    type BorderColor =
        static member Value (color: IBorderColor) = color |> borderColorValue'
        static member Value (horizontal: IBorderColor, vertical: IBorderColor) =
            sprintf "%s %s"
                (borderColorToString horizontal)
                (borderColorToString vertical)
            |> borderColorValue
        static member Value (top: IBorderColor, vertical: IBorderColor, bottom: IBorderColor) =
            sprintf "%s %s %s"
                (borderColorToString top)
                (borderColorToString vertical)
                (borderColorToString bottom)
            |> borderColorValue
        static member Value (top: IBorderColor, right: IBorderColor, bottom: IBorderColor, left: IBorderColor) =
            sprintf "%s %s %s %s"
                (borderColorToString top)
                (borderColorToString right)
                (borderColorToString bottom)
                (borderColorToString left)
            |> borderColorValue
        static member black = CssColor.black |> borderColorValue'
        static member silver = CssColor.silver |> borderColorValue'
        static member gray = CssColor.gray |> borderColorValue'
        static member white = CssColor.white |> borderColorValue'
        static member maroon = CssColor.maroon |> borderColorValue'
        static member red = CssColor.red |> borderColorValue'
        static member purple = CssColor.purple |> borderColorValue'
        static member fuchsia = CssColor.fuchsia |> borderColorValue'
        static member green = CssColor.green |> borderColorValue'
        static member lime = CssColor.lime |> borderColorValue'
        static member olive = CssColor.olive |> borderColorValue'
        static member yellow = CssColor.yellow |> borderColorValue'
        static member navy = CssColor.navy |> borderColorValue'
        static member blue = CssColor.blue |> borderColorValue'
        static member teal = CssColor.teal |> borderColorValue'
        static member aqua = CssColor.aqua |> borderColorValue'
        static member orange = CssColor.orange |> borderColorValue'
        static member aliceBlue = CssColor.aliceBlue |> borderColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> borderColorValue'
        static member aquaMarine = CssColor.aquaMarine |> borderColorValue'
        static member azure = CssColor.azure |> borderColorValue'
        static member beige = CssColor.beige |> borderColorValue'
        static member bisque = CssColor.bisque |> borderColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> borderColorValue'
        static member blueViolet = CssColor.blueViolet |> borderColorValue'
        static member brown = CssColor.brown |> borderColorValue'
        static member burlywood = CssColor.burlywood |> borderColorValue'
        static member cadetBlue = CssColor.cadetBlue |> borderColorValue'
        static member chartreuse = CssColor.chartreuse |> borderColorValue'
        static member chocolate = CssColor.chocolate |> borderColorValue'
        static member coral = CssColor.coral |> borderColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> borderColorValue'
        static member cornsilk = CssColor.cornsilk |> borderColorValue'
        static member crimson = CssColor.crimson |> borderColorValue'
        static member cyan = CssColor.cyan |> borderColorValue'
        static member darkBlue = CssColor.darkBlue |> borderColorValue'
        static member darkCyan = CssColor.darkCyan |> borderColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> borderColorValue'
        static member darkGray = CssColor.darkGray |> borderColorValue'
        static member darkGreen = CssColor.darkGreen |> borderColorValue'
        static member darkKhaki = CssColor.darkKhaki |> borderColorValue'
        static member darkMagenta = CssColor.darkMagenta |> borderColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> borderColorValue'
        static member darkOrange = CssColor.darkOrange |> borderColorValue'
        static member darkOrchid = CssColor.darkOrchid |> borderColorValue'
        static member darkRed = CssColor.darkRed |> borderColorValue'
        static member darkSalmon = CssColor.darkSalmon |> borderColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> borderColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> borderColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> borderColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> borderColorValue'
        static member darkViolet = CssColor.darkViolet |> borderColorValue'
        static member deepPink = CssColor.deepPink |> borderColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> borderColorValue'
        static member dimGrey = CssColor.dimGrey |> borderColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> borderColorValue'
        static member fireBrick = CssColor.fireBrick |> borderColorValue'
        static member floralWhite = CssColor.floralWhite |> borderColorValue'
        static member forestGreen = CssColor.forestGreen |> borderColorValue'
        static member gainsboro = CssColor.gainsboro |> borderColorValue'
        static member ghostWhite = CssColor.ghostWhite |> borderColorValue'
        static member gold = CssColor.gold |> borderColorValue'
        static member goldenrod = CssColor.goldenrod |> borderColorValue'
        static member greenYellow = CssColor.greenYellow |> borderColorValue'
        static member grey = CssColor.grey |> borderColorValue'
        static member honeydew = CssColor.honeydew |> borderColorValue'
        static member hotPink = CssColor.hotPink |> borderColorValue'
        static member indianRed = CssColor.indianRed |> borderColorValue'
        static member indigo = CssColor.indigo |> borderColorValue'
        static member ivory = CssColor.ivory |> borderColorValue'
        static member khaki = CssColor.khaki |> borderColorValue'
        static member lavender = CssColor.lavender |> borderColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> borderColorValue'
        static member lawnGreen = CssColor.lawnGreen |> borderColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> borderColorValue'
        static member lightBlue = CssColor.lightBlue |> borderColorValue'
        static member lightCoral = CssColor.lightCoral |> borderColorValue'
        static member lightCyan = CssColor.lightCyan |> borderColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> borderColorValue'
        static member lightGray = CssColor.lightGray |> borderColorValue'
        static member lightGreen = CssColor.lightGreen |> borderColorValue'
        static member lightGrey = CssColor.lightGrey |> borderColorValue'
        static member lightPink = CssColor.lightPink |> borderColorValue'
        static member lightSalmon = CssColor.lightSalmon |> borderColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> borderColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> borderColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> borderColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> borderColorValue'
        static member lightYellow = CssColor.lightYellow |> borderColorValue'
        static member limeGreen = CssColor.limeGreen |> borderColorValue'
        static member linen = CssColor.linen |> borderColorValue'
        static member magenta = CssColor.magenta |> borderColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> borderColorValue'
        static member mediumBlue = CssColor.mediumBlue |> borderColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> borderColorValue'
        static member mediumPurple = CssColor.mediumPurple |> borderColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> borderColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> borderColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> borderColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> borderColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> borderColorValue'
        static member midnightBlue = CssColor.midnightBlue |> borderColorValue'
        static member mintCream = CssColor.mintCream |> borderColorValue'
        static member mistyRose = CssColor.mistyRose |> borderColorValue'
        static member moccasin = CssColor.moccasin |> borderColorValue'
        static member navajoWhite = CssColor.navajoWhite |> borderColorValue'
        static member oldLace = CssColor.oldLace |> borderColorValue'
        static member olivedrab = CssColor.olivedrab |> borderColorValue'
        static member orangeRed = CssColor.orangeRed |> borderColorValue'
        static member orchid = CssColor.orchid |> borderColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> borderColorValue'
        static member paleGreen = CssColor.paleGreen |> borderColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> borderColorValue'
        static member paleVioletred = CssColor.paleVioletred |> borderColorValue'
        static member papayaWhip = CssColor.papayaWhip |> borderColorValue'
        static member peachpuff = CssColor.peachpuff |> borderColorValue'
        static member peru = CssColor.peru |> borderColorValue'
        static member pink = CssColor.pink |> borderColorValue'
        static member plum = CssColor.plum |> borderColorValue'
        static member powderBlue = CssColor.powderBlue |> borderColorValue'
        static member rosyBrown = CssColor.rosyBrown |> borderColorValue'
        static member royalBlue = CssColor.royalBlue |> borderColorValue'
        static member saddleBrown = CssColor.saddleBrown |> borderColorValue'
        static member salmon = CssColor.salmon |> borderColorValue'
        static member sandyBrown = CssColor.sandyBrown |> borderColorValue'
        static member seaGreen = CssColor.seaGreen |> borderColorValue'
        static member seaShell = CssColor.seaShell |> borderColorValue'
        static member sienna = CssColor.sienna |> borderColorValue'
        static member skyBlue = CssColor.skyBlue |> borderColorValue'
        static member slateBlue = CssColor.slateBlue |> borderColorValue'
        static member slateGray = CssColor.slateGray |> borderColorValue'
        static member snow = CssColor.snow |> borderColorValue'
        static member springGreen = CssColor.springGreen |> borderColorValue'
        static member steelBlue = CssColor.steelBlue |> borderColorValue'
        static member tan = CssColor.tan |> borderColorValue'
        static member thistle = CssColor.thistle |> borderColorValue'
        static member tomato = CssColor.tomato |> borderColorValue'
        static member turquoise = CssColor.turquoise |> borderColorValue'
        static member violet = CssColor.violet |> borderColorValue'
        static member wheat = CssColor.wheat |> borderColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> borderColorValue'
        static member yellowGreen = CssColor.yellowGreen |> borderColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> borderColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> borderColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> borderColorValue'
        static member Hex value = CssColor.Hex value |> borderColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> borderColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> borderColorValue'
        static member transparent = CssColor.transparent |> borderColorValue'
        static member currentColor = CssColor.currentColor |> borderColorValue'

        static member Inherit = Inherit |> borderColorValue'
        static member Initial = Initial |> borderColorValue'
        static member Unset = Unset |> borderColorValue'

    /// <summary>Specifies color of border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderColor' (color: IBorderColor) = BorderColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue value = PropertyValue.cssValue Property.BorderTopColor value
    let private topColorValue' value =
        value
        |> borderColorToString
        |> topColorValue
    type BorderTopColor =
        static member Value (color: IBorderColor) = color |> topColorValue'
        static member black = CssColor.black |> topColorValue'
        static member silver = CssColor.silver |> topColorValue'
        static member gray = CssColor.gray |> topColorValue'
        static member white = CssColor.white |> topColorValue'
        static member maroon = CssColor.maroon |> topColorValue'
        static member red = CssColor.red |> topColorValue'
        static member purple = CssColor.purple |> topColorValue'
        static member fuchsia = CssColor.fuchsia |> topColorValue'
        static member green = CssColor.green |> topColorValue'
        static member lime = CssColor.lime |> topColorValue'
        static member olive = CssColor.olive |> topColorValue'
        static member yellow = CssColor.yellow |> topColorValue'
        static member navy = CssColor.navy |> topColorValue'
        static member blue = CssColor.blue |> topColorValue'
        static member teal = CssColor.teal |> topColorValue'
        static member aqua = CssColor.aqua |> topColorValue'
        static member orange = CssColor.orange |> topColorValue'
        static member aliceBlue = CssColor.aliceBlue |> topColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> topColorValue'
        static member aquaMarine = CssColor.aquaMarine |> topColorValue'
        static member azure = CssColor.azure |> topColorValue'
        static member beige = CssColor.beige |> topColorValue'
        static member bisque = CssColor.bisque |> topColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> topColorValue'
        static member blueViolet = CssColor.blueViolet |> topColorValue'
        static member brown = CssColor.brown |> topColorValue'
        static member burlywood = CssColor.burlywood |> topColorValue'
        static member cadetBlue = CssColor.cadetBlue |> topColorValue'
        static member chartreuse = CssColor.chartreuse |> topColorValue'
        static member chocolate = CssColor.chocolate |> topColorValue'
        static member coral = CssColor.coral |> topColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> topColorValue'
        static member cornsilk = CssColor.cornsilk |> topColorValue'
        static member crimson = CssColor.crimson |> topColorValue'
        static member cyan = CssColor.cyan |> topColorValue'
        static member darkBlue = CssColor.darkBlue |> topColorValue'
        static member darkCyan = CssColor.darkCyan |> topColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> topColorValue'
        static member darkGray = CssColor.darkGray |> topColorValue'
        static member darkGreen = CssColor.darkGreen |> topColorValue'
        static member darkKhaki = CssColor.darkKhaki |> topColorValue'
        static member darkMagenta = CssColor.darkMagenta |> topColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> topColorValue'
        static member darkOrange = CssColor.darkOrange |> topColorValue'
        static member darkOrchid = CssColor.darkOrchid |> topColorValue'
        static member darkRed = CssColor.darkRed |> topColorValue'
        static member darkSalmon = CssColor.darkSalmon |> topColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> topColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> topColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> topColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> topColorValue'
        static member darkViolet = CssColor.darkViolet |> topColorValue'
        static member deepPink = CssColor.deepPink |> topColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> topColorValue'
        static member dimGrey = CssColor.dimGrey |> topColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> topColorValue'
        static member fireBrick = CssColor.fireBrick |> topColorValue'
        static member floralWhite = CssColor.floralWhite |> topColorValue'
        static member forestGreen = CssColor.forestGreen |> topColorValue'
        static member gainsboro = CssColor.gainsboro |> topColorValue'
        static member ghostWhite = CssColor.ghostWhite |> topColorValue'
        static member gold = CssColor.gold |> topColorValue'
        static member goldenrod = CssColor.goldenrod |> topColorValue'
        static member greenYellow = CssColor.greenYellow |> topColorValue'
        static member grey = CssColor.grey |> topColorValue'
        static member honeydew = CssColor.honeydew |> topColorValue'
        static member hotPink = CssColor.hotPink |> topColorValue'
        static member indianRed = CssColor.indianRed |> topColorValue'
        static member indigo = CssColor.indigo |> topColorValue'
        static member ivory = CssColor.ivory |> topColorValue'
        static member khaki = CssColor.khaki |> topColorValue'
        static member lavender = CssColor.lavender |> topColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> topColorValue'
        static member lawnGreen = CssColor.lawnGreen |> topColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> topColorValue'
        static member lightBlue = CssColor.lightBlue |> topColorValue'
        static member lightCoral = CssColor.lightCoral |> topColorValue'
        static member lightCyan = CssColor.lightCyan |> topColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> topColorValue'
        static member lightGray = CssColor.lightGray |> topColorValue'
        static member lightGreen = CssColor.lightGreen |> topColorValue'
        static member lightGrey = CssColor.lightGrey |> topColorValue'
        static member lightPink = CssColor.lightPink |> topColorValue'
        static member lightSalmon = CssColor.lightSalmon |> topColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> topColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> topColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> topColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> topColorValue'
        static member lightYellow = CssColor.lightYellow |> topColorValue'
        static member limeGreen = CssColor.limeGreen |> topColorValue'
        static member linen = CssColor.linen |> topColorValue'
        static member magenta = CssColor.magenta |> topColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> topColorValue'
        static member mediumBlue = CssColor.mediumBlue |> topColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> topColorValue'
        static member mediumPurple = CssColor.mediumPurple |> topColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> topColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> topColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> topColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> topColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> topColorValue'
        static member midnightBlue = CssColor.midnightBlue |> topColorValue'
        static member mintCream = CssColor.mintCream |> topColorValue'
        static member mistyRose = CssColor.mistyRose |> topColorValue'
        static member moccasin = CssColor.moccasin |> topColorValue'
        static member navajoWhite = CssColor.navajoWhite |> topColorValue'
        static member oldLace = CssColor.oldLace |> topColorValue'
        static member olivedrab = CssColor.olivedrab |> topColorValue'
        static member orangeRed = CssColor.orangeRed |> topColorValue'
        static member orchid = CssColor.orchid |> topColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> topColorValue'
        static member paleGreen = CssColor.paleGreen |> topColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> topColorValue'
        static member paleVioletred = CssColor.paleVioletred |> topColorValue'
        static member papayaWhip = CssColor.papayaWhip |> topColorValue'
        static member peachpuff = CssColor.peachpuff |> topColorValue'
        static member peru = CssColor.peru |> topColorValue'
        static member pink = CssColor.pink |> topColorValue'
        static member plum = CssColor.plum |> topColorValue'
        static member powderBlue = CssColor.powderBlue |> topColorValue'
        static member rosyBrown = CssColor.rosyBrown |> topColorValue'
        static member royalBlue = CssColor.royalBlue |> topColorValue'
        static member saddleBrown = CssColor.saddleBrown |> topColorValue'
        static member salmon = CssColor.salmon |> topColorValue'
        static member sandyBrown = CssColor.sandyBrown |> topColorValue'
        static member seaGreen = CssColor.seaGreen |> topColorValue'
        static member seaShell = CssColor.seaShell |> topColorValue'
        static member sienna = CssColor.sienna |> topColorValue'
        static member skyBlue = CssColor.skyBlue |> topColorValue'
        static member slateBlue = CssColor.slateBlue |> topColorValue'
        static member slateGray = CssColor.slateGray |> topColorValue'
        static member snow = CssColor.snow |> topColorValue'
        static member springGreen = CssColor.springGreen |> topColorValue'
        static member steelBlue = CssColor.steelBlue |> topColorValue'
        static member tan = CssColor.tan |> topColorValue'
        static member thistle = CssColor.thistle |> topColorValue'
        static member tomato = CssColor.tomato |> topColorValue'
        static member turquoise = CssColor.turquoise |> topColorValue'
        static member violet = CssColor.violet |> topColorValue'
        static member wheat = CssColor.wheat |> topColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> topColorValue'
        static member yellowGreen = CssColor.yellowGreen |> topColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> topColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> topColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> topColorValue'
        static member Hex value = CssColor.Hex value |> topColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> topColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> topColorValue'
        static member transparent = CssColor.transparent |> topColorValue'
        static member currentColor = CssColor.currentColor |> topColorValue'

        static member Inherit = Inherit |> topColorValue'
        static member Initial = Initial |> topColorValue'
        static member Unset = Unset |> topColorValue'

    /// <summary>Specifies color of top border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopColor' (color: IBorderColor) = BorderTopColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue value = PropertyValue.cssValue Property.BorderRightColor value
    let private rightColorValue' value =
        value
        |> borderColorToString
        |> rightColorValue
    type BorderRightColor =
        static member Value (color: IBorderColor) = color |> rightColorValue'
        static member black = CssColor.black |> rightColorValue'
        static member silver = CssColor.silver |> rightColorValue'
        static member gray = CssColor.gray |> rightColorValue'
        static member white = CssColor.white |> rightColorValue'
        static member maroon = CssColor.maroon |> rightColorValue'
        static member red = CssColor.red |> rightColorValue'
        static member purple = CssColor.purple |> rightColorValue'
        static member fuchsia = CssColor.fuchsia |> rightColorValue'
        static member green = CssColor.green |> rightColorValue'
        static member lime = CssColor.lime |> rightColorValue'
        static member olive = CssColor.olive |> rightColorValue'
        static member yellow = CssColor.yellow |> rightColorValue'
        static member navy = CssColor.navy |> rightColorValue'
        static member blue = CssColor.blue |> rightColorValue'
        static member teal = CssColor.teal |> rightColorValue'
        static member aqua = CssColor.aqua |> rightColorValue'
        static member orange = CssColor.orange |> rightColorValue'
        static member aliceBlue = CssColor.aliceBlue |> rightColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> rightColorValue'
        static member aquaMarine = CssColor.aquaMarine |> rightColorValue'
        static member azure = CssColor.azure |> rightColorValue'
        static member beige = CssColor.beige |> rightColorValue'
        static member bisque = CssColor.bisque |> rightColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> rightColorValue'
        static member blueViolet = CssColor.blueViolet |> rightColorValue'
        static member brown = CssColor.brown |> rightColorValue'
        static member burlywood = CssColor.burlywood |> rightColorValue'
        static member cadetBlue = CssColor.cadetBlue |> rightColorValue'
        static member chartreuse = CssColor.chartreuse |> rightColorValue'
        static member chocolate = CssColor.chocolate |> rightColorValue'
        static member coral = CssColor.coral |> rightColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> rightColorValue'
        static member cornsilk = CssColor.cornsilk |> rightColorValue'
        static member crimson = CssColor.crimson |> rightColorValue'
        static member cyan = CssColor.cyan |> rightColorValue'
        static member darkBlue = CssColor.darkBlue |> rightColorValue'
        static member darkCyan = CssColor.darkCyan |> rightColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> rightColorValue'
        static member darkGray = CssColor.darkGray |> rightColorValue'
        static member darkGreen = CssColor.darkGreen |> rightColorValue'
        static member darkKhaki = CssColor.darkKhaki |> rightColorValue'
        static member darkMagenta = CssColor.darkMagenta |> rightColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> rightColorValue'
        static member darkOrange = CssColor.darkOrange |> rightColorValue'
        static member darkOrchid = CssColor.darkOrchid |> rightColorValue'
        static member darkRed = CssColor.darkRed |> rightColorValue'
        static member darkSalmon = CssColor.darkSalmon |> rightColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> rightColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> rightColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> rightColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> rightColorValue'
        static member darkViolet = CssColor.darkViolet |> rightColorValue'
        static member deepPink = CssColor.deepPink |> rightColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> rightColorValue'
        static member dimGrey = CssColor.dimGrey |> rightColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> rightColorValue'
        static member fireBrick = CssColor.fireBrick |> rightColorValue'
        static member floralWhite = CssColor.floralWhite |> rightColorValue'
        static member forestGreen = CssColor.forestGreen |> rightColorValue'
        static member gainsboro = CssColor.gainsboro |> rightColorValue'
        static member ghostWhite = CssColor.ghostWhite |> rightColorValue'
        static member gold = CssColor.gold |> rightColorValue'
        static member goldenrod = CssColor.goldenrod |> rightColorValue'
        static member greenYellow = CssColor.greenYellow |> rightColorValue'
        static member grey = CssColor.grey |> rightColorValue'
        static member honeydew = CssColor.honeydew |> rightColorValue'
        static member hotPink = CssColor.hotPink |> rightColorValue'
        static member indianRed = CssColor.indianRed |> rightColorValue'
        static member indigo = CssColor.indigo |> rightColorValue'
        static member ivory = CssColor.ivory |> rightColorValue'
        static member khaki = CssColor.khaki |> rightColorValue'
        static member lavender = CssColor.lavender |> rightColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> rightColorValue'
        static member lawnGreen = CssColor.lawnGreen |> rightColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> rightColorValue'
        static member lightBlue = CssColor.lightBlue |> rightColorValue'
        static member lightCoral = CssColor.lightCoral |> rightColorValue'
        static member lightCyan = CssColor.lightCyan |> rightColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> rightColorValue'
        static member lightGray = CssColor.lightGray |> rightColorValue'
        static member lightGreen = CssColor.lightGreen |> rightColorValue'
        static member lightGrey = CssColor.lightGrey |> rightColorValue'
        static member lightPink = CssColor.lightPink |> rightColorValue'
        static member lightSalmon = CssColor.lightSalmon |> rightColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> rightColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> rightColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> rightColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> rightColorValue'
        static member lightYellow = CssColor.lightYellow |> rightColorValue'
        static member limeGreen = CssColor.limeGreen |> rightColorValue'
        static member linen = CssColor.linen |> rightColorValue'
        static member magenta = CssColor.magenta |> rightColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> rightColorValue'
        static member mediumBlue = CssColor.mediumBlue |> rightColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> rightColorValue'
        static member mediumPurple = CssColor.mediumPurple |> rightColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> rightColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> rightColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> rightColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> rightColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> rightColorValue'
        static member midnightBlue = CssColor.midnightBlue |> rightColorValue'
        static member mintCream = CssColor.mintCream |> rightColorValue'
        static member mistyRose = CssColor.mistyRose |> rightColorValue'
        static member moccasin = CssColor.moccasin |> rightColorValue'
        static member navajoWhite = CssColor.navajoWhite |> rightColorValue'
        static member oldLace = CssColor.oldLace |> rightColorValue'
        static member olivedrab = CssColor.olivedrab |> rightColorValue'
        static member orangeRed = CssColor.orangeRed |> rightColorValue'
        static member orchid = CssColor.orchid |> rightColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> rightColorValue'
        static member paleGreen = CssColor.paleGreen |> rightColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> rightColorValue'
        static member paleVioletred = CssColor.paleVioletred |> rightColorValue'
        static member papayaWhip = CssColor.papayaWhip |> rightColorValue'
        static member peachpuff = CssColor.peachpuff |> rightColorValue'
        static member peru = CssColor.peru |> rightColorValue'
        static member pink = CssColor.pink |> rightColorValue'
        static member plum = CssColor.plum |> rightColorValue'
        static member powderBlue = CssColor.powderBlue |> rightColorValue'
        static member rosyBrown = CssColor.rosyBrown |> rightColorValue'
        static member royalBlue = CssColor.royalBlue |> rightColorValue'
        static member saddleBrown = CssColor.saddleBrown |> rightColorValue'
        static member salmon = CssColor.salmon |> rightColorValue'
        static member sandyBrown = CssColor.sandyBrown |> rightColorValue'
        static member seaGreen = CssColor.seaGreen |> rightColorValue'
        static member seaShell = CssColor.seaShell |> rightColorValue'
        static member sienna = CssColor.sienna |> rightColorValue'
        static member skyBlue = CssColor.skyBlue |> rightColorValue'
        static member slateBlue = CssColor.slateBlue |> rightColorValue'
        static member slateGray = CssColor.slateGray |> rightColorValue'
        static member snow = CssColor.snow |> rightColorValue'
        static member springGreen = CssColor.springGreen |> rightColorValue'
        static member steelBlue = CssColor.steelBlue |> rightColorValue'
        static member tan = CssColor.tan |> rightColorValue'
        static member thistle = CssColor.thistle |> rightColorValue'
        static member tomato = CssColor.tomato |> rightColorValue'
        static member turquoise = CssColor.turquoise |> rightColorValue'
        static member violet = CssColor.violet |> rightColorValue'
        static member wheat = CssColor.wheat |> rightColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> rightColorValue'
        static member yellowGreen = CssColor.yellowGreen |> rightColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> rightColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> rightColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> rightColorValue'
        static member Hex value = CssColor.Hex value |> rightColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> rightColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> rightColorValue'
        static member transparent = CssColor.transparent |> rightColorValue'
        static member currentColor = CssColor.currentColor |> rightColorValue'

        static member Inherit = Inherit |> rightColorValue'
        static member Initial = Initial |> rightColorValue'
        static member Unset = Unset |> rightColorValue'

    /// <summary>Specifies color of right border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightColor' (color: IBorderColor) = BorderRightColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue value = PropertyValue.cssValue Property.BorderBottomColor value
    let private bottomColorValue' value =
        value
        |> borderColorToString
        |> bottomColorValue
    type BorderBottomColor =
        static member Value (color: IBorderColor) = color |> bottomColorValue'
        static member black = CssColor.black |> bottomColorValue'
        static member silver = CssColor.silver |> bottomColorValue'
        static member gray = CssColor.gray |> bottomColorValue'
        static member white = CssColor.white |> bottomColorValue'
        static member maroon = CssColor.maroon |> bottomColorValue'
        static member red = CssColor.red |> bottomColorValue'
        static member purple = CssColor.purple |> bottomColorValue'
        static member fuchsia = CssColor.fuchsia |> bottomColorValue'
        static member green = CssColor.green |> bottomColorValue'
        static member lime = CssColor.lime |> bottomColorValue'
        static member olive = CssColor.olive |> bottomColorValue'
        static member yellow = CssColor.yellow |> bottomColorValue'
        static member navy = CssColor.navy |> bottomColorValue'
        static member blue = CssColor.blue |> bottomColorValue'
        static member teal = CssColor.teal |> bottomColorValue'
        static member aqua = CssColor.aqua |> bottomColorValue'
        static member orange = CssColor.orange |> bottomColorValue'
        static member aliceBlue = CssColor.aliceBlue |> bottomColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> bottomColorValue'
        static member aquaMarine = CssColor.aquaMarine |> bottomColorValue'
        static member azure = CssColor.azure |> bottomColorValue'
        static member beige = CssColor.beige |> bottomColorValue'
        static member bisque = CssColor.bisque |> bottomColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> bottomColorValue'
        static member blueViolet = CssColor.blueViolet |> bottomColorValue'
        static member brown = CssColor.brown |> bottomColorValue'
        static member burlywood = CssColor.burlywood |> bottomColorValue'
        static member cadetBlue = CssColor.cadetBlue |> bottomColorValue'
        static member chartreuse = CssColor.chartreuse |> bottomColorValue'
        static member chocolate = CssColor.chocolate |> bottomColorValue'
        static member coral = CssColor.coral |> bottomColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> bottomColorValue'
        static member cornsilk = CssColor.cornsilk |> bottomColorValue'
        static member crimson = CssColor.crimson |> bottomColorValue'
        static member cyan = CssColor.cyan |> bottomColorValue'
        static member darkBlue = CssColor.darkBlue |> bottomColorValue'
        static member darkCyan = CssColor.darkCyan |> bottomColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> bottomColorValue'
        static member darkGray = CssColor.darkGray |> bottomColorValue'
        static member darkGreen = CssColor.darkGreen |> bottomColorValue'
        static member darkKhaki = CssColor.darkKhaki |> bottomColorValue'
        static member darkMagenta = CssColor.darkMagenta |> bottomColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> bottomColorValue'
        static member darkOrange = CssColor.darkOrange |> bottomColorValue'
        static member darkOrchid = CssColor.darkOrchid |> bottomColorValue'
        static member darkRed = CssColor.darkRed |> bottomColorValue'
        static member darkSalmon = CssColor.darkSalmon |> bottomColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> bottomColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> bottomColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> bottomColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> bottomColorValue'
        static member darkViolet = CssColor.darkViolet |> bottomColorValue'
        static member deepPink = CssColor.deepPink |> bottomColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> bottomColorValue'
        static member dimGrey = CssColor.dimGrey |> bottomColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> bottomColorValue'
        static member fireBrick = CssColor.fireBrick |> bottomColorValue'
        static member floralWhite = CssColor.floralWhite |> bottomColorValue'
        static member forestGreen = CssColor.forestGreen |> bottomColorValue'
        static member gainsboro = CssColor.gainsboro |> bottomColorValue'
        static member ghostWhite = CssColor.ghostWhite |> bottomColorValue'
        static member gold = CssColor.gold |> bottomColorValue'
        static member goldenrod = CssColor.goldenrod |> bottomColorValue'
        static member greenYellow = CssColor.greenYellow |> bottomColorValue'
        static member grey = CssColor.grey |> bottomColorValue'
        static member honeydew = CssColor.honeydew |> bottomColorValue'
        static member hotPink = CssColor.hotPink |> bottomColorValue'
        static member indianRed = CssColor.indianRed |> bottomColorValue'
        static member indigo = CssColor.indigo |> bottomColorValue'
        static member ivory = CssColor.ivory |> bottomColorValue'
        static member khaki = CssColor.khaki |> bottomColorValue'
        static member lavender = CssColor.lavender |> bottomColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> bottomColorValue'
        static member lawnGreen = CssColor.lawnGreen |> bottomColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> bottomColorValue'
        static member lightBlue = CssColor.lightBlue |> bottomColorValue'
        static member lightCoral = CssColor.lightCoral |> bottomColorValue'
        static member lightCyan = CssColor.lightCyan |> bottomColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> bottomColorValue'
        static member lightGray = CssColor.lightGray |> bottomColorValue'
        static member lightGreen = CssColor.lightGreen |> bottomColorValue'
        static member lightGrey = CssColor.lightGrey |> bottomColorValue'
        static member lightPink = CssColor.lightPink |> bottomColorValue'
        static member lightSalmon = CssColor.lightSalmon |> bottomColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> bottomColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> bottomColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> bottomColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> bottomColorValue'
        static member lightYellow = CssColor.lightYellow |> bottomColorValue'
        static member limeGreen = CssColor.limeGreen |> bottomColorValue'
        static member linen = CssColor.linen |> bottomColorValue'
        static member magenta = CssColor.magenta |> bottomColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> bottomColorValue'
        static member mediumBlue = CssColor.mediumBlue |> bottomColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> bottomColorValue'
        static member mediumPurple = CssColor.mediumPurple |> bottomColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> bottomColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> bottomColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> bottomColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> bottomColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> bottomColorValue'
        static member midnightBlue = CssColor.midnightBlue |> bottomColorValue'
        static member mintCream = CssColor.mintCream |> bottomColorValue'
        static member mistyRose = CssColor.mistyRose |> bottomColorValue'
        static member moccasin = CssColor.moccasin |> bottomColorValue'
        static member navajoWhite = CssColor.navajoWhite |> bottomColorValue'
        static member oldLace = CssColor.oldLace |> bottomColorValue'
        static member olivedrab = CssColor.olivedrab |> bottomColorValue'
        static member orangeRed = CssColor.orangeRed |> bottomColorValue'
        static member orchid = CssColor.orchid |> bottomColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> bottomColorValue'
        static member paleGreen = CssColor.paleGreen |> bottomColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> bottomColorValue'
        static member paleVioletred = CssColor.paleVioletred |> bottomColorValue'
        static member papayaWhip = CssColor.papayaWhip |> bottomColorValue'
        static member peachpuff = CssColor.peachpuff |> bottomColorValue'
        static member peru = CssColor.peru |> bottomColorValue'
        static member pink = CssColor.pink |> bottomColorValue'
        static member plum = CssColor.plum |> bottomColorValue'
        static member powderBlue = CssColor.powderBlue |> bottomColorValue'
        static member rosyBrown = CssColor.rosyBrown |> bottomColorValue'
        static member royalBlue = CssColor.royalBlue |> bottomColorValue'
        static member saddleBrown = CssColor.saddleBrown |> bottomColorValue'
        static member salmon = CssColor.salmon |> bottomColorValue'
        static member sandyBrown = CssColor.sandyBrown |> bottomColorValue'
        static member seaGreen = CssColor.seaGreen |> bottomColorValue'
        static member seaShell = CssColor.seaShell |> bottomColorValue'
        static member sienna = CssColor.sienna |> bottomColorValue'
        static member skyBlue = CssColor.skyBlue |> bottomColorValue'
        static member slateBlue = CssColor.slateBlue |> bottomColorValue'
        static member slateGray = CssColor.slateGray |> bottomColorValue'
        static member snow = CssColor.snow |> bottomColorValue'
        static member springGreen = CssColor.springGreen |> bottomColorValue'
        static member steelBlue = CssColor.steelBlue |> bottomColorValue'
        static member tan = CssColor.tan |> bottomColorValue'
        static member thistle = CssColor.thistle |> bottomColorValue'
        static member tomato = CssColor.tomato |> bottomColorValue'
        static member turquoise = CssColor.turquoise |> bottomColorValue'
        static member violet = CssColor.violet |> bottomColorValue'
        static member wheat = CssColor.wheat |> bottomColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> bottomColorValue'
        static member yellowGreen = CssColor.yellowGreen |> bottomColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> bottomColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> bottomColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> bottomColorValue'
        static member Hex value = CssColor.Hex value |> bottomColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> bottomColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> bottomColorValue'
        static member transparent = CssColor.transparent |> bottomColorValue'
        static member currentColor = CssColor.currentColor |> bottomColorValue'

        static member Inherit = Inherit |> bottomColorValue'
        static member Initial = Initial |> bottomColorValue'
        static member Unset = Unset |> bottomColorValue'

    /// <summary>Specifies color of bottom border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomColor' (color: IBorderColor) = BorderBottomColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue value = PropertyValue.cssValue Property.BorderLeftColor value
    let private leftColorValue' value =
        value
        |> borderColorToString
        |> leftColorValue
    type BorderLeftColor =
        static member Value (color: IBorderColor) = color |> leftColorValue'
        static member black = CssColor.black |> leftColorValue'
        static member silver = CssColor.silver |> leftColorValue'
        static member gray = CssColor.gray |> leftColorValue'
        static member white = CssColor.white |> leftColorValue'
        static member maroon = CssColor.maroon |> leftColorValue'
        static member red = CssColor.red |> leftColorValue'
        static member purple = CssColor.purple |> leftColorValue'
        static member fuchsia = CssColor.fuchsia |> leftColorValue'
        static member green = CssColor.green |> leftColorValue'
        static member lime = CssColor.lime |> leftColorValue'
        static member olive = CssColor.olive |> leftColorValue'
        static member yellow = CssColor.yellow |> leftColorValue'
        static member navy = CssColor.navy |> leftColorValue'
        static member blue = CssColor.blue |> leftColorValue'
        static member teal = CssColor.teal |> leftColorValue'
        static member aqua = CssColor.aqua |> leftColorValue'
        static member orange = CssColor.orange |> leftColorValue'
        static member aliceBlue = CssColor.aliceBlue |> leftColorValue'
        static member antiqueWhite = CssColor.antiqueWhite |> leftColorValue'
        static member aquaMarine = CssColor.aquaMarine |> leftColorValue'
        static member azure = CssColor.azure |> leftColorValue'
        static member beige = CssColor.beige |> leftColorValue'
        static member bisque = CssColor.bisque |> leftColorValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> leftColorValue'
        static member blueViolet = CssColor.blueViolet |> leftColorValue'
        static member brown = CssColor.brown |> leftColorValue'
        static member burlywood = CssColor.burlywood |> leftColorValue'
        static member cadetBlue = CssColor.cadetBlue |> leftColorValue'
        static member chartreuse = CssColor.chartreuse |> leftColorValue'
        static member chocolate = CssColor.chocolate |> leftColorValue'
        static member coral = CssColor.coral |> leftColorValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> leftColorValue'
        static member cornsilk = CssColor.cornsilk |> leftColorValue'
        static member crimson = CssColor.crimson |> leftColorValue'
        static member cyan = CssColor.cyan |> leftColorValue'
        static member darkBlue = CssColor.darkBlue |> leftColorValue'
        static member darkCyan = CssColor.darkCyan |> leftColorValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> leftColorValue'
        static member darkGray = CssColor.darkGray |> leftColorValue'
        static member darkGreen = CssColor.darkGreen |> leftColorValue'
        static member darkKhaki = CssColor.darkKhaki |> leftColorValue'
        static member darkMagenta = CssColor.darkMagenta |> leftColorValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> leftColorValue'
        static member darkOrange = CssColor.darkOrange |> leftColorValue'
        static member darkOrchid = CssColor.darkOrchid |> leftColorValue'
        static member darkRed = CssColor.darkRed |> leftColorValue'
        static member darkSalmon = CssColor.darkSalmon |> leftColorValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> leftColorValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> leftColorValue'
        static member darkSlateGray = CssColor.darkSlateGray |> leftColorValue'
        static member darkTurquoise = CssColor.darkTurquoise |> leftColorValue'
        static member darkViolet = CssColor.darkViolet |> leftColorValue'
        static member deepPink = CssColor.deepPink |> leftColorValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> leftColorValue'
        static member dimGrey = CssColor.dimGrey |> leftColorValue'
        static member dodgerBlue = CssColor.dodgerBlue |> leftColorValue'
        static member fireBrick = CssColor.fireBrick |> leftColorValue'
        static member floralWhite = CssColor.floralWhite |> leftColorValue'
        static member forestGreen = CssColor.forestGreen |> leftColorValue'
        static member gainsboro = CssColor.gainsboro |> leftColorValue'
        static member ghostWhite = CssColor.ghostWhite |> leftColorValue'
        static member gold = CssColor.gold |> leftColorValue'
        static member goldenrod = CssColor.goldenrod |> leftColorValue'
        static member greenYellow = CssColor.greenYellow |> leftColorValue'
        static member grey = CssColor.grey |> leftColorValue'
        static member honeydew = CssColor.honeydew |> leftColorValue'
        static member hotPink = CssColor.hotPink |> leftColorValue'
        static member indianRed = CssColor.indianRed |> leftColorValue'
        static member indigo = CssColor.indigo |> leftColorValue'
        static member ivory = CssColor.ivory |> leftColorValue'
        static member khaki = CssColor.khaki |> leftColorValue'
        static member lavender = CssColor.lavender |> leftColorValue'
        static member lavenderBlush = CssColor.lavenderBlush |> leftColorValue'
        static member lawnGreen = CssColor.lawnGreen |> leftColorValue'
        static member lemonChiffon = CssColor.lemonChiffon |> leftColorValue'
        static member lightBlue = CssColor.lightBlue |> leftColorValue'
        static member lightCoral = CssColor.lightCoral |> leftColorValue'
        static member lightCyan = CssColor.lightCyan |> leftColorValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> leftColorValue'
        static member lightGray = CssColor.lightGray |> leftColorValue'
        static member lightGreen = CssColor.lightGreen |> leftColorValue'
        static member lightGrey = CssColor.lightGrey |> leftColorValue'
        static member lightPink = CssColor.lightPink |> leftColorValue'
        static member lightSalmon = CssColor.lightSalmon |> leftColorValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> leftColorValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> leftColorValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> leftColorValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> leftColorValue'
        static member lightYellow = CssColor.lightYellow |> leftColorValue'
        static member limeGreen = CssColor.limeGreen |> leftColorValue'
        static member linen = CssColor.linen |> leftColorValue'
        static member magenta = CssColor.magenta |> leftColorValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> leftColorValue'
        static member mediumBlue = CssColor.mediumBlue |> leftColorValue'
        static member mediumOrchid = CssColor.mediumOrchid |> leftColorValue'
        static member mediumPurple = CssColor.mediumPurple |> leftColorValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> leftColorValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> leftColorValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> leftColorValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> leftColorValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> leftColorValue'
        static member midnightBlue = CssColor.midnightBlue |> leftColorValue'
        static member mintCream = CssColor.mintCream |> leftColorValue'
        static member mistyRose = CssColor.mistyRose |> leftColorValue'
        static member moccasin = CssColor.moccasin |> leftColorValue'
        static member navajoWhite = CssColor.navajoWhite |> leftColorValue'
        static member oldLace = CssColor.oldLace |> leftColorValue'
        static member olivedrab = CssColor.olivedrab |> leftColorValue'
        static member orangeRed = CssColor.orangeRed |> leftColorValue'
        static member orchid = CssColor.orchid |> leftColorValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> leftColorValue'
        static member paleGreen = CssColor.paleGreen |> leftColorValue'
        static member paleTurquoise = CssColor.paleTurquoise |> leftColorValue'
        static member paleVioletred = CssColor.paleVioletred |> leftColorValue'
        static member papayaWhip = CssColor.papayaWhip |> leftColorValue'
        static member peachpuff = CssColor.peachpuff |> leftColorValue'
        static member peru = CssColor.peru |> leftColorValue'
        static member pink = CssColor.pink |> leftColorValue'
        static member plum = CssColor.plum |> leftColorValue'
        static member powderBlue = CssColor.powderBlue |> leftColorValue'
        static member rosyBrown = CssColor.rosyBrown |> leftColorValue'
        static member royalBlue = CssColor.royalBlue |> leftColorValue'
        static member saddleBrown = CssColor.saddleBrown |> leftColorValue'
        static member salmon = CssColor.salmon |> leftColorValue'
        static member sandyBrown = CssColor.sandyBrown |> leftColorValue'
        static member seaGreen = CssColor.seaGreen |> leftColorValue'
        static member seaShell = CssColor.seaShell |> leftColorValue'
        static member sienna = CssColor.sienna |> leftColorValue'
        static member skyBlue = CssColor.skyBlue |> leftColorValue'
        static member slateBlue = CssColor.slateBlue |> leftColorValue'
        static member slateGray = CssColor.slateGray |> leftColorValue'
        static member snow = CssColor.snow |> leftColorValue'
        static member springGreen = CssColor.springGreen |> leftColorValue'
        static member steelBlue = CssColor.steelBlue |> leftColorValue'
        static member tan = CssColor.tan |> leftColorValue'
        static member thistle = CssColor.thistle |> leftColorValue'
        static member tomato = CssColor.tomato |> leftColorValue'
        static member turquoise = CssColor.turquoise |> leftColorValue'
        static member violet = CssColor.violet |> leftColorValue'
        static member wheat = CssColor.wheat |> leftColorValue'
        static member whiteSmoke = CssColor.whiteSmoke |> leftColorValue'
        static member yellowGreen = CssColor.yellowGreen |> leftColorValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> leftColorValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> leftColorValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> leftColorValue'
        static member Hex value = CssColor.Hex value |> leftColorValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> leftColorValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> leftColorValue'
        static member transparent = CssColor.transparent |> leftColorValue'
        static member currentColor = CssColor.currentColor |> leftColorValue'

        static member Inherit = Inherit |> leftColorValue'
        static member Initial = Initial |> leftColorValue'
        static member Unset = Unset |> leftColorValue'

    /// <summary>Specifies color of left border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftColor' (color: IBorderColor) = BorderLeftColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    let private spacingValue value = PropertyValue.cssValue Property.BorderSpacing value
    let private spacingValue' value =
        value
        |> spacingToString
        |> spacingValue
    type BorderSpacing =
        static member Value (width: IBorderSpacing) =
            spacingValue (spacingToString width)
        static member Value (w1: IBorderSpacing, w2: IBorderSpacing) =
            sprintf "%s %s"
                (spacingToString w1)
                (spacingToString w2)
            |> spacingValue
        static member Inherit = Inherit |> spacingValue'
        static member Initial = Initial |> spacingValue'
        static member Unset = Unset |> spacingValue'

    /// <summary>Specifies distance borders of table cells.</summary>
    /// <param name="spacing">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderSpacing' (spacing: IBorderSpacing) = BorderSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let private imageWidthValue value = PropertyValue.cssValue Property.BorderImageWidth value
    let private imageWidthValue' value =
        value
        |> imageWidthToString
        |> imageWidthValue
    type BorderImageWidth =
        static member Value (width: IBorderImageWidth) = width |> imageWidthValue'
        static member Value (w1: IBorderImageWidth, w2: IBorderImageWidth) =
            sprintf "%s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
            |> imageWidthValue
        static member Value (w1: IBorderImageWidth, w2: IBorderImageWidth, w3: IBorderImageWidth) =
            sprintf "%s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
            |> imageWidthValue
        static member Value (w1: IBorderImageWidth, w2: IBorderImageWidth, w3: IBorderImageWidth, w4: IBorderImageWidth) =
            sprintf "%s %s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
                (imageWidthToString w4)
            |> imageWidthValue

        static member Auto = Auto |> imageWidthValue'
        static member Inherit = Inherit |> imageWidthValue'
        static member Initial = Initial |> imageWidthValue'
        static member Unset = Unset |> imageWidthValue'

    /// <summary>Specifies width of border image.</summary>
    /// <param name="width">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageWidth' (width: IBorderImageWidth) = BorderImageWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    let private imageValue value = PropertyValue.cssValue Property.BorderImageSource value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type BorderImageSource =
        static member Value (source: IBorderImageSource) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = None' |> imageValue'
        static member Inherit = Inherit |> imageValue'
        static member Initial = Initial |> imageValue'
        static member Unset = Unset |> imageValue'

    /// <summary>Specifies width of border image.</summary>
    /// <param name="source">
    ///     can be:
    ///     - <c> Image </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageSource' (source: IBorderImageSource) = BorderImageSource.Value(source)