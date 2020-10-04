namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Position =
    let tests =
        testList "Position"
            [
                    test
                        "Vertical align baseline"
                        [ VerticalAlign (VerticalAlign.Baseline)]
                        ["verticalAlign" ==> "baseline"]

                    test
                        "Vertical align sub"
                        [ VerticalAlign (VerticalAlign.Sub)]
                        ["verticalAlign" ==> "sub"]

                    test
                        "Vertical align super"
                        [ VerticalAlign (VerticalAlign.Super)]
                        ["verticalAlign" ==> "super"]

                    test
                        "Vertical align text top"
                        [ VerticalAlign (VerticalAlign.TextTop)]
                        ["verticalAlign" ==> "text-top"]

                    test
                        "Vertical align text bottom"
                        [ VerticalAlign (VerticalAlign.TextBottom)]
                        ["verticalAlign" ==> "text-bottom"]

                    test
                        "Vertical align middle"
                        [ VerticalAlign (VerticalAlign.Middle)]
                        ["verticalAlign" ==> "middle"]

                    test
                        "Vertical align top"
                        [ VerticalAlign (VerticalAlign.Top)]
                        ["verticalAlign" ==> "top"]

                    test
                        "Vertical align bottom"
                        [ VerticalAlign (VerticalAlign.Bottom)]
                        ["verticalAlign" ==> "bottom"]

                    test
                        "Vertical align px"
                        [ VerticalAlign (px 10)]
                        ["verticalAlign" ==> "10px"]

                    test
                        "Vertical align percent"
                        [ VerticalAlign (pct 100)]
                        ["verticalAlign" ==> "100%"]

                    test
                        "Vertical align  inherit"
                        [ VerticalAlign Inherit ]
                        ["verticalAlign" ==> "inherit"]

                    test
                        "Vertical align initial"
                        [ VerticalAlign Initial ]
                        ["verticalAlign" ==> "initial"]

                    test
                        "Vertical align unset"
                        [ VerticalAlign Unset ]
                        ["verticalAlign" ==> "unset"]
                    
                    test
                        "Position static"
                        [ Position Position.Static]
                        ["position" ==> "static"]

                    test
                        "Position relative"
                        [ Position Position.Relative]
                        ["position" ==> "relative"]

                    test
                        "Position absolute"
                        [ Position Position.Absolute]
                        ["position" ==> "absolute"]

                    test
                        "Position sticky"
                        [ Position Position.Sticky]
                        ["position" ==> "sticky"]

                    test
                        "Position fixed"
                        [ Position Position.Fixed]
                        ["position" ==> "fixed"]
            ]