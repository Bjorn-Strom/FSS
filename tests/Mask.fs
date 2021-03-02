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
            ]