namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Svg =
    type AlignmentBaseline =
        | Baseline
        | TextBottom
        | TextBeforeEdge
        | Middle
        | Central
        | TextTop
        | TextAfterEdge
        | Ideographic
        | Alphabetic
        | Hanging
        | Mathematical
        | Top
        | Center
        | Bottom
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type BaselineShift =
        | Sub
        | Super
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type DominantBaseline =
        | Ideographic
        | Alphabetic
        | Hanging
        | Mathematical
        | Central
        | Middle
        | TextAfterEdge
        | TextBeforeEdge
        | TextTop
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type TextAnchor =
        | Start
        | Middle
        | End
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type ClipRule =
        | Nonzero
        | Evenodd
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type ColorInterpolation =
        | Srgb
        | LinearRgb
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Srgb -> "sRGB"
                | LinearRgb -> "linearRGB"

    type ImageRendering =
        | OptimizeSpeed
        | OptimizeQuality
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type ShapeRendering =
        | OptimizeSpeed
        | CrispEdges
        | GeometricPrecision
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type StrokeLinecap =
        | Butt
        | Round
        | Square
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type StrokeLinejoin =
        | Arcs
        | Bevel
        | Miter
        | MiterClip
        | Round
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module SvgClasses =
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/alignment-baseline
    type AlignmentBaselineClass(property) =
        member this.auto = (property, Auto) |> Rule

        member this.baseline =
            (property, Svg.AlignmentBaseline.Baseline) |> Rule

        member this.textBottom =
            (property, Svg.AlignmentBaseline.TextBottom) |> Rule

        member this.textBeforeEdge =
            (property, Svg.AlignmentBaseline.TextBeforeEdge)
            |> Rule

        member this.middle =
            (property, Svg.AlignmentBaseline.Middle) |> Rule

        member this.central =
            (property, Svg.AlignmentBaseline.Central) |> Rule

        member this.textTop =
            (property, Svg.AlignmentBaseline.TextTop) |> Rule

        member this.textAfterEdge =
            (property, Svg.AlignmentBaseline.TextAfterEdge)
            |> Rule

        member this.ideographic =
            (property, Svg.AlignmentBaseline.Ideographic) |> Rule

        member this.alphabetic =
            (property, Svg.AlignmentBaseline.Alphabetic) |> Rule

        member this.hanging =
            (property, Svg.AlignmentBaseline.Hanging) |> Rule

        member this.mathematical =
            (property, Svg.AlignmentBaseline.Mathematical) |> Rule

        member this.top =
            (property, Svg.AlignmentBaseline.Top) |> Rule

        member this.center =
            (property, Svg.AlignmentBaseline.Center) |> Rule

        member this.bottom =
            (property, Svg.AlignmentBaseline.Bottom) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/baseline-shift
    type BaselineShift(property) =
        member this.value(shift: ILengthPercentage) =
            (property, lengthPercentageToType shift) |> Rule

        member this.sub = (property, Svg.Sub) |> Rule
        member this.super = (property, Svg.Super) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/dominant-baseline
    type DominantBaseline(property) =
        member this.ideographic =
            (property, Svg.DominantBaseline.Ideographic) |> Rule

        member this.alphabetic =
            (property, Svg.DominantBaseline.Alphabetic) |> Rule

        member this.hanging =
            (property, Svg.DominantBaseline.Hanging) |> Rule

        member this.mathematical =
            (property, Svg.DominantBaseline.Mathematical) |> Rule

        member this.central =
            (property, Svg.DominantBaseline.Central) |> Rule

        member this.middle =
            (property, Svg.DominantBaseline.Middle) |> Rule

        member this.textAfterEdge =
            (property, Svg.DominantBaseline.TextAfterEdge) |> Rule

        member this.textBeforeEdge =
            (property, Svg.DominantBaseline.TextBeforeEdge)
            |> Rule

        member this.textTop =
            (property, Svg.DominantBaseline.TextTop) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/text-anchor
    type TextAnchor(property) =
        member this.start = (property, Svg.Start) |> Rule
        member this.middle = (property, Svg.Middle) |> Rule
        member this.end' = (property, Svg.End) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/clip-rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule
    type ClipRule(property) =
        member this.nonzero = (property, Svg.Nonzero) |> Rule
        member this.evenodd = (property, Svg.Evenodd) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-color
    type FloodColor(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/flood-opacity
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-opacity
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-opacity
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-opacity
    type Opacity(property) =
        member this.value(opacity: float) =
            let value =
                if opacity > 1 then 1.0
                else if opacity < 0 then 0.0
                else opacity

            (property, Float value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/lighting-color
    type LightingColor(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stop-color
    type StopColor(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/color-interpolation
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/color-interpolation-filters
    type ColorInterpolation(property) =
        member this.auto = (property, Auto) |> Rule
        member this.sRGB = (property, Svg.Srgb) |> Rule
        member this.linearRGB = (property, Svg.LinearRgb) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill
    type Fill(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/image-rendering
    type ImageRendering(property) =
        member this.auto = (property, Auto) |> Rule
        member this.optimizeSpeed = (property, Svg.OptimizeSpeed) |> Rule
        member this.optimizeQuality = (property, Svg.OptimizeQuality) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/shape-rendering
    type ShapeRendering(property) =
        member this.auto = (property, Auto) |> Rule
        member this.optimizeSpeed = (property, Svg.OptimizeSpeed) |> Rule
        member this.crispEdges = (property, Svg.CrispEdges) |> Rule
        member this.geometricPrecision = (property, Svg.GeometricPrecision) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke
    type Stroke(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dasharray
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dashoffset
    type StrokeDash(property) =
        member this.value (dash: int list) =
            let value =
                dash
                |> List.map (fun x -> x.ToString())
                |> String.concat ", "
            (property, String value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linecap
    type StrokeLinecap(property) =
        member this.butt = (property, Svg.StrokeLinecap.Butt) |> Rule
        member this.round = (property, Svg.StrokeLinecap.Round) |> Rule
        member this.square = (property, Svg.StrokeLinecap.Square) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linejoin
    type StrokeLinejoin(property) =
        member this.arcs = (property, Svg.Arcs) |> Rule
        member this.bevel = (property, Svg.Bevel) |> Rule
        member this.miter = (property, Svg.Miter) |> Rule
        member this.miterClip = (property, Svg.MiterClip) |> Rule
        member this.round = (property, Svg.Round) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-miterlimit
    type StrokeMiterlimit(property) =
        member this.value (limit: int) =
            (property, Int limit) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-miterlimit
    type StrokeWidth(property) =
        member this.value (limit: ILengthPercentage) =
            (property, lengthPercentageToType limit) |> Rule