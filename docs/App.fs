namespace Docs

module App =
    open Browser.Types
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
        | Selectors
        | KeyframesAnimations
        | MediaQueries
        | GlobalStyles
        | Counters
        | Fontface

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

    let pageToString =
        function
        | Overview -> "Overview"
        | Installation -> "Installation"
        | Philosophy -> "Philosophy"
        | BasicUse -> "Basic Usage"
        | ConditionalStyling -> "Conditional Styling"
        | Pseudo -> "Pseduoclasses/selectors"
        | Composition -> "Composition"
        | Labels -> "Labels"
        | Transitions -> "Transitions"
        | Selectors -> "Selectors"
        | KeyframesAnimations -> "Keyframes and animations"
        | MediaQueries -> "Media queries"
        | GlobalStyles  -> "Global styles"
        | Counters -> "Counters"
        | Fontface -> "Font face"

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
                            Logo.logo 200 200
                        ]
                    h2 [] [ str "Overview" ]
                    p []
                        [
                            str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nisl tortor, semper in sollicitudin a, aliquam eu est. Ut sagittis, ante id pharetra vehicula, orci velit pretium arcu, et auctor nisl ligula ac ante. Nullam auctor, purus vel tincidunt pulvinar, quam risus ullamcorper ipsum, in pulvinar neque est ac massa. Nam consequat interdum nisi eget ultrices. Etiam vitae elementum mauris. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Suspendisse commodo turpis at aliquam accumsan. Aliquam erat volutpat. Nullam interdum lorem lorem, sed dignissim metus pulvinar non. In hac habitasse platea dictumst. Quisque rutrum magna purus. Suspendisse ac hendrerit velit. Integer nisl mi, commodo vitae interdum vel, tincidunt ut magna. Suspendisse a semper metus, et pulvinar ante. Proin suscipit eros ultricies purus tempor, eget sagittis odio accumsan. "
                        ]
                ]

        let installation = article [] []
        let philosophy = article [] []
        let basicUse = article [] []
        let conditionalStyling = article [] []
        let pseudo = article [] []
        let composition = article [] []
        let labels = article [] []
        let transitions = article [] []
        let selectors = article [] []
        let keyframesAnimations = article [] []
        let mediaQueries = article [] []
        let globalStyles = article [] []
        let counters = article [] []
        let fontFace = article [] []

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
        | Selectors -> selectors
        | KeyframesAnimations -> keyframesAnimations
        | MediaQueries -> mediaQueries
        | GlobalStyles  -> globalStyles
        | Counters -> counters
        | Fontface -> fontFace

    let menuListItem example currentExample onClick =
        let buttonStyle =
            fss
                [
                    Border.None
                    if example = currentExample then
                       BackgroundColor.Hex "#29A9DF"
                    else
                        BackgroundColor.transparent
                    Margin' (px 0)
                    Padding' (px 10)
                    Width' (px 200)
                    FontSize' (px 14)
                    TextAlign.Left
                    textFont
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

        let headerText =
            fss
                [
                    headingFont
                ]

        header  [ ClassName headerStyle ]
            [
                h2 [ ClassName headerText ]
                    [
                        str "Fss"
                    ]
            ]

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
                        menuListItem' Selectors
                        menuListItem' KeyframesAnimations
                        menuListItem' MediaQueries
                        menuListItem' GlobalStyles
                        menuListItem' Counters
                        menuListItem' Fontface
                    ]
            ]

    let content model =
        let contentStyle =
            fss
                [
                    GridArea' (GridPosition.Ident "content")
                    textFont
                ]
        article [ ClassName contentStyle ]
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
                    Width' (pct 70)
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