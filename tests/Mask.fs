namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Mask =
     let tests =
        testList "Mask"
            [
                testCase
                    "MaskClip content-box"
                    [ MaskClip.contentBox]
                    [ "maskClip" ==> "content-box" ]
                testCase
                    "MaskClip padding-box"
                    [ MaskClip.paddingBox]
                    [ "maskClip" ==> "padding-box" ]
                testCase
                    "MaskClip border-box"
                    [ MaskClip.borderBox]
                    [ "maskClip" ==> "border-box" ]
                testCase
                    "MaskClip margin-box"
                    [ MaskClip.marginBox]
                    [ "maskClip" ==> "margin-box" ]
                testCase
                    "MaskClip fill-box"
                    [ MaskClip.fillBox]
                    [ "maskClip" ==> "fill-box" ]
                testCase
                    "MaskClip stroke-box"
                    [ MaskClip.strokeBox]
                    [ "maskClip" ==> "stroke-box" ]
                testCase
                    "MaskClip view-box"
                    [ MaskClip.viewBox]
                    [ "maskClip" ==> "view-box" ]
                testCase
                    "MaskClip no-clip"
                    [ MaskClip.noClip]
                    [ "maskClip" ==> "no-clip" ]
                testCase
                    "MaskClip border"
                    [ MaskClip.border]
                    [ "maskClip" ==> "border" ]
                testCase
                    "MaskClip padding"
                    [ MaskClip.padding]
                    [ "maskClip" ==> "padding" ]
                testCase
                    "MaskClip content"
                    [ MaskClip.content]
                    [ "maskClip" ==> "content" ]
                testCase
                    "MaskClip text"
                    [ MaskClip.text]
                    [ "maskClip" ==> "text" ]
                testCase
                    "MaskClip inherit"
                    [ MaskClip.inherit']
                    [ "maskClip" ==> "inherit" ]
                testCase
                    "MaskClip initial"
                    [ MaskClip.initial]
                    [ "maskClip" ==> "initial" ]
                testCase
                    "MaskClip unset"
                    [ MaskClip.unset ]
                    [ "maskClip" ==> "unset" ]
                testCase
                    "MaskComposite add"
                    [ MaskComposite.add]
                    [ "maskComposite" ==> "add" ]
                testCase
                    "MaskComposite subtract"
                    [ MaskComposite.subtract]
                    [ "maskComposite" ==> "subtract" ]
                testCase
                    "MaskComposite intersect"
                    [ MaskComposite.intersect]
                    [ "maskComposite" ==> "intersect" ]
                testCase
                    "MaskComposite exclude"
                    [ MaskComposite.exclude]
                    [ "maskComposite" ==> "exclude" ]
                testCase
                    "MaskComposite inherit"
                    [ MaskComposite.inherit']
                    [ "maskComposite" ==> "inherit" ]
                testCase
                    "MaskComposite initial"
                    [ MaskComposite.initial]
                    [ "maskComposite" ==> "initial" ]
                testCase
                    "MaskComposite unset"
                    [ MaskComposite.unset ]
                    [ "maskComposite" ==> "unset" ]
                testCase
                    "Mask image source none"
                    [ MaskImage.none ]
                    [ "maskImage" ==> "none" ]
                testCase
                    "Mask image source url"
                    [ MaskImage.url "image.jpg" ]
                    [ "maskImage" ==> "url(image.jpg)" ]
                testCase
                    "Mask image source linear gradient"
                    [ MaskImage.linearGradient(deg 45., [ FssTypes.Color.Color.red, pct 0; FssTypes.Color.Color.blue, pct 100 ]) ]
                    [ "maskImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)" ]
                testCase
                    "Mask image source inherit"
                    [ MaskImage.inherit' ]
                    [ "maskImage" ==> "inherit" ]
                testCase
                    "Mask image source initial"
                    [ MaskImage.initial ]
                    [ "maskImage" ==> "initial" ]
                testCase
                    "Mask image source unset"
                    [ MaskImage.unset ]
                    [ "maskImage" ==> "unset" ]
                testCase
                    "Mask mode alpha"
                    [ MaskMode.alpha ]
                    [ "maskMode" ==> "alpha" ]
                testCase
                    "Mask mode luminance"
                    [ MaskMode.luminance ]
                    [ "maskMode" ==> "luminance" ]
                testCase
                    "Mask mode match-source"
                    [ MaskMode.matchSource ]
                    [ "maskMode" ==> "match-source" ]
                testCase
                    "Mask mode multiple"
                    [ MaskMode.value([FssTypes.Mask.Alpha; FssTypes.Mask.MatchSource]) ]
                    [ "maskMode" ==> "alpha, match-source" ]
                testCase
                    "Mask mode inherit"
                    [ MaskMode.inherit' ]
                    [ "maskMode" ==> "inherit" ]
                testCase
                    "Mask mode initial"
                    [ MaskMode.initial ]
                    [ "maskMode" ==> "initial" ]
                testCase
                    "Mask mode unset"
                    [ MaskMode.unset ]
                    [ "maskMode" ==> "unset" ]
                testCase
                    "MaskOrigin multiple"
                    [ MaskOrigin.value([FssTypes.Mask.Origin.ViewBox; FssTypes.Mask.Origin.FillBox; FssTypes.Mask.Origin.BorderBox])]
                    [ "maskOrigin" ==> "view-box, fill-box, border-box" ]
                testCase
                    "MaskOrigin content-box"
                    [ MaskOrigin.contentBox]
                    [ "maskOrigin" ==> "content-box" ]
                testCase
                    "MaskOrigin padding-box"
                    [ MaskOrigin.paddingBox]
                    [ "maskOrigin" ==> "padding-box" ]
                testCase
                    "MaskOrigin border-box"
                    [ MaskOrigin.borderBox]
                    [ "maskOrigin" ==> "border-box" ]
                testCase
                    "MaskOrigin margin-box"
                    [ MaskOrigin.marginBox]
                    [ "maskOrigin" ==> "margin-box" ]
                testCase
                    "MaskOrigin fill-box"
                    [ MaskOrigin.fillBox]
                    [ "maskOrigin" ==> "fill-box" ]
                testCase
                    "MaskOrigin stroke-box"
                    [ MaskOrigin.strokeBox]
                    [ "maskOrigin" ==> "stroke-box" ]
                testCase
                    "MaskOrigin view-box"
                    [ MaskOrigin.viewBox]
                    [ "maskOrigin" ==> "view-box" ]
                testCase
                    "MaskOrigin border"
                    [ MaskOrigin.border]
                    [ "maskOrigin" ==> "border" ]
                testCase
                    "MaskOrigin padding"
                    [ MaskOrigin.padding]
                    [ "maskOrigin" ==> "padding" ]
                testCase
                    "MaskOrigin content"
                    [ MaskOrigin.content]
                    [ "maskOrigin" ==> "content" ]
                testCase
                    "MaskOrigin inherit"
                    [ MaskOrigin.inherit']
                    [ "maskOrigin" ==> "inherit" ]
                testCase
                    "MaskOrigin initial"
                    [ MaskOrigin.initial]
                    [ "maskOrigin" ==> "initial" ]
                testCase
                    "MaskOrigin unset"
                    [ MaskOrigin.unset ]
                    [ "maskOrigin" ==> "unset" ]
                testCase
                    "MaskPosition size"
                    [ MaskPosition.value(px 1, rem 1.)]
                    [ "maskPosition" ==> "1px 1.0rem" ]
                testCase
                    "MaskPosition sizes"
                    [ MaskPosition.value([px 1, rem 1.; px 10, px 100])]
                    [ "maskPosition" ==> "1px 1.0rem, 10px 100px" ]
                testCase
                    "MaskPosition percent"
                    [ MaskPosition.value(pct 10, pct 50)]
                    [ "maskPosition" ==> "10% 50%" ]
                testCase
                    "MaskPosition percents"
                    [ MaskPosition.value([pct 10, pct 50; pct 50, pct 50])]
                    [ "maskPosition" ==> "10% 50%, 50% 50%" ]
                testCase
                    "MaskPosition inherit"
                    [ MaskPosition.inherit']
                    [ "maskPosition" ==> "inherit" ]
                testCase
                    "MaskPosition initial"
                    [ MaskPosition.initial]
                    [ "maskPosition" ==> "initial" ]
                testCase
                    "MaskPosition unset"
                    [ MaskPosition.unset ]
                    [ "maskPosition" ==> "unset" ]

                testCase
                    "MaskRepeat value"
                    [ MaskRepeat.value(FssTypes.Mask.Repeat)]
                    [ "maskRepeat" ==> "repeat" ]
                testCase
                    "MaskRepeat 2 value"
                    [ MaskRepeat.value(FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY)]
                    [ "maskRepeat" ==> "repeat-x repeat-y" ]
                testCase
                    "MaskRepeat multiple values"
                    [ MaskRepeat.value([FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY; FssTypes.Mask.NoRepeat, FssTypes.Mask.Round])]
                    [ "maskRepeat" ==> "repeat-x repeat-y, no-repeat round" ]
                testCase
                    "MaskRepeat repeatX"
                    [ MaskRepeat.repeatX]
                    [ "maskRepeat" ==> "repeat-x" ]
                testCase
                    "MaskRepeat repeatY"
                    [ MaskRepeat.repeatY]
                    [ "maskRepeat" ==> "repeat-y" ]
                testCase
                    "MaskRepeat no-repeat"
                    [ MaskRepeat.noRepeat]
                    [ "maskRepeat" ==> "no-repeat" ]
                testCase
                    "MaskRepeat repeat"
                    [ MaskRepeat.repeat]
                    [ "maskRepeat" ==> "repeat" ]
                testCase
                    "MaskRepeat round"
                    [ MaskRepeat.round]
                    [ "maskRepeat" ==> "round" ]
                testCase
                    "MaskRepeat space"
                    [ MaskRepeat.space]
                    [ "maskRepeat" ==> "space" ]
                testCase
                    "MaskRepeat inherit"
                    [ MaskRepeat.inherit']
                    [ "maskRepeat" ==> "inherit" ]
                testCase
                    "MaskRepeat initial"
                    [ MaskRepeat.initial]
                    [ "maskRepeat" ==> "initial" ]
                testCase
                    "MaskRepeat unset"
                    [ MaskRepeat.unset ]
                    [ "maskRepeat" ==> "unset" ]
                testCase
                    "MaskSize cover"
                    [ MaskSize.cover]
                    [ "maskSize" ==> "cover" ]
                testCase
                    "MaskSize contain"
                    [ MaskSize.contain]
                    [ "maskSize" ==> "contain" ]
                testCase
                    "MaskSize pct"
                    [ MaskSize' <| pct 50 ]
                    [ "maskSize" ==> "50%" ]
                testCase
                    "MaskSize em"
                    [ MaskSize' <| em 3. ]
                    [ "maskSize" ==> "3.0em" ]
                testCase
                    "MaskSize px"
                    [ MaskSize' <| px 12 ]
                    [ "maskSize" ==> "12px" ]
                testCase
                    "MaskSize pct and auto"
                    [ MaskSize.value(pct 50, FssTypes.Auto) ]
                    [ "maskSize" ==> "50% auto" ]
                testCase
                    "MaskSize em and pct"
                    [ MaskSize.value(em 3., pct 25) ]
                    [ "maskSize" ==> "3.0em 25%" ]
                testCase
                    "MaskSize auto px"
                    [ MaskSize.value(FssTypes.Auto, px 6) ]
                    [ "maskSize" ==> "auto 6px" ]
                testCase
                    "MaskSize auto auto"
                    [ MaskSize.value(FssTypes.Auto, FssTypes.Auto) ]
                    [ "maskSize" ==> "auto auto" ]
                testCase
                    "MaskSize multiple auto auto"
                    [ MaskSize.values [FssTypes.Auto; FssTypes.Auto ] ]
                    [ "maskSize" ==> "auto, auto" ]
                testCase
                    "MaskSize multiple pct pct pct"
                    [ MaskSize.values [pct 50; pct 25; pct 25] ]
                    [ "maskSize" ==> "50%, 25%, 25%" ]
                testCase
                    "MaskSize multiple px auto contain"
                    [ MaskSize.values [px 6; FssTypes.Auto; FssTypes.Mask.Contain] ]
                    [ "maskSize" ==> "6px, auto, contain" ]
                testCase
                    "MaskSize auto"
                    [ MaskSize.auto]
                    [ "maskSize" ==> "auto" ]
                testCase
                    "MaskSize inherit"
                    [ MaskSize.inherit']
                    [ "maskSize" ==> "inherit" ]
                testCase
                    "MaskSize initial"
                    [ MaskSize.initial]
                    [ "maskSize" ==> "initial" ]
                testCase
                    "MaskSize unset"
                    [ MaskSize.unset ]
                    [ "maskSize" ==> "unset" ]
            ]