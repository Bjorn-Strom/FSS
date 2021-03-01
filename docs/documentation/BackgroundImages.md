## BackgroundImages

### Linear gradient

```fsharp
let linearGradientStyle1 =
    BackgroundImage.LinearGradient(deg 0.,
        [ hex "e66465", pct 0
          hex "9198e5", pct 100 ])

let linearGradientStyle2 =
    BackgroundImage.LinearGradient(turn 0.25,
                                   [hex "3f87a6", pct 0
                                    hex "ebf8e1", pct 50
                                    hex "f69d3c", pct 100])

let linearGradientStyle3 =
    BackgroundImage.LinearGradient(deg 270.,
                                   [
                                       hex "333", pct 0
                                       hex "333", pct 50
                                       hex "eee", pct 75
                                       hex "333", pct 75
                                   ])
```

### Repeating linear gradient
```fsharp
let repeatingLinearGradientStyle1 =
   BackgroundImage.RepeatingLinearGradient(deg 0.,
               [
                   hex "e66465", px 0
                   hex "e66465", px 20
                   hex "9198e5", px 20
                   hex "9198e5", px 25
               ])

let repeatingLinearGradientStyle2 =
   BackgroundImage.RepeatingLinearGradient(deg 45.,
                                  [
                                      hex "3f87a6", px 0
                                      hex "ebf8e1", px 15
                                      hex "f69d3c", px 20
                                  ])
```

### Radial gradient
```fsharp
let radialGradientStyle1 =
  BackgroundImage.RadialGradient(Ellipse, FarthestCorner, pct 50, pct 50,
             [ hex "e66465", pct 0
               hex "9198e5", pct 100])

let radialGradientStyle2 =
  BackgroundImage.RadialGradient(Ellipse, ClosestSide, pct 50, pct 50,
       [
           hex "3f87a6", pct 0
           hex "ebf8e1", pct 50
           hex "f69d3c", pct 100
       ])

let radialGradientStyle3 =
  BackgroundImage.RadialGradient(Circle, FarthestCorner, pct 100, pct 50,
        [
            hex "333", pct 0
            hex "333", pct 50
            hex "eee", pct 75
            hex "333", pct 75 ])
```

### Repeating Radial Gradient
```fsharp
let repeatingRadialGradientStyle1 =
    BackgroundImage.RepeatingRadialGradient(
            Ellipse, FarthestCorner, pct 50, pct 50,
                [
                    hex "e66465", pct 0
                    hex "9198e5", pct 20
                ])

let repeatingRadialGradientStyle2 =
   BackgroundImage.RepeatingRadialGradient(
        Ellipse, ClosestSide, pct 50, pct 50,
            [
                hex "3f87a6", pct 0
                hex "ebf8e1", pct 50
                hex "f69d3c", pct 100
            ])

let repeatingRadialGradientStyle3 =
    BackgroundImage.RepeatingRadialGradient(
            Circle, FarthestCorner, pct 100, pct 50,
                [
                    hex "333", px 0
                    hex "333", px 10
                    hex "eee", px 10
                    hex "eee", px 20
                ]
```

### Conic gradient
```fsharp
let conicGradientStyle1 =
    BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
                                  [
                                      CssColor.red, deg 0.
                                      CssColor.orange, deg 90.
                                      CssColor.yellow, deg 180.
                                      CssColor.green, deg 270.
                                      CssColor.blue, deg 360.
                                  ])

let conicGradientStyle2 =
     BackgroundImage.ConicGradient(rad 3.1416, pct 10, pct 50,
                                   [
                                         hex "#e66465", deg 0.
                                         hex "#9198e5", deg 360.
                                   ])

let conicGradientStyle3 =
     BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
                                   [
                                      CssColor.red, deg 6.
                                      CssColor.orange, deg 6.
                                      CssColor.orange, deg 18.
                                      CssColor.yellow, deg 18.
                                      CssColor.yellow, deg 45.
                                      CssColor.green, deg 45.
                                      CssColor.green, deg 110.
                                      CssColor.blue, deg 110.
                                      CssColor.blue, deg 200.
                                      CssColor.purple, deg 200.
                                   ])

let conicGradientStyle4 =
     BackgroundImage.ConicGradient(deg 0., pct 50, pct 50,
       [
          CssColor.yellow, deg (360. / 6.)
          CssColor.lime,   deg <| (360. / 6.) * 2.
          CssColor.blue,   deg <| (360. / 6.) * 3.
          CssColor.violet, deg <| (360. / 6.) * 4.
          CssColor.red,    deg <| (360. / 6.) * 5.
          CssColor.yellow, deg <| (360. / 6.) * 6.
       ])
```

### Repeating Conic gradient
```fsharp
let linearGradientStyle1 =
    BackgroundSize.Value(px 50, px 50)
    BorderColor.black
    BorderStyle.Solid
    BorderWidth' (px 1)
    BackgroundImage.RepeatingConicGradient(deg 0., pct 50, pct 50,
                                  [
                                     CssColor.white, pct 0
                                     CssColor.white, pct 25
                                     CssColor.black, pct 25
                                     CssColor.black, pct 50
                                  ])
```
