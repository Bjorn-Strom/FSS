module Page.CustomProperty

open Fss
open Fss.Types
open Feliz
open Fable.Core

[<ReactComponent>]
let CustomProperty () =
    let registeredProp =
        createProperty "--demo-color" CustomProperty.Color false "#3498db"

    let box =
        fss [
            Padding.value (px 20)
            BorderRadius.value (px 8)
            BackgroundColor.hex "#3498db"
            Color.white
            FontWeight.bold
            TransitionProperty.backgroundColor
            TransitionDuration.value (ms 500.)
            Hover [
                BackgroundColor.hex "#e74c3c"
            ]
        ]

    let wrapper =
        fss [
            Display.flex
            FlexDirection.column
            Gap.value (px 12)
        ]

    let label =
        fss [
            FontFamily.value "monospace"
            FontSize.value (px 13)
            Color.gray
        ]

    let codeBlock =
        fss [
            FontFamily.value "monospace"
            FontSize.value (px 13)
            Padding.value (px 12)
            BackgroundColor.hex "#f5f5f5"
            BorderRadius.value (px 4)
            WhiteSpace.pre
        ]

    let styles =
        [ Html.div [
            prop.className wrapper
            prop.children [
                Html.span [ prop.className label; prop.text "Hover the box below. The color transitions smoothly because the browser knows it is a color value." ]
                Html.div [ prop.className box; prop.text "Hover me to see a smooth color transition" ]
                Html.span [ prop.className label; prop.text "The @property registration that makes this possible:" ]
                Html.div [ prop.className codeBlock; prop.text registeredProp ]
            ]
          ] ]

    Page (Pages.FssPage Pages.CustomProperty) styles

JsInterop.exportDefault CustomProperty
