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
                    [ MaskImage.LinearGradient(deg 45., [ CssColor.red, pct 0; CssColor.blue, pct 100 ]) ]
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
                    [ MaskMode.Value([MaskTypes.Alpha; MaskTypes.MatchSource]) ]
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
                    [ MaskOrigin.Value([MaskTypes.MaskOrigin.ViewBox; MaskTypes.MaskOrigin.FillBox; MaskTypes.MaskOrigin.BorderBox])]
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
            ]