## Colors

Fss supports all modern CSS color functions as type-safe F# values.

### light-dark()

The `light-dark()` function returns one of two colors depending on the user's color scheme. Pair it with `ColorScheme.lightDark` to enable automatic switching:

```fsharp
let lightDarkBox =
    fss [ ColorScheme.lightDark
          Color.lightDark (Fss.Types.Color.Hex "1a1a2e") (Fss.Types.Color.Hex "f5f5dc")
          BackgroundColor.lightDark (Fss.Types.Color.Hex "fffbe6") (Fss.Types.Color.Hex "1a1a2e")
          Border.value(px 3, Border.Style.Solid, lightDark (Fss.Types.Color.Hex "e6a817") (Fss.Types.Color.Hex "7c6fe0"))
          Padding.value (px 24)
          BorderRadius.value (px 8) ]
```

<example/>

`light-dark()` can be used on any color property. The standalone `lightDark` helper creates color values directly, while `Color.lightDark`, `BackgroundColor.lightDark`, etc. set the property in one step.

### color-mix()

`color-mix()` blends two colors in a given color space:

```fsharp
let mixed =
    fss [ BackgroundColor.colorMix "srgb" Fss.Types.Color.Red 50 Fss.Types.Color.Blue 50 ]
```

<example/>

You can use any color space (`srgb`, `oklch`, `oklab`, `hsl`, etc.) and any percentage split.

The standalone `colorMix` helper works the same way:

```fsharp
Color.value (colorMix "oklch" Fss.Types.Color.White 30 Fss.Types.Color.Black 70)
```

### Other color functions

Fss supports the full range of modern color functions:

```fsharp
// Named colors
Color.red
BackgroundColor.cornflowerBlue

// Classic functions
Color.rgb 255 0 0
Color.hex "ff6347"
Color.hsl 120 100 50

// Modern functions
Color.oklch 0.7 0.15 180.0
Color.oklab 0.5 -0.1 0.1
Color.lch 50.0 80.0 120.0
Color.lab 50.0 30.0 -20.0
Color.hwb 0.0 0.0 0.0
```

All of these also have standalone helpers (`rgb`, `hex`, `hsl`, `oklch`, `oklab`, `lch`, `lab`, `hwb`) that return `Color` values for use anywhere a color is expected.
