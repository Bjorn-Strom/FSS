namespace FSSTests

open Fss
open Fet
open Utils

module MediaTests =
    let createMediaTest (featureList: Fss.Types.Media.Feature list) (ruleList: Fss.Types.Rule list) =
        let className, styles = createFss [
            Media.query
                featureList
                ruleList
        ]
        let media, styles = (styles |> List.rev |> List.head)
        className, $"{media}{styles}"

    let createMediaForTest (device: Fss.Types.Media.Device) (featureList: Fss.Types.Media.Feature list) (ruleList: Fss.Types.Rule list) =
        let className, styles = createFss [
            Media.queryFor
                device
                featureList
                ruleList
        ]
        let media, styles = (styles |> List.rev |> List.head)
        className, $"{media}{styles}"

    let tests =
       testList "Media"
            [
                let className, actual = createMediaTest
                                            [ Fss.Types.Media.MinWidth (px 500); Fss.Types.Media.MaxWidth (px 700) ]
                                            [ Hover [ BackgroundColor.red ] ]
                testEqual
                    "Media query with pseudo"
                    actual
                    (sprintf "@media (min-width: 500px) and (max-width: 700px){ .%s:hover { background-color: red; } }" className)
//                let className, actual = createMediaTest
//                                            [ Fss.Types.Media.MinWidth (px 500); Fss.Types.Media.MaxWidth (px 700) ]
//                                            [ BackgroundColor.red ]
//                testEqual
//                    "Media query with min width and min height"
//                    actual
//                    (sprintf "@media (min-width: 500px) and (max-width: 700px){ .%s { background-color: red; } }" className)
//                let className, actual = createMediaTest
//                                            [ Fss.Types.Media.MinHeight (px 700) ]
//                                            [ BackgroundColor.pink ]
//                testEqual
//                    "Media query min height only"
//                    actual
//                    (sprintf "@media (min-height: 700px){ .%s { background-color: pink; } }" className)
//                let className, actual = createMediaForTest
//                                            Fss.Types.Media.Print
//                                            []
//                                            [
//                                                MarginTop.value (px 200)
//                                                Transform.value
//                                                    [
//                                                        Transform.rotate (deg 45.0)
//                                                    ]
//                                                BackgroundColor.indianRed
//                                            ]
//                testEqual
//                    "Media query for print"
//                    actual
//                    (sprintf "@media print { .%s { margin-top: 200px;transform: rotate(45deg);background-color: indianred; } }" className)
//
//
//                let className, actual = createMediaForTest
//                                                Fss.Types.Media.Screen
//                                                [ Fss.Types.Media.MaxWidth <| px 1000 ]
//                                                [ BackgroundColor.indianRed ]
//                testEqual
//                    "Media query for screen with max width"
//                    actual
//                    (sprintf "@media screen and (max-width: 1000px){ .%s { background-color: indianred; } }" className)
//                let className, actual = createMediaForTest
//                                            Fss.Types.Media.Screen
//                                            [ Fss.Types.Media.MaxWidth <| px 1000; Fss.Types.Media.MinWidth <| px 500 ]
//                                            [ BackgroundColor.indianRed ]
//
//                testEqual
//                    "Media query for screen with max width and min width"
//                    actual
//                    (sprintf "@media screen and (max-width: 1000px) and (min-width: 500px){ .%s { background-color: indianred; } }" className)
//                let className, actual = createMediaForTest
//                                            (Fss.Types.Media.Not Fss.Types.Media.Device.All)
//                                            [ Fss.Types.Media.Feature.Color ]
//                                            [ MarginTop.value (px 200) ]
//                testEqual
//                    "Media query for not all"
//                    actual
//                    (sprintf "@media not all and (color){ .%s { margin-top: 200px; } }" className)
//                let className, actual = createMediaForTest
//                                            (Fss.Types.Media.Only Fss.Types.Media.Device.Screen)
//                                            [ Fss.Types.Media.Feature.Color
//                                              Fss.Types.Media.Feature.Pointer Fss.Types.Media.Fine
//                                              Fss.Types.Media.Feature.Scan Fss.Types.Media.Interlace
//                                              Fss.Types.Media.Feature.Grid true
//                                            ]
//                                            [ MarginTop.value (px 200)
//                                              Transform.value [ Transform.rotate (deg 45.0) ]
//                                              BackgroundColor.indianRed
//                                            ]
//                testEqual
//                    "Media query only screen, many features"
//                    actual
//                    (sprintf "@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: true){ .%s { margin-top: 200px;transform: rotate(45deg);background-color: indianred; } }" className)
//                let className, actual = createMediaForTest
//                                            (Fss.Types.Media.Device.Only Fss.Types.Media.Device.Screen)
//                                            [ Fss.Types.Media.MinWidth (px 601); Fss.Types.Media.MaxWidth (px 2) ]
//                                            [ Color.red
//                                              !> Fss.Types.Html.Li [ Color.chartreuse; After [ Color.blue ] ] ]
//                testEqual
//                    "Media query only screen and a selector"
//                    actual
//                    $"@media only screen and (min-width: 601px) and (max-width: 2px){{ .%s{className} {{ color: red; }}.%s{className} > li {{ color: chartreuse; }}.%s{className} > li::after {{ color: blue; }} }}"
            ]
