namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Margin =
    let tests =
        testList "Margin"
            [
                testCase
                    "Margin top px"
                    [ MarginTop' (px 10)]
                    ["marginTop" ==> "10px"]
                testCase
                    "Margin right px"
                    [ MarginRight' (px 10)]
                    ["marginRight" ==> "10px"]
                testCase
                    "Margin bottom px"
                    [ MarginBottom' (px 10)]
                    ["marginBottom" ==> "10px"]
                testCase
                    "Margin left px"
                    [ MarginLeft' (px 10)]
                    ["marginLeft" ==> "10px"]
                testCase
                    "Margin px"
                    [ Margin' (px 10)]
                    [ "margin" ==> "10px" ]
                testCase
                    "Margin pct"
                    [ Margin' (pct 10)]
                    [ "margin" ==> "10%" ]
                testCase
                    "Margin em"
                    [ Margin' (em 10.0)]
                    [ "margin" ==> "10.0em" ]
                testCase
                    "Margin auto"
                    [ Margin.auto]
                    [ "margin" ==> "auto" ]
                testCase
                    "Margin inherit"
                    [ Margin.inherit']
                    [ "margin" ==> "inherit" ]
                testCase
                    "Margin initial"
                    [ Margin.initial]
                    [ "margin" ==> "initial" ]
                testCase
                    "Margin unset"
                    [ Margin.unset ]
                    [ "margin" ==> "unset" ]
                testCase
                    "Margins multiple"
                    [ Margin.value (px 10, px 20, px 30, px 40) ]
                    [ "margin" ==> "10px 20px 30px 40px" ]
                testCase
                    "Margin inline start 5%"
                    [ MarginInlineStart' <| pct 5]
                    [ "marginInlineStart" ==> "5%" ]
                testCase
                    "Margin inline start 1em"
                    [ MarginInlineStart' <| em 1.]
                    [ "marginInlineStart" ==> "1.0em" ]
                testCase
                    "Margin inline start 10px"
                    [ MarginInlineStart' <| px 10]
                    [ "marginInlineStart" ==> "10px" ]
                testCase
                    "Margin inline start initial"
                    [ MarginInlineStart.initial]
                    [ "marginInlineStart" ==> "initial" ]
                testCase
                    "Margin inline start unset"
                    [ MarginInlineStart.unset ]
                    [ "marginInlineStart" ==> "unset" ]
                testCase
                    "Margin inline start inherit"
                    [ MarginInlineStart.inherit']
                    [ "marginInlineStart" ==> "inherit" ]
                testCase
                    "Margin inline start initial"
                    [ MarginInlineStart.initial]
                    [ "marginInlineStart" ==> "initial" ]
                testCase
                    "Margin inline start unset"
                    [ MarginInlineStart.unset ]
                    [ "marginInlineStart" ==> "unset" ]
                testCase
                    "Margin inline end 5%"
                    [ MarginInlineEnd' <| pct 5]
                    [ "marginInlineEnd" ==> "5%" ]
                testCase
                    "Margin inline end 1em"
                    [ MarginInlineEnd' <| em 1.]
                    [ "marginInlineEnd" ==> "1.0em" ]
                testCase
                    "Margin inline end 10px"
                    [ MarginInlineEnd' <| px 10]
                    [ "marginInlineEnd" ==> "10px" ]
                testCase
                    "Margin inline end initial"
                    [ MarginInlineEnd.initial]
                    [ "marginInlineEnd" ==> "initial" ]
                testCase
                    "Margin inline end unset"
                    [ MarginInlineEnd.unset ]
                    [ "marginInlineEnd" ==> "unset" ]
                testCase
                    "Margin inline end inherit"
                    [ MarginInlineEnd.inherit']
                    [ "marginInlineEnd" ==> "inherit" ]
                testCase
                    "Margin inline end initial"
                    [ MarginInlineEnd.initial]
                    [ "marginInlineEnd" ==> "initial" ]
                testCase
                    "Margin inline end unset"
                    [ MarginInlineEnd.unset ]
                    [ "marginInlineEnd" ==> "unset" ]
                testCase
                    "Margin block start 5%"
                    [ MarginBlockStart' <| pct 5]
                    [ "marginBlockStart" ==> "5%" ]
                testCase
                    "Margin block start 1em"
                    [ MarginBlockStart' <| em 1.]
                    [ "marginBlockStart" ==> "1.0em" ]
                testCase
                    "Margin block start 10px"
                    [ MarginBlockStart' <| px 10]
                    [ "marginBlockStart" ==> "10px" ]
                testCase
                    "Margin block start initial"
                    [ MarginBlockStart.initial]
                    [ "marginBlockStart" ==> "initial" ]
                testCase
                    "Margin block start unset"
                    [ MarginBlockStart.unset ]
                    [ "marginBlockStart" ==> "unset" ]
                testCase
                    "Margin block start inherit"
                    [ MarginBlockStart.inherit']
                    [ "marginBlockStart" ==> "inherit" ]
                testCase
                    "Margin block start initial"
                    [ MarginBlockStart.initial]
                    [ "marginBlockStart" ==> "initial" ]
                testCase
                    "Margin block start unset"
                    [ MarginBlockStart.unset ]
                    [ "marginBlockStart" ==> "unset" ]
                testCase
                    "Margin block end 5%"
                    [ MarginBlockEnd' <| pct 5]
                    [ "marginBlockEnd" ==> "5%" ]
                testCase
                    "Margin block end 1em"
                    [ MarginBlockEnd' <| em 1.]
                    [ "marginBlockEnd" ==> "1.0em" ]
                testCase
                    "Margin block end 10px"
                    [ MarginBlockEnd' <| px 10]
                    [ "marginBlockEnd" ==> "10px" ]
                testCase
                    "Margin block end initial"
                    [ MarginBlockEnd.initial]
                    [ "marginBlockEnd" ==> "initial" ]
                testCase
                    "Margin block end unset"
                    [ MarginBlockEnd.unset ]
                    [ "marginBlockEnd" ==> "unset" ]
                testCase
                    "Margin block end inherit"
                    [ MarginBlockEnd.inherit']
                    [ "marginBlockEnd" ==> "inherit" ]
                testCase
                    "Margin block end initial"
                    [ MarginBlockEnd.initial]
                    [ "marginBlockEnd" ==> "initial" ]
                testCase
                    "Margin block end unset"
                    [ MarginBlockEnd.unset ]
                    [ "marginBlockEnd" ==> "unset" ]
            ]