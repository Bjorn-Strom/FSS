namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Position =
    let tests =
        testList "Position"
            [
                testCase
                    "Direction rtl"
                    [ Direction.ltr ]
                    ["direction" ==> "ltr"]
                testCase
                    "Direction ltr"
                    [ Direction.rtl ]
                    ["direction" ==> "rtl"]
                testCase
                    "Direction Inherit"
                    [ Direction.inherit']
                    [ "direction" ==> "inherit" ]
                testCase
                    "Direction Initial"
                    [ Direction.initial]
                    [ "direction" ==> "initial" ]
                testCase
                    "Direction Unset"
                    [ Direction.unset]
                    [ "direction" ==> "unset" ]
                testCase
                    "Box sizing border box "
                    [BoxSizing.borderBox]
                    ["boxSizing" ==> "border-box"]
                testCase
                    "Box sizing content box "
                    [BoxSizing.contentBox]
                    ["boxSizing" ==> "content-box"]
                testCase
                    "Left px"
                    [ Left' (px 3) ]
                    [ "left" ==> "3px" ]
                testCase
                    "Left em"
                    [ Left' (em 2.4) ]
                    [ "left" ==> "2.4em" ]
                testCase
                    "Left percent"
                    [ Left' (pct 10) ]
                    [ "left" ==> "10%" ]
                testCase
                    "Left Auto"
                    [ Left.auto]
                    [ "left" ==> "auto" ]
                testCase
                    "Left Inherit"
                    [ Left.inherit']
                    [ "left" ==> "inherit" ]
                testCase
                    "Left Initial"
                    [ Left.initial]
                    [ "left" ==> "initial" ]
                testCase
                    "Left Unset"
                    [ Left.unset]
                    [ "left" ==> "unset" ]
                testCase
                    "Right px"
                    [ Right' (px 3) ]
                    [ "right" ==> "3px" ]
                testCase
                    "Right em"
                    [ Right' (em 2.4) ]
                    [ "right" ==> "2.4em" ]
                testCase
                    "Right percent"
                    [ Right' (pct 10) ]
                    [ "right" ==> "10%" ]
                testCase
                    "Right Auto"
                    [ Right.auto]
                    [ "right" ==> "auto" ]
                testCase
                    "Right Inherit"
                    [ Right.inherit']
                    [ "right" ==> "inherit" ]
                testCase
                    "Right Initial"
                    [ Right.initial]
                    [ "right" ==> "initial" ]
                testCase
                    "Right Unset"
                    [ Right.unset]
                    [ "right" ==> "unset" ]
                testCase
                    "Bottom px"
                    [ Bottom' (px 3) ]
                    [ "bottom" ==> "3px" ]
                testCase
                    "Bottom em"
                    [ Bottom' (em 2.4) ]
                    [ "bottom" ==> "2.4em" ]
                testCase
                    "Bottom percent"
                    [ Bottom' (pct 10) ]
                    [ "bottom" ==> "10%" ]
                testCase
                    "Bottom Auto"
                    [ Bottom.auto]
                    [ "bottom" ==> "auto" ]
                testCase
                    "Bottom Inherit"
                    [ Bottom.inherit']
                    [ "bottom" ==> "inherit" ]
                testCase
                    "Bottom Initial"
                    [ Bottom.initial]
                    [ "bottom" ==> "initial" ]
                testCase
                    "Bottom Unset"
                    [ Bottom.unset]
                    [ "bottom" ==> "unset" ]
                testCase
                    "Top px"
                    [ Top' (px 3) ]
                    [ "top" ==> "3px" ]
                testCase
                    "Top em"
                    [ Top' (em 2.4) ]
                    [ "top" ==> "2.4em" ]
                testCase
                    "Top percent"
                    [ Top' (pct 10) ]
                    [ "top" ==> "10%" ]
                testCase
                    "Top Auto"
                    [ Top.auto]
                    [ "top" ==> "auto" ]
                testCase
                    "Top Inherit"
                    [ Top.inherit']
                    [ "top" ==> "inherit" ]
                testCase
                    "Top Initial"
                    [ Top.initial]
                    [ "top" ==> "initial" ]
                testCase
                    "Top Unset"
                    [ Top.unset]
                    [ "top" ==> "unset" ]
                testCase
                    "Vertical align baseline"
                    [ VerticalAlign.baseline]
                    ["verticalAlign" ==> "baseline"]
                testCase
                    "Vertical align sub"
                    [ VerticalAlign.sub]
                    ["verticalAlign" ==> "sub"]
                testCase
                    "Vertical align super"
                    [ VerticalAlign.super]
                    ["verticalAlign" ==> "super"]
                testCase
                    "Vertical align text top"
                    [ VerticalAlign.textTop]
                    ["verticalAlign" ==> "text-top"]
                testCase
                    "Vertical align text bottom"
                    [ VerticalAlign.textBottom]
                    ["verticalAlign" ==> "text-bottom"]
                testCase
                    "Vertical align middle"
                    [ VerticalAlign.middle]
                    ["verticalAlign" ==> "middle"]
                testCase
                    "Vertical align top"
                    [ VerticalAlign.top]
                    ["verticalAlign" ==> "top"]
                testCase
                    "Vertical align bottom"
                    [ VerticalAlign.bottom]
                    ["verticalAlign" ==> "bottom"]
                testCase
                    "Vertical align px"
                    [ VerticalAlign' (px 10)]
                    ["verticalAlign" ==> "10px"]
                testCase
                    "Vertical align percent"
                    [ VerticalAlign' (pct 100)]
                    ["verticalAlign" ==> "100%"]
                testCase
                    "Vertical align  inherit"
                    [ VerticalAlign.inherit' ]
                    ["verticalAlign" ==> "inherit"]
                testCase
                    "Vertical align initial"
                    [ VerticalAlign.initial ]
                    ["verticalAlign" ==> "initial"]
                testCase
                    "Vertical align unset"
                    [ VerticalAlign.unset ]
                    ["verticalAlign" ==> "unset"]
                testCase
                    "Position static"
                    [ Position.static']
                    ["position" ==> "static"]
                testCase
                    "Position relative"
                    [ Position.relative]
                    ["position" ==> "relative"]
                testCase
                    "Position absolute"
                    [ Position.absolute]
                    ["position" ==> "absolute"]
                testCase
                    "Position sticky"
                    [ Position.sticky]
                    ["position" ==> "sticky"]
                testCase
                    "Position fixed"
                    [ Position.fixed']
                    ["position" ==> "fixed"]
                testCase
                    "Float left"
                    [ Float.left]
                    ["float" ==> "left"]
                testCase
                    "Float right"
                    [ Float.right]
                    ["float" ==> "right"]
                testCase
                    "Float inline-start"
                    [ Float.inlineStart]
                    ["float" ==> "inline-start"]
                testCase
                    "Float inline-end"
                    [ Float.inlineEnd]
                    ["float" ==> "inline-end"]
                testCase
                    "Float none"
                    [ Float.none]
                    ["float" ==> "none"]
                testCase
                    "Float inherit"
                    [ Float.inherit']
                    ["float" ==> "inherit"]
                testCase
                    "Float initial"
                    [ Float.initial]
                    ["float" ==> "initial"]
                testCase
                    "Float unset"
                    [ Float.unset]
                    ["float" ==> "unset"]
                testCase
                    "WritingMode horizontal-tb"
                    [ WritingMode.horizontalTb]
                    ["writingMode" ==> "horizontal-tb"]
                testCase
                    "WritingMode vertical-rl"
                    [ WritingMode.verticalRl]
                    ["writingMode" ==> "vertical-rl"]
                testCase
                    "WritingMode vertical-lr"
                    [ WritingMode.verticalLr]
                    ["writingMode" ==> "vertical-lr"]
                testCase
                    "WritingMode inherit"
                    [ WritingMode.inherit']
                    ["writingMode" ==> "inherit"]
                testCase
                    "WritingMode initial"
                    [ WritingMode.initial]
                    ["writingMode" ==> "initial"]
                testCase
                    "WritingMode unset"
                    [ WritingMode.unset]
                    ["writingMode" ==> "unset"]
                testCase
                    "BreakAfter avoid"
                    [BreakAfter.avoid]
                    ["breakAfter" ==> "avoid"]
                testCase
                    "BreakAfter always"
                    [BreakAfter.always]
                    ["breakAfter" ==> "always"]
                testCase
                    "BreakAfter all"
                    [BreakAfter.all]
                    ["breakAfter" ==> "all"]
                testCase
                    "BreakAfter avoid-page"
                    [BreakAfter.avoidPage]
                    ["breakAfter" ==> "avoid-page"]
                testCase
                    "BreakAfter page"
                    [BreakAfter.page]
                    ["breakAfter" ==> "page"]
                testCase
                    "BreakAfter left"
                    [BreakAfter.left]
                    ["breakAfter" ==> "left"]
                testCase
                    "BreakAfter right"
                    [BreakAfter.right]
                    ["breakAfter" ==> "right"]
                testCase
                    "BreakAfter recto"
                    [BreakAfter.recto]
                    ["breakAfter" ==> "recto"]
                testCase
                    "BreakAfter verso"
                    [BreakAfter.verso]
                    ["breakAfter" ==> "verso"]
                testCase
                    "BreakAfter avoid-column"
                    [BreakAfter.avoidColumn]
                    ["breakAfter" ==> "avoid-column"]
                testCase
                    "BreakAfter column"
                    [BreakAfter.column]
                    ["breakAfter" ==> "column"]
                testCase
                    "BreakAfter avoid-region"
                    [BreakAfter.avoidRegion]
                    ["breakAfter" ==> "avoid-region"]
                testCase
                    "BreakAfter region"
                    [BreakAfter.region]
                    ["breakAfter" ==> "region"]
                testCase
                    "BreakAfter auto"
                    [ BreakAfter.auto]
                    ["breakAfter" ==> "auto"]
                testCase
                    "BreakAfter inherit"
                    [ BreakAfter.inherit']
                    ["breakAfter" ==> "inherit"]
                testCase
                    "BreakAfter initial"
                    [ BreakAfter.initial]
                    ["breakAfter" ==> "initial"]
                testCase
                    "BreakAfter unset"
                    [ BreakAfter.unset]
                    ["breakAfter" ==> "unset"]
                testCase
                    "BreakBefore avoid"
                    [BreakBefore.avoid]
                    ["breakBefore" ==> "avoid"]
                testCase
                    "BreakBefore always"
                    [BreakBefore.always]
                    ["breakBefore" ==> "always"]
                testCase
                    "BreakBefore all"
                    [BreakBefore.all]
                    ["breakBefore" ==> "all"]
                testCase
                    "BreakBefore avoid-page"
                    [BreakBefore.avoidPage]
                    ["breakBefore" ==> "avoid-page"]
                testCase
                    "BreakBefore page"
                    [BreakBefore.page]
                    ["breakBefore" ==> "page"]
                testCase
                    "BreakBefore left"
                    [BreakBefore.left]
                    ["breakBefore" ==> "left"]
                testCase
                    "BreakBefore right"
                    [BreakBefore.right]
                    ["breakBefore" ==> "right"]
                testCase
                    "BreakBefore recto"
                    [BreakBefore.recto]
                    ["breakBefore" ==> "recto"]
                testCase
                    "BreakBefore verso"
                    [BreakBefore.verso]
                    ["breakBefore" ==> "verso"]
                testCase
                    "BreakBefore avoid-column"
                    [BreakBefore.avoidColumn]
                    ["breakBefore" ==> "avoid-column"]
                testCase
                    "BreakBefore column"
                    [BreakBefore.column]
                    ["breakBefore" ==> "column"]
                testCase
                    "BreakBefore avoid-region"
                    [BreakBefore.avoidRegion]
                    ["breakBefore" ==> "avoid-region"]
                testCase
                    "BreakBefore region"
                    [BreakBefore.region]
                    ["breakBefore" ==> "region"]
                testCase
                    "BreakBefore auto"
                    [ BreakBefore.auto]
                    ["breakBefore" ==> "auto"]
                testCase
                    "BreakBefore inherit"
                    [ BreakBefore.inherit']
                    ["breakBefore" ==> "inherit"]
                testCase
                    "BreakBefore initial"
                    [ BreakBefore.initial]
                    ["breakBefore" ==> "initial"]
                testCase
                    "BreakBefore unset"
                    [ BreakBefore.unset]
                    ["breakBefore" ==> "unset"]
                testCase
                    "BreakInside avoid"
                    [BreakInside.avoid]
                    ["breakInside" ==> "avoid"]
                testCase
                    "BreakInside avoid-page"
                    [BreakInside.avoidPage]
                    ["breakInside" ==> "avoid-page"]
                testCase
                    "BreakInside avoid-column"
                    [BreakInside.avoidColumn]
                    ["breakInside" ==> "avoid-column"]
                testCase
                    "BreakInside avoid-region"
                    [BreakInside.avoidRegion]
                    ["breakInside" ==> "avoid-region"]
                testCase
                    "BreakInside auto"
                    [ BreakInside.auto]
                    ["breakInside" ==> "auto"]
                testCase
                    "BreakInside inherit"
                    [ BreakInside.inherit']
                    ["breakInside" ==> "inherit"]
                testCase
                    "BreakInside initial"
                    [ BreakInside.initial]
                    ["breakInside" ==> "initial"]
                testCase
                    "BreakInside unset"
                    [ BreakInside.unset]
                    ["breakInside" ==> "unset"]
            ]