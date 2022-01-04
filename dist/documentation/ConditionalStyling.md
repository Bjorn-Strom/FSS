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