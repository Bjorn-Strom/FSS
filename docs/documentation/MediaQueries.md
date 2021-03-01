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
               [ Media.MinHeight (px 700)]
               [ BackgroundColor.pink ]

           MediaQueryFor Media.Print
               []
               [
                   MarginTop' (px 200)
                   Transforms
                       [
                           Transform.Rotate(deg 45.0)
                       ]
                   BackgroundColor.red
               ]
           MediaQuery
               [ Media.Orientation Media.Landscape]
               [ Color.green; FontSize.Value (px 28)]
```
