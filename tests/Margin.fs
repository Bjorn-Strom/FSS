namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Margin =
    let tests =
        testList "Margin"
            [
                test
                    "Margin top px"
                    [ MarginTop' (px 10)]
                    ["marginTop" ==> "10px"]
                test
                    "Margin right px"
                    [ MarginRight' (px 10)]
                    ["marginRight" ==> "10px"]
                test
                    "Margin bottom px"
                    [ MarginBottom' (px 10)]
                    ["marginBottom" ==> "10px"]
                test
                    "Margin left px"
                    [ MarginLeft' (px 10)]
                    ["marginLeft" ==> "10px"]
                test
                    "Margin px"
                    [ Margin' (px 10)]
                    [ "margin" ==> "10px" ]
                test
                    "Margin pct"
                    [ Margin' (pct 10)]
                    [ "margin" ==> "10%" ]
                test
                    "Margin em"
                    [ Margin' (em 10.0)]
                    [ "margin" ==> "10.0em" ]
                test
                    "Margin auto"
                    [ Margin.Auto]
                    [ "margin" ==> "auto" ]
                test
                    "Margin inherit"
                    [ Margin.Inherit]
                    [ "margin" ==> "inherit" ]
                test
                    "Margin initial"
                    [ Margin.Initial]
                    [ "margin" ==> "initial" ]
                test
                    "Margin unset"
                    [ Margin.Unset ]
                    [ "margin" ==> "unset" ]
                test
                    "Margins multiple"
                    [ Margin.Value (px 10, px 20, px 30, px 40) ]
                    [ "margin" ==> "10px 20px 30px 40px" ]
                test
                    "Margin inline start 5%"
                    [ MarginInlineStart' <| pct 5]
                    [ "marginInlineStart" ==> "5%" ]
                test
                    "Margin inline start 1em"
                    [ MarginInlineStart' <| em 1.]
                    [ "marginInlineStart" ==> "1.0em" ]
                test
                    "Margin inline start 10px"
                    [ MarginInlineStart' <| px 10]
                    [ "marginInlineStart" ==> "10px" ]
                test
                    "Margin inline start initial"
                    [ MarginInlineStart.Initial]
                    [ "marginInlineStart" ==> "initial" ]
                test
                    "Margin inline start unset"
                    [ MarginInlineStart.Unset ]
                    [ "marginInlineStart" ==> "unset" ]
                test
                    "Margin inline start inherit"
                    [ MarginInlineStart.Inherit]
                    [ "marginInlineStart" ==> "inherit" ]
                test
                    "Margin inline start initial"
                    [ MarginInlineStart.Initial]
                    [ "marginInlineStart" ==> "initial" ]
                test
                    "Margin inline start unset"
                    [ MarginInlineStart.Unset ]
                    [ "marginInlineStart" ==> "unset" ]
                test
                    "Margin inline end 5%"
                    [ MarginInlineEnd' <| pct 5]
                    [ "marginInlineEnd" ==> "5%" ]
                test
                    "Margin inline end 1em"
                    [ MarginInlineEnd' <| em 1.]
                    [ "marginInlineEnd" ==> "1.0em" ]
                test
                    "Margin inline end 10px"
                    [ MarginInlineEnd' <| px 10]
                    [ "marginInlineEnd" ==> "10px" ]
                test
                    "Margin inline end initial"
                    [ MarginInlineEnd.Initial]
                    [ "marginInlineEnd" ==> "initial" ]
                test
                    "Margin inline end unset"
                    [ MarginInlineEnd.Unset ]
                    [ "marginInlineEnd" ==> "unset" ]
                test
                    "Margin inline end inherit"
                    [ MarginInlineEnd.Inherit]
                    [ "marginInlineEnd" ==> "inherit" ]
                test
                    "Margin inline end initial"
                    [ MarginInlineEnd.Initial]
                    [ "marginInlineEnd" ==> "initial" ]
                test
                    "Margin inline end unset"
                    [ MarginInlineEnd.Unset ]
                    [ "marginInlineEnd" ==> "unset" ]
                test
                    "Margin block start 5%"
                    [ MarginBlockStart' <| pct 5]
                    [ "marginBlockStart" ==> "5%" ]
                test
                    "Margin block start 1em"
                    [ MarginBlockStart' <| em 1.]
                    [ "marginBlockStart" ==> "1.0em" ]
                test
                    "Margin block start 10px"
                    [ MarginBlockStart' <| px 10]
                    [ "marginBlockStart" ==> "10px" ]
                test
                    "Margin block start initial"
                    [ MarginBlockStart.Initial]
                    [ "marginBlockStart" ==> "initial" ]
                test
                    "Margin block start unset"
                    [ MarginBlockStart.Unset ]
                    [ "marginBlockStart" ==> "unset" ]
                test
                    "Margin block start inherit"
                    [ MarginBlockStart.Inherit]
                    [ "marginBlockStart" ==> "inherit" ]
                test
                    "Margin block start initial"
                    [ MarginBlockStart.Initial]
                    [ "marginBlockStart" ==> "initial" ]
                test
                    "Margin block start unset"
                    [ MarginBlockStart.Unset ]
                    [ "marginBlockStart" ==> "unset" ]
                test
                    "Margin block end 5%"
                    [ MarginBlockEnd' <| pct 5]
                    [ "marginBlockEnd" ==> "5%" ]
                test
                    "Margin block end 1em"
                    [ MarginBlockEnd' <| em 1.]
                    [ "marginBlockEnd" ==> "1.0em" ]
                test
                    "Margin block end 10px"
                    [ MarginBlockEnd' <| px 10]
                    [ "marginBlockEnd" ==> "10px" ]
                test
                    "Margin block end initial"
                    [ MarginBlockEnd.Initial]
                    [ "marginBlockEnd" ==> "initial" ]
                test
                    "Margin block end unset"
                    [ MarginBlockEnd.Unset ]
                    [ "marginBlockEnd" ==> "unset" ]
                test
                    "Margin block end inherit"
                    [ MarginBlockEnd.Inherit]
                    [ "marginBlockEnd" ==> "inherit" ]
                test
                    "Margin block end initial"
                    [ MarginBlockEnd.Initial]
                    [ "marginBlockEnd" ==> "initial" ]
                test
                    "Margin block end unset"
                    [ MarginBlockEnd.Unset ]
                    [ "marginBlockEnd" ==> "unset" ]
            ]