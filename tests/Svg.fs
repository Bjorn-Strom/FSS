namespace FSSTests

open Fet
open Utils
open Fss

module Svg =
     let tests =
        testList "Svg"
            [
                testCase
                    "Alignment baseline Baseline"
                    [AlignmentBaseline.baseline]
                    "alignment-baseline: baseline;"
                testCase
                    "Alignment baseline TextBottom"
                    [AlignmentBaseline.textBottom]
                    "alignment-baseline: text-bottom;"
                testCase
                    "Alignment baseline TextBeforeEdge"
                    [AlignmentBaseline.textBeforeEdge]
                    "alignment-baseline: text-before-edge;"
                testCase
                    "Alignment baseline Middle"
                    [AlignmentBaseline.middle]
                    "alignment-baseline: middle;"
                testCase
                    "Alignment baseline Central"
                    [AlignmentBaseline.central]
                    "alignment-baseline: central;"
                testCase
                    "Alignment baseline TextTop"
                    [AlignmentBaseline.textTop]
                    "alignment-baseline: text-top;"
                testCase
                    "Alignment baseline TextAfterEdge"
                    [AlignmentBaseline.textAfterEdge]
                    "alignment-baseline: text-after-edge;"
                testCase
                    "Alignment baseline Ideographic"
                    [AlignmentBaseline.ideographic]
                    "alignment-baseline: ideographic;"
                testCase
                    "Alignment baseline Alphabetic"
                    [AlignmentBaseline.alphabetic]
                    "alignment-baseline: alphabetic;"
                testCase
                    "Alignment baseline Hanging"
                    [AlignmentBaseline.hanging]
                    "alignment-baseline: hanging;"
                testCase
                    "Alignment baseline Mathematical"
                    [AlignmentBaseline.mathematical]
                    "alignment-baseline: mathematical;"
                testCase
                    "Alignment baseline Top"
                    [AlignmentBaseline.top]
                    "alignment-baseline: top;"
                testCase
                    "Alignment baseline Center"
                    [AlignmentBaseline.center]
                    "alignment-baseline: center;"
                testCase
                    "Alignment baseline Bottom"
                    [AlignmentBaseline.bottom]
                    "alignment-baseline: bottom;"
                testCase
                    "Baseline shift sub"
                    [BaselineShift.sub]
                    "baseline-shift: sub;"
                testCase
                    "Baseline shift super"
                    [BaselineShift.super]
                    "baseline-shift: super;"
                testCase
                    "Baseline shift px"
                    [BaselineShift.value (px 10)]
                    "baseline-shift: 10px;"
                testCase
                    "Baseline shift pct"
                    [BaselineShift.value (pct 74)]
                    "baseline-shift: 74%;"
                testCase
                    "Dominant baseline Ideographic"
                    [DominantBaseline.ideographic]
                    "dominant-baseline: ideographic;"
                testCase
                    "Dominant baseline Alphabetic"
                    [DominantBaseline.alphabetic]
                    "dominant-baseline: alphabetic;"
                testCase
                    "Dominant baseline Hanging"
                    [DominantBaseline.hanging]
                    "dominant-baseline: hanging;"
                testCase
                    "Dominant baseline Mathematical"
                    [DominantBaseline.mathematical]
                    "dominant-baseline: mathematical;"
                testCase
                    "Dominant baseline Central"
                    [DominantBaseline.central]
                    "dominant-baseline: central;"
                testCase
                    "Dominant baseline Middle"
                    [DominantBaseline.middle]
                    "dominant-baseline: middle;"
                testCase
                    "Dominant baseline TextAfterEdge"
                    [DominantBaseline.textAfterEdge]
                    "dominant-baseline: text-after-edge;"
                testCase
                    "Dominant baseline TextBeforeEdge"
                    [DominantBaseline.textBeforeEdge]
                    "dominant-baseline: text-before-edge;"
                testCase
                    "Dominant baseline TextTop"
                    [DominantBaseline.textTop]
                    "dominant-baseline: text-top;"
                testCase
                    "TextAnchor start"
                    [TextAnchor.start]
                    "text-anchor: start;"
                testCase
                    "TextAnchor middle"
                    [TextAnchor.middle]
                    "text-anchor: middle;"
                testCase
                    "TextAnchor end"
                    [TextAnchor.end']
                    "text-anchor: end;"
                testCase
                    "ClipRule nonzero"
                    [ClipRule.nonzero]
                    "clip-rule: nonzero;"
                testCase
                    "ClipRule evenodd"
                    [ClipRule.evenodd]
                    "clip-rule: evenodd;"
                testCase
                    "FloodColor color rgb"
                    [ FloodColor.rgb 255 0 0 ]
                    "flood-color: rgb(255, 0, 0);"
                testCase
                    "FloodColor color green"
                    [ FloodColor.green ]
                    "flood-color: green;"
                testCase
                    "FloodOpacity 1"
                    [ FloodOpacity.value 1.0 ]
                    "flood-opacity: 1;"
                testCase
                    "FloodOpacity 0"
                    [ FloodOpacity.value 0.0]
                    "flood-opacity: 0;"
                testCase
                    "FloodOpacity 50%"
                    [ FloodOpacity.value 0.5 ]
                    "flood-opacity: 0.5;"
                testCase
                    "FloodOpacity -10 should be 0"
                    [ FloodOpacity.value -10.0 ]
                    "flood-opacity: 0;"
                testCase
                    "FloodOpacity 10 should be 1"
                    [ FloodOpacity.value 10.0 ]
                    "flood-opacity: 1;"
                testCase
                    "FloodOpacity 1.5 should be 1"
                    [ FloodOpacity.value 1.5 ]
                    "flood-opacity: 1;"
                testCase
                    "LightingColor color rgb"
                    [ LightingColor.rgb 255 0 0 ]
                    "lighting-color: rgb(255, 0, 0);"
                testCase
                    "LightingColor color green"
                    [ LightingColor.green ]
                    "lighting-color: green;"
                testCase
                    "StopColor color rgb"
                    [ StopColor.rgb 255 0 0 ]
                    "stop-color: rgb(255, 0, 0);"
                testCase
                    "StopColor color green"
                    [ StopColor.green ]
                    "stop-color: green;"
                testCase
                    "StopOpacity 1"
                    [ StopOpacity.value 1.0 ]
                    "stop-opacity: 1;"
                testCase
                    "StopOpacity 0"
                    [ StopOpacity.value 0.0]
                    "stop-opacity: 0;"
                testCase
                    "StopOpacity 50%"
                    [ StopOpacity.value 0.5 ]
                    "stop-opacity: 0.5;"
                testCase
                    "StopOpacity -10 should be 0"
                    [ StopOpacity.value -10.0 ]
                    "stop-opacity: 0;"
                testCase
                    "StopOpacity 10 should be 1"
                    [ StopOpacity.value 10.0 ]
                    "stop-opacity: 1;"
                testCase
                    "StopOpacity 1.5 should be 1"
                    [ StopOpacity.value 1.5 ]
                    "stop-opacity: 1;"
                testCase
                    "ColorInterpolation srgb"
                    [ ColorInterpolation.sRGB ]
                    "color-interpolation: sRGB;"
                testCase
                    "ColorInterpolation linearRGB"
                    [ ColorInterpolation.linearRGB ]
                    "color-interpolation: linearRGB;"
                testCase
                    "ColorInterpolation auto"
                    [ ColorInterpolation.auto ]
                    "color-interpolation: auto;"
                testCase
                    "ColorInterpolationFilters srgb"
                    [ ColorInterpolationFilters.sRGB ]
                    "color-interpolation-filters: sRGB;"
                testCase
                    "ColorInterpolationFilters linearRGB"
                    [ ColorInterpolationFilters.linearRGB ]
                    "color-interpolation-filters: linearRGB;"
                testCase
                    "ColorInterpolationFilters auto"
                    [ ColorInterpolationFilters.auto ]
                    "color-interpolation-filters: auto;"
                testCase
                    "Fill color rgb"
                    [ Fill.rgb 255 0 0 ]
                    "fill: rgb(255, 0, 0);"
                testCase
                    "Fill color green"
                    [ Fill.green ]
                    "fill: green;"
                testCase
                    "FillOpacity 1"
                    [ FillOpacity.value 1.0 ]
                    "fill-opacity: 1;"
                testCase
                    "FillOpacity 0"
                    [ FillOpacity.value 0.0]
                    "fill-opacity: 0;"
                testCase
                    "FillOpacity 50%"
                    [ FillOpacity.value 0.5 ]
                    "fill-opacity: 0.5;"
                testCase
                    "FillOpacity -10 should be 0"
                    [ FillOpacity.value -10.0 ]
                    "fill-opacity: 0;"
                testCase
                    "FillOpacity 10 should be 1"
                    [ FillOpacity.value 10.0 ]
                    "fill-opacity: 1;"
                testCase
                    "FillOpacity 1.5 should be 1"
                    [ FillOpacity.value 1.5 ]
                    "fill-opacity: 1;"
                testCase
                    "FillRule nonzero"
                    [FillRule.nonzero]
                    "fill-rule: nonzero;"
                testCase
                    "FillRule evenodd"
                    [FillRule.evenodd]
                    "fill-rule: evenodd;"
                testCase
                    "ImageRendering optimize speed"
                    [Svg.ImageRendering.optimizeSpeed]
                    "image-rendering: optimize-speed;"
                testCase
                    "ImageRendering optimize quality"
                    [Svg.ImageRendering.optimizeQuality]
                    "image-rendering: optimize-quality;"
                testCase
                    "ImageRendering auto"
                    [Svg.ImageRendering.auto]
                    "image-rendering: auto;"
                testCase
                    "ShapeRendering optimize speed"
                    [ShapeRendering.optimizeSpeed]
                    "shape-rendering: optimize-speed;"
                testCase
                    "ShapeRendering crisp edges"
                    [ShapeRendering.crispEdges]
                    "shape-rendering: crisp-edges;"
                testCase
                    "ShapeRendering geometric precision"
                    [ShapeRendering.geometricPrecision]
                    "shape-rendering: geometric-precision;"
                testCase
                    "ShapeRendering auto"
                    [ShapeRendering.auto]
                    "shape-rendering: auto;"
                testCase
                    "Stroke color rgb"
                    [ Stroke.rgb 255 0 0 ]
                    "stroke: rgb(255, 0, 0);"
                testCase
                    "Stroke color green"
                    [ Stroke.green ]
                    "stroke: green;"
                testCase
                    "StrokeOpacity 1"
                    [ StrokeOpacity.value 1.0 ]
                    "stroke-opacity: 1;"
                testCase
                    "StrokeOpacity 0"
                    [ StrokeOpacity.value 0.0]
                    "stroke-opacity: 0;"
                testCase
                    "StrokeOpacity 50%"
                    [ StrokeOpacity.value 0.5 ]
                    "stroke-opacity: 0.5;"
                testCase
                    "StrokeOpacity -10 should be 0"
                    [ StrokeOpacity.value -10.0 ]
                    "stroke-opacity: 0;"
                testCase
                    "StrokeOpacity 10 should be 1"
                    [ StrokeOpacity.value 10.0 ]
                    "stroke-opacity: 1;"
                testCase
                    "StrokeOpacity 1.5 should be 1"
                    [ StrokeOpacity.value 1.5 ]
                    "stroke-opacity: 1;"
                testCase
                    "Stroke dasharray 5, 3, 2"
                    [StrokeDasharray.value [5;3;2]]
                    "stroke-dasharray: 5, 3, 2;"
                testCase
                    "Stroke dasharray 400"
                    [StrokeDasharray.value [400]]
                    "stroke-dasharray: 400;"
                testCase
                    "Stroke dashoffset 5, 3, 2"
                    [StrokeDashoffset.value [5;3;2]]
                    "stroke-dashoffset: 5, 3, 2;"
                testCase
                    "Stroke dashoffset 400"
                    [StrokeDashoffset.value [400]]
                    "stroke-dashoffset: 400;"
                testCase
                    "StrokeLinecap butt"
                    [StrokeLinecap.butt]
                    "stroke-linecap: butt;"
                testCase
                    "StrokeLinecap round"
                    [StrokeLinecap.round]
                    "stroke-linecap: round;"
                testCase
                    "StrokeLinecap square"
                    [StrokeLinecap.square]
                    "stroke-linecap: square;"
                    
                    
                    
                testCase
                    "StrokeLinejoin arcs"
                    [StrokeLinejoin.arcs]
                    "stroke-linejoin: arcs;"
                testCase
                    "StrokeLinejoin bevel"
                    [StrokeLinejoin.bevel]
                    "stroke-linejoin: bevel;"
                testCase
                    "StrokeLinejoin miter"
                    [StrokeLinejoin.miter]
                    "stroke-linejoin: miter;"
                testCase
                    "StrokeLinejoin miter"
                    [StrokeLinejoin.miter]
                    "stroke-linejoin: miter;"
                testCase
                    "StrokeLinejoin miterClip"
                    [StrokeLinejoin.miterClip]
                    "stroke-linejoin: miter-clip;"
                testCase
                    "StrokeLinejoin round"
                    [StrokeLinejoin.round]
                    "stroke-linejoin: round;"
                testCase
                    "Stroke miterlimit 5"
                    [StrokeMiterlimit.value 5]
                    "stroke-miterlimit: 5;"
                testCase
                    "Stroke width px"
                    [StrokeWidth.value (px 5)]
                    "stroke-width: 5px;"
                testCase
                    "Stroke width em"
                    [StrokeWidth.value (em 2)]
                    "stroke-width: 2em;"
                testCase
                    "Stroke width pct"
                    [StrokeWidth.value (pct 50) ]
                    "stroke-width: 50%;"
                ]