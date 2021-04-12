## SVG

You can style and animate SVGs as you normally would. CSS properties to style these were added with Fss 2.0.

A quick example of how to animate an svg:

```fsharp
let logoAnimation =
    keyframes [
        frame 100 [ StrokeDashoffset' [ 0 ] ]
    ]

let logoStyle =
    fss [
       Stroke.black
       StrokeWidth' <| px 4
       StrokeDashoffset' [ 1000 ]
       StrokeDasharray' [ 1000 ]
       AnimationName' logoAnimation
       AnimationDuration' <| sec 5.
       AnimationTimingFunction.linear
       AnimationFillMode.forwards
    ]

Logo.logo 256 256 logoStyle
```