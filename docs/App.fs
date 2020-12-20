module App

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

fss
    [
        Import.Url("https://fonts.googleapis.com/css?family=Playfair+Display|Roboto")
    ]

let exampleToString =
    function
    | Overview -> "Overview"
    | Installation -> "Installation"
    | Philosophy -> "Philosophy"
    | BasicUse -> "Basic Usage"
    | ConditionalStyling -> "Conditional Styling"
    | Pseudo -> "Pseduoclasses and selectors"
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
                FontFamily.Custom "Roboto"
                Border.None
                BackgroundColor.transparent
                Margin' (px 0)
                Padding' (px 0)
                Width.Auto
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

let menu dispatch =
    let menuList =
        fss
            [
                ListStyleType.None
                Margin' (px 0)
                Padding' (px 0)
                TextIndent' (px 0)
            ]
    aside []
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


let render (model: Model) (dispatch: Msg -> unit) =
    div []
        [
            menu dispatch
            str <| exampleToString model.CurrentExample
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run