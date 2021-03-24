namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Padding =
     let tests =
        testList "Padding"
            [
                test
                    "Padding top px"
                    [ PaddingTop' (px 10)]
                    ["paddingTop" ==> "10px"]
                test
                    "Padding right px"
                    [ PaddingRight' (px 10)]
                    ["paddingRight" ==> "10px"]
                test
                    "Padding bottom px"
                    [ PaddingBottom' (px 10)]
                    ["paddingBottom" ==> "10px"]
                test
                    "Padding left px"
                    [ PaddingLeft' (px 10)]
                    ["paddingLeft" ==> "10px"]
                test
                    "Padding px"
                    [ Padding' (px 10)]
                    [ "padding" ==> "10px" ]
                test
                    "Padding pct"
                    [ Padding' (pct 10)]
                    [ "padding" ==> "10%" ]
                test
                    "Padding em"
                    [ Padding' (em 10.0)]
                    [ "padding" ==> "10.0em" ]
                test
                    "Padding auto"
                    [ Padding.auto]
                    [ "padding" ==> "auto" ]
                test
                    "Padding inherit"
                    [ Padding.inherit']
                    [ "padding" ==> "inherit" ]
                test
                    "Padding initial"
                    [ Padding.initial]
                    [ "padding" ==> "initial" ]
                test
                    "Padding unset"
                    [ Padding.unset ]
                    [ "padding" ==> "unset" ]
                test
                    "Paddings multiple"
                    [ Padding.value (px 10, px 20, px 30, px 40) ]
                    [ "padding" ==> "10px 20px 30px 40px" ]
                test
                    "Padding inline start 5%"
                    [ PaddingInlineStart' <| pct 5]
                    [ "paddingInlineStart" ==> "5%" ]
                test
                    "Padding inline start 1em"
                    [ PaddingInlineStart' <| em 1.]
                    [ "paddingInlineStart" ==> "1.0em" ]
                test
                    "Padding inline start 10px"
                    [ PaddingInlineStart' <| px 10]
                    [ "paddingInlineStart" ==> "10px" ]
                test
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    [ "paddingInlineStart" ==> "initial" ]
                test
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    [ "paddingInlineStart" ==> "unset" ]
                test
                    "Padding inline start inherit"
                    [ PaddingInlineStart.inherit']
                    [ "paddingInlineStart" ==> "inherit" ]
                test
                    "Padding inline start initial"
                    [ PaddingInlineStart.initial]
                    [ "paddingInlineStart" ==> "initial" ]
                test
                    "Padding inline start unset"
                    [ PaddingInlineStart.unset ]
                    [ "paddingInlineStart" ==> "unset" ]
                test
                    "Padding inline end 5%"
                    [ PaddingInlineEnd' <| pct 5]
                    [ "paddingInlineEnd" ==> "5%" ]
                test
                    "Padding inline end 1em"
                    [ PaddingInlineEnd' <| em 1.]
                    [ "paddingInlineEnd" ==> "1.0em" ]
                test
                    "Padding inline end 10px"
                    [ PaddingInlineEnd' <| px 10]
                    [ "paddingInlineEnd" ==> "10px" ]
                test
                    "Padding inline end initial"
                    [ PaddingInlineEnd.initial]
                    [ "paddingInlineEnd" ==> "initial" ]
                test
                    "Padding inline end unset"
                    [ PaddingInlineEnd.unset ]
                    [ "paddingInlineEnd" ==> "unset" ]
                test
                    "Padding inline end inherit"
                    [ PaddingInlineEnd.inherit']
                    [ "paddingInlineEnd" ==> "inherit" ]
                test
                    "Padding inline end initial"
                    [ PaddingInlineEnd.initial]
                    [ "paddingInlineEnd" ==> "initial" ]
                test
                    "Padding inline end unset"
                    [ PaddingInlineEnd.unset ]
                    [ "paddingInlineEnd" ==> "unset" ]
                test
                    "Padding block start 5%"
                    [ PaddingBlockStart' <| pct 5]
                    [ "paddingBlockStart" ==> "5%" ]
                test
                    "Padding block start 1em"
                    [ PaddingBlockStart' <| em 1.]
                    [ "paddingBlockStart" ==> "1.0em" ]
                test
                    "Padding block start 10px"
                    [ PaddingBlockStart' <| px 10]
                    [ "paddingBlockStart" ==> "10px" ]
                test
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    [ "paddingBlockStart" ==> "initial" ]
                test
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    [ "paddingBlockStart" ==> "unset" ]
                test
                    "Padding block start inherit"
                    [ PaddingBlockStart.inherit']
                    [ "paddingBlockStart" ==> "inherit" ]
                test
                    "Padding block start initial"
                    [ PaddingBlockStart.initial]
                    [ "paddingBlockStart" ==> "initial" ]
                test
                    "Padding block start unset"
                    [ PaddingBlockStart.unset ]
                    [ "paddingBlockStart" ==> "unset" ]
                test
                    "Padding block end 5%"
                    [ PaddingBlockEnd' <| pct 5]
                    [ "paddingBlockEnd" ==> "5%" ]
                test
                    "Padding block end 1em"
                    [ PaddingBlockEnd' <| em 1.]
                    [ "paddingBlockEnd" ==> "1.0em" ]
                test
                    "Padding block end 10px"
                    [ PaddingBlockEnd' <| px 10]
                    [ "paddingBlockEnd" ==> "10px" ]
                test
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    [ "paddingBlockEnd" ==> "initial" ]
                test
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    [ "paddingBlockEnd" ==> "unset" ]
                test
                    "Padding block end inherit"
                    [ PaddingBlockEnd.inherit']
                    [ "paddingBlockEnd" ==> "inherit" ]
                test
                    "Padding block end initial"
                    [ PaddingBlockEnd.initial]
                    [ "paddingBlockEnd" ==> "initial" ]
                test
                    "Padding block end unset"
                    [ PaddingBlockEnd.unset ]
                    [ "paddingBlockEnd" ==> "unset" ]
            ]