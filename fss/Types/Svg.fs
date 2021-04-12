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

        type FillRule =
            | Nonzero
            | Evenodd

        type ImageRendering =
            | OptimizeSpeed
            | OptimizeQuality
            interface ISVGImageRendering

        type ShapeRendering =
            | OptimizeSpeed
            | CrispEdges
            | GeometricPrecision
            interface IShapeRendering

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

        // Not done
        // stoke  Miterlimit: int


        // stroke width: size percent