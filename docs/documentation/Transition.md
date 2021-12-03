## Transition

The biggest difference here is that there is no transition shorthand.

Apart from that transitions will work as you expect

```fsharp
let colorTransition =
    fss
        [
            BackgroundColor.red
            TransitionProperty.backgroundColor
            TransitionDuration' (sec 2.5)
            TransitionTimingFunction.ease
            Hover [ BackgroundColor.green ]
       ]
div [ ClassName colorTransition ] [ str "Hover me" ]
```

</example>

````fsharp
let sizeAndColor =
    fss
        [
            Width' (px 40)
            Height' (px 40)
            BackgroundColor.yellowGreen
            TransitionProperty.all
            TransitionTimingFunction.linear
            TransitionDuration' (ms 500.)
            Hover
                [
                    BorderRadius' (pct 100)
                    BackgroundColor.orangeRed
                ]
        ]
div [ ClassName sizeAndColor ] [ ]
````

</example>
