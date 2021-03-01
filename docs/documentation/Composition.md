## Composition

As Fss uses [Emotion-Js](https://github.com/emotion-js/emotion) to generate the CSS we get some nice benefits like [composition](https://emotion.sh/docs/composition). Feel free to read emotions composition docs, the following example is a re-implementation of theirs.

```fsharp
let baseStyle =
    [
        BackgroundColor.darkGreen
        Color.turquoise
    ]
let danger = [ Color.red ]
```

Note that we have nit called `fss` yet.

```fsharp
div [ ClassName (fss baseStyle) ]
    [ str "This will be turquoise" ]
div [ ClassName (fss <| danger @ baseStyle)]
    [ str "This will be also be turquoise since the base styles overwrite the danger styles."]
div [ ClassName (fss <| baseStyle @ danger)]
    [ str "This will be red" ]
```