namespace Docs

module App =
    open Browser.Types
    open Elmish
    open Elmish.React
    open Fable.React
    open Fable.React.Props

    open Fss

    type Example =
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

    type Model = { CurrentExample: Example }

    type Msg =
        | SetExample of Example

    let init() = { CurrentExample = Overview }

    let update (msg: Msg) (model: Model): Model =
        match msg with
        | SetExample example ->
            { model with CurrentExample = example }

    // Load font
    Import.Url "https://fonts.googleapis.com/css?family=Nunito|Raleway"
    let headingFont = FontFamily.Custom "Nunito"
    let textFont = FontFamily.Custom "Raleway"

    let exampleToString =
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

    let menuListItem text onClick =
        let buttonStyle =
            fss
                [
                    Border.None
                    BackgroundColor.transparent
                    Margin' (px 0)
                    Padding' (px 10)
                    Width' (px 200)
                    FontSize' (px 14)
                    TextAlign.Left
                    textFont
                    Hover
                        [
                            BackgroundColor.Hex "808080"
                        ]
                    Focus
                        [
                            BackgroundColor.Hex "0000FF"
                            Outline.None
                            Color.white
                        ]
                ]

        li []
            [
                button [ ClassName buttonStyle; OnClick onClick ]
                    [
                        str text
                    ]
            ]

    let exampleNavigation example dispatch =
        menuListItem (exampleToString example) (fun _ -> dispatch <| SetExample example)

    let header =
        let headerStyle =
            fss
                [
                    GridArea' (GridPosition.Ident "nav")
                    GridColumnEnd.Span 2
                    BackgroundColor.red
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

    let menu dispatch =
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
                    BackgroundColor.bisque
                ]
        aside [ ClassName menuStyle ]
            [
                ul [ ClassName menuList ]
                    [
                        exampleNavigation Overview dispatch
                        exampleNavigation Installation dispatch
                        exampleNavigation Philosophy dispatch
                        exampleNavigation BasicUse dispatch
                        exampleNavigation ConditionalStyling dispatch
                        exampleNavigation Pseudo dispatch
                        exampleNavigation Composition dispatch
                        exampleNavigation Labels dispatch
                        exampleNavigation Transitions dispatch
                        exampleNavigation Selectors dispatch
                        exampleNavigation KeyframesAnimations dispatch
                        exampleNavigation MediaQueries dispatch
                        exampleNavigation GlobalStyles dispatch
                        exampleNavigation Counters dispatch
                        exampleNavigation Fontface dispatch
                    ]
            ]

    let content model =
        let contentStyle =
            fss
                [
                    GridArea' (GridPosition.Ident "content")
                    BackgroundColor.aliceBlue
                    textFont
                ]
        article [ ClassName contentStyle ]
            [
                str <| exampleToString model.CurrentExample
                Logo.logo 200 200
            ]

    let render (model: Model) (dispatch: Msg -> unit) =
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
                        menu dispatch
                        content model
                    ]
            ]

    Program.mkSimple init update render
    |> Program.withReactSynchronous "elmish-app"
    |> Program.run