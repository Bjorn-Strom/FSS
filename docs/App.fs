namespace Docs

module App =
    //open Fetch
    open Feliz
    open Fss
    open Fss.Fable
    //open Feliz.Router
    //open Feliz.fss

    (*
    open Pages
    open Store

    // Constants
    // Load font
    let headingFont = FontFamily.custom "Nunito"
    let textFont = FontFamily.custom "Raleway"

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
        let _, dispatch = useStore()
        let pageString = pageToLinkString page

        Html.a [ prop.href $"#/page/{pageString}"
                 prop.text (Utilities.duToSpaced page)
                 prop.onClick (fun _ -> dispatch ToggleSidebar)
                 prop.fss [ Position.relative
                            Width' <| px 200
                            Label' "Menu link"
                            FontSize' <| px 14
                            TextDecoration.none
                            VerticalAlign.middle
                            Padding' <| px 2
                            textFont ] ]

    [<ReactComponent>]
    let NavBar () =
        let _, dispatch = useStore()

        Html.nav [
            prop.fss [
                  Position.fixed'
                  Left' <| px 0
                  Top' <| pct -100
                  Width' <| vw 100.
                  Height' <| px 50
                  BackgroundColor.hex sidebarBackgroundColor
                  Display.flex
                  AlignItems.center
                  ZIndex' 10

                  TransitionProperty.top
                  TransitionTimingFunction.easeInOut
                  TransitionDuration' <| ms 500.

                  MediaQuery
                    [FssTypes.Media.MaxWidth <| px 1000]
                    [Top' <| px 0]
            ]
            prop.children [
                Html.div [
                    prop.fss [
                        Cursor.pointer
                    ]
                    prop.onClick (fun _ -> dispatch ToggleSidebar)
                    prop.children [
                        Hamburger.hamburger 32 32 ""
                    ]
                ]
            ]
        ]

    [<ReactComponent>]
    let Menu () =
        let store, _ = useStore()
        Html.aside [ prop.fss [ Position.fixed'
                                Left' <| px 0
                                Top' <| px 0
                                Height' <| vh 100.
                                Width' <| px 336
                                BackgroundColor.hex sidebarBackgroundColor
                                Display.flex
                                FlexDirection.column
                                AlignItems.center
                                ZIndex' 5
                                PaddingTop' <| px 100

                                TransitionProperty.left
                                TransitionTimingFunction.easeInOut
                                TransitionDuration' <| ms 500.

                                MediaQuery [ FssTypes.Media.MaxWidth <| px 1000 ] [
                                    if not store.ShowSidebar then Left' <| pct -100
                                ]

                                // Following the menu is the article
                                // We need to animate the article as well as the menu when
                                // The following code block deals with that
                                // (parens added as Fantomas is acting up)
                                (!+FssTypes.Html.Article)
                                    [ MarginLeft' <| px 400
                                      TransitionProperty.marginLeft
                                      TransitionTimingFunction.easeInOut
                                      TransitionDuration' <| ms 500.
                                      MaxWidth' <| pct 60

                                      MediaQuery [ FssTypes.Media.MaxWidth <| px 1000 ] [
                                          MarginLeft' <| px 0
                                          MaxWidth' <| pct 100

                                      ] ] ]
                     prop.children [ Logo.logo 128 128 ""
                                     Html.h1 [ prop.fss [ headingFont
                                                          Color.hex sidebarText ]
                                               prop.text "Fss" ]
                                     yield! (List.map MenuItem allPages) ]

                      ]

    let rec markdownAndExamples (markdown: string) (examples: ReactElement list option) =
        let splitMarkdown =
            markdown.Split "</example>"
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
                                $"https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/docs/documentation/{page}.md"
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
        | Unknown -> Html.div [ prop.text "Unknown"
                                prop.fss [ PaddingTop' <| px 100 ] ]
        | NotFound -> Html.div [ prop.text "Not Found"
                                 prop.fss [ PaddingTop' <| px 100 ] ]
        | _ ->
            match doc with
            | None -> Html.text "Laster"
            | Some (_, markdown) ->
                let examples =
                    match page with
                    | Overview -> None
                    | Installation -> None
                    | Philosophy -> None
                    | New -> None
                    | BasicUsage ->
                        let borderStyle =
                            fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)" ]

                        Some [ Html.div [ prop.className borderStyle
                                          prop.text "Border style made with custom escape hatch" ] ]
                    | ConditionalStyling ->
                        let buttonStyle buttonType =
                            fss [ match buttonType with
                                  | Big ->
                                      Height'(px 80)
                                      Width'(px 80)
                                  | Small ->
                                      Height'(px 40)
                                      Width'(px 40) ]

                        Some [ Html.div [ prop.children [ Html.button [ prop.className (buttonStyle Small)
                                                                        prop.text "Small" ]

                                                          Html.button [ prop.className (buttonStyle Big)
                                                                        prop.text "Big" ] ] ] ]
                    | Pseudo ->
                        let hoverStyle =
                            fss [ Label' "Hover Style"
                                  Padding'(px 40)
                                  Width'(px 100)
                                  BackgroundColor.orangeRed
                                  FontSize'(px 20)
                                  BorderRadius'(px 5)
                                  Color.white
                                  Hover [ BackgroundColor.chartreuse
                                          Color.black ] ]

                        let beforeAndAfter =
                            let beforeAndAfter =
                                [ Content.value ""
                                  Display.inlineBlock
                                  BackgroundColor.orangeRed
                                  Width'(px 10)
                                  Height'(px 10) ]

                            fss [ Label' "Before And After"
                                  Before beforeAndAfter
                                  After beforeAndAfter ]

                        Some [ Html.div [ prop.className hoverStyle
                                          prop.text "Hover me!" ]
                               Html.div [ prop.className beforeAndAfter
                                          prop.text " Some content surrounded by stuff " ] ]
                    | Composition ->
                        let baseStyle =
                            [ Label' "Base Style"
                              BackgroundColor.darkGreen
                              Color.turquoise ]

                        let danger = [ Label' "Danger"; Color.red ]

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
                            fss [ Label' "Style With Label"
                                  Color.hotPink
                                  Label' "HotPinkLabel" ]

                        Some [ Html.div [ Html.div [ prop.className styleWithoutLabel
                                                     prop.text styleWithoutLabel ]
                                          Html.div [ prop.className styleWithLabel
                                                     prop.text styleWithLabel ] ] ]
                    | Transition ->
                        let colorTransition =
                            fss [ Label' "Color Transition"
                                  BackgroundColor.red
                                  TransitionProperty.backgroundColor
                                  TransitionDuration'(sec 2.5)
                                  TransitionTimingFunction.ease
                                  Hover [ BackgroundColor.green ] ]

                        let sizeAndColor =
                            fss [ Label' "Size and Color"
                                  Width'(px 40)
                                  Height'(px 40)
                                  BackgroundColor.yellowGreen
                                  TransitionProperty.all
                                  TransitionTimingFunction.linear
                                  TransitionDuration'(ms 500.)
                                  Hover [ BorderRadius'(pct 100)
                                          BackgroundColor.orangeRed ] ]

                        Some [ Html.div [ prop.className colorTransition
                                          prop.text "Hover me" ]
                               Html.div [ prop.className sizeAndColor ] ]
                    | KeyframesAnimations ->
                        let bounceFrames =
                            keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                                            Transforms [ Transform.translate3D (px 0, px 0, px 0) ]
                                        ]
                                        frames [ 40; 43 ] [
                                            Transforms [ Transform.translate3D (px 0, px -30, px 0) ]
                                        ]
                                        frame 70 [ Transforms [ Transform.translate3D (px 0, px -15, px 0) ] ]
                                        frame 90 [ Transforms [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

                        let backgroundColorFrames =
                            keyframes [ frame 0 [ BackgroundColor.red ]
                                        frame 30 [ BackgroundColor.green ]
                                        frame 60 [ BackgroundColor.blue ]
                                        frame 100 [ BackgroundColor.red ] ]

                        let bounceAnimation =
                            fss [ Label' "Bounce Animation"
                                  AnimationName' bounceFrames
                                  AnimationDuration'(sec 1.0)
                                  AnimationTimingFunction.easeInOut
                                  AnimationIterationCount.infinite ]

                        let bouncyColor =
                            fss [ Label' "Bouncy Color"
                                  AnimationName.names [ bounceFrames
                                                        backgroundColorFrames ]
                                  AnimationDuration.values [ sec 1.0
                                                             sec 5.0 ]
                                  AnimationTimingFunction.values [ FssTypes.Animation.Timing.EaseInOut
                                                                   FssTypes.Animation.Timing.Ease ]
                                  AnimationIterationCount.values [ FssTypes.Animation.Infinite
                                                                   FssTypes.CssInt 3 ] ]

                        Some [ Html.div [ Html.div [ prop.className bounceAnimation
                                                     prop.text "Bouncy bounce" ]
                                          Html.div [ prop.className bouncyColor
                                                     prop.text "Bouncy color" ] ] ]

                    | Combinators ->
                        let borders =
                            [ Label' "Borders"
                              BorderStyle.solid
                              BorderColor.black
                              BorderWidth'(px 1) ]

                        let descendantCombinator =
                            fss [ Label' "Descendant"
                                  yield! borders
                                  ! FssTypes.Html.P [ Color.red ] ]

                        let childCombinator =
                            fss [ Label' "Child"
                                  yield! borders
                                  !> FssTypes.Html.P [ Color.red ]

                                   ]

                        let directCombinator =
                            fss [ Label' "Direct"
                                  !+ FssTypes.Html.P [ Color.red ] ]

                        let adjacentCombinator =
                            fss [ Label' "Adjacent"
                                  !~ FssTypes.Html.P [ Color.red ] ]

                        Some [

                               Html.div [ prop.className descendantCombinator
                                          prop.children [ Html.p "Text in a paragraph and therefore red"
                                                          Html.text "Text outside of paragraph"
                                                          Html.div [ Html.p "Text in paragraph in div and red" ] ] ]
                               Html.div [ prop.className childCombinator
                                          prop.children [ Html.p "Text in a paragraph and therefore red"
                                                          Html.text "Text outside of paragraph"
                                                          Html.div [ Html.p "Text in paragraph in div and not red" ] ] ]
                               Html.div [ prop.className (fss borders)
                                          prop.children [ Html.div [ prop.className directCombinator
                                                                     prop.children [ Html.p [ Html.text
                                                                                                  "Text in paragraph in div " ] ] ]
                                                          Html.p
                                                              "Text in a paragraph and after the div with the combinator so is red"
                                                          Html.p
                                                              "Text in a paragraph but not after div with the combinator so is not red" ] ]
                               Html.div [ prop.className (fss borders)
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
                            fss [ Label' "Media query examples"
                                  Width'(px 200)
                                  Height'(px 200)
                                  BackgroundColor.blue

                                  MediaQuery [ FssTypes.Media.MinWidth(px 700) ] [
                                      BackgroundColor.pink
                                      Color.orangeRed
                                  ]

                                  MediaQueryFor
                                      FssTypes.Media.Print
                                      []
                                      [ MarginTop'(px 200)
                                        Transforms [ Transform.rotate (deg 45.0) ]
                                        BackgroundColor.red ]

                                  MediaQuery [ FssTypes.Media.Orientation FssTypes.Media.Landscape ] [
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
                                           Symbols.strings [ "Ⓐ"
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
                            fss [ Label' "Mozilla Example Style"
                                  ListStyleType' mozillaExampleCounter ]

                        let indexCounter = counterStyle []
                        let subCounter = counterStyle []

                        let sectionStyle =
                            fss [ Label' "Section"
                                  FontFamily.custom "Roboto, sans-serif"
                                  CounterReset' indexCounter ]

                        let commonBefore =
                            [ FontWeight'(FssTypes.CssInt 500)
                              Color.hex "48f" ]

                        let commonStyle =
                            [ Margin.value (px 0, px 0, px 1)
                              Padding.value (px 5, px 10) ]

                        let count =
                            fss [ Label' "Count"
                                  yield! commonStyle
                                  CounterReset' subCounter
                                  CounterIncrement' indexCounter
                                  BackgroundColor.hex "#222426"
                                  Before [ yield! commonBefore
                                           Content.counter (indexCounter, ". ") ] ]

                        let sub =
                            fss [ Label' "Sub"
                                  yield! commonStyle
                                  CounterIncrement' subCounter
                                  TextIndent'(em 1.)
                                  Color.hex "BDB7AF"
                                  Before [ yield! commonBefore
                                           Content.counters ([ indexCounter; subCounter ], [ "."; "." ])
                                           MarginRight'(px 5) ] ]

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
                        let amaticStyle =
                            fss [ Label' "Amatic Style"
                                  FontFamily.custom "Amatic SC"
                                  FontSize'(px 24) ]

                        let droidSerifFont =
                            fontFaces
                                "DroidSerif"
                                [ [ FontFace.source
                                    <| FssTypes.FontFace.UrlFormat(
                                        "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf",
                                        FssTypes.FontFace.Truetype
                                    )
                                    FontFace.weight FssTypes.Font.Bold
                                    FontFace.style FssTypes.Normal ]
                                  [ FontFace.source
                                    <| FssTypes.FontFace.UrlFormat(
                                        "https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf",
                                        FssTypes.FontFace.Truetype
                                    )
                                    FontFace.weight FssTypes.Normal
                                    FontFace.style FssTypes.Normal ] ]

                        let modernaFont =
                            fontFace
                                "moderna"
                                [ FontFace.sources [ FssTypes.FontFace.UrlFormat(
                                                         "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2",
                                                         FssTypes.FontFace.Woff2
                                                     )
                                                     FssTypes.FontFace.UrlFormat(
                                                         "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff",
                                                         FssTypes.FontFace.Woff
                                                     )
                                                     FssTypes.FontFace.UrlFormat(
                                                         "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf",
                                                         FssTypes.FontFace.Truetype
                                                     )
                                                     FssTypes.FontFace.UrlFormat(
                                                         "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg",
                                                         FssTypes.FontFace.Svg
                                                     ) ]
                                  FontFace.weight FssTypes.Normal
                                  FontFace.style FssTypes.Normal ]

                        let droidSerif =
                            fss [ Label' "Droid Serif"
                                  FontFamily.font droidSerifFont ]

                        let droidSerifBold =
                            fss [ Label' "Droid Serif Bold"
                                  FontFamily.font droidSerifFont
                                  FontWeight.bold ]

                        let moderna =
                            fss [ Label' "Moderna"
                                  FontFamily.font modernaFont ]

                        Some [ Html.p [ prop.className amaticStyle
                                        prop.text "This font is Amatic SC, some nice text this huh?" ]
                               Html.div [ Html.p [ prop.className droidSerif
                                                   prop.text "Droid serif" ]
                                          Html.p [ prop.className droidSerifBold
                                                   prop.text "Droid serif bold" ]
                                          Html.p [ prop.className moderna
                                                   prop.text "Moderna" ] ] ]

                    | BackgroundImages ->
                        let box = [ Width'(px 200); Height'(px 200) ]

                        let linearGradientStyle1 =
                            fss [ Label' "Linear gradient style 1"
                                  yield! box
                                  BackgroundImage.linearGradient (
                                      (deg 0.,
                                       [ hex "e66465", pct 0
                                         hex "9198e5", pct 100 ])
                                  ) ]

                        let linearGradientStyle2 =
                            fss [ yield! box
                                  Label' "Linear gradient style 2"
                                  BackgroundImage.linearGradient (
                                      (turn 0.25,
                                       [ hex "3f87a6", pct 0
                                         hex "ebf8e1", pct 50
                                         hex "f69d3c", pct 100 ])
                                  ) ]

                        let linearGradientStyle3 =
                            fss [ yield! box
                                  Label' "Linear gradient style 3"
                                  BackgroundImage.linearGradient (
                                      (deg 270.,
                                       [ hex "333", pct 0
                                         hex "333", pct 50
                                         hex "eee", pct 75
                                         hex "333", pct 75 ])
                                  ) ]

                        let repeatingLinearGradientStyle1 =
                            fss [ yield! box
                                  Label' "Repeating Linear gradient style 1"
                                  BackgroundImage.repeatingLinearGradient (
                                      (deg 0.,
                                       [ hex "e66465", px 0
                                         hex "e66465", px 20
                                         hex "9198e5", px 20
                                         hex "9198e5", px 25 ])
                                  ) ]

                        let repeatingLinearGradientStyle2 =
                            fss [ yield! box
                                  Label' "Repeating Linear gradient style 2"
                                  BackgroundImage.repeatingLinearGradient (
                                      (deg 45.,
                                       [ hex "3f87a6", px 0
                                         hex "ebf8e1", px 15
                                         hex "f69d3c", px 20 ])
                                  ) ]

                        let repeatingLinearGradientsStyle3 =
                            fss [ yield! box
                                  BackgroundImage.repeatingLinearGradients [ deg 217.,
                                                                             [ FssTypes.Color.Color.rgba 255 0 0 0.8, pct 0
                                                                               FssTypes.Color.Color.rgba 255 0 0 0.0, pct 70 ]
                                                                             deg 127.,
                                                                             [ FssTypes.Color.Color.rgba 0 255 0 0.8, pct 0
                                                                               FssTypes.Color.Color.rgba 0 255 0 0.0, pct 70 ]
                                                                             deg 336.,
                                                                             [ FssTypes.Color.Color.rgba 0 0 255 0.8, pct 0
                                                                               FssTypes.Color.Color.rgba 0 0 255 0.0, pct 70 ]

                                                                              ] ]

                        let radialGradientStyle1 =
                            fss [ yield! box
                                  Label' "Radial Gradient style 1"
                                  BackgroundImage.radialGradient (
                                      FssTypes.Image.Ellipse,
                                      FssTypes.Image.FarthestCorner,
                                      pct 50,
                                      pct 50,
                                      [ hex "e66465", pct 0
                                        hex "9198e5", pct 100 ]
                                  ) ]

                        let radialGradientStyle2 =
                            fss [ Label' "Radial Gradient style 2"
                                  yield! box
                                  BackgroundImage.radialGradient (
                                      FssTypes.Image.Ellipse,
                                      FssTypes.Image.ClosestSide,
                                      pct 50,
                                      pct 50,
                                      [ hex "3f87a6", pct 0
                                        hex "ebf8e1", pct 50
                                        hex "f69d3c", pct 100 ]
                                  ) ]

                        let radialGradientStyle3 =
                            fss [ yield! box
                                  Label' "Radial Gradient style 3"
                                  BackgroundImage.radialGradient (
                                      FssTypes.Image.Circle,
                                      FssTypes.Image.FarthestCorner,
                                      pct 100,
                                      pct 50,
                                      [ hex "333", pct 0
                                        hex "333", pct 50
                                        hex "eee", pct 75
                                        hex "333", pct 75 ]
                                  ) ]

                        let repeatingRadialGradientStyle1 =
                            fss [ Label' "Repeating Radial Gradient style 1"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      FssTypes.Image.Ellipse,
                                      FssTypes.Image.FarthestCorner,
                                      pct 50,
                                      pct 50,
                                      [ hex "e66465", pct 0
                                        hex "9198e5", pct 20 ]
                                  ) ]

                        let repeatingRadialGradientStyle2 =
                            fss [ Label' "Repeating Radial Gradient style 2"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      FssTypes.Image.Ellipse,
                                      FssTypes.Image.ClosestSide,
                                      pct 50,
                                      pct 50,
                                      [ hex "3f87a6", pct 0
                                        hex "ebf8e1", pct 50
                                        hex "f69d3c", pct 100 ]
                                  ) ]

                        let repeatingRadialGradientStyle3 =
                            fss [ Label' "Repeating Radial Gradient style 3"
                                  yield! box
                                  BackgroundImage.repeatingRadialGradient (
                                      FssTypes.Image.Circle,
                                      FssTypes.Image.FarthestCorner,
                                      pct 100,
                                      pct 50,
                                      [ hex "333", px 0
                                        hex "333", px 10
                                        hex "eee", px 10
                                        hex "eee", px 20 ]
                                  ) ]

                        let conicGradientStyle1 =
                            fss [ Label' "Conic gradient style 1"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ FssTypes.Color.Color.red, deg 0.
                                        FssTypes.Color.Color.orange, deg 90.
                                        FssTypes.Color.Color.yellow, deg 180.
                                        FssTypes.Color.Color.green, deg 270.
                                        FssTypes.Color.Color.blue, deg 360. ]
                                  ) ]

                        let conicGradientStyle2 =
                            fss [ Label' "Conic gradient style 2"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      rad 3.1416,
                                      pct 10,
                                      pct 50,
                                      [ hex "#e66465", deg 0.
                                        hex "#9198e5", deg 360. ]
                                  ) ]

                        let conicGradientStyle3 =
                            fss [ Label' "Conic gradient style 3"
                                  yield! box
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ FssTypes.Color.Color.red, deg 6.
                                        FssTypes.Color.Color.orange, deg 6.
                                        FssTypes.Color.Color.orange, deg 18.
                                        FssTypes.Color.Color.yellow, deg 18.
                                        FssTypes.Color.Color.yellow, deg 45.
                                        FssTypes.Color.Color.green, deg 45.
                                        FssTypes.Color.Color.green, deg 110.
                                        FssTypes.Color.Color.blue, deg 110.
                                        FssTypes.Color.Color.blue, deg 200.
                                        FssTypes.Color.Color.purple, deg 200. ]
                                  ) ]

                        let conicGradientStyle4 =
                            fss [ Label' "Conic gradient style 4"
                                  yield! box
                                  BorderRadius' <| px 200
                                  BackgroundImage.conicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ FssTypes.Color.Color.yellow, deg (360. / 6.)
                                        FssTypes.Color.Color.lime, deg <| (360. / 6.) * 2.
                                        FssTypes.Color.Color.blue, deg <| (360. / 6.) * 3.
                                        FssTypes.Color.Color.violet, deg <| (360. / 6.) * 4.
                                        FssTypes.Color.Color.red, deg <| (360. / 6.) * 5.
                                        FssTypes.Color.Color.yellow, deg <| (360. / 6.) * 6. ]
                                  ) ]

                        let repeatingConicGradientStyle =
                            fss [ Label' "Repeating conic gradient style"
                                  yield! box
                                  BackgroundSize.value (px 50, px 50)
                                  BorderColor.black
                                  BorderStyle.solid
                                  BorderWidth'(px 1)
                                  BackgroundImage.repeatingConicGradient (
                                      deg 0.,
                                      pct 50,
                                      pct 50,
                                      [ FssTypes.Color.Color.white, pct 0
                                        FssTypes.Color.Color.white, pct 25
                                        FssTypes.Color.Color.black, pct 25
                                        FssTypes.Color.Color.black, pct 50 ]
                                  ) ]

                        Some [

                               Html.div [ prop.className (fss [ Label' "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className linearGradientStyle1 ]
                                                          Html.div [ prop.className linearGradientStyle2 ]
                                                          Html.div [ prop.className linearGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label' "Flex 2"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingLinearGradientStyle1 ]
                                                          Html.div [ prop.className repeatingLinearGradientStyle2 ]
                                                          Html.div [ prop.className repeatingLinearGradientsStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label' "Flex 3"; Display.flex ])
                                          prop.children [ Html.div [ prop.className radialGradientStyle1 ]
                                                          Html.div [ prop.className radialGradientStyle2 ]
                                                          Html.div [ prop.className radialGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label' "Flex 4"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingRadialGradientStyle1 ]
                                                          Html.div [ prop.className repeatingRadialGradientStyle2 ]
                                                          Html.div [ prop.className repeatingRadialGradientStyle3 ] ] ]
                               Html.div [ prop.className (fss [ Label' "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className conicGradientStyle1 ]
                                                          Html.div [ prop.className conicGradientStyle2 ]
                                                          Html.div [ prop.className conicGradientStyle3 ]
                                                          Html.div [ prop.className conicGradientStyle4 ] ] ]
                               Html.div [ prop.className (fss [ Label' "Flex 1"; Display.flex ])
                                          prop.children [ Html.div [ prop.className repeatingConicGradientStyle ] ] ] ]

                    | Feliz ->
                        let bounceFrames =
                            keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                                            Transforms [ Transform.translate3D (px 0, px 0, px 0) ]
                                        ]
                                        frames [ 40; 43 ] [
                                            Transforms [ Transform.translate3D (px 0, px -30, px 0) ]
                                        ]
                                        frame 70 [ Transforms [ Transform.translate3D (px 0, px -15, px 0) ] ]
                                        frame 90 [ Transforms [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

                        let box =
                            Html.div [ prop.fss [ BackgroundColor.red
                                                  Width' <| px 200
                                                  Height' <| px 200
                                                  Hover [ BackgroundColor.blue ] ] ]

                        let bounceBox =
                            Html.div [ prop.fss [ BackgroundColor.red
                                                  Width' <| px 200
                                                  Height' <| px 200
                                                  Hover [ BackgroundColor.blue ]
                                                  AnimationName.name bounceFrames
                                                  AnimationDuration'(sec 1.0)
                                                  AnimationTimingFunction.easeInOut
                                                  AnimationIterationCount.infinite ] ]

                        Some [ box; bounceBox ]

                    | SVG ->
                        let logoAnimation =
                            keyframes [ frame 100 [ StrokeDashoffset' [ 0 ] ] ]

                        let logoStyle =
                            fss [ Stroke.black
                                  StrokeWidth' <| px 4
                                  StrokeDashoffset' [ 1000 ]
                                  StrokeDasharray' [ 1000 ]
                                  AnimationName' logoAnimation
                                  AnimationDuration' <| sec 5.
                                  AnimationTimingFunction.linear
                                  AnimationFillMode.forwards ]

                        Some [ Logo.logo 256 256 logoStyle ]

                Html.article [ prop.fss [ PaddingTop' <| px 100 ]
                               prop.children (markdownAndExamples markdown examples) ]

    let Content page =
        Html.div [ prop.fss [ Display.flex
                              FlexDirection.row ]
                   prop.children [ NavBar (); Menu(); Article page ] ]


    [<ReactComponent>]
    let App () =
        global' [ Link [ Color.hex sidebarText ]
                  Visited [ Color.hex sidebarText ]
                  !
                      FssTypes.Html.A
                      [ Hover [ Color.hex sidebarHover ]
                        Focus [ Color.hex sidebarHover ] ]
                  !
                      FssTypes.Html.Body
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

    *)
    
    let emojiCounterStyle =
        counterStyle [ System.cyclic
                       Symbols.value [ "❤️"
                                       "✨"
                                       "🔥"
                                       "😊"
                                       "😂"
                                       "🥺"
                                       "❤️‍🔥"
                                       "👍"
                                       "🥰"
                                       "🐻"
                                       "🍔"
                                       "⚽"
                                       "💨"
                                       "🎨"
                                       " 🐶"; ]
                       Suffix.value " "
                       Prefix.value " " ]

    let font =
        fontFace
            "DroidSerif"
            [ FontFace.Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
              FontFace.FontWeight.value 100
              FontFace.FontStyle.normal ]

    let emojiCounter =
        fss [ ListStyleType.ident emojiCounterStyle
              FontFamily.value font
              ! FssTypes.Html.Li [ After [ Content.value "."  ]] 
              ! FssTypes.Html.Li [
                  BackgroundColor.aliceBlue
                  Hover [ BackgroundColor.orangeRed ]
              ]
              Label "counter"
              ]

    let container =
        fss [ Display.flex
              FlexDirection.column
              AlignItems.center
              JustifyContent.center
              Label "container" ]

    let spinimation =
        keyframes [ frame 0 [ Custom "transform" "rotate(0deg)" ]
                    frame 100 [ Custom "transform" "rotate(360deg)" ] ]

    let title =
        fss [ AnimationName.value spinimation
              AnimationDuration.value (sec 1)
              AnimationIterationCount.infinite
              FontFamily.value "DroidSerif"
              Hover [ AnimationDuration.value (ms 500) ]
              Media.query [ FssTypes.Media.MaxWidth(px 600) ] [
                  BackgroundColor.orangeRed
              ]
              Label "title"
            ]
        
    open Browser.Dom
    [<ReactComponent>]
    let App () =
        Html.div [
            prop.className container
            prop.children [
                Html.p [
                    prop.className title
                    prop.text "Spin"
                ]
                Html.ul [
                    prop.className emojiCounter
                    prop.children [
                        Html.li "Monday"
                        Html.li "Tuesday"
                        Html.li "Wedesday"
                        Html.li "Thursday"
                        Html.li "Friday"
                        Html.li "Saturday"
                        Html.li "Sunday"
                        Html.li "January"
                        Html.li "February"
                        Html.li "March"
                        Html.li "April"
                        Html.li "May"
                        Html.li "June"
                        Html.li "July"
                        Html.li "August"
                        Html.li "September"
                        Html.li "October"
                        Html.li "November"
                        Html.li "December"
                    ]
                ]
            ]
        ]

    ReactDOM.render (App(), document.getElementById "app")
