module App

open Fss
open Feliz
open Fable.Core
open Feliz.Router
open Fss.Types
open Browser

open Pages
open Store

// Constants
// TODO: Changing theme should save it in local storage
printfn "ColorTheme: %A" "foo"

// Font families
let nunito =
    fontFace
        "Nunito"
        [ FontFace.Src.truetype "https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/fonts/Nunito-Regular.ttf"
          FontFace.FontDisplay.swap ]

let grapeNuts =
    fontFace
        "GrapeNuts"
        [ FontFace.Src.truetype
            "https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/public/fonts/GrapeNuts-Regular.ttf"
          FontFace.FontDisplay.swap ]
let font = FontFamily.value nunito

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

let attributeSelectors: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/AttributeSelectors.fs"

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
    React.suspense ([ Html.div [ React.lazy' (component', ()) ] ], Spinner())

[<ReactComponent>]
let MenuItem (page: Page) =
    Html.li [
        prop.fss [
            ListStyle.none
        ]
        prop.children [
            Html.a [
                prop.fss [
                    TextDecoration.none
                    Color.inherit'
                    Hover [
                        TextDecoration.revert
                    ]
                ]
                prop.text (pageToPrettyString page)
                prop.href $"#/page/{pageToLinkString page}"
            ]
        ]
    ]

[<ReactComponent>]
let MenuItems (title: string, pages: Page list) =
     Html.li [
         prop.fss [
             PaddingTop.value (px 20)
             ListStyle.none
         ]
         prop.children [
             Html.div title
             Html.ul [
                 prop.fss [
                     PaddingLeft.value (px 10)
                     FontSize.value (pct 80)
                     LineHeight.value (pct 150)
                 ]
                 prop.children (List.map MenuItem pages)
             ]
         ]
     ]

[<ReactComponent>]
let Menu () =
    let store, dispatch = useStore()
    Html.nav [
         prop.fss [
             Position.fixed'
             Left.value (px 0)
             Top.value (px 0)
             Bottom.value (px 0)
             MaxWidth.value (px 1300)
             MarginLeft.value (px 0)
             MarginRight.value (px 0)
             MarginTop.auto
             MarginBottom.auto
         ]
         prop.children [
             Html.div [
                 prop.id "shadow"
             ]
             Html.div [
                 prop.fss [
                     Position.absolute
                     Left.value (px 0)
                     Top.value (px 0)
                     Bottom.value (px 0)
                     Padding.value(px 50, px 0, px 30, px 30)
                     OverflowY.auto
                     BackgroundColor.value store.Theme.BackgroundColor
                 ]
                 prop.children [
                     Html.a [
                         prop.id "logo"
                     ]
                     Html.ul [
                         prop.id "menuItems"
                         prop.children (List.map MenuItems allPages)
                     ]
                     Html.div [
                         prop.fss [
                             Display.flex
                             JustifyContent.center

                             ! (Selector.Tag Html.A) [
                                 FirstOfType [
                                     MarginRight.value (px 15)
                                 ]
                             ]
                         ]
                         prop.id "options"
                         let iconStyle = fss [
                             Fss.Svg.Fill.value store.Theme.Opposite
                         ]
                         prop.children [
                             Html.a [
                                 prop.ariaLabel "View this project on GitHub"
                                 prop.href "https://github.com/bjorn-strom/fss"
                                 prop.children [
                                     Github.iconClassName iconStyle
                                ]
                             ]
                             Html.a [
                                 prop.ariaLabel "Toggle dark mode"
                                 prop.onClick (fun _ ->
                                     if store.Theme = Theme.LightTheme then
                                         dispatch (SetTheme Theme.DarkTheme)
                                     else
                                         dispatch (SetTheme Theme.LightTheme))
                                 prop.children [
                                     if store.Theme = Theme.LightTheme then
                                         Moon.iconNormal
                                     else
                                         Sun.iconClassName iconStyle

                                 ]
                             ]
                         ]
                     ]
                 ]

             ]
         ]
     ]

// TODO: Fin not found side
[<ReactComponent>]
let Main (page: Page) =
    Html.main [
        prop.fss [
            Position.relative
            MaxWidth.value (px 1000)
        ]
        prop.children [
            match page with
            | FssPage page ->
                match page with
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
                    | AttributeSelectors -> Suspense attributeSelectors
                    | MediaQueries -> Suspense mediaQueries
                    | Counters -> Suspense counters
                    | Fonts -> Suspense fonts
                    | BackgroundImages -> Suspense backgroundImages
                    | Svg -> Suspense svg
                    | GlobalStyles -> Suspense globalStyles
            | LibraryPage page ->
                match page with
                | Core -> Suspense core
                | Fable -> Suspense fable
                | Feliz -> Suspense feliz
                | Giraffe -> Suspense giraffe
            | OtherPage page ->
                match page with
                | Troubleshoot -> Suspense troubleshoot
        ]
    ]

[<ReactComponent>]
let Content (page: Page) =
    let store, _ = useStore()
    Html.div [
        prop.fss [
            Position.relative
            MarginLeft.value (px 0)
            MarginRight.value (px 0)
            MarginTop.auto
            MarginBottom.auto
            Padding.value(px 50, px 50, px 500, px 250)
            BackgroundColor.value store.Theme.BackgroundColor
            Color.value store.Theme.TextColor
        ]
        prop.children [
            Menu ()
            Main page
        ]
    ]

[<ReactComponent>]
let App () =
    global' [
        Visited [
            Color.inherit'
        ]

        ! (Selector.Tag Html.Body) [
            OverflowX.hidden
            font
        ]
    ]

    let currentUrl, updateUrl = React.useState (Router.currentUrl ())
    let store, _ = useStore()

    Html.div [
        prop.fss [
            Position.absolute
            Top.value (px 0)
            Width.value (pct 100)
            Height.value (pct 100)
            Margin.value(px 0)
            Padding.value(px 0)
            Border.none
            BackgroundColor.value store.Theme.BackgroundColor
        ]
        prop.children [
            React.router [ router.onUrlChanged updateUrl
                           router.children [ match currentUrl with
                                             | [] -> Content (FssPage Overview)
                                             | [ "page"; page ] ->
                                                 let page = stringToPage page

                                                 match page with
                                                 | Page.Unknown -> Content Page.Unknown
                                                 | _ -> Content page
                                             | _ -> Content NotFound ] ]
            ]
    ]

ReactDOM.render (StoreProvider <| App(), document.getElementById "app")
