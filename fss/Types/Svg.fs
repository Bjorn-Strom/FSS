namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type BaselineShift =
        | Sub
        | Super
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type TextAnchor =
        | Start
        | Middle
        | End
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type ClipRule =
        | Nonzero
        | Evenodd
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type ColorInterpolation =
        | Srgb
        | LinearRgb
        interface ICssValue with
            member this.Stringify() =
                match this with
                | Srgb -> "sRGB"
                | LinearRgb -> "linearRGB"

    type ImageRendering =
        | OptimizeSpeed
        | OptimizeQuality
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type ShapeRendering =
        | OptimizeSpeed
        | CrispEdges
        | GeometricPrecision
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type StrokeLinecap =
        | Butt
        | Round
        | Square
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type StrokeLinejoin =
        | Arcs
        | Bevel
        | Miter
        | MiterClip
        | Round
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module SvgClasses =
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/alignment-baseline
        type AlignmentBaselineClass(property) =
            member this.auto = (property, Auto) |> Rule

            member this.baseline =
                (property, AlignmentBaseline.Baseline) |> Rule

            member this.textBottom =
                (property, AlignmentBaseline.TextBottom) |> Rule

            member this.textBeforeEdge =
                (property, AlignmentBaseline.TextBeforeEdge)
                |> Rule

            member this.middle =
                (property, AlignmentBaseline.Middle) |> Rule

            member this.central =
                (property, AlignmentBaseline.Central) |> Rule

            member this.textTop =
                (property, AlignmentBaseline.TextTop) |> Rule

            member this.textAfterEdge =
                (property, AlignmentBaseline.TextAfterEdge)
                |> Rule

            member this.ideographic =
                (property, AlignmentBaseline.Ideographic) |> Rule

            member this.alphabetic =
                (property, AlignmentBaseline.Alphabetic) |> Rule

            member this.hanging =
                (property, AlignmentBaseline.Hanging) |> Rule

            member this.mathematical =
                (property, AlignmentBaseline.Mathematical) |> Rule

            member this.top =
                (property, AlignmentBaseline.Top) |> Rule

            member this.center =
                (property, AlignmentBaseline.Center) |> Rule

            member this.bottom =
                (property, AlignmentBaseline.Bottom) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/baseline-shift
        type BaselineShift(property) =
            member this.value(shift: ILengthPercentage) =
                (property, lengthPercentageToType shift) |> Rule

            member this.sub = (property, Sub) |> Rule
            member this.super = (property, Super) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/dominant-baseline
        type DominantBaseline(property) =
            member this.ideographic =
                (property, DominantBaseline.Ideographic) |> Rule

            member this.alphabetic =
                (property, DominantBaseline.Alphabetic) |> Rule

            member this.hanging =
                (property, DominantBaseline.Hanging) |> Rule

            member this.mathematical =
                (property, DominantBaseline.Mathematical) |> Rule

            member this.central =
                (property, DominantBaseline.Central) |> Rule

            member this.middle =
                (property, DominantBaseline.Middle) |> Rule

            member this.textAfterEdge =
                (property, DominantBaseline.TextAfterEdge) |> Rule

            member this.textBeforeEdge =
                (property, DominantBaseline.TextBeforeEdge)
                |> Rule

            member this.textTop =
                (property, DominantBaseline.TextTop) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/text-anchor
        type TextAnchor(property) =
            member this.start = (property, Start) |> Rule
            member this.middle = (property, Middle) |> Rule
            member this.end' = (property, End) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/clip-rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule
        type ClipRule(property) =
            member this.nonzero = (property, Nonzero) |> Rule
            member this.evenodd = (property, Evenodd) |> Rule
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
            member this.sRGB = (property, Srgb) |> Rule
            member this.linearRGB = (property, LinearRgb) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill
        type Fill(property) =
            inherit ColorClass.Color(property)
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/image-rendering
        type ImageRendering(property) =
            member this.auto = (property, Auto) |> Rule
            member this.optimizeSpeed = (property, OptimizeSpeed) |> Rule
            member this.optimizeQuality = (property, OptimizeQuality) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/shape-rendering
        type ShapeRendering(property) =
            member this.auto = (property, Auto) |> Rule
            member this.optimizeSpeed = (property, OptimizeSpeed) |> Rule
            member this.crispEdges = (property, CrispEdges) |> Rule
            member this.geometricPrecision = (property, GeometricPrecision) |> Rule
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
            member this.butt = (property, StrokeLinecap.Butt) |> Rule
            member this.round = (property, StrokeLinecap.Round) |> Rule
            member this.square = (property, StrokeLinecap.Square) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linejoin
        type StrokeLinejoin(property) =
            member this.arcs = (property, Arcs) |> Rule
            member this.bevel = (property, Bevel) |> Rule
            member this.miter = (property, Miter) |> Rule
            member this.miterClip = (property, MiterClip) |> Rule
            member this.round = (property, Round) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-miterlimit
        type StrokeMiterlimit(property) =
            member this.value (limit: int) =
                (property, Int limit) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-miterlimit
        type StrokeWidth(property) =
            member this.value (limit: ILengthPercentage) =
                (property, lengthPercentageToType limit) |> Rule