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

Most pseudoclasses are supported. This includes things like `not`, `where`, `is` and `has`.

```fsharp
fss [
    ! (Selector.Tag Fss.Types.Html.A) [
        Has [ Selector.Tag Fss.Types.Html.Img; Selector.Tag Fss.Types.Html.Section ] [
            BorderWidth.value (px 2)
        ]
    ]
] 
```
becomes 
```css
.classname a:has(img,section) {
    border-width:2px;
}
```
All of these are extensively tested, so look at the tests for more examples.


```fsharp
fss [
    Has [Selector.Custom "article :first-child"] [
        MarginBlockStart.value (px 0)
    ]
]
```
becomes
```css
.classname:has(article :first-child) {
    margin-block-start: 0px;
}
```

### Escape hatch
If you need any special selectors inside your pseudo-classes currently not supported you can use the escape hatch.


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
