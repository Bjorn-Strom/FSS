namespace Fss

[<AutoOpen>]
module Border =

    let private radiusToString (radius: Types.IBorderRadius) =
        match radius with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border radius"

    let private widthToString (width: Types.IBorderWidth) =
        match width with
            | :? Types.BorderWidth as b -> Utilities.Helpers.duToLowercase b
            | :? Types.Size as s -> Types.unitHelpers.sizeToString s
            | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
            | _ -> "unknown border width"

    let private styleToString (style: Types.IBorderStyle) =
        match style with
        | :? Types.BorderStyle as b -> Utilities.Helpers.duToLowercase b
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border style"

    let private collapseToString (collapse: Types.IBorderCollapse) =
        match collapse with
        | :? Types.BorderCollapse as c -> Utilities.Helpers.duToLowercase c
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border collapse"
    let private imageOutsetToString (imageOutset: Types.IBorderImageOutset) =
        let stringifyOutset (Types.BorderImageOutset v) = string v

        match imageOutset with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.BorderImageOutset as i -> stringifyOutset i
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border image outset"

    let private repeatToString (repeat: Types.IBorderRepeat) =
        match repeat with
        | :? Types.BorderImageRepeat as b -> Utilities.Helpers.duToLowercase b
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border repeat"

    let private imageSliceToString (imageSlice: Types.IBorderImageSlice) =
        let stringifySlice =
            function
                | Types.BorderImageSlice.Value i -> string i
                | Types.BorderImageSlice.Fill -> "fill"

        match imageSlice with
        | :? Types.BorderImageSlice as i -> stringifySlice i
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image slice"

    let private borderColorToString (borderColor: Types.IBorderColor) =
        match borderColor with
        | :? Types.Color as c -> Types.colorHelpers.colorToString c
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border color"

    let private spacingToString (spacing: Types.IBorderSpacing) =
        match spacing with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border spacing"

    let private imageWidthToString (imageWidth: Types.IBorderImageWidth) =
        match imageWidth with
        | :? Types.CssFloat as f -> Types.masterTypeHelpers.FloatToString f
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | _ -> "Unknown border image width"

    let private imageSourceToString (imageSource: Types.IBorderImageSource) =
        match imageSource with
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image source"

    let private borderToString (border: Types.IBorder) =
            match border with
            | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
            | :? Types.None' -> Types.masterTypeHelpers.none
            | _ -> "Unknown border"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    let private borderValue value = Types.propertyHelpers.cssValue Types.Property.Border value
    let private borderValue' value =
        value
        |> borderToString
        |> borderValue

    type Border =
        static member Value (border: Types.IBorder) = border |> borderValue'
        static member None = Types.None' |> borderValue'
        static member Inherit = Types.Inherit |> borderValue'
        static member Initial = Types.Initial |> borderValue'
        static member Unset = Types.Unset |> borderValue'

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
    let private radiusValue value = Types.propertyHelpers.cssValue Types.Property.BorderRadius value
    let private radiusValue' value =
        value
        |> radiusToString
        |> radiusValue
    type BorderRadius =
        static member Value (radius: Types.IBorderRadius) =
            sprintf "%s"
                (radiusToString radius)
                |> radiusValue
        static member Value (topLeftBottomRight: Types.IBorderRadius, topRightBottomLeft: Types.IBorderRadius) =
            sprintf "%s %s"
                (radiusToString topLeftBottomRight)
                (radiusToString topRightBottomLeft)
                |> radiusValue
        static member Value (topLeft: Types.IBorderRadius, topRightBottomLeft: Types.IBorderRadius, bottomRight: Types.IBorderRadius) =
            sprintf "%s %s %s"
                (radiusToString topLeft)
                (radiusToString topRightBottomLeft)
                (radiusToString bottomRight)
                |> radiusValue
        static member Value (topLeft: Types.IBorderRadius, topRight: Types.IBorderRadius, bottomRight: Types.IBorderRadius, bottomLeft: Types.IBorderRadius) =
            sprintf "%s %s %s %s"
                (radiusToString topLeft)
                (radiusToString topRight)
                (radiusToString bottomRight)
                (radiusToString bottomLeft)
                |> radiusValue

        static member Inherit = Types.Inherit |> radiusValue'
        static member Initial = Types.Initial |> radiusValue'
        static member Unset = Types.Unset |> radiusValue'

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
    let BorderRadius' (radius: Types.IBorderRadius) = BorderRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-left-radius
    let private bottomLeftRadiusValue value = Types.propertyHelpers.cssValue Types.Property.BorderBottomLeftRadius value
    let private bottomLeftRadiusValue' value =
        value
        |> radiusToString
        |> bottomLeftRadiusValue
    type BorderBottomLeftRadius =
        static member Value (horizontal: Types.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomLeftRadiusValue
        static member Value (horizontal: Types.IBorderRadius, vertical: Types.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomLeftRadiusValue
        static member Inherit = Types.Inherit |> bottomLeftRadiusValue'
        static member Initial = Types.Initial |> bottomLeftRadiusValue'
        static member Unset = Types.Unset |> bottomLeftRadiusValue'

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
    let BorderBottomLeftRadius' (radius: Types.IBorderRadius) = BorderBottomLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-right-radius
    let private bottomRightRadiusValue value = Types.propertyHelpers.cssValue Types.Property.BorderBottomRightRadius value
    let private bottomRightRadiusValue' value =
        value
        |> radiusToString
        |> bottomRightRadiusValue
    type BorderBottomRightRadius =
        static member Value (horizontal: Types.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomRightRadiusValue
        static member Value (horizontal: Types.IBorderRadius, vertical: Types.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomRightRadiusValue
        static member Inherit = Types.Inherit |> bottomRightRadiusValue'
        static member Initial = Types.Initial |> bottomRightRadiusValue'
        static member Unset = Types.Unset |> bottomRightRadiusValue'

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
    let BorderBottomRightRadius' (radius: Types.IBorderRadius) = BorderBottomRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-left-radius
    let private topLeftRadiusValue value = Types.propertyHelpers.cssValue Types.Property.BorderTopLeftRadius value
    let private topLeftRadiusValue' value =
        value
        |> radiusToString
        |> topLeftRadiusValue
    type BorderTopLeftRadius =
        static member Value (horizontal: Types.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topLeftRadiusValue
        static member Value (horizontal: Types.IBorderRadius, vertical: Types.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topLeftRadiusValue
        static member Inherit = Types.Inherit |> topLeftRadiusValue'
        static member Initial = Types.Initial |> topLeftRadiusValue'
        static member Unset = Types.Unset |> topLeftRadiusValue'

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
    let BorderTopLeftRadius' (radius: Types.IBorderRadius) = BorderTopLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-right-radius
    let private topRightRadiusValue value = Types.propertyHelpers.cssValue Types.Property.BorderTopRightRadius value
    let private topRightRadiusValue' value =
        value
        |> radiusToString
        |> topRightRadiusValue
    type BorderTopRightRadius =
        static member Value (horizontal: Types.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topRightRadiusValue
        static member Value (horizontal: Types.IBorderRadius, vertical: Types.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topRightRadiusValue
        static member Inherit = Types.Inherit |> topRightRadiusValue'
        static member Initial = Types.Initial |> topRightRadiusValue'
        static member Unset = Types.Unset |> topRightRadiusValue'

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
    let BorderTopRightRadius' (radius: Types.IBorderRadius) = BorderTopRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    let private widthValue value = Types.propertyHelpers.cssValue Types.Property.BorderWidth value
    let private widthValue' value =
        value
        |> widthToString
        |> widthValue

    type BorderWidth =
        static member Value (width: Types.IBorderWidth) = widthValue (widthToString width)
        static member Value (vertical: Types.IBorderWidth, horizontal: Types.IBorderWidth) =
            sprintf "%s %s"
                (widthToString vertical)
                (widthToString horizontal)
            |> widthValue
        static member Value (top: Types.IBorderWidth, horizontal: Types.IBorderWidth, bottom: Types.IBorderWidth) =
            sprintf "%s %s %s"
                (widthToString top)
                (widthToString horizontal)
                (widthToString bottom)
            |> widthValue
        static member Value (top: Types.IBorderWidth, right: Types.IBorderWidth, bottom: Types.IBorderWidth, left: Types.IBorderWidth) =
            sprintf "%s %s %s %s"
                (widthToString top)
                (widthToString right)
                (widthToString bottom)
                (widthToString left)
            |> widthValue

        static member Thin = Types.BorderWidth.Thin |> widthValue'
        static member Medium = Types.BorderWidth.Medium |> widthValue'
        static member Thick = Types.BorderWidth.Thick |> widthValue'

        static member Inherit = Types.Inherit |> widthValue'
        static member Initial = Types.Initial |> widthValue'
        static member Unset = Types.Unset |> widthValue'

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
    let BorderWidth' (width: Types.IBorderWidth) = BorderWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let private topWidthValue value = Types.propertyHelpers.cssValue Types.Property.BorderTopWidth value
    let private topWidthValue' value =
        value
        |> widthToString
        |> topWidthValue
    type BorderTopWidth =
        static member Value (width: Types.IBorderWidth) = width |> topWidthValue'
        static member Thin = Types.BorderWidth.Thin |> topWidthValue
        static member Medium = Types.BorderWidth.Medium |> topWidthValue
        static member Thick = Types.BorderWidth.Thick |> topWidthValue

        static member Inherit = Types.Inherit |> topWidthValue
        static member Initial = Types.Initial |> topWidthValue
        static member Unset = Types.Unset |> topWidthValue

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
    let BorderTopWidth' (width: Types.IBorderWidth) = BorderTopWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue value = Types.propertyHelpers.cssValue Types.Property.BorderRightWidth value
    let private rightWidthValue' value =
        value
        |> widthToString
        |> rightWidthValue
    type BorderRightWidth =
        static member Value (width: Types.IBorderWidth) = width |> rightWidthValue'
        static member Thin = Types.BorderWidth.Thin |> rightWidthValue
        static member Medium = Types.BorderWidth.Medium |> rightWidthValue
        static member Thick = Types.BorderWidth.Thick |> rightWidthValue

        static member Inherit = Types.Inherit |> rightWidthValue
        static member Initial = Types.Initial |> rightWidthValue
        static member Unset = Types.Unset |> rightWidthValue

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
    let BorderRightWidth' (width: Types.IBorderWidth) = BorderRightWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue value = Types.propertyHelpers.cssValue Types.Property.BorderBottomWidth value
    let private bottomWidthValue' value =
        value
        |> widthToString
        |> bottomWidthValue
    type BorderBottomWidth =
        static member Value (width: Types.IBorderWidth) = width |> bottomWidthValue'
        static member Thin = Types.BorderWidth.Thin |> bottomWidthValue
        static member Medium = Types.BorderWidth.Medium |> bottomWidthValue
        static member Thick = Types.BorderWidth.Thick |> bottomWidthValue

        static member Inherit = Types.Inherit |> bottomWidthValue
        static member Initial = Types.Initial |> bottomWidthValue
        static member Unset = Types.Unset |> bottomWidthValue

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
    let BorderBottomWidth' (width: Types.IBorderWidth) = BorderBottomWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue value = Types.propertyHelpers.cssValue Types.Property.BorderLeftWidth value
    let private leftWidthValue' value =
        value
        |> widthToString
        |> leftWidthValue
    type BorderLeftWidth =
        static member Value (width: Types.IBorderWidth) = width |> leftWidthValue'
        static member Thin = Types.BorderWidth.Thin |> leftWidthValue
        static member Medium = Types.BorderWidth.Medium |> leftWidthValue
        static member Thick = Types.BorderWidth.Thick |> leftWidthValue

        static member Inherit = Types.Inherit |> leftWidthValue
        static member Initial = Types.Initial |> leftWidthValue
        static member Unset = Types.Unset |> leftWidthValue

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
    let BorderLeftWidth' (width: Types.IBorderWidth) = BorderLeftWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    let private styleValue value = Types.propertyHelpers.cssValue Types.Property.BorderStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue

    type BorderStyle =
        static member Value (style: Types.IBorderStyle) = style |> styleValue'
        static member Value (vertical: Types.IBorderStyle, horizontal: Types.IBorderStyle) =
            sprintf "%s %s"
                (styleToString vertical)
                (styleToString horizontal)
            |> styleValue
        static member Value (top: Types.IBorderStyle, horizontal: Types.IBorderStyle, bottom: Types.IBorderStyle) =
            sprintf "%s %s %s"
                (styleToString top)
                (styleToString horizontal)
                (styleToString bottom)
            |> styleValue
        static member Value (top: Types.IBorderStyle, right: Types.IBorderStyle, bottom: Types.IBorderStyle, left: Types.IBorderStyle) =
            sprintf "%s %s %s %s"
                (styleToString top)
                (styleToString right)
                (styleToString bottom)
                (styleToString left)
            |> styleValue

        static member Hidden = Types.BorderStyle.Hidden |> styleValue'
        static member Dotted = Types.BorderStyle.Dotted |> styleValue'
        static member Dashed = Types.BorderStyle.Dashed |> styleValue'
        static member Solid = Types.BorderStyle.Solid |> styleValue'
        static member Double = Types.BorderStyle.Double |> styleValue'
        static member Groove = Types.BorderStyle.Groove |> styleValue'
        static member Ridge = Types.BorderStyle.Ridge |> styleValue'
        static member Inset = Types.BorderStyle.Inset |> styleValue'
        static member Outset = Types.BorderStyle.Outset |> styleValue'

        static member None = Types.None' |> styleValue'
        static member Inherit = Types.Inherit |> styleValue'
        static member Initial = Types.Initial |> styleValue'
        static member Unset = Types.Unset |> styleValue'

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
    let BorderStyle' (style: Types.IBorderStyle) = BorderStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue value = Types.propertyHelpers.cssValue Types.Property.BorderTopStyle value
    let private topStyleValue' value =
        value
        |> styleToString
        |> topStyleValue

    type BorderTopStyle =
        static member Value (style: Types.IBorderStyle) = style |> topStyleValue'
        static member Hidden = Types.BorderStyle.Hidden |> topStyleValue'
        static member Dotted = Types.BorderStyle.Dotted |> topStyleValue'
        static member Dashed = Types.BorderStyle.Dashed |> topStyleValue'
        static member Solid = Types.BorderStyle.Solid |> topStyleValue'
        static member Double = Types.BorderStyle.Double |> topStyleValue'
        static member Groove = Types.BorderStyle.Groove |> topStyleValue'
        static member Ridge = Types.BorderStyle.Ridge |> topStyleValue'
        static member Inset = Types.BorderStyle.Inset |> topStyleValue'
        static member Outset = Types.BorderStyle.Outset |> topStyleValue'

        static member None = Types.None' |> topStyleValue'
        static member Inherit = Types.Inherit |> topStyleValue'
        static member Initial = Types.Initial |> topStyleValue'
        static member Unset = Types.Unset |> topStyleValue'

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
    let BorderTopStyle' (style: Types.IBorderStyle) = BorderTopStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue value = Types.propertyHelpers.cssValue Types.Property.BorderRightStyle value
    let private rightStyleValue' value =
        value
        |> styleToString
        |> rightStyleValue

    type BorderRightStyle =
        static member Value (style: Types.IBorderStyle) = style |> rightStyleValue'
        static member Hidden = Types.BorderStyle.Hidden |> rightStyleValue'
        static member Dotted = Types.BorderStyle.Dotted |> rightStyleValue'
        static member Dashed = Types.BorderStyle.Dashed |> rightStyleValue'
        static member Solid = Types.BorderStyle.Solid |> rightStyleValue'
        static member Double = Types.BorderStyle.Double |> rightStyleValue'
        static member Groove = Types.BorderStyle.Groove |> rightStyleValue'
        static member Ridge = Types.BorderStyle.Ridge |> rightStyleValue'
        static member Inset = Types.BorderStyle.Inset |> rightStyleValue'
        static member Outset = Types.BorderStyle.Outset |> rightStyleValue'

        static member None = Types.None' |> rightStyleValue'
        static member Inherit = Types.Inherit |> rightStyleValue'
        static member Initial = Types.Initial |> rightStyleValue'
        static member Unset = Types.Unset |> rightStyleValue'

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
    let BorderRightStyle' (style: Types.IBorderStyle) = BorderRightStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue value = Types.propertyHelpers.cssValue Types.Property.BorderBottomStyle value
    let private bottomStyleValue' value =
        value
        |> styleToString
        |> bottomStyleValue

    type BorderBottomStyle =
        static member Value (style: Types.IBorderStyle) = style |> bottomStyleValue'
        static member Hidden = Types.BorderStyle.Hidden |> bottomStyleValue'
        static member Dotted = Types.BorderStyle.Dotted |> bottomStyleValue'
        static member Dashed = Types.BorderStyle.Dashed |> bottomStyleValue'
        static member Solid = Types.BorderStyle.Solid |> bottomStyleValue'
        static member Double = Types.BorderStyle.Double |> bottomStyleValue'
        static member Groove = Types.BorderStyle.Groove |> bottomStyleValue'
        static member Ridge = Types.BorderStyle.Ridge |> bottomStyleValue'
        static member Inset = Types.BorderStyle.Inset |> bottomStyleValue'
        static member Outset = Types.BorderStyle.Outset |> bottomStyleValue'

        static member None = Types.None' |> bottomStyleValue'
        static member Inherit = Types.Inherit |> bottomStyleValue'
        static member Initial = Types.Initial |> bottomStyleValue'
        static member Unset = Types.Unset |> bottomStyleValue'

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
    let BorderBottomStyle' (style: Types.IBorderStyle) = BorderBottomStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue value = Types.propertyHelpers.cssValue Types.Property.BorderLeftStyle value
    let private leftStyleValue' value =
        value
        |> styleToString
        |> leftStyleValue

    type BorderLeftStyle =
        static member Value (style: Types.IBorderStyle) = style |> leftStyleValue'
        static member Hidden = Types.BorderStyle.Hidden |> leftStyleValue'
        static member Dotted = Types.BorderStyle.Dotted |> leftStyleValue'
        static member Dashed = Types.BorderStyle.Dashed |> leftStyleValue'
        static member Solid = Types.BorderStyle.Solid |> leftStyleValue'
        static member Double = Types.BorderStyle.Double |> leftStyleValue'
        static member Groove = Types.BorderStyle.Groove |> leftStyleValue'
        static member Ridge = Types.BorderStyle.Ridge |> leftStyleValue'
        static member Inset = Types.BorderStyle.Inset |> leftStyleValue'
        static member Outset = Types.BorderStyle.Outset |> leftStyleValue'

        static member None = Types.None' |> leftStyleValue'
        static member Inherit = Types.Inherit |> leftStyleValue'
        static member Initial = Types.Initial |> leftStyleValue'
        static member Unset = Types.Unset |> leftStyleValue'

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
    let BorderLeftStyle' (style: Types.IBorderStyle) = BorderLeftStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue value = Types.propertyHelpers.cssValue Types.Property.BorderCollapse value
    let private collapseValue' value =
        value
        |> collapseToString
        |> collapseValue

    type BorderCollapse =
        static member Value (collapse: Types.IBorderCollapse) = collapse |> collapseValue'
        static member Collapse = Types.BorderCollapse.Collapse |> collapseValue'
        static member Separate = Types.BorderCollapse.Separate |> collapseValue'

        static member Inherit = Types.Inherit |> collapseValue'
        static member Initial = Types.Initial |> collapseValue'
        static member Unset = Types.Unset |> collapseValue'

    /// <summary>Specifies whether cells inside a table have shared borders.</summary>
    /// <param name="collapse">
    ///     can be:
    ///     - <c> BorderCollapse </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderCollapse' (collapse: Types.IBorderCollapse) =  BorderCollapse.Value(collapse)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    let private imageOutsetValue value = Types.propertyHelpers.cssValue Types.Property.BorderImageOutset value
    let private imageOutsetValue' value =
        value
        |> imageOutsetToString
        |> imageOutsetValue

    type BorderImageOutset =
        static member Value (outset: Types.IBorderImageOutset) = outset |> imageOutsetValue'
        static member Value (vertical: Types.IBorderImageOutset, horizontal: Types.IBorderImageOutset) =
            sprintf "%s %s" (imageOutsetToString vertical) (imageOutsetToString horizontal) |> imageOutsetValue
        static member Value (top: Types.IBorderImageOutset, horizontal: Types.IBorderImageOutset, bottom: Types.IBorderImageOutset) =
            sprintf "%s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString horizontal)
                (imageOutsetToString bottom)
            |> imageOutsetValue
        static member Value (top: Types.IBorderImageOutset, right: Types.IBorderImageOutset, bottom: Types.IBorderImageOutset, left: Types.IBorderImageOutset) =
            sprintf "%s %s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString right)
                (imageOutsetToString bottom)
                (imageOutsetToString left)
            |> imageOutsetValue

        static member Inherit = Types.Inherit |> imageOutsetValue'
        static member Initial = Types.Initial |> imageOutsetValue'
        static member Unset = Types.Unset |> imageOutsetValue'

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
    let BorderImageOutset' (outset: Types.IBorderImageOutset) =  BorderImageOutset.Value(outset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    let private imageRepeatValue value = Types.propertyHelpers.cssValue Types.Property.BorderImageRepeat value
    let private imageRepeatValue' value =
        value
        |> repeatToString
        |> imageRepeatValue
    type BorderImageRepeat =
        static member Value (repeat: Types.IBorderRepeat) = repeat |> imageRepeatValue'
        static member Value (vertical: Types.IBorderRepeat, horizontal: Types.IBorderRepeat) =
            sprintf "%s %s" (repeatToString vertical) (repeatToString horizontal)
            |> imageRepeatValue
        static member Stretch = Types.BorderImageRepeat.Stretch |> imageRepeatValue'
        static member Repeat = Types.BorderImageRepeat.Repeat |> imageRepeatValue'
        static member Round = Types.BorderImageRepeat.Round |> imageRepeatValue'
        static member Space = Types.BorderImageRepeat.Space |> imageRepeatValue'

        static member Inherit = Types.Inherit |> imageRepeatValue'
        static member Initial = Types.Initial |> imageRepeatValue'
        static member Unset = Types.Unset |> imageRepeatValue'

    /// <summary>Specifies how border image surrounds border box.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BorderImageRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageRepeat' (repeat: Types.IBorderRepeat) = BorderImageRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue value = Types.propertyHelpers.cssValue Types.Property.BorderImageSlice value
    let private imageSliceValue' value =
        value
        |> imageSliceToString
        |> imageSliceValue

    type BorderImageSlice =
        static member Fill = Types.BorderImageSlice.Fill |> imageSliceValue'
        static member Value (imageSlice: Types.IBorderImageSlice) = imageSlice |> imageSliceValue'
        static member Value (vertical: Types.IBorderImageSlice, horizontal: Types.IBorderImageSlice) =
            sprintf "%s %s" (imageSliceToString vertical) (imageSliceToString horizontal) |> imageSliceValue
        static member Value (w1: Types.IBorderImageSlice, w2: Types.IBorderImageSlice, w3: Types.IBorderImageSlice) =
            sprintf "%s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
            |> imageSliceValue
        static member Value (w1: Types.IBorderImageSlice, w2: Types.IBorderImageSlice, w3: Types.IBorderImageSlice, w4: Types.IBorderImageSlice) =
            sprintf "%s %s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
                (imageSliceToString w4)
            |> imageSliceValue

        static member Inherit = Types.Inherit |> imageSliceValue'
        static member Initial = Types.Initial |> imageSliceValue'
        static member Unset = Types.Unset |> imageSliceValue'

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
    let BorderImageSlice' (slice: Types.IBorderImageSlice) = BorderImageSlice.Value(slice)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    let private borderColorValue value = Types.propertyHelpers.cssValue Types.Property.BorderColor value
    let private borderColorValue' value =
        value
        |> borderColorToString
        |> borderColorValue

    type BorderColor =
        static member Value (color: Types.IBorderColor) = color |> borderColorValue'
        static member Value (horizontal: Types.IBorderColor, vertical: Types.IBorderColor) =
            sprintf "%s %s"
                (borderColorToString horizontal)
                (borderColorToString vertical)
            |> borderColorValue
        static member Value (top: Types.IBorderColor, vertical: Types.IBorderColor, bottom: Types.IBorderColor) =
            sprintf "%s %s %s"
                (borderColorToString top)
                (borderColorToString vertical)
                (borderColorToString bottom)
            |> borderColorValue
        static member Value (top: Types.IBorderColor, right: Types.IBorderColor, bottom: Types.IBorderColor, left: Types.IBorderColor) =
            sprintf "%s %s %s %s"
                (borderColorToString top)
                (borderColorToString right)
                (borderColorToString bottom)
                (borderColorToString left)
            |> borderColorValue
        static member black = Types.Color.black |> borderColorValue'
        static member silver = Types.Color.silver |> borderColorValue'
        static member gray = Types.Color.gray |> borderColorValue'
        static member white = Types.Color.white |> borderColorValue'
        static member maroon = Types.Color.maroon |> borderColorValue'
        static member red = Types.Color.red |> borderColorValue'
        static member purple = Types.Color.purple |> borderColorValue'
        static member fuchsia = Types.Color.fuchsia |> borderColorValue'
        static member green = Types.Color.green |> borderColorValue'
        static member lime = Types.Color.lime |> borderColorValue'
        static member olive = Types.Color.olive |> borderColorValue'
        static member yellow = Types.Color.yellow |> borderColorValue'
        static member navy = Types.Color.navy |> borderColorValue'
        static member blue = Types.Color.blue |> borderColorValue'
        static member teal = Types.Color.teal |> borderColorValue'
        static member aqua = Types.Color.aqua |> borderColorValue'
        static member orange = Types.Color.orange |> borderColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> borderColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> borderColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> borderColorValue'
        static member azure = Types.Color.azure |> borderColorValue'
        static member beige = Types.Color.beige |> borderColorValue'
        static member bisque = Types.Color.bisque |> borderColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> borderColorValue'
        static member blueViolet = Types.Color.blueViolet |> borderColorValue'
        static member brown = Types.Color.brown |> borderColorValue'
        static member burlywood = Types.Color.burlywood |> borderColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> borderColorValue'
        static member chartreuse = Types.Color.chartreuse |> borderColorValue'
        static member chocolate = Types.Color.chocolate |> borderColorValue'
        static member coral = Types.Color.coral |> borderColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> borderColorValue'
        static member cornsilk = Types.Color.cornsilk |> borderColorValue'
        static member crimson = Types.Color.crimson |> borderColorValue'
        static member cyan = Types.Color.cyan |> borderColorValue'
        static member darkBlue = Types.Color.darkBlue |> borderColorValue'
        static member darkCyan = Types.Color.darkCyan |> borderColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> borderColorValue'
        static member darkGray = Types.Color.darkGray |> borderColorValue'
        static member darkGreen = Types.Color.darkGreen |> borderColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> borderColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> borderColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> borderColorValue'
        static member darkOrange = Types.Color.darkOrange |> borderColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> borderColorValue'
        static member darkRed = Types.Color.darkRed |> borderColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> borderColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> borderColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> borderColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> borderColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> borderColorValue'
        static member darkViolet = Types.Color.darkViolet |> borderColorValue'
        static member deepPink = Types.Color.deepPink |> borderColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> borderColorValue'
        static member dimGrey = Types.Color.dimGrey |> borderColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> borderColorValue'
        static member fireBrick = Types.Color.fireBrick |> borderColorValue'
        static member floralWhite = Types.Color.floralWhite |> borderColorValue'
        static member forestGreen = Types.Color.forestGreen |> borderColorValue'
        static member gainsboro = Types.Color.gainsboro |> borderColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> borderColorValue'
        static member gold = Types.Color.gold |> borderColorValue'
        static member goldenrod = Types.Color.goldenrod |> borderColorValue'
        static member greenYellow = Types.Color.greenYellow |> borderColorValue'
        static member grey = Types.Color.grey |> borderColorValue'
        static member honeydew = Types.Color.honeydew |> borderColorValue'
        static member hotPink = Types.Color.hotPink |> borderColorValue'
        static member indianRed = Types.Color.indianRed |> borderColorValue'
        static member indigo = Types.Color.indigo |> borderColorValue'
        static member ivory = Types.Color.ivory |> borderColorValue'
        static member khaki = Types.Color.khaki |> borderColorValue'
        static member lavender = Types.Color.lavender |> borderColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> borderColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> borderColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> borderColorValue'
        static member lightBlue = Types.Color.lightBlue |> borderColorValue'
        static member lightCoral = Types.Color.lightCoral |> borderColorValue'
        static member lightCyan = Types.Color.lightCyan |> borderColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> borderColorValue'
        static member lightGray = Types.Color.lightGray |> borderColorValue'
        static member lightGreen = Types.Color.lightGreen |> borderColorValue'
        static member lightGrey = Types.Color.lightGrey |> borderColorValue'
        static member lightPink = Types.Color.lightPink |> borderColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> borderColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> borderColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> borderColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> borderColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> borderColorValue'
        static member lightYellow = Types.Color.lightYellow |> borderColorValue'
        static member limeGreen = Types.Color.limeGreen |> borderColorValue'
        static member linen = Types.Color.linen |> borderColorValue'
        static member magenta = Types.Color.magenta |> borderColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> borderColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> borderColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> borderColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> borderColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> borderColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> borderColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> borderColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> borderColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> borderColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> borderColorValue'
        static member mintCream = Types.Color.mintCream |> borderColorValue'
        static member mistyRose = Types.Color.mistyRose |> borderColorValue'
        static member moccasin = Types.Color.moccasin |> borderColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> borderColorValue'
        static member oldLace = Types.Color.oldLace |> borderColorValue'
        static member olivedrab = Types.Color.olivedrab |> borderColorValue'
        static member orangeRed = Types.Color.orangeRed |> borderColorValue'
        static member orchid = Types.Color.orchid |> borderColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> borderColorValue'
        static member paleGreen = Types.Color.paleGreen |> borderColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> borderColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> borderColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> borderColorValue'
        static member peachpuff = Types.Color.peachpuff |> borderColorValue'
        static member peru = Types.Color.peru |> borderColorValue'
        static member pink = Types.Color.pink |> borderColorValue'
        static member plum = Types.Color.plum |> borderColorValue'
        static member powderBlue = Types.Color.powderBlue |> borderColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> borderColorValue'
        static member royalBlue = Types.Color.royalBlue |> borderColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> borderColorValue'
        static member salmon = Types.Color.salmon |> borderColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> borderColorValue'
        static member seaGreen = Types.Color.seaGreen |> borderColorValue'
        static member seaShell = Types.Color.seaShell |> borderColorValue'
        static member sienna = Types.Color.sienna |> borderColorValue'
        static member skyBlue = Types.Color.skyBlue |> borderColorValue'
        static member slateBlue = Types.Color.slateBlue |> borderColorValue'
        static member slateGray = Types.Color.slateGray |> borderColorValue'
        static member snow = Types.Color.snow |> borderColorValue'
        static member springGreen = Types.Color.springGreen |> borderColorValue'
        static member steelBlue = Types.Color.steelBlue |> borderColorValue'
        static member tan = Types.Color.tan |> borderColorValue'
        static member thistle = Types.Color.thistle |> borderColorValue'
        static member tomato = Types.Color.tomato |> borderColorValue'
        static member turquoise = Types.Color.turquoise |> borderColorValue'
        static member violet = Types.Color.violet |> borderColorValue'
        static member wheat = Types.Color.wheat |> borderColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> borderColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> borderColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> borderColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> borderColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> borderColorValue'
        static member Hex value = Types.Color.Hex value |> borderColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> borderColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> borderColorValue'
        static member transparent = Types.Color.transparent |> borderColorValue'
        static member currentColor = Types.Color.currentColor |> borderColorValue'

        static member Inherit = Types.Inherit |> borderColorValue'
        static member Initial = Types.Initial |> borderColorValue'
        static member Unset = Types.Unset |> borderColorValue'

    /// <summary>Specifies color of border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderColor' (color: Types.IBorderColor) = BorderColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue value = Types.propertyHelpers.cssValue Types.Property.BorderTopColor value
    let private topColorValue' value =
        value
        |> borderColorToString
        |> topColorValue
    type BorderTopColor =
        static member Value (color: Types.IBorderColor) = color |> topColorValue'
        static member black = Types.Color.black |> topColorValue'
        static member silver = Types.Color.silver |> topColorValue'
        static member gray = Types.Color.gray |> topColorValue'
        static member white = Types.Color.white |> topColorValue'
        static member maroon = Types.Color.maroon |> topColorValue'
        static member red = Types.Color.red |> topColorValue'
        static member purple = Types.Color.purple |> topColorValue'
        static member fuchsia = Types.Color.fuchsia |> topColorValue'
        static member green = Types.Color.green |> topColorValue'
        static member lime = Types.Color.lime |> topColorValue'
        static member olive = Types.Color.olive |> topColorValue'
        static member yellow = Types.Color.yellow |> topColorValue'
        static member navy = Types.Color.navy |> topColorValue'
        static member blue = Types.Color.blue |> topColorValue'
        static member teal = Types.Color.teal |> topColorValue'
        static member aqua = Types.Color.aqua |> topColorValue'
        static member orange = Types.Color.orange |> topColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> topColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> topColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> topColorValue'
        static member azure = Types.Color.azure |> topColorValue'
        static member beige = Types.Color.beige |> topColorValue'
        static member bisque = Types.Color.bisque |> topColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> topColorValue'
        static member blueViolet = Types.Color.blueViolet |> topColorValue'
        static member brown = Types.Color.brown |> topColorValue'
        static member burlywood = Types.Color.burlywood |> topColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> topColorValue'
        static member chartreuse = Types.Color.chartreuse |> topColorValue'
        static member chocolate = Types.Color.chocolate |> topColorValue'
        static member coral = Types.Color.coral |> topColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> topColorValue'
        static member cornsilk = Types.Color.cornsilk |> topColorValue'
        static member crimson = Types.Color.crimson |> topColorValue'
        static member cyan = Types.Color.cyan |> topColorValue'
        static member darkBlue = Types.Color.darkBlue |> topColorValue'
        static member darkCyan = Types.Color.darkCyan |> topColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> topColorValue'
        static member darkGray = Types.Color.darkGray |> topColorValue'
        static member darkGreen = Types.Color.darkGreen |> topColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> topColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> topColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> topColorValue'
        static member darkOrange = Types.Color.darkOrange |> topColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> topColorValue'
        static member darkRed = Types.Color.darkRed |> topColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> topColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> topColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> topColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> topColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> topColorValue'
        static member darkViolet = Types.Color.darkViolet |> topColorValue'
        static member deepPink = Types.Color.deepPink |> topColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> topColorValue'
        static member dimGrey = Types.Color.dimGrey |> topColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> topColorValue'
        static member fireBrick = Types.Color.fireBrick |> topColorValue'
        static member floralWhite = Types.Color.floralWhite |> topColorValue'
        static member forestGreen = Types.Color.forestGreen |> topColorValue'
        static member gainsboro = Types.Color.gainsboro |> topColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> topColorValue'
        static member gold = Types.Color.gold |> topColorValue'
        static member goldenrod = Types.Color.goldenrod |> topColorValue'
        static member greenYellow = Types.Color.greenYellow |> topColorValue'
        static member grey = Types.Color.grey |> topColorValue'
        static member honeydew = Types.Color.honeydew |> topColorValue'
        static member hotPink = Types.Color.hotPink |> topColorValue'
        static member indianRed = Types.Color.indianRed |> topColorValue'
        static member indigo = Types.Color.indigo |> topColorValue'
        static member ivory = Types.Color.ivory |> topColorValue'
        static member khaki = Types.Color.khaki |> topColorValue'
        static member lavender = Types.Color.lavender |> topColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> topColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> topColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> topColorValue'
        static member lightBlue = Types.Color.lightBlue |> topColorValue'
        static member lightCoral = Types.Color.lightCoral |> topColorValue'
        static member lightCyan = Types.Color.lightCyan |> topColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> topColorValue'
        static member lightGray = Types.Color.lightGray |> topColorValue'
        static member lightGreen = Types.Color.lightGreen |> topColorValue'
        static member lightGrey = Types.Color.lightGrey |> topColorValue'
        static member lightPink = Types.Color.lightPink |> topColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> topColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> topColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> topColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> topColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> topColorValue'
        static member lightYellow = Types.Color.lightYellow |> topColorValue'
        static member limeGreen = Types.Color.limeGreen |> topColorValue'
        static member linen = Types.Color.linen |> topColorValue'
        static member magenta = Types.Color.magenta |> topColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> topColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> topColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> topColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> topColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> topColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> topColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> topColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> topColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> topColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> topColorValue'
        static member mintCream = Types.Color.mintCream |> topColorValue'
        static member mistyRose = Types.Color.mistyRose |> topColorValue'
        static member moccasin = Types.Color.moccasin |> topColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> topColorValue'
        static member oldLace = Types.Color.oldLace |> topColorValue'
        static member olivedrab = Types.Color.olivedrab |> topColorValue'
        static member orangeRed = Types.Color.orangeRed |> topColorValue'
        static member orchid = Types.Color.orchid |> topColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> topColorValue'
        static member paleGreen = Types.Color.paleGreen |> topColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> topColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> topColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> topColorValue'
        static member peachpuff = Types.Color.peachpuff |> topColorValue'
        static member peru = Types.Color.peru |> topColorValue'
        static member pink = Types.Color.pink |> topColorValue'
        static member plum = Types.Color.plum |> topColorValue'
        static member powderBlue = Types.Color.powderBlue |> topColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> topColorValue'
        static member royalBlue = Types.Color.royalBlue |> topColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> topColorValue'
        static member salmon = Types.Color.salmon |> topColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> topColorValue'
        static member seaGreen = Types.Color.seaGreen |> topColorValue'
        static member seaShell = Types.Color.seaShell |> topColorValue'
        static member sienna = Types.Color.sienna |> topColorValue'
        static member skyBlue = Types.Color.skyBlue |> topColorValue'
        static member slateBlue = Types.Color.slateBlue |> topColorValue'
        static member slateGray = Types.Color.slateGray |> topColorValue'
        static member snow = Types.Color.snow |> topColorValue'
        static member springGreen = Types.Color.springGreen |> topColorValue'
        static member steelBlue = Types.Color.steelBlue |> topColorValue'
        static member tan = Types.Color.tan |> topColorValue'
        static member thistle = Types.Color.thistle |> topColorValue'
        static member tomato = Types.Color.tomato |> topColorValue'
        static member turquoise = Types.Color.turquoise |> topColorValue'
        static member violet = Types.Color.violet |> topColorValue'
        static member wheat = Types.Color.wheat |> topColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> topColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> topColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> topColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> topColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> topColorValue'
        static member Hex value = Types.Color.Hex value |> topColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> topColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> topColorValue'
        static member transparent = Types.Color.transparent |> topColorValue'
        static member currentColor = Types.Color.currentColor |> topColorValue'

        static member Inherit = Types.Inherit |> topColorValue'
        static member Initial = Types.Initial |> topColorValue'
        static member Unset = Types.Unset |> topColorValue'

    /// <summary>Specifies color of top border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopColor' (color: Types.IBorderColor) = BorderTopColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue value = Types.propertyHelpers.cssValue Types.Property.BorderRightColor value
    let private rightColorValue' value =
        value
        |> borderColorToString
        |> rightColorValue
    type BorderRightColor =
        static member Value (color: Types.IBorderColor) = color |> rightColorValue'
        static member black = Types.Color.black |> rightColorValue'
        static member silver = Types.Color.silver |> rightColorValue'
        static member gray = Types.Color.gray |> rightColorValue'
        static member white = Types.Color.white |> rightColorValue'
        static member maroon = Types.Color.maroon |> rightColorValue'
        static member red = Types.Color.red |> rightColorValue'
        static member purple = Types.Color.purple |> rightColorValue'
        static member fuchsia = Types.Color.fuchsia |> rightColorValue'
        static member green = Types.Color.green |> rightColorValue'
        static member lime = Types.Color.lime |> rightColorValue'
        static member olive = Types.Color.olive |> rightColorValue'
        static member yellow = Types.Color.yellow |> rightColorValue'
        static member navy = Types.Color.navy |> rightColorValue'
        static member blue = Types.Color.blue |> rightColorValue'
        static member teal = Types.Color.teal |> rightColorValue'
        static member aqua = Types.Color.aqua |> rightColorValue'
        static member orange = Types.Color.orange |> rightColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> rightColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> rightColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> rightColorValue'
        static member azure = Types.Color.azure |> rightColorValue'
        static member beige = Types.Color.beige |> rightColorValue'
        static member bisque = Types.Color.bisque |> rightColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> rightColorValue'
        static member blueViolet = Types.Color.blueViolet |> rightColorValue'
        static member brown = Types.Color.brown |> rightColorValue'
        static member burlywood = Types.Color.burlywood |> rightColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> rightColorValue'
        static member chartreuse = Types.Color.chartreuse |> rightColorValue'
        static member chocolate = Types.Color.chocolate |> rightColorValue'
        static member coral = Types.Color.coral |> rightColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> rightColorValue'
        static member cornsilk = Types.Color.cornsilk |> rightColorValue'
        static member crimson = Types.Color.crimson |> rightColorValue'
        static member cyan = Types.Color.cyan |> rightColorValue'
        static member darkBlue = Types.Color.darkBlue |> rightColorValue'
        static member darkCyan = Types.Color.darkCyan |> rightColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> rightColorValue'
        static member darkGray = Types.Color.darkGray |> rightColorValue'
        static member darkGreen = Types.Color.darkGreen |> rightColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> rightColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> rightColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> rightColorValue'
        static member darkOrange = Types.Color.darkOrange |> rightColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> rightColorValue'
        static member darkRed = Types.Color.darkRed |> rightColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> rightColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> rightColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> rightColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> rightColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> rightColorValue'
        static member darkViolet = Types.Color.darkViolet |> rightColorValue'
        static member deepPink = Types.Color.deepPink |> rightColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> rightColorValue'
        static member dimGrey = Types.Color.dimGrey |> rightColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> rightColorValue'
        static member fireBrick = Types.Color.fireBrick |> rightColorValue'
        static member floralWhite = Types.Color.floralWhite |> rightColorValue'
        static member forestGreen = Types.Color.forestGreen |> rightColorValue'
        static member gainsboro = Types.Color.gainsboro |> rightColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> rightColorValue'
        static member gold = Types.Color.gold |> rightColorValue'
        static member goldenrod = Types.Color.goldenrod |> rightColorValue'
        static member greenYellow = Types.Color.greenYellow |> rightColorValue'
        static member grey = Types.Color.grey |> rightColorValue'
        static member honeydew = Types.Color.honeydew |> rightColorValue'
        static member hotPink = Types.Color.hotPink |> rightColorValue'
        static member indianRed = Types.Color.indianRed |> rightColorValue'
        static member indigo = Types.Color.indigo |> rightColorValue'
        static member ivory = Types.Color.ivory |> rightColorValue'
        static member khaki = Types.Color.khaki |> rightColorValue'
        static member lavender = Types.Color.lavender |> rightColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> rightColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> rightColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> rightColorValue'
        static member lightBlue = Types.Color.lightBlue |> rightColorValue'
        static member lightCoral = Types.Color.lightCoral |> rightColorValue'
        static member lightCyan = Types.Color.lightCyan |> rightColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> rightColorValue'
        static member lightGray = Types.Color.lightGray |> rightColorValue'
        static member lightGreen = Types.Color.lightGreen |> rightColorValue'
        static member lightGrey = Types.Color.lightGrey |> rightColorValue'
        static member lightPink = Types.Color.lightPink |> rightColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> rightColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> rightColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> rightColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> rightColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> rightColorValue'
        static member lightYellow = Types.Color.lightYellow |> rightColorValue'
        static member limeGreen = Types.Color.limeGreen |> rightColorValue'
        static member linen = Types.Color.linen |> rightColorValue'
        static member magenta = Types.Color.magenta |> rightColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> rightColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> rightColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> rightColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> rightColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> rightColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> rightColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> rightColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> rightColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> rightColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> rightColorValue'
        static member mintCream = Types.Color.mintCream |> rightColorValue'
        static member mistyRose = Types.Color.mistyRose |> rightColorValue'
        static member moccasin = Types.Color.moccasin |> rightColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> rightColorValue'
        static member oldLace = Types.Color.oldLace |> rightColorValue'
        static member olivedrab = Types.Color.olivedrab |> rightColorValue'
        static member orangeRed = Types.Color.orangeRed |> rightColorValue'
        static member orchid = Types.Color.orchid |> rightColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> rightColorValue'
        static member paleGreen = Types.Color.paleGreen |> rightColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> rightColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> rightColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> rightColorValue'
        static member peachpuff = Types.Color.peachpuff |> rightColorValue'
        static member peru = Types.Color.peru |> rightColorValue'
        static member pink = Types.Color.pink |> rightColorValue'
        static member plum = Types.Color.plum |> rightColorValue'
        static member powderBlue = Types.Color.powderBlue |> rightColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> rightColorValue'
        static member royalBlue = Types.Color.royalBlue |> rightColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> rightColorValue'
        static member salmon = Types.Color.salmon |> rightColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> rightColorValue'
        static member seaGreen = Types.Color.seaGreen |> rightColorValue'
        static member seaShell = Types.Color.seaShell |> rightColorValue'
        static member sienna = Types.Color.sienna |> rightColorValue'
        static member skyBlue = Types.Color.skyBlue |> rightColorValue'
        static member slateBlue = Types.Color.slateBlue |> rightColorValue'
        static member slateGray = Types.Color.slateGray |> rightColorValue'
        static member snow = Types.Color.snow |> rightColorValue'
        static member springGreen = Types.Color.springGreen |> rightColorValue'
        static member steelBlue = Types.Color.steelBlue |> rightColorValue'
        static member tan = Types.Color.tan |> rightColorValue'
        static member thistle = Types.Color.thistle |> rightColorValue'
        static member tomato = Types.Color.tomato |> rightColorValue'
        static member turquoise = Types.Color.turquoise |> rightColorValue'
        static member violet = Types.Color.violet |> rightColorValue'
        static member wheat = Types.Color.wheat |> rightColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> rightColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> rightColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> rightColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> rightColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> rightColorValue'
        static member Hex value = Types.Color.Hex value |> rightColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> rightColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> rightColorValue'
        static member transparent = Types.Color.transparent |> rightColorValue'
        static member currentColor = Types.Color.currentColor |> rightColorValue'

        static member Inherit = Types.Inherit |> rightColorValue'
        static member Initial = Types.Initial |> rightColorValue'
        static member Unset = Types.Unset |> rightColorValue'

    /// <summary>Specifies color of right border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightColor' (color: Types.IBorderColor) = BorderRightColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue value = Types.propertyHelpers.cssValue Types.Property.BorderBottomColor value
    let private bottomColorValue' value =
        value
        |> borderColorToString
        |> bottomColorValue
    type BorderBottomColor =
        static member Value (color: Types.IBorderColor) = color |> bottomColorValue'
        static member black = Types.Color.black |> bottomColorValue'
        static member silver = Types.Color.silver |> bottomColorValue'
        static member gray = Types.Color.gray |> bottomColorValue'
        static member white = Types.Color.white |> bottomColorValue'
        static member maroon = Types.Color.maroon |> bottomColorValue'
        static member red = Types.Color.red |> bottomColorValue'
        static member purple = Types.Color.purple |> bottomColorValue'
        static member fuchsia = Types.Color.fuchsia |> bottomColorValue'
        static member green = Types.Color.green |> bottomColorValue'
        static member lime = Types.Color.lime |> bottomColorValue'
        static member olive = Types.Color.olive |> bottomColorValue'
        static member yellow = Types.Color.yellow |> bottomColorValue'
        static member navy = Types.Color.navy |> bottomColorValue'
        static member blue = Types.Color.blue |> bottomColorValue'
        static member teal = Types.Color.teal |> bottomColorValue'
        static member aqua = Types.Color.aqua |> bottomColorValue'
        static member orange = Types.Color.orange |> bottomColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> bottomColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> bottomColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> bottomColorValue'
        static member azure = Types.Color.azure |> bottomColorValue'
        static member beige = Types.Color.beige |> bottomColorValue'
        static member bisque = Types.Color.bisque |> bottomColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> bottomColorValue'
        static member blueViolet = Types.Color.blueViolet |> bottomColorValue'
        static member brown = Types.Color.brown |> bottomColorValue'
        static member burlywood = Types.Color.burlywood |> bottomColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> bottomColorValue'
        static member chartreuse = Types.Color.chartreuse |> bottomColorValue'
        static member chocolate = Types.Color.chocolate |> bottomColorValue'
        static member coral = Types.Color.coral |> bottomColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> bottomColorValue'
        static member cornsilk = Types.Color.cornsilk |> bottomColorValue'
        static member crimson = Types.Color.crimson |> bottomColorValue'
        static member cyan = Types.Color.cyan |> bottomColorValue'
        static member darkBlue = Types.Color.darkBlue |> bottomColorValue'
        static member darkCyan = Types.Color.darkCyan |> bottomColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> bottomColorValue'
        static member darkGray = Types.Color.darkGray |> bottomColorValue'
        static member darkGreen = Types.Color.darkGreen |> bottomColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> bottomColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> bottomColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> bottomColorValue'
        static member darkOrange = Types.Color.darkOrange |> bottomColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> bottomColorValue'
        static member darkRed = Types.Color.darkRed |> bottomColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> bottomColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> bottomColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> bottomColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> bottomColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> bottomColorValue'
        static member darkViolet = Types.Color.darkViolet |> bottomColorValue'
        static member deepPink = Types.Color.deepPink |> bottomColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> bottomColorValue'
        static member dimGrey = Types.Color.dimGrey |> bottomColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> bottomColorValue'
        static member fireBrick = Types.Color.fireBrick |> bottomColorValue'
        static member floralWhite = Types.Color.floralWhite |> bottomColorValue'
        static member forestGreen = Types.Color.forestGreen |> bottomColorValue'
        static member gainsboro = Types.Color.gainsboro |> bottomColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> bottomColorValue'
        static member gold = Types.Color.gold |> bottomColorValue'
        static member goldenrod = Types.Color.goldenrod |> bottomColorValue'
        static member greenYellow = Types.Color.greenYellow |> bottomColorValue'
        static member grey = Types.Color.grey |> bottomColorValue'
        static member honeydew = Types.Color.honeydew |> bottomColorValue'
        static member hotPink = Types.Color.hotPink |> bottomColorValue'
        static member indianRed = Types.Color.indianRed |> bottomColorValue'
        static member indigo = Types.Color.indigo |> bottomColorValue'
        static member ivory = Types.Color.ivory |> bottomColorValue'
        static member khaki = Types.Color.khaki |> bottomColorValue'
        static member lavender = Types.Color.lavender |> bottomColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> bottomColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> bottomColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> bottomColorValue'
        static member lightBlue = Types.Color.lightBlue |> bottomColorValue'
        static member lightCoral = Types.Color.lightCoral |> bottomColorValue'
        static member lightCyan = Types.Color.lightCyan |> bottomColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> bottomColorValue'
        static member lightGray = Types.Color.lightGray |> bottomColorValue'
        static member lightGreen = Types.Color.lightGreen |> bottomColorValue'
        static member lightGrey = Types.Color.lightGrey |> bottomColorValue'
        static member lightPink = Types.Color.lightPink |> bottomColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> bottomColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> bottomColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> bottomColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> bottomColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> bottomColorValue'
        static member lightYellow = Types.Color.lightYellow |> bottomColorValue'
        static member limeGreen = Types.Color.limeGreen |> bottomColorValue'
        static member linen = Types.Color.linen |> bottomColorValue'
        static member magenta = Types.Color.magenta |> bottomColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> bottomColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> bottomColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> bottomColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> bottomColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> bottomColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> bottomColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> bottomColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> bottomColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> bottomColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> bottomColorValue'
        static member mintCream = Types.Color.mintCream |> bottomColorValue'
        static member mistyRose = Types.Color.mistyRose |> bottomColorValue'
        static member moccasin = Types.Color.moccasin |> bottomColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> bottomColorValue'
        static member oldLace = Types.Color.oldLace |> bottomColorValue'
        static member olivedrab = Types.Color.olivedrab |> bottomColorValue'
        static member orangeRed = Types.Color.orangeRed |> bottomColorValue'
        static member orchid = Types.Color.orchid |> bottomColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> bottomColorValue'
        static member paleGreen = Types.Color.paleGreen |> bottomColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> bottomColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> bottomColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> bottomColorValue'
        static member peachpuff = Types.Color.peachpuff |> bottomColorValue'
        static member peru = Types.Color.peru |> bottomColorValue'
        static member pink = Types.Color.pink |> bottomColorValue'
        static member plum = Types.Color.plum |> bottomColorValue'
        static member powderBlue = Types.Color.powderBlue |> bottomColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> bottomColorValue'
        static member royalBlue = Types.Color.royalBlue |> bottomColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> bottomColorValue'
        static member salmon = Types.Color.salmon |> bottomColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> bottomColorValue'
        static member seaGreen = Types.Color.seaGreen |> bottomColorValue'
        static member seaShell = Types.Color.seaShell |> bottomColorValue'
        static member sienna = Types.Color.sienna |> bottomColorValue'
        static member skyBlue = Types.Color.skyBlue |> bottomColorValue'
        static member slateBlue = Types.Color.slateBlue |> bottomColorValue'
        static member slateGray = Types.Color.slateGray |> bottomColorValue'
        static member snow = Types.Color.snow |> bottomColorValue'
        static member springGreen = Types.Color.springGreen |> bottomColorValue'
        static member steelBlue = Types.Color.steelBlue |> bottomColorValue'
        static member tan = Types.Color.tan |> bottomColorValue'
        static member thistle = Types.Color.thistle |> bottomColorValue'
        static member tomato = Types.Color.tomato |> bottomColorValue'
        static member turquoise = Types.Color.turquoise |> bottomColorValue'
        static member violet = Types.Color.violet |> bottomColorValue'
        static member wheat = Types.Color.wheat |> bottomColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> bottomColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> bottomColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> bottomColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> bottomColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> bottomColorValue'
        static member Hex value = Types.Color.Hex value |> bottomColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> bottomColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> bottomColorValue'
        static member transparent = Types.Color.transparent |> bottomColorValue'
        static member currentColor = Types.Color.currentColor |> bottomColorValue'

        static member Inherit = Types.Inherit |> bottomColorValue'
        static member Initial = Types.Initial |> bottomColorValue'
        static member Unset = Types.Unset |> bottomColorValue'

    /// <summary>Specifies color of bottom border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomColor' (color: Types.IBorderColor) = BorderBottomColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue value = Types.propertyHelpers.cssValue Types.Property.BorderLeftColor value
    let private leftColorValue' value =
        value
        |> borderColorToString
        |> leftColorValue
    type BorderLeftColor =
        static member Value (color: Types.IBorderColor) = color |> leftColorValue'
        static member black = Types.Color.black |> leftColorValue'
        static member silver = Types.Color.silver |> leftColorValue'
        static member gray = Types.Color.gray |> leftColorValue'
        static member white = Types.Color.white |> leftColorValue'
        static member maroon = Types.Color.maroon |> leftColorValue'
        static member red = Types.Color.red |> leftColorValue'
        static member purple = Types.Color.purple |> leftColorValue'
        static member fuchsia = Types.Color.fuchsia |> leftColorValue'
        static member green = Types.Color.green |> leftColorValue'
        static member lime = Types.Color.lime |> leftColorValue'
        static member olive = Types.Color.olive |> leftColorValue'
        static member yellow = Types.Color.yellow |> leftColorValue'
        static member navy = Types.Color.navy |> leftColorValue'
        static member blue = Types.Color.blue |> leftColorValue'
        static member teal = Types.Color.teal |> leftColorValue'
        static member aqua = Types.Color.aqua |> leftColorValue'
        static member orange = Types.Color.orange |> leftColorValue'
        static member aliceBlue = Types.Color.aliceBlue |> leftColorValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> leftColorValue'
        static member aquaMarine = Types.Color.aquaMarine |> leftColorValue'
        static member azure = Types.Color.azure |> leftColorValue'
        static member beige = Types.Color.beige |> leftColorValue'
        static member bisque = Types.Color.bisque |> leftColorValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> leftColorValue'
        static member blueViolet = Types.Color.blueViolet |> leftColorValue'
        static member brown = Types.Color.brown |> leftColorValue'
        static member burlywood = Types.Color.burlywood |> leftColorValue'
        static member cadetBlue = Types.Color.cadetBlue |> leftColorValue'
        static member chartreuse = Types.Color.chartreuse |> leftColorValue'
        static member chocolate = Types.Color.chocolate |> leftColorValue'
        static member coral = Types.Color.coral |> leftColorValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> leftColorValue'
        static member cornsilk = Types.Color.cornsilk |> leftColorValue'
        static member crimson = Types.Color.crimson |> leftColorValue'
        static member cyan = Types.Color.cyan |> leftColorValue'
        static member darkBlue = Types.Color.darkBlue |> leftColorValue'
        static member darkCyan = Types.Color.darkCyan |> leftColorValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> leftColorValue'
        static member darkGray = Types.Color.darkGray |> leftColorValue'
        static member darkGreen = Types.Color.darkGreen |> leftColorValue'
        static member darkKhaki = Types.Color.darkKhaki |> leftColorValue'
        static member darkMagenta = Types.Color.darkMagenta |> leftColorValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> leftColorValue'
        static member darkOrange = Types.Color.darkOrange |> leftColorValue'
        static member darkOrchid = Types.Color.darkOrchid |> leftColorValue'
        static member darkRed = Types.Color.darkRed |> leftColorValue'
        static member darkSalmon = Types.Color.darkSalmon |> leftColorValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> leftColorValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> leftColorValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> leftColorValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> leftColorValue'
        static member darkViolet = Types.Color.darkViolet |> leftColorValue'
        static member deepPink = Types.Color.deepPink |> leftColorValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> leftColorValue'
        static member dimGrey = Types.Color.dimGrey |> leftColorValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> leftColorValue'
        static member fireBrick = Types.Color.fireBrick |> leftColorValue'
        static member floralWhite = Types.Color.floralWhite |> leftColorValue'
        static member forestGreen = Types.Color.forestGreen |> leftColorValue'
        static member gainsboro = Types.Color.gainsboro |> leftColorValue'
        static member ghostWhite = Types.Color.ghostWhite |> leftColorValue'
        static member gold = Types.Color.gold |> leftColorValue'
        static member goldenrod = Types.Color.goldenrod |> leftColorValue'
        static member greenYellow = Types.Color.greenYellow |> leftColorValue'
        static member grey = Types.Color.grey |> leftColorValue'
        static member honeydew = Types.Color.honeydew |> leftColorValue'
        static member hotPink = Types.Color.hotPink |> leftColorValue'
        static member indianRed = Types.Color.indianRed |> leftColorValue'
        static member indigo = Types.Color.indigo |> leftColorValue'
        static member ivory = Types.Color.ivory |> leftColorValue'
        static member khaki = Types.Color.khaki |> leftColorValue'
        static member lavender = Types.Color.lavender |> leftColorValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> leftColorValue'
        static member lawnGreen = Types.Color.lawnGreen |> leftColorValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> leftColorValue'
        static member lightBlue = Types.Color.lightBlue |> leftColorValue'
        static member lightCoral = Types.Color.lightCoral |> leftColorValue'
        static member lightCyan = Types.Color.lightCyan |> leftColorValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> leftColorValue'
        static member lightGray = Types.Color.lightGray |> leftColorValue'
        static member lightGreen = Types.Color.lightGreen |> leftColorValue'
        static member lightGrey = Types.Color.lightGrey |> leftColorValue'
        static member lightPink = Types.Color.lightPink |> leftColorValue'
        static member lightSalmon = Types.Color.lightSalmon |> leftColorValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> leftColorValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> leftColorValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> leftColorValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> leftColorValue'
        static member lightYellow = Types.Color.lightYellow |> leftColorValue'
        static member limeGreen = Types.Color.limeGreen |> leftColorValue'
        static member linen = Types.Color.linen |> leftColorValue'
        static member magenta = Types.Color.magenta |> leftColorValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> leftColorValue'
        static member mediumBlue = Types.Color.mediumBlue |> leftColorValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> leftColorValue'
        static member mediumPurple = Types.Color.mediumPurple |> leftColorValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> leftColorValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> leftColorValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> leftColorValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> leftColorValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> leftColorValue'
        static member midnightBlue = Types.Color.midnightBlue |> leftColorValue'
        static member mintCream = Types.Color.mintCream |> leftColorValue'
        static member mistyRose = Types.Color.mistyRose |> leftColorValue'
        static member moccasin = Types.Color.moccasin |> leftColorValue'
        static member navajoWhite = Types.Color.navajoWhite |> leftColorValue'
        static member oldLace = Types.Color.oldLace |> leftColorValue'
        static member olivedrab = Types.Color.olivedrab |> leftColorValue'
        static member orangeRed = Types.Color.orangeRed |> leftColorValue'
        static member orchid = Types.Color.orchid |> leftColorValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> leftColorValue'
        static member paleGreen = Types.Color.paleGreen |> leftColorValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> leftColorValue'
        static member paleVioletred = Types.Color.paleVioletred |> leftColorValue'
        static member papayaWhip = Types.Color.papayaWhip |> leftColorValue'
        static member peachpuff = Types.Color.peachpuff |> leftColorValue'
        static member peru = Types.Color.peru |> leftColorValue'
        static member pink = Types.Color.pink |> leftColorValue'
        static member plum = Types.Color.plum |> leftColorValue'
        static member powderBlue = Types.Color.powderBlue |> leftColorValue'
        static member rosyBrown = Types.Color.rosyBrown |> leftColorValue'
        static member royalBlue = Types.Color.royalBlue |> leftColorValue'
        static member saddleBrown = Types.Color.saddleBrown |> leftColorValue'
        static member salmon = Types.Color.salmon |> leftColorValue'
        static member sandyBrown = Types.Color.sandyBrown |> leftColorValue'
        static member seaGreen = Types.Color.seaGreen |> leftColorValue'
        static member seaShell = Types.Color.seaShell |> leftColorValue'
        static member sienna = Types.Color.sienna |> leftColorValue'
        static member skyBlue = Types.Color.skyBlue |> leftColorValue'
        static member slateBlue = Types.Color.slateBlue |> leftColorValue'
        static member slateGray = Types.Color.slateGray |> leftColorValue'
        static member snow = Types.Color.snow |> leftColorValue'
        static member springGreen = Types.Color.springGreen |> leftColorValue'
        static member steelBlue = Types.Color.steelBlue |> leftColorValue'
        static member tan = Types.Color.tan |> leftColorValue'
        static member thistle = Types.Color.thistle |> leftColorValue'
        static member tomato = Types.Color.tomato |> leftColorValue'
        static member turquoise = Types.Color.turquoise |> leftColorValue'
        static member violet = Types.Color.violet |> leftColorValue'
        static member wheat = Types.Color.wheat |> leftColorValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> leftColorValue'
        static member yellowGreen = Types.Color.yellowGreen |> leftColorValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> leftColorValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> leftColorValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> leftColorValue'
        static member Hex value = Types.Color.Hex value |> leftColorValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> leftColorValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> leftColorValue'
        static member transparent = Types.Color.transparent |> leftColorValue'
        static member currentColor = Types.Color.currentColor |> leftColorValue'

        static member Inherit = Types.Inherit |> leftColorValue'
        static member Initial = Types.Initial |> leftColorValue'
        static member Unset = Types.Unset |> leftColorValue'

    /// <summary>Specifies color of left border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftColor' (color: Types.IBorderColor) = BorderLeftColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    let private spacingValue value = Types.propertyHelpers.cssValue Types.Property.BorderSpacing value
    let private spacingValue' value =
        value
        |> spacingToString
        |> spacingValue
    type BorderSpacing =
        static member Value (width: Types.IBorderSpacing) =
            spacingValue (spacingToString width)
        static member Value (w1: Types.IBorderSpacing, w2: Types.IBorderSpacing) =
            sprintf "%s %s"
                (spacingToString w1)
                (spacingToString w2)
            |> spacingValue
        static member Inherit = Types.Inherit |> spacingValue'
        static member Initial = Types.Initial |> spacingValue'
        static member Unset = Types.Unset |> spacingValue'

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
    let BorderSpacing' (spacing: Types.IBorderSpacing) = BorderSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let private imageWidthValue value = Types.propertyHelpers.cssValue Types.Property.BorderImageWidth value
    let private imageWidthValue' value =
        value
        |> imageWidthToString
        |> imageWidthValue
    type BorderImageWidth =
        static member Value (width: Types.IBorderImageWidth) = width |> imageWidthValue'
        static member Value (w1: Types.IBorderImageWidth, w2: Types.IBorderImageWidth) =
            sprintf "%s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
            |> imageWidthValue
        static member Value (w1: Types.IBorderImageWidth, w2: Types.IBorderImageWidth, w3: Types.IBorderImageWidth) =
            sprintf "%s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
            |> imageWidthValue
        static member Value (w1: Types.IBorderImageWidth, w2: Types.IBorderImageWidth, w3: Types.IBorderImageWidth, w4: Types.IBorderImageWidth) =
            sprintf "%s %s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
                (imageWidthToString w4)
            |> imageWidthValue

        static member Auto = Types.Auto |> imageWidthValue'
        static member Inherit = Types.Inherit |> imageWidthValue'
        static member Initial = Types.Initial |> imageWidthValue'
        static member Unset = Types.Unset |> imageWidthValue'

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
    let BorderImageWidth' (width: Types.IBorderImageWidth) = BorderImageWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    let private imageValue value = Types.propertyHelpers.cssValue Types.Property.BorderImageSource value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type BorderImageSource =
        static member Value (source: Types.IBorderImageSource) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            imageValue <| Types.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            imageValue <| Types.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) list) =
            imageValue <| Types.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) list) =
            imageValue <| Types.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = Types.None' |> imageValue'
        static member Inherit = Types.Inherit |> imageValue'
        static member Initial = Types.Initial |> imageValue'
        static member Unset = Types.Unset |> imageValue'

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
    let BorderImageSource' (source: Types.IBorderImageSource) = BorderImageSource.Value(source)