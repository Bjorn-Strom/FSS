module Page.StartingStyle

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let StartingStyle () =
    let visible, setVisible = React.useState true

    let card =
        fss [
            Padding.value (px 20)
            BackgroundColor.hex "#6c5ce7"
            Color.white
            BorderRadius.value (px 8)
            FontWeight.bold

            Opacity.value 1.0
            Transform.value [ Transform.translateY(px 0) ]
            TransitionProperty.all
            TransitionDuration.value (ms 500.)

            StartingStyle.style [
                Opacity.value 0.0
                Transform.value [ Transform.translateY(px 20) ]
            ]
        ]

    let buttonStyle =
        fss [
            Padding.value (px 8, px 16)
            BorderRadius.value (px 4)
            BorderWidth.value (px 1)
            BorderStyle.solid
            BorderColor.hex "#ccc"
            BackgroundColor.white
            Cursor.pointer
            FontSize.value (px 14)
        ]

    let wrapper =
        fss [
            Display.flex
            FlexDirection.column
            Gap.value (px 16)
            AlignItems.flexStart
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
                Html.span [ prop.className label; prop.text "Click the button to remove and re-add the card. It fades in each time it appears." ]
                Html.button [
                    prop.className buttonStyle
                    prop.text (if visible then "Remove card" else "Add card")
                    prop.onClick (fun _ -> setVisible (not visible))
                ]
                if visible then
                    Html.div [ prop.className card; prop.text "I fade in when I appear" ]
            ]
          ] ]

    Page (Pages.FssPage Pages.StartingStyle) styles

JsInterop.exportDefault StartingStyle
