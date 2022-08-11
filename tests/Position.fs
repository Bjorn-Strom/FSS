namespace FSSTests

open Fet
open Utils
open Fss

module PositionTests =
    let tests =
        testList "Position"
            [
                testCase
                    "Direction rtl"
                    [ Direction.ltr ]
                    "{direction:ltr;}"
                testCase
                    "Direction ltr"
                    [ Direction.rtl ]
                    "{direction:rtl;}"
                testCase
                    "Direction Inherit"
                    [ Direction.inherit']
                     "{direction:inherit;}"
                testCase
                    "Direction Initial"
                    [ Direction.initial]
                     "{direction:initial;}"
                testCase
                    "Direction Unset"
                    [ Direction.unset]
                     "{direction:unset;}"
                testCase
                    "Direction revert"
                    [ Direction.revert]
                     "{direction:revert;}"
                testCase
                    "Box sizing border box "
                    [BoxSizing.borderBox]
                    "{box-sizing:border-box;}"
                testCase
                    "Box sizing content box "
                    [BoxSizing.contentBox]
                    "{box-sizing:content-box;}"
                testCase
                    "BoxSizing Inherit"
                    [ BoxSizing.inherit']
                     "{box-sizing:inherit;}"
                testCase
                    "BoxSizing Initial"
                    [ BoxSizing.initial]
                     "{box-sizing:initial;}"
                testCase
                    "BoxSizing Unset"
                    [ BoxSizing.unset]
                     "{box-sizing:unset;}"
                testCase
                    "BoxSizing revert"
                    [ BoxSizing.revert]
                     "{box-sizing:revert;}"
                testCase
                    "Left px"
                    [ Left.value (px 3) ]
                     "{left:3px;}"
                testCase
                    "Left em"
                    [ Left.value (em 2.4) ]
                     "{left:2.4em;}"
                testCase
                    "Left percent"
                    [ Left.value (pct 10) ]
                     "{left:10%;}"
                testCase
                    "Left Auto"
                    [ Left.auto]
                     "{left:auto;}"
                testCase
                    "Left Inherit"
                    [ Left.inherit']
                     "{left:inherit;}"
                testCase
                    "Left Initial"
                    [ Left.initial]
                     "{left:initial;}"
                testCase
                    "Left Unset"
                    [ Left.unset]
                     "{left:unset;}"
                testCase
                    "Left revert"
                    [ Left.revert]
                     "{left:revert;}"
                testCase
                    "Right px"
                    [ Right.value (px 3) ]
                     "{right:3px;}"
                testCase
                    "Right em"
                    [ Right.value (em 2.4) ]
                     "{right:2.4em;}"
                testCase
                    "Right percent"
                    [ Right.value (pct 10) ]
                     "{right:10%;}"
                testCase
                    "Right Auto"
                    [ Right.auto]
                     "{right:auto;}"
                testCase
                    "Right Inherit"
                    [ Right.inherit']
                     "{right:inherit;}"
                testCase
                    "Right Initial"
                    [ Right.initial]
                     "{right:initial;}"
                testCase
                    "Right unset"
                    [ Right.unset]
                     "{right:unset;}"
                testCase
                    "Right revert"
                    [ Right.revert]
                     "{right:revert;}"
                testCase
                    "Bottom px"
                    [ Bottom.value (px 3) ]
                     "{bottom:3px;}"
                testCase
                    "Bottom em"
                    [ Bottom.value (em 2.4) ]
                     "{bottom:2.4em;}"
                testCase
                    "Bottom percent"
                    [ Bottom.value (pct 10) ]
                     "{bottom:10%;}"
                testCase
                    "Bottom Auto"
                    [ Bottom.auto]
                     "{bottom:auto;}"
                testCase
                    "Bottom Inherit"
                    [ Bottom.inherit']
                     "{bottom:inherit;}"
                testCase
                    "Bottom Initial"
                    [ Bottom.initial]
                     "{bottom:initial;}"
                testCase
                    "Bottom Unset"
                    [ Bottom.unset]
                     "{bottom:unset;}"
                testCase
                    "Bottom revert"
                    [ Bottom.revert]
                     "{bottom:revert;}"
                testCase
                    "Top px"
                    [ Top.value (px 3) ]
                     "{top:3px;}"
                testCase
                    "Top em"
                    [ Top.value (em 2.4) ]
                     "{top:2.4em;}"
                testCase
                    "Top percent"
                    [ Top.value (pct 10) ]
                     "{top:10%;}"
                ;testCase
                    "Top Auto"
                    [ Top.auto]
                     "{top:auto;}"
                testCase
                    "Top Inherit"
                    [ Top.inherit']
                     "{top:inherit;}"
                testCase
                    "Top Initial"
                    [ Top.initial]
                     "{top:initial;}"
                testCase
                    "Top Unset"
                    [ Top.unset]
                     "{top:unset;}"
                testCase
                    "Top revert"
                    [ Top.revert]
                     "{top:revert;}"
                testCase
                    "Vertical align baseline"
                    [ VerticalAlign.baseline]
                    "{vertical-align:baseline;}"
                testCase
                    "Vertical align sub"
                    [ VerticalAlign.sub]
                    "{vertical-align:sub;}"
                testCase
                    "Vertical align super"
                    [ VerticalAlign.super]
                    "{vertical-align:super;}"
                testCase
                    "Vertical align text top"
                    [ VerticalAlign.textTop]
                    "{vertical-align:text-top;}"
                testCase
                    "Vertical align text bottom"
                    [ VerticalAlign.textBottom]
                    "{vertical-align:text-bottom;}"
                testCase
                    "Vertical align middle"
                    [ VerticalAlign.middle]
                    "{vertical-align:middle;}"
                testCase
                    "Vertical align top"
                    [ VerticalAlign.top]
                    "{vertical-align:top;}"
                testCase
                    "Vertical align bottom"
                    [ VerticalAlign.bottom]
                    "{vertical-align:bottom;}"
                testCase
                    "Vertical align px"
                    [ VerticalAlign.value (px 10)]
                    "{vertical-align:10px;}"
                testCase
                    "Vertical align percent"
                    [ VerticalAlign.value (pct 100)]
                    "{vertical-align:100%;}"
                testCase
                    "Vertical align  inherit"
                    [ VerticalAlign.inherit' ]
                    "{vertical-align:inherit;}"
                testCase
                    "Vertical align initial"
                    [ VerticalAlign.initial ]
                    "{vertical-align:initial;}"
                testCase
                    "Vertical align unset"
                    [ VerticalAlign.unset ]
                    "{vertical-align:unset;}"
                testCase
                    "Position static"
                    [ Position.static']
                    "{position:static;}"
                testCase
                    "Position relative"
                    [ Position.relative]
                    "{position:relative;}"
                testCase
                    "Position absolute"
                    [ Position.absolute]
                    "{position:absolute;}"
                testCase
                    "Position sticky"
                    [ Position.sticky]
                    "{position:sticky;}"
                testCase
                    "Position fixed"
                    [ Position.fixed']
                    "{position:fixed;}"
                testCase
                    "Float left"
                    [ Float.left]
                    "{float:left;}"
                testCase
                    "Float right"
                    [ Float.right]
                    "{float:right;}"
                testCase
                    "Float inline-start"
                    [ Float.inlineStart]
                    "{float:inline-start;}"
                testCase
                    "Float inline-end"
                    [ Float.inlineEnd]
                    "{float:inline-end;}"
                testCase
                    "Float none"
                    [ Float.none]
                    "{float:none;}"
                testCase
                    "Float inherit"
                    [ Float.inherit']
                    "{float:inherit;}"
                testCase
                    "Float initial"
                    [ Float.initial]
                    "{float:initial;}"
                testCase
                    "Float unset"
                    [ Float.unset]
                    "{float:unset;}"
                testCase
                    "WritingMode horizontal-tb"
                    [ WritingMode.horizontalTb]
                    "{writing-mode:horizontal-tb;}"
                testCase
                    "WritingMode vertical-rl"
                    [ WritingMode.verticalRl]
                    "{writing-mode:vertical-rl;}"
                testCase
                    "WritingMode vertical-lr"
                    [ WritingMode.verticalLr]
                    "{writing-mode:vertical-lr;}"
                testCase
                    "WritingMode inherit"
                    [ WritingMode.inherit']
                    "{writing-mode:inherit;}"
                testCase
                    "WritingMode initial"
                    [ WritingMode.initial]
                    "{writing-mode:initial;}"
                testCase
                    "WritingMode unset"
                    [ WritingMode.unset]
                    "{writing-mode:unset;}"
                testCase
                    "WritingMode revert"
                    [ WritingMode.revert]
                    "{writing-mode:revert;}"
                testCase
                    "BreakAfter avoid"
                    [BreakAfter.avoid]
                    "{break-after:avoid;}"
                testCase
                    "BreakAfter always"
                    [BreakAfter.always]
                    "{break-after:always;}"
                testCase
                    "BreakAfter all"
                    [BreakAfter.all]
                    "{break-after:all;}"
                testCase
                    "BreakAfter avoid-page"
                    [BreakAfter.avoidPage]
                    "{break-after:avoid-page;}"
                testCase
                    "BreakAfter page"
                    [BreakAfter.page]
                    "{break-after:page;}"
                testCase
                    "BreakAfter left"
                    [BreakAfter.left]
                    "{break-after:left;}"
                testCase
                    "BreakAfter right"
                    [BreakAfter.right]
                    "{break-after:right;}"
                testCase
                    "BreakAfter recto"
                    [BreakAfter.recto]
                    "{break-after:recto;}"
                testCase
                    "BreakAfter verso"
                    [BreakAfter.verso]
                    "{break-after:verso;}"
                testCase
                    "BreakAfter avoid-column"
                    [BreakAfter.avoidColumn]
                    "{break-after:avoid-column;}"
                testCase
                    "BreakAfter column"
                    [BreakAfter.column]
                    "{break-after:column;}"
                testCase
                    "BreakAfter avoid-region"
                    [BreakAfter.avoidRegion]
                    "{break-after:avoid-region;}"
                testCase
                    "BreakAfter region"
                    [BreakAfter.region]
                    "{break-after:region;}"
                testCase
                    "BreakAfter auto"
                    [ BreakAfter.auto]
                    "{break-after:auto;}"
                testCase
                    "BreakAfter inherit"
                    [ BreakAfter.inherit']
                    "{break-after:inherit;}"
                testCase
                    "BreakAfter initial"
                    [ BreakAfter.initial]
                    "{break-after:initial;}"
                testCase
                    "BreakAfter unset"
                    [ BreakAfter.unset]
                    "{break-after:unset;}"
                testCase
                    "BreakAfter revert"
                    [ BreakAfter.revert]
                    "{break-after:revert;}"
                testCase
                    "BreakBefore avoid"
                    [BreakBefore.avoid]
                    "{break-before:avoid;}"
                testCase
                    "BreakBefore always"
                    [BreakBefore.always]
                    "{break-before:always;}"
                testCase
                    "BreakBefore all"
                    [BreakBefore.all]
                    "{break-before:all;}"
                testCase
                    "BreakBefore avoid-page"
                    [BreakBefore.avoidPage]
                    "{break-before:avoid-page;}"
                testCase
                    "BreakBefore page"
                    [BreakBefore.page]
                    "{break-before:page;}"
                testCase
                    "BreakBefore left"
                    [BreakBefore.left]
                    "{break-before:left;}"
                testCase
                    "BreakBefore right"
                    [BreakBefore.right]
                    "{break-before:right;}"
                testCase
                    "BreakBefore recto"
                    [BreakBefore.recto]
                    "{break-before:recto;}"
                testCase
                    "BreakBefore verso"
                    [BreakBefore.verso]
                    "{break-before:verso;}"
                testCase
                    "BreakBefore avoid-column"
                    [BreakBefore.avoidColumn]
                    "{break-before:avoid-column;}"
                testCase
                    "BreakBefore column"
                    [BreakBefore.column]
                    "{break-before:column;}"
                testCase
                    "BreakBefore avoid-region"
                    [BreakBefore.avoidRegion]
                    "{break-before:avoid-region;}"
                testCase
                    "BreakBefore region"
                    [BreakBefore.region]
                    "{break-before:region;}"
                testCase
                    "BreakBefore auto"
                    [ BreakBefore.auto]
                    "{break-before:auto;}"
                testCase
                    "BreakBefore inherit"
                    [ BreakBefore.inherit']
                    "{break-before:inherit;}"
                testCase
                    "BreakBefore initial"
                    [ BreakBefore.initial]
                    "{break-before:initial;}"
                testCase
                    "BreakBefore unset"
                    [ BreakBefore.unset]
                    "{break-before:unset;}"
                testCase
                    "BreakBefore revert"
                    [ BreakBefore.revert]
                    "{break-before:revert;}"
                testCase
                    "BreakInside avoid"
                    [BreakInside.avoid]
                    "{break-inside:avoid;}"
                testCase
                    "BreakInside avoid-page"
                    [BreakInside.avoidPage]
                    "{break-inside:avoid-page;}"
                testCase
                    "BreakInside avoid-column"
                    [BreakInside.avoidColumn]
                    "{break-inside:avoid-column;}"
                testCase
                    "BreakInside avoid-region"
                    [BreakInside.avoidRegion]
                    "{break-inside:avoid-region;}"
                testCase
                    "BreakInside auto"
                    [ BreakInside.auto]
                    "{break-inside:auto;}"
                testCase
                    "BreakInside inherit"
                    [ BreakInside.inherit']
                    "{break-inside:inherit;}"
                testCase
                    "BreakInside initial"
                    [ BreakInside.initial]
                    "{break-inside:initial;}"
                testCase
                    "BreakInside unset"
                    [ BreakInside.unset]
                    "{break-inside:unset;}"
                testCase
                    "BreakInside revert"
                    [ BreakInside.revert]
                    "{break-inside:revert;}"
            ]
