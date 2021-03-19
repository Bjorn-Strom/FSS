namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss
open FssTypes

module Mask =
     let tests =
        testList "Mask"
            [
                test
                    "MaskClip content-box"
                    [ MaskClip.ContentBox]
                    [ "maskClip" ==> "content-box" ]
                test
                    "MaskClip padding-box"
                    [ MaskClip.PaddingBox]
                    [ "maskClip" ==> "padding-box" ]
                test
                    "MaskClip border-box"
                    [ MaskClip.BorderBox]
                    [ "maskClip" ==> "border-box" ]
                test
                    "MaskClip margin-box"
                    [ MaskClip.MarginBox]
                    [ "maskClip" ==> "margin-box" ]
                test
                    "MaskClip fill-box"
                    [ MaskClip.FillBox]
                    [ "maskClip" ==> "fill-box" ]
                test
                    "MaskClip stroke-box"
                    [ MaskClip.StrokeBox]
                    [ "maskClip" ==> "stroke-box" ]
                test
                    "MaskClip view-box"
                    [ MaskClip.ViewBox]
                    [ "maskClip" ==> "view-box" ]
                test
                    "MaskClip no-clip"
                    [ MaskClip.NoClip]
                    [ "maskClip" ==> "no-clip" ]
                test
                    "MaskClip border"
                    [ MaskClip.Border]
                    [ "maskClip" ==> "border" ]
                test
                    "MaskClip padding"
                    [ MaskClip.Padding]
                    [ "maskClip" ==> "padding" ]
                test
                    "MaskClip content"
                    [ MaskClip.Content]
                    [ "maskClip" ==> "content" ]
                test
                    "MaskClip text"
                    [ MaskClip.Text]
                    [ "maskClip" ==> "text" ]
                test
                    "MaskClip inherit"
                    [ MaskClip.Inherit]
                    [ "maskClip" ==> "inherit" ]
                test
                    "MaskClip initial"
                    [ MaskClip.Initial]
                    [ "maskClip" ==> "initial" ]
                test
                    "MaskClip unset"
                    [ MaskClip.Unset ]
                    [ "maskClip" ==> "unset" ]
                test
                    "MaskComposite add"
                    [ MaskComposite.Add]
                    [ "maskComposite" ==> "add" ]
                test
                    "MaskComposite subtract"
                    [ MaskComposite.Subtract]
                    [ "maskComposite" ==> "subtract" ]
                test
                    "MaskComposite intersect"
                    [ MaskComposite.Intersect]
                    [ "maskComposite" ==> "intersect" ]
                test
                    "MaskComposite exclude"
                    [ MaskComposite.Exclude]
                    [ "maskComposite" ==> "exclude" ]
                test
                    "MaskComposite inherit"
                    [ MaskComposite.Inherit]
                    [ "maskComposite" ==> "inherit" ]
                test
                    "MaskComposite initial"
                    [ MaskComposite.Initial]
                    [ "maskComposite" ==> "initial" ]
                test
                    "MaskComposite unset"
                    [ MaskComposite.Unset ]
                    [ "maskComposite" ==> "unset" ]
                test
                    "Mask image source none"
                    [ MaskImage.None ]
                    [ "maskImage" ==> "none" ]
                test
                    "Mask image source url"
                    [ MaskImage.Url "image.jpg" ]
                    [ "maskImage" ==> "url(image.jpg)" ]
                test
                    "Mask image source linear gradient"
                    [ MaskImage.LinearGradient(deg 45., [ Fss.CssColor.CssColor.red, pct 0; Fss.CssColor.CssColor.blue, pct 100 ]) ]
                    [ "maskImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)" ]
                test
                    "Mask image source inherit"
                    [ MaskImage.Inherit ]
                    [ "maskImage" ==> "inherit" ]
                test
                    "Mask image source initial"
                    [ MaskImage.Initial ]
                    [ "maskImage" ==> "initial" ]
                test
                    "Mask image source unset"
                    [ MaskImage.Unset ]
                    [ "maskImage" ==> "unset" ]
                test
                    "Mask mode alpha"
                    [ MaskMode.Alpha ]
                    [ "maskMode" ==> "alpha" ]
                test
                    "Mask mode luminance"
                    [ MaskMode.Luminance ]
                    [ "maskMode" ==> "luminance" ]
                test
                    "Mask mode match-source"
                    [ MaskMode.MatchSource ]
                    [ "maskMode" ==> "match-source" ]
                test
                    "Mask mode multiple"
                    [ MaskMode.Value([Mask.Alpha; Mask.MatchSource]) ]
                    [ "maskMode" ==> "alpha, match-source" ]
                test
                    "Mask mode inherit"
                    [ MaskMode.Inherit ]
                    [ "maskMode" ==> "inherit" ]
                test
                    "Mask mode initial"
                    [ MaskMode.Initial ]
                    [ "maskMode" ==> "initial" ]
                test
                    "Mask mode unset"
                    [ MaskMode.Unset ]
                    [ "maskMode" ==> "unset" ]
                test
                    "MaskOrigin multiple"
                    [ MaskOrigin.Value([Mask.MaskOrigin.ViewBox; Mask.MaskOrigin.FillBox; Mask.MaskOrigin.BorderBox])]
                    [ "maskOrigin" ==> "view-box, fill-box, border-box" ]
                test
                    "MaskOrigin content-box"
                    [ MaskOrigin.ContentBox]
                    [ "maskOrigin" ==> "content-box" ]
                test
                    "MaskOrigin padding-box"
                    [ MaskOrigin.PaddingBox]
                    [ "maskOrigin" ==> "padding-box" ]
                test
                    "MaskOrigin border-box"
                    [ MaskOrigin.BorderBox]
                    [ "maskOrigin" ==> "border-box" ]
                test
                    "MaskOrigin margin-box"
                    [ MaskOrigin.MarginBox]
                    [ "maskOrigin" ==> "margin-box" ]
                test
                    "MaskOrigin fill-box"
                    [ MaskOrigin.FillBox]
                    [ "maskOrigin" ==> "fill-box" ]
                test
                    "MaskOrigin stroke-box"
                    [ MaskOrigin.StrokeBox]
                    [ "maskOrigin" ==> "stroke-box" ]
                test
                    "MaskOrigin view-box"
                    [ MaskOrigin.ViewBox]
                    [ "maskOrigin" ==> "view-box" ]
                test
                    "MaskOrigin border"
                    [ MaskOrigin.Border]
                    [ "maskOrigin" ==> "border" ]
                test
                    "MaskOrigin padding"
                    [ MaskOrigin.Padding]
                    [ "maskOrigin" ==> "padding" ]
                test
                    "MaskOrigin content"
                    [ MaskOrigin.Content]
                    [ "maskOrigin" ==> "content" ]
                test
                    "MaskOrigin inherit"
                    [ MaskOrigin.Inherit]
                    [ "maskOrigin" ==> "inherit" ]
                test
                    "MaskOrigin initial"
                    [ MaskOrigin.Initial]
                    [ "maskOrigin" ==> "initial" ]
                test
                    "MaskOrigin unset"
                    [ MaskOrigin.Unset ]
                    [ "maskOrigin" ==> "unset" ]
                test
                    "MaskPosition size"
                    [ MaskPosition.Value(px 1, rem 1.)]
                    [ "maskPosition" ==> "1px 1.0rem" ]
                test
                    "MaskPosition sizes"
                    [ MaskPosition.Value([px 1, rem 1.; px 10, px 100])]
                    [ "maskPosition" ==> "1px 1.0rem, 10px 100px" ]
                test
                    "MaskPosition percent"
                    [ MaskPosition.Value(pct 10, pct 50)]
                    [ "maskPosition" ==> "10% 50%" ]
                test
                    "MaskPosition percents"
                    [ MaskPosition.Value([pct 10, pct 50; pct 50, pct 50])]
                    [ "maskPosition" ==> "10% 50%, 50% 50%" ]
                test
                    "MaskPosition inherit"
                    [ MaskPosition.Inherit]
                    [ "maskPosition" ==> "inherit" ]
                test
                    "MaskPosition initial"
                    [ MaskPosition.Initial]
                    [ "maskPosition" ==> "initial" ]
                test
                    "MaskPosition unset"
                    [ MaskPosition.Unset ]
                    [ "maskPosition" ==> "unset" ]

                test
                    "MaskRepeat value"
                    [ MaskRepeat.Value(Mask.Repeat)]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat 2 value"
                    [ MaskRepeat.Value(Mask.RepeatX, Mask.RepeatY)]
                    [ "maskRepeat" ==> "repeat-x repeat-y" ]
                test
                    "MaskRepeat multiple values"
                    [ MaskRepeat.Value([Mask.RepeatX, Mask.RepeatY; Mask.NoRepeat, Mask.Round])]
                    [ "maskRepeat" ==> "repeat-x repeat-y, no-repeat round" ]
                test
                    "MaskRepeat repeatX"
                    [ MaskRepeat.RepeatX]
                    [ "maskRepeat" ==> "repeat-x" ]
                test
                    "MaskRepeat repeatY"
                    [ MaskRepeat.RepeatY]
                    [ "maskRepeat" ==> "repeat-y" ]
                test
                    "MaskRepeat no-repeat"
                    [ MaskRepeat.NoRepeat]
                    [ "maskRepeat" ==> "no-repeat" ]
                test
                    "MaskRepeat repeat"
                    [ MaskRepeat.Repeat]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat round"
                    [ MaskRepeat.Round]
                    [ "maskRepeat" ==> "round" ]
                test
                    "MaskRepeat space"
                    [ MaskRepeat.Space]
                    [ "maskRepeat" ==> "space" ]
                test
                    "MaskRepeat inherit"
                    [ MaskRepeat.Inherit]
                    [ "maskRepeat" ==> "inherit" ]
                test
                    "MaskRepeat initial"
                    [ MaskRepeat.Initial]
                    [ "maskRepeat" ==> "initial" ]
                test
                    "MaskRepeat unset"
                    [ MaskRepeat.Unset ]
                    [ "maskRepeat" ==> "unset" ]
            ]