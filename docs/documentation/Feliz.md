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

### Using this syntax
If you know Fss already you write all the styling in a list and pass that into the `fss` function.
This is still true, but when you open the `Fss.Feliz` namespace you can access `fss` as a prop.

Here is a quick example of how that works.
```fsharp
Html.div [
    prop.fss [ BackgroundColor.red
               Width' <| px 200
               Height' <| px 200
               Hover [ BackgroundColor.blue ]]
    ]
```

### What can you do with this?
Anything you can do in an `fss` block you can do in a `prop.fss` block.
For some things, like animations, you might not want to specify them inline as that would lead to some messy code, but we can define them outside of the DSL and use it.

```fsharp
Html.div [
    prop.fss [ BackgroundColor.red
               Width' <| px 200
               Height' <| px 200
               Hover [ BackgroundColor.blue ]
               AnimationName.Name bounceFrames
               AnimationDuration' (sec 1.0)
               AnimationTimingFunction.easeInOut
               AnimationIterationCount.infinite ]
   ]
```

