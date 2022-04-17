## Conditional Styling

If you want to style something conditionally you can use conditional or match expressions.
For example if you've defined a union type for your button sizes that looks like this:

```fsharp
type ButtonSize =
   | Small
   | Big
```

You could have a function that takes this `ButtonSize` as a parameter and spits out the styling you want.

```fsharp
let buttonStyle buttonType =
    fss
        [
            match buttonType with
               | Big ->
                   Height.value (px 80)
                   Width.value (px 80)
                | Small ->
                   Height.value (px 40)
                   Width.value (px 40)

        ]
button [ ClassName <| buttonStyle Small ] [ str "Small" ]
button [ ClassName <| buttonStyle Big ] [ str "Big" ]
```
<example/>

This works with any type of boolean expression and is really useful. 
It can be used to create vastly different CSS depending on certain parameters so you can optionally apply any type of CSS.
The following example doesnt do anything useful, but is helpful in describing what you can do with conditional styling in Fss.
```
let someRandomExample complexObject =
    fss 
        [
            if complexObject.isHoverable then
                Hover [ .... ]
            if complexObject.isRed then
                BackgroundColor.red
        ]
```