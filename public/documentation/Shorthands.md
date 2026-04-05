## Shorthands

CSS shorthands let you set multiple related properties in a single declaration.
FSS supports shorthands using F# optional parameters, so you only specify the values you need.

All shorthand parameters are optional unless noted. The generated CSS only includes the values you provide.

### Border

`Border.value(?width, ?style, ?color)`

```fsharp
fss [ Border.value(px 2, Border.Style.Solid, hex "6495ed") ]
// border: 2px solid #6495ed;

fss [ Border.value(style = Border.Style.Dashed) ]
// border: dashed;
```

<example/>

### Outline

`Outline.value(?width, ?style, ?color)`

Works identically to Border.

```fsharp
fss [ Outline.value(px 3, Outline.Style.Dashed, hex "ff6347") ]
// outline: 3px dashed #ff6347;

fss [ Outline.value(style = Outline.Style.Solid, color = rgb 255 0 0) ]
// outline: solid rgb(255,0,0);
```

<example/>

### Column Rule

`ColumnRule.value(?width, ?style, ?color)`

Same pattern as Border/Outline but for multi-column layouts.

```fsharp
fss [ ColumnRule.value(px 1, Column.RuleStyle.Solid, hex "808080") ]
// column-rule: 1px solid #808080;
```

### Font

`Font.value(size, family, ?style, ?weight, ?lineHeight)` -- **size** and **family** are required.

Size and line-height are joined with `/` as per the CSS spec.

```fsharp
fss [ Font.value(px 16, "Arial") ]
// font: 16px Arial;

fss [ Font.value(px 16, "Arial", style = Font.Style.Italic, weight = Font.Weight.Bold) ]
// font: italic bold 16px Arial;

fss [ Font.value(px 16, "Georgia", lineHeight = em 1.5) ]
// font: 16px/1.5em Georgia;

// Weight as int
fss [ Font.value(px 14, "sans-serif", 700) ]
// font: 700 14px sans-serif;
```

<example/>

### Flex

`Flex.value(?grow, ?shrink, ?basis)`

Also provides `Flex.auto` and `Flex.none`.

```fsharp
fss [ Flex.value(grow = 1.0) ]
// flex: 1;

fss [ Flex.value(grow = 0.0, shrink = 0.0, basis = px 200) ]
// flex: 0 0 200px;

fss [ Flex.auto ]
// flex: auto;

fss [ Flex.none ]
// flex: none;
```

<example/>

### Text Decoration

`TextDecoration.value(?line, ?style, ?color, ?thickness)`

```fsharp
fss [ TextDecoration.value(
        line = Text.DecorationLine.Underline,
        style = Text.DecorationStyle.Wavy,
        color = rgb 255 0 0) ]
// text-decoration: underline wavy rgb(255,0,0);
```

### List Style

`ListStyle.value(?type', ?position, ?image)`

```fsharp
fss [ ListStyle.value(
        type' = ListStyle.Type.Disc,
        position = ListStyle.Position.Inside) ]
// list-style: disc inside;

fss [ ListStyle.value(type' = ListStyle.Type.Square) ]
// list-style: square;
```

### Transition

Single transition with optional parameters:

`Transition.value(?transitionProperty, ?duration, ?timingFunction, ?delay)`

```fsharp
fss [ Transition.value(
        transitionProperty = Property.Opacity,
        duration = sec 0.3,
        timingFunction = TimingFunction.Ease) ]
// transition: opacity 0.3s ease;
```

Multiple transitions using `Transition.create`:

```fsharp
fss [ Transition.value(
        [ Transition.create(transitionProperty = Property.Opacity, duration = sec 0.3)
          Transition.create(
              transitionProperty = Property.Transform,
              duration = sec 0.5,
              timingFunction = TimingFunction.EaseIn) ]) ]
// transition: opacity 0.3s, transform 0.5s ease-in;
```

### Global values and none

All shorthands support global CSS values:

```fsharp
fss [ Border.initial ]
fss [ Outline.inherit' ]
fss [ TextDecoration.unset ]
fss [ Transition.revert ]
```

Border, Outline, Flex, and Transition also support `.none`:

```fsharp
fss [ Border.none ]
fss [ Outline.none ]
fss [ Flex.none ]
fss [ Transition.none ]
```

### Colors in shorthands

The `Color` binding (for the CSS `color` property) shadows the `Fss.Types.Color` type, so named colors need either full qualification or a helper function:

```fsharp
// Use hex, rgb, rgba, etc. - these work directly
Border.value(px 2, Border.Style.Solid, hex "008000")
Outline.value(style = Outline.Style.Solid, color = rgb 255 0 0)

// Named colors need Fss.Types qualification
Border.value(color = Fss.Types.Color.Green)
```
