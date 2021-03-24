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
                    [ Direction.ltr ]
                    ["direction" ==> "ltr"]
                test
                    "Direction ltr"
                    [ Direction.rtl ]
                    ["direction" ==> "rtl"]
                test
                    "Direction Inherit"
                    [ Direction.inherit']
                    [ "direction" ==> "inherit" ]
                test
                    "Direction Initial"
                    [ Direction.initial]
                    [ "direction" ==> "initial" ]
                test
                    "Direction Unset"
                    [ Direction.unset]
                    [ "direction" ==> "unset" ]
                test
                    "Box sizing border box "
                    [BoxSizing.borderBox]
                    ["boxSizing" ==> "border-box"]
                test
                    "Box sizing content box "
                    [BoxSizing.contentBox]
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
                    [ Left.auto]
                    [ "left" ==> "auto" ]
                test
                    "Left Inherit"
                    [ Left.inherit']
                    [ "left" ==> "inherit" ]
                test
                    "Left Initial"
                    [ Left.initial]
                    [ "left" ==> "initial" ]
                test
                    "Left Unset"
                    [ Left.unset]
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
                    [ Right.auto]
                    [ "right" ==> "auto" ]
                test
                    "Right Inherit"
                    [ Right.inherit']
                    [ "right" ==> "inherit" ]
                test
                    "Right Initial"
                    [ Right.initial]
                    [ "right" ==> "initial" ]
                test
                    "Right Unset"
                    [ Right.unset]
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
                    [ Bottom.auto]
                    [ "bottom" ==> "auto" ]
                test
                    "Bottom Inherit"
                    [ Bottom.inherit']
                    [ "bottom" ==> "inherit" ]
                test
                    "Bottom Initial"
                    [ Bottom.initial]
                    [ "bottom" ==> "initial" ]
                test
                    "Bottom Unset"
                    [ Bottom.unset]
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
                    [ Top.auto]
                    [ "top" ==> "auto" ]
                test
                    "Top Inherit"
                    [ Top.inherit']
                    [ "top" ==> "inherit" ]
                test
                    "Top Initial"
                    [ Top.initial]
                    [ "top" ==> "initial" ]
                test
                    "Top Unset"
                    [ Top.unset]
                    [ "top" ==> "unset" ]
                test
                    "Vertical align baseline"
                    [ VerticalAlign.baseline]
                    ["verticalAlign" ==> "baseline"]
                test
                    "Vertical align sub"
                    [ VerticalAlign.sub]
                    ["verticalAlign" ==> "sub"]
                test
                    "Vertical align super"
                    [ VerticalAlign.super]
                    ["verticalAlign" ==> "super"]
                test
                    "Vertical align text top"
                    [ VerticalAlign.textTop]
                    ["verticalAlign" ==> "text-top"]
                test
                    "Vertical align text bottom"
                    [ VerticalAlign.textBottom]
                    ["verticalAlign" ==> "text-bottom"]
                test
                    "Vertical align middle"
                    [ VerticalAlign.middle]
                    ["verticalAlign" ==> "middle"]
                test
                    "Vertical align top"
                    [ VerticalAlign.top]
                    ["verticalAlign" ==> "top"]
                test
                    "Vertical align bottom"
                    [ VerticalAlign.bottom]
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
                    [ VerticalAlign.inherit' ]
                    ["verticalAlign" ==> "inherit"]
                test
                    "Vertical align initial"
                    [ VerticalAlign.initial ]
                    ["verticalAlign" ==> "initial"]
                test
                    "Vertical align unset"
                    [ VerticalAlign.unset ]
                    ["verticalAlign" ==> "unset"]
                test
                    "Position static"
                    [ Position.static']
                    ["position" ==> "static"]
                test
                    "Position relative"
                    [ Position.relative]
                    ["position" ==> "relative"]
                test
                    "Position absolute"
                    [ Position.absolute]
                    ["position" ==> "absolute"]
                test
                    "Position sticky"
                    [ Position.sticky]
                    ["position" ==> "sticky"]
                test
                    "Position fixed"
                    [ Position.fixed']
                    ["position" ==> "fixed"]
                test
                    "Float left"
                    [ Float.left]
                    ["float" ==> "left"]
                test
                    "Float right"
                    [ Float.right]
                    ["float" ==> "right"]
                test
                    "Float inline-start"
                    [ Float.inlineStart]
                    ["float" ==> "inline-start"]
                test
                    "Float inline-end"
                    [ Float.inlineEnd]
                    ["float" ==> "inline-end"]
                test
                    "Float none"
                    [ Float.none]
                    ["float" ==> "none"]
                test
                    "Float inherit"
                    [ Float.inherit']
                    ["float" ==> "inherit"]
                test
                    "Float initial"
                    [ Float.initial]
                    ["float" ==> "initial"]
                test
                    "Float unset"
                    [ Float.unset]
                    ["float" ==> "unset"]
                test
                    "WritingMode horizontal-tb"
                    [ WritingMode.horizontalTb]
                    ["writingMode" ==> "horizontal-tb"]
                test
                    "WritingMode vertical-rl"
                    [ WritingMode.verticalRl]
                    ["writingMode" ==> "vertical-rl"]
                test
                    "WritingMode vertical-lr"
                    [ WritingMode.verticalLr]
                    ["writingMode" ==> "vertical-lr"]
                test
                    "WritingMode inherit"
                    [ WritingMode.inherit']
                    ["writingMode" ==> "inherit"]
                test
                    "WritingMode initial"
                    [ WritingMode.initial]
                    ["writingMode" ==> "initial"]
                test
                    "WritingMode unset"
                    [ WritingMode.unset]
                    ["writingMode" ==> "unset"]
                test
                    "BreakAfter avoid"
                    [BreakAfter.avoid]
                    ["breakAfter" ==> "avoid"]
                test
                    "BreakAfter always"
                    [BreakAfter.always]
                    ["breakAfter" ==> "always"]
                test
                    "BreakAfter all"
                    [BreakAfter.all]
                    ["breakAfter" ==> "all"]
                test
                    "BreakAfter avoid-page"
                    [BreakAfter.avoidPage]
                    ["breakAfter" ==> "avoid-page"]
                test
                    "BreakAfter page"
                    [BreakAfter.page]
                    ["breakAfter" ==> "page"]
                test
                    "BreakAfter left"
                    [BreakAfter.left]
                    ["breakAfter" ==> "left"]
                test
                    "BreakAfter right"
                    [BreakAfter.right]
                    ["breakAfter" ==> "right"]
                test
                    "BreakAfter recto"
                    [BreakAfter.recto]
                    ["breakAfter" ==> "recto"]
                test
                    "BreakAfter verso"
                    [BreakAfter.verso]
                    ["breakAfter" ==> "verso"]
                test
                    "BreakAfter avoid-column"
                    [BreakAfter.avoidColumn]
                    ["breakAfter" ==> "avoid-column"]
                test
                    "BreakAfter column"
                    [BreakAfter.column]
                    ["breakAfter" ==> "column"]
                test
                    "BreakAfter avoid-region"
                    [BreakAfter.avoidRegion]
                    ["breakAfter" ==> "avoid-region"]
                test
                    "BreakAfter region"
                    [BreakAfter.region]
                    ["breakAfter" ==> "region"]
                test
                    "BreakAfter auto"
                    [ BreakAfter.auto]
                    ["breakAfter" ==> "auto"]
                test
                    "BreakAfter inherit"
                    [ BreakAfter.inherit']
                    ["breakAfter" ==> "inherit"]
                test
                    "BreakAfter initial"
                    [ BreakAfter.initial]
                    ["breakAfter" ==> "initial"]
                test
                    "BreakAfter unset"
                    [ BreakAfter.unset]
                    ["breakAfter" ==> "unset"]
                test
                    "BreakBefore avoid"
                    [BreakBefore.avoid]
                    ["breakBefore" ==> "avoid"]
                test
                    "BreakBefore always"
                    [BreakBefore.always]
                    ["breakBefore" ==> "always"]
                test
                    "BreakBefore all"
                    [BreakBefore.all]
                    ["breakBefore" ==> "all"]
                test
                    "BreakBefore avoid-page"
                    [BreakBefore.avoidPage]
                    ["breakBefore" ==> "avoid-page"]
                test
                    "BreakBefore page"
                    [BreakBefore.page]
                    ["breakBefore" ==> "page"]
                test
                    "BreakBefore left"
                    [BreakBefore.left]
                    ["breakBefore" ==> "left"]
                test
                    "BreakBefore right"
                    [BreakBefore.right]
                    ["breakBefore" ==> "right"]
                test
                    "BreakBefore recto"
                    [BreakBefore.recto]
                    ["breakBefore" ==> "recto"]
                test
                    "BreakBefore verso"
                    [BreakBefore.verso]
                    ["breakBefore" ==> "verso"]
                test
                    "BreakBefore avoid-column"
                    [BreakBefore.avoidColumn]
                    ["breakBefore" ==> "avoid-column"]
                test
                    "BreakBefore column"
                    [BreakBefore.column]
                    ["breakBefore" ==> "column"]
                test
                    "BreakBefore avoid-region"
                    [BreakBefore.avoidRegion]
                    ["breakBefore" ==> "avoid-region"]
                test
                    "BreakBefore region"
                    [BreakBefore.region]
                    ["breakBefore" ==> "region"]
                test
                    "BreakBefore auto"
                    [ BreakBefore.auto]
                    ["breakBefore" ==> "auto"]
                test
                    "BreakBefore inherit"
                    [ BreakBefore.inherit']
                    ["breakBefore" ==> "inherit"]
                test
                    "BreakBefore initial"
                    [ BreakBefore.initial]
                    ["breakBefore" ==> "initial"]
                test
                    "BreakBefore unset"
                    [ BreakBefore.unset]
                    ["breakBefore" ==> "unset"]
                test
                    "BreakInside avoid"
                    [BreakInside.avoid]
                    ["breakInside" ==> "avoid"]
                test
                    "BreakInside avoid-page"
                    [BreakInside.avoidPage]
                    ["breakInside" ==> "avoid-page"]
                test
                    "BreakInside avoid-column"
                    [BreakInside.avoidColumn]
                    ["breakInside" ==> "avoid-column"]
                test
                    "BreakInside avoid-region"
                    [BreakInside.avoidRegion]
                    ["breakInside" ==> "avoid-region"]
                test
                    "BreakInside auto"
                    [ BreakInside.auto]
                    ["breakInside" ==> "auto"]
                test
                    "BreakInside inherit"
                    [ BreakInside.inherit']
                    ["breakInside" ==> "inherit"]
                test
                    "BreakInside initial"
                    [ BreakInside.initial]
                    ["breakInside" ==> "initial"]
                test
                    "BreakInside unset"
                    [ BreakInside.unset]
                    ["breakInside" ==> "unset"]
            ]