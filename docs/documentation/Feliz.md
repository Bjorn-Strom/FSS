## Feliz

After I started using Feliz and liking the API quite a bit I figured it was finally time to play around with a Feliz-specific syntax for Fss.
In order to use this specific syntax you need to install an additional Nuget package:
```
# nuget
dotnet add package Fss-lib-feliz

# paket
paket add Fss-lib-feliz --project ./project/path
```
While the codebase for this syntax is small I dont want to introduce any additional dependencies which arent needed for pure Fss. Therefore an extra package is needed.

## Using this syntax
If you know Fss already you write all the styling in a list and pass that into the `fss` function.
This is still true, but when you open the `Fss.Feliz` namespace you can access `fss` as a prop.

Here is a quick example of how that works.
```fsharp
Html.div [
    prop.fss [ BackgroundColor.red
               Width' <| px 200
               Height' <| px 200
               Hover [ BackgroundColor.blue ]
    ]
]
```

</example>

## What can you do with this?
Anything you can do in an `fss` block you can do in a `prop.fss` block.
For some things, like animations, you might not want to specify them inline as that would lead to some messy code, but we can define them outside of the DSL and use it.

```fsharp
Html.div [
    prop.fss [ BackgroundColor.red
               Width' <| px 200
               Height' <| px 200
               Hover [ BackgroundColor.blue ]
               AnimationName.Name bounceFrames
               AnimationDuration' <| sec 1.0
               AnimationTimingFunction.easeInOut
               AnimationIterationCount.infinite
    ]
]
```

</example>

## Helpers

In addition to the `fss` two other helpers have been added as well.

`fssWithClass` which can take in an already existing classname and an fss block. This will combine the two so you can use your existing styling in addition to fss.

`fssCombine` which is an implementation of JavaScripts `classNames` or Emotions `cx`.
The function takes a list of classnames to apply and a list of classnames/predicate tuples to optionally apply.
