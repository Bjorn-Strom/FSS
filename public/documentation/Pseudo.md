## Pseudo-Classes

All pseudo class functions take a list of CSS rules and return a new CSS rule, which the `fss` function takes as a parameter.

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
                  Color.black
                ] 
        ]
```
<example/>
### Selector pseudo-classes: `:has()`, `:is()`, `:where()`

These pseudo-classes take a `Selector list` instead of a plain rule list. Use `Selector.Class`, `Selector.Id`, or tag shortcuts like `Selector.h1` to build the selector list:

```fsharp
// :has() - matches elements that have a descendant matching the selector
fss [ Has [Selector.Class "active"] [
        BorderColor.green
    ]
]

// :is() - matches any of the given selectors (with normal specificity)
fss [ Is [Selector.h1; Selector.h2; Selector.h3] [
        Color.darkBlue
    ]
]

// :where() - same as :is() but with zero specificity
fss [ Where [Selector.Class "card"; Selector.Class "panel"] [
        Padding.value (px 16)
    ]
]
```

You can also reference Fss-generated classnames with `Selector.Class`. Here the container gets an orange border because it contains a child with the `highlightStyle` class:

```fsharp
let highlightStyle =
    fss [ BackgroundColor.yellow
          Padding.value (px 4) ]

let containerStyle =
    fss [ Padding.value (px 16)
          Border.value (px 2, Border.Style.Solid, Fss.Types.Color.Gray)
          Has [Selector.Class highlightStyle] [
              Border.value (px 2, Border.Style.Solid, Fss.Types.Color.Orange)
          ]
    ]
```

<example/>

## Pseudo-elements

These work much in the same way as the pseudo classes. Example follows:

```fsharp
let beforeAndAfter =
    let beforeAndAfter =
        [ Content.value ""
          Display.inlineBlock
          BackgroundColor.orangeRed
          Width.value (px 10)
          Height.value (px 10)
        ]

    fss [ Label "Before And After"
          Before beforeAndAfter
          After beforeAndAfter 
        ]
```
<example/>
