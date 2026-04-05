## Starting style

CSS transitions animate between two states. When you hover a button, it smoothly changes from blue to green. But what about the *first* time an element appears? There is no previous state to transition from, so the browser just snaps it into place. No animation.

`@starting-style` fixes this. It tells the browser: "When this element first appears, pretend it started with these styles, then transition to the real ones."

### Live example

<example/>

### The problem

Here is a card that fades in when it appears on the page:

```fsharp
let card =
    fss [
        Opacity.value 1.0
        TransitionProperty.opacity
        TransitionDuration.value (ms 500.)
    ]
```

This does not actually fade in. The card just appears at full opacity. The transition has nothing to animate *from* because the element did not exist a moment ago.

### The fix

Add a `StartingStyle` block to define where the transition should begin:

```fsharp
let card =
    fss [
        Opacity.value 1.0
        TransitionProperty.opacity
        TransitionDuration.value (ms 500.)

        StartingStyle.style [
            Opacity.value 0.0
        ]
    ]
```

Now when the card first appears, the browser sets its opacity to 0 (the starting style) and then transitions it to 1 (the real style). You get a smooth fade-in.

### Entry animations without keyframes

Before `@starting-style`, the only way to animate an element's entrance was with `@keyframes`. That works, but it is heavier than it needs to be for simple cases:

```fsharp
// The old way: define a keyframe animation
let fadeIn =
    keyframes [
        frame 0 [ Opacity.value 0.0 ]
        frame 100 [ Opacity.value 1.0 ]
    ]

let card =
    fss [
        AnimationName.value fadeIn
        AnimationDuration.value (ms 500.)
    ]

// The new way: just set a starting style
let card =
    fss [
        Opacity.value 1.0
        TransitionProperty.opacity
        TransitionDuration.value (ms 500.)
        StartingStyle.style [ Opacity.value 0.0 ]
    ]
```

The starting style approach is simpler and reuses the same transition system you already use for hovers and state changes.

### Animating from display none

One of the most common uses is making elements animate in when they go from `display: none` to visible. Previously, this was impossible with CSS transitions because changing `display` skips the transition entirely.

With `@starting-style`, the browser knows what the "before" state should be, even when the element was hidden:

```fsharp
let dialog =
    fss [
        Opacity.value 1.0
        TransitionProperty.opacity
        TransitionDuration.value (ms 300.)

        StartingStyle.style [
            Opacity.value 0.0
        ]
    ]
```

When this element goes from `display: none` to `display: block`, it will fade in smoothly instead of popping in.

### Multiple properties

You can set starting values for any properties that have transitions:

```fsharp
let slideIn =
    fss [
        Opacity.value 1.0
        TransformOrigin.center
        Transform.value [ Transform.translateY(px 0) ]
        TransitionProperty.all
        TransitionDuration.value (ms 400.)

        StartingStyle.style [
            Opacity.value 0.0
            Transform.value [ Transform.translateY(px 20) ]
        ]
    ]
```

This element fades in and slides up at the same time.
