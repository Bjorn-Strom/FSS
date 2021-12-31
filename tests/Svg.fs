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
                    [Svg.AlignmentBaseline.baseline]
                    "{ alignment-baseline: baseline; }"
                testCase
                    "Alignment baseline TextBottom"
                    [Svg.AlignmentBaseline.textBottom]
                    "{ alignment-baseline: text-bottom; }"
                testCase
                    "Alignment baseline TextBeforeEdge"
                    [Svg.AlignmentBaseline.textBeforeEdge]
                    "{ alignment-baseline: text-before-edge; }"
                testCase
                    "Alignment baseline Middle"
                    [Svg.AlignmentBaseline.middle]
                    "{ alignment-baseline: middle; }"
                testCase
                    "Alignment baseline Central"
                    [Svg.AlignmentBaseline.central]
                    "{ alignment-baseline: central; }"
                testCase
                    "Alignment baseline TextTop"
                    [Svg.AlignmentBaseline.textTop]
                    "{ alignment-baseline: text-top; }"
                testCase
                    "Alignment baseline TextAfterEdge"
                    [Svg.AlignmentBaseline.textAfterEdge]
                    "{ alignment-baseline: text-after-edge; }"
                testCase
                    "Alignment baseline Ideographic"
                    [Svg.AlignmentBaseline.ideographic]
                    "{ alignment-baseline: ideographic; }"
                testCase
                    "Alignment baseline Alphabetic"
                    [Svg.AlignmentBaseline.alphabetic]
                    "{ alignment-baseline: alphabetic; }"
                testCase
                    "Alignment baseline Hanging"
                    [Svg.AlignmentBaseline.hanging]
                    "{ alignment-baseline: hanging; }"
                testCase
                    "Alignment baseline Mathematical"
                    [Svg.AlignmentBaseline.mathematical]
                    "{ alignment-baseline: mathematical; }"
                testCase
                    "Alignment baseline Top"
                    [Svg.AlignmentBaseline.top]
                    "{ alignment-baseline: top; }"
                testCase
                    "Alignment baseline Center"
                    [Svg.AlignmentBaseline.center]
                    "{ alignment-baseline: center; }"
                testCase
                    "Alignment baseline Bottom"
                    [Svg.AlignmentBaseline.bottom]
                    "{ alignment-baseline: bottom; }"
                testCase
                    "Baseline shift sub"
                    [Svg.BaselineShift.sub]
                    "{ baseline-shift: sub; }"
                testCase
                    "Baseline shift super"
                    [Svg.BaselineShift.super]
                    "{ baseline-shift: super; }"
                testCase
                    "Baseline shift px"
                    [Svg.BaselineShift.value (px 10)]
                    "{ baseline-shift: 10px; }"
                testCase
                    "Baseline shift pct"
                    [Svg.BaselineShift.value (pct 74)]
                    "{ baseline-shift: 74%; }"
                testCase
                    "Dominant baseline Ideographic"
                    [Svg.DominantBaseline.ideographic]
                    "{ dominant-baseline: ideographic; }"
                testCase
                    "Dominant baseline Alphabetic"
                    [Svg.DominantBaseline.alphabetic]
                    "{ dominant-baseline: alphabetic; }"
                testCase
                    "Dominant baseline Hanging"
                    [Svg.DominantBaseline.hanging]
                    "{ dominant-baseline: hanging; }"
                testCase
                    "Dominant baseline Mathematical"
                    [Svg.DominantBaseline.mathematical]
                    "{ dominant-baseline: mathematical; }"
                testCase
                    "Dominant baseline Central"
                    [Svg.DominantBaseline.central]
                    "{ dominant-baseline: central; }"
                testCase
                    "Dominant baseline Middle"
                    [Svg.DominantBaseline.middle]
                    "{ dominant-baseline: middle; }"
                testCase
                    "Dominant baseline TextAfterEdge"
                    [Svg.DominantBaseline.textAfterEdge]
                    "{ dominant-baseline: text-after-edge; }"
                testCase
                    "Dominant baseline TextBeforeEdge"
                    [Svg.DominantBaseline.textBeforeEdge]
                    "{ dominant-baseline: text-before-edge; }"
                testCase
                    "Dominant baseline TextTop"
                    [Svg.DominantBaseline.textTop]
                    "{ dominant-baseline: text-top; }"
                testCase
                    "TextAnchor start"
                    [Svg.TextAnchor.start]
                    "{ text-anchor: start; }"
                testCase
                    "TextAnchor middle"
                    [Svg.TextAnchor.middle]
                    "{ text-anchor: middle; }"
                testCase
                    "TextAnchor end"
                    [Svg.TextAnchor.end']
                    "{ text-anchor: end; }"
                testCase
                    "ClipRule nonzero"
                    [Svg.ClipRule.nonzero]
                    "{ clip-rule: nonzero; }"
                testCase
                    "ClipRule evenodd"
                    [Svg.ClipRule.evenodd]
                    "{ clip-rule: evenodd; }"
                testCase
                    "FloodColor color rgb"
                    [ Svg.FloodColor.rgb 255 0 0 ]
                    "{ flood-color: rgb(255, 0, 0); }"
                testCase
                    "FloodColor color green"
                    [ Svg.FloodColor.green ]
                    "{ flood-color: green; }"
                testCase
                    "FloodOpacity 1"
                    [ Svg.FloodOpacity.value 1.0 ]
                    "{ flood-opacity: 1; }"
                testCase
                    "FloodOpacity 0"
                    [ Svg.FloodOpacity.value 0.0]
                    "{ flood-opacity: 0; }"
                testCase
                    "FloodOpacity 50%"
                    [ Svg.FloodOpacity.value 0.5 ]
                    "{ flood-opacity: 0.5; }"
                testCase
                    "FloodOpacity -10 should be 0"
                    [ Svg.FloodOpacity.value -10.0 ]
                    "{ flood-opacity: 0; }"
                testCase
                    "FloodOpacity 10 should be 1"
                    [ Svg.FloodOpacity.value 10.0 ]
                    "{ flood-opacity: 1; }"
                testCase
                    "FloodOpacity 1.5 should be 1"
                    [ Svg.FloodOpacity.value 1.5 ]
                    "{ flood-opacity: 1; }"
                testCase
                    "LightingColor color rgb"
                    [ Svg.LightingColor.rgb 255 0 0 ]
                    "{ lighting-color: rgb(255, 0, 0); }"
                testCase
                    "LightingColor color green"
                    [ Svg.LightingColor.green ]
                    "{ lighting-color: green; }"
                testCase
                    "StopColor color rgb"
                    [ Svg.StopColor.rgb 255 0 0 ]
                    "{ stop-color: rgb(255, 0, 0); }"
                testCase
                    "StopColor color green"
                    [ Svg.StopColor.green ]
                    "{ stop-color: green; }"
                testCase
                    "StopOpacity 1"
                    [ Svg.StopOpacity.value 1.0 ]
                    "{ stop-opacity: 1; }"
                testCase
                    "StopOpacity 0"
                    [ Svg.StopOpacity.value 0.0]
                    "{ stop-opacity: 0; }"
                testCase
                    "StopOpacity 50%"
                    [ Svg.StopOpacity.value 0.5 ]
                    "{ stop-opacity: 0.5; }"
                testCase
                    "StopOpacity -10 should be 0"
                    [ Svg.StopOpacity.value -10.0 ]
                    "{ stop-opacity: 0; }"
                testCase
                    "StopOpacity 10 should be 1"
                    [ Svg.StopOpacity.value 10.0 ]
                    "{ stop-opacity: 1; }"
                testCase
                    "StopOpacity 1.5 should be 1"
                    [ Svg.StopOpacity.value 1.5 ]
                    "{ stop-opacity: 1; }"
                testCase
                    "ColorInterpolation srgb"
                    [ Svg.ColorInterpolation.sRGB ]
                    "{ color-interpolation: sRGB; }"
                testCase
                    "ColorInterpolation linearRGB"
                    [ Svg.ColorInterpolation.linearRGB ]
                    "{ color-interpolation: linearRGB; }"
                testCase
                    "ColorInterpolation auto"
                    [ Svg.ColorInterpolation.auto ]
                    "{ color-interpolation: auto; }"
                testCase
                    "ColorInterpolationFilters srgb"
                    [ Svg.ColorInterpolationFilters.sRGB ]
                    "{ color-interpolation-filters: sRGB; }"
                testCase
                    "ColorInterpolationFilters linearRGB"
                    [ Svg.ColorInterpolationFilters.linearRGB ]
                    "{ color-interpolation-filters: linearRGB; }"
                testCase
                    "ColorInterpolationFilters auto"
                    [ Svg.ColorInterpolationFilters.auto ]
                    "{ color-interpolation-filters: auto; }"
                testCase
                    "Fill color rgb"
                    [ Svg.Fill.rgb 255 0 0 ]
                    "{ fill: rgb(255, 0, 0); }"
                testCase
                    "Fill color green"
                    [ Svg.Fill.green ]
                    "{ fill: green; }"
                testCase
                    "FillOpacity 1"
                    [ Svg.FillOpacity.value 1.0 ]
                    "{ fill-opacity: 1; }"
                testCase
                    "FillOpacity 0"
                    [ Svg.FillOpacity.value 0.0]
                    "{ fill-opacity: 0; }"
                testCase
                    "FillOpacity 50%"
                    [ Svg.FillOpacity.value 0.5 ]
                    "{ fill-opacity: 0.5; }"
                testCase
                    "FillOpacity -10 should be 0"
                    [ Svg.FillOpacity.value -10.0 ]
                    "{ fill-opacity: 0; }"
                testCase
                    "FillOpacity 10 should be 1"
                    [ Svg.FillOpacity.value 10.0 ]
                    "{ fill-opacity: 1; }"
                testCase
                    "FillOpacity 1.5 should be 1"
                    [ Svg.FillOpacity.value 1.5 ]
                    "{ fill-opacity: 1; }"
                testCase
                    "FillRule nonzero"
                    [Svg.FillRule.nonzero]
                    "{ fill-rule: nonzero; }"
                testCase
                    "FillRule evenodd"
                    [Svg.FillRule.evenodd]
                    "{ fill-rule: evenodd; }"
                testCase
                    "ImageRendering optimize speed"
                    [Svg.ImageRendering.optimizeSpeed]
                    "{ image-rendering: optimize-speed; }"
                testCase
                    "ImageRendering optimize quality"
                    [Svg.ImageRendering.optimizeQuality]
                    "{ image-rendering: optimize-quality; }"
                testCase
                    "ImageRendering auto"
                    [Svg.ImageRendering.auto]
                    "{ image-rendering: auto; }"
                testCase
                    "ShapeRendering optimize speed"
                    [Svg.ShapeRendering.optimizeSpeed]
                    "{ shape-rendering: optimize-speed; }"
                testCase
                    "ShapeRendering crisp edges"
                    [Svg.ShapeRendering.crispEdges]
                    "{ shape-rendering: crisp-edges; }"
                testCase
                    "ShapeRendering geometric precision"
                    [Svg.ShapeRendering.geometricPrecision]
                    "{ shape-rendering: geometric-precision; }"
                testCase
                    "ShapeRendering auto"
                    [Svg.ShapeRendering.auto]
                    "{ shape-rendering: auto; }"
                testCase
                    "Stroke color rgb"
                    [ Svg.Stroke.rgb 255 0 0 ]
                    "{ stroke: rgb(255, 0, 0); }"
                testCase
                    "Stroke color green"
                    [ Svg.Stroke.green ]
                    "{ stroke: green; }"
                testCase
                    "StrokeOpacity 1"
                    [ Svg.StrokeOpacity.value 1.0 ]
                    "{ stroke-opacity: 1; }"
                testCase
                    "StrokeOpacity 0"
                    [ Svg.StrokeOpacity.value 0.0]
                    "{ stroke-opacity: 0; }"
                testCase
                    "StrokeOpacity 50%"
                    [ Svg.StrokeOpacity.value 0.5 ]
                    "{ stroke-opacity: 0.5; }"
                testCase
                    "StrokeOpacity -10 should be 0"
                    [ Svg.StrokeOpacity.value -10.0 ]
                    "{ stroke-opacity: 0; }"
                testCase
                    "StrokeOpacity 10 should be 1"
                    [ Svg.StrokeOpacity.value 10.0 ]
                    "{ stroke-opacity: 1; }"
                testCase
                    "StrokeOpacity 1.5 should be 1"
                    [ Svg.StrokeOpacity.value 1.5 ]
                    "{ stroke-opacity: 1; }"
                testCase
                    "Stroke dasharray 5, 3, 2"
                    [Svg.StrokeDasharray.value [5;3;2]]
                    "{ stroke-dasharray: 5, 3, 2; }"
                testCase
                    "Stroke dasharray 400"
                    [Svg.StrokeDasharray.value [400]]
                    "{ stroke-dasharray: 400; }"
                testCase
                    "Stroke dashoffset 5, 3, 2"
                    [Svg.StrokeDashoffset.value [5;3;2]]
                    "{ stroke-dashoffset: 5, 3, 2; }"
                testCase
                    "Stroke dashoffset 400"
                    [Svg.StrokeDashoffset.value [400]]
                    "{ stroke-dashoffset: 400; }"
                testCase
                    "StrokeLinecap butt"
                    [Svg.StrokeLinecap.butt]
                    "{ stroke-linecap: butt; }"
                testCase
                    "StrokeLinecap round"
                    [Svg.StrokeLinecap.round]
                    "{ stroke-linecap: round; }"
                testCase
                    "StrokeLinecap square"
                    [Svg.StrokeLinecap.square]
                    "{ stroke-linecap: square; }"
                    
                    
                    
                testCase
                    "StrokeLinejoin arcs"
                    [Svg.StrokeLinejoin.arcs]
                    "{ stroke-linejoin: arcs; }"
                testCase
                    "StrokeLinejoin bevel"
                    [Svg.StrokeLinejoin.bevel]
                    "{ stroke-linejoin: bevel; }"
                testCase
                    "StrokeLinejoin miter"
                    [Svg.StrokeLinejoin.miter]
                    "{ stroke-linejoin: miter; }"
                testCase
                    "StrokeLinejoin miter"
                    [Svg.StrokeLinejoin.miter]
                    "{ stroke-linejoin: miter; }"
                testCase
                    "StrokeLinejoin miterClip"
                    [Svg.StrokeLinejoin.miterClip]
                    "{ stroke-linejoin: miter-clip; }"
                testCase
                    "StrokeLinejoin round"
                    [Svg.StrokeLinejoin.round]
                    "{ stroke-linejoin: round; }"
                testCase
                    "Stroke miterlimit 5"
                    [Svg.StrokeMiterlimit.value 5]
                    "{ stroke-miterlimit: 5; }"
                testCase
                    "Stroke width px"
                    [Svg.StrokeWidth.value (px 5)]
                    "{ stroke-width: 5px; }"
                testCase
                    "Stroke width em"
                    [Svg.StrokeWidth.value (em 2)]
                    "{ stroke-width: 2em; }"
                testCase
                    "Stroke width pct"
                    [Svg.StrokeWidth.value (pct 50) ]
                    "{ stroke-width: 50%; }"
                ]