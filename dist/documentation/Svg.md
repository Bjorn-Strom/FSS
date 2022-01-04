## SVG

You can style and animate SVGs as you normally would. CSS properties to style these were added with Fss 2.0.

A quick example of how to animate an svg:

```fsharp
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
```

</example>
