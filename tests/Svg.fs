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











                ]