namespace Fss

open Fss

module BorderType =
    type BorderWidth =
        | Thin
        | Medium
        | Thick
        interface IBorderWidth

    type BorderStyle =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface IBorderStyle

    type BorderCollapse =
        | Collapse
        | Separate
        interface IBorderCollapse

    type BorderImageOutset =
        | BorderImageOutset of float
        interface IBorderImageOutset

    type BorderImageRepeat =
        | Stretch
        | Repeat
        | Round
        | Space
        interface IBorderRepeat

    type BorderImageSlice =
        | Value of float
        | Fill
        interface IBorderImageSlice

[<AutoOpen>]
module Border =
    open BorderType

    let private radiusToString (radius: IBorderRadius) =
        match radius with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border radius"

    let private widthToString (width: IBorderWidth) =
        match width with
            | :? BorderWidth as b -> Utilities.Helpers.duToLowercase b
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Global as g -> GlobalValue.global' g
            | _ -> "unknown border width"

    let private styleToString (style: IBorderStyle) =
        match style with
        | :? BorderStyle as b -> Utilities.Helpers.duToLowercase b
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border style"

    let private collapseToString (collapse: IBorderCollapse) =
        match collapse with
        | :? BorderCollapse as c -> Utilities.Helpers.duToLowercase c
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border collapse"
    let private imageOutsetToString (imageOutset: IBorderImageOutset) =
        let stringifyOutset (BorderImageOutset.BorderImageOutset v) = string v

        match imageOutset with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? BorderImageOutset as i -> stringifyOutset i
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border image outset"

    let private repeatToString (repeat: IBorderRepeat) =
        match repeat with
        | :? BorderImageRepeat as b -> Utilities.Helpers.duToLowercase b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown border repeat"

    let private imageSliceToString (imageSlice: IBorderImageSlice) =
        let stringifySlice =
            function
                | BorderImageSlice.Value i -> string i
                | BorderImageSlice.Fill -> "fill"

        match imageSlice with
        | :? BorderImageSlice as i -> stringifySlice i
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border image slice"

    let private borderColorToString (borderColor: IBorderColor) =
        match borderColor with
        | :? CSSColor as c -> CSSColorValue.color c
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
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown border image source"

    let private borderToString (border: IBorder) =
            match border with
            | :? Global as g -> GlobalValue.global' g
            | _ -> "Unknown border"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    let private borderValue value = PropertyValue.cssValue Property.Border value
    let private borderValue' value =
        value
        |> borderToString
        |> borderValue

    type Border =
        static member Value (border: IBorder) = border |> borderValue'
        static member Inherit = Inherit |> borderValue'
        static member Initial = Initial |> borderValue'
        static member Unset = Unset |> borderValue'

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

        static member Thin = Thin |> widthValue'
        static member Medium = Medium |> widthValue'
        static member Thick = Thick |> widthValue'

        static member Inherit = Inherit |> widthValue'
        static member Initial = Initial |> widthValue'
        static member Unset = Unset |> widthValue'

    let BorderWidth' (width: IBorderWidth) = BorderWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let private topWidthValue value = PropertyValue.cssValue Property.BorderTopWidth value
    let private topWidthValue' value =
        value
        |> widthToString
        |> topWidthValue
    type BorderTopWidth =
        static member Value (width: IBorderWidth) = width |> topWidthValue'
        static member Thin = Thin |> topWidthValue
        static member Medium = Medium |> topWidthValue
        static member Thick = Thick |> topWidthValue

        static member Inherit = Inherit |> topWidthValue
        static member Initial = Initial |> topWidthValue
        static member Unset = Unset |> topWidthValue

    let BorderTopWidth' (width: IBorderWidth) = BorderTopWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue value = PropertyValue.cssValue Property.BorderRightWidth value
    let private rightWidthValue' value =
        value
        |> widthToString
        |> rightWidthValue
    type BorderRightWidth =
        static member Value (width: IBorderWidth) = width |> rightWidthValue'
        static member Thin = Thin |> rightWidthValue
        static member Medium = Medium |> rightWidthValue
        static member Thick = Thick |> rightWidthValue

        static member Inherit = Inherit |> rightWidthValue
        static member Initial = Initial |> rightWidthValue
        static member Unset = Unset |> rightWidthValue

    let BorderRightWidth' (width: IBorderWidth) = BorderRightWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue value = PropertyValue.cssValue Property.BorderBottomWidth value
    let private bottomWidthValue' value =
        value
        |> widthToString
        |> bottomWidthValue
    type BorderBottomWidth =
        static member Value (width: IBorderWidth) = width |> bottomWidthValue'
        static member Thin = Thin |> bottomWidthValue
        static member Medium = Medium |> bottomWidthValue
        static member Thick = Thick |> bottomWidthValue

        static member Inherit = Inherit |> bottomWidthValue
        static member Initial = Initial |> bottomWidthValue
        static member Unset = Unset |> bottomWidthValue

    let BorderBottomWidth' (width: IBorderWidth) = BorderBottomWidth.Value(width)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue value = PropertyValue.cssValue Property.BorderLeftWidth value
    let private leftWidthValue' value =
        value
        |> widthToString
        |> leftWidthValue
    type BorderLeftWidth =
        static member Value (width: IBorderWidth) = width |> leftWidthValue'
        static member Thin = Thin |> leftWidthValue
        static member Medium = Medium |> leftWidthValue
        static member Thick = Thick |> leftWidthValue

        static member Inherit = Inherit |> leftWidthValue
        static member Initial = Initial |> leftWidthValue
        static member Unset = Unset |> leftWidthValue

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

        static member Hidden = Hidden |> styleValue'
        static member Dotted = Dotted |> styleValue'
        static member Dashed = Dashed |> styleValue'
        static member Solid = Solid |> styleValue'
        static member Double = Double |> styleValue'
        static member Groove = Groove |> styleValue'
        static member Ridge = Ridge |> styleValue'
        static member Inset = Inset |> styleValue'
        static member Outset = Outset |> styleValue'

        static member None = None |> styleValue'
        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    let BorderStyle' (style: IBorderStyle) = BorderStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue value = PropertyValue.cssValue Property.BorderTopStyle value
    let private topStyleValue' value =
        value
        |> styleToString
        |> topStyleValue

    type BorderTopStyle =
        static member Value (style: IBorderStyle) = style |> topStyleValue'
        static member Hidden = Hidden |> topStyleValue'
        static member Dotted = Dotted |> topStyleValue'
        static member Dashed = Dashed |> topStyleValue'
        static member Solid = Solid |> topStyleValue'
        static member Double = Double |> topStyleValue'
        static member Groove = Groove |> topStyleValue'
        static member Ridge = Ridge |> topStyleValue'
        static member Inset = Inset |> topStyleValue'
        static member Outset = Outset |> topStyleValue'

        static member None = None |> topStyleValue'
        static member Inherit = Inherit |> topStyleValue'
        static member Initial = Initial |> topStyleValue'
        static member Unset = Unset |> topStyleValue'

    let BorderTopStyle' (style: IBorderStyle) = BorderTopStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue value = PropertyValue.cssValue Property.BorderRightStyle value
    let private rightStyleValue' value =
        value
        |> styleToString
        |> rightStyleValue

    type BorderRightStyle =
        static member Value (style: IBorderStyle) = style |> rightStyleValue'
        static member Hidden = Hidden |> rightStyleValue'
        static member Dotted = Dotted |> rightStyleValue'
        static member Dashed = Dashed |> rightStyleValue'
        static member Solid = Solid |> rightStyleValue'
        static member Double = Double |> rightStyleValue'
        static member Groove = Groove |> rightStyleValue'
        static member Ridge = Ridge |> rightStyleValue'
        static member Inset = Inset |> rightStyleValue'
        static member Outset = Outset |> rightStyleValue'

        static member None = None |> rightStyleValue'
        static member Inherit = Inherit |> rightStyleValue'
        static member Initial = Initial |> rightStyleValue'
        static member Unset = Unset |> rightStyleValue'

    let BorderRightStyle' (style: IBorderStyle) = BorderRightStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue value = PropertyValue.cssValue Property.BorderBottomStyle value
    let private bottomStyleValue' value =
        value
        |> styleToString
        |> bottomStyleValue

    type BorderBottomStyle =
        static member Value (style: IBorderStyle) = style |> bottomStyleValue'
        static member Hidden = Hidden |> bottomStyleValue'
        static member Dotted = Dotted |> bottomStyleValue'
        static member Dashed = Dashed |> bottomStyleValue'
        static member Solid = Solid |> bottomStyleValue'
        static member Double = Double |> bottomStyleValue'
        static member Groove = Groove |> bottomStyleValue'
        static member Ridge = Ridge |> bottomStyleValue'
        static member Inset = Inset |> bottomStyleValue'
        static member Outset = Outset |> bottomStyleValue'

        static member None = None |> bottomStyleValue'
        static member Inherit = Inherit |> bottomStyleValue'
        static member Initial = Initial |> bottomStyleValue'
        static member Unset = Unset |> bottomStyleValue'

    let BorderBottomStyle' (style: IBorderStyle) = BorderBottomStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue value = PropertyValue.cssValue Property.BorderLeftStyle value
    let private leftStyleValue' value =
        value
        |> styleToString
        |> leftStyleValue

    type BorderLeftStyle =
        static member Value (style: IBorderStyle) = style |> leftStyleValue'
        static member Hidden = Hidden |> leftStyleValue'
        static member Dotted = Dotted |> leftStyleValue'
        static member Dashed = Dashed |> leftStyleValue'
        static member Solid = Solid |> leftStyleValue'
        static member Double = Double |> leftStyleValue'
        static member Groove = Groove |> leftStyleValue'
        static member Ridge = Ridge |> leftStyleValue'
        static member Inset = Inset |> leftStyleValue'
        static member Outset = Outset |> leftStyleValue'

        static member None = None |> leftStyleValue'
        static member Inherit = Inherit |> leftStyleValue'
        static member Initial = Initial |> leftStyleValue'
        static member Unset = Unset |> leftStyleValue'

    let BorderLeftStyle' (style: IBorderStyle) = BorderLeftStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue value = PropertyValue.cssValue Property.BorderCollapse value
    let private collapseValue' value =
        value
        |> collapseToString
        |> collapseValue

    type BorderCollapse =
        static member Value (collapse: IBorderCollapse) = collapse |> collapseValue'
        static member Collapse = Collapse |> collapseValue'
        static member Separate = Separate |> collapseValue'

        static member Inherit = Inherit |> collapseValue'
        static member Initial = Initial |> collapseValue'
        static member Unset = Unset |> collapseValue'

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
        static member Stretch = Stretch |> imageRepeatValue'
        static member Repeat = Repeat |> imageRepeatValue'
        static member Round = Round |> imageRepeatValue'
        static member Space = Space |> imageRepeatValue'

        static member Inherit = Inherit |> imageRepeatValue'
        static member Initial = Initial |> imageRepeatValue'
        static member Unset = Unset |> imageRepeatValue'

    let BorderImageRepeat' (repeat: IBorderRepeat) = BorderImageRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue value = PropertyValue.cssValue Property.BorderImageSlice value
    let private imageSliceValue' value =
        value
        |> imageSliceToString
        |> imageSliceValue

    type BorderImageSlice =
        static member Fill = Fill |> imageSliceValue'
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
        static member black = CSSColor.black |> borderColorValue'
        static member silver = CSSColor.silver |> borderColorValue'
        static member gray = CSSColor.gray |> borderColorValue'
        static member white = CSSColor.white |> borderColorValue'
        static member maroon = CSSColor.maroon |> borderColorValue'
        static member red = CSSColor.red |> borderColorValue'
        static member purple = CSSColor.purple |> borderColorValue'
        static member fuchsia = CSSColor.fuchsia |> borderColorValue'
        static member green = CSSColor.green |> borderColorValue'
        static member lime = CSSColor.lime |> borderColorValue'
        static member olive = CSSColor.olive |> borderColorValue'
        static member yellow = CSSColor.yellow |> borderColorValue'
        static member navy = CSSColor.navy |> borderColorValue'
        static member blue = CSSColor.blue |> borderColorValue'
        static member teal = CSSColor.teal |> borderColorValue'
        static member aqua = CSSColor.aqua |> borderColorValue'
        static member orange = CSSColor.orange |> borderColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> borderColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> borderColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> borderColorValue'
        static member azure = CSSColor.azure |> borderColorValue'
        static member beige = CSSColor.beige |> borderColorValue'
        static member bisque = CSSColor.bisque |> borderColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> borderColorValue'
        static member blueViolet = CSSColor.blueViolet |> borderColorValue'
        static member brown = CSSColor.brown |> borderColorValue'
        static member burlywood = CSSColor.burlywood |> borderColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> borderColorValue'
        static member chartreuse = CSSColor.chartreuse |> borderColorValue'
        static member chocolate = CSSColor.chocolate |> borderColorValue'
        static member coral = CSSColor.coral |> borderColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> borderColorValue'
        static member cornsilk = CSSColor.cornsilk |> borderColorValue'
        static member crimson = CSSColor.crimson |> borderColorValue'
        static member cyan = CSSColor.cyan |> borderColorValue'
        static member darkBlue = CSSColor.darkBlue |> borderColorValue'
        static member darkCyan = CSSColor.darkCyan |> borderColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> borderColorValue'
        static member darkGray = CSSColor.darkGray |> borderColorValue'
        static member darkGreen = CSSColor.darkGreen |> borderColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> borderColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> borderColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> borderColorValue'
        static member darkOrange = CSSColor.darkOrange |> borderColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> borderColorValue'
        static member darkRed = CSSColor.darkRed |> borderColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> borderColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> borderColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> borderColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> borderColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> borderColorValue'
        static member darkViolet = CSSColor.darkViolet |> borderColorValue'
        static member deepPink = CSSColor.deepPink |> borderColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> borderColorValue'
        static member dimGrey = CSSColor.dimGrey |> borderColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> borderColorValue'
        static member fireBrick = CSSColor.fireBrick |> borderColorValue'
        static member floralWhite = CSSColor.floralWhite |> borderColorValue'
        static member forestGreen = CSSColor.forestGreen |> borderColorValue'
        static member gainsboro = CSSColor.gainsboro |> borderColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> borderColorValue'
        static member gold = CSSColor.gold |> borderColorValue'
        static member goldenrod = CSSColor.goldenrod |> borderColorValue'
        static member greenYellow = CSSColor.greenYellow |> borderColorValue'
        static member grey = CSSColor.grey |> borderColorValue'
        static member honeydew = CSSColor.honeydew |> borderColorValue'
        static member hotPink = CSSColor.hotPink |> borderColorValue'
        static member indianRed = CSSColor.indianRed |> borderColorValue'
        static member indigo = CSSColor.indigo |> borderColorValue'
        static member ivory = CSSColor.ivory |> borderColorValue'
        static member khaki = CSSColor.khaki |> borderColorValue'
        static member lavender = CSSColor.lavender |> borderColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> borderColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> borderColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> borderColorValue'
        static member lightBlue = CSSColor.lightBlue |> borderColorValue'
        static member lightCoral = CSSColor.lightCoral |> borderColorValue'
        static member lightCyan = CSSColor.lightCyan |> borderColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> borderColorValue'
        static member lightGray = CSSColor.lightGray |> borderColorValue'
        static member lightGreen = CSSColor.lightGreen |> borderColorValue'
        static member lightGrey = CSSColor.lightGrey |> borderColorValue'
        static member lightPink = CSSColor.lightPink |> borderColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> borderColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> borderColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> borderColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> borderColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> borderColorValue'
        static member lightYellow = CSSColor.lightYellow |> borderColorValue'
        static member limeGreen = CSSColor.limeGreen |> borderColorValue'
        static member linen = CSSColor.linen |> borderColorValue'
        static member magenta = CSSColor.magenta |> borderColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> borderColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> borderColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> borderColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> borderColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> borderColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> borderColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> borderColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> borderColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> borderColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> borderColorValue'
        static member mintCream = CSSColor.mintCream |> borderColorValue'
        static member mistyRose = CSSColor.mistyRose |> borderColorValue'
        static member moccasin = CSSColor.moccasin |> borderColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> borderColorValue'
        static member oldLace = CSSColor.oldLace |> borderColorValue'
        static member olivedrab = CSSColor.olivedrab |> borderColorValue'
        static member orangeRed = CSSColor.orangeRed |> borderColorValue'
        static member orchid = CSSColor.orchid |> borderColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> borderColorValue'
        static member paleGreen = CSSColor.paleGreen |> borderColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> borderColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> borderColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> borderColorValue'
        static member peachpuff = CSSColor.peachpuff |> borderColorValue'
        static member peru = CSSColor.peru |> borderColorValue'
        static member pink = CSSColor.pink |> borderColorValue'
        static member plum = CSSColor.plum |> borderColorValue'
        static member powderBlue = CSSColor.powderBlue |> borderColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> borderColorValue'
        static member royalBlue = CSSColor.royalBlue |> borderColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> borderColorValue'
        static member salmon = CSSColor.salmon |> borderColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> borderColorValue'
        static member seaGreen = CSSColor.seaGreen |> borderColorValue'
        static member seaShell = CSSColor.seaShell |> borderColorValue'
        static member sienna = CSSColor.sienna |> borderColorValue'
        static member skyBlue = CSSColor.skyBlue |> borderColorValue'
        static member slateBlue = CSSColor.slateBlue |> borderColorValue'
        static member slateGray = CSSColor.slateGray |> borderColorValue'
        static member snow = CSSColor.snow |> borderColorValue'
        static member springGreen = CSSColor.springGreen |> borderColorValue'
        static member steelBlue = CSSColor.steelBlue |> borderColorValue'
        static member tan = CSSColor.tan |> borderColorValue'
        static member thistle = CSSColor.thistle |> borderColorValue'
        static member tomato = CSSColor.tomato |> borderColorValue'
        static member turquoise = CSSColor.turquoise |> borderColorValue'
        static member violet = CSSColor.violet |> borderColorValue'
        static member wheat = CSSColor.wheat |> borderColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> borderColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> borderColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> borderColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> borderColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> borderColorValue'
        static member Hex value = CSSColor.Hex value |> borderColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> borderColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> borderColorValue'
        static member transparent = CSSColor.transparent |> borderColorValue'
        static member currentColor = CSSColor.currentColor |> borderColorValue'

        static member Inherit = Inherit |> borderColorValue'
        static member Initial = Initial |> borderColorValue'
        static member Unset = Unset |> borderColorValue'

    let BorderColor' (color: IBorderColor) = BorderColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue value = PropertyValue.cssValue Property.BorderTopColor value
    let private topColorValue' value =
        value
        |> borderColorToString
        |> topColorValue
    type BorderTopColor =
        static member Value (color: IBorderColor) = color |> topColorValue'
        static member black = CSSColor.black |> topColorValue'
        static member silver = CSSColor.silver |> topColorValue'
        static member gray = CSSColor.gray |> topColorValue'
        static member white = CSSColor.white |> topColorValue'
        static member maroon = CSSColor.maroon |> topColorValue'
        static member red = CSSColor.red |> topColorValue'
        static member purple = CSSColor.purple |> topColorValue'
        static member fuchsia = CSSColor.fuchsia |> topColorValue'
        static member green = CSSColor.green |> topColorValue'
        static member lime = CSSColor.lime |> topColorValue'
        static member olive = CSSColor.olive |> topColorValue'
        static member yellow = CSSColor.yellow |> topColorValue'
        static member navy = CSSColor.navy |> topColorValue'
        static member blue = CSSColor.blue |> topColorValue'
        static member teal = CSSColor.teal |> topColorValue'
        static member aqua = CSSColor.aqua |> topColorValue'
        static member orange = CSSColor.orange |> topColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> topColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> topColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> topColorValue'
        static member azure = CSSColor.azure |> topColorValue'
        static member beige = CSSColor.beige |> topColorValue'
        static member bisque = CSSColor.bisque |> topColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> topColorValue'
        static member blueViolet = CSSColor.blueViolet |> topColorValue'
        static member brown = CSSColor.brown |> topColorValue'
        static member burlywood = CSSColor.burlywood |> topColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> topColorValue'
        static member chartreuse = CSSColor.chartreuse |> topColorValue'
        static member chocolate = CSSColor.chocolate |> topColorValue'
        static member coral = CSSColor.coral |> topColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> topColorValue'
        static member cornsilk = CSSColor.cornsilk |> topColorValue'
        static member crimson = CSSColor.crimson |> topColorValue'
        static member cyan = CSSColor.cyan |> topColorValue'
        static member darkBlue = CSSColor.darkBlue |> topColorValue'
        static member darkCyan = CSSColor.darkCyan |> topColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> topColorValue'
        static member darkGray = CSSColor.darkGray |> topColorValue'
        static member darkGreen = CSSColor.darkGreen |> topColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> topColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> topColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> topColorValue'
        static member darkOrange = CSSColor.darkOrange |> topColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> topColorValue'
        static member darkRed = CSSColor.darkRed |> topColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> topColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> topColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> topColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> topColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> topColorValue'
        static member darkViolet = CSSColor.darkViolet |> topColorValue'
        static member deepPink = CSSColor.deepPink |> topColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> topColorValue'
        static member dimGrey = CSSColor.dimGrey |> topColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> topColorValue'
        static member fireBrick = CSSColor.fireBrick |> topColorValue'
        static member floralWhite = CSSColor.floralWhite |> topColorValue'
        static member forestGreen = CSSColor.forestGreen |> topColorValue'
        static member gainsboro = CSSColor.gainsboro |> topColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> topColorValue'
        static member gold = CSSColor.gold |> topColorValue'
        static member goldenrod = CSSColor.goldenrod |> topColorValue'
        static member greenYellow = CSSColor.greenYellow |> topColorValue'
        static member grey = CSSColor.grey |> topColorValue'
        static member honeydew = CSSColor.honeydew |> topColorValue'
        static member hotPink = CSSColor.hotPink |> topColorValue'
        static member indianRed = CSSColor.indianRed |> topColorValue'
        static member indigo = CSSColor.indigo |> topColorValue'
        static member ivory = CSSColor.ivory |> topColorValue'
        static member khaki = CSSColor.khaki |> topColorValue'
        static member lavender = CSSColor.lavender |> topColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> topColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> topColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> topColorValue'
        static member lightBlue = CSSColor.lightBlue |> topColorValue'
        static member lightCoral = CSSColor.lightCoral |> topColorValue'
        static member lightCyan = CSSColor.lightCyan |> topColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> topColorValue'
        static member lightGray = CSSColor.lightGray |> topColorValue'
        static member lightGreen = CSSColor.lightGreen |> topColorValue'
        static member lightGrey = CSSColor.lightGrey |> topColorValue'
        static member lightPink = CSSColor.lightPink |> topColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> topColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> topColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> topColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> topColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> topColorValue'
        static member lightYellow = CSSColor.lightYellow |> topColorValue'
        static member limeGreen = CSSColor.limeGreen |> topColorValue'
        static member linen = CSSColor.linen |> topColorValue'
        static member magenta = CSSColor.magenta |> topColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> topColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> topColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> topColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> topColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> topColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> topColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> topColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> topColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> topColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> topColorValue'
        static member mintCream = CSSColor.mintCream |> topColorValue'
        static member mistyRose = CSSColor.mistyRose |> topColorValue'
        static member moccasin = CSSColor.moccasin |> topColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> topColorValue'
        static member oldLace = CSSColor.oldLace |> topColorValue'
        static member olivedrab = CSSColor.olivedrab |> topColorValue'
        static member orangeRed = CSSColor.orangeRed |> topColorValue'
        static member orchid = CSSColor.orchid |> topColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> topColorValue'
        static member paleGreen = CSSColor.paleGreen |> topColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> topColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> topColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> topColorValue'
        static member peachpuff = CSSColor.peachpuff |> topColorValue'
        static member peru = CSSColor.peru |> topColorValue'
        static member pink = CSSColor.pink |> topColorValue'
        static member plum = CSSColor.plum |> topColorValue'
        static member powderBlue = CSSColor.powderBlue |> topColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> topColorValue'
        static member royalBlue = CSSColor.royalBlue |> topColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> topColorValue'
        static member salmon = CSSColor.salmon |> topColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> topColorValue'
        static member seaGreen = CSSColor.seaGreen |> topColorValue'
        static member seaShell = CSSColor.seaShell |> topColorValue'
        static member sienna = CSSColor.sienna |> topColorValue'
        static member skyBlue = CSSColor.skyBlue |> topColorValue'
        static member slateBlue = CSSColor.slateBlue |> topColorValue'
        static member slateGray = CSSColor.slateGray |> topColorValue'
        static member snow = CSSColor.snow |> topColorValue'
        static member springGreen = CSSColor.springGreen |> topColorValue'
        static member steelBlue = CSSColor.steelBlue |> topColorValue'
        static member tan = CSSColor.tan |> topColorValue'
        static member thistle = CSSColor.thistle |> topColorValue'
        static member tomato = CSSColor.tomato |> topColorValue'
        static member turquoise = CSSColor.turquoise |> topColorValue'
        static member violet = CSSColor.violet |> topColorValue'
        static member wheat = CSSColor.wheat |> topColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> topColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> topColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> topColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> topColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> topColorValue'
        static member Hex value = CSSColor.Hex value |> topColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> topColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> topColorValue'
        static member transparent = CSSColor.transparent |> topColorValue'
        static member currentColor = CSSColor.currentColor |> topColorValue'

        static member Inherit = Inherit |> topColorValue'
        static member Initial = Initial |> topColorValue'
        static member Unset = Unset |> topColorValue'

    let BorderTopColor' (color: IBorderColor) = BorderTopColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue value = PropertyValue.cssValue Property.BorderRightColor value
    let private rightColorValue' value =
        value
        |> borderColorToString
        |> rightColorValue
    type BorderRightColor =
        static member Value (color: IBorderColor) = color |> rightColorValue'
        static member black = CSSColor.black |> rightColorValue'
        static member silver = CSSColor.silver |> rightColorValue'
        static member gray = CSSColor.gray |> rightColorValue'
        static member white = CSSColor.white |> rightColorValue'
        static member maroon = CSSColor.maroon |> rightColorValue'
        static member red = CSSColor.red |> rightColorValue'
        static member purple = CSSColor.purple |> rightColorValue'
        static member fuchsia = CSSColor.fuchsia |> rightColorValue'
        static member green = CSSColor.green |> rightColorValue'
        static member lime = CSSColor.lime |> rightColorValue'
        static member olive = CSSColor.olive |> rightColorValue'
        static member yellow = CSSColor.yellow |> rightColorValue'
        static member navy = CSSColor.navy |> rightColorValue'
        static member blue = CSSColor.blue |> rightColorValue'
        static member teal = CSSColor.teal |> rightColorValue'
        static member aqua = CSSColor.aqua |> rightColorValue'
        static member orange = CSSColor.orange |> rightColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> rightColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> rightColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> rightColorValue'
        static member azure = CSSColor.azure |> rightColorValue'
        static member beige = CSSColor.beige |> rightColorValue'
        static member bisque = CSSColor.bisque |> rightColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> rightColorValue'
        static member blueViolet = CSSColor.blueViolet |> rightColorValue'
        static member brown = CSSColor.brown |> rightColorValue'
        static member burlywood = CSSColor.burlywood |> rightColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> rightColorValue'
        static member chartreuse = CSSColor.chartreuse |> rightColorValue'
        static member chocolate = CSSColor.chocolate |> rightColorValue'
        static member coral = CSSColor.coral |> rightColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> rightColorValue'
        static member cornsilk = CSSColor.cornsilk |> rightColorValue'
        static member crimson = CSSColor.crimson |> rightColorValue'
        static member cyan = CSSColor.cyan |> rightColorValue'
        static member darkBlue = CSSColor.darkBlue |> rightColorValue'
        static member darkCyan = CSSColor.darkCyan |> rightColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> rightColorValue'
        static member darkGray = CSSColor.darkGray |> rightColorValue'
        static member darkGreen = CSSColor.darkGreen |> rightColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> rightColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> rightColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> rightColorValue'
        static member darkOrange = CSSColor.darkOrange |> rightColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> rightColorValue'
        static member darkRed = CSSColor.darkRed |> rightColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> rightColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> rightColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> rightColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> rightColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> rightColorValue'
        static member darkViolet = CSSColor.darkViolet |> rightColorValue'
        static member deepPink = CSSColor.deepPink |> rightColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> rightColorValue'
        static member dimGrey = CSSColor.dimGrey |> rightColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> rightColorValue'
        static member fireBrick = CSSColor.fireBrick |> rightColorValue'
        static member floralWhite = CSSColor.floralWhite |> rightColorValue'
        static member forestGreen = CSSColor.forestGreen |> rightColorValue'
        static member gainsboro = CSSColor.gainsboro |> rightColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> rightColorValue'
        static member gold = CSSColor.gold |> rightColorValue'
        static member goldenrod = CSSColor.goldenrod |> rightColorValue'
        static member greenYellow = CSSColor.greenYellow |> rightColorValue'
        static member grey = CSSColor.grey |> rightColorValue'
        static member honeydew = CSSColor.honeydew |> rightColorValue'
        static member hotPink = CSSColor.hotPink |> rightColorValue'
        static member indianRed = CSSColor.indianRed |> rightColorValue'
        static member indigo = CSSColor.indigo |> rightColorValue'
        static member ivory = CSSColor.ivory |> rightColorValue'
        static member khaki = CSSColor.khaki |> rightColorValue'
        static member lavender = CSSColor.lavender |> rightColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> rightColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> rightColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> rightColorValue'
        static member lightBlue = CSSColor.lightBlue |> rightColorValue'
        static member lightCoral = CSSColor.lightCoral |> rightColorValue'
        static member lightCyan = CSSColor.lightCyan |> rightColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> rightColorValue'
        static member lightGray = CSSColor.lightGray |> rightColorValue'
        static member lightGreen = CSSColor.lightGreen |> rightColorValue'
        static member lightGrey = CSSColor.lightGrey |> rightColorValue'
        static member lightPink = CSSColor.lightPink |> rightColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> rightColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> rightColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> rightColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> rightColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> rightColorValue'
        static member lightYellow = CSSColor.lightYellow |> rightColorValue'
        static member limeGreen = CSSColor.limeGreen |> rightColorValue'
        static member linen = CSSColor.linen |> rightColorValue'
        static member magenta = CSSColor.magenta |> rightColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> rightColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> rightColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> rightColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> rightColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> rightColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> rightColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> rightColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> rightColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> rightColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> rightColorValue'
        static member mintCream = CSSColor.mintCream |> rightColorValue'
        static member mistyRose = CSSColor.mistyRose |> rightColorValue'
        static member moccasin = CSSColor.moccasin |> rightColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> rightColorValue'
        static member oldLace = CSSColor.oldLace |> rightColorValue'
        static member olivedrab = CSSColor.olivedrab |> rightColorValue'
        static member orangeRed = CSSColor.orangeRed |> rightColorValue'
        static member orchid = CSSColor.orchid |> rightColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> rightColorValue'
        static member paleGreen = CSSColor.paleGreen |> rightColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> rightColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> rightColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> rightColorValue'
        static member peachpuff = CSSColor.peachpuff |> rightColorValue'
        static member peru = CSSColor.peru |> rightColorValue'
        static member pink = CSSColor.pink |> rightColorValue'
        static member plum = CSSColor.plum |> rightColorValue'
        static member powderBlue = CSSColor.powderBlue |> rightColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> rightColorValue'
        static member royalBlue = CSSColor.royalBlue |> rightColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> rightColorValue'
        static member salmon = CSSColor.salmon |> rightColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> rightColorValue'
        static member seaGreen = CSSColor.seaGreen |> rightColorValue'
        static member seaShell = CSSColor.seaShell |> rightColorValue'
        static member sienna = CSSColor.sienna |> rightColorValue'
        static member skyBlue = CSSColor.skyBlue |> rightColorValue'
        static member slateBlue = CSSColor.slateBlue |> rightColorValue'
        static member slateGray = CSSColor.slateGray |> rightColorValue'
        static member snow = CSSColor.snow |> rightColorValue'
        static member springGreen = CSSColor.springGreen |> rightColorValue'
        static member steelBlue = CSSColor.steelBlue |> rightColorValue'
        static member tan = CSSColor.tan |> rightColorValue'
        static member thistle = CSSColor.thistle |> rightColorValue'
        static member tomato = CSSColor.tomato |> rightColorValue'
        static member turquoise = CSSColor.turquoise |> rightColorValue'
        static member violet = CSSColor.violet |> rightColorValue'
        static member wheat = CSSColor.wheat |> rightColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> rightColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> rightColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> rightColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> rightColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> rightColorValue'
        static member Hex value = CSSColor.Hex value |> rightColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> rightColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> rightColorValue'
        static member transparent = CSSColor.transparent |> rightColorValue'
        static member currentColor = CSSColor.currentColor |> rightColorValue'

        static member Inherit = Inherit |> rightColorValue'
        static member Initial = Initial |> rightColorValue'
        static member Unset = Unset |> rightColorValue'

    let BorderRightColor' (color: IBorderColor) = BorderRightColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue value = PropertyValue.cssValue Property.BorderBottomColor value
    let private bottomColorValue' value =
        value
        |> borderColorToString
        |> bottomColorValue
    type BorderBottomColor =
        static member Value (color: IBorderColor) = color |> bottomColorValue'
        static member black = CSSColor.black |> bottomColorValue'
        static member silver = CSSColor.silver |> bottomColorValue'
        static member gray = CSSColor.gray |> bottomColorValue'
        static member white = CSSColor.white |> bottomColorValue'
        static member maroon = CSSColor.maroon |> bottomColorValue'
        static member red = CSSColor.red |> bottomColorValue'
        static member purple = CSSColor.purple |> bottomColorValue'
        static member fuchsia = CSSColor.fuchsia |> bottomColorValue'
        static member green = CSSColor.green |> bottomColorValue'
        static member lime = CSSColor.lime |> bottomColorValue'
        static member olive = CSSColor.olive |> bottomColorValue'
        static member yellow = CSSColor.yellow |> bottomColorValue'
        static member navy = CSSColor.navy |> bottomColorValue'
        static member blue = CSSColor.blue |> bottomColorValue'
        static member teal = CSSColor.teal |> bottomColorValue'
        static member aqua = CSSColor.aqua |> bottomColorValue'
        static member orange = CSSColor.orange |> bottomColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> bottomColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> bottomColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> bottomColorValue'
        static member azure = CSSColor.azure |> bottomColorValue'
        static member beige = CSSColor.beige |> bottomColorValue'
        static member bisque = CSSColor.bisque |> bottomColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> bottomColorValue'
        static member blueViolet = CSSColor.blueViolet |> bottomColorValue'
        static member brown = CSSColor.brown |> bottomColorValue'
        static member burlywood = CSSColor.burlywood |> bottomColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> bottomColorValue'
        static member chartreuse = CSSColor.chartreuse |> bottomColorValue'
        static member chocolate = CSSColor.chocolate |> bottomColorValue'
        static member coral = CSSColor.coral |> bottomColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> bottomColorValue'
        static member cornsilk = CSSColor.cornsilk |> bottomColorValue'
        static member crimson = CSSColor.crimson |> bottomColorValue'
        static member cyan = CSSColor.cyan |> bottomColorValue'
        static member darkBlue = CSSColor.darkBlue |> bottomColorValue'
        static member darkCyan = CSSColor.darkCyan |> bottomColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> bottomColorValue'
        static member darkGray = CSSColor.darkGray |> bottomColorValue'
        static member darkGreen = CSSColor.darkGreen |> bottomColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> bottomColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> bottomColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> bottomColorValue'
        static member darkOrange = CSSColor.darkOrange |> bottomColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> bottomColorValue'
        static member darkRed = CSSColor.darkRed |> bottomColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> bottomColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> bottomColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> bottomColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> bottomColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> bottomColorValue'
        static member darkViolet = CSSColor.darkViolet |> bottomColorValue'
        static member deepPink = CSSColor.deepPink |> bottomColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> bottomColorValue'
        static member dimGrey = CSSColor.dimGrey |> bottomColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> bottomColorValue'
        static member fireBrick = CSSColor.fireBrick |> bottomColorValue'
        static member floralWhite = CSSColor.floralWhite |> bottomColorValue'
        static member forestGreen = CSSColor.forestGreen |> bottomColorValue'
        static member gainsboro = CSSColor.gainsboro |> bottomColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> bottomColorValue'
        static member gold = CSSColor.gold |> bottomColorValue'
        static member goldenrod = CSSColor.goldenrod |> bottomColorValue'
        static member greenYellow = CSSColor.greenYellow |> bottomColorValue'
        static member grey = CSSColor.grey |> bottomColorValue'
        static member honeydew = CSSColor.honeydew |> bottomColorValue'
        static member hotPink = CSSColor.hotPink |> bottomColorValue'
        static member indianRed = CSSColor.indianRed |> bottomColorValue'
        static member indigo = CSSColor.indigo |> bottomColorValue'
        static member ivory = CSSColor.ivory |> bottomColorValue'
        static member khaki = CSSColor.khaki |> bottomColorValue'
        static member lavender = CSSColor.lavender |> bottomColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> bottomColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> bottomColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> bottomColorValue'
        static member lightBlue = CSSColor.lightBlue |> bottomColorValue'
        static member lightCoral = CSSColor.lightCoral |> bottomColorValue'
        static member lightCyan = CSSColor.lightCyan |> bottomColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> bottomColorValue'
        static member lightGray = CSSColor.lightGray |> bottomColorValue'
        static member lightGreen = CSSColor.lightGreen |> bottomColorValue'
        static member lightGrey = CSSColor.lightGrey |> bottomColorValue'
        static member lightPink = CSSColor.lightPink |> bottomColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> bottomColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> bottomColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> bottomColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> bottomColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> bottomColorValue'
        static member lightYellow = CSSColor.lightYellow |> bottomColorValue'
        static member limeGreen = CSSColor.limeGreen |> bottomColorValue'
        static member linen = CSSColor.linen |> bottomColorValue'
        static member magenta = CSSColor.magenta |> bottomColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> bottomColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> bottomColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> bottomColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> bottomColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> bottomColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> bottomColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> bottomColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> bottomColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> bottomColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> bottomColorValue'
        static member mintCream = CSSColor.mintCream |> bottomColorValue'
        static member mistyRose = CSSColor.mistyRose |> bottomColorValue'
        static member moccasin = CSSColor.moccasin |> bottomColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> bottomColorValue'
        static member oldLace = CSSColor.oldLace |> bottomColorValue'
        static member olivedrab = CSSColor.olivedrab |> bottomColorValue'
        static member orangeRed = CSSColor.orangeRed |> bottomColorValue'
        static member orchid = CSSColor.orchid |> bottomColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> bottomColorValue'
        static member paleGreen = CSSColor.paleGreen |> bottomColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> bottomColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> bottomColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> bottomColorValue'
        static member peachpuff = CSSColor.peachpuff |> bottomColorValue'
        static member peru = CSSColor.peru |> bottomColorValue'
        static member pink = CSSColor.pink |> bottomColorValue'
        static member plum = CSSColor.plum |> bottomColorValue'
        static member powderBlue = CSSColor.powderBlue |> bottomColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> bottomColorValue'
        static member royalBlue = CSSColor.royalBlue |> bottomColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> bottomColorValue'
        static member salmon = CSSColor.salmon |> bottomColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> bottomColorValue'
        static member seaGreen = CSSColor.seaGreen |> bottomColorValue'
        static member seaShell = CSSColor.seaShell |> bottomColorValue'
        static member sienna = CSSColor.sienna |> bottomColorValue'
        static member skyBlue = CSSColor.skyBlue |> bottomColorValue'
        static member slateBlue = CSSColor.slateBlue |> bottomColorValue'
        static member slateGray = CSSColor.slateGray |> bottomColorValue'
        static member snow = CSSColor.snow |> bottomColorValue'
        static member springGreen = CSSColor.springGreen |> bottomColorValue'
        static member steelBlue = CSSColor.steelBlue |> bottomColorValue'
        static member tan = CSSColor.tan |> bottomColorValue'
        static member thistle = CSSColor.thistle |> bottomColorValue'
        static member tomato = CSSColor.tomato |> bottomColorValue'
        static member turquoise = CSSColor.turquoise |> bottomColorValue'
        static member violet = CSSColor.violet |> bottomColorValue'
        static member wheat = CSSColor.wheat |> bottomColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> bottomColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> bottomColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> bottomColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> bottomColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> bottomColorValue'
        static member Hex value = CSSColor.Hex value |> bottomColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> bottomColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> bottomColorValue'
        static member transparent = CSSColor.transparent |> bottomColorValue'
        static member currentColor = CSSColor.currentColor |> bottomColorValue'

        static member Inherit = Inherit |> bottomColorValue'
        static member Initial = Initial |> bottomColorValue'
        static member Unset = Unset |> bottomColorValue'

    let BorderBottomColor' (color: IBorderColor) = BorderBottomColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue value = PropertyValue.cssValue Property.BorderLeftColor value
    let private leftColorValue' value =
        value
        |> borderColorToString
        |> leftColorValue
    type BorderLeftColor =
        static member Value (color: IBorderColor) = color |> leftColorValue'
        static member black = CSSColor.black |> leftColorValue'
        static member silver = CSSColor.silver |> leftColorValue'
        static member gray = CSSColor.gray |> leftColorValue'
        static member white = CSSColor.white |> leftColorValue'
        static member maroon = CSSColor.maroon |> leftColorValue'
        static member red = CSSColor.red |> leftColorValue'
        static member purple = CSSColor.purple |> leftColorValue'
        static member fuchsia = CSSColor.fuchsia |> leftColorValue'
        static member green = CSSColor.green |> leftColorValue'
        static member lime = CSSColor.lime |> leftColorValue'
        static member olive = CSSColor.olive |> leftColorValue'
        static member yellow = CSSColor.yellow |> leftColorValue'
        static member navy = CSSColor.navy |> leftColorValue'
        static member blue = CSSColor.blue |> leftColorValue'
        static member teal = CSSColor.teal |> leftColorValue'
        static member aqua = CSSColor.aqua |> leftColorValue'
        static member orange = CSSColor.orange |> leftColorValue'
        static member aliceBlue = CSSColor.aliceBlue |> leftColorValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> leftColorValue'
        static member aquaMarine = CSSColor.aquaMarine |> leftColorValue'
        static member azure = CSSColor.azure |> leftColorValue'
        static member beige = CSSColor.beige |> leftColorValue'
        static member bisque = CSSColor.bisque |> leftColorValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> leftColorValue'
        static member blueViolet = CSSColor.blueViolet |> leftColorValue'
        static member brown = CSSColor.brown |> leftColorValue'
        static member burlywood = CSSColor.burlywood |> leftColorValue'
        static member cadetBlue = CSSColor.cadetBlue |> leftColorValue'
        static member chartreuse = CSSColor.chartreuse |> leftColorValue'
        static member chocolate = CSSColor.chocolate |> leftColorValue'
        static member coral = CSSColor.coral |> leftColorValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> leftColorValue'
        static member cornsilk = CSSColor.cornsilk |> leftColorValue'
        static member crimson = CSSColor.crimson |> leftColorValue'
        static member cyan = CSSColor.cyan |> leftColorValue'
        static member darkBlue = CSSColor.darkBlue |> leftColorValue'
        static member darkCyan = CSSColor.darkCyan |> leftColorValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> leftColorValue'
        static member darkGray = CSSColor.darkGray |> leftColorValue'
        static member darkGreen = CSSColor.darkGreen |> leftColorValue'
        static member darkKhaki = CSSColor.darkKhaki |> leftColorValue'
        static member darkMagenta = CSSColor.darkMagenta |> leftColorValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> leftColorValue'
        static member darkOrange = CSSColor.darkOrange |> leftColorValue'
        static member darkOrchid = CSSColor.darkOrchid |> leftColorValue'
        static member darkRed = CSSColor.darkRed |> leftColorValue'
        static member darkSalmon = CSSColor.darkSalmon |> leftColorValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> leftColorValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> leftColorValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> leftColorValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> leftColorValue'
        static member darkViolet = CSSColor.darkViolet |> leftColorValue'
        static member deepPink = CSSColor.deepPink |> leftColorValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> leftColorValue'
        static member dimGrey = CSSColor.dimGrey |> leftColorValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> leftColorValue'
        static member fireBrick = CSSColor.fireBrick |> leftColorValue'
        static member floralWhite = CSSColor.floralWhite |> leftColorValue'
        static member forestGreen = CSSColor.forestGreen |> leftColorValue'
        static member gainsboro = CSSColor.gainsboro |> leftColorValue'
        static member ghostWhite = CSSColor.ghostWhite |> leftColorValue'
        static member gold = CSSColor.gold |> leftColorValue'
        static member goldenrod = CSSColor.goldenrod |> leftColorValue'
        static member greenYellow = CSSColor.greenYellow |> leftColorValue'
        static member grey = CSSColor.grey |> leftColorValue'
        static member honeydew = CSSColor.honeydew |> leftColorValue'
        static member hotPink = CSSColor.hotPink |> leftColorValue'
        static member indianRed = CSSColor.indianRed |> leftColorValue'
        static member indigo = CSSColor.indigo |> leftColorValue'
        static member ivory = CSSColor.ivory |> leftColorValue'
        static member khaki = CSSColor.khaki |> leftColorValue'
        static member lavender = CSSColor.lavender |> leftColorValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> leftColorValue'
        static member lawnGreen = CSSColor.lawnGreen |> leftColorValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> leftColorValue'
        static member lightBlue = CSSColor.lightBlue |> leftColorValue'
        static member lightCoral = CSSColor.lightCoral |> leftColorValue'
        static member lightCyan = CSSColor.lightCyan |> leftColorValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> leftColorValue'
        static member lightGray = CSSColor.lightGray |> leftColorValue'
        static member lightGreen = CSSColor.lightGreen |> leftColorValue'
        static member lightGrey = CSSColor.lightGrey |> leftColorValue'
        static member lightPink = CSSColor.lightPink |> leftColorValue'
        static member lightSalmon = CSSColor.lightSalmon |> leftColorValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> leftColorValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> leftColorValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> leftColorValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> leftColorValue'
        static member lightYellow = CSSColor.lightYellow |> leftColorValue'
        static member limeGreen = CSSColor.limeGreen |> leftColorValue'
        static member linen = CSSColor.linen |> leftColorValue'
        static member magenta = CSSColor.magenta |> leftColorValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> leftColorValue'
        static member mediumBlue = CSSColor.mediumBlue |> leftColorValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> leftColorValue'
        static member mediumPurple = CSSColor.mediumPurple |> leftColorValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> leftColorValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> leftColorValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> leftColorValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> leftColorValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> leftColorValue'
        static member midnightBlue = CSSColor.midnightBlue |> leftColorValue'
        static member mintCream = CSSColor.mintCream |> leftColorValue'
        static member mistyRose = CSSColor.mistyRose |> leftColorValue'
        static member moccasin = CSSColor.moccasin |> leftColorValue'
        static member navajoWhite = CSSColor.navajoWhite |> leftColorValue'
        static member oldLace = CSSColor.oldLace |> leftColorValue'
        static member olivedrab = CSSColor.olivedrab |> leftColorValue'
        static member orangeRed = CSSColor.orangeRed |> leftColorValue'
        static member orchid = CSSColor.orchid |> leftColorValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> leftColorValue'
        static member paleGreen = CSSColor.paleGreen |> leftColorValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> leftColorValue'
        static member paleVioletred = CSSColor.paleVioletred |> leftColorValue'
        static member papayaWhip = CSSColor.papayaWhip |> leftColorValue'
        static member peachpuff = CSSColor.peachpuff |> leftColorValue'
        static member peru = CSSColor.peru |> leftColorValue'
        static member pink = CSSColor.pink |> leftColorValue'
        static member plum = CSSColor.plum |> leftColorValue'
        static member powderBlue = CSSColor.powderBlue |> leftColorValue'
        static member rosyBrown = CSSColor.rosyBrown |> leftColorValue'
        static member royalBlue = CSSColor.royalBlue |> leftColorValue'
        static member saddleBrown = CSSColor.saddleBrown |> leftColorValue'
        static member salmon = CSSColor.salmon |> leftColorValue'
        static member sandyBrown = CSSColor.sandyBrown |> leftColorValue'
        static member seaGreen = CSSColor.seaGreen |> leftColorValue'
        static member seaShell = CSSColor.seaShell |> leftColorValue'
        static member sienna = CSSColor.sienna |> leftColorValue'
        static member skyBlue = CSSColor.skyBlue |> leftColorValue'
        static member slateBlue = CSSColor.slateBlue |> leftColorValue'
        static member slateGray = CSSColor.slateGray |> leftColorValue'
        static member snow = CSSColor.snow |> leftColorValue'
        static member springGreen = CSSColor.springGreen |> leftColorValue'
        static member steelBlue = CSSColor.steelBlue |> leftColorValue'
        static member tan = CSSColor.tan |> leftColorValue'
        static member thistle = CSSColor.thistle |> leftColorValue'
        static member tomato = CSSColor.tomato |> leftColorValue'
        static member turquoise = CSSColor.turquoise |> leftColorValue'
        static member violet = CSSColor.violet |> leftColorValue'
        static member wheat = CSSColor.wheat |> leftColorValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> leftColorValue'
        static member yellowGreen = CSSColor.yellowGreen |> leftColorValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> leftColorValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> leftColorValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> leftColorValue'
        static member Hex value = CSSColor.Hex value |> leftColorValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> leftColorValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> leftColorValue'
        static member transparent = CSSColor.transparent |> leftColorValue'
        static member currentColor = CSSColor.currentColor |> leftColorValue'

        static member Inherit = Inherit |> leftColorValue'
        static member Initial = Initial |> leftColorValue'
        static member Unset = Unset |> leftColorValue'

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
        (*
        static member LinearGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(start, last)
        static member LinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(angle,colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RadialGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient ((start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient (colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(colors)
        static member RadialGradient (colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(colorsAndStop)
        static member RadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (shape: Shape, (start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (shape: Shape, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, colors)
        static member RadialGradient (shape: Shape, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, colorsAndStop)
        static member RadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, position, start, last)
        static member RadialGradient (shape: Shape, position: ImagePosition, (start: (CSSColor * ILengthPercentage)), (last: (CSSColor * ILengthPercentage))) =
            imageValue <| Image.Image.RadialGradient(shape, position, start, last)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, position, colors)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, position, colors)
        static member RadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, side, colors)
        static member RadialGradient (shape: Shape, side: Side, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, side, colorsAndStop)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, start, last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, start, last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, colors)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, colorsAndStop)
        static member RepeatingRadialGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient ((start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient (colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(colors)
        static member RepeatingRadialGradient (colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, (start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colors)
        static member RepeatingRadialGradient (shape: Shape, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, (start: (CSSColor * ILengthPercentage)), (last: (CSSColor * ILengthPercentage))) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, colors)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colorsAndStop)
            *)
        static member None = None |> imageValue'
        static member Inherit = Inherit |> imageValue'
        static member Initial = Initial |> imageValue'
        static member Unset = Unset |> imageValue'

    let BorderImageSource' (source: IBorderImageSource) = BorderImageSource.Value(source)