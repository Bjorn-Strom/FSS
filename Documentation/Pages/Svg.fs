module Page.Svg

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Svg () =
    let logoAnimation =
        keyframes [ frame 100 [ Svg.StrokeDashoffset.value [ 0 ] ] ]

    let logoStyle =
        fss [ Svg.Stroke.black
              Svg.StrokeWidth.value (px 4)
              Svg.StrokeDashoffset.value [ 1000 ]
              Svg.StrokeDasharray.value [ 1000 ]
              AnimationName.value logoAnimation
              AnimationDuration.value (sec 5.)
              AnimationTimingFunction.linear
              AnimationFillMode.forwards ]

    let styles = [ Logo.logo 256 256 logoStyle ]

    Page (Pages.FssPage Pages.Svg) styles

JsInterop.exportDefault Svg
