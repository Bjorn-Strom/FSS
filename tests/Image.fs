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
            ]