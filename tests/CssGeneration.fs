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
                    "{ display: flex; }"

                testCase
                    "Several lines of CSS is correct"
                    [ Display.flex; BackgroundColor.blue; FlexDirection.column ]
                    "{ display: flex;background-color: blue;flex-direction: column; }"

                test "Single pseudo class is generated correctly" <| fun _ ->
                    let _, actual = (createFss [ Hover [ Color.orangeRed ] ])
                    Expect.equal actual [".css1444867815:hover", "{ color: orangered; }"]

                test "Nested pseudo classes are generated correctly" <| fun _ ->
                    let _, actual = (createFss [ Hover [ Hover [ Hover [ Hover [ Color.orangeRed ] ] ] ] ])
                    Expect.equal actual [".css1807594511:hover:hover:hover:hover", "{ color: orangered; }"]

                test "Normal line of CSS followed by pseudo generates two scopes" <| fun _ ->
                    let _, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ] ])
                    Expect.equal actual [
                        ".css637796496", "{ color: aqua; }"
                        ".css637796496:hover", "{ color: orangered; }"
                    ]

                test "Normal line of CSS followed by pseudo and another normal line generates three scopes" <| fun _ ->
                    let _, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ]; Display.grid ])
                    Expect.equal actual [
                        ".css-978704596", "{ color: aqua; }"
                        ".css-978704596:hover", "{ color: orangered; }"
                        ".css-978704596", "{ display: grid; }"
                    ]

                test "A nested element whose rules are split by a nested element generates 3 scopes" <| fun _ ->
                    let _, actual = (createFss [ Hover [ Color.white; Display.flex; Checked [ Color.blue ]; FontFamily.serif; FontSize.value (px 28); ]])
                    Expect.equal actual [
                        ".css-2092947002:hover", "{ color: white;display: flex; }"
                        ".css-2092947002:hover:checked", "{ color: blue; }"
                        ".css-2092947002:hover", "{ font-family: serif;font-size: 28px; }"
                    ]

                test "Compound selector, refine the parent selector" <| fun _ ->
                    let _, actual = (createFss [ Color.blue; Classname "bar" [ Color.red ] ])
                    Expect.equal actual [
                        ".css-1784298107", "{ color: blue; }"
                        ".css-1784298107.bar", "{ color: red; }"
                    ]

                test "Multiple levels of nesting" <| fun _ ->
                    let _, actual = (createFss [
                        Margin.value (px 0)
                        !> Fss.Types.Html.Figcaption [
                            BackgroundColor.hsl 0 0 0
                            !> Fss.Types.Html.P [
                                FontSize.value (rem 0.9)
                            ]
                        ]
                    ])
                    Expect.equal actual [
                        ".css-1864087659", "{ margin: 0px; }"
                        ".css-1864087659 > figcaption", "{ background-color: hsl(0, 0%, 0%); }"
                        ".css-1864087659 > figcaption > p", "{ font-size: 0.9rem; }"
                    ]
            ]
