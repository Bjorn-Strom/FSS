namespace Docs

open Fss.DisplayType
open Fss.DisplayType
open Fss.TextTypes
open Fss.TextTypes

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
        | Selectors
        | KeyframesAnimations
        | MediaQueries
        | GlobalStyles
        | Counters
        | Fontface
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
        | Selectors -> "Selectors"
        | KeyframesAnimations -> "Keyframes and animations"
        | MediaQueries -> "Media queries"
        | GlobalStyles  -> "Global styles"
        | Counters -> "Counters"
        | Fontface -> "Font face"
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
        let composition = article [] []
        let labels = article [] []
        let transitions = article [] []
        let selectors = article [] []
        let keyframesAnimations = article [] []
        let mediaQueries = article [] []
        let globalStyles = article [] []
        let counters = article [] []
        let fontFace = article [] []
        let backgroundImage = article [] []

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