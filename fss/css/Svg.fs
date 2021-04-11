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

    /// <summary>Specifies how an object is align to its parent.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> AlignmentBaseline </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AlignmentBaseline' = AlignmentBaseline.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/baseline-shift
    let private stringifyBaselineShift (baselineShift: FssTypes.IBaselineShift) =
        match baselineShift with
        | :? FssTypes.Svg.BaselineShift as bs -> Utilities.Helpers.duToLowercase bs
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | _ -> "Unknown baseline shift"

    let private baselineShiftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BaselineShift
    let private baselineShiftValue' = stringifyBaselineShift >> baselineShiftValue

    [<Erase>]
    type BaselineShift =
        static member value (baselineShift: FssTypes.IBaselineShift) = baselineShift |> baselineShiftValue'
        static member sub = FssTypes.Svg.Sub |> baselineShiftValue'
        static member super = FssTypes.Svg.Super |> baselineShiftValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Baselineshift </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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

    /// <summary>Specifies the dominant baseline.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> DominantBaseline </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let DominantBaseline' = DominantBaseline.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/text-anchor
    let private textAnchorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAnchor
    let private textAnchorValue' = Utilities.Helpers.duToKebab >> textAnchorValue

    [<Erase>]
    type TextAnchor=
        static member value (textAnchor: FssTypes.Svg.TextAnchor) = textAnchor |> textAnchorValue'
        static member start = FssTypes.Svg.TextAnchor.Start |> textAnchorValue'
        static member middle = FssTypes.Svg.TextAnchor.Middle |> textAnchorValue'
        static member end' = FssTypes.Svg.TextAnchor.End |> textAnchorValue'

    /// <summary>Align text.</summary>
    /// <param name="textAnchor">
    ///     can be:
    ///     - <c> TextAnchorline </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAnchor' = TextAnchor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/clip-rule
    let private clipRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ClipRule
    let private clipRuleValue' = Utilities.Helpers.duToLowercase >> clipRuleValue

    [<Erase>]
    type ClipRule=
        static member value (clipRule: FssTypes.Svg.ClipRule) = clipRule |> clipRuleValue'
        static member nonzero = FssTypes.Svg.ClipRule.Nonzero |> clipRuleValue'
        static member evenodd = FssTypes.Svg.ClipRule.Evenodd |> clipRuleValue'

    /// <summary>Sets clip of graphic.</summary>
    /// <param name="clipRule">
    ///     can be:
    ///     - <c> ClipRule </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ClipRule' = ClipRule.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-color
    let private floodColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FloodColor
    let private floodColorValue' = colorToString >> floodColorValue
    let FloodColor = FssTypes.Color.ColorClass(floodColorValue')

    /// <summary>Specifies color to flood the element with.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FloodColor' = FloodColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-opacity
    [<Erase>]
    type FloodOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.FloodOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of flood color element.</summary>
    /// <param name="floodOpacity"> </param>
    /// <returns>Css property for fss.</returns>
    let FloodOpacity' = FloodOpacity.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/lighting-color
    let private lightingColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.LightingColor
    let private lightingColorValue' = colorToString >> lightingColorValue
    let LightingColor = FssTypes.Color.ColorClass(lightingColorValue')

    /// <summary>Specifies color of light source for primitive.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let LightingColor' = LightingColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-color
    let private stopColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.StopColor
    let private stopColorValue' = colorToString >> stopColorValue
    let StopColor = FssTypes.Color.ColorClass(stopColorValue')

    /// <summary>Specifies color to use at gradient stop.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let StopColor' = StopColor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-opacity
    [<Erase>]
    type StopOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.StopOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies the opacity of the color of a gradient stop.</summary>
    /// <param name="stopOpacity"> </param>
    /// <returns>Css property for fss.</returns>
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
    type ColorInterpolation =
        static member value (colorInterpolation: FssTypes.IColorInterpolation) = colorInterpolation |> colorInterpolationValue'
        static member sRGB = FssTypes.Svg.ColorInterpolation.Srgb |> colorInterpolationValue'
        static member linearRGB = FssTypes.Svg.ColorInterpolation.LinearRgb |> colorInterpolationValue'
        static member auto = FssTypes.Auto |> colorInterpolationValue'

    /// <summary>specifies the color space for gradient interpolations, color animations, and alpha compositing.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> ColorInterpolation </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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
    type ColorInterpolationFilters =
        static member value (colorInterpolationFilters: FssTypes.IColorInterpolationFilters) = colorInterpolationFilters |> colorInterpolationFiltersValue'
        static member sRGB = FssTypes.Svg.ColorInterpolationFilters.Srgb |> colorInterpolationFiltersValue'
        static member linearRGB = FssTypes.Svg.ColorInterpolationFilters.LinearRgb |> colorInterpolationFiltersValue'
        static member auto = FssTypes.Auto |> colorInterpolationFiltersValue'

    /// <summary>specifies the color space for imaging operations performed via filter effects..</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> ColorInterpolationFilters </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ColorInterpolationFilters' = ColorInterpolationFilters.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-color
    let private fillValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Fill
    let private fillValue' = colorToString >> fillValue
    let Fill= FssTypes.Color.ColorClass(fillValue')

    /// <summary>Specifies element color.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Fill' = Fill.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-opacity
    [<Erase>]
    type FillOpacity =
        static member value value =
            FssTypes.propertyHelpers.cssValue FssTypes.Property.FillOpacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    /// <summary>Specifies element color opacity.</summary>
    /// <param name="fillOpacity"> </param>
    /// <returns>Css property for fss.</returns>
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
    type ImageRendering =
        static member value (imageRendering: FssTypes.ISVGImageRendering) = imageRendering |> imageRenderingValue'
        static member optimizeSpeed = FssTypes.Svg.ImageRendering.OptimizeSpeed |> imageRenderingValue'
        static member optimizeQuality = FssTypes.Svg.ImageRendering.OptimizeQuality |> imageRenderingValue'
        static member auto = FssTypes.Auto |> imageRenderingValue'

    /// <summary>Specifies how the browser should deal with image in regards to speed versus quality.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> ImageRendering </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
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
    type ShapeRendering =
        static member value (shapeRendering: FssTypes.IShapeRendering) = shapeRendering |> shapeRenderingValue'
        static member optimizeSpeed = FssTypes.Svg.ShapeRendering.OptimizeSpeed |> shapeRenderingValue'
        static member crispEdges = FssTypes.Svg.ShapeRendering.CrispEdges |> shapeRenderingValue'
        static member geometricPrecision = FssTypes.Svg.ShapeRendering.GeometricPrecision |> shapeRenderingValue'
        static member auto = FssTypes.Auto |> shapeRenderingValue'

    /// <summary>Specifies how the browser should deal with tradeoffs when rendering shapes.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> ShapeRendering </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ShapeRendering' = ShapeRendering.value