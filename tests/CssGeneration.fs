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
                    Expect.equal actual (sprintf ".%s{&:hover{color:orangered;}}" className)

                test "Nested pseudo classes are generated correctly" <| fun _ ->
                    let className, actual = (createFss [ Hover [ Hover [ Hover [ Hover [ Color.orangeRed ] ] ] ] ])
                    Expect.equal actual (sprintf ".%s{&:hover{&:hover{&:hover{&:hover{color:orangered;}}}}}" className)

                test "Normal line of CSS followed by pseudo generates nested output" <| fun _ ->
                    let className, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ] ])
                    Expect.equal actual
                        (sprintf ".%s{color:aqua;&:hover{color:orangered;}}" className)

                test "Normal line of CSS followed by pseudo and another normal line generates nested output" <| fun _ ->
                    let className, actual = (createFss [ Color.aqua; Hover [ Color.orangeRed ]; Display.grid ])
                    Expect.equal actual
                        (sprintf ".%s{color:aqua;&:hover{color:orangered;}display:grid;}" className)

                test "A nested element whose rules are split by a nested element stays in one block" <| fun _ ->
                    let className, actual = (createFss [ Hover [ Color.white; Display.flex; Checked [ Color.blue ]; FontFamily.serif; FontSize.value (px 28); ]])
                    Expect.equal actual
                        (sprintf ".%s{&:hover{color:white;display:flex;&:checked{color:blue;}font-family:serif;font-size:28px;}}" className)

                test "Compound selector, refine the parent selector" <| fun _ ->
                    let className, actual = (createFss [ Color.blue; Classname "bar" [ Color.red ] ])
                    Expect.equal actual
                        (sprintf ".%s{color:blue;&.bar{color:red;}}" className)

                test "Multiple levels of nesting" <| fun _ ->
                    let className, actual = (createFss [
                        Margin.value (px 0)
                        !> (Selector.figcaption) [
                            BackgroundColor.hsl 0 0 0
                            !> (Selector.p) [
                                FontSize.value (rem 0.9)
                            ]
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{margin:0px;& > figcaption{background-color:hsl(0,0%%,0%%);& > p{font-size:0.9rem;}}}" className)

                // --- Media queries with nesting ---

                test "Media query with rules nests inside parent block" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        Media.query [ Fss.Types.Media.MinWidth (px 768) ] [
                            FontSize.value (px 18)
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:red;@media (min-width:768px) {&{font-size:18px;}}}" className)

                test "Media query with pseudo inside" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        Media.query [ Fss.Types.Media.MinWidth (px 768) ] [
                            FontSize.value (px 18)
                            Hover [ Color.blue ]
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:red;@media (min-width:768px) {&{font-size:18px;&:hover{color:blue;}}}}" className)

                test "Multiple media queries in one block" <| fun _ ->
                    let className, actual = (createFss [
                        Color.black
                        Media.query [ Fss.Types.Media.MinWidth (px 768) ] [
                            Color.hex "333333"
                        ]
                        Media.query [ Fss.Types.Media.MinWidth (px 1024) ] [
                            Color.hex "666666"
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:black;@media (min-width:768px) {&{color:#333333;}}@media (min-width:1024px) {&{color:#666666;}}}" className)

                test "Media query with combinator inside" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        Media.query [ Fss.Types.Media.MaxWidth (px 600) ] [
                            !> (Selector.p) [
                                FontSize.value (px 12)
                            ]
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:red;@media (max-width:600px) {&{& > p{font-size:12px;}}}}" className)

                // --- Id selector nesting ---

                test "Id selector nests inside parent block" <| fun _ ->
                    let className, actual = (createFss [ Color.blue; Id "myId" [ Color.red ] ])
                    Expect.equal actual
                        (sprintf ".%s{color:blue;&#myId{color:red;}}" className)

                // --- Important inside nested scope ---

                test "Important inside pseudo" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        Hover [ important Color.blue ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:red;&:hover{color:blue !important;}}" className)

                // --- Edge cases ---

                test "Empty rules produce empty block" <| fun _ ->
                    let className, actual = (createFss [])
                    Expect.equal actual (sprintf ".%s{}" className)

                test "Only nested scopes, no flat rules" <| fun _ ->
                    let className, actual = (createFss [
                        Hover [ Color.red ]
                        Focus [ Color.blue ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{&:hover{color:red;}&:focus{color:blue;}}" className)

                test "Pseudo element nests with double colon" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        After [ Content.value "x" ]
                    ])
                    Expect.equal actual
                        (sprintf """.%s{color:red;&::after{content:"x";}}""" className)

                test "Multiple pseudos interleaved with rules" <| fun _ ->
                    let className, actual = (createFss [
                        Color.red
                        Hover [ Color.blue ]
                        FontSize.value (px 14)
                        Focus [ Color.green ]
                        Padding.value (px 10)
                    ])
                    Expect.equal actual
                        (sprintf ".%s{color:red;&:hover{color:blue;}font-size:14px;&:focus{color:green;}padding:10px;}" className)

                // --- createGlobal ---

                test "createGlobal produces global selector without dot prefix" <| fun _ ->
                    let actual = createGlobal [ Color.red; Display.flex ]
                    Expect.equal actual "*{color:red;display:flex;}"

                test "createGlobal with nested pseudo" <| fun _ ->
                    let actual = createGlobal [ Color.red; Hover [ Color.blue ] ]
                    Expect.equal actual "*{color:red;&:hover{color:blue;}}"

                // --- Label ---

                test "Label appends to classname" <| fun _ ->
                    let className, actual = (createFss [ Color.red; Label "myLabel" ])
                    Expect.equal (className.EndsWith("myLabel")) true
                    Expect.equal actual (sprintf ".%s{color:red;}" className)

                // --- createFssWithClassname ---

                test "createFssWithClassname uses provided name" <| fun _ ->
                    let className, actual = createFssWithClassname "myCustomClass" [ Color.red ]
                    Expect.equal className "myCustomClass"
                    Expect.equal actual ".myCustomClass{color:red;}"

                test "createFssWithClassname with nesting" <| fun _ ->
                    let _, actual = createFssWithClassname "nested" [
                        Color.red
                        Hover [ Color.blue ]
                        !> (Selector.p) [ FontSize.value (px 12) ]
                    ]
                    Expect.equal actual ".nested{color:red;&:hover{color:blue;}& > p{font-size:12px;}}"

                // --- Combinator + pseudo + media mix ---

                test "Combinator with pseudo and media inside" <| fun _ ->
                    let className, actual = (createFss [
                        !> (Selector.div) [
                            Color.red
                            Hover [ Color.blue ]
                            Media.query [ Fss.Types.Media.MinWidth (px 768) ] [
                                FontSize.value (px 18)
                            ]
                        ]
                    ])
                    Expect.equal actual
                        (sprintf ".%s{& > div{color:red;&:hover{color:blue;}@media (min-width:768px) {&{font-size:18px;}}}}" className)

                // --- Attribute + pseudo mix ---

                test "Attribute selector with nested pseudo" <| fun _ ->
                    let className, actual = (createFss [
                        Attr.Has (Fss.Types.Attribute.Title, [
                            Color.red
                            Hover [ Color.blue ]
                        ])
                    ])
                    Expect.equal actual
                        (sprintf ".%s{&[title]{color:red;&:hover{color:blue;}}}" className)
            ]
