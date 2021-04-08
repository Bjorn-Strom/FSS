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

        // Not done
        type TextAnchor =
            | Start
            | Middle
            | End

        type ClipRule =
            | Nonzero
            | Evenodd

        // Flood color er en Color

        // Flood opacity tall mellom 0 og 1

        // lighting color er en Color

        // Stop color er en Color

        // Stop opacity tall mellom 0 og 1

        type ColorInterpolation =
            // Auto
            | SRGB // Skal bli sRGB
            | LinearRGB // skal bli linearRGB

        type ColorInterpolationFilters =
            // Auto
            | SRGB // Skal bli sRGB
            | LinearRGB // skal bli linearRGB

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