namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Border =
    type Width =
        | Thin
        | Medium
        | Thick
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Thin -> "thin"
                | Medium -> "medium"
                | Thick -> "thick"
                
    type Style =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Hidden -> "hidden"
                | Dotted -> "dotted"
                | Dashed -> "dashed"
                | Solid -> "solid"
                | Double -> "double"
                | Groove -> "groove"
                | Ridge -> "ridge"
                | Inset -> "inset"
                | Outset -> "outset"

    type Collapse =
        | Collapse
        | Separate
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Collapse -> "collapse"
                | Separate -> "separate"

    type ImageRepeat =
        | Stretch
        | Repeat
        | Round
        | Space
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Stretch -> "stretch"
                | Repeat -> "repeat"
                | Round -> "round"
                | Space -> "space"

[<RequireQualifiedAccess>]
module BorderClasses =
    type BorderColorParent(property) =
        inherit ColorClass.Color(property)

        member this.value(color: Color) = (property, color) |> Rule

    type BorderWidthParent(property) =
        inherit DirectionalLength(property)
        member this.value(width: Border.Width) = (property, width) |> Rule

        /// Apply a thin border width
        member this.thin = (property, Border.Width.Thin) |> Rule
        /// Apply a medium border width
        member this.medium = (property, Border.Width.Medium) |> Rule
        /// Apply a thick border width
        member this.thick = (property, Border.Width.Thick) |> Rule

    type BorderStyleParent(property) =
        inherit CssRuleWithNone(property)
        member this.value(style: Border.Style) = (property, style) |> Rule
        /// Display no border
        member this.hidden = (property, Border.Style.Hidden) |> Rule
        /// The border will be a series of rounded dots
        member this.dotted = (property, Border.Style.Dotted) |> Rule
        /// The border will be a series of line segments
        member this.dashed = (property, Border.Style.Dashed) |> Rule
        /// Displays the border as a solid line
        member this.solid = (property, Border.Style.Solid) |> Rule
        /// Displays two borders
        member this.double = (property, Border.Style.Double) |> Rule
        /// Border will appear carved
        member this.groove = (property, Border.Style.Groove) |> Rule
        /// Border will have an extruded appearance
        member this.ridge = (property, Border.Style.Ridge) |> Rule
        /// Displays a border that makes the element appear embedded
        member this.inset = (property, Border.Style.Inset) |> Rule
        /// Displays a border that makes the element appear embossed
        member this.outset = (property, Border.Style.Outset) |> Rule

    type BorderRadiusParent(property) =
        inherit CssRule(property)

        member this.value(radius: ILengthPercentage) =
            (property, lengthPercentageToType radius) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    type BorderWidth(property) =
        inherit BorderWidthParent(property)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius
    type BorderRadius(property) =
        inherit DirectionalLength(property)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius-top-right
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius-top-left
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius-bottom-right
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius-bottom-left
    type BorderRadiusEdge(property) =
        inherit CssRule(property)

        member this.value(radiusEdge: ILengthPercentage) =
            (property, lengthPercentageToType radiusEdge)
            |> Rule

        member this.value(horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            let value =
                $"{lengthPercentageString horizontal} {lengthPercentageString vertical}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    type BorderStyle(property) =
        inherit BorderStyleParent(property)

        member this.value(topAndBottom: Border.Style, leftAndRight: Border.Style) =
            let value =
                $"{stringifyICssValue topAndBottom} {stringifyICssValue leftAndRight}"
                |> String

            (property, value) |> Rule

        member this.value(top: Border.Style, leftAndRight: Border.Style, bottom: Border.Style) =
            let value =
                $"{stringifyICssValue top} {stringifyICssValue leftAndRight} {stringifyICssValue bottom}"
                |> String

            (property, value) |> Rule

        member this.value(top: Border.Style, right: Border.Style, bottom: Border.Style, left: Border.Style) =
            let value =
                $"{stringifyICssValue top} {stringifyICssValue right} {stringifyICssValue bottom} {stringifyICssValue left}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    type BorderCollapse(property) =
        inherit CssRule(property)
        member this.value(collapse: Border.Collapse) = (property, collapse) |> Rule
        /// Cells have shared borders
        member this.collapse = (property, Border.Collapse) |> Rule
        /// Cells have distinct borders
        member this.separate = (property, Border.Separate) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    type BorderImageOutset(property) =
        inherit DirectionalLength(property)
        member this.value(imageOutset: float) = (property, Float imageOutset) |> Rule

        member this.value(vertical: float, horizontal: float) =
            let value =
                $"{vertical} {horizontal}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    type BorderImageRepeat(property) =
        inherit CssRule(property)
        member this.value(imageRepeat: Border.ImageRepeat) = (property, imageRepeat) |> Rule

        member this.value(vertical: Border.ImageRepeat, horizontal: Border.ImageRepeat) =
            let value =
                $"{stringifyICssValue vertical} {stringifyICssValue horizontal}"
                |> String

            (property, value) |> Rule

        /// The image is stretched to fill the gap between each border
        member this.stretch = (property, Border.Stretch) |> Rule
        /// The image is repeated to fill the gap between each border. Will be clipped to achieve fit
        member this.repeat = (property, Border.Repeat) |> Rule
        /// The image is repeated to fill the gap between each border. Will be stretched to achieve fit
        member this.round = (property, Border.Round) |> Rule
        /// The image is repeated to fill the gap between each border. Extra space will be added to achieve fit
        member this.space = (property, Border.Space) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    type BorderImageSlice(Property) =
        inherit DirectionalLength(Property)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    type BorderColor(property) =
        inherit BorderColorParent(property)

        member this.value(vertical: Color, horizontal: Color) =
            let value =
                $"{stringifyICssValue vertical} {stringifyICssValue horizontal}"
                |> String

            (property, value) |> Rule

        member this.value(top: Color, horizontal: Color, bottom: Color) =
            let value =
                $"{stringifyICssValue top} {stringifyICssValue horizontal} {stringifyICssValue bottom}"
                |> String

            (property, value) |> Rule

        member this.value(top: Color, right: Color, bottom: Color, left: Color) =
            let value =
                $"{stringifyICssValue top} {stringifyICssValue right} {stringifyICssValue bottom} {stringifyICssValue left}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    type BorderSpacing(property) =
        inherit CssRule(property)

        member this.value(spacing: ILengthPercentage) =
            (property, lengthPercentageToType spacing) |> Rule

        member this.value(horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            let value =
                $"{lengthPercentageString horizontal} {lengthPercentageString vertical}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    type BorderImageWidth(property) =
        inherit DirectionalLength(property)
        member this.value(imageWidth: float) = (property, Float imageWidth) |> Rule

        member this.value(vertical: ILengthPercentage, horizontal: ILengthPercentage) =
            let value =
                $"{lengthPercentageString vertical} {lengthPercentageString horizontal}"
                |> String

            (property, value) |> Rule

        member this.auto = (property, Auto) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    type Border(property) =
        inherit CssRule(property)
        member this.value(border: None') = (property, border) |> Rule
        member this.none = (property, None') |> Rule
