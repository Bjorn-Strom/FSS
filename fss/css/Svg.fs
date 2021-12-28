namespace Fss

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Svg =
    /// Specifies how an object is align to its parent.
    let AlignmentBaseline =
        Svg.SvgClasses.AlignmentBaselineClass(Property.AlignmentBaseline)
    /// Resets all of an elements properties.
    let BaselineShift =
        Svg.SvgClasses.BaselineShift(Property.BaselineShift)
    /// Specifies the dominant baseline.
    let DominantBaseline =
        Svg.SvgClasses.DominantBaseline(Property.DominantBaseline)
    /// Align text.
    let TextAnchor =
        Svg.SvgClasses.TextAnchor(Property.TextAnchor)
    /// Sets clip of graphic.
    let ClipRule =
        Svg.SvgClasses.ClipRule(Property.ClipRule)
    /// Specifies color to flood the element with.
    let FloodColor =
        Svg.SvgClasses.FloodColor(Property.FloodColor)
    /// Specifies the opacity of flood color element.
    let FloodOpacity =
        Svg.SvgClasses.Opacity(Property.FloodOpacity)
    /// Specifies color of light source for primitive.
    let LightingColor =
        Svg.SvgClasses.LightingColor(Property.LightingColor)
    /// Specifies color to use at gradient stop.
    let StopColor =
        Svg.SvgClasses.StopColor(Property.StopColor)
    /// Specifies color to use at gradient stop.
    let StopOpacity =
        Svg.SvgClasses.Opacity(Property.StopOpacity)
    /// Specifies the color space for gradient interpolations, color animations, and alpha compositing.
    let ColorInterpolation =
        Svg.SvgClasses.ColorInterpolation(Property.ColorInterpolation)
    /// specifies the color space for imaging operations performed via filter effects.
    let ColorInterpolationFilters =
        Svg.SvgClasses.ColorInterpolation(Property.ColorInterpolationFilters)
    /// Specifies element color.
    let Fill = Svg.SvgClasses.Fill(Property.Fill)
    /// Specifies element color opacity.
    let FillOpacity =
        Svg.SvgClasses.Opacity(Property.FillOpacity)

    let FillRule =
        Svg.SvgClasses.ClipRule(Property.FillRule)
    /// Specifies how the browser should deal with image in regards to speed versus quality.
    let ImageRendering =
        Svg.SvgClasses.ImageRendering(Property.ImageRendering)
    /// Specifies how the browser should deal with tradeoffs when rendering shapes.
    let ShapeRendering =
        Svg.SvgClasses.ShapeRendering(Property.ShapeRendering)
    /// Specifies color to stroke the element with.
    let Stroke = Svg.SvgClasses.Stroke(Property.Stroke)
    /// Specifies the opacity of stroke color element.
    let StrokeOpacity =
        Svg.SvgClasses.Opacity(Property.StrokeOpacity)
    /// Specifies the pattern of dashes and gaps used to paint the outline of the shape.
    let StrokeDasharray = Svg.SvgClasses.StrokeDash(Property.StrokeDasharray)
    /// Specifies the offset when drawing the stroke dash array.
    let StrokeDashoffset = Svg.SvgClasses.StrokeDash(Property.StrokeDashoffset)
    /// Define the shape used at open subpaths when they are stroked.
    let StrokeLinecap = Svg.SvgClasses.StrokeLinecap(Property.StrokeLinecap)
    /// Define the shape used at corners of paths when they are stroked.
    let StrokeLinejoin = Svg.SvgClasses.StrokeLinejoin(Property.StrokeLinejoin)
    /// Limits ratio of miter length to stroke width when used to draw miter join.
    let StrokeMiterlimit = Svg.SvgClasses.StrokeMiterlimit(Property.StrokeMiterlimit)
    /// Specifies size of stroke width.
    let StrokeWidth = Svg.SvgClasses.StrokeWidth(Property.StrokeWidth)
