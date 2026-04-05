module Page.CascadeLayers

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let CascadeLayers () =
    let base' = Layer.define "base"
    let theme = Layer.define "theme"

    let box1 =
        fss [
            Padding.value (px 20)
            BorderRadius.value (px 8)
            FontWeight.bold
            Layer.layer base' [
                BackgroundColor.hex "#e74c3c"
                Color.white
            ]
            Layer.layer theme [
                BackgroundColor.hex "#2ecc71"
                Color.white
            ]
        ]

    let box2 =
        fss [
            Padding.value (px 20)
            BorderRadius.value (px 8)
            FontWeight.bold
            Layer.layer theme [
                BackgroundColor.hex "#3498db"
                Color.white
            ]
            Layer.layer base' [
                BackgroundColor.hex "#e74c3c"
                Color.white
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

    let styles =
        [ Html.div [
            prop.className wrapper
            prop.children [
                Html.span [ prop.className label; prop.text "Both boxes set colors in 'base' (red) and 'theme' (green/blue). The last layer declared wins." ]
                Html.div [ prop.className box1; prop.text "theme layer wins (green) because it is declared after base" ]
                Html.div [ prop.className box2; prop.text "base layer wins (red) because it is declared after theme" ]
            ]
          ] ]

    Page (Pages.FssPage Pages.CascadeLayers) styles

JsInterop.exportDefault CascadeLayers
