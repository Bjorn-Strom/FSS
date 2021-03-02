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
            ]