[<AutoOpen>]
module Spinner

open Feliz
open Fss

let spinner = keyframes [
  frame 0 [
    Transform.value [
      Transform.translateX(px 0)
      Transform.rotateZ(deg 0)
    ]
    BorderRadius.value (px 0)
    BackgroundColor.hex "8E24C9"
  ]
  frame 50 [
    BorderRadius.value (px 10)
    BackgroundColor.hex "FF8034"
  ]
  frame 100 [
    Transform.value [
      Transform.translateX(px 100)
      Transform.rotateZ(deg 360)
    ]
    BorderRadius.value (px 0)
    BackgroundColor.hex "FF5B5B"
  ]
]

[<ReactComponent>]
let Spinner () =
  Html.div [
    prop.fss [
      Display.flex
      JustifyContent.center
      AlignItems.center
      Height.value (vh 100)
    ]
    prop.children [
      Html.div [
        prop.fss [
          AnimationName.value spinner
          AnimationDuration.value (sec 1)
          AnimationIterationCount.infinite
          AnimationDirection.alternate
          AnimationTimingFunction.easeInOut
          Width.value (px 15)
          Height.value (px 15)
        ]
      ]
    ]
  ]
