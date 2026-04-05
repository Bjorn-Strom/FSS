## Cascade layers

CSS has a specificity problem. When two rules target the same element, the more specific selector wins. This seems reasonable until your codebase grows and you end up writing `.page .sidebar .card .header h2` just to override `.card h2`. Then someone adds `!important` and things spiral from there.

Cascade layers solve this by letting you control *which group of styles wins* regardless of how specific the selectors are.

### Live example

<example/>

### The idea

Think of layers like transparent sheets stacked on top of each other. You decide the order of the sheets. Anything on a higher sheet wins over anything on a lower sheet, no matter what.

```
utilities  (top, wins)
components
base       (bottom, loses)
```

A plain `Color.red` in the `utilities` layer will beat an extremely specific selector in `base`. You do not need `!important`. You do not need to increase specificity. You just put the rule in the right layer.

### Defining layers

In Fss, you create layers with `Layer.define` and declare their order with `createLayerOrder`:

```fsharp
let base' = Layer.define "base"
let components = Layer.define "components"
let utilities = Layer.define "utilities"

// Later layers have higher priority
let order = createLayerOrder [ base'; components; utilities ]
```

The order matters. `utilities` is listed last, so it wins over everything before it.

### Putting rules in layers

Use `Layer.layer` inside `fss` to assign rules to a specific layer:

```fsharp
let heading =
    fss [
        Layer.layer base' [
            Color.black
            FontSize.value (px 24)
        ]
        Layer.layer components [
            Color.darkBlue
        ]
    ]
```

The heading will be dark blue, because `components` has higher priority than `base'`. It does not matter that `base'` also sets a color. The layer order decides.

### A practical example

Imagine you have a design system with base styles, component styles, and utility overrides:

```fsharp
let base' = Layer.define "base"
let components = Layer.define "components"
let utilities = Layer.define "utilities"

let order = createLayerOrder [ base'; components; utilities ]

// Base: sensible defaults
let text =
    fss [
        Layer.layer base' [
            Color.black
            LineHeight.value 1.6
        ]
    ]

// Component: specific styling
let card =
    fss [
        Layer.layer components [
            Padding.value (px 16)
            BackgroundColor.white
            BorderRadius.value (px 8)
        ]
    ]

// Utility: quick overrides that always win
let hidden =
    fss [
        Layer.layer utilities [
            Display.none
        ]
    ]
```

The `hidden` utility will always work, even on elements with complex component styles. No specificity battles.

### Anonymous layers

Sometimes you want the isolation benefits of a layer without needing to reference it by name. Use `Layer.anonymous`:

```fsharp
let isolated =
    fss [
        Layer.anonymous [
            Color.red
            Display.flex
        ]
    ]
```

Anonymous layers sit at the bottom of the priority order, below any named layers.

### Layers and media queries

Layers work naturally with other Fss features:

```fsharp
let responsive =
    fss [
        Layer.layer utilities [
            Display.flex
            Media.query [ Media.MaxWidth (px 768) ] [
                FlexDirection.column
            ]
        ]
    ]
```

### Further reading

For a thorough introduction to cascade layers, see Lullabot's [Introduction to CSS Cascade Layers](https://www.lullabot.com/articles/introduction-css-cascade-layers).
