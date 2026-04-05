## Container queries

Media queries let you change styles based on the viewport. "If the *screen* is narrow, stack things vertically." That works fine when you control the whole page, but it falls apart with reusable components.

Picture a card component. It lives in a wide main content area and looks great with a horizontal layout. Now you reuse that same card in a narrow sidebar. The screen has not changed size, so your media query does not fire, and the card looks broken.

Container queries fix this. Instead of asking "how wide is the screen?", they ask "how wide is the element I am inside?"

### How it works

There are two steps.

**First**, mark a parent element as a "container" so the browser knows its size can be queried:

```fsharp
let wrapper =
    fss [ ContainerType.inlineSize ]
```

**Second**, inside any child, use `Container.query` to respond to that container's size:

```fsharp
let card =
    fss [
        Display.flex
        FlexDirection.column

        Container.query [ Container.MinWidth (px 500) ] [
            FlexDirection.row
        ]
    ]
```

When the container is at least 500px wide, the card switches to a horizontal layout. When it shrinks below 500px, it goes back to vertical. The viewport size does not matter at all.

### Live example

Drag the slider to resize the container. The cards inside will rearrange themselves:

<example/>

Notice how the layout changes even though your browser window stays the same size. That is the whole point.

### Named containers

When you have nested containers, the query targets the nearest one by default. If you need to target a specific ancestor, give it a name:

```fsharp
let sidebar =
    fss [
        ContainerType.inlineSize
        ContainerName.value "sidebar"
    ]

let widget =
    fss [
        Container.queryNamed "sidebar"
            [ Container.MinWidth (px 300) ]
            [ Display.grid ]
    ]
```

The widget will always query the "sidebar" container, even if there is another container in between.

### Container shorthand

You can set both the name and type in a single property:

```fsharp
fss [ ContainerShorthand.value("sidebar", "inline-size") ]
```

### Container query units

Containers also introduce new length units. These are like `vw` and `vh`, but relative to the container instead of the viewport:

| Unit | Meaning |
|------|---------|
| `cqw` | 1% of the container's width |
| `cqh` | 1% of the container's height |
| `cqi` | 1% of the container's inline size |
| `cqb` | 1% of the container's block size |

They work anywhere you would use `px`, `em`, or `rem`:

```fsharp
fss [
    FontSize.value (cqi 5)    // scales with the container
    Padding.value (cqw 3)     // 3% of container width
    Width.value (cqw 50)      // half the container
]
```

This is powerful for truly responsive components. A heading can scale its font size relative to the card it sits in, not the page.

### What you can query

You can check these properties on a container:

```
Container.Width          Container.MinWidth          Container.MaxWidth
Container.Height         Container.MinHeight         Container.MaxHeight
Container.InlineSize     Container.MinInlineSize     Container.MaxInlineSize
Container.BlockSize      Container.MinBlockSize      Container.MaxBlockSize
Container.AspectRatio    Container.MinAspectRatio    Container.MaxAspectRatio
Container.Orientation
```

### Further reading

For a deep dive into container queries and why they matter, check out Josh Comeau's excellent [An Interactive Guide to CSS Container Queries](https://www.joshwcomeau.com/css/container-queries-introduction/).
