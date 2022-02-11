## Media queries

Using media queries in Fss is similar to how you would with normal css - except you have 2 functions to use here.

- `Media.query` - which takes a list of features which define when the CSS block should be active and a list of CSSRules to use when it is active.
- `Media.queryFor` - Which takes a device before the list of features and rules.

```fsharp
fss [ Label "Media query examples"
      Width.value (px 200)
      Height.value (px 200)
      BackgroundColor.blue

      Media.query [ Fss.Types.Media.MinWidth(px 700) ] [
          BackgroundColor.pink
          Color.orangeRed
      ]

      Media.queryFor
          Fss.Types.Media.Print
          []
          [ MarginTop.value (px 200)
            Transform.value [ Transform.rotate (deg 45.0) ]
            BackgroundColor.red ]

      Media.query [ Fss.Types.Media.Orientation Fss.Types.Media.Landscape ] [
          Color.green
          BackgroundColor.orangeRed
          FontSize.value (px 28)
      ] ]
```

<example/>
