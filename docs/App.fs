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
        | New
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
        | BackgroundImages
        | Feliz
        | Svg

    type ButtonType =
        | Big
        | Small

    type Model = { CurrentPage: Page; Pages: Map<Page, string> }

    type Msg =
        | GetMarkdown of Page
        | GotMarkdown of Page * string
        | FailedGettingMarkdown of string

    let init page =
        let page = page |> Option.defaultValue Overview

        let requests =
            [ Overview |> GetMarkdown |> Cmd.ofMsg
              Installation |> GetMarkdown |> Cmd.ofMsg
              Philosophy |> GetMarkdown |> Cmd.ofMsg
              New |> GetMarkdown |> Cmd.ofMsg
              BasicUsage |> GetMarkdown |> Cmd.ofMsg
              ConditionalStyling |> GetMarkdown |> Cmd.ofMsg
              Pseudo |> GetMarkdown |> Cmd.ofMsg
              Composition |> GetMarkdown |> Cmd.ofMsg
              Labels |> GetMarkdown |> Cmd.ofMsg
              Transition |> GetMarkdown |> Cmd.ofMsg
              KeyframesAnimations |> GetMarkdown |> Cmd.ofMsg
              Combinators |> GetMarkdown |> Cmd.ofMsg
              MediaQueries |> GetMarkdown |> Cmd.ofMsg
              GlobalStyles |> GetMarkdown |> Cmd.ofMsg
              Counters |> GetMarkdown |> Cmd.ofMsg
              Fonts |> GetMarkdown |> Cmd.ofMsg
              BackgroundImages |> GetMarkdown |> Cmd.ofMsg
              Feliz |> GetMarkdown |> Cmd.ofMsg
              Svg |> GetMarkdown |> Cmd.ofMsg
            ]
        { CurrentPage = page; Pages = Map.empty; }, Cmd.batch requests

    let update (msg: Msg) (model: Model) =
        match msg with
        | GetMarkdown page ->
            let nextCommand =
                async {
                    let! (statusCode, response) = getMarkdown (Utilities.duToString page)

                    if statusCode = 200 then
                        return GotMarkdown (page, response)
                    else
                        return FailedGettingMarkdown "Unable to get markdown"
                }
            model, Cmd.OfAsync.result nextCommand
        | GotMarkdown (page, markdown) ->
            let pages = model.Pages.Add(page, markdown)
            { model with Pages = pages }, Cmd.none
        | FailedGettingMarkdown _ ->
            model, Cmd.none

    // Load font
    let headingFont = FontFamily.custom "Nunito"
    let textFont = FontFamily.custom "Raleway"

    // Colors
    let background = "E1E2E1"
    let textOnPrimary = "ffffff"
    let textOnSecondary = "000000"
    let primary = "606060"
    let primaryLight = "8d8d8d"
    let primaryDark = "363636"
    let secondary = "2979ff"
    let secondaryLight = "75a7ff"
    let secondaryDark = "004ecb"

    // Styles
    let multilineText =
        fss
            [
                Label' "Multi Line Text"
                WhiteSpace.preLine
                MarginBottom' (px 200)
            ]

    let pageToString =
        function
        | Overview -> "Overview"
        | Installation -> "Installation"
        | Philosophy -> "Philosophy"
        | New -> "New"
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
        | BackgroundImages -> "Background image"
        | Feliz -> "Feliz"
        | Svg -> "Svg"

    let pageToContent page currentMarkdown =

        let overview = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let installation = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let philosophy = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let ``new`` = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]

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
                        Content.value ""
                        Display.inlineBlock
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
                                   TransitionProperty.backgroundColor
                                   TransitionDuration' (sec 2.5)
                                   TransitionTimingFunction.ease
                                   Hover [ BackgroundColor.green ]
                               ]
                    let sizeAndColor =
                        fss
                            [
                                Label' "Size and Color"
                                Width' (px 40)
                                Height' (px 40)
                                BackgroundColor.yellowGreen
                                TransitionProperty.all
                                TransitionTimingFunction.linear
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
                            [ Transforms [ Transform.translate3D(px 0, px 0, px 0) ] ]
                        frames [40; 43]
                            [ Transforms [ Transform.translate3D(px 0, px -30, px 0) ] ]
                        frame 70
                            [ Transforms [ Transform.translate3D(px 0, px -15, px 0) ] ]
                        frame 90
                            [ Transforms [ Transform.translate3D(px 0, px -4, px 0) ] ]
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
                        AnimationTimingFunction.easeInOut
                        AnimationIterationCount.infinite
                    ]

            let bouncyColor =
                fss
                    [
                        Label' "Bouncy Color"
                        AnimationName.names [ bounceFrames; backgroundColorFrames ]
                        AnimationDuration.values [ sec 1.0; sec 5.0 ]
                        AnimationTimingFunction.values [ FssTypes.Animation.Timing.EaseInOut; FssTypes.Animation.Timing.Ease ]
                        AnimationIterationCount.values [ FssTypes.Animation.Infinite; FssTypes.CssInt 3 ]
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
                    BorderStyle.solid
                    BorderColor.black
                    BorderWidth' (px 1)
                ]
            let descendantCombinator =
                fss
                    [
                        Label' "Descendant"
                        yield! borders
                        ! FssTypes.Html.P [ Color.red ]
                    ]
            let childCombinator =
                fss
                    [
                        Label' "Child"
                        yield! borders
                        !> FssTypes.Html.P [ Color.red ]

                    ]
            let directCombinator =
                fss
                    [
                        Label' "Direct"
                        !+ FssTypes.Html.P [ Color.red ]
                    ]
            let adjacentCombinator =
                fss
                    [
                        Label' "Adjacent"
                        !~ FssTypes.Html.P [ Color.red ]
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
                            [ FssTypes.Media.MinHeight (px 700)]
                            [ BackgroundColor.pink ]

                        MediaQueryFor FssTypes.Media.Print
                            []
                            [
                                MarginTop' (px 200)
                                Transforms [ Transform.rotate(deg 45.0) ]
                                BackgroundColor.red
                            ]

                        MediaQuery
                            [ FssTypes.Media.Orientation FssTypes.Media.Landscape]
                            [ Color.green; FontSize.value (px 28)]
                    ]

            article []
                [
                    markdown [ Renderers renderers; Children currentMarkdown ]
                    div [ ClassName mediaQueryExamples] [ str "Changing height changes this thing"]
                ]

        let globalStyles =
            article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let counters =
            let mozillaExampleCounter =
                counterStyle
                    [
                        System.fixed'
                        Symbols.strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ"; "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ"; "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ"; "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ"; "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"]
                        Suffix.value " "
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
                        FontFamily.custom "Roboto, sans-serif"
                        CounterReset' indexCounter
                    ]
            let commonBefore =
                [
                    FontWeight' (FssTypes.CssInt 500)
                    Color.hex "48f"
                ]
            let commonStyle =
                [
                    Margin.value (px 0, px 0, px 1)
                    Padding.value (px 5, px 10)
                ]
            let count =
                fss
                    [
                        Label' "Count"
                        yield! commonStyle
                        CounterReset' subCounter
                        CounterIncrement' indexCounter
                        BackgroundColor.hex "#222426"
                        Before
                            [
                                yield! commonBefore
                                Content.counter(indexCounter,". ")
                            ]
                    ]
            let sub =
                fss
                    [
                        Label' "Sub"
                        yield! commonStyle
                        CounterIncrement' subCounter
                        TextIndent' (em 1.)
                        Color.hex "BDB7AF"
                        Before
                            [
                                yield! commonBefore
                                Content.counters([indexCounter; subCounter], [".";"."])
                                MarginRight' (px 5)
                            ]
                    ]

            article []
                [
                    markdown [ Renderers renderers; Children currentMarkdown ]
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
        let fonts =
            let amaticStyle =
                fss
                    [
                        Label' "Amatic Style"
                        FontFamily.custom "Amatic SC"
                        FontSize' (px 24)
                    ]

            let droidSerifFont =
                fontFaces "DroidSerif"
                    [
                        [
                            FontFace.source <| FssTypes.FontFace.UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf", FssTypes.FontFace.Truetype)
                            FontFace.weight FssTypes.Font.Bold
                            FontFace.style FssTypes.Normal
                        ]
                        [
                            FontFace.source <| FssTypes.FontFace.UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf", FssTypes.FontFace.Truetype)
                            FontFace.weight FssTypes.Normal
                            FontFace.style FssTypes.Normal
                        ]
                    ]

            let modernaFont =
                fontFace "moderna"
                    [
                        FontFace.sources
                            [
                                FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FssTypes.FontFace.Woff2)
                                FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FssTypes.FontFace.Woff)
                                FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FssTypes.FontFace.Truetype)
                                FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FssTypes.FontFace.Svg)
                            ]
                        FontFace.weight FssTypes.Normal
                        FontFace.style FssTypes.Normal
                    ]

            let droidSerif =
                fss
                    [
                        Label' "Droid Serif"
                        FontFamily.font droidSerifFont
                    ]

            let droidSerifBold =
                fss
                    [
                        Label' "Droid Serif Bold"
                        FontFamily.font droidSerifFont
                        FontWeight.bold
                    ]

            let moderna =
                fss
                    [
                        Label' "Moderna"
                        FontFamily.font modernaFont
                    ]

            article []
                [
                    markdown [ Renderers renderers; Children currentMarkdown ]
                    p [ ClassName amaticStyle ] [str """This font is Amatic SC, some nice text this huh?"""]
                    p [ ClassName droidSerif ] [ str "Droid serif" ]
                    p [ ClassName droidSerifBold ] [ str "Droid serif bold" ]
                    p [ ClassName moderna] [ str "Moderna" ]
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
                        BackgroundImage.linearGradient((deg 0.,
                                                        [ hex "e66465", pct 0
                                                          hex "9198e5", pct 100 ]))
                    ]
            let linearGradientStyle2 =
                fss
                    [
                        yield! box
                        Label' "Linear gradient style 2"
                        BackgroundImage.linearGradient((turn 0.25,
                                                        [hex "3f87a6", pct 0
                                                         hex "ebf8e1", pct 50
                                                         hex "f69d3c", pct 100]))
                    ]
            let linearGradientStyle3 =
                fss
                    [
                        yield! box
                        Label' "Linear gradient style 3"
                        BackgroundImage.linearGradient((deg 270.,
                                                        [ hex "333", pct 0
                                                          hex "333", pct 50
                                                          hex "eee", pct 75
                                                          hex "333", pct 75 ]))
                    ]
            let repeatingLinearGradientStyle1 =
                fss
                    [
                        yield! box
                        Label' "Repeating Linear gradient style 1"
                        BackgroundImage.repeatingLinearGradient((deg 0.,
                                                                 [ hex "e66465", px 0
                                                                   hex "e66465", px 20
                                                                   hex "9198e5", px 20
                                                                   hex "9198e5", px 25 ]))
                    ]
            let repeatingLinearGradientStyle2 =
                fss
                    [
                        yield! box
                        Label' "Repeating Linear gradient style 2"
                        BackgroundImage.repeatingLinearGradient((deg 45.,
                                                                 [ hex "3f87a6", px 0
                                                                   hex "ebf8e1", px 15
                                                                   hex "f69d3c", px 20 ]))
                    ]
            let repeatingLinearGradientsStyle3 =
                fss
                    [
                        yield! box
                        BackgroundImage.repeatingLinearGradients
                            [
                                deg 217.,
                                    [
                                        FssTypes.Color.Color.rgba 255 0 0 0.8, pct 0
                                        FssTypes.Color.Color.rgba 255 0 0 0.0, pct 70
                                    ]
                                deg 127.,
                                    [
                                        FssTypes.Color.Color.rgba 0 255 0 0.8, pct 0
                                        FssTypes.Color.Color.rgba 0 255 0 0.0, pct 70
                                    ]
                                deg 336.,
                                    [
                                        FssTypes.Color.Color.rgba 0 0 255 0.8, pct 0
                                        FssTypes.Color.Color.rgba 0 0 255 0.0, pct 70
                                    ]

                            ]
                    ]

            let radialGradientStyle1 =
                fss
                    [
                        yield! box
                        Label' "Radial Gradient style 1"
                        BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.FarthestCorner, pct 50, pct 50,
                                                       [ hex "e66465", pct 0
                                                         hex "9198e5", pct 100])
                    ]
            let radialGradientStyle2 =
                fss
                    [
                        Label' "Radial Gradient style 2"
                        yield! box
                        BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.ClosestSide, pct 50, pct 50,
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
                        BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.FarthestCorner, pct 100, pct 50,
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
                        BackgroundImage.repeatingRadialGradient(
                                FssTypes.Image.Ellipse, FssTypes.Image.FarthestCorner, pct 50, pct 50,
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
                        BackgroundImage.repeatingRadialGradient(
                            FssTypes.Image.Ellipse, FssTypes.Image.ClosestSide, pct 50, pct 50,
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
                        BackgroundImage.repeatingRadialGradient(
                                FssTypes.Image.Circle, FssTypes.Image.FarthestCorner, pct 100, pct 50,
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
                        BackgroundImage.conicGradient(deg 0., pct 50, pct 50,
                              [
                                  FssTypes.Color.Color.red, deg 0.
                                  FssTypes.Color.Color.orange, deg 90.
                                  FssTypes.Color.Color.yellow, deg 180.
                                  FssTypes.Color.Color.green, deg 270.
                                  FssTypes.Color.Color.blue, deg 360.
                              ])
                    ]
            let conicGradientStyle2 =
                fss
                    [
                        Label' "Conic gradient style 2"
                        yield! box
                        BackgroundImage.conicGradient(rad 3.1416, pct 10, pct 50,
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
                        BackgroundImage.conicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         FssTypes.Color.Color.red, deg 6.
                                                         FssTypes.Color.Color.orange, deg 6.
                                                         FssTypes.Color.Color.orange, deg 18.
                                                         FssTypes.Color.Color.yellow, deg 18.
                                                         FssTypes.Color.Color.yellow, deg 45.
                                                         FssTypes.Color.Color.green, deg 45.
                                                         FssTypes.Color.Color.green, deg 110.
                                                         FssTypes.Color.Color.blue, deg 110.
                                                         FssTypes.Color.Color.blue, deg 200.
                                                         FssTypes.Color.Color.purple, deg 200.
                                                      ])
                    ]
            let conicGradientStyle4 =
                fss
                    [
                        Label' "Conic gradient style 4"
                        yield! box
                        BorderRadius' <| px 200
                        BackgroundImage.conicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         FssTypes.Color.Color.yellow, deg (360. / 6.)
                                                         FssTypes.Color.Color.lime,   deg <| (360. / 6.) * 2.
                                                         FssTypes.Color.Color.blue,   deg <| (360. / 6.) * 3.
                                                         FssTypes.Color.Color.violet, deg <| (360. / 6.) * 4.
                                                         FssTypes.Color.Color.red,    deg <| (360. / 6.) * 5.
                                                         FssTypes.Color.Color.yellow, deg <| (360. / 6.) * 6.
                                                      ])
                    ]
            let repeatingConicGradientStyle =
                fss
                    [
                        Label' "Repeating conic gradient style"
                        yield! box
                        BackgroundSize.value(px 50, px 50)
                        BorderColor.black
                        BorderStyle.solid
                        BorderWidth' (px 1)
                        BackgroundImage.repeatingConicGradient(deg 0., pct 50, pct 50,
                                                      [
                                                         FssTypes.Color.Color.white, pct 0
                                                         FssTypes.Color.Color.white, pct 25
                                                         FssTypes.Color.Color.black, pct 25
                                                         FssTypes.Color.Color.black, pct 50
                                                      ])
                    ]

            article []
                [
                    let elements =
                        [ div [ ClassName (fss [ Label' "Flex 1"; Display.flex ]) ]
                            [
                                div [ClassName linearGradientStyle1 ] []
                                div [ClassName linearGradientStyle2 ] []
                                div [ClassName linearGradientStyle3 ] []
                            ]
                          div [ ClassName (fss [ Label' "Flex 2"; Display.flex ]) ]
                            [
                                div [ClassName repeatingLinearGradientStyle1 ] []
                                div [ClassName repeatingLinearGradientStyle2 ] []
                                div [ClassName repeatingLinearGradientsStyle3 ] []
                            ]
                          div [ ClassName (fss [ Label' "Flex 3"; Display.flex ]) ]
                            [
                                div [ClassName radialGradientStyle1 ] []
                                div [ClassName radialGradientStyle2 ] []
                                div [ClassName radialGradientStyle3 ] []
                            ]
                          div [ ClassName (fss [ Label' "Flex 4"; Display.flex ]) ]
                            [
                                div [ClassName repeatingRadialGradientStyle1 ] []
                                div [ClassName repeatingRadialGradientStyle2 ] []
                                div [ClassName repeatingRadialGradientStyle3 ] []
                            ]
                          div [ ClassName (fss [ Label' "Flex 1"; Display.flex ]) ]
                            [
                                div [ClassName conicGradientStyle1 ] []
                                div [ClassName conicGradientStyle2 ] []
                                div [ClassName conicGradientStyle3 ] []
                                div [ClassName conicGradientStyle4 ] []
                            ]
                          div [ ClassName (fss [ Label' "Flex 1"; Display.flex ]) ]
                            [
                                div [ClassName repeatingConicGradientStyle ] []
                            ]]

                    let title =
                        currentMarkdown.Split "##"
                        |> Seq.skip 1
                        |> Seq.head
                    let elements =
                        currentMarkdown.Split "###"
                        |> Seq.skip 1
                        |> Seq.map (fun x -> $"### {x}")
                        |> Seq.zip elements
                        |> Seq.map (fun (e, s) ->
                                fragment []
                                    [
                                        markdown [ Renderers renderers; Children s ]
                                        e
                                    ]
                            )

                    div []
                        [
                            markdown [ Renderers renderers; Children $"## {title}"]
                            yield! elements
                        ]
                ]
        let feliz = article [] [ markdown [ Renderers renderers; Children currentMarkdown ] ]
        let svg = article [] [
            markdown [ Renderers renderers; Children currentMarkdown]
            let logoAnimation =
                keyframes [
                    frame 100 [ StrokeDashoffset' [ 0 ] ]
                ]

            let logoStyle =
                fss [
                   Stroke.black
                   StrokeWidth' <| px 4
                   StrokeDashoffset' [ 1000 ]
                   StrokeDasharray' [ 1000 ]
                   AnimationName' logoAnimation
                   AnimationDuration' <| sec 5.
                   AnimationTimingFunction.linear
                   AnimationFillMode.forwards
                ]

            Logo.logo 256 256 logoStyle
        ]

        match page with
        | Overview -> overview
        | Installation -> installation
        | Philosophy -> philosophy
        | New -> ``new``
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
        | BackgroundImages -> backgroundImage
        | Feliz -> feliz
        | Svg -> svg

    let menuListItem example =
        let linkStyle =
            fss
                [
                    Position.relative
                    Width' <| px 200
                    Label' "Button Style"
                    TextDecoration.none
                    Padding' <| px 2
                    FontSize' <| px 14
                    VerticalAlign.middle
                    textFont
                ]

        a [ ClassName linkStyle; Href $"#{Utilities.duToKebab example}" ] [ str $"{pageToString example}" ]

    let header =
        let headerStyle =
            fss
                [
                    Label' "Header Style"
                    Color.white
                    BackgroundColor.hex primary
                    PaddingLeft' (px 10)
                    AlignItems.center
                ]

        let headerText =
            fss
                [
                    Label' "Header Text"
                    headingFont
                ]

        header  [ ClassName headerStyle ] [ h2 [ ClassName headerText ] [ str "Fss" ] ]

    let menu =
        let menu =
            fss [ Position.fixed'
                  Left' <| px 0
                  Top' <| px 0
                  Height' <| vh 100.
                  Width' <| pct 25
                  BackgroundColor.hex "#212731"
                  Display.flex
                  FlexDirection.column
                  AlignItems.center
                  PaddingTop' <| px 100
                ]
        let menuList =
            fss
                [ Label' "Menu List"
                  Display.flex
                  FlexDirection.column
                  ! FssTypes.Html.A [ Link [ Color.hex "#759DB2" ]
                                      Visited [ Color.hex "#759DB2" ]
                                      Hover [ Color.hex "#c7dae0" ]
                                    ]
                ]
        let heading =
            fss [ headingFont
                  Color.hex "#759DB2"
                ]
        let menuListItem' example = menuListItem example
        aside [ ClassName menu ]
            [
                Logo.logo 128 128 ""
                h1 [ ClassName heading ] [ str "Fss" ]
                div [ ClassName menuList ]
                    [
                        menuListItem' Overview
                        menuListItem' Installation
                        menuListItem' Philosophy
                        menuListItem' New
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
                        menuListItem' BackgroundImages
                        menuListItem' Feliz
                        menuListItem' Svg
                    ]
            ]

    let content model =
        let contentStyle =
            fss
                [ Label' "Content Style"
                  Position.absolute
                  textFont
                  Width' <| pct 66
                  Right' <| pct 0
                  Top' <| pct 0
                  PaddingTop' <| px 100
                  PaddingLeft' <| px 25
                  PaddingRight' <| px 100
                  BackgroundColor.hex "#181A1B"
                  Color.white
                ]
        section [ ClassName contentStyle ] [ pageToContent model.CurrentPage model.Pages.[model.CurrentPage] ]

    let render (model: Model) (_: Msg -> unit) =
        let contentStyle =
            fss
                [
                    Label' "Content style"
                    Display.flex
                    FlexDirection.row

                ]
        div [ ClassName contentStyle ]
            [
                menu
                if model.Pages.ContainsKey model.CurrentPage then
                    content model
            ]

    open Elmish.UrlParser

    let pageParser : Parser<_,_> =
        oneOf
            [ map Overview            (s <| Utilities.duToKebab Overview)
              map Installation        (s <| Utilities.duToKebab Installation)
              map Philosophy          (s <| Utilities.duToKebab Philosophy)
              map New                 (s <| Utilities.duToKebab New)
              map BasicUsage          (s <| Utilities.duToKebab BasicUsage)
              map ConditionalStyling  (s <| Utilities.duToKebab ConditionalStyling)
              map Pseudo              (s <| Utilities.duToKebab Pseudo)
              map Composition         (s <| Utilities.duToKebab Composition)
              map Labels              (s <| Utilities.duToKebab Labels)
              map Transition          (s <| Utilities.duToKebab Transition)
              map KeyframesAnimations (s <| Utilities.duToKebab KeyframesAnimations)
              map Combinators         (s <| Utilities.duToKebab Combinators)
              map MediaQueries        (s <| Utilities.duToKebab MediaQueries)
              map GlobalStyles        (s <| Utilities.duToKebab GlobalStyles)
              map Counters            (s <| Utilities.duToKebab Counters)
              map Fonts               (s <| Utilities.duToKebab Fonts)
              map BackgroundImages    (s <| Utilities.duToKebab BackgroundImages)
              map Feliz               (s <| Utilities.duToKebab Feliz)
              map Svg                 (s <| Utilities.duToKebab Svg)
            ]

    let urlUpdate (page: Page option) model =
        let page = page |> Option.defaultValue Overview

        { model with CurrentPage = page }, Cmd.none

    Program.mkProgram init update render
    |> Program.toNavigable (parseHash pageParser) urlUpdate
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run