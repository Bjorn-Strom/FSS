namespace Fss

[<AutoOpen>]
module Border =

    let private radiusToString (radius: FssTypes.IBorderRadius) =
        match radius with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border radius"

    let private widthToString (width: FssTypes.IBorderWidth) =
        match width with
            | :? FssTypes.Border.Width as b -> Utilities.Helpers.duToLowercase b
            | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "unknown border width"

    let private styleToString (style: FssTypes.IBorderStyle) =
        match style with
        | :? FssTypes.Border.Style as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border style"

    let private collapseToString (collapse: FssTypes.IBorderCollapse) =
        match collapse with
        | :? FssTypes.Border.Collapse as c -> Utilities.Helpers.duToLowercase c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border collapse"
    let private imageOutsetToString (imageOutset: FssTypes.IBorderImageOutset) =
        let stringifyOutset (FssTypes.Border.ImageOutset v) = string v

        match imageOutset with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Border.ImageOutset as i -> stringifyOutset i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border image outset"

    let private repeatToString (repeat: FssTypes.IBorderRepeat) =
        match repeat with
        | :? FssTypes.Border.ImageRepeat as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border repeat"

    let private imageSliceToString (imageSlice: FssTypes.IBorderImageSlice) =
        let stringifySlice =
            function
                | FssTypes.Border.ImageSlice.Value i -> string i
                | FssTypes.Border.ImageSlice.Fill -> "fill"

        match imageSlice with
        | :? FssTypes.Border.ImageSlice as i -> stringifySlice i
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image slice"

    let private borderColorToString (borderColor: FssTypes.IBorderColor) =
        match borderColor with
        | :? FssTypes.ColorType as c -> FssTypes.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border color"

    let private spacingToString (spacing: FssTypes.IBorderSpacing) =
        match spacing with
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border spacing"

    let private imageWidthToString (imageWidth: FssTypes.IBorderImageWidth) =
        match imageWidth with
        | :? FssTypes.CssFloat as f -> FssTypes.masterTypeHelpers.FloatToString f
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown border image width"

    let private imageSourceToString (imageSource: FssTypes.IBorderImageSource) =
        match imageSource with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image source"

    let private borderToString (border: FssTypes.IBorder) =
            match border with
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
            | _ -> "Unknown border"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    let private borderValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Border value
    let private borderValue' value =
        value
        |> borderToString
        |> borderValue

    type Border =
        static member Value (border: FssTypes.IBorder) = border |> borderValue'
        static member None = FssTypes.None' |> borderValue'
        static member Inherit = FssTypes.Inherit |> borderValue'
        static member Initial = FssTypes.Initial |> borderValue'
        static member Unset = FssTypes.Unset |> borderValue'

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
    let private radiusValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRadius value
    let private radiusValue' value =
        value
        |> radiusToString
        |> radiusValue
    type BorderRadius =
        static member Value (radius: FssTypes.IBorderRadius) =
            sprintf "%s"
                (radiusToString radius)
                |> radiusValue
        static member Value (topLeftBottomRight: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s"
                (radiusToString topLeftBottomRight)
                (radiusToString topRightBottomLeft)
                |> radiusValue
        static member Value (topLeft: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius) =
            sprintf "%s %s %s"
                (radiusToString topLeft)
                (radiusToString topRightBottomLeft)
                (radiusToString bottomRight)
                |> radiusValue
        static member Value (topLeft: FssTypes.IBorderRadius, topRight: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius, bottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s %s %s"
                (radiusToString topLeft)
                (radiusToString topRight)
                (radiusToString bottomRight)
                (radiusToString bottomLeft)
                |> radiusValue

        static member Inherit = FssTypes.Inherit |> radiusValue'
        static member Initial = FssTypes.Initial |> radiusValue'
        static member Unset = FssTypes.Unset |> radiusValue'

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
    let BorderRadius' (radius: FssTypes.IBorderRadius) = BorderRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-left-radius
    let private bottomLeftRadiusValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomLeftRadius value
    let private bottomLeftRadiusValue' value =
        value
        |> radiusToString
        |> bottomLeftRadiusValue
    type BorderBottomLeftRadius =
        static member Value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomLeftRadiusValue
        static member Value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomLeftRadiusValue
        static member Inherit = FssTypes.Inherit |> bottomLeftRadiusValue'
        static member Initial = FssTypes.Initial |> bottomLeftRadiusValue'
        static member Unset = FssTypes.Unset |> bottomLeftRadiusValue'

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
    let BorderBottomLeftRadius' (radius: FssTypes.IBorderRadius) = BorderBottomLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-right-radius
    let private bottomRightRadiusValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomRightRadius value
    let private bottomRightRadiusValue' value =
        value
        |> radiusToString
        |> bottomRightRadiusValue
    type BorderBottomRightRadius =
        static member Value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomRightRadiusValue
        static member Value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomRightRadiusValue
        static member Inherit = FssTypes.Inherit |> bottomRightRadiusValue'
        static member Initial = FssTypes.Initial |> bottomRightRadiusValue'
        static member Unset = FssTypes.Unset |> bottomRightRadiusValue'

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
    let BorderBottomRightRadius' (radius: FssTypes.IBorderRadius) = BorderBottomRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-left-radius
    let private topLeftRadiusValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopLeftRadius value
    let private topLeftRadiusValue' value =
        value
        |> radiusToString
        |> topLeftRadiusValue
    type BorderTopLeftRadius =
        static member Value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topLeftRadiusValue
        static member Value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topLeftRadiusValue
        static member Inherit = FssTypes.Inherit |> topLeftRadiusValue'
        static member Initial = FssTypes.Initial |> topLeftRadiusValue'
        static member Unset = FssTypes.Unset |> topLeftRadiusValue'

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
    let BorderTopLeftRadius' (radius: FssTypes.IBorderRadius) = BorderTopLeftRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-right-radius
    let private topRightRadiusValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopRightRadius value
    let private topRightRadiusValue' value =
        value
        |> radiusToString
        |> topRightRadiusValue
    type BorderTopRightRadius =
        static member Value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topRightRadiusValue
        static member Value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topRightRadiusValue
        static member Inherit = FssTypes.Inherit |> topRightRadiusValue'
        static member Initial = FssTypes.Initial |> topRightRadiusValue'
        static member Unset = FssTypes.Unset |> topRightRadiusValue'

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
    let BorderTopRightRadius' (radius: FssTypes.IBorderRadius) = BorderTopRightRadius.Value(radius)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    let private widthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderWidth value
    let private widthValue' value =
        value
        |> widthToString
        |> widthValue

    type BorderWidth =
        static member Value (width: FssTypes.IBorderWidth) = widthValue (widthToString width)
        static member Value (vertical: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth) =
            sprintf "%s %s"
                (widthToString vertical)
                (widthToString horizontal)
            |> widthValue
        static member Value (top: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth) =
            sprintf "%s %s %s"
                (widthToString top)
                (widthToString horizontal)
                (widthToString bottom)
            |> widthValue
        static member Value (top: FssTypes.IBorderWidth, right: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth, left: FssTypes.IBorderWidth) =
            sprintf "%s %s %s %s"
                (widthToString top)
                (widthToString right)
                (widthToString bottom)
                (widthToString left)
            |> widthValue

        static member Thin = FssTypes.Border.Width.Thin |> widthValue'
        static member Medium = FssTypes.Border.Width.Medium |> widthValue'
        static member Thick = FssTypes.Border.Width.Thick |> widthValue'

        static member Inherit = FssTypes.Inherit |> widthValue'
        static member Initial = FssTypes.Initial |> widthValue'
        static member Unset = FssTypes.Unset |> widthValue'

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
    let BorderWidth' (width: FssTypes.IBorderWidth) = BorderWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let private topWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopWidth value
    let private topWidthValue' value =
        value
        |> widthToString
        |> topWidthValue
    type BorderTopWidth =
        static member Value (width: FssTypes.IBorderWidth) = width |> topWidthValue'
        static member Thin = FssTypes.Border.Width.Thin |> topWidthValue
        static member Medium = FssTypes.Border.Width.Medium |> topWidthValue
        static member Thick = FssTypes.Border.Width.Thick |> topWidthValue

        static member Inherit = FssTypes.Inherit |> topWidthValue
        static member Initial = FssTypes.Initial |> topWidthValue
        static member Unset = FssTypes.Unset |> topWidthValue

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
    let BorderTopWidth' (width: FssTypes.IBorderWidth) = BorderTopWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightWidth value
    let private rightWidthValue' value =
        value
        |> widthToString
        |> rightWidthValue
    type BorderRightWidth =
        static member Value (width: FssTypes.IBorderWidth) = width |> rightWidthValue'
        static member Thin = FssTypes.Border.Width.Thin |> rightWidthValue
        static member Medium = FssTypes.Border.Width.Medium |> rightWidthValue
        static member Thick = FssTypes.Border.Width.Thick |> rightWidthValue

        static member Inherit = FssTypes.Inherit |> rightWidthValue
        static member Initial = FssTypes.Initial |> rightWidthValue
        static member Unset = FssTypes.Unset |> rightWidthValue

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
    let BorderRightWidth' (width: FssTypes.IBorderWidth) = BorderRightWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomWidth value
    let private bottomWidthValue' value =
        value
        |> widthToString
        |> bottomWidthValue
    type BorderBottomWidth =
        static member Value (width: FssTypes.IBorderWidth) = width |> bottomWidthValue'
        static member Thin = FssTypes.Border.Width.Thin |> bottomWidthValue
        static member Medium = FssTypes.Border.Width.Medium |> bottomWidthValue
        static member Thick = FssTypes.Border.Width.Thick |> bottomWidthValue

        static member Inherit = FssTypes.Inherit |> bottomWidthValue
        static member Initial = FssTypes.Initial |> bottomWidthValue
        static member Unset = FssTypes.Unset |> bottomWidthValue

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
    let BorderBottomWidth' (width: FssTypes.IBorderWidth) = BorderBottomWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftWidth value
    let private leftWidthValue' value =
        value
        |> widthToString
        |> leftWidthValue
    type BorderLeftWidth =
        static member Value (width: FssTypes.IBorderWidth) = width |> leftWidthValue'
        static member Thin = FssTypes.Border.Width.Thin |> leftWidthValue
        static member Medium = FssTypes.Border.Width.Medium |> leftWidthValue
        static member Thick = FssTypes.Border.Width.Thick |> leftWidthValue

        static member Inherit = FssTypes.Inherit |> leftWidthValue
        static member Initial = FssTypes.Initial |> leftWidthValue
        static member Unset = FssTypes.Unset |> leftWidthValue

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
    let BorderLeftWidth' (width: FssTypes.IBorderWidth) = BorderLeftWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    let private styleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue

    type BorderStyle =
        static member Value (style: FssTypes.IBorderStyle) = style |> styleValue'
        static member Value (vertical: FssTypes.IBorderStyle, horizontal: FssTypes.IBorderStyle) =
            sprintf "%s %s"
                (styleToString vertical)
                (styleToString horizontal)
            |> styleValue
        static member Value (top: FssTypes.IBorderStyle, horizontal: FssTypes.IBorderStyle, bottom: FssTypes.IBorderStyle) =
            sprintf "%s %s %s"
                (styleToString top)
                (styleToString horizontal)
                (styleToString bottom)
            |> styleValue
        static member Value (top: FssTypes.IBorderStyle, right: FssTypes.IBorderStyle, bottom: FssTypes.IBorderStyle, left: FssTypes.IBorderStyle) =
            sprintf "%s %s %s %s"
                (styleToString top)
                (styleToString right)
                (styleToString bottom)
                (styleToString left)
            |> styleValue

        static member Hidden = FssTypes.Border.Style.Hidden |> styleValue'
        static member Dotted = FssTypes.Border.Style.Dotted |> styleValue'
        static member Dashed = FssTypes.Border.Style.Dashed |> styleValue'
        static member Solid = FssTypes.Border.Style.Solid |> styleValue'
        static member Double = FssTypes.Border.Style.Double |> styleValue'
        static member Groove = FssTypes.Border.Style.Groove |> styleValue'
        static member Ridge = FssTypes.Border.Style.Ridge |> styleValue'
        static member Inset = FssTypes.Border.Style.Inset |> styleValue'
        static member Outset = FssTypes.Border.Style.Outset |> styleValue'

        static member None = FssTypes.None' |> styleValue'
        static member Inherit = FssTypes.Inherit |> styleValue'
        static member Initial = FssTypes.Initial |> styleValue'
        static member Unset = FssTypes.Unset |> styleValue'

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
    let BorderStyle' (style: FssTypes.IBorderStyle) = BorderStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopStyle value
    let private topStyleValue' value =
        value
        |> styleToString
        |> topStyleValue

    type BorderTopStyle =
        static member Value (style: FssTypes.IBorderStyle) = style |> topStyleValue'
        static member Hidden = FssTypes.Border.Style.Hidden |> topStyleValue'
        static member Dotted = FssTypes.Border.Style.Dotted |> topStyleValue'
        static member Dashed = FssTypes.Border.Style.Dashed |> topStyleValue'
        static member Solid = FssTypes.Border.Style.Solid |> topStyleValue'
        static member Double = FssTypes.Border.Style.Double |> topStyleValue'
        static member Groove = FssTypes.Border.Style.Groove |> topStyleValue'
        static member Ridge = FssTypes.Border.Style.Ridge |> topStyleValue'
        static member Inset = FssTypes.Border.Style.Inset |> topStyleValue'
        static member Outset = FssTypes.Border.Style.Outset |> topStyleValue'

        static member None = FssTypes.None' |> topStyleValue'
        static member Inherit = FssTypes.Inherit |> topStyleValue'
        static member Initial = FssTypes.Initial |> topStyleValue'
        static member Unset = FssTypes.Unset |> topStyleValue'

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
    let BorderTopStyle' (style: FssTypes.IBorderStyle) = BorderTopStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightStyle value
    let private rightStyleValue' value =
        value
        |> styleToString
        |> rightStyleValue

    type BorderRightStyle =
        static member Value (style: FssTypes.IBorderStyle) = style |> rightStyleValue'
        static member Hidden = FssTypes.Border.Style.Hidden |> rightStyleValue'
        static member Dotted = FssTypes.Border.Style.Dotted |> rightStyleValue'
        static member Dashed = FssTypes.Border.Style.Dashed |> rightStyleValue'
        static member Solid = FssTypes.Border.Style.Solid |> rightStyleValue'
        static member Double = FssTypes.Border.Style.Double |> rightStyleValue'
        static member Groove = FssTypes.Border.Style.Groove |> rightStyleValue'
        static member Ridge = FssTypes.Border.Style.Ridge |> rightStyleValue'
        static member Inset = FssTypes.Border.Style.Inset |> rightStyleValue'
        static member Outset = FssTypes.Border.Style.Outset |> rightStyleValue'

        static member None = FssTypes.None' |> rightStyleValue'
        static member Inherit = FssTypes.Inherit |> rightStyleValue'
        static member Initial = FssTypes.Initial |> rightStyleValue'
        static member Unset = FssTypes.Unset |> rightStyleValue'

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
    let BorderRightStyle' (style: FssTypes.IBorderStyle) = BorderRightStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomStyle value
    let private bottomStyleValue' value =
        value
        |> styleToString
        |> bottomStyleValue

    type BorderBottomStyle =
        static member Value (style: FssTypes.IBorderStyle) = style |> bottomStyleValue'
        static member Hidden = FssTypes.Border.Style.Hidden |> bottomStyleValue'
        static member Dotted = FssTypes.Border.Style.Dotted |> bottomStyleValue'
        static member Dashed = FssTypes.Border.Style.Dashed |> bottomStyleValue'
        static member Solid = FssTypes.Border.Style.Solid |> bottomStyleValue'
        static member Double = FssTypes.Border.Style.Double |> bottomStyleValue'
        static member Groove = FssTypes.Border.Style.Groove |> bottomStyleValue'
        static member Ridge = FssTypes.Border.Style.Ridge |> bottomStyleValue'
        static member Inset = FssTypes.Border.Style.Inset |> bottomStyleValue'
        static member Outset = FssTypes.Border.Style.Outset |> bottomStyleValue'

        static member None = FssTypes.None' |> bottomStyleValue'
        static member Inherit = FssTypes.Inherit |> bottomStyleValue'
        static member Initial = FssTypes.Initial |> bottomStyleValue'
        static member Unset = FssTypes.Unset |> bottomStyleValue'

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
    let BorderBottomStyle' (style: FssTypes.IBorderStyle) = BorderBottomStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftStyle value
    let private leftStyleValue' value =
        value
        |> styleToString
        |> leftStyleValue

    type BorderLeftStyle =
        static member Value (style: FssTypes.IBorderStyle) = style |> leftStyleValue'
        static member Hidden = FssTypes.Border.Style.Hidden |> leftStyleValue'
        static member Dotted = FssTypes.Border.Style.Dotted |> leftStyleValue'
        static member Dashed = FssTypes.Border.Style.Dashed |> leftStyleValue'
        static member Solid = FssTypes.Border.Style.Solid |> leftStyleValue'
        static member Double = FssTypes.Border.Style.Double |> leftStyleValue'
        static member Groove = FssTypes.Border.Style.Groove |> leftStyleValue'
        static member Ridge = FssTypes.Border.Style.Ridge |> leftStyleValue'
        static member Inset = FssTypes.Border.Style.Inset |> leftStyleValue'
        static member Outset = FssTypes.Border.Style.Outset |> leftStyleValue'

        static member None = FssTypes.None' |> leftStyleValue'
        static member Inherit = FssTypes.Inherit |> leftStyleValue'
        static member Initial = FssTypes.Initial |> leftStyleValue'
        static member Unset = FssTypes.Unset |> leftStyleValue'

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
    let BorderLeftStyle' (style: FssTypes.IBorderStyle) = BorderLeftStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderCollapse value
    let private collapseValue' value =
        value
        |> collapseToString
        |> collapseValue

    type BorderCollapse =
        static member Value (collapse: FssTypes.IBorderCollapse) = collapse |> collapseValue'
        static member Collapse = FssTypes.Border.Collapse |> collapseValue'
        static member Separate = FssTypes.Border.Separate |> collapseValue'

        static member Inherit = FssTypes.Inherit |> collapseValue'
        static member Initial = FssTypes.Initial |> collapseValue'
        static member Unset = FssTypes.Unset |> collapseValue'

    /// <summary>Specifies whether cells inside a table have shared borders.</summary>
    /// <param name="collapse">
    ///     can be:
    ///     - <c> BorderCollapse </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderCollapse' (collapse: FssTypes.IBorderCollapse) =  BorderCollapse.Value(collapse)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    let private imageOutsetValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageOutset value
    let private imageOutsetValue' value =
        value
        |> imageOutsetToString
        |> imageOutsetValue

    type BorderImageOutset =
        static member Value (outset: FssTypes.IBorderImageOutset) = outset |> imageOutsetValue'
        static member Value (vertical: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset) =
            sprintf "%s %s" (imageOutsetToString vertical) (imageOutsetToString horizontal) |> imageOutsetValue
        static member Value (top: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString horizontal)
                (imageOutsetToString bottom)
            |> imageOutsetValue
        static member Value (top: FssTypes.IBorderImageOutset, right: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset, left: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString right)
                (imageOutsetToString bottom)
                (imageOutsetToString left)
            |> imageOutsetValue

        static member Inherit = FssTypes.Inherit |> imageOutsetValue'
        static member Initial = FssTypes.Initial |> imageOutsetValue'
        static member Unset = FssTypes.Unset |> imageOutsetValue'

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
    let BorderImageOutset' (outset: FssTypes.IBorderImageOutset) =  BorderImageOutset.Value(outset)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    let private imageRepeatValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageRepeat value
    let private imageRepeatValue' value =
        value
        |> repeatToString
        |> imageRepeatValue
    type BorderImageRepeat =
        static member Value (repeat: FssTypes.IBorderRepeat) = repeat |> imageRepeatValue'
        static member Value (vertical: FssTypes.IBorderRepeat, horizontal: FssTypes.IBorderRepeat) =
            sprintf "%s %s" (repeatToString vertical) (repeatToString horizontal)
            |> imageRepeatValue
        static member Stretch = FssTypes.Border.ImageRepeat.Stretch |> imageRepeatValue'
        static member Repeat = FssTypes.Border.ImageRepeat.Repeat |> imageRepeatValue'
        static member Round = FssTypes.Border.ImageRepeat.Round |> imageRepeatValue'
        static member Space = FssTypes.Border.ImageRepeat.Space |> imageRepeatValue'

        static member Inherit = FssTypes.Inherit |> imageRepeatValue'
        static member Initial = FssTypes.Initial |> imageRepeatValue'
        static member Unset = FssTypes.Unset |> imageRepeatValue'

    /// <summary>Specifies how border image surrounds border box.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BorderImageRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageRepeat' (repeat: FssTypes.IBorderRepeat) = BorderImageRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSlice value
    let private imageSliceValue' value =
        value
        |> imageSliceToString
        |> imageSliceValue

    type BorderImageSlice =
        static member Fill = FssTypes.Border.ImageSlice.Fill |> imageSliceValue'
        static member Value (imageSlice: FssTypes.IBorderImageSlice) = imageSlice |> imageSliceValue'
        static member Value (vertical: FssTypes.IBorderImageSlice, horizontal: FssTypes.IBorderImageSlice) =
            sprintf "%s %s" (imageSliceToString vertical) (imageSliceToString horizontal) |> imageSliceValue
        static member Value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
            |> imageSliceValue
        static member Value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice, w4: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
                (imageSliceToString w4)
            |> imageSliceValue

        static member Inherit = FssTypes.Inherit |> imageSliceValue'
        static member Initial = FssTypes.Initial |> imageSliceValue'
        static member Unset = FssTypes.Unset |> imageSliceValue'

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
    let BorderImageSlice' (slice: FssTypes.IBorderImageSlice) = BorderImageSlice.Value(slice)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    let private borderColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderColor value
    let private borderColorValue' value =
        value
        |> borderColorToString
        |> borderColorValue

    type BorderColor =
        static member Value (color: FssTypes.IBorderColor) = color |> borderColorValue'
        static member Value (horizontal: FssTypes.IBorderColor, vertical: FssTypes.IBorderColor) =
            sprintf "%s %s"
                (borderColorToString horizontal)
                (borderColorToString vertical)
            |> borderColorValue
        static member Value (top: FssTypes.IBorderColor, vertical: FssTypes.IBorderColor, bottom: FssTypes.IBorderColor) =
            sprintf "%s %s %s"
                (borderColorToString top)
                (borderColorToString vertical)
                (borderColorToString bottom)
            |> borderColorValue
        static member Value (top: FssTypes.IBorderColor, right: FssTypes.IBorderColor, bottom: FssTypes.IBorderColor, left: FssTypes.IBorderColor) =
            sprintf "%s %s %s %s"
                (borderColorToString top)
                (borderColorToString right)
                (borderColorToString bottom)
                (borderColorToString left)
            |> borderColorValue
        static member black = FssTypes.Color.black |> borderColorValue'
        static member silver = FssTypes.Color.silver |> borderColorValue'
        static member gray = FssTypes.Color.gray |> borderColorValue'
        static member white = FssTypes.Color.white |> borderColorValue'
        static member maroon = FssTypes.Color.maroon |> borderColorValue'
        static member red = FssTypes.Color.red |> borderColorValue'
        static member purple = FssTypes.Color.purple |> borderColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> borderColorValue'
        static member green = FssTypes.Color.green |> borderColorValue'
        static member lime = FssTypes.Color.lime |> borderColorValue'
        static member olive = FssTypes.Color.olive |> borderColorValue'
        static member yellow = FssTypes.Color.yellow |> borderColorValue'
        static member navy = FssTypes.Color.navy |> borderColorValue'
        static member blue = FssTypes.Color.blue |> borderColorValue'
        static member teal = FssTypes.Color.teal |> borderColorValue'
        static member aqua = FssTypes.Color.aqua |> borderColorValue'
        static member orange = FssTypes.Color.orange |> borderColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> borderColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> borderColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> borderColorValue'
        static member azure = FssTypes.Color.azure |> borderColorValue'
        static member beige = FssTypes.Color.beige |> borderColorValue'
        static member bisque = FssTypes.Color.bisque |> borderColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> borderColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> borderColorValue'
        static member brown = FssTypes.Color.brown |> borderColorValue'
        static member burlywood = FssTypes.Color.burlywood |> borderColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> borderColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> borderColorValue'
        static member chocolate = FssTypes.Color.chocolate |> borderColorValue'
        static member coral = FssTypes.Color.coral |> borderColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> borderColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> borderColorValue'
        static member crimson = FssTypes.Color.crimson |> borderColorValue'
        static member cyan = FssTypes.Color.cyan |> borderColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> borderColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> borderColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> borderColorValue'
        static member darkGray = FssTypes.Color.darkGray |> borderColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> borderColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> borderColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> borderColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> borderColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> borderColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> borderColorValue'
        static member darkRed = FssTypes.Color.darkRed |> borderColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> borderColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> borderColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> borderColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> borderColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> borderColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> borderColorValue'
        static member deepPink = FssTypes.Color.deepPink |> borderColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> borderColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> borderColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> borderColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> borderColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> borderColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> borderColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> borderColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> borderColorValue'
        static member gold = FssTypes.Color.gold |> borderColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> borderColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> borderColorValue'
        static member grey = FssTypes.Color.grey |> borderColorValue'
        static member honeydew = FssTypes.Color.honeydew |> borderColorValue'
        static member hotPink = FssTypes.Color.hotPink |> borderColorValue'
        static member indianRed = FssTypes.Color.indianRed |> borderColorValue'
        static member indigo = FssTypes.Color.indigo |> borderColorValue'
        static member ivory = FssTypes.Color.ivory |> borderColorValue'
        static member khaki = FssTypes.Color.khaki |> borderColorValue'
        static member lavender = FssTypes.Color.lavender |> borderColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> borderColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> borderColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> borderColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> borderColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> borderColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> borderColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> borderColorValue'
        static member lightGray = FssTypes.Color.lightGray |> borderColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> borderColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> borderColorValue'
        static member lightPink = FssTypes.Color.lightPink |> borderColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> borderColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> borderColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> borderColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> borderColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> borderColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> borderColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> borderColorValue'
        static member linen = FssTypes.Color.linen |> borderColorValue'
        static member magenta = FssTypes.Color.magenta |> borderColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> borderColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> borderColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> borderColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> borderColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> borderColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> borderColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> borderColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> borderColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> borderColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> borderColorValue'
        static member mintCream = FssTypes.Color.mintCream |> borderColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> borderColorValue'
        static member moccasin = FssTypes.Color.moccasin |> borderColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> borderColorValue'
        static member oldLace = FssTypes.Color.oldLace |> borderColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> borderColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> borderColorValue'
        static member orchid = FssTypes.Color.orchid |> borderColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> borderColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> borderColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> borderColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> borderColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> borderColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> borderColorValue'
        static member peru = FssTypes.Color.peru |> borderColorValue'
        static member pink = FssTypes.Color.pink |> borderColorValue'
        static member plum = FssTypes.Color.plum |> borderColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> borderColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> borderColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> borderColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> borderColorValue'
        static member salmon = FssTypes.Color.salmon |> borderColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> borderColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> borderColorValue'
        static member seaShell = FssTypes.Color.seaShell |> borderColorValue'
        static member sienna = FssTypes.Color.sienna |> borderColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> borderColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> borderColorValue'
        static member slateGray = FssTypes.Color.slateGray |> borderColorValue'
        static member snow = FssTypes.Color.snow |> borderColorValue'
        static member springGreen = FssTypes.Color.springGreen |> borderColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> borderColorValue'
        static member tan = FssTypes.Color.tan |> borderColorValue'
        static member thistle = FssTypes.Color.thistle |> borderColorValue'
        static member tomato = FssTypes.Color.tomato |> borderColorValue'
        static member turquoise = FssTypes.Color.turquoise |> borderColorValue'
        static member violet = FssTypes.Color.violet |> borderColorValue'
        static member wheat = FssTypes.Color.wheat |> borderColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> borderColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> borderColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> borderColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> borderColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> borderColorValue'
        static member Hex value = FssTypes.Color.Hex value |> borderColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> borderColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> borderColorValue'
        static member transparent = FssTypes.Color.transparent |> borderColorValue'
        static member currentColor = FssTypes.Color.currentColor |> borderColorValue'

        static member Inherit = FssTypes.Inherit |> borderColorValue'
        static member Initial = FssTypes.Initial |> borderColorValue'
        static member Unset = FssTypes.Unset |> borderColorValue'

    /// <summary>Specifies color of border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderColor' (color: FssTypes.IBorderColor) = BorderColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopColor value
    let private topColorValue' value =
        value
        |> borderColorToString
        |> topColorValue
    type BorderTopColor =
        static member Value (color: FssTypes.IBorderColor) = color |> topColorValue'
        static member black = FssTypes.Color.black |> topColorValue'
        static member silver = FssTypes.Color.silver |> topColorValue'
        static member gray = FssTypes.Color.gray |> topColorValue'
        static member white = FssTypes.Color.white |> topColorValue'
        static member maroon = FssTypes.Color.maroon |> topColorValue'
        static member red = FssTypes.Color.red |> topColorValue'
        static member purple = FssTypes.Color.purple |> topColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> topColorValue'
        static member green = FssTypes.Color.green |> topColorValue'
        static member lime = FssTypes.Color.lime |> topColorValue'
        static member olive = FssTypes.Color.olive |> topColorValue'
        static member yellow = FssTypes.Color.yellow |> topColorValue'
        static member navy = FssTypes.Color.navy |> topColorValue'
        static member blue = FssTypes.Color.blue |> topColorValue'
        static member teal = FssTypes.Color.teal |> topColorValue'
        static member aqua = FssTypes.Color.aqua |> topColorValue'
        static member orange = FssTypes.Color.orange |> topColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> topColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> topColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> topColorValue'
        static member azure = FssTypes.Color.azure |> topColorValue'
        static member beige = FssTypes.Color.beige |> topColorValue'
        static member bisque = FssTypes.Color.bisque |> topColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> topColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> topColorValue'
        static member brown = FssTypes.Color.brown |> topColorValue'
        static member burlywood = FssTypes.Color.burlywood |> topColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> topColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> topColorValue'
        static member chocolate = FssTypes.Color.chocolate |> topColorValue'
        static member coral = FssTypes.Color.coral |> topColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> topColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> topColorValue'
        static member crimson = FssTypes.Color.crimson |> topColorValue'
        static member cyan = FssTypes.Color.cyan |> topColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> topColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> topColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> topColorValue'
        static member darkGray = FssTypes.Color.darkGray |> topColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> topColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> topColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> topColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> topColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> topColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> topColorValue'
        static member darkRed = FssTypes.Color.darkRed |> topColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> topColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> topColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> topColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> topColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> topColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> topColorValue'
        static member deepPink = FssTypes.Color.deepPink |> topColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> topColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> topColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> topColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> topColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> topColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> topColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> topColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> topColorValue'
        static member gold = FssTypes.Color.gold |> topColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> topColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> topColorValue'
        static member grey = FssTypes.Color.grey |> topColorValue'
        static member honeydew = FssTypes.Color.honeydew |> topColorValue'
        static member hotPink = FssTypes.Color.hotPink |> topColorValue'
        static member indianRed = FssTypes.Color.indianRed |> topColorValue'
        static member indigo = FssTypes.Color.indigo |> topColorValue'
        static member ivory = FssTypes.Color.ivory |> topColorValue'
        static member khaki = FssTypes.Color.khaki |> topColorValue'
        static member lavender = FssTypes.Color.lavender |> topColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> topColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> topColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> topColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> topColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> topColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> topColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> topColorValue'
        static member lightGray = FssTypes.Color.lightGray |> topColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> topColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> topColorValue'
        static member lightPink = FssTypes.Color.lightPink |> topColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> topColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> topColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> topColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> topColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> topColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> topColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> topColorValue'
        static member linen = FssTypes.Color.linen |> topColorValue'
        static member magenta = FssTypes.Color.magenta |> topColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> topColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> topColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> topColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> topColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> topColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> topColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> topColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> topColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> topColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> topColorValue'
        static member mintCream = FssTypes.Color.mintCream |> topColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> topColorValue'
        static member moccasin = FssTypes.Color.moccasin |> topColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> topColorValue'
        static member oldLace = FssTypes.Color.oldLace |> topColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> topColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> topColorValue'
        static member orchid = FssTypes.Color.orchid |> topColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> topColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> topColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> topColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> topColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> topColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> topColorValue'
        static member peru = FssTypes.Color.peru |> topColorValue'
        static member pink = FssTypes.Color.pink |> topColorValue'
        static member plum = FssTypes.Color.plum |> topColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> topColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> topColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> topColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> topColorValue'
        static member salmon = FssTypes.Color.salmon |> topColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> topColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> topColorValue'
        static member seaShell = FssTypes.Color.seaShell |> topColorValue'
        static member sienna = FssTypes.Color.sienna |> topColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> topColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> topColorValue'
        static member slateGray = FssTypes.Color.slateGray |> topColorValue'
        static member snow = FssTypes.Color.snow |> topColorValue'
        static member springGreen = FssTypes.Color.springGreen |> topColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> topColorValue'
        static member tan = FssTypes.Color.tan |> topColorValue'
        static member thistle = FssTypes.Color.thistle |> topColorValue'
        static member tomato = FssTypes.Color.tomato |> topColorValue'
        static member turquoise = FssTypes.Color.turquoise |> topColorValue'
        static member violet = FssTypes.Color.violet |> topColorValue'
        static member wheat = FssTypes.Color.wheat |> topColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> topColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> topColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> topColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> topColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> topColorValue'
        static member Hex value = FssTypes.Color.Hex value |> topColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> topColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> topColorValue'
        static member transparent = FssTypes.Color.transparent |> topColorValue'
        static member currentColor = FssTypes.Color.currentColor |> topColorValue'

        static member Inherit = FssTypes.Inherit |> topColorValue'
        static member Initial = FssTypes.Initial |> topColorValue'
        static member Unset = FssTypes.Unset |> topColorValue'

    /// <summary>Specifies color of top border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopColor' (color: FssTypes.IBorderColor) = BorderTopColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightColor value
    let private rightColorValue' value =
        value
        |> borderColorToString
        |> rightColorValue
    type BorderRightColor =
        static member Value (color: FssTypes.IBorderColor) = color |> rightColorValue'
        static member black = FssTypes.Color.black |> rightColorValue'
        static member silver = FssTypes.Color.silver |> rightColorValue'
        static member gray = FssTypes.Color.gray |> rightColorValue'
        static member white = FssTypes.Color.white |> rightColorValue'
        static member maroon = FssTypes.Color.maroon |> rightColorValue'
        static member red = FssTypes.Color.red |> rightColorValue'
        static member purple = FssTypes.Color.purple |> rightColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> rightColorValue'
        static member green = FssTypes.Color.green |> rightColorValue'
        static member lime = FssTypes.Color.lime |> rightColorValue'
        static member olive = FssTypes.Color.olive |> rightColorValue'
        static member yellow = FssTypes.Color.yellow |> rightColorValue'
        static member navy = FssTypes.Color.navy |> rightColorValue'
        static member blue = FssTypes.Color.blue |> rightColorValue'
        static member teal = FssTypes.Color.teal |> rightColorValue'
        static member aqua = FssTypes.Color.aqua |> rightColorValue'
        static member orange = FssTypes.Color.orange |> rightColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> rightColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> rightColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> rightColorValue'
        static member azure = FssTypes.Color.azure |> rightColorValue'
        static member beige = FssTypes.Color.beige |> rightColorValue'
        static member bisque = FssTypes.Color.bisque |> rightColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> rightColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> rightColorValue'
        static member brown = FssTypes.Color.brown |> rightColorValue'
        static member burlywood = FssTypes.Color.burlywood |> rightColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> rightColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> rightColorValue'
        static member chocolate = FssTypes.Color.chocolate |> rightColorValue'
        static member coral = FssTypes.Color.coral |> rightColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> rightColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> rightColorValue'
        static member crimson = FssTypes.Color.crimson |> rightColorValue'
        static member cyan = FssTypes.Color.cyan |> rightColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> rightColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> rightColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> rightColorValue'
        static member darkGray = FssTypes.Color.darkGray |> rightColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> rightColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> rightColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> rightColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> rightColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> rightColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> rightColorValue'
        static member darkRed = FssTypes.Color.darkRed |> rightColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> rightColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> rightColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> rightColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> rightColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> rightColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> rightColorValue'
        static member deepPink = FssTypes.Color.deepPink |> rightColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> rightColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> rightColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> rightColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> rightColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> rightColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> rightColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> rightColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> rightColorValue'
        static member gold = FssTypes.Color.gold |> rightColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> rightColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> rightColorValue'
        static member grey = FssTypes.Color.grey |> rightColorValue'
        static member honeydew = FssTypes.Color.honeydew |> rightColorValue'
        static member hotPink = FssTypes.Color.hotPink |> rightColorValue'
        static member indianRed = FssTypes.Color.indianRed |> rightColorValue'
        static member indigo = FssTypes.Color.indigo |> rightColorValue'
        static member ivory = FssTypes.Color.ivory |> rightColorValue'
        static member khaki = FssTypes.Color.khaki |> rightColorValue'
        static member lavender = FssTypes.Color.lavender |> rightColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> rightColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> rightColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> rightColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> rightColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> rightColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> rightColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> rightColorValue'
        static member lightGray = FssTypes.Color.lightGray |> rightColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> rightColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> rightColorValue'
        static member lightPink = FssTypes.Color.lightPink |> rightColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> rightColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> rightColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> rightColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> rightColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> rightColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> rightColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> rightColorValue'
        static member linen = FssTypes.Color.linen |> rightColorValue'
        static member magenta = FssTypes.Color.magenta |> rightColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> rightColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> rightColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> rightColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> rightColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> rightColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> rightColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> rightColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> rightColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> rightColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> rightColorValue'
        static member mintCream = FssTypes.Color.mintCream |> rightColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> rightColorValue'
        static member moccasin = FssTypes.Color.moccasin |> rightColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> rightColorValue'
        static member oldLace = FssTypes.Color.oldLace |> rightColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> rightColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> rightColorValue'
        static member orchid = FssTypes.Color.orchid |> rightColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> rightColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> rightColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> rightColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> rightColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> rightColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> rightColorValue'
        static member peru = FssTypes.Color.peru |> rightColorValue'
        static member pink = FssTypes.Color.pink |> rightColorValue'
        static member plum = FssTypes.Color.plum |> rightColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> rightColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> rightColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> rightColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> rightColorValue'
        static member salmon = FssTypes.Color.salmon |> rightColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> rightColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> rightColorValue'
        static member seaShell = FssTypes.Color.seaShell |> rightColorValue'
        static member sienna = FssTypes.Color.sienna |> rightColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> rightColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> rightColorValue'
        static member slateGray = FssTypes.Color.slateGray |> rightColorValue'
        static member snow = FssTypes.Color.snow |> rightColorValue'
        static member springGreen = FssTypes.Color.springGreen |> rightColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> rightColorValue'
        static member tan = FssTypes.Color.tan |> rightColorValue'
        static member thistle = FssTypes.Color.thistle |> rightColorValue'
        static member tomato = FssTypes.Color.tomato |> rightColorValue'
        static member turquoise = FssTypes.Color.turquoise |> rightColorValue'
        static member violet = FssTypes.Color.violet |> rightColorValue'
        static member wheat = FssTypes.Color.wheat |> rightColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> rightColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> rightColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> rightColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> rightColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> rightColorValue'
        static member Hex value = FssTypes.Color.Hex value |> rightColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> rightColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> rightColorValue'
        static member transparent = FssTypes.Color.transparent |> rightColorValue'
        static member currentColor = FssTypes.Color.currentColor |> rightColorValue'

        static member Inherit = FssTypes.Inherit |> rightColorValue'
        static member Initial = FssTypes.Initial |> rightColorValue'
        static member Unset = FssTypes.Unset |> rightColorValue'

    /// <summary>Specifies color of right border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightColor' (color: FssTypes.IBorderColor) = BorderRightColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomColor value
    let private bottomColorValue' value =
        value
        |> borderColorToString
        |> bottomColorValue
    type BorderBottomColor =
        static member Value (color: FssTypes.IBorderColor) = color |> bottomColorValue'
        static member black = FssTypes.Color.black |> bottomColorValue'
        static member silver = FssTypes.Color.silver |> bottomColorValue'
        static member gray = FssTypes.Color.gray |> bottomColorValue'
        static member white = FssTypes.Color.white |> bottomColorValue'
        static member maroon = FssTypes.Color.maroon |> bottomColorValue'
        static member red = FssTypes.Color.red |> bottomColorValue'
        static member purple = FssTypes.Color.purple |> bottomColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> bottomColorValue'
        static member green = FssTypes.Color.green |> bottomColorValue'
        static member lime = FssTypes.Color.lime |> bottomColorValue'
        static member olive = FssTypes.Color.olive |> bottomColorValue'
        static member yellow = FssTypes.Color.yellow |> bottomColorValue'
        static member navy = FssTypes.Color.navy |> bottomColorValue'
        static member blue = FssTypes.Color.blue |> bottomColorValue'
        static member teal = FssTypes.Color.teal |> bottomColorValue'
        static member aqua = FssTypes.Color.aqua |> bottomColorValue'
        static member orange = FssTypes.Color.orange |> bottomColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> bottomColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> bottomColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> bottomColorValue'
        static member azure = FssTypes.Color.azure |> bottomColorValue'
        static member beige = FssTypes.Color.beige |> bottomColorValue'
        static member bisque = FssTypes.Color.bisque |> bottomColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> bottomColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> bottomColorValue'
        static member brown = FssTypes.Color.brown |> bottomColorValue'
        static member burlywood = FssTypes.Color.burlywood |> bottomColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> bottomColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> bottomColorValue'
        static member chocolate = FssTypes.Color.chocolate |> bottomColorValue'
        static member coral = FssTypes.Color.coral |> bottomColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> bottomColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> bottomColorValue'
        static member crimson = FssTypes.Color.crimson |> bottomColorValue'
        static member cyan = FssTypes.Color.cyan |> bottomColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> bottomColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> bottomColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> bottomColorValue'
        static member darkGray = FssTypes.Color.darkGray |> bottomColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> bottomColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> bottomColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> bottomColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> bottomColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> bottomColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> bottomColorValue'
        static member darkRed = FssTypes.Color.darkRed |> bottomColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> bottomColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> bottomColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> bottomColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> bottomColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> bottomColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> bottomColorValue'
        static member deepPink = FssTypes.Color.deepPink |> bottomColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> bottomColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> bottomColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> bottomColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> bottomColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> bottomColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> bottomColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> bottomColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> bottomColorValue'
        static member gold = FssTypes.Color.gold |> bottomColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> bottomColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> bottomColorValue'
        static member grey = FssTypes.Color.grey |> bottomColorValue'
        static member honeydew = FssTypes.Color.honeydew |> bottomColorValue'
        static member hotPink = FssTypes.Color.hotPink |> bottomColorValue'
        static member indianRed = FssTypes.Color.indianRed |> bottomColorValue'
        static member indigo = FssTypes.Color.indigo |> bottomColorValue'
        static member ivory = FssTypes.Color.ivory |> bottomColorValue'
        static member khaki = FssTypes.Color.khaki |> bottomColorValue'
        static member lavender = FssTypes.Color.lavender |> bottomColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> bottomColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> bottomColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> bottomColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> bottomColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> bottomColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> bottomColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> bottomColorValue'
        static member lightGray = FssTypes.Color.lightGray |> bottomColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> bottomColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> bottomColorValue'
        static member lightPink = FssTypes.Color.lightPink |> bottomColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> bottomColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> bottomColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> bottomColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> bottomColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> bottomColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> bottomColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> bottomColorValue'
        static member linen = FssTypes.Color.linen |> bottomColorValue'
        static member magenta = FssTypes.Color.magenta |> bottomColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> bottomColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> bottomColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> bottomColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> bottomColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> bottomColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> bottomColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> bottomColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> bottomColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> bottomColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> bottomColorValue'
        static member mintCream = FssTypes.Color.mintCream |> bottomColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> bottomColorValue'
        static member moccasin = FssTypes.Color.moccasin |> bottomColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> bottomColorValue'
        static member oldLace = FssTypes.Color.oldLace |> bottomColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> bottomColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> bottomColorValue'
        static member orchid = FssTypes.Color.orchid |> bottomColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> bottomColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> bottomColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> bottomColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> bottomColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> bottomColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> bottomColorValue'
        static member peru = FssTypes.Color.peru |> bottomColorValue'
        static member pink = FssTypes.Color.pink |> bottomColorValue'
        static member plum = FssTypes.Color.plum |> bottomColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> bottomColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> bottomColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> bottomColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> bottomColorValue'
        static member salmon = FssTypes.Color.salmon |> bottomColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> bottomColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> bottomColorValue'
        static member seaShell = FssTypes.Color.seaShell |> bottomColorValue'
        static member sienna = FssTypes.Color.sienna |> bottomColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> bottomColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> bottomColorValue'
        static member slateGray = FssTypes.Color.slateGray |> bottomColorValue'
        static member snow = FssTypes.Color.snow |> bottomColorValue'
        static member springGreen = FssTypes.Color.springGreen |> bottomColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> bottomColorValue'
        static member tan = FssTypes.Color.tan |> bottomColorValue'
        static member thistle = FssTypes.Color.thistle |> bottomColorValue'
        static member tomato = FssTypes.Color.tomato |> bottomColorValue'
        static member turquoise = FssTypes.Color.turquoise |> bottomColorValue'
        static member violet = FssTypes.Color.violet |> bottomColorValue'
        static member wheat = FssTypes.Color.wheat |> bottomColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> bottomColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> bottomColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> bottomColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> bottomColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> bottomColorValue'
        static member Hex value = FssTypes.Color.Hex value |> bottomColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> bottomColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> bottomColorValue'
        static member transparent = FssTypes.Color.transparent |> bottomColorValue'
        static member currentColor = FssTypes.Color.currentColor |> bottomColorValue'

        static member Inherit = FssTypes.Inherit |> bottomColorValue'
        static member Initial = FssTypes.Initial |> bottomColorValue'
        static member Unset = FssTypes.Unset |> bottomColorValue'

    /// <summary>Specifies color of bottom border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomColor' (color: FssTypes.IBorderColor) = BorderBottomColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftColor value
    let private leftColorValue' value =
        value
        |> borderColorToString
        |> leftColorValue
    type BorderLeftColor =
        static member Value (color: FssTypes.IBorderColor) = color |> leftColorValue'
        static member black = FssTypes.Color.black |> leftColorValue'
        static member silver = FssTypes.Color.silver |> leftColorValue'
        static member gray = FssTypes.Color.gray |> leftColorValue'
        static member white = FssTypes.Color.white |> leftColorValue'
        static member maroon = FssTypes.Color.maroon |> leftColorValue'
        static member red = FssTypes.Color.red |> leftColorValue'
        static member purple = FssTypes.Color.purple |> leftColorValue'
        static member fuchsia = FssTypes.Color.fuchsia |> leftColorValue'
        static member green = FssTypes.Color.green |> leftColorValue'
        static member lime = FssTypes.Color.lime |> leftColorValue'
        static member olive = FssTypes.Color.olive |> leftColorValue'
        static member yellow = FssTypes.Color.yellow |> leftColorValue'
        static member navy = FssTypes.Color.navy |> leftColorValue'
        static member blue = FssTypes.Color.blue |> leftColorValue'
        static member teal = FssTypes.Color.teal |> leftColorValue'
        static member aqua = FssTypes.Color.aqua |> leftColorValue'
        static member orange = FssTypes.Color.orange |> leftColorValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> leftColorValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> leftColorValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> leftColorValue'
        static member azure = FssTypes.Color.azure |> leftColorValue'
        static member beige = FssTypes.Color.beige |> leftColorValue'
        static member bisque = FssTypes.Color.bisque |> leftColorValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> leftColorValue'
        static member blueViolet = FssTypes.Color.blueViolet |> leftColorValue'
        static member brown = FssTypes.Color.brown |> leftColorValue'
        static member burlywood = FssTypes.Color.burlywood |> leftColorValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> leftColorValue'
        static member chartreuse = FssTypes.Color.chartreuse |> leftColorValue'
        static member chocolate = FssTypes.Color.chocolate |> leftColorValue'
        static member coral = FssTypes.Color.coral |> leftColorValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> leftColorValue'
        static member cornsilk = FssTypes.Color.cornsilk |> leftColorValue'
        static member crimson = FssTypes.Color.crimson |> leftColorValue'
        static member cyan = FssTypes.Color.cyan |> leftColorValue'
        static member darkBlue = FssTypes.Color.darkBlue |> leftColorValue'
        static member darkCyan = FssTypes.Color.darkCyan |> leftColorValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> leftColorValue'
        static member darkGray = FssTypes.Color.darkGray |> leftColorValue'
        static member darkGreen = FssTypes.Color.darkGreen |> leftColorValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> leftColorValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> leftColorValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> leftColorValue'
        static member darkOrange = FssTypes.Color.darkOrange |> leftColorValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> leftColorValue'
        static member darkRed = FssTypes.Color.darkRed |> leftColorValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> leftColorValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> leftColorValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> leftColorValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> leftColorValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> leftColorValue'
        static member darkViolet = FssTypes.Color.darkViolet |> leftColorValue'
        static member deepPink = FssTypes.Color.deepPink |> leftColorValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> leftColorValue'
        static member dimGrey = FssTypes.Color.dimGrey |> leftColorValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> leftColorValue'
        static member fireBrick = FssTypes.Color.fireBrick |> leftColorValue'
        static member floralWhite = FssTypes.Color.floralWhite |> leftColorValue'
        static member forestGreen = FssTypes.Color.forestGreen |> leftColorValue'
        static member gainsboro = FssTypes.Color.gainsboro |> leftColorValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> leftColorValue'
        static member gold = FssTypes.Color.gold |> leftColorValue'
        static member goldenrod = FssTypes.Color.goldenrod |> leftColorValue'
        static member greenYellow = FssTypes.Color.greenYellow |> leftColorValue'
        static member grey = FssTypes.Color.grey |> leftColorValue'
        static member honeydew = FssTypes.Color.honeydew |> leftColorValue'
        static member hotPink = FssTypes.Color.hotPink |> leftColorValue'
        static member indianRed = FssTypes.Color.indianRed |> leftColorValue'
        static member indigo = FssTypes.Color.indigo |> leftColorValue'
        static member ivory = FssTypes.Color.ivory |> leftColorValue'
        static member khaki = FssTypes.Color.khaki |> leftColorValue'
        static member lavender = FssTypes.Color.lavender |> leftColorValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> leftColorValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> leftColorValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> leftColorValue'
        static member lightBlue = FssTypes.Color.lightBlue |> leftColorValue'
        static member lightCoral = FssTypes.Color.lightCoral |> leftColorValue'
        static member lightCyan = FssTypes.Color.lightCyan |> leftColorValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> leftColorValue'
        static member lightGray = FssTypes.Color.lightGray |> leftColorValue'
        static member lightGreen = FssTypes.Color.lightGreen |> leftColorValue'
        static member lightGrey = FssTypes.Color.lightGrey |> leftColorValue'
        static member lightPink = FssTypes.Color.lightPink |> leftColorValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> leftColorValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> leftColorValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> leftColorValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> leftColorValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> leftColorValue'
        static member lightYellow = FssTypes.Color.lightYellow |> leftColorValue'
        static member limeGreen = FssTypes.Color.limeGreen |> leftColorValue'
        static member linen = FssTypes.Color.linen |> leftColorValue'
        static member magenta = FssTypes.Color.magenta |> leftColorValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> leftColorValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> leftColorValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> leftColorValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> leftColorValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> leftColorValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> leftColorValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> leftColorValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> leftColorValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> leftColorValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> leftColorValue'
        static member mintCream = FssTypes.Color.mintCream |> leftColorValue'
        static member mistyRose = FssTypes.Color.mistyRose |> leftColorValue'
        static member moccasin = FssTypes.Color.moccasin |> leftColorValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> leftColorValue'
        static member oldLace = FssTypes.Color.oldLace |> leftColorValue'
        static member olivedrab = FssTypes.Color.olivedrab |> leftColorValue'
        static member orangeRed = FssTypes.Color.orangeRed |> leftColorValue'
        static member orchid = FssTypes.Color.orchid |> leftColorValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> leftColorValue'
        static member paleGreen = FssTypes.Color.paleGreen |> leftColorValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> leftColorValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> leftColorValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> leftColorValue'
        static member peachpuff = FssTypes.Color.peachpuff |> leftColorValue'
        static member peru = FssTypes.Color.peru |> leftColorValue'
        static member pink = FssTypes.Color.pink |> leftColorValue'
        static member plum = FssTypes.Color.plum |> leftColorValue'
        static member powderBlue = FssTypes.Color.powderBlue |> leftColorValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> leftColorValue'
        static member royalBlue = FssTypes.Color.royalBlue |> leftColorValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> leftColorValue'
        static member salmon = FssTypes.Color.salmon |> leftColorValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> leftColorValue'
        static member seaGreen = FssTypes.Color.seaGreen |> leftColorValue'
        static member seaShell = FssTypes.Color.seaShell |> leftColorValue'
        static member sienna = FssTypes.Color.sienna |> leftColorValue'
        static member skyBlue = FssTypes.Color.skyBlue |> leftColorValue'
        static member slateBlue = FssTypes.Color.slateBlue |> leftColorValue'
        static member slateGray = FssTypes.Color.slateGray |> leftColorValue'
        static member snow = FssTypes.Color.snow |> leftColorValue'
        static member springGreen = FssTypes.Color.springGreen |> leftColorValue'
        static member steelBlue = FssTypes.Color.steelBlue |> leftColorValue'
        static member tan = FssTypes.Color.tan |> leftColorValue'
        static member thistle = FssTypes.Color.thistle |> leftColorValue'
        static member tomato = FssTypes.Color.tomato |> leftColorValue'
        static member turquoise = FssTypes.Color.turquoise |> leftColorValue'
        static member violet = FssTypes.Color.violet |> leftColorValue'
        static member wheat = FssTypes.Color.wheat |> leftColorValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> leftColorValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> leftColorValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> leftColorValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> leftColorValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> leftColorValue'
        static member Hex value = FssTypes.Color.Hex value |> leftColorValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> leftColorValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> leftColorValue'
        static member transparent = FssTypes.Color.transparent |> leftColorValue'
        static member currentColor = FssTypes.Color.currentColor |> leftColorValue'

        static member Inherit = FssTypes.Inherit |> leftColorValue'
        static member Initial = FssTypes.Initial |> leftColorValue'
        static member Unset = FssTypes.Unset |> leftColorValue'

    /// <summary>Specifies color of left border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftColor' (color: FssTypes.IBorderColor) = BorderLeftColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    let private spacingValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderSpacing value
    let private spacingValue' value =
        value
        |> spacingToString
        |> spacingValue
    type BorderSpacing =
        static member Value (width: FssTypes.IBorderSpacing) =
            spacingValue (spacingToString width)
        static member Value (w1: FssTypes.IBorderSpacing, w2: FssTypes.IBorderSpacing) =
            sprintf "%s %s"
                (spacingToString w1)
                (spacingToString w2)
            |> spacingValue
        static member Inherit = FssTypes.Inherit |> spacingValue'
        static member Initial = FssTypes.Initial |> spacingValue'
        static member Unset = FssTypes.Unset |> spacingValue'

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
    let BorderSpacing' (spacing: FssTypes.IBorderSpacing) = BorderSpacing.Value(spacing)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let private imageWidthValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageWidth value
    let private imageWidthValue' value =
        value
        |> imageWidthToString
        |> imageWidthValue
    type BorderImageWidth =
        static member Value (width: FssTypes.IBorderImageWidth) = width |> imageWidthValue'
        static member Value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth) =
            sprintf "%s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
            |> imageWidthValue
        static member Value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
            |> imageWidthValue
        static member Value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth, w4: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
                (imageWidthToString w4)
            |> imageWidthValue

        static member Auto = FssTypes.Auto |> imageWidthValue'
        static member Inherit = FssTypes.Inherit |> imageWidthValue'
        static member Initial = FssTypes.Initial |> imageWidthValue'
        static member Unset = FssTypes.Unset |> imageWidthValue'

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
    let BorderImageWidth' (width: FssTypes.IBorderImageWidth) = BorderImageWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    let private imageValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSource value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type BorderImageSource =
        static member Value (source: FssTypes.IBorderImageSource) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType * FssTypes.Percent) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType * FssTypes.Size) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = FssTypes.None' |> imageValue'
        static member Inherit = FssTypes.Inherit |> imageValue'
        static member Initial = FssTypes.Initial |> imageValue'
        static member Unset = FssTypes.Unset |> imageValue'

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
    let BorderImageSource' (source: FssTypes.IBorderImageSource) = BorderImageSource.Value(source)