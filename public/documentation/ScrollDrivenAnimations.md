## Scroll-driven animations

Normally, CSS animations run on a timer. They start, play for a set duration, and stop. Scroll-driven animations replace that timer with scroll position. Instead of "play this over 2 seconds", you say "play this as the user scrolls from here to there."

This lets you build effects like progress bars that fill as you read, elements that fade in as they scroll into view, or parallax effects, all with pure CSS. No JavaScript scroll listeners, no requestAnimationFrame, no jank.

### Live example

<example/>

### Two types of scroll timelines

There are two ways to drive an animation with scrolling:

**Scroll progress timeline** tracks how far a scroll container has been scrolled. At the top the animation is at 0%, at the bottom it is at 100%.

**View progress timeline** tracks an element's visibility within the scrollport. When the element starts entering the viewport the animation begins. When it finishes leaving, the animation ends.

### Scroll progress: reading progress bar

Here is a progress bar that fills as the user scrolls down the page:

```fsharp
// Define the animation: grow from 0% to 100% width
let grow =
    keyframes [
        frame 0 [ Width.value (pct 0) ]
        frame 100 [ Width.value (pct 100) ]
    ]

// Tie the animation to the page scroll position
let progressBar =
    fss [
        AnimationName.value grow
        AnimationTimingFunction.linear
        AnimationFillMode.forwards
        AnimationTimeline.scroll(ScrollTimeline.Root)
        Position.fixed'
        Top.value (px 0)
        Left.value (px 0)
        Height.value (px 4)
        BackgroundColor.blue
    ]
```

As the user scrolls down, the bar fills. Scroll back up and it shrinks. The animation is not running on a timer. It is directly tied to how far the page has been scrolled.

You can control which scroller and which axis to track:

```fsharp
// Track the root scroller (the page itself)
AnimationTimeline.scroll(ScrollTimeline.Root)

// Track horizontal scrolling of the nearest scrollable ancestor
AnimationTimeline.scroll(ScrollTimeline.Nearest, ScrollTimeline.X)

// Track the element's own scroll position
AnimationTimeline.scroll(ScrollTimeline.Self, ScrollTimeline.Block)
```

The scroller options are:
- `ScrollTimeline.Nearest` finds the closest scrollable ancestor (default)
- `ScrollTimeline.Root` uses the document viewport
- `ScrollTimeline.Self` uses the element's own scrollbar

The axis options are:
- `ScrollTimeline.Block` vertical in horizontal writing modes (default)
- `ScrollTimeline.Inline` horizontal in horizontal writing modes
- `ScrollTimeline.X` always horizontal
- `ScrollTimeline.Y` always vertical

### View progress: fade in on scroll

Here is an element that fades in as it scrolls into the viewport:

```fsharp
let fadeIn =
    keyframes [
        frame 0 [ Opacity.value 0.0; Transform.value [ Transform.translateY(px 30) ] ]
        frame 100 [ Opacity.value 1.0; Transform.value [ Transform.translateY(px 0) ] ]
    ]

let animateOnScroll =
    fss [
        AnimationName.value fadeIn
        AnimationTimingFunction.linear
        AnimationFillMode.both
        AnimationTimeline.view()
        AnimationRange.value ScrollTimeline.Entry
    ]
```

Every element with the `animateOnScroll` class will start invisible and 30px below its final position. As it enters the viewport, it fades in and slides up. This is the CSS-only version of all those "animate on scroll" JavaScript libraries.

### Animation range

By default, a scroll-driven animation plays across the entire scroll distance or the entire time the element is visible. That is usually too much. `AnimationRange` lets you pick a subset.

For example, you probably want the fade-in to finish by the time the element is fully in view, not when it is halfway out the other side:

```fsharp
// Only animate during the "entry" phase (element scrolling into view)
fss [
    AnimationName.value fadeIn
    AnimationTimingFunction.linear
    AnimationFillMode.both
    AnimationTimeline.view()
    AnimationRange.value ScrollTimeline.Entry
]

// Animate between 10% and 90% of the entry phase for a subtler effect
fss [
    AnimationName.value fadeIn
    AnimationTimingFunction.linear
    AnimationFillMode.both
    AnimationTimeline.view()
    AnimationRange.value(ScrollTimeline.Entry, pct 10, ScrollTimeline.Entry, pct 90)
]
```

You can also set start and end separately:

```fsharp
fss [
    AnimationName.value fadeIn
    AnimationTimingFunction.linear
    AnimationFillMode.both
    AnimationTimeline.view()
    AnimationRangeStart.value ScrollTimeline.Entry
    AnimationRangeEnd.value ScrollTimeline.Cover
]
```

The range keywords are:
- `Cover` the full range while any part of the element is visible
- `Contain` the range where the element is fully visible
- `Entry` while the element is entering the viewport
- `Exit` while the element is leaving
- `EntryCrossing` while the element crosses the start edge
- `ExitCrossing` while the element crosses the end edge

### Named timelines

If you need an animation to follow a scroller that is not a direct ancestor, give the scroller a name:

```fsharp
// Define a keyframe for the indicator
let fillUp =
    keyframes [
        frame 0 [ Height.value (pct 0) ]
        frame 100 [ Height.value (pct 100) ]
    ]

// The scrollable element
let scroller =
    fss [
        ScrollTimelineName.value "--hero-scroll"
        ScrollTimelineAxis.block
        OverflowY.auto
        Height.value (px 400)
    ]

// An indicator elsewhere in the DOM tracks the scroller
let indicator =
    fss [
        AnimationName.value fillUp
        AnimationTimingFunction.linear
        AnimationFillMode.forwards
        AnimationTimeline.named "--hero-scroll"
        Width.value (px 4)
        BackgroundColor.blue
    ]
```

This also works for view timelines with `ViewTimelineName` and `ViewTimelineAxis`.
