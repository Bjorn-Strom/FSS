## Media queries

Using media queries in Fss is similar to how you would with normal css - except you have 2 functions to use here.

- `MediaQuery` - which takes a list of features which define when the CSS block should be active and a list of CSSProperties which is the styles to be active.
- `MediaQueryFor` - Which takes a device and then the list of features and a list of CSSProperties

```fsharp
fss [ Label "Media query examples"
      Width.value (px 200)
      Height.value (px 200)
      BackgroundColor.blue

      Media.query [ FssTypes.Media.MinWidth(px 700) ] [
          BackgroundColor.pink
          Color.orangeRed
      ]

      Media.queryFor
          FssTypes.Media.Print
          []
          [ MarginTop.value (px 200)
            Transform.value [ Transform.rotate (deg 45.0) ]
            BackgroundColor.red ]

      Media.query [ FssTypes.Media.Orientation FssTypes.Media.Landscape ] [
          Color.green
          BackgroundColor.orangeRed
          FontSize.value (px 28)
      ] ]
```

</example>
