namespace FSSTests

open Fet
open Utils
open Fss

module CssGenerationTests =
    let tests =
        testList "CssGeneration"
            [
                testCase
                    "One line of CSS is correct"
                    [ Display.flex ]
                    "{display:flex;}"

                testCase
                    "Several lines of CSS is correct"
                    [ Display.flex; BackgroundColor.blue; FlexDirection.column ]
                    "{display:flex;background-color:blue;flex-direction:column;}"

                test "Single pseudo class is generated correctly" <| fun _ ->
                    let className, actual = (createFss [ Hover [ Color.orangeRed ] ])
                    Expect.equal actual $".{className}:hover{{color:orangered;}}"

                test "Nested pseudo classes are generated correctly" <| fun _ ->
                    let className, actual = (createFss [ Hover [ Hover [ Hover [ Hover [ Color.orangeRed ] ] ] ] ])
                    Expect.equal actual $".{className}:hover:hover:hover:hover{{color:orangered;}}"

                test "Normal line of CSS followed by pseudo generates two scopes" <| fun _ ->
                    let className, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ] ])
                    Expect.equal actual
                        $".{className}{{color:aqua;}}.{className}:hover{{color:orangered;}}"

                test "Normal line of CSS followed by pseudo and another normal line generates three scopes" <| fun _ ->
                    let className, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ]; Display.grid ])
                    Expect.equal actual
                        $".{className}{{color:aqua;}}.{className}:hover{{color:orangered;}}.{className}{{display:grid;}}"

                test "A nested element whose rules are split by a nested element generates 3 scopes" <| fun _ ->
                    let className, actual = (createFss [ Hover [ Color.white; Display.flex; Checked [ Color.blue ]; FontFamily.serif; FontSize.value (px 28); ]])
                    Expect.equal actual
                        $".{className}:hover{{color:white;display:flex;}}.{className}:hover:checked{{color:blue;}}.{className}:hover{{font-family:serif;font-size:28px;}}"

                test "Compound selector, refine the parent selector" <| fun _ ->
                    let className, actual = (createFss [ Color.blue; Classname "bar" [ Color.red ] ])
                    Expect.equal actual
                        $".{className}{{color:blue;}}.{className}.bar{{color:red;}}"

                test "Multiple levels of nesting" <| fun _ ->
                    let className, actual = (createFss [
                        Margin.value (px 0)
                        !> Fss.Types.Html.Figcaption [
                            BackgroundColor.hsl 0 0 0
                            !> Fss.Types.Html.P [
                                FontSize.value (rem 0.9)
                            ]
                        ]
                    ])
                    Expect.equal actual
                        $".{className}{{margin:0px;}}.{className} > figcaption{{background-color:hsl(0,0%%,0%%);}}.{className} > figcaption > p{{font-size:0.9rem;}}"
            ]
