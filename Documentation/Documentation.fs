module App

open Fss
open Feliz
open Fable.Core
open Feliz.Router

open Pages
open Store

// Constants
// Font families
let nunito =
    fontFace
        "Nunito"
        [ FontFace.Src.truetype "https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/fonts/Nunito-Regular.ttf"
          FontFace.FontDisplay.swap ]

let raleway =
    fontFace
        "Raleway"
        [ FontFace.Src.truetype
            "https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/fonts/Raleway-Regular.ttf"
          FontFace.FontDisplay.swap ]

let grapeNuts =
    fontFace
        "GrapeNuts"
        [ FontFace.Src.truetype
            "https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/fonts/GrapeNuts-Regular.ttf"
          FontFace.FontDisplay.swap ]

let headingFont = FontFamily.value nunito
let textFont = FontFamily.value raleway

// Colors
let sidebarBackgroundColor = "212731"
let sidebarText = "759DB2"
let sidebarHover = "c7dae0"
let contentText = "e8e6e3"
let contentLink = "50b8ec"

// Code splitting
let overview: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Overview.fs"

let installation: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Installation.fs"

let philosophy: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Philosophy.fs"

let basicUsage: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/BasicUsage.fs"

let conditionalStyling: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/ConditionalStyling.fs"

let pseudo: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Pseudo.fs"

let composition: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Composition.fs"

let labels: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Labels.fs"

let transition: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Transition.fs"

let keyframesAnimations: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/KeyframesAnimations.fs"

let combinators: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Combinators.fs"

let mediaQueries: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/MediaQueries.fs"

let globalStyles: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/GlobalStyles.fs"

let counters: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Counters.fs"

let fonts: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Fonts.fs"

let backgroundImages: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/BackgroundImages.fs"

let svg: JS.Promise<unit -> ReactElement> = JsInterop.importDynamic "./Pages/Svg.fs"

let core: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Core.fs"

let fable: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Fable.fs"

let feliz: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Feliz.fs"

let giraffe: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Giraffe.fs"

let troubleshoot: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Troubleshoot.fs"

[<ReactComponent>]
let Suspense (component': JS.Promise<unit -> ReactElement>) =
    React.suspense ([ Html.div [ React.lazy' (component', ()) ] ], Html.p "LOADING")


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



let Article (page: Page) =
    //                    | Feliz ->
//                    | SVG ->

    Html.article [ prop.fss [ PaddingTop.value (px 100) ]
                   prop.children [ match page with
                                   | Overview -> Suspense overview
                                   | Installation -> Suspense installation
                                   | Philosophy -> Suspense philosophy
                                   | BasicUsage -> Suspense basicUsage
                                   | ConditionalStyling -> Suspense conditionalStyling
                                   | Pseudo -> Suspense pseudo
                                   | Composition -> Suspense composition
                                   | Labels -> Suspense labels
                                   | Transition -> Suspense transition
                                   | KeyframesAnimations -> Suspense keyframesAnimations
                                   | Combinators -> Suspense combinators
                                   | MediaQueries -> Suspense mediaQueries
                                   | Counters -> Suspense counters
                                   | Fonts -> Suspense fonts
                                   | BackgroundImages -> Suspense backgroundImages
                                   | Svg -> Suspense svg
                                   | Core -> Suspense core
                                   | Fable -> Suspense fable
                                   | Feliz -> Suspense feliz
                                   | Giraffe -> Suspense giraffe
                                   | Troubleshoot -> Suspense troubleshoot
                                   | GlobalStyles -> Suspense globalStyles ] ]

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
