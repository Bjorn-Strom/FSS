module Page.Transition

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Transition () =
    let colorTransition =
        fss [ Label "Color Transition"
              BackgroundColor.red
              TransitionProperty.backgroundColor
              TransitionDuration.value (sec 2.5)
              TransitionTimingFunction.ease
              Hover [ BackgroundColor.green ] ]

    let sizeAndColor =
        fss [ Label "Size and Color"
              Width.value (px 40)
              Height.value (px 40)
              BackgroundColor.yellowGreen
              TransitionProperty.all
              TransitionTimingFunction.linear
              TransitionDuration.value (ms 500.)
              Hover [ BorderRadius.value (pct 100)
                      BackgroundColor.orangeRed ] ]

    let styles =
        [ Html.div [ prop.className colorTransition
                     prop.text "Hover me" ]
          Html.div [ prop.className sizeAndColor ] ]

    Page (Pages.FssPage Pages.Transition) styles

JsInterop.exportDefault Transition
