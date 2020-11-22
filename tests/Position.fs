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
                    "Direction rtl"
                    [ Direction.Ltr ]
                    ["direction" ==> "ltr"]
                test
                    "Direction ltr"
                    [ Direction.Rtl ]
                    ["direction" ==> "rtl"]
                test
                    "Direction Inherit"
                    [ Direction.Inherit]
                    [ "direction" ==> "inherit" ]
                test
                    "Direction Initial"
                    [ Direction.Initial]
                    [ "direction" ==> "initial" ]
                test
                    "Direction Unset"
                    [ Direction.Unset]
                    [ "direction" ==> "unset" ]
                test
                    "Box sizing border box "
                    [BoxSizing.BorderBox]
                    ["boxSizing" ==> "border-box"]
                test
                    "Box sizing content box "
                    [BoxSizing.ContentBox]
                    ["boxSizing" ==> "content-box"]
                test
                    "Left px"
                    [ Left' (px 3) ]
                    [ "left" ==> "3px" ]
                test
                    "Left em"
                    [ Left' (em 2.4) ]
                    [ "left" ==> "2.4em" ]
                test
                    "Left percent"
                    [ Left' (pct 10) ]
                    [ "left" ==> "10%" ]
                test
                    "Left Auto"
                    [ Left.Auto]
                    [ "left" ==> "auto" ]
                test
                    "Left Inherit"
                    [ Left.Inherit]
                    [ "left" ==> "inherit" ]
                test
                    "Left Initial"
                    [ Left.Initial]
                    [ "left" ==> "initial" ]
                test
                    "Left Unset"
                    [ Left.Unset]
                    [ "left" ==> "unset" ]
                test
                    "Right px"
                    [ Right' (px 3) ]
                    [ "right" ==> "3px" ]
                test
                    "Right em"
                    [ Right' (em 2.4) ]
                    [ "right" ==> "2.4em" ]
                test
                    "Right percent"
                    [ Right' (pct 10) ]
                    [ "right" ==> "10%" ]
                test
                    "Right Auto"
                    [ Right.Auto]
                    [ "right" ==> "auto" ]
                test
                    "Right Inherit"
                    [ Right.Inherit]
                    [ "right" ==> "inherit" ]
                test
                    "Right Initial"
                    [ Right.Initial]
                    [ "right" ==> "initial" ]
                test
                    "Right Unset"
                    [ Right.Unset]
                    [ "right" ==> "unset" ]
                test
                    "Bottom px"
                    [ Bottom' (px 3) ]
                    [ "bottom" ==> "3px" ]
                test
                    "Bottom em"
                    [ Bottom' (em 2.4) ]
                    [ "bottom" ==> "2.4em" ]
                test
                    "Bottom percent"
                    [ Bottom' (pct 10) ]
                    [ "bottom" ==> "10%" ]
                test
                    "Bottom Auto"
                    [ Bottom.Auto]
                    [ "bottom" ==> "auto" ]
                test
                    "Bottom Inherit"
                    [ Bottom.Inherit]
                    [ "bottom" ==> "inherit" ]
                test
                    "Bottom Initial"
                    [ Bottom.Initial]
                    [ "bottom" ==> "initial" ]
                test
                    "Bottom Unset"
                    [ Bottom.Unset]
                    [ "bottom" ==> "unset" ]
                test
                    "Top px"
                    [ Top' (px 3) ]
                    [ "top" ==> "3px" ]
                test
                    "Top em"
                    [ Top' (em 2.4) ]
                    [ "top" ==> "2.4em" ]
                test
                    "Top percent"
                    [ Top' (pct 10) ]
                    [ "top" ==> "10%" ]
                test
                    "Top Auto"
                    [ Top.Auto]
                    [ "top" ==> "auto" ]
                test
                    "Top Inherit"
                    [ Top.Inherit]
                    [ "top" ==> "inherit" ]
                test
                    "Top Initial"
                    [ Top.Initial]
                    [ "top" ==> "initial" ]
                test
                    "Top Unset"
                    [ Top.Unset]
                    [ "top" ==> "unset" ]
                test
                    "Vertical align baseline"
                    [ VerticalAlign.Baseline]
                    ["verticalAlign" ==> "baseline"]
                test
                    "Vertical align sub"
                    [ VerticalAlign.Sub]
                    ["verticalAlign" ==> "sub"]
                test
                    "Vertical align super"
                    [ VerticalAlign.Super]
                    ["verticalAlign" ==> "super"]
                test
                    "Vertical align text top"
                    [ VerticalAlign.TextTop]
                    ["verticalAlign" ==> "text-top"]
                test
                    "Vertical align text bottom"
                    [ VerticalAlign.TextBottom]
                    ["verticalAlign" ==> "text-bottom"]
                test
                    "Vertical align middle"
                    [ VerticalAlign.Middle]
                    ["verticalAlign" ==> "middle"]
                test
                    "Vertical align top"
                    [ VerticalAlign.Top]
                    ["verticalAlign" ==> "top"]
                test
                    "Vertical align bottom"
                    [ VerticalAlign.Bottom]
                    ["verticalAlign" ==> "bottom"]
                test
                    "Vertical align px"
                    [ VerticalAlign' (px 10)]
                    ["verticalAlign" ==> "10px"]
                test
                    "Vertical align percent"
                    [ VerticalAlign' (pct 100)]
                    ["verticalAlign" ==> "100%"]
                test
                    "Vertical align  inherit"
                    [ VerticalAlign.Inherit ]
                    ["verticalAlign" ==> "inherit"]
                test
                    "Vertical align initial"
                    [ VerticalAlign.Initial ]
                    ["verticalAlign" ==> "initial"]
                test
                    "Vertical align unset"
                    [ VerticalAlign.Unset ]
                    ["verticalAlign" ==> "unset"]
                test
                    "Position static"
                    [ Position.Static]
                    ["position" ==> "static"]
                test
                    "Position relative"
                    [ Position.Relative]
                    ["position" ==> "relative"]
                test
                    "Position absolute"
                    [ Position.Absolute]
                    ["position" ==> "absolute"]
                test
                    "Position sticky"
                    [ Position.Sticky]
                    ["position" ==> "sticky"]
                test
                    "Position fixed"
                    [ Position.Fixed]
                    ["position" ==> "fixed"]
                test
                    "Float left"
                    [ Float.Left]
                    ["float" ==> "left"]
                test
                    "Float right"
                    [ Float.Right]
                    ["float" ==> "right"]
                test
                    "Float inline-start"
                    [ Float.InlineStart]
                    ["float" ==> "inline-start"]
                test
                    "Float inline-end"
                    [ Float.InlineEnd]
                    ["float" ==> "inline-end"]
                test
                    "Float none"
                    [ Float.None]
                    ["float" ==> "none"]
                test
                    "Float inherit"
                    [ Float.Inherit]
                    ["float" ==> "inherit"]
                test
                    "Float initial"
                    [ Float.Initial]
                    ["float" ==> "initial"]
                test
                    "Float unset"
                    [ Float.Unset]
                    ["float" ==> "unset"]
            ]