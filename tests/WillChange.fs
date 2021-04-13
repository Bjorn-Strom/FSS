namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module WillChange =
     let tests =
        testList "WillChange"
            [
                testCase
                    "Will change ident"
                    [ WillChange.ident "opacity" ]
                    [ "willChange" ==> "opacity" ]
                testCase
                    "Will change idents"
                    [ WillChange.idents ["left"; "top"] ]
                    [ "willChange" ==> "left,top" ]
                testCase
                    "Will change contents"
                    [ WillChange.contents ]
                    [ "willChange" ==> "contents" ]
                testCase
                    "Will change scroll position"
                    [ WillChange.scrollPosition ]
                    [ "willChange" ==> "scroll-position" ]
                testCase
                    "Will change auto"
                    [ WillChange.auto ]
                    [ "willChange" ==> "auto" ]
            ]