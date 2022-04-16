namespace Documentation

module App =
    open Fetch
    open Feliz
    open Feliz.Router
    open Fss

    open Pages
    open Store
    
    // Constants
    // Font families
    let nunito =
        fontFace "Nunito" [
            FontFace.Src.truetype "./fonts/Nunito-Regular.ttf"
            FontFace.FontDisplay.swap
        ]
    
    let raleway =
        fontFace "Raleway" [
            FontFace.Src.truetype "./fonts/Raleway-Regular.ttf"
            FontFace.FontDisplay.swap
        ]
        
    let grapeNuts =
        fontFace "GrapeNuts" [
            FontFace.Src.truetype "./fonts/GrapeNuts-Regular.ttf"
            FontFace.FontDisplay.swap
        ]
    
    let headingFont = FontFamily.value nunito
    let textFont = FontFamily.value raleway

    // Colors
    let sidebarBackgroundColor = "212731"
    let sidebarText = "759DB2"
    let sidebarHover = "c7dae0"
    let contentText = "e8e6e3"
    let contentLink = "50b8ec"

    type ButtonSize =
        | Small
        | Big

    [<ReactComponent>]
    let MenuItem (page: Page) =
        let _, dispatch = useStore ()   
        let pageString = pageToLinkString page

        Html.a [ prop.href $"#/page/{pageString}"
                 prop.text (Utilities.duToSpaced page)
                 prop.onClick (fun _ -> dispatch ToggleSidebar)
                 prop.fss [ Position.relative
                            Width.value (px 200)
                            Label "Menu link"
                            FontSize.value (px 14)
                            TextDecoration.none
                            VerticalAlign.middle
                            Padding.value (px 2)
                            textFont ] ]

    [<ReactComponent>]
    let NavBar () =
        let _, dispatch = useStore ()

        Html.nav [ prop.fss [ Position.fixed'
                              Left.value (px 0)
                              Top.value (pct -100)
                              Width.value (vw 100.)
                              Height.value (px 50)
                              BackgroundColor.hex sidebarBackgroundColor
                              Display.flex
                              AlignItems.center
                              ZIndex.value 10

                              TransitionProperty.top
                              TransitionTimingFunction.easeInOut
                              TransitionDuration.value (ms 500.)

                              Media.query [ Fss.Types.Media.MaxWidth <| px 1000 ] [
                                  Top.value (px 0)
                              ] ]
                   prop.children [ Html.div [ prop.fss [ Cursor.pointer ]
                                              prop.onClick (fun _ -> dispatch ToggleSidebar)
                                              prop.children [ Hamburger.hamburger 32 32 "" ] ] ] ]

    [<ReactComponent>]
    let Menu () =
        let store, _ = useStore ()
        
        Html.aside [ prop.fss [ Label "Menu"
                                Position.fixed'
                                Left.value (px 0)
                                Top.value (px 0)
                                Height.value (vh 100.)
                                Width.value (px 336)
                                BackgroundColor.hex sidebarBackgroundColor
                                Display.flex
                                FlexDirection.column
                                AlignItems.center
                                ZIndex.value 5
                                PaddingTop.value (px 100)

                                TransitionProperty.left
                                TransitionTimingFunction.easeInOut
                                TransitionDuration.value (ms 500.)
                                
                                Media.query [ Fss.Types.Media.MaxWidth <| px 1000 ] [
                                    if store.ShowSidebar then
                                        Left.value (pct 0)
                                    else
                                        Left.value (pct -100)
                                ]

                                // Following the menu is the article
                                // We need to animate the article as well as the menu when
                                // The following code block deals with that
                                // (parens added as Fantomas is acting up)
                                (!+Fss.Types.Html.Article)
                                    [ MarginLeft.value (px 400)
                                      TransitionProperty.marginLeft
                                      TransitionTimingFunction.easeInOut
                                      TransitionDuration.value (ms 500.)
                                      MaxWidth.value (pct 60)

                                      Media.query [ Fss.Types.Media.MaxWidth <| px 1000 ] [
                                          MarginLeft.value (px 0)
                                          MaxWidth.value (pct 100)

                                      ] ] ]

                     prop.children [ Logo.logo 128 128 ""
                                     Html.h1 [ prop.fss [ headingFont
                                                          Color.hex sidebarText ]
                                               prop.text "Fss" ]
                                     yield! (List.map MenuItem allPages) ] ]


    let rec markdownAndExamples (markdown: string) (examples: ReactElement list option) =
        let splitMarkdown =
            markdown.Split "<example/>"
            |> Seq.toList
            |> List.map Markdown.markdownDefaultRenderer

        match examples with
        | Some examples ->
            if List.length splitMarkdown > List.length examples then
                markdownAndExamples markdown (Some(examples @ [ Html.none ]))
            else
                List.zip splitMarkdown examples
                |> List.collect (fun (a, b) -> [ a; b ])
        | None -> splitMarkdown

    let Article (page: Page) =
        let store, dispatch = useStore ()

        let doc, setDoc =
            React.useState<Documentation option> None

        React.useEffect (
            (fun () ->
                match tryGetDocumentation store page with
                | None ->
                    promise {
                        let! response =
                            fetch
                                $"documentation/{page}.md"
                                []

                        let! text = response.text ()
                        let document = Documentation(page, text)
                        do dispatch <| AddDocument document
                        do setDoc (Some document)
                    }
                    |> Promise.start
                | Some documentation -> setDoc (Some documentation)),
            [| page :> obj |]
        )

        match page with
        | Unknown ->
            Html.div [ prop.text "Unknown"
                       prop.fss [ PaddingTop.value (px 100) ] ]
        | NotFound ->
            Html.div [ prop.text "Not Found"
                       prop.fss [ PaddingTop.value (px 100) ] ]
        | _ ->
            match doc with
            | None -> Html.text "Laster"
            | Some (_, markdown) ->
                let examples =
                    match page with
                    | Overview -> None
                    | Installation -> None
                    | Philosophy -> None
                    | BasicUsage ->
                        let borderStyle =
                            fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)" ]

                        Some [ Html.div [ prop.className borderStyle
                                          prop.text "Border style made with custom escape hatch" ] ]
                    | ConditionalStyling ->
                        let buttonStyle buttonType =
                            fss [ match buttonType with
                                  | Big ->
                                      Height.value (px 80)
                                      Width.value (px 80)
                                  | Small ->
                                      Height.value (px 40)
                                      Width.value (px 40) ]

                        Some [ Html.div [ prop.children [ Html.button [ prop.className (buttonStyle Small)
                                                                        prop.text "Small" ]

                                                          Html.button [ prop.className (buttonStyle Big)
                                                                        prop.text "Big" ] ] ] ]
                    | Pseudo ->
                        let hoverStyle =
                            fss [ Label "Hover Style"
                                  Padding.value (px 40)
                                  Width.value (px 100)
                                  BackgroundColor.orangeRed
                                  FontSize.value (px 20)
                                  BorderRadius.value (px 5)
                                  Color.white
                                  Hover [ BackgroundColor.chartreuse
                                          Color.black ] ]

                        let beforeAndAfter =
                            let beforeAndAfter =
                                [ Content.value ""
                                  Display.inlineBlock
                                  BackgroundColor.orangeRed
                                  Width.value (px 10)
                                  Height.value (px 10) ]

                            fss [ Label "Before And After"
                                  Before beforeAndAfter
                                  After beforeAndAfter ]

                        Some [ Html.div [ prop.className hoverStyle
                                          prop.text "Hover me!" ]
                               Html.div [ prop.className beforeAndAfter
                                          prop.text " Some content surrounded by stuff " ] ]
                    | Composition ->
                        let baseStyle =
                            [ Label "Base Style"
                              BackgroundColor.darkGreen
                              Color.turquoise ]

                        let danger = [ Label "Danger"; Color.red ]

                        Some [ Html.div [ Html.div [ prop.className (fss baseStyle)
                                                     prop.text "This will be turquoise" ]

                                          Html.div [ prop.className (fss <| danger @ baseStyle)
                                                     prop.text
                                                         "This will be also be turquoise since the base styles overwrite the danger styles." ]

                                          Html.div [ prop.className (fss <| baseStyle @ danger)
                                                     prop.text "This will be red" ] ] ]
                    | Labels ->
                        let styleWithoutLabel = fss [ Color.red ]

                        let styleWithLabel =
                            fss [ Label "Style With Label"
                                  Color.hotPink
                                  Label "HotPinkLabel" ]

                        Some [ Html.div [ Html.div [ prop.className styleWithoutLabel
                                                     prop.text styleWithoutLabel ]
                                          Html.div [ prop.className styleWithLabel
                                                     prop.text styleWithLabel ] ] ]
                    | Transition ->
                        let colorTransition =
                            fss [ Label "Color Transition"
                                  BackgroundColor.red
                                  TransitionProperty.backgroundColor
                                  TransitionDuration.value (sec 2.5)
                                  TransitionTimingFunction.ease
                                  Hover [ BackgroundColor.green ] ]

                        let sizeAndColor =
                            fss [ Label "Size and Color"
                                  Width.value (px 40)
                                  Height.value (px 40)
                                  BackgroundColor.yellowGreen
                                  TransitionProperty.all
                                  TransitionTimingFunction.linear
                                  TransitionDuration.value (ms 500.)
                                  Hover [ BorderRadius.value (pct 100)
                                          BackgroundColor.orangeRed ] ]

                        Some [ Html.div [ prop.className colorTransition
                                          prop.text "Hover me" ]
                               Html.div [ prop.className sizeAndColor ] ]
                    | KeyframesAnimations ->
                        let bounceFrames =
                            keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                                            Transform.value [ Transform.translate3D (px 0, px 0, px 0) ]
                                        ]
                                        frames [ 40; 43 ] [
                                            Transform.value [ Transform.translate3D (px 0, px -30, px 0) ]
                                        ]
                                        frame 70 [ Transform.value [ Transform.translate3D (px 0, px -15, px 0) ] ]
                                        frame 90 [ Transform.value [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

                        let backgroundColorFrames =
                            keyframes [ frame 0 [ BackgroundColor.red ]
                                        frame 30 [ BackgroundColor.green ]
                                        frame 60 [ BackgroundColor.blue ]
                                        frame 100 [ BackgroundColor.red ] ]

                        let bounceAnimation =
                            fss [ Label "Bounce Animation"
                                  AnimationName.value bounceFrames
                                  AnimationDuration.value (sec 1.0)
                                  AnimationTimingFunction.easeInOut
                                  AnimationIterationCount.infinite ]

                        let bouncyColor =
                            fss [ Label "Bouncy Color"
                                  AnimationName.value [ bounceFrames
                                                        backgroundColorFrames ]
                                  AnimationDuration.value [ sec 1.0
                                                            sec 5.0 ]
                                  AnimationTimingFunction.value [ Fss.Types.TimingFunction.EaseInOut
                                                                  Fss.Types.TimingFunction.Ease ]
                                  AnimationIterationCount.value [ Fss.Types.Animation.Infinite
                                                                  Fss.Types.Animation.IterationCount.Value 3 ] ]

                        Some [ Html.div [ Html.div [ prop.className bounceAnimation
                                                     prop.text "Bouncy bounce" ]
                                          Html.div [ prop.className bouncyColor
                                                     prop.text "Bouncy color" ] ] ]

                    | Combinators ->
                        let descendantCombinator =
                            fss [ Label "Descendant"
                                  ! Fss.Types.Html.P [ Color.red ] ]

                        let childCombinator =
                            fss [ Label "Child"
                                  !> Fss.Types.Html.P [ Color.red ]

                                   ]

                        let directCombinator =
                            fss [ Label "Direct"
                                  !+ Fss.Types.Html.P [ Color.red ] ]

                        let adjacentCombinator =
                            fss [ Label "Adjacent"
                                  !~ Fss.Types.Html.P [ Color.red ] ]

                        Some [

                               Html.div [ prop.className descendantCombinator
                                          prop.children [ Html.p "Text in a paragraph and therefore red"
                                                          Html.text "Text outside of paragraph"
                                                          Html.div [ Html.p "Text in paragraph in div and red" ] ] ]
                               Html.div [ prop.className childCombinator
                                          prop.children [ Html.p "Text in a paragraph and therefore red"
                                                          Html.text "Text outside of paragraph"
                                                          Html.div [ Html.p "Text in paragraph in div and not red" ] ] ]
                               Html.div [ 
                                          prop.children [ Html.div [ prop.className directCombinator
                                                                     prop.children [ Html.p [ Html.text "Text in paragraph in div " ] ] ]
                                                          Html.p
                                                              "Text in a paragraph and after the div with the combinator so is red"
                                                          Html.p
                                                              "Text in a paragraph but not after div with the combinator so is not red" ] ]
                               Html.div [ 
                                          prop.children [ Html.div [ prop.className adjacentCombinator
                                                                     prop.children [ Html.p [ prop.text
                                                                                                  "Text in paragraph in div " ] ] ]
                                                          Html.p
                                                              "Text in a paragraph and after the div with the combinator so is red"
                                                          Html.p
                                                              "Text in a paragraph and after the div with the combinator so is red"
                                                          Html.div [ Html.p
                                                                         "Text in a paragraph inside another div, paragraph is not directly after div with the combinator so is not red" ] ] ] ]
                    | MediaQueries ->
                        let mediaQueryExamples =
                            fss [ Label "Media query examples"
                                  Width.value (px 200)
                                  Height.value (px 200)
                                  BackgroundColor.blue

                                  Media.query [ Fss.Types.Media.MinWidth(px 700) ] [
                                      BackgroundColor.pink
                                      Color.orangeRed
                                  ]

                                  Media.queryFor
                                      Fss.Types.Media.Print
                                      []
                                      [ MarginTop.value (px 200)
                                        Transform.value [ Transform.rotate (deg 45.0) ]
                                        BackgroundColor.red ]

                                  Media.query [ Fss.Types.Media.Orientation Fss.Types.Media.Landscape ] [
                                      Color.green
                                      BackgroundColor.orangeRed
                                      FontSize.value (px 28)
                                  ] ]

                        Some [ Html.div [ prop.className mediaQueryExamples
                                          prop.text "Changing width changes me" ] ]
                    | GlobalStyles -> None
                    | Counters ->
                        let mozillaExampleCounter =
                            counterStyle [ System.fixed'
                                           Symbols.value [ "Ⓐ"
                                                           "Ⓑ"
                                                           "Ⓒ"
                                                           "Ⓓ"
                                                           "Ⓔ"
                                                           "Ⓕ"
                                                           "Ⓖ"
                                                           "Ⓗ"
                                                           "Ⓘ"
                                                           "Ⓙ"
                                                           "Ⓚ"
                                                           "Ⓛ"
                                                           "Ⓜ"
                                                           "Ⓝ"
                                                           "Ⓞ"
                                                           "Ⓟ"
                                                           "Ⓠ"
                                                           "Ⓡ"
                                                           "Ⓢ"
                                                           "Ⓣ"
                                                           "Ⓤ"
                                                           "Ⓥ"
                                                           "Ⓦ"
                                                           "Ⓧ"
                                                           "Ⓨ"
                                                           "Ⓩ" ]
                                           Suffix.value " " ]

                        let mozillaExampleStyle =
                            fss [ Label "Mozilla Example Style"
                                  ListStyleType.value mozillaExampleCounter ]

                        let indexCounter = counterStyle [
                            CounterLabel "indexCounter"
                        ]
                        let subCounter = counterStyle [
                            CounterLabel "subCounter"
                        ]

                        let sectionStyle =
                            fss [ Label "Section"
                                  FontFamily.value "Roboto, sans-serif"
                                  CounterReset.value indexCounter ]

                        let commonBefore =
                            [ FontWeight.value 500
                              Color.hex "48f" ]

                        let commonStyle =
                            [ Margin.value (px 0, px 0, px 1)
                              Padding.value (px 5, px 10) ]

                        let count =
                            fss [ Label "Count"
                                  yield! commonStyle
                                  CounterReset.value subCounter
                                  CounterIncrement.value indexCounter
                                  BackgroundColor.hex "#222426"
                                  Before [ yield! commonBefore
                                           Content.counter (indexCounter, ". ") ] ]

                        let sub =
                            fss [ Label "Sub"
                                  yield! commonStyle
                                  CounterIncrement.value subCounter
                                  TextIndent.value (em 1.)
                                  Color.hex "BDB7AF"
                                  Before [ yield! commonBefore
                                           Content.counter ([ indexCounter; subCounter ], [ "."; "." ])
                                           MarginRight.value (px 5) ] ]

                        Some [ Html.ul [ prop.className mozillaExampleStyle
                                         prop.children [ Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five"
                                                         Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five"
                                                         Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five"
                                                         Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five"
                                                         Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five"
                                                         Html.li "one"
                                                         Html.li "two"
                                                         Html.li "three"
                                                         Html.li "four"
                                                         Html.li "five" ] ]
                               Html.section [ prop.className sectionStyle
                                              prop.children [ Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className count
                                                                       prop.text "Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ]
                                                              Html.p [ prop.className sub
                                                                       prop.text "Sub-Item" ] ] ] ]
                    | Fonts ->
                        let grapeNutsStyle =
                            fss [ Label "Grape Nuts Style"
                                  FontFamily.value grapeNuts
                                  FontSize.value (px 24) ]

                        let droidSerifFont =
                            fontFaces
                                "DroidSerif"
                                [ [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf")
                                    FontFace.FontWeight.bold
                                    FontFace.FontStyle.normal
                                    FontFace.FontDisplay.swap ]
                                  [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf")
                                    FontFace.FontWeight.normal
                                    FontFace.FontStyle.normal
                                    FontFace.FontDisplay.swap ] ]

                        let modernaFont =
                            fontFace
                                "moderna"
                                [ FontFace.Src.sources
                                      [ Fss.Types.FontFace.Woff2 "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2"
                                        Fss.Types.FontFace.Woff "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff"
                                        Fss.Types.FontFace.Truetype "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf"
                                        Fss.Types.FontFace.Svg "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg" ]
                                  FontFace.FontWeight.normal
                                  FontFace.FontStyle.normal
                                  FontFace.FontDisplay.swap ]

                        let droidSerif =
                            fss [ Label "Droid Serif"
                                  FontFamily.value droidSerifFont ]

                        let droidSerifBold =
                            fss [ Label "Droid Serif Bold"
                                  FontFamily.value droidSerifFont
                                  FontWeight.bold ]

                        let moderna =
                            fss [ Label "Moderna"
                                  FontFamily.value modernaFont ]

                        Some [ Html.p [ prop.className grapeNutsStyle
                                        prop.text "This font is Grape Nuts, some nice text this huh?" ]
                               Html.div [ Html.p [ prop.text "Droid serif"
                                                   prop.className droidSerif ]
                                          Html.p [ prop.text "Droid serif bold"
                                                   prop.className droidSerifBold
                                                    ]
                                          Html.p [ prop.text "Moderna"
                                                   prop.className moderna
                                                    ] ] ]

                    | BackgroundImages ->
                        let box =
                            [ Width.value (px 200)
                              Height.value (px 200) ]

                        let linearGradientStyle1 =
                            fss [ Label "Linear gradient style 1"
                                  yield! box
                                  BackgroundImage.linearGradient (
                                      (deg 0.,
                                       [ hex "e66465", pct 0
                                         hex "9198e5", pct 100 ])
                                  ) ]

                        let linearGradientStyle2 =
                            fss [ yield! box
                                  Label "Linear gradient style 2"
                                  BackgroundImage.linearGradient (
                                      (turn 0.25,
                                       [ hex "3f87a6", pct 0
                                         hex "ebf8e1", pct 50
                                         hex "f69d3c", pct 100 ])
                                  ) ]

                        let linearGradientStyle3 =
                            fss [ yield! box
                                  Label "Linear gradient style 3"
                                  BackgroundImage.linearGradient (
                                      (deg 270.,
                                       [ hex "333", pct 0
                                         hex "333", pct 50
                                         hex "eee", pct 75
                                         hex "333", pct 75 ])
                                  ) ]

                        let repeatingLinearGradientStyle1 =
                            fss [ yield! box
                                  Label "Repeating Linear gradient style 1"
                                  BackgroundImage.repeatingLinearGradient (
                                      (deg 0.,
                                       [ hex "e66465", px 0
                                         hex "e66465", px 20
                                         hex "9198e5", px 20
                                         hex "9198e5", px 25 ])
                                  ) ]

                        let repeatingLinearGradientStyle2 =
                            fss [ yield! box
                                  Label "Repeating Linear gradient style 2"
                                  BackgroundImage.repeatingLinearGradient (
                                      (deg 45.,
                                       [ hex "3f87a6", px 0
                                         hex "ebf8e1", px 15
                                         hex "f69d3c", px 20 ])
                                  ) ]

                        let repeatingLinearGradientsStyle3 =
                            fss [ yield! box
                                  BackgroundImage.repeatingLinearGradients [ deg 217.,
                                                                             [ rgba 255 0 0 0.8, pct 0
                                                                               rgba 255 0 0 0.0, pct 70 ]
                                                                             deg 127.,
                                                                             [ rgba 0 255 0 0.8, pct 0
                                                                               rgba 0 255 0 0.0, pct 70 ]
                                                                             deg 336.,
                                                                             [ rgba 0 0 255 0.8, pct 0
                                                                               rgba 0 0 255 0.0, pct 70 ] ] ]

                        let radialGradientStyle1 =
                            fss [ yield! box
                                  Label "Radial Gradient style 1"
                                  BackgroundImage.radialGradient (
                                      Fss.Types.Image.Ellipse,
                                      Fss.Types.Image.FarthestCorner,
                                      pct 50,
                                      pct 50,
                                      [ hex "e66465", pct 0
                                        hex "9198e5", pct 100 ]
                                  ) ]

                        let radialGradientStyle2 =
                            fss [ Label "Radial Gradient style 2"
                                  yield! box
                                  BackgroundImage.radialGradient (
                                      Fss.Types.Image.Ellipse,
                                      Fss.Types.Image.ClosestSide,
                                      pct 50,
                                      pct 50,
                                      [ hex "3f87a6", pct 0
                                        hex "ebf8e1", pct 50
                                        hex "f69d3c", pct 100 ]
                                  ) ]

                        let radialGradientStyle3 =
                            fss [ yield! box
                                  Label "Radial Gradient style 3"
                                  BackgroundImage.radialGradient (
                                      Fss.Types.Image.Circle,
                                      Fss.Types.Image.FarthestCorner,
                                      pct 100,
                                      pct 50,
                                      [ hex "333", pct 0
                                        hex "333", pct 50
                                        hex "eee", pct 75
                                        hex "333", pct 75 ]
                                  ) ]

                        let repeatingRadialGradientStyle1 =
                            fss [ Label "Repeating Radial Gradient style 1"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      Fss.Types.Image.Ellipse,
                                      Fss.Types.Image.FarthestCorner,
                                      pct 50,
                                      pct 50,
                                      [ hex "e66465", pct 0
                                        hex "9198e5", pct 20 ]
                                  ) ]

                        let repeatingRadialGradientStyle2 =
                            fss [ Label "Repeating Radial Gradient style 2"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      Fss.Types.Image.Ellipse,
                                      Fss.Types.Image.ClosestSide,
                                      pct 50,
                                      pct 50,
                                      [ hex "3f87a6", pct 0
                                        hex "ebf8e1", pct 50
                                        hex "f69d3c", pct 100 ]
                                  ) ]

                        let repeatingRadialGradientStyle3 =
                            fss [ Label "Repeating Radial Gradient style 3"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      Fss.Types.Image.Circle,
                                      Fss.Types.Image.FarthestCorner,
                                      pct 100,
                                      pct 50,
                                      [ hex "333", px 0
                                        hex "333", px 10
                                        hex "eee", px 10
                                        hex "eee", px 20 ]
                                  ) ]

                        let conicGradientStyle1 =
                            fss [ Label "Conic gradient style 1"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ Fss.Types.Color.Red, deg 0.
                                        Fss.Types.Color.Orange, deg 90.
                                        Fss.Types.Color.Yellow, deg 180.
                                        Fss.Types.Color.Green, deg 270.
                                        Fss.Types.Color.Blue, deg 360. ]
                                  ) ]

                        let conicGradientStyle2 =
                            fss [ Label "Conic gradient style 2"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      rad 3.1416,
                                      pct 10,
                                      pct 50,
                                      [ hex "#e66465", deg 0.
                                        hex "#9198e5", deg 360. ]
                                  ) ]

                        let conicGradientStyle3 =
                            fss [ Label "Conic gradient style 3"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ Fss.Types.Color.Red, deg 6.
                                        Fss.Types.Color.Orange, deg 6.
                                        Fss.Types.Color.Orange, deg 18.
                                        Fss.Types.Color.Yellow, deg 18.
                                        Fss.Types.Color.Yellow, deg 45.
                                        Fss.Types.Color.Green, deg 45.
                                        Fss.Types.Color.Green, deg 110.
                                        Fss.Types.Color.Blue, deg 110.
                                        Fss.Types.Color.Blue, deg 200.
                                        Fss.Types.Color.Purple, deg 200. ]
                                  ) ]

                        let conicGradientStyle4 =
                            fss [ Label "Conic gradient style 4"
                                  yield! box
                                  BorderRadius.value (px 200)
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ Fss.Types.Color.Yellow, deg (360. / 6.)
                                        Fss.Types.Color.Lime, deg <| (360. / 6.) * 2.
                                        Fss.Types.Color.Blue, deg <| (360. / 6.) * 3.
                                        Fss.Types.Color.Violet, deg <| (360. / 6.) * 4.
                                        Fss.Types.Color.Red, deg <| (360. / 6.) * 5.
                                        Fss.Types.Color.Yellow, deg <| (360. / 6.) * 6. ]
                                  ) ]

                        let repeatingConicGradientStyle =
                            fss [ Label "Repeating conic gradient style"
                                  yield! box
                                  BackgroundSize.value (px 50, px 50)
                                  BorderColor.black
                                  BorderStyle.solid
                                  BorderWidth.value (px 1)
                                  BackgroundImage.repeatingConicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ Fss.Types.Color.White, pct 0
                                        Fss.Types.Color.White, pct 25
                                        Fss.Types.Color.Black, pct 25
                                        Fss.Types.Color.Black, pct 50 ]
                                  ) ]

                        Some [

                               Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className linearGradientStyle1 ]
                                                          Html.div [ prop.className linearGradientStyle2 ]
                                                          Html.div [ prop.className linearGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label "Flex 2"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingLinearGradientStyle1 ]
                                                          Html.div [ prop.className repeatingLinearGradientStyle2 ]
                                                          Html.div [ prop.className repeatingLinearGradientsStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label "Flex 3"; Display.flex ])
                                          prop.children [ Html.div [ prop.className radialGradientStyle1 ]
                                                          Html.div [ prop.className radialGradientStyle2 ]
                                                          Html.div [ prop.className radialGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label "Flex 4"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingRadialGradientStyle1 ]
                                                          Html.div [ prop.className repeatingRadialGradientStyle2 ]
                                                          Html.div [ prop.className repeatingRadialGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className conicGradientStyle1 ]
                                                          Html.div [ prop.className conicGradientStyle2 ]
                                                          Html.div [ prop.className conicGradientStyle3 ]
                                                          Html.div [ prop.className conicGradientStyle4 ] ] ]
                               Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingConicGradientStyle ] ] ] ]
                    | Core ->
                        None
                    | Fable ->
                        None

                    | Feliz ->
                        let bounceFrames =
                            keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                                            Transform.value [ Transform.translate3D (px 0, px 0, px 0) ]
                                        ]
                                        frames [ 40; 43 ] [
                                            Transform.value [ Transform.translate3D (px 0, px -30, px 0) ]
                                        ]
                                        frame 70 [ Transform.value [ Transform.translate3D (px 0, px -15, px 0) ] ]
                                        frame 90 [ Transform.value [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

                        let box =
                            Html.div [ prop.fss [ BackgroundColor.red
                                                  Width.value (px 200)
                                                  Height.value (px 200)
                                                  Hover [ BackgroundColor.blue ] ] ]

                        let bounceBox =
                            Html.div [ prop.fss [ BackgroundColor.red
                                                  Width.value (px 200)
                                                  Height.value (px 200)
                                                  Hover [ BackgroundColor.blue ]
                                                  AnimationName.value bounceFrames
                                                  AnimationDuration.value (sec 1.0)
                                                  AnimationTimingFunction.easeInOut
                                                  AnimationIterationCount.infinite ] ]

                        Some [ box; bounceBox ]
                    | Giraffe ->
                        None
                    | Troubleshoot ->
                        None
                    | SVG ->
                        let logoAnimation =
                            keyframes [ frame 100 [ Svg.StrokeDashoffset.value [ 0 ] ] ]

                        let logoStyle =
                            fss [ Svg.Stroke.black
                                  Svg.StrokeWidth.value (px 4)
                                  Svg.StrokeDashoffset.value [ 1000 ]
                                  Svg.StrokeDasharray.value [ 1000 ]
                                  AnimationName.value logoAnimation
                                  AnimationDuration.value (sec 5.)
                                  AnimationTimingFunction.linear
                                  AnimationFillMode.forwards ]

                        Some [ Logo.logo 256 256 logoStyle ]

                Html.article [ prop.fss [ PaddingTop.value (px 100) ]
                               prop.children (markdownAndExamples markdown examples) ]

    let Content page =
        Html.div [ prop.fss [ Display.flex
                              FlexDirection.row ]
                   prop.children [ NavBar()
                                   Menu()
                                   Article page ] ]


    [<ReactComponent>]
    let App () =
        global' [ Link [ Color.hex sidebarText ]
                  Visited [ Color.hex sidebarText ]
                  !
                      Fss.Types.Html.A
                      [ Hover [ Color.hex sidebarHover ]
                        Focus [ Color.hex sidebarHover ] ]
                  !
                      Fss.Types.Html.Body
                      [ BackgroundColor.hex "#181A1B"
                        textFont
                        Color.hex contentText ] ]

        let currentUrl, updateUrl = React.useState (Router.currentUrl ())

        React.router [ router.onUrlChanged updateUrl
                       router.children [ match currentUrl with
                                         | [] -> Content Overview
                                         | [ "page"; page ] ->
                                             let page = stringToPage page

                                             match page with
                                             | Unknown -> Content Unknown
                                             | _ -> Content page
                                         | _ -> Content NotFound ] ]

    open Browser.Dom
    ReactDOM.render (StoreProvider <| App(), document.getElementById "app")