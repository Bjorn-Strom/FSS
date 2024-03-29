namespace FSSTests

open Fss
open Fet
open Utils

module MediaTests =
    let tests =
       testList "Media"
            [
                test "Media query with pseudo" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ] [ Hover [ BackgroundColor.red ] ]  ]
                    Expect.equal actual $"@media (min-width:500px) and (max-width:700px) {{.{className}:hover{{background-color:red;}}}}"

                test "Media query with min width and min height" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ] [ BackgroundColor.red ] ]
                    Expect.equal actual $"@media (min-width:500px) and (max-width:700px) {{.{className}{{background-color:red;}}}}"

                test "Media query with min height" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 700) ] [ BackgroundColor.pink; Color.greenYellow ] ]
                    Expect.equal actual $"@media (min-width:700px) {{.{className}{{background-color:pink;color:greenyellow;}}}}"

                test "Media query with min height" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 700) ] [ BackgroundColor.pink; Color.greenYellow ] ]
                    Expect.equal actual $"@media (min-width:700px) {{.{className}{{background-color:pink;color:greenyellow;}}}}"

                test "Media query for print" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Print [] [ MarginTop.value (px 200)
                                                                                        Transform.value [
                                                                                          Transform.rotate (deg 45.0)
                                                                                        ]
                                                                                        BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual $"@media print {{.{className}{{margin-top:200px;transform:rotate(45deg);background-color:indianred;}}}}"

                test "Media query for screen with max width" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Screen [ Media.MaxWidth(px 500) ] [
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual $"@media screen and (max-width:500px) {{.{className}{{background-color:indianred;}}}}"

                test "Media query for screen with max width and min width" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Screen [ Media.MaxWidth(px 1000); Media.MinWidth (px 500) ] [
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual $"@media screen and (max-width:1000px) and (min-width:500px) {{.{className}{{background-color:indianred;}}}}"

                test "Media query for not all" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Not Media.All) [ Media.Color ] [
                                                                                            MarginTop.value (px 200)
                                                                                        ] ]
                    Expect.equal actual $"@media not all and (color) {{.{className}{{margin-top:200px;}}}}"

                test "Media query only screen, many features" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Only Media.Screen) [ Media.Color
                                                                                                   Media.Pointer Media.Fine
                                                                                                   Media.Scan Media.Interlace
                                                                                                   Media.Grid true ]
                                                                                        [ MarginTop.value (px 200)
                                                                                          Transform.value [ Transform.rotate (deg 45.0) ]
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual $"@media only screen and (color) and (pointer:fine) and (scan:interlace) and (grid:true) {{.{className}{{margin-top:200px;transform:rotate(45deg);background-color:indianred;}}}}"

                test "Media query only screen and a selector" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Only Media.Screen)
                                                                                        [  Media.MinWidth (px 601)
                                                                                           Media.MaxWidth (px 2) ]
                                                                                        [ Color.red
                                                                                          !> (Selector.Tag Fss.Types.Html.Li) [ Color.chartreuse; After [ Color.blue
                                                                                        ] ] ] ]
                    Expect.equal actual $"@media only screen and (min-width:601px) and (max-width:2px) {{.{className}{{color:red;}}.{className} > li{{color:chartreuse;}}.{className} > li::after{{color:blue;}}}}"



            ]
