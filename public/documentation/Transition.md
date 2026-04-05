## Transition

Transitions can be specified using individual properties or the shorthand.

### Individual properties

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

### Shorthand

The `Transition.value` shorthand accepts optional parameters for property, duration, timing function, and delay:

```fsharp
let shorthandTransition =
    fss [ Label "Shorthand Transition"
          BackgroundColor.red
          Transition.value(transitionProperty = Property.BackgroundColor, duration = sec 0.3, timingFunction = TimingFunction.Ease)
          Hover [ BackgroundColor.green ]
        ]
```

For multiple transitions, use `Transition.create` to build a list:

```fsharp
let multiTransition =
    fss [ Label "Multi Transition"
          Opacity.value 1.0
          BackgroundColor.red
          Transition.value(
              [ Transition.create(transitionProperty = Property.Opacity, duration = sec 0.3)
                Transition.create(transitionProperty = Property.BackgroundColor, duration = sec 0.5, timingFunction = TimingFunction.EaseIn) ])
          Hover [ Opacity.value 0.5
                  BackgroundColor.green ]
        ]
```

### TransitionBehavior

`TransitionBehavior` controls whether transitions are allowed on discrete properties (like `display`):

```fsharp
fss [ TransitionBehavior.allowDiscrete ]
fss [ TransitionBehavior.normal ]
```
