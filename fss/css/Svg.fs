namespace Fss

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Svg =
    /// Specifies how an object is align to its parent.
    let AlignmentBaseline = SvgClasses.AlignmentBaselineClass(Property.AlignmentBaseline)
    /// Resets all of an elements properties.
    let BaselineShift = SvgClasses.BaselineShift(Property.BaselineShift)
    /// Specifies the dominant baseline.
    let DominantBaseline = SvgClasses.DominantBaseline(Property.DominantBaseline)
    /// Align text.
    let TextAnchor = SvgClasses.TextAnchor(Property.TextAnchor)
    /// Sets clip of graphic.
    let ClipRule = SvgClasses.ClipRule(Property.ClipRule)
    /// Specifies color to flood the element with.
    let FloodColor = SvgClasses.FloodColor(Property.FloodColor)
    /// Specifies the opacity of flood color element.
    let FloodOpacity = SvgClasses.Opacity(Property.FloodOpacity)
    /// Specifies color of light source for primitive.
    let LightingColor = SvgClasses.LightingColor(Property.LightingColor)
    /// Specifies color to use at gradient stop.
    let StopColor = SvgClasses.StopColor(Property.StopColor)
    /// Specifies color to use at gradient stop.
    let StopOpacity = SvgClasses.Opacity(Property.StopOpacity)
    /// Specifies the color space for gradient interpolations, color animations, and alpha compositing.
    let ColorInterpolation = SvgClasses.ColorInterpolation(Property.ColorInterpolation)
    /// specifies the color space for imaging operations performed via filter effects.
    let ColorInterpolationFilters = SvgClasses.ColorInterpolation(Property.ColorInterpolationFilters)
    /// Specifies element color.
    let Fill = SvgClasses.Fill(Property.Fill)
    /// Specifies element color opacity.
    let FillOpacity = SvgClasses.Opacity(Property.FillOpacity)

    let FillRule = SvgClasses.ClipRule(Property.FillRule)
    /// Specifies how the browser should deal with image in regards to speed versus quality.
    let ImageRendering = SvgClasses.ImageRendering(Property.ImageRendering)
    /// Specifies how the browser should deal with tradeoffs when rendering shapes.
    let ShapeRendering = SvgClasses.ShapeRendering(Property.ShapeRendering)
    /// Specifies color to stroke the element with.
    let Stroke = SvgClasses.Stroke(Property.Stroke)
    /// Specifies the opacity of stroke color element.
    let StrokeOpacity = SvgClasses.Opacity(Property.StrokeOpacity)
    /// Specifies the pattern of dashes and gaps used to paint the outline of the shape.
    let StrokeDasharray = SvgClasses.StrokeDash(Property.StrokeDasharray)
    /// Specifies the offset when drawing the stroke dash array.
    let StrokeDashoffset = SvgClasses.StrokeDash(Property.StrokeDashoffset)
    /// Define the shape used at open subpaths when they are stroked.
    let StrokeLinecap = SvgClasses.StrokeLinecap(Property.StrokeLinecap)
    /// Define the shape used at corners of paths when they are stroked.
    let StrokeLinejoin = SvgClasses.StrokeLinejoin(Property.StrokeLinejoin)
    /// Limits ratio of miter length to stroke width when used to draw miter join.
    let StrokeMiterlimit = SvgClasses.StrokeMiterlimit(Property.StrokeMiterlimit)
    /// Specifies size of stroke width.
    let StrokeWidth = SvgClasses.StrokeWidth(Property.StrokeWidth)
