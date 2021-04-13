namespace Fss

open Fable.Core

[<AutoOpen>]
module Svg =
    let private colorToString (color: FssTypes.IColor) =
        match color with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | _ -> "Unknown svg color"

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/alignment-baseline
    let private alignmentBaselineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignmentBaseline
    let private alignmentBaselineValue' = Utilities.Helpers.duToKebab >> alignmentBaselineValue

    [<Erase>]
    /// Specifies how an object is align to its parent.
    type AlignmentBaseline =
        static member value (alignment: FssTypes.Svg.AlignmentBaseline) = alignment |> alignmentBaselineValue'
        static member baseline = FssTypes.Svg.Baseline |> alignmentBaselineValue'
        static member textBottom = FssTypes.Svg.TextBottom |> alignmentBaselineValue'
        static member textBeforeEdge = FssTypes.Svg.TextBeforeEdge |> alignmentBaselineValue'
        static member middle = FssTypes.Svg.Middle |> alignmentBaselineValue'
        static member central = FssTypes.Svg.Central |> alignmentBaselineValue'
        static member textTop = FssTypes.Svg.TextTop |> alignmentBaselineValue'
        static member textAfterEdge = FssTypes.Svg.TextAfterEdge |> alignmentBaselineValue'
        static member ideographic = FssTypes.Svg.Ideographic |> alignmentBaselineValue'
        static member alphabetic = FssTypes.Svg.Alphabetic |> alignmentBaselineValue'
        static member hanging = FssTypes.Svg.Hanging |> alignmentBaselineValue'
        static member mathematical = FssTypes.Svg.Mathematical |> alignmentBaselineValue'
        static member top = FssTypes.Svg.Top |> alignmentBaselineValue'
        static member center = FssTypes.Svg.Center |> alignmentBaselineValue'
        static member bottom = FssTypes.Svg.Bottom |> alignmentBaselineValue'

    /// Specifies how an object is align to its parent.
    let AlignmentBaseline' = AlignmentBaseline.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/baseline-shift
    let private stringifyBaselineShift (baselineShift: FssTypes.IBaselineShift) =
        match baselineShift with
        | :? FssTypes.Svg.BaselineShift as bs -> Utilities.Helpers.duToLowercase bs
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | _ -> "Unknown baseline shift"

    let private baselineShiftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BaselineShift
    let private baselineShiftValue' = stringifyBaselineShift >> baselineShiftValue

    [<Erase>]
    /// Resets all of an elements properties.
    type BaselineShift =
        static member value (baselineShift: FssTypes.IBaselineShift) = baselineShift |> baselineShiftValue'
        static member sub = FssTypes.Svg.Sub |> baselineShiftValue'
        static member super = FssTypes.Svg.Super |> baselineShiftValue'

    /// Resets all of an elements properties.
    /// Valid parameters:
    /// - BaselineShift
    /// - Length
    /// - Percent
    let BaselineShift' = BaselineShift.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/dominant-baseline
    let private stringifyDominantBaseline (dominantBaseline: FssTypes.IDominantBaseline) =
        match dominantBaseline with
        | :? FssTypes.Svg.DominantBaseline as ds -> Utilities.Helpers.duToKebab ds
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown baseline shift"

    let private dominantBaselineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.DominantBaseline
    let private dominantBaselineValue' = stringifyDominantBaseline >> dominantBaselineValue

    [<Erase>]
    /// Specifies the dominant baseline.
    type DominantBaseline =
        static member value (dominantBaseline: FssTypes.IDominantBaseline) = dominantBaseline |> dominantBaselineValue'
        static member ideographic = FssTypes.Svg.DominantBaseline.Ideographic |> dominantBaselineValue'
        static member alphabetic = FssTypes.Svg.DominantBaseline.Alphabetic |> dominantBaselineValue'
        static member hanging = FssTypes.Svg.DominantBaseline.Hanging |> dominantBaselineValue'
        static member mathematical = FssTypes.Svg.DominantBaseline.Mathematical |> dominantBaselineValue'
        static member central = FssTypes.Svg.DominantBaseline.Central |> dominantBaselineValue'
        static member middle = FssTypes.Svg.DominantBaseline.Middle |> dominantBaselineValue'
        static member textAfterEdge = FssTypes.Svg.DominantBaseline.TextAfterEdge |> dominantBaselineValue'
        static member textBeforeEdge = FssTypes.Svg.DominantBaseline.TextBeforeEdge |> dominantBaselineValue'
        static member textTop = FssTypes.Svg.DominantBaseline.TextTop |> dominantBaselineValue'
        static member auto = FssTypes.Auto |> dominantBaselineValue'

    /// Specifies the dominant baseline.
    /// Valid parameters:
    /// - DominantBaseline
    /// - Auto
    let DominantBaseline' = DominantBaseline.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/text-anchor
    let private textAnchorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAnchor
    let private textAnchorValue' = Utilities.Helpers.duToKebab >> textAnchorValue

    [<Erase>]
    /// Align text.
    type TextAnchor=
        static member value (textAnchor: FssTypes.Svg.TextAnchor) = textAnchor |> textAnchorValue'
        static member start = FssTypes.Svg.TextAnchor.Start |> textAnchorValue'
        static member middle = FssTypes.Svg.TextAnchor.Middle |> textAnchorValue'
        static member end' = FssTypes.Svg.TextAnchor.End |> textAnchorValue'

    /// Align text.
    let TextAnchor' = TextAnchor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/clip-rule
    let private clipRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ClipRule
    let private clipRuleValue' = Utilities.Helpers.duToLowercase >> clipRuleValue

    [<Erase>]
    /// Sets clip of graphic.
    type ClipRule=
        static member value (clipRule: FssTypes.Svg.ClipRule) = clipRule |> clipRuleValue'
        static member nonzero = FssTypes.Svg.ClipRule.Nonzero |> clipRuleValue'
        static member evenodd = FssTypes.Svg.ClipRule.Evenodd |> clipRuleValue'

    /// Sets clip of graphic.
    let ClipRule' = ClipRule.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-color
    let private floodColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FloodColor
    let private floodColorValue' = colorToString >> floodColorValue

    /// Specifies color to flood the element with.
    let FloodColor = FssTypes.Color.ColorClass(floodColorValue')

    /// Specifies color to flood the element with.
    let FloodColor' = FloodColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-opacity
    [<Erase>]
    /// Specifies the opacity of flood color element.
    type FloodOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.FloodOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// Specifies the opacity of flood color element.
    let FloodOpacity' = FloodOpacity.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/lighting-color
    let private lightingColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.LightingColor
    let private lightingColorValue' = colorToString >> lightingColorValue

    /// Specifies color of light source for primitive.
    let LightingColor = FssTypes.Color.ColorClass(lightingColorValue')

    /// Specifies color of light source for primitive.
    let LightingColor' = LightingColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-color
    let private stopColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StopColor
    let private stopColorValue' = colorToString >> stopColorValue

    /// Specifies color to use at gradient stop.
    let StopColor = FssTypes.Color.ColorClass(stopColorValue')

    /// Specifies color to use at gradient stop.
    let StopColor' = StopColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-opacity
    [<Erase>]
    /// Specifies the opacity of the color of a gradient stop.
    type StopOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.StopOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// Specifies the opacity of the color of a gradient stop.
    let StopOpacity' = StopOpacity.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/color-interpolation
    let private stringifyColorInterpolation (colorInterpolation: FssTypes.IColorInterpolation) =
        match colorInterpolation with
        | :? FssTypes.Svg.ColorInterpolation as ci ->
            match ci with
                | FssTypes.Svg.ColorInterpolation.Srgb -> "sRGB"
                | FssTypes.Svg.ColorInterpolation.LinearRgb -> "linearRGB"
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown color interpolation"

    let private colorInterpolationValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColorInterpolation
    let private colorInterpolationValue' = stringifyColorInterpolation >> colorInterpolationValue

    [<Erase>]
    /// Specifies the color space for gradient interpolations, color animations, and alpha compositing.
    type ColorInterpolation =
        static member value (colorInterpolation: FssTypes.IColorInterpolation) = colorInterpolation |> colorInterpolationValue'
        static member sRGB = FssTypes.Svg.ColorInterpolation.Srgb |> colorInterpolationValue'
        static member linearRGB = FssTypes.Svg.ColorInterpolation.LinearRgb |> colorInterpolationValue'
        static member auto = FssTypes.Auto |> colorInterpolationValue'

    /// Specifies the color space for gradient interpolations, color animations, and alpha compositing.
    let ColorInterpolation' = ColorInterpolation.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/color-interpolation-filters
    let private stringifyColorInterpolationFilters(colorInterpolationFilters: FssTypes.IColorInterpolationFilters) =
        match colorInterpolationFilters with
        | :? FssTypes.Svg.ColorInterpolationFilters as ci ->
            match ci with
                | FssTypes.Svg.ColorInterpolationFilters.Srgb -> "sRGB"
                | FssTypes.Svg.ColorInterpolationFilters.LinearRgb -> "linearRGB"
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown color interpolation filters"

    let private colorInterpolationFiltersValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ColorInterpolationFilters
    let private colorInterpolationFiltersValue' = stringifyColorInterpolationFilters >> colorInterpolationFiltersValue

    [<Erase>]
    /// specifies the color space for imaging operations performed via filter effects.
    type ColorInterpolationFilters =
        static member value (colorInterpolationFilters: FssTypes.IColorInterpolationFilters) = colorInterpolationFilters |> colorInterpolationFiltersValue'
        static member sRGB = FssTypes.Svg.ColorInterpolationFilters.Srgb |> colorInterpolationFiltersValue'
        static member linearRGB = FssTypes.Svg.ColorInterpolationFilters.LinearRgb |> colorInterpolationFiltersValue'
        static member auto = FssTypes.Auto |> colorInterpolationFiltersValue'

    /// specifies the color space for imaging operations performed via filter effects.
    let ColorInterpolationFilters' = ColorInterpolationFilters.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-color
    let private fillValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Fill
    let private fillValue' = colorToString >> fillValue

    /// Specifies element color.
    let Fill = FssTypes.Color.ColorClass(fillValue')

    /// Specifies element color.
    let Fill' = Fill.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-opacity
    [<Erase>]
    /// Specifies element color opacity.
    type FillOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.FillOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// Specifies element color opacity.
    let FillOpacity' = FillOpacity.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule
    let private fillRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FillRule
    let private fillRuleValue' = Utilities.Helpers.duToLowercase >> fillRuleValue

    [<Erase>]
    type FillRule =
        static member value (fillRule: FssTypes.Svg.FillRule) = fillRule |> fillRuleValue'
        static member nonzero = FssTypes.Svg.FillRule.Nonzero |> fillRuleValue'
        static member evenodd = FssTypes.Svg.FillRule.Evenodd |> fillRuleValue'

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/image-rendering
    let private stringifyImageRendering (imageRendering: FssTypes.ISVGImageRendering) =
        match imageRendering with
        | :? FssTypes.Svg.ImageRendering as ir -> Utilities.Helpers.duToKebab ir
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown image rendering"

    let private imageRenderingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ImageRendering
    let private imageRenderingValue' = stringifyImageRendering >> imageRenderingValue

    [<Erase>]
    /// Specifies how the browser should deal with image in regards to speed versus quality.
    type ImageRendering =
        static member value (imageRendering: FssTypes.ISVGImageRendering) = imageRendering |> imageRenderingValue'
        static member optimizeSpeed = FssTypes.Svg.ImageRendering.OptimizeSpeed |> imageRenderingValue'
        static member optimizeQuality = FssTypes.Svg.ImageRendering.OptimizeQuality |> imageRenderingValue'
        static member auto = FssTypes.Auto |> imageRenderingValue'

    /// Specifies how the browser should deal with image in regards to speed versus quality.
    /// Valid parameters:
    /// - ImageRendering
    /// - Auto
    let ImageRendering' = ImageRendering.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/shape-rendering
    let private stringifyShapeRendering (shapreRendering: FssTypes.IShapeRendering) =
        match shapreRendering with
        | :? FssTypes.Svg.ShapeRendering as sr -> Utilities.Helpers.duToKebab sr
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown shape rendering"

    let private shapeRenderingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ShapeRendering
    let private shapeRenderingValue' = stringifyShapeRendering >> shapeRenderingValue

    [<Erase>]
    /// Specifies how the browser should deal with tradeoffs when rendering shapes.
    type ShapeRendering =
        static member value (shapeRendering: FssTypes.IShapeRendering) = shapeRendering |> shapeRenderingValue'
        static member optimizeSpeed = FssTypes.Svg.ShapeRendering.OptimizeSpeed |> shapeRenderingValue'
        static member crispEdges = FssTypes.Svg.ShapeRendering.CrispEdges |> shapeRenderingValue'
        static member geometricPrecision = FssTypes.Svg.ShapeRendering.GeometricPrecision |> shapeRenderingValue'
        static member auto = FssTypes.Auto |> shapeRenderingValue'

    /// Specifies how the browser should deal with tradeoffs when rendering shapes.
    /// Valid parameters:
    /// - ShapeRendering
    /// - Auto
    let ShapeRendering' = ShapeRendering.value

   // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke
    let private strokeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Stroke
    let private strokeValue' = colorToString >> strokeValue

    /// Specifies color to stroke the element with.
    let Stroke = FssTypes.Color.ColorClass(strokeValue')

    /// Specifies color to stroke the element with.
    let Stroke' = Stroke.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-opacity
    [<Erase>]
    /// Specifies the opacity of stroke color element.
    type StrokeOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// Specifies the opacity of stroke color element.
    let StrokeOpacity' = StrokeOpacity.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dasharray
    let private strokeDasharrayValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeDasharray

    [<Erase>]
    /// Specifies the pattern of dashes and gaps used to paint the outline of the shape.
    type StrokeDasharray =
        static member value (strokeDasharray: int list) =
            strokeDasharray |> Utilities.Helpers.combineComma string |> strokeDasharrayValue

    /// Specifies the pattern of dashes and gaps used to paint the outline of the shape.
    let StrokeDasharray' = StrokeDasharray.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dashoffset
    let private strokeDashoffsetValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeDashoffset

    [<Erase>]
    /// Specifies the offset when drawing the stroke dash array.
    type StrokeDashoffset =
        static member value (strokeDashoffset: int list) =
            strokeDashoffset |> Utilities.Helpers.combineComma string |> strokeDashoffsetValue

    /// Specifies the offset when drawing the stroke dash array.
    let StrokeDashoffset' = StrokeDashoffset.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linecap
    let private strokeLinecapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeLinecap
    let private strokeLinecapValue' = Utilities.Helpers.duToKebab >> strokeLinecapValue

    [<Erase>]
    /// Define the shape used at open subpaths when they are stroked.
    type StrokeLinecap=
        static member value (strokeLinecap: FssTypes.Svg.StrokeLinecap) = strokeLinecap |> strokeLinecapValue'
        static member butt = FssTypes.Svg.StrokeLinecap.Butt |> strokeLinecapValue'
        static member round = FssTypes.Svg.StrokeLinecap.Round |> strokeLinecapValue'
        static member square = FssTypes.Svg.StrokeLinecap.Square |> strokeLinecapValue'

    /// Define the shape used at open subpaths when they are stroked.
    let StrokeLinecap' = StrokeLinecap.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linejoin
    let private strokeLinejoinValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeLinejoin
    let private strokeLinejoinValue' = Utilities.Helpers.duToKebab >> strokeLinejoinValue

    [<Erase>]
    type StrokeLinejoin=
        static member value (strokeLinejoin: FssTypes.Svg.StrokeLinejoin) = strokeLinejoin |> strokeLinejoinValue'
        static member arcs = FssTypes.Svg.StrokeLinejoin.Arcs |> strokeLinejoinValue'
        static member bevel = FssTypes.Svg.StrokeLinejoin.Bevel |> strokeLinejoinValue'
        static member miter = FssTypes.Svg.StrokeLinejoin.Miter |> strokeLinejoinValue'
        static member miterClip = FssTypes.Svg.StrokeLinejoin.MiterClip |> strokeLinejoinValue'
        static member round = FssTypes.Svg.StrokeLinejoin.Round |> strokeLinejoinValue'

    /// Define the shape used at corners of paths when they are stroked.
    let StrokeLinejoin' = StrokeLinejoin.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-miterlimit
    let private strokeMiterlimitValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeMiterlimit

    [<Erase>]
    /// Limits ratio of miter length to stroke width when used to draw miter join.
    type StrokeMiterlimit =
        static member value (strokeMiterlimit: int) =
            strokeMiterlimit |> string |> strokeMiterlimitValue

    /// Limits ratio of miter length to stroke width when used to draw miter join.
    let StrokeMiterlimit' = StrokeMiterlimit.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-width
    let private strokeWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StrokeWidth
    let private strokeWidthValue' = FssTypes.unitHelpers.lengthPercentageToString >> strokeWidthValue

    [<Erase>]
    /// Specifies size of stroke width.
    type StrokeWidth =
        static member value (size: FssTypes.ILengthPercentage) = size |> strokeWidthValue'

    /// Specifies size of stroke width.
    let StrokeWidth' = StrokeWidth.value