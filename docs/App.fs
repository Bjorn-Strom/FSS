namespace Docs

module App =
    open Elmish
    open Elmish.React
    open Fable.React
    open Fable.React.Props

    open Fss

    type Page =
        | Overview
        | Installation
        | Philosophy
        | BasicUse
        | ConditionalStyling
        | Pseudo
        | Composition
        | Labels
        | Transitions
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

    type Model = { CurrentPage: Page }

    type SetPage =
        | SetPage of Page

    let init() = { CurrentPage = Overview }

    let update (msg: SetPage) (model: Model): Model =
        match msg with
        | SetPage example ->
            { model with CurrentPage = example }

    // Load font
    Import.Url "https://fonts.googleapis.com/css?family=Nunito|Raleway"
    let headingFont = FontFamily.Custom "Nunito"
    let textFont = FontFamily.Custom "Raleway"

    // Styles
    let multilineText =
        fss
            [
                Whitespace.PreLine
                MarginBottom' (px 200)
            ]

    let pageToString =
        function
        | Overview -> "Overview"
        | Installation -> "Installation"
        | Philosophy -> "Philosophy"
        | BasicUse -> "Basic Usage"
        | ConditionalStyling -> "Conditional Styling"
        | Pseudo -> "Pseduoclasses/elements"
        | Composition -> "Composition"
        | Labels -> "Labels"
        | Transitions -> "Transitions"
        | KeyframesAnimations -> "Keyframes and animations"
        | Combinators -> "Combinators"
        | MediaQueries -> "Media queries"
        | GlobalStyles  -> "Global styles"
        | Counters -> "Counters"
        | Fonts -> "Fonts"
        | BackgroundImage -> "Background image"

    let codeBlock (code: string List) =
        let myDecorationColor = CSSColor.white
        let codeBlock =
            fss
                [
                    BackgroundColor.Hex "#2A2A2A"
                    Color.white
                    Padding' (px 20)
                    TextDecorationColor.Value(myDecorationColor)
                ]
        pre [ ClassName codeBlock ] [ str (code |> String.concat "\n") ]


    let pageToContent =
        let imageStyle =
            fss
                [
                    Display.Flex
                    JustifyContent.Center
                ]

        let overview =
            article []
                [
                    div [ ClassName imageStyle ]
                        [
                            Logo.logoNormal
                        ]
                    h2 [] [ str "Overview" ]
                    div [ ClassName multilineText ]
                        [
                            str
                                """An opinionated styling library for F#.
                                Have CSS as a first class citizen in your F# projects.
                                """

                            str """Built atop the fantastic """
                            a [ Href "https://github.com/emotion-js/emotion" ] [ str "Emotion-js" ]
                            str " FSS allows you to have CSS as a first class citizen in your F# code and aims to support most of the CSS spec"
                        ]
                ]

        let installation =
            article []
                [
                    h2 [] [ str "Installation" ]
                    str "In order to use Fss you need to install the "
                    a [ Href "" ] [ str "nuget" ]
                    str " package"
                    codeBlock [ "# nuget"
                                "dotnet add package Fss"
                                ""
                                "# paket"
                                "paket add Fss --project ./project/path" ]
                ]

        let philosophy =
            article []
                [
                    h2 [] [ str "Philosophy" ]
                    str "The main idea behind Fss is discoverable CSS. Write CSS in F# quick and easy."

                    str "There already exists some quite good styling alternatives to F# already"
                    ul []
                        [
                            li [] [
                                a [ Href "https://fulma.github.io/Fulma/" ] [ str "Fulma"]
                                str " which is a really nice wrapper over Bulma"
                            ]
                            li []
                                [
                                    a [ Href "https://github.com/zanaptak/TypedCssClasses" ] [ str "TypedCssClasses" ]
                                    str " a type provider if you want to generate types from existing CSS (or if you prefer CSS, you madman)"
                                ]
                            li []
                                [
                                    str "Webpack configuration for CSS or SCSS"
                                ]
                        ]
                    div [ ClassName multilineText ]
                        [
                            str """Ultimately I believe you will find whatever solution that suits your needs best.

                            Personally I find that writing CSS is bad. Just in general - bad!
                            What I like is having CSS as part of my language. So I can use the language I like to write both the markup and the styling.

                            There are tons of benefits to this:"""
                        ]
                    ul []
                        [
                            li [] [ str "Noe om å empirisk bestemme verdier and shizz" ]
                        ]
                ]

        let basicUse =
            article []
               [
                    h2 []
                        [
                            str "Basic usage"
                        ]
                    div [ ClassName multilineText ]
                        [
                            str """The main function Fss supplies is fss. This function takes a list of CSS properties and returns a string.
                                This string is the classname you can give to your html tag.

                                Simply write the CSS you want in PascalCase and dot yourself into the methods you want.
                                For example if I want """
                            codeBlock ["text-decoration-color: white"]
                            str """ then you write"""
                            codeBlock [ "let myStyle = fss [ TextDecorationColor.white ]"
                                        "div [ClassName myStyle] []" ]
                            str """This should work for most CSS properties you would want, if one is missing feel free to make a PR or an issue

                            You might want to store CSS in F# variables as well and Fss supports that with value methods.
                            All Fss properties should have a value method that accepts a type for that Css property.
                            Continuing with our TextDecorationColor example you could do the following"""
                            codeBlock ["let myDecorationColor = CSSColor.White"
                                       "fss [ TextDecorationColor.Value(myDecorationColor) ]"]
                            str """As this is something you might potentially want to do quite a but of (and we do like pipelining) there exists a shorthand which is TextDecorationPrime"""
                            codeBlock ["let myDecorationColor = CSSColor.White"
                                       "fss [ TextDecorationColor' myDecorationColor ]"]
                        ]

                    h3 []
                        [
                            str "Shorthands"
                        ]
                    div [ ClassName multilineText ]
                        [
                            str """I don't like shorthands so I haven't included them. In general I feel they make CSS more complicated than it needs to be..
                            However as this project creates CSS and interacts with it, it has to deal with some of its shortcoming, like shorthands.

                            Therefore the shorthands that are included are limited to ones where using inherit, initial, unset or none is natural. Like text-decoration.
                            Resetting text-decoration could be annoying without it.

                            Oh an yeah you can use margin and padding if you want to, so there are sprinkles of shorthands around
                            Dont you judge me, I said it was opinionated!"""
                        ]
               ]

        let conditionalStyling =
            let buttonStyle buttonType =
                fss
                    [
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
                    h2 [] [ str "Conditional styling" ]
                    str """If you want to style something conditionally you can use conditional or match expression

                        For example if you've defined a union type for your button sizes that looks like this: """
                    codeBlock [ "type ButtonSize ="
                                "   | Small"
                                "   | Big" ]
                    str "You could have a function that takes this ButtonSize as a parameter and spits out the styling you want."
                    codeBlock [ "let buttonStyle buttonType ="
                                "  fss"
                                "       ["
                                "           match buttonType with"
                                "           | Big ->"
                                "               Height' (px 80)"
                                "               Width' (px 80)"
                                "           | Small ->"
                                "               Height' (px 40)"
                                "               Width' (px 40)" ]
                    str "This function creates a string that you use as your classname"
                    codeBlock [ "button [ ClassName <| buttonStyle Small ] [ str \"Small\" ]"
                                "button [ ClassName <| buttonStyle Big ] [ str \"Big\" ]" ]
                    str "This has the following result: "

                    button [ ClassName <| buttonStyle Small ] [ str "Small" ]
                    button [ ClassName <| buttonStyle Big ] [ str "Big" ]
                ]

        let pseudo =
            let hoverStyle =
                fss
                    [
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
            article []
                [
                    h2 [] [ str "Pseudo-classes" ]
                    div [ ClassName multilineText ]
                        [
                            str """All pseudo class functions take a list of CSSProperties and return a CSSProperty, which the Fss function takes as a parameter.
                            So doing pseudo classes is as easy as calling them within the fss function.
                            Hover for example is done like so:
                            """
                            codeBlock ["let hoverStyle ="
                                       "     fss"
                                       "         ["
                                       "             Padding' (px 40)"
                                       "             Width' (px 100)"
                                       "             BackgroundColor.orangeRed"
                                       "             FontSize' (px 20)"
                                       "             BorderRadius' (px 5)"
                                       "             Color.white"
                                       "             Hover"
                                       "                 ["
                                       "                     BackgroundColor.chartreuse"
                                       "                     Color.black"
                                       "                 ]"
                                       "         ]" ]
                        ]
                    div [ ClassName hoverStyle ]
                        [
                            str "Hover me!"
                        ]
                    h2 [] [ str "Pseudo-elements" ]
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
                                Before beforeAndAfter
                                After beforeAndAfter
                            ]
                    div []
                        [
                            str """These bad boys work much in the same way as the pseudo classes. Example follows:"""
                            codeBlock [ "let beforeAndAfterStyle = "
                                        "   let beforeAndAfter ="
                                        "      ["
                                        "           Content.Value\"\""
                                        "           Display.InlineBlock"
                                        "           BackgroundColor.orangeRed"
                                        "           Width' (px 10)"
                                        "           Height' (px 10)"
                                        "       ]"
                                        "   fss"
                                        "       ["
                                        "           Before beforeAndAfter"
                                        "           After beforeAndAfter"
                                        "       ]"
                                        "div [ ClassName beforeAndAfter ]"
                                        "   ["
                                        "       str \" Some content surrounded by stuff \""
                                        "   ]"
                                ]
                            str """Results in"""
                            div [ ClassName beforeAndAfter ]
                                [
                                    str " Some content surrounded by stuff "
                                ]
                            ]

                ]
        let composition =
            article []
                [
                    let baseStyle =
                        [
                            BackgroundColor.darkGreen
                            Color.turquoise
                        ]
                    let danger = [ Color.red ]

                    h2 [] [ str "Composition" ]
                    div [ ClassName multilineText ]
                        [
                            str """As Fss uses """
                            a [ Href "https://github.com/emotion-js/emotion" ] [ str "Emotion-js" ]
                            str " to generate the CSS we get some nice benefits like "
                            a [ Href "https://emotion.sh/docs/composition" ] [ str "composition" ]
                            str """. Feel free to read emotions composition docs, the following example is a re-implementation of theirs."""

                            codeBlock ["let baseStyle ="
                                       "    ["
                                       "        BackgroundColor.darkGreen"
                                       "        Color.turquoise"
                                       "    ]"
                                       "let danger = [ Color.red ]"]
                            str """Note how we havent called Fss yet."""
                            codeBlock ["div [ ClassName (fss baseStyle) ]"
                                       "    [ str \"This will be turquoise\" ]"
                                       "div [ ClassName (fss <| danger @ baseStyle)\]"
                                       "    [ str \"This will be also be turquoise since the base styles overwrite the danger styles.\"]"
                                       "div [ ClassName (fss <| baseStyle @ danger)]"
                                       "    [ str \"This will be red\" ]"]

                            div [ ClassName (fss baseStyle) ]
                                [ str "This will be turquoise" ]
                            div [ ClassName (fss <| danger @ baseStyle)]
                                [ str "This will be also be turquoise since the base styles overwrite the danger styles."]
                            div [ ClassName (fss <| baseStyle @ danger)]
                                [ str "This will be red" ]
                        ]
                ]
        let labels =
            article []
                [
                    h2 [] [ str "Labels" ]
                    a [ Href "https://emotion.sh/docs/labels" ] [ str "Labels" ]
                    str """ is yet another benefit from using """
                    a [ Href "https://github.com/emotion-js/emotion" ] [ str "Emotion-js." ]

                    str """It is a CSS property called label which appends any name to the generated classname making it more readable."""

                    codeBlock ["let styleWithoutLabel = fss [ Color.red ]"
                               "let styleWithLabel = fss [ Color.hotPink; Label' \"HotPinkLabel\" ]"
                               "div [ ClassName styleWithoutLabel ] [ str styleWithoutLabel ]"
                               "div [ ClassName styleWithLabel ] [ str styleWithLabel ]"]

                    str """Results in: """

                    let styleWithoutLabel = fss [ Color.red ]
                    let styleWithLabel = fss [ Color.hotPink; Label' "HotPinkLabel" ]
                    div [ ClassName styleWithoutLabel ] [ str styleWithoutLabel ]
                    div [ ClassName styleWithLabel ] [ str styleWithLabel ]
                ]

        let transitions =
            article []
                [
                    h2 [] [ str "Transition" ]
                    div [ ClassName multilineText ]
                        [
                            str """The biggest difference here is that there is no transition shorthand.
                                Apart from that transitions will work as you expect
                                Hover example: """

                            codeBlock [ "let colorTransition ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundColor.red"
                                        "            TransitionProperty.BackgroundColor"
                                        "            TransitionDuration' (sec 2.5)"
                                        "            TransitionTimingFunction.Ease"
                                        "            Hover [ BackgroundColor.green ]"
                                        "       ]"
                                        "div [ ClassName colorTransition ] [ str \"Hover me\" ]" ]

                            let colorTransition =
                                   fss
                                       [
                                           BackgroundColor.red
                                           TransitionProperty.BackgroundColor
                                           TransitionDuration' (sec 2.5)
                                           TransitionTimingFunction.Ease
                                           Hover [ BackgroundColor.green ]
                                       ]

                            div [ ClassName colorTransition ] [ str "Hover me" ]

                            str """Another example"""
                            codeBlock [ "let sizeAndColor ="
                                        "    fss"
                                        "        ["
                                        "            Width' (px 40)"
                                        "            Height' (px 40)"
                                        "            BackgroundColor.yellowGreen"
                                        "            TransitionProperty.All"
                                        "            TransitionTimingFunction.Linear"
                                        "            TransitionDuration' (ms 500.)"
                                        "            Hover"
                                        "                ["
                                        "                    BorderRadius' (pct 100)"
                                        "                    BackgroundColor.orangeRed"
                                        "                ]"
                                        "        ]"
                                        "div [ ClassName sizeAndColor ] [ ]" ]

                            let sizeAndColor =
                                fss
                                    [
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
                            div [ ClassName sizeAndColor ] [ ]
                        ]
                ]

        let keyframesAnimations =
            let bounceFrames =
                keyframes
                    [
                        frames [ 0; 20; 53; 80; 100 ]
                            [ Transform.Translate3D(px 0, px 0, px 0) ]
                        frames [40; 43]
                            [ Transform.Translate3D(px 0, px -30, px 0) ]
                        frame 70
                            [ Transform.Translate3D(px 0, px -15, px 0) ]
                        frame 90
                            [ Transform.Translate3D(px 0, px -4, px 0) ]
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
                        AnimationName.Name bounceFrames
                        AnimationDuration' (sec 1.0)
                        AnimationTimingFunction.EaseInOut
                        AnimationIterationCount.Infinite
                    ]

            let bouncyColor =
                fss
                    [
                        AnimationName.Names [ bounceFrames; backgroundColorFrames ]
                        AnimationDuration.Values [ sec 1.0; sec 5.0 ]
                        AnimationTimingFunction.Values [ TimingFunctionType.EaseInOut; TimingFunctionType.Ease ]
                        AnimationIterationCount.Values [ AnimationType.Infinite; CssInt 3 ]
                    ]
            article []
                [
                    h2 [] [ str "Animations" ]
                    div [ ClassName multilineText ]
                        [
                            str """Animations introduce 3 new functions:"""
                            ul []
                                [
                                    li []
                                        [
                                            str "frame"
                                            codeBlock ["int -> CSSProperty list -> KeyframeAttribute"]
                                        ]
                                    li []
                                        [
                                            str "frames"
                                            codeBlock ["int list -> CSSProperty list -> KeyframeAttribute"]
                                        ]
                                    li []
                                        [
                                            str "keyframes"
                                            codeBlock ["KeyframeAttribute list -> IAnimationName"]
                                        ]
                                ]

                            str """What this means is that keyframes is a function that takes a list of frame or frame function calls.
                                Frame is used when you want to define a single keyframe and frames for multiple.
                                keyframes then gives you an animation name you supply to fss"""

                            codeBlock [ "let bounceFrames ="
                                        "    keyframes"
                                        "        ["
                                        "            frames [ 0; 20; 53; 80; 100 ]"
                                        "                [ Transform.Translate3D(px 0, px 0, px 0) ]"
                                        "            frames [40; 43]"
                                        "                [ Transform.Translate3D(px 0, px -30, px 0) ]"
                                        "            frame 70"
                                        "                [ Transform.Translate3D(px 0, px -15, px 0) ]"
                                        "            frame 90"
                                        "                [ Transform.Translate3D(px 0, px -4, px 0) ]"
                                        "        ]"
                                        "let bounceAnimation ="
                                        "    fss"
                                        "        ["
                                        "            AnimationName.Name bounceFrames"
                                        "            AnimationDuration' (sec 1.0)"
                                        "            AnimationTimingFunction.EaseInOut"
                                        "            AnimationIterationCount.Infinite"
                                        "        ]"]

                            div [ ClassName bounceAnimation ] [ str "Bouncy bounce" ]
                            str """Animations can be combined too. So if we define another animation, say one that changes background color.
                                We can combine it with the bouncy we already have.
                                The main difference here is that the animation properties in Fss takes a list of arguments, each element in the list corresponds to one animation."""
                            codeBlock [
                                "let backgroundColorFrames ="
                                "    keyframes"
                                "        ["
                                "            frame 0 [ BackgroundColor.red ]"
                                "            frame 30 [ BackgroundColor.green ]"
                                "            frame 60 [ BackgroundColor.blue ]"
                                "            frame 100 [ BackgroundColor.red ]"
                                "        ]"
                                "let bouncyColor ="
                                "    fss"
                                "        ["
                                "            AnimationName.Names [ bounceFrames; backgroundColorFrames ]"
                                "            AnimationDuration.Values [ sec 1.0; sec 5.0 ]"
                                "            AnimationTimingFunction.Values [ TimingFunctionType.EaseInOut; TimingFunctionType.Ease ]"
                                "            AnimationIterationCount.Values [ AnimationType.Infinite; CssInt 3 ]"
                                "        ]"]
                            div [ ClassName bouncyColor ] [ str "Bouncy color" ]

                        ]

                ]

        let Combinators =
            let borders =
                [
                    BorderStyle.Solid
                    BorderColor.black
                    BorderWidth' (px 1)
                ]
            let combinatorStyle =
                fss
                    [
                        Before [ Color.black; Content.Value "(" ]
                        After [ Color.black; Content.Value ")" ]
                        Color.red
                    ]
            let descendantCombinator =
                fss
                    [
                        yield! borders
                        ! Html.P [ Color.red ]
                    ]
            let childCombinator =
                fss
                    [
                        yield! borders
                        !> Html.P [ Color.red ]

                    ]
            let directCombinator =
                fss
                    [
                        !+ Html.P [ Color.red ]
                    ]
            let adjacentCombinator =
                fss
                    [
                        !~ Html.P [ Color.red ]
                    ]


            article []
                [
                    h2 [] [ str "Combinators" ]
                    div [ ClassName multilineText ]
                        [
                            str """Combinators can be used when you want to style something depending on selector relationships.
                            There are 4 combinators all of them supported by Fss."""
                            ul []
                                [
                                    li []
                                        [
                                            h3 []
                                                [
                                                    str "Descendant "
                                                    span [ ClassName combinatorStyle ] [ str "! space" ]
                                                ]
                                            str """This combinator allows you to select specific selectors within a css block.
                                            For example if we want to make all paragraphs within a div be red, we can do the following:"""
                                            codeBlock [  "let redParagraphs = fss [ ! Html.P [ Color.red ] ]"
                                                         "div [ ClassName redParagraphs ]"
                                                         "   ["
                                                         "       p [] [ str \"Text in a paragraph and therefore red\"]"
                                                         "       str \"Text outside of paragraph\""
                                                         "       div [] [ p [] [ str \"Text in paragraph in div and red\" ] ]"
                                                         "   ]" ]
                                            str """which gives us: """
                                            div [ ClassName descendantCombinator ]
                                                [
                                                    p [] [ str "Text in a paragraph and therefore red"]
                                                    str "Text outside of paragraph"
                                                    div [] [ p [] [ str "Text in paragraph in div and red" ] ]
                                                ]
                                        ]
                                    li []
                                        [
                                            h3 []
                                                [
                                                    str "Child"
                                                    span [ ClassName combinatorStyle ] [ str "!>" ]
                                                ]
                                            str """While descendants hit on all of the selector within the css block, child will only select direct descendants. I.E one level deep.
                                            So if we copy the same example from above but use the child combinator instead we get: """
                                            codeBlock [  "let childCombinator = fss [ !> Html.P [ Color.red ] ]"
                                                         "div [ ClassName childCombinator ]"
                                                         "   ["
                                                         "       p [] [ str \"Text in a paragraph and therefore red\"]"
                                                         "       str \"Text outside of paragraph\""
                                                         "       div [] [ p [] [ str \"Text in paragraph in div and not red\" ] ]"
                                                         "   ]" ]
                                            str """which gives us: """
                                            div [ ClassName childCombinator ]
                                                [
                                                    p [] [ str "Text in a paragraph and therefore red"]
                                                    str "Text outside of paragraph"
                                                    div [] [ p [] [ str "Text in paragraph in div and not red" ] ]
                                                ]
                                        ]
                                    li []
                                        [
                                            h3 []
                                                [
                                                    str "Adjacent sibling"
                                                    span [ ClassName combinatorStyle ] [ str "!+" ]
                                                ]
                                            str """This combinator selects the element directly after the "main" element.
                                            So if we do:"""

                                            codeBlock [  "let directCombinator = fss [ !+ Html.P [ Color.red ] ]"
                                                         "div []"
                                                         "  ["
                                                         "      div [ ClassName directCombinator ] [ p [] [ str \"Text in paragraph in div\" ] ]"
                                                         "      p [] [ str \"Text in a paragraph and after the div with the combinator so is red\"]"
                                                         "      p [] [ str \"Text in a paragraph but not after div with the combinator so is not red\"]"
                                                         "   ]" ]
                                            str """we get: """
                                            div [ ClassName (fss borders)]
                                                [
                                                    div [ ClassName directCombinator ] [ p [] [ str "Text in paragraph in div " ] ]
                                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                                    p [] [ str "Text in a paragraph but not after div with the combinator so is not red"]
                                                ]

                                        ]
                                    li []
                                        [
                                            h3 []
                                                [
                                                    str "General sibling"
                                                    span [ ClassName combinatorStyle ] [ str "!~" ]
                                                ]
                                            str """The general sibling combinator is similar to the adjacent one. But instead of selecting only 1 sibling, it selects them all."""
                                            codeBlock [  "let adjacentCombinator = fss [ !+ Html.P [ Color.red ] ]"
                                                         "div []"
                                                         "  ["
                                                         "      div [ ClassName adjacentCombinator ] [ p [] [ str \"Text in paragraph in div\" ] ]"
                                                         "      p [] [ str \"Text in a paragraph and after the div with the combinator so is red\"]"
                                                         "      p [] [ str \"Text in a paragraph but not after div with the combinator so is not red\"]"
                                                         "   ]" ]
                                            str """we get: """
                                            div [ ClassName (fss borders)]
                                                [
                                                    div [ ClassName adjacentCombinator ] [ p [] [ str "Text in paragraph in div " ] ]
                                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                                    p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
                                                    div [] [p [] [ str "Text in a paragraph inside another div, paragraph is not directly after div with the combinator so is not red"]]
                                                ]
                                        ]
                                ]

                            str "If you want some more information about combinators or where these examples come from you can look "
                            a [ Href "https://blog.logrocket.com/what-you-need-to-know-about-css-combinators/" ] [ str "here" ]
                            str "."
                        ]
                ]

        let mediaQueries =
            let mediaQueryExamples =
                fss
                    [
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
                                Transform.Rotate(deg 45.0)
                                BackgroundColor.red
                            ]

                        MediaQuery
                            [ Media.Orientation Media.Landscape]
                            [ Color.green; FontSize.Value (px 28)]
                    ]

            article []
                [
                    h2 []
                        [
                            str "Media queries"
                        ]
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
                                                "                   Transform.Rotate(deg 45.0)"
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
                fss [ ListStyleType' mozillaExampleCounter ]

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
            Import.Url "https://fonts.googleapis.com/css2?family=Amatic+SC"
            let amaticStyle =
                fss
                    [
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

            let droidSerif = fss [ FontFamily.Font droidSerifFont ]

            let droidSerifBold =
                fss
                    [
                        FontFamily.Font droidSerifFont
                        FontWeight.Bold
                    ]

            let moderna = fss [ FontFamily.Font modernaFont ]


            article []
                [
                    h3 [] [ str "Import" ]
                    div [ ClassName multilineText ]
                        [
                            codeBlock [ "Import.Url \"https://fonts.googleapis.com/css2?family=Amatic+SC\""
                                        "let amaticStyle ="
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
                        yield! box
                        BackgroundImage.LinearGradient(CSSColor.Hex "e66465", CSSColor.Hex "9198e5")
                    ]
            let linearGradientStyle2 =
                fss
                    [
                        yield! box
                        BackgroundImage.LinearGradient(turn 0.25,
                                                       [CSSColor.Hex "3f87a6" :> IColorStop
                                                        CSSColor.Hex "ebf8e1" :> IColorStop
                                                        CSSColor.Hex "f69d3c" :> IColorStop])
                    ]
            let linearGradientStyle3 =
                fss
                    [
                        yield! box
                        BackgroundImage.LinearGradient(ToLeft,
                                                       [
                                                           CSSColor.Hex "333" :> IColorStop
                                                           stop (CSSColor.Hex "333") (pct 50)
                                                           stop (CSSColor.Hex "eee") (pct 75)
                                                           stop (CSSColor.Hex "333") (pct 75)
                                                       ])
                    ]
            let repeatingLinearGradientStyle1 =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingLinearGradient(ToLeft,
                                                       [
                                                           CSSColor.Hex "e66465" :> IColorStop
                                                           stop (CSSColor.Hex "e66465") (px 20)
                                                           stop (CSSColor.Hex "9198e5") (px 20)
                                                           stop (CSSColor.Hex "9198e5") (px 25)
                                                       ])
                    ]
            let repeatingLinearGradientStyle2 =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingLinearGradient(deg 45.,
                                                       [
                                                           CSSColor.Hex "3f87a6" :> IColorStop
                                                           stop (CSSColor.Hex "ebf8e1") (px 15)
                                                           stop (CSSColor.Hex "f69d3c") (px 20)
                                                       ])
                    ]
            let radialGradientStyle1 =
                fss
                    [
                        yield! box
                        BackgroundImage.RadialGradient(CSSColor.Hex "e66465", CSSColor.Hex "9198e5")
                    ]
            let radialGradientStyle2 =
                fss
                    [
                        yield! box
                        BackgroundImage.RadialGradient(ClosestSide, [CSSColor.Hex "3f87a6" :> IColorStop; CSSColor.Hex "ebf8e1" :> IColorStop; CSSColor.Hex "f69d3c" :> IColorStop])
                    ]
            let radialGradientStyle3 =
                fss
                    [
                        yield! box
                        BackgroundImage.RadialGradient(
                            CircleAt <| ImagePosition.Percent(pct 100),
                            [CSSColor.Hex "333" :> IColorStop
                             stop (CSSColor.Hex "333") (pct 50)
                             stop (CSSColor.Hex "eee") (pct 75)
                             stop (CSSColor.Hex "333") (pct 75) ])
                    ]
            let repeatingRadialGradientStyle1 =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(CSSColor.Hex "e66465", stop (CSSColor.Hex "9198e5") (pct 20))
                    ]
            let repeatingRadialGradientStyle2 =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(ClosestSide, [CSSColor.Hex "3f87a6" :> IColorStop; CSSColor.Hex "ebf8e1" :> IColorStop; CSSColor.Hex "f69d3c" :> IColorStop])
                    ]
            let repeatingRadialGradientStyle3 =
                fss
                    [
                        yield! box
                        BackgroundImage.RepeatingRadialGradient(
                            CircleAt <| ImagePosition.Percent(pct 100),
                            [CSSColor.Hex "333" :> IColorStop
                             stop (CSSColor.Hex "333") (px 10)
                             stop (CSSColor.Hex "eee") (px 10)
                             stop (CSSColor.Hex "eee") (px 20) ])
                    ]

            article []
                [
                    h2 [] [ str "Background images" ]
                    div [ ClassName multilineText ]
                        [
                            h3 [] [ str "Linear gradient" ]
                            codeBlock ["let linearGradientStyle1 = fss [ BackgroundImage.LinearGradient(CSSColor.Hex \"e66465\", CSSColor.Hex \"9198e5\") ]"
                                       "let linearGradientStyle2 ="
                                       "   fss"
                                       "       ["
                                       "           BackgroundImage.LinearGradient(turn 0.25,"
                                       "                                          [CSSColor.Hex \"3f87a6\" :> IColorStop"
                                       "                                           CSSColor.Hex \"ebf8e1\" :> IColorStop"
                                       "                                           CSSColor.Hex \"f69d3c\" :> IColorStop])"
                                       "       ]"
                                       "let linearGradientStyle3 ="
                                       "   fss"
                                       "       ["
                                       "           BackgroundImage.LinearGradient(ToLeft,"
                                       "                                          ["
                                       "                                             CSSColor.Hex \"333\" :> IColorStop"
                                       "                                              stop (CSSColor.Hex \"333\") (pct 50)"
                                       "                                              stop (CSSColor.Hex \"eee\") (pct 75)"
                                       "                                              stop (CSSColor.Hex \"333\") (pct 75)"
                                       "                                          ])"
                                       "       ]"]

                            div [ ClassName (fss [ Display.Flex ]) ]
                                [
                                    div [ClassName linearGradientStyle1 ] []
                                    div [ClassName linearGradientStyle2 ] []
                                    div [ClassName linearGradientStyle3 ] []
                                ]
                            h3 [] [ str "Repeating Linear gradient" ]
                            codeBlock [ "let repeatingLinearGradientStyle1 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RepeatingLinearGradient(ToLeft,"
                                        "                                           ["
                                        "                                               CSSColor.Hex \"e66465\" :> IColorStop"
                                        "                                               stop (CSSColor.Hex \"e66465\") (px 20)"
                                        "                                               stop (CSSColor.Hex \"9198e5\") (px 20)"
                                        "                                               stop (CSSColor.Hex \"9198e5\") (px 25)"
                                        "                                           ])"
                                        "        ]"
                                        "let repeatingLinearGradientStyle2 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RepeatingLinearGradient(deg 45.,"
                                        "                                           ["
                                        "                                               CSSColor.Hex \"3f87a6\" :> IColorStop"
                                        "                                               stop (CSSColor.Hex \"ebf8e1\") (px 15)"
                                        "                                               stop (CSSColor.Hex \"f69d3c\") (px 20)"
                                        "                                           ])"
                                        "        ]"]
                            div [ ClassName (fss [ Display.Flex ]) ]
                                [
                                    div [ClassName repeatingLinearGradientStyle1 ] []
                                    div [ClassName repeatingLinearGradientStyle2 ] []
                                ]
                            h3 [] [ str "Radial gradient" ]

                            codeBlock [ "let radialGradientStyle1 = fss [ BackgroundImage.RadialGradient(CSSColor.Hex \"e66465\", CSSColor.Hex \"9198e5\") ]"
                                        "let radialGradientStyle2 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RadialGradient(ClosestSide, [CSSColor.Hex \"3f87a6\" :> IColorStop; CSSColor.Hex \"ebf8e1\" :> IColorStop; CSSColor.Hex \"f69d3c\" :> IColorStop])"
                                        "        ]"
                                        "let radialGradientStyle3 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RadialGradient("
                                        "                CircleAt <| ImagePosition.Percent(pct 100),"
                                        "                [CSSColor.Hex \"333\" :> IColorStop"
                                        "                 stop (CSSColor.Hex \"333\") (pct 50)"
                                        "                 stop (CSSColor.Hex \"eee\") (pct 75)"
                                        "                 stop (CSSColor.Hex \"333\") (pct 75) ])"
                                        "        ]"]

                            div [ ClassName (fss [ Display.Flex ]) ]
                                [
                                    div [ClassName radialGradientStyle1 ] []
                                    div [ClassName radialGradientStyle2 ] []
                                    div [ClassName radialGradientStyle3 ] []
                                ]
                            h3 [] [ str "Repeating radial gradient" ]
                            codeBlock [ "let repeatingRadialGradientStyle1 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RepeatingRadialGradient(CSSColor.Hex \"e66465\", stop (CSSColor.Hex \"9198e5\") (pct 20))"
                                        "        ]"
                                        "let repeatingRadialGradientStyle2 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RepeatingRadialGradient(ClosestSide, [CSSColor.Hex \"3f87a6\" :> IColorStop; CSSColor.Hex \"ebf8e1\" :> IColorStop; CSSColor.Hex \"f69d3c\" :> IColorStop])"
                                        "        ]"
                                        "let repeatingRadialGradientStyle3 ="
                                        "    fss"
                                        "        ["
                                        "            BackgroundImage.RepeatingRadialGradient("
                                        "                CircleAt <| ImagePosition.Percent(pct 100),"
                                        "                [CSSColor.Hex \"333\" :> IColorStop"
                                        "                 stop (CSSColor.Hex \"333\") (px 10)"
                                        "                 stop (CSSColor.Hex \"eee\") (px 10)"
                                        "                 stop (CSSColor.Hex \"eee\") (px 20) ])"
                                        "        ]"]
                            div [ ClassName (fss [ Display.Flex ]) ]
                                [
                                    div [ClassName repeatingRadialGradientStyle1 ] []
                                    div [ClassName repeatingRadialGradientStyle2 ] []
                                    div [ClassName repeatingRadialGradientStyle3 ] []
                                ]
                        ]
                ]

        function
        | Overview -> overview
        | Installation -> installation
        | Philosophy -> philosophy
        | BasicUse -> basicUse
        | ConditionalStyling -> conditionalStyling
        | Pseudo -> pseudo
        | Composition -> composition
        | Labels -> labels
        | Transitions -> transitions
        | KeyframesAnimations -> keyframesAnimations
        | Combinators -> Combinators
        | MediaQueries -> mediaQueries
        | GlobalStyles  -> globalStyles
        | Counters -> counters
        | Fonts -> fonts
        | BackgroundImage -> backgroundImage

    let menuListItem example currentExample onClick =
        let buttonStyle =
            fss
                [
                    Border.None
                    if example = currentExample then
                       BackgroundColor.Hex "#29A9DF"
                       BorderRightColor.Hex "#0170BA"
                       BorderRightWidth' (px 3)
                       BorderRightStyle.Solid
                    else
                        BackgroundColor.transparent
                    Margin' (px 0)
                    Padding' (px 10)
                    Width' (px 200)
                    FontSize' (px 14)
                    TextAlign.Left
                    textFont
                    Cursor.Pointer
                    Hover
                        [
                            BackgroundColor.Hex "E0E0E0"
                        ]
                ]

        li []
            [
                button [ ClassName buttonStyle; OnClick onClick ]
                    [
                        str <| pageToString example
                    ]
            ]

    let header =
        let headerStyle =
            fss
                [
                    GridArea' (GridPosition.Ident "nav")
                    GridColumnEnd.Span 2
                    Color.white
                    BackgroundColor.Hex "#0170BA"
                    PaddingLeft' (px 10)
                    AlignItems.Center
                ]

        let headerText = fss [ headingFont ]

        header  [ ClassName headerStyle ] [ h2 [ ClassName headerText ] [ str "Fss" ] ]

    let menu model (dispatch: SetPage -> unit)=
        let menuStyle =
            fss
                [
                    GridArea' (GridPosition.Ident "menu")
                ]
        let menuList =
            fss
                [
                    ListStyleType.None
                    Margin' (px 0)
                    Padding' (px 0)
                    TextIndent' (px 0)
                ]
        let menuListItem' example = menuListItem example model.CurrentPage (fun _ -> dispatch <| SetPage example)
        aside [ ClassName menuStyle ]
            [
                ul [ ClassName menuList ]
                    [
                        menuListItem' Overview
                        menuListItem' Installation
                        menuListItem' Philosophy
                        menuListItem' BasicUse
                        menuListItem' ConditionalStyling
                        menuListItem' Pseudo
                        menuListItem' Composition
                        menuListItem' Labels
                        menuListItem' Transitions
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
                    GridArea' (GridPosition.Ident "content")
                    textFont
                ]
        section [ ClassName contentStyle ]
            [
                pageToContent model.CurrentPage
            ]

    let render (model: Model) (dispatch: SetPage -> unit) =
        let container =
            fss
                [
                    Display.Flex
                    JustifyContent.Center
                ]
        let grid =
            fss
                [
                    Display.Grid
                    GridGap' (px 10)
                    Height' (vh 100.)
                    Width' (pct 60)
                    MaxWidth' (pct 60)
                    GridTemplateColumns.Values [fr 0.15; fr 1.]
                    GridTemplateRows.Values [fr 0.05; fr 1.]
                    GridTemplateAreas.Value
                        [
                            [ "nav"; "nav" ]
                            [ "menu"; "content" ]
                        ]
                ]
        div [ ClassName container ]
            [
                div [ ClassName grid ]
                    [
                        header
                        menu model dispatch
                        content model
                    ]
            ]

    Program.mkSimple init update render
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run
