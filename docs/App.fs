namespace Docs

module App =
    open Elmish
    open Elmish.React
    open Elmish.Navigation
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

    type Msg = Unit

    let init page =
        let page = page |> Option.defaultValue Overview
        { CurrentPage = page }, Cmd.none

    let update (msg: Msg) (model: Model) =
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
        let codeBlock =
            fss
                [
                    Label' "Code Block"
                    BackgroundColor.Hex "#2A2A2A"
                    Color.white
                    Padding' (px 20)
                ]
        pre [ ClassName codeBlock ] [ str (code |> String.concat "\n") ]

    let pageToContent =
        let imageStyle =
            fss
                [
                    Label' "Image Style"
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
                                Built atop the fantastic """
                            a [ Href "https://github.com/emotion-js/emotion" ] [ str "Emotion-js" ]
                            str " FSS allows you to have CSS as a first class citizen in your F# code and aims to support most of the CSS spec."
                        ]
                ]

        let installation =
            article []
                [
                    h2 [] [ str "Installation" ]
                    str "In order to use Fss you need to install the "
                    a [ Href "https://www.nuget.org/packages/fss-lib/" ] [ str "nuget" ]
                    str " package"
                    codeBlock [ "# nuget"
                                "dotnet add package Fss-lib"
                                ""
                                "# paket"
                                "paket add Fss-lib --project ./project/path" ]

                    str """And you need to install """
                    a [ Href "https://github.com/emotion-js/emotion" ] [ str "Emotion-js" ]
                    str """. Fss uses version 11 or greater"""
                    codeBlock [ "# npm"
                                "npm i @emotion/css"
                                ""
                                "# yarn"
                                "yarn add @emotion/css"]
                ]

        let philosophy =
            article []
                [
                    h2 [] [ str "Philosophy" ]
                    str "The main idea behind Fss is discoverable CSS. Write CSS in F# quick and easy."

                    str "There exists some quite good styling alternatives to F# already"
                    ul []
                        [
                            li [] [
                                a [ Href "https://fulma.github.io/Fulma/" ] [ str "Fulma"]
                                str " which is a really nice wrapper over Bulma"
                            ]
                            li []
                                [
                                    a [ Href "https://github.com/zanaptak/TypedCssClasses" ] [ str "TypedCssClasses" ]
                                    str " a type provider if you want to generate types from existing CSS or SCSS"
                                ]
                            li []
                                [
                                    str "Webpack configuration for CSS or SCSS"
                                ]
                        ]
                    div [ ClassName multilineText ]
                        [
                            str """Ultimately I believe you will find whatever solution that suits your needs best.

                            Writing css in your language has some nice benefits:"""
                            ul []
                                [
                                    li [] [ str "Types" ]
                                    li [] [ str "Declarative and maintainable styling." ]
                                    li [] [ str "Easy to set up and use." ]
                                    li [] [ str "Take advantage of nice F# syntax and features." ]
                                    li [] [ str "Scoping! Having local styles will not affect other stuff somewhere else." ]
                                    li [] [ str "Parameterize your styling." ]
                                ]
                        ]
                ]

        let basicUse =
            let borderStyle = fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)" ]
            article []
               [
                    h2 [] [ str "Basic usage" ]
                    div [ ClassName multilineText ]
                        [
                            str """The main function this library supplies is the function fss. It takes a list of CSS properties and returns a string.
                                This string is the classname you can give to your html tag.

                                Simply write the CSS you want in PascalCase and dot yourself into the method you want.
                                What is available are the typical options the property might provide.

                                For example if you want """
                            codeBlock ["text-decoration-color: white"]
                            str """ then you write"""
                            codeBlock [ "TextDecorationColor.white" ]

                            str """This works in nearly all cases and is the idiomatic way to write most things.
                                   However you sometimes also want to have the “right hand side” as a variable or parameter.
                                   In this case you can fallback on the .Value function, which every CSS property has and is how the library works behind the scenes.
                                Here is an example of that. """
                            codeBlock ["let myDecorationColor = CssColor.White"
                                       "fss [ TextDecorationColor.Value myDecorationColor ]"]
                            str """As this is something you might potentially want to do quite a bit there exists a shorthand which is TextDecorationColor'"""
                            codeBlock ["let myDecorationColor = CssColor.White"
                                       "fss [ TextDecorationColor' myDecorationColor ]"]
                            str """The .Value function is particularly useful when you wish to apply a function to a property. Like pixel size or percent, that does not exist as a member on the property you are trying to style."""

                            h3 [] [ str "Shorthands" ]
                            div [ ClassName multilineText ]
                                [
                                    str """I don't like shorthands so I haven't included them. In general I feel they make CSS more complicated than it needs to be..
                                    However as this project creates CSS and interacts with it, it has to deal with some of its shortcoming, like shorthands.

                                    Therefore the shorthands that are included are limited to ones where using inherit, initial, unset or none is natural. Like text-decoration.
                                    Resetting text-decoration would be  really annoying without it - having to go through each property resetting it.

                                    However if shorthands is something you really want to use, you can use the custom escape hatch to write them up in string.
                                    The escape hatch is a function that takes two string, a key and a value and attempts to make Css with it.
                                    For example if I want to set border with shorthand I can write:
                                    """
                                    codeBlock [ "fss"
                                                "[ Custom \"border\" \"4mm ridge rgba(170, 50, 220, .6)\" ]" ]

                                    str """Which has the following result"""
                                    div [ ClassName borderStyle ]
                                        [
                                            str "Border style made with custom escape hatch"
                                        ]
                                ]

                        ]
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
                    h2 [] [ str "Conditional styling" ]
                    str """If you want to style something conditionally you can use conditional or match expression

                        For example if you've defined a union type for your button sizes that looks like this: """
                    codeBlock [ "type ButtonSize ="
                                "   | Small"
                                "   | Big" ]
                    str "You could have a function that takes this ButtonSize as a parameter and spits out the styling you want."
                    codeBlock [ "let buttonStyle buttonType ="
                                "  fss  ["
                                "           match buttonType with"
                                "           | Big ->"
                                "               Height' (px 80)"
                                "               Width' (px 80)"
                                "           | Small ->"
                                "               Height' (px 40)"
                                "               Width' (px 40)"
                                "       ]" ]
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
                            div [ ClassName hoverStyle ] [ str "Hover me!" ]
                            h2 [] [ str "Pseudo-elements" ]

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
                            div [ ClassName beforeAndAfter ] [ str " Some content surrounded by stuff " ]
                        ]
                ]
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

                            div [ ClassName (fss baseStyle) ] [ str "This will be turquoise" ]
                            div [ ClassName (fss <| danger @ baseStyle)] [ str "This will be also be turquoise since the base styles overwrite the danger styles."]
                            div [ ClassName (fss <| baseStyle @ danger)] [ str "This will be red" ]
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

                    let styleWithoutLabel =
                        fss
                            [
                                Label' "Style Without Label"
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
                                           Label' "Color Transition"
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
                            div [ ClassName sizeAndColor ] [ ]
                        ]
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
                                        "                ["
                                        "                   transforms"
                                        "                       ["
                                        "                           Transform.Translate3D(px 0, px 0, px 0) ]"
                                        "                       ]"
                                        "                ]"
                                        "            frames [40; 43]"
                                        "                ["
                                        "                   transforms"
                                        "                       ["
                                        "                           Transform.Translate3D(px 0, px -30, px 0) ]"
                                        "                       ]"
                                        "                ]"
                                        "            frame 70"
                                        "                ["
                                        "                   transforms"
                                        "                       ["
                                        "                            Transform.Translate3D(px 0, px -15, px 0) ]"
                                        "                       ]"
                                        "                ]"
                                        "            frame 90"
                                        "                ["
                                        "                   transforms"
                                        "                       ["
                                        "                           Transform.Translate3D(px 0, px -4, px 0) ]"
                                        "                       ]"
                                        "                ]"
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

                            h2 [] [ str "Transforms" ]
                            str """Just a quick note on transforms. In Css it is easy to think that when you apply a transform Css expects just one transform
                            It works with one, but it is easier to think about transforms as accepting a list of transforms, now this list can have just one element.
                            I have also seen it as a mistake from people who don't know Css too well (I have made it myself), where combining transforms can be a bit of an issue.
                            For there reasons in Fss when you apply transforms it always expects a list, but otherwise works as you would expect.
                            """
                            codeBlock ["Transforms"
                                       "    ["
                                       "        Transform.RotateX <| deg 10."
                                       "        Transform.RotateY <| deg 15."
                                       "        Transform.Perspective <| px 20"
                                       "    ]"]
                        ]
                ]

        let Combinators =
            let borders =
                [
                    Label' "Borders"
                    BorderStyle.Solid
                    BorderColor.black
                    BorderWidth' (px 1)
                ]
            let combinatorStyle =
                fss
                    [
                        Label' "Combinator"
                        Before [ Color.black; Content.Value "(" ]
                        After [ Color.black; Content.Value ")" ]
                        Color.red
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
                                            str """While descendants hit on all of the selectors within the css block, child will only select direct descendants. I.E one level deep.
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
                    Label' "Content Style"
                    textFont
                ]
        section [ ClassName contentStyle ] [ pageToContent model.CurrentPage ]

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
                        content model
                    ]
            ]

    open Elmish.UrlParser

    let pageParser : Parser<_,_> =
        oneOf
            [ map Overview (s <| Utilities.duToKebab Overview)
              map Installation (s <| Utilities.duToKebab Installation)
              map Philosophy (s <| Utilities.duToKebab Philosophy)
              map BasicUse (s <| Utilities.duToKebab BasicUse)
              map ConditionalStyling (s <| Utilities.duToKebab ConditionalStyling)
              map Pseudo (s <| Utilities.duToKebab Pseudo)
              map Composition (s <| Utilities.duToKebab Composition)
              map Labels (s <| Utilities.duToKebab Labels)
              map Transitions (s <| Utilities.duToKebab Transitions)
              map KeyframesAnimations (s <| Utilities.duToKebab KeyframesAnimations)
              map Combinators (s <| Utilities.duToKebab Combinators)
              map MediaQueries (s <| Utilities.duToKebab MediaQueries)
              map GlobalStyles (s <| Utilities.duToKebab GlobalStyles)
              map Counters (s <| Utilities.duToKebab Counters)
              map Fonts (s <| Utilities.duToKebab Fonts)
              map BackgroundImage (s <| Utilities.duToKebab BackgroundImage)
            ]

    let urlUpdate (page: Page option) _ =
        let page = page |> Option.defaultValue Overview
        let model, _ = Some page |> init

        { model with CurrentPage = page }, Cmd.none

    Program.mkProgram init update render
    |> Program.toNavigable (parseHash pageParser) urlUpdate
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run