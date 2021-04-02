namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Padding =
     let tests =
        testList "Padding"
            [
                testCase
                    "Padding top px"
                    [ PaddingTop' (px 10)]
                    ["paddingTop" ==> "10px"]
                testCase
                    "Padding right px"
                    [ PaddingRight' (px 10)]
                    ["paddingRight" ==> "10px"]
                testCase
                    "Padding bottom px"
                    [ PaddingBottom' (px 10)]
                    ["paddingBottom" ==> "10px"]
                testCase
                    "Padding left px"
                    [ PaddingLeft' (px 10)]
                    ["paddingLeft" ==> "10px"]
                testCase
                    "Padding px"
                    [ Padding' (px 10)]
                    [ "padding" ==> "10px" ]
                testCase
                    "Padding pct"
                    [ Padding' (pct 10)]
                    [ "padding" ==> "10%" ]
                testCase
                    "Padding em"
                    [ Padding' (em 10.0)]
                    [ "padding" ==> "10.0em" ]
                testCase
                    "Padding auto"
                    [ Padding.auto]
                    [ "padding" ==> "auto" ]
                testCase
                    "Padding inherit"
                    [ Padding.inherit']
                    [ "padding" ==> "inherit" ]
                testCase
                    "Padding initial"
                    [ Padding.initial]
                    [ "padding" ==> "initial" ]
                testCase
                    "Padding unset"
                    [ Padding.unset ]
                    [ "padding" ==> "unset" ]
                testCase
                    "Paddings multiple"
                    [ Padding.value (px 10, px 20, px 30, px 40) ]
                    [ "padding" ==> "10px 20px 30px 40px" ]
                testCase
                    "Padding inline start 5%"
                    [ PaddingInlineStart' <| pct 5]
                    [ "paddingInlineStart" ==> "5%" ]
                testCase
                    "Padding inline start 1em"
                    [ PaddingInlineStart' <| em 1.]
                    [ "paddingInlineStart" ==> "1.0em" ]
                testCase
                    "Padding inline start 10px"
                    [ PaddingInlineStart' <| px 10]
                    [ "paddingInlineStart" ==> "10px" ]
                testCase
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    [ "paddingInlineStart" ==> "initial" ]
                testCase
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    [ "paddingInlineStart" ==> "unset" ]
                testCase
                    "Padding inline start inherit"
                    [ PaddingInlineStart.inherit']
                    [ "paddingInlineStart" ==> "inherit" ]
                testCase
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    [ "paddingInlineStart" ==> "initial" ]
                testCase
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    [ "paddingInlineStart" ==> "unset" ]
                testCase
                    "Padding inline end 5%"
                    [ PaddingInlineEnd' <| pct 5]
                    [ "paddingInlineEnd" ==> "5%" ]
                testCase
                    "Padding inline end 1em"
                    [ PaddingInlineEnd' <| em 1.]
                    [ "paddingInlineEnd" ==> "1.0em" ]
                testCase
                    "Padding inline end 10px"
                    [ PaddingInlineEnd' <| px 10]
                    [ "paddingInlineEnd" ==> "10px" ]
                testCase
                    "Padding inline end initial"
                    [ PaddingInlineEnd.initial]
                    [ "paddingInlineEnd" ==> "initial" ]
                testCase
                    "Padding inline end unset"
                    [ PaddingInlineEnd.unset ]
                    [ "paddingInlineEnd" ==> "unset" ]
                testCase
                    "Padding inline end inherit"
                    [ PaddingInlineEnd.inherit']
                    [ "paddingInlineEnd" ==> "inherit" ]
                testCase
                    "Padding inline end initial"
                    [ PaddingInlineEnd.initial]
                    [ "paddingInlineEnd" ==> "initial" ]
                testCase
                    "Padding inline end unset"
                    [ PaddingInlineEnd.unset ]
                    [ "paddingInlineEnd" ==> "unset" ]
                testCase
                    "Padding block start 5%"
                    [ PaddingBlockStart' <| pct 5]
                    [ "paddingBlockStart" ==> "5%" ]
                testCase
                    "Padding block start 1em"
                    [ PaddingBlockStart' <| em 1.]
                    [ "paddingBlockStart" ==> "1.0em" ]
                testCase
                    "Padding block start 10px"
                    [ PaddingBlockStart' <| px 10]
                    [ "paddingBlockStart" ==> "10px" ]
                testCase
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    [ "paddingBlockStart" ==> "initial" ]
                testCase
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    [ "paddingBlockStart" ==> "unset" ]
                testCase
                    "Padding block start inherit"
                    [ PaddingBlockStart.inherit']
                    [ "paddingBlockStart" ==> "inherit" ]
                testCase
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    [ "paddingBlockStart" ==> "initial" ]
                testCase
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    [ "paddingBlockStart" ==> "unset" ]
                testCase
                    "Padding block end 5%"
                    [ PaddingBlockEnd' <| pct 5]
                    [ "paddingBlockEnd" ==> "5%" ]
                testCase
                    "Padding block end 1em"
                    [ PaddingBlockEnd' <| em 1.]
                    [ "paddingBlockEnd" ==> "1.0em" ]
                testCase
                    "Padding block end 10px"
                    [ PaddingBlockEnd' <| px 10]
                    [ "paddingBlockEnd" ==> "10px" ]
                testCase
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    [ "paddingBlockEnd" ==> "initial" ]
                testCase
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    [ "paddingBlockEnd" ==> "unset" ]
                testCase
                    "Padding block end inherit"
                    [ PaddingBlockEnd.inherit']
                    [ "paddingBlockEnd" ==> "inherit" ]
                testCase
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    [ "paddingBlockEnd" ==> "initial" ]
                testCase
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    [ "paddingBlockEnd" ==> "unset" ]
            ]