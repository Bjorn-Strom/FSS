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
                    "Baseline"
                    [AlignmentBaseline.baseline]
                    ["alignmentBaseline" ==> "baseline"]

                testCase
                    "TextBottom"
                    [AlignmentBaseline.textBottom]
                    ["alignmentBaseline" ==> "text-bottom"]

                testCase
                    "TextBeforeEdge"
                    [AlignmentBaseline.textBeforeEdge]
                    ["alignmentBaseline" ==> "text-before-edge"]

                testCase
                    "Middle"
                    [AlignmentBaseline.middle]
                    ["alignmentBaseline" ==> "middle"]

                testCase
                    "Central"
                    [AlignmentBaseline.central]
                    ["alignmentBaseline" ==> "central"]

                testCase
                    "TextTop"
                    [AlignmentBaseline.textTop]
                    ["alignmentBaseline" ==> "text-top"]

                testCase
                    "TextAfterEdge"
                    [AlignmentBaseline.textAfterEdge]
                    ["alignmentBaseline" ==> "text-after-edge"]

                testCase
                    "Ideographic"
                    [AlignmentBaseline.ideographic]
                    ["alignmentBaseline" ==> "ideographic"]

                testCase
                    "Alphabetic"
                    [AlignmentBaseline.alphabetic]
                    ["alignmentBaseline" ==> "alphabetic"]

                testCase
                    "Hanging"
                    [AlignmentBaseline.hanging]
                    ["alignmentBaseline" ==> "hanging"]

                testCase
                    "Mathematical"
                    [AlignmentBaseline.mathematical]
                    ["alignmentBaseline" ==> "mathematical"]

                testCase
                    "Top"
                    [AlignmentBaseline.top]
                    ["alignmentBaseline" ==> "top"]

                testCase
                    "Center"
                    [AlignmentBaseline.center]
                    ["alignmentBaseline" ==> "center"]

                testCase
                    "Bottom"
                    [AlignmentBaseline.bottom]
                    ["alignmentBaseline" ==> "bottom"]

                ]