namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Svg =
     let tests =
        testList "Svg"
            [
                testCase
                    "Alignment baseline Baseline"
                    [AlignmentBaseline.baseline]
                    ["alignmentBaseline" ==> "baseline"]
                testCase
                    "Alignment baseline TextBottom"
                    [AlignmentBaseline.textBottom]
                    ["alignmentBaseline" ==> "text-bottom"]
                testCase
                    "Alignment baseline TextBeforeEdge"
                    [AlignmentBaseline.textBeforeEdge]
                    ["alignmentBaseline" ==> "text-before-edge"]
                testCase
                    "Alignment baseline Middle"
                    [AlignmentBaseline.middle]
                    ["alignmentBaseline" ==> "middle"]
                testCase
                    "Alignment baseline Central"
                    [AlignmentBaseline.central]
                    ["alignmentBaseline" ==> "central"]
                testCase
                    "Alignment baseline TextTop"
                    [AlignmentBaseline.textTop]
                    ["alignmentBaseline" ==> "text-top"]
                testCase
                    "Alignment baseline TextAfterEdge"
                    [AlignmentBaseline.textAfterEdge]
                    ["alignmentBaseline" ==> "text-after-edge"]
                testCase
                    "Alignment baseline Ideographic"
                    [AlignmentBaseline.ideographic]
                    ["alignmentBaseline" ==> "ideographic"]
                testCase
                    "Alignment baseline Alphabetic"
                    [AlignmentBaseline.alphabetic]
                    ["alignmentBaseline" ==> "alphabetic"]
                testCase
                    "Alignment baseline Hanging"
                    [AlignmentBaseline.hanging]
                    ["alignmentBaseline" ==> "hanging"]
                testCase
                    "Alignment baseline Mathematical"
                    [AlignmentBaseline.mathematical]
                    ["alignmentBaseline" ==> "mathematical"]
                testCase
                    "Alignment baseline Top"
                    [AlignmentBaseline.top]
                    ["alignmentBaseline" ==> "top"]
                testCase
                    "Alignment baseline Center"
                    [AlignmentBaseline.center]
                    ["alignmentBaseline" ==> "center"]
                testCase
                    "Alignment baseline Bottom"
                    [AlignmentBaseline.bottom]
                    ["alignmentBaseline" ==> "bottom"]
                testCase
                    "Baseline shift sub"
                    [BaselineShift.sub]
                    ["baselineShift" ==> "sub"]
                testCase
                    "Baseline shift super"
                    [BaselineShift.super]
                    ["baselineShift" ==> "super"]
                testCase
                    "Baseline shift px"
                    [BaselineShift' <| px 10]
                    ["baselineShift" ==> "10px"]
                testCase
                    "Baseline shift pct"
                    [BaselineShift' <| pct 74]
                    ["baselineShift" ==> "74%"]

                testCase
                    "Dominant baseline Ideographic"
                    [DominantBaseline.ideographic]
                    ["dominantBaseline" ==> "ideographic"]
                testCase
                    "Dominant baseline Alphabetic"
                    [DominantBaseline.alphabetic]
                    ["dominantBaseline" ==> "alphabetic"]
                testCase
                    "Dominant baseline Hanging"
                    [DominantBaseline.hanging]
                    ["dominantBaseline" ==> "hanging"]
                testCase
                    "Dominant baseline Mathematical"
                    [DominantBaseline.mathematical]
                    ["dominantBaseline" ==> "mathematical"]
                testCase
                    "Dominant baseline Central"
                    [DominantBaseline.central]
                    ["dominantBaseline" ==> "central"]
                testCase
                    "Dominant baseline Middle"
                    [DominantBaseline.middle]
                    ["dominantBaseline" ==> "middle"]
                testCase
                    "Dominant baseline TextAfterEdge"
                    [DominantBaseline.textAfterEdge]
                    ["dominantBaseline" ==> "text-after-edge"]
                testCase
                    "Dominant baseline TextBeforeEdge"
                    [DominantBaseline.textBeforeEdge]
                    ["dominantBaseline" ==> "text-before-edge"]
                testCase
                    "Dominant baseline TextTop"
                    [DominantBaseline.textTop]
                    ["dominantBaseline" ==> "text-top"]
                testCase
                    "TextAnchor start"
                    [TextAnchor.start]
                    ["textAnchor" ==> "start"]
                testCase
                    "TextAnchor middle"
                    [TextAnchor.middle]
                    ["textAnchor" ==> "middle"]
                testCase
                    "TextAnchor end"
                    [TextAnchor.end']
                    ["textAnchor" ==> "end"]
                testCase
                    "ClipRule nonzero"
                    [ClipRule.nonzero]
                    ["clipRule" ==> "nonzero"]
                testCase
                    "ClipRule evenodd"
                    [ClipRule.evenodd]
                    ["clipRule" ==> "evenodd"]
                testCase
                    "FloodColor color rgb"
                    [ FloodColor.rgb 255 0 0 ]
                    ["floodColor" ==> "rgb(255, 0, 0)"]
                testCase
                    "FloodColor color green"
                    [ FloodColor.green ]
                    ["floodColor" ==> "#008000"]
                testCase
                    "FloodOpacity 1"
                    [ FloodOpacity' 1.0 ]
                    ["floodOpacity" ==> "1"]
                testCase
                    "FloodOpacity 0"
                    [ FloodOpacity' 0.0]
                    ["floodOpacity" ==> "0"]
                testCase
                    "FloodOpacity 50%"
                    [ FloodOpacity' 0.5 ]
                    ["floodOpacity" ==> "0.5"]
                testCase
                    "FloodOpacity -10 should be 0"
                    [ FloodOpacity' -10.0 ]
                    ["floodOpacity" ==> "0"]
                testCase
                    "FloodOpacity 10 should be 1"
                    [ FloodOpacity' 10.0 ]
                    ["floodOpacity" ==> "1"]
                testCase
                    "FloodOpacity 1.5 should be 1"
                    [ FloodOpacity' 1.5 ]
                    ["floodOpacity" ==> "1"]
                testCase
                    "LightingColor color rgb"
                    [ LightingColor.rgb 255 0 0 ]
                    ["lightingColor" ==> "rgb(255, 0, 0)"]
                testCase
                    "LightingColor color green"
                    [ LightingColor.green ]
                    ["lightingColor" ==> "#008000"]
                testCase
                    "StopColor color rgb"
                    [ StopColor.rgb 255 0 0 ]
                    ["stopColor" ==> "rgb(255, 0, 0)"]
                testCase
                    "StopColor color green"
                    [ StopColor.green ]
                    ["stopColor" ==> "#008000"]
                testCase
                    "StopOpacity 1"
                    [ StopOpacity' 1.0 ]
                    ["stopOpacity" ==> "1"]
                testCase
                    "StopOpacity 0"
                    [ StopOpacity' 0.0]
                    ["stopOpacity" ==> "0"]
                testCase
                    "StopOpacity 50%"
                    [ StopOpacity' 0.5 ]
                    ["stopOpacity" ==> "0.5"]
                testCase
                    "StopOpacity -10 should be 0"
                    [ StopOpacity' -10.0 ]
                    ["stopOpacity" ==> "0"]
                testCase
                    "StopOpacity 10 should be 1"
                    [ StopOpacity' 10.0 ]
                    ["stopOpacity" ==> "1"]
                testCase
                    "StopOpacity 1.5 should be 1"
                    [ StopOpacity' 1.5 ]
                    ["stopOpacity" ==> "1"]
                testCase
                    "ColorInterpolation srgb"
                    [ ColorInterpolation.sRGB ]
                    ["colorInterpolation" ==> "sRGB"]
                testCase
                    "ColorInterpolation linearRGB"
                    [ ColorInterpolation.linearRGB ]
                    ["colorInterpolation" ==> "linearRGB"]
                testCase
                    "ColorInterpolation auto"
                    [ ColorInterpolation.auto ]
                    ["colorInterpolation" ==> "auto"]
                testCase
                    "ColorInterpolationFilters srgb"
                    [ ColorInterpolationFilters.sRGB ]
                    ["colorInterpolationFilters" ==> "sRGB"]
                testCase
                    "ColorInterpolationFilters linearRGB"
                    [ ColorInterpolationFilters.linearRGB ]
                    ["colorInterpolationFilters" ==> "linearRGB"]
                testCase
                    "ColorInterpolationFilters auto"
                    [ ColorInterpolationFilters.auto ]
                    ["colorInterpolationFilters" ==> "auto"]
                testCase
                    "Fill color rgb"
                    [ Fill.rgb 255 0 0 ]
                    ["fill" ==> "rgb(255, 0, 0)"]
                testCase
                    "Fill color green"
                    [ Fill.green ]
                    ["fill" ==> "#008000"]
                testCase
                    "FillOpacity 1"
                    [ FillOpacity' 1.0 ]
                    ["fillOpacity" ==> "1"]
                testCase
                    "FillOpacity 0"
                    [ FillOpacity' 0.0]
                    ["fillOpacity" ==> "0"]
                testCase
                    "FillOpacity 50%"
                    [ FillOpacity' 0.5 ]
                    ["fillOpacity" ==> "0.5"]
                testCase
                    "FillOpacity -10 should be 0"
                    [ FillOpacity' -10.0 ]
                    ["fillOpacity" ==> "0"]
                testCase
                    "FillOpacity 10 should be 1"
                    [ FillOpacity' 10.0 ]
                    ["fillOpacity" ==> "1"]
                testCase
                    "FillOpacity 1.5 should be 1"
                    [ FillOpacity' 1.5 ]
                    ["fillOpacity" ==> "1"]
                testCase
                    "FillRule nonzero"
                    [FillRule.nonzero]
                    ["fillRule" ==> "nonzero"]
                testCase
                    "FillRule evenodd"
                    [FillRule.evenodd]
                    ["fillRule" ==> "evenodd"]
                testCase
                    "ImageRendering optimize speed"
                    [ImageRendering.optimizeSpeed]
                    ["imageRendering" ==> "optimize-speed"]
                testCase
                    "ImageRendering optimize quality"
                    [ImageRendering.optimizeQuality]
                    ["imageRendering" ==> "optimize-quality"]
                testCase
                    "ImageRendering auto"
                    [ImageRendering.auto]
                    ["imageRendering" ==> "auto"]
                testCase
                    "ShapeRendering optimize speed"
                    [ShapeRendering.optimizeSpeed]
                    ["shapeRendering" ==> "optimize-speed"]
                testCase
                    "ShapeRendering crisp edges"
                    [ShapeRendering.crispEdges]
                    ["shapeRendering" ==> "crisp-edges"]
                testCase
                    "ShapeRendering geometric precision"
                    [ShapeRendering.geometricPrecision]
                    ["shapeRendering" ==> "geometric-precision"]
                testCase
                    "ShapeRendering auto"
                    [ShapeRendering.auto]
                    ["shapeRendering" ==> "auto"]
                testCase
                    "Stroke color rgb"
                    [ Stroke.rgb 255 0 0 ]
                    ["stroke" ==> "rgb(255, 0, 0)"]
                testCase
                    "Stroke color green"
                    [ Stroke.green ]
                    ["stroke" ==> "#008000"]
                testCase
                    "StrokeOpacity 1"
                    [ StrokeOpacity' 1.0 ]
                    ["strokeOpacity" ==> "1"]
                testCase
                    "StrokeOpacity 0"
                    [ StrokeOpacity' 0.0]
                    ["strokeOpacity" ==> "0"]
                testCase
                    "StrokeOpacity 50%"
                    [ StrokeOpacity' 0.5 ]
                    ["strokeOpacity" ==> "0.5"]
                testCase
                    "StrokeOpacity -10 should be 0"
                    [ StrokeOpacity' -10.0 ]
                    ["strokeOpacity" ==> "0"]
                testCase
                    "StrokeOpacity 10 should be 1"
                    [ StrokeOpacity' 10.0 ]
                    ["strokeOpacity" ==> "1"]
                testCase
                    "StrokeOpacity 1.5 should be 1"
                    [ StrokeOpacity' 1.5 ]
                    ["strokeOpacity" ==> "1"]
                testCase
                    "Stroke dasharray 5, 3, 2"
                    [StrokeDasharray' [5;3;2]]
                    ["strokeDasharray" ==> "5, 3, 2"]
                testCase
                    "Stroke dasharray 400"
                    [StrokeDasharray' [400]]
                    ["strokeDasharray" ==> "400"]
                testCase
                    "Stroke dashoffset 5, 3, 2"
                    [StrokeDashoffset' [5;3;2]]
                    ["strokeDashoffset" ==> "5, 3, 2"]
                testCase
                    "Stroke dashoffset 400"
                    [StrokeDashoffset' [400]]
                    ["strokeDashoffset" ==> "400"]
                testCase
                    "StrokeLinecap butt"
                    [StrokeLinecap.butt]
                    ["strokeLinecap" ==> "butt"]
                testCase
                    "StrokeLinecap round"
                    [StrokeLinecap.round]
                    ["strokeLinecap" ==> "round"]
                testCase
                    "StrokeLinecap square"
                    [StrokeLinecap.square]
                    ["strokeLinecap" ==> "square"]
                testCase
                    "StrokeLinejoin arcs"
                    [StrokeLinejoin.arcs]
                    ["strokeLinejoin" ==> "arcs"]
                testCase
                    "StrokeLinejoin bevel"
                    [StrokeLinejoin.bevel]
                    ["strokeLinejoin" ==> "bevel"]
                testCase
                    "StrokeLinejoin miter"
                    [StrokeLinejoin.miter]
                    ["strokeLinejoin" ==> "miter"]
                testCase
                    "StrokeLinejoin miter"
                    [StrokeLinejoin.miter]
                    ["strokeLinejoin" ==> "miter"]
                testCase
                    "StrokeLinejoin miterClip"
                    [StrokeLinejoin.miterClip]
                    ["strokeLinejoin" ==> "miter-clip"]
                testCase
                    "StrokeLinejoin round"
                    [StrokeLinejoin.round]
                    ["strokeLinejoin" ==> "round"]
                testCase
                    "Stroke miterlimit 5"
                    [StrokeMiterlimit' 5]
                    ["strokeMiterlimit" ==> "5"]
                testCase
                    "Stroke width px"
                    [StrokeWidth' <| px 5]
                    ["strokeWidth" ==> "5px"]
                testCase
                    "Stroke width em"
                    [StrokeWidth' <| em 2.]
                    ["strokeWidth" ==> "2.0em"]
                testCase
                    "Stroke width pct"
                    [StrokeWidth' <| pct 50 ]
                    ["strokeWidth" ==> "50%"]
                ]