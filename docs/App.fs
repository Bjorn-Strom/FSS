namespace Docs

module App =
    open Elmish
    open Elmish.React
    open Elmish.Navigation
    open Fable.React
    open Fable.React.Props
    open Fable.SimpleHttp
    open Fss

    open Markdown

    let inline getMarkdown (markdown: string) =
        Http.get $"https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/docs/documentation/{markdown}.md"

    type Page =
        | Overview
        | Installation
        | Philosophy
        | BasicUsage
        | ConditionalStyling
        | Pseudo
        | Composition
        | Labels
        | Transition
        | KeyframesAnimations
        | Combinators
        | MediaQueries
        | GlobalStyles
        | Counters
        | Fonts
        | BackgroundImage

    type ButtonType =
        | Big
        | Small

    type Model = { CurrentPage: Page; Pages: Map<Page, string>; CurrentMarkdown: string }

    type Msg =
        | GetMarkdown
        | GotMarkdown of string
        | FailedGettingMarkdown of string

    let init page =
        let page = page |> Option.defaultValue Overview
        { CurrentPage = page; Pages = Map.empty; CurrentMarkdown = "" }, Cmd.ofMsg GetMarkdown

    let update (msg: Msg) (model: Model) =
        match msg with
        | GetMarkdown ->
            Map.tryFind model.CurrentPage model.Pages
            |> function
                | None ->
                    let nextCommand =
                        async {
                            let! (statusCode, response) = getMarkdown (Utilities.duToString model.CurrentPage)

                            if statusCode = 200 then
                                return GotMarkdown response
                            else
                                return FailedGettingMarkdown "Unable to get markdown"
                        }
                    model, Cmd.OfAsync.result nextCommand
                | Some markdown ->
                    model, Cmd.ofMsg <| GotMarkdown markdown

        | GotMarkdown markdown ->
            let pages = model.Pages.Add(model.CurrentPage, markdown)
            { model with CurrentMarkdown = markdown; Pages = pages }, Cmd.none
        | FailedGettingMarkdown e ->
            model, Cmd.none

    // Load font
    let headingFont = FontFamily.Custom "Nunito"
    let textFont = FontFamily.Custom "Raleway"

    // Styles
    let multilineText =
        fss
            [
                Label' "Multi Line Text"
                WhiteSpace.PreLine
                MarginBottom' (px 200)
            ]

    let pageToString =
        function
        | Overview -> "Overview"
        | Installation -> "Installation"
        | Philosophy -> "Philosophy"
        | BasicUsage -> "Basic Usage"
        | ConditionalStyling -> "Conditional Styling"
        | Pseudo -> "Pseduoclasses/elements"
        | Composition -> "Composition"
        | Labels -> "Labels"
        | Transition -> "Transition"
        | KeyframesAnimations -> "Keyframes and animations"
        | Combinators -> "Combinators"
        | MediaQueries -> "Media queries"
        | GlobalStyles  -> "Global styles"
        | Counters -> "Counters"
        | Fonts -> "Fonts"
        | BackgroundImage -> "Background image"

    let codeBlock (code: string List) =
        let codeBlock =
            fss
                [
                    Label' "Code Block"
                    BackgroundColor.Hex "#2A2A2A"
                    Color.white
                    Padding' (px 20)
                ]
        pre [ ClassName codeBlock ] [ str (code |> String.concat "\n") ]

    let pageToContent page currentMarkdown =

        let overview = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let installation = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let philosophy = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]

        let basicUse =
            let borderStyle = fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)" ]
            article []
               [
                    markdown [ Renderers renderers; Children currentMarkdown ]
                    div [ ClassName borderStyle ] [ str "Border style made with custom escape hatch" ]
               ]

        let conditionalStyling =
            let buttonStyle buttonType =
                fss
                    [
                        Label' "Button Style"
                        Padding' (px 0)
                        match buttonType with
                        | Big ->
                            Height' (px 80)
                            Width' (px 80)
                        | Small ->
                            Height' (px 40)
                            Width' (px 40)
                    ]
            article []
                [
                    markdown [ Renderers renderers; Children currentMarkdown ]
                    button [ ClassName <| buttonStyle Small ] [ str "Small" ]
                    button [ ClassName <| buttonStyle Big ] [ str "Big" ]
                ]

        let pseudo =
            let hoverStyle =
                fss
                    [
                        Label' "Hover Style"
                        Padding' (px 40)
                        Width' (px 100)
                        BackgroundColor.orangeRed
                        FontSize' (px 20)
                        BorderRadius' (px 5)
                        Color.white
                        Hover
                            [
                                BackgroundColor.chartreuse
                                Color.black
                            ]
                    ]

            let beforeAndAfter =
                let beforeAndAfter =
                    [
                        Content.Value ""
                        Display.InlineBlock
                        BackgroundColor.orangeRed
                        Width' (px 10)
                        Height' (px 10)
                    ]
                fss
                    [
                        Label' "Before And After"
                        Before beforeAndAfter
                        After beforeAndAfter
                    ]

            let examples =
                    [ div [ ClassName hoverStyle ] [ str "Hover me!" ]
                      div [ ClassName beforeAndAfter ] [ str " Some content surrounded by stuff " ]
                    ]

            let pseudoElements =
                currentMarkdown.Split "##"
                |> Seq.toList
                |> List.skip 1
                |> List.zip examples
                |> List.map (fun (e, s) ->
                    fragment []
                        [
                            markdown [ Renderers renderers; Children $"## {s}" ]
                            e
                        ])

            article [] pseudoElements

        let composition =
            article []
                [
                    let baseStyle =
                        [
                            Label' "Base Style"
                            BackgroundColor.darkGreen
                            Color.turquoise
                        ]
                    let danger =
                        [
                            Label' "Danger"
                            Color.red
                        ]

                    markdown [ Renderers renderers; Children currentMarkdown ]
                    div [ ClassName (fss baseStyle) ] [ str "This will be turquoise" ]
                    div [ ClassName (fss <| danger @ baseStyle)] [ str "This will be also be turquoise since the base styles overwrite the danger styles."]
                    div [ ClassName (fss <| baseStyle @ danger)] [ str "This will be red" ]
                ]

        let labels =
            article []
                [
                    markdown [ Renderers renderers; Children currentMarkdown ]

                    let styleWithoutLabel =
                        fss
                            [
                                Color.red
                            ]
                    let styleWithLabel =
                        fss
                            [
                                Label' "Style With Label"
                                Color.hotPink
                                Label' "HotPinkLabel"
                            ]
                    div [ ClassName styleWithoutLabel ] [ str styleWithoutLabel ]
                    div [ ClassName styleWithLabel ] [ str styleWithLabel ]
                ]

        let transitions =
            article []
                [
                    let colorTransition =
                           fss
                               [
                                   Label' "Color Transition"
                                   BackgroundColor.red
                                   TransitionProperty.BackgroundColor
                                   TransitionDuration' (sec 2.5)
                                   TransitionTimingFunction.Ease
                                   Hover [ BackgroundColor.green ]
                               ]
                    let sizeAndColor =
                        fss
                            [
                                Label' "Size and Color"
                                Width' (px 40)
                                Height' (px 40)
                                BackgroundColor.yellowGreen
                                TransitionProperty.All
                                TransitionTimingFunction.Linear
                                TransitionDuration' (ms 500.)
                                Hover
                                    [
                                        BorderRadius' (pct 100)
                                        BackgroundColor.orangeRed
                                    ]
                            ]


                    markdown [ Renderers renderers; Children currentMarkdown ]
                    div [ ClassName colorTransition ] [ str "Hover me" ]
                    div [ ClassName sizeAndColor ] [ ]
                ]

        let keyframesAnimations =
            let bounceFrames =
                keyframes
                    [
                        frames [ 0; 20; 53; 80; 100 ]
                            [ Transforms [ Transform.Translate3D(px 0, px 0, px 0) ] ]
                        frames [40; 43]
                            [ Transforms [ Transform.Translate3D(px 0, px -30, px 0) ] ]
                        frame 70
                            [ Transforms [ Transform.Translate3D(px 0, px -15, px 0) ] ]
                        frame 90
                            [ Transforms [ Transform.Translate3D(px 0, px -4, px 0) ] ]
                    ]

            let backgroundColorFrames =
                keyframes
                    [
                        frame 0 [ BackgroundColor.red ]
                        frame 30 [ BackgroundColor.green ]
                        frame 60 [ BackgroundColor.blue ]
                        frame 100 [ BackgroundColor.red ]
                    ]

            let bounceAnimation =
                fss
                    [
                        Label' "Bounce Animation"
                        AnimationName' bounceFrames
                        AnimationDuration' (sec 1.0)
                        AnimationTimingFunction.EaseInOut
                        AnimationIterationCount.Infinite
                    ]

            let bouncyColor =
                fss
                    [
                        Label' "Bouncy Color"
                        AnimationName.Names [ bounceFrames; backgroundColorFrames ]
                        AnimationDuration.Values [ sec 1.0; sec 5.0 ]
                        AnimationTimingFunction.Values [ TimingFunctionType.EaseInOut; TimingFunctionType.Ease ]
                        AnimationIterationCount.Values [ AnimationType.Infinite; CssInt 3 ]
                    ]
            article []
                [
                    let elements = currentMarkdown.Split "##"
                    let animations = elements |> Seq.skip 1 |> Seq.head
                    let transforms = elements |> Seq.rev |> Seq.head
                    markdown [ Renderers renderers; Children $"##{animations}" ]
                    div [ ClassName bounceAnimation ] [ str "Bouncy bounce" ]
                    div [ ClassName bouncyColor ] [ str "Bouncy color" ]
                    markdown [ Renderers renderers; Children $"##{transforms}" ]
                ]

        let Combinators =
            let borders =
                [
                    Label' "Borders"
                    BorderStyle.Solid
                    BorderColor.black
                    BorderWidth' (px 1)
                ]
            let descendantCombinator =
                fss
                    [
                        Label' "Descendant"
                        yield! borders
                        ! Html.P [ Color.red ]
                    ]
            let childCombinator =
                fss
                    [
                        Label' "Child"
                        yield! borders
                        !> Html.P [ Color.red ]

                    ]
            let directCombinator =
                fss
                    [
                        Label' "Direct"
                        !+ Html.P [ Color.red ]
                    ]
            let adjacentCombinator =
                fss
                    [
                        Label' "Adjacent"
                        !~ Html.P [ Color.red ]
                    ]

            article []
                [
                    let info  =
                        currentMarkdown.Split "- "
                        |> Seq.head

                    let elements =
                        [
                            div [ ClassName descendantCombinator ]
                                [
                                    p [] [ str "Text in a paragraph and therefore red"]
                                    str "Text outside of paragraph"
                                    div [] [ p [] [ str "Text in paragraph in div and red" ] ]
                                ]
                            div [ ClassName childCombinator ]
                                [
                                    p [] [ str "Text in a paragraph and therefore red"]
                                    str "Text outside of paragraph"
                                    div [] [ p [] [ str "Text in paragraph in div and not red" ] ]
                                ]
                            div [ ClassName (fss borders)]
                                [
                                    div [ ClassName directCombinator ] [ p [] [ str "Text in paragraph in div " ] ]
                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                    p [] [ str "Text in a paragraph but not after div with the combinator so is not red"]
                                ]
                            div [ ClassName (fss borders)]
                                [
                                    div [ ClassName adjacentCombinator ] [ p [] [ str "Text in paragraph in div " ] ]
                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                    div [] [p [] [ str "Text in a paragraph inside another div, paragraph is not directly after div with the combinator so is not red"]]
                                ]
                        ]

                    let pseudoElements =
                        currentMarkdown.Split "- "
                        |> Seq.skip 1
                        |> Seq.zip elements
                        |> Seq.map (fun (e, s) ->
                            fragment []
                                [
                                    markdown [ Renderers renderers; Children s ]
                                    e
                                ])


                    markdown [ Renderers renderers; Children info ]
                    div [] pseudoElements


                ]

        let mediaQueries =
            let mediaQueryExamples =
                fss
                    [
                        Label' "Media query examples"
                        Width' (px 200)
                        Height' (px 200)
                        BackgroundColor.blue

                        MediaQuery
                            [ Media.MinHeight (px 700)]
                            [ BackgroundColor.pink ]

                        MediaQueryFor Media.Print
                            []
                            [
                                MarginTop' (px 200)
                                Transforms [ Transform.Rotate(deg 45.0) ]
                                BackgroundColor.red
                            ]

                        MediaQuery
                            [ Media.Orientation Media.Landscape]
                            [ Color.green; FontSize.Value (px 28)]
                    ]

            article []
                [
                    h2 [] [ str "Media queries" ]
                    div [ ClassName multilineText ]
                        [
                            str """Using media queries in FSS is similar to how you would with normal css - except you have 2 functions to use here."""
                            ul []
                                [
                                    li [] [ str "'MediaQuery'" ]
                                    str """Which takes a list of features which defines when the css block should be active and a list of css properties which is the styles to be active."""
                                    li [] [ str "'MediaQueryFor'"]
                                    str """Which takes a device and then the list of features and a list of css properties"""
                                    codeBlock [ "let mediaQueryExamples ="
                                                "   fss"
                                                "       ["
                                                "           Width' (px 200)"
                                                "           Height' (px 200)"
                                                "           BackgroundColor.blue"
                                                "           MediaQuery"
                                                "               [ Media.MinHeight (px 700)]"
                                                "               [ BackgroundColor.pink ]"
                                                ""
                                                "           MediaQueryFor Media.Print"
                                                "               []"
                                                "               ["
                                                "                   MarginTop' (px 200)"
                                                "                   Transforms"
                                                "                       ["
                                                "                           Transform.Rotate(deg 45.0)"
                                                "                       ]"
                                                "                   BackgroundColor.red"
                                                "               ]"
                                                "           MediaQuery"
                                                "               [ Media.Orientation Media.Landscape]"
                                                "               [ Color.green; FontSize.Value (px 28)]" ]

                                    div [ ClassName mediaQueryExamples] [ str "Changing height changes this thing"]

                                ]
                        ]
                ]

        let globalStyles =
            article []
                [
                    h3 [] [ str "Global styles" ]
                    div [ ClassName multilineText ] [ str """Yeah, not supported. Put your styling in the topmost html tag I guess.""" ]
                ]
        let counters =
            let mozillaExampleCounter =
                counterStyle
                    [
                        System.Fixed
                        Symbols.Strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ"; "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ"; "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ"; "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ"; "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"]
                        Suffix.Value " "
                    ]
            let mozillaExampleStyle =
                fss
                    [
                        Label' "Mozilla Example Style"
                        ListStyleType' mozillaExampleCounter
                    ]

            let indexCounter = counterStyle []
            let subCounter = counterStyle []
            let sectionStyle =
                fss
                    [
                        Label' "Section"
                        FontFamily.Custom "Roboto, sans-serif"
                        CounterReset' indexCounter
                    ]
            let commonBefore =
                [
                    FontWeight' (CssInt 500)
                    Color.Hex "48f"
                ]
            let commonStyle =
                [
                    Margin.Value (px 0, px 0, px 1)
                    Padding.Value (px 5, px 10)
                ]
            let count =
                fss
                    [
                        Label' "Count"
                        yield! commonStyle
                        CounterReset' subCounter
                        CounterIncrement' indexCounter
                        BackgroundColor.Hex "eee"
                        Before
                            [
                                yield! commonBefore
                                Content.Counter(indexCounter,". ")
                            ]
                    ]
            let sub =
                fss
                    [
                        Label' "Sub"
                        yield! commonStyle
                        CounterIncrement' subCounter
                        TextIndent' (em 1.)
                        Color.Hex "444"
                        Before
                            [
                                yield! commonBefore
                                Content.Counters([indexCounter; subCounter], [".";"."])
                                MarginRight' (px 5)
                            ]
                    ]


            article []
                [
                    h3 [] [ str "Counters" ]
                    div [ ClassName multilineText ]
                        [
                            str """Counters are pretty cool and allows you to define style for well, counters.
                                You can use the counters as liststyle type or as content. Examples follow:
                                Example from """
                            a [ Href "https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style" ] [ str "mozilla" ]
                            codeBlock [ "let mozillaExampleCounter ="
                                        "    counterStyle"
                                        "        ["
                                        "            System.Fixed"
                                        "            Symbols.Strings [\"Ⓐ\"; \"Ⓑ\"; \"Ⓒ\"; \"Ⓓ\"; \"Ⓔ\";"
                                        "                              \"Ⓕ\"; \"Ⓖ\"; \"Ⓗ\"; \"Ⓘ\"; \"Ⓙ\";"
                                        "                              \"Ⓚ\"; \"Ⓛ\"; \"Ⓜ\"; \"Ⓝ\"; \"Ⓞ\";"
                                        "                              \"Ⓟ\"; \"Ⓠ\"; \"Ⓡ\"; \"Ⓢ\"; \"Ⓣ\";"
                                        "                              \"Ⓤ\"; \"Ⓥ\"; \"Ⓦ\"; \"Ⓧ\"; \"Ⓨ\"; \"Ⓩ\"]"
                                        "            Suffix.Value \" \""
                                        "        ]"
                                        "let mozillaExampleStyle = fss [ ListStyleType' mozillaExampleCounter ]"]

                            ul [ ClassName mozillaExampleStyle ]
                                [
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                    li [] [ str "one" ]
                                    li [] [ str "two" ]
                                    li [] [ str "three" ]
                                    li [] [ str "four" ]
                                    li [] [ str "five" ]
                                ]

                            str """Another example found """
                            a [ Href "https://codepen.io/mkmueller/pen/pHiqb" ] [ str "here" ]
                            str """."""

                            codeBlock [ "let commonBefore ="
                                        "    ["
                                        "       FontWeight' (CssInt 500)"
                                        "       Color.Hex \"48f\""
                                        "   ]"
                                        "let commonStyle ="
                                        "   ["
                                        "       Margin.Value (px 0, px 0, px 1)"
                                        "       Padding.Value (px 5, px 10)"
                                        "    ]"
                                        "let count ="
                                        "    fss"
                                        "        ["
                                        "            yield! commonStyle"
                                        "            CounterReset' subCounter"
                                        "            CounterIncrement' indexCounter"
                                        "            BackgroundColor.Hex \"eee\""
                                        "            Before"
                                        "                ["
                                        "                    yield! commonBefore"
                                        "                    Content.Counter(indexCounter,\". \")"
                                        "                ]"
                                        "        ]"
                                        "let sub ="
                                        "    fss"
                                        "        ["
                                        "            yield! commonStyle"
                                        "            CounterIncrement' subCounter"
                                        "            TextIndent' (em 1.)"
                                        "            Color.Hex \"444\""
                                        "            Before"
                                        "                ["
                                        "                    yield! commonBefore"
                                        "                    Content.Counters([indexCounter; subCounter], [\".\";\".\"])"
                                        "                    MarginRight' (px 5)"
                                        "                ]"
                                        "        ]"
                                        "section [ ClassName sectionStyle ]"
                                        "    ["
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName count] [ str \"Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "        p [ ClassName sub] [ str \"Sub-Item\" ]"
                                        "    ]"]

                            section [ ClassName sectionStyle ]
                                [
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName count] [ str "Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                    p [ ClassName sub] [ str "Sub-Item" ]
                                ]

                        ]

                ]
        let fonts =
            let amaticStyle =
                fss
                    [
                        Label' "Amatic Style"
                        FontFamily.Custom "Amatic SC"
                        FontSize' (px 24)
                    ]

            let droidSerifFont =
                fontFaces "DroidSerif"
                    [
                        [
                            FontFace.Source <| UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf", FontFace.Truetype)
                            FontFace.Weight FontTypes.Bold
                            FontFace.Style Normal
                        ]
                        [
                            FontFace.Source <| UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf", FontFace.Truetype)
                            FontFace.Weight Normal
                            FontFace.Style Normal
                        ]
                    ]

            let modernaFont =
                fontFace "moderna"
                    [
                        FontFace.Sources
                            [
                                UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FontFace.Woff2)
                                UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FontFace.Woff)
                                UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FontFace.Truetype)
                                UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FontFace.Svg)
                            ]
                        FontFace.Weight Normal
                        FontFace.Style Normal
                    ]

            let droidSerif =
                fss
                    [
                        Label' "Droid Serif"
                        FontFamily.Font droidSerifFont
                    ]

            let droidSerifBold =
                fss
                    [
                        Label' "Droid Serif Bold"
                        FontFamily.Font droidSerifFont
                        FontWeight.Bold
                    ]

            let moderna =
                fss
                    [
                        Label' "Moderna"
                        FontFamily.Font modernaFont
                    ]

            article []
                [
                    h3 [] [ str "Import" ]
                    div [ ClassName multilineText ]
                        [
                            str """For importing fonts from google fonts for example, use link syntax within <head>"""
                            codeBlock [ "<head>"
                                        "    ..."
                                        "    ..."
                                        "    ..."
                                        "    <link href=\"https://fonts.googleapis.com/css?family=Nunito|Raleway|Amatic+SC\" rel=\"stylesheet\">"
                                        "</head>" ]
                            codeBlock [ "let amaticStyle ="
                                        "    fss"
                                        "        ["
                                        "            FontFamily.Custom \"Amatic SC\""
                                        "            FontSize' (px 24)"
                                        "        ]"
                                        "p [ ClassName amaticStyle ] [str \"\"\"This font is Amatic SC, some nice text this huh?\"\"\"]"]
                            p [ ClassName amaticStyle ] [str """This font is Amatic SC, some nice text this huh?"""]

                            h3 [] [ str "Font face" ]

                            codeBlock ["let droidSerifFont ="
                                       "    fontFaces  \"DroidSerif \""
                                       "        ["
                                       "            ["
                                       "                FontFace.Source <| UrlFormat ( \"https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf \", FontFace.Truetype)"
                                       "                FontFace.Weight FontTypes.Bold"
                                       "                FontFace.Style Normal"
                                       "            ]"
                                       "            ["
                                       "                FontFace.Source <| UrlFormat ( \https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf \, FontFace.Truetype)"
                                       "                FontFace.Weight Normal"
                                       "                FontFace.Style Normal"
                                       "            ]"
                                       "        ]"
                                       "let modernaFont ="
                                       "    fontFace \"moderna \""
                                       "        ["
                                       "            FontFace.Sources"
                                       "                ["
                                       "                    UrlFormat (\"https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2 \", FontFace.Woff2)"
                                       "                    UrlFormat (\"https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff \", FontFace.Woff)"
                                       "                    UrlFormat (\"https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf\", FontFace.Truetype)"
                                       "                    UrlFormat (\"https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg\", FontFace.Svg)"
                                       "                ]"
                                       "            FontFace.Weight Normal"
                                       "            FontFace.Style Normal"
                                       "        ]"
                                       "let droidSerif = fss [ FontFamily.Font droidSerifFont ]"
                                       "let droidSerifBold ="
                                       "    fss"
                                       "        ["
                                       "            FontFamily.Font droidSerifFont"
                                       "            FontWeight.Bold"
                                       "        ]"
                                       "let moderna = fss [ FontFamily.Font modernaFont ]"
                                       "p [ ClassName droidSerif ] [ str \"Droid serif\" ]"
                                       "p [ ClassName droidSerifBold ] [ str  \"Droid serif bold\" ]"
                                       "p [ ClassName moderna] [ str \"Moderna\" ]"]


                            p [ ClassName droidSerif ] [ str "Droid serif" ]
                            p [ ClassName droidSerifBold ] [ str "Droid serif bold" ]
                            p [ ClassName moderna] [ str "Moderna" ]

                        ]
                    ]

        let backgroundImage =
            let box =
                [
                    Width' (px 200)
                    Height' (px 200)
                ]

            let linearGradientStyle1 =
                fss
                    [
                        Label' "Linear gradient style 1"
                        yield! box
                        BackgroundImage.LinearGradient(deg 0.,
                                                       [ hex "e66465", pct 0
                                                         hex "9198e5", pct 100 ])
                    ]
            let linearGradientStyle2 =
                fss
                    [
                        yield! box
                        Label' "Linear gradient style 2"
                        BackgroundImage.LinearGradient(turn 0.25,
                                                       [hex "3f87a6", pct 0
                                                        hex "ebf8e1", pct 50
                                                        hex "f69d3c", pct 100])
                    ]
            let linearGradientStyle3 =
                fss
                    [
                        yield! box
                        Label' "Linear gradient style 3"
                        BackgroundImage.LinearGradient(deg 270.,
                                                       [
                                                           hex "333", pct 0
                                                           hex "333", pct 50
                                                           hex "eee", pct 75
                                                           hex "333", pct 75
                                                       ])
                    ]
            let repeatingLinearGradientStyle1 =
                fss
                    [
                        yield! box
                        Label' "Repeating Linear gradient style 1"
                        BackgroundImage.RepeatingLinearGradient(deg 0.,
                                                       [
                                                           hex "e66465", px 0
                                                           hex "e66465", px 20
                                                           hex "9198e5", px 20
                                                           hex "9198e5", px 25
                                                       ])
                    ]
            let repeatingLinearGradientStyle2 =
                fss
                    [
                        yield! box
                        Label' "Repeating Linear gradient style 2"
                        BackgroundImage.RepeatingLinearGradient(deg 45.,
                                                       [
                                                           hex "3f87a6", px 0
                                                           hex "ebf8e1", px 15
                                                           hex "f69d3c", px 20
                                                       ])
                    ]
            let repeatingLinearGradientsStyle =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingLinearGradients
                            [
                                deg 217.,
                                    [
                                        CssColor.Rgba(255, 0, 0, 0.8), pct 0
                                        CssColor.Rgba(255, 0, 0, 0.0), pct 70
                                    ]
                                deg 127.,
                                    [
                                        CssColor.Rgba(0, 255, 0,0.8), pct 0
                                        CssColor.Rgba(0, 255, 0,0.0), pct 70
                                    ]
                                deg 336.,
                                    [
                                        CssColor.Rgba(0, 0, 255, 0.8), pct 0
                                        CssColor.Rgba(0, 0, 255,0.0), pct 70
                                    ]

                            ]
                    ]

            let radialGradientStyle1 =
                fss
                    [
                        yield! box
                        Label' "Radial Gradient style 1"
                        BackgroundImage.RadialGradient(Ellipse, FarthestCorner, pct 50, pct 50,
                                                       [ hex "e66465", pct 0
                                                         hex "9198e5", pct 100])
                    ]
            let radialGradientStyle2 =
                fss
                    [
                        Label' "Radial Gradient style 2"
                        yield! box
                        BackgroundImage.RadialGradient(Ellipse, ClosestSide, pct 50, pct 50,
                                [
                                    hex "3f87a6", pct 0
                                    hex "ebf8e1", pct 50
                                    hex "f69d3c", pct 100
                                ])
                    ]
            let radialGradientStyle3 =
                fss
                    [
                        yield! box
                        Label' "Radial Gradient style 3"
                        BackgroundImage.RadialGradient(Circle, FarthestCorner, pct 100, pct 50,
                            [hex "333", pct 0
                             hex "333", pct 50
                             hex "eee", pct 75
                             hex "333", pct 75 ])
                    ]
            let repeatingRadialGradientStyle1 =
                fss
                    [
                        Label' "Repeating Radial Gradient style 1"
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(
                                Ellipse, FarthestCorner, pct 50, pct 50,
                                    [
                                        hex "e66465", pct 0
                                        hex "9198e5", pct 20
                                    ])
                    ]
            let repeatingRadialGradientStyle2 =
                fss
                    [
                        Label' "Repeating Radial Gradient style 2"
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(
                            Ellipse, ClosestSide, pct 50, pct 50,
                                [
                                    hex "3f87a6", pct 0
                                    hex "ebf8e1", pct 50
                                    hex "f69d3c", pct 100
                                ])
                    ]
            let repeatingRadialGradientStyle3 =
                fss
                    [
                        Label' "Repeating Radial Gradient style 3"
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(
                                Circle, FarthestCorner, pct 100, pct 50,
                                    [
                                        hex "333", px 0
                                        hex "333", px 10
                                        hex "eee", px 10
                                        hex "eee", px 20
                                    ])
                    ]
            let conicGradientStyle1 =
                fss
                    [
                        Label' "Conic gradient style 1"
                        yield! box
                        BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
                              [
                                  CssColor.red, deg 0.
                                  CssColor.orange, deg 90.
                                  CssColor.yellow, deg 180.
                                  CssColor.green, deg 270.
                                  CssColor.blue, deg 360.
                              ])
                    ]
            let conicGradientStyle2 =
                fss
                    [
                        Label' "Conic gradient style 2"
                        yield! box
                        BackgroundImage.ConicGradient(rad 3.1416, pct 10, pct 50,
                                                      [
                                                            hex "#e66465", deg 0.
                                                            hex "#9198e5", deg 360.
                                                      ])
                    ]
            let conicGradientStyle3 =
                fss
                    [
                        Label' "Conic gradient style 3"
                        yield! box
                        BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         CssColor.red, deg 6.
                                                         CssColor.orange, deg 6.
                                                         CssColor.orange, deg 18.
                                                         CssColor.yellow, deg 18.
                                                         CssColor.yellow, deg 45.
                                                         CssColor.green, deg 45.
                                                         CssColor.green, deg 110.
                                                         CssColor.blue, deg 110.
                                                         CssColor.blue, deg 200.
                                                         CssColor.purple, deg 200.
                                                      ])
                    ]
            let conicGradientStyle4 =
                fss
                    [
                        Label' "Conic gradient style 4"
                        yield! box
                        BorderRadius' <| px 200
                        BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         CssColor.yellow, deg (360. / 6.)
                                                         CssColor.lime,   deg <| (360. / 6.) * 2.
                                                         CssColor.blue,   deg <| (360. / 6.) * 3.
                                                         CssColor.violet, deg <| (360. / 6.) * 4.
                                                         CssColor.red,    deg <| (360. / 6.) * 5.
                                                         CssColor.yellow, deg <| (360. / 6.) * 6.
                                                      ])
                    ]
            let repeatingConicGradientStyle =
                fss
                    [
                        Label' "Repeating conic gradient style"
                        yield! box
                        BackgroundSize.Value(px 50, px 50)
                        BorderColor.black
                        BorderStyle.Solid
                        BorderWidth' (px 1)
                        BackgroundImage.RepeatingConicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         CssColor.white, pct 0
                                                         CssColor.white, pct 25
                                                         CssColor.black, pct 25
                                                         CssColor.black, pct 50
                                                      ])
                    ]

            article []
                [
                    h2 [] [ str "Background images" ]
                    div [ ClassName multilineText ]
                        [
                            h3 [] [ str "Linear gradient" ]
                            codeBlock ["let linearGradientStyle1 = "
                                       "    BackgroundImage.LinearGradient(deg 0.,"
                                       "        [ hex \"e66465\", pct 0"
                                       "          hex \"9198e5\", pct 100 ])"
                                       ""
                                       "let linearGradientStyle2 ="
                                       "    BackgroundImage.LinearGradient(turn 0.25,"
                                       "                                   [hex \"3f87a6\", pct 0"
                                       "                                    hex \"ebf8e1\", pct 50"
                                       "                                    hex \"f69d3c\", pct 100])"
                                       ""
                                       "let linearGradientStyle3 ="
                                       "    BackgroundImage.LinearGradient(deg 270.,"
                                       "                                   ["
                                       "                                       hex \"333\", pct 0"
                                       "                                       hex \"333\", pct 50"
                                       "                                       hex \"eee\", pct 75"
                                       "                                       hex \"333\", pct 75"
                                       "                                   ])"]

                            div [ ClassName (fss [ Label' "Flex 1"; Display.Flex ]) ]
                                [
                                    div [ClassName linearGradientStyle1 ] []
                                    div [ClassName linearGradientStyle2 ] []
                                    div [ClassName linearGradientStyle3 ] []
                                ]
                            h3 [] [ str "Repeating Linear gradient" ]
                            codeBlock [ "let repeatingLinearGradientStyle1 ="
                                        "   BackgroundImage.RepeatingLinearGradient(deg 0.,"
                                        "               ["
                                        "                   hex \"e66465\", px 0"
                                        "                   hex \"e66465\", px 20"
                                        "                   hex \"9198e5\", px 20"
                                        "                   hex \"9198e5\", px 25"
                                        "               ])"
                                        ""
                                        "let repeatingLinearGradientStyle2 ="
                                        "   BackgroundImage.RepeatingLinearGradient(deg 45.,"
                                        "                                  ["
                                        "                                      hex \"3f87a6\", px 0"
                                        "                                      hex \"ebf8e1\", px 15"
                                        "                                      hex \"f69d3c\", px 20"
                                        "                                  ])"]
                            div [ ClassName (fss [ Label' "Flex 2"; Display.Flex ]) ]
                                [
                                    div [ClassName repeatingLinearGradientStyle1 ] []
                                    div [ClassName repeatingLinearGradientStyle2 ] []
                                ]
                            h3 [] [ str "Radial gradient" ]

                            codeBlock [ "let radialGradientStyle1 = "
                                        "  BackgroundImage.RadialGradient(Ellipse, FarthestCorner, pct 50, pct 50,"
                                        "             [ hex \"e66465\", pct 0"
                                        "               hex \"9198e5\", pct 100])"
                                        ""
                                        "let radialGradientStyle2 ="
                                        "  BackgroundImage.RadialGradient(Ellipse, ClosestSide, pct 50, pct 50,"
                                        "       ["
                                        "           hex \"3f87a6\", pct 0"
                                        "           hex \"ebf8e1\", pct 50"
                                        "           hex \"f69d3c\", pct 100"
                                        "       ])"
                                        ""
                                        "let radialGradientStyle3 ="
                                        "  BackgroundImage.RadialGradient(Circle, FarthestCorner, pct 100, pct 50,"
                                        "        ["
                                        "            hex \"333\", pct 0"
                                        "            hex \"333\", pct 50"
                                        "            hex \"eee\", pct 75"
                                        "            hex \"333\", pct 75 ])"
                                        ]

                            div [ ClassName (fss [ Label' "Flex 3"; Display.Flex ]) ]
                                [
                                    div [ClassName radialGradientStyle1 ] []
                                    div [ClassName radialGradientStyle2 ] []
                                    div [ClassName radialGradientStyle3 ] []
                                ]
                            h3 [] [ str "Repeating radial gradient" ]
                            codeBlock [ "let repeatingRadialGradientStyle1 ="
                                        "    BackgroundImage.RepeatingRadialGradient("
                                        "            Ellipse, FarthestCorner, pct 50, pct 50,"
                                        "                ["
                                        "                    hex \"e66465\", pct 0"
                                        "                    hex \"9198e5\", pct 20"
                                        "                ])"
                                        ""
                                        "let repeatingRadialGradientStyle2 ="
                                        "   BackgroundImage.RepeatingRadialGradient("
                                        "        Ellipse, ClosestSide, pct 50, pct 50,"
                                        "            ["
                                        "                hex \"3f87a6\", pct 0"
                                        "                hex \"ebf8e1\", pct 50"
                                        "                hex \"f69d3c\", pct 100"
                                        "            ])"
                                        ""
                                        "let repeatingRadialGradientStyle3 ="
                                        "    BackgroundImage.RepeatingRadialGradient("
                                        "            Circle, FarthestCorner, pct 100, pct 50,"
                                        "                ["
                                        "                    hex \"333\", px 0"
                                        "                    hex \"333\", px 10"
                                        "                    hex \"eee\", px 10"
                                        "                    hex \"eee\", px 20"
                                        "                ]"]
                            div [ ClassName (fss [ Label' "Flex 4"; Display.Flex ]) ]
                                [
                                    div [ClassName repeatingRadialGradientStyle1 ] []
                                    div [ClassName repeatingRadialGradientStyle2 ] []
                                    div [ClassName repeatingRadialGradientStyle3 ] []
                                ]
                            h3 [] [ str "Conic gradient" ]
                            codeBlock ["let conicGradientStyle1 = "
                                       "    BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,"
                                       "                                  ["
                                       "                                      CssColor.red, deg 0."
                                       "                                      CssColor.orange, deg 90."
                                       "                                      CssColor.yellow, deg 180."
                                       "                                      CssColor.green, deg 270."
                                       "                                      CssColor.blue, deg 360."
                                       "                                  ])"
                                       ""
                                       "let conicGradientStyle2 ="
                                       "     BackgroundImage.ConicGradient(rad 3.1416, pct 10, pct 50,"
                                       "                                   ["
                                       "                                         hex \"#e66465\", deg 0."
                                       "                                         hex \"#9198e5\", deg 360."
                                       "                                   ])"
                                       ""
                                       "let conicGradientStyle3 ="
                                       "     BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,"
                                       "                                   ["
                                       "                                      CssColor.red, deg 6."
                                       "                                      CssColor.orange, deg 6."
                                       "                                      CssColor.orange, deg 18."
                                       "                                      CssColor.yellow, deg 18."
                                       "                                      CssColor.yellow, deg 45."
                                       "                                      CssColor.green, deg 45."
                                       "                                      CssColor.green, deg 110."
                                       "                                      CssColor.blue, deg 110."
                                       "                                      CssColor.blue, deg 200."
                                       "                                      CssColor.purple, deg 200."
                                       "                                   ])"
                                       ""
                                       "let conicGradientStyle4 = "
                                       "     BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,"
                                       "       ["
                                       "          CssColor.yellow, deg (360. / 6.)"
                                       "          CssColor.lime,   deg <| (360. / 6.) * 2."
                                       "          CssColor.blue,   deg <| (360. / 6.) * 3."
                                       "          CssColor.violet, deg <| (360. / 6.) * 4."
                                       "          CssColor.red,    deg <| (360. / 6.) * 5."
                                       "          CssColor.yellow, deg <| (360. / 6.) * 6."
                                       "       ])"]

                            div [ ClassName (fss [ Label' "Flex 1"; Display.Flex ]) ]
                                [
                                    div [ClassName conicGradientStyle1 ] []
                                    div [ClassName conicGradientStyle2 ] []
                                    div [ClassName conicGradientStyle3 ] []
                                    div [ClassName conicGradientStyle4 ] []
                                ]
                            h3 [] [ str "Repeating Conic gradient" ]
                            codeBlock ["let linearGradientStyle1 = "
                                       "    BackgroundSize.Value(px 50, px 50)"
                                       "    BorderColor.black"
                                       "    BorderStyle.Solid"
                                       "    BorderWidth' (px 1)"
                                       "    BackgroundImage.RepeatingConicGradient(deg 0., pct 50, pct 50,"
                                       "                                  ["
                                       "                                     CssColor.white, pct 0"
                                       "                                     CssColor.white, pct 25"
                                       "                                     CssColor.black, pct 25"
                                       "                                     CssColor.black, pct 50"
                                       "                                  ])"]

                            div [ ClassName (fss [ Label' "Flex 1"; Display.Flex ]) ]
                                [
                                    div [ClassName repeatingConicGradientStyle ] []
                                ]
                        ]
                    ]

        match page with
        | Overview -> overview
        | Installation -> installation
        | Philosophy -> philosophy
        | BasicUsage -> basicUse
        | ConditionalStyling -> conditionalStyling
        | Pseudo -> pseudo
        | Composition -> composition
        | Labels -> labels
        | Transition -> transitions
        | KeyframesAnimations -> keyframesAnimations
        | Combinators -> Combinators
        | MediaQueries -> mediaQueries
        | GlobalStyles  -> globalStyles
        | Counters -> counters
        | Fonts -> fonts
        | BackgroundImage -> backgroundImage

    let menuListItem example currentExample page =
        let listStyle =
            fss
                [
                    Height' <| px 40
                    Width' <| px 200
                ]
        let buttonStyle =
            fss
                [
                    Label' "Button Style"
                    Border.None
                    TextDecoration.None
                    Color.black
                    if example = currentExample then
                       BackgroundColor.Hex "#29A9DF"
                       BorderRightColor.Hex "#4a8ab5"
                       BorderRightWidth' (px 3)
                       BorderRightStyle.Solid
                    else
                        BackgroundColor.transparent
                    Margin' (px 0)
                    Padding' (px 10)
                    Width' (px 50)
                    FontSize' (px 14)
                    TextAlign.Left
                    textFont
                    Cursor.Pointer
                    Hover
                        [
                            BackgroundColor.Hex "E0E0E0"
                        ]
                ]

        li [ ClassName listStyle ]
            [
                a [ ClassName buttonStyle; Href $"#{Utilities.duToKebab example}" ] [ str $"{pageToString example}" ]
            ]

    let header =
        let headerStyle =
            fss
                [
                    Label' "Header Style"
                    Color.white
                    BackgroundColor.Hex "#4a8ab5"
                    PaddingLeft' (px 10)
                    AlignItems.Center
                ]

        let headerText =
            fss
                [
                    Label' "Header Text"
                    headingFont
                ]

        header  [ ClassName headerStyle ] [ h2 [ ClassName headerText ] [ str "Fss" ] ]

    let menu model (dispatch: Msg -> unit)=
        let menuList =
            fss
                [
                    Label' "Menu List"
                    ListStyleType.None
                    Margin' (px 0)
                    Padding' (px 0)
                    PaddingRight' (px 5)
                    TextIndent' (px 0)
                ]
        let menuListItem' example = menuListItem example model.CurrentPage example
        aside []
            [
                ul [ ClassName menuList ]
                    [
                        menuListItem' Overview
                        menuListItem' Installation
                        menuListItem' Philosophy
                        menuListItem' BasicUsage
                        menuListItem' ConditionalStyling
                        menuListItem' Pseudo
                        menuListItem' Composition
                        menuListItem' Labels
                        menuListItem' Transition
                        menuListItem' KeyframesAnimations
                        menuListItem' Combinators
                        menuListItem' MediaQueries
                        menuListItem' GlobalStyles
                        menuListItem' Counters
                        menuListItem' Fonts
                        menuListItem' BackgroundImage
                    ]
            ]

    let content model =
        let contentStyle =
            fss
                [
                    Label' "Content Style"
                    textFont
                ]
        section [ ClassName contentStyle ] [ pageToContent model.CurrentPage model.CurrentMarkdown ]

    let render (model: Model) (dispatch: Msg -> unit) =
        let contentStyle =
            fss
                [
                    Label' "Content style"
                    Width' (pct 60)
                    MaxWidth' (pct 60)
                    Display.Flex
                    FlexDirection.Row
                    MarginLeft.Auto
                    MarginRight.Auto
                ]
        div []
            [
                header
                div [ ClassName contentStyle ]
                    [
                        menu model dispatch
                        if model.CurrentMarkdown.Length > 0 then
                            content model
                    ]
            ]

    open Elmish.UrlParser

    let pageParser : Parser<_,_> =
        oneOf
            [ map Overview (s <| Utilities.duToKebab Overview)
              map Installation (s <| Utilities.duToKebab Installation)
              map Philosophy (s <| Utilities.duToKebab Philosophy)
              map BasicUsage (s <| Utilities.duToKebab BasicUsage)
              map ConditionalStyling (s <| Utilities.duToKebab ConditionalStyling)
              map Pseudo (s <| Utilities.duToKebab Pseudo)
              map Composition (s <| Utilities.duToKebab Composition)
              map Labels (s <| Utilities.duToKebab Labels)
              map Transition (s <| Utilities.duToKebab Transition)
              map KeyframesAnimations (s <| Utilities.duToKebab KeyframesAnimations)
              map Combinators (s <| Utilities.duToKebab Combinators)
              map MediaQueries (s <| Utilities.duToKebab MediaQueries)
              map GlobalStyles (s <| Utilities.duToKebab GlobalStyles)
              map Counters (s <| Utilities.duToKebab Counters)
              map Fonts (s <| Utilities.duToKebab Fonts)
              map BackgroundImage (s <| Utilities.duToKebab BackgroundImage)
            ]

    let urlUpdate (page: Page option) model =
        let page = page |> Option.defaultValue Overview

        { model with CurrentPage = page }, Cmd.ofMsg GetMarkdown

    Program.mkProgram init update render
    |> Program.toNavigable (parseHash pageParser) urlUpdate
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run