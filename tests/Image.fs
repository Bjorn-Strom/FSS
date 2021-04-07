namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Image =
     let tests =
        testList "Image"
            [
                testCase
                    "Object fit value"
                    [ ObjectFit' <| FssTypes.Image.ScaleDown]
                    [ "objectFit" ==> "scale-down" ]
                testCase
                    "Object fit fill"
                    [ ObjectFit.fill ]
                    [ "objectFit" ==> "fill" ]
                testCase
                    "Object fit contain"
                    [ ObjectFit.contain ]
                    [ "objectFit" ==> "contain" ]
                testCase
                    "Object fit cover"
                    [ ObjectFit.cover ]
                    [ "objectFit" ==> "cover" ]
                testCase
                    "Object fit scaleDown"
                    [ ObjectFit.scaleDown ]
                    [ "objectFit" ==> "scale-down" ]
                testCase
                    "Object fit none"
                    [ ObjectFit.none ]
                    [ "objectFit" ==> "none" ]
                testCase
                    "ObjectPosition pixels"
                    [ ObjectPosition' (px 10, px 10)]
                    [ "objectPosition" ==> "10px 10px" ]
                testCase
                    "ObjectPosition percent"
                    [ ObjectPosition' (pct 50, pct 50)]
                    [ "objectPosition" ==> "50% 50%" ]
                testCase
                    "ObjectPosition percent and pixels"
                    [ ObjectPosition' (pct 50, px 50)]
                    [ "objectPosition" ==> "50% 50px" ]
                testCase
                    "ObjectPosition inherit"
                    [ ObjectPosition.inherit']
                    [ "objectPosition" ==> "inherit" ]
                testCase
                    "ObjectPosition initial"
                    [ ObjectPosition.initial]
                    [ "objectPosition" ==> "initial" ]
                testCase
                    "ObjectPosition unset"
                    [ ObjectPosition.unset ]
                    [ "objectPosition" ==> "unset" ]
                testCase
                    "ImageRendering auto"
                    [ ImageRendering.auto]
                    [ "imageRendering" ==> "auto" ]
                testCase
                    "ImageRendering crispEdges"
                    [ ImageRendering.crispEdges]
                    [ "imageRendering" ==> "crisp-edges" ]
                testCase
                    "ImageRendering pixelated"
                    [ ImageRendering.pixelated ]
                    [ "imageRendering" ==> "pixelated" ]
                testCase
                    "ImageRendering inherit"
                    [ ImageRendering.inherit']
                    [ "imageRendering" ==> "inherit" ]
                testCase
                    "ImageRendering initial"
                    [ ImageRendering.initial]
                    [ "imageRendering" ==> "initial" ]
                testCase
                    "ImageRendering unset"
                    [ ImageRendering.unset ]
                    [ "imageRendering" ==> "unset" ]
            ]