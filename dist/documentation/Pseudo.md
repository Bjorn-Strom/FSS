## Pseudo-Classes

All pseudo class functions take a list of CSS properties and return a CSS property, which the `fss` function takes as a parameter.

So using pseudoclasses is as easy as calling them within the `fss` function.

Hover for example is done like so:
```fsharp
let hoverStyle =
    fss [ Label "Hover Style"
          Padding.value (px 40)
          Width.value (px 100)
          BackgroundColor.orangeRed
          FontSize.value (px 20)
          BorderRadius.value (px 5)
          Color.white
          Hover [ BackgroundColor.chartreuse
                  Color.black ] ]
```
</example>
## Pseudo-elements

These work much in the same way as the pseudo classes. Example follows:

```fsharp
let hoverStyle =
    fss [ Label "Hover Style"
          Padding.value (px 40)
          Width.value (px 100)
          BackgroundColor.orangeRed
          FontSize.value (px 20)
          BorderRadius.value (px 5)
          Color.white
          Hover [ BackgroundColor.chartreuse
                  Color.black ] ]

```
</example>
