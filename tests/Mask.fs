namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Mask =
     let tests =
        testList "Mask"
            [
                test
                    "MaskClip content-box"
                    [ MaskClip.contentBox]
                    [ "maskClip" ==> "content-box" ]
                test
                    "MaskClip padding-box"
                    [ MaskClip.paddingBox]
                    [ "maskClip" ==> "padding-box" ]
                test
                    "MaskClip border-box"
                    [ MaskClip.borderBox]
                    [ "maskClip" ==> "border-box" ]
                test
                    "MaskClip margin-box"
                    [ MaskClip.marginBox]
                    [ "maskClip" ==> "margin-box" ]
                test
                    "MaskClip fill-box"
                    [ MaskClip.fillBox]
                    [ "maskClip" ==> "fill-box" ]
                test
                    "MaskClip stroke-box"
                    [ MaskClip.strokeBox]
                    [ "maskClip" ==> "stroke-box" ]
                test
                    "MaskClip view-box"
                    [ MaskClip.viewBox]
                    [ "maskClip" ==> "view-box" ]
                test
                    "MaskClip no-clip"
                    [ MaskClip.noClip]
                    [ "maskClip" ==> "no-clip" ]
                test
                    "MaskClip border"
                    [ MaskClip.border]
                    [ "maskClip" ==> "border" ]
                test
                    "MaskClip padding"
                    [ MaskClip.padding]
                    [ "maskClip" ==> "padding" ]
                test
                    "MaskClip content"
                    [ MaskClip.content]
                    [ "maskClip" ==> "content" ]
                test
                    "MaskClip text"
                    [ MaskClip.text]
                    [ "maskClip" ==> "text" ]
                test
                    "MaskClip inherit"
                    [ MaskClip.inherit']
                    [ "maskClip" ==> "inherit" ]
                test
                    "MaskClip initial"
                    [ MaskClip.initial]
                    [ "maskClip" ==> "initial" ]
                test
                    "MaskClip unset"
                    [ MaskClip.unset ]
                    [ "maskClip" ==> "unset" ]
                test
                    "MaskComposite add"
                    [ MaskComposite.add]
                    [ "maskComposite" ==> "add" ]
                test
                    "MaskComposite subtract"
                    [ MaskComposite.subtract]
                    [ "maskComposite" ==> "subtract" ]
                test
                    "MaskComposite intersect"
                    [ MaskComposite.intersect]
                    [ "maskComposite" ==> "intersect" ]
                test
                    "MaskComposite exclude"
                    [ MaskComposite.exclude]
                    [ "maskComposite" ==> "exclude" ]
                test
                    "MaskComposite inherit"
                    [ MaskComposite.inherit']
                    [ "maskComposite" ==> "inherit" ]
                test
                    "MaskComposite initial"
                    [ MaskComposite.initial]
                    [ "maskComposite" ==> "initial" ]
                test
                    "MaskComposite unset"
                    [ MaskComposite.unset ]
                    [ "maskComposite" ==> "unset" ]
                test
                    "Mask image source none"
                    [ MaskImage.none ]
                    [ "maskImage" ==> "none" ]
                test
                    "Mask image source url"
                    [ MaskImage.url "image.jpg" ]
                    [ "maskImage" ==> "url(image.jpg)" ]
                test
                    "Mask image source linear gradient"
                    [ MaskImage.linearGradient(deg 45., [ FssTypes.Color.red, pct 0; FssTypes.Color.blue, pct 100 ]) ]
                    [ "maskImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)" ]
                test
                    "Mask image source inherit"
                    [ MaskImage.inherit' ]
                    [ "maskImage" ==> "inherit" ]
                test
                    "Mask image source initial"
                    [ MaskImage.initial ]
                    [ "maskImage" ==> "initial" ]
                test
                    "Mask image source unset"
                    [ MaskImage.unset ]
                    [ "maskImage" ==> "unset" ]
                test
                    "Mask mode alpha"
                    [ MaskMode.alpha ]
                    [ "maskMode" ==> "alpha" ]
                test
                    "Mask mode luminance"
                    [ MaskMode.luminance ]
                    [ "maskMode" ==> "luminance" ]
                test
                    "Mask mode match-source"
                    [ MaskMode.matchSource ]
                    [ "maskMode" ==> "match-source" ]
                test
                    "Mask mode multiple"
                    [ MaskMode.value([FssTypes.Mask.Alpha; FssTypes.Mask.MatchSource]) ]
                    [ "maskMode" ==> "alpha, match-source" ]
                test
                    "Mask mode inherit"
                    [ MaskMode.inherit' ]
                    [ "maskMode" ==> "inherit" ]
                test
                    "Mask mode initial"
                    [ MaskMode.initial ]
                    [ "maskMode" ==> "initial" ]
                test
                    "Mask mode unset"
                    [ MaskMode.unset ]
                    [ "maskMode" ==> "unset" ]
                test
                    "MaskOrigin multiple"
                    [ MaskOrigin.value([FssTypes.Mask.Origin.ViewBox; FssTypes.Mask.Origin.FillBox; FssTypes.Mask.Origin.BorderBox])]
                    [ "maskOrigin" ==> "view-box, fill-box, border-box" ]
                test
                    "MaskOrigin content-box"
                    [ MaskOrigin.contentBox]
                    [ "maskOrigin" ==> "content-box" ]
                test
                    "MaskOrigin padding-box"
                    [ MaskOrigin.paddingBox]
                    [ "maskOrigin" ==> "padding-box" ]
                test
                    "MaskOrigin border-box"
                    [ MaskOrigin.borderBox]
                    [ "maskOrigin" ==> "border-box" ]
                test
                    "MaskOrigin margin-box"
                    [ MaskOrigin.marginBox]
                    [ "maskOrigin" ==> "margin-box" ]
                test
                    "MaskOrigin fill-box"
                    [ MaskOrigin.fillBox]
                    [ "maskOrigin" ==> "fill-box" ]
                test
                    "MaskOrigin stroke-box"
                    [ MaskOrigin.strokeBox]
                    [ "maskOrigin" ==> "stroke-box" ]
                test
                    "MaskOrigin view-box"
                    [ MaskOrigin.viewBox]
                    [ "maskOrigin" ==> "view-box" ]
                test
                    "MaskOrigin border"
                    [ MaskOrigin.border]
                    [ "maskOrigin" ==> "border" ]
                test
                    "MaskOrigin padding"
                    [ MaskOrigin.padding]
                    [ "maskOrigin" ==> "padding" ]
                test
                    "MaskOrigin content"
                    [ MaskOrigin.content]
                    [ "maskOrigin" ==> "content" ]
                test
                    "MaskOrigin inherit"
                    [ MaskOrigin.inherit']
                    [ "maskOrigin" ==> "inherit" ]
                test
                    "MaskOrigin initial"
                    [ MaskOrigin.initial]
                    [ "maskOrigin" ==> "initial" ]
                test
                    "MaskOrigin unset"
                    [ MaskOrigin.unset ]
                    [ "maskOrigin" ==> "unset" ]
                test
                    "MaskPosition size"
                    [ MaskPosition.value(px 1, rem 1.)]
                    [ "maskPosition" ==> "1px 1.0rem" ]
                test
                    "MaskPosition sizes"
                    [ MaskPosition.value([px 1, rem 1.; px 10, px 100])]
                    [ "maskPosition" ==> "1px 1.0rem, 10px 100px" ]
                test
                    "MaskPosition percent"
                    [ MaskPosition.value(pct 10, pct 50)]
                    [ "maskPosition" ==> "10% 50%" ]
                test
                    "MaskPosition percents"
                    [ MaskPosition.value([pct 10, pct 50; pct 50, pct 50])]
                    [ "maskPosition" ==> "10% 50%, 50% 50%" ]
                test
                    "MaskPosition inherit"
                    [ MaskPosition.inherit']
                    [ "maskPosition" ==> "inherit" ]
                test
                    "MaskPosition initial"
                    [ MaskPosition.initial]
                    [ "maskPosition" ==> "initial" ]
                test
                    "MaskPosition unset"
                    [ MaskPosition.unset ]
                    [ "maskPosition" ==> "unset" ]

                test
                    "MaskRepeat value"
                    [ MaskRepeat.value(FssTypes.Mask.Repeat)]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat 2 value"
                    [ MaskRepeat.value(FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY)]
                    [ "maskRepeat" ==> "repeat-x repeat-y" ]
                test
                    "MaskRepeat multiple values"
                    [ MaskRepeat.value([FssTypes.Mask.RepeatX, FssTypes.Mask.RepeatY; FssTypes.Mask.NoRepeat, FssTypes.Mask.Round])]
                    [ "maskRepeat" ==> "repeat-x repeat-y, no-repeat round" ]
                test
                    "MaskRepeat repeatX"
                    [ MaskRepeat.repeatX]
                    [ "maskRepeat" ==> "repeat-x" ]
                test
                    "MaskRepeat repeatY"
                    [ MaskRepeat.repeatY]
                    [ "maskRepeat" ==> "repeat-y" ]
                test
                    "MaskRepeat no-repeat"
                    [ MaskRepeat.noRepeat]
                    [ "maskRepeat" ==> "no-repeat" ]
                test
                    "MaskRepeat repeat"
                    [ MaskRepeat.repeat]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat round"
                    [ MaskRepeat.round]
                    [ "maskRepeat" ==> "round" ]
                test
                    "MaskRepeat space"
                    [ MaskRepeat.space]
                    [ "maskRepeat" ==> "space" ]
                test
                    "MaskRepeat inherit"
                    [ MaskRepeat.inherit']
                    [ "maskRepeat" ==> "inherit" ]
                test
                    "MaskRepeat initial"
                    [ MaskRepeat.initial]
                    [ "maskRepeat" ==> "initial" ]
                test
                    "MaskRepeat unset"
                    [ MaskRepeat.unset ]
                    [ "maskRepeat" ==> "unset" ]
            ]