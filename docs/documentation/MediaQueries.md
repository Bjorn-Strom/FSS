## Media queries

Using media queries in Fss is similar to how you would with normal css - except you have 2 functions to use here.

- `MediaQuery` - which takes a list of features which define when the CSS block should be active and a list of CSSProperties which is the styles to be active.
- `MediaQueryFor` - Which takes a device and then the list of features and a list of CSSProperties

```fsharp
let mediaQueryExamples =
    fss
       [
           Width' (px 200)
           Height' (px 200)
           BackgroundColor.blue

           MediaQuery
               [ FssTypes.Media.MinWidth (px 700)]
               [ BackgroundColor.pink
                 Color.orangeRed
               ]

           MediaQueryFor FssTypes.Media.Print
               []
               [
                   MarginTop' (px 200)
                   Transforms
                       [
                           Transform.rotate(deg 45.0)
                       ]
                   BackgroundColor.red
               ]
           MediaQuery
               [ FssTypes.Media.Orientation FssTypes.Media.Landscape]
               [ Color.green
                 BackgroundColor.orangeRed
                 FontSize.value (px 28)]
       ]
```

</example>
