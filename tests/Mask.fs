namespace FSSTests

open Fet
open Fss.FssTypes
open Utils
open Fss

module Mask =
     let tests =
        testList "Mask"
            [
                testCase
                    "MaskClip content-box"
                    [ MaskClip.contentBox]
                    "{ mask-clip: content-box; }" 
                testCase
                    "MaskClip padding-box"
                    [ MaskClip.paddingBox]
                    "{ mask-clip: padding-box; }" 
                testCase
                    "MaskClip border-box"
                    [ MaskClip.borderBox]
                    "{ mask-clip: border-box; }" 
                testCase
                    "MaskClip margin-box"
                    [ MaskClip.marginBox]
                    "{ mask-clip: margin-box; }" 
                testCase
                    "MaskClip fill-box"
                    [ MaskClip.fillBox]
                    "{ mask-clip: fill-box; }" 
                testCase
                    "MaskClip stroke-box"
                    [ MaskClip.strokeBox]
                    "{ mask-clip: stroke-box; }" 
                testCase
                    "MaskClip view-box"
                    [ MaskClip.viewBox]
                    "{ mask-clip: view-box; }" 
                testCase
                    "MaskClip no-clip"
                    [ MaskClip.noClip]
                    "{ mask-clip: no-clip; }" 
                testCase
                    "MaskClip border"
                    [ MaskClip.border]
                    "{ mask-clip: border; }" 
                testCase
                    "MaskClip padding"
                    [ MaskClip.padding]
                    "{ mask-clip: padding; }" 
                testCase
                    "MaskClip content"
                    [ MaskClip.content]
                    "{ mask-clip: content; }" 
                testCase
                    "MaskClip text"
                    [ MaskClip.text]
                    "{ mask-clip: text; }" 
                testCase
                    "MaskClip inherit"
                    [ MaskClip.inherit']
                    "{ mask-clip: inherit; }" 
                testCase
                    "MaskClip initial"
                    [ MaskClip.initial]
                    "{ mask-clip: initial; }" 
                testCase
                    "MaskClip unset"
                    [ MaskClip.unset ]
                    "{ mask-clip: unset; }"
                testCase
                    "MaskClip revert"
                    [ MaskClip.revert ]
                    "{ mask-clip: revert; }"
                testCase
                    "MaskComposite add"
                    [ MaskComposite.add]
                    "{ mask-composite: add; }" 
                testCase
                    "MaskComposite subtract"
                    [ MaskComposite.subtract]
                    "{ mask-composite: subtract; }" 
                testCase
                    "MaskComposite intersect"
                    [ MaskComposite.intersect]
                    "{ mask-composite: intersect; }" 
                testCase
                    "MaskComposite exclude"
                    [ MaskComposite.exclude]
                    "{ mask-composite: exclude; }" 
                testCase
                    "MaskComposite inherit"
                    [ MaskComposite.inherit']
                    "{ mask-composite: inherit; }" 
                testCase
                    "MaskComposite initial"
                    [ MaskComposite.initial]
                    "{ mask-composite: initial; }" 
                testCase
                    "MaskComposite unset"
                    [ MaskComposite.unset ]
                    "{ mask-composite: unset; }"
                testCase
                    "MaskComposite revert"
                    [ MaskComposite.revert ]
                    "{ mask-composite: revert; }"
                testCase
                    "Mask image source none"
                    [ MaskImage.none ]
                    "{ mask-image: none; }" 
                testCase
                    "Mask image source url"
                    [ MaskImage.url "image.jpg" ]
                    "{ mask-image: url(image.jpg); }" 
                testCase
                    "Mask image source linear gradient"
                    [ MaskImage.linearGradient((deg 45., [ FssTypes.Color.Red, pct 0; FssTypes.Color.Blue, pct 100 ])) ]
                    "{ mask-image: linear-gradient(45deg, red 0%, blue 100%); }" 
                testCase
                    "Mask image source inherit"
                    [ MaskImage.inherit' ]
                    "{ mask-image: inherit; }" 
                testCase
                    "Mask image source initial"
                    [ MaskImage.initial ]
                    "{ mask-image: initial; }" 
                testCase
                    "Mask image source unset"
                    [ MaskImage.unset ]
                    "{ mask-image: unset; }"
                testCase
                    "Mask image source revert"
                    [ MaskImage.revert ]
                    "{ mask-image: revert; }"
                testCase
                    "Mask mode alpha"
                    [ MaskMode.alpha ]
                    "{ mask-mode: alpha; }" 
                testCase
                    "Mask mode luminance"
                    [ MaskMode.luminance ]
                    "{ mask-mode: luminance; }" 
                testCase
                    "Mask mode match-source"
                    [ MaskMode.matchSource ]
                    "{ mask-mode: match-source; }" 
                testCase
                    "Mask mode multiple"
                    [ MaskMode.value [FssTypes.Mask.Alpha; FssTypes.Mask.MatchSource] ]
                    "{ mask-mode: alpha, match-source; }" 
                testCase
                    "Mask mode inherit"
                    [ MaskMode.inherit' ]
                    "{ mask-mode: inherit; }" 
                testCase
                    "Mask mode initial"
                    [ MaskMode.initial ]
                    "{ mask-mode: initial; }" 
                testCase
                    "Mask mode unset"
                    [ MaskMode.unset ]
                    "{ mask-mode: unset; }"
                testCase
                    "Mask mode revert"
                    [ MaskMode.revert ]
                    "{ mask-mode: revert; }"
                testCase
                    "MaskOrigin multiple"
                    [ MaskOrigin.value([FssTypes.Mask.Origin.ViewBox; FssTypes.Mask.Origin.FillBox; FssTypes.Mask.Origin.BorderBox])]
                    "{ mask-origin: view-box, fill-box, border-box; }" 
                testCase
                    "MaskOrigin content-box"
                    [ MaskOrigin.contentBox]
                    "{ mask-origin: content-box; }" 
                testCase
                    "MaskOrigin padding-box"
                    [ MaskOrigin.paddingBox]
                    "{ mask-origin: padding-box; }" 
                testCase
                    "MaskOrigin border-box"
                    [ MaskOrigin.borderBox]
                    "{ mask-origin: border-box; }" 
                testCase
                    "MaskOrigin margin-box"
                    [ MaskOrigin.marginBox]
                    "{ mask-origin: margin-box; }" 
                testCase
                    "MaskOrigin fill-box"
                    [ MaskOrigin.fillBox]
                    "{ mask-origin: fill-box; }" 
                testCase
                    "MaskOrigin stroke-box"
                    [ MaskOrigin.strokeBox]
                    "{ mask-origin: stroke-box; }" 
                testCase
                    "MaskOrigin view-box"
                    [ MaskOrigin.viewBox]
                    "{ mask-origin: view-box; }" 
                testCase
                    "MaskOrigin border"
                    [ MaskOrigin.border]
                    "{ mask-origin: border; }" 
                testCase
                    "MaskOrigin padding"
                    [ MaskOrigin.padding]
                    "{ mask-origin: padding; }" 
                testCase
                    "MaskOrigin content"
                    [ MaskOrigin.content]
                    "{ mask-origin: content; }" 
                testCase
                    "MaskOrigin inherit"
                    [ MaskOrigin.inherit']
                    "{ mask-origin: inherit; }" 
                testCase
                    "MaskOrigin initial"
                    [ MaskOrigin.initial]
                    "{ mask-origin: initial; }" 
                testCase
                    "MaskOrigin unset"
                    [ MaskOrigin.unset ]
                    "{ mask-origin: unset; }"
                testCase
                    "MaskPosition size"
                    [ MaskPosition.value(px 1, rem 1.)]
                    "{ mask-position: 1px 1rem; }" 
                testCase
                    "MaskPosition sizes"
                    [ MaskPosition.value [px 1 :> ILengthPercentage, rem 1. :> ILengthPercentage; px 10, px 100] ]
                    "{ mask-position: 1px 1rem, 10px 100px; }" 
                testCase
                    "MaskPosition percent"
                    [ MaskPosition.value(pct 10, pct 50)]
                    "{ mask-position: 10% 50%; }" 
                testCase
                    "MaskPosition percents"
                    [ MaskPosition.value [pct 10 :> ILengthPercentage, pct 50 :> ILengthPercentage; pct 50, pct 50] ]
                    "{ mask-position: 10% 50%, 50% 50%; }" 
                testCase
                    "MaskPosition inherit"
                    [ MaskPosition.inherit']
                    "{ mask-position: inherit; }" 
                testCase
                    "MaskPosition initial"
                    [ MaskPosition.initial]
                    "{ mask-position: initial; }" 
                testCase
                    "MaskPosition unset"
                    [ MaskPosition.unset ]
                    "{ mask-position: unset; }"
                testCase
                    "MaskPosition revert"
                    [ MaskPosition.revert ]
                    "{ mask-position: revert; }"
                testCase
                    "MaskRepeat 2 value"
                    [ MaskRepeat.value(FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY)]
                    "{ mask-repeat: repeat-x repeat-y; }" 
                testCase
                    "MaskRepeat multiple values"
                    [ MaskRepeat.value [FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY; FssTypes.Mask.NoRepeat, FssTypes.Mask.Round]]
                    "{ mask-repeat: repeat-x repeat-y, no-repeat round; }" 
                testCase
                    "MaskRepeat repeatX"
                    [ MaskRepeat.repeatX]
                    "{ mask-repeat: repeat-x; }" 
                testCase
                    "MaskRepeat repeatY"
                    [ MaskRepeat.repeatY]
                    "{ mask-repeat: repeat-y; }" 
                testCase
                    "MaskRepeat no-repeat"
                    [ MaskRepeat.noRepeat]
                    "{ mask-repeat: no-repeat; }" 
                testCase
                    "MaskRepeat repeat"
                    [ MaskRepeat.repeat]
                    "{ mask-repeat: repeat; }" 
                testCase
                    "MaskRepeat round"
                    [ MaskRepeat.round]
                    "{ mask-repeat: round; }" 
                testCase
                    "MaskRepeat space"
                    [ MaskRepeat.space]
                    "{ mask-repeat: space; }" 
                testCase
                    "MaskRepeat inherit"
                    [ MaskRepeat.inherit']
                    "{ mask-repeat: inherit; }" 
                testCase
                    "MaskRepeat initial"
                    [ MaskRepeat.initial]
                    "{ mask-repeat: initial; }" 
                testCase
                    "MaskRepeat unset"
                    [ MaskRepeat.unset ]
                    "{ mask-repeat: unset; }"
                testCase
                    "MaskRepeat revert"
                    [ MaskRepeat.revert ]
                    "{ mask-repeat: revert; }"
                testCase
                    "MaskSize cover"
                    [ MaskSize.cover]
                    "{ mask-size: cover; }" 
                testCase
                    "MaskSize contain"
                    [ MaskSize.contain]
                    "{ mask-size: contain; }" 
                testCase
                    "MaskSize pct"
                    [ MaskSize.value (pct 50) ]
                    "{ mask-size: 50%; }" 
                testCase
                    "MaskSize em"
                    [ MaskSize.value (em 3.) ]
                    "{ mask-size: 3em; }" 
                testCase
                    "MaskSize px"
                    [ MaskSize.value (px 12) ]
                    "{ mask-size: 12px; }" 
                testCase
                    "MaskSize em and pct"
                    [ MaskSize.value(em 3., pct 25) ]
                    "{ mask-size: 3em 25%; }" 
                testCase
                    "MaskSize multiple pct pct pct"
                    [ MaskSize.value [pct 50 :> ILengthPercentage; pct 25; pct 25] ]
                    "{ mask-size: 50%, 25%, 25%; }" 
                testCase
                    "MaskSize auto"
                    [ MaskSize.auto]
                    "{ mask-size: auto; }" 
                testCase
                    "MaskSize inherit"
                    [ MaskSize.inherit']
                    "{ mask-size: inherit; }" 
                testCase
                    "MaskSize initial"
                    [ MaskSize.initial]
                    "{ mask-size: initial; }" 
                testCase
                    "MaskSize unset"
                    [ MaskSize.unset ]
                    "{ mask-size: unset; }" 
                testCase
                    "MaskSize revert"
                    [ MaskSize.revert ]
                    "{ mask-size: revert; }" 
            ]