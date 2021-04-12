## Pseudo-Classes

All pseudo class functions take a list of CSS properties and return a CSS property, which the `fss` function takes as a parameter.

So using pseudoclasses is as easy as calling them within the `fss` function.

Hover for example is done like so:
```fsharp
let hoverStyle =
     fss
         [
            Padding' (px 40)
            Width' (px 100)
            BackgroundColor.orangeRed
            FontSize' (px 20)
            BorderRadius' (px 5)
            Color.white
            Hover
                [
                    BackgroundColor.chartreuse
                    Color.black
                ]
         ]
```

## Pseudo-elements

These work much in the same way as the pseudo classes. Example follows:

```fsharp
let beforeAndAfterStyle =
    let beforeAndAfter =
        [
            Content.value ""
            Display.inlineBlock
            BackgroundColor.orangeRed
            Width' (px 10)
            Height' (px 10)
        ] // Note how we haven't called fss here, we do that below for both ::before and ::after
    fss
        [
            Before beforeAndAfter
            After beforeAndAfter
        ]
div [ ClassName beforeAndAfter ]
    [
        str " Some content surrounded by stuff "
    ]
```