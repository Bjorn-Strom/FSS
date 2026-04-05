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
                    Expect.equal actual (sprintf ".%s{@media (min-width:500px) and (max-width:700px) {&{&:hover{background-color:red;}}}}" className)

                test "Media query with min width and min height" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ] [ BackgroundColor.red ] ]
                    Expect.equal actual (sprintf ".%s{@media (min-width:500px) and (max-width:700px) {&{background-color:red;}}}" className)

                test "Media query with min height" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 700) ] [ BackgroundColor.pink; Color.greenYellow ] ]
                    Expect.equal actual (sprintf ".%s{@media (min-width:700px) {&{background-color:pink;color:greenyellow;}}}" className)

                test "Media query with min height 2" <| fun _ ->
                    let className, actual = createFss [ Media.query [ Media.MinWidth (px 700) ] [ BackgroundColor.pink; Color.greenYellow ] ]
                    Expect.equal actual (sprintf ".%s{@media (min-width:700px) {&{background-color:pink;color:greenyellow;}}}" className)

                test "Media query for print" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Print [] [ MarginTop.value (px 200)
                                                                                        Transform.value [
                                                                                          Transform.rotate (deg 45.0)
                                                                                        ]
                                                                                        BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual (sprintf ".%s{@media print {&{margin-top:200px;transform:rotate(45deg);background-color:indianred;}}}" className)

                test "Media query for screen with max width" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Screen [ Media.MaxWidth(px 500) ] [
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual (sprintf ".%s{@media screen and (max-width:500px) {&{background-color:indianred;}}}" className)

                test "Media query for screen with max width and min width" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor Media.Screen [ Media.MaxWidth(px 1000); Media.MinWidth (px 500) ] [
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual (sprintf ".%s{@media screen and (max-width:1000px) and (min-width:500px) {&{background-color:indianred;}}}" className)

                test "Media query for not all" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Not Media.All) [ Media.Color ] [
                                                                                            MarginTop.value (px 200)
                                                                                        ] ]
                    Expect.equal actual (sprintf ".%s{@media not all and (color) {&{margin-top:200px;}}}" className)

                test "Media query only screen, many features" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Only Media.Screen) [ Media.Color
                                                                                                   Media.Pointer Media.Fine
                                                                                                   Media.Scan Media.Interlace
                                                                                                   Media.Grid true ]
                                                                                        [ MarginTop.value (px 200)
                                                                                          Transform.value [ Transform.rotate (deg 45.0) ]
                                                                                          BackgroundColor.indianRed
                                                                                        ] ]
                    Expect.equal actual (sprintf ".%s{@media only screen and (color) and (pointer:fine) and (scan:interlace) and (grid:true) {&{margin-top:200px;transform:rotate(45deg);background-color:indianred;}}}" className)

                test "Media query only screen and a selector" <| fun _ ->
                    let className, actual = createFss [ Media.queryFor (Media.Only Media.Screen)
                                                                                        [  Media.MinWidth (px 601)
                                                                                           Media.MaxWidth (px 2) ]
                                                                                        [ Color.red
                                                                                          !> (Selector.li) [ Color.chartreuse; After [ Color.blue
                                                                                        ] ] ] ]
                    Expect.equal actual (sprintf ".%s{@media only screen and (min-width:601px) and (max-width:2px) {&{color:red;& > li{color:chartreuse;&::after{color:blue;}}}}}" className)



            ]
