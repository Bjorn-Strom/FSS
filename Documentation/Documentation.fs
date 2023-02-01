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

let falco: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Falco.fs"

let troubleshoot: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Troubleshoot.fs"

let changelog: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Pages/Changelog.fs"

[<ReactComponent>]
let Suspense (component': JS.Promise<unit -> ReactElement>) =
    React.suspense ([ Html.div [ React.lazy' (component', ()) ] ], Spinner())

[<ReactComponent>]
let MenuItem (page: Page) =
    let _, dispatch = useStore()
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
                prop.onClick (fun _ -> dispatch ToggleSidebar)
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
             TransitionProperty.left
             TransitionTimingFunction.easeInOut
             TransitionDuration.value (ms 500.)
             ZIndex.value 11

             Media.query [ Media.MaxWidth(px 700) ] [
                 if store.ShowSidebar = false then
                    Left.value (pct -100)
                 else
                    Left.value (pct 0)
             ]
         ]
         prop.children [
             Html.div [
                 prop.id "Shadow"
                 prop.onClick (fun _ -> dispatch ToggleSidebar)
                 prop.fss [
                     Position.fixed'
                     Top.value (px 0)
                     Right.value (px 0)
                     Bottom.value (px 0)
                     Left.value (px 0)
                     BackgroundColor.rgba 0 0 0 0
                     Visibility.hidden
                     TransitionProperty.backgroundColor
                     TransitionDuration.value (ms 500.)

                     Media.query [Media.MaxWidth (px 700)] [
                        if store.ShowSidebar then
                            BackgroundColor.rgba 0 0 0 0.5
                            Visibility.visible
                     ]
                 ]
             ]
             Html.div [
                 prop.fss [
                     Position.absolute
                     Display.flex
                     FlexDirection.column
                     Left.value (px 0)
                     Top.value (px 0)
                     Bottom.value (px 0)
                     Padding.value(px 50, px 70, px 30, px 30)
                     OverflowY.auto
                     BackgroundColor.value store.Theme.BackgroundColor
                 ]
                 prop.children [
                     Html.a [
                         prop.fss [
                             AlignSelf.end'
                         ]
                         prop.id "logo"
                         prop.href "/"
                         prop.children [
                             Logo.logo 128 128 ""
                         ]
                     ]
                     Html.ul [
                         prop.id "menuItems"
                         prop.children (List.map MenuItems allPages)
                     ]
                     Html.div [
                         prop.fss [
                             AlignSelf.center

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
                                 prop.fss [
                                     Cursor.pointer
                                 ]
                                 prop.href "javascript:void(0)"
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
                | Falco -> Suspense falco
            | OtherPage page ->
                match page with
                | Troubleshoot -> Suspense troubleshoot
                | Changelog -> Suspense changelog
        ]
    ]

[<ReactComponent>]
let TopBar () =
    let store, dispatch = useStore()
    Html.div [
        prop.fss [
             Position.fixed'
             Left.value (px 0)
             Top.value (pct -100)
             Width.value (vw 100.)
             Height.value (px 50)
             PaddingLeft.value (px 25)
             BackgroundColor.value store.Theme.TopBar
             BoxShadow.value(px 0, px 1, px 10, Fss.Types.Color.Black)

             Display.flex
             AlignItems.center
             ZIndex.value 10

             TransitionProperty.top
             TransitionTimingFunction.easeInOut
             TransitionDuration.value (ms 500.)

             Media.query [ Media.MaxWidth (px 700) ] [
                 Top.value (px 0)
             ]
        ]
        prop.id "TopBar"
        prop.children [
            Html.div [
                prop.fss [
                    Cursor.pointer
                ]
                prop.children [
                    Hamburger.hamburger 32 32 ""
                ]
                prop.onClick(fun _ -> dispatch ToggleSidebar)
            ]
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
            Padding.value(px 50, px 50, px 500, px 280)
            BackgroundColor.value store.Theme.BackgroundColor
            Color.value store.Theme.TextColor
            TransitionProperty.paddingLeft
            TransitionTimingFunction.easeInOut
            TransitionDuration.value (ms 500.)

            Media.query [ Media.MaxWidth (px 700) ] [
                PaddingLeft.value(px 50)
            ]
        ]
        prop.children [
            Menu ()
            Main page
            TopBar ()
        ]
    ]

[<ReactComponent>]
let App () =
    global' [
        Visited [
            Color.inherit'
        ]

        Link [
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
            Left.value (px 0)
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



// This would be 'css647538688'
let someClass = fss [ ]

let contrast = fssWithName "dx-row-focused" [
        ! (Selector.Class someClass) [
            Color.white
        ]
    ]
