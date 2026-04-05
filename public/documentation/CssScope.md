## CSS Scope

When you style a `.title` class, that style applies to every `.title` on the page. In a small project that is fine. In a large project with many components, it leads to styles leaking where you do not want them.

`@scope` lets you limit where your styles apply. You pick a root element and your styles only affect things inside it.

### Live example

<example/>

### Basic scoping

Suppose you want to style links, but only the ones inside a `.card`:

```fsharp
let cardLinks =
    fss [
        Scope.scope ".card" [
            Color.blue
            TextDecoration.underline
        ]
    ]
```

This generates `@scope (.card) { ... }`. The styles only apply to elements inside `.card`. Links in the navbar, footer, or anywhere else are untouched.

### Donut scope

Sometimes you want to style a region but *exclude* a nested part of it. For example, style everything inside `.card` but leave `.card-content` alone:

```fsharp
let cardChrome =
    fss [
        Scope.scopeTo ".card" ".card-content" [
            Color.gray
            FontSize.value (px 12)
        ]
    ]
```

This creates a "donut" shape: styles apply inside `.card` but stop at `.card-content`. The header and footer of the card get styled, but the main content area does not.

This is useful for component wrappers where you control the chrome (borders, padding, header) but the inner content comes from elsewhere and should keep its own styles.

### How scope differs from specificity

With regular CSS, if two selectors match the same element, the more specific one wins. With `@scope`, the *closer* scope wins instead. This is called proximity.

```fsharp
// Outer scope sets text to gray
let outer =
    fss [
        Scope.scope ".sidebar" [
            Color.gray
        ]
    ]

// Inner scope sets text to black
let inner =
    fss [
        Scope.scope ".card" [
            Color.black
        ]
    ]
```

If a `.card` sits inside a `.sidebar`, the text will be black because `.card` is closer. With regular CSS, you would need to worry about which selector is more specific. With scope, proximity decides.

### Implicit scope

If you want to scope styles to the current element without naming a specific selector:

```fsharp
let self =
    fss [
        Scope.implicit [
            Color.red
            FontWeight.bold
        ]
    ]
```

This generates `@scope { ... }` without a root selector.

### Combining scope with other features

Scope works alongside media queries, container queries, and layers:

```fsharp
let responsiveCard =
    fss [
        Scope.scope ".card" [
            Display.flex
            FlexDirection.column

            Media.query [ Media.MinWidth (px 768) ] [
                FlexDirection.row
            ]
        ]
    ]
```
