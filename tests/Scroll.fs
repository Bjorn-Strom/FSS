namespace FSSTests

open Fet
open Utils
open Fss

module Scroll =
     let tests =
        testList "Scroll"
            [
                testCase
                    "ScrollBehavior auto"
                    [ ScrollBehavior.auto]
                    "scroll-behavior: auto;"
                testCase
                    "ScrollBehavior smooth"
                    [ ScrollBehavior.smooth]
                    "scroll-behavior: smooth;"
                testCase
                    "ScrollBehavior inherit"
                    [ ScrollBehavior.inherit']
                    "scroll-behavior: inherit;"
                testCase
                    "ScrollBehavior initial"
                    [ ScrollBehavior.initial]
                    "scroll-behavior: initial;"
                testCase
                    "ScrollBehavior unset"
                    [ ScrollBehavior.unset ]
                    "scroll-behavior: unset;"
                testCase
                    "ScrollBehavior revert"
                    [ ScrollBehavior.revert ]
                    "scroll-behavior: revert;"
                testCase
                    "OverscrollBehaviorX contain"
                    [ OverscrollBehaviorX.contain]
                    "overscroll-behavior-x: contain;"
                testCase
                    "OverscrollBehaviorX auto"
                    [ OverscrollBehaviorX.auto]
                    "overscroll-behavior-x: auto;"
                testCase
                    "OverscrollBehaviorX inherit"
                    [ OverscrollBehaviorX.inherit']
                    "overscroll-behavior-x: inherit;"
                testCase
                    "OverscrollBehaviorX initial"
                    [ OverscrollBehaviorX.initial]
                    "overscroll-behavior-x: initial;"
                testCase
                    "OverscrollBehaviorX unset"
                    [ OverscrollBehaviorX.unset ]
                    "overscroll-behavior-x: unset;"
                testCase
                    "OverscrollBehaviorY contain"
                    [ OverscrollBehaviorY.contain]
                    "overscroll-behavior-y: contain;"
                testCase
                    "OverscrollBehaviorY auto"
                    [ OverscrollBehaviorY.auto]
                    "overscroll-behavior-y: auto;"
                testCase
                    "OverscrollBehaviorY inherit"
                    [ OverscrollBehaviorY.inherit']
                    "overscroll-behavior-y: inherit;"
                testCase
                    "OverscrollBehaviorY initial"
                    [ OverscrollBehaviorY.initial]
                    "overscroll-behavior-y: initial;"
                testCase
                    "OverscrollBehaviorY unset"
                    [ OverscrollBehaviorY.unset ]
                    "overscroll-behavior-y: unset;"
                testCase
                    "ScrollPadding top px"
                    [ ScrollPaddingTop.value (px 10)]
                    "scroll-padding-top: 10px;"
                testCase
                    "ScrollPadding top px"
                    [ ScrollPaddingTop.value (pct 50)]
                    "scroll-padding-top: 50%;"
                testCase
                    "ScrollPaddingTop inherit"
                    [ ScrollPaddingTop.inherit']
                    "scroll-padding-top: inherit;"
                testCase
                    "ScrollPaddingTop initial"
                    [ ScrollPaddingTop.initial]
                    "scroll-padding-top: initial;"
                testCase
                    "ScrollPaddingTop unset"
                    [ ScrollPaddingTop.unset ]
                    "scroll-padding-top: unset;"
                testCase
                    "ScrollPaddingTop revert"
                    [ ScrollPaddingTop.revert ]
                    "scroll-padding-top: revert;"
                testCase
                    "ScrollPadding right px"
                    [ ScrollPaddingRight.value (px 10)]
                    "scroll-padding-right: 10px;"
                testCase
                    "ScrollPadding right px"
                    [ ScrollPaddingRight.value (pct 50)]
                    "scroll-padding-right: 50%;"
                testCase
                    "ScrollPaddingRight inherit"
                    [ ScrollPaddingRight.inherit']
                    "scroll-padding-right: inherit;"
                testCase
                    "ScrollPaddingRight initial"
                    [ ScrollPaddingRight.initial]
                    "scroll-padding-right: initial;"
                testCase
                    "ScrollPaddingRight unset"
                    [ ScrollPaddingRight.unset ]
                    "scroll-padding-right: unset;"
                testCase
                    "ScrollPaddingRight revert"
                    [ ScrollPaddingRight.revert ]
                    "scroll-padding-right: revert;"
                testCase
                    "ScrollPadding bottom px"
                    [ ScrollPaddingBottom.value (px 10)]
                    "scroll-padding-bottom: 10px;"
                testCase
                    "ScrollPadding bottom px"
                    [ ScrollPaddingBottom.value (pct 50)]
                    "scroll-padding-bottom: 50%;"
                testCase
                    "ScrollPaddingBottom inherit"
                    [ ScrollPaddingBottom.inherit']
                    "scroll-padding-bottom: inherit;"
                testCase
                    "ScrollPaddingBottom initial"
                    [ ScrollPaddingBottom.initial]
                    "scroll-padding-bottom: initial;"
                testCase
                    "ScrollPaddingBottom unset"
                    [ ScrollPaddingBottom.unset ]
                    "scroll-padding-bottom: unset;"
                testCase
                    "ScrollPaddingBottom revert"
                    [ ScrollPaddingBottom.revert ]
                    "scroll-padding-bottom: revert;"
                testCase
                    "ScrollPadding left px"
                    [ ScrollPaddingLeft.value (px 10)]
                    "scroll-padding-left: 10px;"
                testCase
                    "ScrollPadding left px"
                    [ ScrollPaddingLeft.value (pct 50)]
                    "scroll-padding-left: 50%;"
                testCase
                    "ScrollPaddingLeft inherit"
                    [ ScrollPaddingLeft.inherit']
                    "scroll-padding-left: inherit;"
                testCase
                    "ScrollPaddingLeft initial"
                    [ ScrollPaddingLeft.initial]
                    "scroll-padding-left: initial;"
                testCase
                    "ScrollPaddingLeft unset"
                    [ ScrollPaddingLeft.unset ]
                    "scroll-padding-left: unset;"
                testCase
                    "ScrollPaddingLeft revert"
                    [ ScrollPaddingLeft.revert ]
                    "scroll-padding-left: revert;"
                testCase
                    "ScrollPadding px"
                    [ ScrollPadding.value (px 10)]
                    "scroll-padding: 10px;"
                testCase
                    "ScrollPadding em"
                    [ ScrollPadding.value (em 10.0)]
                    "scroll-padding: 10em;"
                testCase
                    "ScrollPadding inherit"
                    [ ScrollPadding.inherit']
                    "scroll-padding: inherit;"
                testCase
                    "ScrollPadding initial"
                    [ ScrollPadding.initial]
                    "scroll-padding: initial;"
                testCase
                    "ScrollPadding unset"
                    [ ScrollPadding.unset ]
                    "scroll-padding: unset;"
                testCase
                    "ScrollPadding revert"
                    [ ScrollPadding.revert ]
                    "scroll-padding: revert;"
                testCase
                    "ScrollPaddings multiple"
                    [ ScrollPadding.value (px 10, px 20, px 30, px 40) ]
                    "scroll-padding: 10px 20px 30px 40px;"
                testCase
                    "ScrollMargin top px"
                    [ ScrollMarginTop.value (px 10)]
                    "scroll-margin-top: 10px;"
                testCase
                    "ScrollMargin top px"
                    [ ScrollMarginTop.value (pct 50)]
                    "scroll-margin-top: 50%;"
                testCase
                    "ScrollMarginTop inherit"
                    [ ScrollMarginTop.inherit']
                    "scroll-margin-top: inherit;"
                testCase
                    "ScrollMarginTop initial"
                    [ ScrollMarginTop.initial]
                    "scroll-margin-top: initial;"
                testCase
                    "ScrollMarginTop unset"
                    [ ScrollMarginTop.unset ]
                    "scroll-margin-top: unset;"
                testCase
                    "ScrollMarginTop revert"
                    [ ScrollMarginTop.revert ]
                    "scroll-margin-top: revert;"
                testCase
                    "ScrollMargin right px"
                    [ ScrollMarginRight.value (px 10)]
                    "scroll-margin-right: 10px;"
                testCase
                    "ScrollMargin right px"
                    [ ScrollMarginRight.value (pct 50)]
                    "scroll-margin-right: 50%;"
                testCase
                    "ScrollMarginRight inherit"
                    [ ScrollMarginRight.inherit']
                    "scroll-margin-right: inherit;"
                testCase
                    "ScrollMarginRight initial"
                    [ ScrollMarginRight.initial]
                    "scroll-margin-right: initial;"
                testCase
                    "ScrollMarginRight unset"
                    [ ScrollMarginRight.unset ]
                    "scroll-margin-right: unset;"
                testCase
                    "ScrollMarginRight revert"
                    [ ScrollMarginRight.revert ]
                    "scroll-margin-right: revert;"
                testCase
                    "ScrollMargin bottom px"
                    [ ScrollMarginBottom.value (px 10)]
                    "scroll-margin-bottom: 10px;"
                testCase
                    "ScrollMargin bottom px"
                    [ ScrollMarginBottom.value (pct 50)]
                    "scroll-margin-bottom: 50%;"
                testCase
                    "ScrollMarginBottom inherit"
                    [ ScrollMarginBottom.inherit']
                    "scroll-margin-bottom: inherit;"
                testCase
                    "ScrollMarginBottom initial"
                    [ ScrollMarginBottom.initial]
                    "scroll-margin-bottom: initial;"
                testCase
                    "ScrollMarginBottom unset"
                    [ ScrollMarginBottom.unset ]
                    "scroll-margin-bottom: unset;"
                testCase
                    "ScrollMarginBottom revert"
                    [ ScrollMarginBottom.revert ]
                    "scroll-margin-bottom: revert;"
                testCase
                    "ScrollMargin left px"
                    [ ScrollMarginLeft.value (px 10)]
                    "scroll-margin-left: 10px;"
                testCase
                    "ScrollMargin left px"
                    [ ScrollMarginLeft.value (pct 50)]
                    "scroll-margin-left: 50%;"
                testCase
                    "ScrollMarginLeft inherit"
                    [ ScrollMarginLeft.inherit']
                    "scroll-margin-left: inherit;"
                testCase
                    "ScrollMarginLeft initial"
                    [ ScrollMarginLeft.initial]
                    "scroll-margin-left: initial;"
                testCase
                    "ScrollMarginLeft unset"
                    [ ScrollMarginLeft.unset ]
                    "scroll-margin-left: unset;"
                testCase
                    "ScrollMarginLeft revert"
                    [ ScrollMarginLeft.revert ]
                    "scroll-margin-left: revert;"
                testCase
                    "ScrollMargin em"
                    [ ScrollMargin.value (em 10.0)]
                    "scroll-margin: 10em;"
                testCase
                    "ScrollMargin inherit"
                    [ ScrollMargin.inherit']
                    "scroll-margin: inherit;"
                testCase
                    "ScrollMargin initial"
                    [ ScrollMargin.initial]
                    "scroll-margin: initial;"
                testCase
                    "ScrollMargin unset"
                    [ ScrollMargin.unset ]
                    "scroll-margin: unset;"
                testCase
                    "ScrollMargins multiple"
                    [ ScrollMargin.value (px 10, px 20, px 30, px 40) ]
                    "scroll-margin: 10px 20px 30px 40px;"
                testCase
                    "ScrollSnapType none"
                    [ ScrollSnapType.none ]
                    "scroll-snap-type: none;"
                testCase
                    "ScrollSnapType x"
                    [ ScrollSnapType.x ]
                    "scroll-snap-type: x;"
                testCase
                    "ScrollSnapType y"
                    [ ScrollSnapType.y ]
                    "scroll-snap-type: y;"
                testCase
                    "ScrollSnapType block"
                    [ ScrollSnapType.block ]
                    "scroll-snap-type: block;"
                testCase
                    "ScrollSnapType inline"
                    [ ScrollSnapType.inline' ]
                    "scroll-snap-type: inline;"
                testCase
                    "ScrollSnapType both"
                    [ ScrollSnapType.both ]
                    "scroll-snap-type: both;"
                testCase
                    "ScrollSnapType x mandatory"
                    [ ScrollSnapType.mandatory(FssTypes.Scroll.SnapType.X) ]
                    "scroll-snap-type: x mandatory;"
                testCase
                    "ScrollSnapType x mandatory"
                    [ ScrollSnapType.proximity(FssTypes.Scroll.SnapType.X) ]
                    "scroll-snap-type: x proximity;"
                testCase
                    "ScrollSnapType inherit"
                    [ ScrollSnapType.inherit']
                    "scroll-snap-type: inherit;"
                testCase
                    "ScrollSnapType initial"
                    [ ScrollSnapType.initial]
                    "scroll-snap-type: initial;"
                testCase
                    "ScrollSnapType unset"
                    [ ScrollSnapType.unset ]
                    "scroll-snap-type: unset;"
                testCase
                    "ScrollSnapType revert"
                    [ ScrollSnapType.revert ]
                    "scroll-snap-type: revert;"
                testCase
                    "ScrollSnapAlign start end"
                    [ ScrollSnapAlign.value(FssTypes.Scroll.SnapAlign.Start, FssTypes.Scroll.SnapAlign.End)]
                    "scroll-snap-align: start end;"
                testCase
                    "ScrollSnapAlign start"
                    [ ScrollSnapAlign.start]
                    "scroll-snap-align: start;"
                testCase
                    "ScrollSnapAlign end"
                    [ ScrollSnapAlign.end']
                    "scroll-snap-align: end;"
                testCase
                    "ScrollSnapAlign center"
                    [ ScrollSnapAlign.center]
                    "scroll-snap-align: center;"
                testCase
                    "ScrollSnapAlign none"
                    [ ScrollSnapAlign.none]
                    "scroll-snap-align: none;"
                testCase
                    "ScrollSnapAlign inherit"
                    [ ScrollSnapAlign.inherit' ]
                    "scroll-snap-align: inherit;"
                testCase
                    "ScrollSnapAlign initial"
                    [ ScrollSnapAlign.initial]
                    "scroll-snap-align: initial;"
                testCase
                    "ScrollSnapAlign unset"
                    [ ScrollSnapAlign.unset ]
                    "scroll-snap-align: unset;"
                testCase
                    "ScrollSnapAlign revert"
                    [ ScrollSnapAlign.revert ]
                    "scroll-snap-align: revert;"
                testCase
                    "ScrollSnapStop normal"
                    [ ScrollSnapStop.normal]
                    "scroll-snap-stop: normal;"
                testCase
                    "ScrollSnapStop always"
                    [ ScrollSnapStop.always]
                    "scroll-snap-stop: always;"
                testCase
                    "ScrollSnapStop inherit"
                    [ ScrollSnapStop.inherit' ]
                    "scroll-snap-stop: inherit;"
                testCase
                    "ScrollSnapStop initial"
                    [ ScrollSnapStop.initial]
                    "scroll-snap-stop: initial;"
                testCase
                    "ScrollSnapStop unset"
                    [ ScrollSnapStop.unset ]
                    "scroll-snap-stop: unset;"
                testCase
                    "ScrollSnapStop revert"
                    [ ScrollSnapStop.revert ]
                    "scroll-snap-stop: revert;"
            ]