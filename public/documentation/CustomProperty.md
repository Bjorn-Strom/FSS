## Custom properties (@property)

CSS custom properties (also called CSS variables) let you define reusable values with `--my-color: blue`. They are powerful, but the browser treats them as dumb strings. It does not know if `--my-color` is a color, a length, or just random text. That means you can not animate them, the browser can not validate them, and there are no useful defaults when they are missing.

`@property` changes this. It lets you register a custom property with a type, an initial value, and whether child elements should inherit it.

### Live example

<example/>

### Why this matters

Without `@property`, you can not transition a custom property:

```css
/* This does NOT animate smoothly */
.card {
  --card-color: red;
  background: var(--card-color);
  transition: --card-color 0.3s;
}
.card:hover {
  --card-color: blue;
}
```

The browser does not know `--card-color` is a color, so it swaps the value instantly instead of transitioning smoothly. When you register the property with `@property`, the browser understands the type and can interpolate between values.

### Registering a property

Use `createProperty` to register a custom property:

```fsharp
let colorProperty =
    createProperty "--card-color" CustomProperty.Color false "red"
```

This generates:

```css
@property --card-color {
  syntax: "<color>";
  inherits: false;
  initial-value: red;
}
```

The four arguments are:

1. **Name**: the custom property name, starting with `--`
2. **Syntax**: what type of value this property holds
3. **Inherits**: whether child elements inherit this value from their parent
4. **Initial value**: the default value when the property is not set

### Available syntax types

The syntax tells the browser what kind of value to expect:

```
CustomProperty.Color              "<color>"
CustomProperty.Length             "<length>"
CustomProperty.Percentage         "<percentage>"
CustomProperty.LengthPercentage   "<length-percentage>"
CustomProperty.Number             "<number>"
CustomProperty.Integer            "<integer>"
CustomProperty.Angle              "<angle>"
CustomProperty.Time               "<time>"
CustomProperty.Resolution         "<resolution>"
CustomProperty.Image              "<image>"
CustomProperty.TransformFunction  "<transform-function>"
CustomProperty.TransformList      "<transform-list>"
CustomProperty.Url                "<url>"
CustomProperty.CustomIdent        "<custom-ident>"
CustomProperty.Any                "*"
CustomProperty.Custom "..."       any custom syntax string
```

### Practical example: animatable custom properties

One of the most popular uses of `@property` is animating values that normally can not be animated. Without registration, the browser sees custom properties as strings and swaps them instantly. With registration, it knows the type and can interpolate.

For example, you can register a color property and smoothly transition between theme colors:

```fsharp
// Register --accent as a color so the browser can transition it
let accentProperty =
    createProperty "--accent" CustomProperty.Color false "#3498db"

// Use it in a style. When --accent changes, it transitions smoothly.
let button =
    fss [
        BackgroundColor.hex "#3498db"
        TransitionDuration.value (ms 300.)
        TransitionProperty.backgroundColor
    ]
```

This also works with angles (rotating gradients), lengths (growing/shrinking), percentages (progress indicators), and any other registered type.

### Inheritance

The `inherits` flag controls whether children pick up the value from their parent.

```fsharp
// Children will inherit this value
let themeColor =
    createProperty "--theme-color" CustomProperty.Color true "black"

// Each element needs its own value
let progress =
    createProperty "--progress" CustomProperty.Percentage false "0%"
```

Setting `inherits` to `true` is useful for theme-level properties that should flow down the tree. Setting it to `false` makes sense for component-specific values that should not leak to children.

### Initial values as fallbacks

The initial value acts as a fallback. If an element uses `var(--card-color)` but no one has set `--card-color`, the browser uses the initial value from `@property` instead of breaking.

This is more reliable than the `var(--card-color, red)` fallback syntax because it applies everywhere the property is used, not just at each individual `var()` call.
