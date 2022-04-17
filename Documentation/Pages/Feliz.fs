module Page.Feliz

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Feliz ()  =
    let bounceFrames =
        keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                        Transform.value [ Transform.translate3D (px 0, px 0, px 0) ]
                    ]
                    frames [ 40; 43 ] [
                        Transform.value [ Transform.translate3D (px 0, px -30, px 0) ]
                    ]
                    frame 70 [ Transform.value [ Transform.translate3D (px 0, px -15, px 0) ] ]
                    frame 90 [ Transform.value [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

    let box =
        Html.div [ prop.fss [ BackgroundColor.red
                              Width.value (px 200)
                              Height.value (px 200)
                              Hover [ BackgroundColor.blue ] ] ]

    let bounceBox =
        Html.div [ prop.fss [ BackgroundColor.red
                              Width.value (px 200)
                              Height.value (px 200)
                              Hover [ BackgroundColor.blue ]
                              AnimationName.value bounceFrames
                              AnimationDuration.value (sec 1.0)
                              AnimationTimingFunction.easeInOut
                              AnimationIterationCount.infinite ] ]

    let styles = [ box; bounceBox ]
    Page Pages.Feliz styles

JsInterop.exportDefault Feliz