## Transition

The biggest difference here is that there is no transition shorthand.

Apart from that transitions will work as you expect

```fsharp
let colorTransition =
    fss [ Label "Color Transition"
          BackgroundColor.red
          TransitionProperty.backgroundColor
          TransitionDuration.value (sec 2.5)
          TransitionTimingFunction.ease
          Hover [ BackgroundColor.green ]
        ]
```

<example/>

```fsharp
let sizeAndColor =
    fss [ Label "Size and Color"
          Width.value (px 40)
          Height.value (px 40)
          BackgroundColor.yellowGreen
          TransitionProperty.all
          TransitionTimingFunction.linear
          TransitionDuration.value (ms 500.)
          Hover [ BorderRadius.value (pct 100)
                  BackgroundColor.orangeRed
                ]
       ]
```

<example/>
