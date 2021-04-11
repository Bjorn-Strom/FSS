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

        type BaselineShift =
            | Sub
            | Super
            interface IBaselineShift

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
            interface IDominantBaseline

        type TextAnchor =
            | Start
            | Middle
            | End

        type ClipRule =
            | Nonzero
            | Evenodd

        type ColorInterpolation =
            | Srgb
            | LinearRgb
            interface IColorInterpolation

        type ColorInterpolationFilters =
            | Srgb
            | LinearRgb
            interface IColorInterpolationFilters






        // Not done
        // Fill er en farge

        type FillRule =
            | Nonzero
            | Evenod

        // Fill opacity tall mellom 0 og 1

        type ImageRendering =
            // Auto
            | OptimizeSpeed
            | OptimizeQuality

        type ShapeRendering =
            // Auto
            | OptimizeSpeed
            | CrispEdges
            | GeometricPrecision

        // Stroke er en farge

        // Stroke dasharray, int, size, percent

        // Stroke dashoffset: innt percent

        type StrokeLinecap =
            | Butt
            | Round
            | Square

        type StrokeLinejoin =
            | Arcs
            | Bevel
            | Miter
            | MiterClip
            | Round

        // Miterlimit: int

        // Stroke opacity tall mellom 0 og 1

        // stroke width: size percent