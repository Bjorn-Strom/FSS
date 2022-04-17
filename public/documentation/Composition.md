## Composition

A really useful pattern in Fss is composition. As long as you haven't called the Fss function yet you can compose styles by concatenating the lists
using normal F# syntax.

```fsharp
let baseStyle =
    [
        BackgroundColor.darkGreen
        Color.turquoise
    ]
let danger = [ Color.red ]
```

Note that we have not called `fss` yet.

```fsharp
div [ ClassName (fss baseStyle) ]
    [ str "This will be turquoise" ]
div [ ClassName (fss <| danger @ baseStyle)]
    [ str "This will be also be turquoise since the base styles overwrite the danger styles."]
div [ ClassName (fss <| baseStyle @ danger)]
    [ str "This will be red" ]
```
<example/>

You can also use the yield keyword

```fsharp
let baseWithFlex =
    fss [
        Display.flex
        yield baseStyle
    ]
```