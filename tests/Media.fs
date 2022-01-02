namespace FSSTests

open Fss
open Fet
open Utils

module Media =
    let createMediaTest (featureList: FssTypes.Media.Feature list) (ruleList: FssTypes.Rule list) =
        let className, styles = createFss [
            Media.query
                featureList
                ruleList
        ]
        let media, styles = (styles |> List.rev |> List.head)
        className, $"{media}{styles}"
        
    let createMediaForTest (device: FssTypes.Media.Device) (featureList: FssTypes.Media.Feature list) (ruleList: FssTypes.Rule list) =
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
                                            [ FssTypes.Media.MinWidth (px 500); FssTypes.Media.MaxWidth (px 700) ]
                                            [ Hover [ BackgroundColor.red ] ]
                testEqual
                    "Media query with pseudo"
                    actual
                    (sprintf "@media (min-width: 500px) and (max-width: 700px){ .%s:hover { background-color: red; } }" className)
                let className, actual = createMediaTest
                                            [ FssTypes.Media.MinWidth (px 500); FssTypes.Media.MaxWidth (px 700) ]
                                            [ BackgroundColor.red ]
                testEqual
                    "Media query with min width and min height"
                    actual
                    (sprintf "@media (min-width: 500px) and (max-width: 700px){ .%s { background-color: red; } }" className)
                let className, actual = createMediaTest
                                            [ FssTypes.Media.MinHeight (px 700) ]
                                            [ BackgroundColor.pink ]
                testEqual
                    "Media query min height only"
                    actual
                    (sprintf "@media (min-height: 700px){ .%s { background-color: pink; } }" className)
                let className, actual = createMediaForTest
                                            FssTypes.Media.Print
                                            []
                                            [
                                                MarginTop.value (px 200)
                                                Transform.value
                                                    [
                                                        Transform.rotate (deg 45.0)
                                                    ]
                                                BackgroundColor.indianRed
                                            ]
                testEqual
                    "Media query for print"
                    actual
                    (sprintf "@media print { .%s { margin-top: 200px;transform: rotate(45deg);background-color: indianred; } }" className)
                    
                    
                let className, actual = createMediaForTest
                                                FssTypes.Media.Screen
                                                [ FssTypes.Media.MaxWidth <| px 1000 ]
                                                [ BackgroundColor.indianRed ]
                testEqual
                    "Media query for screen with max width"
                    actual
                    (sprintf "@media screen and (max-width: 1000px){ .%s { background-color: indianred; } }" className)
                let className, actual = createMediaForTest
                                            FssTypes.Media.Screen
                                            [ FssTypes.Media.MaxWidth <| px 1000; FssTypes.Media.MinWidth <| px 500 ]
                                            [ BackgroundColor.indianRed ]
                        
                testEqual
                    "Media query for screen with max width and min width"
                    actual
                    (sprintf "@media screen and (max-width: 1000px) and (min-width: 500px){ .%s { background-color: indianred; } }" className)
                let className, actual = createMediaForTest
                                            (FssTypes.Media.Not FssTypes.Media.Device.All)
                                            [ FssTypes.Media.Feature.Color ]
                                            [ MarginTop.value (px 200) ]
                testEqual
                    "Media query for not all"
                    actual
                    (sprintf "@media not all and (color){ .%s { margin-top: 200px; } }" className)
                let className, actual = createMediaForTest
                                            (FssTypes.Media.Only FssTypes.Media.Device.Screen)
                                            [ FssTypes.Media.Feature.Color
                                              FssTypes.Media.Feature.Pointer FssTypes.Media.Fine
                                              FssTypes.Media.Feature.Scan FssTypes.Media.Interlace
                                              FssTypes.Media.Feature.Grid true
                                            ]
                                            [ MarginTop.value (px 200)
                                              Transform.value [ Transform.rotate (deg 45.0) ]
                                              BackgroundColor.indianRed
                                            ]
                testEqual
                    "Media query only screen, many features"
                    actual
                    (sprintf "@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: true){ .%s { margin-top: 200px;transform: rotate(45deg);background-color: indianred; } }" className)
                let className, actual = createMediaForTest
                                            (FssTypes.Media.Device.Only FssTypes.Media.Device.Screen)
                                            [ FssTypes.Media.MinWidth (px 601); FssTypes.Media.MaxWidth (px 2) ]
                                            [ Color.red
                                              !> FssTypes.Html.Li [ Color.chartreuse; After [ Color.blue ] ] ]
                testEqual
                    "Media query only screen and a selector"
                    actual
                    $"@media only screen and (min-width: 601px) and (max-width: 2px){{ .%s{className} {{ color: red; }}.%s{className} > li {{ color: chartreuse; }}.%s{className} > li::after {{ color: blue; }} }}"
            ]