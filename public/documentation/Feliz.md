## Fss.Feliz

## Installation

```
# nuget
dotnet add package Fss-lib.Feliz
```

## Usage
As this is built on `Fss.Fable` all functions that library defines are also available here, in addition to that
you can also write Fss with Feliz syntax.

Here is a quick example of how that works.
```fsharp
Html.div [
    prop.fss [ BackgroundColor.red
               Width.value (px 200)
               Height.value (px 200)
               Hover [ 
                BackgroundColor.blue 
               ] 
             ] 
    ]
```

<example/>

## What can you do with this?
Anything you can do in an `fss` block you can do in a `prop.fss` block.
While you would want to specify shared styling outside of a component, you can still do anything inline if you want.

```fsharp
Html.div [ 
    prop.fss [ BackgroundColor.red
               Width.value (px 200)
               Height.value (px 200)
               Hover [ BackgroundColor.blue ]
               AnimationName.value bounceFrames
               AnimationDuration.value (sec 1.0)
               AnimationTimingFunction.easeInOut
               AnimationIterationCount.infinite 
             ] 
   ]
```

<example/>

## Helpers

In addition to the `fss` two other helpers have been added as well.

`fssWithClass` which can take in an already existing classname and an fss block. This will combine the two so you can use your existing styling in addition to fss.

```fsharp
// Just a list of CssProperties without calling `fss`
let anAnimation =
    [
        AnimationName.name bounceFrames
        AnimationDuration.value sec 1.0
        AnimationTimingFunction.easeInOut
        AnimationIterationCount.infinite
    ]

// Generates CSS and returns a classname
let someStyle =
    fss [
       BackgroundColor.red
       Width.value (px 200)
       Height.value (px 200)
       Hover [ BackgroundColor.blue ]
    ]

Html.div [
    prop.fssWithClass someStyle anAnimation
]
```

This is useful for combining some shared code with existing styles.

`fssCombine` which is an implementation of JavaScripts `classNames` or Emotions `cx`.
The function takes a list of classnames to apply and a list of classnames/predicate tuples to optionally apply.

```fsharp
Html.div [
    // someStyle will be applied as it is true
    // someOtherStyle will not be applied as it is false
    // The red background color will always be applied
    // Naturally these boolean can be swapped with any bool or a function returning one
    prop.fssCombine [someStyle, true; someOtherStyle, false] [ BackgroundColor.red ]
]
```
