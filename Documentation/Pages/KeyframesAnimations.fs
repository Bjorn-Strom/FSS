module Page.KeyframesAnimations

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let KeyframesAnimations () =
    let bounceFrames =
        keyframes [ frames [ 0; 20; 53; 80; 100 ] [
                        Transform.value [ Transform.translate3D (px 0, px 0, px 0) ]
                    ]
                    frames [ 40; 43 ] [
                        Transform.value [ Transform.translate3D (px 0, px -30, px 0) ]
                    ]
                    frame 70 [ Transform.value [ Transform.translate3D (px 0, px -15, px 0) ] ]
                    frame 90 [ Transform.value [ Transform.translate3D (px 0, px -4, px 0) ] ] ]

    let backgroundColorFrames =
        keyframes [ frame 0 [ BackgroundColor.red ]
                    frame 30 [ BackgroundColor.green ]
                    frame 60 [ BackgroundColor.blue ]
                    frame 100 [ BackgroundColor.red ] ]

    let bounceAnimation =
        fss [ Label "Bounce Animation"
              AnimationName.value bounceFrames
              AnimationDuration.value (sec 1.0)
              AnimationTimingFunction.easeInOut
              AnimationIterationCount.infinite ]

    let bouncyColor =
        fss [ Label "Bouncy Color"
              AnimationName.value [ bounceFrames
                                    backgroundColorFrames ]
              AnimationDuration.value [ sec 1.0
                                        sec 5.0 ]
              AnimationTimingFunction.value [ Fss.Types.TimingFunction.EaseInOut
                                              Fss.Types.TimingFunction.Ease ]
              AnimationIterationCount.value [ Fss.Types.Animation.Infinite
                                              Fss.Types.Animation.IterationCount.Value 3 ] ]

    let styles =
        [ Html.div [ Html.div [ prop.className bounceAnimation
                                prop.text "Bouncy bounce" ]
                     Html.div [ prop.className bouncyColor
                                prop.text "Bouncy color" ] ] ]

    Page Pages.KeyframesAnimations styles

JsInterop.exportDefault KeyframesAnimations
