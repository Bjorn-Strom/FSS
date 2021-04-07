namespace Fss

open Fable.Core

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
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
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
    let private borderValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Border
    let private borderValue' = borderToString >> borderValue

    [<Erase>]
    type Border =
        static member value (border: FssTypes.IBorder) = border |> borderValue'
        static member none = FssTypes.None' |> borderValue'
        static member inherit' = FssTypes.Inherit |> borderValue'
        static member initial = FssTypes.Initial |> borderValue'
        static member unset = FssTypes.Unset |> borderValue'

    /// <summary>Resets border.</summary>
    /// <param name="border">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Border' = Border.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius
    let private radiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRadius
    let private radiusValue' = radiusToString >> radiusValue

    [<Erase>]
    type BorderRadius =
        static member value (radius: FssTypes.IBorderRadius) =
            sprintf "%s"
                (radiusToString radius)
                |> radiusValue
        static member value (topLeftBottomRight: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s"
                (radiusToString topLeftBottomRight)
                (radiusToString topRightBottomLeft)
                |> radiusValue
        static member value (topLeft: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius) =
            sprintf "%s %s %s"
                (radiusToString topLeft)
                (radiusToString topRightBottomLeft)
                (radiusToString bottomRight)
                |> radiusValue
        static member value (topLeft: FssTypes.IBorderRadius, topRight: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius, bottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s %s %s"
                (radiusToString topLeft)
                (radiusToString topRight)
                (radiusToString bottomRight)
                (radiusToString bottomLeft)
                |> radiusValue

        static member inherit' = FssTypes.Inherit |> radiusValue'
        static member initial = FssTypes.Initial |> radiusValue'
        static member unset = FssTypes.Unset |> radiusValue'

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
    let BorderRadius' = BorderRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-left-radius
    let private bottomLeftRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomLeftRadius
    let private bottomLeftRadiusValue' = radiusToString >> bottomLeftRadiusValue

    [<Erase>]
    type BorderBottomLeftRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomLeftRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomLeftRadiusValue
        static member inherit' = FssTypes.Inherit |> bottomLeftRadiusValue'
        static member initial = FssTypes.Initial |> bottomLeftRadiusValue'
        static member unset = FssTypes.Unset |> bottomLeftRadiusValue'

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
    let BorderBottomLeftRadius' = BorderBottomLeftRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-right-radius
    let private bottomRightRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomRightRadius
    let private bottomRightRadiusValue' = radiusToString >> bottomRightRadiusValue
    [<Erase>]
    type BorderBottomRightRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomRightRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomRightRadiusValue
        static member inherit' = FssTypes.Inherit |> bottomRightRadiusValue'
        static member initial = FssTypes.Initial |> bottomRightRadiusValue'
        static member unset = FssTypes.Unset |> bottomRightRadiusValue'

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
    let BorderBottomRightRadius' = BorderBottomRightRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-left-radius
    let private topLeftRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopLeftRadius
    let private topLeftRadiusValue' = radiusToString >> topLeftRadiusValue
    [<Erase>]
    type BorderTopLeftRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topLeftRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topLeftRadiusValue
        static member inherit' = FssTypes.Inherit |> topLeftRadiusValue'
        static member initial = FssTypes.Initial |> topLeftRadiusValue'
        static member unset = FssTypes.Unset |> topLeftRadiusValue'

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
    let BorderTopLeftRadius' = BorderTopLeftRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-right-radius
    let private topRightRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopRightRadius
    let private topRightRadiusValue' = radiusToString >> topRightRadiusValue
    [<Erase>]
    type BorderTopRightRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topRightRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topRightRadiusValue
        static member inherit' = FssTypes.Inherit |> topRightRadiusValue'
        static member initial = FssTypes.Initial |> topRightRadiusValue'
        static member unset = FssTypes.Unset |> topRightRadiusValue'

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
    let BorderTopRightRadius' = BorderTopRightRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    let private widthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderWidth
    let private widthValue': (FssTypes.IBorderWidth -> FssTypes.CssProperty) = widthToString >> widthValue

    [<Erase>]
    type BorderWidth =
        static member value (width: FssTypes.IBorderWidth) = widthValue (widthToString width)
        static member value (vertical: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth) =
            sprintf "%s %s"
                (widthToString vertical)
                (widthToString horizontal)
            |> widthValue
        static member value (top: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth) =
            sprintf "%s %s %s"
                (widthToString top)
                (widthToString horizontal)
                (widthToString bottom)
            |> widthValue
        static member value (top: FssTypes.IBorderWidth, right: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth, left: FssTypes.IBorderWidth) =
            sprintf "%s %s %s %s"
                (widthToString top)
                (widthToString right)
                (widthToString bottom)
                (widthToString left)
            |> widthValue

        static member thin = FssTypes.Border.Width.Thin |> widthValue'
        static member medium = FssTypes.Border.Width.Medium |> widthValue'
        static member thick = FssTypes.Border.Width.Thick |> widthValue'

        static member inherit' = FssTypes.Inherit |> widthValue'
        static member initial = FssTypes.Initial |> widthValue'
        static member unset = FssTypes.Unset |> widthValue'

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
    let BorderWidth' = BorderWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let internal topWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopWidth
    let internal topWidthValue' = widthToString >> topWidthValue
    let BorderTopWidth = FssTypes.Border.BorderValue(topWidthValue')

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
    let BorderTopWidth' = BorderTopWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightWidth
    let private rightWidthValue' = widthToString >> rightWidthValue
    let BorderRightWidth = FssTypes.Border.BorderValue(rightWidthValue')
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
    let BorderRightWidth' = BorderRightWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomWidth
    let private bottomWidthValue' = widthToString >> bottomWidthValue
    let BorderBottomWidth = FssTypes.Border.BorderValue(bottomWidthValue')

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
    let BorderBottomWidth' = BorderBottomWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftWidth
    let private leftWidthValue' = widthToString >> leftWidthValue
    let BorderLeftWidth = FssTypes.Border.BorderValue(leftWidthValue')
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
    let BorderLeftWidth' = BorderLeftWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderStyle
    let private styleValue' = styleToString >> styleValue

    [<Erase>]
    type BorderStyle =
        static member value (style: FssTypes.IBorderStyle) = style |> styleValue'
        static member value (vertical: FssTypes.IBorderStyle, horizontal: FssTypes.IBorderStyle) =
            sprintf "%s %s"
                (styleToString vertical)
                (styleToString horizontal)
            |> styleValue
        static member value (top: FssTypes.IBorderStyle, horizontal: FssTypes.IBorderStyle, bottom: FssTypes.IBorderStyle) =
            sprintf "%s %s %s"
                (styleToString top)
                (styleToString horizontal)
                (styleToString bottom)
            |> styleValue
        static member value (top: FssTypes.IBorderStyle, right: FssTypes.IBorderStyle, bottom: FssTypes.IBorderStyle, left: FssTypes.IBorderStyle) =
            sprintf "%s %s %s %s"
                (styleToString top)
                (styleToString right)
                (styleToString bottom)
                (styleToString left)
            |> styleValue

        static member hidden = FssTypes.Border.Style.Hidden |> styleValue'
        static member dotted = FssTypes.Border.Style.Dotted |> styleValue'
        static member dashed = FssTypes.Border.Style.Dashed |> styleValue'
        static member solid = FssTypes.Border.Style.Solid |> styleValue'
        static member double = FssTypes.Border.Style.Double |> styleValue'
        static member groove = FssTypes.Border.Style.Groove |> styleValue'
        static member ridge = FssTypes.Border.Style.Ridge |> styleValue'
        static member inset = FssTypes.Border.Style.Inset |> styleValue'
        static member outset = FssTypes.Border.Style.Outset |> styleValue'

        static member none = FssTypes.None' |> styleValue'
        static member inherit' = FssTypes.Inherit |> styleValue'
        static member initial = FssTypes.Initial |> styleValue'
        static member unset = FssTypes.Unset |> styleValue'

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
    let BorderStyle' = BorderStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopStyle
    let private topStyleValue' = styleToString >> topStyleValue

    let BorderTopStyle = FssTypes.Border.BorderStyle(topStyleValue')

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
    let BorderTopStyle' = BorderTopStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightStyle
    let private rightStyleValue' = styleToString >> rightStyleValue

    let BorderRightStyle = FssTypes.Border.BorderStyle(rightStyleValue')

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
    let BorderRightStyle' = BorderRightStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomStyle
    let private bottomStyleValue' = styleToString >> bottomStyleValue

    let BorderBottomStyle = FssTypes.Border.BorderStyle(bottomStyleValue')

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
    let BorderBottomStyle' = BorderBottomStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftStyle
    let private leftStyleValue' = styleToString >> leftStyleValue

    let BorderLeftStyle = FssTypes.Border.BorderStyle(leftStyleValue')

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
    let BorderLeftStyle' = BorderLeftStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderCollapse
    let private collapseValue' = collapseToString >> collapseValue

    [<Erase>]
    type BorderCollapse =
        static member value (collapse: FssTypes.IBorderCollapse) = collapse |> collapseValue'
        static member collapse = FssTypes.Border.Collapse |> collapseValue'
        static member separate = FssTypes.Border.Separate |> collapseValue'

        static member inherit' = FssTypes.Inherit |> collapseValue'
        static member initial = FssTypes.Initial |> collapseValue'
        static member unset = FssTypes.Unset |> collapseValue'

    /// <summary>Specifies whether cells inside a table have shared borders.</summary>
    /// <param name="collapse">
    ///     can be:
    ///     - <c> BorderCollapse </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderCollapse' =  BorderCollapse.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    let private imageOutsetValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageOutset
    let private imageOutsetValue' = imageOutsetToString >> imageOutsetValue

    [<Erase>]
    type BorderImageOutset =
        static member value (outset: FssTypes.IBorderImageOutset) = outset |> imageOutsetValue'
        static member value (vertical: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset) =
            sprintf "%s %s" (imageOutsetToString vertical) (imageOutsetToString horizontal) |> imageOutsetValue
        static member value (top: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString horizontal)
                (imageOutsetToString bottom)
            |> imageOutsetValue
        static member value (top: FssTypes.IBorderImageOutset, right: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset, left: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString right)
                (imageOutsetToString bottom)
                (imageOutsetToString left)
            |> imageOutsetValue

        static member inherit' = FssTypes.Inherit |> imageOutsetValue'
        static member initial = FssTypes.Initial |> imageOutsetValue'
        static member unset = FssTypes.Unset |> imageOutsetValue'

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
    let BorderImageOutset' = BorderImageOutset.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    let private imageRepeatValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageRepeat
    let private imageRepeatValue' = repeatToString >> imageRepeatValue
    [<Erase>]
    type BorderImageRepeat =
        static member value (repeat: FssTypes.IBorderRepeat) = repeat |> imageRepeatValue'
        static member value (vertical: FssTypes.IBorderRepeat, horizontal: FssTypes.IBorderRepeat) =
            sprintf "%s %s" (repeatToString vertical) (repeatToString horizontal)
            |> imageRepeatValue
        static member stretch = FssTypes.Border.ImageRepeat.Stretch |> imageRepeatValue'
        static member repeat = FssTypes.Border.ImageRepeat.Repeat |> imageRepeatValue'
        static member round = FssTypes.Border.ImageRepeat.Round |> imageRepeatValue'
        static member space = FssTypes.Border.ImageRepeat.Space |> imageRepeatValue'

        static member inherit' = FssTypes.Inherit |> imageRepeatValue'
        static member initial = FssTypes.Initial |> imageRepeatValue'
        static member unset = FssTypes.Unset |> imageRepeatValue'

    /// <summary>Specifies how border image surrounds border box.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BorderImageRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderImageRepeat' = BorderImageRepeat.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSlice
    let private imageSliceValue': (FssTypes.IBorderImageSlice -> FssTypes.CssProperty) = imageSliceToString >> imageSliceValue

    [<Erase>]
    type BorderImageSlice =
        static member fill = FssTypes.Border.ImageSlice.Fill |> imageSliceValue'
        static member value (imageSlice: FssTypes.IBorderImageSlice) = imageSlice |> imageSliceValue'
        static member value (vertical: FssTypes.IBorderImageSlice, horizontal: FssTypes.IBorderImageSlice) =
            sprintf "%s %s" (imageSliceToString vertical) (imageSliceToString horizontal) |> imageSliceValue
        static member value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
            |> imageSliceValue
        static member value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice, w4: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
                (imageSliceToString w4)
            |> imageSliceValue

        static member inherit' = FssTypes.Inherit |> imageSliceValue'
        static member initial = FssTypes.Initial |> imageSliceValue'
        static member unset = FssTypes.Unset |> imageSliceValue'

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
    let BorderImageSlice' = BorderImageSlice.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    let private borderColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderColor
    let private borderColorValue' = borderColorToString >> borderColorValue

    let BorderColor = FssTypes.Border.BorderColor (borderColorToString, borderColorValue, borderColorValue')

    /// <summary>Specifies color of border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderColor' = BorderColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopColor
    let private topColorValue' = borderColorToString >> topColorValue

    let BorderTopColor = FssTypes.Border.BorderSideColor(topColorValue')

    /// <summary>Specifies color of top border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderTopColor' = BorderTopColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightColor
    let private rightColorValue' = borderColorToString >> rightColorValue
    let BorderRightColor = FssTypes.Border.BorderSideColor(rightColorValue')

    /// <summary>Specifies color of right border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderRightColor' = BorderRightColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomColor
    let private bottomColorValue' = borderColorToString >> bottomColorValue
    let BorderBottomColor = FssTypes.Border.BorderSideColor(bottomColorValue')
    /// <summary>Specifies color of bottom border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderBottomColor' = BorderBottomColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftColor
    let private leftColorValue' = borderColorToString >> leftColorValue
    let BorderLeftColor = FssTypes.Border.BorderSideColor(leftColorValue')

    /// <summary>Specifies color of left border.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BorderLeftColor' = BorderLeftColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    let private spacingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderSpacing
    let private spacingValue' = spacingToString >> spacingValue
    [<Erase>]
    type BorderSpacing =
        static member value (width: FssTypes.IBorderSpacing) =
            spacingValue (spacingToString width)
        static member value (w1: FssTypes.IBorderSpacing, w2: FssTypes.IBorderSpacing) =
            sprintf "%s %s"
                (spacingToString w1)
                (spacingToString w2)
            |> spacingValue
        static member inherit' = FssTypes.Inherit |> spacingValue'
        static member initial = FssTypes.Initial |> spacingValue'
        static member unset = FssTypes.Unset |> spacingValue'

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
    let BorderSpacing' = BorderSpacing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let private imageWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageWidth
    let private imageWidthValue' = imageWidthToString >> imageWidthValue
    [<Erase>]
    type BorderImageWidth =
        static member value (width: FssTypes.IBorderImageWidth) = width |> imageWidthValue'
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth) =
            sprintf "%s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
            |> imageWidthValue
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
            |> imageWidthValue
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth, w4: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
                (imageWidthToString w4)
            |> imageWidthValue

        static member auto = FssTypes.Auto |> imageWidthValue'
        static member inherit' = FssTypes.Inherit |> imageWidthValue'
        static member initial = FssTypes.Initial |> imageWidthValue'
        static member unset = FssTypes.Unset |> imageWidthValue'

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
    let BorderImageWidth' = BorderImageWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    let private imageValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSource
    let private imageValue' = imageSourceToString >> imageValue

    [<Erase>]
    type BorderImageSource =
        static member value (source: FssTypes.IBorderImageSource) = source |> imageValue'
        static member url (url: string) = imageValue <| sprintf "url(%s)" url
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.Color.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.Color.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.Color.ColorType * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.Color.ColorType * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.Color.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.Color.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.Color.ColorType * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.Color.ColorType * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.Color.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.Color.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.Color.ColorType * FssTypes.Percent) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.Color.ColorType * FssTypes.Size) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.Color.ColorType * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.Color.ColorType * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member none = FssTypes.None' |> imageValue'
        static member inherit' = FssTypes.Inherit |> imageValue'
        static member initial = FssTypes.Initial |> imageValue'
        static member unset = FssTypes.Unset |> imageValue'

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
    let BorderImageSource' = BorderImageSource.value